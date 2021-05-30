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
    //Page Developed by 
    public partial class RPeP_MasterContractor : Form
    {
        private FunctionLib funclib;
        string strCName, session, strMgr1, strMgr2, strDesg1, strDesg2, strSQL, Group_ID;
        public RPeP_MasterContractor()
        {
            
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            txtC_ID.Visible = false;
           // filldata();
            cmdEdit.Enabled=false;
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}


            if (txtC_Name.Text == "")//checking for blank Name text field 
            {
                MessageBox.Show("Please Enter Name");
                txtC_Name.Focus();
            }

            //else if (txtC_Addr1.Text == "")//checking for blank Addr1 text field 
            //{
            //    MessageBox.Show("Please Enter Address1");
            //    txtC_Addr1.Focus();
            //}

            else if (ddlC_City.Text == "")//Checking for blank City field
            {
                MessageBox.Show("Please Select City");
                ddlC_City.Focus();
            }
            else if (ddlC_State.Text == "")//Checking for blank State field
            {
                MessageBox.Show("Please Select State");
                ddlC_State.Focus();
            }
            //else if (txtC_PinCode.Text == "")//Checking for blank PinCode field
            //{
            //    MessageBox.Show("Enter Pincode number");
            //    txtC_PinCode.Focus();
            //}
            //else if (txtC_Tel.Text == "")//Checking for blank TelNo field
            //{
            //    MessageBox.Show("Enter Telephone no");
            //    txtC_Tel.Focus();
            //}
            else if (ddlC_WeekOff.Text == "")//Checking for blank weeklyoff field
            {
                MessageBox.Show("Select Weeklyoff");
                ddlC_WeekOff.Focus();
            }
            else if (ddlC_Active.Text == "")//Checking for blank Active field
            {
                MessageBox.Show("Select Active field");
                ddlC_Active.Focus();
            }
            else if (ddlC_Category.Text == "")//Checking for blank Category field
            {
                MessageBox.Show("Select Category");
                ddlC_Category.Focus();
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
                    double flag = funclib.isThere(con, "select C_Name ,Grp_ID from Contractor_Master where C_Name='" + txtC_Name.Text + "' and Grp_ID='" + Group_ID + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Contractor Name and Group is not allowed");

                    }
                    else
                    {
                        //Inserting records in table Contractor_Master
                        strCName = funclib.FirstCap(txtC_Name.Text);
                        strMgr1 = funclib.FirstCap(txtC_Mgr1Name.Text);
                        strMgr2 = funclib.FirstCap(txtC_Mgr2Name.Text);
                        strDesg1 = funclib.FirstCap(txtC_Mgr1Desig.Text);
                        strDesg2 = funclib.FirstCap(txtC_Mgr2Desig.Text);
                        txtC_Addr1.Text = funclib.FirstCap(txtC_Addr1.Text);

                        string mid = funclib.AutoKey("M", con, "select C_ID from Contractor_Master order by C_ID desc");
                        SqlCommand cmdContractor = new SqlCommand("insert into Contractor_Master values('" + mid + "','" + Group_ID + "','" + strCName.Trim().Replace("'", "''").ToString() + "','" + txtC_Addr1.Text.Trim().Replace("'", "''").ToString() + "','" + txtC_Addr2.Text.Trim().Replace("'", "''").ToString() + "','" + ddlC_City.SelectedValue.ToString() + "','" + ddlC_State.SelectedValue.ToString() + "','" + txtC_PinCode.Text.Trim().Replace("'", "''").ToString() + "','" + txtC_Tel.Text.Trim().Replace("'", "''").ToString() + "','" + txtC_FAX.Text.Trim().Replace("'", "''").ToString() + "','" + txtC_Email.Text.Trim().Replace("'", "''").ToString() + "', '" + txtC_Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + ddlC_WeekOff.SelectedValue.ToString() + "','" + strMgr1.Trim().Replace("'", "''").ToString() + "','" + strDesg1.Trim().Replace("'", "''").ToString() + "','" + txtC_Mgr1Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtC_Mgr1Email.Text.Trim().Replace("'", "''").ToString() + "','" + strMgr2.Trim().Replace("'", "''").ToString() + "','" + strDesg2.Trim().Replace("'", "''").ToString() + "','" + txtC_Mgr2Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtC_Mgr2Email.Text.Trim().Replace("'", "''").ToString() + "','" + ddlC_Category.SelectedValue.ToString() + "','" + ddlC_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        con.Open();
                        int i = cmdContractor.ExecuteNonQuery();
                        MessageBox.Show("Contractor data has been inserted");
                        con.Close();
                        filldata();
                        clearAll();
                    }
                }
            }

        }

        private void RPeP_MasterContractor_Load(object sender, EventArgs e)
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



            //Displaying weeklyoff day

            con1.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("Select '' as B_Day UNION select B_Day from B_Cal", con1);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            ddlC_WeekOff.DataSource = dt4;
            ddlC_WeekOff.DisplayMember = dt4.Columns[0].ToString();
            ddlC_WeekOff.ValueMember = dt4.Columns[0].ToString();
            con1.Close();


            //Displaying Value in Category from Machine Type
            con1.Open();
            SqlDataAdapter daCat = new SqlDataAdapter("select '' as M_Type UNION select M_Type from MachType_Master where MT_Active='Yes'", con1);
            DataTable dtCat = new DataTable();
            daCat.Fill(dtCat);
            ddlC_Category.DataSource = dtCat;
            ddlC_Category.DisplayMember = dtCat.Columns[0].ToString();
            ddlC_Category.ValueMember = dtCat.Columns[0].ToString();
            con1.Close();
            

            //Displaying Active value in Combo field

            ddlC_Active.SelectedText = "Yes";
            ddlC_Active.Enabled = false;
            ddlC_Active.Items.Add("Yes");
            ddlC_Active.Items.Add("No");
            




            //Displayig City Name in Combo field
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select '' as City_Name UNION select City_Name from City_Master", con1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            ddlC_City.DataSource = dt2;
            ddlC_City.DisplayMember = dt2.Columns[0].ToString();
            ddlC_City.ValueMember = dt2.Columns[0].ToString();
            con1.Close();

            //Displayig State Name in Combo field
            con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select '' as State_Name UNION select State_Name from State_Master", con1);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            ddlC_State.DataSource = dt3;
            ddlC_State.DisplayMember = dt3.Columns[0].ToString();
            ddlC_State.ValueMember = dt3.Columns[0].ToString();
            con1.Close();


        }
        private void txtC_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Name Text Field

            funclib = new FunctionLib();
            //funclib.checkNumericChar(e);
            funclib.onlyCharacterPress(e);


        }

        private void txtC_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Addr1 Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtC_Addr1.Text);
            lblAddress1.Text = "(Character " + P_AddressData + "  " + "Out of" + txtC_Addr1.MaxLength + ")";
        }

        private void txtC_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Addr2 Text Field

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtC_Addr2.Text);
            lbladdress2.Text = "(Character " + P_AddressData + "  " + "Out of" + txtC_Addr2.MaxLength + ")";

        }

        private void txtC_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_PinCode Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtC_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Tel Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtC_FAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_FAX Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtC_Mgr1Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr1Mobile Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtC_Mgr2Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr2Mobile Text Field

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtC_Mgr1Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr1Name Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);


        }

        private void txtC_Mgr2Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr2Name Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtC_Mgr1Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr1Desig Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtC_Mgr2Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mgr2Desig Text Field

            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtC_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating C_Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }
        private void filldata()
        {
            //to fill the Datagridview with user details named dgwMasterContractor 

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.C_ID as Contractor,a.C_Name as ContarctorName,b.Grp_Name as GroupName,a.C_Addr1 as Addr1,a.C_Addr2 as Addr2,a.C_City as City,a.C_State as State,a.C_PinCode as Pincode,a.C_Tel as Tel,a.C_FAX as Fax,a.C_Email as Email,a.C_Mobile as Mobile,a.C_WeekOff as Weekoff,a.C_Mgr1Name as Mgr1,a.C_Mgr1Desig as Mgr1Desg,a.C_Mgr1Mobile as Mgr1Mobile,a.C_Mgr1Email as Email1,a.C_Mgr2Name as Mgr2,a.C_Mgr2Desig as Mgr2Desg,a.C_Mgr2Mobile as Mobile2,a.C_Mgr2Email as Email2,a.C_Category as Category,a.C_Active as Active from Contractor_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwMasterContractor.DataSource = dt;
            this.dgwMasterContractor.Columns[0].Visible = false;
        }

        private void dgwMasterContractor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlC_Active.Enabled = true;

            //to display data in form on click of datagridview named dgwMasterContractor

            txtC_ID.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtC_Name.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[2].Value.ToString();
          //  ddlGrp_ID.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtC_Addr1.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtC_Addr2.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlC_City.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlC_State.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtC_PinCode.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtC_Tel.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtC_FAX.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtC_Email.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtC_Mobile.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[11].Value.ToString();
            ddlC_WeekOff.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtC_Mgr1Name.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtC_Mgr1Desig.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtC_Mgr1Mobile.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtC_Mgr1Email.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[16].Value.ToString();
            txtC_Mgr2Name.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtC_Mgr2Desig.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtC_Mgr2Mobile.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[19].Value.ToString();
            txtC_Mgr2Email.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[20].Value.ToString();
            ddlC_Category.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[21].Value.ToString();
            ddlC_Active.Text = dgwMasterContractor.Rows[e.RowIndex].Cells[22].Value.ToString();

            txtC_Name.Enabled = false;
            ddlGrp_ID.Enabled = false;


        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

            txtC_Addr1.Text = funclib.FirstCap(txtC_Addr1.Text);


            txtC_Mgr1Name.Text = funclib.FirstCap(txtC_Mgr1Name.Text);
            txtC_Mgr2Name.Text = funclib.FirstCap(txtC_Mgr2Name.Text);
                           
            //Update Records in table Contractor_Master
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            if(MessageBox.Show("Do you wish to Edit this record","UpdateConfirm",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("update Contractor_Master set C_Addr1='" + txtC_Addr1.Text + "',C_Addr2 ='" + txtC_Addr2.Text + "',C_City ='" + ddlC_City.SelectedValue.ToString() + "',C_State ='" + ddlC_State.SelectedValue.ToString() + "',C_PinCode='" + txtC_PinCode.Text + "',C_Tel='" + txtC_Tel.Text + "',C_FAX='" + txtC_FAX.Text + "',C_Email ='" + txtC_Email.Text + "',C_Mobile ='" + txtC_Mobile.Text + "',C_WeekOff='" + ddlC_WeekOff.SelectedValue.ToString() + "',C_Mgr1Name='" + txtC_Mgr1Name.Text + "',C_Mgr1Desig='" + txtC_Mgr1Desig.Text + "',C_Mgr1Mobile='" + txtC_Mgr1Mobile.Text + "',C_Mgr1Email='" + txtC_Mgr1Email.Text + "',C_Mgr2Name='" + txtC_Mgr2Name.Text + "',C_Mgr2Desig='" + txtC_Mgr2Desig.Text + "',C_Mgr2Mobile='" + txtC_Mgr2Mobile.Text + "',C_Mgr2Email='" + txtC_Mgr2Email.Text + "',C_Category='" + ddlC_Category.SelectedValue.ToString() + "',C_Active='" + ddlC_Active.SelectedItem.ToString() + "',Mod_By='"+session+"',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where C_ID='" + txtC_ID.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            clearAll();

            }
            else
            {

                con.Close();
            }

        }
        private void clearAll()
        {
            //Clear all fields

            ddlGrp_ID.Text = "";
            txtC_Name.Clear();
            txtC_Addr1.Clear();
            txtC_Addr2.Clear();
           
            ddlC_City.Text = "";
            ddlC_State.Text = "";
            txtC_Email.Clear();
            txtC_FAX.Clear();
            txtC_Mgr1Desig.Clear();
            txtC_Mobile.Clear();
            ddlC_WeekOff.Text = "";
            txtC_Mgr1Email.Clear();
            txtC_Mgr1Mobile.Clear();
            txtC_Mgr1Name.Clear();
            txtC_Mgr2Desig.Clear();
            txtC_Mgr2Email.Clear();
            txtC_Mgr2Name.Clear();
            txtC_Mgr2Mobile.Clear();
            ddlC_Active.Text = "";
            txtC_PinCode.Clear();
            txtC_Tel.Clear();

            ddlC_Active.SelectedText = "Yes";
            ddlC_Active.Enabled = false;

            cmdSubmit.Enabled = true;
            cmdEdit.Enabled = false;

            ddlGrp_ID.Enabled = true;
            txtC_Name.Enabled = true;
            txtC_Name.Focus();


        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterContractor form
            clearAll();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search C_Name data from table Contractor_Master
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from Contractor_Master where C_Name like '%" + txtC_Name_Search.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
           dgwMasterContractor.DataSource = dt;


           if (dgwMasterContractor.Rows.Count == 0)
           {

               cmdExcelReport.Visible = false;
           }

           else
           {
               cmdExcelReport.Visible = true;
           }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Code to close MasterContractor form temporarily.
            this.Close();



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterContractor.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select * from Contractor_Master where C_Name like '%" + txtC_Name_Search.Text + "%'";
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
