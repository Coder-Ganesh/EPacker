using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ePacker1.App_Code;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;


namespace ePacker1
{
    public partial class RPeP_MasterPartyMain : Form
    {
        string session, strSQL, Group_ID;
        private FunctionLib funclib;

        string strFirstCap;
        //private SqlDataReader dr1;
        //private string str1;
        
       
        public RPeP_MasterPartyMain()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdEdit.Enabled = false;
            txtPM_ID.Visible = false;
        }

        private void txttxtPM_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
            int Name_Data = funclib.countChar(e, txtPM_Name.Text);
            lblName_Desc.Text = "(Character " + Name_Data + "  " + "Out of" + txtPM_Name.MaxLength + ")";


        }

        private void RPeP_MasterPartyMain_Load(object sender, EventArgs e)
        {
            //to display data on Form load
           
            ddlPM_Active.SelectedText = "Yes";
            ddlPM_Active.Enabled = false;
            ddlPM_Active.Items.Add("Yes");
            ddlPM_Active.Items.Add("No");
            this.WindowState = FormWindowState.Maximized;

            funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            //SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();
            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtPM_Name.Text=="")//checking for blank PM_Name text field 
            {
                MessageBox.Show("Please enter name");
                txtPM_Name.Focus();
            }


            //else if (ddlGrp_ID.Text=="")//checking for blank Grp_ID Combo 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();
            //}
            else if (ddlPM_Active.Text == "")//checking for blank PM_Active Combo 
            {
                MessageBox.Show("Please Select Active state");
                ddlPM_Active.Focus();
            }
            else
            {

                //Insert the details into the table
                funclib = new FunctionLib();
                strFirstCap = funclib.FirstCap(txtPM_Name.Text);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Checking for duplicate entries 
                    double flag=funclib.isThere(con,"select PM_Name,Grp_ID from PartyMain_Master where PM_Name='"+txtPM_Name.Text+"' and Grp_ID='"+Group_ID+"'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Party (Main) Name and Group is not allowed");
                    }
                    else
                    {

                        
                        string pid = funclib.AutoKey1("PM", con, "select PM_ID from PartyMain_Master order by PM_ID desc");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into PartyMain_Master values('" + pid + "','" + strFirstCap.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "','" + ddlPM_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
            //to fill the grid with  details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select PM_ID as PartyID,PM_Name as PartyName,Grp_Name as GroupName,PM_Active as PartyActive from PartyMain_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwRPeP_MasterPartyMain.DataSource = dt;
            this.dgwRPeP_MasterPartyMain.Columns[0].Visible = false;

        }

        private void dgwRPeP_MasterPartyMain_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview
            ddlPM_Active.Enabled = true;
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false; 
            txtPM_ID.Text = dgwRPeP_MasterPartyMain.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPM_Name.Text = dgwRPeP_MasterPartyMain.Rows[e.RowIndex].Cells[1].Value.ToString();
            //ddlGrp_ID.Text = dgwRPeP_MasterPartyMain.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlPM_Active.Text = dgwRPeP_MasterPartyMain.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            txtPM_Name.Text = funclib.FirstCap(txtPM_Name.Text);
            //Edit data in form
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("update PartyMain_Master set PM_Name ='" + txtPM_Name.Text + "',Grp_ID ='" + Group_ID + "',PM_Active ='" + ddlPM_Active.SelectedItem.ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where PM_ID='" + txtPM_ID.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            clearAll();
        }
        private void clearAll()
        {
            //Clear all fields
            txtPM_Name.Clear();
            ddlGrp_ID.Text = "";
            ddlPM_Active.Text = "";

            cmdSubmit.Enabled = true;
            cmdEdit.Enabled = false;
            ddlPM_Active.SelectedText = "Yes";
            ddlPM_Active.Enabled = false;


        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            clearAll();

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from PartyMain_Master where PM_Name like '%" + txtNameSearch.Text + "%'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwRPeP_MasterPartyMain.DataSource = dt;


            if (dgwRPeP_MasterPartyMain.Rows.Count == 0)
            {

                cmdExcelReport.Visible = false;
            }

            else
            {
                cmdExcelReport.Visible = true;
            }

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterPartyMain.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select * from PartyMain_Master where PM_Name like '%" + txtNameSearch.Text + "%'";
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