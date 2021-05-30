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

    public partial class RPeP_MasterItemPrntMach : Form
    {
        string session, strSQL, Group_ID;  
        private FunctionLib funclib;
        public RPeP_MasterItemPrntMach()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            cmdEdit.Enabled = false;
            txtPrntMach_ID.Visible = false;
        }

        

        private void RPeP_MasterItemPrntMach_Load(object sender, EventArgs e)
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
            ddlPrntMach_Active.SelectedText = "Yes";
            ddlPrntMach_Active.Enabled = false;
            ddlPrntMach_Active.Items.Add("Yes");
            ddlPrntMach_Active.Items.Add("No");

            




        }

        private void txtPrntMach_Size_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPrntMach_Size Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);

        }

        private void txtPrntMach_Printg_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPrntMach_Printg Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtPrntMach_PlateSgl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPrntMach_PlateSgl Text Field
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtPrntMach_PlateSgl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating txtPrntMach_PlateSgl2 Text Field
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


           if (txtPrntMach_Size.Text == "")//checking for blank Machine Size text field 
            {
                MessageBox.Show("Please Enter Machine Size");
                txtPrntMach_Size.Focus();
            }
            else if (txtPrntMach_Printg.Text == "")//checking for blank Printing Machine text field 
            {
                MessageBox.Show("Please Enter Printing Machine");
                txtPrntMach_Printg.Focus();
            }
            else if (txtPrntMach_PlateSgl.Text == "")//checking for PrintingMachinePlate text field 
            {
                MessageBox.Show("Please enter Printing Machine Plate");
                txtPrntMach_PlateSgl.Focus();
            }
            else if (txtPrntMach_PlateSgl2.Text == "")//checking for PrintingMachinePlate2 text field 
            {
                MessageBox.Show("Please enter Printing Machine Plate2");
                txtPrntMach_PlateSgl2.Focus();
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
                    double flag = funclib.isThere(con, "select Grp_ID,PrntMach_Size,PrntMach_Printg,PrntMach_PlateSgl,PrntMach_PlateDbl from Item_PrntMach_Master where PrntMach_Size='" + txtPrntMach_Size.Text + "'and Grp_ID='" + Group_ID + "'and PrntMach_Printg  ='" + txtPrntMach_Printg.Text + "' and PrntMach_PlateSgl='" + txtPrntMach_PlateSgl.Text + "'and PrntMach_PlateDbl='"+txtPrntMach_PlateSgl2.Text+"'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group,Type,First 100 Inches and Additional Inch is not allowed");

                    }
                    else
                    {
                        //Inserting Details into table Item_PrntMach_Master
                        string pid = funclib.AutoKey1("PR", con, "select PrntMach_ID from Item_PrntMach_Master order by PrntMach_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Item_PrntMach_Master values('" + pid + "','" + Group_ID + "','" + txtPrntMach_Size.Text + "','" + txtPrntMach_Printg.Text.Trim().Replace("'", "''").ToString() + "','" + txtPrntMach_PlateSgl.Text.Trim().Replace("'", "''").ToString() + "','" + txtPrntMach_PlateSgl2.Text.Trim().Replace("'", "''").ToString() + "','" + ddlPrntMach_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
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
            //to fill the Datagridview with user details named dgwItem_PrntMach_Master.
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.PrntMach_ID as PrntMach_ID,b.Grp_Name as GroupName,a.PrntMach_Size as MachineSize,a.PrntMach_Printg  as MachinePrint,a.PrntMach_PlateSgl as PrintPlate,a.PrntMach_PlateDbl as PlateDbl,a.PrntMach_Active as Active from Item_PrntMach_Master a,Group_Master b where b.Grp_ID=a.Grp_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_PrntMach_Master.DataSource = dt;
            this.dgwItem_PrntMach_Master.Columns[0].Visible = false;

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table Item_PrntMach_Master. 
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Item_PrntMach_Master set Grp_ID ='" + Group_ID + "',PrntMach_Size  ='" + txtPrntMach_Size.Text + "',PrntMach_Printg   ='" + txtPrntMach_Printg.Text + "',PrntMach_PlateSgl   ='" + txtPrntMach_PlateSgl.Text + "',PrntMach_PlateDbl='" + txtPrntMach_PlateSgl2.Text + "', PrntMach_Active ='" + ddlPrntMach_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where PrntMach_ID  ='" + txtPrntMach_ID.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                filldata();
                clearAll();
            }
            else
            {

            }

        }

        private void dgwItem_PrntMach_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ddlGrp_ID.Enabled = false;
            txtPrntMach_Printg.Enabled = false;
            txtPrntMach_PlateSgl.Enabled = false;
            txtPrntMach_PlateSgl2.Enabled = false;

            ddlPrntMach_Active.Enabled = true;

            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;


            //to display data in form on click of datagridview named dgwItem_PrntMach_Master 
            txtPrntMach_ID.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
         //   ddlGrp_ID.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrntMach_Size.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrntMach_Printg.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPrntMach_PlateSgl.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPrntMach_PlateSgl2.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlPrntMach_Active.Text = dgwItem_PrntMach_Master.Rows[e.RowIndex].Cells[6].Value.ToString();

        }

        private void clearAll()
        {
            //Code for Clearing all form fields.
            txtPrntMach_PlateSgl.Clear();
            txtPrntMach_PlateSgl2.Clear();
            txtPrntMach_Printg.Clear();
            txtPrntMach_Size.Clear();
           
            ddlGrp_ID.Text = "";

            ddlGrp_ID.Enabled = true;
            txtPrntMach_Size.Enabled = true;
            txtPrntMach_Printg.Enabled = true;
            txtPrntMach_PlateSgl.Enabled = true;
            txtPrntMach_PlateSgl2.Enabled = true;

            ddlPrntMach_Active.Enabled = false;

            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            //Code to call MasterItemPrntMach form with all blank fields to enter new entry
            clearAll();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search Group Name data from table Item_PrntMach_Master
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select b.Grp_Name,a.PrntMach_Size,a.PrntMach_Printg,a.PrntMach_PlateSgl,a.PrntMach_PlateDbl from Item_PrntMach_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%'and a.Grp_ID=b.Grp_ID order by b.Grp_Name,a.PrntMach_Size", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwItem_PrntMach_Master.DataSource = dt;



            if (dgwItem_PrntMach_Master.Rows.Count == 0)
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
            //Code to close MasterItemPrntMach form temporarily.
            this.Close();
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterItemPrnMach.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select b.Grp_Name,a.PrntMach_Size,a.PrntMach_Printg,a.PrntMach_PlateSgl,a.PrntMach_PlateDbl from Item_PrntMach_Master a,Group_Master b where b.Grp_Name like '%" + txtGrp_Name_Search.Text + "%'and a.Grp_ID=b.Grp_ID order by b.Grp_Name,a.PrntMach_Size";
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
