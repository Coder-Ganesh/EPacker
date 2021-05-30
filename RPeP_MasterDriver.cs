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
    public partial class RPeP_MasterDriver : Form
    {
        //Page Developed by Shirish and Avinash on(15/3/2011).
        private FunctionLib funclib;
        string strFName, session, strMName, strLName, strOName, strSQL, Group_ID;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterDriver()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtDrv_ID.Visible = false;
            BindDriverMasterDataToGrid();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtDrv_FName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_FName Text Field
            funclib = new FunctionLib();
            //funclib.checkNumericChar(e);
            funclib.onlyCharacterPress(e);
        }

        private void txtDrv_MName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_MName Text Field
            funclib = new FunctionLib();
            //funclib.checkNumericChar(e);
            funclib.onlyCharacterPress(e);
        }

        private void txtDrv_LName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_LName Text Field
            funclib = new FunctionLib();
            //funclib.checkNumericChar(e);
            funclib.onlyCharacterPress(e);
        }

        private void txtDrv_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_Addr1 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtDrv_Addr1.Text);
            lblAddressone.Text = "(Character " + P_AddressData + "  " + "Out of" + txtDrv_Addr1.MaxLength + ")";
        }

        private void txtDrv_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_Addr2 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtDrv_Addr2.Text);
            lblAddresstwo.Text = "(Character " + P_AddressData + "  " + "Out of" + txtDrv_Addr2.MaxLength + ")";
        }

        private void txtDrv_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_PinCode Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtDrv_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtDrv_BirthPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_BirthPlace Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtDrv_Owner_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_Owner Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtDrv_OwnAddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_OwnAddr Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtDrv_OwnPinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_OwnPinCode Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtDrv_OwnPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_OwnPhone Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void RPeP_MasterDriver_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);

            //Displaying City Name in CityCombo field
            DataTable dtAllCityMaster = bl.GetAllCityMaster();
            if (dtAllCityMaster != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllCityMaster);
                ddlDrv_City.DataSource = dtAllCityMaster;
                ddlDrv_City.DisplayMember = dtAllCityMaster.Columns[0].ToString();
                ddlDrv_City.ValueMember = dtAllCityMaster.Columns[0].ToString();
            }

            //Displaying State Name in StateCombo field
            DataTable dtAllStateMaster = bl.GetAllStateMaster();
            if (dtAllStateMaster != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllStateMaster);
                ddlDrv_State.DataSource = dtAllStateMaster;
                ddlDrv_State.DisplayMember = dtAllStateMaster.Columns[0].ToString();
                ddlDrv_State.ValueMember = dtAllStateMaster.Columns[0].ToString();
            }

            //Displaying Active value in ActiveCombo field
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlDrv_Active.DataSource = dtActive;
            ddlDrv_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlDrv_Active.ValueMember = dtActive.Columns[0].ToString();

            //Displaying Blood group values in BloodgroupCombo field
            DataTable dtBloodGrp = new DataTable();
            GlobalFunctions.AddBloodGrpOptions(ref dtBloodGrp);
            ddlDrv_BloodGrp.DataSource = dtBloodGrp;
            ddlDrv_BloodGrp.DisplayMember = dtBloodGrp.Columns[0].ToString();
            ddlDrv_BloodGrp.ValueMember = dtBloodGrp.Columns[0].ToString();         

            //Displaying state values in LicnState
            dtAllStateMaster = bl.GetAllStateMaster();
            if (dtAllStateMaster != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllStateMaster);
                ddlDrv_LicnState.DataSource = dtAllStateMaster;
                ddlDrv_LicnState.DisplayMember = dtAllStateMaster.Columns[0].ToString();
                ddlDrv_LicnState.ValueMember = dtAllStateMaster.Columns[0].ToString();
            }

            //Displaying Owner City Name in Combo field        
            dtAllCityMaster = bl.GetAllCityMaster();
            if (dtAllCityMaster != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllCityMaster);
                ddlDrv_OwnCity.DataSource = dtAllCityMaster;
                ddlDrv_OwnCity.DisplayMember = dtAllCityMaster.Columns[0].ToString();
                ddlDrv_OwnCity.ValueMember = dtAllCityMaster.Columns[0].ToString();
            }

            //Displaying Owner State Name in Combo field         
            dtAllStateMaster = bl.GetAllStateMaster();
            if (dtAllStateMaster != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllStateMaster);
                ddlDrv_OwnState.DataSource = dtAllStateMaster;
                ddlDrv_OwnState.DisplayMember = dtAllStateMaster.Columns[0].ToString();
                ddlDrv_OwnState.ValueMember = dtAllStateMaster.Columns[0].ToString();
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
                        double flag = funclib.isThere(con, "select Drv_FName,Drv_MName,Drv_LName,Grp_ID from Driver_Master where Drv_FName='" + txtDrv_FName.Text + "'and Drv_MName='" + txtDrv_MName.Text + "' and Drv_LName='" + txtDrv_LName.Text + "' and Grp_ID='" + Group_ID + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Driver Name and Group is not allowed");

                        }
                        else
                        {
                            string drid = funclib.AutoKey1("DR", con, "select Drv_ID from Driver_Master order by Drv_ID desc");
                            bool result = AddEditDeleteDriverMasterData("A", drid);
                            if (result)
                            {
                                MessageBox.Show("Record Inserted Sucessfully");
                            }
                            else
                            { MessageBox.Show("There was an error while inserting data"); }
                            BindDriverMasterDataToGrid();
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

        private void BindDriverMasterDataToGrid()
        {
            try
            {
                DataTable lstAllAgent = bl.GetAllDriverDataByDriverName(Group_ID, "");
                if (lstAllAgent != null)
                {
                    dgwDriver_Master.DataSource = lstAllAgent;
                    this.dgwDriver_Master.Columns[0].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while fetching Agent Master Data " + ex.Message); }
        }

        private void dgwDriver_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlDrv_Active.Enabled = true;
            txtDrv_FName.Enabled = false;
            txtDrv_MName.Enabled = false;
            txtDrv_LName.Enabled = false;
            ddlGrp_ID.Enabled = false;
            //to display data in form on click of datagridview named dgwDriver_Master. 
            txtDrv_ID.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            //  ddlGrp_ID.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDrv_FName.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDrv_MName.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDrv_LName.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDrv_Addr1.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDrv_Addr2.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[6].Value.ToString();
            ddlDrv_City.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[7].Value.ToString();
            ddlDrv_State.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtDrv_PinCode.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtDrv_Mobile.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtDrv_BirthPlace.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[11].Value.ToString();
            ddlDrv_BloodGrp.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtDrv_LicnNo.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[13].Value.ToString();
            ddlDrv_LicnState.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtDrv_Owner.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtDrv_OwnAddr.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[16].Value.ToString();
            ddlDrv_OwnCity.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[17].Value.ToString();
            ddlDrv_OwnState.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtDrv_OwnPinCode.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[19].Value.ToString();
            txtDrv_OwnPhone.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[20].Value.ToString();
            ddlDrv_Active.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[21].Value.ToString();
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
                        bool result = AddEditDeleteDriverMasterData("E", txtDrv_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        BindDriverMasterDataToGrid();
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
            //Search data from table Driver_Master
            try
            {
                DataTable dt = bl.GetAllDriverDataByDriverName(Group_ID, Convert.ToString(txtDrv_Name_Search.Text));
                if (dt != null)
                {
                    dgwDriver_Master.DataSource = dt;
                    this.dgwDriver_Master.Columns[0].Visible = false;
                    if (dgwDriver_Master.Rows.Count == 0)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = AddEditDeleteDriverMasterData("D", txtDrv_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    BindDriverMasterDataToGrid();
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

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterDriver form
            clearAll();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            ddlGrp_ID.Text = "";
            txtDrv_FName.Clear();
            txtDrv_MName.Clear();
            txtDrv_LName.Clear();
            txtDrv_Addr1.Clear();
            txtDrv_Addr2.Clear();
            ddlDrv_City.SelectedIndex = 0;
            ddlDrv_State.SelectedIndex = 0;
            txtDrv_PinCode.Clear();
            txtDrv_Mobile.Clear();
            txtDrv_BirthPlace.Clear();
            ddlDrv_BloodGrp.SelectedIndex = 0;
            txtDrv_LicnNo.Clear();
            ddlDrv_LicnState.SelectedIndex = 0;
            txtDrv_Owner.Clear();
            txtDrv_OwnAddr.Clear();
            txtDrv_OwnPhone.Clear();
            txtDrv_OwnPinCode.Clear();
            ddlDrv_OwnCity.SelectedIndex = 0;
            ddlDrv_OwnState.SelectedIndex = 0;
            ddlDrv_Active.SelectedIndex = 0;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtDrv_FName.Enabled = true;
            txtDrv_MName.Enabled = true;
            txtDrv_LName.Enabled = true;
            ddlGrp_ID.Enabled = true;
            txtDrv_Addr1.Focus();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Code to close MasterDriver form temporarily.
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
                        System.Data.DataTable table = dgwDriver_Master.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("DriverMaster");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwDriver_Master.Columns.Count])
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

        private bool AddEditDeleteDriverMasterData(string action, string DriverId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("DriverId", DriverId);
                dictionaryInstance.Add("FirstName", funclib.FirstCap(txtDrv_FName.Text));
                dictionaryInstance.Add("MiddleName", funclib.FirstCap(txtDrv_MName.Text));
                dictionaryInstance.Add("LastName", funclib.FirstCap(txtDrv_LName.Text));
                dictionaryInstance.Add("AddressLine1", funclib.FirstCap(txtDrv_Addr1.Text));
                dictionaryInstance.Add("AddressLine2", funclib.FirstCap(txtDrv_Addr2.Text));
                dictionaryInstance.Add("City", Convert.ToString(ddlDrv_City.SelectedValue));
                dictionaryInstance.Add("State", Convert.ToString(ddlDrv_State.SelectedValue));
                dictionaryInstance.Add("PinCode", Convert.ToString(txtDrv_PinCode.Text));
                dictionaryInstance.Add("MobileNo", Convert.ToString(txtDrv_Mobile.Text));
                dictionaryInstance.Add("BirthPlace", Convert.ToString(txtDrv_BirthPlace.Text));
                dictionaryInstance.Add("BloodGrp", Convert.ToString(ddlDrv_BloodGrp.SelectedValue));
                dictionaryInstance.Add("LicenseNo", funclib.FirstCap(txtDrv_LicnNo.Text));
                dictionaryInstance.Add("LicenseState", Convert.ToString(ddlDrv_LicnState.SelectedValue));
                dictionaryInstance.Add("OwnerName", funclib.FirstCap(txtDrv_Owner.Text));
                dictionaryInstance.Add("OwnerAddress", funclib.FirstCap(txtDrv_OwnAddr.Text));
                dictionaryInstance.Add("OwnerCity", Convert.ToString(ddlDrv_OwnCity.SelectedValue));
                dictionaryInstance.Add("OwnerState", Convert.ToString(ddlDrv_OwnState.SelectedValue));
                dictionaryInstance.Add("OwnerPinCode", funclib.FirstCap(txtDrv_OwnPinCode.Text));
                dictionaryInstance.Add("OwnerPhone", funclib.FirstCap(txtDrv_OwnPhone.Text));
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlDrv_Active.SelectedValue));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeleteDriverMasterData(dictionaryInstance);
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
                if (string.IsNullOrEmpty(txtDrv_FName.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Driver First Name   ";
                }
                if (string.IsNullOrEmpty(txtDrv_LName.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Driver Last Name   ";
                }
                if (string.IsNullOrEmpty(txtDrv_Addr1.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Driver Address    ";
                }
                if (ddlDrv_City.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Driver City   ";
                }
                if (ddlDrv_OwnCity.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Driver Own City   ";
                }
                if (ddlDrv_State.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Driver State   ";
                }
                if (ddlDrv_LicnState.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Driver License State   ";
                }
                if (ddlDrv_OwnState.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Driver Own State   ";
                }
                if (string.IsNullOrEmpty(txtDrv_LicnNo.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Driver License Number    ";
                }
                if (string.IsNullOrEmpty(txtDrv_Owner.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Owner Name    ";
                }
                if (ddlDrv_Active.SelectedIndex == 0)
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