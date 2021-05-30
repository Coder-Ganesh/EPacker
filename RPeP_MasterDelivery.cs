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
    public partial class RPeP_MasterDelivery : Form
    {
        //Page Developed by Shirish Phadnis on(14/03/2011).
        string session, strSQL, Group_ID;
        private FunctionLib funcLib;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterDelivery()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            BindDeliveryMasterDataToGrid();          
            txtDelv_ID.Visible = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            cmdSubmit.Visible = true;
        }

        private void RPeP_MasterDelivery_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);

            //Displayig City Name in Combo field
            DataTable dtAllCityMaster = bl.GetAllCityMaster();
            if (dtAllCityMaster != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllCityMaster);
                ddlDelv_City.DataSource = dtAllCityMaster;
                ddlDelv_City.DisplayMember = dtAllCityMaster.Columns[0].ToString();
                ddlDelv_City.ValueMember = dtAllCityMaster.Columns[0].ToString();
            }

            //Displayig State Name in Combo field
            DataTable dtAllStateMaster = bl.GetAllStateMaster();
            if (dtAllStateMaster != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllStateMaster);
                ddlDelv_State.DataSource = dtAllStateMaster;
                ddlDelv_State.DisplayMember = dtAllStateMaster.Columns[0].ToString();
                ddlDelv_State.ValueMember = dtAllStateMaster.Columns[0].ToString();
            }

            //Displaying Active value in Combo field
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlDelv_Active.DataSource = dtActive;
            ddlDelv_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlDelv_Active.ValueMember = dtActive.Columns[0].ToString();

            //Display value in PM_Search combo field
            con1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT a.PM_ID,a.PM_Name from PartyMain_Master a,DelvPlace_Master b where  a.PM_ID=b.PM_ID", con1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1 != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dt1);
                ddlPM_ID_Search.DataSource = dt1;
                ddlPM_ID_Search.DisplayMember = dt1.Columns[1].ToString();
                ddlPM_ID_Search.ValueMember = dt1.Columns[0].ToString();
            }
          
            con1.Close();

            DataTable dtAllPartyMainMasterData = bl.GetAllPartyMainMasterData(Group_ID);
            if (dtAllPartyMainMasterData != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllPartyMainMasterData);
                ddlPM_ID.DataSource = dtAllPartyMainMasterData;
                ddlPM_ID.DisplayMember = dtAllPartyMainMasterData.Columns[1].ToString();
                ddlPM_ID.ValueMember = dtAllPartyMainMasterData.Columns[0].ToString();
            }

            DataTable dtAllRegionMasterData = bl.GetAllRegionDataByRegionName(Group_ID, "");
            if (dtAllRegionMasterData != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dtAllRegionMasterData);
                ddlRG_ID.DataSource = dtAllRegionMasterData;
                ddlRG_ID.DisplayMember = dtAllRegionMasterData.Columns[1].ToString();
                ddlRG_ID.ValueMember = dtAllRegionMasterData.Columns[0].ToString();
            }
        }

        private void ddlGrp_ID_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void ddlPM_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = bl.GetAllPartyMasterDataByMainPartyId(Group_ID, ddlPM_ID.SelectedValue.ToString(), "");
            if (dt != null)
            {
                GlobalFunctions.AddPleaseSelect(ref dt);
                ddlP_ID.DataSource = dt;
                ddlP_ID.DisplayMember = dt.Columns[4].ToString();
                ddlP_ID.ValueMember = dt.Columns[0].ToString();
            }
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
                        double flag = funcLib.isThere(con, "select PM_ID,Grp_ID,P_ID,Rg_ID from DelvPlace_Master where PM_ID='" + ddlPM_ID.SelectedValue.ToString() + "' and Grp_ID='" + Group_ID + "' and P_ID='" + ddlP_ID.SelectedValue.ToString() + "' and Rg_ID='" + ddlRG_ID.SelectedValue.ToString() + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Party (Main), Party, Group and Region is not allowed");
                        }
                        else
                        {
                            //Inserting records in Table DelvPlace_Master
                            string delvid = funcLib.AutoKey1("DL", con, "select Delv_ID from DelvPlace_Master order by Delv_ID desc");
                            bool result = AddEditDeleteDeliveryMasterData("A", delvid);
                            if (result)
                            {
                                MessageBox.Show("Record Inserted");
                            }
                            else
                            { MessageBox.Show("There was an error while Inserting data"); }
                            BindDeliveryMasterDataToGrid();
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

        private void BindDeliveryMasterDataToGrid()
        {
            try
            {
                DataTable dt = bl.GetAllDeliveryMasterDataByPartyIdName(Group_ID, "", "");
                if (dt != null)
                {
                    dgwDeliveryMaster.DataSource = dt;
                    this.dgwDeliveryMaster.Columns[0].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while fetching Agent Master Data " + ex.Message); }
        }

        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgwDeliveryMaster_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Visible = false;
            ddlDelv_Active.Enabled = true;
            //to display data in form on click of datagridview named dgwDeliveryMaster.
            txtDelv_ID.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[0].Value.ToString();
            ddlPM_ID.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlP_ID.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlRG_ID.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDelv_Addr1.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDelv_Addr2.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[6].Value.ToString();
            ddlDelv_City.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[7].Value.ToString();
            ddlDelv_State.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtDelv_PinCode.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtDelv_Tel.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtDelv_FAX.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtDelv_Email.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[12].Value.ToString();
            ddlDelv_Active.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[13].Value.ToString();
            ddlP_ID.Enabled = false;
            ddlGrp_ID.Enabled = false;
            ddlPM_ID.Enabled = false;
            ddlRG_ID.Enabled = false;
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
                        bool result = AddEditDeleteDeliveryMasterData("E", txtDelv_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        BindDeliveryMasterDataToGrid();
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

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterDelivery form
            clearAll();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            ddlGrp_ID.Text = "";
            ddlPM_ID.SelectedIndex = 0;
            ddlP_ID.SelectedIndex = 0;
            ddlRG_ID.SelectedIndex = 0;
            ddlDelv_State.SelectedIndex = 0;
            ddlDelv_City.SelectedIndex = 0;
            ddlDelv_Active.SelectedIndex = 0;
            txtDelv_Addr1.Text = "";
            txtDelv_Addr2.Text = "";
            txtDelv_Email.Text = "";
            txtDelv_FAX.Text = "";
            txtDelv_PinCode.Text = "";
            txtDelv_Tel.Text = "";
            ddlDelv_Active.SelectedIndex = 0;
            cmdSubmit.Enabled = true;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtP_Name_Search.Text = "";
        }

        private void txtDelv_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDelv_Addr1 Text Field
            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);
            int P_AddressData = funcLib.countChar(e, txtDelv_Addr1.Text);
            lblAddrone.Text = "(Character " + P_AddressData + "  " + "Out of" + txtDelv_Addr1.MaxLength + ")";
        }

        private void txtDelv_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDelv_Addr2 Text Field
            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);
            int P_AddressData = funcLib.countChar(e, txtDelv_Addr2.Text);
            lblAddrtwo.Text = "(Character " + P_AddressData + "  " + "Out of" + txtDelv_Addr2.MaxLength + ")";
        }

        private void txtDelv_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDelv_PinCode Text Field
            funcLib = new FunctionLib();
            funcLib.onlyNumbers(e);
        }

        private void txtDelv_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDelv_Tel Text Field
            funcLib = new FunctionLib();
            funcLib.onlyNumbers(e);
        }

        private void txtDelv_FAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDelv_FAX Text Field
            funcLib = new FunctionLib();
            funcLib.onlyNumbers(e);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search (P_Name) data from table DelvPlace_Master
            try
            {
                DataTable dt = bl.GetAllDeliveryMasterDataByPartyIdName(Group_ID, Convert.ToString(ddlPM_ID_Search.SelectedValue), Convert.ToString(txtP_Name_Search.Text));
                if (dt != null)
                {
                    dgwDeliveryMaster.DataSource = dt;
                    this.dgwDeliveryMaster.Columns[0].Visible = false;
                    this.dgwDeliveryMaster.Columns[1].Visible = false;
                    if (dgwDeliveryMaster.Rows.Count == 0)
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
            //Code to close MasterDelivery form temporarily.
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
                        System.Data.DataTable table = dgwDeliveryMaster.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Delivery Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwDeliveryMaster.Columns.Count])
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
                    bool result = AddEditDeleteDeliveryMasterData("D", txtDelv_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    BindDeliveryMasterDataToGrid();
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

        private bool AddEditDeleteDeliveryMasterData(string action, string DeliveryId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("DeliveryId", DeliveryId);
                dictionaryInstance.Add("PartyMainId", Convert.ToString(ddlPM_ID.SelectedValue));
                dictionaryInstance.Add("PartyId", Convert.ToString(ddlP_ID.SelectedValue));
                dictionaryInstance.Add("RegionId", Convert.ToString(ddlRG_ID.SelectedValue));
                dictionaryInstance.Add("AddressLine1", funcLib.FirstCap(txtDelv_Addr1.Text));
                dictionaryInstance.Add("AddressLine2", funcLib.FirstCap(txtDelv_Addr2.Text));
                dictionaryInstance.Add("City", Convert.ToString(ddlDelv_City.SelectedValue));
                dictionaryInstance.Add("State", Convert.ToString(ddlDelv_State.SelectedValue));
                dictionaryInstance.Add("PinCode", Convert.ToString(txtDelv_PinCode.Text));
                dictionaryInstance.Add("TelePhoneNo", Convert.ToString(txtDelv_Tel.Text));
                dictionaryInstance.Add("FaxNo", Convert.ToString(txtDelv_FAX.Text));
                dictionaryInstance.Add("EmailId", Convert.ToString(txtDelv_Email.Text));
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlDelv_Active.SelectedValue));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeleteDeliveryMasterData(dictionaryInstance);
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
                if (ddlPM_ID.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Party Main   ";
                }
                if (ddlP_ID.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Party   ";
                }
                if (ddlRG_ID.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Region   ";
                }
                if (ddlDelv_City.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select City   ";
                }
                if (ddlDelv_State.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select State   ";
                }
                if (ddlDelv_Active.SelectedIndex == 0)
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