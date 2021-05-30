using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace ePacker1
{
    public partial class RPeP_MasterPositive : Form
    {
        string session, strSQL, Group_ID; 
        //Page developed by Shirish Phadnis on 12/3/2011
        private FunctionLib funcLib;
        string strFirstCap;

        public RPeP_MasterPositive()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdEdit.Enabled = false;
            txtPtve_ID.Visible = false;
        }

        private void txtPtve_File1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {

            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}
           if (ddlA_ID.Text == "")//checking for Name  field 
            {
                MessageBox.Show("Please Select Agent");
                ddlA_ID.Focus();
            }

            else if (txtPtve_Name.Text == "")//checking for blank Addr1 text field 
            {
                MessageBox.Show("Please Enter Positive Name");
                txtPtve_Name.Focus();
            }
            else if (txtPtve_Qty_OS.Text == "")//checking for blank Opening stock
            {
                MessageBox.Show("Enter Opening Stock");
                txtPtve_Qty_OS.Focus();

            }
            else if (txtPtve_Qty_CS.Text == "")//checking for blank Closing stock
            {
                MessageBox.Show("Enter Closing Stock");
                txtPtve_Qty_CS.Focus();

            }
            else if (txtPtve_Qty_RO.Text == "")//checking for blank Reorder level
            {
                MessageBox.Show("Enter Reorder Level");
                txtPtve_Qty_RO.Focus();

            }

            else if (ddlPtve_Active.Text == "")
            {
                MessageBox.Show("Please select Active field");
            }
            else
            {


                funcLib = new FunctionLib();
                strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                string strcon = funcLib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //Checking for duplicate values
                    double flag = funcLib.isThere(con, "select Grp_ID ,A_ID,Ptve_Name from Positive_Master where Grp_ID='" + Group_ID + "' and A_ID='" + ddlA_ID.SelectedValue.ToString() + "' and Ptve_Name='" + txtPtve_Name.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group, Agent and Positive Name is not allowed");
                    }
                    else
                    {
                        //Inserting records in Positive_Master

                        string pvid = funcLib.AutoKey1("PV", con, "select Ptve_ID from Positive_Master order by Ptve_ID desc");
                        SqlCommand cmdPositive = new SqlCommand("insert into Positive_Master values('" + pvid + "','" + Group_ID + "','" + ddlA_ID.SelectedValue.ToString() + "','" + strFirstCap.Trim().Replace("'", "''").ToString() + "','" + txtPtve_File1.Text.Trim().Replace("'", "''").ToString() + "','" + txtPtve_File2.Text.Trim().Replace("'", "''").ToString() + "','" + txtPtve_Qty_OS.Text.Trim().Replace("'", "''").ToString() + "','" + txtPtve_Qty_CS.Text.Trim().Replace("'", "''").ToString() + "','" + txtPtve_Qty_RO.Text.Trim().Replace("'", "''").ToString() + "','" + ddlPtve_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        con.Open();
                        int Positive = cmdPositive.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted in Positive_Master");
                        con.Close();
                        filldata();
                        clearAll();

                    }
                }
            }
        }

        

        private void RPeP_MasterPositive_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            
            //con1.Open();
            ////Displayig Group Name in Combo field
            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();
            SqlConnection con2 = new SqlConnection(strcon);
            con2.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as A_ID, '' as A_Name UNION select A_ID,(A_Name +' ('+ A_City +')') as Agent_Data from Agent_Master  where Grp_ID='" + Group_ID + "' and A_Cate='JobWork' and A_Active ='yes' ", con2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            ddlA_ID.DataSource = dt2;
            ddlA_ID.DisplayMember = dt2.Columns[1].ToString();
            ddlA_ID.ValueMember = dt2.Columns[0].ToString();
            con2.Close();

            //Displaying Active value in Combo field

            ddlPtve_Active.SelectedText = "Yes";
            ddlPtve_Active.Enabled = false;
            ddlPtve_Active.Items.Add("Yes");
            ddlPtve_Active.Items.Add("No");


            

        }

        private void txtPtve_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);

        }

        private void txtPtve_File1_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);

        }

        private void txtPtve_File2_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcLib = new FunctionLib();
            funcLib.checkNumericChar(e);
        }

        private void ddlGrp_ID_SelectedValueChanged(object sender, EventArgs e)
        {
            //funcLib = new FunctionLib();
            //string strcon = funcLib.setConnection();
            //SqlConnection con2 = new SqlConnection(strcon);
            //con2.Open();
            //SqlDataAdapter da2 = new SqlDataAdapter("select A_ID,(A_Name +' ('+ A_City +')') as Agent_Data from Agent_Master  where Grp_ID='" + Group_ID + "' and A_Cate='JobWork' and A_Active ='yes' ", con2);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            //ddlA_ID.DataSource = dt2;
            //ddlA_ID.DisplayMember = dt2.Columns[1].ToString();
            //ddlA_ID.ValueMember = dt2.Columns[0].ToString();
            //con2.Close();
        }


        private void filldata()
        {
            //to fill the grid with user details

            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("select Ptve_ID as PositiveID,Grp_Name as GroupName,A_Name as Agent,Ptve_Name as PositiveName,Ptve_File1 as File1,Ptve_File2 as File2,Ptve_Qty_OS,Ptve_Qty_CS,Ptve_Qty_RO,Ptve_Active as Active from Positive_Master a,Group_Master b,Agent_Master c where b.Grp_ID=a.Grp_ID and c.A_ID=a.A_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvMasterPositive.DataSource = dt;
            this.dgvMasterPositive.Columns[0].Visible = false;
        }

        private void dgvMasterPositive_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlPtve_Active.Enabled = true;
            ddlGrp_ID.Enabled = false;
            ddlA_ID.Enabled = false;
            txtPtve_Name.Enabled = false;
            txtPtve_File1.Enabled = false;
            txtPtve_File2.Enabled = false;
            txtPtve_Qty_OS.Enabled = false;
            txtPtve_Qty_CS.Enabled = false;
            txtPtve_Qty_RO.Enabled = false;
            

            //to display data in form on click of datagridview

            txtPtve_ID.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[0].Value.ToString();
           // ddlGrp_ID.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlA_ID.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPtve_Name.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPtve_File1.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPtve_File2.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPtve_Qty_OS.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtPtve_Qty_CS.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtPtve_Qty_RO.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[8].Value.ToString();
            ddlPtve_Active.Text = dgvMasterPositive.Rows[e.RowIndex].Cells[9].Value.ToString();


        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table
            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                SqlCommand cmd = new SqlCommand("update Positive_Master set Ptve_Active='" + ddlPtve_Active.SelectedItem.ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Ptve_ID ='" + txtPtve_ID.Text + "'", con);
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

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from Positive_Master a,Agent_Master b,Group_Master c where b.A_Name like '%" + txtA_Name_Search.Text + "%' and a.A_ID=b.A_ID and c.Grp_ID=a.Grp_ID order by c.Grp_Name,b.A_Name,a.Ptve_Name", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvMasterPositive.DataSource = dt;


            if (dgvMasterPositive.Rows.Count == 0)
            {

                cmdExcelReport.Visible = false;
            }

            else
            {
                cmdExcelReport.Visible = true;
            }
        }

        private void btnPtve_File1_Click(object sender, EventArgs e)
        {
            //Saving file1 path in database
            funcLib = new FunctionLib();

            OpenFileDialog ofn = new OpenFileDialog();
            if (ofn.ShowDialog() == DialogResult.OK)
            {
                FileStream fstr;
                try
                {
                    fstr = new FileStream(ofn.FileName, FileMode.Open, FileAccess.Read);
                    txtPtve_File1.Text = ofn.SafeFileName;

                    //Storing path in database

                    string path = ofn.FileName;
                    string strcon = funcLib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlCommand cmd = new SqlCommand("insert into Positive_Location values('" + path + "')", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Path inserted successfully");


                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }

            }


        }

        private void cmdAgentSearch_Click(object sender, EventArgs e)
        {
            //Display values in Agent Combo by searching

            funcLib = new FunctionLib();
            string strcon = funcLib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select distinct A_ID,(A_Name +' ('+ A_City +')') from Agent_Master where (A_Name +' ('+ A_City +')') like '%" + txtAgentSearch.Text.Trim().Replace("'", "''").ToString() + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlA_ID.DataSource = dt;
            ddlA_ID.DisplayMember = dt.Columns[1].ToString();
            ddlA_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();

        }

        private void cmdPtve_File2_Click(object sender, EventArgs e)
        {
            funcLib = new FunctionLib();
            OpenFileDialog ofn = new OpenFileDialog();
            if (ofn.ShowDialog() == DialogResult.OK)
            {
                FileStream fstr;
                try
                {
                    fstr = new FileStream(ofn.FileName, FileMode.Open, FileAccess.Read);
                    txtPtve_File2.Text = ofn.SafeFileName;

                    //Storing path in database

                    string path=ofn.FileName;
                    string strcon = funcLib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlCommand cmd = new SqlCommand("insert into Positive_Location values('" + path + "')", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Path inserted successfully");
                    


                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }

            }


        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();

        } 

        private void clearAll()
        {
            //Clearing form data
            ddlGrp_ID.Text = "";
            ddlA_ID.Text = "";
            txtPtve_File1.Clear();
            txtPtve_File2.Clear();
            txtPtve_Name.Clear();
            txtPtve_Qty_OS.Clear();
            txtPtve_Qty_CS.Clear();
            txtPtve_Qty_RO.Clear();
            //ddlPtve_Active.Text = "";
            txtAgentSearch.Clear();
            ddlGrp_ID.Enabled = true;
            ddlA_ID.Enabled = true;
            txtPtve_Name.Enabled = true;
            txtPtve_File1.Enabled = true;
            txtPtve_File2.Enabled = true;
            txtPtve_Qty_OS.Enabled = true;
            txtPtve_Qty_CS.Enabled = true;
            txtPtve_Qty_RO.Enabled = true;
            ddlPtve_Active.SelectedText = "Yes";
            ddlPtve_Active.Enabled = false;
            cmdSubmit.Enabled = true;
            cmdEdit.Enabled = false;

        }

        private void dgvMasterPositive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPtve_Qty_OS_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Opening Stock
            funcLib = new FunctionLib();
            funcLib.onlyNumbers(e);

        }

        private void txtPtve_Qty_CS_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Closing Stock
            funcLib = new FunctionLib();
            funcLib.onlyNumbers(e);

        }

        private void txtPtve_Qty_RO_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Reorder level
            funcLib = new FunctionLib();
            funcLib.onlyNumbers(e);

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterPositive.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select * from Positive_Master a,Agent_Master b,Group_Master c where b.A_Name like '%" + txtA_Name_Search.Text + "%' and a.A_ID=b.A_ID and c.Grp_ID=a.Grp_ID order by c.Grp_Name,b.A_Name,a.Ptve_Name";
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
