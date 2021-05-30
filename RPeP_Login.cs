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

namespace ePacker1
{
    public partial class RPeP_LogIn : Form
    {
        FunctionLib funclib;
        public static string strUser;
        public static string strPasswd;
        public static string strGroup;
        int counter = 0;
        int flag = 0;

        public RPeP_LogIn()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            strUser = txtUser_ID.Text;
            strPasswd = txtUser_Passwd.Text;
            strGroup = ddlGrp_ID.SelectedValue.ToString();
            funclib = new FunctionLib();

            //Checking for blank username and password
            if ((strUser.Equals("") == true) || (strPasswd.Equals("") == true) || (strGroup.Equals("") == true))
            {
                MessageBox.Show("Please enter all field");
            }
            else
            {
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("select User_ID,User_Passwd from User_Master", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Encrypting pasword
                    byte[] encodePasswd = new byte[strPasswd.Length];
                    encodePasswd = System.Text.Encoding.UTF8.GetBytes(strPasswd);
                    string encodingdata = Convert.ToBase64String(encodePasswd);
                    if ((strUser.Equals(dr[0].ToString()) == true) && (encodingdata.Equals(dr[1].ToString()) == true))
                    {
                        RPeP_MasterMDI frmMaster = new RPeP_MasterMDI();
                        this.Visible = false;
                        frmMaster.Show();
                        flag = flag + 1;
                        break;
                    }
                    else
                    {
                        flag = 0;
                    }
                }

                if (flag == 0)
                {
                    counter = counter + 1;
                    MessageBox.Show("Wrong UserName/Password", "LoginForm", MessageBoxButtons.OK);
                    txtUser_ID.Clear();
                    txtUser_Passwd.Clear();
                    txtUser_ID.Focus();
                    if (counter == 4)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void RPeP_LogIn_Load(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strCon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strCon);
            con1.Open();
            //Displayig Group Name in Combo field
            SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='Yes' ", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlGrp_ID.DataSource = dt;
            ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            con1.Close();
        }
    }
}