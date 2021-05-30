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
    public partial class RPeP_MasterDriver : Form
    {
        //Page Developed by Shirish and Avinash on(15/3/2011).
        private FunctionLib funclib;
        string strFName, session, strMName, strLName, strOName, strSQL, Group_ID;
        public RPeP_MasterDriver()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            cmdEdit.Enabled = false;
            txtDrv_ID.Visible = false;
           // filldata();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDrv_FName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_FName Text Field
            funclib = new FunctionLib();
            //funclib.checkNumericChar(e);
            funclib.onlyCharacterPress(e);



        }

        private void txtDrv_MName_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Validating txtDrv_MName Text Field
            funclib = new FunctionLib();
            //funclib.checkNumericChar(e);
            funclib.onlyCharacterPress(e);


        }

        private void txtDrv_LName_KeyPress(object sender, KeyPressEventArgs e)
       {
           //Validating txtDrv_LName Text Field
            funclib = new FunctionLib();
            //funclib.checkNumericChar(e);
            funclib.onlyCharacterPress(e);


        }

        private void txtDrv_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_Addr1 Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtDrv_Addr1.Text);
            lblAddressone.Text = "(Character " + P_AddressData + "  " + "Out of" + txtDrv_Addr1.MaxLength + ")";

        }

        private void txtDrv_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Validating txtDrv_Addr2 Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtDrv_Addr2.Text);
            lblAddresstwo.Text = "(Character " + P_AddressData + "  " + "Out of" + txtDrv_Addr2.MaxLength + ")";

        }

        private void txtDrv_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_PinCode Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtDrv_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtDrv_BirthPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_BirthPlace Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtDrv_Owner_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Validating txtDrv_Owner Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);


        }

        private void txtDrv_OwnAddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_OwnAddr Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);

        }

        private void txtDrv_OwnPinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDrv_OwnPinCode Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtDrv_OwnPhone_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Validating txtDrv_OwnPhone Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void RPeP_MasterDriver_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();

            ////Displaying Group Name in GroupCombo field
            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();



            //Displaying City Name in CityCombo field
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select '' as City_Name UNION select City_Name from City_Master", con1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            ddlDrv_City.DataSource = dt2;
            ddlDrv_City.DisplayMember = dt2.Columns[0].ToString();
            ddlDrv_City.ValueMember = dt2.Columns[0].ToString();
            con1.Close();

            //Displaying State Name in StateCombo field
            con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select '' as State_Name UNION select State_Name from State_Master", con1);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            ddlDrv_State.DataSource = dt3;
            ddlDrv_State.DisplayMember = dt3.Columns[0].ToString();
            ddlDrv_State.ValueMember = dt3.Columns[0].ToString();
            con1.Close();


            //Displaying Active value in ActiveCombo field

            ddlDrv_Active.SelectedText = "Yes";
            ddlDrv_Active.Enabled = false;
            ddlDrv_Active.Items.Add("Yes");
            ddlDrv_Active.Items.Add("No");


            //Displaying Blood group values in BloodgroupCombo field

            ddlDrv_BloodGrp.Items.Add("AB+");
            ddlDrv_BloodGrp.Items.Add("AB-");
            ddlDrv_BloodGrp.Items.Add("O-");
            ddlDrv_BloodGrp.Items.Add("O+");
            ddlDrv_BloodGrp.Items.Add("A-");
            ddlDrv_BloodGrp.Items.Add("A+");
            ddlDrv_BloodGrp.Items.Add("B-");
            ddlDrv_BloodGrp.Items.Add("B+");


            //Displaying state values in LicnState

            con1.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("select '' as State_Name UNION select State_Name from State_Master", con1);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            ddlDrv_LicnState.DataSource = dt4;
            ddlDrv_LicnState.DisplayMember = dt4.Columns[0].ToString();
            ddlDrv_LicnState.ValueMember = dt4.Columns[0].ToString();
            con1.Close();

            //Displaying Owner City Name in Combo field
            con1.Open();

            SqlDataAdapter da5 = new SqlDataAdapter("select '' as City_Name UNION select City_Name from City_Master", con1);
            DataTable dt5 = new DataTable();
            da2.Fill(dt5);
            ddlDrv_OwnCity.DataSource = dt5;
            ddlDrv_OwnCity.DisplayMember = dt5.Columns[0].ToString();
            ddlDrv_OwnCity.ValueMember = dt5.Columns[0].ToString();
            con1.Close();

            //Displaying Owner State Name in Combo field
            con1.Open();
            SqlDataAdapter da6 = new SqlDataAdapter("select '' as State_Name UNION select State_Name from State_Master", con1);
            DataTable dt6 = new DataTable();
            da3.Fill(dt6);
            ddlDrv_OwnState.DataSource = dt6;
            ddlDrv_OwnState.DisplayMember = dt6.Columns[0].ToString();
            ddlDrv_OwnState.ValueMember = dt6.Columns[0].ToString();
            con1.Close();



        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}


            if (txtDrv_FName.Text == "")//checking for blank First Name text field 
            {
                MessageBox.Show("Please Enter Name");
                txtDrv_FName.Focus();
            }
            else if (txtDrv_LName.Text == "")//checking for blank Last Name text field 
            {
                MessageBox.Show("Please enter Last Name");
                txtDrv_LName.Focus();
            }
            //else if (txtDrv_Addr1.Text == "")//checking for blank Addr1 text field 
            //{
            //    MessageBox.Show("Please Enter Address1");
            //    txtDrv_Addr1.Focus();
            //}

            else if (ddlDrv_City.Text == "")//Checking for blank City combo field
            {
                MessageBox.Show("Please Select City");
                ddlDrv_City.Focus();
            }
            else if (ddlDrv_State.Text == "")//Checking for blank State combo field
            {
                MessageBox.Show("Please Select State");
                ddlDrv_State.Focus();
            }
            //else if (txtDrv_PinCode.Text == "")//Checking for blank PinCode text field
            //{
            //    MessageBox.Show("Enter Pincode number");
            //    txtDrv_PinCode.Focus();
            //}
            //else if (txtDrv_Mobile.Text == "")//Checking for blank Mobile text field
            //{
            //    MessageBox.Show("Enter Mobile no");
            //    txtDrv_Mobile.Focus();
            //}
            //else if (txtDrv_BirthPlace.Text == "")//Checking for blank BirthPlace text field
            //{
            //    MessageBox.Show("Enter BirthPlace");
            //    txtDrv_BirthPlace.Focus();
            //}
            //else if (ddlDrv_BloodGrp.Text == "")//Checking for blank BloodGroup combo field
            //{
            //    MessageBox.Show("Please Select Blood Group");
            //    ddlDrv_BloodGrp.Focus();
            //}
            else if (txtDrv_LicnNo.Text == "")////Checking for blank LicenseNo text field
            {
                MessageBox.Show("Enter License no");
                txtDrv_LicnNo.Focus();
            }
            else if (ddlDrv_LicnState.Text == "")//Checking for blank LicenseState text field
            {
                MessageBox.Show("Select License State field");
                ddlDrv_LicnState.Focus();
            }
            else if (txtDrv_Owner.Text == "")//Checking for blank Ownername text field
            {
                MessageBox.Show("Enter Owner Name");
                txtDrv_Owner.Focus();
            }
            //else if (txtDrv_OwnAddr.Text == "")//Checking for blank OwnerAddress text field
            //{
            //    MessageBox.Show("Enter Owner Address");
            //    txtDrv_OwnAddr.Focus();
            //}
            else if (ddlDrv_OwnCity.Text == "")//Checking for blank OwnerCity text field
            {
                MessageBox.Show("Select Owner City");
                ddlDrv_OwnCity.Focus();
            }
            else if (ddlDrv_OwnState.Text == "")//Checking for blank OwnerState text field
            {
                MessageBox.Show("Select Owner State");
                ddlDrv_OwnState.Focus();
            }
            //else if (txtDrv_OwnPhone.Text == "")//Checking for blank OwnerPhoneNo text field
            //{
            //    MessageBox.Show("Enter Owner Phone No");
            //    txtDrv_OwnPhone.Focus();

            //}
            //else if (txtDrv_OwnPinCode.Text == "")//Checking for blank OwnerPincode text field
            //{
            //    MessageBox.Show("Enter Pincode");
            //    txtDrv_OwnPinCode.Focus();
            //}
            else if (ddlDrv_Active.Text == "")//Checking for blank Active combo field
            {
                MessageBox.Show("Please select Active field");
                ddlDrv_Active.Focus();
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
                    double flag = funclib.isThere(con, "select Drv_FName,Drv_MName,Drv_LName,Grp_ID from Driver_Master where Drv_FName='" + txtDrv_FName.Text + "'and Drv_MName='" + txtDrv_MName.Text + "' and Drv_LName='" + txtDrv_LName.Text + "' and Grp_ID='" + Group_ID + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Driver Name and Group is not allowed");

                    }
                    else
                    {
                        //Inserting Details into table Driver_Master.
                        strFName = funclib.FirstCap(txtDrv_FName.Text);
                        strMName = funclib.FirstCap(txtDrv_MName.Text);
                        strLName = funclib.FirstCap(txtDrv_LName.Text);
                        strOName = funclib.FirstCap(txtDrv_Owner.Text);
                        txtDrv_Addr1.Text = funclib.FirstCap(txtDrv_Addr1.Text);
                        string drid = funclib.AutoKey1("DR", con, "select Drv_ID from Driver_Master order by Drv_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Driver_Master values('" + drid + "','" + Group_ID + "','" + strFName.Trim().Replace("'", "''").ToString() + "','" + strMName.Trim().Replace("'", "''").ToString() + "','" + strLName.Trim().Replace("'", "''").ToString() + "','" + txtDrv_Addr1.Text.Trim().Replace("'", "''").ToString() + "','" + txtDrv_Addr2.Text.Trim().Replace("'", "''").ToString() + "','" + ddlDrv_City.SelectedValue.ToString() + "','" + ddlDrv_State.SelectedValue.ToString() + "','" + txtDrv_PinCode.Text.Trim().Replace("'", "''").ToString() + "','" + txtDrv_Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtDrv_BirthPlace.Text.Trim().Replace("'", "''").ToString() + "', '" + ddlDrv_BloodGrp.Text.ToString() + "','" + txtDrv_LicnNo.Text.Trim().Replace("'", "''").ToString() + "','" + ddlDrv_LicnState.SelectedValue.ToString() + "','" + strOName.Trim().Replace("'", "''").ToString() + "','" + txtDrv_OwnAddr.Text.Trim().Replace("'", "''").ToString() + "','" + ddlDrv_OwnCity.SelectedValue.ToString() + "','" + ddlDrv_OwnState.SelectedValue.ToString() + "','" + txtDrv_OwnPinCode.Text.Trim().Replace("'", "''").ToString() + "','" + txtDrv_OwnPhone.Text.Trim().Replace("'", "''").ToString() + "','" + ddlDrv_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
            //to fill the Datagridview with user details named dgwDriver_Master.
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.Drv_ID  as DriverID,b.Grp_Name as GroupName,a.Drv_FName as FirstName,a.Drv_MName as MiddleName,a.Drv_LName as LastName,a.Drv_Addr1 as Addr1,a.Drv_Addr2 as Addr2,a.Drv_City as DriverCity,a.Drv_State as DriverState,a.Drv_PinCode as DriverPinCode,a.Drv_Mobile as DriverMobile,a.Drv_BirthPlace as DriverBirth,a.Drv_BloodGrp as Bloodroup,a.Drv_LicnNo as LicenseNo,a.Drv_LicnState as LicenseState,a.Drv_Owner as DriverOwner,a.Drv_OwnAddr as OwnerAddr,a.Drv_OwnCity as OwnerCity,a.Drv_OwnState as Ownerstate,a.Drv_OwnPinCode as OwnerPincode,a.Drv_OwnPhone as OwnerPhone,a.Drv_Active as Active from Driver_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwDriver_Master.DataSource = dt;
            this.dgwDriver_Master.Columns[0].Visible = false;

        }

        private void dgwDriver_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlDrv_Active.Enabled = true;

            txtDrv_FName.Enabled = false;
            txtDrv_MName.Enabled = false;
            txtDrv_LName.Enabled = false;
            ddlGrp_ID.Enabled = false;

            //to display data in form on click of datagridview named dgwDriver_Master. 

            txtDrv_ID.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
          //  ddlGrp_ID.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDrv_FName.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDrv_MName.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDrv_LName.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDrv_Addr1.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDrv_Addr2.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[6].Value.ToString();
            ddlDrv_City.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[7].Value.ToString();
            ddlDrv_State.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtDrv_PinCode.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtDrv_Mobile.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtDrv_BirthPlace.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[11].Value.ToString();
            ddlDrv_BloodGrp.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtDrv_LicnNo.Text=dgwDriver_Master.Rows[e.RowIndex].Cells[13].Value.ToString();
            ddlDrv_LicnState.Text=dgwDriver_Master.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtDrv_Owner.Text=dgwDriver_Master.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtDrv_OwnAddr.Text=dgwDriver_Master.Rows[e.RowIndex].Cells[16].Value.ToString();
            ddlDrv_OwnCity.Text=dgwDriver_Master.Rows[e.RowIndex].Cells[17].Value.ToString();
            ddlDrv_OwnState.Text=dgwDriver_Master.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtDrv_OwnPinCode.Text=dgwDriver_Master.Rows[e.RowIndex].Cells[19].Value.ToString();
            txtDrv_OwnPhone.Text=dgwDriver_Master.Rows[e.RowIndex].Cells[20].Value.ToString();
            ddlDrv_Active.Text = dgwDriver_Master.Rows[e.RowIndex].Cells[21].Value.ToString();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
           
            strOName = funclib.FirstCap(txtDrv_Owner.Text);
            txtDrv_Addr1.Text = funclib.FirstCap(txtDrv_Addr1.Text);

            //Update data in table Driver_Master
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Driver_Master set Drv_Addr1  ='" + txtDrv_Addr1.Text + "',Drv_Addr2='" + txtDrv_Addr2.Text + "',Drv_City ='" + ddlDrv_City.SelectedValue.ToString() + "',Drv_State ='" + ddlDrv_State.SelectedValue.ToString() + "',Drv_PinCode='" + txtDrv_PinCode.Text + "',Drv_Mobile ='" + txtDrv_Mobile.Text + "',Drv_BirthPlace='" + txtDrv_BirthPlace.Text + "',Drv_BloodGrp='" + ddlDrv_BloodGrp.SelectedItem.ToString() + "',Drv_LicnNo='" + txtDrv_LicnNo.Text + "',Drv_LicnState='" + ddlDrv_LicnState.SelectedValue.ToString() + "',Drv_Owner='" + txtDrv_Owner.Text + "',Drv_OwnAddr='" + txtDrv_OwnAddr.Text + "',Drv_OwnCity='" + ddlDrv_OwnCity.SelectedValue.ToString() + "',Drv_OwnState='" + ddlDrv_OwnState.SelectedValue.ToString() + "',Drv_OwnPinCode='" + txtDrv_PinCode.Text + "',Drv_OwnPhone='" + txtDrv_OwnPhone.Text + "',Drv_Active='" + ddlDrv_Active.SelectedItem.ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Drv_ID='" + txtDrv_ID.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            clearAll();

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table Driver_Master
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from Driver_Master where Drv_FName like '%" + txtDrv_Name_Search.Text + "%' or Drv_MName like '%" + txtDrv_Name_Search.Text + "%'or Drv_LName like '%" + txtDrv_Name_Search.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwDriver_Master.DataSource = dt;


            if (dgwDriver_Master.Rows.Count == 0)
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
            //Clearing all fields & refreshes the MasterDriver form
            clearAll();

        }
        private void clearAll()
        {
            //Code for Clearing all form fields.


            ddlGrp_ID.Text = "";
            txtDrv_FName.Clear();
            txtDrv_MName.Clear();
            txtDrv_LName.Clear();
            txtDrv_Addr1.Clear();
            txtDrv_Addr2.Clear();
            ddlDrv_City.Text = "";
            ddlDrv_State.Text = "";
            txtDrv_PinCode.Clear();
            txtDrv_Mobile.Clear();
            txtDrv_BirthPlace.Clear();
            ddlDrv_BloodGrp.Text = "";
            txtDrv_LicnNo.Clear();
            ddlDrv_LicnState.Text = "";
            txtDrv_Owner.Clear();
            txtDrv_OwnAddr.Clear();
            txtDrv_OwnPhone.Clear();
            txtDrv_OwnPinCode.Clear();
            ddlDrv_OwnCity.Text = "";
            ddlDrv_OwnState.Text = "";

            ddlDrv_Active.SelectedText = "Yes";
            ddlDrv_Active.Enabled = false;

            cmdSubmit.Enabled = true;
            cmdEdit.Enabled = false;

            txtDrv_FName.Enabled = true;
            txtDrv_MName.Enabled = true;
            txtDrv_LName.Enabled = true;
            ddlGrp_ID.Enabled = true;

            txtDrv_Addr1.Focus();
            
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Code to close MasterDriver form temporarily.
            this.Close();
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterDriver.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select * from Driver_Master where Drv_FName like '%" + txtDrv_Name_Search.Text + "%' or Drv_MName like '%" + txtDrv_Name_Search.Text + "%'or Drv_LName like '%" + txtDrv_Name_Search.Text + "%'";
                //string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "eBabyReport.xls");
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