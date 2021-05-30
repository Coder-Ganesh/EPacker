using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ePacker1.App_Code;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using ePacker1.Business_Logic;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace ePacker1
{
    public partial class RPeP_MasterPartyMain : Form
    {
        string session, strSQL, Group_ID;
        private FunctionLib funclib = new FunctionLib();
        AllBusinessLogic bl = new AllBusinessLogic();
        string strFirstCap;

        public RPeP_MasterPartyMain()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            BindPartyMainMasterDataToGrid();
            txtPM_ID.Visible = false;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
        }

        private void txttxtPM_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
            int Name_Data = funclib.countChar(e, txtPM_Name.Text);
            lblName_Desc.Text = "(Character " + Name_Data + "  " + "Out of" + txtPM_Name.MaxLength + ")";
        }

        private void RPeP_MasterPartyMain_Load(object sender, EventArgs e)
        {
            //to display data on Form load
            ddlPM_Active.SelectedText = "Yes";
            ddlPM_Active.Enabled = false;
            ddlPM_Active.Items.Add("Yes");
            ddlPM_Active.Items.Add("No");
            this.WindowState = FormWindowState.Maximized;
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPM_Name.Text == "")//checking for blank PM_Name text field 
                {
                    MessageBox.Show("Please enter Party name");
                    txtPM_Name.Focus();
                }
                else if (ddlPM_Active.Text == "")//checking for blank PM_Active Combo 
                {
                    MessageBox.Show("Please Select Active state");
                    ddlPM_Active.Focus();
                }
                else
                {
                    //Insert the details into the table
                    funclib = new FunctionLib();
                    strFirstCap = funclib.FirstCap(txtPM_Name.Text);
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //Checking for duplicate entries 
                        double flag = funclib.isThere(con, "select PM_Name,Grp_ID from PartyMain_Master where PM_Name='" + txtPM_Name.Text + "' and Grp_ID='" + Group_ID + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Party (Main) Name and Group is not allowed");
                        }
                        else
                        {
                            string pid = funclib.AutoKey1("PM", con, "select PM_ID from PartyMain_Master order by PM_ID desc");
                            bool result = AddEditDeletePartyMainMasterData("A", pid);
                            if (result)
                            {
                                MessageBox.Show("Record Inserted Sucessfully");
                            }
                            else
                            { MessageBox.Show("There was an error while inserting data"); }
                            BindPartyMainMasterDataToGrid();
                            clearAll();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while inserting data " + ex.Message);
            }
           
        }

        private void BindPartyMainMasterDataToGrid()
        {
            try
            {
                DataTable dtAllPartyMainMasterData = bl.GetAllPartyMainMasterData(Group_ID);
                if (dtAllPartyMainMasterData != null)
                {
                    dgwRPeP_MasterPartyMain.DataSource = dtAllPartyMainMasterData;
                    this.dgwRPeP_MasterPartyMain.Columns[0].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while fetching Party Main Master Data " + ex.Message); }
        }        

        private void dgwRPeP_MasterPartyMain_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //to display data in form on click of datagridview
                ddlPM_Active.Enabled = true;
                cmdEdit.Enabled = true;
                cmdEdit.Visible = true;
                btnDelete.Visible = true;
                cmdSubmit.Enabled = false;
                cmdSubmit.Visible = false;
                txtPM_ID.Text = dgwRPeP_MasterPartyMain.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPM_Name.Text = dgwRPeP_MasterPartyMain.Rows[e.RowIndex].Cells[1].Value.ToString();
                ddlPM_Active.Text = dgwRPeP_MasterPartyMain.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while displaying data from DataGridView " + ex.Message);         
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                txtPM_Name.Text = funclib.FirstCap(txtPM_Name.Text);
                if (string.IsNullOrEmpty(txtPM_Name.Text))//checking for blank PQ_Rate text field 
                {
                    MessageBox.Show("Please enter Paper Name");
                    txtPM_Name.Focus();
                }
                else
                {
                    if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool result = AddEditDeletePartyMainMasterData("E", txtPM_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        BindPartyMainMasterDataToGrid();
                        clearAll();
                    }
                    else
                    {
                        cmdSubmit.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while updating data " + ex.Message);
            }           
        }

        private void clearAll()
        {
            //Clear all fields
            txtPM_Name.Clear();
            ddlGrp_ID.Text = "";
            ddlPM_Active.Text = "";
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            ddlPM_Active.SelectedText = "Yes";
            ddlPM_Active.Enabled = false;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select PM_ID as PartID,PM_Name as PartyName,Grp_Name as GroupName,PM_Active as PartyActive, a.Add_By ,a.Add_On ,a.Mod_By ,a.Mod_On as ModOn from PartyMain_Master a, Group_Master b  where PM_Name like '%" + txtNameSearch.Text
                    + "%'" + " and b.Grp_ID=a.Grp_ID and b.Grp_ID = '" + Group_ID + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgwRPeP_MasterPartyMain.DataSource = dt;
                this.dgwRPeP_MasterPartyMain.Columns[0].Visible = false;
                if (dgwRPeP_MasterPartyMain.Rows.Count == 0)
                {
                    cmdExcelReport.Visible = false;
                }
                else
                {
                    cmdExcelReport.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while fetching data " + ex.Message);
            }          
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
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
                        System.Data.DataTable table = dgwRPeP_MasterPartyMain.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("PartyMainMaster");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwRPeP_MasterPartyMain.Columns.Count])
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
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = AddEditDeletePartyMainMasterData("D", txtPM_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    BindPartyMainMasterDataToGrid();
                    clearAll();
                }
                else
                {
                    cmdSubmit.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while deleting data  " + ex.Message);
            }
        }

        private bool AddEditDeletePartyMainMasterData(string action, string PMM_Id)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("PMM_Id", PMM_Id);
                dictionaryInstance.Add("PMM_Name", Convert.ToString(funclib.FirstCap(txtPM_Name.Text)));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("PM_Active", Convert.ToString(ddlPM_Active.SelectedItem));
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeletePartyMainMasterData(dictionaryInstance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);               
            }
            return result;
        }

    }
}