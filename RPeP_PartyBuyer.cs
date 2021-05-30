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
using ePacker1.Business_Logic;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace ePacker1
{
    public partial class RPeP_PartyBuyer : Form
    {
        string session, strSQL, Group_ID;  
        private FunctionLib funclib;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_PartyBuyer()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            filldata();
            txtPB_ID.Visible = false;
            cmdEdit.Visible = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;           
        }

        private void RPeP_PartyBuyer_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                funclib = new FunctionLib();
                string strCon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strCon);

                // Displaying values in ddlPM_ID_Search combo box
                con1.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT  a.P_ID, a.P_Name +' ( '+ b.PM_Name +')'  as Name from Party_Master a, PartyMain_Master b where a.PM_ID = b.PM_ID and a.P_Active='Yes'", con1);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                GlobalFunctions.AddPleaseSelect(ref dt2);
                ddlP_ID_Search.DataSource = dt2;
                ddlP_ID_Search.DisplayMember = dt2.Columns[1].ToString();
                ddlP_ID_Search.ValueMember = dt2.Columns[0].ToString();
                con1.Close();

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("SELECT a.P_ID, a.P_Name +' ( '+ b.PM_Name +')'  as  PName from Party_Master a, PartyMain_Master b where a.Grp_ID = '" + Group_ID + "' and a.PM_ID = b.PM_ID and a.P_Active='Yes'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GlobalFunctions.AddPleaseSelect(ref dt);
                ddlP_ID.DataSource = dt;
                ddlP_ID.DisplayMember = dt.Columns[1].ToString();
                ddlP_ID.ValueMember = dt.Columns[0].ToString();
                con.Close();

                //Displaying Active Values
                DataTable dtActive = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActive);
                ddlPB_Active.DataSource = dtActive;
                ddlPB_Active.DisplayMember = dtActive.Columns[0].ToString();
                ddlPB_Active.ValueMember = dtActive.Columns[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading the page " + ex.Message);
            }
        }
        
        private void txtPB_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating PB_Name Text Field
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);            
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

            else if (txtPB_Name.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Please Enter Name");
                txtPB_Name.Focus();
            }
            else if (txtPB_Phone.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Enter Phone No");
                txtPB_Phone.Focus();

            }
            else if (ddlPB_Active.Text == "")
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
                    double flag = funclib.isThere(con, "select PB_Name,P_ID,Grp_ID  from Party_Buyer where Grp_ID='" + Group_ID + "' and P_ID='" + ddlP_ID.Text + "' and PB_Name='" + txtPB_Name.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Group, Agent and Positive Name is not allowed");
                    }
                    else
                    {
                        //Inserting records in Positive_Master
                        txtPB_Name.Text = funclib.FirstCap(txtPB_Name.Text);
                        string PBid = funclib.AutoKey1("PB", con, "select PB_ID from Party_Buyer order by PB_ID desc");
                        txtPB_ID.Text = PBid;
                        SqlCommand cmdPositive = new SqlCommand("insert into Party_Buyer(PB_ID,Grp_ID,P_ID,PB_Name,PB_Phone,PB_Mobile,PB_Email,PB_Active,Add_By,Add_ByNode,Add_On) values('" + txtPB_ID.Text.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "','" + ddlP_ID.SelectedValue.ToString() + "','" + txtPB_Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtPB_Phone.Text.Trim().Replace("'", "''").ToString() + "','" + txtPB_Mobile.Text.Trim().Replace("'", "''").ToString() + "','" + txtPB_Email.Text.Trim().Replace("'", "''").ToString() + "','" + ddlPB_Active.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
                        con.Open();
                        int Positive = cmdPositive.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted in Party_Buyer");
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
           
        private void clearAll()
        {
            //Clearing form data
            txtPB_ID.Clear();
            ddlGrp_ID.Text = "";
            ddlP_ID.Text = "";
            txtPB_Email.Clear();
            txtPB_Mobile.Clear();
            txtPB_Name.Clear();
            txtPB_Name_Search.Clear();
            txtPB_Phone.Clear();
            ddlGrp_ID.Enabled = true;
            ddlP_ID.Enabled = true;
            cmdEdit.Visible = false;
            cmdEdit.Visible = false;
            cmdSubmit.Visible = true;
            btnDelete.Visible = false;
            ddlPB_Active.SelectedIndex = 0;
            ddlP_ID.SelectedIndex = 0;
            ddlP_ID_Search.SelectedIndex = 0;
        }

        private void filldata()
        {
            try
            {
                //to fill the grid with user details
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select c.PB_ID, (d.Grp_SName +' ('+ d.Grp_Name +')') as Grp_Data, a.P_Name +' ( '+ b.PM_Name +')'  as Party,c.PB_Name as Buyer,c.PB_Phone as TelePhone,c.PB_Mobile as Mobile,c.PB_Email as Email,c.PB_Active as Active,  c.Add_By,c.Add_On,c.Mod_By,c.Mod_On from Party_Master a, PartyMain_Master b,Party_Buyer as c,Group_Master as d  where  a.PM_ID = b.PM_ID and a.P_ID=c.P_ID and  c.Grp_ID=d.Grp_ID and a.P_Active='Yes' order by a.P_Name, c.PB_Name", con4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgwPartyBuyer.DataSource = dt;
                this.dgwPartyBuyer.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading Grid " + ex.Message);
            }
        }

        private void dgwPartyBuyer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Visible = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Visible = false;            
            ddlPB_Active.Enabled = true;
            ddlGrp_ID.Enabled = false;
            ddlP_ID.Enabled = false;
            txtPB_ID.Text = dgwPartyBuyer.Rows[e.RowIndex].Cells[0].Value.ToString();
            ddlP_ID.Text = dgwPartyBuyer.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPB_Name.Text = dgwPartyBuyer.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPB_Phone.Text = dgwPartyBuyer.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPB_Mobile.Text = dgwPartyBuyer.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPB_Email.Text = dgwPartyBuyer.Rows[e.RowIndex].Cells[6].Value.ToString();
            ddlPB_Active.SelectedValue = dgwPartyBuyer.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Code to close Master Party form temporarily
            this.Close();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //Update data in table
                if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtPB_Name.Text = funclib.FirstCap(txtPB_Name.Text);
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Party_Buyer set PB_Name ='" + txtPB_Name.Text + "',PB_Phone='" + txtPB_Phone.Text + "',PB_Mobile ='" + txtPB_Mobile.Text + "',PB_Email ='" + txtPB_Email.Text + "',PB_Active ='" + ddlPB_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where PB_ID='" + txtPB_ID.Text.Trim().Replace("'", "''").ToString() + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                    filldata();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while Editing Values " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Update data in table
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtPB_Name.Text = funclib.FirstCap(txtPB_Name.Text);
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Party_Buyer  where PB_ID='" + txtPB_ID.Text.Trim().Replace("'", "''").ToString() + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted");
                    filldata();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while Deleting Values " + ex.Message);
            }
        }

        private void cmd_PB_Name_Search_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter(" select c.PB_ID, (d.Grp_SName +' ('+ d.Grp_Name +')') as Grp_Data, a.P_Name +' ( '+ b.PM_Name +')'  as Party,c.PB_Name as Buyer,c.PB_Phone as TelePhone,c.PB_Mobile as Mobile,c.PB_Email as Email,c.PB_Active as Active from Party_Master a, PartyMain_Master b,Party_Buyer as c,Group_Master as d  where c.P_ID='" + ddlP_ID_Search.SelectedValue.ToString() + "' and  a.PM_ID = b.PM_ID and a.P_ID=c.P_ID and  c.Grp_ID=d.Grp_ID and a.P_Active='Yes' order by a.P_Name, c.PB_Name", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwPartyBuyer.DataSource = dt;
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
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Party Buyer Master");
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

