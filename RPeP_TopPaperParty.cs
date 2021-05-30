using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;
using ePacker1.Business_Logic;

namespace ePacker1
{
    public partial class RPeP_TopPaperParty : Form
    {
        string Group_ID, strSession;
        private FunctionLib funclib;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_TopPaperParty()
        {
            InitializeComponent();
            Group_ID = RPeP_LogIn.strGroup;
            strSession = RPeP_LogIn.strUser;
            filldata();
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            ddlP_ID.Enabled = false;
            txtTP_OrdId.Visible = false;
        }

        private void RPeP_TopPaperParty_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strcon);
                //Displaying value in Active field
                DataTable dtActive = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActive);
                ddlTPP_Active.DataSource = dtActive;
                ddlTPP_Active.DisplayMember = dtActive.Columns[0].ToString();
                ddlTPP_Active.ValueMember = dtActive.Columns[0].ToString();
                //Displaying value in Party Main
                SqlConnection con2 = new SqlConnection(strcon);
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT TP_ID,TP_Name from TopPaper_Master where TP_Active = 'Yes' and Grp_ID='" + Group_ID + "'", con1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                GlobalFunctions.AddPleaseSelect(ref dt1);
                ddlTP_ID.DataSource = dt1;
                ddlTP_ID.DisplayMember = dt1.Columns[1].ToString();
                ddlTP_ID.ValueMember = dt1.Columns[0].ToString();
                con1.Close();
                //Displaying PM_ID combo             
                DataTable dtAllPartyMainMasterData = bl.GetAllActivePartyMainMasterData(Group_ID);
                if (dtAllPartyMainMasterData != null)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtAllPartyMainMasterData);
                    ddlPM_ID.DataSource = dtAllPartyMainMasterData;
                    ddlPM_ID.DisplayMember = dtAllPartyMainMasterData.Columns[1].ToString();
                    ddlPM_ID.ValueMember = dtAllPartyMainMasterData.Columns[0].ToString();
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading page " + ex.Message);
            }
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (ddlTP_ID.SelectedIndex == 0)//checking for First Name field 
            {
                MessageBox.Show("Please Select Paper ID");
                ddlTP_ID.Focus();
            }
            else if (ddlPM_ID.SelectedIndex == 0)//Checking for blnk State field
            {
                MessageBox.Show("Please Select Party(Main) id");
                ddlPM_ID.Focus();
            }
            else if (ddlP_ID.SelectedIndex == 0)//Checking for blnk State field
            {
                MessageBox.Show("Please Select Party id");
                ddlP_ID.Focus();
            }
            else if (string.IsNullOrEmpty(txtRQty.Text))
            {
                MessageBox.Show("Enter Re-order level");
                txtRQty.Focus();
            }
            else if (ddlTPP_Active.SelectedIndex == 0)//Checking for blnk State field
            {
                MessageBox.Show("Please Select Active");
                ddlTPP_Active.Focus();
            }
            else
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Inserting data in table
                    string stryear = System.DateTime.Now.Year.ToString();
                    string strID = stryear + "-TPP";
                    if (con.State == ConnectionState.Open) con.Close();
                    string SID = funclib.Year_ID(strID, con, "select TP_OrdId from TopPaper_Party where left(TP_OrdId, 4) = '" + stryear + "' order by TP_OrdId desc");
                    SqlCommand cmd = new SqlCommand("insert into TopPaper_Party values('" + SID + "','" + ddlTP_ID.SelectedValue.ToString() + "','" + Group_ID + "','" + ddlPM_ID.SelectedValue.ToString() + "','" + ddlP_ID.SelectedValue.ToString() + "','" + txtRQty.Text + "','" + ddlTPP_Active.Text + "','" + strSession + "','',convert(datetime,getdate(),103),'','',convert(datetime,getdate(),103))", con);
                    string TPID = ddlTP_ID.SelectedValue.ToString();
                    string MPID = ddlPM_ID.SelectedValue.ToString();
                    string PID = ddlP_ID.SelectedValue.ToString();
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                    con.Close();
                    filldata();
                    clearAll();
                }
            }
        }

        private void filldata()
        {
            try
            {
                //to fill the grid with user details
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select a.TP_OrdId as TopPaperParty,b.TP_Name as TopPaper,c.Grp_Name,d.PM_Name as PartyMain,e.P_Name as Party,a.Req_Qty as Quantity,a.TPP_Active as Active from TopPaper_Party a,TopPaper_Master b,Group_Master c,PartyMain_Master d,Party_Master e where a.Grp_ID=c.Grp_ID and a.TP_ID=b.TP_ID and a.PM_ID=d.PM_ID and a.P_ID=e.P_ID", con4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgwTopPaper_Party.DataSource = dt;
                this.dgwTopPaper_Party.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading data to Grid " + ex.Message);
            }
        }

        private void ddlGrp_ID_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void dgwTopPaper_Party_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlTPP_Active.Enabled = true;
            ddlTP_ID.Enabled = false;
            ddlGrp_ID.Enabled = false;
            ddlPM_ID.Enabled = false;
            ddlP_ID.Enabled = false;
            txtRQty.Enabled = false;
            //Display Form 
            txtTP_OrdId.Text = dgwTopPaper_Party.Rows[e.RowIndex].Cells[0].Value.ToString();
            ddlTP_ID.Text = dgwTopPaper_Party.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlPM_ID.Text = dgwTopPaper_Party.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlP_ID.Text = dgwTopPaper_Party.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtRQty.Text = dgwTopPaper_Party.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlTPP_Active.Text = dgwTopPaper_Party.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to update records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("update TopPaper_Party set TPP_Active='" + ddlTPP_Active.Text + "' where TP_OrdId='" + txtTP_OrdId.Text + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                    filldata();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while updating record " + ex.Message);
            }
        }

        private void cmdPaperSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Search data from combo box
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT TP_ID,TP_Name from TopPaper_Master where Grp_ID='" + Group_ID + "' and TP_Name like '%" + txtNameSearch.Text + "%'", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (string.IsNullOrEmpty(txtNameSearch.Text))
                {
                    GlobalFunctions.AddPleaseSelect(ref dt1);
                }
                ddlTP_ID.DataSource = dt1;
                ddlTP_ID.DisplayMember = dt1.Columns[1].ToString();
                ddlTP_ID.ValueMember = dt1.Columns[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while searching " + ex.Message);
            }
        }

        private void cmdPartySearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Search data from combo box
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT PM_ID,PM_Name from PartyMain_Master where Grp_ID='" + Group_ID + "' and PM_Name like '%" + txtPartyMainSearch.Text + "%'", con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (string.IsNullOrEmpty(txtPartyMainSearch.Text))
                {
                    GlobalFunctions.AddPleaseSelect(ref dt2);
                }
                ddlPM_ID.DataSource = dt2;
                ddlPM_ID.DisplayMember = dt2.Columns[1].ToString();
                ddlPM_ID.ValueMember = dt2.Columns[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while searching " + ex.Message);
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing form data
            clearAll();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            txtOpenStock.Text = "";
            txCloseStock.Text = "";
            txtReOrderLevel.Text = "";
            txtTP_OrdId.Text = "";
            ddlTP_ID.SelectedIndex = 0;
            ddlGrp_ID.Text = "";
            ddlPM_ID.Text = "";
            ddlP_ID.Text = "";
            txtRQty.Text = "";
            ddlTP_ID.Enabled = true;
            ddlGrp_ID.Enabled = true;
            ddlPM_ID.Enabled = true;            
            txtRQty.Enabled = true;
            ddlTPP_Active.SelectedIndex = 0;
            ddlPM_ID.SelectedIndex = 0;
            //ddlP_ID.SelectedIndex = 0;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            ddlP_ID.Enabled = false;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Code to close Top Paper Party form temporarily
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to delete records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("delete from TopPaper_Party where TP_OrdId='" + txtTP_OrdId.Text + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record deleted");
                    filldata();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while deleting record " + ex.Message);
            }
        }

        private void ddlPM_ID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (ddlPM_ID.SelectedIndex == 0)
                {
                    ddlP_ID.SelectedIndex = 0;
                    ddlP_ID.Enabled = false;
                }
                else
                {
                    DataTable dt = bl.GetAllPartyMasterDataByMainPartyId(Group_ID, Convert.ToString(ddlPM_ID.SelectedValue), "");
                    if (dt != null)
                    {
                        ddlP_ID.Enabled = true;
                        GlobalFunctions.AddPleaseSelect(ref dt);
                        ddlP_ID.DataSource = dt;
                        ddlP_ID.DisplayMember = dt.Columns[4].ToString();
                        ddlP_ID.ValueMember = dt.Columns[0].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No Data Found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while loading party " + ex.Message);
            }
        }

        private void ddlTP_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con2 = new SqlConnection(strcon);
                con2.Open();
                SqlCommand cmd = new SqlCommand("select a.TP_OS,a.TP_CS,a.TP_ReLev from TopPaper_Master a,TopPaper_Party b where a.TP_ID=b.TP_ID and a.TP_ID='" + ddlTP_ID.SelectedValue.ToString() + "'", con2);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtOpenStock.Text = dr[0].ToString();
                    txCloseStock.Text = dr[1].ToString();
                    txtReOrderLevel.Text = dr[2].ToString();
                }
                else
                {
                    txtOpenStock.Text = "0";
                    txCloseStock.Text = "0";
                    txtReOrderLevel.Text = "0";
                }
                dr.Close();
                con2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading data " + ex.Message);
            }
        
        }

    }
}
