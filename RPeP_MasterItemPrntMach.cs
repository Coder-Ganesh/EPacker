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

    public partial class RPeP_MasterItemPrntMach : Form
    {
        string session, strSQL, Group_ID;  
        private FunctionLib funclib;

        public RPeP_MasterItemPrntMach()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdEdit.Visible = false;
            txtPrntMach_ID.Visible = false;
        }

        private void RPeP_MasterItemPrntMach_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);          

            //Displaying value in ActiveCombo field           
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlPrntMach_Active.DataSource = dtActive;
            ddlPrntMach_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlPrntMach_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void txtPrntMach_Size_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPrntMach_Size Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtPrntMach_Printg_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPrntMach_Printg Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPrntMach_PlateSgl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPrntMach_PlateSgl Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPrntMach_PlateSgl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPrntMach_PlateSgl2 Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrntMach_Size.Text == "")//checking for blank Machine Size text field 
                {
                    MessageBox.Show("Please Enter Machine Size");
                    txtPrntMach_Size.Focus();
                }
                else if (txtPrntMach_Printg.Text == "")//checking for blank Printing Machine text field 
                {
                    MessageBox.Show("Please Enter Printing Machine");
                    txtPrntMach_Printg.Focus();
                }
                else if (txtPrntMach_PlateSgl.Text == "")//checking for PrintingMachinePlate text field 
                {
                    MessageBox.Show("Please enter Printing Machine Plate");
                    txtPrntMach_PlateSgl.Focus();
                }
                else if (txtPrntMach_PlateSgl2.Text == "")//checking for PrintingMachinePlate2 text field 
                {
                    MessageBox.Show("Please enter Printing Machine Plate2");
                    txtPrntMach_PlateSgl2.Focus();
                }
                else if (ddlPrntMach_Active.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Active");
                    ddlPrntMach_Active.Focus();
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
                        double flag = funclib.isThere(con, "select Grp_ID,PrntMach_Size,PrntMach_Printg,PrntMach_PlateSgl,PrntMach_PlateDbl from Item_PrntMach_Master where PrntMach_Size='" + txtPrntMach_Size.Text + "'and Grp_ID='" + Group_ID + "'and PrntMach_Printg  ='" + txtPrntMach_Printg.Text + "' and PrntMach_PlateSgl='" + txtPrntMach_PlateSgl.Text + "'and PrntMach_PlateDbl='" + txtPrntMach_PlateSgl2.Text + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Group,Type,First 100 Inches and Additional Inch is not allowed");
                        }
                        else
                        {
                            //Inserting Details into table Item_PrntMach_Master
                            string pid = funclib.AutoKey1("PR", con, "select PrntMach_ID from Item_PrntMach_Master order by PrntMach_ID desc");
                            SqlCommand cmd = new SqlCommand("insert into Item_PrntMach_Master values('" + pid + "','" + Group_ID + "','" + txtPrntMach_Size.Text + "','" + txtPrntMach_Printg.Text.Trim().Replace("'", "''").ToString() + "','" + txtPrntMach_PlateSgl.Text.Trim().Replace("'", "''").ToString() + "','" + txtPrntMach_PlateSgl2.Text.Trim().Replace("'", "''").ToString() + "','" + ddlPrntMach_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
            //to fill the Datagridview with user details named dgwItem_PrntMach_Master.
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.PrntMach_ID as PrntMach_ID,b.Grp_Name as GroupName,a.PrntMach_Size as MachineSize,a.PrntMach_Printg  as MachinePrint,a.PrntMach_PlateSgl as PrintPlate,a.PrntMach_PlateDbl as PlateDbl,a.PrntMach_Active as Active ,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On from Item_PrntMach_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_PrntMach_Master.DataSource = dt;
            this.dgwItem_PrntMach_Master.Columns[0].Visible = false;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //Update data in table Item_PrntMach_Master. 
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Item_PrntMach_Master set PrntMach_Size  ='" + txtPrntMach_Size.Text + "',PrntMach_Printg   ='" + txtPrntMach_Printg.Text + "',PrntMach_PlateSgl   ='" + txtPrntMach_PlateSgl.Text + "',PrntMach_PlateDbl='" + txtPrntMach_PlateSgl2.Text + "', PrntMach_Active ='" + ddlPrntMach_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where PrntMach_ID  ='" + txtPrntMach_ID.Text + "'", con);
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

        private void dgwItem_PrntMach_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ddlGrp_ID.Enabled = false;
            txtPrntMach_Printg.Enabled = false;
            txtPrntMach_PlateSgl.Enabled = false;
            txtPrntMach_PlateSgl2.Enabled = false;
            ddlPrntMach_Active.Enabled = true;
            cmdEdit.Visible = true;
            cmdSubmit.Visible = false;
            //to display data in form on click of datagridview named dgwItem_PrntMach_Master 
            txtPrntMach_ID.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPrntMach_Size.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrntMach_Printg.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPrntMach_PlateSgl.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPrntMach_PlateSgl2.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlPrntMach_Active.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            txtPrntMach_PlateSgl.Clear();
            txtPrntMach_PlateSgl2.Clear();
            txtPrntMach_Printg.Clear();
            txtPrntMach_Size.Clear();
            ddlGrp_ID.Text = "";
            ddlGrp_ID.Enabled = true;
            txtPrntMach_Size.Enabled = true;
            txtPrntMach_Printg.Enabled = true;
            txtPrntMach_PlateSgl.Enabled = true;
            txtPrntMach_PlateSgl2.Enabled = true;
            ddlPrntMach_Active.Enabled = true;
            cmdEdit.Visible = false;
            cmdSubmit.Visible = true;
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            //Code to call MasterItemPrntMach form with all blank fields to enter new entry
            clearAll();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search Group Name data from table Item_PrntMach_Master
            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            //SqlConnection con = new SqlConnection(strcon);
            //SqlDataAdapter da = new SqlDataAdapter("select b.Grp_Name,a.PrntMach_Size,a.PrntMach_Printg,a.PrntMach_PlateSgl,a.PrntMach_PlateDbl from Item_PrntMach_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%'and a.Grp_ID=b.Grp_ID order by b.Grp_Name,a.PrntMach_Size", con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dgwItem_PrntMach_Master.DataSource = dt;
            //if (dgwItem_PrntMach_Master.Rows.Count == 0)
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
            //Application.Exit();
            //Code to close MasterItemPrntMach form temporarily.
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
                        System.Data.DataTable table = dgwItem_PrntMach_Master.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Item Print Machine Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwItem_PrntMach_Master.Columns.Count])
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
