using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;
using ePacker1.Business_Logic;

namespace ePacker1
{
    public partial class RPeP_MasterPQuality : Form
    {
        string session, Group_ID;
        //Page Developed by Shirish Phadnis on(28/2/2011)
        private FunctionLib funclib = new FunctionLib();
        string strFirstCap;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterPQuality()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            BindPaperQualityDataToGrid();
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            txtPQ_ID.Visible = false;
            btnDelete.Visible = false;
        }

        private void RPeP_MasterPQuality_Load(object sender, EventArgs e)
        {
            //Displaying values in Active field
            ddlPQ_Active.SelectedText = "Yes";
            ddlPQ_Active.Enabled = false;
            ddlPQ_Active.Items.Add("Yes");
            ddlPQ_Active.Items.Add("No");
            this.WindowState = FormWindowState.Maximized;
            BindAllItemBFMasterData();
            BindAllItemGSMMasterData();
        }

        private void txtPQ_Desc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating PQ_Desc text Field 
            funclib = new FunctionLib();
            funclib.charNumber(e);
            int Grp_AddressData = funclib.countChar(e, txtPQ_Desc.Text);
            lblDesc_Char.Text = "(Character " + Grp_AddressData + "  " + "Out of" + txtPQ_Desc.MaxLength + ")";
        }

        private void txtPQ_BF_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating PQ_BF text Field 
            funclib = new FunctionLib();
            funclib.charNumber(e);
        }

        private void txtPQ_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating PQ_Rate text field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPQ_Desc.Text))//checking for blank PQ_Desc text field 
            {
                MessageBox.Show("Please enter Paper Description");
                txtPQ_Desc.Focus();
            }
            else if (ddlBF_ID.SelectedIndex == 0)//checking for blank PQ_BF text field 
            {
                MessageBox.Show("Please Select BF");
                ddlBF_ID.Focus();
            }
            else if (ddlGSM_ID.SelectedIndex == 0)//checking for blank GSM text field 
            {
                MessageBox.Show("Please Select GSM");
                ddlGSM_ID.Focus();
            }
            else if (string.IsNullOrEmpty(txtPQ_Rate.Text))//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Paper Rate");
                txtPQ_Rate.Focus();
            }
            else if (ddlPQ_Active.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Active State");
                ddlPQ_Active.Focus();
            }
            else
            {
                //Insert the details into the table
                funclib = new FunctionLib();
                strFirstCap = funclib.FirstCap(txtPQ_Desc.Text);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Checking for duplicate values
                    double flag = funclib.isThere(con, "select PQ_Desc,Grp_ID,BF_ID from PQuality_Master where PQ_Desc='" + txtPQ_Desc.Text + "' and Grp_ID='" + Group_ID + "' and BF_ID='" + ddlBF_ID.SelectedValue.ToString() + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Paper Quality Description, BF and Group is not allowed");
                    }
                    else
                    {
                        string pid = funclib.AutoKey("Q", con, "select PQ_ID from PQuality_Master order by PQ_ID desc");                      
                        bool result = AddEditDeletePaperQualityData("A",pid);
                        if (result)
                        {
                            MessageBox.Show("Record Inserted Sucessfully");
                        }
                        else
                        { MessageBox.Show("There was an error while inserting data"); }
                        BindPaperQualityDataToGrid();
                        clearAll();
                    }
                }
                else
                {
                    cmdSubmit.Focus();
                }
            }
        }

        private void dgwPQuality_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            btnDelete.Visible = true;
            txtPQ_Desc.Enabled = false;
            ddlBF_ID.Enabled = false;
            ddlGSM_ID.Enabled = false;
            ddlPQ_Active.Enabled = true;
            txtPQ_ID.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPQ_Desc.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlBF_ID.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlGSM_ID.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPQ_Rate.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlPQ_Active.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPQ_Rate.Text))//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Paper Rate");
                txtPQ_Rate.Focus();
            }
            else if (ddlPQ_Active.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Active State");
                ddlPQ_Active.Focus();
            }
            else
            {
                if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = AddEditDeletePaperQualityData("E", txtPQ_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Updated");
                    }
                    else
                    { MessageBox.Show("There was an error while updating data"); }
                    BindPaperQualityDataToGrid();
                    clearAll();
                }
                else
                {
                    cmdSubmit.Focus();
                }
            }
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            txtPQ_Desc.Clear();
            ddlBF_ID.Text = "";
            ddlGSM_ID.Text = "";
            txtPQ_Rate.Clear();
            txtPQ_Desc.Enabled = true;
            ddlBF_ID.Enabled = true;
            ddlBF_ID.SelectedIndex = 0;
            ddlGSM_ID.Enabled = true;
            ddlGSM_ID.SelectedIndex = 0;
            ddlPQ_Active.SelectedText = "Yes";
            ddlPQ_Active.Enabled = false;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            btnDelete.Visible = false;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Code to close MasterPQuality form temporarily.
            this.Close();
        }

        private void cmdRefresh_Click_1(object sender, EventArgs e)
        {
            //Code to call MasterPQuality form with all blank fields to enter new entry
            clearAll();
        }

        private void BindAllItemBFMasterData()
        {
            try
            {
                DataTable dtBFMaster = bl.GetAllItemBFMasterData(Group_ID);
                if (dtBFMaster != null)
                {
                    ddlBF_ID.DataSource = dtBFMaster;
                    ddlBF_ID.DisplayMember = dtBFMaster.Columns[1].ToString();
                    ddlBF_ID.ValueMember = dtBFMaster.Columns[0].ToString();
                }
                else
                {
                    ddlBF_ID.DataSource = "";
                    ddlBF_ID.DisplayMember = "";
                    ddlBF_ID.ValueMember = "";
                }
            }
            catch (Exception) { throw; }
        }

        private void BindAllItemGSMMasterData()
        {
            try
            {
                DataTable dtGSMMaster = bl.GetAllGSMMasterData(Group_ID);
                if (dtGSMMaster != null)
                {
                    ddlGSM_ID.DataSource = dtGSMMaster;
                    ddlGSM_ID.DisplayMember = dtGSMMaster.Columns[1].ToString();
                    ddlGSM_ID.ValueMember = dtGSMMaster.Columns[0].ToString();
                }
                else
                {
                    ddlGSM_ID.DataSource = "";
                    ddlGSM_ID.DisplayMember = "";
                    ddlGSM_ID.ValueMember = "";
                }
            }
            catch (Exception) { throw; }

        }

        private void BindPaperQualityDataToGrid()
        {
            try
            {
                DataTable dtAllPaperQualityData = bl.GetAllPaperQualityData(Group_ID);
                if (dtAllPaperQualityData != null)
                {
                    dgwPQuality_Master.DataSource = dtAllPaperQualityData;
                    this.dgwPQuality_Master.Columns[0].Visible = false;
                }
            }
            catch (Exception) { throw; }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool result = AddEditDeletePaperQualityData("D", txtPQ_ID.Text);
                if (result)
                {
                    MessageBox.Show("Record Updated");
                }
                else
                { MessageBox.Show("There was an error while deleting data"); }
                BindPaperQualityDataToGrid();
                clearAll();
            }
            else
            {
                cmdSubmit.Focus();
            }
        }

        private bool AddEditDeletePaperQualityData(string action, string PQ_Id)
        {
            bool result = false;
            Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
            dictionaryInstance.Add("PQ_ID", PQ_Id);
            dictionaryInstance.Add("Group_ID", Group_ID);
            dictionaryInstance.Add("PQ_Desc", Convert.ToString(funclib.FirstCap(txtPQ_Desc.Text)));
            dictionaryInstance.Add("BF_ID", Convert.ToString(ddlBF_ID.SelectedValue));
            dictionaryInstance.Add("GSM_ID", Convert.ToString(ddlGSM_ID.SelectedValue));
            dictionaryInstance.Add("PQ_Rate", Convert.ToString(txtPQ_Rate.Text));
            dictionaryInstance.Add("PQ_Active", Convert.ToString(ddlPQ_Active.SelectedItem));
            dictionaryInstance.Add("User", Convert.ToString(session));
            dictionaryInstance.Add("Action", action);

            return result = bl.AddEditDeletePaperQualityData(dictionaryInstance);
        }

    }
}