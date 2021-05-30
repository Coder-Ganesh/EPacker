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
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ePacker1
{
    public partial class RPeP_MasterMachineType : Form
    {
        string session; 
        private FunctionLib funclib;
        string strMType, strSQL, Group_ID;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterMachineType()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            filldata();
        }

        private void RPeP_MasterMachineType_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //Displaying Active Values
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlMT_Active.DataSource = dtActive;
            ddlMT_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlMT_Active.ValueMember = dtActive.Columns[0].ToString();
        }

        private void txtM_Name_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //Validating M_Type Text Field
            funclib = new FunctionLib();
            funclib.charNumber(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtM_Type.Text == "")//checking for blank Type combo field 
            {
                MessageBox.Show("Please Select Type");
                txtM_Type.Focus();
            }
            else if (ddlMT_Active.SelectedIndex == 0)//Checking for blnk Active field
            {
                MessageBox.Show("Select Active field");
                ddlMT_Active.Focus();
            }
            else
            {
                funclib = new FunctionLib();
                strMType = funclib.FirstCap(txtM_Type.Text);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Checking for duplicate values
                    double flag = funclib.isThere(con, "select M_Type from MachType_Master where M_Type='" + txtM_Type.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Machine Type is not allowed");
                    }
                    else
                    {
                        //Inserting Details into table
                        SqlCommand cmd = new SqlCommand("insert into MachType_Master values('" + strMType.Trim().Replace("'", "''").ToString() + "','" + ddlMT_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        filldata();
                        clearAll();
                    }                    
                }
            }
        }

        private void filldata()
        {
            //to fill the grid with user details
            cmdSearch.Enabled = true;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select M_Type,MT_Active,Add_By,Add_On,Mod_By,Mod_On from MachType_Master order by Add_On", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null)
            {
                dgwRPeP_MasterMachineType.DataSource = dt;
            }
        }

        private void dgwRPeP_MasterMachineType_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Displaying form data on click of grid
            txtM_Type.Enabled = false;
            ddlMT_Active.Enabled = true;
            cmdSearch.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            txtM_Type.Text = dgwRPeP_MasterMachineType.Rows[e.RowIndex].Cells[0].Value.ToString();
            ddlMT_Active.Text = dgwRPeP_MasterMachineType.Rows[e.RowIndex].Cells[1].Value.ToString();
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
                        bool result = AddEditDeleteMachineTypeMasterData("E");
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

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            //Clearing form data
            txtM_Type.Enabled = true;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            txtM_Type.Clear();
            ddlMT_Active.Text = "";
            ddlMT_Active.SelectedIndex = 0;                  
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            try
            {
                if (!string.IsNullOrEmpty(txtM_Type_Search.Text))
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("select * from MachType_Master where M_Type like '%" + txtM_Type_Search.Text + "%'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgwRPeP_MasterMachineType.DataSource = dt;
                    if (dgwRPeP_MasterMachineType.Rows.Count == 0)
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
                    MessageBox.Show("Please enter Machine Type name to Search ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was en arror while Search " + ex.Message);
            }                       
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
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
                        System.Data.DataTable table = dgwRPeP_MasterMachineType.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Machine Type Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwRPeP_MasterMachineType.Columns.Count])
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
                    bool result = AddEditDeleteMachineTypeMasterData("D");
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

        private bool AddEditDeleteMachineTypeMasterData(string action)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("MachineType", txtM_Type.Text);            
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlMT_Active.SelectedValue));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeleteMachineTypeMasterData(dictionaryInstance);
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
                if (string.IsNullOrEmpty(txtM_Type.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Machine Type  ";
                }             
                if (ddlMT_Active.SelectedIndex == 0)
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