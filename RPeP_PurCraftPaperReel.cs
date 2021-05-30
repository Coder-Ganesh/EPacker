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

namespace ePacker1
{
    public partial class RPeP_PurCraftPaperReel : Form
    {
        string session, strSQL, Group_ID, Reel_No, SubOrder, SubItem_Of, R_StkInHand, ExistingPOR_Qty,strPOR_Qty, str_StkInHand;
        private FunctionLib funclib;
        public RPeP_PurCraftPaperReel()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_PurCraftPaperReel_Load(object sender, EventArgs e)
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
            monthCalendar2.Visible = false;


            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);


            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as POR_No UNION select  POR_No from PO_Reel  where Grp_ID = '" + Group_ID + "' and POR_Active='Yes'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlPOR_No.DataSource = dt;
            ddlPOR_No.DisplayMember = dt.Columns[0].ToString();
            ddlPOR_No.ValueMember = dt.Columns[0].ToString();
            con.Close();


        



            Reel_No = funclib.I_ID("R", con, "select Reel_No  from PO_ReelPurchase order by Reel_No  desc");
            txtReel_No.Text = Reel_No;

            ddlSearch.Items.Add("");
            ddlSearch.Items.Add("Reel No");
            ddlSearch.Items.Add("PO No");
            ddlSearch.Items.Add("Agent");
            ddlSearch.Items.Add("Mill");
            ddlSearch.Items.Add("Size");

        }

        private void ddlPOR_No_SelectedIndexChanged(object sender, EventArgs e)
        {

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da3 = new SqlDataAdapter("SELECT '' as POR_Size UNION select  POR_Size from PO_ReelDetail where POR_No='" + ddlPOR_No.SelectedValue.ToString() + "'", con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Open();
            ddlPOR_Size.DataSource = dt3;
            ddlPOR_Size.DisplayMember = dt3.Columns[0].ToString();
            ddlPOR_Size.ValueMember = dt3.Columns[0].ToString();
            con.Close();



            SqlCommand cmd3 = new SqlCommand("select convert(varchar(20),POR_Dt,103) as 'POR_Dt',Cr_Dy,Delv_Days,Delv_Place,b.A_Name as 'Agent',c.M_Name as 'Mill' from PO_Reel as a,Agent_Master as b,Mill_Master as c where a.A_ID=b.A_ID and a.M_ID=c.M_ID and POR_No='" + ddlPOR_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtPOR_Dt.Text = Convert.ToString(dr1["POR_Dt"]);
                txtCr_Dy.Text = Convert.ToString(dr1["Cr_Dy"]);
                txtDelv_Days.Text = Convert.ToString(dr1["Delv_Days"]);
                txtDelv_Place.Text = Convert.ToString(dr1["Delv_Place"]);
                txtAgent.Text = Convert.ToString(dr1["Agent"]);
                txtMill.Text = Convert.ToString(dr1["Mill"]);
            }
            dr1.Close();
            con1.Close();


            SqlCommand cmd4 = new SqlCommand("select sum (CAST(POR_Qty as float)) as 'POR_Qty'  from PO_ReelPurchase where POR_No ='" + ddlPOR_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr2 = cmd4.ExecuteReader();
            if (dr2.Read())
            {

                ExistingPOR_Qty = Convert.ToString(dr2["POR_Qty"]);

            }
            else
            {
                ExistingPOR_Qty = "0";
 
            }
            if (ExistingPOR_Qty == "" || ExistingPOR_Qty == null)
            {
                ExistingPOR_Qty = "0";
 
            }
            dr2.Close();
            con1.Close();

        }

        private void ddlPOR_Size_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select b.PQ_Desc as 'Quality',POR_BF as 'BF',POR_GSM as 'GSM',POR_Rate as 'Rate',POR_Qty as 'Quantity'  from PO_ReelDetail as a,PQuality_Master as b where a.PQ_ID=b.PQ_ID and POR_Size='" + ddlPOR_Size.SelectedValue.ToString() + "' and POR_No='"+ddlPOR_No.SelectedValue.ToString()+"'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtPOR_Qual.Text = Convert.ToString(dr1["Quality"]);
                txtPOR_BF.Text = Convert.ToString(dr1["BF"]);
                txtPOR_GSM.Text = Convert.ToString(dr1["GSM"]);
                txtPOR_Rate.Text = Convert.ToString(dr1["Rate"]);
                txtPOR_Qty.Text = Convert.ToString(dr1["Quantity"]);
                strPOR_Qty = Convert.ToString(dr1["Quantity"]);
              
            }
            dr1.Close();
            con1.Close();


            SqlCommand cmd4 = new SqlCommand("select R_StkInHand from Reel_Stock where R_Size='" + ddlPOR_Size.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr2 = cmd4.ExecuteReader();
            if (dr2.Read())
            {

                R_StkInHand = Convert.ToString(dr2["R_StkInHand"]);

            }
            dr2.Close();
            con1.Close();

            if (txtPOR_Qty.Text != "" && txtPOR_Rate.Text != "")
            {

                double Qty = Convert.ToDouble(txtPOR_Qty.Text);
                double Rate = Convert.ToDouble(txtPOR_Rate.Text);

                double amt = Qty * Rate;

                txtReel_Amt.Text = Convert.ToString(Math.Round(amt));
            }
        }

        private void txtPOR_Rate_Leave(object sender, EventArgs e)
        {
            double Qty = Convert.ToDouble(txtPOR_Qty.Text);
            double Rate = Convert.ToDouble(txtPOR_Rate.Text);

            double amt = Qty * Rate;

            txtReel_Amt.Text = Convert.ToString(Math.Round(amt));
        }

        private void txtPOR_Qty_Leave(object sender, EventArgs e)
        {
            double Qty = Convert.ToDouble(txtPOR_Qty.Text);
            double Rate = Convert.ToDouble(txtPOR_Rate.Text);

            double amt = Qty * Rate;

            txtReel_Amt.Text = Convert.ToString(Math.Round(amt));
        }

        private void txtMillReel_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtReel_Wt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtPOR_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtPOR_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtReel_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtReel_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtReel_Dt.Focus();
        }

        private void txtMillReel_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar2.Visible = true;

        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtMillReel_Dt.Text = monthCalendar2.SelectionStart.ToShortDateString();
            monthCalendar2.Visible = false;
            txtMillReel_Dt.Focus();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtReel_No.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Reel No Cannot be Blank");
                txtReel_No.Focus();
            }

            else if (txtReel_Dt.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtReel_Dt.Focus();
            }
            else if (ddlPOR_No.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlPOR_No.Focus();
            }
            else if (txtAgent.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtAgent.Focus();

            }
            else if (txtMill.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtMill.Focus();
            }
            else if (txtCr_Dy.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtCr_Dy.Focus();
            }
            else if (txtDelv_Days.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtDelv_Days.Focus();
            }
            else if (txtDelv_Place.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtDelv_Place.Focus();
            }
            else if (ddlActive.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlActive.Focus();
            }
            else if (txtMillReel_Dt.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtMillReel_Dt.Focus();
            }
            else if (txtMillReel_No.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtMillReel_No.Focus();
            }
            else if (txtReel_Amt.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtReel_Amt.Focus();
            }
            else if (txtPOR_Rate.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPOR_Rate.Focus();
            }
            else if (txtPOR_Qty.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPOR_Qty.Focus();
            }



            else
            {

                //Checking Current Ordered Quantity and substracting with Existing Quantity
                double current = Convert.ToDouble(strPOR_Qty);
                double existingQty = Convert.ToDouble(ExistingPOR_Qty);

                double Balance = current - existingQty;

                double QtyEntered = Convert.ToDouble(txtPOR_Qty.Text);

                if (Balance >= QtyEntered)
                {

                    funclib = new FunctionLib();
                    //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlConnection con1 = new SqlConnection(strcon);


                    //Inserting records 


                    SqlCommand cmdPositive = new SqlCommand("insert into PO_ReelPurchase(Reel_No,Reel_Dt,POR_No,POR_Dt,Grp_ID,MillReel_No,MillReel_Dt,POR_Size,Reel_Wt,POR_Rate,POR_Qty,Reel_Amt,Reel_Active,Add_By,Add_ByNode,Add_On) values('" + txtReel_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txtReel_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlPOR_No.SelectedValue.ToString() + "',convert(datetime,'" + txtPOR_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + Group_ID + "','" + txtMillReel_No.Text.Trim().Replace("'", "''").ToString() + "',Convert(datetime,'" + txtMillReel_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlPOR_Size.SelectedValue.ToString() + "','" + txtReel_Wt.Text.Trim().Replace("'", "''").ToString() + "','" + txtPOR_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + txtPOR_Qty.Text.Trim().Replace("'", "''").ToString() + "','" + txtReel_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + ddlActive.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
                    con.Open();
                    int Positive = cmdPositive.ExecuteNonQuery();
                    if (Positive > 0)
                    {
                        double stockinhand = Convert.ToDouble(R_StkInHand);
                        double POR_qty = Convert.ToDouble(txtPOR_Qty.Text);

                        double NewQty = stockinhand + POR_qty;

                        str_StkInHand = Convert.ToString(Math.Round(NewQty));

                        SqlCommand cmd = new SqlCommand("update Reel_Stock set R_StkInHand = '" + str_StkInHand + "' where R_Size ='" + ddlPOR_Size.SelectedValue.ToString() + "'", con1);
                        con1.Open();
                        cmd.ExecuteNonQuery();
                        con1.Close();

                    }

                    MessageBox.Show("Record Inserted");
                    con.Close();
                    clearAll();

                }
                else
                {
                    MessageBox.Show("Quantity Enterd Should Be less than Purchase Order Quantity which is  " + Balance);
                    txtPOR_Qty.Focus();
                }

            }
        }
        protected void clearAll()
        {
            txtAgent.Text = "";
            txtCr_Dy.Text = "";
            txtDelv_Days.Text = "";
            txtDelv_Place.Text = "";
            txtMill.Text = "";
            txtMillReel_Dt.Text = "";
            txtMillReel_No.Text = "";
            txtPOR_BF.Text = "";
            txtPOR_Dt.Text = "";
            txtPOR_GSM.Text = "";
            txtPOR_Qty.Text = "";
            txtPOR_Qual.Text = "";
            txtPOR_Rate.Text = "";
            txtReel_Amt.Text = "";
            txtReel_Dt.Text = "";
            txtReel_No.Text = "";
            txtReel_Wt.Text = "";
            ddlPOR_No.Text = "";
            ddlPOR_Size.Text = "";
            ddlActive.Text = "Yes";
            ddlActive.Enabled = false;
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            funclib = new FunctionLib();
            //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlConnection con1 = new SqlConnection(strcon);
            Reel_No = funclib.I_ID("R", con, "select Reel_No  from PO_ReelPurchase order by Reel_No  desc");
            txtReel_No.Text = Reel_No;

            ddlPOR_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlPOR_Size.DropDownStyle = ComboBoxStyle.DropDownList;

            txtReel_Dt.Enabled = true;
            ddlPOR_No.Enabled = true;
            txtMillReel_No.Enabled = true;
            txtMillReel_Dt.Enabled = true;
            ddlPOR_Size.Enabled = true;
            txtReel_Wt.Enabled = true;
            txtPOR_Rate.Enabled = true;
            txtReel_Amt.Enabled = true;
            txtPOR_Qty.Enabled = true;

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
                SqlCommand cmd = new SqlCommand("update PO_ReelPurchase set Reel_Active   ='" + ddlActive.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Reel_No  ='" + txtReel_No.Text.Trim().Replace("'", "''").ToString() + "'", con);

                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                con.Close();


                clearAll();
            }
        }

        private void CmdSearch_Click(object sender, EventArgs e)
        {
          

            if (ddlSearch.Text == "Reel No")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select Reel_No as 'Reel No',a.POR_No as 'PO No',c.A_Name as 'Agent',d.M_Name as 'Mill',a.POR_Size as 'Size' from dbo.PO_ReelPurchase as a,PO_Reel as b,Agent_Master as c,Mill_Master as d where a.POR_No=b.POR_No and b.A_ID=c.A_ID and b.M_ID=d.M_ID and a.Reel_No like '%" + txt_Search.Text.ToString() + "%'  order by a.Reel_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else if (ddlSearch.Text == "PO No")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select Reel_No as 'Reel No',a.POR_No as 'PO No',c.A_Name as 'Agent',d.M_Name as 'Mill',a.POR_Size as 'Size' from dbo.PO_ReelPurchase as a,PO_Reel as b,Agent_Master as c,Mill_Master as d where a.POR_No=b.POR_No and b.A_ID=c.A_ID and b.M_ID=d.M_ID and a.POR_No like '%" + txt_Search.Text.ToString() + "%'  order by a.Reel_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else if (ddlSearch.Text == "Agent")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select Reel_No as 'Reel No',a.POR_No as 'PO No',c.A_Name as 'Agent',d.M_Name as 'Mill',a.POR_Size as 'Size' from dbo.PO_ReelPurchase as a,PO_Reel as b,Agent_Master as c,Mill_Master as d where a.POR_No=b.POR_No and b.A_ID=c.A_ID and b.M_ID=d.M_ID and c.A_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.Reel_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else if (ddlSearch.Text == "Mill")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select Reel_No as 'Reel No',a.POR_No as 'PO No',c.A_Name as 'Agent',d.M_Name as 'Mill',a.POR_Size as 'Size' from dbo.PO_ReelPurchase as a,PO_Reel as b,Agent_Master as c,Mill_Master as d where a.POR_No=b.POR_No and b.A_ID=c.A_ID and b.M_ID=d.M_ID and d.M_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.Reel_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else if (ddlSearch.Text == "Size")
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select Reel_No as 'Reel No',a.POR_No as 'PO No',c.A_Name as 'Agent',d.M_Name as 'Mill',a.POR_Size as 'Size' from dbo.PO_ReelPurchase as a,PO_Reel as b,Agent_Master as c,Mill_Master as d where a.POR_No=b.POR_No and b.A_ID=c.A_ID and b.M_ID=d.M_ID and a.POR_Size like '%" + txt_Search.Text.ToString() + "%'  order by a.Reel_No", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;

            }
            else
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select Reel_No as 'Reel No',a.POR_No as 'PO No',c.A_Name as 'Agent',d.M_Name as 'Mill',a.POR_Size as 'Size' from dbo.PO_ReelPurchase as a,PO_Reel as b,Agent_Master as c,Mill_Master as d where a.POR_No=b.POR_No and b.A_ID=c.A_ID and b.M_ID=d.M_ID order by a.Reel_No", con);
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

            txtReel_Dt.Enabled = false;
            ddlPOR_No.Enabled = false;
            txtMillReel_No.Enabled = false;
            txtMillReel_Dt.Enabled = false;
            ddlPOR_Size.Enabled = false;
            txtReel_Wt.Enabled = false;
            txtPOR_Rate.Enabled = false;
            txtReel_Amt.Enabled = false;
            txtPOR_Qty.Enabled = false;

         
            txtReel_No.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            ddlPOR_No.DropDownStyle = ComboBoxStyle.Simple;
            ddlPOR_No.Text = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
          
            txtAgent.Text = GridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMill.Text = GridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            ddlPOR_Size.DropDownStyle = ComboBoxStyle.Simple;
            ddlPOR_Size.Text = GridView1.Rows[e.RowIndex].Cells[4].Value.ToString();



            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

       
            SqlCommand cmd3 = new SqlCommand("select convert(varchar(20),POR_Dt,103) as 'POR_Dt',Cr_Dy,Delv_Days,Delv_Place from PO_Reel as a where POR_No='" + ddlPOR_No.Text.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtPOR_Dt.Text = Convert.ToString(dr1["POR_Dt"]);
                txtCr_Dy.Text = Convert.ToString(dr1["Cr_Dy"]);
                txtDelv_Days.Text = Convert.ToString(dr1["Delv_Days"]);
                txtDelv_Place.Text = Convert.ToString(dr1["Delv_Place"]);
            
            }
            dr1.Close();
            con1.Close();


            SqlCommand cmd4 = new SqlCommand("select convert(varchar(20),Reel_Dt,103) as 'Reel_Dt',MillReel_No,convert(varchar(20),MillReel_Dt,103) as 'MillReel_Dt',Reel_Wt,POR_Rate,POR_Qty,Reel_Amt,Reel_Active from PO_ReelPurchase as a where Reel_No='" + txtReel_No.Text.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr2 = cmd4.ExecuteReader();
            if (dr2.Read())
            {

                txtReel_Dt.Text = Convert.ToString(dr2["Reel_Dt"]);
                txtMillReel_No.Text = Convert.ToString(dr2["MillReel_No"]);
                txtMillReel_Dt.Text = Convert.ToString(dr2["MillReel_Dt"]);
                txtReel_Wt.Text = Convert.ToString(dr2["Reel_Wt"]);
                txtPOR_Rate.Text = Convert.ToString(dr2["POR_Rate"]);
                txtPOR_Qty.Text = Convert.ToString(dr2["POR_Qty"]);
                txtReel_Amt.Text = Convert.ToString(dr2["Reel_Amt"]);
                ddlActive.Text = Convert.ToString(dr2["Reel_Active"]);

            }
            dr2.Close();
            con1.Close();


            SqlCommand cmd5 = new SqlCommand("select b.PQ_Desc as 'Quality',POR_BF as 'BF',POR_GSM as 'GSM'  from PO_ReelDetail as a,PQuality_Master as b where a.PQ_ID=b.PQ_ID and POR_Size='" + ddlPOR_Size.Text.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr5 = cmd5.ExecuteReader();
            if (dr5.Read())
            {

                txtPOR_Qual.Text = Convert.ToString(dr5["Quality"]);
                txtPOR_BF.Text = Convert.ToString(dr5["BF"]);
                txtPOR_GSM.Text = Convert.ToString(dr5["GSM"]);
         

            }
            dr5.Close();
            con1.Close();
           
        }
    }
}
