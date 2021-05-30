using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using ePacker1.Business_Logic;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

namespace ePacker1
{
    //Page Developed by 
    public partial class RPeP_MasterContractor : Form
    {
        private FunctionLib funclib;
        string strCName, session, strMgr1, strMgr2, strDesg1, strDesg2, strSQL, Group_ID;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterContractor()
        {

            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            BindContractorMasterDataToGrid();
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtC_ID.Visible = false;
        }

        private void RPeP_MasterContractor_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strcon);

                //Displaying weeklyoff day
                con1.Open();
                SqlDataAdapter da4 = new SqlDataAdapter("select B_Day from B_Cal", con1);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                GlobalFunctions.AddPleaseSelect(ref dt4);
                ddlC_WeekOff.DataSource = dt4;
                ddlC_WeekOff.DisplayMember = dt4.Columns[0].ToString();
                ddlC_WeekOff.ValueMember = dt4.Columns[0].ToString();
                con1.Close();

                //Displaying Value in Category from Machine Type
                DataTable dtAllActiveMachineTypes = bl.GetAllActiveMachineType();
                if (dtAllActiveMachineTypes != null)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtAllActiveMachineTypes);
                    ddlC_Category.DataSource = dtAllActiveMachineTypes;
                    ddlC_Category.DisplayMember = dtAllActiveMachineTypes.Columns[0].ToString();
                    ddlC_Category.ValueMember = dtAllActiveMachineTypes.Columns[0].ToString();
                }

                //Displaying Active Values
                DataTable dtActive = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActive);
                ddlC_Active.DataSource = dtActive;
                ddlC_Active.DisplayMember = dtActive.Columns[0].ToString();
                ddlC_Active.ValueMember = dtActive.Columns[0].ToString();

                //Displayig City Name in Combo field
                DataTable dtAllCityMaster = bl.GetAllCityMaster();
                if (dtAllCityMaster != null)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtAllCityMaster);
                    ddlC_City.DataSource = dtAllCityMaster;
                    ddlC_City.DisplayMember = dtAllCityMaster.Columns[0].ToString();
                    ddlC_City.ValueMember = dtAllCityMaster.Columns[0].ToString();
                }

                //Displayig State Name in Combo field
                DataTable dtAllStateMaster = bl.GetAllStateMaster();
                if (dtAllStateMaster != null)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtAllStateMaster);
                    ddlC_State.DataSource = dtAllStateMaster;
                    ddlC_State.DisplayMember = dtAllStateMaster.Columns[0].ToString();
                    ddlC_State.ValueMember = dtAllStateMaster.Columns[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading the page " + ex.Message);
            }
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
                        double flag = funclib.isThere(con, "select C_Name ,Grp_ID from Contractor_Master where C_Name='" + txtC_Name.Text + "' and Grp_ID='" + Group_ID + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Contractor Name and Group is not allowed");
                        }
                        else
                        {
                            string mid = funclib.AutoKey("M", con, "select C_ID from Contractor_Master order by C_ID desc");
                            bool result = AddEditDeleteContractorMasterData("A", mid);
                            if (result)
                            {
                                MessageBox.Show("Record Inserted");
                            }
                            else
                            { MessageBox.Show("There was an error while Inserting data"); }
                            BindContractorMasterDataToGrid();
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
                MessageBox.Show("There was an error while Inserting data " + ex.Message);
            }           
        }

        private void txtC_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Name Text Field

            funclib = new FunctionLib();
            //funclib.checkNumericChar(e);
            funclib.onlyCharacterPress(e);


        }

        private void txtC_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Addr1 Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtC_Addr1.Text);
            lblAddress1.Text = "(Character " + P_AddressData + "  " + "Out of" + txtC_Addr1.MaxLength + ")";
        }

        private void txtC_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Addr2 Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtC_Addr2.Text);
            lbladdress2.Text = "(Character " + P_AddressData + "  " + "Out of" + txtC_Addr2.MaxLength + ")";

        }

        private void txtC_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_PinCode Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtC_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Tel Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtC_FAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_FAX Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtC_Mgr1Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr1Mobile Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtC_Mgr2Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr2Mobile Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtC_Mgr1Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr1Name Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);


        }

        private void txtC_Mgr2Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr2Name Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtC_Mgr1Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr1Desig Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtC_Mgr2Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr2Desig Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtC_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void BindContractorMasterDataToGrid()
        {
            try
            {
                DataTable dtContractorData = bl.GetAllContractorDataByContractorName(Group_ID, "");
                if (dtContractorData != null)
                {
                    dgwMasterContractor.DataSource = dtContractorData;
                    this.dgwMasterContractor.Columns[0].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while fetching Agent Master Data " + ex.Message); }
        }

        private void dgwMasterContractor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlC_Active.Enabled = true;

            //to display data in form on click of datagridview named dgwMasterContractor
            txtC_ID.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtC_Name.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[1].Value.ToString();            
            txtC_Addr1.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtC_Addr2.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlC_City.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlC_State.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtC_PinCode.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtC_Tel.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtC_FAX.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtC_Email.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtC_Mobile.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[11].Value.ToString();
            ddlC_WeekOff.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtC_Mgr1Name.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtC_Mgr1Desig.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtC_Mgr1Mobile.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtC_Mgr1Email.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[16].Value.ToString();
            txtC_Mgr2Name.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtC_Mgr2Desig.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtC_Mgr2Mobile.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[19].Value.ToString();
            txtC_Mgr2Email.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[20].Value.ToString();
            ddlC_Category.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[21].Value.ToString();
            ddlC_Active.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[22].Value.ToString();        
            txtC_Name.Enabled = false;
            ddlGrp_ID.Enabled = false;
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
                        bool result = AddEditDeleteContractorMasterData("E", txtC_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        BindContractorMasterDataToGrid();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = AddEditDeleteContractorMasterData("D", txtC_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    BindContractorMasterDataToGrid();
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

        private void clearAll()
        {
            //Clear all fields
            txtC_Name_Search.Text = "";
            ddlGrp_ID.Text = "";
            txtC_Name.Clear();
            txtC_Addr1.Clear();
            txtC_Addr2.Clear();
            ddlC_City.SelectedIndex = 0;
            ddlC_State.SelectedIndex = 0;
            txtC_Email.Clear();
            txtC_FAX.Clear();
            txtC_Mgr1Desig.Clear();
            txtC_Mobile.Clear();
            ddlC_WeekOff.SelectedIndex = 0;
            txtC_Mgr1Email.Clear();
            txtC_Mgr1Mobile.Clear();
            txtC_Mgr1Name.Clear();
            txtC_Mgr2Desig.Clear();
            txtC_Mgr2Email.Clear();
            txtC_Mgr2Name.Clear();
            txtC_Mgr2Mobile.Clear();
            ddlC_Active.SelectedIndex = 0;
            txtC_PinCode.Clear();
            txtC_Tel.Clear();          
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            ddlGrp_ID.Enabled = true;
            txtC_Name.Enabled = true;
            txtC_Name.Focus();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterContractor form
            clearAll();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search C_Name data from table Contractor_Master
            try
            {
                DataTable dtContractorMasterData = bl.GetAllContractorDataByContractorName(Group_ID, Convert.ToString(txtC_Name_Search.Text));
                if (dtContractorMasterData != null)
                {
                    dgwMasterContractor.DataSource = dtContractorMasterData;
                    this.dgwMasterContractor.Columns[0].Visible = false;
                    if (dgwMasterContractor.Rows.Count == 0)
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
            //Application.Exit();
            //Code to close MasterContractor form temporarily.
            this.Close();



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                        System.Data.DataTable table = dgwMasterContractor.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Contractor Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwMasterContractor.Columns.Count])
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

        private bool AddEditDeleteContractorMasterData(string action, string ContractorId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("ContractorId", ContractorId);
                dictionaryInstance.Add("ContractorName", funclib.FirstCap(txtC_Name.Text));
                dictionaryInstance.Add("AddressLine1", funclib.FirstCap(txtC_Addr1.Text));
                dictionaryInstance.Add("AddressLine2", funclib.FirstCap(txtC_Addr2.Text));
                dictionaryInstance.Add("City", Convert.ToString(ddlC_City.SelectedValue));
                dictionaryInstance.Add("State", Convert.ToString(ddlC_State.SelectedValue));
                dictionaryInstance.Add("PinCode", Convert.ToString(txtC_PinCode.Text));
                dictionaryInstance.Add("TelePhoneNo", Convert.ToString(txtC_Tel.Text));
                dictionaryInstance.Add("FaxNo", Convert.ToString(txtC_FAX.Text));
                dictionaryInstance.Add("EmailId", Convert.ToString(txtC_Email.Text));
                dictionaryInstance.Add("MobileNo", Convert.ToString(txtC_Mobile.Text));
                dictionaryInstance.Add("WeeklyOff", Convert.ToString(ddlC_WeekOff.SelectedValue));
                dictionaryInstance.Add("Manager1Name", funclib.FirstCap(txtC_Mgr1Name.Text));
                dictionaryInstance.Add("Manager1Desgn", funclib.FirstCap(txtC_Mgr1Desig.Text));
                dictionaryInstance.Add("Manager1Mobile", Convert.ToString(txtC_Mgr1Mobile.Text));
                dictionaryInstance.Add("Manager1Email", Convert.ToString(txtC_Mgr1Email.Text));
                dictionaryInstance.Add("Manager2Name", funclib.FirstCap(txtC_Mgr2Name.Text));
                dictionaryInstance.Add("Manager2Desgn", funclib.FirstCap(txtC_Mgr2Desig.Text));
                dictionaryInstance.Add("Manager2Mobile", Convert.ToString(txtC_Mgr2Mobile.Text));
                dictionaryInstance.Add("Manager2Email", Convert.ToString(txtC_Mgr2Email.Text));
                dictionaryInstance.Add("Category", Convert.ToString(ddlC_Category.SelectedValue));
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlC_Active.SelectedValue));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeleteContractorMasterData(dictionaryInstance);
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
                if (string.IsNullOrEmpty(txtC_Name.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Contractor Name   ";
                }
                if (string.IsNullOrEmpty(txtC_Addr1.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Contractor Address    ";
                }
                if (ddlC_City.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Contractor City   ";
                }
                if (ddlC_State.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Contractor State   ";
                }
                if (ddlC_WeekOff.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Weekly Off   ";
                }
                if (ddlC_Category.Text == "")
                {
                    strError = strError + Environment.NewLine + "Please Select Category   ";
                }
                if (ddlC_Active.SelectedIndex == 0)
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
