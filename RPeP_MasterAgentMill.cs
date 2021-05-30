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
using ePacker1.Business_Entity;
using System.Linq;

namespace ePacker1
{
    public partial class RPeP_MasterAgentMill : Form
    {
        //Page Developed by Shirish Phadnis on(8/3/2011)
        private FunctionLib funclib;
        string strSQL, Group_ID, session;
        AllBusinessLogic bl = new AllBusinessLogic();
        List<AgentBE> lstAllAgent = new List<AgentBE>();
        public RPeP_MasterAgentMill()
        {
            InitializeComponent();           
            Group_ID = RPeP_LogIn.strGroup;
            session = RPeP_LogIn.strUser;
            BindAgentMillLinkMasterDataToGrid();
            btnDelete.Visible = false;
            cmdSubmit.Visible = true;
        }
       
        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterAgentMill form
            clearAll();
        }

        private void clearAll()
        {
            //Clear all fields
            ddlGrp_ID.Text = "";
            ddlA_Active.Text = "";
            ddlA_ID.Text = "";
            ddlM_ID.Text = "";
            ddlA_Active.SelectedIndex = 0;
            ddlA_ID.SelectedIndex = 0;
            ddlM_ID.SelectedIndex = 0;
            cmdSubmit.Visible = true;
            btnDelete.Visible = false;
        }

        private void RPeP_MasterAgentMill_Load(object sender, EventArgs e)
        {
            //Displaying Active Values
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlA_Active.DataSource = dtActive;
            ddlA_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlA_Active.ValueMember = dtActive.Columns[0].ToString();

            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);

            //Displayig Agent Name in Combo field 
            DataTable dtAllAgentMasterData = bl.GetAllActiveAgentDataByAgentName(Group_ID, "");            
            for (int index = dtAllAgentMasterData.Columns.Count - 1; index >= 2; index--)
            {
                dtAllAgentMasterData.Columns.RemoveAt(index);
            }
            GlobalFunctions.AddPleaseSelect(ref dtAllAgentMasterData);
            ddlA_ID.DataSource = dtAllAgentMasterData;
            ddlA_ID.DisplayMember = dtAllAgentMasterData.Columns[1].ToString();
            ddlA_ID.ValueMember = dtAllAgentMasterData.Columns[0].ToString();

            //Displayig Mill Name in Combo field    
            DataTable dtAllMillMasterData = bl.GetAllMillDataByMillName(Group_ID, "");
            for (int index = dtAllMillMasterData.Columns.Count - 1; index >= 2; index--)
            {
                dtAllMillMasterData.Columns.RemoveAt(index);
            }
            GlobalFunctions.AddPleaseSelect(ref dtAllMillMasterData);
            ddlM_ID.DataSource = dtAllMillMasterData;
            ddlM_ID.DisplayMember = dtAllMillMasterData.Columns[1].ToString();
            ddlM_ID.ValueMember = dtAllMillMasterData.Columns[0].ToString();
        }

        private void ddlGrp_ID_SelectedValueChanged(object sender, EventArgs e)
        {            
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
                        double flag = funclib.isThere(con, "select Grp_ID ,A_ID,M_ID from AgentMill_Link where Grp_ID='" + Group_ID + "' and A_ID='" + ddlA_ID.SelectedValue.ToString() + "' and M_ID='" + ddlM_ID.SelectedValue.ToString() + "'");
                        if (flag == 1)
                        {
                            MessageBox.Show("Cannot add this record as duplication of Group, Agent and Mill is not allowed");
                        }
                        else
                        {                            
                            bool result = AddDeleteAgentMillLinkData("A", ddlA_ID.SelectedValue.ToString(), ddlM_ID.SelectedValue.ToString());
                            if (result)
                            {
                                MessageBox.Show("Record Inserted Sucessfully");
                            }
                            else
                            { MessageBox.Show("There was an error while inserting data"); }
                            BindAgentMillLinkMasterDataToGrid();
                            clearAll();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(strValidationError);
                }
            }
            catch (Exception)
            {

                throw;
            }            
          
        }
     
        private void BindAgentMillLinkMasterDataToGrid()
        {
            try
            {
                DataTable dtAllAgentMillLinkMasterData = bl.GetAllAgentMillLinkMasterDataByAgent(Group_ID,"");
                if (dtAllAgentMillLinkMasterData != null)
                {
                    dgwAgentMill_Link.DataSource = dtAllAgentMillLinkMasterData;
                    this.dgwAgentMill_Link.Columns[0].Visible = false;
                    this.dgwAgentMill_Link.Columns[1].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while fetching Agent Mill Link Master Data " + ex.Message); }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DataTable dtAllAgentMillLinkMasterData = bl.GetAllAgentMillLinkMasterDataByAgent(Group_ID, txtA_Name_Search.Text);
            if (dtAllAgentMillLinkMasterData != null)
            {
                dgwAgentMill_Link.DataSource = dtAllAgentMillLinkMasterData;                
                if (dgwAgentMill_Link.Rows.Count == 0)
                {
                    cmdExcelReport.Visible = false;
                }
                else
                {
                    cmdExcelReport.Visible = true;
                }
            }
        }

        private void cmdAgentSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtAllAgentMasterData = bl.GetAllActiveAgentDataByAgentName(Group_ID, txtAgent_Search.Text);
                for (int index = dtAllAgentMasterData.Columns.Count - 1; index >= 2; index--)
                {
                    dtAllAgentMasterData.Columns.RemoveAt(index);
                }
                GlobalFunctions.AddPleaseSelect(ref dtAllAgentMasterData);
                ddlA_ID.DataSource = dtAllAgentMasterData;
                ddlA_ID.DisplayMember = dtAllAgentMasterData.Columns[1].ToString();
                ddlA_ID.ValueMember = dtAllAgentMasterData.Columns[0].ToString();
                txtAgent_Search.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Searching " + ex.Message);
            }
        }

        private void cmdMillSearch_Click(object sender, EventArgs e)
        {
            DataTable dtAllMillMasterData = bl.GetAllMillDataByMillName(Group_ID, txtMill_Search.Text);
            for (int index = dtAllMillMasterData.Columns.Count - 1; index >= 2; index--)
            {
                dtAllMillMasterData.Columns.RemoveAt(index);
            }
            GlobalFunctions.AddPleaseSelect(ref dtAllMillMasterData);
            ddlM_ID.DataSource = dtAllMillMasterData;
            ddlM_ID.DisplayMember = dtAllMillMasterData.Columns[1].ToString();
            ddlM_ID.ValueMember = dtAllMillMasterData.Columns[0].ToString();
            txtMill_Search.Text = "";
        }

        private void txtAgent_Search_TextChanged(object sender, EventArgs e)
        {
        }

        private void dgwAgentMill_Link_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Code to close MasterAgentMill form temporarily.
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string strValidationError = Validation();
                if (string.IsNullOrEmpty(strValidationError))
                {
                    if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool result = AddDeleteAgentMillLinkData("D", ddlA_ID.SelectedValue.ToString(), ddlM_ID.SelectedValue.ToString());
                        if (result)
                        {
                            MessageBox.Show("Record Deleted Sucessfully");
                        }
                        else
                        { MessageBox.Show("There was an error while Deleting data"); }
                        BindAgentMillLinkMasterDataToGrid();
                        clearAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while deleting" + ex.Message);
            }
        }
        

        private void ddlA_ID_SelectedIndexChanged(object sender, EventArgs e)
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
                        System.Data.DataTable table = dgwAgentMill_Link.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("AgentMillLinkMaster");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwAgentMill_Link.Columns.Count])
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

        private void dgwAgentMill_Link_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnDelete.Visible = true;
            cmdSubmit.Visible = false;
            ddlA_ID.Text = dgwAgentMill_Link.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlM_ID.Text = dgwAgentMill_Link.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlA_Active.Text = dgwAgentMill_Link.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private string Validation()
        {
            string strError = "";
            try
            {
               
                if (ddlA_ID.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Agent   ";
                }
                if (ddlM_ID.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Mill   ";
                }              
                if (ddlA_Active.SelectedIndex == 0)
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

        private bool AddDeleteAgentMillLinkData(string action, string AgentId, string MillId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("AgentId", AgentId);
                dictionaryInstance.Add("MillId", MillId);              
                dictionaryInstance.Add("IsActive", Convert.ToString(ddlA_Active.SelectedValue));               
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddDeleteAgentMillLinkData(dictionaryInstance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

    }
}