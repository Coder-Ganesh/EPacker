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
    public partial class RPeP_DispNewChallan : Form
    {
        string session, strSQL, Group_ID, Challan_No;
        string P_Name, P_ID, P_PONo, P_PODt, Box_Qty, Desp_Det;
        string griOrder_ID, griPartyPono, griPartoPoDt, griP_Name, strOpenDoc, Grp_Name;
        private FunctionLib funclib;
        public RPeP_DispNewChallan()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_DispNewChallan_Load(object sender, EventArgs e)
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

            Challan_No = funclib.Challan_ID("CH", con, "select Challan_No from Dispatch_Challan order by Challan_No  desc");
            txtChallan_No.Text = Challan_No;

            ddlSearch.Items.Add("");
            ddlSearch.Items.Add("Challan No.");
            ddlSearch.Items.Add("Order No.");
            ddlSearch.Items.Add("Party");
            ddlSearch.Items.Add("Party PO");
            ddlSearch.Items.Add("Party PO Dt.");
            ddlSearch.Items.Add("Item");
            ddlSearch.Items.Add("Order Qty.");
            ddlSearch.Items.Add("Qty.");
            ddlSearch.Items.Add("Amt.");

        }

        private void txtOrder_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtChallan_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtChallan_Dt.Focus();
        }

        private void cmdOrderSearch_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' and b.P_Name like '%" + txtOrderSearch.Text.Trim().ToString() + "%' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlOrder_ID.DataSource = dt;
            ddlOrder_ID.DisplayMember = dt.Columns[0].ToString();
            ddlOrder_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void ddlOrder_ID_SelectedIndexChanged(object sender, EventArgs e)
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

        private void txtVeh_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtChallan_Type_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyCharacterPress(e);
        }

        private void txtChallan_Type_Leave(object sender, EventArgs e)
        {
            string Upp = txtChallan_Type.Text.ToUpper();
            txtChallan_Type.Text = Upp;
        }

        private void txtFre_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtExc_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtBundle_Note_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtPer_Det_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtDesp_Det_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtWt_Det_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtAvgWg_Det_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtRate_Det_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtDisc_Det_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtTotal_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtDiscount_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtNet_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtExcise_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtEduPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtEdu_Cess_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtHSECPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtHSEC_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtCSTPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtCST_VAT_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtFreight_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);

        }

        private void txtGrand_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtChallan_No.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Challan No Cannot be Blank");
                txtChallan_No.Focus();
            }

            else if (txtChallan_Dt.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtChallan_Dt.Focus();
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
            else if (txtChallan_Type.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtChallan_Type.Focus();
            }
            else if (txtBundle_Note.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtBundle_Note.Focus();
            }
            else if (txtPer_Det.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPer_Det.Focus();
            }
            else if (txtDesp_Det.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtDesp_Det.Focus();
            }
            else if (txtWt_Det.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtWt_Det.Focus();
            }
            else if (txtAvgWg_Det.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtAvgWg_Det.Focus();
            }
            else if (txtRate_Det.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtRate_Det.Focus();
            }
            else if (txtDisc_Det.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtDisc_Det.Focus();
            }
            else if (txtTotal_Amt.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtTotal_Amt.Focus();
            }
            //else if (ddlTP_ID.Text == "")
            //{
            //    MessageBox.Show("Field Cannot Be Balnk");
            //    ddlTP_ID.Focus();
            //}
            else if (txtGrand_Amt.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtGrand_Amt.Focus();
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

                SqlCommand cmd3 = new SqlCommand("select Desp_Det  from Dispatch_Challan where Order_ID ='"+ddlOrder_ID.SelectedValue.ToString()+"'", con1);
                con1.Open();
                SqlDataReader dr1 = cmd3.ExecuteReader();
                if (dr1.Read())
                {

                    Desp_Det = Convert.ToString(dr1["Desp_Det"]);

                }
                else
                {
                    Desp_Det = "0";
                }
                dr1.Close();
                con1.Close();

                double Despath_QtyOlder = Convert.ToDouble(Desp_Det);
                double Despath_Qty = Convert.ToDouble(txtDesp_Det.Text);

                double TotalDespath_Qty = Despath_QtyOlder + Despath_Qty;

                double Order_Qty = Convert.ToDouble(txtOrder_Qty.Text);

                if (TotalDespath_Qty > Order_Qty)
                {
                    MessageBox.Show("Despatch Qty. cannot be greater than Order Qty.");
                
                }

                else
                {

                   
                    //Inserting records 

                    SqlCommand cmdPositive = new SqlCommand("insert into Dispatch_Challan(Challan_No,Challan_Dt,Grp_ID,Order_ID,P_ID,LR_No,Veh_No,Trans_Name,Challan_Type,Local_Sales,Fre_Amt,Exc_Amt,Bundle_Note,Per_Det,Desp_Det,Wt_Det,AvgWg_Det,Rate_Det,Disc_Det,Total_Amt,Discount_Amt,Net_Amt,Excise_Amt,Edu_Cess_Amt,HSEC_Amt,CST_VAT_Amt,Freight_Amt,Grand_Amt,Challan_Active,Add_By,Add_ByNode,Add_On) values('" + txtChallan_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txtChallan_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + Group_ID + "','" + ddlOrder_ID.SelectedValue.ToString() + "','" + P_ID.Trim().Replace("'", "''").ToString() + "','" + txtLR_No.Text.Trim().Replace("'", "''").ToString() + "','" + txtVeh_No.Text.Trim().Replace("'", "''").ToString() + "','" + txtTrans_Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtChallan_Type.Text.Trim().Replace("'", "''").ToString() + "','" + txtLocal_Sales.Text.Trim().Replace("'", "''").ToString() + "','" + txtFre_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtExc_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtBundle_Note.Text.Trim().Replace("'", "''").ToString() + "','" + txtPer_Det.Text.Trim().Replace("'", "''").ToString() + "','" + txtDesp_Det.Text.Trim().Replace("'", "''").ToString() + "','" + txtWt_Det.Text.Trim().Replace("'", "''").ToString() + "','" + txtAvgWg_Det.Text.Trim().Replace("'", "''").ToString() + "','" + txtRate_Det.Text.Trim().Replace("'", "''").ToString() + "','" + txtDisc_Det.Text.Trim().Replace("'", "''").ToString() + "','" + txtTotal_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtDiscount_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtNet_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtExc_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtEdu_Cess_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtHSEC_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtCST_VAT_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtFreight_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtGrand_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + ddlActive.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
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
        }

        protected void ClearAll()
        {

            ddlOrder_ID.Text = "";            
            txt_Search.Text = "";
            txtAvgWg_Det.Text = "";
            txtBundle_Note.Text = "";
            txtChallan_Dt.Text = "";
            txtChallan_No.Text = "";
            txtChallan_Type.Text = "";
            txtCST_VAT_Amt.Text = "";
            txtCSTPercentage.Text = "";
            txtDesp_Det.Text = "";
            txtDisc_Det.Text = "";
            txtDiscount_Amt.Text = "";
            txtEdu_Cess_Amt.Text = "";
            txtEduPercentage.Text = "";
            txtExc_Amt.Text = "";
            txtExcise_Amt.Text = "";
            txtFre_Amt.Text = "";
            txtFreight_Amt.Text = "";
            txtGrand_Amt.Text = "";
            txtHSEC_Amt.Text = "";
            txtHSECPercentage.Text = "";
            txtLocal_Sales.Text = "";
            txtLR_No.Text = "";
            txtNet_Amt.Text = "";
            txtOrder_Qty.Text = "";
            txtOrderSearch.Text = "";
            txtP_ID.Text = "";
            txtPer_Det.Text = "";
            txtPoandDate.Text = "";
            txtRate_Det.Text = "";
            txtTotal_Amt.Text = "";
            txtTrans_Name.Text = "";
            txtVeh_No.Text = "";
            txtWt_Det.Text = "";

          
            ddlSearch.Text = "";

            ddlOrder_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlActive.Text = "Yes";
            cmdPrint.Visible = false;
            ddlActive.Enabled = false;


            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            Challan_No = funclib.Challan_ID("CH", con, "select Challan_No from Dispatch_Challan order by Challan_No  desc");
            txtChallan_No.Text = Challan_No;


            ddlActive.Enabled = false;
            txtChallan_Dt.Enabled = true;
            txtAvgWg_Det.Enabled = true;
            txtBundle_Note.Enabled = true;
            txtChallan_Type.Enabled = true;
            txtCST_VAT_Amt.Enabled = true;
            txtCSTPercentage.Enabled = true;
            txtDesp_Det.Enabled = true;
            txtDisc_Det.Enabled = true;
            txtDiscount_Amt.Enabled = true;
            txtEdu_Cess_Amt.Enabled = true;
            txtEduPercentage.Enabled = true;
            txtExc_Amt.Enabled = true;
            txtExcise_Amt.Enabled = true;
            txtFre_Amt.Enabled = true;
            txtFreight_Amt.Enabled = true;
            txtGrand_Amt.Enabled = true;
            txtHSEC_Amt.Enabled = true;
            txtHSECPercentage.Enabled = true;
            txtLocal_Sales.Enabled = true;
            txtLR_No.Enabled = true;
            txtNet_Amt.Enabled = true;
            txtPer_Det.Enabled = true;
            txtRate_Det.Enabled = true;
            txtTotal_Amt.Enabled = true;
            txtTrans_Name.Enabled = true;
            txtVeh_No.Enabled = true;
            txtWt_Det.Enabled = true;
            ddlOrder_ID.Enabled = true;

            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;
          

        }
        private void cmdReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void CmdSearch_Click(object sender, EventArgs e)
        {       

            if (ddlSearch.Text == "Challan No.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Challan_No as 'Challan No.' ,a.Order_ID as 'Order No.',b.P_Name as 'Party',C.P_PONo  as 'Party PO No.',convert (varchar(20),c.P_PODt,103)  as 'Party PO Dt.',d.I_Name as 'Item',c.Box_Qty  as 'Order Qty.',a.Desp_Det  as 'Qty',a.Grand_Amt  as 'Amt.'   from Dispatch_Challan as a,Party_Master as b,Item_Order as c,Item_Master as d where a.P_ID=b.P_ID and a.Order_ID=c.Order_ID and c.I_ID=d.I_ID and a.Challan_No like '%" + txt_Search.Text.ToString() + "%'  order by a.Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
            }
            else if (ddlSearch.Text == "Order No.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Challan_No as 'Challan No.' ,a.Order_ID as 'Order No.',b.P_Name as 'Party',C.P_PONo  as 'Party PO No.',convert (varchar(20),c.P_PODt,103)  as 'Party PO Dt.',d.I_Name as 'Item',c.Box_Qty  as 'Order Qty.',a.Desp_Det  as 'Qty',a.Grand_Amt  as 'Amt.'   from Dispatch_Challan as a,Party_Master as b,Item_Order as c,Item_Master as d where a.P_ID=b.P_ID and a.Order_ID=c.Order_ID and c.I_ID=d.I_ID and a.Order_ID like '%" + txt_Search.Text.ToString() + "%'  order by a.Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
            }
            else if (ddlSearch.Text == "Party")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Challan_No as 'Challan No.' ,a.Order_ID as 'Order No.',b.P_Name as 'Party',C.P_PONo  as 'Party PO No.',convert (varchar(20),c.P_PODt,103)  as 'Party PO Dt.',d.I_Name as 'Item',c.Box_Qty  as 'Order Qty.',a.Desp_Det  as 'Qty',a.Grand_Amt  as 'Amt.'   from Dispatch_Challan as a,Party_Master as b,Item_Order as c,Item_Master as d where a.P_ID=b.P_ID and a.Order_ID=c.Order_ID and c.I_ID=d.I_ID and b.P_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
            }
            else if (ddlSearch.Text == "Party PO")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Challan_No as 'Challan No.' ,a.Order_ID as 'Order No.',b.P_Name as 'Party',C.P_PONo  as 'Party PO No.',convert (varchar(20),c.P_PODt,103)  as 'Party PO Dt.',d.I_Name as 'Item',c.Box_Qty  as 'Order Qty.',a.Desp_Det  as 'Qty',a.Grand_Amt  as 'Amt.'   from Dispatch_Challan as a,Party_Master as b,Item_Order as c,Item_Master as d where a.P_ID=b.P_ID and a.Order_ID=c.Order_ID and c.I_ID=d.I_ID and C.P_PONo like '%" + txt_Search.Text.ToString() + "%'  order by a.Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
            }
            else if (ddlSearch.Text == "Party PO Dt.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Challan_No as 'Challan No.' ,a.Order_ID as 'Order No.',b.P_Name as 'Party',C.P_PONo  as 'Party PO No.',convert (varchar(20),c.P_PODt,103)  as 'Party PO Dt.',d.I_Name as 'Item',c.Box_Qty  as 'Order Qty.',a.Desp_Det  as 'Qty',a.Grand_Amt  as 'Amt.'   from Dispatch_Challan as a,Party_Master as b,Item_Order as c,Item_Master as d where a.P_ID=b.P_ID and a.Order_ID=c.Order_ID and c.I_ID=d.I_ID and c.P_PODt = Convert(datetime,'" + txt_Search.Text + "',103)   order by a.Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
            }
            else if (ddlSearch.Text == "Item")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Challan_No as 'Challan No.' ,a.Order_ID as 'Order No.',b.P_Name as 'Party',C.P_PONo  as 'Party PO No.',convert (varchar(20),c.P_PODt,103)  as 'Party PO Dt.',d.I_Name as 'Item',c.Box_Qty  as 'Order Qty.',a.Desp_Det  as 'Qty',a.Grand_Amt  as 'Amt.'   from Dispatch_Challan as a,Party_Master as b,Item_Order as c,Item_Master as d where a.P_ID=b.P_ID and a.Order_ID=c.Order_ID and c.I_ID=d.I_ID and d.I_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
            }
            else if (ddlSearch.Text == "Order Qty.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Challan_No as 'Challan No.' ,a.Order_ID as 'Order No.',b.P_Name as 'Party',C.P_PONo  as 'Party PO No.',convert (varchar(20),c.P_PODt,103)  as 'Party PO Dt.',d.I_Name as 'Item',c.Box_Qty  as 'Order Qty.',a.Desp_Det  as 'Qty',a.Grand_Amt  as 'Amt.'   from Dispatch_Challan as a,Party_Master as b,Item_Order as c,Item_Master as d where a.P_ID=b.P_ID and a.Order_ID=c.Order_ID and c.I_ID=d.I_ID and c.Box_Qty like '%" + txt_Search.Text.ToString() + "%'  order by a.Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
            }
            else if (ddlSearch.Text == "Qty.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Challan_No as 'Challan No.' ,a.Order_ID as 'Order No.',b.P_Name as 'Party',C.P_PONo  as 'Party PO No.',convert (varchar(20),c.P_PODt,103)  as 'Party PO Dt.',d.I_Name as 'Item',c.Box_Qty  as 'Order Qty.',a.Desp_Det  as 'Qty',a.Grand_Amt  as 'Amt.'   from Dispatch_Challan as a,Party_Master as b,Item_Order as c,Item_Master as d where a.P_ID=b.P_ID and a.Order_ID=c.Order_ID and c.I_ID=d.I_ID and a.Desp_Det like '%" + txt_Search.Text.ToString() + "%'  order by a.Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
            }
            else if (ddlSearch.Text == "Amt.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Challan_No as 'Challan No.' ,a.Order_ID as 'Order No.',b.P_Name as 'Party',C.P_PONo  as 'Party PO No.',convert (varchar(20),c.P_PODt,103)  as 'Party PO Dt.',d.I_Name as 'Item',c.Box_Qty  as 'Order Qty.',a.Desp_Det  as 'Qty',a.Grand_Amt  as 'Amt.'   from Dispatch_Challan as a,Party_Master as b,Item_Order as c,Item_Master as d where a.P_ID=b.P_ID and a.Order_ID=c.Order_ID and c.I_ID=d.I_ID and a.Grand_Amt like '%" + txt_Search.Text.ToString() + "%'  order by a.Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
            }
            else
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select a.Challan_No as 'Challan No.' ,a.Order_ID as 'Order No.',b.P_Name as 'Party',C.P_PONo  as 'Party PO No.',convert (varchar(20),c.P_PODt,103)  as 'Party PO Dt.',d.I_Name as 'Item',c.Box_Qty  as 'Order Qty.',a.Desp_Det  as 'Qty',a.Grand_Amt  as 'Amt.'   from Dispatch_Challan as a,Party_Master as b,Item_Order as c,Item_Master as d where a.P_ID=b.P_ID and a.Order_ID=c.Order_ID and c.I_ID=d.I_ID order by a.Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            
            cmdPrint.Visible = true;

            ddlActive.Enabled = true;
            txtChallan_Dt.Enabled = false;
            txtAvgWg_Det.Enabled = false;
            txtBundle_Note.Enabled = false;
            txtChallan_Type.Enabled = false;
            txtCST_VAT_Amt.Enabled = false;
            txtCSTPercentage.Enabled = false;
            txtDesp_Det.Enabled = false;
            txtDisc_Det.Enabled = false;
            txtDiscount_Amt.Enabled = false;
            txtEdu_Cess_Amt.Enabled = false;
            txtEduPercentage.Enabled = false;
            txtExc_Amt.Enabled = false;
            txtExcise_Amt.Enabled = false;
            txtFre_Amt.Enabled = false;
            txtFreight_Amt.Enabled = false;
            txtGrand_Amt.Enabled = false;
            txtHSEC_Amt.Enabled = false;
            txtHSECPercentage.Enabled = false;
            txtLocal_Sales.Enabled = false;
            txtLR_No.Enabled = false;
            txtNet_Amt.Enabled = false;
            txtPer_Det.Enabled = false;
            txtRate_Det.Enabled = false;
            txtTotal_Amt.Enabled = false;
            txtTrans_Name.Enabled = false;
            txtVeh_No.Enabled = false;
            txtWt_Det.Enabled = false;
            ddlOrder_ID.Enabled = false;

            
            txtChallan_No.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //ddlOrder_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            griOrder_ID = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtP_ID.Text = GridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            griPartyPono = GridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            griPartoPoDt = GridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtOrder_Qty.Text = GridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtDesp_Det.Text = GridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtGrand_Amt.Text = GridView1.Rows[e.RowIndex].Cells[8].Value.ToString();


            txtPoandDate.Text = griPartyPono + "  " + griPartoPoDt;

            ddlOrder_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlOrder_ID.Text = griOrder_ID;





            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select convert (varchar(20),a.Challan_Dt,103)  as 'Challan_Dt',LR_No,Veh_No,Challan_Type,Local_Sales,Fre_Amt,Exc_Amt,Bundle_Note,Per_Det,Desp_Det,Wt_Det,AvgWg_Det,Rate_Det,Disc_Det,Total_Amt,Discount_Amt,Net_Amt,Excise_Amt,Edu_Cess_Amt,HSEC_Amt,CST_VAT_Amt,Freight_Amt,Grand_Amt,Challan_Active from Dispatch_Challan as a where a.Challan_No ='"+txtChallan_No.Text+"' ", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtChallan_Dt.Text = Convert.ToString(dr1["Challan_Dt"]);
                txtLR_No.Text = Convert.ToString(dr1["LR_No"]);
                txtVeh_No.Text = Convert.ToString(dr1["Veh_No"]);
                txtChallan_Type.Text = Convert.ToString(dr1["Challan_Type"]);
                txtFre_Amt.Text = Convert.ToString(dr1["Fre_Amt"]);
                txtExc_Amt.Text = Convert.ToString(dr1["Exc_Amt"]);
                txtBundle_Note.Text = Convert.ToString(dr1["Bundle_Note"]);
                txtPer_Det.Text = Convert.ToString(dr1["Per_Det"]);
                txtDesp_Det.Text = Convert.ToString(dr1["Desp_Det"]);
                txtWt_Det.Text = Convert.ToString(dr1["Wt_Det"]);
                txtAvgWg_Det.Text = Convert.ToString(dr1["AvgWg_Det"]);
                txtRate_Det.Text = Convert.ToString(dr1["Rate_Det"]);
                txtDisc_Det.Text = Convert.ToString(dr1["Disc_Det"]);
                txtTotal_Amt.Text = Convert.ToString(dr1["Total_Amt"]);
                txtDiscount_Amt.Text = Convert.ToString(dr1["Discount_Amt"]);
                txtNet_Amt.Text = Convert.ToString(dr1["Net_Amt"]);
                txtExcise_Amt.Text = Convert.ToString(dr1["Excise_Amt"]);
                txtEdu_Cess_Amt.Text = Convert.ToString(dr1["Edu_Cess_Amt"]);
                txtHSEC_Amt.Text = Convert.ToString(dr1["HSEC_Amt"]);
                txtCST_VAT_Amt.Text = Convert.ToString(dr1["CST_VAT_Amt"]);
                txtFreight_Amt.Text = Convert.ToString(dr1["Freight_Amt"]);
                txtGrand_Amt.Text = Convert.ToString(dr1["Grand_Amt"]);
                ddlActive.Text = Convert.ToString(dr1["Challan_Active"]);
                
            }
            dr1.Close();
            con1.Close();
     
          
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Dispatch_Challan set Challan_Active  ='" + ddlActive.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Challan_No ='" + txtChallan_No.Text.Trim().Replace("'", "''").ToString() + "'", con);

                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");

                ClearAll();
            }
        }

        private void txt_Search_MouseClick(object sender, MouseEventArgs e)
        {
            if (ddlSearch.Text == "Party PO Dt.")
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
            sfd.FileName = "DispatchNewChallan.pdf";
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


                    Chunk chunk = new Chunk("Dispatch : New Challan" + '\n', titleFont);
                    chunk.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaTitle = new Paragraph(chunk);
                    ParaTitle.SpacingBefore = 5f;
                    ParaTitle.SpacingAfter = 5f;




                    var phrase2 = new Phrase();
                    phrase2.Add(new Chunk("Challan No.: ", underline));
                    Chunk c2 = new Chunk(txtChallan_No.Text.Trim().ToString(), underline);
                    c2.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c2);

                    phrase2.Add(new Chunk("        "));

                    phrase2.Add(new Chunk("Challan Dt.: ", underline));
                    Chunk c3 = new Chunk(txtChallan_Dt.Text.Trim().ToString() + '\n', underline);
                    c3.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c3);

                    Paragraph pf1 = new Paragraph(phrase2);

                    var phrase3 = new Phrase();
                    phrase3.Add(new Chunk("Order No.:     ", underline));
                    Chunk c4 = new Chunk(ddlOrder_ID.SelectedValue.ToString(), underline);
                    c4.SetUnderline(0.5f, -1.5f);
                    phrase3.Add(c4);


                    Paragraph pf1_1 = new Paragraph(phrase3);

                    var phrase4 = new Phrase();
                    phrase4.Add(new Chunk("Party :     ", underline));
                    Chunk cadd = new Chunk(P_Name + '\n', underline);
                    cadd.SetUnderline(0.5f, -1.5f);
                    phrase4.Add(cadd);

                    Paragraph pf2 = new Paragraph(phrase4);


                    var phrase33 = new Phrase();
                    phrase33.Add(new Chunk("Party PO No. & Dt. :", underline));
                    Chunk c44 = new Chunk(txtPoandDate.Text.Trim().ToString(), underline);
                    c44.SetUnderline(0.5f, -1.5f);
                    phrase33.Add(c44);

                    phrase33.Add(new Chunk("         "));

                    phrase33.Add(new Chunk("Order Qty. :", underline));
                    Chunk c55 = new Chunk(txtOrder_Qty.Text.Trim().ToString(), underline);
                    c55.SetUnderline(0.5f, -1.5f);
                    phrase33.Add(c55);


                    Paragraph pf3 = new Paragraph(phrase33);




                    var phrase7 = new Phrase();
                    phrase7.Add(new Chunk("L.R. No. :", underline));
                    Chunk c7 = new Chunk(txtLR_No.Text.Trim().ToString(), underline);
                    c7.SetUnderline(0.5f, -1.5f);
                    phrase7.Add(c7);

                    phrase7.Add(new Chunk("      "));

                    phrase7.Add(new Chunk("Vehicle No. :", underline));
                    Chunk c71 = new Chunk(txtVeh_No.Text.Trim().ToString(), underline);
                    c71.SetUnderline(0.5f, -1.5f);
                    phrase7.Add(c71);


                    Paragraph pf4 = new Paragraph(phrase7);
                    // pf4.SpacingBefore = 5f;
                    //    pf4.SpacingAfter = 10f;




                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("Type :     ", underline));
                    Chunk c81 = new Chunk(txtChallan_Type.Text.Trim().ToString(), underline);
                    c81.SetUnderline(0.5f, -1.5f);
                    phrase8.Add(c81);

                    phrase8.Add(new Chunk("      "));

                    phrase8.Add(new Chunk("Local Sales :", underline));
                    Chunk c82 = new Chunk(txtLocal_Sales.Text.Trim().ToString(), underline);
                    c82.SetUnderline(0.5f, -1.5f);
                    phrase8.Add(c82);

                    Paragraph pf7 = new Paragraph(phrase8);
                    // pf4.SpacingBefore = 5f;


                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("Freight Amt.:", underline));
                    Chunk cins = new Chunk(txtFre_Amt.Text.Trim().ToString(), underline);
                    cins.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(cins);


                    phraseIns.Add(new Chunk("      "));

                    phraseIns.Add(new Chunk("Excise :", underline));
                    Chunk c83 = new Chunk(txtExc_Amt.Text.Trim().ToString(), underline);
                    c83.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(c83);


                    Paragraph pf8 = new Paragraph(phraseIns);
                    pf8.SpacingAfter = 5f;

               


                    doc.Add(MainTitle);

                    doc.Add(ParaTitle);
                    doc.Add(pf1);
                    doc.Add(pf1_1);
                    doc.Add(pf2);
                    doc.Add(pf3);
                    doc.Add(pf4);                                    
                    doc.Add(pf7);             
               
                    doc.Add(pf8);


                    LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line3));


                    //Itemg Grid2

                    PdfPTable t2 = new PdfPTable(7);
                    //float[] widthst1 = new float[] { 1f,1f,1f,1f,1.4f,1f,1f };
                    //t2.SetWidths(widthst1);
                    t2.DefaultCell.BorderWidth = 0;
                    t2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    t2.DefaultCell.BorderColor = BaseColor.WHITE;
                    t2.WidthPercentage = 100;
                    //t2.SpacingAfter = 4f;




                    PdfPCell Length_MM = new PdfPCell(new Phrase("BUNDLE", underlinBold));
                    PdfPCell Width_MM = new PdfPCell(new Phrase("PER", underlinBold));
                    PdfPCell Height_MM = new PdfPCell(new Phrase("DESPATCH", underlinBold));
                    PdfPCell Dimn_Opt = new PdfPCell(new Phrase("WEIGHT", underlinBold));
                    PdfPCell Length_MM_Conv = new PdfPCell(new Phrase("AVG.WG.", underlinBold));
                    PdfPCell Width_MM_Conv = new PdfPCell(new Phrase("RATE", underlinBold));
                    PdfPCell Height_MM_Conv = new PdfPCell(new Phrase("DISC", underlinBold));



                    Length_MM.BorderColor = BaseColor.WHITE;
                    Width_MM.BorderColor = BaseColor.WHITE;

                    Height_MM.BorderColor = BaseColor.WHITE;
                    Dimn_Opt.BorderColor = BaseColor.WHITE;
                    Length_MM_Conv.BorderColor = BaseColor.WHITE;
                    Width_MM_Conv.BorderColor = BaseColor.WHITE;
                    Height_MM_Conv.BorderColor = BaseColor.WHITE;



                    t2.AddCell(Length_MM);
                    t2.AddCell(Width_MM);
                    t2.AddCell(Height_MM);
                    t2.AddCell(Dimn_Opt);
                    t2.AddCell(Length_MM_Conv);
                    t2.AddCell(Width_MM_Conv);
                    t2.AddCell(Height_MM_Conv);

                                   
                    
                        PdfPCell c1_1 = new PdfPCell(new Phrase(txtBundle_Note.Text, underlinBold));
                        PdfPCell c1 = new PdfPCell(new Phrase(txtPer_Det.Text, underlinBold));

                        PdfPCell c32 = new PdfPCell(new Phrase(txtDesp_Det.Text, underlinBold));
                        PdfPCell c33 = new PdfPCell(new Phrase(txtWt_Det.Text, underlinBold));
                        PdfPCell c34 = new PdfPCell(new Phrase(txtAvgWg_Det.Text, underlinBold));
                        PdfPCell c35 = new PdfPCell(new Phrase(txtRate_Det.Text, underlinBold));
                        PdfPCell c36 = new PdfPCell(new Phrase(txtDisc_Det.Text, underlinBold));




                        c1_1.BorderColor = BaseColor.BLACK;
                        c1.BorderColor = BaseColor.BLACK;
                        c32.BorderColor = BaseColor.BLACK;
                        c33.BorderColor = BaseColor.BLACK;
                        c34.BorderColor = BaseColor.BLACK;
                        c35.BorderColor = BaseColor.BLACK;
                        c36.BorderColor = BaseColor.BLACK;

                        t2.AddCell(c1_1);
                        t2.AddCell(c1);
                        t2.AddCell(c32);
                        t2.AddCell(c33);
                        t2.AddCell(c34);
                        t2.AddCell(c35);
                        t2.AddCell(c36);




                        doc.Add(t2);

                        LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                        doc.Add(new Chunk(line));

                
                        var phrase9 = new Phrase();
                        phrase9.Add(new Chunk("Total Amount", underline));
                        phrase9.Add(new Chunk("                        "));
                        Chunk c9 = new Chunk(txtTotal_Amt.Text.Trim().ToString(), underline);
                        c9.SetUnderline(0.5f, -1.5f);
                        phrase9.Add(c9);
                        Paragraph pf9 = new Paragraph(phrase9);
                        

                       

                        var phrase10 = new Phrase();
                        phrase10.Add(new Chunk("Discount Amount", underline));
                        phrase10.Add(new Chunk("                   "));
                        Chunk c91 = new Chunk(txtDiscount_Amt.Text.Trim().ToString(), underline);
                        c91.SetUnderline(0.5f, -1.5f);
                        phrase10.Add(c91);
                        Paragraph pf10 = new Paragraph(phrase10);


                        var phrase11 = new Phrase();
                        phrase11.Add(new Chunk("Net Amount", underline));
                        phrase11.Add(new Chunk("                          "));
                        Chunk c11 = new Chunk(txtNet_Amt.Text.Trim().ToString(), underline);
                        c11.SetUnderline(0.5f, -1.5f);
                        phrase11.Add(c11);
                        Paragraph pf11 = new Paragraph(phrase11);



                        var phrase12 = new Phrase();
                        phrase12.Add(new Chunk("Excise Amount", underline));
                        phrase12.Add(new Chunk("                      "));
                        Chunk c12 = new Chunk(txtExcise_Amt.Text.Trim().ToString(), underline);
                        c12.SetUnderline(0.5f, -1.5f);
                        phrase12.Add(c12);
                        Paragraph pf12 = new Paragraph(phrase12);


                        var phrase13 = new Phrase();
                        phrase13.Add(new Chunk("Edu.Cess Amount     ", underline));

                        Chunk c14 = new Chunk(txtEduPercentage.Text.Trim().ToString() + "%", underline);
                        //c14.SetUnderline(0.5f, -1.5f);
                        phrase13.Add(c14);

                        phrase13.Add(new Chunk("        "));

                        Chunk c13 = new Chunk(txtEdu_Cess_Amt.Text.Trim().ToString(), underline);
                        c13.SetUnderline(0.5f, -1.5f);
                        phrase13.Add(c13);
                        Paragraph pf13 = new Paragraph(phrase13);


                        var phrase14 = new Phrase();
                        phrase14.Add(new Chunk("HSEC Amount           ", underline));

                        Chunk c15 = new Chunk(txtHSECPercentage.Text.Trim().ToString() + "%", underline);
                        //c15.SetUnderline(0.5f, -1.5f);
                        phrase14.Add(c15);

                        phrase14.Add(new Chunk("        "));

                        Chunk c16 = new Chunk(txtHSEC_Amt.Text.Trim().ToString(), underline);
                        c16.SetUnderline(0.5f, -1.5f);
                        phrase14.Add(c16);
                        Paragraph pf14 = new Paragraph(phrase14);



                        var phrase15 = new Phrase();
                        phrase15.Add(new Chunk("CST/VAT Amount      ", underline));

                        Chunk c17 = new Chunk(txtCSTPercentage.Text.Trim().ToString() + "%", underline);
                        c16.SetUnderline(0.5f, -1.5f);
                        phrase15.Add(c17);

                        phrase15.Add(new Chunk("        "));

                        Chunk c18 = new Chunk(txtCST_VAT_Amt.Text.Trim().ToString(), underline);
                        c18.SetUnderline(0.5f, -1.5f);
                        phrase15.Add(c18);
                        Paragraph pf15 = new Paragraph(phrase15);



                        var phrase16 = new Phrase();
                        phrase16.Add(new Chunk("Freight Amount", underline));
                        phrase16.Add(new Chunk("                      "));
                        Chunk c19 = new Chunk(txtFreight_Amt.Text.Trim().ToString(), underline);
                        c19.SetUnderline(0.5f, -1.5f);
                        phrase16.Add(c19);
                        Paragraph pf16 = new Paragraph(phrase16);


                        var phrase17 = new Phrase();
                        phrase17.Add(new Chunk("Grand Amount", underline));
                        phrase17.Add(new Chunk("                       "));
                        Chunk c20 = new Chunk(txtGrand_Amt.Text.Trim().ToString(), underline);
                        c20.SetUnderline(0.5f, -1.5f);
                        phrase17.Add(c20);
                        Paragraph pf17 = new Paragraph(phrase17);


                    
                      
                        doc.Add(pf9);
                        doc.Add(pf10);
                        doc.Add(pf11);
                        doc.Add(pf12);
                        doc.Add(pf13);
                        doc.Add(pf14);
                        doc.Add(pf15);
                        doc.Add(pf16);
                        doc.Add(pf17);

                        LineSeparator line2 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                        doc.Add(new Chunk(line2));

                


                }
                catch (DocumentException dex)
                {


                    //Handle document exception
                }
                catch (IOException ioex)
                {
                    //Handle IO exception
                }
                catch (Exception ex)
                {
                    //Handle Other Exception
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
            sfd.FileName = "CopyOfDispatchNewChallan.pdf";
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


                    Chunk chunk = new Chunk("Dispatch : New Challan  (Copy)" + '\n', titleFont);
                    chunk.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaTitle = new Paragraph(chunk);
                    ParaTitle.SpacingBefore = 5f;
                    ParaTitle.SpacingAfter = 5f;




                    var phrase2 = new Phrase();
                    phrase2.Add(new Chunk("Challan No.: ", underline));
                    Chunk c2 = new Chunk(txtChallan_No.Text.Trim().ToString(), underline);
                    c2.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c2);

                    phrase2.Add(new Chunk("        "));

                    phrase2.Add(new Chunk("Challan Dt.: ", underline));
                    Chunk c3 = new Chunk(txtChallan_Dt.Text.Trim().ToString() + '\n', underline);
                    c3.SetUnderline(0.5f, -1.5f);
                    phrase2.Add(c3);

                    Paragraph pf1 = new Paragraph(phrase2);

                    var phrase3 = new Phrase();
                    phrase3.Add(new Chunk("Order No.:     ", underline));
                    Chunk c4 = new Chunk(griOrder_ID.ToString(), underline);
                    c4.SetUnderline(0.5f, -1.5f);
                    phrase3.Add(c4);


                    Paragraph pf1_1 = new Paragraph(phrase3);

                    var phrase4 = new Phrase();
                    phrase4.Add(new Chunk("Party :     ", underline));
                    Chunk cadd = new Chunk(txtP_ID.Text + '\n', underline);
                    cadd.SetUnderline(0.5f, -1.5f);
                    phrase4.Add(cadd);

                    Paragraph pf2 = new Paragraph(phrase4);


                    var phrase33 = new Phrase();
                    phrase33.Add(new Chunk("Party PO No. & Dt. :", underline));
                    Chunk c44 = new Chunk(txtPoandDate.Text.Trim().ToString(), underline);
                    c44.SetUnderline(0.5f, -1.5f);
                    phrase33.Add(c44);

                    phrase33.Add(new Chunk("         "));

                    phrase33.Add(new Chunk("Order Qty. :", underline));
                    Chunk c55 = new Chunk(txtOrder_Qty.Text.Trim().ToString(), underline);
                    c55.SetUnderline(0.5f, -1.5f);
                    phrase33.Add(c55);


                    Paragraph pf3 = new Paragraph(phrase33);




                    var phrase7 = new Phrase();
                    phrase7.Add(new Chunk("L.R. No. :", underline));
                    Chunk c7 = new Chunk(txtLR_No.Text.Trim().ToString(), underline);
                    c7.SetUnderline(0.5f, -1.5f);
                    phrase7.Add(c7);

                    phrase7.Add(new Chunk("      "));

                    phrase7.Add(new Chunk("Vehicle No. :", underline));
                    Chunk c71 = new Chunk(txtVeh_No.Text.Trim().ToString(), underline);
                    c71.SetUnderline(0.5f, -1.5f);
                    phrase7.Add(c71);


                    Paragraph pf4 = new Paragraph(phrase7);
                    // pf4.SpacingBefore = 5f;
                    //    pf4.SpacingAfter = 10f;




                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("Type :     ", underline));
                    Chunk c81 = new Chunk(txtChallan_Type.Text.Trim().ToString(), underline);
                    c81.SetUnderline(0.5f, -1.5f);
                    phrase8.Add(c81);

                    phrase8.Add(new Chunk("      "));

                    phrase8.Add(new Chunk("Local Sales :", underline));
                    Chunk c82 = new Chunk(txtLocal_Sales.Text.Trim().ToString(), underline);
                    c82.SetUnderline(0.5f, -1.5f);
                    phrase8.Add(c82);

                    Paragraph pf7 = new Paragraph(phrase8);
                    // pf4.SpacingBefore = 5f;


                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("Freight Amt.:", underline));
                    Chunk cins = new Chunk(txtFre_Amt.Text.Trim().ToString(), underline);
                    cins.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(cins);


                    phraseIns.Add(new Chunk("      "));

                    phraseIns.Add(new Chunk("Excise :", underline));
                    Chunk c83 = new Chunk(txtExc_Amt.Text.Trim().ToString(), underline);
                    c83.SetUnderline(0.5f, -1.5f);
                    phraseIns.Add(c83);


                    Paragraph pf8 = new Paragraph(phraseIns);
                    pf8.SpacingAfter = 5f;




                    doc.Add(MainTitle);

                    doc.Add(ParaTitle);
                    doc.Add(pf1);
                    doc.Add(pf1_1);
                    doc.Add(pf2);
                    doc.Add(pf3);
                    doc.Add(pf4);
                    doc.Add(pf7);

                    doc.Add(pf8);


                    LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line3));


                    //Itemg Grid2

                    PdfPTable t2 = new PdfPTable(7);
                    //float[] widthst1 = new float[] { 1f,1f,1f,1f,1.4f,1f,1f };
                    //t2.SetWidths(widthst1);
                    t2.DefaultCell.BorderWidth = 0;
                    t2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    t2.DefaultCell.BorderColor = BaseColor.WHITE;
                    t2.WidthPercentage = 100;
                    //t2.SpacingAfter = 4f;




                    PdfPCell Length_MM = new PdfPCell(new Phrase("BUNDLE", underlinBold));
                    PdfPCell Width_MM = new PdfPCell(new Phrase("PER", underlinBold));
                    PdfPCell Height_MM = new PdfPCell(new Phrase("DESPATCH", underlinBold));
                    PdfPCell Dimn_Opt = new PdfPCell(new Phrase("WEIGHT", underlinBold));
                    PdfPCell Length_MM_Conv = new PdfPCell(new Phrase("AVG.WG.", underlinBold));
                    PdfPCell Width_MM_Conv = new PdfPCell(new Phrase("RATE", underlinBold));
                    PdfPCell Height_MM_Conv = new PdfPCell(new Phrase("DISC", underlinBold));



                    Length_MM.BorderColor = BaseColor.WHITE;
                    Width_MM.BorderColor = BaseColor.WHITE;

                    Height_MM.BorderColor = BaseColor.WHITE;
                    Dimn_Opt.BorderColor = BaseColor.WHITE;
                    Length_MM_Conv.BorderColor = BaseColor.WHITE;
                    Width_MM_Conv.BorderColor = BaseColor.WHITE;
                    Height_MM_Conv.BorderColor = BaseColor.WHITE;



                    t2.AddCell(Length_MM);
                    t2.AddCell(Width_MM);
                    t2.AddCell(Height_MM);
                    t2.AddCell(Dimn_Opt);
                    t2.AddCell(Length_MM_Conv);
                    t2.AddCell(Width_MM_Conv);
                    t2.AddCell(Height_MM_Conv);



                    PdfPCell c1_1 = new PdfPCell(new Phrase(txtBundle_Note.Text, underlinBold));
                    PdfPCell c1 = new PdfPCell(new Phrase(txtPer_Det.Text, underlinBold));

                    PdfPCell c32 = new PdfPCell(new Phrase(txtDesp_Det.Text, underlinBold));
                    PdfPCell c33 = new PdfPCell(new Phrase(txtWt_Det.Text, underlinBold));
                    PdfPCell c34 = new PdfPCell(new Phrase(txtAvgWg_Det.Text, underlinBold));
                    PdfPCell c35 = new PdfPCell(new Phrase(txtRate_Det.Text, underlinBold));
                    PdfPCell c36 = new PdfPCell(new Phrase(txtDisc_Det.Text, underlinBold));




                    c1_1.BorderColor = BaseColor.BLACK;
                    c1.BorderColor = BaseColor.BLACK;
                    c32.BorderColor = BaseColor.BLACK;
                    c33.BorderColor = BaseColor.BLACK;
                    c34.BorderColor = BaseColor.BLACK;
                    c35.BorderColor = BaseColor.BLACK;
                    c36.BorderColor = BaseColor.BLACK;

                    t2.AddCell(c1_1);
                    t2.AddCell(c1);
                    t2.AddCell(c32);
                    t2.AddCell(c33);
                    t2.AddCell(c34);
                    t2.AddCell(c35);
                    t2.AddCell(c36);




                    doc.Add(t2);

                    LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line));


                    var phrase9 = new Phrase();
                    phrase9.Add(new Chunk("Total Amount", underline));
                    phrase9.Add(new Chunk("                        "));
                    Chunk c9 = new Chunk(txtTotal_Amt.Text.Trim().ToString(), underline);
                    c9.SetUnderline(0.5f, -1.5f);
                    phrase9.Add(c9);
                    Paragraph pf9 = new Paragraph(phrase9);




                    var phrase10 = new Phrase();
                    phrase10.Add(new Chunk("Discount Amount", underline));
                    phrase10.Add(new Chunk("                   "));
                    Chunk c91 = new Chunk(txtDiscount_Amt.Text.Trim().ToString(), underline);
                    c91.SetUnderline(0.5f, -1.5f);
                    phrase10.Add(c91);
                    Paragraph pf10 = new Paragraph(phrase10);


                    var phrase11 = new Phrase();
                    phrase11.Add(new Chunk("Net Amount", underline));
                    phrase11.Add(new Chunk("                          "));
                    Chunk c11 = new Chunk(txtNet_Amt.Text.Trim().ToString(), underline);
                    c11.SetUnderline(0.5f, -1.5f);
                    phrase11.Add(c11);
                    Paragraph pf11 = new Paragraph(phrase11);



                    var phrase12 = new Phrase();
                    phrase12.Add(new Chunk("Excise Amount", underline));
                    phrase12.Add(new Chunk("                      "));
                    Chunk c12 = new Chunk(txtExcise_Amt.Text.Trim().ToString(), underline);
                    c12.SetUnderline(0.5f, -1.5f);
                    phrase12.Add(c12);
                    Paragraph pf12 = new Paragraph(phrase12);


                    var phrase13 = new Phrase();
                    phrase13.Add(new Chunk("Edu.Cess Amount     ", underline));

                    Chunk c14 = new Chunk(txtEduPercentage.Text.Trim().ToString() + "%", underline);
                    //c14.SetUnderline(0.5f, -1.5f);
                    phrase13.Add(c14);

                    phrase13.Add(new Chunk("        "));

                    Chunk c13 = new Chunk(txtEdu_Cess_Amt.Text.Trim().ToString(), underline);
                    c13.SetUnderline(0.5f, -1.5f);
                    phrase13.Add(c13);
                    Paragraph pf13 = new Paragraph(phrase13);


                    var phrase14 = new Phrase();
                    phrase14.Add(new Chunk("HSEC Amount           ", underline));

                    Chunk c15 = new Chunk(txtHSECPercentage.Text.Trim().ToString() + "%", underline);
                    //c15.SetUnderline(0.5f, -1.5f);
                    phrase14.Add(c15);

                    phrase14.Add(new Chunk("        "));

                    Chunk c16 = new Chunk(txtHSEC_Amt.Text.Trim().ToString(), underline);
                    c16.SetUnderline(0.5f, -1.5f);
                    phrase14.Add(c16);
                    Paragraph pf14 = new Paragraph(phrase14);



                    var phrase15 = new Phrase();
                    phrase15.Add(new Chunk("CST/VAT Amount      ", underline));

                    Chunk c17 = new Chunk(txtCSTPercentage.Text.Trim().ToString() + "%", underline);
                    c16.SetUnderline(0.5f, -1.5f);
                    phrase15.Add(c17);

                    phrase15.Add(new Chunk("        "));

                    Chunk c18 = new Chunk(txtCST_VAT_Amt.Text.Trim().ToString(), underline);
                    c18.SetUnderline(0.5f, -1.5f);
                    phrase15.Add(c18);
                    Paragraph pf15 = new Paragraph(phrase15);



                    var phrase16 = new Phrase();
                    phrase16.Add(new Chunk("Freight Amount", underline));
                    phrase16.Add(new Chunk("                      "));
                    Chunk c19 = new Chunk(txtFreight_Amt.Text.Trim().ToString(), underline);
                    c19.SetUnderline(0.5f, -1.5f);
                    phrase16.Add(c19);
                    Paragraph pf16 = new Paragraph(phrase16);


                    var phrase17 = new Phrase();
                    phrase17.Add(new Chunk("Grand Amount", underline));
                    phrase17.Add(new Chunk("                       "));
                    Chunk c20 = new Chunk(txtGrand_Amt.Text.Trim().ToString(), underline);
                    c20.SetUnderline(0.5f, -1.5f);
                    phrase17.Add(c20);
                    Paragraph pf17 = new Paragraph(phrase17);




                    doc.Add(pf9);
                    doc.Add(pf10);
                    doc.Add(pf11);
                    doc.Add(pf12);
                    doc.Add(pf13);
                    doc.Add(pf14);
                    doc.Add(pf15);
                    doc.Add(pf16);
                    doc.Add(pf17);

                    LineSeparator line2 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line2));




                }
                catch (DocumentException dex)
                {


                    //Handle document exception
                }
                catch (IOException ioex)
                {
                    //Handle IO exception
                }
                catch (Exception ex)
                {
                    //Handle Other Exception
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
