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
    public partial class RPeP_MasterItemPunchMach : Form
    {
        string session, strSQL, Group_ID;  
        private FunctionLib funclib;

        public RPeP_MasterItemPunchMach()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdUpdate.Enabled = false;
            cmdUpdate.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void RPeP_MasterItemPunchMach_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);

            //Displaying value in Activecombo field
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlPunchMach_Active.DataSource = dtActive;
            ddlPunchMach_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlPunchMach_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPunchMach_Rate.Text == "")//checking for blank Punching Machine Rate text field 
                {
                    MessageBox.Show("Please Enter Punching Machine Rate");
                    txtPunchMach_Rate.Focus();
                }
                else if (txtPunchMach_Size.Text == "")//checking for blank Punching Machine Size text field 
                {
                    MessageBox.Show("Please enter Punching Machine Size");
                    txtPunchMach_Size.Focus();
                }
                else if (ddlPunchMach_Active.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Active");
                    ddlPunchMach_Active.Focus();
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
                        double flag = funclib.isThere(con, "select Grp_ID,PunchMach_Size,PunchMach_Rate from Item_PunchMach_Master where PunchMach_Size ='" + txtPunchMach_Size.Text + "'and Grp_ID='" + Group_ID + "'and PunchMach_Rate ='" + txtPunchMach_Rate.Text + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Group, Machine Size and Punching Rate is not allowed");
                        }
                        else
                        {
                            //Inserting Details into table Item_PunchMach_Master
                            string vid = funclib.AutoKey1("PM", con, "select PunchMach_ID  from Item_PunchMach_Master order by PunchMach_ID desc");
                            SqlCommand cmd = new SqlCommand("insert into Item_PunchMach_Master values('" + vid + "','" + Group_ID + "','" + txtPunchMach_Size.Text.Trim().Replace("'", "''").ToString() + "','" + txtPunchMach_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + ddlPunchMach_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
            //to fill the Datagridview with user details named dgwItem_PunchMach_Master. 
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.PunchMach_ID  as PunchMachID,b.Grp_Name as GroupName,a.PunchMach_Size  as PunchMachSize,a.PunchMach_Rate  as PunchMachRate ,a.PunchMach_Active as Active,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On from Item_PunchMach_Master a,Group_Master b where b.Grp_ID=a.Grp_ID  and a.Grp_ID = '" + Group_ID + "'  ", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_PunchMach_Master.DataSource = dt;
            this.dgwItem_PunchMach_Master.Columns[0].Visible = false;
        }

        private void txtPunchMach_Size_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPunchMach_Size text field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtPunchMach_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPunchMach_Rate text field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Update data in table Item_PunchMach_Master. 
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Item_PunchMach_Master set PunchMach_Size ='" + txtPunchMach_Size.Text + "',PunchMach_Rate  ='" + txtPunchMach_Rate.Text + "',PunchMach_Active ='" + ddlPunchMach_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where PunchMach_ID ='" + txtPunchMach_ID.Text + "'", con);
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

        private void dgwItem_PunchMach_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtPunchMach_Size.Enabled = false;
            txtPunchMach_Rate.Enabled = false;
            ddlGrp_ID.Enabled = false;
            cmdUpdate.Enabled = true;
            cmdUpdate.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlPunchMach_Active.Enabled = true;
            //to display data in form on click of datagridview named dgwItem_PunchMach_Master.
            txtPunchMach_ID.Text = dgwItem_PunchMach_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPunchMach_Size.Text = dgwItem_PunchMach_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPunchMach_Rate.Text = dgwItem_PunchMach_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlPunchMach_Active.Text = dgwItem_PunchMach_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            txtPunchMach_Size.Enabled = true;
            txtPunchMach_Rate.Enabled = true;
            ddlGrp_ID.Enabled = true;
            txtPunchMach_Size.Clear();
            txtPunchMach_Rate.Clear();
            cmdUpdate.Enabled = false;
            cmdUpdate.Visible = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            ddlPunchMach_Active.Enabled = true;
            ddlPunchMach_Active.SelectedIndex = 0;
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            // Code to call MasterItemPunchMach form with all blank fields to enter new entry.
            clearAll();            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search GroupName data from table Item_PunchMach_Master. 
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select b.Grp_Name,a.PunchMach_Size,a.PunchMach_Rate,a.PunchMach_Active from Item_PunchMach_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%'and a.Grp_ID=b.Grp_ID order by b.Grp_Name,a.PunchMach_Size", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_PunchMach_Master.DataSource = dt;
            if (dgwItem_PunchMach_Master.Rows.Count == 0)
            {
                cmdExcelReport.Visible = false;
            }
            else
            {
                cmdExcelReport.Visible = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Code to close MasterItemPunchMach form temporarily.
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
                        System.Data.DataTable table = dgwItem_PunchMach_Master.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Item Punch Machine Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwItem_PunchMach_Master.Columns.Count])
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
