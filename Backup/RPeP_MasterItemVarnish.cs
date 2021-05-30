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
    public partial class RPeP_MasterItemVarnish : Form
    {
        string session, strSQL, Group_ID; 
        private FunctionLib funclib;
        public RPeP_MasterItemVarnish()
        {
            InitializeComponent(); 
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            txtVarnish_ID.Visible = false;
            cmdEdit.Enabled = false;
        }

        private void RPeP_MasterItemVarnish_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();

            ////Displayig Group Name in Combo field
            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();

            //Displaying value in Active field
            ddlVarnish_Active.SelectedText = "Yes";
            ddlVarnish_Active.Enabled = false;
            ddlVarnish_Active.Items.Add("Yes");
            ddlVarnish_Active.Items.Add("No");

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {

            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}


          if (txtVarnish_Type.Text == "")//checking for Varnish Type field 
            {
                MessageBox.Show("Please Enter Varnish Type");
                txtVarnish_Type.Focus();
            }
            else if (txtVarnish_100In.Text == "")//checking for Paper Width 
            {
                MessageBox.Show("Please enter Varnish 100 in");
                txtVarnish_100In.Focus();
            }
            else if (txtarnish_AddnlIn.Text == "")//checking for Paper Width 
            {
                MessageBox.Show("Please enter Varnish AddIn");
                txtarnish_AddnlIn.Focus();
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
                    double flag = funclib.isThere(con, "select Grp_ID,Varnish_Type,Varnish_100In,Varnish_AddnlIn from Item_Varnish_Master where Varnish_Type ='" + txtVarnish_Type.Text + "'and Grp_ID='" + Group_ID + "'and Varnish_100In ='" + txtVarnish_100In.Text + "'and Varnish_AddnlIn='"+txtarnish_AddnlIn.Text+"'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group,Type,First 100 Inches and Additional Inch is not allowed");

                    }
                    else
                    {
                        //Inserting Details into table
                        string vid = funclib.AutoKey1("VR", con, "select Varnish_ID from Item_Varnish_Master order by Varnish_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Item_Varnish_Master values('" + vid + "','" + Group_ID + "','" + txtVarnish_Type.Text.Trim().Replace("'", "''").ToString() + "','" + txtVarnish_100In.Text.Trim().Replace("'", "''").ToString() + "','" + txtarnish_AddnlIn.Text.Trim().Replace("'", "''").ToString() + "','" + ddlVarnish_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
            SqlDataAdapter da = new SqlDataAdapter("select a.Varnish_ID as VarnishID,b.Grp_Name as GroupName,a.Varnish_Type as VarnishType,a.Varnish_100In as Varnish_100In,a.Varnish_AddnlIn as VarnishAdd,a.Varnish_Active as Active from Item_Varnish_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_Varnish_Master.DataSource = dt;
            this.dgwItem_Varnish_Master.Columns[0].Visible = false;

        }


        private void txtVarnish_Type_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation for Varnish Type
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtVarnish_100In_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation for Varnish_100In
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtarnish_AddnlIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation for Varnish_AddnlIn
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Item_Varnish_Master set Grp_ID ='" + Group_ID + "',Varnish_Type='" + txtVarnish_Type.Text + "',Varnish_100In ='" + txtVarnish_100In.Text + "',Varnish_AddnlIn ='" + txtarnish_AddnlIn.Text + "',Varnish_Active='" + ddlVarnish_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Varnish_ID='" + txtVarnish_ID.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                filldata();
                clearAll();

            }
            else
            {



            }

        }

        private void dgwItem_Varnish_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtVarnish_Type.Enabled = false;
            txtVarnish_100In.Enabled = false;
            txtarnish_AddnlIn.Enabled = false;
            ddlGrp_ID.Enabled = false;


            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlVarnish_Active.Enabled = true;

            //Display data in form on click of grid
            txtVarnish_ID.Text = dgwItem_Varnish_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
           // ddlGrp_ID.Text = dgwItem_Varnish_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtVarnish_Type.Text = dgwItem_Varnish_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtVarnish_100In.Text = dgwItem_Varnish_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtarnish_AddnlIn.Text = dgwItem_Varnish_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlVarnish_Active.Text = dgwItem_Varnish_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void clearAll()
        {
            txtVarnish_Type.Clear();
            txtVarnish_100In.Clear();
            txtarnish_AddnlIn.Clear();
            ddlGrp_ID.Text = "";

            txtVarnish_Type.Enabled = true;
            txtVarnish_100In.Enabled = true;
            txtarnish_AddnlIn.Enabled = true;
            ddlGrp_ID.Enabled = true;

            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            
            ddlVarnish_Active.Enabled = false;

        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            
            clearAll();
            
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select b.Grp_Name,a.Varnish_Type,a.Varnish_100In,a.Varnish_AddnlIn,a.Varnish_Active from Item_Varnish_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%'and a.Grp_ID=b.Grp_ID order by b.Grp_Name,a.Varnish_Type", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_Varnish_Master.DataSource = dt;


            if (dgwItem_Varnish_Master.Rows.Count == 0)
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
            //Code to close MasterItemVarnish form temporarily.
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "eBabyReport.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select b.Grp_Name,a.Varnish_Type,a.Varnish_100In,a.Varnish_AddnlIn,a.Varnish_Active from Item_Varnish_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%'and a.Grp_ID=b.Grp_ID order by b.Grp_Name,a.Varnish_Type";
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
