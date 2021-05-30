using System;
using System.Data;
using System.Windows.Forms;
using ePacker1.App_Code;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using iTextSharp.text.pdf.draw;

namespace ePacker1
{
    public partial class RPeP_DispForm403 : Form
    {
        string session, strSQL, Group_ID, Sr_No;
        string P_Name, P_ID, P_PONo, P_PODt, Box_Qty, PQ_ID, Drv_ID;
        string griOrder_ID, griPartyPono, griPartoPoDt, griP_Name, strOpenDoc, Grp_Name;
        string Detail1, Detail2, Detail3, Detail4, Detail5, Detail6, Detail7, Detail8, Detail9, Detail10;
        private FunctionLib funclib;
        public RPeP_DispForm403()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_DispForm403_Load(object sender, EventArgs e)
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
            monthCalendar3.Visible = false;

            ddlTrans_Nature.Items.Add("");
            ddlTrans_Nature.Items.Add("Inter State Sale");
            ddlTrans_Nature.Items.Add("R. R. Endorsment"); 
            ddlTrans_Nature.Items.Add("Depot Transfer");
             ddlTrans_Nature.Items.Add("Consignment to Branch / Agent");
            ddlTrans_Nature.Items.Add("For Job work / works contract");
            ddlTrans_Nature.Items.Add("Any Other");
         
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlConnection con1 = new SqlConnection(strcon);

            Sr_No = funclib.I_ID("D", con, "select [403_No]  from Dispatch_Form403 order by [403_No]   desc");
            txt403_No.Text = Sr_No;


            ddlSearch.Items.Add("");
            ddlSearch.Items.Add("Sr.No.");
            ddlSearch.Items.Add("Form 403 Dt");
            ddlSearch.Items.Add("Party");
            ddlSearch.Items.Add("Nature of Transaction");
            ddlSearch.Items.Add("Consigned Value");
            ddlSearch.Items.Add("Transporter Name");
            ddlSearch.Items.Add("Driver Name");


            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Grp_ID, '' as Grp_Name UNION select Grp_ID,Grp_Name from Group_Master  where Grp_Active='Yes' and Grp_ID='"+Group_ID+"' ", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con1.Open();
            ddlGrp_ID.DataSource = dt;
            ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            con1.Close();



            SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as P_ID, '' as P_Name UNION select  a.P_ID, a.P_Name  as  PName from Party_Master a where  a.Grp_ID = '" + Group_ID + "' and a.P_Active='Yes'", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Open();
            ddlP_ID.DataSource = dt2;
            ddlP_ID.DisplayMember = dt2.Columns[1].ToString();
            ddlP_ID.ValueMember = dt2.Columns[0].ToString();
            con.Close();


            SqlDataAdapter da3 = new SqlDataAdapter("SELECT '' as Drv_ID, '' as DRV_Name UNION select  Drv_ID,Drv_FName+' '+Drv_MName+' '+Drv_LName   as  DRV_Name from Driver_Master where  Grp_ID = '" + Group_ID + "' and Drv_Active='Yes'", con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Open();
            ddlDrv_ID.DataSource = dt3;
            ddlDrv_ID.DisplayMember = dt3.Columns[1].ToString();
            ddlDrv_ID.ValueMember = dt3.Columns[0].ToString();
            con.Close();



            // all order ddls
            SqlDataAdapter daOrder1 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.Order_ID in (select Order_ID from Dispatch_Challan) and a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' ", con);
            DataTable dtOrder1 = new DataTable();
            daOrder1.Fill(dtOrder1);
            con.Open();
            ddl1Order_ID.DataSource = dtOrder1;
            ddl1Order_ID.DisplayMember = dtOrder1.Columns[0].ToString();
            ddl1Order_ID.ValueMember = dtOrder1.Columns[0].ToString();
            con.Close();


            SqlDataAdapter daOrder2 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.Order_ID in (select Order_ID from Dispatch_Challan) and a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' ", con);
            DataTable dtOrder2 = new DataTable();
            daOrder2.Fill(dtOrder2);
            con.Open();
            ddl2Order_ID.DataSource = dtOrder2;
            ddl2Order_ID.DisplayMember = dtOrder2.Columns[0].ToString();
            ddl2Order_ID.ValueMember = dtOrder2.Columns[0].ToString();
            con.Close();


            SqlDataAdapter daOrder3 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.Order_ID in (select Order_ID from Dispatch_Challan) and a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' ", con);
            DataTable dtOrder3 = new DataTable();
            daOrder3.Fill(dtOrder3);
            con.Open();
            ddl3Order_ID.DataSource = dtOrder3;
            ddl3Order_ID.DisplayMember = dtOrder3.Columns[0].ToString();
            ddl3Order_ID.ValueMember = dtOrder3.Columns[0].ToString();
            con.Close();


            SqlDataAdapter daOrder4 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.Order_ID in (select Order_ID from Dispatch_Challan) and a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' ", con);
            DataTable  dtOrder4 = new DataTable();
            daOrder4.Fill(dtOrder4);
            con.Open();
            ddl4Order_ID.DataSource = dtOrder4;
            ddl4Order_ID.DisplayMember = dtOrder4.Columns[0].ToString();
            ddl4Order_ID.ValueMember = dtOrder4.Columns[0].ToString();
            con.Close();


            SqlDataAdapter daOrder5 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.Order_ID in (select Order_ID from Dispatch_Challan) and a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' ", con);
            DataTable dtOrder5 = new DataTable();
            daOrder5.Fill(dtOrder5);
            con.Open();
            ddl5Order_ID.DataSource = dtOrder5;
            ddl5Order_ID.DisplayMember = dtOrder5.Columns[0].ToString();
            ddl5Order_ID.ValueMember = dtOrder5.Columns[0].ToString();
            con.Close();

            SqlDataAdapter daOrder6 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.Order_ID in (select Order_ID from Dispatch_Challan) and a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' ", con);
            DataTable dtOrder6 = new DataTable();
            daOrder6.Fill(dtOrder6);
            con.Open();
            ddl6Order_ID.DataSource = dtOrder6;
            ddl6Order_ID.DisplayMember = dtOrder6.Columns[0].ToString();
            ddl6Order_ID.ValueMember = dtOrder6.Columns[0].ToString();
            con.Close();


            SqlDataAdapter daOrder7 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.Order_ID in (select Order_ID from Dispatch_Challan) and a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' ", con);
            DataTable dtOrder7 = new DataTable();
            daOrder7.Fill(dtOrder7);
            con.Open();
            ddl7Order_ID.DataSource = dtOrder7;
            ddl7Order_ID.DisplayMember = dtOrder7.Columns[0].ToString();
            ddl7Order_ID.ValueMember = dtOrder7.Columns[0].ToString();
            con.Close();

            SqlDataAdapter daOrder8 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.Order_ID in (select Order_ID from Dispatch_Challan) and a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' ", con);
            DataTable dtOrder8 = new DataTable();
            daOrder8.Fill(dtOrder8);
            con.Open();
            ddl8Order_ID.DataSource = dtOrder8;
            ddl8Order_ID.DisplayMember = dtOrder8.Columns[0].ToString();
            ddl8Order_ID.ValueMember = dtOrder8.Columns[0].ToString();
            con.Close();

            SqlDataAdapter daOrder9 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.Order_ID in (select Order_ID from Dispatch_Challan) and a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' ", con);
            DataTable dtOrder9 = new DataTable();
            daOrder9.Fill(dtOrder9);
            con.Open();
            ddl9Order_ID.DataSource = dtOrder9;
            ddl9Order_ID.DisplayMember = dtOrder9.Columns[0].ToString();
            ddl9Order_ID.ValueMember = dtOrder8.Columns[0].ToString();
            con.Close();


            SqlDataAdapter daOrder10 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order as a,Party_Master as b where a.Order_ID in (select Order_ID from Dispatch_Challan) and a.P_ID=b.P_ID  and a.Grp_ID = '" + Group_ID + "' and a.Order_Active='Yes' ", con);
            DataTable dtOrder10 = new DataTable();
            daOrder10.Fill(dtOrder10);
            con.Open();
            ddl10Order_ID.DataSource = dtOrder10;
            ddl10Order_ID.DisplayMember = dtOrder10.Columns[0].ToString();
            ddl10Order_ID.ValueMember = dtOrder10.Columns[0].ToString();
            con.Close();


            Detail1 = "Yes";
            Detail2 = "Yes";
            Detail3 = "Yes";
            Detail4 = "Yes";
            Detail5 = "Yes";
            Detail6 = "Yes";
            Detail7 = "Yes";
            Detail8 = "Yes";
            Detail9 = "Yes";
            Detail10 = "Yes";



        }

        private void txt403_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void txt403_Dt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txt403_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txt403_Dt.Focus();
        }
        private void txtGoods_InvDt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtGoods_InvDt.Text = monthCalendar2.SelectionStart.ToShortDateString();
            monthCalendar2.Visible = false;
            txtGoods_InvDt.Focus();
        }
        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txt403_No.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("403 No Cannot be Blank");
                txt403_No.Focus();
            }

            else if (txt403_Dt.Text == "")//checking for blank name text field 
            {
                System.Windows.MessageBox.Show("Field Cannot Be Balnk");
                txt403_Dt.Focus();
            }
            else if (ddlGrp_ID.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlGrp_ID.Focus();

            }
            else if (txtPlace_From.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPlace_From.Focus();
            }
            else if (txtPlace_FromDist.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPlace_FromDist.Focus();
            }
            else if (txtPlace_To.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPlace_To.Focus();
            }
            else if (txtPlace_ToDist.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPlace_ToDist.Focus();
            }
            else if (txtGoods_InvDt.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtGoods_InvDt.Focus();
            }
            else if (txtGoods_InvNo.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtGoods_InvNo.Focus();
            }
            else if (ddlP_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlP_ID.Focus();
            }
            else if (ddlTrans_Nature.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlTrans_Nature.Focus();
            }
            else if (txtConsign_Value.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtConsign_Value.Focus();
            }
            else if (txtTransp_Name.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtTransp_Name.Focus();
            }
            else if (txtTransp_Address.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtTransp_Address.Focus();
            }
            else if (txtVeh_No.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtVeh_No.Focus();
            }
            else if (txtLR_No.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtLR_No.Focus();
            }
            else if (ddlDrv_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlDrv_ID.Focus();

            }
            else if (txt403_Place.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txt403_Place.Focus();
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

                SqlCommand cmdPositive = new SqlCommand("insert into Dispatch_Form403([403_No],[403_Dt],Grp_ID,Place_From,Place_FromDist,Place_To,Place_ToDist,Goods_InvNo,P_ID,Goods_InvDt,Trans_Nature,Consign_Value,Transp_Name,Transp_Address,Veh_No,LR_No,Drv_ID,[403_Place],[403_Active],Add_By,Add_ByNode,Add_On) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txt403_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlGrp_ID.SelectedValue.ToString() + "','" + txtPlace_From.Text.Trim().Replace("'", "''").ToString() + "','" + txtPlace_FromDist.Text.Trim().Replace("'", "''").ToString() + "','" + txtPlace_To.Text.Trim().Replace("'", "''").ToString() + "','" + txtPlace_ToDist.Text.Trim().Replace("'", "''").ToString() + "','" + txtGoods_InvNo.Text.Trim().Replace("'", "''").ToString() + "','" + ddlP_ID.SelectedValue.ToString() + "',convert(datetime,'" + txtGoods_InvDt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlTrans_Nature.Text.ToString() + "','" + txtConsign_Value.Text.Trim().Replace("'", "''").ToString() + "','" + txtTransp_Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtTransp_Address.Text.Trim().Replace("'", "''").ToString() + "','" + txtVeh_No.Text.Trim().Replace("'", "''").ToString() + "','" + txtLR_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddlDrv_ID.SelectedValue.ToString() + "','" + txt403_Place.Text.Trim().Replace("'", "''").ToString() + "','" + ddlActive.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
                con.Open();
                int Positive = cmdPositive.ExecuteNonQuery();

                if (Positive > 0)
                {
                    if (ddl1Order_ID.Text != "" && ddl1Challan_No.Text != "" && txt1Item.Text != "")
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Dispatch_Form403Det([403_No],Order_ID,Challan_No) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "','"+ddl1Order_ID.SelectedValue.ToString()+"','" + ddl1Challan_No.SelectedValue.ToString() + "')", con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                    if (ddl2Order_ID.Text != "" && ddl2Challan_No.Text != "" && txt2Item.Text != "")
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Dispatch_Form403Det([403_No],Order_ID,Challan_No) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddl2Order_ID.SelectedValue.ToString() + "','" + ddl2Challan_No.SelectedValue.ToString() + "')", con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                    if (ddl3Order_ID.Text != "" && ddl3Challan_No.Text != "" && txt3Item.Text != "")
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Dispatch_Form403Det([403_No],Order_ID,Challan_No) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddl3Order_ID.SelectedValue.ToString() + "','" + ddl3Challan_No.SelectedValue.ToString() + "')", con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                   if (ddl4Order_ID.Text != "" && ddl4Challan_No.Text != "" && txt4Item.Text != "")
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Dispatch_Form403Det([403_No],Order_ID,Challan_No) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddl4Order_ID.SelectedValue.ToString() + "','" + ddl4Challan_No.SelectedValue.ToString() + "')", con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                   if (ddl5Order_ID.Text != "" && ddl5Challan_No.Text != "" && txt5Item.Text != "")
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Dispatch_Form403Det([403_No],Order_ID,Challan_No) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddl5Order_ID.SelectedValue.ToString() + "','" + ddl5Challan_No.SelectedValue.ToString() + "')", con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                   if (ddl6Order_ID.Text != "" && ddl6Challan_No.Text != "" && txt6Item.Text != "")
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Dispatch_Form403Det([403_No],Order_ID,Challan_No) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddl6Order_ID.SelectedValue.ToString() + "','" + ddl6Challan_No.SelectedValue.ToString() + "')", con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                    if (ddl7Order_ID.Text != "" && ddl7Challan_No.Text != "" && txt7Item.Text != "")
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Dispatch_Form403Det([403_No],Order_ID,Challan_No) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddl7Order_ID.SelectedValue.ToString() + "','" + ddl7Challan_No.SelectedValue.ToString() + "')", con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                    if (ddl8Order_ID.Text != "" && ddl8Challan_No.Text != "" && txt8Item.Text != "")
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Dispatch_Form403Det([403_No],Order_ID,Challan_No) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddl8Order_ID.SelectedValue.ToString() + "','" + ddl8Challan_No.SelectedValue.ToString() + "')", con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                    if (ddl9Order_ID.Text != "" && ddl9Challan_No.Text != "" && txt9Item.Text != "")
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Dispatch_Form403Det([403_No],Order_ID,Challan_No) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddl9Order_ID.SelectedValue.ToString() + "','" + ddl9Challan_No.SelectedValue.ToString() + "')", con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                    if (ddl10Order_ID.Text != "" && ddl10Challan_No.Text != "" && txt10Item.Text != "")
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Dispatch_Form403Det([403_No],Order_ID,Challan_No) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddl10Order_ID.SelectedValue.ToString() + "','" + ddl10Challan_No.SelectedValue.ToString() + "')", con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                }

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
        protected void ClearAll()
        {
            Detail1 = "Yes";
            Detail2 = "Yes";
            Detail3 = "Yes";
            Detail4 = "Yes";
            Detail5 = "Yes";
            Detail6 = "Yes";
            Detail7 = "Yes";
            Detail8 = "Yes";
            Detail9 = "Yes";
            Detail10 = "Yes";

            ddlSearch.Text = "";
            txt10Amt.Text = "";
            txt10Item.Text = "";
            txt10Qty.Text = "";
            txt1Amt.Text = "";
            txt1Item.Text = "";
            txt1Qty.Text = "";
            txt2Amt.Text = "";
            txt2Item.Text = "";
            txt2Qty.Text = "";
            txt3Amt.Text = "";
            txt3Item.Text = "";
            txt3Qty.Text = "";
            txt403_Dt.Text = "";
            txt403_No.Text = "";
            txt403_Place.Text = "";
            txt4Amt.Text = "";
            txt4Item.Text = "";
            txt4Qty.Text = "";
            txt5Item.Text = "";
            txt5Qty.Text = "";
            txt5Amt.Text = "";
            txt6Amt.Text = "";
            txt6Item.Text = "";
            txt6Qty.Text = "";
            txt7Amt.Text = "";
            txt7Item.Text = "";
            txt7Qty.Text = "";
            txt8Amt.Text = "";
            txt8Item.Text = "";
            txt8Qty.Text = "";
            txt9Amt.Text = "";
            txt9Item.Text = "";
            txt9Qty.Text = "";
            txtConsign_Value.Text = "";
            txtDrvAddress1.Text = "";
            txtDrvAddress2.Text = "";
            txtDrvCity.Text = "";
            txtDrvLicenseNo.Text = "";
            txtDrvLicenseState.Text = "";
            txtDrvPincode.Text = "";
            txtDrvState.Text = "";
            txtG_Address.Text = "";
            txtG_CSt.Text = "";
            txtG_Phone.Text = "";
            txtG_Vat.Text = "";
            txtGoods_InvDt.Text = "";
            txtGoods_InvNo.Text = "";
            txtLR_No.Text = "";
            txtP_Address.Text = "";
            txtP_Cst.Text = "";
            txtP_Phone.Text = "";
            txtP_Vat.Text = "";
            txtPlace_From.Text = "";
            txtPlace_FromDist.Text = "";
            txtPlace_To.Text = "";
            txtPlace_ToDist.Text = "";
            txtTransp_Address.Text = "";
            txtTransp_Name.Text = "";
            txtVeh_No.Text = "";

            ddl10Challan_No.Text = "";
            ddl10Order_ID.Text = "";
            ddl1Challan_No.Text = "";
            ddl1Order_ID.Text = "";
            ddl2Challan_No.Text = "";
            ddl2Order_ID.Text = "";
            ddl3Challan_No.Text = "";
            ddl3Order_ID.Text = "";
            ddl4Challan_No.Text = "";
            ddl4Order_ID.Text = "";
            ddl5Challan_No.Text = "";
            ddl5Order_ID.Text = "";
            ddl6Challan_No.Text = "";
            ddl6Order_ID.Text = "";
            ddl7Challan_No.Text = "";
            ddl7Order_ID.Text = "";
            ddl8Challan_No.Text = "";
            ddl8Order_ID.Text = "";
            ddl9Challan_No.Text = "";
            ddl9Order_ID.Text = "";
            ddlDrv_ID.Text = "";
            ddlGrp_ID.Text = "";
            ddlP_ID.Text = "";
            ddlTrans_Nature.Text = "";

            ddlActive.Text = "Yes";
            cmdPrint.Visible = false;
            ddlActive.Enabled = false;


            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);



            Sr_No = funclib.I_ID("D", con, "select [403_No]  from Dispatch_Form403 order by [403_No]   desc");
            txt403_No.Text = Sr_No;



            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            txt_Search.Enabled = true;


            txt403_Dt.Enabled = true;
            txtPlace_From.Enabled = true;
            txtPlace_FromDist.Enabled = true;
            txtPlace_To.Enabled = true;
            txtPlace_ToDist.Enabled = true;
            txtTransp_Address.Enabled = true;
            txtTransp_Name.Enabled = true;
            txtVeh_No.Enabled = true;
            txtLR_No.Enabled = true;
            txt403_Place.Enabled = true;
            txtGoods_InvDt.Enabled = true;
            txtGoods_InvNo.Enabled = true;

            ddlGrp_ID.Enabled = true;
            ddlTrans_Nature.Enabled = true;
            ddlP_ID.Enabled = true;
            ddlDrv_ID.Enabled = true;
            ddl1Challan_No.Enabled = true;
            ddl1Order_ID.Enabled = true;
            ddl2Challan_No.Enabled = true;
            ddl2Order_ID.Enabled = true;
            ddl3Challan_No.Enabled = true;
            ddl3Order_ID.Enabled = true;
            ddl4Challan_No.Enabled = true;
            ddl4Order_ID.Enabled = true;
            ddl5Challan_No.Enabled = true;
            ddl5Order_ID.Enabled = true;
            ddl6Challan_No.Enabled = true;
            ddl6Order_ID.Enabled = true;
            ddl7Challan_No.Enabled = true;
            ddl7Order_ID.Enabled = true;
            ddl8Challan_No.Enabled = true;
            ddl8Order_ID.Enabled = true;
            ddl9Challan_No.Enabled = true;
            ddl9Order_ID.Enabled = true;
            ddl10Challan_No.Enabled = true;
            ddl10Order_ID.Enabled = true;



            ddlGrp_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlTrans_Nature.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlP_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlDrv_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl1Challan_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl1Order_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl2Challan_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl2Order_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl3Challan_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl3Order_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl4Challan_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl4Order_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl5Challan_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl5Order_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl6Challan_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl6Order_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl7Challan_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl7Order_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl8Challan_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl8Order_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl9Challan_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl9Order_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl10Challan_No.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl10Order_ID.DropDownStyle = ComboBoxStyle.DropDownList;



        }
        private void cmdReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select  Grp_Address,Grp_Phone,Grp_LST,Grp_CST from Group_Master where Grp_ID ='" + ddlGrp_ID.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtG_Address.Text = Convert.ToString(dr1["Grp_Address"]);
                txtG_Phone.Text = Convert.ToString(dr1["Grp_Phone"]);
                txtG_Vat.Text = Convert.ToString(dr1["Grp_LST"]);
                txtG_CSt.Text = Convert.ToString(dr1["Grp_CST"]);
              
            }
            dr1.Close();
            con1.Close();


          
        }

        private void ddlP_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select P_Addr1+' '+P_Addr2 as 'Address',P_Tel,LBT_No,P_CST from Party_Master where P_ID ='" + ddlP_ID.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtP_Address.Text = Convert.ToString(dr1["Address"]);
                txtP_Phone.Text = Convert.ToString(dr1["P_Tel"]);
                txtP_Vat.Text = Convert.ToString(dr1["LBT_No"]);
                txtP_Cst.Text = Convert.ToString(dr1["P_CST"]);

            }
            dr1.Close();
            con1.Close();

        }

        private void ddlDrv_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("SELECT Drv_Addr1,Drv_Addr2,Drv_City,Drv_State,Drv_PinCode,Drv_LicnNo,Drv_LicnState from Driver_Master  where Drv_ID ='" + ddlDrv_ID.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txtDrvAddress1.Text = Convert.ToString(dr1["Drv_Addr1"]);
                txtDrvAddress2.Text = Convert.ToString(dr1["Drv_Addr2"]);
                txtDrvCity.Text = Convert.ToString(dr1["Drv_City"]);
                txtDrvState.Text = Convert.ToString(dr1["Drv_State"]);
                txtDrvPincode.Text = Convert.ToString(dr1["Drv_PinCode"]);
                txtDrvLicenseNo.Text = Convert.ToString(dr1["Drv_LicnNo"]);
                txtDrvLicenseState.Text = Convert.ToString(dr1["Drv_LicnState"]);

            }
            dr1.Close();
            con1.Close();
        }

        private void ddl1Order_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Challan_No UNION select  Challan_No from Dispatch_Challan as a where Challan_Active='Yes'  and a.Order_ID ='" + ddl1Order_ID.SelectedValue.ToString() + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddl1Challan_No.DataSource = dt;
            ddl1Challan_No.DisplayMember = dt.Columns[0].ToString();
            ddl1Challan_No.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void ddl2Order_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Challan_No UNION select  Challan_No from Dispatch_Challan as a where Challan_Active='Yes'  and a.Order_ID ='" + ddl2Order_ID.SelectedValue.ToString() + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddl2Challan_No.DataSource = dt;
            ddl2Challan_No.DisplayMember = dt.Columns[0].ToString();
            ddl2Challan_No.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void ddl3Order_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Challan_No UNION select  Challan_No from Dispatch_Challan as a where Challan_Active='Yes'  and a.Order_ID ='" + ddl3Order_ID.SelectedValue.ToString() + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddl3Challan_No.DataSource = dt;
            ddl3Challan_No.DisplayMember = dt.Columns[0].ToString();
            ddl3Challan_No.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void ddl4Order_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Challan_No UNION select  Challan_No from Dispatch_Challan as a where Challan_Active='Yes'  and a.Order_ID ='" + ddl4Order_ID.SelectedValue.ToString() + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddl4Challan_No.DataSource = dt;
            ddl4Challan_No.DisplayMember = dt.Columns[0].ToString();
            ddl4Challan_No.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void ddl5Order_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Challan_No UNION select  Challan_No from Dispatch_Challan as a where Challan_Active='Yes'  and a.Order_ID ='" + ddl5Order_ID.SelectedValue.ToString() + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddl5Challan_No.DataSource = dt;
            ddl5Challan_No.DisplayMember = dt.Columns[0].ToString();
            ddl5Challan_No.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void ddl6Order_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Challan_No UNION select  Challan_No from Dispatch_Challan as a where Challan_Active='Yes'  and a.Order_ID ='" + ddl6Order_ID.SelectedValue.ToString() + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddl6Challan_No.DataSource = dt;
            ddl6Challan_No.DisplayMember = dt.Columns[0].ToString();
            ddl6Challan_No.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void ddl7Order_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Challan_No UNION select  Challan_No from Dispatch_Challan as a where Challan_Active='Yes'  and a.Order_ID ='" + ddl7Order_ID.SelectedValue.ToString() + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddl7Challan_No.DataSource = dt;
            ddl7Challan_No.DisplayMember = dt.Columns[0].ToString();
            ddl7Challan_No.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void ddl8Order_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Challan_No UNION select  Challan_No from Dispatch_Challan as a where Challan_Active='Yes'  and a.Order_ID ='" + ddl8Order_ID.SelectedValue.ToString() + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddl8Challan_No.DataSource = dt;
            ddl8Challan_No.DisplayMember = dt.Columns[0].ToString();
            ddl8Challan_No.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void ddl9Order_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Challan_No UNION select  Challan_No from Dispatch_Challan as a where Challan_Active='Yes'  and a.Order_ID ='" + ddl9Order_ID.SelectedValue.ToString() + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddl9Challan_No.DataSource = dt;
            ddl9Challan_No.DisplayMember = dt.Columns[0].ToString();
            ddl9Challan_No.ValueMember = dt.Columns[0].ToString();
            con.Close();

        }

        private void ddl10Order_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Challan_No UNION select  Challan_No from Dispatch_Challan as a where Challan_Active='Yes'  and a.Order_ID ='" + ddl10Order_ID.SelectedValue.ToString() + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddl10Challan_No.DataSource = dt;
            ddl10Challan_No.DisplayMember = dt.Columns[0].ToString();
            ddl10Challan_No.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void ddl1Challan_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl1Challan_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txt1Item.Text = Convert.ToString(dr1["Item_Name"]);
                txt1Qty.Text = Convert.ToString(dr1["Qty"]);
                txt1Amt.Text = Convert.ToString(dr1["Grand_Amt"]);
              

            }
            dr1.Close();
            con1.Close();
        }

        private void ddl2Challan_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl2Challan_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txt2Item.Text = Convert.ToString(dr1["Item_Name"]);
                txt2Qty.Text = Convert.ToString(dr1["Qty"]);
                txt2Amt.Text = Convert.ToString(dr1["Grand_Amt"]);


            }
            dr1.Close();
            con1.Close();

        }

        private void ddl3Challan_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl3Challan_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txt3Item.Text = Convert.ToString(dr1["Item_Name"]);
                txt3Qty.Text = Convert.ToString(dr1["Qty"]);
                txt3Amt.Text = Convert.ToString(dr1["Grand_Amt"]);


            }
            dr1.Close();
            con1.Close();
        }

        private void ddl4Challan_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl4Challan_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txt4Item.Text = Convert.ToString(dr1["Item_Name"]);
                txt4Qty.Text = Convert.ToString(dr1["Qty"]);
                txt4Amt.Text = Convert.ToString(dr1["Grand_Amt"]);


            }
            dr1.Close();
            con1.Close();
        }

        private void ddl5Challan_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl5Challan_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txt5Item.Text = Convert.ToString(dr1["Item_Name"]);
                txt5Qty.Text = Convert.ToString(dr1["Qty"]);
                txt5Amt.Text = Convert.ToString(dr1["Grand_Amt"]);


            }
            dr1.Close();
            con1.Close();
        }

        private void ddl6Challan_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl6Challan_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txt6Item.Text = Convert.ToString(dr1["Item_Name"]);
                txt6Qty.Text = Convert.ToString(dr1["Qty"]);
                txt6Amt.Text = Convert.ToString(dr1["Grand_Amt"]);


            }
            dr1.Close();
            con1.Close();

        }

        private void ddl7Challan_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl7Challan_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txt7Item.Text = Convert.ToString(dr1["Item_Name"]);
                txt7Qty.Text = Convert.ToString(dr1["Qty"]);
                txt7Amt.Text = Convert.ToString(dr1["Grand_Amt"]);


            }
            dr1.Close();
            con1.Close();
        }

        private void ddl8Challan_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl8Challan_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txt8Item.Text = Convert.ToString(dr1["Item_Name"]);
                txt8Qty.Text = Convert.ToString(dr1["Qty"]);
                txt8Amt.Text = Convert.ToString(dr1["Grand_Amt"]);


            }
            dr1.Close();
            con1.Close();

        }

        private void ddl9Challan_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl9Challan_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txt9Item.Text = Convert.ToString(dr1["Item_Name"]);
                txt9Qty.Text = Convert.ToString(dr1["Qty"]);
                txt9Amt.Text = Convert.ToString(dr1["Grand_Amt"]);


            }
            dr1.Close();
            con1.Close();
        }

        private void ddl10Challan_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl10Challan_No.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                txt10Item.Text = Convert.ToString(dr1["Item_Name"]);
                txt10Qty.Text = Convert.ToString(dr1["Qty"]);
                txt10Amt.Text = Convert.ToString(dr1["Grand_Amt"]);


            }
            dr1.Close();
            con1.Close();

        }

        private void txt1Amt_TextChanged(object sender, EventArgs e)
        {
            if (txt1Amt.Text == "")
            {
                txt1Amt.Text = "0";
            }
            else if (txt2Amt.Text == "")
            {
                txt2Amt.Text = "0";
            }
            else if (txt3Amt.Text == "")
            {
                txt3Amt.Text = "0";
            }
            else if (txt4Amt.Text == "")
            {
                txt4Amt.Text = "0";
            }
            else if (txt5Amt.Text == "")
            {
                txt5Amt.Text = "0";
            }
            else if (txt6Amt.Text == "")
            {
                txt6Amt.Text = "0";
            }
            else if (txt7Amt.Text == "")
            {
                txt7Amt.Text = "0";
            }
            else if (txt8Amt.Text == "")
            {
                txt8Amt.Text = "0";
            }
            else if (txt9Amt.Text == "")
            {
                txt9Amt.Text = "0";
            }
            else if (txt10Amt.Text == "")
            {
                txt10Amt.Text = "0";
            }

            double Amt_1 = Convert.ToDouble(txt1Amt.Text);
            double Amt_2 = Convert.ToDouble(txt2Amt.Text);
            double Amt_3 = Convert.ToDouble(txt3Amt.Text);
            double Amt_4 = Convert.ToDouble(txt4Amt.Text);
            double Amt_5 = Convert.ToDouble(txt5Amt.Text);
            double Amt_6 = Convert.ToDouble(txt6Amt.Text);
            double Amt_7 = Convert.ToDouble(txt7Amt.Text);
            double Amt_8 = Convert.ToDouble(txt8Amt.Text);
            double Amt_9 = Convert.ToDouble(txt9Amt.Text);
            double Amt_10 = Convert.ToDouble(txt10Amt.Text);



            double Total = Amt_1 + Amt_2 + Amt_3 + Amt_4 + Amt_5 + Amt_6 + Amt_7 + Amt_8 + Amt_9 + Amt_10;
            txtConsign_Value.Text = Convert.ToString(Math.Round(Total));
        }

        private void txt2Amt_TextChanged(object sender, EventArgs e)
        {
            if (txt1Amt.Text == "")
            {
                txt1Amt.Text = "0";
            }
            else if (txt2Amt.Text == "")
            {
                txt2Amt.Text = "0";
            }
            else if (txt3Amt.Text == "")
            {
                txt3Amt.Text = "0";
            }
            else if (txt4Amt.Text == "")
            {
                txt4Amt.Text = "0";
            }
            else if (txt5Amt.Text == "")
            {
                txt5Amt.Text = "0";
            }
            else if (txt6Amt.Text == "")
            {
                txt6Amt.Text = "0";
            }
            else if (txt7Amt.Text == "")
            {
                txt7Amt.Text = "0";
            }
            else if (txt8Amt.Text == "")
            {
                txt8Amt.Text = "0";
            }
            else if (txt9Amt.Text == "")
            {
                txt9Amt.Text = "0";
            }
            else if (txt10Amt.Text == "")
            {
                txt10Amt.Text = "0";
            }

            double Amt_1 = Convert.ToDouble(txt1Amt.Text);
            double Amt_2 = Convert.ToDouble(txt2Amt.Text);
            double Amt_3 = Convert.ToDouble(txt3Amt.Text);
            double Amt_4 = Convert.ToDouble(txt4Amt.Text);
            double Amt_5 = Convert.ToDouble(txt5Amt.Text);
            double Amt_6 = Convert.ToDouble(txt6Amt.Text);
            double Amt_7 = Convert.ToDouble(txt7Amt.Text);
            double Amt_8 = Convert.ToDouble(txt8Amt.Text);
            double Amt_9 = Convert.ToDouble(txt9Amt.Text);
            double Amt_10 = Convert.ToDouble(txt10Amt.Text);



            double Total = Amt_1 + Amt_2 + Amt_3 + Amt_4 + Amt_5 + Amt_6 + Amt_7 + Amt_8 + Amt_9 + Amt_10;
            txtConsign_Value.Text = Convert.ToString(Math.Round(Total));
        }

        private void txt3Amt_TextChanged(object sender, EventArgs e)
        {
            if (txt1Amt.Text == "")
            {
                txt1Amt.Text = "0";
            }
            else if (txt2Amt.Text == "")
            {
                txt2Amt.Text = "0";
            }
            else if (txt3Amt.Text == "")
            {
                txt3Amt.Text = "0";
            }
            else if (txt4Amt.Text == "")
            {
                txt4Amt.Text = "0";
            }
            else if (txt5Amt.Text == "")
            {
                txt5Amt.Text = "0";
            }
            else if (txt6Amt.Text == "")
            {
                txt6Amt.Text = "0";
            }
            else if (txt7Amt.Text == "")
            {
                txt7Amt.Text = "0";
            }
            else if (txt8Amt.Text == "")
            {
                txt8Amt.Text = "0";
            }
            else if (txt9Amt.Text == "")
            {
                txt9Amt.Text = "0";
            }
            else if (txt10Amt.Text == "")
            {
                txt10Amt.Text = "0";
            }

            double Amt_1 = Convert.ToDouble(txt1Amt.Text);
            double Amt_2 = Convert.ToDouble(txt2Amt.Text);
            double Amt_3 = Convert.ToDouble(txt3Amt.Text);
            double Amt_4 = Convert.ToDouble(txt4Amt.Text);
            double Amt_5 = Convert.ToDouble(txt5Amt.Text);
            double Amt_6 = Convert.ToDouble(txt6Amt.Text);
            double Amt_7 = Convert.ToDouble(txt7Amt.Text);
            double Amt_8 = Convert.ToDouble(txt8Amt.Text);
            double Amt_9 = Convert.ToDouble(txt9Amt.Text);
            double Amt_10 = Convert.ToDouble(txt10Amt.Text);



            double Total = Amt_1 + Amt_2 + Amt_3 + Amt_4 + Amt_5 + Amt_6 + Amt_7 + Amt_8 + Amt_9 + Amt_10;
            txtConsign_Value.Text = Convert.ToString(Math.Round(Total));
        }

        private void txt4Amt_TextChanged(object sender, EventArgs e)
        {
            if (txt1Amt.Text == "")
            {
                txt1Amt.Text = "0";
            }
            else if (txt2Amt.Text == "")
            {
                txt2Amt.Text = "0";
            }
            else if (txt3Amt.Text == "")
            {
                txt3Amt.Text = "0";
            }
            else if (txt4Amt.Text == "")
            {
                txt4Amt.Text = "0";
            }
            else if (txt5Amt.Text == "")
            {
                txt5Amt.Text = "0";
            }
            else if (txt6Amt.Text == "")
            {
                txt6Amt.Text = "0";
            }
            else if (txt7Amt.Text == "")
            {
                txt7Amt.Text = "0";
            }
            else if (txt8Amt.Text == "")
            {
                txt8Amt.Text = "0";
            }
            else if (txt9Amt.Text == "")
            {
                txt9Amt.Text = "0";
            }
            else if (txt10Amt.Text == "")
            {
                txt10Amt.Text = "0";
            }

            double Amt_1 = Convert.ToDouble(txt1Amt.Text);
            double Amt_2 = Convert.ToDouble(txt2Amt.Text);
            double Amt_3 = Convert.ToDouble(txt3Amt.Text);
            double Amt_4 = Convert.ToDouble(txt4Amt.Text);
            double Amt_5 = Convert.ToDouble(txt5Amt.Text);
            double Amt_6 = Convert.ToDouble(txt6Amt.Text);
            double Amt_7 = Convert.ToDouble(txt7Amt.Text);
            double Amt_8 = Convert.ToDouble(txt8Amt.Text);
            double Amt_9 = Convert.ToDouble(txt9Amt.Text);
            double Amt_10 = Convert.ToDouble(txt10Amt.Text);



            double Total = Amt_1 + Amt_2 + Amt_3 + Amt_4 + Amt_5 + Amt_6 + Amt_7 + Amt_8 + Amt_9 + Amt_10;
            txtConsign_Value.Text = Convert.ToString(Math.Round(Total));
        }

        private void txt5Amt_TextChanged(object sender, EventArgs e)
        {
            if (txt1Amt.Text == "")
            {
                txt1Amt.Text = "0";
            }
            else if (txt2Amt.Text == "")
            {
                txt2Amt.Text = "0";
            }
            else if (txt3Amt.Text == "")
            {
                txt3Amt.Text = "0";
            }
            else if (txt4Amt.Text == "")
            {
                txt4Amt.Text = "0";
            }
            else if (txt5Amt.Text == "")
            {
                txt5Amt.Text = "0";
            }
            else if (txt6Amt.Text == "")
            {
                txt6Amt.Text = "0";
            }
            else if (txt7Amt.Text == "")
            {
                txt7Amt.Text = "0";
            }
            else if (txt8Amt.Text == "")
            {
                txt8Amt.Text = "0";
            }
            else if (txt9Amt.Text == "")
            {
                txt9Amt.Text = "0";
            }
            else if (txt10Amt.Text == "")
            {
                txt10Amt.Text = "0";
            }

            double Amt_1 = Convert.ToDouble(txt1Amt.Text);
            double Amt_2 = Convert.ToDouble(txt2Amt.Text);
            double Amt_3 = Convert.ToDouble(txt3Amt.Text);
            double Amt_4 = Convert.ToDouble(txt4Amt.Text);
            double Amt_5 = Convert.ToDouble(txt5Amt.Text);
            double Amt_6 = Convert.ToDouble(txt6Amt.Text);
            double Amt_7 = Convert.ToDouble(txt7Amt.Text);
            double Amt_8 = Convert.ToDouble(txt8Amt.Text);
            double Amt_9 = Convert.ToDouble(txt9Amt.Text);
            double Amt_10 = Convert.ToDouble(txt10Amt.Text);



            double Total = Amt_1 + Amt_2 + Amt_3 + Amt_4 + Amt_5 + Amt_6 + Amt_7 + Amt_8 + Amt_9 + Amt_10;
            txtConsign_Value.Text = Convert.ToString(Math.Round(Total));
        }

        private void txt6Amt_TextChanged(object sender, EventArgs e)
        {
            if (txt1Amt.Text == "")
            {
                txt1Amt.Text = "0";
            }
            else if (txt2Amt.Text == "")
            {
                txt2Amt.Text = "0";
            }
            else if (txt3Amt.Text == "")
            {
                txt3Amt.Text = "0";
            }
            else if (txt4Amt.Text == "")
            {
                txt4Amt.Text = "0";
            }
            else if (txt5Amt.Text == "")
            {
                txt5Amt.Text = "0";
            }
            else if (txt6Amt.Text == "")
            {
                txt6Amt.Text = "0";
            }
            else if (txt7Amt.Text == "")
            {
                txt7Amt.Text = "0";
            }
            else if (txt8Amt.Text == "")
            {
                txt8Amt.Text = "0";
            }
            else if (txt9Amt.Text == "")
            {
                txt9Amt.Text = "0";
            }
            else if (txt10Amt.Text == "")
            {
                txt10Amt.Text = "0";
            }

            double Amt_1 = Convert.ToDouble(txt1Amt.Text);
            double Amt_2 = Convert.ToDouble(txt2Amt.Text);
            double Amt_3 = Convert.ToDouble(txt3Amt.Text);
            double Amt_4 = Convert.ToDouble(txt4Amt.Text);
            double Amt_5 = Convert.ToDouble(txt5Amt.Text);
            double Amt_6 = Convert.ToDouble(txt6Amt.Text);
            double Amt_7 = Convert.ToDouble(txt7Amt.Text);
            double Amt_8 = Convert.ToDouble(txt8Amt.Text);
            double Amt_9 = Convert.ToDouble(txt9Amt.Text);
            double Amt_10 = Convert.ToDouble(txt10Amt.Text);



            double Total = Amt_1 + Amt_2 + Amt_3 + Amt_4 + Amt_5 + Amt_6 + Amt_7 + Amt_8 + Amt_9 + Amt_10;
            txtConsign_Value.Text = Convert.ToString(Math.Round(Total));
        }

        private void txt7Amt_TextChanged(object sender, EventArgs e)
        {
            if (txt1Amt.Text == "")
            {
                txt1Amt.Text = "0";
            }
            else if (txt2Amt.Text == "")
            {
                txt2Amt.Text = "0";
            }
            else if (txt3Amt.Text == "")
            {
                txt3Amt.Text = "0";
            }
            else if (txt4Amt.Text == "")
            {
                txt4Amt.Text = "0";
            }
            else if (txt5Amt.Text == "")
            {
                txt5Amt.Text = "0";
            }
            else if (txt6Amt.Text == "")
            {
                txt6Amt.Text = "0";
            }
            else if (txt7Amt.Text == "")
            {
                txt7Amt.Text = "0";
            }
            else if (txt8Amt.Text == "")
            {
                txt8Amt.Text = "0";
            }
            else if (txt9Amt.Text == "")
            {
                txt9Amt.Text = "0";
            }
            else if (txt10Amt.Text == "")
            {
                txt10Amt.Text = "0";
            }

            double Amt_1 = Convert.ToDouble(txt1Amt.Text);
            double Amt_2 = Convert.ToDouble(txt2Amt.Text);
            double Amt_3 = Convert.ToDouble(txt3Amt.Text);
            double Amt_4 = Convert.ToDouble(txt4Amt.Text);
            double Amt_5 = Convert.ToDouble(txt5Amt.Text);
            double Amt_6 = Convert.ToDouble(txt6Amt.Text);
            double Amt_7 = Convert.ToDouble(txt7Amt.Text);
            double Amt_8 = Convert.ToDouble(txt8Amt.Text);
            double Amt_9 = Convert.ToDouble(txt9Amt.Text);
            double Amt_10 = Convert.ToDouble(txt10Amt.Text);



            double Total = Amt_1 + Amt_2 + Amt_3 + Amt_4 + Amt_5 + Amt_6 + Amt_7 + Amt_8 + Amt_9 + Amt_10;
            txtConsign_Value.Text = Convert.ToString(Math.Round(Total));
        }

        private void txt8Amt_TextChanged(object sender, EventArgs e)
        {
            if (txt1Amt.Text == "")
            {
                txt1Amt.Text = "0";
            }
            else if (txt2Amt.Text == "")
            {
                txt2Amt.Text = "0";
            }
            else if (txt3Amt.Text == "")
            {
                txt3Amt.Text = "0";
            }
            else if (txt4Amt.Text == "")
            {
                txt4Amt.Text = "0";
            }
            else if (txt5Amt.Text == "")
            {
                txt5Amt.Text = "0";
            }
            else if (txt6Amt.Text == "")
            {
                txt6Amt.Text = "0";
            }
            else if (txt7Amt.Text == "")
            {
                txt7Amt.Text = "0";
            }
            else if (txt8Amt.Text == "")
            {
                txt8Amt.Text = "0";
            }
            else if (txt9Amt.Text == "")
            {
                txt9Amt.Text = "0";
            }
            else if (txt10Amt.Text == "")
            {
                txt10Amt.Text = "0";
            }

            double Amt_1 = Convert.ToDouble(txt1Amt.Text);
            double Amt_2 = Convert.ToDouble(txt2Amt.Text);
            double Amt_3 = Convert.ToDouble(txt3Amt.Text);
            double Amt_4 = Convert.ToDouble(txt4Amt.Text);
            double Amt_5 = Convert.ToDouble(txt5Amt.Text);
            double Amt_6 = Convert.ToDouble(txt6Amt.Text);
            double Amt_7 = Convert.ToDouble(txt7Amt.Text);
            double Amt_8 = Convert.ToDouble(txt8Amt.Text);
            double Amt_9 = Convert.ToDouble(txt9Amt.Text);
            double Amt_10 = Convert.ToDouble(txt10Amt.Text);



            double Total = Amt_1 + Amt_2 + Amt_3 + Amt_4 + Amt_5 + Amt_6 + Amt_7 + Amt_8 + Amt_9 + Amt_10;
            txtConsign_Value.Text = Convert.ToString(Math.Round(Total));
        }

        private void txt9Amt_TextChanged(object sender, EventArgs e)
        {
            if (txt1Amt.Text == "")
            {
                txt1Amt.Text = "0";
            }
            else if (txt2Amt.Text == "")
            {
                txt2Amt.Text = "0";
            }
            else if (txt3Amt.Text == "")
            {
                txt3Amt.Text = "0";
            }
            else if (txt4Amt.Text == "")
            {
                txt4Amt.Text = "0";
            }
            else if (txt5Amt.Text == "")
            {
                txt5Amt.Text = "0";
            }
            else if (txt6Amt.Text == "")
            {
                txt6Amt.Text = "0";
            }
            else if (txt7Amt.Text == "")
            {
                txt7Amt.Text = "0";
            }
            else if (txt8Amt.Text == "")
            {
                txt8Amt.Text = "0";
            }
            else if (txt9Amt.Text == "")
            {
                txt9Amt.Text = "0";
            }
            else if (txt10Amt.Text == "")
            {
                txt10Amt.Text = "0";
            }

            double Amt_1 = Convert.ToDouble(txt1Amt.Text);
            double Amt_2 = Convert.ToDouble(txt2Amt.Text);
            double Amt_3 = Convert.ToDouble(txt3Amt.Text);
            double Amt_4 = Convert.ToDouble(txt4Amt.Text);
            double Amt_5 = Convert.ToDouble(txt5Amt.Text);
            double Amt_6 = Convert.ToDouble(txt6Amt.Text);
            double Amt_7 = Convert.ToDouble(txt7Amt.Text);
            double Amt_8 = Convert.ToDouble(txt8Amt.Text);
            double Amt_9 = Convert.ToDouble(txt9Amt.Text);
            double Amt_10 = Convert.ToDouble(txt10Amt.Text);



            double Total = Amt_1 + Amt_2 + Amt_3 + Amt_4 + Amt_5 + Amt_6 + Amt_7 + Amt_8 + Amt_9 + Amt_10;
            txtConsign_Value.Text = Convert.ToString(Math.Round(Total));
        }

        private void txt10Amt_TextChanged(object sender, EventArgs e)
        {
            if (txt1Amt.Text == "")
            {
                txt1Amt.Text = "0";
            }
            else if (txt2Amt.Text == "")
            {
                txt2Amt.Text = "0";
            }
            else if (txt3Amt.Text == "")
            {
                txt3Amt.Text = "0";
            }
            else if (txt4Amt.Text == "")
            {
                txt4Amt.Text = "0";
            }
            else if (txt5Amt.Text == "")
            {
                txt5Amt.Text = "0";
            }
            else if (txt6Amt.Text == "")
            {
                txt6Amt.Text = "0";
            }
            else if (txt7Amt.Text == "")
            {
                txt7Amt.Text = "0";
            }
            else if (txt8Amt.Text == "")
            {
                txt8Amt.Text = "0";
            }
            else if (txt9Amt.Text == "")
            {
                txt9Amt.Text = "0";
            }
            else if (txt10Amt.Text == "")
            {
                txt10Amt.Text = "0";
            }

            double Amt_1 = Convert.ToDouble(txt1Amt.Text);
            double Amt_2 = Convert.ToDouble(txt2Amt.Text);
            double Amt_3 = Convert.ToDouble(txt3Amt.Text);
            double Amt_4 = Convert.ToDouble(txt4Amt.Text);
            double Amt_5 = Convert.ToDouble(txt5Amt.Text);
            double Amt_6 = Convert.ToDouble(txt6Amt.Text);
            double Amt_7 = Convert.ToDouble(txt7Amt.Text);
            double Amt_8 = Convert.ToDouble(txt8Amt.Text);
            double Amt_9 = Convert.ToDouble(txt9Amt.Text);
            double Amt_10 = Convert.ToDouble(txt10Amt.Text);



            double Total = Amt_1 + Amt_2 + Amt_3 + Amt_4 + Amt_5 + Amt_6 + Amt_7 + Amt_8 + Amt_9 + Amt_10;
            txtConsign_Value.Text = Convert.ToString(Math.Round(Total));
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Dispatch_Form403 set [403_Active]   ='" + ddlActive.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where [403_No]  ='" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "'", con);

                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");

                ClearAll();
            }

        }

        private void CmdSearch_Click(object sender, EventArgs e)
        {
          
           
         

            if (ddlSearch.Text == "Sr.No.")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select [403_No] as 'Sr.No.',convert (varchar(20),[403_Dt],103) as 'Form 403 Dt.',b.P_Name as 'Party',a.Trans_Nature as 'Nature of Transaction',a.Consign_Value as 'Consigned Value',a.Transp_Name as 'Transporter Name',c.Drv_FName+' '+c.Drv_MName+' '+Drv_LName as 'Driver Name',[403_Active] as 'Active' from Dispatch_Form403 as a ,Party_Master as b,Driver_Master as c where a.P_ID=b.P_ID and a.Drv_ID=c.Drv_ID and  [403_No] like '%" + txt_Search.Text.ToString() + "%'  order by [403_No]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                this.GridView1.Columns[7].Visible = false;

            }
           else if (ddlSearch.Text == "Form 403 Dt")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select [403_No] as 'Sr.No.',convert (varchar(20),[403_Dt],103) as 'Form 403 Dt.',b.P_Name as 'Party',a.Trans_Nature as 'Nature of Transaction',a.Consign_Value as 'Consigned Value',a.Transp_Name as 'Transporter Name',c.Drv_FName+' '+c.Drv_MName+' '+Drv_LName as 'Driver Name',[403_Active] as 'Active' from Dispatch_Form403 as a ,Party_Master as b,Driver_Master as c where a.P_ID=b.P_ID and a.Drv_ID=c.Drv_ID and  [403_Dt] =Convert(datetime,'" + txt_Search.Text + "',103) order by [403_No]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                this.GridView1.Columns[7].Visible = false;

            }
            else if (ddlSearch.Text == "Party")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select [403_No] as 'Sr.No.',convert (varchar(20),[403_Dt],103) as 'Form 403 Dt.',b.P_Name as 'Party',a.Trans_Nature as 'Nature of Transaction',a.Consign_Value as 'Consigned Value',a.Transp_Name as 'Transporter Name',c.Drv_FName+' '+c.Drv_MName+' '+Drv_LName as 'Driver Name',[403_Active] as 'Active' from Dispatch_Form403 as a ,Party_Master as b,Driver_Master as c where a.P_ID=b.P_ID and a.Drv_ID=c.Drv_ID and  b.P_Name like '%" + txt_Search.Text.ToString() + "%'  order by [403_No]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                this.GridView1.Columns[7].Visible = false;
            }
            else if (ddlSearch.Text == "Nature of Transaction")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select [403_No] as 'Sr.No.',convert (varchar(20),[403_Dt],103) as 'Form 403 Dt.',b.P_Name as 'Party',a.Trans_Nature as 'Nature of Transaction',a.Consign_Value as 'Consigned Value',a.Transp_Name as 'Transporter Name',c.Drv_FName+' '+c.Drv_MName+' '+Drv_LName as 'Driver Name',[403_Active] as 'Active' from Dispatch_Form403 as a ,Party_Master as b,Driver_Master as c where a.P_ID=b.P_ID and a.Drv_ID=c.Drv_ID and a.Trans_Nature like '%" + txt_Search.Text.ToString() + "%'  order by [403_No]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                this.GridView1.Columns[7].Visible = false;
            }
            else if (ddlSearch.Text == "Consigned Value")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select [403_No] as 'Sr.No.',convert (varchar(20),[403_Dt],103) as 'Form 403 Dt.',b.P_Name as 'Party',a.Trans_Nature as 'Nature of Transaction',a.Consign_Value as 'Consigned Value',a.Transp_Name as 'Transporter Name',c.Drv_FName+' '+c.Drv_MName+' '+Drv_LName as 'Driver Name',[403_Active] as 'Active' from Dispatch_Form403 as a ,Party_Master as b,Driver_Master as c where a.P_ID=b.P_ID and a.Drv_ID=c.Drv_ID and a.Consign_Value like '%" + txt_Search.Text.ToString() + "%'  order by [403_No]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                this.GridView1.Columns[7].Visible = false;
            }
            else if (ddlSearch.Text == "Transporter Name")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select [403_No] as 'Sr.No.',convert (varchar(20),[403_Dt],103) as 'Form 403 Dt.',b.P_Name as 'Party',a.Trans_Nature as 'Nature of Transaction',a.Consign_Value as 'Consigned Value',a.Transp_Name as 'Transporter Name',c.Drv_FName+' '+c.Drv_MName+' '+Drv_LName as 'Driver Name',[403_Active] as 'Active' from Dispatch_Form403 as a ,Party_Master as b,Driver_Master as c where a.P_ID=b.P_ID and a.Drv_ID=c.Drv_ID and  a.Transp_Name like '%" + txt_Search.Text.ToString() + "%'  order by [403_No]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                this.GridView1.Columns[7].Visible = false;
            }
            else if (ddlSearch.Text == "Driver Name")
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select [403_No] as 'Sr.No.',convert (varchar(20),[403_Dt],103) as 'Form 403 Dt.',b.P_Name as 'Party',a.Trans_Nature as 'Nature of Transaction',a.Consign_Value as 'Consigned Value',a.Transp_Name as 'Transporter Name',c.Drv_FName+' '+c.Drv_MName+' '+Drv_LName as 'Driver Name',[403_Active] as 'Active' from Dispatch_Form403 as a ,Party_Master as b,Driver_Master as c where a.P_ID=b.P_ID and a.Drv_ID=c.Drv_ID and c.Drv_FName+' '+c.Drv_MName+' '+Drv_LName like '%" + txt_Search.Text.ToString() + "%'  order by [403_No]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                this.GridView1.Columns[7].Visible = false;
            }
            else
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter(" select [403_No] as 'Sr.No.',convert (varchar(20),[403_Dt],103) as 'Form 403 Dt.',b.P_Name as 'Party',a.Trans_Nature as 'Nature of Transaction',a.Consign_Value as 'Consigned Value',a.Transp_Name as 'Transporter Name',c.Drv_FName+' '+c.Drv_MName+' '+Drv_LName as 'Driver Name',[403_Active] as 'Active' from Dispatch_Form403 as a ,Party_Master as b,Driver_Master as c where a.P_ID=b.P_ID and a.Drv_ID=c.Drv_ID order by [403_No]", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                this.GridView1.Columns[7].Visible = false;
            }

        }

        private void cmdPrint_Click(object sender, EventArgs e)
        { funclib = new FunctionLib();
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
            sfd.FileName = "CopyOf Form No 403.pdf";
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


                    var bigFontbold = FontFactory.GetFont("NewFont", 14, 1);
                    var libigFontbold = FontFactory.GetFont("NewFont", 11, 1);
                    var titleFont = FontFactory.GetFont("NewFont", 14);
                    var subTitleFont = FontFactory.GetFont("NewFont", 14);
                    var boldTableFont = FontFactory.GetFont("NewFont", 12);
                    var endingMessageFont = FontFactory.GetFont("NewFont", 12);
                    var bodyFont = FontFactory.GetFont("NewFont", 12);
                    var underline = FontFactory.GetFont("BodyFont", 10);
                    var underlinBold = FontFactory.GetFont("NewFont", 9);
                    var smallfont = FontFactory.GetFont("NewFont", 8);
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
                    //PdfPTable footerTbl = new PdfPTable(1);
                    //footerTbl.TotalWidth = doc.PageSize.Width;

                    //footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
                    //PdfPCell cell = new PdfPCell(new Phrase("ePacker - www.ropras.com", footerfont));
                    //cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    //cell.Border = 0;
                    //footerTbl.AddCell(cell);
                    //footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin + 20), wri.DirectContent);



                    //doc.Add(logo);
                    //doc.Add(new Paragraph("" + '\n'));
                    //doc.Add(new Paragraph("" + '\n'));



                    Chunk MainTitle = new Chunk(Grp_Name + '\n', boldTableFont);
                    MainTitle.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaMainTitle = new Paragraph(MainTitle);
                    //ParaMainTitle.SpacingBefore = 5f;
                    //ParaMainTitle.SpacingAfter = 5f;


                    Chunk chunk = new Chunk("Dispatch : Invoice Copy" + '\n', titleFont);
                    chunk.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaTitle = new Paragraph(chunk);
                    ParaTitle.SpacingBefore = 5f;
                    ParaTitle.SpacingAfter = 5f;






                    var phrase77 = new Phrase();
                    phrase77.Add(new Chunk("Form No. 403", bigFontbold));
                    Paragraph pf4_4 = new Paragraph(phrase77);
                    pf4_4.Alignment = 1;



                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("See Sub-Rule (5) of Rule 51)", underline));
                    Paragraph pf7 = new Paragraph(phrase8);
                    pf7.Alignment = 1;
                    // pf4.SpacingBefore = 5f;


                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("Declaration under Section 68 of the Gujrat Value Added Tax Act 2003", underline));
                    Paragraph pf8 = new Paragraph(phraseIns);
                    pf8.Alignment = 1;

                    var phraseChall = new Phrase();
                    phraseChall.Add(new Chunk("(For goods entering into the State from outside the State)", underline));
                    Paragraph pf8_1 = new Paragraph(phraseChall);
                    pf8_1.Alignment = 1;



                    var phrase16 = new Phrase();
                    phrase16.Add(new Chunk("Sr. No.         " + txt403_No.Text + "                                                                       Form 403  Dt.  " + txt403_Dt.Text, underline));
                    Paragraph pf10 = new Paragraph(phrase16);
                    pf10.SpacingBefore = 4f;
                    pf10.SpacingAfter = 4f;


                    var phrase18 = new Phrase();
                    phrase18.Add(new Chunk("The Officer in Charge, Check Post ___________________________________________________", underline));
                    Paragraph pf12 = new Paragraph(phrase18);
                    pf12.SpacingAfter = 5f;

                    var phrase19 = new Phrase();
                    phrase19.Add(new Chunk("(1) Place from which goods are dispatched   " + txtPlace_From.Text.ToString() + "  District  " + txtPlace_FromDist.Text, underline));
                    Paragraph pf13 = new Paragraph(phrase19);
                    pf13.SpacingAfter = 3f;

                    var phrase20 = new Phrase();
                    phrase20.Add(new Chunk("(2) Place to which goods are dispatched       " + txtPlace_To.Text.ToString() + "  District  " + txtPlace_ToDist.Text, underline));
                    Paragraph pf14 = new Paragraph(phrase20);
                    pf14.SpacingAfter = 3f;

                    var phrase21 = new Phrase();
                    phrase21.Add(new Chunk("(3) Details of goods Invoice No.                      " + txtGoods_InvNo.Text.ToString() + "  Date      " + txtGoods_InvDt.Text, underline));
                    Paragraph pf15 = new Paragraph(phrase21);
                    pf15.SpacingAfter = 3f;

                    var phrase22 = new Phrase();
                    phrase22.Add(new Chunk("(4) Consignor (Group)                                     " + ddlGrp_ID.Text.ToString(), underline));
                    Paragraph pf16 = new Paragraph(phrase22);

                    var phrase23 = new Phrase();
                    phrase23.Add(new Chunk("          Address  " + txtG_Address.Text.ToString(), underline));
                    Paragraph pf17 = new Paragraph(phrase23);


                    var phrase24 = new Phrase();
                    phrase24.Add(new Chunk("          Phone  " + txtG_Phone.Text.ToString() + "        VAT No.  " + txtG_Vat.Text + "        C.S.T. No.  " + txtG_CSt.Text, underline));
                    Paragraph pf18 = new Paragraph(phrase24);
                    pf18.SpacingAfter = 3f;


                    var phrase25 = new Phrase();
                    phrase25.Add(new Chunk("(5) Nature of Transaction                               " + ddlTrans_Nature.Text.ToString(), underline));
                    Paragraph pf19 = new Paragraph(phrase25);
                    pf19.SpacingAfter = 3f;


                    var phrase26 = new Phrase();
                    phrase26.Add(new Chunk("(6) Consignee (Party)                                     " + ddlP_ID.Text.ToString(), underline));
                    Paragraph pf20 = new Paragraph(phrase26);
                    pf20.SpacingAfter = 3f;

                    var phrase27 = new Phrase();
                    phrase27.Add(new Chunk("          Address  " + txtP_Address.Text.ToString(), underline));
                    Paragraph pf21 = new Paragraph(phrase27);


                    var phrase28 = new Phrase();
                    phrase28.Add(new Chunk("          Phone  " + txtP_Phone.Text.ToString() + "        VAT No.  " + txtP_Vat.Text + "        C.S.T. No.  " + txtP_Cst.Text, underline));
                    Paragraph pf22 = new Paragraph(phrase28);
                    pf22.SpacingAfter = 10f;




                    PdfPTable t1 = new PdfPTable(5);
                    //float[] widthst1 = new float[] { 1f, 1f, 1f, 2f, 2f };
                    //t1.SetWidths(widthst1);
                    t1.DefaultCell.BorderWidth = 2;
                    // t2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    //t2.DefaultCell.BorderColor = BaseColor.WHITE;
                    t1.WidthPercentage = 100;
                    //t2.SpacingAfter = 4f;




                    PdfPCell h1 = new PdfPCell(new Phrase("Order No.", underlinBold));
                    PdfPCell h2 = new PdfPCell(new Phrase("Challan No.", underlinBold));
                    PdfPCell h3 = new PdfPCell(new Phrase("Item", underlinBold));
                    PdfPCell h4 = new PdfPCell(new Phrase("Despatch Qty.", underlinBold));
                    PdfPCell h5 = new PdfPCell(new Phrase("Amount.", underlinBold));


                    h1.BackgroundColor = BaseColor.YELLOW;
                    h2.BackgroundColor = BaseColor.YELLOW;
                    h3.BackgroundColor = BaseColor.YELLOW;
                    h4.BackgroundColor = BaseColor.YELLOW;
                    h5.BackgroundColor = BaseColor.YELLOW;

                    t1.AddCell(h1);
                    t1.AddCell(h2);
                    t1.AddCell(h3);
                    t1.AddCell(h4);
                    t1.AddCell(h5);



                    if (ddl1Order_ID.Text != "" && ddl1Challan_No.Text != "" && txt1Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl1Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl1Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt1Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt1Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt1Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl2Order_ID.Text != "" && ddl2Challan_No.Text != "" && txt2Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl2Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl2Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt2Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt2Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt2Amt.Text, underlinBold));

                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;

                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl3Order_ID.Text != "" && ddl3Challan_No.Text != "" && txt3Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl3Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl3Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt3Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt3Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt3Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }
                    if (ddl4Order_ID.Text != "" && ddl4Challan_No.Text != "" && txt4Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl4Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl4Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt4Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt4Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt4Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl5Order_ID.Text != "" && ddl5Challan_No.Text != "" && txt5Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl5Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl5Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt5Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt5Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt5Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl6Order_ID.Text != "" && ddl6Challan_No.Text != "" && txt6Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl6Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl6Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt6Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt6Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt6Amt.Text, underlinBold));

                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;



                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }
                    if (ddl7Order_ID.Text != "" && ddl7Challan_No.Text != "" && txt7Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl7Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl7Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt7Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt7Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt7Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }
                    if (ddl8Order_ID.Text != "" && ddl8Challan_No.Text != "" && txt8Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl8Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl8Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt8Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt8Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt8Amt.Text, underlinBold));

                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;



                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl9Order_ID.Text != "" && ddl9Challan_No.Text != "" && txt9Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl9Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl9Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt9Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt9Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt9Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl10Order_ID.Text != "" && ddl10Challan_No.Text != "" && txt10Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl10Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl10Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt10Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt10Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt10Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }



                    var phrase28_1 = new Phrase();
                    phrase28_1.Add(new Chunk("Total Consigned Value (Rs.)    " + txtConsign_Value.Text.ToString(), underline));
                    Paragraph pf22_2 = new Paragraph(phrase28_1);
                    pf22_2.SpacingBefore = 2f;
                    pf22_2.Alignment = 2;

                    var phrase29 = new Phrase();
                    phrase29.Add(new Chunk("(7) Transporter's Name                          " + txtTransp_Name.Text.ToString(), underline));
                    Paragraph pf23 = new Paragraph(phrase29);


                    var phrase30 = new Phrase();
                    phrase30.Add(new Chunk("      Transporter's Address                      " + txtTransp_Address.Text.ToString(), underline));
                    Paragraph pf24 = new Paragraph(phrase30);
                    pf24.SpacingAfter = 2f;

                    var phrase31 = new Phrase();
                    phrase31.Add(new Chunk("(8) Vehicle No.                                       " + txtVeh_No.Text.ToString() + "    L.R. No.    " + txtLR_No.Text, underline));
                    Paragraph pf25 = new Paragraph(phrase31);
                    pf25.SpacingAfter = 2f;

                    var phrase32 = new Phrase();
                    phrase32.Add(new Chunk("(9) Driver                                                " + ddlDrv_ID.Text.ToString(), underline));
                    Paragraph pf26 = new Paragraph(phrase32);
                    pf26.SpacingAfter = 2f;


                    var phrase33 = new Phrase();
                    phrase33.Add(new Chunk("      Address 1                                         " + txtDrvAddress1.Text.ToString(), underline));
                    Paragraph pf27 = new Paragraph(phrase33);

                    var phrase34 = new Phrase();
                    phrase34.Add(new Chunk("      Address 2                                         " + txtDrvAddress2.Text.ToString(), underline));
                    Paragraph pf28 = new Paragraph(phrase34);

                    var phrase35 = new Phrase();
                    phrase35.Add(new Chunk("      City                                                   " + txtDrvCity.Text.ToString() + "    State   " + txtDrvState.Text + "    Pin Code  " + txtDrvPincode.Text, underline));
                    Paragraph pf29 = new Paragraph(phrase35);

                    var phrase36 = new Phrase();
                    phrase36.Add(new Chunk("      License No.                                      " + txtDrvLicenseNo.Text.ToString() + "   License State  " + txtDrvLicenseState.Text, underline));
                    Paragraph pf30 = new Paragraph(phrase36);

                    var phrase37 = new Phrase();
                    phrase37.Add(new Chunk("      Place                                                " + txt403_Place.Text.ToString(), underline));
                    Paragraph pf31 = new Paragraph(phrase37);



                    var phrase38 = new Phrase();
                    phrase38.Add(new Chunk("FOR SALES TAX DEPARTMENT / CHECK POST", libigFontbold));
                    Paragraph pf32 = new Paragraph(phrase38);
                    pf32.Alignment = 1;
                    pf32.SpacingAfter = 10f;
                    pf32.SpacingBefore = 5f;


                    PdfPTable t2 = new PdfPTable(5);
                    float[] widthst2 = new float[] { 1f, 1f, 1f, 2f, 2f };
                    t2.SetWidths(widthst2);
                    t2.DefaultCell.BorderWidth = 2;
                    // t2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    //t2.DefaultCell.BorderColor = BaseColor.WHITE;
                    t2.WidthPercentage = 90;
                    //t2.SpacingAfter = 4f;




                    PdfPCell Length_MM = new PdfPCell(new Phrase("Entry No.", underlinBold));
                    PdfPCell Width_MM = new PdfPCell(new Phrase("Date", underlinBold));
                    PdfPCell Height_MM = new PdfPCell(new Phrase("Time", underlinBold));
                    PdfPCell Dimn_Opt = new PdfPCell(new Phrase("Reason for abnormal stoppage", underlinBold));
                    PdfPCell Length_MM_Conv = new PdfPCell(new Phrase("Result if any", underlinBold));

                    t2.AddCell(Length_MM);
                    t2.AddCell(Width_MM);
                    t2.AddCell(Height_MM);
                    t2.AddCell(Dimn_Opt);
                    t2.AddCell(Length_MM_Conv);



                    PdfPCell c1 = new PdfPCell(new Phrase("Vehicle", underlinBold));
                    PdfPCell c2 = new PdfPCell(new Phrase("", underlinBold));

                    PdfPCell c3 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c4 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c5 = new PdfPCell(new Phrase("", underlinBold));


                    PdfPCell c11 = new PdfPCell(new Phrase("Arrival", underlinBold));
                    PdfPCell c22 = new PdfPCell(new Phrase("", underlinBold));

                    PdfPCell c33 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c44 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c55 = new PdfPCell(new Phrase("", underlinBold));


                    PdfPCell c111 = new PdfPCell(new Phrase("Depart", underlinBold));
                    PdfPCell c222 = new PdfPCell(new Phrase("", underlinBold));

                    PdfPCell c333 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c444 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c555 = new PdfPCell(new Phrase("", underlinBold));






                    t2.AddCell(c1);
                    t2.AddCell(c2);
                    t2.AddCell(c3);
                    t2.AddCell(c4);
                    t2.AddCell(c5);


                    t2.AddCell(c11);
                    t2.AddCell(c22);
                    t2.AddCell(c33);
                    t2.AddCell(c44);
                    t2.AddCell(c55);

                    t2.AddCell(c111);
                    t2.AddCell(c222);
                    t2.AddCell(c333);
                    t2.AddCell(c444);
                    t2.AddCell(c555);



                    var phrase39 = new Phrase();
                    phrase39.Add(new Chunk("                  Date : ___________ Signature : _______________ Designation : ______________", underline));
                    Paragraph pf33 = new Paragraph(phrase39);



                    //doc.Add(MainTitle);

                    //doc.Add(ParaTitle);


                    doc.Add(pf4_4);
                    doc.Add(pf7);
                    doc.Add(pf8);
                    doc.Add(pf8_1);

                    LineSeparator line4 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line4));


                    doc.Add(pf10);
                    doc.Add(pf12);
                    doc.Add(pf13);
                    doc.Add(pf14);
                    doc.Add(pf15);
                    doc.Add(pf16);
                    doc.Add(pf17);
                    doc.Add(pf18);
                    doc.Add(pf19);
                    doc.Add(pf20);
                    doc.Add(pf21);
                    doc.Add(pf22);
                    doc.Add(t1);
                    doc.Add(pf22_2);
                    doc.Add(pf23);
                    doc.Add(pf24);
                    doc.Add(pf25);
                    doc.Add(pf26);
                    doc.Add(pf27);
                    doc.Add(pf28);
                    doc.Add(pf29);
                    doc.Add(pf30);
                    doc.Add(pf31);
                    LineSeparator line5 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line5));
                    doc.Add(pf32);
                    doc.Add(t2);
                    doc.Add(pf33);





                    //Itemg Grid2






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

        private void GridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;

            cmdPrint.Visible = true;

            ddlActive.Enabled = true;

            txt403_Dt.Enabled = false;
            txtPlace_From.Enabled = false;
            txtPlace_FromDist.Enabled = false;
            txtPlace_To.Enabled = false;
            txtPlace_ToDist.Enabled = false;
            txtTransp_Address.Enabled = false;
            txtTransp_Name.Enabled = false;
            txtVeh_No.Enabled = false;
            txtLR_No.Enabled = false;
            txt403_Place.Enabled = false;
            txtGoods_InvDt.Enabled = false;
            txtGoods_InvNo.Enabled = false;

            ddlGrp_ID.Enabled = false;
            ddlTrans_Nature.Enabled = false;
            ddlP_ID.Enabled = false;
            ddlDrv_ID.Enabled = false;
            ddl1Challan_No.Enabled = false;
            ddl1Order_ID.Enabled = false;
            ddl2Challan_No.Enabled = false;
            ddl2Order_ID.Enabled = false;
            ddl3Challan_No.Enabled = false;
            ddl3Order_ID.Enabled = false;
            ddl4Challan_No.Enabled = false;
            ddl4Order_ID.Enabled = false;
            ddl5Challan_No.Enabled = false;
            ddl5Order_ID.Enabled = false;
            ddl6Challan_No.Enabled = false;
            ddl6Order_ID.Enabled = false;
            ddl7Challan_No.Enabled = false;
            ddl7Order_ID.Enabled = false;
            ddl8Challan_No.Enabled = false;
            ddl8Order_ID.Enabled = false;
            ddl9Challan_No.Enabled = false;
            ddl9Order_ID.Enabled = false;
            ddl10Challan_No.Enabled = false;
            ddl10Order_ID.Enabled = false;



            ddlGrp_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlTrans_Nature.DropDownStyle = ComboBoxStyle.Simple;
            ddlP_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlDrv_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddl1Challan_No.DropDownStyle = ComboBoxStyle.Simple;
            ddl1Order_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddl2Challan_No.DropDownStyle = ComboBoxStyle.Simple;
            ddl2Order_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddl3Challan_No.DropDownStyle = ComboBoxStyle.Simple;
            ddl3Order_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddl4Challan_No.DropDownStyle = ComboBoxStyle.Simple;
            ddl4Order_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddl5Challan_No.DropDownStyle = ComboBoxStyle.Simple;
            ddl5Order_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddl6Challan_No.DropDownStyle = ComboBoxStyle.Simple;
            ddl6Order_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddl7Challan_No.DropDownStyle = ComboBoxStyle.Simple;
            ddl7Order_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddl8Challan_No.DropDownStyle = ComboBoxStyle.Simple;
            ddl8Order_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddl9Challan_No.DropDownStyle = ComboBoxStyle.Simple;
            ddl9Order_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddl10Challan_No.DropDownStyle = ComboBoxStyle.Simple;
            ddl10Order_ID.DropDownStyle = ComboBoxStyle.Simple;


            txt403_No.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            ddlActive.Text = GridView1.Rows[e.RowIndex].Cells[7].Value.ToString();


            funclib = new FunctionLib();
            string strCon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strCon);
            SqlConnection con1 = new SqlConnection(strCon);
            SqlConnection con3 = new SqlConnection(strCon);


           
            //SqlCommand cmdPositive = new SqlCommand("insert into Dispatch_Form403([403_No],[403_Dt],Grp_ID,Place_From,Place_FromDist,Place_To,Place_ToDist,Goods_InvNo,P_ID,Goods_InvDt,Trans_Nature,Consign_Value,Transp_Name,Transp_Address,Veh_No,LR_No,Drv_ID,[403_Place],[403_Active],Add_By,Add_ByNode,Add_On) values('" + txt403_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txt403_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlGrp_ID.SelectedValue.ToString() + "','" + txtPlace_From.Text.Trim().Replace("'", "''").ToString() + "','" + txtPlace_FromDist.Text.Trim().Replace("'", "''").ToString() + "','" + txtPlace_To.Text.Trim().Replace("'", "''").ToString() + "','" + txtPlace_ToDist.Text.Trim().Replace("'", "''").ToString() + "','" + txtGoods_InvNo.Text.Trim().Replace("'", "''").ToString() + "','" + ddlP_ID.SelectedValue.ToString() + "',convert(datetime,'" + txtGoods_InvDt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlTrans_Nature.Text.ToString() + "','" + txtConsign_Value.Text.Trim().Replace("'", "''").ToString() + "','" + txtTransp_Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtTransp_Address.Text.Trim().Replace("'", "''").ToString() + "','" + txtVeh_No.Text.Trim().Replace("'", "''").ToString() + "','" + txtLR_No.Text.Trim().Replace("'", "''").ToString() + "','" + ddlDrv_ID.SelectedValue.ToString() + "','" + txt403_Place.Text.Trim().Replace("'", "''").ToString() + "','" + ddlActive.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
            string strsql5 = "select  Grp_Name from Group_Master  where Grp_Active='Yes' and Grp_ID = '" + Group_ID + "'";
            SqlCommand cmd5 = new SqlCommand(strsql5, con);
            con.Open();
            SqlDataReader dr = cmd5.ExecuteReader();
            if (dr.Read())
            {


                ddlGrp_ID.Text = Convert.ToString(dr["Grp_Name"]);



            }
            dr.Close();
            con.Close();



            string strsql6 = "select convert(varchar(20),[403_Dt],103) as 'Date',Place_From,Place_FromDist,Place_To,Place_ToDist,Goods_InvNo,P_ID,convert(varchar(20),Goods_InvDt,103) as 'Goods_InvDt',Trans_Nature,Consign_Value,Transp_Name,Transp_Address,Veh_No,LR_No,Drv_ID,[403_Place] as 'Place' from Dispatch_Form403  where   [403_No] = '" + txt403_No.Text + "'";
            SqlCommand cmd6 = new SqlCommand(strsql6, con);
            con.Open();
            SqlDataReader dr1 = cmd6.ExecuteReader();
            if (dr1.Read())
            {


                txt403_Dt.Text = Convert.ToString(dr1["Date"]);
                txtPlace_From.Text = Convert.ToString(dr1["Place_From"]);
                txtPlace_FromDist.Text = Convert.ToString(dr1["Place_FromDist"]);
                txtPlace_To.Text = Convert.ToString(dr1["Place_To"]);
                txtPlace_ToDist.Text = Convert.ToString(dr1["Place_ToDist"]);
                P_ID = Convert.ToString(dr1["P_ID"]);
                txtGoods_InvDt.Text = Convert.ToString(dr1["Goods_InvDt"]);
                txtGoods_InvNo.Text = Convert.ToString(dr1["Goods_InvNo"]);
                ddlTrans_Nature.Text = Convert.ToString(dr1["Trans_Nature"]);

                txtConsign_Value.Text = Convert.ToString(dr1["Consign_Value"]);
                txtTransp_Name.Text = Convert.ToString(dr1["Transp_Name"]);
                txtTransp_Address.Text = Convert.ToString(dr1["Transp_Address"]);
                txtVeh_No.Text = Convert.ToString(dr1["Veh_No"]);
                txtLR_No.Text = Convert.ToString(dr1["LR_No"]);
                Drv_ID = Convert.ToString(dr1["Drv_ID"]);
                txt403_Place.Text = Convert.ToString(dr1["Place"]);



            }
            dr1.Close();
            con.Close();



            SqlCommand cmd7 = new SqlCommand("select  Grp_Address,Grp_Phone,Grp_LST,Grp_CST from Group_Master where Grp_ID ='" + Group_ID + "'", con1);
            con1.Open();
            SqlDataReader dr7 = cmd7.ExecuteReader();
            if (dr7.Read())
            {

                txtG_Address.Text = Convert.ToString(dr7["Grp_Address"]);
                txtG_Phone.Text = Convert.ToString(dr7["Grp_Phone"]);
                txtG_Vat.Text = Convert.ToString(dr7["Grp_LST"]);
                txtG_CSt.Text = Convert.ToString(dr7["Grp_CST"]);

            }
            dr7.Close();
            con1.Close();

            //SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as P_ID, '' as P_Name UNION select  a.P_ID, a.P_Name  as  PName from Party_Master a where  a.Grp_ID = '" + Group_ID + "' and a.P_Active='Yes'", con);

            SqlCommand cmd8 = new SqlCommand("select  P_Name from Party_Master where P_ID ='" + P_ID + "'", con1);
            con1.Open();
            SqlDataReader dr8 = cmd8.ExecuteReader();
            if (dr8.Read())
            {

                ddlP_ID.Text = Convert.ToString(dr8["P_Name"]);
              

            }
            dr8.Close();
            con1.Close();


            SqlCommand cmd9 = new SqlCommand("select P_Addr1+' '+P_Addr2 as 'Address',P_Tel,LBT_No,P_CST from Party_Master where P_ID ='" + P_ID+ "'", con1);
            con1.Open();
            SqlDataReader dr9 = cmd9.ExecuteReader();
            if (dr9.Read())
            {

                txtP_Address.Text = Convert.ToString(dr9["Address"]);
                txtP_Phone.Text = Convert.ToString(dr9["P_Tel"]);
                txtP_Vat.Text = Convert.ToString(dr9["LBT_No"]);
                txtP_Cst.Text = Convert.ToString(dr9["P_CST"]);

            }
            dr9.Close();
            con1.Close();

            //SqlDataAdapter da3 = new SqlDataAdapter("SELECT '' as Drv_ID, '' as DRV_Name UNION select  Drv_ID,Drv_FName+' '+Drv_MName+' '+Drv_LName   as  DRV_Name from Driver_Master where  Grp_ID = '" + Group_ID + "' and Drv_Active='Yes'", con);

            SqlCommand cmd10 = new SqlCommand("select Drv_FName+' '+Drv_MName+' '+Drv_LName   as  DRV_Name from Driver_Master where Drv_ID ='" + Drv_ID + "'", con1);
            con1.Open();
            SqlDataReader dr10 = cmd10.ExecuteReader();
            if (dr10.Read())
            {

                ddlDrv_ID.Text = Convert.ToString(dr10["DRV_Name"]);
         
            }
            dr10.Close();
            con1.Close();



            SqlCommand cmd11 = new SqlCommand("SELECT Drv_Addr1,Drv_Addr2,Drv_City,Drv_State,Drv_PinCode,Drv_LicnNo,Drv_LicnState from Driver_Master  where Drv_ID ='" + Drv_ID+ "'", con1);
            con1.Open();
            SqlDataReader dr11 = cmd11.ExecuteReader();
            if (dr11.Read())
            {

                txtDrvAddress1.Text = Convert.ToString(dr11["Drv_Addr1"]);
                txtDrvAddress2.Text = Convert.ToString(dr11["Drv_Addr2"]);
                txtDrvCity.Text = Convert.ToString(dr11["Drv_City"]);
                txtDrvState.Text = Convert.ToString(dr11["Drv_State"]);
                txtDrvPincode.Text = Convert.ToString(dr11["Drv_PinCode"]);
                txtDrvLicenseNo.Text = Convert.ToString(dr11["Drv_LicnNo"]);
                txtDrvLicenseState.Text = Convert.ToString(dr11["Drv_LicnState"]);

            }
            dr11.Close();
            con1.Close();

            //reading from Detail Table
            
            SqlCommand cmd12 = new SqlCommand("SELECT Order_ID,Challan_No from Dispatch_Form403Det  where [403_No] ='" + txt403_No.Text + "'", con1);
            con1.Open();
            SqlDataReader dr12 = cmd12.ExecuteReader();
            while (dr12.Read())
            {




                if (Detail1 == "Yes")
                {
                    ddl1Order_ID.Text = Convert.ToString(dr12["Order_ID"]);
                    ddl1Challan_No.Text = Convert.ToString(dr12["Challan_No"]);

                    Detail1 = "No";

               
                    SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl1Challan_No.Text + "'", con3);
                    con3.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {

                        txt1Item.Text = Convert.ToString(dr3["Item_Name"]);
                        txt1Qty.Text = Convert.ToString(dr3["Qty"]);
                        txt1Amt.Text = Convert.ToString(dr3["Grand_Amt"]);


                    }
                    dr3.Close();
                    con3.Close();
                }                                   

               else if (Detail2 == "Yes")
                {
                    ddl2Order_ID.Text = Convert.ToString(dr12["Order_ID"]);
                    ddl2Challan_No.Text = Convert.ToString(dr12["Challan_No"]);
                    Detail2 = "No";

                    SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl2Challan_No.Text + "'", con3);
                    con3.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {

                        txt2Item.Text = Convert.ToString(dr3["Item_Name"]);
                        txt2Qty.Text = Convert.ToString(dr3["Qty"]);
                        txt2Amt.Text = Convert.ToString(dr3["Grand_Amt"]);


                    }
                    dr3.Close();
                    con3.Close();
                }

                else if (Detail3 == "Yes")
                {
                    ddl3Order_ID.Text = Convert.ToString(dr12["Order_ID"]);
                    ddl3Challan_No.Text = Convert.ToString(dr12["Challan_No"]);
                    Detail3 = "No";


                    SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl3Challan_No.Text + "'", con3);
                    con3.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {

                        txt3Item.Text = Convert.ToString(dr3["Item_Name"]);
                        txt3Qty.Text = Convert.ToString(dr3["Qty"]);
                        txt3Amt.Text = Convert.ToString(dr3["Grand_Amt"]);


                    }
                    dr3.Close();
                    con3.Close();
                }
                else if (Detail4 == "Yes")
                {
                    ddl4Order_ID.Text = Convert.ToString(dr12["Order_ID"]);
                    ddl4Challan_No.Text = Convert.ToString(dr12["Challan_No"]);
                    Detail4 = "No";


                    SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl4Challan_No.Text + "'", con3);
                    con3.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {

                        txt4Item.Text = Convert.ToString(dr3["Item_Name"]);
                        txt4Qty.Text = Convert.ToString(dr3["Qty"]);
                        txt4Amt.Text = Convert.ToString(dr3["Grand_Amt"]);


                    }
                    dr3.Close();
                    con3.Close();
                }
                else if (Detail5 == "Yes")
                {
                    ddl5Order_ID.Text = Convert.ToString(dr12["Order_ID"]);
                    ddl5Challan_No.Text = Convert.ToString(dr12["Challan_No"]);
                    Detail5 = "No";

                    SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl5Challan_No.Text + "'", con3);
                    con3.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {

                        txt5Item.Text = Convert.ToString(dr3["Item_Name"]);
                        txt5Qty.Text = Convert.ToString(dr3["Qty"]);
                        txt5Amt.Text = Convert.ToString(dr3["Grand_Amt"]);


                    }
                    dr3.Close();
                    con3.Close();
                }
                else if (Detail6 == "Yes")
                {
                    ddl6Order_ID.Text = Convert.ToString(dr12["Order_ID"]);
                    ddl6Challan_No.Text = Convert.ToString(dr12["Challan_No"]);
                    Detail6 = "No";


                    SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl6Challan_No.Text + "'", con3);
                    con3.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {

                        txt6Item.Text = Convert.ToString(dr3["Item_Name"]);
                        txt6Qty.Text = Convert.ToString(dr3["Qty"]);
                        txt6Amt.Text = Convert.ToString(dr3["Grand_Amt"]);


                    }
                    dr3.Close();
                    con3.Close();
                }
                else if (Detail7 == "Yes")
                {
                    ddl7Order_ID.Text = Convert.ToString(dr12["Order_ID"]);
                    ddl7Challan_No.Text = Convert.ToString(dr12["Challan_No"]);
                    Detail7 = "No";


                    SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl7Challan_No.Text + "'", con3);
                    con3.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {

                        txt7Item.Text = Convert.ToString(dr3["Item_Name"]);
                        txt7Qty.Text = Convert.ToString(dr3["Qty"]);
                        txt7Amt.Text = Convert.ToString(dr3["Grand_Amt"]);


                    }
                    dr3.Close();
                    con3.Close();
                }

                else if (Detail8 == "Yes")
                {
                    ddl8Order_ID.Text = Convert.ToString(dr12["Order_ID"]);
                    ddl8Challan_No.Text = Convert.ToString(dr12["Challan_No"]);
                    Detail8 = "No";


                    SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl8Challan_No.Text + "'", con3);
                    con3.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {

                        txt8Item.Text = Convert.ToString(dr3["Item_Name"]);
                        txt8Qty.Text = Convert.ToString(dr3["Qty"]);
                        txt8Amt.Text = Convert.ToString(dr3["Grand_Amt"]);


                    }
                    dr3.Close();
                    con3.Close();
                }
                else if (Detail9 == "Yes")
                {
                    ddl9Order_ID.Text = Convert.ToString(dr12["Order_ID"]);
                    ddl9Challan_No.Text = Convert.ToString(dr12["Challan_No"]);
                    Detail9 = "No";


                    SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl9Challan_No.Text + "'", con3);
                    con3.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {

                        txt9Item.Text = Convert.ToString(dr3["Item_Name"]);
                        txt9Qty.Text = Convert.ToString(dr3["Qty"]);
                        txt9Amt.Text = Convert.ToString(dr3["Grand_Amt"]);


                    }
                    dr3.Close();
                    con3.Close();
                }
                else if (Detail10 == "Yes")
                {
                    ddl10Order_ID.Text = Convert.ToString(dr12["Order_ID"]);
                    ddl10Challan_No.Text = Convert.ToString(dr12["Challan_No"]);
                    Detail10 = "No";


                    SqlCommand cmd3 = new SqlCommand("select (select I_Name from Item_Master as c where b.I_ID=c.I_ID) as Item_Name,a.Desp_Det as 'Qty',a.Grand_Amt from dbo.Dispatch_Challan as a,Item_Order as b where a.Order_ID=b.Order_ID and a.Challan_No ='" + ddl10Challan_No.Text + "'", con3);
                    con3.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {

                        txt10Item.Text = Convert.ToString(dr3["Item_Name"]);
                        txt10Qty.Text = Convert.ToString(dr3["Qty"]);
                        txt10Amt.Text = Convert.ToString(dr3["Grand_Amt"]);


                    }
                    dr3.Close();
                    con3.Close();
                }


             

            }
            dr12.Close();
            con1.Close();
        }

        private void txt_Search_MouseClick(object sender, MouseEventArgs e)
        {
            if (ddlSearch.Text == "Form 403 Dt")
            {
                monthCalendar3.Visible = true;
            }
        }

        private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        {
            txt_Search.Text = monthCalendar3.SelectionStart.ToShortDateString();
            monthCalendar3.Visible = false;
            txt_Search.Focus();
        }

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
            sfd.FileName = "Form No 403.pdf";
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


                    var bigFontbold = FontFactory.GetFont("NewFont", 14, 1);
                    var libigFontbold = FontFactory.GetFont("NewFont", 11, 1);
                    var titleFont = FontFactory.GetFont("NewFont", 14);
                    var subTitleFont = FontFactory.GetFont("NewFont", 14);
                    var boldTableFont = FontFactory.GetFont("NewFont", 12);
                    var endingMessageFont = FontFactory.GetFont("NewFont", 12);
                    var bodyFont = FontFactory.GetFont("NewFont", 12);
                    var underline = FontFactory.GetFont("BodyFont", 10);
                    var underlinBold = FontFactory.GetFont("NewFont", 9);
                    var smallfont = FontFactory.GetFont("NewFont", 8);
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
                    //PdfPTable footerTbl = new PdfPTable(1);
                    //footerTbl.TotalWidth = doc.PageSize.Width;

                    //footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
                    //PdfPCell cell = new PdfPCell(new Phrase("ePacker - www.ropras.com", footerfont));
                    //cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    //cell.Border = 0;
                    //footerTbl.AddCell(cell);
                    //footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin + 20), wri.DirectContent);



                    //doc.Add(logo);
                    //doc.Add(new Paragraph("" + '\n'));
                    //doc.Add(new Paragraph("" + '\n'));



                    Chunk MainTitle = new Chunk(Grp_Name + '\n', boldTableFont);
                    MainTitle.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaMainTitle = new Paragraph(MainTitle);
                    //ParaMainTitle.SpacingBefore = 5f;
                    //ParaMainTitle.SpacingAfter = 5f;


                    Chunk chunk = new Chunk("Dispatch : Invoice Copy" + '\n', titleFont);
                    chunk.SetUnderline(0.5f, -1.5f);

                    Paragraph ParaTitle = new Paragraph(chunk);
                    ParaTitle.SpacingBefore = 5f;
                    ParaTitle.SpacingAfter = 5f;






                    var phrase77 = new Phrase();
                    phrase77.Add(new Chunk("Form No. 403", bigFontbold));
                    Paragraph pf4_4 = new Paragraph(phrase77);
                    pf4_4.Alignment = 1;



                    var phrase8 = new Phrase();

                    phrase8.Add(new Chunk("See Sub-Rule (5) of Rule 51)", underline));
                    Paragraph pf7 = new Paragraph(phrase8);
                    pf7.Alignment = 1;
                    // pf4.SpacingBefore = 5f;


                    var phraseIns = new Phrase();
                    phraseIns.Add(new Chunk("Declaration under Section 68 of the Gujrat Value Added Tax Act 2003", underline));
                    Paragraph pf8 = new Paragraph(phraseIns);
                    pf8.Alignment = 1;

                    var phraseChall = new Phrase();
                    phraseChall.Add(new Chunk("(For goods entering into the State from outside the State)", underline));
                    Paragraph pf8_1 = new Paragraph(phraseChall);
                    pf8_1.Alignment = 1;

                                   

                    var phrase16 = new Phrase();
                    phrase16.Add(new Chunk("Sr. No.         " + txt403_No.Text +"                                                                       Form 403  Dt.  "+txt403_Dt.Text, underline));
                    Paragraph pf10 = new Paragraph(phrase16);
                    pf10.SpacingBefore = 4f;
                    pf10.SpacingAfter = 4f;
             

                    var phrase18 = new Phrase();
                    phrase18.Add(new Chunk("The Officer in Charge, Check Post ___________________________________________________", underline));
                    Paragraph pf12 = new Paragraph(phrase18);
                    pf12.SpacingAfter = 5f;

                    var phrase19 = new Phrase();
                    phrase19.Add(new Chunk("(1) Place from which goods are dispatched   " + txtPlace_From.Text.ToString() + "  District  "+txtPlace_FromDist.Text, underline));
                    Paragraph pf13 = new Paragraph(phrase19);
                    pf13.SpacingAfter = 3f;

                    var phrase20 = new Phrase();
                    phrase20.Add(new Chunk("(2) Place to which goods are dispatched       " + txtPlace_To.Text.ToString() + "  District  " + txtPlace_ToDist.Text, underline));
                    Paragraph pf14 = new Paragraph(phrase20);
                    pf14.SpacingAfter = 3f;

                    var phrase21 = new Phrase();
                    phrase21.Add(new Chunk("(3) Details of goods Invoice No.                      " + txtGoods_InvNo.Text.ToString() + "  Date      " + txtGoods_InvDt.Text, underline));
                    Paragraph pf15 = new Paragraph(phrase21);
                    pf15.SpacingAfter = 3f;

                    var phrase22 = new Phrase();
                    phrase22.Add(new Chunk("(4) Consignor (Group)                                     " + ddlGrp_ID.Text.ToString(), underline));
                    Paragraph pf16 = new Paragraph(phrase22);

                    var phrase23 = new Phrase();
                    phrase23.Add(new Chunk("          Address  " + txtG_Address.Text.ToString(), underline));
                    Paragraph pf17 = new Paragraph(phrase23);
                   

                    var phrase24 = new Phrase();
                    phrase24.Add(new Chunk("          Phone  " + txtG_Phone.Text.ToString() + "        VAT No.  " + txtG_Vat.Text + "        C.S.T. No.  " + txtG_CSt.Text, underline));
                    Paragraph pf18 = new Paragraph(phrase24);
                    pf18.SpacingAfter = 3f;


                    var phrase25 = new Phrase();
                    phrase25.Add(new Chunk("(5) Nature of Transaction                               " + ddlTrans_Nature.Text.ToString(), underline));
                    Paragraph pf19 = new Paragraph(phrase25);
                    pf19.SpacingAfter = 3f;


                    var phrase26 = new Phrase();
                    phrase26.Add(new Chunk("(6) Consignee (Party)                                     " + ddlP_ID.Text.ToString(), underline));
                    Paragraph pf20 = new Paragraph(phrase26);
                    pf20.SpacingAfter = 3f;

                    var phrase27 = new Phrase();
                    phrase27.Add(new Chunk("          Address  " + txtP_Address.Text.ToString(), underline));
                    Paragraph pf21 = new Paragraph(phrase27);
                    

                    var phrase28 = new Phrase();
                    phrase28.Add(new Chunk("          Phone  " + txtP_Phone.Text.ToString() + "        VAT No.  " + txtP_Vat.Text + "        C.S.T. No.  " + txtP_Cst.Text, underline));
                    Paragraph pf22 = new Paragraph(phrase28);
                    pf22.SpacingAfter = 10f;




                    PdfPTable t1 = new PdfPTable(5);
                    //float[] widthst1 = new float[] { 1f, 1f, 1f, 2f, 2f };
                    //t1.SetWidths(widthst1);
                    t1.DefaultCell.BorderWidth = 2;
                    // t2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    //t2.DefaultCell.BorderColor = BaseColor.WHITE;
                    t1.WidthPercentage = 100;
                    //t2.SpacingAfter = 4f;




                    PdfPCell h1 = new PdfPCell(new Phrase("Order No.", underlinBold));
                    PdfPCell h2 = new PdfPCell(new Phrase("Challan No.", underlinBold));
                    PdfPCell h3 = new PdfPCell(new Phrase("Item", underlinBold));
                    PdfPCell h4 = new PdfPCell(new Phrase("Despatch Qty.", underlinBold));
                    PdfPCell h5 = new PdfPCell(new Phrase("Amount.", underlinBold));


                    h1.BackgroundColor = BaseColor.YELLOW;
                    h2.BackgroundColor = BaseColor.YELLOW;
                    h3.BackgroundColor = BaseColor.YELLOW;
                    h4.BackgroundColor = BaseColor.YELLOW;
                    h5.BackgroundColor = BaseColor.YELLOW;

                    t1.AddCell(h1);
                    t1.AddCell(h2);
                    t1.AddCell(h3);
                    t1.AddCell(h4);
                    t1.AddCell(h5);



                    if (ddl1Order_ID.Text != "" && ddl1Challan_No.Text != "" && txt1Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl1Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl1Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt1Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt1Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt1Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl2Order_ID.Text != "" && ddl2Challan_No.Text != "" && txt2Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl2Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl2Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt2Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt2Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt2Amt.Text, underlinBold));

                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;

                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl3Order_ID.Text != "" && ddl3Challan_No.Text != "" && txt3Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl3Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl3Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt3Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt3Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt3Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }
                    if (ddl4Order_ID.Text != "" && ddl4Challan_No.Text != "" && txt4Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl4Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl4Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt4Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt4Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt4Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl5Order_ID.Text != "" && ddl5Challan_No.Text != "" && txt5Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl5Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl5Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt5Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt5Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt5Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl6Order_ID.Text != "" && ddl6Challan_No.Text != "" && txt6Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl6Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl6Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt6Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt6Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt6Amt.Text, underlinBold));

                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;



                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }
                    if (ddl7Order_ID.Text != "" && ddl7Challan_No.Text != "" && txt7Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl7Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl7Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt7Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt7Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt7Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }
                    if (ddl8Order_ID.Text != "" && ddl8Challan_No.Text != "" && txt8Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl8Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl8Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt8Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt8Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt8Amt.Text, underlinBold));

                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;



                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl9Order_ID.Text != "" && ddl9Challan_No.Text != "" && txt9Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl9Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl9Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt9Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt9Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt9Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }

                    if (ddl10Order_ID.Text != "" && ddl10Challan_No.Text != "" && txt10Item.Text != "")
                    {

                        PdfPCell o1 = new PdfPCell(new Phrase(ddl10Order_ID.Text, underlinBold));
                        PdfPCell o2 = new PdfPCell(new Phrase(ddl10Challan_No.Text, underlinBold));

                        PdfPCell o3 = new PdfPCell(new Phrase(txt10Item.Text, underlinBold));
                        PdfPCell o4 = new PdfPCell(new Phrase(txt10Qty.Text, underlinBold));
                        PdfPCell o5 = new PdfPCell(new Phrase(txt10Amt.Text, underlinBold));


                        o4.HorizontalAlignment = Element.ALIGN_RIGHT;
                        o5.HorizontalAlignment = Element.ALIGN_RIGHT;


                        t1.AddCell(o1);
                        t1.AddCell(o2);
                        t1.AddCell(o3);
                        t1.AddCell(o4);
                        t1.AddCell(o5);

                    }



                    var phrase28_1 = new Phrase();
                    phrase28_1.Add(new Chunk("Total Consigned Value (Rs.)    " + txtConsign_Value.Text.ToString() , underline));
                    Paragraph pf22_2 = new Paragraph(phrase28_1);
                    pf22_2.SpacingBefore = 2f;
                    pf22_2.Alignment = 2;

                    var phrase29 = new Phrase();
                    phrase29.Add(new Chunk("(7) Transporter's Name                          " + txtTransp_Name.Text.ToString(), underline));
                    Paragraph pf23 = new Paragraph(phrase29);


                    var phrase30 = new Phrase();
                    phrase30.Add(new Chunk("      Transporter's Address                      " + txtTransp_Address.Text.ToString(), underline));
                    Paragraph pf24 = new Paragraph(phrase30);
                    pf24.SpacingAfter = 2f;

                    var phrase31 = new Phrase();
                    phrase31.Add(new Chunk("(8) Vehicle No.                                       " + txtVeh_No.Text.ToString() + "    L.R. No.    " + txtLR_No.Text, underline));
                    Paragraph pf25 = new Paragraph(phrase31);
                    pf25.SpacingAfter = 2f;

                    var phrase32 = new Phrase();
                    phrase32.Add(new Chunk("(9) Driver                                                " + ddlDrv_ID.Text.ToString(), underline));
                    Paragraph pf26 = new Paragraph(phrase32);
                    pf26.SpacingAfter = 2f;


                    var phrase33 = new Phrase();
                    phrase33.Add(new Chunk("      Address 1                                         " + txtDrvAddress1.Text.ToString(), underline));
                    Paragraph pf27 = new Paragraph(phrase33);

                    var phrase34 = new Phrase();
                    phrase34.Add(new Chunk("      Address 2                                         " + txtDrvAddress2.Text.ToString(), underline));
                    Paragraph pf28 = new Paragraph(phrase34);

                    var phrase35 = new Phrase();
                    phrase35.Add(new Chunk("      City                                                   " + txtDrvCity.Text.ToString() +"    State   "+txtDrvState.Text +"    Pin Code  "+txtDrvPincode.Text, underline));
                    Paragraph pf29 = new Paragraph(phrase35);

                    var phrase36 = new Phrase();
                    phrase36.Add(new Chunk("      License No.                                      " + txtDrvLicenseNo.Text.ToString() + "   License State  " + txtDrvLicenseState.Text, underline));
                    Paragraph pf30 = new Paragraph(phrase36);

                    var phrase37 = new Phrase();
                    phrase37.Add(new Chunk("      Place                                                " + txt403_Place.Text.ToString() , underline));
                    Paragraph pf31 = new Paragraph(phrase37);



                    var phrase38 = new Phrase();
                    phrase38.Add(new Chunk("FOR SALES TAX DEPARTMENT / CHECK POST", libigFontbold));
                    Paragraph pf32 = new Paragraph(phrase38);
                    pf32.Alignment = 1;
                    pf32.SpacingAfter = 10f;
                    pf32.SpacingBefore = 5f;


                    PdfPTable t2 = new PdfPTable(5);
                    float[] widthst2 = new float[] { 1f,1f,1f,2f,2f};
                    t2.SetWidths(widthst2);
                    t2.DefaultCell.BorderWidth = 2;
                   // t2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    //t2.DefaultCell.BorderColor = BaseColor.WHITE;
                    t2.WidthPercentage = 90;
                    //t2.SpacingAfter = 4f;




                    PdfPCell Length_MM = new PdfPCell(new Phrase("Entry No.", underlinBold));
                    PdfPCell Width_MM = new PdfPCell(new Phrase("Date", underlinBold));
                    PdfPCell Height_MM = new PdfPCell(new Phrase("Time", underlinBold));
                    PdfPCell Dimn_Opt = new PdfPCell(new Phrase("Reason for abnormal stoppage", underlinBold));
                    PdfPCell Length_MM_Conv = new PdfPCell(new Phrase("Result if any", underlinBold));
              
                    t2.AddCell(Length_MM);
                    t2.AddCell(Width_MM);
                    t2.AddCell(Height_MM);
                    t2.AddCell(Dimn_Opt);
                    t2.AddCell(Length_MM_Conv);
               


                    PdfPCell c1 = new PdfPCell(new Phrase("Vehicle", underlinBold));
                    PdfPCell c2 = new PdfPCell(new Phrase("", underlinBold));

                    PdfPCell c3 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c4 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c5 = new PdfPCell(new Phrase("", underlinBold));


                    PdfPCell c11 = new PdfPCell(new Phrase("Arrival", underlinBold));
                    PdfPCell c22 = new PdfPCell(new Phrase("", underlinBold));

                    PdfPCell c33 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c44 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c55 = new PdfPCell(new Phrase("", underlinBold));


                    PdfPCell c111 = new PdfPCell(new Phrase("Depart", underlinBold));
                    PdfPCell c222 = new PdfPCell(new Phrase("", underlinBold));

                    PdfPCell c333 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c444 = new PdfPCell(new Phrase("", underlinBold));
                    PdfPCell c555 = new PdfPCell(new Phrase("", underlinBold));
          





                    t2.AddCell(c1);
                    t2.AddCell(c2);
                    t2.AddCell(c3);
                    t2.AddCell(c4);
                    t2.AddCell(c5);


                    t2.AddCell(c11);
                    t2.AddCell(c22);
                    t2.AddCell(c33);
                    t2.AddCell(c44);
                    t2.AddCell(c55);

                    t2.AddCell(c111);
                    t2.AddCell(c222);
                    t2.AddCell(c333);
                    t2.AddCell(c444);
                    t2.AddCell(c555);



                    var phrase39 = new Phrase();
                    phrase39.Add(new Chunk("                  Date : ___________ Signature : _______________ Designation : ______________", underline));
                    Paragraph pf33 = new Paragraph(phrase39);
                  


                    //doc.Add(MainTitle);

                    //doc.Add(ParaTitle);
                 

                   doc.Add(pf4_4);
                    doc.Add(pf7);
                    doc.Add(pf8);
                    doc.Add(pf8_1);
                   
                    LineSeparator line4 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line4));


                    doc.Add(pf10);
                    doc.Add(pf12);
                    doc.Add(pf13);
                    doc.Add(pf14);
                    doc.Add(pf15);
                    doc.Add(pf16);
                    doc.Add(pf17);
                    doc.Add(pf18);
                    doc.Add(pf19);
                    doc.Add(pf20);
                    doc.Add(pf21);
                    doc.Add(pf22);
                    doc.Add(t1);
                    doc.Add(pf22_2);
                    doc.Add(pf23);
                    doc.Add(pf24);
                    doc.Add(pf25);
                    doc.Add(pf26);
                    doc.Add(pf27);
                    doc.Add(pf28);
                    doc.Add(pf29);
                    doc.Add(pf30);
                    doc.Add(pf31);
                    LineSeparator line5 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    doc.Add(new Chunk(line5));
                    doc.Add(pf32);
                    doc.Add(t2);
                    doc.Add(pf33);





                    //Itemg Grid2






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
    }
}
