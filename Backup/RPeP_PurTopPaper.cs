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
using System.Windows;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using System.Diagnostics;
using iTextSharp.text.pdf.draw;

namespace ePacker1
{
    public partial class RPeP_PurTopPaper : Form
    {
        string session, strSQL, Group_ID,newTP_CS, Sr_No,curr_Date, TP_CS,SubOrder, SubItem_Of, R_StkInHand, ExistingPOR_Qty, strPOR_Qty, str_StkInHand;
        private FunctionLib funclib;
        public RPeP_PurTopPaper()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_PurTopPaper_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Displaying Active Values 
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            ddlActive.Enabled = false;
            ddlActive.Items.Add("Yes");
            ddlActive.Items.Add("No");
            ddlActive.Text = "Yes";
            monthCalendar1.Visible = false;
      


            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);


            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Order_ID  UNION select  Order_ID  from Item_Order  where Grp_ID = '" + Group_ID + "' and Order_Active='Yes'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlOrder_ID.DataSource = dt;
            ddlOrder_ID.DisplayMember = dt.Columns[0].ToString();
            ddlOrder_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();



            SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as M_ID,'' as M_Name  UNION select  M_ID,M_Name  from Mill_Master  where Grp_ID = '" + Group_ID + "' and M_Active='Yes'", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Open();
            ddlM_ID.DataSource = dt2;
            ddlM_ID.DisplayMember = dt2.Columns[1].ToString();
            ddlM_ID.ValueMember = dt2.Columns[0].ToString();
            con.Close();



            Sr_No = funclib.I_ID("T", con, "select TPSr_No   from TopPaper_Purchase order by TPSr_No   desc");
            txtSr_No.Text = Sr_No;

            ddlSearch.Items.Add("");
            ddlSearch.Items.Add("Sr. No");
            ddlSearch.Items.Add("Order No");
            ddlSearch.Items.Add("Top Paper");
            ddlSearch.Items.Add("57F(4) Sr. No");
            ddlSearch.Items.Add("Party");
            ddlSearch.Items.Add("Mill");

            curr_Date = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void ddlOrder_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da3 = new SqlDataAdapter("SELECT '' as TP_ID,'' as TP_Name UNION select a.TP_ID,a.TP_Name from dbo.TopPaper_Master as a,Item_Order as b where a.TP_ID=b.TP_ID and  b.Order_ID='" + ddlOrder_ID.SelectedValue.ToString() + "'", con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Open();
            ddlTP_ID.DataSource = dt3;
            ddlTP_ID.DisplayMember = dt3.Columns[1].ToString();
            ddlTP_ID.ValueMember = dt3.Columns[0].ToString();
            con.Close();



            SqlCommand cmd3 = new SqlCommand("select P_Name,convert(varchar(20),Order_Dt,103) as 'Order_Dt' from dbo.Party_Master as a,Item_Order as b where a.P_ID=b.P_ID and  Order_ID='" + ddlOrder_ID.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtParty.Text = Convert.ToString(dr1["P_Name"]);
                txtOrderDT.Text = Convert.ToString(dr1["Order_Dt"]);
         
            }
            dr1.Close();
            con1.Close();

            SqlDataAdapter da4 = new SqlDataAdapter("SELECT '' as Sr_No UNION select Sr_No from Dispatch_Form57F4 as a,Item_Order as b where a.Order_ID=b.Order_ID and  a.Order_ID='" + ddlOrder_ID.SelectedValue.ToString() + "'", con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            con.Open();
            ddlSr_No.DataSource = dt4;
            ddlSr_No.DisplayMember = dt4.Columns[0].ToString();
            ddlSr_No.ValueMember = dt4.Columns[0].ToString();
            con.Close();
        }

        private void ddlTP_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select TP_PPWt,TP_Rate,TP_CS   from dbo.TopPaper_Master  as a where  TP_ID='" + ddlTP_ID.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtQty_Wt.Text = Convert.ToString(dr1["TP_PPWt"]);
                txtTP_Rate.Text = Convert.ToString(dr1["TP_Rate"]);
                TP_CS = Convert.ToString(dr1["TP_CS"]);

            }
            dr1.Close();
            con1.Close();
        }

        private void ddlSr_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da4 = new SqlDataAdapter("SELECT '' as P_ID,'' as P_Name UNION select b.P_ID,b.P_Name from Dispatch_Form57F4 as a,Party_Master as b where a.P_ID=b.P_ID and  a.Sr_No='" + ddlSr_No.SelectedValue.ToString() + "'", con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            con.Open();
            ddlP_ID.DataSource = dt4;
            ddlP_ID.DisplayMember = dt4.Columns[1].ToString();
            ddlP_ID.ValueMember = dt4.Columns[0].ToString();
            con.Close();
        }

        private void txtQty_Pcs_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtSr_No.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Sr No Cannot be Blank");
                txtSr_No.Focus();
            }

            else if (txtIn_Dt.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtIn_Dt.Focus();
            }
            else if (ddlOrder_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlOrder_ID.Focus();
            }
            else if (ddlTP_ID.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlTP_ID.Focus();

            }
            else if (txtQty_Pcs.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtQty_Pcs.Focus();
            }
            else if (ddlM_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlM_ID.Focus();
            }
           
            else if (ddlActive.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlActive.Focus();
            }



            else
            {
                

                    funclib = new FunctionLib();
                    //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlConnection con1 = new SqlConnection(strcon);


                    //Inserting records 


                    SqlCommand cmdPositive = new SqlCommand("insert into TopPaper_Purchase(TPSr_No,In_Dt,Grp_ID,Order_ID,TP_ID,Qty_Pcs,Qty_Wt,TP_Rate,Sr_No,P_ID,M_ID,In_Active,Add_By,Add_ByNode,Add_On) values('" + txtSr_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txtIn_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + Group_ID + "','" + ddlOrder_ID.SelectedValue.ToString() + "','" + ddlTP_ID.SelectedValue.ToString() + "','" + txtQty_Pcs.Text.Trim().Replace("'", "''").ToString() + "','" + txtQty_Wt.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + ddlSr_No.SelectedValue.ToString() + "','" + ddlP_ID.SelectedValue.ToString() + "','" + ddlM_ID.SelectedValue.ToString() + "','" + ddlActive.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
                    con.Open();
                    int Positive = cmdPositive.ExecuteNonQuery();
                    if (Positive > 0)
                    {
                        double doTP_CS = Convert.ToDouble(TP_CS);
                        double qtyPcs = Convert.ToDouble(txtQty_Pcs.Text);

                        double tota = doTP_CS + qtyPcs;

                        newTP_CS = Convert.ToString(tota);

                        SqlCommand cmd = new SqlCommand("update TopPaper_Master set TP_OS = '" + TP_CS + "',TP_OSOn =convert(datetime,'" + curr_Date + "',103),TP_CS ='" + newTP_CS + "',TP_CsOn  =convert(datetime,'" + curr_Date + "',103) where TP_ID ='" + ddlTP_ID.SelectedValue.ToString() + "'", con1);
                        con1.Open();
                        cmd.ExecuteNonQuery();
                        con1.Close();
                    }
                    MessageBox.Show("Record Inserted");
                    con.Close();
                    clearAll();

             
            }

        }
        protected void clearAll()
        {
            txtIn_Dt.Text = "";
            txtOrderDT.Text = "";
            txtParty.Text = "";
            txtQty_Pcs.Text = "";
            txtQty_Wt.Text = "";
            txtSr_No.Text = "";
            txtTP_Rate.Text = "";
            ddlM_ID.Text = "";
            ddlOrder_ID.Text = "";
            ddlP_ID.Text = "";
            ddlSr_No.Text = "";
            ddlTP_ID.Text = "";

            ddlActive.Text = "Yes";
            ddlActive.Enabled = false;
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;


            funclib = new FunctionLib();
            //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlConnection con1 = new SqlConnection(strcon);


            Sr_No = funclib.I_ID("T", con, "select TPSr_No   from TopPaper_Purchase order by TPSr_No   desc");
            txtSr_No.Text = Sr_No;


            txtIn_Dt.Enabled = true;
            ddlOrder_ID.Enabled = true;
            ddlTP_ID.Enabled = true;
            txtQty_Pcs.Enabled = true;
            ddlM_ID.Enabled = true;
            ddlSr_No.Enabled = true;
            txtParty.Enabled = true;
            ddlP_ID.Enabled = true;


            ddlOrder_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlSr_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlTP_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlP_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlM_ID.DropDownStyle = ComboBoxStyle.DropDownList;
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
        { //Update data in table
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("update TopPaper_Purchase set In_Active    ='" + ddlActive.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where TPSr_No  ='" + txtSr_No.Text.Trim().Replace("'", "''").ToString() + "'", con);

                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                con.Close();


                clearAll();
            }

        }

        private void CmdSearch_Click(object sender, EventArgs e)
        {
           

            if (ddlSearch.Text == "Sr. No")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.TPSr_No as 'Sr. No',a.Order_ID as 'Order No',b.TP_Name as 'Top Paper',a.Sr_No as '57F(4) Sr. No',c.P_Name as 'Party',d.M_Name as 'Mill'  from dbo.TopPaper_Purchase as a,TopPaper_Master as b,Party_Master as c,Mill_Master as d where a.TP_ID=b.TP_ID and a.P_ID=c.P_ID and a.M_ID=d.M_ID and a.TPSr_No like '%" + txt_Search.Text.ToString() + "%'  order by a.TPSr_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else if (ddlSearch.Text == "Order No")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.TPSr_No as 'Sr. No',a.Order_ID as 'Order No',b.TP_Name as 'Top Paper',a.Sr_No as '57F(4) Sr. No',c.P_Name as 'Party',d.M_Name as 'Mill'  from dbo.TopPaper_Purchase as a,TopPaper_Master as b,Party_Master as c,Mill_Master as d where a.TP_ID=b.TP_ID and a.P_ID=c.P_ID and a.M_ID=d.M_ID and a.Order_ID like '%" + txt_Search.Text.ToString() + "%'  order by a.TPSr_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else if (ddlSearch.Text == "Top Paper")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.TPSr_No as 'Sr. No',a.Order_ID as 'Order No',b.TP_Name as 'Top Paper',a.Sr_No as '57F(4) Sr. No',c.P_Name as 'Party',d.M_Name as 'Mill'  from dbo.TopPaper_Purchase as a,TopPaper_Master as b,Party_Master as c,Mill_Master as d where a.TP_ID=b.TP_ID and a.P_ID=c.P_ID and a.M_ID=d.M_ID and b.TP_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.TPSr_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else if (ddlSearch.Text == "57F(4) Sr. No")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.TPSr_No as 'Sr. No',a.Order_ID as 'Order No',b.TP_Name as 'Top Paper',a.Sr_No as '57F(4) Sr. No',c.P_Name as 'Party',d.M_Name as 'Mill'  from dbo.TopPaper_Purchase as a,TopPaper_Master as b,Party_Master as c,Mill_Master as d where a.TP_ID=b.TP_ID and a.P_ID=c.P_ID and a.M_ID=d.M_ID and a.Sr_No like '%" + txt_Search.Text.ToString() + "%'  order by a.TPSr_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else if (ddlSearch.Text == "Party")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.TPSr_No as 'Sr. No',a.Order_ID as 'Order No',b.TP_Name as 'Top Paper',a.Sr_No as '57F(4) Sr. No',c.P_Name as 'Party',d.M_Name as 'Mill'  from dbo.TopPaper_Purchase as a,TopPaper_Master as b,Party_Master as c,Mill_Master as d where a.TP_ID=b.TP_ID and a.P_ID=c.P_ID and a.M_ID=d.M_ID and c.P_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.TPSr_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else if (ddlSearch.Text == "Mill")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.TPSr_No as 'Sr. No',a.Order_ID as 'Order No',b.TP_Name as 'Top Paper',a.Sr_No as '57F(4) Sr. No',c.P_Name as 'Party',d.M_Name as 'Mill'  from dbo.TopPaper_Purchase as a,TopPaper_Master as b,Party_Master as c,Mill_Master as d where a.TP_ID=b.TP_ID and a.P_ID=c.P_ID and a.M_ID=d.M_ID and d.M_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.TPSr_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else 
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.TPSr_No as 'Sr. No',a.Order_ID as 'Order No',b.TP_Name as 'Top Paper',a.Sr_No as '57F(4) Sr. No',c.P_Name as 'Party',d.M_Name as 'Mill'  from dbo.TopPaper_Purchase as a,TopPaper_Master as b,Party_Master as c,Mill_Master as d where a.TP_ID=b.TP_ID and a.P_ID=c.P_ID and a.M_ID=d.M_ID order by a.TPSr_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
        }

        private void GridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            ddlActive.Enabled = true;

            txtIn_Dt.Enabled = false;
            ddlOrder_ID.Enabled = false;
            ddlTP_ID.Enabled = false;
            txtQty_Pcs.Enabled = false;
            ddlM_ID.Enabled = false;
            ddlSr_No.Enabled = false;
            txtParty.Enabled = false;
            ddlP_ID.Enabled = false;

            txtSr_No.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            ddlOrder_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlOrder_ID.Text = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            ddlTP_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlTP_ID.Text = GridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            ddlSr_No.DropDownStyle = ComboBoxStyle.Simple;
            ddlSr_No.Text = GridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            ddlP_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlP_ID.Text = GridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            ddlM_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlM_ID.Text = GridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);


            SqlCommand cmd3 = new SqlCommand("select convert(varchar(20),In_Dt,103) as 'In_Dt',Qty_Pcs,Qty_Wt,TP_Rate,In_Active from TopPaper_Purchase as a where TPSr_No ='" + txtSr_No.Text.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtIn_Dt.Text = Convert.ToString(dr1["In_Dt"]);
                txtQty_Pcs.Text = Convert.ToString(dr1["Qty_Pcs"]);
                txtQty_Wt.Text = Convert.ToString(dr1["Qty_Wt"]);
                txtTP_Rate.Text = Convert.ToString(dr1["TP_Rate"]);
                ddlActive.Text = Convert.ToString(dr1["In_Active"]);

            }
            dr1.Close();
            con1.Close();

            SqlCommand cmd4 = new SqlCommand("select P_Name,convert(varchar(20),Order_Dt,103) as 'Order_Dt' from dbo.Party_Master as a,Item_Order as b where a.P_ID=b.P_ID and  Order_ID='" + ddlOrder_ID.Text.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr4 = cmd4.ExecuteReader();
            if (dr4.Read())
            {

                txtParty.Text = Convert.ToString(dr4["P_Name"]);
                txtOrderDT.Text = Convert.ToString(dr4["Order_Dt"]);

            }
            dr4.Close();
            con1.Close();

        }

        private void txtOrderDT_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtIn_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtIn_Dt.Focus();

        }

        private void txtIn_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;

        }
    }
}
