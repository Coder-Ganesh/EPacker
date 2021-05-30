using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;

namespace ePacker1
{
    public partial class RPeP_MasterPQuality : Form
    {
        string session, Group_ID; 
        //Page Developed by Shirish Phadnis on(28/2/2011)
        private FunctionLib funclib;
        string strFirstCap;
        public RPeP_MasterPQuality()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdEdit.Enabled = false;
            txtPQ_ID.Visible = false;



        }

        private void RPeP_MasterPQuality_Load(object sender, EventArgs e)
        {
            //Displaying values in Active field
            ddlPQ_Active.SelectedText = "Yes";
            ddlPQ_Active.Enabled = false;
            ddlPQ_Active.Items.Add("Yes");
            ddlPQ_Active.Items.Add("No");

            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();

            //Displaying values in Group Combobox
            SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();
            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();

            //Dispalying values in BF
            con1.Open();
            SqlDataAdapter daBF = new SqlDataAdapter("SELECT '' as BF_ID, '' as BF_Value UNION select BF_ID,BF_Value from Item_BF_Master where BF_Active='yes' ", con1);
            DataTable dtBF = new DataTable();
            daBF.Fill(dtBF);
            ddlBF_ID.DataSource = dtBF;
            ddlBF_ID.DisplayMember = dtBF.Columns[1].ToString();
            ddlBF_ID.ValueMember = dtBF.Columns[0].ToString();
            con1.Close();

            //Displaying values in GSM

            con1.Open();
            SqlDataAdapter daGSM = new SqlDataAdapter("SELECT '' as GSM_ID, '' as GSM_Value UNION select GSM_ID,GSM_Value from Item_GSM_Master where GSM_Active='yes' ", con1);
            DataTable dtGSM = new DataTable();
            daGSM.Fill(dtGSM);
            ddlGSM_ID.DataSource = dtGSM;
            ddlGSM_ID.DisplayMember = dtGSM.Columns[1].ToString();
            ddlGSM_ID.ValueMember = dtGSM.Columns[0].ToString();
            con1.Close();

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
            if (txtPQ_Desc.Text == "")//checking for blank PQ_Desc text field 
            {
                MessageBox.Show("Please enter Paper Description");
                txtPQ_Desc.Focus();
            }


            //else if (ddlGrp_ID.Text == "")//checking for blank Grp_ID combo field 
            //{
            //    MessageBox.Show("Please select Group ID");
            //    ddlGrp_ID.Focus();
            //}
            else if (ddlBF_ID.Text == "")//checking for blank PQ_BF text field 
            {
                MessageBox.Show("Please Select BF");
                ddlBF_ID.Focus();
            }
            else if (ddlGSM_ID.Text == "")//checking for blank GSM text field 
            {
                MessageBox.Show("Please Select GSM");
                ddlGSM_ID.Focus();
            }
            else if (txtPQ_Rate.Text == "")//checking for blank PQ_Rate text field 
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
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into PQuality_Master values('" + pid + "','" + txtPQ_Desc.Text.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "','" + ddlBF_ID.SelectedValue.ToString() + "','" + ddlGSM_ID.SelectedValue.ToString() + "','" + txtPQ_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + ddlPQ_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        //con.Open();
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted Successfully");
                        filldata();
                        clearAll();
                    }

                }
                else
                {
                    cmdSubmit.Focus();
                }




            }

        }
        private void filldata()
        {
            //to fill the grid with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            con4.Open();
            SqlDataAdapter da = new SqlDataAdapter("select a.PQ_ID as ProductId,a.PQ_Desc as Description,b.Grp_Name as GroupName,c.BF_Value as BF,d.GSM_Value as GSM,a.PQ_Rate as Rate,a.PQ_Active as Active from PQuality_Master a,Group_Master b,Item_BF_Master c,Item_GSM_Master d where b.Grp_ID=a.Grp_ID and a.BF_ID=c.BF_ID and a.GSM_ID=d.GSM_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwPQuality_Master.DataSource = dt;
            this.dgwPQuality_Master.Columns[0].Visible = false;

        }
        private void dgwPQuality_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;

            txtPQ_Desc.Enabled = false;
            ddlGrp_ID.Enabled = false;
            ddlBF_ID.Enabled = false;
            ddlGSM_ID.Enabled = false;

            ddlPQ_Active.Enabled = true;
            txtPQ_ID.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPQ_Desc.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
           // ddlGrp_ID.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlBF_ID.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlGSM_ID.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPQ_Rate.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlPQ_Active.Text = dgwPQuality_Master.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Edit data in form 

            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("update PQuality_Master set PQ_Desc ='" + txtPQ_Desc.Text + "',Grp_ID ='" + Group_ID + "',BF_ID ='" + ddlBF_ID.SelectedValue.ToString() + "', GSM_ID='" + ddlGSM_ID.SelectedValue.ToString() + "',PQ_Rate='" + txtPQ_Rate.Text + "',PQ_Active ='" + ddlPQ_Active.SelectedItem.ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where PQ_ID='" + txtPQ_ID.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            clearAll();
           
           
           
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            txtPQ_Desc.Clear();
            ddlGrp_ID.Text = "";
            ddlBF_ID.Text = "";
            ddlGSM_ID.Text = "";
            txtPQ_Rate.Clear();

            txtPQ_Desc.Enabled = true;
            ddlGrp_ID.Enabled = true;
            ddlBF_ID.Enabled = true;
            ddlGSM_ID.Enabled = true;

            ddlPQ_Active.SelectedText = "Yes";
            ddlPQ_Active.Enabled = false;
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;
            
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

        


    }
}