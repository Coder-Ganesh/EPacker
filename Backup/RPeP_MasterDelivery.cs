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
    public partial class RPeP_MasterDelivery : Form
    {
        //Page Developed by Shirish Phadnis on(14/03/2011).
        string session, strSQL, Group_ID; 
        private FunctionLib funcLib;
        public RPeP_MasterDelivery()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdEdit.Enabled = false;
            txtDelv_ID.Visible = false;

        }

        private void RPeP_MasterDelivery_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
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
            ddlDelv_City.DataSource = dt2;
            ddlDelv_City.DisplayMember = dt2.Columns[0].ToString();
            ddlDelv_City.ValueMember = dt2.Columns[0].ToString();
            con1.Close();

            //Displayig State Name in Combo field
            con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select '' as State_Name UNION select State_Name from State_Master", con1);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            ddlDelv_State.DataSource = dt3;
            ddlDelv_State.DisplayMember = dt3.Columns[0].ToString();
            ddlDelv_State.ValueMember = dt3.Columns[0].ToString();
            con1.Close();


            //Displaying Active value in Combo field

            ddlDelv_Active.SelectedText = "Yes";
            ddlDelv_Active.Enabled = false;
            ddlDelv_Active.Items.Add("Yes");
            ddlDelv_Active.Items.Add("No");

            //Display value in PM_Search combo field
            con1.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT '' as PM_Name UNION select a.PM_Name from PartyMain_Master a,DelvPlace_Master b where  a.PM_ID=b.PM_ID", con1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            ddlPM_ID_Search.DataSource = dt1;
            ddlPM_ID_Search.DisplayMember = dt1.Columns[0].ToString();
            con1.Close();


            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as PM_ID, '' as PM_Name UNION select PM_ID,PM_Name from PartyMain_Master  where Grp_ID='" + Group_ID + "' and PM_Active='yes'", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlPM_ID.DataSource = dt;
            ddlPM_ID.DisplayMember = dt.Columns[1].ToString();
            ddlPM_ID.ValueMember = dt.Columns[0].ToString();
            con1.Close();



            //Displayig Region Name(Rg_Name)in Region Combo field
            funcLib = new FunctionLib();
            string strcon1 = funcLib.setConnection();
            SqlConnection con2 = new SqlConnection(strcon);
            con2.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("SELECT '' as Rg_ID, '' as Rg_Name UNION select Rg_ID,Rg_Name from Region_Master where Grp_ID='" + Group_ID + "' and Rg_Active='yes'", con2);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            ddlRG_ID.DataSource = dt5;
            ddlRG_ID.DisplayMember = dt5.Columns[1].ToString();
            ddlRG_ID.ValueMember = dt5.Columns[0].ToString();
            con2.Close();
            
        }

        private void ddlGrp_ID_SelectedValueChanged(object sender, EventArgs e)
        {
            
            //////Displayig Party Name in Combo field
            ////funcLib = new FunctionLib();
            ////SqlConnection con1 = funcLib.setConnection();
            ////con1.Open();
            ////SqlDataAdapter da = new SqlDataAdapter("select PM_ID,PM_Name from PartyMain_Master  where Grp_ID='"+ddlGrp_ID.SelectedValue.ToString()+"' and PM_Active='yes'", con1);
            ////DataTable dt = new DataTable();
            ////da.Fill(dt);
            ////ddlPM_ID.DataSource = dt;
            ////ddlPM_ID.DisplayMember = dt.Columns[1].ToString();
            ////ddlPM_ID.ValueMember = dt.Columns[0].ToString();
            ////con1.Close();



            //////Displayig Region Name in Combo field
            ////funcLib = new FunctionLib();
            ////SqlConnection con2 = funcLib.setConnection();
            ////con1.Open();
            ////SqlDataAdapter da2 = new SqlDataAdapter("select Rg_ID,Rg_Name from Region_Master where Grp_ID='" + ddlGrp_ID.SelectedValue.ToString() + "' and Rg_Active='yes'", con2);
            ////DataTable dt2 = new DataTable();
            ////da2.Fill(dt2);
            ////ddlRG_ID.DataSource = dt2;
            ////ddlRG_ID.DisplayMember = dt2.Columns[1].ToString();
            ////ddlRG_ID.ValueMember = dt2.Columns[0].ToString();
            ////con2.Close();




        }

        

        private void ddlPM_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //To Display Party Id combo field

            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
           // SqlConnection con = new SqlConnection(strcon);
            SqlConnection con1 = new SqlConnection(strcon);
            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as P_ID, '' as P_Name UNION select P_ID,P_Name from Party_Master where Grp_ID='" + Group_ID + "'and PM_ID='" + ddlPM_ID.SelectedValue.ToString() + "' and P_Active='yes'", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlP_ID.DataSource = dt;
            ddlP_ID.DisplayMember = dt.Columns[1].ToString();
            ddlP_ID.ValueMember = dt.Columns[0].ToString();
            con1.Close();

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
                

            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}


            if (ddlPM_ID.Text == "")//checking for blank Party(Main)combo field 
            {
                MessageBox.Show("Please select Party(Main)");
                ddlPM_ID.Focus();
            }

            else if (ddlP_ID.Text == "")//checking for blank Party combo field 
            {
                MessageBox.Show("Please Select Party");
                ddlP_ID.Focus();
            }

            else if (ddlRG_ID.Text == "")//Checking for blank Region combo field
            {
                MessageBox.Show("Please Select Region");
                ddlRG_ID.Focus();
            }
            //else if (txtDelv_Addr1.Text == "")//checking for blank Addr1 text field 
            //{
            //    MessageBox.Show("Please Select State");
            //    txtDelv_Addr1.Focus();
            //}
            //else if (txtDelv_PinCode.Text == "")//Checking for blank PinCode text field
            //{
            //    MessageBox.Show("Enter Pincode number");
            //    txtDelv_PinCode.Focus();
            //}
            else if (ddlDelv_City.Text == "")//Checking for blank City combo field
            {
                MessageBox.Show("Please Select City");
                ddlDelv_City.Focus();
            }
            else if (ddlDelv_State.Text == "")//Checking for blank State combo field
            {
                MessageBox.Show("Please Select State");
                ddlDelv_State.Focus();
            }
            //else if (txtDelv_Tel.Text == "")//Checking for blank TelNo text field
            // {
            //        MessageBox.Show("Please Enter TelPhone no");
            //        txtDelv_Tel.Focus();
            // }

            else if (ddlDelv_Active.Text == "")//Checking for blank Active combo field
            {
                MessageBox.Show("Select Active field");
                ddlDelv_Active.Focus();
            }
            else
            {
                funcLib = new FunctionLib();
                string strcon = funcLib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //Checking for duplicate values
                    double flag = funcLib.isThere(con, "select PM_ID,Grp_ID,P_ID,Rg_ID from DelvPlace_Master where PM_ID='" + ddlPM_ID.SelectedValue.ToString() + "' and Grp_ID='" + Group_ID + "' and P_ID='" + ddlP_ID.SelectedValue.ToString() + "' and Rg_ID='" + ddlRG_ID.SelectedValue.ToString() + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Party (Main), Party, Group and Region is not allowed");

                    }
                    

                    else
                    {
                        //Inserting records in Table DelvPlace_Master


                        txtDelv_Addr1.Text = funcLib.FirstCap(txtDelv_Addr1.Text);
                           

                        string delvid = funcLib.AutoKey1("DL", con, "select Delv_ID from DelvPlace_Master order by Delv_ID desc");
                        SqlCommand cmdDelivery = new SqlCommand("insert into DelvPlace_Master values('" + delvid + "','" + Group_ID + "','" + ddlPM_ID.SelectedValue.ToString() + "','" + ddlP_ID.SelectedValue.ToString() + "','" + ddlRG_ID.SelectedValue.ToString() + "','" + txtDelv_Addr1.Text.Trim().Replace("'", "''").ToString() + "','" + txtDelv_Addr2.Text.Trim().Replace("'", "''").ToString() + "','" + ddlDelv_City.SelectedValue.ToString() + "','" + ddlDelv_State.SelectedValue.ToString() + "','" + txtDelv_PinCode.Text.Trim().Replace("'", "''").ToString() + "','" + txtDelv_Tel.Text.Trim().Replace("'", "''").ToString() + "','" + txtDelv_FAX.Text.Trim().Replace("'", "''").ToString() + "','" + txtDelv_Email.Text.Trim().Replace("'", "''").ToString() + "', '" + ddlDelv_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        con.Open();
                        int i = cmdDelivery.ExecuteNonQuery();
                        MessageBox.Show("Delivery data has been inserted");
                        con.Close();
                        filldata();
                        clearAll();
                    }
                }
            }
        }


        private void filldata()
        {
            //to fill the Datagridview with user details named dgwDeliveryMaster.

            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            con4.Open();
            SqlDataAdapter da = new SqlDataAdapter("select a.Delv_ID as Delivery,b.Grp_Name as GroupName,c.PM_Name as PartyMain,d.P_Name as Party,e.Rg_Name as Region,a.Delv_Addr1 as Addr1,a.Delv_Addr2 as Addr2,a.Delv_City as City,a.Delv_State as State,a.Delv_PinCode as Pincode,a.Delv_Tel as Tel,a.Delv_FAX as Fax,a.Delv_Email as Email,a.Delv_Active from DelvPlace_Master a,Group_Master b,PartyMain_Master c,Party_Master d,Region_Master e where a.Grp_ID=b.Grp_ID and c.PM_ID=a.PM_ID and d.P_ID=a.P_ID and e.Rg_ID=a.Rg_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwDeliveryMaster.DataSource = dt;
            this.dgwDeliveryMaster.Columns[0].Visible = false;
        }

        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Displayig Party Name(PM_Name) in PartyMain Combo field
            //funcLib = new FunctionLib();
            //string strcon = funcLib.setConnection();
            //SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();
            //SqlDataAdapter da = new SqlDataAdapter("select PM_ID,PM_Name from PartyMain_Master  where Grp_ID='" + Group_ID + "' and PM_Active='yes'", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlPM_ID.DataSource = dt;
            //ddlPM_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlPM_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();



            ////Displayig Region Name(Rg_Name)in Region Combo field
            //funcLib = new FunctionLib();
            //string strcon1 = funcLib.setConnection();
            //SqlConnection con2 = new SqlConnection(strcon);
            //con2.Open();
            //SqlDataAdapter da2 = new SqlDataAdapter("select Rg_ID,Rg_Name from Region_Master where Grp_ID='" + Group_ID + "' and Rg_Active='yes'", con2);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            //ddlRG_ID.DataSource = dt2;
            //ddlRG_ID.DisplayMember = dt2.Columns[1].ToString();
            //ddlRG_ID.ValueMember = dt2.Columns[0].ToString();
            //con2.Close();


        }

        private void dgwDeliveryMaster_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlDelv_Active.Enabled = true;

            //to display data in form on click of datagridview named dgwDeliveryMaster.

            txtDelv_ID.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[0].Value.ToString();
         //   ddlGrp_ID.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlPM_ID.Text =dgwDeliveryMaster.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlP_ID.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlRG_ID.Text= dgwDeliveryMaster.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDelv_Addr1.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDelv_Addr2.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[6].Value.ToString();
            ddlDelv_City.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[7].Value.ToString();
            ddlDelv_State.Text= dgwDeliveryMaster.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtDelv_PinCode.Text=dgwDeliveryMaster.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtDelv_Tel.Text=dgwDeliveryMaster.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtDelv_FAX.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtDelv_Email.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[12].Value.ToString();
            ddlDelv_Active.Text = dgwDeliveryMaster.Rows[e.RowIndex].Cells[13].Value.ToString();
            ddlP_ID.Enabled=false;
            ddlGrp_ID.Enabled = false;
            ddlPM_ID.Enabled=false;
            ddlRG_ID.Enabled=false;




        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            txtDelv_Addr1.Text = funcLib.FirstCap(txtDelv_Addr1.Text);
            //Update Records in table DelvPlace_Master  
            string strcon = funcLib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            if (MessageBox.Show("Do you wish to Edit this record", "UpdateConfirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("update DelvPlace_Master set Delv_Addr1='" + txtDelv_Addr1.Text + "',Delv_Addr2 ='" + txtDelv_Addr2.Text + "',Delv_City ='" + ddlDelv_City.SelectedValue.ToString() + "',Delv_State ='" + ddlDelv_State.SelectedValue.ToString() + "',Delv_PinCode='" + txtDelv_PinCode.Text + "',Delv_Tel='" + txtDelv_Tel.Text + "',Delv_FAX='" + txtDelv_FAX.Text + "',Delv_Email ='" + txtDelv_Email.Text + "',Delv_Active='" + ddlDelv_Active.SelectedItem.ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Delv_ID='" + txtDelv_ID.Text + "'", con);
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

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterDelivery form
            clearAll();
            
        }
        private void clearAll()
        {
            //Code for Clearing all form fields.
            ddlGrp_ID.Text = "";
            ddlPM_ID.Text = "";
            ddlP_ID.Text = "";
            ddlRG_ID.Text = "";
            ddlDelv_State.Text = "";
            ddlDelv_City.Text = "";
            ddlDelv_Active.Text = "";
            txtDelv_Addr1.Text = "";
            txtDelv_Addr2.Text = "";
            txtDelv_Email.Text = "";
            txtDelv_FAX.Text = "";
            txtDelv_PinCode.Text = "";
            txtDelv_Tel.Text = "";
            ddlDelv_Active.SelectedText = "Yes";
            ddlDelv_Active.Enabled = false;
            cmdSubmit.Enabled = true;
            cmdEdit.Enabled = false;

        }

        private void txtDelv_Addr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDelv_Addr1 Text Field

            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);
            int P_AddressData = funcLib.countChar(e, txtDelv_Addr1.Text);
            lblAddrone.Text = "(Character " + P_AddressData + "  " + "Out of" + txtDelv_Addr1.MaxLength + ")";


        }

        private void txtDelv_Addr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDelv_Addr2 Text Field

            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);
            int P_AddressData = funcLib.countChar(e, txtDelv_Addr2.Text);
            lblAddrtwo.Text = "(Character " + P_AddressData + "  " + "Out of" + txtDelv_Addr2.MaxLength + ")";



        }

        private void txtDelv_PinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDelv_PinCode Text Field
            funcLib = new FunctionLib();
            funcLib.onlyNumbers(e);

        }

        private void txtDelv_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDelv_Tel Text Field
           funcLib = new FunctionLib();
           funcLib.onlyNumbers(e);


        }

        private void txtDelv_FAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtDelv_FAX Text Field
            funcLib = new FunctionLib();
            funcLib.onlyNumbers(e);

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search (P_Name) data from table DelvPlace_Master
            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from DelvPlace_Master a,Party_Master b where a.PM_ID='" + ddlPM_ID_Search.SelectedValue.ToString() + "' and b.P_Name like '%" + txtP_Name_Search.Text + "%' and a.P_ID=b.P_ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwDeliveryMaster.DataSource = dt;


            if (dgwDeliveryMaster.Rows.Count == 0)
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
            //Code to close MasterDelivery form temporarily.
            this.Close();

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterDelivery.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select * from DelvPlace_Master a,Party_Master b where a.PM_ID='" + ddlPM_ID_Search.SelectedValue.ToString() + "' and b.P_Name like '%" + txtP_Name_Search.Text + "%' and a.P_ID=b.P_ID";
                //string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "eBabyReport.xls");
                string data = null;
                ////to fill the grid with user details
                funcLib = new FunctionLib();
                string strcon = funcLib.setConnection();
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