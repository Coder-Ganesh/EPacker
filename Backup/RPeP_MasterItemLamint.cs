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
    //Page Developed by 
    public partial class RPeP_MasterItemLamint : Form
    {
        string session, strSQL, Group_ID; 
        private FunctionLib funclib;
        public RPeP_MasterItemLamint()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdUpdate.Enabled = false;
            txtLamint_ID.Visible = false;
        }

        

        private void RPeP_MasterItemLamint_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();

            ////Displaying Group Name in GroupCombo field
            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();

            //Displaying value in ActiveCombo field
            ddlLamint_Active.SelectedText = "Yes";
            ddlLamint_Active.Enabled = false;
            ddlLamint_Active.Items.Add("Yes");
            ddlLamint_Active.Items.Add("No");

            //Displaying value in Lamination Type Combo field
            ddlLamint_Type.Items.Add("PVC");
            ddlLamint_Type.Items.Add("BOPP");
            ddlLamint_Type.Items.Add("LDPE");

            //Displaying value in Thickness Combo field
            ddlLamint_Thick.Items.Add(8);
            ddlLamint_Thick.Items.Add(9);
            ddlLamint_Thick.Items.Add(10);
            ddlLamint_Thick.Items.Add(11);
            ddlLamint_Thick.Items.Add(12);
            ddlLamint_Thick.Items.Add(13);
            ddlLamint_Thick.Items.Add(14);
            ddlLamint_Thick.Items.Add(15);
            ddlLamint_Thick.Items.Add(16);
            ddlLamint_Thick.Items.Add(17);
            ddlLamint_Thick.Items.Add(18);
            ddlLamint_Thick.Items.Add(19);
            ddlLamint_Thick.Items.Add(20);
            ddlLamint_Thick.Items.Add(21); 
            ddlLamint_Thick.Items.Add(22);
            ddlLamint_Thick.Items.Add(23);
            ddlLamint_Thick.Items.Add(24);
            ddlLamint_Thick.Items.Add(25);
            ddlLamint_Thick.Items.Add(26);
            ddlLamint_Thick.Items.Add(27);
            ddlLamint_Thick.Items.Add(28);
            ddlLamint_Thick.Items.Add(29);
            ddlLamint_Thick.Items.Add(30);
            



        }

        private void txtLamint_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtLamint_Rate Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group");
            //    ddlGrp_ID.Focus();

            //}


          if (ddlLamint_Type.Text == "")//checking for blank Lamination Type combo field 
            {
                MessageBox.Show("Please Select Lamination Type");
                ddlLamint_Type.Focus();
            }
            else if (ddlLamint_Thick.Text == "")//checking for blank lamination thickness combo field 
            {
                MessageBox.Show("Please select lamination thickness");
                ddlLamint_Thick.Focus();
            }
            else if (txtLamint_Rate.Text == "")//checking for blank Lamination Rate Text field 
            {
                MessageBox.Show("Please enter Lamination Rate");
                txtLamint_Rate.Focus();
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
                    double flag = funclib.isThere(con, "select Grp_ID,Lamint_Type,Lamint_Thick from Item_Lamint_Master where Lamint_Type ='" + ddlLamint_Type.SelectedItem.ToString() + "'and Grp_ID='" + Group_ID + "'and Lamint_Thick ='" + ddlLamint_Thick.SelectedItem.ToString() + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group,Type,First 100 Inches and Additional Inch is not allowed");

                    }
                    else
                    {
                        //Inserting Details into table Item_Lamint_Master
                        string lmid = funclib.AutoKey1("LM", con, "select Lamint_ID from Item_Lamint_Master order by Lamint_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Item_Lamint_Master values('" + lmid + "','" + Group_ID + "','" + ddlLamint_Type.SelectedItem.ToString() + "','" + ddlLamint_Thick.SelectedItem.ToString() + "','" + txtLamint_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + ddlLamint_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
            //to fill the Datagridview with user details named dgwItem_Lamint_Master 
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.Lamint_ID as LaminationID,b.Grp_Name as GroupName,a.Lamint_Type as LaminationType,a.Lamint_Thick as LaminationThick ,a.Lamint_Rate  as Rate,a.Lamint_Active as Active from Item_Lamint_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_Lamint_Master.DataSource = dt;
            this.dgwItem_Lamint_Master.Columns[0].Visible = false;

        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            //Update data in table Item_Lamint_Master
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Item_Lamint_Master set Grp_ID ='" + Group_ID + "',Lamint_Type ='" + ddlLamint_Type.SelectedItem.ToString() + "',Lamint_Thick  ='" + ddlLamint_Thick.SelectedItem.ToString() + "',Lamint_Rate  ='" + txtLamint_Rate.Text + "',Lamint_Active ='" + ddlLamint_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Lamint_ID ='" + txtLamint_ID.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                filldata();
                clearAll();
            }
            else
            {



            }

        }

        private void dgwItem_Lamint_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ddlGrp_ID.Enabled = false;
            ddlLamint_Thick.Enabled = false;
            ddlLamint_Type.Enabled = false;

            cmdUpdate.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlLamint_Active.Enabled = true;


            //To Display data in form on click of Datagridview named dgwItem_Lamint_Master
            txtLamint_ID.Text = dgwItem_Lamint_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            //ddlGrp_ID.Text = dgwItem_Lamint_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlLamint_Type.Text = dgwItem_Lamint_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlLamint_Thick.Text = dgwItem_Lamint_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtLamint_Rate.Text = dgwItem_Lamint_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlLamint_Active.Text = dgwItem_Lamint_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            ddlLamint_Type.Text = "";
            ddlLamint_Thick.Text = "";
            txtLamint_Rate.Clear();
            ddlGrp_ID.Text = "";

            ddlGrp_ID.Enabled = true;
            ddlLamint_Thick.Enabled = true;
            ddlLamint_Type.Enabled = true;

            cmdUpdate.Enabled = false;
            cmdSubmit.Enabled = true;

            ddlLamint_Active.Enabled = false;
            //ddlLamint_Active.SelectedText = "Yes";

        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            //Code to call MasterItemLamint form with all blank fields to enter new entry
            clearAll();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search (Grp_Name) data from table Item_Lamint_Master
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select b.Grp_Name,a.Lamint_Type,a.Lamint_Thick,a.Lamint_Rate,a.Lamint_Active from Item_Lamint_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%'and a.Grp_ID=b.Grp_ID order by b.Grp_Name", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_Lamint_Master.DataSource = dt;



            if (dgwItem_Lamint_Master.Rows.Count == 0)
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
            //Code to close MasterItemLamint form temporarily.
            this.Close();
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterItemLamint.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select b.Grp_Name,a.Lamint_Type,a.Lamint_Thick,a.Lamint_Rate,a.Lamint_Active from Item_Lamint_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%'and a.Grp_ID=b.Grp_ID order by b.Grp_Name";
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
