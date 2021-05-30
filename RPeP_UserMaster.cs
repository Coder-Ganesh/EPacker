using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;
using System.Collections;

namespace ePacker1
{
    public partial class RPeP_UserMaster : Form
    {
        //Page Developed by Shirish Phadnis on(28/2/2011)
        private FunctionLib funclib;
        string strFirstCap, strSession, Group_ID;
       

        public RPeP_UserMaster()
        {
            InitializeComponent();
            //ddlGrp_ID.Items.Insert(0, "");
            strSession = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();//Invoking Function for clear the form
            cmdEdit.Enabled = false;//disabled the group id text field
            
         }

        

        private void RPeP_UserMaster_Load(object sender, EventArgs e)
        {
                                    
            ddlUser_Active.SelectedText = "Yes";
            ddlUser_Active.Enabled = false;
            ddlUser_Active.Items.Add("Yes");
            ddlUser_Active.Items.Add("No");
            //ddlUser_Level.Items.Add(" ");
            ddlUser_Level.Items.Add("User");
            ddlUser_Level.Items.Add("Admin");
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();
            //SqlDataAdapter da= new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();

          }

        


        private void txtUser_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating User_ID text field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }


        private void txtUser_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating User_Name text field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        

        private void cmdSubmit_Click(object sender, EventArgs e)
        {

            if (txtUser_ID.Text == "")//checking for blank User_ID text field 
            {
                MessageBox.Show("Please enter User Id");
                txtUser_ID.Focus();

            }


            else if (txtUser_Name.Text == "")//checking for blank User_Name text field 
            {
                MessageBox.Show("Please enter User name");
                txtUser_Name.Focus();
            }
            else if (txtUser_Passwd.Text == "")//checking for blank User_Name text field 
            {
                MessageBox.Show("Please enter Password");
                txtUser_Passwd.Focus();
            }
            //else if (ddlGrp_ID.Text == "")//checking for blank Grp_Id combo field 
            //{
            //    MessageBox.Show("Please Select Group Id");
            //    ddlGrp_ID.Focus();
            //}
            else if (ddlUser_Level.Text == "")//checking for blank User_level combo field 
            {
                MessageBox.Show("Please select User level");
                ddlUser_Level.Focus();
            }
            else if (ddlUser_Active.Text == "")//checking for blank User_Active combo field 
            {
                MessageBox.Show("Please select User Active");
                ddlUser_Active.Focus();
            }
            else if (txtUser_ID.Text == "shirish")//Checking for duplicate entries
            {
                MessageBox.Show("sory!! shirish name already exist");
                txtUser_ID.Text = "";
            }


            else
            {
                //Insert the details into the table


                funclib = new FunctionLib();
                strFirstCap = funclib.FirstCap(txtUser_Name.Text);
                string txtPassdata = txtUser_Passwd.Text;
                string pwdata = funclib.encryptData(txtPassdata);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string stQuery = "insert into User_Master values('" + txtUser_ID.Text.Trim().Replace("'", "''").ToString() + "', '" + strFirstCap.Trim().Replace("'", "''").ToString() + "','" + pwdata + "','" + Group_ID + "','" + ddlUser_Level.SelectedItem.ToString() + "','" + ddlUser_Active.Text + "','" + strSession + "','',convert(datetime,getdate(),103),'','','' )";
                SqlCommand cmd = new SqlCommand(stQuery, con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Inserted");
                filldata();
                clearAll();

            }






        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
            
        }
        private void clearAll()
        {
            //to clear the form data
            txtUser_ID.Clear();
            txtUser_Name.Clear();
            txtUser_Passwd.Clear();
            ddlGrp_ID.Text = "";
           //ddlGrp_ID.Items.Clear();
            ddlUser_Active.Text = "";
            ddlUser_Level.Text = "";
            ddlUser_Active.SelectedText = "Yes";
            ddlUser_Active.Enabled = false;
            cmdSubmit.Enabled = true;
            cmdEdit.Enabled = false;
            txtUser_ID.Enabled = true;
            txtUser_ID.Focus();
            
        }
        private void filldata()
        {
                //to fill the grid with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select User_ID as UserId,User_Name as Name,User_Passwd as Password,Grp_Name as GroupName,User_Level as Level,User_Active as Active from User_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlUser_Active.Enabled = true;
            txtUser_ID.Enabled = false;
            txtUser_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUser_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtUser_Passwd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //ddlGrp_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlUser_Level.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlUser_Active.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

           

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //allow to edit the data
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("update User_Master set User_Name='" + txtUser_Name.Text + "',User_Passwd='" + txtUser_Passwd.Text + "',Grp_ID='" + Group_ID + "',User_Level='" + ddlUser_Level.Text + "',User_Active='"+ddlUser_Active.Text+"'where User_ID='"+txtUser_ID.Text+"'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            clearAll();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Code to close current form only
            this.Close();
            //Application.Exit();
        }
           
            

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

}
}