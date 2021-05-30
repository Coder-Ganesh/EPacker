using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using ePacker1.Business_Logic;

namespace ePacker1
{
    public partial class RPeP_MasterPurchaseItem : Form
    {
        string session, strSQL, Group_ID;
        private FunctionLib funclib;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterPurchaseItem()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            cmdUpdate.Enabled = false;
            cmdUpdate.Visible = false;
            btnDelete.Visible = false;
            txtSI_ID.Visible = false;
            filldata();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string strValidationError = Validation();
                if (string.IsNullOrEmpty(strValidationError))
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //Checking for duplicate values
                        double flag = funclib.isThere(con, "select SI_Name,GRP_ID from Purchase_Item where GRP_ID='" + Group_ID + "' and SI_Name='" + txtSI_Name.Text + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Shift is not allowed");
                        }
                        else
                        {
                            txtSI_Name.Text = funclib.FirstCap(txtSI_Name.Text);
                            //Inserting Details into table
                            string Siid = funclib.SI_ID("SI", con, "select SI_ID from Purchase_Item order by SI_ID desc");
                            SqlCommand cmd = new SqlCommand("insert into Purchase_Item values('" + Siid + "','" + Group_ID + "','" + txtSI_Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_CuStock.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_MinLev.Text.Trim().Replace("'", "''").ToString() + "','" + ddlSI_UOM.SelectedValue.ToString() + "','" + ddlSI_Cate.Text + "','" + txtSI_ExcCode.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_ExcDesc.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_ChapTarNo.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_Procesg.Text.Trim().Replace("'", "''").ToString() + "','" + ddlSI_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Inserted");
                            filldata();
                            clearAll();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(strValidationError);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Inserting Data " + ex.Message);
            }
        }

        private void RPeP_MasterPurchaseItem_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            //Displayig UOM in Combo field
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT UOM_ID,UOM_Name from UOM_Master", con1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            GlobalFunctions.AddPleaseSelect(ref dt1);
            ddlSI_UOM.DataSource = dt1;
            ddlSI_UOM.DisplayMember = dt1.Columns[1].ToString();
            ddlSI_UOM.ValueMember = dt1.Columns[0].ToString();
            con1.Close();

            //Displaying value in Active field          
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlSI_Active.DataSource = dtActive;
            ddlSI_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlSI_Active.ValueMember = dtActive.Columns[0].ToString();

            DataTable dtSiCategory = new DataTable();
            GlobalFunctions.AddSiCategoryOptions(ref dtSiCategory);
            ddlSI_Cate.DataSource = dtSiCategory;
            ddlSI_Cate.DisplayMember = dtSiCategory.Columns[0].ToString();
            ddlSI_Cate.ValueMember = dtSiCategory.Columns[0].ToString();
        }

        private void txtSI_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);

        }

        private void txtSI_CuStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtSI_MinLev_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtSI_ExcCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);


        }

        private void txtSI_ChapTarNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);


        }

        private void txtSI_ExcDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);


        }

        private void txtSI_Procesg_KeyPress(object sender, KeyPressEventArgs e)
        {

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);

        }

        private void filldata()
        {
            try
            {
                //to fill the grid with user details
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select a.SI_ID,b.Grp_Name as GroupName,a.SI_Name as Store,a.SI_CuStock as CurrentStock,a.SI_MinLev as MinLevel,a.SI_Cate as category,c.UOM_Name as UOM,a.SI_ExcCode,a.SI_ExcDesc,a.SI_ChapTarNo,a.SI_Procesg,a.SI_Active from Purchase_Item as a,Group_Master as b,UOM_Master as c where a.Grp_ID=b.Grp_ID and a.SI_UOM=c.UOM_ID ", con4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading Grid " + ex.Message);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdUpdate.Enabled = true;
            cmdUpdate.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlSI_Active.Enabled = true;
            txtSI_Name.Enabled = false;
            txtSI_CuStock.Enabled = false;          
            //Display data in form on click of grid
            txtSI_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSI_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSI_CuStock.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSI_MinLev.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlSI_Cate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlSI_UOM.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtSI_ExcCode.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtSI_ExcDesc.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtSI_ChapTarNo.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtSI_Procesg.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            ddlSI_Active.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string strValidationError = Validation();
                    if (string.IsNullOrEmpty(strValidationError))
                    {
                        //Update data in table
                        string strcon = funclib.setConnection();
                        SqlConnection con = new SqlConnection(strcon);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("update Purchase_Item set SI_MinLev='" + txtSI_MinLev.Text + "', SI_UOM='" + ddlSI_UOM.SelectedValue.ToString() + "',SI_Cate ='" + ddlSI_Cate.Text + "',SI_ExcCode ='" + txtSI_ExcCode.Text + "',SI_ExcDesc='" + txtSI_ExcDesc.Text + "',SI_ChapTarNo ='" + txtSI_ChapTarNo.Text + "',SI_Procesg='" + txtSI_Procesg.Text + "',SI_Active='" + ddlSI_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where SI_ID='" + txtSI_ID.Text + "'", con);
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Updated");
                        filldata();
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show(strValidationError);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error " + ex.Message);
            }
        }

        private void clearAll()
        {
            txtSI_ID.Text = "";
            txtSI_Name.Text = "";           
            ddlSI_Cate.SelectedIndex = 0;
            txtSI_CuStock.Text = "";
            txtSI_ExcCode.Text = "";
            txtSI_ExcDesc.Text = "";
            txtSI_MinLev.Text = "";
            txtSI_Procesg.Text = "";         
            ddlSI_UOM.SelectedIndex = 0;
            txtSI_ChapTarNo.Text = "";
            ddlSI_Active.SelectedIndex = 0;
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //Search data from table
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select a.SI_ID,b.Grp_Name as GroupName,a.SI_Name as Store,a.SI_CuStock as CurrentStock,a.SI_MinLev as MinLevel,a.SI_Cate as category,c.UOM_Name as UOM,a.SI_ExcCode,a.SI_ExcDesc,a.SI_ChapTarNo,a.SI_Procesg,a.SI_Active from Purchase_Item as a,Group_Master as b,UOM_Master as c where a.Grp_ID=b.Grp_ID and a.SI_UOM=c.UOM_ID and a.SI_Name like '" + txtSearch.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Update data in table
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Purchase_Item  where SI_ID='" + txtSI_ID.Text + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted");
                    filldata();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error " + ex.Message);
            }
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            try
            {
                saveFileDialog1.InitialDirectory = "C:";
                saveFileDialog1.Title = "Save as Excel file";
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "Excel Files(2003) |*.xls|Excel Files(2007) |*.xlsx";
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        System.Data.DataTable table = dataGridView1.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Purchase Item Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dataGridView1.Columns.Count])
                        {
                            rng.Style.Font.Bold = true;
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }
                        FileInfo excelFile = new FileInfo(saveFileDialog1.FileName);
                        pck.SaveAs(excelFile);
                    }
                    MessageBox.Show("Data Exported Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while exporting excel  " + ex.Message);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private string Validation()
        {
            string strError = "";
            try
            {
                if (string.IsNullOrEmpty(txtSI_Name.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Purchase Item Name   ";
                }
                if (string.IsNullOrEmpty(txtSI_CuStock.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Current Stock    ";
                }
                if (ddlSI_UOM.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select UOM   ";
                }
                if (ddlSI_Cate.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Category   ";
                }
                if (string.IsNullOrEmpty(txtSI_ExcCode.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Excise Code   ";
                }
                if (string.IsNullOrEmpty(txtSI_ExcDesc.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Excise Description   ";
                }
                if (ddlSI_Active.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Active   ";
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show("There was an Error while Validating Values " + ex.Message);
            }
            return strError;
        }

    }
}
