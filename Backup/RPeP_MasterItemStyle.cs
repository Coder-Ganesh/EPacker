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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

		 
	

namespace ePacker1
{
    public partial class RPeP_MasterItemStyle : Form
    {
        private FunctionLib funclib;
        private string imagename;
        string session, strSQL, Group_ID; 
        public RPeP_MasterItemStyle()
        {
            
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            cmdEdit.Enabled = false;
            filldata();
        }



        private void RPeP_MasterItemStyle_Load(object sender, EventArgs e)
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
            ddlStyle_Active.SelectedText = "Yes";
            ddlStyle_Active.Enabled = false;
            ddlStyle_Active.Items.Add("Yes");
            ddlStyle_Active.Items.Add("No");


        }

        private void txtRS_Length_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Length of RS
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRS_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Width of RS
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRS_Height_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Height of RS
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRS_Pinning_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating Pinning of RS
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtRS_Param1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating RS Param_1
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRS_Param2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating RS Param_2
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRS_Param3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating RS Param_3
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Length_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Length
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Width
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Height_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Height
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Pinning_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Printing
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Param1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Param1
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Param2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Param2
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCS_Param3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating CS Param3
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {

            if (txtStyle_No.Text == "")//checking for blank Group_ID combo field 
            {
                MessageBox.Show("Please Enter Style No");
                txtStyle_No.Focus();

            }


            else if (txtImage_Sheet.Text == "")//checking for Image Sheet
            {
                MessageBox.Show("Please Browse path for Sheet Image");
                txtImage_Sheet.Focus();
            }
            else if (txtImage_Box.Text == "")//checking for Image Box 
            {
                MessageBox.Show("Please Browse path for Box Image");
                txtImage_Box.Focus();
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
                    double flag = funclib.isThere(con, "select Grp_ID,Style_No from Item_Style_Master where Grp_ID='" + Group_ID + "'and Style_No='" + txtStyle_No.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group and Style No combination is not allowed");

                    }
                    else
                    {
                        //Inserting Details into table Item_Style_Master
                        string path1 = txtImage_Sheet.Text;
                        string path2 = txtImage_Box.Text;
                        FileStream fsSheetImage = new FileStream(@path1,FileMode.Open,FileAccess.Read);
                        FileStream fsBoxImage = new FileStream(@path2, FileMode.Open, FileAccess.Read);
                        byte[] picbyte = new byte[fsSheetImage.Length];
                        fsSheetImage.Read(picbyte, 0, System.Convert.ToInt32(fsSheetImage.Length));
                        fsSheetImage.Close();
                        byte[] picbyte1 = new byte[fsBoxImage.Length];
                        fsBoxImage.Read(picbyte1, 0, System.Convert.ToInt32(fsBoxImage.Length));
                        fsBoxImage.Close();

                        SqlParameter picparameter1 = new SqlParameter();
                        picparameter1.SqlDbType = SqlDbType.Image;
                        picparameter1.ParameterName = "Image_Sheet";
                        picparameter1.Value = picbyte;

                        SqlParameter picparameter2 = new SqlParameter();
                        picparameter2.SqlDbType = SqlDbType.Image;
                        picparameter2.ParameterName = "Image_Box";
                        picparameter2.Value = picbyte1;
                       



                        string sid = funclib.AutoKey1("ST", con, "select Style_ID from Item_Style_Master order by Style_ID desc");
                        SqlCommand cmd = new SqlCommand("insert into Item_Style_Master values('" + sid + "','" + Group_ID + "','" + txtStyle_No.Text.Trim().Replace("'", "''").ToString() + "','" + txtParam_1.Text.Trim().Replace("'", "''").ToString() + "','" + txtParam_2.Text.Trim().Replace("'", "''").ToString() + "','" + txtParam_3.Text.Trim().Replace("'", "''").ToString() + "','" + txtRS_Length.Text.Trim().Replace("'", "''").ToString() + "','" + txtRS_Width.Text.Trim().Replace("'", "''").ToString() + "','" + txtRS_Height.Text.Trim().Replace("'", "''").ToString() + "','" + txtRS_Pinning.Text.Trim().Replace("'", "''").ToString() + "','" + txtRS_Param1.Text.Trim().Replace("'", "''").ToString() + "','" + txtRS_Param2.Text.Trim().Replace("'", "''").ToString() + "','" + txtRS_Param3.Text.Trim().Replace("'", "''").ToString() + "','" + txtCS_Length.Text.Trim().Replace("'", "''").ToString() + "','" + txtCS_Width.Text.Trim().Replace("'", "''").ToString() + "','" + txtCS_Height.Text.Trim().Replace("'", "''").ToString() + "','" + txtCS_Pinning.Text.Trim().Replace("'", "''").ToString() + "','" + txtCS_Param1.Text.Trim().Replace("'", "''").ToString() + "','" + txtCS_Param2.Text.Trim().Replace("'", "''").ToString() + "','" + txtCS_Param3.Text.Trim().Replace("'", "''").ToString() + "',@Image_Sheet,@Image_Box,'" + ddlStyle_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        cmd.Parameters.Add(picparameter1);
                        cmd.Parameters.Add(picparameter2);

                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        filldata();
                        clearAll();

                    }
                }

            }
        }

        private void cmdImage_Sheet_Click(object sender, EventArgs e)
        {
            //Browse the Sheet Image
            FileDialog flSheetImage = new OpenFileDialog();
            flSheetImage.Filter = "ImageFile(*.jpg)|*.jpg";
            if (flSheetImage.ShowDialog() == DialogResult.OK)
            {
                string strImg = flSheetImage.FileName;
                txtImage_Sheet.Text = strImg;
                
                

            }

        }
        private void filldata()
        {
            //to fill the Datagridview with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select a.Style_ID,b.Grp_Name as GroupName,a.Style_No as StyleNo,a.Param_1 as Parameter1,a.Param_2 as Parameter2,a.Param_3 as Parameter3,a.RS_Length as ReelLength,a.RS_Width as ReelWidth,a.RS_Height as ReelHeight,a.RS_Pinning as ReelPrinting,a.RS_Param1 as ReelParameter1,a.RS_Param2 as ReelParameter2,a.RS_Param3 as ReelParameter3,a.CS_Length as CutLength,a.CS_Width  as CutWidth,a.CS_Height as CutHeight,a.CS_Pinning as Printing,a.CS_Param1 as Parameter1,a.CS_Param2 as Parameter2,a.CS_Param3 as Parameter3,a.Image_Sheet as SheetImage,a.Image_Box as BoxImage,a.Style_Active from Item_Style_Master a,Group_Master b where a.Grp_ID=b.Grp_ID", con);
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            da.Fill(dt);
            bindingSource1.DataSource = dt;
            //dgwMasterItemStyle.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dgwMasterItemStyle.DataSource = bindingSource1;
            this.dgwMasterItemStyle.Columns[0].Visible = false;

            



            
 

        }

        private void cmdBox_Image_Click(object sender, EventArgs e)
        {
            //Browse the Box Image
            FileDialog flSheetImage = new OpenFileDialog();
            flSheetImage.Filter = "ImageFile(*.jpg)|*.jpg";
            if (flSheetImage.ShowDialog() == DialogResult.OK)
            {
                string strImg = flSheetImage.FileName;
                txtImage_Box.Text = strImg;
            }

        }

        private void dgwMasterItemStyle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //MessageBox.Show(e.Context.ToString());

             if (e.Context == DataGridViewDataErrorContexts.Commit) 
            {
       
                MessageBox.Show("Commit error");
            }

            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }

   
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
       
                 MessageBox.Show("parsing error");
            }
   
            if (e.Context==DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

   


        }

        private void dgwMasterItemStyle_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //to display data in form on click of datagridview named dgwMasterItemStyle
            txtStyle_No.Enabled = false;

            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlStyle_Active.Enabled = true; 

            txtStyle_ID.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[0].Value.ToString();
           // ddlGrp_ID.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtStyle_No.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtParam_1.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtParam_2.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtParam_3.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtRS_Length.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtRS_Width.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtRS_Height.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtRS_Pinning.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtRS_Param1.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtRS_Param2.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtRS_Param3.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtCS_Length.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtCS_Width.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtCS_Height.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtCS_Pinning.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[16].Value.ToString();
            txtCS_Param1.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtCS_Param2.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtCS_Param3.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[19].Value.ToString();
            ddlStyle_Active.Text = dgwMasterItemStyle.Rows[e.RowIndex].Cells[22].Value.ToString();




        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Item_Style_Master set Grp_ID ='" + Group_ID + "',Param_1 ='" + txtParam_1.Text + "',Param_2='" + txtParam_2.Text + "',Param_3='" + txtParam_3.Text + "',RS_Length='" + txtRS_Length.Text + "',RS_Width='" + txtRS_Width.Text + "',RS_Height='" + txtRS_Height.Text + "',RS_Pinning='" + txtRS_Pinning.Text + "',RS_Param1='" + txtRS_Param1.Text + "',RS_Param2='" + txtRS_Param2.Text + "',RS_Param3='" + txtRS_Param3.Text + "',CS_Length='" + txtCS_Length.Text + "',CS_Width='" + txtCS_Width.Text + "',CS_Height='" + txtCS_Height.Text + "',CS_Pinning='" + txtCS_Pinning.Text + "',CS_Param1='" + txtCS_Param1.Text + "',CS_Param2='" + txtCS_Param2.Text + "',CS_Param3='" + txtCS_Param3.Text + "',Style_Active='" + ddlStyle_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Style_ID='" + txtStyle_ID.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                filldata();
                clearAll();
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //Clearing all fields & refreshes the MasterItemStyle form
            clearAll();
        }

        private void clearAll()
        {
            //Code for Clearing all form fields.

            ddlGrp_ID.Text = "";
            txtStyle_ID.Clear();
            txtStyle_No.Clear();
            txtParam_1.Clear();
            txtParam_2.Clear();
            txtParam_3.Clear();
            txtRS_Length.Clear();
            txtRS_Width.Clear();
            txtRS_Height.Clear();
            txtRS_Pinning.Clear();
            txtRS_Param1.Clear();
            txtRS_Param2.Clear();
            txtRS_Param3.Clear();
            txtCS_Length.Clear();
            txtCS_Width.Clear();
            txtCS_Height.Clear();
            txtCS_Pinning.Clear();
            txtCS_Param1.Clear();
            txtCS_Param2.Clear();
            txtCS_Param3.Clear();
            txtImage_Sheet.Clear();
            txtImage_Box.Clear();

            txtStyle_No.Enabled = true;

            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;
            ddlStyle_Active.Enabled = false;
            

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select b.Grp_Name as GroupName,a.Style_No as StyleNo,a.Param_1 as Parameter1,a.Param_2 as Parameter2,a.Param_3 as Parameter3,a.RS_Length as ReelLength,a.RS_Width as ReelWidth,a.RS_Height as ReelHeight,a.RS_Pinning as ReelPrinting,a.RS_Param1 as ReelParameter1,a.RS_Param2 as ReelParameter2,a.RS_Param3 as ReelParameter3,a.CS_Length as CutLength,a.CS_Width  as CutWidth,a.CS_Height as CutHeight,a.CS_Pinning as Printing,a.CS_Param1 as Parameter1,a.CS_Param2 as Parameter2,a.CS_Param3 as Parameter3,a.Image_Sheet as SheetImage,a.Image_Box as BoxImage,a.Style_Active from Item_Style_Master a,Group_Master b where a.Style_No like '%" + txtStyle_No_Search.Text + "%' and a.Grp_ID=b.Grp_ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bindingSource1.DataSource = dt;
            dgwMasterItemStyle.DataSource = bindingSource1;


            if (dgwMasterItemStyle.Rows.Count == 0)
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
            //Code to close MasterItemStyle form temporarily.
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterItemStyle.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select b.Grp_Name as GroupName,a.Style_No as StyleNo,a.Param_1 as Parameter1,a.Param_2 as Parameter2,a.Param_3 as Parameter3,a.RS_Length as ReelLength,a.RS_Width as ReelWidth,a.RS_Height as ReelHeight,a.RS_Pinning as ReelPrinting,a.RS_Param1 as ReelParameter1,a.RS_Param2 as ReelParameter2,a.RS_Param3 as ReelParameter3,a.CS_Length as CutLength,a.CS_Width  as CutWidth,a.CS_Height as CutHeight,a.CS_Pinning as Printing,a.CS_Param1 as Parameter1,a.CS_Param2 as Parameter2,a.CS_Param3 as Parameter3,a.Image_Sheet as SheetImage,a.Image_Box as BoxImage,a.Style_Active from Item_Style_Master a,Group_Master b where a.Style_No like '%" + txtStyle_No_Search.Text + "%' and a.Grp_ID=b.Grp_ID";
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
