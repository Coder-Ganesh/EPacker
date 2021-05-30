using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ePacker1.Business_Logic;

namespace ePacker1
{
    public partial class RPeP_MasterPositive : Form
    {
        string session, strSQL, Group_ID;
        //Page developed by Shirish Phadnis on 12/3/2011
        private FunctionLib funcLib;
        string strFirstCap, strFile1Location, strFile2Location;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterPositive()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            BindPositiveMasterDataToGrid();
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtPtve_ID.Visible = false;
            pBFile1.Visible = false;
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string strValidationError = Validation();
                if (string.IsNullOrEmpty(strValidationError))
                {
                    funcLib = new FunctionLib();
                    string strcon = funcLib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //Checking for duplicate values
                        double flag = funcLib.isThere(con, "select Grp_ID ,A_ID,Ptve_Name from Positive_Master where Grp_ID='" + Group_ID + "' and A_ID='" + ddlA_ID.SelectedValue.ToString() + "' and Ptve_Name='" + txtPtve_Name.Text + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Positive Name, Agent and Group is not allowed");
                        }
                        else
                        {
                            string pvid = funcLib.AutoKey1("PV", con, "select Ptve_ID from Positive_Master order by Ptve_ID desc");
                            bool result = AddEditDeletePositiveMasterData("A", pvid);
                            if (result)
                            {
                                MessageBox.Show("Record Inserted Sucessfully");
                                if (!string.IsNullOrEmpty(strFile1Location))
                                {
                                    string filePath = Application.StartupPath + "\\SavedImages\\";
                                    if (!Directory.Exists(filePath))
                                    {
                                        Directory.CreateDirectory(filePath);
                                    }
                                    File.Copy(strFile1Location, filePath + txtPtve_File1.Text, true);
                                }
                                if (!string.IsNullOrEmpty(strFile2Location))
                                {
                                    string filePath = Application.StartupPath + "\\SavedPDFs\\" ;
                                    if (!Directory.Exists(filePath))
                                    {
                                        Directory.CreateDirectory(filePath);
                                    }
                                    File.Copy(strFile1Location, filePath + txtPtve_File2.Text,true);
                                }
                            }
                            else
                            { MessageBox.Show("There was an error while inserting data"); }
                            BindPositiveMasterDataToGrid();
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
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while inserting data. " + ex.Message);
            }
        }

        private void RPeP_MasterPositive_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //Displaying Agent value in Combo field
            DataTable dt = bl.GetAllAgentDataByAgentName(Group_ID, "");
            if (dt != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dt);
                ddlA_ID.DataSource = dt;
                ddlA_ID.DisplayMember = dt.Columns[1].ToString();
                ddlA_ID.ValueMember = dt.Columns[0].ToString();
            }

            //Displaying Active value in Combo field
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlPtve_Active.DataSource = dtActive;
            ddlPtve_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlPtve_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void txtPtve_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);
        }

        private void txtPtve_File1_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);
        }

        private void txtPtve_File2_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);
        }        

        private void BindPositiveMasterDataToGrid()
        {
            try
            {
                DataTable lstAllAgent = bl.GetAllPositiveMasterData(Group_ID, "");
                if (lstAllAgent != null)
                {
                    dgvMasterPositive.DataSource = lstAllAgent;
                    this.dgvMasterPositive.Columns[0].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while fetching Agent Master Data " + ex.Message); }
        }

        private void dgvMasterPositive_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Visible = false;
            cmdSubmit.Enabled = false;
            ddlPtve_Active.Enabled = true;
            ddlGrp_ID.Enabled = false;
            ddlA_ID.Enabled = false;
            txtPtve_Name.Enabled = false;
            txtPtve_File1.Enabled = false;
            txtPtve_File2.Enabled = false;
            txtPtve_Qty_OS.Enabled = true;
            txtPtve_Qty_CS.Enabled = true;
            txtPtve_Qty_RO.Enabled = true;
            //to display data in form on click of datagridview
            txtPtve_ID.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[0].Value.ToString();
            // ddlGrp_ID.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlA_ID.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPtve_Name.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPtve_File1.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (!string.IsNullOrEmpty(txtPtve_File1.Text))
            {
                pBFile1.Visible = true;
                pBFile1.ImageLocation = dgvMasterPositive.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPtve_File1.Text = Path.GetFileName(txtPtve_File1.Text);
            }
            txtPtve_File2.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (!string.IsNullOrEmpty(txtPtve_File2.Text))
            {
                txtPtve_File2.Text = Path.GetFileName(txtPtve_File2.Text);
            }
            txtPtve_Qty_OS.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtPtve_Qty_CS.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtPtve_Qty_RO.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[8].Value.ToString();
            ddlPtve_Active.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[9].Value.ToString();

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string strValidationError = Validation();
                if (string.IsNullOrEmpty(strValidationError))
                {
                    if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool result = AddEditDeletePositiveMasterData("E", txtPtve_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        BindPositiveMasterDataToGrid();
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

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            try
            {
                DataTable lstAllAgent = bl.GetAllPositiveMasterData(Group_ID, Convert.ToString(txtA_Name_Search.Text));
                if (lstAllAgent != null)
                {
                    dgvMasterPositive.DataSource = lstAllAgent;
                    this.dgvMasterPositive.Columns[0].Visible = false;
                    if (dgvMasterPositive.Rows.Count == 0)
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

        private void btnPtve_File1_Click(object sender, EventArgs e)
        {
            //Saving file1 path in database           
            OpenFileDialog ofn1 = new OpenFileDialog();
            ofn1.InitialDirectory = "C:";
            ofn1.Title = "Save as Image file";
            ofn1.FileName = "";
            ofn1.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (ofn1.ShowDialog() == DialogResult.OK)
            {
                FileStream fstr;
                try
                {
                    fstr = new FileStream(ofn1.FileName, FileMode.Open, FileAccess.Read);
                    txtPtve_File1.Text = ofn1.SafeFileName;
                    strFile1Location = ofn1.FileName;
                    pBFile1.Visible = true;
                    pBFile1.ImageLocation = strFile1Location;        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error " + ex.Message);
                }
            }
        }

        private void cmdAgentSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Display values in Agent Combo by searching
                DataTable dt = bl.GetAllAgentDataByAgentName(Group_ID, txtAgentSearch.Text.Trim().Replace("'", "''"));
                if (dt != null)
                {
                    if (string.IsNullOrEmpty(txtAgentSearch.Text))
                    {
                        GlobalFunctions.AddPleaseSelect(ref dt);
                    }
                    ddlA_ID.DataSource = dt;
                    ddlA_ID.DisplayMember = dt.Columns[1].ToString();
                    ddlA_ID.ValueMember = dt.Columns[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while searching " + ex.Message);
            }
        }

        private void cmdPtve_File2_Click(object sender, EventArgs e)
        {
            //funcLib = new FunctionLib();
            OpenFileDialog ofn1 = new OpenFileDialog();
            ofn1.InitialDirectory = "C:";
            ofn1.Title = "Save as PDF file";
            ofn1.FileName = "";
            ofn1.Filter = "Pdf Files|*.pdf";
            if (ofn1.ShowDialog() == DialogResult.OK)
            {
                FileStream fstr;
                try
                {
                    fstr = new FileStream(ofn1.FileName, FileMode.Open, FileAccess.Read);
                    txtPtve_File2.Text = ofn1.SafeFileName;
                    strFile2Location = ofn1.FileName;                
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while searching " + ex.Message);
                }
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            //Clearing form data
            ddlGrp_ID.Text = "";
            ddlA_ID.SelectedIndex = 0;
            txtPtve_File1.Clear();
            txtPtve_File2.Clear();
            txtPtve_Name.Clear();
            txtPtve_Qty_OS.Clear();
            txtPtve_Qty_CS.Clear();
            txtPtve_Qty_RO.Clear();
            //ddlPtve_Active.Text = "";
            txtAgentSearch.Clear();
            ddlGrp_ID.Enabled = true;
            ddlA_ID.Enabled = true;
            txtPtve_Name.Enabled = true;
            txtPtve_File1.Enabled = true;
            txtPtve_File2.Enabled = true;
            txtPtve_Qty_OS.Enabled = true;
            txtPtve_Qty_CS.Enabled = true;
            txtPtve_Qty_RO.Enabled = true;
            ddlPtve_Active.SelectedIndex = 0;
            ddlPtve_Active.Enabled = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            pBFile1.Visible = false;
        }

        private void txtPtve_Qty_OS_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Opening Stock
            funcLib = new FunctionLib();
            funcLib.onlyNumbers(e);
        }

        private void txtPtve_Qty_CS_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Closing Stock
            funcLib = new FunctionLib();
            funcLib.onlyNumbers(e);
        }

        private void txtPtve_Qty_RO_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Reorder level
            funcLib = new FunctionLib();
            funcLib.onlyNumbers(e);
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
                        System.Data.DataTable table = dgvMasterPositive.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("PositiveMaster");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgvMasterPositive.Columns.Count])
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
                    bool result = AddEditDeletePositiveMasterData("D", txtPtve_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    BindPositiveMasterDataToGrid();
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

        private bool AddEditDeletePositiveMasterData(string action, string PositiveId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("PositiveId", PositiveId);
                dictionaryInstance.Add("AgentId", Convert.ToString(ddlA_ID.SelectedValue));
                dictionaryInstance.Add("PositiveName", funcLib.FirstCap(txtPtve_Name.Text));
                if (string.IsNullOrEmpty(txtPtve_File1.Text))
                {
                    dictionaryInstance.Add("File1", "");
                }
                else
                {
                    dictionaryInstance.Add("File1", Application.StartupPath + "\\SavedImages\\" + txtPtve_File1.Text);
                }
                if (string.IsNullOrEmpty(txtPtve_File2.Text))
                {
                    dictionaryInstance.Add("File2", "");
                }
                else
                {
                    dictionaryInstance.Add("File2", Application.StartupPath + "\\SavedPDFs\\" + txtPtve_File2.Text);
                }
                dictionaryInstance.Add("OpeningStock", Convert.ToString(txtPtve_Qty_OS.Text));
                dictionaryInstance.Add("ClosingStock", Convert.ToString(txtPtve_Qty_CS.Text));
                dictionaryInstance.Add("ReOrder", Convert.ToString(txtPtve_Qty_RO.Text));             
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlPtve_Active.SelectedValue));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeletePositiveMasterData(dictionaryInstance);
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
                if (ddlA_ID.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Agent  ";
                }
                if (string.IsNullOrEmpty(txtPtve_Name.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Positive Name   ";
                }
                if (string.IsNullOrEmpty(txtPtve_Qty_OS.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Opening Stock  ";
                }
                if (string.IsNullOrEmpty(txtPtve_Qty_CS.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Closing Stock  ";
                }
                if (string.IsNullOrEmpty(txtPtve_Qty_RO.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Re-Order  ";
                }
                if (ddlPtve_Active.SelectedIndex == 0)
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