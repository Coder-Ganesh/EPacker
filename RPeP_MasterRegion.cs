using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ePacker1.App_Code;
using Excel = Microsoft.Office.Interop.Excel;
using ePacker1.Business_Logic;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

namespace ePacker1
{
    public partial class RPeP_MasterRegion : Form
    {
        string session, strSQL, Group_ID; 
        private FunctionLib funcLib;
        string strFirstCap;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterRegion()
        {
            InitializeComponent();
            Group_ID = RPeP_LogIn.strGroup;
            session = RPeP_LogIn.strUser;
            BindRegionDataToGrid();
            txtRg_ID.Visible = false;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
        }

        private void RPeP_MasterRegion_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);          

            //Displaying Active value in Combo field
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlRg_Active.DataSource = dtActive;
            ddlRg_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlRg_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void txtRg_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            string strValidationError = Validation();
            if (string.IsNullOrEmpty(strValidationError))                        
            {
                    funcLib = new FunctionLib();
                    strFirstCap = funcLib.FirstCap(txtRg_Name.Text);
                    string strcon = funcLib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //Checking for duplicate values
                        double flag = funcLib.isThere(con, "select Rg_Name, Grp_ID from Region_Master where Rg_Name='" + txtRg_Name.Text + "' and Grp_ID='" + Group_ID + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Group and Region Name is not allowed");
                        }
                        else
                        {
                            string rgid = funcLib.AutoKey1("RG", con, "select Rg_ID from Region_Master order by Rg_ID desc");
                        bool result = AddEditDeleteRegionMasterData("A", rgid);
                        if (result)
                        {
                            MessageBox.Show("Record Inserted");
                        }
                        else
                        { MessageBox.Show("There was an error while Inserting data"); }
                        BindRegionDataToGrid();
                        clearAll();
                    }
                    }
                else
                {
                    cmdSubmit.Focus();
                }
            }
            else
            {
                MessageBox.Show(strValidationError);
            }
        }

        private void BindRegionDataToGrid()
        {
            try
            {
                DataTable dtRegionData = bl.GetAllRegionDataByRegionName(Group_ID, "");
                if (dtRegionData != null)
                {
                    dgwMasterRegion.DataSource = dtRegionData;
                    this.dgwMasterRegion.Columns[0].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while fetching Region Master Data " + ex.Message); }
        }

        private void clearAll()
        {
            //Clearing form
            ddlGrp_ID.Text = "";
            txtRg_Name.Clear();
            txtRg_ID.Clear();
            ddlGrp_ID.Enabled = true;
            txtRg_Name.Enabled = true;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            ddlRg_Active.SelectedIndex = 0;
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void dgwMasterRegion_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ddlGrp_ID.Enabled=false;
            txtRg_Name.Enabled = false;
            ddlRg_Active.Enabled=true;
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            //to display data in form on click of datagridview
            txtRg_ID.Text = dgwMasterRegion.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtRg_Name.Text = dgwMasterRegion.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlRg_Active.Text = dgwMasterRegion.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table
            try
            {
                string strValidationError = Validation();
                if (string.IsNullOrEmpty(strValidationError))
                {
                    if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool result = AddEditDeleteRegionMasterData("E", txtRg_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        BindRegionDataToGrid();
                        clearAll();
                    }
                }
                else
                {
                    MessageBox.Show(strValidationError);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while Editing Values " + ex.Message);
            }
        }

        private void cmdRg_Name_Search_Click(object sender, EventArgs e)
        {
            //Search C_Name data from table Contractor_Master
            try
            {
                DataTable dtRegionData = bl.GetAllRegionDataByRegionName(Group_ID, Convert.ToString(txtRg_Name_Search.Text));
                if (dtRegionData != null)
                {
                    dgwMasterRegion.DataSource = dtRegionData;
                    this.dgwMasterRegion.Columns[0].Visible = false;
                    if (dgwMasterRegion.Rows.Count == 0)
                    {
                        cmdExcelReport.Visible = false;
                    }
                    else
                    {
                        cmdExcelReport.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while Searching " + ex.Message);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
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
                        System.Data.DataTable table = dgwMasterRegion.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Contractor Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);
                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwMasterRegion.Columns.Count])
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
                    bool result = AddEditDeleteRegionMasterData("D", txtRg_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    BindRegionDataToGrid();
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

        private bool AddEditDeleteRegionMasterData(string action, string RegionId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("RegionId", RegionId);
                dictionaryInstance.Add("RegionName", funcLib.FirstCap(txtRg_Name.Text));              
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlRg_Active.SelectedValue));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeleteRegionMasterData(dictionaryInstance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        private string Validation()
        {
            string strError = "";
            try
            {
                if (string.IsNullOrEmpty(txtRg_Name.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Region Name   ";
                }               
                if (ddlRg_Active.SelectedIndex == 0)
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