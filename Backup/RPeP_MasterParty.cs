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
    public partial class RPeP_MasterParty : Form
    {
        //Page developed by Shirish on(4/3/2011)
        private FunctionLib funclib;
        string strPartyName, session, strMgr1, strMgr2, strDesg1, strDesg2, strSQL, Group_ID;
        public RPeP_MasterParty()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdEdit.Enabled = false;
            txtP_ID.Visible = false;
        }

        private void RPeP_MasterParty_Load(object sender, EventArgs e)
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



            //Displaying values in ddlPM_ID_Search combo box
            con1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT '' as PM_ID, '' as PM_Name UNION select a.PM_ID,a.PM_Name as Party_Data from PartyMain_Master a,Group_Master b where b.Grp_Active='yes'", con1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            ddlPM_ID_Search.DataSource = dt1;
            ddlPM_ID_Search.DisplayMember = dt1.Columns[1].ToString();
            ddlPM_ID_Search.ValueMember = dt1.Columns[0].ToString();
            con1.Close();
            
            

            
            //Displayig City Name in Combo field
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select '' as City_Name UNION select City_Name from City_Master", con1);
            DataTable dt2=new DataTable();
            da2.Fill(dt2);
            ddlP_City.DataSource=dt2;
            ddlP_City.DisplayMember=dt2.Columns[0].ToString();
            ddlP_City.ValueMember=dt2.Columns[0].ToString();
            con1.Close();
            
            //Displayig State Name in Combo field
            con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select '' as State_Name UNION select State_Name from State_Master", con1);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            ddlP_State.DataSource = dt3;
            ddlP_State.DisplayMember = dt3.Columns[0].ToString();
            ddlP_State.ValueMember = dt3.Columns[0].ToString();
            con1.Close();
            
            //Displaying weekoff day
            con1.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("Select '' as B_Day UNION select B_Day from B_Cal", con1);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            ddlP_WeekOff1.DataSource = dt4;
            ddlP_WeekOff1.DisplayMember = dt4.Columns[0].ToString();
            ddlP_WeekOff1.ValueMember = dt4.Columns[0].ToString();
            con1.Close();



            SqlDataAdapter da6 = new SqlDataAdapter("SELECT '' as PM_ID, '' as PM_Name UNION select PM_ID,PM_Name from PartyMain_Master where Grp_ID='" + Group_ID + "'", con1);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);
            ddlP_Name.DataSource = dt6;
            ddlP_Name.DisplayMember = dt6.Columns[1].ToString();
            ddlP_Name.ValueMember = dt6.Columns[0].ToString();
            con1.Close();
            
           //Displaying Top_Paper Values
           
            ddlP_TopPaper.Items.Add("Yes");
            ddlP_TopPaper.Items.Add("No");
            
            //Displaying CForm Values
            ddlP_CForm.Items.Add("Yes");
            ddlP_CForm.Items.Add("No");

            //Displaying Active Values
            ddlP_Active.SelectedText = "Yes";
            ddlP_Active.Enabled = false;
            ddlP_Active.Items.Add("Yes");
            ddlP_Active.Items.Add("No");
        }

        private void txtP_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Name Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);

        }

        private void txtP_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Addr1 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtP_Addr1.Text);
            lblAddrChar.Text = "(Character " + P_AddressData + "  " + "Out of" + txtP_Addr1.MaxLength + ")";
        }

        private void txtP_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Addr2 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtP_Addr2.Text);
            lblAddreChar2.Text = "(Character " + P_AddressData + "  " + "Out of" + txtP_Addr2.MaxLength + ")";

        }

        private void txtP_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_PinCode Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtP_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Tel Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtP_FAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_FAX Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }
        private void txtP_Mgr1Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr1Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtP_Mgr2Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr2Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtP_Mgr1Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr1Name Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);


        }

        private void txtP_Mgr2Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr2Name Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtP_Mgr1Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr1Desig Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtP_Mgr2Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mgr2Desig Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

       private void txtP_Mobile1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Mobile1 Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtP_ECC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_ECC Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);


        }

        private void txtP_Tin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_Tin Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            
        }

        private void txtP_BST_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_BST Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtP_CST_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_CST Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);

        }

        private void txtP_CrDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating P_CST Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {

            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}


           if (ddlP_Name.Text == "")//checking for blank P_(Main)Name combo field 
            {
                MessageBox.Show("Please Select Party(Main) Name");
                ddlP_Name.Focus();
            }
            else if (txtP_Name.Text == "")//checking for blank P_Name text field 
            {
                MessageBox.Show("Please enter Party Name");
                txtP_Name.Focus();
            }
            else if (txtP_Addr1.Text == "")//checking for blank Addr1 text field 
            {
                MessageBox.Show("Please Enter Address1");
                txtP_Addr1.Focus();
            }
            
            else if (ddlP_City.Text == "")//Checking for blnk City field
            {
                MessageBox.Show("Please Select City");
                ddlP_City.Focus();
            }
            else if (ddlP_State.Text == "")//Checking for blnk State field
            {
                MessageBox.Show("Please Select State");
                ddlP_State.Focus();
            }
            else if (txtP_PinCode.Text == "")//Checking for blnk PinCode field
            {
                MessageBox.Show("Enter Pincode number");
                txtP_PinCode.Focus();
            }
            else if (txtP_Tel.Text == "")//Checking for blnk TelNo field
            {
                MessageBox.Show("Enter Telephone no");
                txtP_Tel.Focus();
            }
            else if (ddlP_WeekOff1.Text == "")//Checking for blnk weeklyoff field
            {
                MessageBox.Show("Select Weeklyoff");
                ddlP_WeekOff1.Focus();
            }
            else if (txtP_ECC.Text == "")//Checking for blnk ECC field
            {
                MessageBox.Show("Enter ECC no");
                txtP_ECC.Focus();
            }
            else if (txtP_CST.Text == "")////Checking for blnk CST field
            {
                MessageBox.Show("Enter CST");
                txtP_CST.Focus();
            }
            else if (txtP_Tin.Text == "")//Checking for blnk Tin field
            {
                MessageBox.Show("Enter Tin No");
                txtP_Tin.Focus();
            }
            else if (ddlP_TopPaper.Text == "")//Checking for blnk Top Paper field
            {
                MessageBox.Show("Select Top Paper");
                ddlP_TopPaper.Focus();
            }
            else if (ddlP_Active.Text == "")//Checking for blnk Active field
            {
                MessageBox.Show("Select Active field");
                ddlP_Active.Focus();
            }
            else if (ddlP_CForm.Text == "")//Checking for blnk CForm field
            {
                MessageBox.Show("Select CForm");
                ddlP_CForm.Focus();
            }
            else if (txtPAN_No.Text == "")//Checking for blank pan no
            {
                MessageBox.Show("Enter PAN No");
                txtPAN_No.Focus();

            }
            else
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Checking for duplicate values
                    double flag = funclib.isThere(con, "select P_Name,PM_ID,Grp_ID from Party_Master where P_Name='" + txtP_Name.Text + "'and PM_ID='" + Group_ID + "' and Grp_ID='" + Group_ID + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Party Name, Party (Main) and Group is not allowed");
                    }


                    else
                    {
                        //Inserting Details into table

                        strPartyName = funclib.FirstCap(txtP_Name.Text);
                        txtP_Addr1.Text = funclib.FirstCap(txtP_Addr1.Text);
                        strMgr1 = funclib.FirstCap(txtP_Mgr1Name.Text);
                        strMgr2 = funclib.FirstCap(txtP_Mgr2Name.Text);
                        strDesg1 = funclib.FirstCap(txtP_Mgr1Desig.Text);
                        strDesg2 = funclib.FirstCap(txtP_Mgr2Desig.Text);

                        string pmid = funclib.AutoKey("P", con, "select P_ID from Party_Master order by P_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Party_Master values('" + pmid + "','" + Group_ID + "','" + ddlP_Name.SelectedValue.ToString() + "','" + strPartyName.Trim().Replace("'", "''").ToString() + "','" + txtP_Addr1.Text.Trim().Replace("'", "''").ToString() + "','" + txtP_Addr2.Text.Trim().Replace("'", "''").ToString() + "','" + ddlP_City.SelectedValue.ToString() + "','" + ddlP_State.SelectedValue.ToString() + "','" + txtP_PinCode.Text.Trim().Replace("'", "''").ToString() + "','" + txtP_Tel.Text.Trim().Replace("'", "''").ToString() + "','" + txtP_FAX.Text.Trim().Replace("'", "''").ToString() + "','" + txtP_Email.Text.Trim().Replace("'", "''").ToString() + "', '" + txtP_Mobile1.Text.Trim().Replace("'", "''").ToString() + "','" + ddlP_WeekOff1.SelectedValue.ToString() + "','" + strMgr1.Trim().Replace("'", "''").ToString() + "','" + strDesg1.Trim().Replace("'", "''").ToString() + "','" + txtP_Mgr1Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtP_Mgr1Email.Text.Trim().Replace("'", "''").ToString() + "','" + strMgr2.Trim().Replace("'", "''").ToString() + "','" + strDesg2.Trim().Replace("'", "''").ToString() + "','" + txtP_Mgr2Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtP_Mgr2Email.Text.Trim().Replace("'", "''").ToString() + "','" + txtP_ECC.Text.Trim().Replace("'", "''").ToString() + "','" + txtP_Tin.Text.Trim().Replace("'", "''").ToString() + "','" + txtLBT_No.Text.Trim().Replace("'", "''").ToString() + "','" + txtP_CST.Text.Trim().Replace("'", "''").ToString() + "','" + ddlP_TopPaper.SelectedItem.ToString() + "','" + ddlP_CForm.SelectedItem.ToString() + "','" + txtP_CrDays.Text.Trim().Replace("'", "''").ToString() + "','" + ddlP_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','','" + txtPAN_No.Text.Trim().Replace("'", "''").ToString() + "')", con);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
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
            SqlDataAdapter da = new SqlDataAdapter("select P_ID as PartyID,Grp_Name as GroupName,PM_ID as PartyID,P_Name as Party,P_Addr1 as Addr1,P_Addr2 as Addr2,P_City as City,P_State as State,P_PinCode as PinCode,P_Tel as Tel,P_FAX as Fax,P_Email as Email,P_Mobile as Mobile,P_WeekOff as Weekoff,P_Mgr1Name as Mgr1,P_Mgr1Desig Desg1,P_Mgr1Mobile as Mobile1,P_Mgr1Email as Email1,P_Mgr2Name as Mgr2,P_Mgr2Desig as Desg2,P_Mgr2Mobile as Mobile2,P_Mgr2Email as Email2,P_ECC as ECC,P_Tin as TinNo,LBT_No,P_CST as CST,P_TopPaper as TopPaper,P_CForm as CForm,P_CrDays as CreditDays,P_Active as Active,PAN_No as PANNO from Party_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwRPeP_MasterParty.DataSource = dt;
            this.dgwRPeP_MasterParty.Columns[0].Visible = false;
            
         }
        private void clearAll()
        {
            //Clear all fields
            txtP_Name.Enabled = true;
            ddlGrp_ID.Enabled = true;
            ddlP_Name.Enabled = true;

            ddlGrp_ID.Text = "";
            ddlP_Name.Text = "";
            txtP_Name.Clear();
            txtP_Addr1.Clear();
            txtP_Addr2.Clear();
            txtP_ECC.Clear();
            txtLBT_No.Clear();
            txtP_CST.Clear();
            txtP_PinCode.Clear();
            txtP_Tel.Clear();
            ddlP_City.Text = "";
            ddlP_State.Text = "";
            txtP_Email.Clear();
            txtP_FAX.Clear();
            txtP_Mgr1Desig.Clear();
            txtP_Mobile1.Clear();
            ddlP_WeekOff1.Text = "";
            txtP_Mgr1Email.Clear();
            txtP_Mgr1Mobile.Clear();
            txtP_Mgr1Name.Clear();
            txtP_Mgr2Desig.Clear();
            txtP_Mgr2Email.Clear();
            txtP_Mgr2Name.Clear();
            txtP_Mgr2Mobile.Clear();
            ddlP_TopPaper.Text = "";
            ddlP_Active.Text = "";
            ddlP_CForm.Text = "";
            txtPAN_No.Clear();
            txtP_CrDays.Clear();
            txtP_Tin.Clear();

            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;
            ddlP_Active.Enabled = false;
            ddlP_Active.SelectedText = "Yes";

        }

            

        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Displayig Party Name in Combo field
            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            //SqlConnection con1 = new SqlConnection(strcon);
            //SqlDataAdapter da1 = new SqlDataAdapter("select PM_ID,PM_Name from PartyMain_Master where Grp_ID='" + Group_ID + "'", con1);
            //DataTable dt1 = new DataTable();
            //da1.Fill(dt1);
            //ddlP_Name.DataSource = dt1;
            //ddlP_Name.DisplayMember = dt1.Columns[1].ToString();
            //ddlP_Name.ValueMember = dt1.Columns[0].ToString();
            //con1.Close();
        }

        private void dgwRPeP_MasterParty_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            //to display data in form on click of datagridview
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlP_Active.Enabled = true;

            txtP_ID.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[0].Value.ToString();
            //ddlGrp_ID.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlP_Name.SelectedValue = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtP_Name.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtP_Addr1.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtP_Addr2.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlP_City.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[6].Value.ToString();
            ddlP_State.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtP_PinCode.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtP_Tel.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtP_FAX.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtP_Email.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtP_Mobile1.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[12].Value.ToString();
            ddlP_WeekOff1.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtP_Mgr1Name.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtP_Mgr1Desig.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtP_Mgr1Mobile.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[16].Value.ToString();
            txtP_Mgr1Email.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtP_Mgr2Name.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtP_Mgr2Desig.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[19].Value.ToString();
            txtP_Mgr2Mobile.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[20].Value.ToString();
            txtP_Mgr2Email.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[21].Value.ToString();
            txtP_ECC.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[22].Value.ToString();
            txtP_Tin.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[23].Value.ToString();
            txtLBT_No.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[24].Value.ToString();
            txtP_CST.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[25].Value.ToString();
            ddlP_TopPaper.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[26].Value.ToString();
            ddlP_CForm.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[27].Value.ToString();
            txtP_CrDays.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[28].Value.ToString();
            ddlP_Active.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[29].Value.ToString();
            txtPAN_No.Text = dgwRPeP_MasterParty.Rows[e.RowIndex].Cells[30].Value.ToString();

            txtP_Name.Enabled = false;
            ddlGrp_ID.Enabled = false;
            ddlP_Name.Enabled = false;

            


           

        
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            txtP_Addr1.Text = funclib.FirstCap(txtP_Addr1.Text);
            //Update data in table
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Party_Master set P_Name ='" + txtP_Name.Text + "',P_Addr1='" + txtP_Addr1.Text + "',P_Addr2 ='" + txtP_Addr2.Text + "',P_City ='" + ddlP_City.SelectedValue.ToString() + "',P_State ='" + ddlP_State.SelectedValue.ToString() + "',P_PinCode='" + txtP_PinCode.Text + "',P_Tel='" + txtP_Tel.Text + "',P_FAX='" + txtP_FAX.Text + "',P_Email ='" + txtP_Email.Text + "',P_Mobile ='" + txtP_Mobile1.Text + "',P_WeekOff='" + ddlP_WeekOff1.SelectedValue.ToString() + "',P_Mgr1Name='" + txtP_Mgr1Name.Text + "',P_Mgr1Desig='" + txtP_Mgr1Desig.Text + "',P_Mgr1Mobile='" + txtP_Mgr1Mobile.Text + "',P_Mgr1Email='" + txtP_Mgr1Email.Text + "',P_Mgr2Name='" + txtP_Mgr2Name.Text + "',P_Mgr2Desig='" + txtP_Mgr2Desig.Text + "',P_Mgr2Mobile='" + txtP_Mgr2Mobile.Text + "',P_Mgr2Email='" + txtP_Mgr2Email.Text + "',P_ECC='" + txtP_ECC.Text + "',P_Tin='" + txtP_Tin.Text + "',LBT_No='" + txtLBT_No.Text + "',P_CST='" + txtP_CST.Text + "',P_TopPaper='" + ddlP_TopPaper.SelectedItem.ToString() + "',P_CForm='" + ddlP_CForm.SelectedItem.ToString() + "',P_CrDays='" + txtP_CrDays.Text + "',P_Active='" + ddlP_Active.SelectedItem.ToString() + "',PAN_No='" + txtPAN_No.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where P_ID='" + txtP_ID.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            clearAll();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from Party_Master where PM_ID='" + ddlPM_ID_Search.SelectedValue.ToString() + "' and P_Name like '%" + txtP_Name_Search.Text + "%'", con);
            //SqlDataAdapter da = new SqlDataAdapter("select * from Party_Master where P_Name like '%" + txtP_Name_Search.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwRPeP_MasterParty.DataSource = dt;

            if (dgwRPeP_MasterParty.Rows.Count == 0)
            {

                cmdExcelReport.Visible = false;
            }

            else
            {
                cmdExcelReport.Visible = true;
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void txtPAN_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating PAN Number

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Code to close Master Party form temporarily
            this.Close();

        }

        private void ddlPM_ID_Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Search data from table
            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            //SqlConnection con = new SqlConnection(strcon);
            //SqlDataAdapter da = new SqlDataAdapter("select * from Party_Master where PM_ID='" + ddlPM_ID_Search.SelectedValue.ToString() + "'", con);
            ////SqlDataAdapter da = new SqlDataAdapter("select * from Party_Master where P_Name like '%" + txtP_Name_Search.Text + "%'", con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dgwRPeP_MasterParty.DataSource = dt;


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterParty.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                strSQL = strSQL + "select * from Party_Master where PM_ID='" + ddlPM_ID_Search.SelectedValue.ToString() + "' and P_Name like '%" + txtP_Name_Search.Text + "%'";

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

                MessageBox.Show("Excel File Created");
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