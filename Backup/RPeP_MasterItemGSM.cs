using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace ePacker1
{
    public partial class RPeP_MasterItemGSM : Form
    {
        //Page developed by Shirish Phadnis on(18/4/2011)
        private FunctionLib funclib;
        string session, strSQL, Group_ID;   
        public RPeP_MasterItemGSM()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            
            cmdEdit.Enabled = false;
            txtGSM_ID.Visible = false;
            filldata();
        }

        private void RPeP_MasterItemGSM_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            //SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();

            ////Displaying Group Name in GroupCombo field
            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();


            //Displaying value in Activecombo field
            ddlGSM_Active.SelectedText = "Yes";
            ddlGSM_Active.Enabled = false;
            ddlGSM_Active.Items.Add("Yes");
            ddlGSM_Active.Items.Add("No");
        }

        
        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            //if (ddlGrp_ID.Text == "")//Checking for blank Group combo field.
            //{
            //    MessageBox.Show("Please Select Group");
            //    ddlGrp_ID.Focus();
            //}
            if (txtGSM_Value.Text == "")//Checking for blank GSM Value text field.
            {
                MessageBox.Show("Enter GSM Value");
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
                    double flag = funclib.isThere(con, "select Grp_ID,GSM_Value from Item_GSM_Master where Grp_ID='" + Group_ID + "' and GSM_Value='" + txtGSM_Value.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group and GSM Value is not allowed");

                    }
                    else
                    {
                        //Inserting Details into table Item_GSM_Master.
                        con.Close();
                        string gid = funclib.AutoKey1("GS", con, "select GSM_ID from Item_GSM_Master order by GSM_ID desc");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Item_GSM_Master values('" + gid + "','" + Group_ID + "','" + txtGSM_Value.Text.Trim().Replace("'", "''").ToString() + "','" + ddlGSM_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        filldata();
                        clearAll();
                    }
                }
            }
        }

        private void txtGSM_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtGSM_Value Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void filldata()
        {
            //to fill the Datagridview with user details named dgwItem_GSM_Master. 
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.GSM_ID as GSMID,b.Grp_Name,a.GSM_Value as Value,a.GSM_Active as Active from Item_GSM_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_GSM_Master.DataSource = dt;
            this.dgwItem_GSM_Master.Columns[0].Visible = false;
        }

        private void dgwItem_GSM_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview named dgwItem_GSM_Master. 
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlGSM_Active.Enabled = true;

            txtGSM_ID.Text = dgwItem_GSM_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
           // ddlGrp_ID.Text = dgwItem_GSM_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtGSM_Value.Text = dgwItem_GSM_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlGSM_Active.Text = dgwItem_GSM_Master.Rows[e.RowIndex].Cells[3].Value.ToString();



        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update Records in table Item_GSM_Master.
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            if (MessageBox.Show("Do you wish to Edit this record", "UpdateConfirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("update Item_GSM_Master set Grp_ID ='" + Group_ID + "',GSM_Value ='" + txtGSM_Value.Text + "',GSM_Active='" + ddlGSM_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where GSM_ID='" + txtGSM_ID.Text + "'", con);
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
            //Clearing all fields & refreshes the MasterItemGSM  form
            clearAll();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            ddlGrp_ID.Text = "";
            txtGSM_Value.Clear();
            ddlGSM_Active.Enabled = false;
            //ddlGSM_Active.SelectedText = "Yes";
            cmdSubmit.Enabled = true;
            cmdEdit.Enabled = false;
            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search (Grp_Name) data from table Item_GSM_Master.
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select b.Grp_Name,a.GSM_Value,a.GSM_Active from Item_GSM_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%' and a.Grp_ID=b.Grp_ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_GSM_Master.DataSource = dt;

            if (dgwItem_GSM_Master.Rows.Count == 0)
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
            //Code to close MasterItemGSM form temporarily.
            this.Close();

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterItemGSM.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select b.Grp_Name,a.GSM_Value,a.GSM_Active from Item_GSM_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%' and a.Grp_ID=b.Grp_ID";
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
