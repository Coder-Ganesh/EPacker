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
    public partial class RPeP_MasterPurchaseItem : Form
    {
        string session, strSQL, Group_ID; 
        private FunctionLib funclib;
        public RPeP_MasterPurchaseItem()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            cmdUpdate.Enabled = false;
            txtSI_ID.Visible = false;
            filldata();
           
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {

            if ((ddlSI_Cate.Text.Equals("Excisable Item") == true) || (ddlSI_Cate.Text.Equals("57F4 Item") == true))
            {


                if (txtSI_ExcCode.Text == "")//Checking for blnk PinCode field
                {
                    MessageBox.Show("Enter Excise Code");
                    txtSI_ExcCode.Focus();
                }
                else if (txtSI_ExcDesc.Text == "")//Checking for blnk Mobile field
                {
                    MessageBox.Show("Enter Excise Description");
                    txtSI_ExcDesc.Focus();
                }
                else if (txtSI_ChapTarNo.Text == "")//Checking for blnk BirthPlace field
                {
                    MessageBox.Show("Enter Tariff");
                    txtSI_ChapTarNo.Focus();
                }
                else if (txtSI_Procesg.Text == "")//Checking for blnk ECC field
                {
                    MessageBox.Show("Please Enter Processing");
                    txtSI_Procesg.Focus();
                }


            }
            

            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}


            if (txtSI_Name.Text == "")//checking for First Name field 
            {
                MessageBox.Show("Please Enter Name");
                txtSI_Name.Focus();
            }
            else if (txtSI_CuStock.Text == "")//checking for Last Name 
            {
                MessageBox.Show("Please enter Current Stock");
                txtSI_CuStock.Focus();
            }
            else if (txtSI_MinLev.Text == "")//checking for blank Addr1 text field 
            {
                MessageBox.Show("Please Enter Min Level");
                txtSI_MinLev.Focus();
            }

            else if (ddlSI_UOM.Text == "")//Checking for blnk City field
            {
                MessageBox.Show("Please Enter UOM");
                ddlSI_UOM.Focus();
            }
            else if (ddlSI_Cate.Text == "")//Checking for blnk State field
            {
                MessageBox.Show("Please select category");
                ddlSI_Cate.Focus();
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
                    double flag = funclib.isThere(con, "select SI_Name,GRP_ID from Purchase_Item where GRP_ID='" + Group_ID + "' and SI_Name='" + txtSI_Name.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Shift is not allowed");
                    }


                    else
                    {
                        txtSI_Name.Text = funclib.FirstCap(txtSI_Name.Text);
                        //Inserting Details into table
                        string Siid = funclib.SI_ID("SI", con, "select SI_ID from Purchase_Item order by SI_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Purchase_Item values('" + Siid + "','" + Group_ID + "','" + txtSI_Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_CuStock.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_MinLev.Text.Trim().Replace("'", "''").ToString() + "','" + ddlSI_UOM.SelectedValue.ToString() + "','" + ddlSI_Cate.Text + "','" + txtSI_ExcCode.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_ExcDesc.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_ChapTarNo.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_Procesg.Text.Trim().Replace("'", "''").ToString() + "','" + ddlSI_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        filldata();
                        clearAll();



                    }
                }
            }
            
            


        }

        private void RPeP_MasterPurchaseItem_Load(object sender, EventArgs e)
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
            ////ddlGrp_ID.Items.Add("");
            //con1.Close();


            //Displayig UOM in Combo field
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT '' as UOM_ID, '' as UOM_Name UNION select UOM_ID,UOM_Name from UOM_Master", con1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            ddlSI_UOM.DataSource = dt1;
            ddlSI_UOM.DisplayMember = dt1.Columns[1].ToString();
            ddlSI_UOM.ValueMember = dt1.Columns[0].ToString();
          
            con1.Close();


            //Displaying value in Active field
            ddlSI_Active.SelectedText = "Yes";
            ddlSI_Active.Enabled = false;
            ddlSI_Active.Items.Add("Yes");
            ddlSI_Active.Items.Add("No");

            ddlSI_Cate.Items.Add("Excisable Item");
            ddlSI_Cate.Items.Add("57F4 Item");
            ddlSI_Cate.Items.Add("Non- Excisable Item");

            

        }

        private void txtSI_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            
        }

        private void txtSI_CuStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtSI_MinLev_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtSI_ExcCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            

        }

        private void txtSI_ChapTarNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            

        }

        private void txtSI_ExcDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            

        }

        private void txtSI_Procesg_KeyPress(object sender, KeyPressEventArgs e)
        {

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
            
        }

        private void filldata()
        {
            //to fill the grid with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.SI_ID,b.Grp_Name as GroupName,a.SI_Name as Store,a.SI_CuStock as CurrentStock,a.SI_MinLev as MinLevel,a.SI_Cate as category,c.UOM_Name as UOM,a.SI_ExcCode,a.SI_ExcDesc,a.SI_ChapTarNo,a.SI_Procesg,a.SI_Active from Purchase_Item as a,Group_Master as b,UOM_Master as c where a.Grp_ID=b.Grp_ID and a.SI_UOM=c.UOM_ID ", con4);
            //SqlDataAdapter da = new SqlDataAdapter("select a.TP_ID as TopPaperID,b.Grp_Name as GroupName,c.P_Name as PartyName,a.TP_Name as TopPaperName,d.PQ_Desc as PaperQuality, a.TP_PPLgth as TopPaperLength,a.TP_PPWdth as PaperWidth,a.TP_PPBf as PaperBf, a.TP_PPGram as PaperGram,a.TP_PPRate as PaperRate,a.TP_PPCost as PaperCost, a.TP_LmLgth as LaminationLength,a.TP_LmWdth as LaminationWidth, a.TP_LmRate as LaminationRate,a.TP_LmCost as LaminationCost ,a.TP_LmType as LaminationType,a.TP_VrLgth as VarnishLength,a.TP_VrWdth as varnishWidth,a.TP_VrRate as vanishRate,a.TP_VrCost as VarnishCost,a.TP_VrType as varnishType, a.TP_PnColor as NoColors,a.TP_PnRate as PlateRate,a.TP_PnCost as PlateCost,a.TP_PlDivFact as Divfactor, a.TP_PlNo as PlateNo,a.TP_PlRate as PlateRate,a.TP_PlCost as PlateCost, a.TP_PlWsCnt as WeightPercnt,a.TP_PlWsAmt as WeightAmt,e.Ptve_Name as PositiveName, a.TP_Rate as Rate,a.TP_OS as OpenStock,a.TP_CS as ClosingStock,a.TP_ReLev as ReOrder, a.TP_Active as Active from TopPaper_Master a,Group_Master b ,Party_Master c,PQuality_Master d,Positive_Master e  where b.Grp_ID=a.Grp_ID and b.Grp_ID=c.Grp_ID and b.Grp_ID=d.Grp_ID and a.PQ_ID=d.PQ_ID and a.P_ID=c.P_ID and a.Ptve_ID=e.Ptve_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[0].Visible = false;

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            cmdUpdate.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlSI_Active.Enabled = true;

            txtSI_Name.Enabled = false;
            txtSI_CuStock.Enabled = false;
            //ddlGrp_ID.Enabled = false;
            //ddlPQ_ID.Enabled = false;
            //ddlPtve_ID.Enabled = false;

            //Display data in form on click of grid


            txtSI_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            
         //   ddlGrp_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSI_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSI_CuStock.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSI_MinLev.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlSI_Cate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            ddlSI_UOM.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtSI_ExcCode.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtSI_ExcDesc.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtSI_ChapTarNo.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtSI_Procesg.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            ddlSI_Active.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
           

        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                //Update data in table
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                //SqlCommand cmd = new SqlCommand("update TopPaper_Master set Grp_ID ='" + Group_ID + "',TP_PPLgth='" + txtTP_PPLgth.Text + "',TP_PPWdth ='" + txtTP_PPWdth.Text + "',TP_PPBf ='" + txtTP_PPBf.Text + "',TP_PPGram='" + txtTP_PPGram.Text + "',TP_PPRate ='" + txtTP_PPRate.Text + "',TP_PPCost='" + txtTP_PPCost.Text + "',TP_LmLgth='" + txtTP_LmLgth.Text + "',TP_LmWdth='" + txtTP_LmWdth.Text + "',TP_LmRate='" + txtTP_LmRate.Text + "',TP_LmCost='" + txtTP_LmCost.Text + "',TP_PnColor='" + txtTP_PnColor.Text + "',TP_PnRate='" + txtTP_PnRate.Text + "',TP_PnCost='" + txtTP_PnCost.Text + "',TP_PlNo='" + txtTP_PlNo.Text + "',TP_PlRate='" + txtTP_PlRate.Text + "',TP_PlCost='" + txtTP_PlCost.Text + "',TP_PlWsCnt='" + txtTP_PlWsCnt.Text + "',TP_PlWsAmt='" + txtTP_PlWsAmt + "',Ptve_ID='" + ddlPtve_ID.SelectedItem.ToString() + "',TP_Rate='" + txtTP_Rate.Text + "',TP_OS='" + txtTP_OS.Text + "',TP_CS='" + txtTP_CS.Text + "',TP_ReLev='" + txtTP_ReLev.Text + "',TP_Active='"+ddlTP_Active.Text+"' where TP_ID='" + txtTP_ID.Text + "'", con);
                //SqlCommand cmd = new SqlCommand("update TopPaper_Master set P_ID='" + ddlP_ID.Text + "',PQ_ID='" + ddlPQ_ID.SelectedValue.ToString() + "', TP_PPLgth='" + txtTP_PPLgth.Text + "',TP_PPWdth ='" + txtTP_PPWdth.Text + "',TP_PPBf ='" + txtTP_PPBf.Text + "',TP_PPGram='" + txtTP_PPGram.Text + "',TP_PPRate ='" + txtTP_PPRate.Text + "',TP_PPCost='" + txtTP_PPCost.Text + "',TP_LmLgth='" + txtTP_LmLgth.Text + "',TP_LmWdth='" + txtTP_LmWdth.Text + "',TP_LmRate='" + txtTP_LmRate.Text + "',TP_LmCost='" + txtTP_LmCost.Text + "',TP_LmType='" + ddlTP_LmType.SelectedValue.ToString() + "',TP_VrLgth='" + txtTP_VrLgth.Text + "',TP_VrWdth='" + txtTP_VrWdth.Text + "',TP_VrRate='" + txtTP_VrRate.Text + "',TP_VrCost='" + txtTP_VrCost.Text + "',TP_VrType='" + ddlTP_VrType.SelectedValue.ToString() + "',TP_PnColor='" + txtTP_PnColor.Text + "',TP_PnRate='" + txtTP_PnRate.Text + "',TP_PnCost='" + txtTP_PnCost.Text + "',TP_PlDivFact='"+ddlTP_PlDivFact.SelectedValue.ToString()+"', TP_PlNo='" + txtTP_PlNo.Text + "',TP_PlRate='" + txtTP_PlRate.Text + "',TP_PlCost='" + txtTP_PlCost.Text + "',TP_PlWsCnt='" + txtTP_PlWsCnt.Text + "',TP_PlWsAmt='" + txtTP_PlWsAmt + "',Ptve_ID='" + ddlPtve_ID.SelectedItem.ToString() + "',TP_Rate='" + txtTP_Rate.Text + "',TP_OS='" + txtTP_OS.Text + "',TP_CS='" + txtTP_CS.Text + "',TP_ReLev='" + txtTP_ReLev.Text + "',TP_Active='" + ddlTP_Active.Text + "' where TP_ID='" + txtTP_ID.Text + "'", con);


                SqlCommand cmd = new SqlCommand("update Purchase_Item set Grp_ID ='" + Group_ID + "', SI_MinLev='" + txtSI_MinLev.Text + "', SI_UOM='" + ddlSI_UOM.SelectedValue.ToString() + "',SI_Cate ='" + ddlSI_Cate.Text + "',SI_ExcCode ='" + txtSI_ExcCode.Text + "',SI_ExcDesc='" + txtSI_ExcDesc.Text + "',SI_ChapTarNo ='" + txtSI_ChapTarNo.Text + "',SI_Procesg='" + txtSI_Procesg.Text + "',SI_Active='" + ddlSI_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where SI_ID='" + txtSI_ID.Text + "'", con);


                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                filldata();
                //cmdSubmit.Enabled = true; ;
                //cmdEdit.Enabled = false;
                clearAll();
            }
            

        }
        private void clearAll()
        {
            txtSI_ID.Text = "";
            txtSI_Name.Text = "";
            ddlGrp_ID.Text = "";
            ddlSI_Cate.Text = "";
            txtSI_CuStock.Text = "";
            txtSI_ExcCode.Text = "";
            txtSI_ExcDesc.Text = "";
            txtSI_MinLev.Text = "";
            txtSI_Procesg.Text = "";
            ddlSI_Active.Text = "";
            ddlSI_UOM.Text = "";
            txtSI_ChapTarNo.Text = "";
            ddlSI_Active.SelectedText = "Yes";


        }

        

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from Purchase_Item where SI_Name like '%" + txtSearch.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterPurchaseItem.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select * from Purchase_Item where SI_Name like '%" + txtSearch.Text + "%'";
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        

        
    }

    
}
