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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using System.Diagnostics;
using iTextSharp.text.pdf.draw;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ePacker1
{
    public partial class RPeP_DispForm57F4 : Form
    {
        string session, strSQL, Group_ID, Sr_No;
        string P_Name, P_ID, P_PONo, P_PODt, Box_Qty, PQ_ID;
        string griOrder_ID, griPartyPono, griPartoPoDt, griP_Name, strOpenDoc, Grp_Name;
        private FunctionLib funclib;

        public RPeP_DispForm57F4()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_DispForm57F4_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                //Displaying Active Values
                cmdEdit.Enabled = false;
                cmdEdit.Visible = false;
                btnDelete.Visible = false;
                cmdSubmit.Enabled = true;
                ddlActive.Enabled = false;
                ddlActive.Items.Add("Yes");
                ddlActive.Items.Add("No");
                ddlActive.Text = "Yes";
                monthCalendar1.Visible = false;
                monthCalendar2.Visible = false;

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                Sr_No = funclib.SR_No("57F", con, "select Sr_No  from Dispatch_Form57F4 order by Sr_No   desc");
                txtSr_No.Text = Sr_No;

                ddlSearch.Items.Add("");
                ddlSearch.Items.Add("Sr.No.");
                ddlSearch.Items.Add("Form Date");
                ddlSearch.Items.Add("Party");
                ddlSearch.Items.Add("Order No.");
                ddlSearch.Items.Add("Product");
                ddlSearch.Items.Add("Qty.");
                ddlSearch.Items.Add("Amt.");

                BindParty();
                BindPaperQuality();
                BindOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Loading form " + ex.Message);
            }
        }

        private void txtForm_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtForm_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtForm_Dt.Focus();
        }

        private void cmdP_IDSearch_Click(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                SqlDataAdapter da = new SqlDataAdapter("SELECT '' as P_ID, '' as P_Name UNION select  a.P_ID, a.P_Name  as  PName from Party_Master a where  a.Grp_ID = '" + Group_ID + "' and a.P_Name like '%" + txtP_IDSearch.Text.Trim().ToString() + "%' and a.P_Active='Yes'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Open();
                ddlP_ID.DataSource = dt;
                ddlP_ID.DisplayMember = dt.Columns[1].ToString();
                ddlP_ID.ValueMember = dt.Columns[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Party search " + ex.Message);
            }
        }

        private void BindParty()
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                SqlDataAdapter da = new SqlDataAdapter("SELECT '' as P_ID, '' as P_Name UNION select  a.P_ID, a.P_Name  as  PName from Party_Master a where  a.Grp_ID = '" + Group_ID + "' and a.P_Active='Yes'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Open();
                ddlP_ID.DataSource = dt;
                ddlP_ID.DisplayMember = dt.Columns[1].ToString();
                ddlP_ID.ValueMember = dt.Columns[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Loading Party " + ex.Message);
            }
        }

        private void CmdPQ_IDSearch_Click(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                SqlDataAdapter da = new SqlDataAdapter("SELECT '' as PQ_ID, '' as PQ_Desc UNION select  a.PQ_ID, a.PQ_Desc  from PQuality_Master a where  a.Grp_ID = '" + Group_ID + "' and a.PQ_Desc like '%" + txtPQ_IDSearch.Text.Trim().ToString() + "%' and a.PQ_Active='Yes'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Open();
                ddlPQ_ID.DataSource = dt;
                ddlPQ_ID.DisplayMember = dt.Columns[1].ToString();
                ddlPQ_ID.ValueMember = dt.Columns[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Searching Paper Quality " + ex.Message);
            }
        }

        private void BindPaperQuality()
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                SqlDataAdapter da = new SqlDataAdapter("SELECT '' as PQ_ID, '' as PQ_Desc UNION select  a.PQ_ID, a.PQ_Desc  from PQuality_Master a where  a.Grp_ID = '" + Group_ID + "' and a.PQ_Active='Yes'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Open();
                ddlPQ_ID.DataSource = dt;
                ddlPQ_ID.DisplayMember = dt.Columns[1].ToString();
                ddlPQ_ID.ValueMember = dt.Columns[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Loading Paper Quality " + ex.Message);
            }
        }

        private void ddlPQ_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strcon);
                SqlConnection con = new SqlConnection(strcon);

                SqlCommand cmd3 = new SqlCommand("select b.BF_Value,c.GSM_Value,a.PQ_Rate from dbo.PQuality_Master as a,Item_BF_Master as b,Item_GSM_Master as c where a.BF_ID=b.BF_ID and a.GSM_ID=c.GSM_ID and a.PQ_ID ='" + ddlPQ_ID.SelectedValue.ToString() + "'", con1);
                con1.Open();
                SqlDataReader dr1 = cmd3.ExecuteReader();
                if (dr1.Read())
                {
                    txtBF.Text = Convert.ToString(dr1["BF_Value"]);
                    txtGSM.Text = Convert.ToString(dr1["GSM_Value"]);
                    txtRate.Text = Convert.ToString(dr1["PQ_Rate"]);
                }
                dr1.Close();
                con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Loading Paper Quality Details " + ex.Message);
            }
        }

        private void cmdOrderSearch_Click(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' and b.Order_ID like '%" + txtOrderSearch.Text.Trim().ToString() + "%' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Open();
                ddlOrder_ID.DataSource = dt;
                ddlOrder_ID.DisplayMember = dt.Columns[0].ToString();
                ddlOrder_ID.ValueMember = dt.Columns[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Searching Order " + ex.Message);
            }
        }

        private void BindOrder()
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Open();
                ddlOrder_ID.DataSource = dt;
                ddlOrder_ID.DisplayMember = dt.Columns[0].ToString();
                ddlOrder_ID.ValueMember = dt.Columns[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Searching Order " + ex.Message);
            }
        }

        private void ddlOrder_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strcon);
                SqlConnection con = new SqlConnection(strcon);

                SqlCommand cmd3 = new SqlCommand("select b.P_Name,a.P_ID,a.P_PONo,convert (varchar(20),a.P_PODt,103) as 'P_PODt',a.Box_Qty from Item_Order as a,Party_Master as b where a.P_ID=b.P_ID and a.Order_ID ='" + ddlOrder_ID.SelectedValue.ToString() + "'", con1);
                con1.Open();
                SqlDataReader dr1 = cmd3.ExecuteReader();
                if (dr1.Read())
                {

                    P_Name = Convert.ToString(dr1["P_Name"]);
                    P_ID = Convert.ToString(dr1["P_ID"]);
                    P_PONo = Convert.ToString(dr1["P_PONo"]);
                    P_PODt = Convert.ToString(dr1["P_PODt"]);
                    Box_Qty = Convert.ToString(dr1["Box_Qty"]);
                }
                dr1.Close();
                con1.Close();

                txtP_ID.Text = P_Name;
                txtPoandDate.Text = P_PONo + "  " + P_PODt;
                txtOrder_Qty.Text = Box_Qty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Loading Order Details " + ex.Message);
            }
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSr_No.Text == "")//checking for PartyName  field 
                {
                    MessageBox.Show("Sr No Cannot be Blank");
                    txtSr_No.Focus();
                }
                else if (txtForm_Dt.Text == "")//checking for blank name text field 
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    txtForm_Dt.Focus();
                }
                else if (ddlOrder_ID.Text == "")//checking for blank Phone
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    ddlOrder_ID.Focus();

                }
                else if (txtP_ID.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    txtP_ID.Focus();
                }
                else if (txtOrder_Qty.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    txtOrder_Qty.Focus();
                }
                else if (txtVeh_No.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    txtVeh_No.Focus();
                }
                else if (ddlPQ_ID.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    ddlPQ_ID.Focus();
                }
                else if (txtProc_Desc.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    txtProc_Desc.Focus();
                }
                else if (txtExc_Code.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    txtExc_Code.Focus();
                }
                else if (txtForm_Qty.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    txtForm_Qty.Focus();
                }
                else if (txtForm_Amt.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    txtForm_Amt.Focus();
                }
                else if (txtForm_Days.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    txtForm_Days.Focus();
                }
                else if (txtAdj_Qty.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    txtAdj_Qty.Focus();
                }
                else if (txtVeh_No.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    txtVeh_No.Focus();
                }
                else if (ddlActive.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Balnk");
                    ddlActive.Focus();
                }
                else
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con1 = new SqlConnection(strcon);
                    SqlConnection con = new SqlConnection(strcon);

                    //Inserting records 

                    SqlCommand cmdPositive = new SqlCommand("insert into Dispatch_Form57F4(Sr_No,Form_Dt,Grp_ID,P_ID,PQ_ID,Proc_Desc,Exc_Code,Order_ID,Form_Qty,Form_Amt,Form_Days,Adj_Qty,Veh_No,Form_Active,Add_By,Add_ByNode,Add_On) values('" + txtSr_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txtForm_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + Group_ID + "','" + ddlP_ID.SelectedValue.ToString() + "','" + ddlPQ_ID.SelectedValue.ToString() + "','" + txtProc_Desc.Text.Trim().Replace("'", "''").ToString() + "','" + txtExc_Code.Text.Trim().Replace("'", "''").ToString() + "','" + ddlOrder_ID.SelectedValue.ToString() + "','" + txtForm_Qty.Text.Trim().Replace("'", "''").ToString() + "','" + txtForm_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtForm_Days.Text.Trim().Replace("'", "''").ToString() + "','" + txtAdj_Qty.Text.Trim().Replace("'", "''").ToString() + "','" + txtVeh_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddlActive.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
                    con.Open();
                    int Positive = cmdPositive.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                    con.Close();
                    pdfGenerate();
                    ClearAll();
                    if (strOpenDoc != "" & strOpenDoc != null)
                    {
                        Process.Start(strOpenDoc);
                    }
                    strOpenDoc = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Adding Dispatch Details " + ex.Message);
            }
        }

        protected void ClearAll()
        {
            try
            {
                ddlOrder_ID.Text = "";
                txt_Search.Text = "";
                txtAdj_Qty.Text = "";
                txtBF.Text = "";
                txtExc_Code.Text = "";
                txtForm_Amt.Text = "";
                txtForm_Days.Text = "";
                txtForm_Dt.Text = "";
                txtForm_Qty.Text = "";
                txtGSM.Text = "";
                txtOrder_Qty.Text = "";
                txtOrderSearch.Text = "";
                txtP_ID.Text = "";
                txtP_IDSearch.Text = "";
                txtPoandDate.Text = "";
                txtPQ_IDSearch.Text = "";
                txtProc_Desc.Text = "";
                txtRate.Text = "";
                txtSr_No.Text = "";
                txtVeh_No.Text = "";

                ddlOrder_ID.Text = "";
                ddlP_ID.Text = "";
                ddlPQ_ID.Text = "";
                ddlSearch.Text = "";

                ddlActive.Text = "Yes";
                cmdPrint.Visible = false;
                ddlActive.Enabled = false;

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                Sr_No = funclib.SR_No("57F", con, "select Sr_No  from Dispatch_Form57F4 order by Sr_No   desc");
                txtSr_No.Text = Sr_No;

                cmdEdit.Enabled = false;
                cmdEdit.Visible = false;
                btnDelete.Visible = false;
                cmdSubmit.Enabled = true;
                cmdSubmit.Visible = true;

                txt_Search.Enabled = true;
                txtAdj_Qty.Enabled = true;
                txtExc_Code.Enabled = true;
                txtForm_Amt.Enabled = true;
                txtForm_Days.Enabled = true;
                txtForm_Dt.Enabled = true;
                txtForm_Qty.Enabled = true;
                txtOrderSearch.Enabled = true;
                txtP_IDSearch.Enabled = true;
                txtPQ_IDSearch.Enabled = true;
                txtProc_Desc.Enabled = true;
                txtSr_No.Enabled = true;
                txtVeh_No.Enabled = true;
                ddlP_ID.Enabled = true;
                ddlPQ_ID.Enabled = true;
                ddlSearch.Enabled = true;
                ddlOrder_ID.Enabled = true;

                ddlP_ID.DropDownStyle = ComboBoxStyle.DropDownList;
                ddlOrder_ID.DropDownStyle = ComboBoxStyle.DropDownList;
                ddlPQ_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Clearing Data " + ex.Message);
            }
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = "C:";
                sfd.Title = "Save as Excel file";
                sfd.FileName = "";
                sfd.Filter = "Excel Files(2003) |*.xls|Excel Files(2007) |*.xlsx";
                if (sfd.ShowDialog() != DialogResult.Cancel)
                {
                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        System.Data.DataTable table = GridView1.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Dispatch57F4Form");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, GridView1.Columns.Count])
                        {
                            rng.Style.Font.Bold = true;
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }
                        FileInfo excelFile = new FileInfo(sfd.FileName);
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

        private void cmdReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Dispatch_Form57F4 set Form_Active   ='" + ddlActive.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Sr_No  ='" + txtSr_No.Text.Trim().Replace("'", "''").ToString() + "'", con);

                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");

                    ClearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Editing Data " + ex.Message);
            }
        }

        private void txtForm_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtForm_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtForm_Days_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtAdj_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void CmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSearch.Text == "Sr.No.")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("select a.Sr_No as 'Sr.No.',Convert (varchar(20),Form_Dt,103) as 'Form Date',b.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',c.PQ_Desc as 'Product',a.Form_Qty as 'Qty.',a.Form_Amt as 'Amt.',a.P_ID,a.PQ_ID,a.Proc_Desc,a.Exc_Code,a.Form_Days,a.Adj_Qty,a.Veh_No,a.Form_Active  from Dispatch_Form57F4 as a,Party_Master as b,PQuality_Master as c,Item_Order as d where a.P_ID=b.P_ID and a.PQ_ID=c.PQ_ID and a.Order_ID=d.Order_ID and a.Sr_No like '%" + txt_Search.Text.ToString() + "%'  order by a.Sr_No", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[10].Visible = false;
                    GridView1.Columns[11].Visible = false;
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[13].Visible = false;
                    GridView1.Columns[14].Visible = false;
                    GridView1.Columns[15].Visible = false;
                }
                else if (ddlSearch.Text == "Form Date")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("select a.Sr_No as 'Sr.No.',Convert (varchar(20),Form_Dt,103) as 'Form Date',b.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',c.PQ_Desc as 'Product',a.Form_Qty as 'Qty.',a.Form_Amt as 'Amt.',a.P_ID,a.PQ_ID,a.Proc_Desc,a.Exc_Code,a.Form_Days,a.Adj_Qty,a.Veh_No,a.Form_Active  from Dispatch_Form57F4 as a,Party_Master as b,PQuality_Master as c,Item_Order as d where a.P_ID=b.P_ID and a.PQ_ID=c.PQ_ID and a.Order_ID=d.Order_ID and a.Form_Dt = Convert(datetime,'" + txt_Search.Text + "',103)  order by a.Sr_No", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[10].Visible = false;
                    GridView1.Columns[11].Visible = false;
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[13].Visible = false;
                    GridView1.Columns[14].Visible = false;
                    GridView1.Columns[15].Visible = false;
                }
                else if (ddlSearch.Text == "Party")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("select a.Sr_No as 'Sr.No.',Convert (varchar(20),Form_Dt,103) as 'Form Date',b.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',c.PQ_Desc as 'Product',a.Form_Qty as 'Qty.',a.Form_Amt as 'Amt.',a.P_ID,a.PQ_ID,a.Proc_Desc,a.Exc_Code,a.Form_Days,a.Adj_Qty,a.Veh_No,a.Form_Active  from Dispatch_Form57F4 as a,Party_Master as b,PQuality_Master as c,Item_Order as d where a.P_ID=b.P_ID and a.PQ_ID=c.PQ_ID and a.Order_ID=d.Order_ID and b.P_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.Sr_No", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[10].Visible = false;
                    GridView1.Columns[11].Visible = false;
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[13].Visible = false;
                    GridView1.Columns[14].Visible = false;
                    GridView1.Columns[15].Visible = false;
                }
                else if (ddlSearch.Text == "Order No.")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("select a.Sr_No as 'Sr.No.',Convert (varchar(20),Form_Dt,103) as 'Form Date',b.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',c.PQ_Desc as 'Product',a.Form_Qty as 'Qty.',a.Form_Amt as 'Amt.',a.P_ID,a.PQ_ID,a.Proc_Desc,a.Exc_Code,a.Form_Days,a.Adj_Qty,a.Veh_No,a.Form_Active  from Dispatch_Form57F4 as a,Party_Master as b,PQuality_Master as c,Item_Order as d where a.P_ID=b.P_ID and a.PQ_ID=c.PQ_ID and a.Order_ID=d.Order_ID and a.Order_ID like '%" + txt_Search.Text.ToString() + "%'  order by a.Sr_No", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[10].Visible = false;
                    GridView1.Columns[11].Visible = false;
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[13].Visible = false;
                    GridView1.Columns[14].Visible = false;
                    GridView1.Columns[15].Visible = false;
                }
                else if (ddlSearch.Text == "Product")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("select a.Sr_No as 'Sr.No.',Convert (varchar(20),Form_Dt,103) as 'Form Date',b.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',c.PQ_Desc as 'Product',a.Form_Qty as 'Qty.',a.Form_Amt as 'Amt.',a.P_ID,a.PQ_ID,a.Proc_Desc,a.Exc_Code,a.Form_Days,a.Adj_Qty,a.Veh_No,a.Form_Active  from Dispatch_Form57F4 as a,Party_Master as b,PQuality_Master as c,Item_Order as d where a.P_ID=b.P_ID and a.PQ_ID=c.PQ_ID and a.Order_ID=d.Order_ID and c.PQ_Desc like '%" + txt_Search.Text.ToString() + "%'  order by a.Sr_No", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[10].Visible = false;
                    GridView1.Columns[11].Visible = false;
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[13].Visible = false;
                    GridView1.Columns[14].Visible = false;
                    GridView1.Columns[15].Visible = false;
                }
                else if (ddlSearch.Text == "Qty.")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("select a.Sr_No as 'Sr.No.',Convert (varchar(20),Form_Dt,103) as 'Form Date',b.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',c.PQ_Desc as 'Product',a.Form_Qty as 'Qty.',a.Form_Amt as 'Amt.',a.P_ID,a.PQ_ID,a.Proc_Desc,a.Exc_Code,a.Form_Days,a.Adj_Qty,a.Veh_No,a.Form_Active  from Dispatch_Form57F4 as a,Party_Master as b,PQuality_Master as c,Item_Order as d where a.P_ID=b.P_ID and a.PQ_ID=c.PQ_ID and a.Order_ID=d.Order_ID and a.Form_Qty like '%" + txt_Search.Text.ToString() + "%'  order by a.Sr_No", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[10].Visible = false;
                    GridView1.Columns[11].Visible = false;
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[13].Visible = false;
                    GridView1.Columns[14].Visible = false;
                    GridView1.Columns[15].Visible = false;
                }
                else if (ddlSearch.Text == "Amt.")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("select a.Sr_No as 'Sr.No.',Convert (varchar(20),Form_Dt,103) as 'Form Date',b.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',c.PQ_Desc as 'Product',a.Form_Qty as 'Qty.',a.Form_Amt as 'Amt.',a.P_ID,a.PQ_ID,a.Proc_Desc,a.Exc_Code,a.Form_Days,a.Adj_Qty,a.Veh_No,a.Form_Active  from Dispatch_Form57F4 as a,Party_Master as b,PQuality_Master as c,Item_Order as d where a.P_ID=b.P_ID and a.PQ_ID=c.PQ_ID and a.Order_ID=d.Order_ID and a.Form_Amt like '%" + txt_Search.Text.ToString() + "%'  order by a.Sr_No", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[10].Visible = false;
                    GridView1.Columns[11].Visible = false;
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[13].Visible = false;
                    GridView1.Columns[14].Visible = false;
                    GridView1.Columns[15].Visible = false;
                }
                else
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("select a.Sr_No as 'Sr.No.',Convert (varchar(20),Form_Dt,103) as 'Form Date',b.P_Name as 'Party',a.Order_ID as 'Order No.',(select P_Name from Party_Master where P_ID=d.P_ID) as  'Order Party',c.PQ_Desc as 'Product',a.Form_Qty as 'Qty.',a.Form_Amt as 'Amt.',a.P_ID,a.PQ_ID,a.Proc_Desc,a.Exc_Code,a.Form_Days,a.Adj_Qty,a.Veh_No,a.Form_Active  from Dispatch_Form57F4 as a,Party_Master as b,PQuality_Master as c,Item_Order as d where a.P_ID=b.P_ID and a.PQ_ID=c.PQ_ID and a.Order_ID=d.Order_ID order by a.Sr_No", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[10].Visible = false;
                    GridView1.Columns[11].Visible = false;
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[13].Visible = false;
                    GridView1.Columns[14].Visible = false;
                    GridView1.Columns[15].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Searching 57F4 form " + ex.Message);
            }
        }

        private void GridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cmdEdit.Enabled = true;
                cmdEdit.Visible = true;

                btnDelete.Visible = false;

                cmdSubmit.Enabled = false;
                cmdSubmit.Visible = false;

                cmdPrint.Visible = true;

                ddlActive.Enabled = true;
                txt_Search.Enabled = false;
                txtAdj_Qty.Enabled = false;
                txtExc_Code.Enabled = false;
                txtForm_Amt.Enabled = false;
                txtForm_Days.Enabled = false;
                txtForm_Dt.Enabled = false;
                txtForm_Qty.Enabled = false;
                txtOrderSearch.Enabled = false;
                txtP_IDSearch.Enabled = false;
                txtPQ_IDSearch.Enabled = false;
                txtProc_Desc.Enabled = false;
                txtSr_No.Enabled = false;
                txtVeh_No.Enabled = false;
                ddlP_ID.Enabled = false;
                ddlOrder_ID.Enabled = false;
                ddlPQ_ID.Enabled = false;
                ddlSearch.Enabled = false;

                txtSr_No.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //ddlOrder_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtForm_Dt.Text = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                ddlP_ID.DropDownStyle = ComboBoxStyle.Simple;
                ddlP_ID.Text = GridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                ddlOrder_ID.DropDownStyle = ComboBoxStyle.Simple;
                griOrder_ID = GridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                ddlOrder_ID.Text = GridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                txtP_ID.Text = GridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                ddlPQ_ID.DropDownStyle = ComboBoxStyle.Simple;
                ddlPQ_ID.Text = GridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                txtForm_Qty.Text = GridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtForm_Amt.Text = GridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                P_ID = GridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                PQ_ID = GridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtProc_Desc.Text = GridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtExc_Code.Text = GridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtForm_Days.Text = GridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtAdj_Qty.Text = GridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                txtVeh_No.Text = GridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                ddlActive.Text = GridView1.Rows[e.RowIndex].Cells[15].Value.ToString();

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strcon);
                SqlConnection con = new SqlConnection(strcon);

                SqlCommand cmd3 = new SqlCommand("select b.BF_Value,c.GSM_Value,a.PQ_Rate from dbo.PQuality_Master as a,Item_BF_Master as b,Item_GSM_Master as c where a.BF_ID=b.BF_ID and a.GSM_ID=c.GSM_ID and a.PQ_ID ='" + PQ_ID + "'", con1);
                con1.Open();
                SqlDataReader dr1 = cmd3.ExecuteReader();
                if (dr1.Read())
                {
                    txtBF.Text = Convert.ToString(dr1["BF_Value"]);
                    txtGSM.Text = Convert.ToString(dr1["GSM_Value"]);
                    txtRate.Text = Convert.ToString(dr1["PQ_Rate"]);
                }
                dr1.Close();
                con1.Close();

                SqlCommand cmd4 = new SqlCommand("select b.P_Name,a.P_ID,a.P_PONo,convert (varchar(20),a.P_PODt,103) as 'P_PODt',a.Box_Qty from Item_Order as a,Party_Master as b where a.P_ID=b.P_ID and a.Order_ID ='" + griOrder_ID + "'", con1);
                con1.Open();
                SqlDataReader dr2 = cmd4.ExecuteReader();
                if (dr2.Read())
                {
                    P_Name = Convert.ToString(dr2["P_Name"]);
                    P_ID = Convert.ToString(dr2["P_ID"]);
                    P_PONo = Convert.ToString(dr2["P_PONo"]);
                    P_PODt = Convert.ToString(dr2["P_PODt"]);
                    Box_Qty = Convert.ToString(dr2["Box_Qty"]);
                }
                dr2.Close();
                con1.Close();

                txtPoandDate.Text = P_PONo + "  " + P_PODt;
                txtOrder_Qty.Text = Box_Qty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Bind 57F4 data " + ex.Message);
            }
        }

        private void txt_Search_MouseClick(object sender, MouseEventArgs e)
        {
            if (ddlSearch.Text == "Form Date")
            {
                monthCalendar2.Visible = true;
            }
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txt_Search.Text = monthCalendar2.SelectionStart.ToShortDateString();
            monthCalendar2.Visible = false;
            txt_Search.Focus();
        }

        //for date selection
        protected void pdfGenerate()
        {
            funclib = new FunctionLib();
            string strCon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strCon);
            SqlConnection con4 = new SqlConnection(strCon);

            string strsql5 = "select  Grp_Name from Group_Master  where Grp_Active='Yes' and Grp_ID = '" + Group_ID + "'";
            SqlCommand cmd5 = new SqlCommand(strsql5, con);
            con.Open();
            SqlDataReader dr = cmd5.ExecuteReader();
            if (dr.Read())
            {
                Grp_Name = Convert.ToString(dr["Grp_Name"]);
            }
            dr.Close();
            con.Close();

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Pdf Documents (*.pdf)|*.pdf";
            sfd.FileName = "DispatchFormNo57F(4).pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                strOpenDoc = sfd.FileName;

                //Create Document class obejct and set its size to letter and give space left, right, Top, Bottom Margin
                Document doc = new Document(iTextSharp.text.PageSize.A4, 50, 35, 42, 35);
                try
                {
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    //Open Document to write
                    doc.Open();

                    //var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    //var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                    string fontCAMBRIAB = Path.Combine(Application.StartupPath, "CAMBRIAB.TTF");
                    string fontArial = Path.Combine(Application.StartupPath, "arial.ttf");

                    FontFactory.Register(fontArial, "NewFont");
                    iTextSharp.text.Font myBoldFont = FontFactory.GetFont("NewFont");

                    FontFactory.Register(fontArial, "BodyFont");
                    iTextSharp.text.Font myBoldFont2 = FontFactory.GetFont("BodyFont");

                    var titleFont = FontFactory.GetFont("NewFont", 14);
                    var subTitleFont = FontFactory.GetFont("NewFont", 14);
                    var boldTableFont = FontFactory.GetFont("NewFont", 12);
                    var endingMessageFont = FontFactory.GetFont("NewFont", 12);
                    var bodyFont = FontFactory.GetFont("NewFont", 12);
                    var underline = FontFactory.GetFont("BodyFont", 10);
                    var underlinBold = FontFactory.GetFont("NewFont", 9);
                    var underlinBoldfont = FontFactory.GetFont("NewFont", 10, 1);
                    var underline2 = FontFactory.GetFont("NewFont", 9);
                    var footerfont = FontFactory.GetFont("NewFont", 5);

                    //string rptPath = Path.Combine(Application.StartupPath, "OPSM_02.jpg");
                    //var logo = iTextSharp.text.Image.GetInstance(rptPath);

                    //logo.ScaleAbsoluteHeight(45);
                    ////logo.ScaleAbsoluteHeight(35);
                    //logo.ScaleAbsoluteWidth(120);
                    //logo.Alignment = Element.ALIGN_RIGHT;
                    //logo.SetAbsolutePosition(400, 760);

                    //Chunk footer = new Chunk("LifeLine Doctor - www.ropras.com" + '\n', footerfont);
                    //Paragraph Parafooter = new Paragraph(doc.Bottom,footer);
                    //Parafooter.Alignment = Element.ALIGN_RIGHT;

                    //tbl footer
                    PdfPTable footerTbl = new PdfPTable(1);
                    footerTbl.TotalWidth = doc.PageSize.Width;

                    footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
                    PdfPCell cell = new PdfPCell(new Phrase("ePacker - www.ropras.com", footerfont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Border = 0;
                    footerTbl.AddCell(cell);
                    footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin + 20), wri.DirectContent);

                    //doc.Add(logo);
                    //doc.Add(new Paragraph("" + '\n'));
                    //doc.Add(new Paragraph("" + '\n'));

                    Chunk MainTitle = new Chunk(Grp_Name + '\n', boldTableFont);
                    MainTitle.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaMainTitle = new Paragraph(MainTitle);
                    //ParaMainTitle.SpacingBefore = 5f;
                    //ParaMainTitle.SpacingAfter = 5f;

                    Chunk chunk = new Chunk("Dispatch : Form No.57F(4)" + '\n', titleFont);
                    chunk.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaTitle = new Paragraph(chunk);
                    ParaTitle.SpacingBefore = 5f;
                    ParaTitle.SpacingAfter = 5f;

                    var phrase2 = new Phrase();
                    phrase2.Add(new Chunk("Sr. No. : ", underline));
                    Chunk c2 = new Chunk(txtSr_No.Text.Trim().ToString(), underline);
                    c2.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c2);

                    phrase2.Add(new Chunk("        "));

                    phrase2.Add(new Chunk("Form Dt. : ", underline));
                    Chunk c3 = new Chunk(txtForm_Dt.Text.Trim().ToString() + '\n', underline);
                    c3.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c3);

                    Paragraph pf1 = new Paragraph(phrase2);

                    var phrase4 = new Phrase();
                    phrase4.Add(new Chunk("Party : ", underline));
                    Chunk cadd = new Chunk(ddlP_ID.Text + '\n', underline);
                    cadd.SetUnderline(0.5f, -1.5f);
                    phrase4.Add(cadd);

                    Paragraph pf2 = new Paragraph(phrase4);

                    var phrase4_1 = new Phrase();
                    phrase4_1.Add(new Chunk("Paper Quality Product : ", underline));
                    Chunk cadd_1 = new Chunk(ddlPQ_ID.Text + '\n', underline);
                    cadd_1.SetUnderline(0.5f, -1.5f);
                    phrase4_1.Add(cadd);

                    Paragraph pf2_1 = new Paragraph(phrase4_1);

                    var phrase33 = new Phrase();
                    phrase33.Add(new Chunk("BF : ", underline));
                    Chunk c44 = new Chunk(txtBF.Text.Trim().ToString(), underline);
                    c44.SetUnderline(0.5f, -1.5f);
                    phrase33.Add(c44);

                    phrase33.Add(new Chunk("  "));

                    phrase33.Add(new Chunk("GSM : ", underline));
                    Chunk c55 = new Chunk(txtGSM.Text.Trim().ToString(), underline);
                    c55.SetUnderline(0.5f, -1.5f);
                    phrase33.Add(c55);

                    phrase33.Add(new Chunk("  "));

                    phrase33.Add(new Chunk("Rate : ", underline));
                    Chunk c555 = new Chunk(txtRate.Text.Trim().ToString(), underline);
                    c555.SetUnderline(0.5f, -1.5f);
                    phrase33.Add(c555);

                    Paragraph pf3 = new Paragraph(phrase33);

                    var phrase44 = new Phrase();
                    phrase44.Add(new Chunk("Process Description :  ", underline));
                    Chunk cadd4 = new Chunk(txtProc_Desc.Text + '\n', underline);
                    cadd4.SetUnderline(0.5f, -1.5f);
                    phrase44.Add(cadd4);

                    Paragraph pf3_3 = new Paragraph(phrase44);

                    var phrase7 = new Phrase();
                    phrase7.Add(new Chunk("Excise Code : ", underline));
                    Chunk c7 = new Chunk(txtExc_Code.Text.Trim().ToString(), underline);
                    c7.SetUnderline(0.5f, -1.5f);
                    phrase7.Add(c7);

                    Paragraph pf4 = new Paragraph(phrase7);

                    var phrase77 = new Phrase();
                    phrase77.Add(new Chunk("Order No. : ", underline));
                    Chunk cadd77 = new Chunk(ddlOrder_ID.Text + '\n', underline);
                    cadd77.SetUnderline(0.5f, -1.5f);
                    phrase77.Add(cadd77);

                    Paragraph pf4_4 = new Paragraph(phrase77);

                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("Order Party : ", underline));
                    Chunk c81 = new Chunk(txtP_ID.Text.Trim().ToString(), underline);
                    c81.SetUnderline(0.5f, -1.5f);
                    phrase8.Add(c81);

                    Paragraph pf7 = new Paragraph(phrase8);
                    // pf4.SpacingBefore = 5f;

                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("Party PO No. & Dt :  ", underline));
                    Chunk cins = new Chunk(txtPoandDate.Text.Trim().ToString(), underline);
                    cins.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(cins);

                    phraseIns.Add(new Chunk("      "));

                    phraseIns.Add(new Chunk("Order Qty. : ", underline));
                    Chunk c83 = new Chunk(txtOrder_Qty.Text.Trim().ToString(), underline);
                    c83.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(c83);

                    Paragraph pf8 = new Paragraph(phraseIns);

                    var phraseIns2 = new Phrase();
                    phraseIns2.Add(new Chunk("Quantity  : ", underline));
                    Chunk cins2 = new Chunk(txtForm_Qty.Text.Trim().ToString(), underline);
                    cins2.SetUnderline(0.5f, -1.5f);
                    phraseIns2.Add(cins2);

                    phraseIns2.Add(new Chunk("      "));

                    phraseIns2.Add(new Chunk("Amount  : ", underline));
                    Chunk c832 = new Chunk(txtForm_Amt.Text.Trim().ToString(), underline);
                    c832.SetUnderline(0.5f, -1.5f);
                    phraseIns2.Add(c832);

                    Paragraph pf8_8 = new Paragraph(phraseIns2);

                    var phraseIns23 = new Phrase();
                    phraseIns23.Add(new Chunk("No. of Days  : ", underline));
                    Chunk cins23 = new Chunk(txtForm_Days.Text.Trim().ToString(), underline);
                    cins23.SetUnderline(0.5f, -1.5f);
                    phraseIns23.Add(cins23);

                    phraseIns23.Add(new Chunk("      "));

                    phraseIns23.Add(new Chunk("Adj. Qty. : ", underline));
                    Chunk c8323 = new Chunk(txtAdj_Qty.Text.Trim().ToString(), underline);
                    c8323.SetUnderline(0.5f, -1.5f);
                    phraseIns23.Add(c8323);

                    Paragraph pf8_99 = new Paragraph(phraseIns23);

                    var phraseIns234 = new Phrase();
                    phraseIns234.Add(new Chunk("Vehicle No. : ", underline));
                    Chunk cins234 = new Chunk(txtVeh_No.Text.Trim().ToString(), underline);
                    cins234.SetUnderline(0.5f, -1.5f);
                    phraseIns234.Add(cins234);

                    Paragraph pf8_999 = new Paragraph(phraseIns234);

                    doc.Add(MainTitle);

                    doc.Add(ParaTitle);
                    doc.Add(pf1);
                    doc.Add(pf2);
                    doc.Add(pf2_1);
                    doc.Add(pf3);
                    doc.Add(pf3_3);
                    doc.Add(pf4);
                    doc.Add(pf4_4);
                    doc.Add(pf7);
                    doc.Add(pf8);
                    doc.Add(pf8_8);
                    doc.Add(pf8_99);
                    doc.Add(pf8_999);

                    LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line3));
                    //Itemg Grid2
                }
                catch (DocumentException dex)
                {
                    //Handle document exception
                    MessageBox.Show("There was an DocumentException while Creating Invoice PDF" + dex.Message);
                }
                catch (IOException ioex)
                {
                    //Handle IO exception
                    MessageBox.Show("There was an IO while Creating Invoice PDF" + ioex.Message);
                }
                catch (Exception ex)
                {
                    //Handle Other Exception
                    MessageBox.Show("There was an Other while Creating Invoice PDF" + ex.Message);
                }
                finally
                {
                    doc.Close(); //Close document
                }
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {

            funclib = new FunctionLib();
            string strCon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strCon);
            SqlConnection con4 = new SqlConnection(strCon);

            string strsql5 = "select  Grp_Name from Group_Master  where Grp_Active='Yes' and Grp_ID = '" + Group_ID + "'";
            SqlCommand cmd5 = new SqlCommand(strsql5, con);
            con.Open();
            SqlDataReader dr = cmd5.ExecuteReader();
            if (dr.Read())
            {
                Grp_Name = Convert.ToString(dr["Grp_Name"]);
            }
            dr.Close();
            con.Close();

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Pdf Documents (*.pdf)|*.pdf";
            sfd.FileName = "CopyOfDispatchFormNo57F(4).pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                strOpenDoc = sfd.FileName;

                //Create Document class obejct and set its size to letter and give space left, right, Top, Bottom Margin
                Document doc = new Document(iTextSharp.text.PageSize.A4, 50, 35, 42, 35);
                try
                {
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    //Open Document to write
                    doc.Open();

                    //var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    //var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                    string fontCAMBRIAB = Path.Combine(Application.StartupPath, "CAMBRIAB.TTF");
                    string fontArial = Path.Combine(Application.StartupPath, "arial.ttf");

                    FontFactory.Register(fontArial, "NewFont");
                    iTextSharp.text.Font myBoldFont = FontFactory.GetFont("NewFont");

                    FontFactory.Register(fontArial, "BodyFont");
                    iTextSharp.text.Font myBoldFont2 = FontFactory.GetFont("BodyFont");

                    var titleFont = FontFactory.GetFont("NewFont", 14);
                    var subTitleFont = FontFactory.GetFont("NewFont", 14);
                    var boldTableFont = FontFactory.GetFont("NewFont", 12);
                    var endingMessageFont = FontFactory.GetFont("NewFont", 12);
                    var bodyFont = FontFactory.GetFont("NewFont", 12);
                    var underline = FontFactory.GetFont("BodyFont", 10);
                    var underlinBold = FontFactory.GetFont("NewFont", 9);
                    var underlinBoldfont = FontFactory.GetFont("NewFont", 10, 1);
                    var underline2 = FontFactory.GetFont("NewFont", 9);
                    var footerfont = FontFactory.GetFont("NewFont", 5);

                    //string rptPath = Path.Combine(Application.StartupPath, "OPSM_02.jpg");
                    //var logo = iTextSharp.text.Image.GetInstance(rptPath);

                    //logo.ScaleAbsoluteHeight(45);
                    ////logo.ScaleAbsoluteHeight(35);
                    //logo.ScaleAbsoluteWidth(120);
                    //logo.Alignment = Element.ALIGN_RIGHT;
                    //logo.SetAbsolutePosition(400, 760);

                    //Chunk footer = new Chunk("LifeLine Doctor - www.ropras.com" + '\n', footerfont);
                    //Paragraph Parafooter = new Paragraph(doc.Bottom,footer);
                    //Parafooter.Alignment = Element.ALIGN_RIGHT;

                    //tbl footer
                    PdfPTable footerTbl = new PdfPTable(1);
                    footerTbl.TotalWidth = doc.PageSize.Width;

                    footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
                    PdfPCell cell = new PdfPCell(new Phrase("ePacker - www.ropras.com", footerfont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Border = 0;
                    footerTbl.AddCell(cell);
                    footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin + 20), wri.DirectContent);

                    //doc.Add(logo);
                    //doc.Add(new Paragraph("" + '\n'));
                    //doc.Add(new Paragraph("" + '\n'));

                    Chunk MainTitle = new Chunk(Grp_Name + '\n', boldTableFont);
                    MainTitle.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaMainTitle = new Paragraph(MainTitle);
                    //ParaMainTitle.SpacingBefore = 5f;
                    //ParaMainTitle.SpacingAfter = 5f;

                    Chunk chunk = new Chunk("Dispatch : Form No.57F(4) (Copy)" + '\n', titleFont);
                    chunk.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaTitle = new Paragraph(chunk);
                    ParaTitle.SpacingBefore = 5f;
                    ParaTitle.SpacingAfter = 5f;

                    var phrase2 = new Phrase();
                    phrase2.Add(new Chunk("Sr. No. : ", underline));
                    Chunk c2 = new Chunk(txtSr_No.Text.Trim().ToString(), underline);
                    c2.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c2);

                    phrase2.Add(new Chunk("        "));

                    phrase2.Add(new Chunk("Form Dt. : ", underline));
                    Chunk c3 = new Chunk(txtForm_Dt.Text.Trim().ToString() + '\n', underline);
                    c3.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c3);

                    Paragraph pf1 = new Paragraph(phrase2);

                    var phrase4 = new Phrase();
                    phrase4.Add(new Chunk("Party : ", underline));
                    Chunk cadd = new Chunk(ddlP_ID.Text + '\n', underline);
                    cadd.SetUnderline(0.5f, -1.5f);
                    phrase4.Add(cadd);

                    Paragraph pf2 = new Paragraph(phrase4);

                    var phrase4_1 = new Phrase();
                    phrase4_1.Add(new Chunk("Paper Quality Product : ", underline));
                    Chunk cadd_1 = new Chunk(ddlPQ_ID.Text + '\n', underline);
                    cadd_1.SetUnderline(0.5f, -1.5f);
                    phrase4_1.Add(cadd);

                    Paragraph pf2_1 = new Paragraph(phrase4_1);

                    var phrase33 = new Phrase();
                    phrase33.Add(new Chunk("BF : ", underline));
                    Chunk c44 = new Chunk(txtBF.Text.Trim().ToString(), underline);
                    c44.SetUnderline(0.5f, -1.5f);
                    phrase33.Add(c44);

                    phrase33.Add(new Chunk("  "));

                    phrase33.Add(new Chunk("GSM : ", underline));
                    Chunk c55 = new Chunk(txtGSM.Text.Trim().ToString(), underline);
                    c55.SetUnderline(0.5f, -1.5f);
                    phrase33.Add(c55);

                    phrase33.Add(new Chunk("  "));

                    phrase33.Add(new Chunk("Rate : ", underline));
                    Chunk c555 = new Chunk(txtRate.Text.Trim().ToString(), underline);
                    c555.SetUnderline(0.5f, -1.5f);
                    phrase33.Add(c555);

                    Paragraph pf3 = new Paragraph(phrase33);

                    var phrase44 = new Phrase();
                    phrase44.Add(new Chunk("Process Description :  ", underline));
                    Chunk cadd4 = new Chunk(txtProc_Desc.Text + '\n', underline);
                    cadd4.SetUnderline(0.5f, -1.5f);
                    phrase44.Add(cadd4);

                    Paragraph pf3_3 = new Paragraph(phrase44);

                    var phrase7 = new Phrase();
                    phrase7.Add(new Chunk("Excise Code : ", underline));
                    Chunk c7 = new Chunk(txtExc_Code.Text.Trim().ToString(), underline);
                    c7.SetUnderline(0.5f, -1.5f);
                    phrase7.Add(c7);

                    Paragraph pf4 = new Paragraph(phrase7);

                    var phrase77 = new Phrase();
                    phrase77.Add(new Chunk("Order No. : ", underline));
                    Chunk cadd77 = new Chunk(ddlOrder_ID.Text + '\n', underline);
                    cadd77.SetUnderline(0.5f, -1.5f);
                    phrase77.Add(cadd77);

                    Paragraph pf4_4 = new Paragraph(phrase77);

                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("Order Party : ", underline));
                    Chunk c81 = new Chunk(txtP_ID.Text.Trim().ToString(), underline);
                    c81.SetUnderline(0.5f, -1.5f);
                    phrase8.Add(c81);

                    Paragraph pf7 = new Paragraph(phrase8);
                    // pf4.SpacingBefore = 5f;

                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("Party PO No. & Dt :  ", underline));
                    Chunk cins = new Chunk(txtPoandDate.Text.Trim().ToString(), underline);
                    cins.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(cins);

                    phraseIns.Add(new Chunk("      "));

                    phraseIns.Add(new Chunk("Order Qty. : ", underline));
                    Chunk c83 = new Chunk(txtOrder_Qty.Text.Trim().ToString(), underline);
                    c83.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(c83);

                    Paragraph pf8 = new Paragraph(phraseIns);

                    var phraseIns2 = new Phrase();
                    phraseIns2.Add(new Chunk("Quantity  : ", underline));
                    Chunk cins2 = new Chunk(txtForm_Qty.Text.Trim().ToString(), underline);
                    cins2.SetUnderline(0.5f, -1.5f);
                    phraseIns2.Add(cins2);

                    phraseIns2.Add(new Chunk("      "));

                    phraseIns2.Add(new Chunk("Amount  : ", underline));
                    Chunk c832 = new Chunk(txtForm_Amt.Text.Trim().ToString(), underline);
                    c832.SetUnderline(0.5f, -1.5f);
                    phraseIns2.Add(c832);

                    Paragraph pf8_8 = new Paragraph(phraseIns2);

                    var phraseIns23 = new Phrase();
                    phraseIns23.Add(new Chunk("No. of Days  : ", underline));
                    Chunk cins23 = new Chunk(txtForm_Days.Text.Trim().ToString(), underline);
                    cins23.SetUnderline(0.5f, -1.5f);
                    phraseIns23.Add(cins23);

                    phraseIns23.Add(new Chunk("      "));

                    phraseIns23.Add(new Chunk("Adj. Qty. : ", underline));
                    Chunk c8323 = new Chunk(txtAdj_Qty.Text.Trim().ToString(), underline);
                    c8323.SetUnderline(0.5f, -1.5f);
                    phraseIns23.Add(c8323);

                    Paragraph pf8_99 = new Paragraph(phraseIns23);

                    var phraseIns234 = new Phrase();
                    phraseIns234.Add(new Chunk("Vehicle No. : ", underline));
                    Chunk cins234 = new Chunk(txtVeh_No.Text.Trim().ToString(), underline);
                    cins234.SetUnderline(0.5f, -1.5f);
                    phraseIns234.Add(cins234);

                    Paragraph pf8_999 = new Paragraph(phraseIns234);

                    doc.Add(MainTitle);

                    doc.Add(ParaTitle);
                    doc.Add(pf1);
                    doc.Add(pf2);
                    doc.Add(pf2_1);
                    doc.Add(pf3);
                    doc.Add(pf3_3);
                    doc.Add(pf4);
                    doc.Add(pf4_4);
                    doc.Add(pf7);
                    doc.Add(pf8);
                    doc.Add(pf8_8);
                    doc.Add(pf8_99);
                    doc.Add(pf8_999);

                    LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line3));

                    //Itemg Grid2
                }
                catch (DocumentException dex)
                {
                    //Handle document exception
                    MessageBox.Show("There was an DocumentException while Creating Invoice PDF" + dex.Message);
                }
                catch (IOException ioex)
                {
                    //Handle IO exception
                    MessageBox.Show("There was an IO while Creating Invoice PDF" + ioex.Message);
                }
                catch (Exception ex)
                {
                    //Handle Other Exception
                    MessageBox.Show("There was an Other while Creating Invoice PDF" + ex.Message);
                }
                finally
                {
                    doc.Close(); //Close document
                }
            }
            if (strOpenDoc != "" & strOpenDoc != null)
            {
                Process.Start(strOpenDoc);
            }
            strOpenDoc = "";
        }
    }
}
