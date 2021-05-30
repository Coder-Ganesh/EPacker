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
    public partial class RPeP_MasterGroup : Form
    {
        //Page Developed by Shirish Phadnis on(28/2/2011).
        private FunctionLib funclib;
        string strGrpName, strGrpSName, session;
        public RPeP_MasterGroup()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            filldata();//Invoking Function for clear the form
            cmdEdit.Enabled = false;//disabled the edit button
            //txtGrp_ID.Enabled = false;//disabled the group id text field
            txtGrp_ID.Visible = false;//Invisible group id text field 
            //cmdSubmit.Image = Image.FromFile(@"\Resources\ePacker_AddNew.jpg");
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtGrp_Name.Text == "")//checking for blank Grp_Name text field 
            {
                MessageBox.Show("Please enter name");
                txtGrp_Name.Focus();
            }


            else if (txtGrp_SName.Text == "")//checking for blank Grp_SName text field 
            {
                MessageBox.Show("Please enter Sname");
                txtGrp_SName.Focus();
            }
            else if (txtGrp_Address.Text == "")//checking for blank Grp_Address text field 
            {
                MessageBox.Show("Please enter Address");
                txtGrp_Address.Focus();
            }
            else if (txtGrp_Phone.Text == "")//checking for blank Grp_Phone text field 
            {
                MessageBox.Show("Please enter Phone no");
                txtGrp_Phone.Focus();
            }
            else if (txtGrp_Email.Text == "")//checking for blank Grp_Email text field 
            {
                MessageBox.Show("Please enter EmailID");
                txtGrp_Email.Focus();
            }



            else if (txtGrp_Excise.Text == "")//checking for blank Grp_Excise text field 
            {
                MessageBox.Show("Please enterExcise no");
                txtGrp_Excise.Focus();
            }
            else if (txtGrp_Range.Text == "")//checking for blank Grp_Range text field
            {
                MessageBox.Show("Please enter Range");
                txtGrp_Range.Focus();
            }
            else if (txtGrp_Div.Text == "")//checking for blank Grp_Div text field
            {
                MessageBox.Show("Please enter Division");
                txtGrp_Div.Focus();
            }
            else if (txtGrp_Commis.Text == "")//checking for blank Grp_Commis text field
            {
                MessageBox.Show("Please enter commisionrate");
                txtGrp_Commis.Focus();
            }
            else if (txtGrp_LST.Text == "")//checking for blank Grp_LST text field
            {
                MessageBox.Show("Please enter LST");
                txtGrp_LST.Focus();
            }
            else if (txtGrp_CST.Text == "")//checking for blank Grp_CST text field
            {
                MessageBox.Show("Please enter CST");
                txtGrp_CST.Focus();
            }
            else if (ddlGrp_Active.Text == "")//checking for blank Grp_Active combo field
            {
                MessageBox.Show("Please Choose Actve Feild");
                ddlGrp_Active.Focus();

            }
            else
            {
                //Inserting details into the table Group_Master
                funclib = new FunctionLib();
                bool val = funclib.emailValidation(txtGrp_Email.Text);
                if (val == false)
                {
                    txtGrp_Email.Clear();
                    txtGrp_Email.Focus();
                }
                else
                {
                    strGrpName = funclib.FirstCap(txtGrp_Name.Text);
                    strGrpSName = funclib.FirstCap(txtGrp_SName.Text);

                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    string gid = funclib.AutoKey("G", con, "select Grp_ID from Group_Master order by Grp_ID desc");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Group_Master values('" + gid + "','" + strGrpName.Trim().Replace("'", "''").ToString() + "','" + strGrpSName.Trim().Replace("'", "''").ToString() + "','" + txtGrp_Address.Text.Trim().Replace("'", "''").ToString() + "','" + txtGrp_Phone.Text.Trim().Replace("'", "''").ToString() + "','" + txtGrp_Email.Text.Trim().Replace("'", "''").ToString() + "','" + txtGrp_Excise.Text.Trim().Replace("'", "''").ToString() + "','" + txtGrp_Range.Text.Trim().Replace("'", "''").ToString() + "','" + txtGrp_Div.Text.Trim().Replace("'", "''").ToString() + "','" + txtGrp_Commis.Text.Trim().Replace("'", "''").ToString() + "','" + txtGrp_LST.Text.Trim().Replace("'", "''").ToString() + "','" + txtGrp_CST.Text.Trim().Replace("'", "''").ToString() + "','" + ddlGrp_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                    clearAll();
                    filldata();
                    //ddlGrp_Active.Enabled = true;
                    //ddlGrp_Active.SelectedText = "Yes";
                    //ddlGrp_Active.Enabled = false;
                }


            }



        }

        private void txtGrp_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating txtGrp_Name text field
            funclib = new FunctionLib();
            //funclib.checkNumericChar(e);
            funclib.onlyCharacterPress(e);

        }

        private void txtGrp_SName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating txtGrp_SName text field
            funclib = new FunctionLib();
            //funclib.checkNumericChar(e);
            funclib.onlyCharacterPress(e);
        }

        private void txtGrp_Address_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtGrp_Address Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtGrp_Address.Text);
            lblAddrone.Text = "(Character " + P_AddressData + "  " + "Out of" + txtGrp_Address.MaxLength + ")";

            


        }


        private void txtGrp_Excise_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating txtGrp_Excise text field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtGrp_Range_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating txtGrp_Range text field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtGrp_Div_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating txtGrp_Div text field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtGrp_Commis_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating txtGrp_Commis text field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtGrp_LST_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating txtGrp_LST text field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtGrp_CST_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating txtGrp_CST text field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        
        private void txtGrp_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validating txtGrp_Phone text field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtGrp_Email_Validating(object sender, CancelEventArgs e)
        {
            //validating txtGrp_Email text field
            funclib = new FunctionLib();
            funclib.emailValidation(txtGrp_Email.Text);
        }

        
        private void RPeP_MasterGroup_Load(object sender, EventArgs e)
        {
            //cmdSubmit.Image = Image.FromFile(@"D:\Shirish\ePacker\ePacker_Buttons\ePacker_AddNew.jpg");
            //cmdEdit.Image = Image.FromFile(@"D:\Shirish\ePacker\ePacker_Buttons\ePacker_Edit.jpg");
            //cmdRefresh.Image  = Image.FromFile(@"D:\Shirish\ePacker\ePacker_Buttons\ePacker_Refresh.jpg");
            //to dislplay value on form load
            
            
            ddlGrp_Active.SelectedText = "Yes";
            ddlGrp_Active.Enabled = false;
            ddlGrp_Active.Items.Add("Yes");
            ddlGrp_Active.Items.Add("No");
            this.WindowState = FormWindowState.Maximized;
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterGroup form
            clearAll();

        }
        public void clearAll()
        {
            //Code for Clearing all form fields.
            txtGrp_ID.Clear();
            txtGrp_Address.Clear();
            txtGrp_Commis.Clear();
            txtGrp_CST.Clear();
            txtGrp_Div.Clear();
            txtGrp_Email.Clear();
            txtGrp_Excise.Clear();
            txtGrp_LST.Clear();
            txtGrp_Name.Clear();
            txtGrp_Phone.Clear();
            txtGrp_Range.Clear();
            txtGrp_SName.Clear();
            ddlGrp_Active.Text = "";
            txtGrp_Name.Focus();
            cmdSubmit.Enabled = true;
            cmdEdit.Enabled = false;
            ddlGrp_Active.SelectedText = "Yes";
            ddlGrp_Active.Enabled = false;
        }
        void filldata()
        {
            // to fill the Datagridview with user details.   
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select Grp_ID as GroupID,Grp_Name as GroupName,Grp_SName as ShortName,Grp_Address as Address,Grp_Phone as Phone,Grp_Email as Email,Grp_Excise as Excise,Grp_Range as Range ,Grp_Div as Division,Grp_Commis as Commis,Grp_LST as LST,Grp_CST as CST,Grp_Active as Active from Group_Master",con4);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[0].Visible = false;
            

        }

        

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            //to display data in form on click of datagridview.
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlGrp_Active.Enabled = true;
            txtGrp_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtGrp_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtGrp_SName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtGrp_Address.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtGrp_Phone.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtGrp_Email.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtGrp_Excise.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtGrp_Range.Text=dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtGrp_Div.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtGrp_Commis.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtGrp_LST.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtGrp_CST.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            ddlGrp_Active.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            txtGrp_Name.Text = funclib.FirstCap(txtGrp_Name.Text);
            txtGrp_SName.Text = funclib.FirstCap(txtGrp_SName.Text);
            //Update Records in table Group_Master.
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
           con.Open();
           SqlCommand cmd = new SqlCommand("update Group_Master set Grp_Name='" + txtGrp_Name.Text + "',Grp_SName='" + txtGrp_SName.Text + "',Grp_Address ='" + txtGrp_Address.Text + "',Grp_Phone='" + txtGrp_Phone.Text + "',Grp_Email ='" + txtGrp_Email.Text + "',Grp_Excise ='" + txtGrp_Excise.Text + "',Grp_Range='" + txtGrp_Range.Text + "',Grp_Div='" + txtGrp_Div.Text + "',Grp_Commis='" + txtGrp_Commis.Text + "',Grp_LST='" + txtGrp_LST.Text + "',Grp_CST='" + txtGrp_LST.Text + "',Grp_Active='" + ddlGrp_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Grp_ID='" + txtGrp_ID.Text + "'", con);
           int i = cmd.ExecuteNonQuery();
           MessageBox.Show("Record Updated");
           filldata();
           clearAll();

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Code to close MasterGroup form temporarily.
            this.Close();


        }

        



    }


}