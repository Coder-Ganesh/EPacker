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
    //Page Developed by 
    public partial class RPeP_MasterItemLamint : Form
    {
        string session, strSQL, Group_ID; 
        private FunctionLib funclib;

        public RPeP_MasterItemLamint()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdUpdate.Enabled = false;
            cmdUpdate.Visible = false;
            txtLamint_ID.Visible = false;
        }

        private void RPeP_MasterItemLamint_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);

            //Displaying value in ActiveCombo field
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlLamint_Active.DataSource = dtActive;
            ddlLamint_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlLamint_Active.ValueMember = dtActive.Columns[0].ToString();

            //Displaying value in Lamination Type Combo field
            DataTable dtLamType = new DataTable();
            GlobalFunctions.AddLaminationTypesOptions(ref dtLamType);
            ddlLamint_Type.DataSource = dtLamType;
            ddlLamint_Type.DisplayMember = dtLamType.Columns[0].ToString();
            ddlLamint_Type.ValueMember = dtLamType.Columns[0].ToString();

            //Displaying value in Thickness Combo field
            DataTable dtLamThick = new DataTable();
            GlobalFunctions.AddLaminationThickness(ref dtLamThick);
            ddlLamint_Thick.DataSource = dtLamThick;
            ddlLamint_Thick.DisplayMember = dtLamThick.Columns[0].ToString();
            ddlLamint_Thick.ValueMember = dtLamThick.Columns[0].ToString();           
        }

        private void txtLamint_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtLamint_Rate Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlLamint_Type.SelectedIndex == 0)//checking for blank Lamination Type combo field 
                {
                    MessageBox.Show("Please Select Lamination Type");
                    ddlLamint_Type.Focus();
                }
                else if (ddlLamint_Thick.SelectedIndex == 0)//checking for blank lamination thickness combo field 
                {
                    MessageBox.Show("Please select lamination thickness");
                    ddlLamint_Thick.Focus();
                }
                else if (txtLamint_Rate.Text == "")//checking for blank Lamination Rate Text field 
                {
                    MessageBox.Show("Please enter Lamination Rate");
                    txtLamint_Rate.Focus();
                }
                else if (ddlLamint_Active.SelectedIndex == 0)//checking for blank Active 
                {
                    MessageBox.Show("Please select Active");
                    ddlLamint_Active.Focus();
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
                        double flag = funclib.isThere(con, "select Grp_ID,Lamint_Type,Lamint_Thick from Item_Lamint_Master where Lamint_Type ='" + ddlLamint_Type.SelectedValue.ToString() + "'and Grp_ID='" + Group_ID + "'and Lamint_Thick ='" + ddlLamint_Thick.SelectedItem.ToString() + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Group,Type,First 100 Inches and Additional Inch is not allowed");
                        }
                        else
                        {
                            //Inserting Details into table Item_Lamint_Master
                            string lmid = funclib.AutoKey1("LM", con, "select Lamint_ID from Item_Lamint_Master order by Lamint_ID desc");
                            SqlCommand cmd = new SqlCommand("insert into Item_Lamint_Master values('" + lmid + "','" + Group_ID + "','" + ddlLamint_Type.SelectedValue.ToString() + "','" + ddlLamint_Thick.SelectedValue.ToString() + "','" + txtLamint_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + ddlLamint_Active.Text + "','" + session + "', '',convert(datetime,getdate(),103),'','','')", con);
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
            //to fill the Datagridview with user details named dgwItem_Lamint_Master 
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.Lamint_ID as LaminationID,b.Grp_Name as GroupName,a.Lamint_Type as LaminationType,a.Lamint_Thick as LaminationThick ,a.Lamint_Rate  as Rate,a.Lamint_Active as Active ,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On from Item_Lamint_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_Lamint_Master.DataSource = dt;
            this.dgwItem_Lamint_Master.Columns[0].Visible = false;
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Update data in table Item_Lamint_Master
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Item_Lamint_Master set Lamint_Type ='" + ddlLamint_Type.SelectedValue.ToString() + "',Lamint_Thick  ='" + ddlLamint_Thick.SelectedValue.ToString() + "',Lamint_Rate  ='" + txtLamint_Rate.Text + "',Lamint_Active ='" + ddlLamint_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Lamint_ID ='" + txtLamint_ID.Text + "'", con);
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

        private void dgwItem_Lamint_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {           
            ddlLamint_Thick.Enabled = false;
            ddlLamint_Type.Enabled = false;
            cmdUpdate.Enabled = true;
            cmdUpdate.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlLamint_Active.Enabled = true;        
            //To Display data in form on click of Datagridview named dgwItem_Lamint_Master
            txtLamint_ID.Text = dgwItem_Lamint_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            ddlLamint_Type.Text = dgwItem_Lamint_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlLamint_Thick.Text = dgwItem_Lamint_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtLamint_Rate.Text = dgwItem_Lamint_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlLamint_Active.Text = dgwItem_Lamint_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            ddlLamint_Type.SelectedIndex = 0;
            ddlLamint_Thick.SelectedIndex = 0;
            txtLamint_Rate.Clear();            
            ddlGrp_ID.Enabled = true;
            ddlLamint_Thick.Enabled = true;
            ddlLamint_Type.Enabled = true;
            cmdUpdate.Enabled = false;
            cmdUpdate.Visible = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            ddlLamint_Active.Enabled = true;
            ddlLamint_Active.SelectedIndex = 0;
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            //Code to call MasterItemLamint form with all blank fields to enter new entry
            clearAll();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            ////Search (Grp_Name) data from table Item_Lamint_Master
            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            //SqlConnection con = new SqlConnection(strcon);
            //SqlDataAdapter da = new SqlDataAdapter("select b.Grp_Name,a.Lamint_Type,a.Lamint_Thick,a.Lamint_Rate,a.Lamint_Active from Item_Lamint_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%'and a.Grp_ID=b.Grp_ID order by b.Grp_Name", con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dgwItem_Lamint_Master.DataSource = dt;
            //if (dgwItem_Lamint_Master.Rows.Count == 0)
            //{
            //    cmdExcelReport.Visible = false;
            //}
            //else
            //{
            //    cmdExcelReport.Visible = true;
            //}
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {            
            //Code to close MasterItemLamint form temporarily.
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
                        System.Data.DataTable table = dgwItem_Lamint_Master.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Item Lamination Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwItem_Lamint_Master.Columns.Count])
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
