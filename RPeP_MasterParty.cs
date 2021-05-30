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
using OfficeOpenXml.Style;
using System.IO;

namespace ePacker1
{
    public partial class RPeP_MasterParty : Form
    {
        //Page developed by Shirish on(4/3/2011)
        private FunctionLib funclib;
        string strPartyName, session, strMgr1, strMgr2, strDesg1, strDesg2, strSQL, Group_ID;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterParty()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            BindPartyMasterDataToGrid();
            cmdEdit.Enabled = false;
            txtP_ID.Visible = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
        }

        private void RPeP_MasterParty_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);       

            DataTable dtAllPartyMainMasterData = bl.GetAllActivePartyMainMasterData(Group_ID);
            if (dtAllPartyMainMasterData != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllPartyMainMasterData);
                ddlPM_ID_Search.DataSource = dtAllPartyMainMasterData;
                ddlPM_ID_Search.DisplayMember = dtAllPartyMainMasterData.Columns[1].ToString();
                ddlPM_ID_Search.ValueMember = dtAllPartyMainMasterData.Columns[0].ToString();
            }
            dtAllPartyMainMasterData = bl.GetAllActivePartyMainMasterData(Group_ID);
            if (dtAllPartyMainMasterData != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllPartyMainMasterData);
                ddlP_Name.DataSource = dtAllPartyMainMasterData;
                ddlP_Name.DisplayMember = dtAllPartyMainMasterData.Columns[1].ToString();
                ddlP_Name.ValueMember = dtAllPartyMainMasterData.Columns[0].ToString();
            }

            DataTable dtAllCityMaster = bl.GetAllCityMaster();
            if (dtAllCityMaster != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllCityMaster);
                ddlP_City.DataSource = dtAllCityMaster;
                ddlP_City.DisplayMember = dtAllCityMaster.Columns[0].ToString();
                ddlP_City.ValueMember = dtAllCityMaster.Columns[0].ToString();
            }

            DataTable dtAllStateMaster = bl.GetAllStateMaster();
            if (dtAllStateMaster != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllStateMaster);
                ddlP_State.DataSource = dtAllStateMaster;
                ddlP_State.DisplayMember = dtAllStateMaster.Columns[0].ToString();
                ddlP_State.ValueMember = dtAllStateMaster.Columns[0].ToString();
            }

            //Displaying weekoff day
            con1.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("Select B_Day from B_Cal", con1);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            GlobalFunctions.AddPleaseSelect(ref dt4);
            ddlP_WeekOff1.DataSource = dt4;
            ddlP_WeekOff1.DisplayMember = dt4.Columns[0].ToString();
            ddlP_WeekOff1.ValueMember = dt4.Columns[0].ToString();
            con1.Close();

            //Displaying Top_Paper Values
            DataTable dtTopPaper = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtTopPaper);
            ddlP_TopPaper.DataSource = dtTopPaper;
            ddlP_TopPaper.DisplayMember = dtTopPaper.Columns[0].ToString();
            ddlP_TopPaper.ValueMember = dtTopPaper.Columns[0].ToString();

            //Displaying CForm Values
            DataTable dtCForm = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtCForm);
            ddlP_CForm.DataSource = dtCForm;
            ddlP_CForm.DisplayMember = dtCForm.Columns[0].ToString();
            ddlP_CForm.ValueMember = dtCForm.Columns[0].ToString();

            //Displaying Active Values
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlP_Active.DataSource = dtActive;
            ddlP_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlP_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void txtP_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Name Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtP_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Addr1 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtP_Addr1.Text);
            lblAddrChar.Text = "(Character " + P_AddressData + "  " + "Out of" + txtP_Addr1.MaxLength + ")";
        }

        private void txtP_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Addr2 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtP_Addr2.Text);
            lblAddreChar2.Text = "(Character " + P_AddressData + "  " + "Out of" + txtP_Addr2.MaxLength + ")";
        }

        private void txtP_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_PinCode Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtP_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Tel Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtP_FAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_FAX Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtP_Mgr1Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr1Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtP_Mgr2Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr2Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtP_Mgr1Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr1Name Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtP_Mgr2Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr2Name Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtP_Mgr1Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr1Desig Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtP_Mgr2Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr2Desig Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtP_Mobile1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mobile1 Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtP_ECC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_ECC Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtP_Tin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Tin Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtP_BST_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_BST Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtP_CST_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_CST Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtP_CrDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_CST Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
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
                        double flag = funclib.isThere(con, "select P_Name,PM_ID,Grp_ID from Party_Master where P_Name='" + txtP_Name.Text + "'and PM_ID='" + Group_ID + "' and Grp_ID='" + Group_ID + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Party Name, Party (Main) and Group is not allowed");
                        }
                        else
                        {
                            //Inserting Details into table
                            strPartyName = funclib.FirstCap(txtP_Name.Text);
                            txtP_Addr1.Text = funclib.FirstCap(txtP_Addr1.Text);
                            strMgr1 = funclib.FirstCap(txtP_Mgr1Name.Text);
                            strMgr2 = funclib.FirstCap(txtP_Mgr2Name.Text);
                            strDesg1 = funclib.FirstCap(txtP_Mgr1Desig.Text);
                            strDesg2 = funclib.FirstCap(txtP_Mgr2Desig.Text);
                            string pmid = funclib.AutoKey("P", con, "select P_ID from Party_Master order by P_ID desc");
                            bool result = AddEditDeletePartyMasterData("A", pmid);
                            if (result)
                            {
                                MessageBox.Show("Record Inserted Sucessfully");
                            }
                            else
                            { MessageBox.Show("There was an error while inserting data"); }
                            BindPartyMasterDataToGrid();
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

        private void BindPartyMasterDataToGrid()
        {
            try
            {
                DataTable dtAllPartyMasterData = bl.GetAllPartyMasterDataByMainPartyId(Group_ID, "", "");
                if (dtAllPartyMasterData != null)
                {
                    dgwRPeP_MasterParty.DataSource = dtAllPartyMasterData;
                    this.dgwRPeP_MasterParty.Columns[0].Visible = false;
                    this.dgwRPeP_MasterParty.Columns[1].Visible = false;
                    this.dgwRPeP_MasterParty.Columns[2].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while fetching Party Main Master Data " + ex.Message); }
        }

        private void clearAll()
        {
            //Clear all fields
            txtP_Name.Enabled = true;
            ddlGrp_ID.Enabled = true;
            ddlP_Name.Enabled = true;
            ddlGrp_ID.Text = "";
            ddlP_Name.Text = "";
            txtP_Name.Clear();
            txtP_Addr1.Clear();
            txtP_Addr2.Clear();
            txtP_ECC.Clear();
            txtLBT_No.Clear();
            txtP_CST.Clear();
            txtP_PinCode.Clear();
            txtP_Tel.Clear();
            ddlP_City.Text = "";
            ddlP_State.Text = "";
            txtP_Email.Clear();
            txtP_FAX.Clear();
            txtP_Mgr1Desig.Clear();
            txtP_Mobile1.Clear();
            ddlP_WeekOff1.Text = "";
            txtP_Mgr1Email.Clear();
            txtP_Mgr1Mobile.Clear();
            txtP_Mgr1Name.Clear();
            txtP_Mgr2Desig.Clear();
            txtP_Mgr2Email.Clear();
            txtP_Mgr2Name.Clear();
            txtP_Mgr2Mobile.Clear();
            ddlP_TopPaper.Text = "";
            ddlP_Active.Text = "";
            ddlP_CForm.Text = "";
            txtPAN_No.Clear();
            txtP_CrDays.Clear();
            txtP_Tin.Clear();
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;            
            cmdEdit.Visible = false;
            btnDelete.Visible = false;

            txtGSTNo.Text = "";
            ddlP_TopPaper.SelectedIndex  = 0;
            ddlP_CForm.SelectedIndex = 0;
            ddlP_Name.SelectedIndex = 0;
            ddlP_City.SelectedIndex = 0;
            ddlP_State.SelectedIndex = 0;
            ddlP_WeekOff1.SelectedIndex = 0;
            ddlP_Active.SelectedIndex = 0;
        }

        private void dgwRPeP_MasterParty_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //to display data in form on click of datagridview
                cmdEdit.Enabled = true;
                cmdEdit.Visible = true;
                btnDelete.Visible = true;
                cmdSubmit.Enabled = false;
                cmdSubmit.Visible = false;
                ddlP_Active.Enabled = true;
                txtP_ID.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[0].Value.ToString();
                //ddlGrp_ID.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[1].Value.ToString();
                ddlP_Name.SelectedValue = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtP_Name.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtP_Addr1.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtP_Addr2.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[6].Value.ToString();
                ddlP_City.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[7].Value.ToString();
                ddlP_State.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtP_PinCode.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtP_Tel.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtP_FAX.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtP_Email.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtP_Mobile1.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[13].Value.ToString();
                ddlP_WeekOff1.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[14].Value.ToString();
                txtP_Mgr1Name.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[15].Value.ToString();
                txtP_Mgr1Desig.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[16].Value.ToString();
                txtP_Mgr1Mobile.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[17].Value.ToString();
                txtP_Mgr1Email.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[18].Value.ToString();
                txtP_Mgr2Name.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[19].Value.ToString();
                txtP_Mgr2Desig.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[20].Value.ToString();
                txtP_Mgr2Mobile.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[21].Value.ToString();
                txtP_Mgr2Email.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[22].Value.ToString();
                txtGSTNo.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[23].Value.ToString();
                txtP_ECC.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[24].Value.ToString();
                txtP_Tin.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[25].Value.ToString();
                txtLBT_No.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[26].Value.ToString();
                txtP_CST.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[27].Value.ToString();
                ddlP_TopPaper.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[28].Value.ToString();
                ddlP_CForm.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[29].Value.ToString();
                txtP_CrDays.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[30].Value.ToString();
                ddlP_Active.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[31].Value.ToString();
                txtPAN_No.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[32].Value.ToString();

                txtP_Name.Enabled = false;
                ddlGrp_ID.Enabled = false;
                ddlP_Name.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error " + ex.Message);
            }
            
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
                        bool result = AddEditDeletePartyMasterData("E", txtP_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        BindPartyMasterDataToGrid();
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
            try
            {
                DataTable dt = bl.GetAllPartyMasterDataByMainPartyId(Group_ID, Convert.ToString(ddlPM_ID_Search.SelectedValue), Convert.ToString(txtP_Name_Search.Text));
                if (dt != null)
                {
                    dgwRPeP_MasterParty.DataSource = dt;
                    this.dgwRPeP_MasterParty.Columns[0].Visible = false;
                    this.dgwRPeP_MasterParty.Columns[1].Visible = false;
                    this.dgwRPeP_MasterParty.Columns[2].Visible = false;

                    if (dgwRPeP_MasterParty.Rows.Count == 0)
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

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void txtPAN_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating PAN Number
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = AddEditDeletePartyMasterData("D", txtP_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    BindPartyMasterDataToGrid();
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

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            txtP_Name_Search.Text = "";
            ddlPM_ID_Search.SelectedIndex = 0;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Code to close Master Party form temporarily
            this.Close();
        }

        private void ddlPM_ID_Search_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
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
                        System.Data.DataTable table = dgwRPeP_MasterParty.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("PartyMaster");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwRPeP_MasterParty.Columns.Count])
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

        private bool AddEditDeletePartyMasterData(string action, string pmid)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("PMM_Id", Convert.ToString(ddlP_Name.SelectedValue));
                dictionaryInstance.Add("PartyId", pmid);
                dictionaryInstance.Add("PartyName", funclib.FirstCap(txtP_Name.Text));
                dictionaryInstance.Add("AddressLine1", funclib.FirstCap(txtP_Addr1.Text));
                dictionaryInstance.Add("AddressLine2", funclib.FirstCap(txtP_Addr2.Text));
                dictionaryInstance.Add("City", Convert.ToString(ddlP_City.SelectedValue));
                dictionaryInstance.Add("State", Convert.ToString(ddlP_State.SelectedValue));
                dictionaryInstance.Add("PinCode", Convert.ToString(txtP_PinCode.Text));
                dictionaryInstance.Add("TelePhoneNo", Convert.ToString(txtP_Tel.Text));
                dictionaryInstance.Add("FaxNo", Convert.ToString(txtP_FAX.Text));
                dictionaryInstance.Add("EmailId", Convert.ToString(txtP_Email.Text));
                dictionaryInstance.Add("MobileNo", Convert.ToString(txtP_Mobile1.Text));
                dictionaryInstance.Add("WeeklyOff", Convert.ToString(ddlP_WeekOff1.SelectedValue));
                dictionaryInstance.Add("Manager1Name", funclib.FirstCap(txtP_Mgr1Name.Text));
                dictionaryInstance.Add("Manager1Desgn", funclib.FirstCap(txtP_Mgr1Desig.Text));
                dictionaryInstance.Add("Manager1Mobile", Convert.ToString(txtP_Mgr1Mobile.Text));
                dictionaryInstance.Add("Manager1Email", Convert.ToString(txtP_Mgr1Email.Text));
                dictionaryInstance.Add("Manager2Name", funclib.FirstCap(txtP_Mgr2Name.Text));
                dictionaryInstance.Add("Manager2Desgn", funclib.FirstCap(txtP_Mgr2Desig.Text));
                dictionaryInstance.Add("Manager2Mobile", Convert.ToString(txtP_Mgr2Mobile.Text));
                dictionaryInstance.Add("Manager2Email", Convert.ToString(txtP_Mgr2Email.Text));
                dictionaryInstance.Add("PANNo", Convert.ToString(txtPAN_No.Text));
                dictionaryInstance.Add("IsTopPaper", Convert.ToString(ddlP_TopPaper.SelectedValue));
                dictionaryInstance.Add("GSTNo", Convert.ToString(txtGSTNo.Text));
                dictionaryInstance.Add("VATTINNo", Convert.ToString(txtP_Tin.Text));
                dictionaryInstance.Add("ECCNo", Convert.ToString(txtP_ECC.Text));
                dictionaryInstance.Add("CSTNo", Convert.ToString(txtP_CST.Text));
                dictionaryInstance.Add("LBTNo", Convert.ToString(txtLBT_No.Text));
                dictionaryInstance.Add("IsCForm", Convert.ToString(ddlP_CForm.SelectedValue));
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlP_Active.SelectedValue));
                dictionaryInstance.Add("CreditDays", Convert.ToString(txtP_CrDays.Text));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeletePartyMasterData(dictionaryInstance);
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
                if (ddlP_Name.SelectedIndex == 0)
                {
                    strError = "Please Select Main Party    ";
                }
                if (string.IsNullOrEmpty(txtP_Name.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Party Name   ";
                }
                if (string.IsNullOrEmpty(txtP_Addr1.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Party Address    ";
                }
                if (ddlP_City.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Party City   ";
                }
                if (ddlP_State.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Party State   ";
                }
                if (string.IsNullOrEmpty(txtP_PinCode.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Party Pin Code    ";
                }
                if (string.IsNullOrEmpty(txtP_Tel.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Party Telephone Number    ";
                }
                if (ddlP_WeekOff1.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Weekly Off   ";
                }
                if (string.IsNullOrEmpty(txtPAN_No.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter PAN Number    ";
                }
                if (ddlP_TopPaper.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Top Paper   ";
                }
                if (string.IsNullOrEmpty(txtGSTNo.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter GST Number    ";
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