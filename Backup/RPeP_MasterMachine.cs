using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ePacker1.App_Code;
using Excel = Microsoft.Office.Interop.Excel;

namespace ePacker1
{
    public partial class RPeP_MasterMachine : Form
    { 
        //Page Developed by Shirish Phadnis on(15/3/2011)
        private FunctionLib funclib;
        string strMName, session, strSQL, Group_ID;
        public RPeP_MasterMachine()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            //filldata();
            cmdEdit.Enabled = false;
            txtM_ID.Visible = false;
        }


        private void RPeP_MasterMachine_Load(object sender, EventArgs e)
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

            //Displaying Values in Type combo field
            con1.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select '' as M_Type UNION select M_Type from  MachType_Master where MT_Active='yes'", con1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            ddlM_Type.DataSource = dt2;
            ddlM_Type.DisplayMember = dt2.Columns[0].ToString();
            ddlM_Type.ValueMember = dt2.Columns[0].ToString();
            con1.Close();

            //Displaying Active Values
            ddlM_Active.SelectedText = "Yes";
            ddlM_Active.Enabled = false;
            ddlM_Active.Items.Add("Yes");
            ddlM_Active.Items.Add("No");


            //Displaying Values in SearchType combo field
            con1.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select '' as M_Type UNION select M_Type from  MachType_Master where MT_Active='yes'", con1);
            DataTable dt3 = new DataTable();
            da2.Fill(dt3);
            ddlM_Type_Search.DataSource = dt3;
            ddlM_Type_Search.DisplayMember = dt3.Columns[0].ToString();
            ddlM_Type_Search.ValueMember = dt3.Columns[0].ToString();
        }



        private void txtM_Name_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            //Validating P_Name Text Field
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
           if (txtM_Name.Text == "")//checking for blank Name combo field 
            {
                MessageBox.Show("Please Select  Name");
                txtM_Name.Focus();
            }
            else if (ddlM_Type.Text == "")//checking for blank Type combo field 
            {
                MessageBox.Show("Please Select Type");
                ddlM_Type.Focus();
            }
            else if (ddlM_Active.Text == "")//Checking for blnk Active field
            {
                MessageBox.Show("Select Active field");
                ddlM_Active.Focus();
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
                    double flag = funclib.isThere(con, "select M_Name,Grp_ID from Machine_Master where M_Name='" + txtM_Name.Text + "'and Grp_ID='" + Group_ID + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group and Machine Name is not allowed");
                    }
                    else
                    {
                        //Inserting Details into table
                        strMName = funclib.FirstCap(txtM_Name.Text);
                        string mid = funclib.AutoKey1("MC", con, "select M_ID from Machine_Master order by M_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Machine_Master values('" + mid + "','" + Group_ID + "','" + strMName.Trim().Replace("'", "''").ToString() + "','" + ddlM_Type.SelectedValue.ToString() + "','" + ddlM_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
            SqlDataAdapter da = new SqlDataAdapter("select a.M_ID as MachineID,b.Grp_Name  as GroupName,a.M_Name as MachineName,a.M_Type as Type,a.M_Active as Active from Machine_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvRPeP_MasterMachine.DataSource = dt;
            this.dgvRPeP_MasterMachine.Columns[0].Visible = false;

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {

            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Machine_Master where M_Type ='" + ddlM_Type_Search.SelectedValue.ToString() + "' order by M_Type,Grp_ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvRPeP_MasterMachine.DataSource = dt;


            if (dgvRPeP_MasterMachine.Rows.Count == 0)
            {

                cmdExcelReport.Visible = false;
            }

            else
            {
                cmdExcelReport.Visible = true;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table
            cmdSubmit.Visible = true;
            
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Machine_Master set M_Active='" + ddlM_Active.SelectedItem.ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where M_ID='" + txtM_ID.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            clearAll();
        }

        private void dgvRPeP_MasterMachine_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlM_Active.Enabled = true; 
            ddlGrp_ID.Enabled = false;
            txtM_Name.Enabled = false;
            ddlM_Type.Enabled = false;

            //Displaying grid data in form

            txtM_ID.Text = dgvRPeP_MasterMachine.Rows[e.RowIndex].Cells[0].Value.ToString();
            //ddlGrp_ID.Text = dgvRPeP_MasterMachine.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtM_Name.Text = dgvRPeP_MasterMachine.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlM_Type.Text = dgvRPeP_MasterMachine.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlM_Active.Text = dgvRPeP_MasterMachine.Rows[e.RowIndex].Cells[4].Value.ToString();


            
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
            
        }
        private void clearAll()
        {
            //Clearing form data
            ddlGrp_ID.Text = "";
            txtM_Name.Clear();
            ddlM_Active.Text = "";
            ddlM_Type.Text = "";
            cmdSubmit.Enabled = true;
            cmdEdit.Enabled = false;
            ddlGrp_ID.Enabled = true;
            txtM_Name.Enabled = true;
            ddlM_Type.Enabled = true;
            ddlM_Active.SelectedText = "Yes";
            ddlM_Active.Enabled = false;
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterMachine.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select * from Machine_Master where M_Type ='" + ddlM_Type_Search.SelectedValue.ToString() + "' order by M_Type,Grp_ID";
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