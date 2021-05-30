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
    public partial class RPeP_MasterMachineContractor : Form
    {
        private FunctionLib funclib;
        string session, strSQL, Group_ID;  
        public RPeP_MasterMachineContractor()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdEdit.Enabled = false;
        }

        private void RPeP_MasterMachineContractor_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
           
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            con1.Open();
            ////Displayig Group Name in Combo field
            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();

            //Display value in Active


            SqlDataAdapter daMach = new SqlDataAdapter("select '' as M_ID, '' as M_Name UNION select a.M_ID,(a.M_Name+'('+a.M_Type+')') from Machine_Master a,MachType_Master b  where a.Grp_ID='" + Group_ID + "' and a.M_Type=b.M_Type  ", con1);
            DataTable dtMach = new DataTable();
            daMach.Fill(dtMach);
            ddlM_ID.DataSource = dtMach;
            ddlM_ID.DisplayMember = dtMach.Columns[1].ToString();
            ddlM_ID.ValueMember = dtMach.Columns[0].ToString();
            con1.Close();


            //displaying Value in Contractor
            SqlConnection con2 = new SqlConnection(strcon);
            SqlDataAdapter daContra = new SqlDataAdapter("select '' as C_ID, '' as C_Name UNION select C_ID,(C_Name+'('+C_City+')') from Contractor_Master   where Grp_ID='" + Group_ID + "'", con2);
            DataTable dtContra = new DataTable();
            daContra.Fill(dtContra);
            ddlC_ID.DataSource = dtContra;
            ddlC_ID.DisplayMember = dtContra.Columns[1].ToString();
            ddlC_ID.ValueMember = dtContra.Columns[0].ToString();
            con2.Close();


            ddlMC_Active.SelectedText = "Yes";
            ddlMC_Active.Enabled = false;
            ddlMC_Active.Items.Add("Yes");
            ddlMC_Active.Items.Add("No");


      }

        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Displaying value in Machine Combobox
            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();

            //SqlConnection con1 = new SqlConnection(strcon);
            //SqlDataAdapter daMach = new SqlDataAdapter("select a.M_ID,(a.M_Name+'('+a.M_Type+')') from Machine_Master a,MachType_Master b  where a.Grp_ID='"+Group_ID+"' and a.M_Type=b.M_Type  ", con1);
            //DataTable dtMach = new DataTable();
            //daMach.Fill(dtMach);
            //ddlM_ID.DataSource = dtMach;
            //ddlM_ID.DisplayMember = dtMach.Columns[1].ToString();
            //ddlM_ID.ValueMember = dtMach.Columns[0].ToString();
            //con1.Close();


            ////displaying Value in Contractor
            //SqlConnection con2 = new SqlConnection(strcon);
            //SqlDataAdapter daContra = new SqlDataAdapter("select C_ID,(C_Name+'('+C_City+')') from Contractor_Master   where Grp_ID='"+Group_ID+"'", con2);
            //DataTable dtContra = new DataTable();
            //daContra.Fill(dtContra);
            //ddlC_ID.DataSource = dtContra;
            //ddlC_ID.DisplayMember = dtContra.Columns[1].ToString();
            //ddlC_ID.ValueMember = dtContra.Columns[0].ToString();
            //con2.Close();







        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            //if (ddlGrp_ID.Text == "")
            //{
            //    MessageBox.Show("Please Select Group");
            //    ddlGrp_ID.Focus();
            //}
            if (ddlC_ID.Text == "")
            {
                MessageBox.Show("Please Select Contractor");
                ddlC_ID.Focus();
            }
            else if (ddlM_ID.Text == "")
            {
                MessageBox.Show("Please Select Machine Name");
                ddlM_ID.Focus();
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
                    double flag = funclib.isThere(con, "select Grp_ID,M_ID,C_ID from MachContractor_Link where  Grp_ID='" + Group_ID + "' and M_ID='"+ddlM_ID.SelectedValue.ToString()+"' and C_ID='"+ddlC_ID.SelectedValue.ToString()+"'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group, Machine and Contractor is not allowed");

                    }
                    else
                    {
                        //Insert details in table

                        SqlCommand cmdMachContra = new SqlCommand("insert into MachContractor_Link values('" + Group_ID + "','" + ddlM_ID.SelectedValue.ToString() + "','" + ddlC_ID.SelectedValue.ToString() + "','" + ddlMC_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        con.Open();
                        int i = cmdMachContra.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        con.Close();
                        clearAll();
                        filldata();
                    }
                }
                
            }


        }

        private void filldata()
        {
            //to fill the grid with MachContractor

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.Grp_Name as GroupName,b.M_Name as Machinename,c.C_Name as Contractor, d.MC_Active as Active  from Group_Master a,Machine_Master b,Contractor_Master c,MachContractor_Link d where a.Grp_ID=d.Grp_ID and b.M_ID=d.M_ID and c.C_ID=d.C_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwMachContractor_Link.DataSource = dt;
            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.Grp_Name as GroupName,b.M_Name as Machinename,c.C_Name as Contractor from Group_Master a,Machine_Master b,Contractor_Master c,MachContractor_Link d where a.Grp_ID=d.Grp_ID and b.M_ID=d.M_ID and c.C_ID=d.C_ID and  b.M_Name like '%" + txtM_Name_Search.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwMachContractor_Link.DataSource = dt;


            if (dgwMachContractor_Link.Rows.Count == 0)
            {

                cmdExcelReport.Visible = false;
            }

            else
            {
                cmdExcelReport.Visible = true;
            }
        }

        private void cmdSearchMach_Click(object sender, EventArgs e)
        {
            //Search Machine 

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.M_Name from Machine_Master a,MachContractor_Link b where a.M_Name like '%" + txtMachSearch.Text + "%' and a.M_ID=b.M_ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlM_ID.DataSource = dt;
            ddlM_ID.DisplayMember = dt.Columns[0].ToString();
            //ddlM_ID.ValueMember = dt.Columns[0].ToString();
            
            

        }

        private void cmdSearchContra_Click(object sender, EventArgs e)
        {
            //Search Contractor

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.C_Name from Contractor_Master a,MachContractor_Link b where a.C_Name like '%" + txtContraSearch.Text + "%' and a.C_ID=b.C_ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlC_ID.DataSource = dt;
            ddlC_ID.DisplayMember = dt.Columns[0].ToString();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
            
        }
        private void clearAll()
        {
            ddlGrp_ID.Text = "";
            ddlM_ID.Text = "";
            ddlC_ID.Text = "";
            ddlMC_Active.Text = "";
            ddlMC_Active.SelectedText = "Yes";
            ddlMC_Active.Enabled = false;
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;
            ddlM_ID.Enabled = true;
            ddlC_ID.Enabled = true;
            ddlGrp_ID.Enabled = true;

        }

        private void dgwMachContractor_Link_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlM_ID.Enabled = false;
            ddlC_ID.Enabled = false;
            ddlGrp_ID.Enabled = false;
            ddlMC_Active.Enabled = true;

           //ddlGrp_ID.Text = dgwMachContractor_Link.Rows[e.RowIndex].Cells[0].Value.ToString();
            ddlM_ID.Text = dgwMachContractor_Link.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlC_ID.Text = dgwMachContractor_Link.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlMC_Active.Text = dgwMachContractor_Link.Rows[e.RowIndex].Cells[3].Value.ToString();


        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
         
            string strCon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("update MachContractor_Link set MC_Active='" + ddlMC_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Grp_ID='" + Group_ID + "'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            clearAll();
           

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
            sfd.FileName = "MasterMachineContractor.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select a.Grp_Name as GroupName,b.M_Name as Machinename,c.C_Name as Contractor from Group_Master a,Machine_Master b,Contractor_Master c,MachContractor_Link d where a.Grp_ID=d.Grp_ID and b.M_ID=d.M_ID and c.C_ID=d.C_ID and  b.M_Name like '%" + txtM_Name_Search.Text + "%'";
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
