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
    public partial class RPeP_MasterMachineType : Form
    {
        string session; 
        private FunctionLib funclib;
        string strMType, strSQL;
        public RPeP_MasterMachineType()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            cmdSearch.Enabled = false;
            cmdEdit.Enabled = false;
            filldata();

        }

        private void RPeP_MasterMachineType_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;


            //Displaying Active Values
            ddlMT_Active.SelectedText = "Yes";
            ddlMT_Active.Enabled = false;
            ddlMT_Active.Items.Add("Yes");
            ddlMT_Active.Items.Add("No");
        }



        private void txtM_Name_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            //Validating M_Type Text Field
            funclib = new FunctionLib();
            funclib.charNumber(e);

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtM_Type.Text == "")//checking for blank Type combo field 
            {
                MessageBox.Show("Please Select Type");
                txtM_Type.Focus();
            }
            else if (ddlMT_Active.Text == "")//Checking for blnk Active field
            {
                MessageBox.Show("Select Active field");
                ddlMT_Active.Focus();
            }


            else
            {
                funclib = new FunctionLib();
                strMType = funclib.FirstCap(txtM_Type.Text);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Checking for duplicate values
                    double flag = funclib.isThere(con, "select M_Type from MachType_Master where M_Type='" + txtM_Type.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Machine Type is not allowed");
                    }
                    else
                    {
                        //Inserting Details into table
                        SqlCommand cmd = new SqlCommand("insert into MachType_Master values('" + strMType.Trim().Replace("'", "''").ToString() + "','" + ddlMT_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
            //to fill the grid with user details
            cmdSearch.Enabled = true;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select M_Type as Type,MT_Active as Active from MachType_Master", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwRPeP_MasterMachineType.DataSource = dt;

        }

        private void dgwRPeP_MasterMachineType_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Displaying form data on click of grid

            txtM_Type.Enabled = false;
            ddlMT_Active.Enabled = true;
            cmdSearch.Visible = true;
            cmdSubmit.Enabled = false;
            cmdEdit.Enabled = true;
            txtM_Type.Text = dgwRPeP_MasterMachineType.Rows[e.RowIndex].Cells[0].Value.ToString();
            ddlMT_Active.Text = dgwRPeP_MasterMachineType.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table

            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("update MachType_Master set MT_Active='" + ddlMT_Active.SelectedItem.ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where M_Type='" + txtM_Type.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            clearAll();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();

        }
        private void clearAll()
        {
            //Clearing form data
            txtM_Type.Enabled = true;
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;
            txtM_Type.Clear();
            ddlMT_Active.Text = "";
            ddlMT_Active.SelectedText = "Yes";
            ddlMT_Active.Enabled = false;
            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from MachType_Master where M_Type like '%" + txtM_Type_Search.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwRPeP_MasterMachineType.DataSource = dt;


            if (dgwRPeP_MasterMachineType.Rows.Count == 0)
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
            this.Close();

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterMachineType.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select * from MachType_Master where M_Type like '%" + txtM_Type_Search.Text + "%'";
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
        

        
    
