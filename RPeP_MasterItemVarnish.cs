using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ePacker1.App_Code;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace ePacker1
{
    public partial class RPeP_MasterItemVarnish : Form
    {
        string session, strSQL, Group_ID; 
        private FunctionLib funclib;

        public RPeP_MasterItemVarnish()
        {
            InitializeComponent(); 
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            txtVarnish_ID.Visible = false;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
        }

        private void RPeP_MasterItemVarnish_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);          
            //Displaying value in Active field         
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlVarnish_Active.DataSource = dtActive;
            ddlVarnish_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlVarnish_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtVarnish_Type.Text))//checking for Varnish Type field 
                {
                    MessageBox.Show("Please Enter Varnish Type");
                    txtVarnish_Type.Focus();
                }
                else if (string.IsNullOrEmpty(txtRate.Text))
                {
                    MessageBox.Show("Please Enter Varnish Rate");
                    txtRate.Focus();
                }
                else if (ddlVarnish_Active.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Active");
                    ddlVarnish_Active.Focus();
                }
                else
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //Checking for duplicate values
                        double flag = funclib.isThere(con, "select Varnish_Type from Item_Varnish_Master where Varnish_Type ='" + txtVarnish_Type.Text + "'and Grp_ID='" + Group_ID + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Group,Type,First 100 Inches and Additional Inch is not allowed");
                        }
                        else
                        {
                            //Inserting Details into table
                            string vid = funclib.AutoKey1("VR", con, "select Varnish_ID from Item_Varnish_Master order by Varnish_ID desc");
                            SqlCommand cmd = new SqlCommand("insert into Item_Varnish_Master(Varnish_ID,Grp_ID,Varnish_Type,VarnishRate,Varnish_Active,Add_By,Add_On) values ('" + vid + "',  '" + Group_ID + "',    '" + txtVarnish_Type.Text.Replace(",", "") + "', '" + txtRate.Text + "', '" + ddlVarnish_Active.Text + "',   '" + session + "',convert(datetime,getdate(),103))",con);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Inserted");
                            filldata();
                            clearAll();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error " + ex.Message);
            }      
        }

        private void filldata()
        {
            try
            {
                //to fill the grid with user details
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select a.Varnish_ID as VarnishID,b.Grp_Name as GroupName,a.Varnish_Type as VarnishType,a.VarnishRate,a.Varnish_Active as Active,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On from Item_Varnish_Master a,Group_Master b where b.Grp_ID=a.Grp_ID and a.Grp_ID = '" + Group_ID + "' ", con4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgwItem_Varnish_Master.DataSource = dt;
                this.dgwItem_Varnish_Master.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading grid " + ex.Message);
            }         
        }

        private void txtVarnish_Type_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation for Varnish Type
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //Update data in table
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Item_Varnish_Master set Varnish_Type='" + txtVarnish_Type.Text + "',VarnishRate ='" + txtRate.Text + "',Varnish_Active='" + ddlVarnish_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Varnish_ID='" + txtVarnish_ID.Text + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                    filldata();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error " + ex.Message);
            }
        }

        private void dgwItem_Varnish_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtVarnish_Type.Enabled = false;
            txtRate.Enabled = false;
            ddlGrp_ID.Enabled = false;
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            btnDelete.Visible = false;
            ddlVarnish_Active.Enabled = true;
            //Display data in form on click of grid
            txtVarnish_ID.Text = dgwItem_Varnish_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtVarnish_Type.Text = dgwItem_Varnish_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtRate.Text = dgwItem_Varnish_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlVarnish_Active.Text = dgwItem_Varnish_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void clearAll()
        {
            txtVarnish_Type.Clear();
            txtVarnish_Type.Enabled = true;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            ddlVarnish_Active.Enabled = false;
            ddlVarnish_Active.SelectedIndex = 0;
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Update data in table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Item_Varnish_Master where Varnish_ID='" + txtVarnish_ID.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted");
                filldata();
                clearAll();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Code to close MasterItemVarnish form temporarily.
            this.Close();
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
                        System.Data.DataTable table = dgwItem_Varnish_Master.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Item Varnish Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwItem_Varnish_Master.Columns.Count])
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

    }
}
