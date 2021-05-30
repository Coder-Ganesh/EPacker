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
using ePacker1.Business_Entity;

namespace ePacker1
{
    public partial class RPeP_MasterAgent : Form
    {
        string session, Group_ID;
        //Page Developed by Shirish Phadnis on(8/3/2011)
        private FunctionLib funclib;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterAgent()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            BindAgentMasterDataToGrid();
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtA_ID.Visible = false;
        }

        private void RPeP_MasterAgent_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);

            //Displayig City Name in Combo field
            DataTable dtAllCityMaster = bl.GetAllCityMaster();
            if (dtAllCityMaster != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllCityMaster);
                ddlA_City.DataSource = dtAllCityMaster;
                ddlA_City.DisplayMember = dtAllCityMaster.Columns[0].ToString();
                ddlA_City.ValueMember = dtAllCityMaster.Columns[0].ToString();
            }

            DataTable dtAllStateMaster = bl.GetAllStateMaster();
            if (dtAllStateMaster != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllStateMaster);
                ddlA_State.DataSource = dtAllStateMaster;
                ddlA_State.DisplayMember = dtAllStateMaster.Columns[0].ToString();
                ddlA_State.ValueMember = dtAllStateMaster.Columns[0].ToString();
            }

            //Displaying category value in Combo field
            ddlA_Cate.Items.Add("Purchase");
            ddlA_Cate.Items.Add("JobWork");

            //displaying type in Combo field
            ddlA_Type.Items.Add("Manufacturer");
            ddlA_Type.Items.Add("Dealer");

            //Displaying Active Values
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlA_Active.DataSource = dtActive;
            ddlA_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlA_Active.ValueMember = dtActive.Columns[0].ToString();

            //Displaying weeklyoff day
            con1.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("select B_Day from B_Cal", con1);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            GlobalFunctions.AddPleaseSelect(ref dt4);
            ddlA_WeekOff.DataSource = dt4;
            ddlA_WeekOff.DisplayMember = dt4.Columns[0].ToString();
            ddlA_WeekOff.ValueMember = dt4.Columns[0].ToString();
            con1.Close();
        }

        private void txtA_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtA_Name_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //Validating A_Name Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtA_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Addr1 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtA_Addr1.Text);
            lblAddress1.Text = "(Character " + P_AddressData + "  " + "Out of" + txtA_Addr1.MaxLength + ")";
        }

        private void txtA_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Addr2 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtA_Addr2.Text);
            lbladdress2.Text = "(Character " + P_AddressData + "  " + "Out of" + txtA_Addr2.MaxLength + ")";
        }

        private void txtA_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_PinCode Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtA_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Tel Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtA_FAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_FAX Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtA_Mgr1Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr1Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtA_Mgr2Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr2Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtA_Mgr1Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr1Name Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtA_Mgr2Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr2Name Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtA_Mgr1Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr1Desig Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtA_Mgr2Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr2Desig Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtA_ECC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_ECC Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtA_BST_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_BST Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtA_CST_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_CST Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtA_CrDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_CrDays Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtA_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPAN_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating PAN_No Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtA_Regn_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Regn Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtA_Tin_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
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
                        double flag = funclib.isThere(con, "select A_Name ,Grp_ID from Agent_Master where A_Name='" + txtA_Name.Text + "' and Grp_ID='" + Group_ID + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Party Name, Party (Main) and Group is not allowed");
                        }
                        else
                        {
                            if ((ddlA_Cate.SelectedItem.ToString().Equals("Purchase") == true) && (ddlA_Type.SelectedItem.ToString().Equals("Manufacturer") == true))
                            {
                                MessageBox.Show("As Agent Type is Manufacturer, Mill will be automatically added with same details.");
                            }
                            string AgentIdd = funclib.AutoKey("A", con, "select A_ID from Agent_Master order by A_ID desc");
                            string Millid = funclib.AutoKey("M", con, "select M_ID from Mill_Master order by M_ID desc");
                            bool result = AddEditDeleteAgentMasterData("A", AgentIdd, Millid);
                            if (result)
                            {
                                MessageBox.Show("Record Inserted Sucessfully");
                            }
                            else
                            { MessageBox.Show("There was an error while inserting data"); }
                            BindAgentMasterDataToGrid();
                            clearAll();
                        }
                    }
                    else
                    {
                        cmdSubmit.Focus();
                    }
                    con.Close();
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

        //to fill the Datagridview with user details named dgwMasterAgent 
        private void BindAgentMasterDataToGrid()
        {
            try
            {
                DataTable lstAllAgent = bl.GetAllAgentDataByAgentName(Group_ID, "");
                if (lstAllAgent != null)
                {
                    dgwMasterAgent.DataSource = lstAllAgent;
                    this.dgwMasterAgent.Columns[0].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while fetching Agent Master Data " + ex.Message); }
        }

        private void clearAll()
        {
            //Clear all fields
            ddlGrp_ID.Text = "";
            txtA_Name.Clear();
            txtA_Addr1.Clear();
            txtA_Addr2.Clear();
            txtLBT_No.Clear();
            txtA_CST.Clear();
            ddlA_City.Text = "";
            ddlA_State.Text = "";
            txtA_Email.Clear();
            txtA_FAX.Clear();
            txtA_Mgr1Desig.Clear();
            txtA_Mobile.Clear();
            ddlA_WeekOff.Text = "";
            txtA_Mgr1Email.Clear();
            txtA_Mgr1Mobile.Clear();
            txtA_Mgr1Name.Clear();
            txtA_Mgr2Desig.Clear();
            txtA_Mgr2Email.Clear();
            txtA_Mgr2Name.Clear();
            txtA_Mgr2Mobile.Clear();
            txtA_CrDays.Clear();
            txtA_PinCode.Clear();
            txtA_ECC.Clear();
            txtA_Tel.Clear();
            txtA_Tin.Clear();
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            ddlA_Active.SelectedIndex = 0;
            ddlA_Active.Enabled = true;
            txtA_Addr1.Focus();
            ddlGrp_ID.Enabled = true;
            txtA_Name.Enabled = true;
            ddlA_Type.Enabled = true;
            ddlA_Cate.Enabled = true;
            txtA_Regn.Clear();
            txtPAN_No.Clear();
            txtGSTNo.Text = "";
        }

        private void ddlA_Cate_SelectedIndexChanged(object sender, EventArgs e)
        {           
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable lstAllAgent = bl.GetAllAgentDataByAgentName(Group_ID, Convert.ToString(txtA_Name_Search.Text));
                if (lstAllAgent != null)
                {
                    dgwMasterAgent.DataSource = lstAllAgent;
                    this.dgwMasterAgent.Columns[0].Visible = false;
                    if (dgwMasterAgent.Rows.Count == 0)
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

        private void dgwMasterAgent_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlA_Active.Enabled = true;

            //to display data in form on click of datagridview named dgwMasterAgent
            txtA_ID.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtA_Name.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtA_Addr1.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtA_Addr2.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlA_City.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlA_State.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtA_PinCode.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtA_Tel.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtA_FAX.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtA_Email.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtA_Mobile.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[11].Value.ToString();
            ddlA_WeekOff.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtA_Mgr1Name.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtA_Mgr1Desig.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtA_Mgr1Mobile.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtA_Mgr1Email.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[16].Value.ToString();
            txtA_Mgr2Name.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtA_Mgr2Desig.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtA_Mgr2Mobile.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[19].Value.ToString();
            txtA_Mgr2Email.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[20].Value.ToString();
            txtGSTNo.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[21].Value.ToString();
            txtA_ECC.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[22].Value.ToString();
            txtA_Regn.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[23].Value.ToString();
            txtLBT_No.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[24].Value.ToString();
            txtA_CST.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[25].Value.ToString();
            ddlA_Type.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[26].Value.ToString();
            ddlA_Cate.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[27].Value.ToString();
            txtA_CrDays.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[28].Value.ToString();
            ddlA_Active.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[29].Value.ToString();
            txtPAN_No.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[30].Value.ToString();
            txtA_Tin.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[31].Value.ToString();
            txtA_Name.Enabled = false;
            ddlGrp_ID.Enabled = false;
            ddlA_Cate.Enabled = false;
            ddlA_Type.Enabled = false;
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
                        bool result = AddEditDeleteAgentMasterData("E", txtA_ID.Text, "");
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        BindAgentMasterDataToGrid();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = AddEditDeleteAgentMasterData("D", txtA_ID.Text, "");
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    BindAgentMasterDataToGrid();
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
            //Clearing all fields & refreshes the AgentMaster form
            clearAll();
        }

        private void ddlA_Cate_SelectedValueChanged(object sender, EventArgs e)
        {
            string str = ddlA_Cate.SelectedItem.ToString();
            if (str.Equals("Purchase") == true)
            {
                ddlA_Type.Enabled = true;
            }
            if (str.Equals("JobWork") == true)
            {
                ddlA_Type.Enabled = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Code to close AgentMaster form temporarily 
            this.Close();
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
                        System.Data.DataTable table = dgwMasterAgent.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("AgentMaster");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwMasterAgent.Columns.Count])
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

        private bool AddEditDeleteAgentMasterData(string action, string AgentId, string MillId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("AgentId", AgentId);
                dictionaryInstance.Add("MillId", MillId);
                dictionaryInstance.Add("AgentName", funclib.FirstCap(txtA_Name.Text));
                dictionaryInstance.Add("AddressLine1", funclib.FirstCap(txtA_Addr1.Text));
                dictionaryInstance.Add("AddressLine2", funclib.FirstCap(txtA_Addr2.Text));
                dictionaryInstance.Add("City", Convert.ToString(ddlA_City.SelectedValue));
                dictionaryInstance.Add("State", Convert.ToString(ddlA_State.SelectedValue));
                dictionaryInstance.Add("PinCode", Convert.ToString(txtA_PinCode.Text));
                dictionaryInstance.Add("TelePhoneNo", Convert.ToString(txtA_Tel.Text));
                dictionaryInstance.Add("FaxNo", Convert.ToString(txtA_FAX.Text));
                dictionaryInstance.Add("EmailId", Convert.ToString(txtA_Email.Text));
                dictionaryInstance.Add("MobileNo", Convert.ToString(txtA_Mobile.Text));
                dictionaryInstance.Add("WeeklyOff", Convert.ToString(ddlA_WeekOff.SelectedValue));
                dictionaryInstance.Add("Manager1Name", funclib.FirstCap(txtA_Mgr1Name.Text));
                dictionaryInstance.Add("Manager1Desgn", funclib.FirstCap(txtA_Mgr1Desig.Text));
                dictionaryInstance.Add("Manager1Mobile", Convert.ToString(txtA_Mgr1Mobile.Text));
                dictionaryInstance.Add("Manager1Email", Convert.ToString(txtA_Mgr1Email.Text));
                dictionaryInstance.Add("Manager2Name", funclib.FirstCap(txtA_Mgr2Name.Text));
                dictionaryInstance.Add("Manager2Desgn", funclib.FirstCap(txtA_Mgr2Desig.Text));
                dictionaryInstance.Add("Manager2Mobile", Convert.ToString(txtA_Mgr2Mobile.Text));
                dictionaryInstance.Add("Manager2Email", Convert.ToString(txtA_Mgr2Email.Text));
                dictionaryInstance.Add("PANNo", Convert.ToString(txtPAN_No.Text));
                dictionaryInstance.Add("GSTNo", Convert.ToString(txtGSTNo.Text));
                dictionaryInstance.Add("RegnNo", Convert.ToString(txtA_Regn.Text));
                dictionaryInstance.Add("ECCNo", Convert.ToString(txtA_ECC.Text));
                dictionaryInstance.Add("CSTNo", Convert.ToString(txtA_CST.Text));
                dictionaryInstance.Add("LBTNo", Convert.ToString(txtLBT_No.Text));
                dictionaryInstance.Add("Type", Convert.ToString(ddlA_Type.SelectedItem));
                dictionaryInstance.Add("Category", Convert.ToString(ddlA_Cate.SelectedItem));
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlA_Active.SelectedValue));
                dictionaryInstance.Add("CreditDays", Convert.ToString(txtA_CrDays.Text));
                dictionaryInstance.Add("VATTINNo", Convert.ToString(txtA_Tin.Text));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeleteAgentMasterData(dictionaryInstance);
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
                if (string.IsNullOrEmpty(txtA_Name.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Agent Name   ";
                }
                if (string.IsNullOrEmpty(txtA_Addr1.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Agent Address    ";
                }
                if (ddlA_City.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Agent City   ";
                }
                if (ddlA_State.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Agent State   ";
                }
                if (ddlA_WeekOff.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Weekly Off   ";
                }
                if (string.IsNullOrEmpty(txtPAN_No.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter PAN Number    ";
                }
                if (string.IsNullOrEmpty(txtA_Regn.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Registration Number    ";
                }
                if (ddlA_Type.Text == "")
                {
                    strError = strError + Environment.NewLine + "Please Select Type   ";
                }
                if (ddlA_Cate.Text == "")
                {
                    strError = strError + Environment.NewLine + "Please Select Category   ";
                }
                if (ddlA_Active.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Active   ";
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