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
    public partial class RPeP_MasterMill : Form
    {
        //Page Developed by Ashwin Prabhu on(8/3/2011)
        string session, strSQL,Group_ID;  
        private FunctionLib funclib;
        string strMill, strMgr1, strMgr2, strDesg1, strDesg2;
        public RPeP_MasterMill()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            //filldata();
            cmdEdit.Enabled=false;
        }

        

        private void RPeP_MasterMill_Load(object sender, EventArgs e)
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
            ddlM_City.Items.Insert(0, "".ToString());
            ddlM_City.DataSource = dt2;
            ddlM_City.DisplayMember = dt2.Columns[0].ToString();
            ddlM_City.ValueMember = dt2.Columns[0].ToString();
            
            
            con1.Close();

            //Displayig State Name in Combo field
            con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select '' as State_Name UNION select State_Name from State_Master", con1);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            ddlM_State.DataSource = dt3;
            ddlM_State.DisplayMember = dt3.Columns[0].ToString();
            ddlM_State.ValueMember = dt3.Columns[0].ToString();
            
            con1.Close();

            //Displaying weekoff day
            con1.Open();
            SqlDataAdapter da4 = new SqlDataAdapter("Select '' as B_Day UNION select B_Day from B_Cal", con1);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            ddlM_WeekOff.DataSource = dt4;
            ddlM_WeekOff.DisplayMember = dt4.Columns[0].ToString();
            ddlM_WeekOff.ValueMember = dt4.Columns[0].ToString();
            
            con1.Close();


            //Displaying Active Values
            ddlM_Active.SelectedText = "Yes";
            ddlM_Active.Enabled = false;
            ddlM_Active.Items.Add("Yes");
            ddlM_Active.Items.Add("No");

        }

        private void txtM_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Name Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);

        }

        private void txtM_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Addr1 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtM_Addr1.Text);
            lblAddress1Count.Text = "(Character " + P_AddressData + "  " + "Out of" + txtM_Addr1.MaxLength + ")";
            
        }

        private void txtM_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Addr2 Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            int P_AddressData = funclib.countChar(e, txtM_Addr2.Text);
            lblAddress2Count.Text = "(Character " + P_AddressData + "  " + "Out of" + txtM_Addr2.MaxLength + ")";
            

        }

        private void txtM_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_PinCode Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtM_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Tel Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtM_FAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_FAX Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }
        private void txtM_Mgr1Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Validating M_Mgr1Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtM_Mgr2Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mgr2Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtM_Mgr1Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mgr1Name Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);


        }

        private void txtM_Mgr2Name_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Validating M_Mgr2Name Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtM_Mgr1Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mgr1Desig Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtM_Mgr2Desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mgr2Desig Text Field
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);

        }

        private void txtM_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating M_Mobile Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            //Clear all fields
            txtM_ID.Clear();
            ddlGrp_ID.Text = "";
            //ddlP_Name.Text = "";
            txtM_Name.Clear();
            txtM_Addr1.Clear();
            txtM_Addr2.Clear();
            //txtP_BST.Clear();
            //txtP_CST.Clear();
            ddlM_City.Text = "";
            ddlM_State.Text = "";
            txtM_PinCode.Clear();
            txtM_Tel.Clear();
            txtM_Email.Clear();
            txtM_FAX.Clear();
            txtM_Mgr1Desig.Clear();
            txtM_Mobile.Clear();
            ddlM_WeekOff.Text = "";
            txtM_Mgr1Email.Clear();
            txtM_Mgr1Mobile.Clear();
            txtM_Mgr1Name.Clear();
            txtM_Mgr2Desig.Clear();
            txtM_Mgr2Email.Clear();
            txtM_Mgr2Name.Clear();
            txtM_Mgr2Mobile.Clear();
            //ddlP_TopPaper.Text = "";
            ddlM_Active.Text = "";
            //txtP_CrDays.Clear();
            ddlGrp_ID.Enabled = true;
            txtM_Name.Enabled = true;

            cmdSubmit.Enabled = true;
            cmdEdit.Enabled = false;
            ddlM_Active.SelectedText = "Yes";
            ddlM_Active.Enabled = false;


        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}


            
            if (txtM_Name.Text == "")//checking for blank P_Name text field 
            {
                MessageBox.Show("Please enter Name");
                txtM_Name.Focus();
            }
            else if (txtM_Addr1.Text == "")//checking for blank Addr1 text field 
            {
                MessageBox.Show("Please Enter Address1");
                txtM_Addr1.Focus();
            }

            else if (ddlM_City.Text == "")//Checking for blnk City field
            {
                MessageBox.Show("Please Select City");
                ddlM_City.Focus();
            }
            else if (ddlM_State.Text == "")//Checking for blnk State field
            {
                MessageBox.Show("Please Select State");
                ddlM_State.Focus();
            }
            else if (txtM_PinCode.Text == "")//Checking for blnk PinCode field
            {
                MessageBox.Show("Enter Pincode number");
                txtM_PinCode.Focus();
            }
            else if (txtM_Tel.Text == "")//Checking for blnk TelNo field
            {
                MessageBox.Show("Enter Telephone no");
                txtM_Tel.Focus();
            }
            else if (ddlM_WeekOff.Text == "")//Checking for blnk weeklyoff field
            {
                MessageBox.Show("Select Weeklyoff");
                ddlM_WeekOff.Focus();
            }
            

            else
            {
                funclib = new FunctionLib();
                strMill = funclib.FirstCap(txtM_Name.Text);
                txtM_Addr1.Text = funclib.FirstCap(txtM_Addr1.Text);
                strMgr1 = funclib.FirstCap(txtM_Mgr1Name.Text);
                strMgr2 = funclib.FirstCap(txtM_Mgr2Name.Text);
                strDesg1 = funclib.FirstCap(txtM_Mgr1Desig.Text);
                strDesg2 = funclib.FirstCap(txtM_Mgr2Desig.Text);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Checking for duplicate values
                    double flag = funclib.isThere(con, "select M_Name,Grp_ID from Mill_Master where M_Name='" + txtM_Name.Text + "'and Grp_ID='" + Group_ID + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Mill Name and Group is not allowed");
                    }
                    

                    else
                    {
                        //Inserting Details into table
                        string mid = funclib.AutoKey("M", con, "select M_ID from Mill_Master order by M_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Mill_Master values('" + mid + "','" + Group_ID + "','" + strMill.Trim().Replace("'", "''").ToString() + "','" + txtM_Addr1.Text.Trim().Replace("'", "''").ToString() + "','" + txtM_Addr2.Text.Trim().Replace("'", "''").ToString() + "','" + ddlM_City.SelectedValue.ToString() + "','" + ddlM_State.SelectedValue.ToString() + "','" + txtM_PinCode.Text.Trim().Replace("'", "''").ToString() + "','" + txtM_Tel.Text.Trim().Replace("'", "''").ToString() + "','" + txtM_FAX.Text.Trim().Replace("'", "''").ToString() + "','" + txtM_Email.Text.Trim().Replace("'", "''").ToString() + "', '" + txtM_Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + ddlM_WeekOff.SelectedValue.ToString() + "','" + strMgr1.Trim().Replace("'", "''").ToString() + "','" + strDesg1.Trim().Replace("'", "''").ToString() + "','" + txtM_Mgr1Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtM_Mgr1Email.Text.Trim().Replace("'", "''").ToString() + "','" + strMgr2.Trim().Replace("'", "''").ToString() + "','" + strDesg2.Trim().Replace("'", "''").ToString() + "','" + txtM_Mgr2Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtM_Mgr2Email.Text.Trim().Replace("'", "''").ToString() + "','" + ddlM_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            txtM_Addr1.Text = funclib.FirstCap(txtM_Addr1.Text);
            //Update data in table
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Mill_Master set M_Addr1='" + txtM_Addr1.Text + "',M_Addr2 ='" + txtM_Addr2.Text + "',M_City ='" + ddlM_City.SelectedValue.ToString() + "',M_State ='" + ddlM_State.SelectedValue.ToString() + "',M_PinCode='" + txtM_PinCode.Text + "',M_Tel='" + txtM_Tel.Text + "',M_FAX='" + txtM_FAX.Text + "',M_Email ='" + txtM_Email.Text + "',M_Mobile ='" + txtM_Mobile.Text + "',M_WeekOff='" + ddlM_WeekOff.SelectedValue.ToString() + "',M_Mgr1Name='" + txtM_Mgr1Name.Text + "',M_Mgr1Desig='" + txtM_Mgr1Desig.Text + "',M_Mgr1Mobile='" + txtM_Mgr1Mobile.Text + "',M_Mgr1Email='" + txtM_Mgr1Email.Text + "',M_Mgr2Name='" + txtM_Mgr2Name.Text + "',M_Mgr2Desig='" + txtM_Mgr2Desig.Text + "',M_Mgr2Mobile='" + txtM_Mgr2Mobile.Text + "',M_Mgr2Email='" + txtM_Mgr2Email.Text + "',M_Active='" + ddlM_Active.SelectedItem.ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where M_ID='" + txtM_ID.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            clearAll();

        }

        private void filldata()
        {
            //to fill the grid with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select M_ID as MillID,M_Name as Mill,Grp_Name as GroupName,M_Addr1 as Addr1,M_Addr2 as Addr2,M_City as City,M_State as State,M_PinCode as Pincode,M_Tel as Telephone,M_FAX as Fax,M_Email as Email,M_Mobile as Mobile,M_WeekOff as WeekOff,M_Mgr1Name as Mgr1,M_Mgr1Desig as Desg1,M_Mgr1Mobile as Mobile1,M_Mgr1Email as Email1,M_Mgr2Name as Mgr2,M_Mgr2Desig as Desg2,M_Mgr2Mobile as Mobile2,M_Mgr2Email as Email2,M_Active as Active from Mill_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwMill_Master.DataSource = dt;
            this.dgwMill_Master.Columns[0].Visible = false;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from Mill_Master where M_Name like '%" + txtM_Name_Search.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwMill_Master.DataSource = dt;


            if (dgwMill_Master.Rows.Count == 0)
            {

                cmdExcelReport.Visible = false;
            }

            else
            {
                cmdExcelReport.Visible = true;
            }
        }

        private void dgwMill_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //to display data in form on click of datagridview
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlM_Active.Enabled = true;
            txtM_Name.Enabled = false;
            ddlGrp_ID.Enabled = false;
            txtM_ID.Text = dgwMill_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtM_Name.Text = dgwMill_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
           // ddlGrp_ID.Text = dgwMill_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtM_Addr1.Text = dgwMill_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtM_Addr2.Text = dgwMill_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlM_City.Text = dgwMill_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlM_State.Text = dgwMill_Master.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtM_PinCode.Text = dgwMill_Master.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtM_Tel.Text = dgwMill_Master.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtM_FAX.Text = dgwMill_Master.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtM_Email.Text = dgwMill_Master.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtM_Mobile.Text = dgwMill_Master.Rows[e.RowIndex].Cells[11].Value.ToString();
            ddlM_WeekOff.Text = dgwMill_Master.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtM_Mgr1Name.Text = dgwMill_Master.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtM_Mgr1Desig.Text = dgwMill_Master.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtM_Mgr1Mobile.Text = dgwMill_Master.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtM_Mgr1Email.Text = dgwMill_Master.Rows[e.RowIndex].Cells[16].Value.ToString();
            txtM_Mgr2Name.Text = dgwMill_Master.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtM_Mgr2Desig.Text = dgwMill_Master.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtM_Mgr2Mobile.Text = dgwMill_Master.Rows[e.RowIndex].Cells[19].Value.ToString();
            txtM_Mgr2Email.Text = dgwMill_Master.Rows[e.RowIndex].Cells[20].Value.ToString();
            ddlM_Active.Text = dgwMill_Master.Rows[e.RowIndex].Cells[21].Value.ToString();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterMill.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select * from Mill_Master where M_Name like '%" + txtM_Name_Search.Text + "%'";
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