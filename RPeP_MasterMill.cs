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
    public partial class RPeP_MasterMill : Form
    {
        //Page Developed by Ashwin Prabhu on(8/3/2011)
        string session, strSQL, Group_ID;
        private FunctionLib funclib;
        string strMill, strMgr1, strMgr2, strDesg1, strDesg2;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterMill()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            BindMillMasterDataToGrid();
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
        }

        private void RPeP_MasterMill_Load(object sender, EventArgs e)
        {
            try
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
                    ddlM_City.DataSource = dtAllCityMaster;
                    ddlM_City.DisplayMember = dtAllCityMaster.Columns[0].ToString();
                    ddlM_City.ValueMember = dtAllCityMaster.Columns[0].ToString();
                }

                DataTable dtAllStateMaster = bl.GetAllStateMaster();
                if (dtAllStateMaster != null)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtAllStateMaster);
                    ddlM_State.DataSource = dtAllStateMaster;
                    ddlM_State.DisplayMember = dtAllStateMaster.Columns[0].ToString();
                    ddlM_State.ValueMember = dtAllStateMaster.Columns[0].ToString();
                }

                //Displaying weekoff day
                con1.Open();
                SqlDataAdapter da4 = new SqlDataAdapter("select B_Day from B_Cal", con1);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                GlobalFunctions.AddPleaseSelect(ref dt4);
                ddlM_WeekOff.DataSource = dt4;
                ddlM_WeekOff.DisplayMember = dt4.Columns[0].ToString();
                ddlM_WeekOff.ValueMember = dt4.Columns[0].ToString();
                con1.Close();

                //Displaying Active Values
                DataTable dtActive = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActive);
                ddlM_Active.DataSource = dtActive;
                ddlM_Active.DisplayMember = dtActive.Columns[0].ToString();
                ddlM_Active.ValueMember = dtActive.Columns[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while loading the Page " + ex.Message);
            }
        }

        private void txtM_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Name Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtM_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Addr1 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtM_Addr1.Text);
            lblAddress1Count.Text = "(Character " + P_AddressData + "  " + "Out of" + txtM_Addr1.MaxLength + ")";
        }

        private void txtM_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Addr2 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtM_Addr2.Text);
            lblAddress2Count.Text = "(Character " + P_AddressData + "  " + "Out of" + txtM_Addr2.MaxLength + ")";
        }

        private void txtM_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_PinCode Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtM_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Tel Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtM_FAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_FAX Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtM_Mgr1Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mgr1Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtM_Mgr2Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mgr2Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtM_Mgr1Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mgr1Name Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtM_Mgr2Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mgr2Name Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtM_Mgr1Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mgr1Desig Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtM_Mgr2Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mgr2Desig Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtM_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            //Clear all fields
            txtM_ID.Clear();
            ddlGrp_ID.Text = "";
            txtM_Name.Clear();
            txtM_Addr1.Clear();
            txtM_Addr2.Clear();
            ddlM_City.Text = "";
            ddlM_State.Text = "";
            txtM_PinCode.Clear();
            txtM_Tel.Clear();
            txtM_Email.Clear();
            txtM_FAX.Clear();
            txtM_Mgr1Desig.Clear();
            txtM_Mobile.Clear();
            ddlM_WeekOff.Text = "";
            txtM_Mgr1Email.Clear();
            txtM_Mgr1Mobile.Clear();
            txtM_Mgr1Name.Clear();
            txtM_Mgr2Desig.Clear();
            txtM_Mgr2Email.Clear();
            txtM_Mgr2Name.Clear();
            txtM_Mgr2Mobile.Clear();
            ddlGrp_ID.Enabled = true;
            txtM_Name.Enabled = true;

            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = true;
            ddlM_Active.SelectedIndex = 0;
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
                        double flag = funclib.isThere(con, "select M_Name,Grp_ID from Mill_Master where M_Name='" + txtM_Name.Text + "'and Grp_ID='" + Group_ID + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Mill Name and Group is not allowed");
                        }
                        else
                        {
                            //Inserting Details into table
                            string mid = funclib.AutoKey("M", con, "select M_ID from Mill_Master order by M_ID desc");
                            bool result = AddEditDeleteMillMasterData("A", mid);
                            if (result)
                            {
                                MessageBox.Show("Record Inserted Sucessfully");
                            }
                            else
                            { MessageBox.Show("There was an error while inserting data"); }
                            BindMillMasterDataToGrid();
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

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string strValidationError = Validation();
                if (string.IsNullOrEmpty(strValidationError))
                {
                    if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool result = AddEditDeleteMillMasterData("E", txtM_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        BindMillMasterDataToGrid();
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
      
        private void BindMillMasterDataToGrid()
        {
            try
            {
                DataTable dtAllMillMasterData = bl.GetAllMillDataByMillName(Group_ID, "");
                if (dtAllMillMasterData != null)
                {
                    dgwMill_Master.DataSource = dtAllMillMasterData;
                    this.dgwMill_Master.Columns[0].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while fetching Agent Master Data " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = AddEditDeleteMillMasterData("D", txtM_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    BindMillMasterDataToGrid();
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
     

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table            
            try
            {
                DataTable dt = bl.GetAllMillDataByMillName(Group_ID, Convert.ToString(txtM_Name_Search.Text));
                if (dt != null)
                {
                    dgwMill_Master.DataSource = dt;
                    this.dgwMill_Master.Columns[0].Visible = false;
                    if (dgwMill_Master.Rows.Count == 0)
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

        private void dgwMill_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlM_Active.Enabled = true;
            txtM_Name.Enabled = false;
            ddlGrp_ID.Enabled = false;
            txtM_ID.Text = dgwMill_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtM_Name.Text = dgwMill_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtM_Addr1.Text = dgwMill_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtM_Addr2.Text = dgwMill_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlM_City.Text = dgwMill_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlM_State.Text = dgwMill_Master.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtM_PinCode.Text = dgwMill_Master.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtM_Tel.Text = dgwMill_Master.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtM_FAX.Text = dgwMill_Master.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtM_Email.Text = dgwMill_Master.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtM_Mobile.Text = dgwMill_Master.Rows[e.RowIndex].Cells[11].Value.ToString();
            ddlM_WeekOff.Text = dgwMill_Master.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtM_Mgr1Name.Text = dgwMill_Master.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtM_Mgr1Desig.Text = dgwMill_Master.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtM_Mgr1Mobile.Text = dgwMill_Master.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtM_Mgr1Email.Text = dgwMill_Master.Rows[e.RowIndex].Cells[16].Value.ToString();
            txtM_Mgr2Name.Text = dgwMill_Master.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtM_Mgr2Desig.Text = dgwMill_Master.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtM_Mgr2Mobile.Text = dgwMill_Master.Rows[e.RowIndex].Cells[19].Value.ToString();
            txtM_Mgr2Email.Text = dgwMill_Master.Rows[e.RowIndex].Cells[20].Value.ToString();
            txtGSTNo.Text = dgwMill_Master.Rows[e.RowIndex].Cells[21].Value.ToString();
            ddlM_Active.Text = dgwMill_Master.Rows[e.RowIndex].Cells[22].Value.ToString();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
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
                        System.Data.DataTable table = dgwMill_Master.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("MillMaster");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwMill_Master.Columns.Count])
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

        private bool AddEditDeleteMillMasterData(string action, string MillId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("MillId", MillId);
                dictionaryInstance.Add("MillName", funclib.FirstCap(txtM_Name.Text));
                dictionaryInstance.Add("AddressLine1", funclib.FirstCap(txtM_Addr1.Text));
                dictionaryInstance.Add("AddressLine2", funclib.FirstCap(txtM_Addr2.Text));
                dictionaryInstance.Add("City", Convert.ToString(ddlM_City.SelectedValue));
                dictionaryInstance.Add("State", Convert.ToString(ddlM_State.SelectedValue));
                dictionaryInstance.Add("PinCode", Convert.ToString(txtM_PinCode.Text));
                dictionaryInstance.Add("TelePhoneNo", Convert.ToString(txtM_Tel.Text));
                dictionaryInstance.Add("FaxNo", Convert.ToString(txtM_FAX.Text));
                dictionaryInstance.Add("EmailId", Convert.ToString(txtM_Email.Text));
                dictionaryInstance.Add("MobileNo", Convert.ToString(txtM_Mobile.Text));
                dictionaryInstance.Add("WeeklyOff", Convert.ToString(ddlM_WeekOff.SelectedValue));
                dictionaryInstance.Add("Manager1Name", funclib.FirstCap(txtM_Mgr1Name.Text));
                dictionaryInstance.Add("Manager1Desgn", funclib.FirstCap(txtM_Mgr1Desig.Text));
                dictionaryInstance.Add("Manager1Mobile", Convert.ToString(txtM_Mgr1Mobile.Text));
                dictionaryInstance.Add("Manager1Email", Convert.ToString(txtM_Mgr1Email.Text));
                dictionaryInstance.Add("Manager2Name", funclib.FirstCap(txtM_Mgr2Name.Text));
                dictionaryInstance.Add("Manager2Desgn", funclib.FirstCap(txtM_Mgr2Desig.Text));
                dictionaryInstance.Add("Manager2Mobile", Convert.ToString(txtM_Mgr2Mobile.Text));
                dictionaryInstance.Add("Manager2Email", Convert.ToString(txtM_Mgr2Email.Text));
                dictionaryInstance.Add("GSTNo", Convert.ToString(txtGSTNo.Text));
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlM_Active.SelectedValue));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeleteMillMasterData(dictionaryInstance);
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
                if (string.IsNullOrEmpty(txtM_Name.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Mill Name   ";
                }
                if (string.IsNullOrEmpty(txtM_Addr1.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Mill Address    ";
                }
                if (ddlM_City.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Mill City   ";
                }
                if (ddlM_State.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Mill State   ";
                }
                if (ddlM_WeekOff.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Weekly Off   ";
                }
                if (ddlM_Active.SelectedIndex == 0)
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