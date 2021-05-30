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
using System.Windows.Forms.PropertyGridInternal;

namespace ePacker1
{
    public partial class RPeP_PurchaseItemIn : Form
    {

        private FunctionLib funclib;
        private double Amount;
        private double NetAmount; 
           private double strExice1;
           private double strCess;
           private double strHScess;
           private double strcst;
           private double strInsu;
           private double strOther;
        private double GrandAmt;

        string strCurrentStock, Group_ID, strSession, strsiid, Si_ind, strAmt, strAmount, strGrandAmt, Recieve, Rate, strsiid1, strstock, OrderQyt, strPurCurrentStock, NewCurrentStock;
        //SqlConnection con = new SqlConnection();
        private Button buttnAdd = new Button();
        
        public RPeP_PurchaseItemIn()
        {
            InitializeComponent();
            strSession = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;

            funclib = new FunctionLib();
            string strcon6 = funclib.setConnection();
            SqlConnection con9 = new SqlConnection(strcon6);
            SqlCommand cmd9 = new SqlCommand("delete from Purchase_ItemIn_Det_Temp where Add_By='"+strSession+"'", con9);
            con9.Open();
            int n = cmd9.ExecuteNonQuery();
            con9.Close();


        }

        private void RPeP_PurchaseItemIn_Load(object sender, EventArgs e)
        {

            txtTotal_Amt.Text = "0";
            txtDisc_Amt.Text = "0";
            txtCSTVAT_Amt.Text = "0";
            txtHSCess_Amt.Text= "1";
            txtCess_Amt.Text= "0";
            txtExcise_Amt.Text= "6%";
            txtInsu_Amt.Text= "0";
            txtOther_Amt.Text = "0";
            txtRecieve.Text = "0";
            txtOrder.Text = "0";
            txtRate.Text = "0";
            txtFreight.Text = "0";

            monthCalendar1.Visible = false;
            calenderPoDt.Visible = false;
            challenDt.Visible = false;
            txtSIIn_ID.Visible = false;


            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            con1.Open();
            //Displayig PurchaseItem in Grid Combo field
            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as SI_ID, '' as SI_Name UNION select SI_ID,SI_Name from Purchase_Item where SI_Active='Yes' and SI_ID not in (select SI_ID from Purchase_ItemIn_Det_Temp where Add_By='" + strSession + "')", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlPurchase1.DataSource = dt;
            ddlPurchase1.DisplayMember = dt.Columns[1].ToString();
            ddlPurchase1.ValueMember = dt.Columns[0].ToString();
            //ddlGrp_ID.Items.Add("");
            ddlPurchase1.Text = "";
            con1.Close();


            ////Displayig Group Name in Combo field
            //SqlDataAdapter da1 = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master where Grp_Active='yes' ", con1);
            //DataTable dt1 = new DataTable();
            //da1.Fill(dt1);
            //ddlGrp_ID.DataSource = dt1;
            //ddlGrp_ID.DisplayMember = dt1.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt1.Columns[0].ToString();
            ////ddlGrp_ID.Items.Add("");
            //ddlGrp_ID.Text = "";
            //con1.Close();

            filldata();
            fillGrid();


            ddlSalesTaxType.Items.Add("");
            ddlSalesTaxType.Items.Add("For C Form");
            ddlSalesTaxType.Items.Add("No Form");
            ddlSalesTaxType.Items.Add("No Tax");
            ddlSalesTaxType.Items.Add("Exempted From");



            //Delete record from Purchase_ItemIn_Det_Temp

           

            //dataGridView1.Location = new Point(0, 6);
   

        }

        

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSIIn_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtSIIn_Dt.Focus();
                

          

            
            
            
        }

      

        private void txtSIIn_Dt_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

       

        private void txtSIIn_Dt_Leave(object sender, EventArgs e)
        {
            //monthCalendar1.Visible = false;

        }

        private void txtSIIn_Dt_MouseClick_1(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;

        }

        private void txtPO_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            calenderPoDt.Visible = true;

        }

        private void txtPO_Dt_Leave(object sender, EventArgs e)
        {
            //calenderPoDt.Visible = false;

        }

        private void calenderPoDt_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtPO_Dt.Text = calenderPoDt.SelectionStart.ToShortDateString();
            calenderPoDt.Visible = false;
            txtPO_Dt.Focus();

        }

        private void txtInvoice_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            challenDt.Visible = true;

        }

        private void txtInvoice_Dt_Leave(object sender, EventArgs e)
        {
            //challenDt.Visible = false;

        }

        private void challenDt_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtInvoice_Dt.Text = challenDt.SelectionStart.ToShortDateString();
            challenDt.Visible = false;
            txtInvoice_Dt.Focus();
        }

        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            //monthCalendar1.Visible = false;
        }

        private void txtSIIn_Dt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPO_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtPO_Dt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }
        private void txtSIIn_From_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);

        }

        private void txtSIIn_FromAddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtInvoice_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }


        private void txtInvoice_Dt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPO_No_KeyUp(object sender, KeyEventArgs e)
        {

        }








        private void txtSIIn_Place_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtCredit_Period_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.charNumber(e);
        }

        private void txtTotal_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtDisc_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtNet_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtExcise_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCess_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtHSCess_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCSTVAT_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtInsu_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtOther_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtGrand_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtFreight_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }


        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}
            if (txtSIIn_Dt.Text == "")//Checking for blnk PinCode field
            {
                MessageBox.Show("Enter Date");
                txtSIIn_Dt.Focus();
            }
            else if (txtPO_No.Text == "")//Checking for blnk Mobile field
            {
                MessageBox.Show("Enter PO No.");
                txtPO_No.Focus();
            }
            else if (txtPO_Dt.Text == "")//Checking for blnk BirthPlace field
            {
                MessageBox.Show("Enter PODt");
                txtPO_Dt.Focus();
            }
            else if (txtSIIn_From.Text == "")//Checking for blnk ECC field
            {
                MessageBox.Show("Please Recd. From");
                txtSIIn_From.Focus();
            }

            else if (txtSIIn_FromAddr.Text == "")//Checking for blnk Mobile field
            {
                MessageBox.Show("Enter Address");
                txtSIIn_FromAddr.Focus();
            }
            else if (txtInvoice_No.Text == "")//Checking for blnk BirthPlace field
            {
                MessageBox.Show("Enter Invoice No.");
                txtInvoice_No.Focus();
            }
            else if (txtInvoice_Dt.Text == "")//Checking for blnk ECC field
            {
                MessageBox.Show("Please select Invoice Dt.");
                txtInvoice_Dt.Focus();
            }


            else if (txtSIIn_Place.Text == "")//Checking for blnk Mobile field
            {
                MessageBox.Show("Enter Place");
                txtSIIn_Place.Focus();
            }
            else if (txtCredit_Period.Text == "")//Checking for blnk BirthPlace field
            {
                MessageBox.Show("Enter Credite.");
                txtCredit_Period.Focus();
            }
            else if (txtTotal_Amt.Text == "")//Checking for blnk ECC field
            {
                MessageBox.Show("Enter Total Amt.");
                txtTotal_Amt.Focus();
            }


            //else if (txtDisc_Amt.Text == "")//Checking for blnk Mobile field
            //{
            //    MessageBox.Show("Enter Disc_Amt.");
            //    txtDisc_Amt.Focus();
            //}
            //else if (txtNet_Amt.Text == "")//Checking for blnk BirthPlace field
            //{
            //    MessageBox.Show("Enter Net_Amt.");
            //    txtNet_Amt.Focus();
            //}
            //else if (txtExcise_Amt.Text == "")//Checking for blnk ECC field
            //{
            //    MessageBox.Show("Enter Total Excise_Amt.");
            //    txtExcise_Amt.Focus();
            //}

            //else if (txtCess_Amt.Text == "")//Checking for blnk Mobile field
            //{
            //    MessageBox.Show("Enter Cess_Amt.");
            //    txtCess_Amt.Focus();
            //}
            //else if (txtHSCess_Amt.Text == "")//Checking for blnk BirthPlace field
            //{
            //    MessageBox.Show("Enter HSCess_Amt.");
            //    txtHSCess_Amt.Focus();
            //}
            //else if (txtCSTVAT_Amt.Text == "")//Checking for blnk ECC field
            //{
            //    MessageBox.Show("Enter CSTVAT_Amt.");
            //    txtCSTVAT_Amt.Focus();
            //}


            //else if (txtInsu_Amt.Text == "")//Checking for blnk Mobile field
            //{
            //    MessageBox.Show("Enter Insu_Amt.");
            //    txtInsu_Amt.Focus();
            //}
            //else if (txtOther_Amt.Text == "")//Checking for blnk BirthPlace field
            //{
            //    MessageBox.Show("Enter Other_Amt.");
            //    txtOther_Amt.Focus();
            //}
            else if (txtGrand_Amt.Text == "")//Checking for blnk ECC field
            {
                MessageBox.Show("Enter Grand_Amt.");
                txtGrand_Amt.Focus();
            }

            else
            {

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                //con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Checking for duplicate values
                    double flag = funclib.isThere(con, "select PO_No from Purchase_ItemIn where  PO_No='" + txtPO_No.Text + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Shift is not allowed");
                    }


                    else
                    {
                        string strExciseAmt = txtExcise_Amt.Text.Replace("%", "");

                        string year = Convert.ToString(System.DateTime.Now.Year);
                        year = year + "SII";
                        //Inserting Details into table
                        Si_ind = funclib.PurchYear(year, con, "select SIIn_ID  from Purchase_ItemIn order by SIIn_ID  desc");
                        SqlCommand cmd = new SqlCommand("insert into Purchase_ItemIn values('" + Si_ind + "','" + Group_ID + "',convert(datetime,'" + txtSIIn_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + txtPO_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txtPO_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + txtInvoice_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txtInvoice_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + txtSIIn_From.Text.Trim().Replace("'", "''").ToString() + "','" + txtSIIn_FromAddr.Text.Trim().Replace("'", "''").ToString() + "','" + txtSIIn_Place.Text.Trim().Replace("'", "''").ToString() + "','" + txtCredit_Period.Text.Trim().Replace("'", "''").ToString() + "','" + txtTotal_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtDisc_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtNet_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + strExciseAmt.Trim().Replace("'", "''").ToString() + "','" + txtCess_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtHSCess_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtCSTVAT_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtInsu_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtOther_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + txtGrand_Amt.Text.Trim().Replace("'", "''").ToString() + "','" + strSession + "','',convert(datetime,getdate(),103),'','','','" + ddlSalesTaxType.Text + "','" + txtFreight.Text.Trim().Replace("'", "''").ToString() + "')", con);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Inserted");

                        con.Close();

                        funclib = new FunctionLib();
                        string strcon2 = funclib.setConnection();
                        SqlConnection con1 = new SqlConnection(strcon2);

                        SqlCommand cmd3 = new SqlCommand("select SI_ID,SI_CuStock,SI_OrdQty,SI_RecdQty,SI_Rate,SI_Amt from Purchase_ItemIn_Det_Temp where Add_By='" + strSession + "'", con1);
                        con1.Open();
                        SqlDataReader dr1 = cmd3.ExecuteReader();
                        while (dr1.Read())
                        {
                            strsiid1 = Convert.ToString(dr1["SI_ID"]);
                            strstock = Convert.ToString(dr1["SI_CuStock"]);
                            Recieve = Convert.ToString(dr1["SI_RecdQty"]);
                            OrderQyt = Convert.ToString(dr1["SI_OrdQty"]);
                            Rate = Convert.ToString(dr1["SI_Rate"]);
                            strAmt = Convert.ToString(dr1["SI_Amt"]);


                            funclib = new FunctionLib();
                            string strcon3 = funclib.setConnection();
                            SqlConnection con2 = new SqlConnection(strcon3);
                            SqlCommand cmd6 = new SqlCommand("select SI_CuStock from Purchase_Item where SI_ID='" + strsiid1 + "'", con2);
                            con2.Open();
                            SqlDataReader dr4 = cmd6.ExecuteReader();
                            if (dr4.Read())
                            {
                                strPurCurrentStock = Convert.ToString(dr4["SI_CuStock"]);
                                NewCurrentStock = Convert.ToString(Math.Round(Convert.ToDecimal(strPurCurrentStock), 2) + Math.Round(Convert.ToDecimal(Recieve), 2));
                            }
                            dr4.Close();
                            con2.Close();



                            //Insert Into Purchase_ItemIn_Det
                            funclib = new FunctionLib();
                            string strcon4 = funclib.setConnection();
                            SqlConnection con3 = new SqlConnection(strcon4);
                            SqlCommand cmd5 = new SqlCommand("insert into Purchase_ItemIn_Det values('" + Si_ind + "','" + strsiid1 + "','" + strstock + "','" + OrderQyt + "','" + Recieve + "','" + Rate + "','" + strAmt + "')", con3);
                            con3.Open();
                            int k = cmd5.ExecuteNonQuery();
                            con3.Close();


                            //Delete record from Purchase_ItemIn_Det_Temp

                            funclib = new FunctionLib();
                            string strcon6 = funclib.setConnection();
                            SqlConnection con9 = new SqlConnection(strcon6);
                            SqlCommand cmd9 = new SqlCommand("delete from Purchase_ItemIn_Det_Temp where Add_By='" + strSession + "'", con9);
                            con9.Open();
                            int n = cmd9.ExecuteNonQuery();
                            con9.Close();


                            //Update CuStock of Purchase_Item
                            funclib = new FunctionLib();
                            string strcon5 = funclib.setConnection();
                            SqlConnection con4 = new SqlConnection(strcon5);
                            SqlCommand cmd7 = new SqlCommand("update Purchase_Item set SI_CuStock='" + NewCurrentStock + "' where SI_ID='" + strsiid1 + "'",con4);
                            con4.Open();
                            int m = cmd7.ExecuteNonQuery();
                            con4.Close();



                        }

                        filldata();
                        fillGrid();
                        clearall();
                        



                    }
                }

            }

        }

        
      
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ddlPurchase1_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon1 = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon1);
            SqlCommand cmd2 = new SqlCommand("select SI_CuStock,SI_ID from Purchase_Item where SI_ID='" + ddlPurchase1.SelectedValue.ToString() + "'", con);
            con.Open();
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                strCurrentStock = Convert.ToString(dr["SI_CuStock"]);
                strsiid = Convert.ToString(dr["SI_ID"]);
            }
            con.Close();

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmdSubmitTemp_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon1 = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon1);

            double flag = funclib.isThere(con, "select SI_ID from Purchase_ItemIn_Det_Temp where  SI_ID='" + ddlPurchase1.SelectedValue.ToString() + "'");
            if (flag == 1)
            {
                MessageBox.Show("Cannot add this record as duplication of Purchase Item is not allowed");
            }
            else
            {

                SqlCommand cmd1 = new SqlCommand("insert into Purchase_ItemIn_Det_Temp values('" + strSession + "','" + strsiid + "','" + strCurrentStock + "','" + txtOrder.Text + "','" + txtRecieve.Text + "','" + txtRate.Text + "','" + txtAmt.Text + "')", con);
                con.Open();
                int i = cmd1.ExecuteNonQuery();
                con.Close();
                filldata();
                

                funclib = new FunctionLib();
                string strcon6 = funclib.setConnection();
                SqlConnection con7 = new SqlConnection(strcon6);
                SqlCommand cmd8 = new SqlCommand("select SUM(cast(SI_Amt as float)) as Amount from Purchase_ItemIn_Det_Temp where Add_By='" + strSession + "'", con7);
                con7.Open();
                SqlDataReader dr6 = cmd8.ExecuteReader();
                if (dr6.Read())
                {
                    strAmount = Convert.ToString(dr6["Amount"]);
                    txtTotal_Amt.Text = strAmount;
                }


            }
            clearall1();

             


        }

        private void txtAmt_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            clearall();
            dataGridView1.Visible = true;
            

        }
        protected void clearall1()
        {
            txtOrder.Text = "";
            txtRecieve.Text = "";
            txtAmt.Text = "";
            ddlPurchase1.Text = "";
            txtRate.Text = "";
        }
        protected void clearall()
        {
            ddlGrp_ID.Text = "";
            txtCess_Amt.Text = "";
            txtCredit_Period.Text = "";
            txtCSTVAT_Amt.Text = "";
            txtDisc_Amt.Text = "";
            txtExcise_Amt.Text = "";
            txtGrand_Amt.Text = "";
            txtHSCess_Amt.Text = "";
            txtInsu_Amt.Text = "";
            txtInvoice_Dt.Text = "";
            txtInvoice_No.Text = "";
            txtNet_Amt.Text = "";
            
            txtOther_Amt.Text = "";
            txtPO_Dt.Text = "";
            txtPO_No.Text = "";
            
            
            txtSearchPO.Text = "";
            txtSIIn_Dt.Text = "";
            txtSIIn_From.Text = "";
            txtSIIn_FromAddr.Text = "";
            txtSIIn_ID.Text = "";
            txtSIIn_Place.Text = "";
            txtTotal_Amt.Text = "";
           
            txtFreight.Text = "";
            ddlSalesTaxType.Text = "";
            txtAmtAfterTax.Text = "";
            amtbeforetax.Text = "";


            txtTotal_Amt.Text = "0";
            txtDisc_Amt.Text = "0";
            txtCSTVAT_Amt.Text = "0";
            txtHSCess_Amt.Text = "1";
            txtCess_Amt.Text = "0";
            txtExcise_Amt.Text = "6%";
            txtInsu_Amt.Text = "0";
            txtOther_Amt.Text = "0";
            txtRecieve.Text = "0";
            txtOrder.Text = "0";
            txtRate.Text = "0";
            txtFreight.Text = "0";
            

        }

        private void filldata()
        {
            //to fill the grid with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.SI_ID,b.SI_Name as PurchaseItem,a.SI_OrdQty as OrderQuantity,a.SI_RecdQty as RecdQty,a.SI_Rate as Rate,a.SI_Amt as Amt from Purchase_Item as b,Purchase_ItemIn_Det_Temp as a where a.SI_ID=b.SI_ID and SI_Active='Yes'", con4);
            //SqlDataAdapter da = new SqlDataAdapter("select a.TP_ID as TopPaperID,b.Grp_Name as GroupName,c.P_Name as PartyName,a.TP_Name as TopPaperName,d.PQ_Desc as PaperQuality, a.TP_PPLgth as TopPaperLength,a.TP_PPWdth as PaperWidth,a.TP_PPBf as PaperBf, a.TP_PPGram as PaperGram,a.TP_PPRate as PaperRate,a.TP_PPCost as PaperCost, a.TP_LmLgth as LaminationLength,a.TP_LmWdth as LaminationWidth, a.TP_LmRate as LaminationRate,a.TP_LmCost as LaminationCost ,a.TP_LmType as LaminationType,a.TP_VrLgth as VarnishLength,a.TP_VrWdth as varnishWidth,a.TP_VrRate as vanishRate,a.TP_VrCost as VarnishCost,a.TP_VrType as varnishType, a.TP_PnColor as NoColors,a.TP_PnRate as PlateRate,a.TP_PnCost as PlateCost,a.TP_PlDivFact as Divfactor, a.TP_PlNo as PlateNo,a.TP_PlRate as PlateRate,a.TP_PlCost as PlateCost, a.TP_PlWsCnt as WeightPercnt,a.TP_PlWsAmt as WeightAmt,e.Ptve_Name as PositiveName, a.TP_Rate as Rate,a.TP_OS as OpenStock,a.TP_CS as ClosingStock,a.TP_ReLev as ReOrder, a.TP_Active as Active from TopPaper_Master a,Group_Master b ,Party_Master c,PQuality_Master d,Positive_Master e  where b.Grp_ID=a.Grp_ID and b.Grp_ID=c.Grp_ID and b.Grp_ID=d.Grp_ID and a.PQ_ID=d.PQ_ID and a.P_ID=c.P_ID and a.Ptve_ID=e.Ptve_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[0].Visible = false;

        }

        private void fillGrid()
        {
            //to fill the grid with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.SIIn_ID,a.PO_No,a.SIIn_From as RecdFrom,b.Grp_Name as Groups,a.Invoice_No,a.Credit_Period,a.Grand_Amt,convert(varchar(20),a.SIIn_Dt,103) as SIIn_Dt ,convert(varchar(20),a.PO_Dt,103) as PO_Dt,convert(varchar(20),a.Invoice_Dt,103) as Invoice_Dt,a.SIIn_FromAddr,a.SIIn_Place,a.Credit_Period,a.Total_Amt,a.Disc_Amt,a.Net_Amt,a.Excise_Amt,a.Cess_Amt,a.HSCess_Amt,a.CSTVAT_Amt,a.Insu_Amt,a.Other_Amt,a.SalesTax_Type,a.Freight_Amt from Purchase_ItemIn as a,Group_Master as b where a.Grp_ID=b.Grp_ID ", con4);
            //SqlDataAdapter da = new SqlDataAdapter("select * from Purchase_ItemIn ", con4);
            //SqlDataAdapter da = new SqlDataAdapter("select a.TP_ID as TopPaperID,b.Grp_Name as GroupName,c.P_Name as PartyName,a.TP_Name as TopPaperName,d.PQ_Desc as PaperQuality, a.TP_PPLgth as TopPaperLength,a.TP_PPWdth as PaperWidth,a.TP_PPBf as PaperBf, a.TP_PPGram as PaperGram,a.TP_PPRate as PaperRate,a.TP_PPCost as PaperCost, a.TP_LmLgth as LaminationLength,a.TP_LmWdth as LaminationWidth, a.TP_LmRate as LaminationRate,a.TP_LmCost as LaminationCost ,a.TP_LmType as LaminationType,a.TP_VrLgth as VarnishLength,a.TP_VrWdth as varnishWidth,a.TP_VrRate as vanishRate,a.TP_VrCost as VarnishCost,a.TP_VrType as varnishType, a.TP_PnColor as NoColors,a.TP_PnRate as PlateRate,a.TP_PnCost as PlateCost,a.TP_PlDivFact as Divfactor, a.TP_PlNo as PlateNo,a.TP_PlRate as PlateRate,a.TP_PlCost as PlateCost, a.TP_PlWsCnt as WeightPercnt,a.TP_PlWsAmt as WeightAmt,e.Ptve_Name as PositiveName, a.TP_Rate as Rate,a.TP_OS as OpenStock,a.TP_CS as ClosingStock,a.TP_ReLev as ReOrder, a.TP_Active as Active from TopPaper_Master a,Group_Master b ,Party_Master c,PQuality_Master d,Positive_Master e  where b.Grp_ID=a.Grp_ID and b.Grp_ID=c.Grp_ID and b.Grp_ID=d.Grp_ID and a.PQ_ID=d.PQ_ID and a.P_ID=c.P_ID and a.Ptve_ID=e.Ptve_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            this.dataGridView2.Columns[0].Visible = false;

        }

        private void cmdRefreshTemp_Click(object sender, EventArgs e)
        {
            clearall1();
            
        }

    
      

      

        public void Calculation()
        {
            

        }

       

        private void txtRate_Leave(object sender, EventArgs e)
        {
                double ReciveQyt = Convert.ToDouble(txtRecieve.Text);
                double Rate=Convert.ToDouble(txtRate.Text);
                Amount = (ReciveQyt * Rate);
                txtAmt.Text = Amount.ToString();

            //txtAmt.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtRecieve.Text), 2) * Math.Round(Convert.ToDecimal(txtRate.Text), 2));
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdUpdate.Visible = true;
            txtPO_No.Enabled = false;
            ddlGrp_ID.Enabled = false;
            txtSIIn_Dt.Enabled = false;
            dataGridView1.Visible = false;
            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            //SqlConnection con4 = new SqlConnection(strcon);
            //SqlCommand cmd = new SqlCommand("select a.SIIn_ID,a.PO_No,a.SIIn_From as RecdFrom,b.Grp_Name as Groups,a.Invoice_No,a.Credit_Period,a.Grand_Amt,a.SIIn_Dt,a.PO_Dt,a.Invoice_Dt,a.SIIn_FromAddr,a.SIIn_Place,a.Credit_Period,a.Total_Amt,a.Disc_Amt,a.Net_Amt,a.Excise_Amt,a.Cess_Amt,a.HSCess_Amt,a.CSTVAT_Amt,a.Insu_Amt,a.Other_Amt from Purchase_ItemIn as a,Group_Master as b where SIIn_ID='"+txtSIIn_ID.Text+"' a.Grp_ID=b.Grp_ID", con4);
            //con4.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
                txtSIIn_ID.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPO_No.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSIIn_From.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
              //  ddlGrp_ID.Text=dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtInvoice_No.Text=dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCredit_Period.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtGrand_Amt.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                
                txtSIIn_Dt.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtPO_Dt.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtInvoice_Dt.Text = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtSIIn_FromAddr.Text = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtSIIn_Place.Text = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtCredit_Period.Text = dataGridView2.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtTotal_Amt.Text = dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString();
                txtDisc_Amt.Text = dataGridView2.Rows[e.RowIndex].Cells[14].Value.ToString();
                txtNet_Amt.Text = dataGridView2.Rows[e.RowIndex].Cells[15].Value.ToString();
                txtExcise_Amt.Text = dataGridView2.Rows[e.RowIndex].Cells[16].Value.ToString();
                txtCess_Amt.Text = dataGridView2.Rows[e.RowIndex].Cells[17].Value.ToString();
                txtHSCess_Amt.Text = dataGridView2.Rows[e.RowIndex].Cells[18].Value.ToString();
                txtCSTVAT_Amt.Text = dataGridView2.Rows[e.RowIndex].Cells[19].Value.ToString();
                txtInsu_Amt.Text = dataGridView2.Rows[e.RowIndex].Cells[20].Value.ToString();
                txtOther_Amt.Text = dataGridView2.Rows[e.RowIndex].Cells[21].Value.ToString();
                ddlSalesTaxType.Text = dataGridView2.Rows[e.RowIndex].Cells[22].Value.ToString();
                txtFreight.Text = dataGridView2.Rows[e.RowIndex].Cells[23].Value.ToString();
               
            //}


        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string strExciseAmt = txtExcise_Amt.Text.Replace("%", "");
                //Update data in table
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                //SqlCommand cmd = new SqlCommand("update TopPaper_Master set Grp_ID ='" + Group_ID + "',TP_PPLgth='" + txtTP_PPLgth.Text + "',TP_PPWdth ='" + txtTP_PPWdth.Text + "',TP_PPBf ='" + txtTP_PPBf.Text + "',TP_PPGram='" + txtTP_PPGram.Text + "',TP_PPRate ='" + txtTP_PPRate.Text + "',TP_PPCost='" + txtTP_PPCost.Text + "',TP_LmLgth='" + txtTP_LmLgth.Text + "',TP_LmWdth='" + txtTP_LmWdth.Text + "',TP_LmRate='" + txtTP_LmRate.Text + "',TP_LmCost='" + txtTP_LmCost.Text + "',TP_PnColor='" + txtTP_PnColor.Text + "',TP_PnRate='" + txtTP_PnRate.Text + "',TP_PnCost='" + txtTP_PnCost.Text + "',TP_PlNo='" + txtTP_PlNo.Text + "',TP_PlRate='" + txtTP_PlRate.Text + "',TP_PlCost='" + txtTP_PlCost.Text + "',TP_PlWsCnt='" + txtTP_PlWsCnt.Text + "',TP_PlWsAmt='" + txtTP_PlWsAmt + "',Ptve_ID='" + ddlPtve_ID.SelectedItem.ToString() + "',TP_Rate='" + txtTP_Rate.Text + "',TP_OS='" + txtTP_OS.Text + "',TP_CS='" + txtTP_CS.Text + "',TP_ReLev='" + txtTP_ReLev.Text + "',TP_Active='"+ddlTP_Active.Text+"' where TP_ID='" + txtTP_ID.Text + "'", con);
                //SqlCommand cmd = new SqlCommand("update TopPaper_Master set P_ID='" + ddlP_ID.Text + "',PQ_ID='" + ddlPQ_ID.SelectedValue.ToString() + "', TP_PPLgth='" + txtTP_PPLgth.Text + "',TP_PPWdth ='" + txtTP_PPWdth.Text + "',TP_PPBf ='" + txtTP_PPBf.Text + "',TP_PPGram='" + txtTP_PPGram.Text + "',TP_PPRate ='" + txtTP_PPRate.Text + "',TP_PPCost='" + txtTP_PPCost.Text + "',TP_LmLgth='" + txtTP_LmLgth.Text + "',TP_LmWdth='" + txtTP_LmWdth.Text + "',TP_LmRate='" + txtTP_LmRate.Text + "',TP_LmCost='" + txtTP_LmCost.Text + "',TP_LmType='" + ddlTP_LmType.SelectedValue.ToString() + "',TP_VrLgth='" + txtTP_VrLgth.Text + "',TP_VrWdth='" + txtTP_VrWdth.Text + "',TP_VrRate='" + txtTP_VrRate.Text + "',TP_VrCost='" + txtTP_VrCost.Text + "',TP_VrType='" + ddlTP_VrType.SelectedValue.ToString() + "',TP_PnColor='" + txtTP_PnColor.Text + "',TP_PnRate='" + txtTP_PnRate.Text + "',TP_PnCost='" + txtTP_PnCost.Text + "',TP_PlDivFact='"+ddlTP_PlDivFact.SelectedValue.ToString()+"', TP_PlNo='" + txtTP_PlNo.Text + "',TP_PlRate='" + txtTP_PlRate.Text + "',TP_PlCost='" + txtTP_PlCost.Text + "',TP_PlWsCnt='" + txtTP_PlWsCnt.Text + "',TP_PlWsAmt='" + txtTP_PlWsAmt + "',Ptve_ID='" + ddlPtve_ID.SelectedItem.ToString() + "',TP_Rate='" + txtTP_Rate.Text + "',TP_OS='" + txtTP_OS.Text + "',TP_CS='" + txtTP_CS.Text + "',TP_ReLev='" + txtTP_ReLev.Text + "',TP_Active='" + ddlTP_Active.Text + "' where TP_ID='" + txtTP_ID.Text + "'", con);


                SqlCommand cmd = new SqlCommand("update Purchase_ItemIn set PO_Dt =convert(datetime,'" + txtPO_Dt.Text + "',103), Invoice_No='" + txtInvoice_No.Text + "', Invoice_Dt=convert(datetime,'" + txtInvoice_Dt.Text + "',103),SIIn_From ='" + txtSIIn_From.Text + "',SIIn_FromAddr ='" + txtSIIn_FromAddr.Text + "',SIIn_Place='" + txtSIIn_Place.Text + "',Credit_Period ='" + txtCredit_Period.Text + "',Total_Amt='" + txtTotal_Amt.Text + "',Disc_Amt='" + txtDisc_Amt.Text + "',Net_Amt='" + txtNet_Amt.Text + "',Excise_Amt='" + strExciseAmt+ "',Cess_Amt='" + txtCess_Amt.Text + "',HSCess_Amt='" + txtHSCess_Amt.Text + "',CSTVAT_Amt='" + txtCSTVAT_Amt.Text + "',Insu_Amt='" + txtInsu_Amt.Text + "',Other_Amt='" + txtOther_Amt.Text + "',Grand_Amt='" + txtGrand_Amt.Text + "',SalesTax_Type='" + ddlSalesTaxType.Text + "',Freight_Amt='" + txtFreight.Text.Trim().Replace("'", "''").ToString() + "',Mod_By='" + strSession + "',Mod_ByNode='',Mod_On = convert(datetime,getdate(),103) where SIIn_ID='" + txtSIIn_ID.Text + "'", con);


                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                fillGrid();
                //cmdSubmit.Enabled = true; ;
                //cmdEdit.Enabled = false;
                clearall();
            }

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from Purchase_ItemIn where PO_No like '%" + txtSearchPO.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.MaxDate = System.DateTime.Now;
        }

        private void calenderPoDt_DateChanged(object sender, DateRangeEventArgs e)
        {
            calenderPoDt.MaxDate = System.DateTime.Now;
        }

        private void challenDt_DateChanged(object sender, DateRangeEventArgs e)
        {
            challenDt.MaxDate = System.DateTime.Now;
        }

        private void txtExcise_Amt_Leave(object sender, EventArgs e)
        {
            if (txtExcise_Amt.Text.Contains("%"))
            {
            }
            else
            {

                txtExcise_Amt.Text = txtExcise_Amt.Text + "%";
            }
            //strExice = strExice1 + strExice;

            //txtGrand_Amt.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtNet_Amt.Text), 2) + Math.Round(Convert.ToDecimal(txtExcise_Amt.Text), 2));  
             //txtExcise_Amt.Text = strExice.ToString();
            //double strCess = Convert.ToDouble(txtCess_Amt.Text);
            //double strHScess = Convert.ToDouble(txtHSCess_Amt.Text);
            //double strcst = Convert.ToDouble(txtCSTVAT_Amt.Text);
            //double strExice = Convert.ToDouble(txtExcise_Amt.Text);
            //double strOther = Convert.ToDouble(txtOther_Amt.Text);
            //double strInsu = Convert.ToDouble(txtInsu_Amt.Text);

            //GrandAmt = (NetAmount + strExice1 + strCess + strHScess + strcst + strInsu + strOther);
            //txtGrand_Amt.Text = GrandAmt.ToString();


        }

        private void txtInsu_Amt_Leave(object sender, EventArgs e)
        {
            
            
             //txtInsu_Amt.Text = strInsu.ToString();
            //double strCess = Convert.ToDouble(txtCess_Amt.Text);
            //double strHScess = Convert.ToDouble(txtHSCess_Amt.Text);
            //double strcst = Convert.ToDouble(txtCSTVAT_Amt.Text);
            //double strExice = Convert.ToDouble(txtExcise_Amt.Text);
            //double strOther = Convert.ToDouble(txtOther_Amt.Text);
            //double strInsu = Convert.ToDouble(txtInsu_Amt.Text);

            //GrandAmt = (NetAmount + strExice + strCess + strHScess + strcst + strInsu + strOther);
            //txtGrand_Amt.Text = GrandAmt.ToString();


        }

      

       

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtOther_Amt_Leave(object sender, EventArgs e)
        {


            double amtAfeTax = Convert.ToDouble(txtAmtAfterTax.Text);
            
            double strFreight = Convert.ToDouble(txtFreight.Text);
          
            strInsu = Convert.ToDouble(txtInsu_Amt.Text);
            strOther = Convert.ToDouble(txtOther_Amt.Text);


            txtGrand_Amt.Text = Convert.ToString(Math.Round(Convert.ToDecimal(amtAfeTax), 2) + Math.Round(Convert.ToDecimal(strFreight), 2) + Math.Round(Convert.ToDecimal(strInsu), 2) + Math.Round(Convert.ToDecimal(strOther), 2));


            // double strCess = Convert.ToDouble(txtCess_Amt.Text);
            // double strHScess = Convert.ToDouble(txtHSCess_Amt.Text);
            // double strcst = Convert.ToDouble(txtCSTVAT_Amt.Text);
            //double strExice = Convert.ToDouble(txtExcise_Amt.Text);
            // double strOther = Convert.ToDouble(txtOther_Amt.Text);
            // double strInsu = Convert.ToDouble(txtInsu_Amt.Text);

            // GrandAmt = (NetAmount + strExice + strCess + strHScess + strcst + strInsu + strOther);
            // txtGrand_Amt.Text = GrandAmt.ToString();


        }
        private void txtDisc_Amt_Leave(object sender, EventArgs e)
        {
            //txtNet_Amt.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtTotal_Amt.Text), 2) - Math.Round(Convert.ToDecimal(txtDisc_Amt.Text), 2));
            //NetAmount = Convert.ToDouble(txtNet_Amt.Text);
            double TotalAmt = Convert.ToDouble(txtTotal_Amt.Text);
            double Discount = Convert.ToDouble(txtDisc_Amt.Text);
            NetAmount = (TotalAmt - Discount);
            txtNet_Amt.Text = NetAmount.ToString();

        }
        private void txtHSCess_Amt_Leave(object sender, EventArgs e)
        {
            string strExciseAmt = txtExcise_Amt.Text.Replace("%", "");

          
            strHScess = Convert.ToDouble(txtHSCess_Amt.Text);
            strCess = Convert.ToDouble(txtCess_Amt.Text);
            strExice1 = Convert.ToDouble(strExciseAmt);
           
            double netAmt = Convert.ToDouble(txtNet_Amt.Text);
            double percentofexice = strExice1 / 100;
            double excicevalue = netAmt * percentofexice;

            amtbeforetax.Text =Convert.ToString(Math.Round(Convert.ToDecimal(txtNet_Amt.Text), 2) + Math.Round(Convert.ToDecimal(excicevalue), 2) + Math.Round(Convert.ToDecimal(strCess), 2) + Math.Round(Convert.ToDecimal(strHScess), 2));

        }

        private void txtCSTVAT_Amt_Leave(object sender, EventArgs e)
        {
            double amtbeforeax = Convert.ToDouble(amtbeforetax.Text);
            strcst = Convert.ToDouble(txtCSTVAT_Amt.Text);

            txtAmtAfterTax.Text = Convert.ToString(Math.Round(Convert.ToDecimal(amtbeforeax), 2) + Math.Round(Convert.ToDecimal(strcst), 2));
            
        }

      

       

       

       

        

       


        //private void AddDataGridColumn()
        //{
        //    DataSet dataset = new DataSet();
        //    // Put some actions to populate the dataset
        //    // Set column style
        //    DataGridTableStyle TblStyle = new DataGridTableStyle();
        //    // Set datagrid ComboBox ColumnStyle for PubID field
        //    DataTable tblCompanies = dataset.Tables["Companies"];
        //    TblStyle.GridColumnStyles.Add(new DataGridcom(ref tblCompanies, 1, 0, true, false, true, DataGridComboBoxColumn.DisplayModes.ShowDisplayMember, 0));
        //    TblStyle.GridColumnStyles[0].MappingName = "PubID";
        //    TblStyle.GridColumnStyles[0].HeaderText = "Company ID";
        //    TblStyle.GridColumnStyles[0].Width = 150;
        //    TblStyle.GridColumnStyles[0].NullText = string.Empty;
        //    // Add TableStyle
        //    DataGrid1.TableStyles.Add(TblStyle);
        //}

        
        
    }
}
