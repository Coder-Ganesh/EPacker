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
    public partial class RPeP_MasterRegion : Form
    {
        string session, strSQL, Group_ID; 
        private FunctionLib funcLib;
        string strFirstCap;
        public RPeP_MasterRegion()
        {
            InitializeComponent();
            Group_ID = RPeP_LogIn.strGroup;
            session = RPeP_LogIn.strUser;
           // filldata();
            txtRg_ID.Visible = false;
            cmdEdit.Enabled = false;

        }

        private void RPeP_MasterRegion_Load(object sender, EventArgs e)
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


            //Displaying Active value in Combo field
            ddlRg_Active.SelectedText = "Yes";
            ddlRg_Active.Enabled = false;
            ddlRg_Active.Items.Add("Yes");
            ddlRg_Active.Items.Add("No");
        }

        private void txtRg_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {

            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}
            if (txtRg_Name.Text == "")//checking for Name  field 
            {
                MessageBox.Show("Please Enter Region Name");
                txtRg_Name.Focus();
            }
            else if (ddlRg_Active.Text == "")//Checking for blnk Active field
            {
                MessageBox.Show("Select Active field");
                ddlRg_Active.Focus();
            }
            else
            {
                funcLib = new FunctionLib();

                strFirstCap = funcLib.FirstCap(txtRg_Name.Text);
                string strcon = funcLib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //Checking for duplicate values
                    double flag = funcLib.isThere(con, "select Rg_Name, Grp_ID from Region_Master where Rg_Name='" + txtRg_Name.Text + "' and Grp_ID='" + Group_ID + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group and Region Name is not allowed");
                    }
                    else
                    {
                        string rgid = funcLib.AutoKey1("RG", con, "select Rg_ID from Region_Master order by Rg_ID desc");
                        SqlCommand cmdRegion = new SqlCommand("insert into Region_Master values('" + rgid + "','" + Group_ID + "','" + strFirstCap.Trim().Replace("'", "''").ToString() + "','" + ddlRg_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        con.Open();
                        int Region = cmdRegion.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted in Region Master");
                        con.Close();
                        filldata();
                        clearAll();
                    }

                }

            }
        }


        private void filldata()
        {
            //to fill the grid with user details

            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select Rg_ID as Registration,Grp_Name as GroupName,Rg_Name as RegName,Rg_Active as Active from Region_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwMasterRegion.DataSource = dt;
            this.dgwMasterRegion.Columns[0].Visible = false;
        }
        private void clearAll()
        {
            //Clearing form

            ddlGrp_ID.Text = "";
            txtRg_Name.Clear();
            txtRg_ID.Clear();
            
            ddlGrp_ID.Enabled = true;
            txtRg_Name.Enabled = true;
            
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            
            //ddlRg_Active.SelectedText = "Yes";
            ddlRg_Active.Enabled = false;


        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();

        }

        private void dgwMasterRegion_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ddlGrp_ID.Enabled=false;
            txtRg_Name.Enabled = false;

            ddlRg_Active.Enabled=true;
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;

            //to display data in form on click of datagridview

            txtRg_ID.Text = dgwMasterRegion.Rows[e.RowIndex].Cells[0].Value.ToString();
           // ddlGrp_ID.Text = dgwMasterRegion.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtRg_Name.Text = dgwMasterRegion.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlRg_Active.Text = dgwMasterRegion.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table
            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            if (MessageBox.Show("Do you wish to Edit this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand("update Region_Master set Rg_Active='" + ddlRg_Active.SelectedItem.ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Rg_ID ='" + txtRg_ID.Text + "'", con);
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

        private void cmdRg_Name_Search_Click(object sender, EventArgs e)
        {
            //Search data from table
            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from Region_Master a,Group_Master b where a.Rg_Name like '%" + txtRg_Name_Search.Text + "%' and a.Grp_ID=b.Grp_ID order by b.Grp_Name,a.Rg_Name", con);
            //SqlDataAdapter da = new SqlDataAdapter("select * from Region_Master where Rg_Name like '%" + txtRg_Name_Search.Text + "%' order by Rg_Name", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwMasterRegion.DataSource = dt;

            if (dgwMasterRegion.Rows.Count == 0)
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
            this.Close();

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterRegion.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select * from Region_Master a,Group_Master b where a.Rg_Name like '%" + txtRg_Name_Search.Text + "%' and a.Grp_ID=b.Grp_ID order by b.Grp_Name,a.Rg_Name";
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