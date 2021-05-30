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
    public partial class RPeP_MasterAgentMill : Form
    {
        //Page Developed by Shirish Phadnis on(8/3/2011)
        private FunctionLib funclib;
        string strSQL, Group_ID, session;
        public RPeP_MasterAgentMill()
        {
            InitializeComponent();
            filldata();
            Group_ID = RPeP_LogIn.strGroup;
            session = RPeP_LogIn.strUser;

        }

       
        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterAgentMill form
            clearAll();
        }
        private void clearAll()
        {
            //Clear all fields
            ddlGrp_ID.Text = "";
            ddlA_Active.Text = "";
            ddlA_ID.Text = "";
            ddlM_ID.Text = "";
            ddlA_Active.SelectedText = "Yes";
            
        
        
        }

        private void RPeP_MasterAgentMill_Load(object sender, EventArgs e)
        {
            //Displaying Active value in Combo field
            ddlA_Active.SelectedText = "Yes";
            ddlA_Active.Enabled = false;
            ddlA_Active.Items.Add("Yes");
            ddlA_Active.Items.Add("No");

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

            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as A_ID, '' as A_Name UNION select A_ID,(A_Name +' ('+ A_City +')') as Agent_Data from Agent_Master  where Grp_ID='" + Group_ID + "' ", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlA_ID.DataSource = dt;
            ddlA_ID.DisplayMember = dt.Columns[1].ToString();
            ddlA_ID.ValueMember = dt.Columns[0].ToString();
            con1.Close();


            //Displayig Mill Name in Combo field
            funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            SqlConnection con2 = new SqlConnection(strcon);
            con2.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as M_ID, '' as M_Name UNION select M_ID,(M_Name +' ('+ M_City +')') as Mill_Data from Mill_Master  where Grp_ID='" + Group_ID + "' ", con1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            ddlM_ID.DataSource = dt2;
            ddlM_ID.DisplayMember = dt2.Columns[1].ToString();
            ddlM_ID.ValueMember = dt2.Columns[0].ToString();
            con2.Close();
            

        }

        private void ddlGrp_ID_SelectedValueChanged(object sender, EventArgs e)
        {
            ////Displayig Agent Name in Combo field
            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            //SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();
            //SqlDataAdapter da = new SqlDataAdapter("select A_ID,(A_Name +' ('+ A_City +')') as Agent_Data from Agent_Master  where Grp_ID='" + Group_ID + "' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlA_ID.DataSource = dt;
            //ddlA_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlA_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();


            ////Displayig Mill Name in Combo field
            //funclib = new FunctionLib();
            ////string strcon = funclib.setConnection();
            //SqlConnection con2 = new SqlConnection(strcon);
            //con2.Open();
            //SqlDataAdapter da2 = new SqlDataAdapter("select M_ID,(M_Name +' ('+ M_City +')') as Mill_Data from Mill_Master  where Grp_ID='" + Group_ID + "' ", con1);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            //ddlM_ID.DataSource = dt2;
            //ddlM_ID.DisplayMember = dt2.Columns[1].ToString();
            //ddlM_ID.ValueMember = dt2.Columns[0].ToString();
            //con2.Close();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //Checking for duplicate values
                    double flag = funclib.isThere(con, "select Grp_ID ,A_ID,M_ID from AgentMill_Link where Grp_ID='" + Group_ID + "' and A_ID='" + ddlA_ID.SelectedValue.ToString() + "' and M_ID='" + ddlM_ID.SelectedValue.ToString() + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group, Agent and Mill is not allowed");
                    }
                    else
                    {
                        //Insert Details into table AgentMill_Link
                        SqlCommand cmd = new SqlCommand("insert into AgentMill_Link values('" + Group_ID + "','" + ddlA_ID.SelectedValue.ToString() + "','" + ddlM_ID.SelectedValue.ToString() + "','" + ddlA_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        filldata();
                        clearAll();
                    }

                }


        }
        private void filldata()
        {

            //to fill the Datagridview with user details named dgwAgentMill_Link 

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.A_Name as Agent,b.M_Name as Mill,c.Grp_Name from Agent_Master a,Mill_Master b,Group_Master c where c.Grp_ID=a.Grp_ID and c.Grp_ID=b.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwAgentMill_Link.DataSource = dt;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search A_Namedata from table AgentMill_Link

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from AgentMill_Link a,Agent_Master b,Mill_Master c where b.A_Name  like '%" + txtA_Name_Search.Text + "%' order by b.A_Name,c.M_Name", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwAgentMill_Link.DataSource = dt;

            if (dgwAgentMill_Link.Rows.Count == 0)
            {

                cmdExcelReport.Visible = false;
            }

            else
            {
                cmdExcelReport.Visible = true;
            }

        }

        private void cmdAgentSearch_Click(object sender, EventArgs e)
        {
            //Displaying values in Agent Combo by searching

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select distinct A_ID,(A_Name +' ('+ A_City +')') from Agent_Master where (A_Name +' ('+ A_City +')') like '%" + txtAgent_Search.Text.Trim().Replace("'", "''").ToString() + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlA_ID.DataSource = dt;
            ddlA_ID.DisplayMember = dt.Columns[1].ToString();
            ddlA_ID.ValueMember = dt.Columns[0].ToString();  
            con.Close();

        }

        private void cmdMillSearch_Click(object sender, EventArgs e)
        {
            //Displaying values in Mill Combo by searching

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select M_ID,(M_Name +' ('+ M_City +')') from Mill_Master  where (M_Name +' ('+ M_City +')') like '%" + txtMill_Search.Text.Trim().Replace("'", "''").ToString() + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlM_ID.DataSource = dt;
            ddlM_ID.DisplayMember = dt.Columns[1].ToString();
            ddlM_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();

        }

        private void txtAgent_Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgwAgentMill_Link_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Code to close MasterAgentMill form temporarily.
            this.Close();

        }

        private void ddlA_ID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterAgentMill.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                strSQL = strSQL + "select * from AgentMill_Link a,Agent_Master b,Mill_Master c where b.A_Name  like '%" + txtA_Name_Search.Text + "%' order by b.A_Name,c.M_Name";
                //  string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "eBabyReport.xls");
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

                MessageBox.Show("Excel File Created");



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