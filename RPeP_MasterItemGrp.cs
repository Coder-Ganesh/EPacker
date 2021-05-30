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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

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
            btnDelete.Visible = false;
            ListName.Visible = false;
            txtIG_ID.Visible = false;
            ddlPB_ID.Enabled = false;
            filldata();
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
            //Displaying Active Values
            //Displaying value in Active field
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlIG_Active.DataSource = dtActive;
            ddlIG_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlIG_Active.ValueMember = dtActive.Columns[0].ToString();
            
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.P_ID, a.P_Name +' ( '+ b.PM_Name +')'  as  PName from Party_Master a, PartyMain_Master b where a.Grp_ID = '" + Group_ID + "' and a.PM_ID = b.PM_ID and a.P_Active='Yes'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GlobalFunctions.AddPleaseSelect(ref dt);
            ddlP_ID.DataSource = dt;
            ddlP_ID.DisplayMember = dt.Columns[1].ToString();
            ddlP_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();
            lstI_ID.DataSource = null;
        }

        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ddlP_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Filling ddl PartyBuyer On Selection of Party Name in Combo Box
            ddlPB_ID.Text = "";
            lstI_ID.DataSource = null;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("SELECT a.PB_ID,a.PB_Name from Party_Buyer as a,Party_Master as b where a.P_ID='" + ddlP_ID.SelectedValue.ToString() + "' and a.P_ID=b.P_ID and a.PB_Active='Yes'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    GlobalFunctions.AddPleaseSelect(ref dt);
                }
                ddlPB_ID.DataSource = dt;
                ddlPB_ID.DisplayMember = dt.Columns[1].ToString();
                ddlPB_ID.ValueMember = dt.Columns[0].ToString();
                ddlPB_ID.Enabled = true;
                con.Close();
            }
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
                        foreach (DataRowView drv in lstI_ID.SelectedItems)
                        {
                            // MessageBox.Show("My value: " + objDataRowView["id"].ToString());
                            ListName.Text += drv.Row[0].ToString().Trim().Replace("'", "''") + ","; // index in '[]' will vary
                            ListName.Text = ListName.Text.Substring(0, ListName.Text.Length - 1);
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
            ddlGrp_ID.Enabled = true;
            ddlP_ID.Enabled = true;
            ddlPB_ID.Enabled = false;
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
            SqlDataAdapter da = new SqlDataAdapter("select I_ID,I_Name from Item_Master where I_ID in (select I_ID from ItemGrp_Master where IG_ID='" + txtIG_ID.Text.ToString() + "')", con);
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
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            try
            {
                saveFileDialog1.InitialDirectory = "C:";
                saveFileDialog1.Title = "Save as Excel file";
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "Excel Files(2003) |*.xls|Excel Files(2007) |*.xlsx";
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        System.Data.DataTable table = dgwPartyBuyer.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Item Group Party Buyer Master");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwPartyBuyer.Columns.Count])
                        {
                            rng.Style.Font.Bold = true;
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }
                        FileInfo excelFile = new FileInfo(saveFileDialog1.FileName);
                        pck.SaveAs(excelFile);
                    }
                    MessageBox.Show("Data Exported Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while exporting excel  " + ex.Message);
            }
        }        

    }
}
