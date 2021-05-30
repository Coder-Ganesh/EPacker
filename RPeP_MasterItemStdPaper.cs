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
    public partial class RPeP_MasterItemStdPaper : Form
    {
        private FunctionLib funclib;
        string session, strSQL, Group_ID;

        public RPeP_MasterItemStdPaper()
        {

            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdUpdate.Enabled = false;
            cmdUpdate.Visible = false;
            cmdSubmit.Visible = true;
        }

        private void RPeP_MasterItemStdPaper_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            //Displaying value in Active field
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlStdPaper_Active.DataSource = dtActive;
            ddlStdPaper_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlStdPaper_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void txtStdPaper_Length_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating length of Paper
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtStdPaper_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Width of Paper
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStdPaper_Length.Text == "")//checking for Paper Length field 
                {
                    MessageBox.Show("Please Top Paper Length");
                    txtStdPaper_Length.Focus();
                }
                else if (txtStdPaper_Width.Text == "")//checking for Paper Width 
                {
                    MessageBox.Show("Please enter Paper Width");
                    txtStdPaper_Width.Focus();
                }
                else if (ddlStdPaper_Active.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Active");
                    ddlStdPaper_Active.Focus();
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
                        double flag = funclib.isThere(con, "select Grp_ID,StdPaper_Length,StdPaper_Width  from Item_StdPaper_Master where StdPaper_Length='" + txtStdPaper_Length.Text + "'and Grp_ID='" + Group_ID + "'and StdPaper_Width='" + txtStdPaper_Width.Text + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Group, Length and Width is not allowed");
                        }
                        else
                        {
                            //Inserting Details into table
                            string spid = funclib.AutoKey1("SP", con, "select StdPaper_ID  from Item_StdPaper_Master order by StdPaper_ID desc");
                            SqlCommand cmd = new SqlCommand("insert into Item_StdPaper_Master values('" + spid + "','" + Group_ID + "','" + txtStdPaper_Length.Text.Trim().Replace("'", "''").ToString() + "','" + txtStdPaper_Width.Text.Trim().Replace("'", "''").ToString() + "','" + ddlStdPaper_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
            //to fill the grid with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.StdPaper_ID  as StdPaperID,b.Grp_Name as GroupName,a.StdPaper_Length  as PaperLength,a.StdPaper_Width  as StdPaperWidth,a.StdPaper_Active  as Active,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On from Item_StdPaper_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_StdPaper_Master.DataSource = dt;
            this.dgwItem_StdPaper_Master.Columns[0].Visible = false;
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("update Item_StdPaper_Master set StdPaper_Length ='" + txtStdPaper_Length.Text + "',StdPaper_Width='" + txtStdPaper_Width.Text + "',StdPaper_Active ='" + ddlStdPaper_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where StdPaper_ID ='" + txtStdPaper_ID.Text + "'", con);
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

        private void dgwItem_StdPaper_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtStdPaper_Length.Enabled = false;
            txtStdPaper_Width.Enabled = false;
            ddlGrp_ID.Enabled = false;
            cmdUpdate.Enabled = true;
            cmdUpdate.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlStdPaper_Active.Enabled = true;
            txtStdPaper_ID.Text = dgwItem_StdPaper_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtStdPaper_Length.Text = dgwItem_StdPaper_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtStdPaper_Width.Text = dgwItem_StdPaper_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlStdPaper_Active.Text = dgwItem_StdPaper_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void clearAll()
        {
            txtStdPaper_Length.Clear();
            txtStdPaper_Width.Clear();
            txtStdPaper_ID.Clear();
            ddlGrp_ID.Text = "";
            txtStdPaper_Length.Enabled = true;
            txtStdPaper_Width.Enabled = true;
            ddlGrp_ID.Enabled = true;
            ddlStdPaper_Active.Enabled = false;
            //ddlStdPaper_Active.SelectedText = "Yes";
            ddlStdPaper_Active.SelectedIndex = 0;
            cmdUpdate.Enabled = false;
            cmdSubmit.Enabled = true;
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select b.Grp_Name,a.StdPaper_Length,a.StdPaper_Width,a.StdPaper_Active from Item_StdPaper_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%' and a.Grp_ID=b.Grp_ID order by b.Grp_Name,a.StdPaper_Length,a.StdPaper_Width", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_StdPaper_Master.DataSource = dt;
            if (dgwItem_StdPaper_Master.Rows.Count == 0)
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
            //Code to close MasterItemStdPaper form temporarily
            this.Close();
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
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
                            System.Data.DataTable table = dgwItem_StdPaper_Master.DataSource as DataTable;
                            System.Data.DataTable filtered = table.DefaultView.ToTable();
                            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Item BF Master");
                            ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                            using (ExcelRange rng = ws.Cells[1, 1, 1, dgwItem_StdPaper_Master.Columns.Count])
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
}
