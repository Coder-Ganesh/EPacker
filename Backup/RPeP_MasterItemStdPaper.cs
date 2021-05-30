using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ePacker1.App_Code;
using Excel = Microsoft.Office.Interop.Excel;

namespace ePacker1
{
    public partial class RPeP_MasterItemStdPaper : Form
    {
        private FunctionLib funclib;
        string session, strSQL, Group_ID;
        public RPeP_MasterItemStdPaper()
        {
            
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdUpdate.Enabled = false;

        }


        private void RPeP_MasterItemStdPaper_Load(object sender, EventArgs e)
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


            //Displaying value in Active field
            ddlStdPaper_Active.SelectedText = "Yes";
            ddlStdPaper_Active.Enabled = false;
            ddlStdPaper_Active.Items.Add("Yes");
            ddlStdPaper_Active.Items.Add("No");

        }

        private void txtStdPaper_Length_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating length of Paper

            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtStdPaper_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Width of Paper
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


            if (txtStdPaper_Length.Text == "")//checking for Paper Length field 
            {
                MessageBox.Show("Please Top Paper Length");
                txtStdPaper_Length.Focus();
            }
            else if (txtStdPaper_Width.Text == "")//checking for Paper Width 
            {
                MessageBox.Show("Please enter Paper Width");
                txtStdPaper_Width.Focus();
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
                    double flag = funclib.isThere(con, "select Grp_ID,StdPaper_Length,StdPaper_Width  from Item_StdPaper_Master where StdPaper_Length='" + txtStdPaper_Length.Text + "'and Grp_ID='" + Group_ID + "'and StdPaper_Width='" + txtStdPaper_Width.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group, Length and Width is not allowed");

                    }
                    else
                    {
                        //Inserting Details into table
                        string spid = funclib.AutoKey1("SP", con, "select StdPaper_ID  from Item_StdPaper_Master order by StdPaper_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Item_StdPaper_Master values('" + spid + "','" + Group_ID + "','" + txtStdPaper_Length.Text.Trim().Replace("'", "''").ToString() + "','" + txtStdPaper_Width.Text.Trim().Replace("'", "''").ToString() + "','" + ddlStdPaper_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.StdPaper_ID  as StdPaperID,b.Grp_Name as GroupName,a.StdPaper_Length  as PaperLength,a.StdPaper_Width  as StdPaperWidth,a.StdPaper_Active  as Active from Item_StdPaper_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_StdPaper_Master.DataSource = dt;
            this.dgwItem_StdPaper_Master.Columns[0].Visible = false;

        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            //Update data in table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Item_StdPaper_Master set Grp_ID ='" + Group_ID + "',StdPaper_Length ='" + txtStdPaper_Length.Text + "',StdPaper_Width='" + txtStdPaper_Width.Text + "',StdPaper_Active ='" + ddlStdPaper_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where StdPaper_ID ='" + txtStdPaper_ID.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                filldata();
                clearAll();
            }
            else {



                 }

        }

        private void dgwItem_StdPaper_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtStdPaper_Length.Enabled = false;
            txtStdPaper_Width.Enabled = false;
            ddlGrp_ID.Enabled = false;

            cmdUpdate.Enabled = true;
            cmdSubmit.Enabled = false;

            ddlStdPaper_Active.Enabled = true;

            //Display data in form on click of grid
            txtStdPaper_ID.Text = dgwItem_StdPaper_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
           // ddlGrp_ID.Text=dgwItem_StdPaper_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtStdPaper_Length.Text=dgwItem_StdPaper_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtStdPaper_Width.Text = dgwItem_StdPaper_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlStdPaper_Active.Text = dgwItem_StdPaper_Master.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void clearAll()
        {
            txtStdPaper_Length.Clear();
            txtStdPaper_Width.Clear();
            txtStdPaper_ID.Clear();
            ddlGrp_ID.Text = "";

            txtStdPaper_Length.Enabled = true;
            txtStdPaper_Width.Enabled = true;

            ddlGrp_ID.Enabled = true;

            ddlStdPaper_Active.Enabled = false;
            //ddlStdPaper_Active.SelectedText = "Yes";

            cmdUpdate.Enabled = false;
            cmdSubmit.Enabled = true;

        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            
            clearAll();
            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
           
            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select b.Grp_Name,a.StdPaper_Length,a.StdPaper_Width,a.StdPaper_Active from Item_StdPaper_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%' and a.Grp_ID=b.Grp_ID order by b.Grp_Name,a.StdPaper_Length,a.StdPaper_Width", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_StdPaper_Master.DataSource = dt;


            if (dgwItem_StdPaper_Master.Rows.Count == 0)
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
            //Code to close MasterItemStdPaper form temporarily
            this.Close();

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterItenStdPaper.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select b.Grp_Name,a.StdPaper_Length,a.StdPaper_Width,a.StdPaper_Active from Item_StdPaper_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%' and a.Grp_ID=b.Grp_ID order by b.Grp_Name,a.StdPaper_Length,a.StdPaper_Width";
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
