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
    public partial class RPeP_MasterItemGrp : Form
    {
        string session, strSQL, Group_ID;
        private FunctionLib funclib;
        string strList;
        public RPeP_MasterItemGrp()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            
            cmdEdit.Visible = false;
            ListName.Visible = false;
            txtIG_ID.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RPeP_MasterItemGrp_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strCon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strCon);
            //con1.Open();


            ////Displayig Group Name in Combo field

            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='Yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();

            //ddlGrp_ID.Text = "";


            //// Displaying values in ddlPM_ID_Search combo box
            //con1.Open();
            //SqlDataAdapter da2 = new SqlDataAdapter("select  a.P_ID, a.P_Name +' ( '+ b.PM_Name +')'  as Name from Party_Master a, PartyMain_Master b where a.PM_ID = b.PM_ID and a.P_Active='Yes'", con1);
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            //ddlP_ID_Search.DataSource = dt2;
            //ddlP_ID_Search.DisplayMember = dt2.Columns[1].ToString();
            //ddlP_ID_Search.ValueMember = dt2.Columns[0].ToString();
            //con1.Close();


            //Displaying Active Values
            ddlIG_Active.SelectedText = "Yes";
            ddlIG_Active.Enabled = false;
            ddlIG_Active.Items.Add("Yes");
            ddlIG_Active.Items.Add("No");

            ddlP_ID.Text = "";

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select '' as P_ID, '' as P_Name union select  a.P_ID, a.P_Name +' ( '+ b.PM_Name +')'  as  PName from Party_Master a, PartyMain_Master b where a.Grp_ID = '" + Group_ID + "' and a.PM_ID = b.PM_ID and a.P_Active='Yes'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlP_ID.DataSource = dt;
            ddlP_ID.DisplayMember = dt.Columns[1].ToString();
            ddlP_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();

            //ddlP_ID.Text = "";
            //ddlPB_ID.Text = "";
           lstI_ID.DataSource = null;

        }

        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Filling ddl Party On Selection of Group Name in Combo Box

            //ddlP_ID.Text = "";

            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            //SqlConnection con = new SqlConnection(strcon);
            //SqlDataAdapter da = new SqlDataAdapter("select  a.P_ID, a.P_Name +' ( '+ b.PM_Name +')'  as  PName from Party_Master a, PartyMain_Master b where a.Grp_ID = '" + Group_ID + "' and a.PM_ID = b.PM_ID and a.P_Active='Yes'", con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlP_ID.DataSource = dt;
            //ddlP_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlP_ID.ValueMember = dt.Columns[0].ToString();
            //con.Close();

            //ddlP_ID.Text = "";
            //ddlPB_ID.Text = "";
            //lstI_ID.DataSource = null;
        }

        private void ddlP_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Filling ddl PartyBuyer On Selection of Party Name in Combo Box


            ddlPB_ID.Text = "";
            lstI_ID.DataSource = null;         
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as PB_ID, '' as PB_Name UNION select a.PB_ID,a.PB_Name from Party_Buyer as a,Party_Master as b where a.P_ID='" + ddlP_ID.SelectedValue.ToString() + "' and a.P_ID=b.P_ID and a.PB_Active='Yes'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlPB_ID.DataSource = dt;
            ddlPB_ID.DisplayMember = dt.Columns[1].ToString();
            ddlPB_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();

            //ddlPB_ID.Text = "";
            //lstI_ID.DataSource = null;    
        }

        private void ddlPB_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Filling list itm On Selection of PartyBuyer Name in Combo Box

            
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as I_ID, '' as I_Name UNION select I_ID,I_Name from Item_Master where Grp_ID='" + Group_ID + "' and PB_ID='" + ddlPB_ID.SelectedValue.ToString() + "' and P_ID='" + ddlP_ID.SelectedValue.ToString() + "' and I_Active='Yes'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lstI_ID.DataSource = dt;
            lstI_ID.DisplayMember = dt.Columns[1].ToString();
            lstI_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();
         
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();


            //}
           if (ddlP_ID.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Please Select Party");
                ddlP_ID.Focus();
            }

            else if (ddlPB_ID.Text == "")//checking for PartyBuyerName text field 
            {
                MessageBox.Show("Please Select Party Buyer");
                ddlPB_ID.Focus();
            }
            else if (txtIG_Name.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Enter Group Name");
                txtIG_Name.Focus();

            }
            else if (lstI_ID.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Please Select Item");
                lstI_ID.Focus();
            }
            else if (ddlIG_Active.Text == "")
            {
                MessageBox.Show("Please select Active field");
            }


            else
            {


                funclib = new FunctionLib();
                //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //Checking for duplicate values
                    double flag = funclib.isThere(con, "select IG_Name,Grp_ID,P_ID,PB_ID from ItemGrp_Master where  IG_Name='" + txtIG_Name.Text + "' and Grp_ID='" + Group_ID + "' and P_ID='" + ddlP_ID.SelectedValue.ToString() + "' and PB_ID='" + ddlPB_ID.SelectedValue.ToString() + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group Name is not allowed");
                    }
                    else
                    {
                        //Inserting records in ItemGrp_Master

                        

                        string PBid = funclib.SI_ID("IG", con, "select IG_ID from ItemGrp_Master order by IG_ID desc");
                        txtIG_ID.Text = PBid;



                        //for (int i = 0; i < lstI_ID.SelectedItems.Count; i++)
                        //{
                        //    SqlCommand cmdPositive = new SqlCommand("insert into ItemGrp_Master(IG_ID,Grp_ID,P_ID,PB_ID,IG_Name,I_ID,IG_Active,Add_By,Add_ByNode,Add_On) values('" + txtIG_ID.Text.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "','" + ddlP_ID.SelectedValue.ToString() + "','" + ddlPB_ID.SelectedValue.ToString() + "','" + txtIG_Name.Text.Trim().Replace("'", "''").ToString() + "','" + lstI_ID.SelectedValue.ToString() + "','" + ddlIG_Active.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
                        //    con.Open();
                        //    int Positive = cmdPositive.ExecuteNonQuery();
                        //    con.Close();

                            
                        //}
                        //string retval = "";
                        foreach (DataRowView drv in lstI_ID.SelectedItems)
                        {
                            // MessageBox.Show("My value: " + objDataRowView["id"].ToString());

                            ListName.Text += drv.Row[0].ToString().Trim().Replace("'", "''") + ","; // index in '[]' will vary

                            ListName.Text = ListName.Text.Substring(0,ListName.Text.Length - 1);

                            SqlCommand cmdPositive = new SqlCommand("insert into ItemGrp_Master(IG_ID,Grp_ID,P_ID,PB_ID,IG_Name,I_ID,IG_Active,Add_By,Add_ByNode,Add_On) values('" + txtIG_ID.Text.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "','" + ddlP_ID.SelectedValue.ToString() + "','" + ddlPB_ID.SelectedValue.ToString() + "','" + txtIG_Name.Text.Trim().Replace("'", "''").ToString() + "','" + ListName.Text.ToString() + "','" + ddlIG_Active.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
                            con.Open();
                            int Positive = cmdPositive.ExecuteNonQuery();
                            con.Close();
                            ListName.Text = "";
                        }


                    

                        MessageBox.Show("Record Successfully Inserted ");
                        con.Close();
                        filldata();
                       clearAll();

                    }
                }
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

            //Update data in table
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("update ItemGrp_Master set IG_Active ='" + ddlIG_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where IG_ID='" + txtIG_ID.Text.Trim().Replace("'", "''").ToString() + "'", con);                                        
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                filldata();
                clearAll();
            }
        }

        private void clearAll()
        {
            //Clearing form data
            txtIG_ID.Clear();
            ddlGrp_ID.Text = "";
            ddlP_ID.Text = "";
            ddlPB_ID.Text = "";
            lstI_ID.DataSource = null;
            txtIG_Name.Clear();
          
            //ddlPB_Active.Text="";
            ddlGrp_ID.Enabled = true;
            ddlP_ID.Enabled = true;
            ddlPB_ID.Enabled = true;
            lstI_ID.Enabled = true;
            ddlIG_Active.Text = "";
            cmdEdit.Visible = false;
            cmdSubmit.Visible = true;
            ddlIG_Active.SelectedText = "Yes";
            ddlIG_Active.Enabled = false;
            txtIG_Name.Enabled = true;
 
        }

        private void filldata()
        {
            //to fill the grid with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            //SqlDataAdapter da = new SqlDataAdapter("select  a.Grp_ID, a.P_Name +' ( '+ b.PM_Name +')'  as Party,c.PB_Name as Buyer,c.PB_Phone as TelePhone,c.PB_Mobile as Mobile,c.PB_Email as Email,c.PB_Active as Active from Party_Master a, PartyMain_Master b,Party_Buyer as c where  a.PM_ID = b.PM_ID and a.Grp_ID=c.Grp_ID and a.P_Active='Yes'", con4);
            //SqlDataAdapter da = new SqlDataAdapter("select  (d.Grp_SName +' ('+ d.Grp_Name +')') as Grp_Data, a.P_Name +' ( '+ b.PM_Name +')'  as Party,c.PB_Name as Buyer,c.PB_Phone as TelePhone,c.PB_Mobile as Mobile,c.PB_Email as Email,c.PB_Active as Active from Party_Master a, PartyMain_Master b,Party_Buyer as c,Group_Master as d  where  a.PM_ID = b.PM_ID and a.Grp_ID=c.Grp_ID and  c.Grp_ID=d.Grp_ID and a.P_Active='Yes'", con4);

            SqlDataAdapter da = new SqlDataAdapter(" select distinct c.IG_ID, c.IG_Name, (d.Grp_SName +' ('+ d.Grp_Name +')') as Grp_Data, a.P_Name, a.P_Name +' ( '+ b.PM_Name +')'  as Party,c.IG_Active as Active from Party_Master a, PartyMain_Master b,ItemGrp_Master as c,Group_Master as d where   a.PM_ID = b.PM_ID and a.P_ID=c.P_ID and  c.Grp_ID=d.Grp_ID and  a.P_Active='Yes' order by a.P_Name, c.IG_Name", con4);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwPartyBuyer.DataSource = dt;
            this.dgwPartyBuyer.Columns[0].Visible = false;

        }

        private void dgwPartyBuyer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Visible = true;
            cmdSubmit.Visible = false;
            ddlIG_Active.Enabled = true;
            ddlGrp_ID.Enabled = false;
            ddlP_ID.Enabled = false;
            ddlPB_ID.Enabled = false;
            txtIG_Name.Enabled = false;

            lstI_ID.Enabled = false;


            txtIG_ID.Text = dgwPartyBuyer.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtIG_Name.Text = dgwPartyBuyer.Rows[e.RowIndex].Cells[1].Value.ToString();
           // ddlGrp_ID.Text = dgwPartyBuyer.Rows[e.RowIndex].Cells[2].Value.ToString();
            ddlP_ID.Text = dgwPartyBuyer.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlPB_ID.Text = dgwPartyBuyer.Rows[e.RowIndex].Cells[4].Value.ToString();        
            ddlIG_Active.SelectedValue = dgwPartyBuyer.Rows[e.RowIndex].Cells[5].Value.ToString();

            //string strcon = funclib.setConnection();
            //SqlConnection con = new SqlConnection(strcon);
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select b.I_Name from ItemGrp_Master as a,Item_Master as b where  a.IG_ID='" + txtIG_ID.Text + "' and a.Grp_ID='" + Group_ID + "' and a.P_ID='" + ddlP_ID.SelectedValue.ToString() + "' and a.PB_ID='" + ddlPB_ID.SelectedValue.ToString() + "' and a.I_ID=b.I_ID ", con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //     strList = Convert.ToString(dr["I_Name"]);
            //     //strList = dgwPartyBuyer.Rows[e.RowIndex].Cells[6].Value.ToString();
            //     //lstI_ID.Text = strList;
            //     //strList = dgwPartyBuyer.Rows[e.RowIndex].Cells[6].Value.ToString();


            //}

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select I_ID,I_Name from Item_Master where I_ID in (select I_ID from ItemGrp_Master where IG_ID='"+txtIG_ID.Text.ToString()+"')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lstI_ID.DataSource = dt;
            lstI_ID.DisplayMember = dt.Columns[1].ToString();
            lstI_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();
            
            
            
            
            
        }

        private void cmd_PB_Name_Search_Click(object sender, EventArgs e)
        {
            //to fill the grid with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            //SqlDataAdapter da = new SqlDataAdapter("select  a.Grp_ID, a.P_Name +' ( '+ b.PM_Name +')'  as Party,c.PB_Name as Buyer,c.PB_Phone as TelePhone,c.PB_Mobile as Mobile,c.PB_Email as Email,c.PB_Active as Active from Party_Master a, PartyMain_Master b,Party_Buyer as c where  a.PM_ID = b.PM_ID and a.Grp_ID=c.Grp_ID and a.P_Active='Yes'", con4);
            //SqlDataAdapter da = new SqlDataAdapter("select  (d.Grp_SName +' ('+ d.Grp_Name +')') as Grp_Data, a.P_Name +' ( '+ b.PM_Name +')'  as Party,c.PB_Name as Buyer,c.PB_Phone as TelePhone,c.PB_Mobile as Mobile,c.PB_Email as Email,c.PB_Active as Active from Party_Master a, PartyMain_Master b,Party_Buyer as c,Group_Master as d  where  a.PM_ID = b.PM_ID and a.Grp_ID=c.Grp_ID and  c.Grp_ID=d.Grp_ID and a.P_Active='Yes'", con4);
            SqlDataAdapter da = new SqlDataAdapter(" select distinct c.IG_ID, c.IG_Name, (d.Grp_SName +' ('+ d.Grp_Name +')') as Grp_Data, a.P_Name +' ( '+ b.PM_Name +')'  as Party,e.PB_Name,c.IG_Active as Active from Party_Master a, PartyMain_Master b,ItemGrp_Master as c,Group_Master as d,Party_Buyer as e where c.IG_Name like '%" + txtPB_Name_Search.Text + "%' and  a.PM_ID = b.PM_ID and a.P_ID=c.P_ID and  c.Grp_ID=d.Grp_ID and c.PB_ID=e.PB_ID and   a.P_Active='Yes' order by  c.IG_Name", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwPartyBuyer.DataSource = dt;
            this.dgwPartyBuyer.Columns[0].Visible = false;
            this.dgwPartyBuyer.Columns[4].Visible = false;

            if (dgwPartyBuyer.Rows.Count == 0)
            {

                cmdExcelReport.Visible = false;
            }

            else
            {
                cmdExcelReport.Visible = true;
            }


            //this.dgwPartyBuyer.Columns[6].Visible = false;
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "MasterItemGrp.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + " select distinct c.IG_ID, c.IG_Name, (d.Grp_SName +' ('+ d.Grp_Name +')') as Grp_Data, a.P_Name +' ( '+ b.PM_Name +')'  as Party,e.PB_Name,c.IG_Active as Active from Party_Master a, PartyMain_Master b,ItemGrp_Master as c,Group_Master as d,Party_Buyer as e where c.IG_Name like '%" + txtPB_Name_Search.Text + "%' and  a.PM_ID = b.PM_ID and a.P_ID=c.P_ID and  c.Grp_ID=d.Grp_ID and c.PB_ID=e.PB_ID and   a.P_Active='Yes' order by  c.IG_Name";
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
