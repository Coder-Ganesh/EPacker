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

namespace ePacker1
{
    public partial class RPeP_MasterAgent : Form
    {
        string session,Group_ID;
        //Page Developed by Shirish Phadnis on(8/3/2011)
        private FunctionLib funclib;
        string strAName, strMgr1, strMgr2, strDesg1,strSQL, strDesg2;
        public RPeP_MasterAgent()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdEdit.Enabled = false;
            txtA_ID.Visible = false;
        }



        private void RPeP_MasterAgent_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();

            ////Displayig Group Name in Combo field
            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();

            //Displayig City Name in Combo field
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select '' as City_Name UNION select City_Name from City_Master", con1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            ddlA_City.DataSource = dt2;
            ddlA_City.DisplayMember = dt2.Columns[0].ToString();
            ddlA_City.ValueMember = dt2.Columns[0].ToString();
            con1.Close();

            //Displayig State Name in Combo field
            con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select '' as State_Name UNION select State_Name from State_Master", con1);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            ddlA_State.DataSource = dt3;
            ddlA_State.DisplayMember = dt3.Columns[0].ToString();
            ddlA_State.ValueMember = dt3.Columns[0].ToString();
            con1.Close();

            //Displaying category value in Combo field
            ddlA_Cate.Items.Add("Purchase");
            ddlA_Cate.Items.Add("JobWork");

            //displaying type in Combo field

            ddlA_Type.Items.Add("Manufacturer");
            ddlA_Type.Items.Add("Dealer");

            //Displaying Active value in Combo field

            ddlA_Active.SelectedText = "Yes";
            ddlA_Active.Enabled = false;
            ddlA_Active.Items.Add("Yes");
            ddlA_Active.Items.Add("No");


            //Displaying weeklyoff day

            con1.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("select B_Day from B_Cal", con1);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            ddlA_WeekOff.DataSource = dt4;
            ddlA_WeekOff.DisplayMember = dt4.Columns[0].ToString();
            ddlA_WeekOff.ValueMember = dt4.Columns[0].ToString();
            con1.Close();

        }
        private void txtA_Name_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtA_Name_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            //Validating A_Name Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }



        private void txtA_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Addr1 Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtA_Addr1.Text);
            lblAddress1.Text = "(Character " + P_AddressData + "  " + "Out of" + txtA_Addr1.MaxLength + ")";
        }

        private void txtA_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Addr2 Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtA_Addr2.Text);
            lbladdress2.Text = "(Character " + P_AddressData + "  " + "Out of" + txtA_Addr2.MaxLength + ")";

        }

        private void txtA_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_PinCode Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtA_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Tel Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtA_FAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_FAX Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }
        private void txtA_Mgr1Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr1Mobile Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtA_Mgr2Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr2Mobile Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtA_Mgr1Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr1Name Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);


        }

        private void txtA_Mgr2Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr2Name Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtA_Mgr1Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr1Desig Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtA_Mgr2Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mgr2Desig Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }



        private void txtA_ECC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_ECC Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);


        }

        private void txtA_BST_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_BST Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtA_CST_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_CST Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);

        }

        private void txtA_CrDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_CrDays Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }
        private void txtA_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Mobile Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPAN_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating PAN_No Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtA_Regn_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating A_Regn Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);


        }

        private void txtA_Tin_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {

            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}


           if (txtA_Name.Text == "")//checking for blank Name text field 
            {
                MessageBox.Show("Please Enter Name");
                txtA_Name.Focus();
            }

            //else if (txtA_Addr1.Text == "")//checking for blank Addr1 text field 
            //{
            //    MessageBox.Show("Please Enter Address1");
            //    txtA_Addr1.Focus();
            //}

            else if (ddlA_City.Text == "")//Checking for blank City field
            {
                MessageBox.Show("Please Select City");
                ddlA_City.Focus();
            }
            else if (ddlA_State.Text == "")//Checking for blank State field
            {
                MessageBox.Show("Please Select State");
                ddlA_State.Focus();
            }
            //else if (txtA_PinCode.Text == "")//Checking for blank PinCode field
            //{
            //    MessageBox.Show("Enter Pincode number");
            //    txtA_PinCode.Focus();
            //}
            //else if (txtA_Tel.Text == "")//Checking for blank TelNo field
            //{
            //    MessageBox.Show("Enter Telephone no");
            //    txtA_Tel.Focus();
            //}
            else if (ddlA_WeekOff.Text == "")//Checking for blank weeklyoff field
            {
                MessageBox.Show("Select Weeklyoff");
                ddlA_WeekOff.Focus();
            }
            else if (txtA_ECC.Text == "")//Checking for blank ECC field
            {
                MessageBox.Show("Enter ECC no");
                txtA_ECC.Focus();
            }
            else if (txtA_CST.Text == "")////Checking for blank CST field
            {
                MessageBox.Show("Enter CST");
                txtA_CST.Focus();
            }


            else if (ddlA_Active.Text == "")//Checking for blank Active field
            {
                MessageBox.Show("Select Active field");
                ddlA_Active.Focus();
            }
            else if (ddlA_Cate.Text == "")//Checking for blank Category field
            {
                MessageBox.Show("Select Category");
                ddlA_Cate.Focus();
            }
            else if (ddlA_Type.Text == "")//Checking for blank Category field
            {
                MessageBox.Show("Select Type");
                ddlA_Type.Focus();
            }
            else if (txtA_Regn.Text == "")////Checking for Registration field
            {
                MessageBox.Show("Enter Registration");
                txtA_Regn.Focus();
            }
            else if (txtPAN_No.Text == "")//Checking for PAN no
            {
                MessageBox.Show("Enter PAN Number");
                txtPAN_No.Focus();
            }
            ////////else if (ddlA_Type.Text == "")//Checking for blnk Type field
            ////////{
            ////////    MessageBox.Show("Select Type  field");
            ////////    ddlA_Type.Focus();
            ////////}
            else
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //Checking for duplicate values
                    double flag = funclib.isThere(con, "select A_Name ,Grp_ID from Agent_Master where A_Name='" + txtA_Name.Text + "' and Grp_ID='" + Group_ID + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Party Name, Party (Main) and Group is not allowed");

                    }
                    else
                    {
                        //Inserting Details into table

                        if ((ddlA_Cate.SelectedItem.ToString().Equals("Purchase") == true) && (ddlA_Type.SelectedItem.ToString().Equals("Manufacturer") == true))
                        {


                            MessageBox.Show("As Agent Type is Manufacturer, Mill will be automatically added with same details.");



                            txtA_Name.Text = funclib.FirstCap(txtA_Name.Text);
                            txtA_Addr1.Text = funclib.FirstCap(txtA_Addr1.Text);


                            txtA_Mgr1Name.Text = funclib.FirstCap(txtA_Mgr1Name.Text);
                            txtA_Mgr2Name.Text = funclib.FirstCap(txtA_Mgr2Name.Text);
                           
                            //Inserting records in Agent_Master
                            string aid = funclib.AutoKey("A", con, "select A_ID from Agent_Master order by A_ID desc");
                            SqlCommand cmdAgent = new SqlCommand("insert into Agent_Master values('" + aid + "','" + Group_ID + "','" + txtA_Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Addr1.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Addr2.Text.Trim().Replace("'", "''").ToString() + "','" + ddlA_City.SelectedValue.ToString() + "','" + ddlA_State.SelectedValue.ToString() + "','" + txtA_PinCode.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Tel.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_FAX.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Email.Text.Trim().Replace("'", "''").ToString() + "', '" + txtA_Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + ddlA_WeekOff.SelectedValue.ToString() + "','" + txtA_Mgr1Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr1Desig.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr1Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr1Email.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr2Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr2Desig.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr2Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr2Email.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_ECC.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Regn.Text.Trim().Replace("'", "''").ToString() + "','" + txtLBT_No.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_CST.Text.Trim().Replace("'", "''").ToString() + "','" + ddlA_Type.SelectedItem.ToString() + "','" + ddlA_Cate.SelectedItem.ToString() + "','" + txtA_CrDays.Text.Trim().Replace("'", "''").ToString() + "','" + ddlA_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','','" + txtPAN_No.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Tin.Text.Trim().Replace("'", "''").ToString() + "')", con);


                            con.Open();
                            int AgentRow = cmdAgent.ExecuteNonQuery();
                            MessageBox.Show("Record Inserted in Agent");
                            con.Close();

                            //Inserting records in AgentMill_Link

                            SqlCommand cmdAgentMill = new SqlCommand("insert into AgentMill_Link values('" + Group_ID + "','" + aid + "','','" + ddlA_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                            con.Open();
                            int AgentMilk = cmdAgentMill.ExecuteNonQuery();
                            MessageBox.Show("Record Inserted in AgentMill");
                            con.Close();

                            //Inserting records in Mill_Master
                            string mid = funclib.AutoKey("M", con, "select M_ID from Mill_Master order by M_ID desc");
                            SqlCommand cmdMillMaster = new SqlCommand("insert into Mill_Master values('" + mid + "','" + Group_ID + "','" + txtA_Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Addr1.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Addr2.Text.Trim().Replace("'", "''").ToString() + "','" + ddlA_City.SelectedValue.ToString() + "','" + ddlA_State.SelectedValue.ToString() + "','" + txtA_PinCode.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Tel.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_FAX.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Email.Text.Trim().Replace("'", "''").ToString() + "', '" + txtA_Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + ddlA_WeekOff.SelectedValue.ToString() + "','" + txtA_Mgr1Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr1Desig.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr1Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr1Email.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr2Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr2Desig.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr2Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr2Email.Text.Trim().Replace("'", "''").ToString() + "','" + ddlA_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                            con.Open();
                            int MillMaster = cmdMillMaster.ExecuteNonQuery();
                            MessageBox.Show("Record Inserted in MillMaster");
                            con.Close();
                            filldata();
                            clearAll();




                        }
                        else
                        {
                            //Inserting records in Agent_Master
                            strAName = funclib.FirstCap(txtA_Name.Text);
                            strMgr1 = funclib.FirstCap(txtA_Mgr1Name.Text);
                            strMgr2 = funclib.FirstCap(txtA_Mgr2Name.Text);
                            strDesg1 = funclib.FirstCap(txtA_Mgr1Desig.Text);
                            strDesg2 = funclib.FirstCap(txtA_Mgr2Desig.Text);


                            string aid = funclib.AutoKey("A", con, "select A_ID from Agent_Master order by A_ID desc");
                            SqlCommand cmdAgent = new SqlCommand("insert into Agent_Master values('" + aid + "','" + Group_ID + "','" + strAName.Trim().Replace("'", "''").ToString() + "','" + txtA_Addr1.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Addr2.Text.Trim().Replace("'", "''").ToString() + "','" + ddlA_City.SelectedValue.ToString() + "','" + ddlA_State.SelectedValue.ToString() + "','" + txtA_PinCode.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Tel.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_FAX.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Email.Text.Trim().Replace("'", "''").ToString() + "', '" + txtA_Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + ddlA_WeekOff.SelectedValue.ToString() + "','" + strMgr1.Trim().Replace("'", "''").ToString() + "','" + strDesg1.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr1Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr1Email.Text.Trim().Replace("'", "''").ToString() + "','" + strMgr2.Trim().Replace("'", "''").ToString() + "','" + strDesg2.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr2Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Mgr2Email.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_ECC.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Regn.Text.Trim().Replace("'", "''").ToString() + "','" + txtLBT_No.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_CST.Text.Trim().Replace("'", "''").ToString() + "','" + ddlA_Type.Text + "','" + ddlA_Cate.SelectedItem.ToString() + "','" + txtA_CrDays.Text.Trim().Replace("'", "''").ToString() + "','" + ddlA_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','','" + txtPAN_No.Text.Trim().Replace("'", "''").ToString() + "','" + txtA_Tin.Text.Trim().Replace("'", "''").ToString() + "')", con);
                            con.Open();
                            int AgentRow = cmdAgent.ExecuteNonQuery();
                            MessageBox.Show("Record Inserted in Agent");
                            con.Close();
                            filldata();
                            clearAll();
                        }

                        //Checking for valid email id

                        //bool val = funclib.emailValidation(txtA_Email.Text);
                        //if (val == false)
                        //{
                        //    txtA_Email.Clear();
                        //    txtA_Email.Focus();
                        //}
                        //bool val1 = funclib.emailValidation(txtA_Mgr1Email.Text);
                        //if (val1 == false)
                        //{
                        //    txtA_Mgr1Email.Clear();
                        //    txtA_Mgr1Email.Focus();
                        //}
                        //bool val3 = funclib.emailValidation(txtA_Mgr2Email.Text);
                        //if (val3 == false)
                        //{
                        //    txtA_Mgr2Email.Clear();
                        //    txtA_Mgr2Email.Focus();
                        //}
                    }






                }






            }
            }
        private void filldata()
        {
            //to fill the Datagridview with user details named dgwMasterAgent 

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.A_ID as AgentID,a.A_Name as Agent,b.Grp_Name as GroupName,a.A_Addr1 as Addr1,a.A_Addr2 as Addr2,a.A_City as City,a.A_State as State,a.A_PinCode as Pincode,a.A_Tel as Tel,a.A_FAX as Fax,a.A_Email as Email,a.A_Mobile as Mobile,a.A_WeekOff as Weekoff,a.A_Mgr1Name as Mgr1,a.A_Mgr1Desig as Mgr1Desg,a.A_Mgr1Mobile as A_Mgr1Mobile,a.A_Mgr1Email as Email1,a.A_Mgr2Name as Mgr2,a.A_Mgr2Desig as Mgr2Desg,a.A_Mgr2Mobile as Mobile2,a.A_Mgr2Email as Email2,a.A_ECC as ECC,a.A_Regn as Regn,a.LBT_No as LBT,a.A_CST as CST,a.A_Type as Type,a.A_Cate as Category,a.A_CrDays as CrDays,a.A_Active as Active,a.PAN_No as Pan,a.A_Tin as Tin from Agent_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwMasterAgent.DataSource = dt;
            this.dgwMasterAgent.Columns[0].Visible = false;
        }
        private void clearAll()
        {
            //Clear all fields

            ddlGrp_ID.Text = "";
            txtA_Name.Clear();
            txtA_Addr1.Clear();
            txtA_Addr2.Clear();
            txtLBT_No.Clear();
            txtA_CST.Clear();
            ddlA_City.Text = "";
            ddlA_State.Text = "";
            txtA_Email.Clear();
            txtA_FAX.Clear();
            txtA_Mgr1Desig.Clear();
            txtA_Mobile.Clear();
            ddlA_WeekOff.Text = "";
            txtA_Mgr1Email.Clear();
            txtA_Mgr1Mobile.Clear();
            txtA_Mgr1Name.Clear();
            txtA_Mgr2Desig.Clear();
            txtA_Mgr2Email.Clear();
            txtA_Mgr2Name.Clear();
            txtA_Mgr2Mobile.Clear();
            ddlA_Active.Text = "";
            txtA_CrDays.Clear();
            txtA_PinCode.Clear();
            txtA_ECC.Clear();
            txtA_Tel.Clear();
            txtA_Tin.Clear();

            cmdSubmit.Enabled = true;
            cmdEdit.Enabled = false;

            ddlA_Active.SelectedText = "Yes";
            ddlA_Active.Enabled = false;

            txtA_Addr1.Focus();
            ddlGrp_ID.Enabled = true;
            txtA_Name.Enabled = true;
            ddlA_Type.Enabled = true;
            ddlA_Cate.Enabled = true;

            txtA_Regn.Clear();
            txtPAN_No.Clear();
           

            
        }










        private void ddlA_Cate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string str = ddlA_Cate.SelectedItem.ToString();
            //if (str.Equals("Purchase") == true)
            //{
            //    ddlA_Type.Enabled = true;
            //}
            //if (str.Equals("JobWork") == true)
            //{
            //    ddlA_Type.Enabled = false;
            //}




        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search A_Name data from table Agent_Master
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.A_ID as AgentID,a.A_Name as Agent,b.Grp_Name as GroupName,a.A_Addr1 as Addr1,a.A_Addr2 as Addr2,a.A_City as City,a.A_State as State,a.A_PinCode as Pincode,a.A_Tel as Tel,a.A_FAX as Fax,a.A_Email as Email,a.A_Mobile as Mobile,a.A_WeekOff as Weekoff,a.A_Mgr1Name as Mgr1,a.A_Mgr1Desig as Mgr1Desg,a.A_Mgr1Mobile as A_Mgr1Mobile,a.A_Mgr1Email as Email1,a.A_Mgr2Name as Mgr2,a.A_Mgr2Desig as Mgr2Desg,a.A_Mgr2Mobile as Mobile2,a.A_Mgr2Email as Email2,a.A_ECC as ECC,a.A_Regn as Regn,a.LBT_No as LBT,a.A_CST as CST,a.A_Type as Type,a.A_Cate as Category,a.A_CrDays as CrDays,a.A_Active as Active,a.PAN_No,a.A_Tin as TinNo from Agent_Master a,Group_Master b where a.A_Name like '%" + txtA_Name_Search.Text + "%' and b.Grp_ID=a.Grp_ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwMasterAgent.DataSource = dt;


            if (dgwMasterAgent.Rows.Count == 0)
            {

                cmdExcelReport.Visible = false;
            }

            else
            {
                cmdExcelReport.Visible = true;
            }
        }

        private void dgwMasterAgent_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlA_Active.Enabled = true;

            //to display data in form on click of datagridview named dgwMasterAgent

                txtA_ID.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtA_Name.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[1].Value.ToString();
               // ddlGrp_ID.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtA_Addr1.Text=dgwMasterAgent.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtA_Addr2.Text=dgwMasterAgent.Rows[e.RowIndex].Cells[4].Value.ToString();
                ddlA_City.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[5].Value.ToString();
                ddlA_State.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtA_PinCode.Text=dgwMasterAgent.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtA_Tel.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtA_FAX.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtA_Email.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtA_Mobile.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[11].Value.ToString();
                ddlA_WeekOff.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtA_Mgr1Name.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[13].Value.ToString();
                txtA_Mgr1Desig.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[14].Value.ToString();
                txtA_Mgr1Mobile.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[15].Value.ToString();
                txtA_Mgr1Email.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[16].Value.ToString();
                txtA_Mgr2Name.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[17].Value.ToString();
                txtA_Mgr2Desig.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[18].Value.ToString();
                txtA_Mgr2Mobile.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[19].Value.ToString();
                txtA_Mgr2Email.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[20].Value.ToString();
                txtA_ECC.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[21].Value.ToString();
                txtA_Regn.Text=dgwMasterAgent.Rows[e.RowIndex].Cells[22].Value.ToString();
                txtLBT_No.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[23].Value.ToString();
                txtA_CST.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[24].Value.ToString();
                ddlA_Type.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[25].Value.ToString();
                ddlA_Cate.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[26].Value.ToString();
                txtA_CrDays.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[27].Value.ToString();
                ddlA_Active.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[28].Value.ToString();
                txtPAN_No.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[29].Value.ToString();
                txtA_Tin.Text = dgwMasterAgent.Rows[e.RowIndex].Cells[30].Value.ToString();

                txtA_Name.Enabled = false;
                ddlGrp_ID.Enabled = false;
                ddlA_Cate.Enabled = false;
                ddlA_Type.Enabled = false;




            
            
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

            //txtA_Name.Text = funclib.FirstCap(txtA_Name.Text);
            txtA_Addr1.Text = funclib.FirstCap(txtA_Addr1.Text);
            txtA_Mgr1Name.Text = funclib.FirstCap(txtA_Mgr1Name.Text);
            txtA_Mgr2Name.Text = funclib.FirstCap(txtA_Mgr2Name.Text);
                           

            //Update data in table Agent_Master
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Agent_Master set A_Addr1='" + txtA_Addr1.Text + "',A_Addr2 ='" + txtA_Addr2.Text + "',A_City ='" + ddlA_City.SelectedValue.ToString() + "',A_State ='" + ddlA_State.SelectedValue.ToString() + "',A_PinCode='" + txtA_PinCode.Text + "',A_Tel='" + txtA_Tel.Text + "',A_FAX='" + txtA_FAX.Text + "',A_Email ='" + txtA_Email.Text + "',A_Mobile ='" + txtA_Mobile.Text + "',A_WeekOff='" + ddlA_WeekOff.SelectedValue.ToString() + "',A_Mgr1Name='" + txtA_Mgr1Name.Text + "',A_Mgr1Desig='" + txtA_Mgr1Desig.Text + "',A_Mgr1Mobile='" + txtA_Mgr1Mobile.Text + "',A_Mgr1Email='" + txtA_Mgr1Email.Text + "',A_Mgr2Name='" + txtA_Mgr2Name.Text + "',A_Mgr2Desig='" + txtA_Mgr2Desig.Text + "',A_Mgr2Mobile='" + txtA_Mgr2Mobile.Text + "',A_Mgr2Email='" + txtA_Mgr2Email.Text + "',A_ECC='" + txtA_ECC.Text + "',LBT_No='" + txtLBT_No.Text + "',A_CST='" + txtA_CST.Text + "',A_CrDays='" + txtA_CrDays.Text + "',A_Active='" + ddlA_Active.SelectedItem.ToString() + "',PAN_No='" + txtPAN_No.Text + "',A_Tin='" + txtA_Tin.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where A_ID='" + txtA_ID.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            clearAll();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the AgentMaster form
            clearAll();
        }

        

        private void ddlA_Cate_SelectedValueChanged(object sender, EventArgs e)
        {
            string str = ddlA_Cate.SelectedItem.ToString();
            if (str.Equals("Purchase") == true)
            {
                ddlA_Type.Enabled = true;
            }
            if (str.Equals("JobWork") == true)
            {
                ddlA_Type.Enabled = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Code to close AgentMaster form temporarily 
            //Application.Exit();
            this.Close();


        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "AgentMaster.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                strSQL = strSQL + "select a.A_ID as AgentID,a.A_Name as Agent,b.Grp_Name as GroupName,a.A_Addr1 as Addr1,a.A_Addr2 as Addr2,a.A_City as City,a.A_State as State,a.A_PinCode as Pincode,a.A_Tel as Tel,a.A_FAX as Fax,a.A_Email as Email,a.A_Mobile as Mobile,a.A_WeekOff as Weekoff,a.A_Mgr1Name as Mgr1,a.A_Mgr1Desig as Mgr1Desg,a.A_Mgr1Mobile as A_Mgr1Mobile,a.A_Mgr1Email as Email1,a.A_Mgr2Name as Mgr2,a.A_Mgr2Desig as Mgr2Desg,a.A_Mgr2Mobile as Mobile2,a.A_Mgr2Email as Email2,a.A_ECC as ECC,a.A_Regn as Regn,a.LBT_No as LBT,a.A_CST as CST,a.A_Type as Type,a.A_Cate as Category,a.A_CrDays as CrDays,a.A_Active as Active,a.PAN_No,a.Tin as TinNo from Agent_Master a,Group_Master b where a.A_Name like '%" + txtA_Name.Text.Trim().Replace("'", "''").ToString() + "%' and b.Grp_ID=a.Grp_ID";

                // string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "eBabyReport.xls");
                string data = null;
                ////to fill the grid with user details
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                int i = 0;
                int j = 0;
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;


                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlApp.Columns.ColumnWidth = 30;
                con4.Open();

                SqlDataAdapter da = new SqlDataAdapter(strSQL, con4);
                //da.TableMappings.Add("Item_Master", "Item_Master");
                //SqlDataAdapter da = new SqlDataAdapter("select a.TP_ID as TopPaperID,b.Grp_Name as GroupName,c.P_Name as PartyName,a.TP_Name as TopPaperName,d.PQ_Desc as PaperQuality, a.TP_PPLgth as TopPaperLength,a.TP_PPWdth as PaperWidth,a.TP_PPBf as PaperBf, a.TP_PPGram as PaperGram,a.TP_PPRate as PaperRate,a.TP_PPCost as PaperCost, a.TP_LmLgth as LaminationLength,a.TP_LmWdth as LaminationWidth, a.TP_LmRate as LaminationRate,a.TP_LmCost as LaminationCost ,a.TP_LmType as LaminationType,a.TP_VrLgth as VarnishLength,a.TP_VrWdth as varnishWidth,a.TP_VrRate as vanishRate,a.TP_VrCost as VarnishCost,a.TP_VrType as varnishType, a.TP_PnColor as NoColors,a.TP_PnRate as PlateRate,a.TP_PnCost as PlateCost,a.TP_PlDivFact as Divfactor, a.TP_PlNo as PlateNo,a.TP_PlRate as PlateRate,a.TP_PlCost as PlateCost, a.TP_PlWsCnt as WeightPercnt,a.TP_PlWsAmt as WeightAmt,e.Ptve_Name as PositiveName, a.TP_Rate as Rate,a.TP_OS as OpenStock,a.TP_CS as ClosingStock,a.TP_ReLev as ReOrder, a.TP_Active as Active from TopPaper_Master a,Group_Master b ,Party_Master c,PQuality_Master d,Positive_Master e  where b.Grp_ID=a.Grp_ID and b.Grp_ID=c.Grp_ID and b.Grp_ID=d.Grp_ID and a.PQ_ID=d.PQ_ID and a.P_ID=c.P_ID and a.Ptve_ID=e.Ptve_ID", con4);
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (i = 1; i <= ds.Tables[0].Columns.Count; i++)
                {
                    xlApp.Cells[1, i] = ds.Tables[0].Columns[i - 1].Caption.ToString();
                }
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[i + 3, j + 1] = data;
                    }


                }
                //xlApp.ActiveWorkbook.SaveCopyAs("C:\\ExcelReport.xls");
                //xlApp.ActiveWorkbook.Saved = true;
                //xlApp.Quit();
                //xlApp.ActiveWorkbook.SaveCopyAs("C:\\ExcelReport.xls");
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel File Created ");

            }

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

      

    }
}


        
    

       
