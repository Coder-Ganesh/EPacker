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
using OfficeOpenXml.Style;
using System.IO;

namespace ePacker1
{
    public partial class RPeP_MasterMachine : Form
    { 
        //Page Developed by Shirish Phadnis on(15/3/2011)
        private FunctionLib funclib;
        string strMName, session, strSQL, Group_ID;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterMachine()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtM_ID.Visible = false;
        }

        private void RPeP_MasterMachine_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strcon);

                DataTable dtAllActiveMachineTypes = bl.GetAllActiveMachineType();
                if (dtAllActiveMachineTypes != null)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtAllActiveMachineTypes);
                    ddlM_Type.DataSource = dtAllActiveMachineTypes;
                    ddlM_Type.DisplayMember = dtAllActiveMachineTypes.Columns[0].ToString();
                    ddlM_Type.ValueMember = dtAllActiveMachineTypes.Columns[0].ToString();
                }
                dtAllActiveMachineTypes = bl.GetAllActiveMachineType();
                if (dtAllActiveMachineTypes != null)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtAllActiveMachineTypes);
                    ddlM_Type_Search.DataSource = dtAllActiveMachineTypes;
                    ddlM_Type_Search.DisplayMember = dtAllActiveMachineTypes.Columns[0].ToString();
                    ddlM_Type_Search.ValueMember = dtAllActiveMachineTypes.Columns[0].ToString();
                }

                DataTable dtActive = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActive);
                ddlM_Active.DataSource = dtActive;
                ddlM_Active.DisplayMember = dtActive.Columns[0].ToString();
                ddlM_Active.ValueMember = dtActive.Columns[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while loading page " + ex.Message);
            }          
        }

        private void txtM_Name_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //Validating P_Name Text Field
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
                        double flag = funclib.isThere(con, "select M_Name,Grp_ID from Machine_Master where M_Name='" + txtM_Name.Text + "'and Grp_ID='" + Group_ID + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Group and Machine Name is not allowed");
                        }
                        else
                        {
                            string mid = funclib.AutoKey1("MC", con, "select M_ID from Machine_Master order by M_ID desc");
                            bool result = AddEditDeleteMachineMasterData("A", mid);
                            if (result)
                            {
                                MessageBox.Show("Record Inserted");
                            }
                            else
                            { MessageBox.Show("There was an error while Inserting data"); }
                            filldata();
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

        private void filldata()
        {
            //to fill the grid with user details
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select a.M_ID as MachineID,b.Grp_Name  as GroupName,a.M_Name as MachineName,a.M_Type as Type,a.M_Active as Active,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On from Machine_Master a, Group_Master b where b.Grp_ID = a.Grp_ID and a.Grp_ID = '"+Group_ID +"'", con4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRPeP_MasterMachine.DataSource = dt;
                this.dgvRPeP_MasterMachine.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while binding Machine Data to Grid " + ex.Message);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select a.M_ID as MachineID,b.Grp_Name  as GroupName,a.M_Name as MachineName,a.M_Type as Type,a.M_Active as Active,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On from Machine_Master a, Group_Master b where b.Grp_ID = a.Grp_ID and a.Grp_ID = '" + Group_ID + "' and M_Type ='" + ddlM_Type_Search.SelectedValue.ToString() + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRPeP_MasterMachine.DataSource = dt;
                if (dgvRPeP_MasterMachine.Rows.Count == 0)
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
                MessageBox.Show("There was an Error while Searching " + ex.Message);
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
                        bool result = AddEditDeleteMachineMasterData("E", txtM_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        filldata();
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

        private void dgvRPeP_MasterMachine_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlM_Active.Enabled = true; 
            ddlGrp_ID.Enabled = false;
            txtM_Name.Enabled = false;
            ddlM_Type.Enabled = false;
            //Displaying grid data in form
            txtM_ID.Text = dgvRPeP_MasterMachine.Rows[e.RowIndex].Cells[0].Value.ToString();
            //ddlGrp_ID.Text = dgvRPeP_MasterMachine.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtM_Name.Text = dgvRPeP_MasterMachine.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlM_Type.Text = dgvRPeP_MasterMachine.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlM_Active.Text = dgvRPeP_MasterMachine.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();            
        }

        private void clearAll()
        {
            //Clearing form data
            ddlGrp_ID.Text = "";
            txtM_Name.Clear();            
            ddlM_Type.SelectedIndex = 0;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            cmdEdit.Visible = false;
            cmdEdit.Enabled = false;
            btnDelete.Visible = false;
            ddlGrp_ID.Enabled = true;
            txtM_Name.Enabled = true;
            ddlM_Type.Enabled = true;
            ddlM_Active.SelectedIndex = 0;
            ddlM_Type_Search.SelectedIndex = 0;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = AddEditDeleteMachineMasterData("D", txtM_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    filldata();
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
                        System.Data.DataTable table = dgvRPeP_MasterMachine.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Contractor Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgvRPeP_MasterMachine.Columns.Count])
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

        private bool AddEditDeleteMachineMasterData(string action, string MachineId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("MachineId", MachineId);
                dictionaryInstance.Add("MachineName", funclib.FirstCap(txtM_Name.Text));                
                dictionaryInstance.Add("MachineType", Convert.ToString(ddlM_Type.SelectedValue));           
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlM_Active.SelectedValue));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeleteMachineMasterData(dictionaryInstance);
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
                    strError = strError + Environment.NewLine + "Please Enter Machine Name   ";
                }             
                if (ddlM_Type.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Machine Type   ";
                }                
                if (ddlM_Active.SelectedIndex == 0)
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