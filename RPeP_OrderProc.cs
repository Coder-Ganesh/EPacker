using ePacker1.App_Code;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ePacker1
{
    public partial class RPeP_OrderProc : Form
    {
        string session, strSQL, Group_ID, Order_ID, SubOrder, SubItem_Of;
        string EF_NF_PC, Sell_Rate, Box_PerSheet, IDChar, strOrder_ID, Style_ID, TP_ID;
        string strOpenDoc, Grp_Name, rptImagepath, rptImagelogo, P_Name, TP_Name, grTP_ID, grTP_Name;
        public static string I_ID;
        string grP_ID, grI_ID;
        private FunctionLib funclib;
        Byte[] bytImage = null;
        Byte[] bytImagelogo = null;

        public RPeP_OrderProc()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_OrderProc_Load(object sender, EventArgs e)
        {
            try
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
                GetAllOrderDataForGrid();

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("SELECT a.P_ID as P_ID, a.P_Name +' ( '+ b.PM_Name +')'  as PName from Party_Master a, PartyMain_Master b where a.Grp_ID = '" + Group_ID + "' and a.PM_ID = b.PM_ID and a.P_Active='Yes' Order by PName", con);
                con.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    GlobalFunctions.AddPleaseSelect(ref dt);
                    ddlP_ID.DataSource = dt;
                    ddlP_ID.DisplayMember = dt.Columns[1].ToString();
                    ddlP_ID.ValueMember = dt.Columns[0].ToString();
                }
                con.Close();

                SubOrder = "No";
                EF_NF_PC = "";

                ddlSearch.Items.Add("");
                ddlSearch.Items.Add("Order ID");
                ddlSearch.Items.Add("Order Dt.");
                ddlSearch.Items.Add("Party");
                ddlSearch.Items.Add("Party PO No.");
                ddlSearch.Items.Add("Party PO Dt.");
                ddlSearch.Items.Add("Item");
                ddlSearch.Items.Add("Box Qty.");
                ddlSearch.Items.Add("Selling Rate");
                ddlSearch.Items.Add("Sub Order Of");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error RPeP_OrderProc_Load" + ex.Message);
            }          
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetAllOrderDataForGrid()
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select a.Order_ID as 'Order ID',convert (varchar(20),a.Order_Dt,103)  as 'Order Dt.',b.P_Name as 'Party',a.P_PONo  as 'Party PO No.',convert (varchar(20),a.P_PODt,103)  as 'Party PO Dt.',c.I_Name as 'Item',a.Box_Qty  as 'Box Qty.',a.Sell_Rate  as 'Selling Rate',a.SubItem_Of  as 'Sub Order Of',a.P_ID,a.I_ID,a.Box_PerSheet,a.Sheet_Qty,a.Print_Inst,a.Order_Active,a.Add_By,a.Add_On,a.Mod_By,a.Mod_On from Item_Order as a,Party_Master as b,Item_Master as c where a.P_ID=b.P_ID and a.I_ID=c.I_ID order by a.Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                this.GridView1.Columns[9].Visible = false;
                this.GridView1.Columns[10].Visible = false;
                //this.GridView1.Columns[11].Visible = false;
                //this.GridView1.Columns[12].Visible = false;
                //this.GridView1.Columns[13].Visible = false;
                //this.GridView1.Columns[14].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error GetAllOrderDataForGrid " + ex.Message);
            }        
        }

        private void cmdItemSearch_Click(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                SqlDataAdapter da = new SqlDataAdapter("SELECT '' as I_ID, '' as I_Name UNION select  I_ID,I_Name from Item_Master as a where a.Grp_ID = '" + Group_ID + "' and a.P_ID = '" + ddlP_ID.SelectedValue.ToString() + "' and a.I_Active='Yes' and a.I_Name like '%" + txtItemSearch.Text.Trim().ToString() + "%' and a.EF_NF_PC like '%" + EF_NF_PC + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Open();
                ddlI_ID.DataSource = dt;
                ddlI_ID.DisplayMember = dt.Columns[1].ToString();
                ddlI_ID.ValueMember = dt.Columns[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at Item Search " + ex.Message);
            }
        }

        private void cmdTopPapertSearch_Click(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                SqlDataAdapter da = new SqlDataAdapter("SELECT '' as TP_ID, '' as TP_Name UNION select  TP_ID,TP_Name from TopPaper_Master as a where a.Grp_ID = '" + Group_ID + "' and a.P_ID = '" + ddlP_ID.SelectedValue.ToString() + "' and a.TP_Active='Yes' and a.TP_Name like '%" + txtTopPaperSearch.Text.Trim().ToString() + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Open();
                ddlTP_ID.DataSource = dt;
                ddlTP_ID.DisplayMember = dt.Columns[1].ToString();
                ddlTP_ID.ValueMember = dt.Columns[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at Top Paper Search " + ex.Message);
            }
        }

        private void txtOrder_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void txtP_PODt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtOrder_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtOrder_Dt.Focus();
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtP_PODt.Text = monthCalendar2.SelectionStart.ToShortDateString();
            monthCalendar2.Visible = false;
            txtP_PODt.Focus();
        }

        private void txtSell_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtBox_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtBox_PerSheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtSheet_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void ddlP_ID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                SqlDataAdapter da = new SqlDataAdapter("SELECT I_ID,I_Name from Item_Master as a where a.Grp_ID = '" + Group_ID + "' and a.P_ID = '" + ddlP_ID.SelectedValue.ToString() + "' and a.I_Active='Yes' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {

                    GlobalFunctions.AddPleaseSelect(ref dt);
                    ddlI_ID.DataSource = dt;
                    ddlI_ID.DisplayMember = dt.Columns[1].ToString();
                    ddlI_ID.ValueMember = dt.Columns[0].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at Party Change " + ex.Message);
            }
        }

        private void ddlI_ID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Sell_Rate = "";
                Box_PerSheet = "";

                if (ddlI_ID.SelectedValue != null)
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con1 = new SqlConnection(strcon);
                    SqlConnection con = new SqlConnection(strcon);
                    SqlCommand cmd3 = new SqlCommand("select EF_NF_PC,Sell_Rate,Box_PerSheet,TP_ID from Item_Master where I_ID='" + ddlI_ID.SelectedValue.ToString() + "'", con1);
                    con1.Open();
                    SqlDataReader dr1 = cmd3.ExecuteReader();
                    if (dr1.Read())
                    {
                        EF_NF_PC = Convert.ToString(dr1["EF_NF_PC"]);
                        Sell_Rate = Convert.ToString(dr1["Sell_Rate"]);
                        Box_PerSheet = Convert.ToString(dr1["Box_PerSheet"]);
                        TP_ID = Convert.ToString(dr1["TP_ID"]);
                    }
                    dr1.Close();
                    con1.Close();

                    if (!string.IsNullOrEmpty(TP_ID))
                    {
                        SqlConnection conTPP = new SqlConnection(strcon);
                        SqlDataAdapter da = new SqlDataAdapter("select TopPaperID,TopPaperName from Tbl_TopPaperMaster where TopPaperID = '" + TP_ID + "' and TopPaper_Active = 'Yes' ", conTPP);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        con.Open();
                        if (dt != null)
                        {
                            GlobalFunctions.AddPleaseSelect(ref dt);
                            ddlTP_ID.DataSource = dt;
                            ddlTP_ID.DisplayMember = dt.Columns[1].ToString();
                            ddlTP_ID.ValueMember = dt.Columns[0].ToString();
                        }
                        con.Close();
                    }

                    if (EF_NF_PC != "" && SubOrder == "No")
                    {
                        string IDFirstChar = EF_NF_PC.Substring(0, 1);
                        IDChar = IDFirstChar;
                        Order_ID = funclib.I_ID(IDChar, con, "select Order_ID  from Item_Order order by Order_ID desc");
                        txtOrder_ID.Text = Order_ID;
                    }

                    if (EF_NF_PC != "" && SubOrder == "Yes")
                    {
                        if (txtOrder_ID.Text.Length == 11)
                        {
                            SqlCommand cmd = new SqlCommand("select Order_ID  from Item_Order where Order_ID like'%" + Order_ID + "%' order by Order_ID desc ", con1);
                            con1.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                strOrder_ID = Convert.ToString(dr["Order_ID"]);
                            }
                            dr.Close();
                            con1.Close();

                            if (strOrder_ID.Length == 11)
                            {
                                string newOrderID = funclib.NextLetter(strOrder_ID);
                                txtOrder_ID.Text = newOrderID;
                            }
                            else
                            {
                                txtOrder_ID.Text = Order_ID + "A";
                            }
                        }
                        else
                        {
                            txtOrder_ID.Text = Order_ID + "A";
                        }
                    }

                    if (Sell_Rate != "")
                    {
                        txtSell_Rate.Text = Sell_Rate;
                    }

                    if (Box_PerSheet != "")
                    {
                        txtBox_PerSheet.Text = Box_PerSheet;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at Item Change " + ex.Message);
            }
        }      

        private void txtBox_PerSheet_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBox_Qty.Text == "")
                {
                    txtBox_Qty.Text = "0";
                }
                if (txtBox_PerSheet.Text == "")
                {
                    txtBox_PerSheet.Text = "0";
                }
                double box_Quantity = Convert.ToDouble(txtBox_Qty.Text);
                double box_PerSheet = Convert.ToDouble(txtBox_PerSheet.Text);
                double Sheet_Qty = box_Quantity / box_PerSheet;
                txtSheet_Qty.Text = Convert.ToString((Math.Round(Sheet_Qty)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at txtBox_PerSheet_Leave Change " + ex.Message);
            }
        }

        private void txtSell_Rate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBox_Qty.Text == "")
                {
                    txtBox_Qty.Text = "0";
                }

                if (txtBox_PerSheet.Text == "")
                {
                    txtBox_PerSheet.Text = "0";
                }
                double box_Quantity = Convert.ToDouble(txtBox_Qty.Text);
                double box_PerSheet = Convert.ToDouble(txtBox_PerSheet.Text);
                double Sheet_Qty = box_Quantity / box_PerSheet;
                txtSheet_Qty.Text = Convert.ToString((Math.Round(Sheet_Qty)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at txtSell_Rate_Leave Change " + ex.Message);
            }
        }

        private void txtBox_Qty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBox_Qty.Text == "")
                {
                    txtBox_Qty.Text = "0";
                }
                if (txtBox_PerSheet.Text == "")
                {
                    txtBox_PerSheet.Text = "0";
                }
                double box_Quantity = Convert.ToDouble(txtBox_Qty.Text);
                double box_PerSheet = Convert.ToDouble(txtBox_PerSheet.Text);
                double Sheet_Qty = box_Quantity / box_PerSheet;
                txtSheet_Qty.Text = Convert.ToString((Math.Round(Sheet_Qty)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at txtBox_Qty_Leave Change " + ex.Message);
            }
        }

        private void txtBox_Qty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBox_Qty.Text == "")
                {
                    txtBox_Qty.Text = "0";
                }

                if (txtBox_PerSheet.Text == "")
                {
                    txtBox_PerSheet.Text = "0";
                }
                double box_Quantity = Convert.ToDouble(txtBox_Qty.Text);
                double box_PerSheet = Convert.ToDouble(txtBox_PerSheet.Text);

                double Sheet_Qty = box_Quantity / box_PerSheet;

                txtSheet_Qty.Text = Convert.ToString((Math.Round(Sheet_Qty)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at txtBox_Qty_TextChanged Change " + ex.Message);
            }
        }

        private void txtBox_PerSheet_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBox_Qty.Text == "")
                {
                    txtBox_Qty.Text = "0";
                }

                if (txtBox_PerSheet.Text == "")
                {
                    txtBox_PerSheet.Text = "0";
                }
                double box_Quantity = Convert.ToDouble(txtBox_Qty.Text);
                double box_PerSheet = Convert.ToDouble(txtBox_PerSheet.Text);
                double Sheet_Qty = box_Quantity / box_PerSheet;
                txtSheet_Qty.Text = Convert.ToString((Math.Round(Sheet_Qty)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at txtBox_PerSheet_TextChanged Change " + ex.Message);
            }
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOrder_ID.Text == "")
                {
                    MessageBox.Show("Order ID Cannot be Blank");
                    txtOrder_ID.Focus();
                }
                else if (txtOrder_Dt.Text == "")
                {
                    MessageBox.Show("OrderDate Cannot Be Blank");
                    txtOrder_Dt.Focus();
                }
                else if (ddlP_ID.SelectedIndex == 0)
                {
                    MessageBox.Show("Party Name Cannot Be Blank");
                    ddlP_ID.Focus();
                }
                else if (txtP_PONo.Text == "")
                {
                    MessageBox.Show("Party PO Number Cannot Be Blank");
                    txtP_PONo.Focus();
                }
                else if (txtP_PODt.Text == "")
                {
                    MessageBox.Show("Party PO Date Cannot Be Blank");
                    txtP_PODt.Focus();
                }
                else if (ddlI_ID.SelectedIndex == 0)
                {
                    MessageBox.Show("Item Name Cannot Be Blank");
                    ddlI_ID.Focus();
                }
                else if (txtSell_Rate.Text == "")
                {
                    MessageBox.Show("Selling Rate Cannot Be Blank");
                    txtSell_Rate.Focus();
                }
                else if (txtBox_Qty.Text == "")
                {
                    MessageBox.Show("Box Qty Cannot Be Blank");
                    txtBox_Qty.Focus();
                }
                else if (txtBox_PerSheet.Text == "")
                {
                    MessageBox.Show("Bos Per Sheet Cannot Be Blank");
                    txtBox_PerSheet.Focus();
                }
                else if (txtSheet_Qty.Text == "")
                {
                    MessageBox.Show("Sheet Qty Cannot Be Blank");
                    txtSheet_Qty.Focus();
                }
                //else if (ddlTP_ID.Items.Count > 1)
                //{
                //    if (ddlTP_ID.SelectedIndex == 0)
                //    {
                //        MessageBox.Show("Top Paper Cannot Be Blank");
                //        ddlTP_ID.Focus();
                //    }
                //    else
                //    { }
                //}
                else if (txtPrint_Inst.Text == "")
                {
                    MessageBox.Show("Printing Instruction Cannot Be Blank");
                    txtPrint_Inst.Focus();
                }
                else if (ddlActive.Text == "")
                {
                    MessageBox.Show("Field Cannot Be Blank");
                    ddlActive.Focus();
                }
                else
                {
                    funclib = new FunctionLib();
                    //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    //Inserting records 
                    if (txtOrder_ID.Text.Length == 10)
                    {
                        SubItem_Of = "";
                    }
                    else
                    {
                        SubItem_Of = Order_ID;
                    }

                    try
                    {
                        SqlCommand cmdPositive = new SqlCommand("insert into Item_Order(Order_ID,Grp_ID,Order_Dt,P_ID,P_PONo,P_PODt,I_ID,Sell_Rate,Box_Qty,Box_PerSheet,Sheet_Qty,TP_ID,SubItem_Of,Print_Inst,Order_Active,Add_By,Add_ByNode,Add_On) values('" + txtOrder_ID.Text.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "',convert(datetime,'" + txtOrder_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlP_ID.SelectedValue.ToString() + "','" + txtP_PONo.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txtP_PODt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlI_ID.SelectedValue.ToString() + "','" + txtSell_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + txtBox_Qty.Text.Trim().Replace("'", "''").ToString() + "','" + txtBox_PerSheet.Text.Trim().Replace("'", "''").ToString() + "','" + txtSheet_Qty.Text.Trim().Replace("'", "''").ToString() + "','" + ddlTP_ID.SelectedValue.ToString() + "','" + SubItem_Of + "','" + txtPrint_Inst.Text.Trim().Replace("'", "''").ToString() + "','" + ddlActive.Text + "','" + session + "','',convert(datetime,getdate(),103))", con);
                        con.Open();
                        int Positive = cmdPositive.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        con.Close();
                        pdfGenerate();
                        if (strOpenDoc != "" & strOpenDoc != null)
                        {
                            Process.Start(strOpenDoc);
                        }
                        strOpenDoc = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The was some error at Saving Item_Order " + ex.Message);
                    }


                    if (MessageBox.Show("Do you wish to add Sub-Order ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SubOrder = "Yes";

                        //if (txtOrder_ID.Text.Length == 11)
                        //{
                        //    string newOrderID = funclib.NextLetter(txtOrder_ID.Text);
                        //    txtOrder_ID.Text = newOrderID;
                        //}
                        //else
                        //{
                        //    txtOrder_ID.Text = Order_ID + "A";
                        //}

                        try
                        {
                            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as I_ID, '' as I_Name UNION select  I_ID,I_Name from Item_Master as a where a.Grp_ID = '" + Group_ID + "' and a.P_ID = '" + ddlP_ID.SelectedValue.ToString() + "' and a.I_Active='Yes' and a.I_Name like '%" + txtItemSearch.Text.Trim().ToString() + "%' and a.EF_NF_PC like '%" + EF_NF_PC + "%'", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            con.Open();
                            ddlI_ID.DataSource = dt;
                            ddlI_ID.DisplayMember = dt.Columns[1].ToString();
                            ddlI_ID.ValueMember = dt.Columns[0].ToString();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("The was some error at Saving Sub-Order " + ex.Message);
                        }
                    }
                    else
                    {
                        SubOrder = "No";
                        ClearAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at Saving " + ex.Message);
            }
        }

        protected void ClearAll()
        {
            txtBox_PerSheet.Text = "";
            txtBox_Qty.Text = "";
            txtItemSearch.Text = "";
            txtOrder_Dt.Text = "";
            txtOrder_ID.Text = "";
            txtP_PODt.Text = "";
            txtP_PONo.Text = "";
            txt_Search.Text = "";
            txtPrint_Inst.Text = "";
            txtSell_Rate.Text = "";
            txtSheet_Qty.Text = "";
            txtTopPaperSearch.Text = "";
            ddlActive.Text = "Yes";
            ddlI_ID.Text = "";
            ddlP_ID.Text = "";
            ddlTP_ID.Text = "";
            cmdPrint.Visible = false;
            ddlActive.Enabled = false;
            ddlP_ID.Enabled = true;
            txtBox_PerSheet.Enabled = true;
            txtBox_Qty.Enabled = true;
            txtItemSearch.Enabled = true;
            txtOrder_Dt.Enabled = true;
            txtP_PODt.Enabled = true;
            txtP_PONo.Enabled = true;
            txtPrint_Inst.Enabled = true;
            txtSell_Rate.Enabled = true;
            txtSheet_Qty.Enabled = true;
            txtTopPaperSearch.Enabled = true;
            ddlI_ID.Enabled = true;
            ddlP_ID.Enabled = true;
            ddlTP_ID.Enabled = true;
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;
        }

        private void CmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSearch.Text == "Order ID")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("Select a.Order_ID as 'Order ID',convert (varchar(20),a.Order_Dt,103)  as 'Order Dt.',b.P_Name as 'Party',a.P_PONo  as 'Party PO No.',convert (varchar(20),a.P_PODt,103)  as 'Party PO Dt.',c.I_Name as 'Item',a.Box_Qty  as 'Box Qty.',a.Sell_Rate  as 'Selling Rate',a.SubItem_Of  as 'Sub Order Of',a.P_ID,a.I_ID,a.Box_PerSheet,a.Sheet_Qty,a.Print_Inst,a.Order_Active   from Item_Order as a,Party_Master as b,Item_Master as c where a.P_ID=b.P_ID and a.I_ID=c.I_ID and a.Order_ID like '%" + txt_Search.Text.ToString() + "%'  order by a.Order_ID", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;                    
                }
                else if (ddlSearch.Text == "Order Dt.")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("Select a.Order_ID as 'Order ID',convert (varchar(20),a.Order_Dt,103)  as 'Order Dt.',b.P_Name as 'Party',a.P_PONo  as 'Party PO No.',convert (varchar(20),a.P_PODt,103)  as 'Party PO Dt.',c.I_Name as 'Item',a.Box_Qty  as 'Box Qty.',a.Sell_Rate  as 'Selling Rate',a.SubItem_Of  as 'Sub Order Of',a.P_ID,a.I_ID,a.Box_PerSheet,a.Sheet_Qty,a.Print_Inst,a.Order_Active   from Item_Order as a,Party_Master as b,Item_Master as c where a.P_ID=b.P_ID and a.I_ID=c.I_ID and a.Order_Dt = Convert(datetime,'" + txt_Search.Text + "',103)  order by a.Order_ID", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;

                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;                    
                }
                else if (ddlSearch.Text == "Party")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("Select a.Order_ID as 'Order ID',convert (varchar(20),a.Order_Dt,103)  as 'Order Dt.',b.P_Name as 'Party',a.P_PONo  as 'Party PO No.',convert (varchar(20),a.P_PODt,103)  as 'Party PO Dt.',c.I_Name as 'Item',a.Box_Qty  as 'Box Qty.',a.Sell_Rate  as 'Selling Rate',a.SubItem_Of  as 'Sub Order Of',a.P_ID,a.I_ID,a.Box_PerSheet,a.Sheet_Qty,a.Print_Inst,a.Order_Active   from Item_Order as a,Party_Master as b,Item_Master as c where a.P_ID=b.P_ID and a.I_ID=c.I_ID and b.P_Name like '%" + txt_Search.Text.ToString() + "%'  order by a.Order_ID", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;

                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;                  
                }
                else if (ddlSearch.Text == "Party PO No.")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("Select a.Order_ID as 'Order ID',convert (varchar(20),a.Order_Dt,103)  as 'Order Dt.',b.P_Name as 'Party',a.P_PONo  as 'Party PO No.',convert (varchar(20),a.P_PODt,103)  as 'Party PO Dt.',c.I_Name as 'Item',a.Box_Qty  as 'Box Qty.',a.Sell_Rate  as 'Selling Rate',a.SubItem_Of  as 'Sub Order Of',a.P_ID,a.I_ID,a.Box_PerSheet,a.Sheet_Qty,a.Print_Inst,a.Order_Active   from Item_Order as a,Party_Master as b,Item_Master as c where a.P_ID=b.P_ID and a.I_ID=c.I_ID and a.P_PONo like '%" + txt_Search.Text.ToString() + "%'  order by a.Order_ID", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;

                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;                   
                }
                else if (ddlSearch.Text == "Party PO Dt.")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("Select a.Order_ID as 'Order ID',convert (varchar(20),a.Order_Dt,103)  as 'Order Dt.',b.P_Name as 'Party',a.P_PONo  as 'Party PO No.',convert (varchar(20),a.P_PODt,103)  as 'Party PO Dt.',c.I_Name as 'Item',a.Box_Qty  as 'Box Qty.',a.Sell_Rate  as 'Selling Rate',a.SubItem_Of  as 'Sub Order Of',a.P_ID,a.I_ID,a.Box_PerSheet,a.Sheet_Qty,a.Print_Inst,a.Order_Active   from Item_Order as a,Party_Master as b,Item_Master as c where a.P_ID=b.P_ID and a.I_ID=c.I_ID and a.P_PODt = Convert(datetime,'" + txt_Search.Text + "',103)  order by a.Order_ID", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;

                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;                   
                }
                else if (ddlSearch.Text == "Item")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("Select a.Order_ID as 'Order ID',convert (varchar(20),a.Order_Dt,103)  as 'Order Dt.',b.P_Name as 'Party',a.P_PONo  as 'Party PO No.',convert (varchar(20),a.P_PODt,103)  as 'Party PO Dt.',c.I_Name as 'Item',a.Box_Qty  as 'Box Qty.',a.Sell_Rate  as 'Selling Rate',a.SubItem_Of  as 'Sub Order Of',a.P_ID,a.I_ID,a.Box_PerSheet,a.Sheet_Qty,a.Print_Inst,a.Order_Active   from Item_Order as a,Party_Master as b,Item_Master as c where a.P_ID=b.P_ID and a.I_ID=c.I_ID and c.I_Name like  '%" + txt_Search.Text + "%'  order by a.Order_ID", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;

                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;                   
                }
                else if (ddlSearch.Text == "Box Qty.")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("Select a.Order_ID as 'Order ID',convert (varchar(20),a.Order_Dt,103)  as 'Order Dt.',b.P_Name as 'Party',a.P_PONo  as 'Party PO No.',convert (varchar(20),a.P_PODt,103)  as 'Party PO Dt.',c.I_Name as 'Item',a.Box_Qty  as 'Box Qty.',a.Sell_Rate  as 'Selling Rate',a.SubItem_Of  as 'Sub Order Of',a.P_ID,a.I_ID,a.Box_PerSheet,a.Sheet_Qty,a.Print_Inst,a.Order_Active   from Item_Order as a,Party_Master as b,Item_Master as c where a.P_ID=b.P_ID and a.I_ID=c.I_ID and a.Box_Qty like '%" + txt_Search.Text.ToString() + "%' order by a.Order_ID", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;

                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;              
                }
                else if (ddlSearch.Text == "Selling Rate")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("Select a.Order_ID as 'Order ID',convert (varchar(20),a.Order_Dt,103)  as 'Order Dt.',b.P_Name as 'Party',a.P_PONo  as 'Party PO No.',convert (varchar(20),a.P_PODt,103)  as 'Party PO Dt.',c.I_Name as 'Item',a.Box_Qty  as 'Box Qty.',a.Sell_Rate  as 'Selling Rate',a.SubItem_Of  as 'Sub Order Of',a.P_ID,a.I_ID,a.Box_PerSheet,a.Sheet_Qty,a.Print_Inst,a.Order_Active   from Item_Order as a,Party_Master as b,Item_Master as c where a.P_ID=b.P_ID and a.I_ID=c.I_ID and a.Sell_Rate like '%" + txt_Search.Text.ToString() + "%' order by a.Order_ID", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;

                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;           
                }
                else if (ddlSearch.Text == "Sub Order Of")
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("Select a.Order_ID as 'Order ID',convert (varchar(20),a.Order_Dt,103)  as 'Order Dt.',b.P_Name as 'Party',a.P_PONo  as 'Party PO No.',convert (varchar(20),a.P_PODt,103)  as 'Party PO Dt.',c.I_Name as 'Item',a.Box_Qty  as 'Box Qty.',a.Sell_Rate  as 'Selling Rate',a.SubItem_Of  as 'Sub Order Of',a.P_ID,a.I_ID,a.Box_PerSheet,a.Sheet_Qty,a.Print_Inst,a.Order_Active   from Item_Order as a,Party_Master as b,Item_Master as c where a.P_ID=b.P_ID and a.I_ID=c.I_ID and a.SubItem_Of  like '%" + txt_Search.Text.ToString() + "%' order by a.Order_ID", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;

                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;   
                }
                else
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlDataAdapter da = new SqlDataAdapter("Select a.Order_ID as 'Order ID',convert (varchar(20),a.Order_Dt,103)  as 'Order Dt.',b.P_Name as 'Party',a.P_PONo  as 'Party PO No.',convert (varchar(20),a.P_PODt,103)  as 'Party PO Dt.',c.I_Name as 'Item',a.Box_Qty  as 'Box Qty.',a.Sell_Rate  as 'Selling Rate',a.SubItem_Of  as 'Sub Order Of',a.P_ID,a.I_ID,a.Box_PerSheet,a.Sheet_Qty,a.Print_Inst,a.Order_Active   from Item_Order as a,Party_Master as b,Item_Master as c where a.P_ID=b.P_ID and a.I_ID=c.I_ID  order by a.Order_ID", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;

                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at Search " + ddlSearch.Text + " " + ex.Message);
            }
        }

        private void txt_Search_MouseClick(object sender, MouseEventArgs e)
        {
            if ((ddlSearch.Text == "Order Dt.") || (ddlSearch.Text == "Party PO Dt."))
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

        private void GridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cmdEdit.Enabled = true;
                cmdSubmit.Enabled = false;
                ddlActive.Enabled = true;
                ddlP_ID.Enabled = false;
                txtBox_PerSheet.Enabled = false;
                txtBox_Qty.Enabled = false;
                txtItemSearch.Enabled = false;
                txtOrder_Dt.Enabled = false;
                txtOrder_ID.Enabled = false;
                txtP_PODt.Enabled = false;
                txtP_PONo.Enabled = false;
                txtPrint_Inst.Enabled = false;
                txtSell_Rate.Enabled = false;
                txtSheet_Qty.Enabled = false;
                txtTopPaperSearch.Enabled = false;
                ddlI_ID.Enabled = false;
                ddlP_ID.Enabled = false;
                ddlTP_ID.Enabled = false;
                cmdPrint.Visible = true;

                txtOrder_ID.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtOrder_Dt.Text = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtP_PONo.Text = GridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtP_PODt.Text = GridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtBox_Qty.Text = GridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSell_Rate.Text = GridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                ddlP_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                grP_ID = GridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                ddlI_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                grI_ID = GridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtBox_PerSheet.Text = GridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtSheet_Qty.Text = GridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtPrint_Inst.Text = GridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                ddlActive.Text = GridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at GridView1_RowHeaderMouseClick " + ex.Message);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //Update data in table
                if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Item_Order set Order_Active  ='" + ddlActive.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where Order_ID ='" + txtOrder_ID.Text.Trim().Replace("'", "''").ToString() + "'", con);

                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");

                    ClearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error at Update " + ex.Message);
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            I_ID = ddlI_ID.SelectedValue.ToString();

            RPeP_OrderProc_ItemMasterDetail mmm = new RPeP_OrderProc_ItemMasterDetail();
            mmm.Show();
        }

        //for date selection
        protected void pdfGenerate()
        {
            try
            {
                funclib = new FunctionLib();
                string strCon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strCon);
                SqlConnection con4 = new SqlConnection(strCon);

                //Item Grid1
                string strsql = "select b.Style_No,Ply_Sheet,Length_Inch,Width_Inch,Height_Inch from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + ddlI_ID.SelectedValue.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(strsql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                //Item Grid2
                string strsql2 = "select Length_MM,Width_MM,Height_MM,Dimn_Opt,Length_MM_Conv,Width_MM_Conv,Height_MM_Conv from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + ddlI_ID.SelectedValue.ToString() + "'";
                SqlDataAdapter da2 = new SqlDataAdapter(strsql2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;

                //Item Grid3
                string strsql3 = "select Length_Inch_Sheet,Width_Inch_Sheet,Length_Inch_Sheet1,Width_Inch_Sheet1,EF_NF_PC,Bundle_Packet,Box_PerSheet from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + ddlI_ID.SelectedValue.ToString() + "'";
                SqlDataAdapter da3 = new SqlDataAdapter(strsql3, con);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                dataGridView3.DataSource = dt3;

                //Item Grid4
                string strsql4 = "select Corrugation_Opt,Paper_Cutting,Printing_Opt,No_Colors,PrntColor_Name,Paper_Printed,Scoring_Opt,Punching_Opt,Pasting_Opt from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + ddlI_ID.SelectedValue.ToString() + "'";
                SqlDataAdapter da4 = new SqlDataAdapter(strsql4, con);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                dataGridView4.DataSource = dt4;

                //Item Grid5
                string strsql11 = "select Slotting_Opt,Pinning_Opt,No_Pins,Pinning_InOut,Side_Pasting,Rate_SidePastg,Canvas_Opt,Side_Canvas,CanvColor_Name,Sell_Rate from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + ddlI_ID.SelectedValue.ToString() + "'";
                SqlDataAdapter da5 = new SqlDataAdapter(strsql11, con);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);
                dataGridView5.DataSource = dt5;

                //Item Grid6
                string strsql12 = "select Rate_Type,Excise_Code,Top_BF,Top_GSM,Top_WPP,Top_BFPP,Weight_Pcs,BF_Pcs,ArtWrk_Code,Revi_No from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + ddlI_ID.SelectedValue.ToString() + "'";
                SqlDataAdapter da12 = new SqlDataAdapter(strsql12, con);
                DataTable dt12 = new DataTable();
                da12.Fill(dt12);
                dataGridView6.DataSource = dt12;

                //Item Grid7
                string strsql13 = "select Convert(varchar(20),Art_Dt,103) as 'Art_Dt',Speci_Code,For_Pedilite,Pedilite_BS,Pedilite_GSM,Pedilite_WtBox,Pedilite_PReq,I_Lock from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + ddlI_ID.SelectedValue.ToString() + "'";
                SqlDataAdapter da13 = new SqlDataAdapter(strsql13, con);
                DataTable dt13 = new DataTable();
                da13.Fill(dt13);
                dataGridView7.DataSource = dt13;

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

                string strsql7 = "Select Style_ID,TP_ID  from Item_Master where I_ID='" + ddlI_ID.SelectedValue.ToString() + "' ";
                SqlCommand cmd7 = new SqlCommand(strsql7, con);
                con.Open();
                SqlDataReader dr7 = cmd7.ExecuteReader();
                if (dr7.Read())
                {
                    Style_ID = Convert.ToString(dr7["Style_ID"]);
                    TP_ID = Convert.ToString(dr7["TP_ID"]);
                }
                dr7.Close();
                con.Close();

                string strsql8 = "Select P_Name  from Party_Master where P_ID='" + ddlP_ID.SelectedValue.ToString() + "' ";
                SqlCommand cmd8 = new SqlCommand(strsql8, con);
                con.Open();
                SqlDataReader dr8 = cmd8.ExecuteReader();
                if (dr8.Read())
                {
                    P_Name = Convert.ToString(dr8["P_Name"]);
                }
                dr8.Close();
                con.Close();

                string strsql9 = "Select TP_Name from TopPaper_Master where TP_ID='" + TP_ID + "' ";
                SqlCommand cmd9 = new SqlCommand(strsql9, con);
                con.Open();
                SqlDataReader dr9 = cmd9.ExecuteReader();
                if (dr9.Read())
                {
                    TP_Name = Convert.ToString(dr9["TP_Name"]);
                }
                dr9.Close();
                con.Close();

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Pdf Documents (*.pdf)|*.pdf";
                sfd.FileName = "OrderProcessing.pdf";
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

                        Chunk chunk = new Chunk("Order Processing" + '\n', titleFont);
                        chunk.SetUnderline(0.5f, -1.5f);

                        Paragraph ParaTitle = new Paragraph(chunk);
                        ParaTitle.SpacingBefore = 5f;
                        ParaTitle.SpacingAfter = 5f;

                        var phrase2 = new Phrase();
                        phrase2.Add(new Chunk("Order No.: ", underline));
                        Chunk c2 = new Chunk(txtOrder_ID.Text.Trim().ToString(), underline);
                        c2.SetUnderline(0.5f, -1.5f);
                        phrase2.Add(c2);

                        phrase2.Add(new Chunk("        "));

                        phrase2.Add(new Chunk("Order Dt: ", underline));
                        Chunk c3 = new Chunk(txtOrder_Dt.Text.Trim().ToString() + '\n', underline);
                        c3.SetUnderline(0.5f, -1.5f);
                        phrase2.Add(c3);

                        Paragraph pf1 = new Paragraph(phrase2);

                        var phrase3 = new Phrase();
                        phrase3.Add(new Chunk("Party PO No.:  ", underline));
                        Chunk c4 = new Chunk(txtP_PONo.Text.Trim().ToString(), underline);
                        c4.SetUnderline(0.5f, -1.5f);
                        phrase3.Add(c4);

                        phrase3.Add(new Chunk("       "));

                        phrase3.Add(new Chunk("Party PO Dt: ", underline));
                        Chunk c5 = new Chunk(txtP_PODt.Text.Trim().ToString() + '\n', underline);
                        c5.SetUnderline(0.5f, -1.5f);
                        phrase3.Add(c5);

                        Paragraph pf1_1 = new Paragraph(phrase3);
                        var phrase4 = new Phrase();
                        phrase4.Add(new Chunk("Party    :", underline));
                        Chunk cadd = new Chunk(P_Name + '\n', underline);
                        cadd.SetUnderline(0.5f, -1.5f);
                        phrase4.Add(cadd);

                        Paragraph pf2 = new Paragraph(phrase4);
                        var phrase33 = new Phrase();
                        phrase33.Add(new Chunk("Selling Rate :", underline));
                        Chunk c44 = new Chunk(txtSell_Rate.Text.Trim().ToString(), underline);
                        c44.SetUnderline(0.5f, -1.5f);
                        phrase33.Add(c44);
                        phrase33.Add(new Chunk("         "));
                        phrase33.Add(new Chunk("Box Quantity :", underline));
                        Chunk c55 = new Chunk(txtBox_Qty.Text.Trim().ToString(), underline);
                        c55.SetUnderline(0.5f, -1.5f);
                        phrase33.Add(c55);


                        Paragraph pf3 = new Paragraph(phrase33);
                        var phrase7 = new Phrase();
                        phrase7.Add(new Chunk("Box Per Sheet :", underline));
                        Chunk c7 = new Chunk(txtBox_PerSheet.Text.Trim().ToString(), underline);
                        c7.SetUnderline(0.5f, -1.5f);
                        phrase7.Add(c7);
                        phrase7.Add(new Chunk("      "));
                        phrase7.Add(new Chunk("Sheet Quantity :", underline));
                        Chunk c71 = new Chunk(txtSheet_Qty.Text.Trim().ToString(), underline);
                        c71.SetUnderline(0.5f, -1.5f);
                        phrase7.Add(c71);


                        Paragraph pf4 = new Paragraph(phrase7);
                        // pf4.SpacingBefore = 5f;
                        //    pf4.SpacingAfter = 10f;
                        var phrase8 = new Phrase();
                        phrase8.Add(new Chunk("Top Paper :", underline));
                        Chunk c81 = new Chunk(ddlTP_ID.Text.Trim().ToString(), underline);
                        c81.SetUnderline(0.5f, -1.5f);
                        phrase8.Add(c81);


                        Paragraph pf7 = new Paragraph(phrase8);
                        // pf4.SpacingBefore = 5f;
                        var phraseIns = new Phrase();
                        phraseIns.Add(new Chunk("Printing Instruction :", underline));
                        Chunk cins = new Chunk(txtPrint_Inst.Text.Trim().ToString(), underline);
                        cins.SetUnderline(0.5f, -1.5f);
                        phraseIns.Add(cins);


                        Paragraph pf8 = new Paragraph(phraseIns);
                        pf8.SpacingAfter = 5f;
                        doc.Add(MainTitle);
                        doc.Add(ParaTitle);
                        doc.Add(pf1);
                        doc.Add(pf1_1);
                        doc.Add(pf2);
                        doc.Add(pf3);
                        doc.Add(pf4);

                        if (ddlTP_ID.SelectedValue != "")
                        {
                            doc.Add(pf7);
                        }

                        if (txtPrint_Inst.Text != "")
                        {
                            doc.Add(pf8);
                        }

                        LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                        doc.Add(new Chunk(line));

                        //var phraseItem = new Phrase();
                        //phraseItem.Add(new Chunk("Item  ", underline));
                        //Chunk cItem = new Chunk(ddlI_ID.Text.Trim().ToString(), underlinBold);
                        //cItem.SetUnderline(0.5f, -1.5f);
                        //phraseItem.Add(cItem);
                        //Paragraph pfitem = new Paragraph(phraseItem);
                        //doc.Add(pfitem);

                        #region ITEM GRID 1
                        PdfPTable t1 = new PdfPTable(7);
                        // float[] widthst1 = new float[] { 2f, 1.4f };
                        //  t1.SetWidths(widthst1);
                        t1.DefaultCell.BorderWidth = 0;
                        t1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t1.DefaultCell.BorderColor = BaseColor.WHITE;
                        t1.WidthPercentage = 100;
                        // t1.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        //"Select Convert(varchar(20),Rec_Dt,103) as 'Consultancy Date',b.H_Name as 'Hospital',P_Case as 'Case',P_Note as 'Note',P_Presc as 'Prescription',P_Fee as 'Fee',P_FeeRecd  as 'Fee Received' from Patient_Consultancy as a,Hospital_Master as b where a.H_ID=b.H_ID and Patient_ID='" + PAtient_ID + "' ";
                        PdfPCell cid1 = new PdfPCell(new Phrase("Item", underlinBold));
                        PdfPCell cid = new PdfPCell(new Phrase("Style of Box", underlinBold));
                        PdfPCell cPhoto = new PdfPCell(new Phrase("Style Image", underlinBold));
                        PdfPCell cbal = new PdfPCell(new Phrase("Ply of Sheet", underlinBold));
                        PdfPCell ccell = new PdfPCell(new Phrase("Box Length Inch", underlinBold));
                        PdfPCell cTele = new PdfPCell(new Phrase("Box Width Inch", underlinBold));
                        PdfPCell cTele2 = new PdfPCell(new Phrase("Box Height Inch", underlinBold));

                        cid.BorderColor = BaseColor.WHITE;
                        cid1.BorderColor = BaseColor.WHITE;

                        cbal.BorderColor = BaseColor.WHITE;
                        ccell.BorderColor = BaseColor.WHITE;
                        cTele.BorderColor = BaseColor.WHITE;
                        cTele2.BorderColor = BaseColor.WHITE;
                        cPhoto.BorderColor = BaseColor.WHITE;

                        t1.AddCell(cid1);
                        t1.AddCell(cid);
                        t1.AddCell(cPhoto);
                        t1.AddCell(cbal);
                        t1.AddCell(ccell);
                        t1.AddCell(cTele);
                        t1.AddCell(cTele2);

                        //b.Style_No,Ply_Sheet,Length_Inch,Width_Inch,Height_Inch
                        foreach (DataGridViewRow rows in dataGridView1.Rows)
                        {
                            iTextSharp.text.Image Photo;
                            //if (Convert.ToBoolean(GridView1.Rows[rows.Index].Cells[2].Value))
                            //{Consultancy_ID
                            string Style_No = dataGridView1.Rows[rows.Index].Cells["Style_No"].Value.ToString();
                            string Ply_Sheet = dataGridView1.Rows[rows.Index].Cells["Ply_Sheet"].Value.ToString();

                            string Length_Inch = dataGridView1.Rows[rows.Index].Cells["Length_Inch"].Value.ToString();
                            string Width_Inch = dataGridView1.Rows[rows.Index].Cells["Width_Inch"].Value.ToString();
                            string Height_Inch = dataGridView1.Rows[rows.Index].Cells["Height_Inch"].Value.ToString();

                            PdfPCell c1_1 = new PdfPCell(new Phrase(ddlI_ID.Text, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Style_No, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Ply_Sheet, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Length_Inch, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Width_Inch, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Height_Inch, underlinBold));

                            PdfPCell cPhot = new PdfPCell();
                            funclib = new FunctionLib();
                            string strcon = funclib.setConnection();
                            SqlConnection con3 = new SqlConnection(strcon);
                            con3.Open();
                            //Retrieve BLOB from database into DataSet.

                            SqlCommand cmd = new SqlCommand("select Image_Sheet from Item_Style_Master where Image_Sheet is not null and Style_ID='" + Style_ID + "'", con3);
                            SqlDataReader drimg = cmd.ExecuteReader();
                            if (drimg.Read())
                            {
                                bytImage = (byte[])drimg["Image_Sheet"];

                                MemoryStream ms = new MemoryStream(bytImage);

                                System.Drawing.Bitmap BMP = new System.Drawing.Bitmap(ms);

                                rptImagepath = Path.Combine(Application.StartupPath, Style_ID + ".bmp");
                                BMP.Save(rptImagepath);

                                Photo = iTextSharp.text.Image.GetInstance(rptImagepath);
                                // Photo.ScaleAbsoluteHeight(45);
                                //Photo.ScaleAbsoluteWidth(120);
                                cPhot = new PdfPCell(Photo);
                                cPhot.PaddingTop = 2f;
                                cPhot.HorizontalAlignment = Element.ALIGN_CENTER;
                            }
                            else
                            {
                                cPhot = new PdfPCell(new Phrase("NA", underline));
                                cPhot.HorizontalAlignment = Element.ALIGN_LEFT;
                            }
                            drimg.Close();
                            con3.Close();

                            //doc.Add(logo);
                            cPhot.BorderColor = BaseColor.WHITE;

                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;

                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            cPhot.BorderColor = BaseColor.WHITE;

                            t1.AddCell(c1_1);
                            t1.AddCell(c1);
                            t1.AddCell(cPhot);
                            t1.AddCell(c32);
                            t1.AddCell(c33);
                            t1.AddCell(c34);
                            t1.AddCell(c35);

                            rptImagepath = "";
                            doc.Add(t1);

                            LineSeparator line2 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line2));
                        }
                        #endregion


                        #region ITEM GRID 2
                        //Itemg Grid2
                        PdfPTable t2 = new PdfPTable(7);
                        //float[] widthst1 = new float[] { 1f,1f,1f,1f,1.4f,1f,1f };
                        //t2.SetWidths(widthst1);
                        t2.DefaultCell.BorderWidth = 0;
                        t2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t2.DefaultCell.BorderColor = BaseColor.WHITE;
                        t2.WidthPercentage = 100;
                        //t2.SpacingAfter = 4f;

                        PdfPCell Length_MM = new PdfPCell(new Phrase("Box Length MM", underlinBold));
                        PdfPCell Width_MM = new PdfPCell(new Phrase("Box Width MM", underlinBold));
                        PdfPCell Height_MM = new PdfPCell(new Phrase("Box Height MM", underlinBold));
                        PdfPCell Dimn_Opt = new PdfPCell(new Phrase("Dimension", underlinBold));
                        PdfPCell Length_MM_Conv = new PdfPCell(new Phrase("Box Length Conv", underlinBold));
                        PdfPCell Width_MM_Conv = new PdfPCell(new Phrase("Box Width Conv", underlinBold));
                        PdfPCell Height_MM_Conv = new PdfPCell(new Phrase("Box Height Conv", underlinBold));

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

                        // Length_MM,Width_MM,Height_MM,Dimn_Opt,Length_MM_Conv,Width_MM_Conv,Height_MM_Conv
                        foreach (DataGridViewRow rows in dataGridView2.Rows)
                        {

                            string Length_MMstr = dataGridView2.Rows[rows.Index].Cells["Length_MM"].Value.ToString();
                            string Width_MMstr = dataGridView2.Rows[rows.Index].Cells["Width_MM"].Value.ToString();

                            string Height_MMstr = dataGridView2.Rows[rows.Index].Cells["Height_MM"].Value.ToString();
                            string Dimn_Optstr = dataGridView2.Rows[rows.Index].Cells["Dimn_Opt"].Value.ToString();
                            string Length_MM_Convstr = dataGridView2.Rows[rows.Index].Cells["Length_MM_Conv"].Value.ToString();
                            string Width_MM_Convstr = dataGridView2.Rows[rows.Index].Cells["Width_MM_Conv"].Value.ToString();
                            string Height_MM_Convstr = dataGridView2.Rows[rows.Index].Cells["Height_MM_Conv"].Value.ToString();


                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));




                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;

                            t2.AddCell(c1_1);
                            t2.AddCell(c1);
                            t2.AddCell(c32);
                            t2.AddCell(c33);
                            t2.AddCell(c34);
                            t2.AddCell(c35);
                            t2.AddCell(c36);





                            doc.Add(t2);
                            LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line3));
                        }
                        #endregion


                        #region ITEM GRID 3
                        //Itemg Grid3
                        PdfPTable t3 = new PdfPTable(7);
                        //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                        //t3.SetWidths(widthst3);
                        t3.DefaultCell.BorderWidth = 0;
                        t3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t3.DefaultCell.BorderColor = BaseColor.WHITE;
                        t3.WidthPercentage = 100;
                        // t3.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        PdfPCell Length_Inch_Sheet = new PdfPCell(new Phrase("Sheet Length Inch", underlinBold));
                        PdfPCell Width_Inch_Sheet = new PdfPCell(new Phrase("Sheet Width Inch", underlinBold));
                        PdfPCell Length_Inch_Sheet1 = new PdfPCell(new Phrase("Sheet Length Inch1", underlinBold));
                        PdfPCell Width_Inch_Sheet1 = new PdfPCell(new Phrase("Sheet Width Inch1", underlinBold));
                        PdfPCell EF_NF_PC = new PdfPCell(new Phrase("EF/NF/PC", underlinBold));
                        PdfPCell Bundle_Packet = new PdfPCell(new Phrase("Bundle/Packet", underlinBold));
                        PdfPCell Box_PerSheet = new PdfPCell(new Phrase("Box Per Sheet", underlinBold));

                        Length_Inch_Sheet.BorderColor = BaseColor.WHITE;
                        Width_Inch_Sheet.BorderColor = BaseColor.WHITE;

                        Length_Inch_Sheet1.BorderColor = BaseColor.WHITE;
                        Width_Inch_Sheet1.BorderColor = BaseColor.WHITE;
                        EF_NF_PC.BorderColor = BaseColor.WHITE;
                        Bundle_Packet.BorderColor = BaseColor.WHITE;
                        Box_PerSheet.BorderColor = BaseColor.WHITE;

                        t3.AddCell(Length_Inch_Sheet);
                        t3.AddCell(Width_Inch_Sheet);
                        t3.AddCell(Length_Inch_Sheet1);
                        t3.AddCell(Width_Inch_Sheet1);
                        t3.AddCell(EF_NF_PC);
                        t3.AddCell(Bundle_Packet);
                        t3.AddCell(Box_PerSheet);

                        foreach (DataGridViewRow rows in dataGridView3.Rows)
                        {

                            string Length_MMstr = dataGridView3.Rows[rows.Index].Cells["Length_Inch_Sheet"].Value.ToString();
                            string Width_MMstr = dataGridView3.Rows[rows.Index].Cells["Width_Inch_Sheet"].Value.ToString();

                            string Height_MMstr = dataGridView3.Rows[rows.Index].Cells["Length_Inch_Sheet1"].Value.ToString();
                            string Dimn_Optstr = dataGridView3.Rows[rows.Index].Cells["Width_Inch_Sheet1"].Value.ToString();
                            string Length_MM_Convstr = dataGridView3.Rows[rows.Index].Cells["EF_NF_PC"].Value.ToString();
                            string Width_MM_Convstr = dataGridView3.Rows[rows.Index].Cells["Bundle_Packet"].Value.ToString();
                            string Height_MM_Convstr = dataGridView3.Rows[rows.Index].Cells["Box_PerSheet"].Value.ToString();

                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));

                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;

                            t3.AddCell(c1_1);
                            t3.AddCell(c1);
                            t3.AddCell(c32);
                            t3.AddCell(c33);
                            t3.AddCell(c34);
                            t3.AddCell(c35);
                            t3.AddCell(c36);

                            doc.Add(t3);
                            LineSeparator line4 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line4));
                        }
                        #endregion


                        #region ITEM GRID 4
                        //Itemg Grid4
                        PdfPTable t4 = new PdfPTable(10);
                        //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                        //t3.SetWidths(widthst3);
                        t4.DefaultCell.BorderWidth = 0;
                        t4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t4.DefaultCell.BorderColor = BaseColor.WHITE;
                        t4.WidthPercentage = 100;
                        // t4.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        PdfPCell Corrugation_Opt = new PdfPCell(new Phrase("Corrugation", underlinBold));
                        PdfPCell Paper_Cutting = new PdfPCell(new Phrase("Paper Cutting", underlinBold));
                        PdfPCell Printing_Opt = new PdfPCell(new Phrase("Printing", underlinBold));
                        PdfPCell No_Colors = new PdfPCell(new Phrase("No. Of Colors", underlinBold));
                        PdfPCell PrntColor_Name = new PdfPCell(new Phrase("Color Names", underlinBold));
                        PdfPCell Paper_Printed = new PdfPCell(new Phrase("Paper Printed", underlinBold));
                        PdfPCell TopPaper = new PdfPCell(new Phrase("TopPaper", underlinBold));
                        PdfPCell Scoring_Opt = new PdfPCell(new Phrase("Scoring", underlinBold));
                        PdfPCell Punching_Opt = new PdfPCell(new Phrase("Punching", underlinBold));
                        PdfPCell Pasting_Opt = new PdfPCell(new Phrase("Pasting", underlinBold));

                        Corrugation_Opt.BorderColor = BaseColor.WHITE;
                        Paper_Cutting.BorderColor = BaseColor.WHITE;
                        Printing_Opt.BorderColor = BaseColor.WHITE;
                        No_Colors.BorderColor = BaseColor.WHITE;
                        PrntColor_Name.BorderColor = BaseColor.WHITE;
                        Paper_Printed.BorderColor = BaseColor.WHITE;
                        TopPaper.BorderColor = BaseColor.WHITE;
                        Scoring_Opt.BorderColor = BaseColor.WHITE;
                        Punching_Opt.BorderColor = BaseColor.WHITE;
                        Pasting_Opt.BorderColor = BaseColor.WHITE;

                        t4.AddCell(Corrugation_Opt);
                        t4.AddCell(Paper_Cutting);
                        t4.AddCell(Printing_Opt);
                        t4.AddCell(No_Colors);
                        t4.AddCell(PrntColor_Name);
                        t4.AddCell(Paper_Printed);
                        t4.AddCell(TopPaper);
                        t4.AddCell(Scoring_Opt);
                        t4.AddCell(Punching_Opt);
                        t4.AddCell(Pasting_Opt);

                        foreach (DataGridViewRow rows in dataGridView4.Rows)
                        {
                            //,,,,,,,,
                            string Length_MMstr = dataGridView4.Rows[rows.Index].Cells["Corrugation_Opt"].Value.ToString();
                            string Width_MMstr = dataGridView4.Rows[rows.Index].Cells["Paper_Cutting"].Value.ToString();

                            string Height_MMstr = dataGridView4.Rows[rows.Index].Cells["Printing_Opt"].Value.ToString();
                            string Dimn_Optstr = dataGridView4.Rows[rows.Index].Cells["No_Colors"].Value.ToString();
                            string Length_MM_Convstr = dataGridView4.Rows[rows.Index].Cells["PrntColor_Name"].Value.ToString();
                            string Width_MM_Convstr = dataGridView4.Rows[rows.Index].Cells["Paper_Printed"].Value.ToString();
                            string Height_MM_Convstr = dataGridView4.Rows[rows.Index].Cells["Scoring_Opt"].Value.ToString();
                            string Punching_Optstr = dataGridView4.Rows[rows.Index].Cells["Punching_Opt"].Value.ToString();
                            string Pasting_Optstr = dataGridView4.Rows[rows.Index].Cells["Pasting_Opt"].Value.ToString();

                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c35_5 = new PdfPCell(new Phrase(TP_Name, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));
                            PdfPCell c37 = new PdfPCell(new Phrase(Punching_Optstr, underlinBold));
                            PdfPCell c38 = new PdfPCell(new Phrase(Pasting_Optstr, underlinBold));

                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c35_5.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;
                            c37.BorderColor = BaseColor.WHITE;
                            c38.BorderColor = BaseColor.WHITE;

                            t4.AddCell(c1_1);
                            t4.AddCell(c1);
                            t4.AddCell(c32);
                            t4.AddCell(c33);
                            t4.AddCell(c34);
                            t4.AddCell(c35);
                            t4.AddCell(c35_5);
                            t4.AddCell(c36);
                            t4.AddCell(c37);
                            t4.AddCell(c38);

                            doc.Add(t4);
                            LineSeparator line5 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line5));
                        }
                        #endregion


                        #region ITEM GRID 5
                        //Itemg Grid5

                        PdfPTable t5 = new PdfPTable(10);
                        //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                        //t3.SetWidths(widthst3);
                        t5.DefaultCell.BorderWidth = 0;
                        t5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t5.DefaultCell.BorderColor = BaseColor.WHITE;
                        t5.WidthPercentage = 100;
                        // t4.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        PdfPCell Slotting_Opt = new PdfPCell(new Phrase("Slotting", underlinBold));
                        PdfPCell Pinning_Opt = new PdfPCell(new Phrase("Pinning", underlinBold));
                        PdfPCell No_Pins = new PdfPCell(new Phrase("No. of Pins", underlinBold));
                        PdfPCell Pinning_InOut = new PdfPCell(new Phrase("Pinning where", underlinBold));
                        PdfPCell Side_Pasting = new PdfPCell(new Phrase("Side Pasting", underlinBold));
                        PdfPCell Rate_SidePastg = new PdfPCell(new Phrase("Side Pasting Rate", underlinBold));
                        PdfPCell Canvas_Opt = new PdfPCell(new Phrase("Canvas", underlinBold));
                        PdfPCell Side_Canvas = new PdfPCell(new Phrase("Side for Canvas", underlinBold));
                        PdfPCell CanvColor_Name = new PdfPCell(new Phrase("Color Name", underlinBold));
                        PdfPCell Sell_Rate = new PdfPCell(new Phrase("Selling Rate", underlinBold));

                        Slotting_Opt.BorderColor = BaseColor.WHITE;
                        Pinning_Opt.BorderColor = BaseColor.WHITE;
                        No_Pins.BorderColor = BaseColor.WHITE;
                        Pinning_InOut.BorderColor = BaseColor.WHITE;
                        Side_Pasting.BorderColor = BaseColor.WHITE;
                        Rate_SidePastg.BorderColor = BaseColor.WHITE;
                        Canvas_Opt.BorderColor = BaseColor.WHITE;
                        Side_Canvas.BorderColor = BaseColor.WHITE;
                        CanvColor_Name.BorderColor = BaseColor.WHITE;
                        Sell_Rate.BorderColor = BaseColor.WHITE;

                        t5.AddCell(Slotting_Opt);
                        t5.AddCell(Pinning_Opt);
                        t5.AddCell(No_Pins);
                        t5.AddCell(Pinning_InOut);
                        t5.AddCell(Side_Pasting);
                        t5.AddCell(Rate_SidePastg);
                        t5.AddCell(Canvas_Opt);
                        t5.AddCell(Side_Canvas);
                        t5.AddCell(CanvColor_Name);
                        t5.AddCell(Sell_Rate);

                        foreach (DataGridViewRow rows in dataGridView5.Rows)
                        {

                            string Length_MMstr = dataGridView5.Rows[rows.Index].Cells["Slotting_Opt"].Value.ToString();
                            string Width_MMstr = dataGridView5.Rows[rows.Index].Cells["Pinning_Opt"].Value.ToString();

                            string Height_MMstr = dataGridView5.Rows[rows.Index].Cells["No_Pins"].Value.ToString();
                            string Dimn_Optstr = dataGridView5.Rows[rows.Index].Cells["Pinning_InOut"].Value.ToString();
                            string Length_MM_Convstr = dataGridView5.Rows[rows.Index].Cells["Side_Pasting"].Value.ToString();
                            string Width_MM_Convstr = dataGridView5.Rows[rows.Index].Cells["Rate_SidePastg"].Value.ToString();
                            string Width_MM_Convstr2 = dataGridView5.Rows[rows.Index].Cells["Canvas_Opt"].Value.ToString();
                            string Height_MM_Convstr = dataGridView5.Rows[rows.Index].Cells["Side_Canvas"].Value.ToString();
                            string Punching_Optstr = dataGridView5.Rows[rows.Index].Cells["CanvColor_Name"].Value.ToString();
                            string Pasting_Optstr = dataGridView5.Rows[rows.Index].Cells["Sell_Rate"].Value.ToString();


                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c35_5 = new PdfPCell(new Phrase(Width_MM_Convstr2, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));
                            PdfPCell c37 = new PdfPCell(new Phrase(Punching_Optstr, underlinBold));
                            PdfPCell c38 = new PdfPCell(new Phrase(Pasting_Optstr, underlinBold));




                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c35_5.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;
                            c37.BorderColor = BaseColor.WHITE;
                            c38.BorderColor = BaseColor.WHITE;

                            t5.AddCell(c1_1);
                            t5.AddCell(c1);
                            t5.AddCell(c32);
                            t5.AddCell(c33);
                            t5.AddCell(c34);
                            t5.AddCell(c35);
                            t5.AddCell(c35_5);
                            t5.AddCell(c36);
                            t5.AddCell(c37);
                            t5.AddCell(c38);





                            doc.Add(t5);
                            LineSeparator line5 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line5));
                        }
                        #endregion



                        #region ITEM GRID 6
                        //Itemg Grid6

                        PdfPTable t6 = new PdfPTable(10);
                        //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                        //t3.SetWidths(widthst3);
                        t6.DefaultCell.BorderWidth = 0;
                        t6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t6.DefaultCell.BorderColor = BaseColor.WHITE;
                        t6.WidthPercentage = 100;
                        // t4.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        PdfPCell Rate_Type = new PdfPCell(new Phrase("Rate Type", underlinBold));
                        PdfPCell Excise_Code = new PdfPCell(new Phrase("Excise Code", underlinBold));
                        PdfPCell Top_BF = new PdfPCell(new Phrase("Top BF", underlinBold));
                        PdfPCell Top_GSM = new PdfPCell(new Phrase("Top GSM", underlinBold));
                        PdfPCell Top_WPP = new PdfPCell(new Phrase("Top WPP", underlinBold));
                        PdfPCell Top_BFPP = new PdfPCell(new Phrase("Top BFPP", underlinBold));
                        PdfPCell Weight_Pcs = new PdfPCell(new Phrase("Weight Per Pcs", underlinBold));
                        PdfPCell BF_Pcs = new PdfPCell(new Phrase("BF Per Pcs", underlinBold));
                        PdfPCell ArtWrk_Code = new PdfPCell(new Phrase("Art Work Code", underlinBold));
                        PdfPCell Revi_No = new PdfPCell(new Phrase("Revision No", underlinBold));

                        Rate_Type.BorderColor = BaseColor.WHITE;
                        Excise_Code.BorderColor = BaseColor.WHITE;
                        Top_BF.BorderColor = BaseColor.WHITE;
                        Top_GSM.BorderColor = BaseColor.WHITE;
                        Top_WPP.BorderColor = BaseColor.WHITE;
                        Top_BFPP.BorderColor = BaseColor.WHITE;
                        Weight_Pcs.BorderColor = BaseColor.WHITE;
                        BF_Pcs.BorderColor = BaseColor.WHITE;
                        ArtWrk_Code.BorderColor = BaseColor.WHITE;
                        Revi_No.BorderColor = BaseColor.WHITE;

                        t6.AddCell(Rate_Type);
                        t6.AddCell(Excise_Code);
                        t6.AddCell(Top_BF);
                        t6.AddCell(Top_GSM);
                        t6.AddCell(Top_WPP);
                        t6.AddCell(Top_BFPP);
                        t6.AddCell(Weight_Pcs);
                        t6.AddCell(BF_Pcs);
                        t6.AddCell(ArtWrk_Code);
                        t6.AddCell(Revi_No);

                        foreach (DataGridViewRow rows in dataGridView6.Rows)
                        {


                            string Length_MMstr = dataGridView6.Rows[rows.Index].Cells["Rate_Type"].Value.ToString();
                            string Width_MMstr = dataGridView6.Rows[rows.Index].Cells["Excise_Code"].Value.ToString();

                            string Height_MMstr = dataGridView6.Rows[rows.Index].Cells["Top_BF"].Value.ToString();
                            string Dimn_Optstr = dataGridView6.Rows[rows.Index].Cells["Top_GSM"].Value.ToString();
                            string Length_MM_Convstr = dataGridView6.Rows[rows.Index].Cells["Top_WPP"].Value.ToString();
                            string Width_MM_Convstr = dataGridView6.Rows[rows.Index].Cells["Top_BFPP"].Value.ToString();
                            string Width_MM_Convstr2 = dataGridView6.Rows[rows.Index].Cells["Weight_Pcs"].Value.ToString();
                            string Height_MM_Convstr = dataGridView6.Rows[rows.Index].Cells["BF_Pcs"].Value.ToString();
                            string Punching_Optstr = dataGridView6.Rows[rows.Index].Cells["ArtWrk_Code"].Value.ToString();
                            string Pasting_Optstr = dataGridView6.Rows[rows.Index].Cells["Revi_No"].Value.ToString();


                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c35_5 = new PdfPCell(new Phrase(Width_MM_Convstr2, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));
                            PdfPCell c37 = new PdfPCell(new Phrase(Punching_Optstr, underlinBold));
                            PdfPCell c38 = new PdfPCell(new Phrase(Pasting_Optstr, underlinBold));




                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c35_5.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;
                            c37.BorderColor = BaseColor.WHITE;
                            c38.BorderColor = BaseColor.WHITE;

                            t6.AddCell(c1_1);
                            t6.AddCell(c1);
                            t6.AddCell(c32);
                            t6.AddCell(c33);
                            t6.AddCell(c34);
                            t6.AddCell(c35);
                            t6.AddCell(c35_5);
                            t6.AddCell(c36);
                            t6.AddCell(c37);
                            t6.AddCell(c38);





                            doc.Add(t6);
                            LineSeparator line5 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line5));
                        }
                        #endregion



                        #region ITEM GRID 7
                        //Itemg Grid6

                        PdfPTable t7 = new PdfPTable(8);
                        //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                        //t3.SetWidths(widthst3);
                        t7.DefaultCell.BorderWidth = 0;
                        t7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t7.DefaultCell.BorderColor = BaseColor.WHITE;
                        t7.WidthPercentage = 100;
                        // t4.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        PdfPCell Art_Dt = new PdfPCell(new Phrase("Art Dt", underlinBold));
                        PdfPCell Speci_Code = new PdfPCell(new Phrase("Specification Code", underlinBold));
                        PdfPCell For_Pedilite = new PdfPCell(new Phrase("For Pedilite", underlinBold));
                        PdfPCell Pedilite_BS = new PdfPCell(new Phrase("BS", underlinBold));
                        PdfPCell Pedilite_GSM = new PdfPCell(new Phrase("GSM", underlinBold));
                        PdfPCell Pedilite_WtBox = new PdfPCell(new Phrase("Weightt of Box", underlinBold));
                        PdfPCell Pedilite_PReq = new PdfPCell(new Phrase("Purchase Requirement", underlinBold));
                        PdfPCell I_Lock = new PdfPCell(new Phrase("Lock", underlinBold));

                        Art_Dt.BorderColor = BaseColor.WHITE;
                        Speci_Code.BorderColor = BaseColor.WHITE;
                        For_Pedilite.BorderColor = BaseColor.WHITE;
                        Pedilite_BS.BorderColor = BaseColor.WHITE;
                        Pedilite_GSM.BorderColor = BaseColor.WHITE;
                        Pedilite_WtBox.BorderColor = BaseColor.WHITE;
                        Pedilite_PReq.BorderColor = BaseColor.WHITE;
                        I_Lock.BorderColor = BaseColor.WHITE;

                        t7.AddCell(Art_Dt);
                        t7.AddCell(Speci_Code);
                        t7.AddCell(For_Pedilite);
                        t7.AddCell(Pedilite_BS);
                        t7.AddCell(Pedilite_GSM);
                        t7.AddCell(Pedilite_WtBox);
                        t7.AddCell(Pedilite_PReq);
                        t7.AddCell(I_Lock);

                        foreach (DataGridViewRow rows in dataGridView7.Rows)
                        {

                            //'',,,,,,,
                            string Length_MMstr = dataGridView7.Rows[rows.Index].Cells["Art_Dt"].Value.ToString();
                            string Width_MMstr = dataGridView7.Rows[rows.Index].Cells["Speci_Code"].Value.ToString();

                            string Height_MMstr = dataGridView7.Rows[rows.Index].Cells["For_Pedilite"].Value.ToString();
                            string Dimn_Optstr = dataGridView7.Rows[rows.Index].Cells["Pedilite_BS"].Value.ToString();
                            string Length_MM_Convstr = dataGridView7.Rows[rows.Index].Cells["Pedilite_GSM"].Value.ToString();
                            string Width_MM_Convstr = dataGridView7.Rows[rows.Index].Cells["Pedilite_WtBox"].Value.ToString();
                            string Width_MM_Convstr2 = dataGridView7.Rows[rows.Index].Cells["Pedilite_PReq"].Value.ToString();
                            string Height_MM_Convstr = dataGridView7.Rows[rows.Index].Cells["I_Lock"].Value.ToString();


                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c35_5 = new PdfPCell(new Phrase(Width_MM_Convstr2, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));



                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c35_5.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;


                            t7.AddCell(c1_1);
                            t7.AddCell(c1);
                            t7.AddCell(c32);
                            t7.AddCell(c33);
                            t7.AddCell(c34);
                            t7.AddCell(c35);
                            t7.AddCell(c35_5);
                            t7.AddCell(c36);






                            doc.Add(t7);
                            LineSeparator line5 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line5));
                        }
                        #endregion

                    }
                    catch (DocumentException ex)
                    {
                        //Handle document exception
                        MessageBox.Show("The was DocumentException error While creating PDF " + ex.Message);
                    }
                    catch (IOException ex)
                    {
                        //Handle IO exception
                        MessageBox.Show("The was IOException error While creating PDF " + ex.Message);
                    }
                    catch (Exception)
                    {
                        //Handle Other Exception
                    }
                    finally
                    {
                        doc.Close(); //Close document
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The was some error While creating PDF " + ex.Message);
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strCon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strCon);
                SqlConnection con4 = new SqlConnection(strCon);

                //Item Grid1
                string strsql = "select b.Style_No,Ply_Sheet,Length_Inch,Width_Inch,Height_Inch from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + grI_ID + "'";

                SqlDataAdapter da = new SqlDataAdapter(strsql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                //Item Grid2
                string strsql2 = "select Length_MM,Width_MM,Height_MM,Dimn_Opt,Length_MM_Conv,Width_MM_Conv,Height_MM_Conv from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + grI_ID + "'";

                SqlDataAdapter da2 = new SqlDataAdapter(strsql2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;


                //Item Grid3
                string strsql3 = "select Length_Inch_Sheet,Width_Inch_Sheet,Length_Inch_Sheet1,Width_Inch_Sheet1,EF_NF_PC,Bundle_Packet,Box_PerSheet from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + grI_ID + "'";

                SqlDataAdapter da3 = new SqlDataAdapter(strsql3, con);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                dataGridView3.DataSource = dt3;

                //Item Grid4
                string strsql4 = "select Corrugation_Opt,Paper_Cutting,Printing_Opt,No_Colors,PrntColor_Name,Paper_Printed,Scoring_Opt,Punching_Opt,Pasting_Opt from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + grI_ID + "'";

                SqlDataAdapter da4 = new SqlDataAdapter(strsql4, con);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                dataGridView4.DataSource = dt4;

                //Item Grid5
                string strsql11 = "select Slotting_Opt,Pinning_Opt,No_Pins,Pinning_InOut,Side_Pasting,Rate_SidePastg,Canvas_Opt,Side_Canvas,CanvColor_Name,Sell_Rate from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + grI_ID + "'";

                SqlDataAdapter da5 = new SqlDataAdapter(strsql11, con);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);
                dataGridView5.DataSource = dt5;

                //Item Grid6
                string strsql12 = "select Rate_Type,Excise_Code,Top_BF,Top_GSM,Top_WPP,Top_BFPP,Weight_Pcs,BF_Pcs,ArtWrk_Code,Revi_No from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + grI_ID + "'";

                SqlDataAdapter da12 = new SqlDataAdapter(strsql12, con);
                DataTable dt12 = new DataTable();
                da12.Fill(dt12);
                dataGridView6.DataSource = dt12;

                //Item Grid7
                string strsql13 = "select Convert(varchar(20),Art_Dt,103) as 'Art_Dt',Speci_Code,For_Pedilite,Pedilite_BS,Pedilite_GSM,Pedilite_WtBox,Pedilite_PReq,I_Lock from Item_MAster as a,Item_Style_Master as b where a.Style_ID=b.Style_ID and a.I_ID='" + grI_ID + "'";

                SqlDataAdapter da13 = new SqlDataAdapter(strsql13, con);
                DataTable dt13 = new DataTable();
                da13.Fill(dt13);
                dataGridView7.DataSource = dt13;

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


                string strsql7 = "Select Style_ID,TP_ID  from Item_Master where I_ID='" + grI_ID + "' ";
                SqlCommand cmd7 = new SqlCommand(strsql7, con);
                con.Open();
                SqlDataReader dr7 = cmd7.ExecuteReader();
                if (dr7.Read())
                {
                    Style_ID = Convert.ToString(dr7["Style_ID"]);
                    TP_ID = Convert.ToString(dr7["TP_ID"]);
                }

                dr7.Close();
                con.Close();

                string strsql15 = "Select TP_ID  from Item_Order where Order_ID='" + txtOrder_ID.Text.ToString() + "' ";
                SqlCommand cmd15 = new SqlCommand(strsql15, con);
                con.Open();
                SqlDataReader dr15 = cmd15.ExecuteReader();
                if (dr15.Read())
                {
                    grTP_ID = Convert.ToString(dr15["TP_ID"]);
                }

                dr15.Close();
                con.Close();


                string strsql99 = "Select TP_Name from TopPaper_Master where TP_ID='" + grTP_ID + "' ";
                SqlCommand cmd99 = new SqlCommand(strsql99, con);
                con.Open();
                SqlDataReader dr99 = cmd99.ExecuteReader();
                if (dr99.Read())
                {
                    grTP_Name = Convert.ToString(dr99["TP_Name"]);
                }
                else
                {
                    grTP_Name = "";
                }

                dr99.Close();
                con.Close();

                string strsql8 = "Select P_Name  from Party_Master where P_ID='" + grP_ID + "' ";
                SqlCommand cmd8 = new SqlCommand(strsql8, con);
                con.Open();
                SqlDataReader dr8 = cmd8.ExecuteReader();
                if (dr8.Read())
                {
                    P_Name = Convert.ToString(dr8["P_Name"]);
                }

                dr8.Close();
                con.Close();

                string strsql9 = "Select TP_Name from TopPaper_Master where TP_ID='" + TP_ID + "' ";
                SqlCommand cmd9 = new SqlCommand(strsql9, con);
                con.Open();
                SqlDataReader dr9 = cmd9.ExecuteReader();
                if (dr9.Read())
                {
                    TP_Name = Convert.ToString(dr9["TP_Name"]);
                }

                dr9.Close();
                con.Close();

                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "Pdf Documents (*.pdf)|*.pdf";
                sfd.FileName = "CopyofOrderProcessing.pdf";
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

                        Chunk chunk = new Chunk("Order Processing (Copy)" + '\n', titleFont);
                        chunk.SetUnderline(0.5f, -1.5f);

                        Paragraph ParaTitle = new Paragraph(chunk);
                        ParaTitle.SpacingBefore = 5f;
                        ParaTitle.SpacingAfter = 5f;

                        var phrase2 = new Phrase();
                        phrase2.Add(new Chunk("Order No.: ", underline));
                        Chunk c2 = new Chunk(txtOrder_ID.Text.Trim().ToString(), underline);
                        c2.SetUnderline(0.5f, -1.5f);
                        phrase2.Add(c2);

                        phrase2.Add(new Chunk("        "));

                        phrase2.Add(new Chunk("Order Dt: ", underline));
                        Chunk c3 = new Chunk(txtOrder_Dt.Text.Trim().ToString() + '\n', underline);
                        c3.SetUnderline(0.5f, -1.5f);
                        phrase2.Add(c3);

                        Paragraph pf1 = new Paragraph(phrase2);

                        var phrase3 = new Phrase();
                        phrase3.Add(new Chunk("Party PO No.:  ", underline));
                        Chunk c4 = new Chunk(txtP_PONo.Text.Trim().ToString(), underline);
                        c4.SetUnderline(0.5f, -1.5f);
                        phrase3.Add(c4);

                        phrase3.Add(new Chunk("       "));

                        phrase3.Add(new Chunk("Party PO Dt: ", underline));
                        Chunk c5 = new Chunk(txtP_PODt.Text.Trim().ToString() + '\n', underline);
                        c5.SetUnderline(0.5f, -1.5f);
                        phrase3.Add(c5);

                        Paragraph pf1_1 = new Paragraph(phrase3);
                        var phrase4 = new Phrase();
                        phrase4.Add(new Chunk("Party    :", underline));
                        Chunk cadd = new Chunk(P_Name + '\n', underline);
                        cadd.SetUnderline(0.5f, -1.5f);
                        phrase4.Add(cadd);

                        Paragraph pf2 = new Paragraph(phrase4);
                        var phrase33 = new Phrase();
                        phrase33.Add(new Chunk("Selling Rate :", underline));
                        Chunk c44 = new Chunk(txtSell_Rate.Text.Trim().ToString(), underline);
                        c44.SetUnderline(0.5f, -1.5f);
                        phrase33.Add(c44);
                        phrase33.Add(new Chunk("         "));
                        phrase33.Add(new Chunk("Box Quantity :", underline));
                        Chunk c55 = new Chunk(txtBox_Qty.Text.Trim().ToString(), underline);
                        c55.SetUnderline(0.5f, -1.5f);
                        phrase33.Add(c55);


                        Paragraph pf3 = new Paragraph(phrase33);
                        var phrase7 = new Phrase();
                        phrase7.Add(new Chunk("Box Per Sheet :", underline));
                        Chunk c7 = new Chunk(txtBox_PerSheet.Text.Trim().ToString(), underline);
                        c7.SetUnderline(0.5f, -1.5f);
                        phrase7.Add(c7);
                        phrase7.Add(new Chunk("      "));
                        phrase7.Add(new Chunk("Sheet Quantity :", underline));
                        Chunk c71 = new Chunk(txtSheet_Qty.Text.Trim().ToString(), underline);
                        c71.SetUnderline(0.5f, -1.5f);
                        phrase7.Add(c71);


                        Paragraph pf4 = new Paragraph(phrase7);
                        // pf4.SpacingBefore = 5f;
                        //    pf4.SpacingAfter = 10f;
                        var phrase8 = new Phrase();
                        phrase8.Add(new Chunk("Top Paper :", underline));
                        Chunk c81 = new Chunk(grTP_Name.Trim().ToString(), underline);
                        c81.SetUnderline(0.5f, -1.5f);
                        phrase8.Add(c81);


                        Paragraph pf7 = new Paragraph(phrase8);
                        // pf4.SpacingBefore = 5f;
                        var phraseIns = new Phrase();
                        phraseIns.Add(new Chunk("Printing Instruction :", underline));
                        Chunk cins = new Chunk(txtPrint_Inst.Text.Trim().ToString(), underline);
                        cins.SetUnderline(0.5f, -1.5f);
                        phraseIns.Add(cins);

                        Paragraph pf8 = new Paragraph(phraseIns);
                        pf8.SpacingAfter = 5f;
                        doc.Add(MainTitle);
                        doc.Add(ParaTitle);
                        doc.Add(pf1);
                        doc.Add(pf1_1);
                        doc.Add(pf2);
                        doc.Add(pf3);
                        doc.Add(pf4);

                        if (ddlTP_ID.SelectedValue != "")
                        {
                            doc.Add(pf7);
                        }

                        if (txtPrint_Inst.Text != "")
                        {
                            doc.Add(pf8);
                        }

                        LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                        doc.Add(new Chunk(line));

                        //var phraseItem = new Phrase();
                        //phraseItem.Add(new Chunk("Item  ", underline));
                        //Chunk cItem = new Chunk(ddlI_ID.Text.Trim().ToString(), underlinBold);
                        //cItem.SetUnderline(0.5f, -1.5f);
                        //phraseItem.Add(cItem);

                        //Paragraph pfitem = new Paragraph(phraseItem);

                        //doc.Add(pfitem);

                        #region GRID 1
                        PdfPTable t1 = new PdfPTable(7);
                        // float[] widthst1 = new float[] { 2f, 1.4f };
                        //  t1.SetWidths(widthst1);
                        t1.DefaultCell.BorderWidth = 0;
                        t1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t1.DefaultCell.BorderColor = BaseColor.WHITE;
                        t1.WidthPercentage = 100;
                        // t1.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        //"Select Convert(varchar(20),Rec_Dt,103) as 'Consultancy Date',b.H_Name as 'Hospital',P_Case as 'Case',P_Note as 'Note',P_Presc as 'Prescription',P_Fee as 'Fee',P_FeeRecd  as 'Fee Received' from Patient_Consultancy as a,Hospital_Master as b where a.H_ID=b.H_ID and Patient_ID='" + PAtient_ID + "' ";
                        PdfPCell cid1 = new PdfPCell(new Phrase("Item", underlinBold));
                        PdfPCell cid = new PdfPCell(new Phrase("Style of Box", underlinBold));
                        PdfPCell cPhoto = new PdfPCell(new Phrase("Style Image", underlinBold));
                        PdfPCell cbal = new PdfPCell(new Phrase("Ply of Sheet", underlinBold));
                        PdfPCell ccell = new PdfPCell(new Phrase("Box Length Inch", underlinBold));
                        PdfPCell cTele = new PdfPCell(new Phrase("Box Width Inch", underlinBold));
                        PdfPCell cTele2 = new PdfPCell(new Phrase("Box Height Inch", underlinBold));

                        cid.BorderColor = BaseColor.WHITE;
                        cid1.BorderColor = BaseColor.WHITE;

                        cbal.BorderColor = BaseColor.WHITE;
                        ccell.BorderColor = BaseColor.WHITE;
                        cTele.BorderColor = BaseColor.WHITE;
                        cTele2.BorderColor = BaseColor.WHITE;
                        cPhoto.BorderColor = BaseColor.WHITE;

                        t1.AddCell(cid1);
                        t1.AddCell(cid);
                        t1.AddCell(cPhoto);
                        t1.AddCell(cbal);
                        t1.AddCell(ccell);
                        t1.AddCell(cTele);
                        t1.AddCell(cTele2);

                        //b.Style_No,Ply_Sheet,Length_Inch,Width_Inch,Height_Inch
                        foreach (DataGridViewRow rows in dataGridView1.Rows)
                        {
                            iTextSharp.text.Image Photo;
                            //if (Convert.ToBoolean(GridView1.Rows[rows.Index].Cells[2].Value))
                            //{Consultancy_ID
                            string Style_No = dataGridView1.Rows[rows.Index].Cells["Style_No"].Value.ToString();
                            string Ply_Sheet = dataGridView1.Rows[rows.Index].Cells["Ply_Sheet"].Value.ToString();

                            string Length_Inch = dataGridView1.Rows[rows.Index].Cells["Length_Inch"].Value.ToString();
                            string Width_Inch = dataGridView1.Rows[rows.Index].Cells["Width_Inch"].Value.ToString();
                            string Height_Inch = dataGridView1.Rows[rows.Index].Cells["Height_Inch"].Value.ToString();


                            PdfPCell c1_1 = new PdfPCell(new Phrase(ddlI_ID.Text, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Style_No, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Ply_Sheet, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Length_Inch, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Width_Inch, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Height_Inch, underlinBold));

                            PdfPCell cPhot = new PdfPCell();
                            funclib = new FunctionLib();
                            string strcon = funclib.setConnection();
                            SqlConnection con3 = new SqlConnection(strcon);
                            con3.Open();
                            //Retrieve BLOB from database into DataSet.

                            SqlCommand cmd = new SqlCommand("select Image_Sheet from Item_Style_Master where Image_Sheet is not null and Style_ID='" + Style_ID + "'", con3);
                            SqlDataReader drimg = cmd.ExecuteReader();
                            if (drimg.Read())
                            {
                                bytImage = (byte[])drimg["Image_Sheet"];

                                MemoryStream ms = new MemoryStream(bytImage);

                                System.Drawing.Bitmap BMP = new System.Drawing.Bitmap(ms);

                                rptImagepath = Path.Combine(Application.StartupPath, Style_ID + ".bmp");
                                BMP.Save(rptImagepath);

                                Photo = iTextSharp.text.Image.GetInstance(rptImagepath);
                                // Photo.ScaleAbsoluteHeight(45);
                                //Photo.ScaleAbsoluteWidth(120);
                                cPhot = new PdfPCell(Photo);
                                cPhot.PaddingTop = 2f;
                                cPhot.HorizontalAlignment = Element.ALIGN_CENTER;
                            }
                            else
                            {
                                cPhot = new PdfPCell(new Phrase("NA", underline));
                                cPhot.HorizontalAlignment = Element.ALIGN_LEFT;
                            }
                            drimg.Close();
                            con3.Close();
                            //doc.Add(logo);

                            cPhot.BorderColor = BaseColor.WHITE;

                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;

                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            cPhot.BorderColor = BaseColor.WHITE;

                            t1.AddCell(c1_1);
                            t1.AddCell(c1);
                            t1.AddCell(cPhot);
                            t1.AddCell(c32);
                            t1.AddCell(c33);
                            t1.AddCell(c34);
                            t1.AddCell(c35);

                            rptImagepath = "";
                            doc.Add(t1);

                            LineSeparator line2 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line2));
                        }
                        #endregion


                        #region GRID 2
                        //Itemg Grid2

                        PdfPTable t2 = new PdfPTable(7);
                        //float[] widthst1 = new float[] { 1f,1f,1f,1f,1.4f,1f,1f };
                        //t2.SetWidths(widthst1);
                        t2.DefaultCell.BorderWidth = 0;
                        t2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t2.DefaultCell.BorderColor = BaseColor.WHITE;
                        t2.WidthPercentage = 100;
                        //t2.SpacingAfter = 4f;

                        PdfPCell Length_MM = new PdfPCell(new Phrase("Box Length MM", underlinBold));
                        PdfPCell Width_MM = new PdfPCell(new Phrase("Box Width MM", underlinBold));
                        PdfPCell Height_MM = new PdfPCell(new Phrase("Box Height MM", underlinBold));
                        PdfPCell Dimn_Opt = new PdfPCell(new Phrase("Dimension", underlinBold));
                        PdfPCell Length_MM_Conv = new PdfPCell(new Phrase("Box Length Conv", underlinBold));
                        PdfPCell Width_MM_Conv = new PdfPCell(new Phrase("Box Width Conv", underlinBold));
                        PdfPCell Height_MM_Conv = new PdfPCell(new Phrase("Box Height Conv", underlinBold));

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

                        // Length_MM,Width_MM,Height_MM,Dimn_Opt,Length_MM_Conv,Width_MM_Conv,Height_MM_Conv
                        foreach (DataGridViewRow rows in dataGridView2.Rows)
                        {

                            string Length_MMstr = dataGridView2.Rows[rows.Index].Cells["Length_MM"].Value.ToString();
                            string Width_MMstr = dataGridView2.Rows[rows.Index].Cells["Width_MM"].Value.ToString();

                            string Height_MMstr = dataGridView2.Rows[rows.Index].Cells["Height_MM"].Value.ToString();
                            string Dimn_Optstr = dataGridView2.Rows[rows.Index].Cells["Dimn_Opt"].Value.ToString();
                            string Length_MM_Convstr = dataGridView2.Rows[rows.Index].Cells["Length_MM_Conv"].Value.ToString();
                            string Width_MM_Convstr = dataGridView2.Rows[rows.Index].Cells["Width_MM_Conv"].Value.ToString();
                            string Height_MM_Convstr = dataGridView2.Rows[rows.Index].Cells["Height_MM_Conv"].Value.ToString();

                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));

                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;

                            t2.AddCell(c1_1);
                            t2.AddCell(c1);
                            t2.AddCell(c32);
                            t2.AddCell(c33);
                            t2.AddCell(c34);
                            t2.AddCell(c35);
                            t2.AddCell(c36);

                            doc.Add(t2);
                            LineSeparator line3 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line3));
                        }
                        #endregion


                        #region GRID 3
                        //Itemg Grid3
                        PdfPTable t3 = new PdfPTable(7);
                        //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                        //t3.SetWidths(widthst3);
                        t3.DefaultCell.BorderWidth = 0;
                        t3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t3.DefaultCell.BorderColor = BaseColor.WHITE;
                        t3.WidthPercentage = 100;
                        // t3.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        PdfPCell Length_Inch_Sheet = new PdfPCell(new Phrase("Sheet Length Inch", underlinBold));
                        PdfPCell Width_Inch_Sheet = new PdfPCell(new Phrase("Sheet Width Inch", underlinBold));
                        PdfPCell Length_Inch_Sheet1 = new PdfPCell(new Phrase("Sheet Length Inch1", underlinBold));
                        PdfPCell Width_Inch_Sheet1 = new PdfPCell(new Phrase("Sheet Width Inch1", underlinBold));
                        PdfPCell EF_NF_PC = new PdfPCell(new Phrase("EF/NF/PC", underlinBold));
                        PdfPCell Bundle_Packet = new PdfPCell(new Phrase("Bundle/Packet", underlinBold));
                        PdfPCell Box_PerSheet = new PdfPCell(new Phrase("Box Per Sheet", underlinBold));

                        Length_Inch_Sheet.BorderColor = BaseColor.WHITE;
                        Width_Inch_Sheet.BorderColor = BaseColor.WHITE;

                        Length_Inch_Sheet1.BorderColor = BaseColor.WHITE;
                        Width_Inch_Sheet1.BorderColor = BaseColor.WHITE;
                        EF_NF_PC.BorderColor = BaseColor.WHITE;
                        Bundle_Packet.BorderColor = BaseColor.WHITE;
                        Box_PerSheet.BorderColor = BaseColor.WHITE;

                        t3.AddCell(Length_Inch_Sheet);
                        t3.AddCell(Width_Inch_Sheet);
                        t3.AddCell(Length_Inch_Sheet1);
                        t3.AddCell(Width_Inch_Sheet1);
                        t3.AddCell(EF_NF_PC);
                        t3.AddCell(Bundle_Packet);
                        t3.AddCell(Box_PerSheet);

                        foreach (DataGridViewRow rows in dataGridView3.Rows)
                        {
                            string Length_MMstr = dataGridView3.Rows[rows.Index].Cells["Length_Inch_Sheet"].Value.ToString();
                            string Width_MMstr = dataGridView3.Rows[rows.Index].Cells["Width_Inch_Sheet"].Value.ToString();

                            string Height_MMstr = dataGridView3.Rows[rows.Index].Cells["Length_Inch_Sheet1"].Value.ToString();
                            string Dimn_Optstr = dataGridView3.Rows[rows.Index].Cells["Width_Inch_Sheet1"].Value.ToString();
                            string Length_MM_Convstr = dataGridView3.Rows[rows.Index].Cells["EF_NF_PC"].Value.ToString();
                            string Width_MM_Convstr = dataGridView3.Rows[rows.Index].Cells["Bundle_Packet"].Value.ToString();
                            string Height_MM_Convstr = dataGridView3.Rows[rows.Index].Cells["Box_PerSheet"].Value.ToString();

                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));

                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;

                            t3.AddCell(c1_1);
                            t3.AddCell(c1);
                            t3.AddCell(c32);
                            t3.AddCell(c33);
                            t3.AddCell(c34);
                            t3.AddCell(c35);
                            t3.AddCell(c36);

                            doc.Add(t3);
                            LineSeparator line4 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line4));
                        }
                        #endregion


                        #region GRID 4
                        //Itemg Grid4
                        PdfPTable t4 = new PdfPTable(10);
                        //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                        //t3.SetWidths(widthst3);
                        t4.DefaultCell.BorderWidth = 0;
                        t4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t4.DefaultCell.BorderColor = BaseColor.WHITE;
                        t4.WidthPercentage = 100;
                        // t4.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        PdfPCell Corrugation_Opt = new PdfPCell(new Phrase("Corrugation", underlinBold));
                        PdfPCell Paper_Cutting = new PdfPCell(new Phrase("Paper Cutting", underlinBold));
                        PdfPCell Printing_Opt = new PdfPCell(new Phrase("Printing", underlinBold));
                        PdfPCell No_Colors = new PdfPCell(new Phrase("No. Of Colors", underlinBold));
                        PdfPCell PrntColor_Name = new PdfPCell(new Phrase("Color Names", underlinBold));
                        PdfPCell Paper_Printed = new PdfPCell(new Phrase("Paper Printed", underlinBold));
                        PdfPCell TopPaper = new PdfPCell(new Phrase("TopPaper", underlinBold));
                        PdfPCell Scoring_Opt = new PdfPCell(new Phrase("Scoring", underlinBold));
                        PdfPCell Punching_Opt = new PdfPCell(new Phrase("Punching", underlinBold));
                        PdfPCell Pasting_Opt = new PdfPCell(new Phrase("Pasting", underlinBold));

                        Corrugation_Opt.BorderColor = BaseColor.WHITE;
                        Paper_Cutting.BorderColor = BaseColor.WHITE;
                        Printing_Opt.BorderColor = BaseColor.WHITE;
                        No_Colors.BorderColor = BaseColor.WHITE;
                        PrntColor_Name.BorderColor = BaseColor.WHITE;
                        Paper_Printed.BorderColor = BaseColor.WHITE;
                        TopPaper.BorderColor = BaseColor.WHITE;
                        Scoring_Opt.BorderColor = BaseColor.WHITE;
                        Punching_Opt.BorderColor = BaseColor.WHITE;
                        Pasting_Opt.BorderColor = BaseColor.WHITE;

                        t4.AddCell(Corrugation_Opt);
                        t4.AddCell(Paper_Cutting);
                        t4.AddCell(Printing_Opt);
                        t4.AddCell(No_Colors);
                        t4.AddCell(PrntColor_Name);
                        t4.AddCell(Paper_Printed);
                        t4.AddCell(TopPaper);
                        t4.AddCell(Scoring_Opt);
                        t4.AddCell(Punching_Opt);
                        t4.AddCell(Pasting_Opt);

                        foreach (DataGridViewRow rows in dataGridView4.Rows)
                        {
                            //,,,,,,,,
                            string Length_MMstr = dataGridView4.Rows[rows.Index].Cells["Corrugation_Opt"].Value.ToString();
                            string Width_MMstr = dataGridView4.Rows[rows.Index].Cells["Paper_Cutting"].Value.ToString();

                            string Height_MMstr = dataGridView4.Rows[rows.Index].Cells["Printing_Opt"].Value.ToString();
                            string Dimn_Optstr = dataGridView4.Rows[rows.Index].Cells["No_Colors"].Value.ToString();
                            string Length_MM_Convstr = dataGridView4.Rows[rows.Index].Cells["PrntColor_Name"].Value.ToString();
                            string Width_MM_Convstr = dataGridView4.Rows[rows.Index].Cells["Paper_Printed"].Value.ToString();
                            string Height_MM_Convstr = dataGridView4.Rows[rows.Index].Cells["Scoring_Opt"].Value.ToString();
                            string Punching_Optstr = dataGridView4.Rows[rows.Index].Cells["Punching_Opt"].Value.ToString();
                            string Pasting_Optstr = dataGridView4.Rows[rows.Index].Cells["Pasting_Opt"].Value.ToString();

                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c35_5 = new PdfPCell(new Phrase(TP_Name, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));
                            PdfPCell c37 = new PdfPCell(new Phrase(Punching_Optstr, underlinBold));
                            PdfPCell c38 = new PdfPCell(new Phrase(Pasting_Optstr, underlinBold));

                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c35_5.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;
                            c37.BorderColor = BaseColor.WHITE;
                            c38.BorderColor = BaseColor.WHITE;

                            t4.AddCell(c1_1);
                            t4.AddCell(c1);
                            t4.AddCell(c32);
                            t4.AddCell(c33);
                            t4.AddCell(c34);
                            t4.AddCell(c35);
                            t4.AddCell(c35_5);
                            t4.AddCell(c36);
                            t4.AddCell(c37);
                            t4.AddCell(c38);

                            doc.Add(t4);
                            LineSeparator line5 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line5));
                        }
                        #endregion


                        #region GRID 5
                        //Itemg Grid5
                        PdfPTable t5 = new PdfPTable(10);
                        //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                        //t3.SetWidths(widthst3);
                        t5.DefaultCell.BorderWidth = 0;
                        t5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t5.DefaultCell.BorderColor = BaseColor.WHITE;
                        t5.WidthPercentage = 100;
                        // t4.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        PdfPCell Slotting_Opt = new PdfPCell(new Phrase("Slotting", underlinBold));
                        PdfPCell Pinning_Opt = new PdfPCell(new Phrase("Pinning", underlinBold));
                        PdfPCell No_Pins = new PdfPCell(new Phrase("No. of Pins", underlinBold));
                        PdfPCell Pinning_InOut = new PdfPCell(new Phrase("Pinning where", underlinBold));
                        PdfPCell Side_Pasting = new PdfPCell(new Phrase("Side Pasting", underlinBold));
                        PdfPCell Rate_SidePastg = new PdfPCell(new Phrase("Side Pasting Rate", underlinBold));
                        PdfPCell Canvas_Opt = new PdfPCell(new Phrase("Canvas", underlinBold));
                        PdfPCell Side_Canvas = new PdfPCell(new Phrase("Side for Canvas", underlinBold));
                        PdfPCell CanvColor_Name = new PdfPCell(new Phrase("Color Name", underlinBold));
                        PdfPCell Sell_Rate = new PdfPCell(new Phrase("Selling Rate", underlinBold));

                        Slotting_Opt.BorderColor = BaseColor.WHITE;
                        Pinning_Opt.BorderColor = BaseColor.WHITE;
                        No_Pins.BorderColor = BaseColor.WHITE;
                        Pinning_InOut.BorderColor = BaseColor.WHITE;
                        Side_Pasting.BorderColor = BaseColor.WHITE;
                        Rate_SidePastg.BorderColor = BaseColor.WHITE;
                        Canvas_Opt.BorderColor = BaseColor.WHITE;
                        Side_Canvas.BorderColor = BaseColor.WHITE;
                        CanvColor_Name.BorderColor = BaseColor.WHITE;
                        Sell_Rate.BorderColor = BaseColor.WHITE;

                        t5.AddCell(Slotting_Opt);
                        t5.AddCell(Pinning_Opt);
                        t5.AddCell(No_Pins);
                        t5.AddCell(Pinning_InOut);
                        t5.AddCell(Side_Pasting);
                        t5.AddCell(Rate_SidePastg);
                        t5.AddCell(Canvas_Opt);
                        t5.AddCell(Side_Canvas);
                        t5.AddCell(CanvColor_Name);
                        t5.AddCell(Sell_Rate);

                        foreach (DataGridViewRow rows in dataGridView5.Rows)
                        {
                            string Length_MMstr = dataGridView5.Rows[rows.Index].Cells["Slotting_Opt"].Value.ToString();
                            string Width_MMstr = dataGridView5.Rows[rows.Index].Cells["Pinning_Opt"].Value.ToString();

                            string Height_MMstr = dataGridView5.Rows[rows.Index].Cells["No_Pins"].Value.ToString();
                            string Dimn_Optstr = dataGridView5.Rows[rows.Index].Cells["Pinning_InOut"].Value.ToString();
                            string Length_MM_Convstr = dataGridView5.Rows[rows.Index].Cells["Side_Pasting"].Value.ToString();
                            string Width_MM_Convstr = dataGridView5.Rows[rows.Index].Cells["Rate_SidePastg"].Value.ToString();
                            string Width_MM_Convstr2 = dataGridView5.Rows[rows.Index].Cells["Canvas_Opt"].Value.ToString();
                            string Height_MM_Convstr = dataGridView5.Rows[rows.Index].Cells["Side_Canvas"].Value.ToString();
                            string Punching_Optstr = dataGridView5.Rows[rows.Index].Cells["CanvColor_Name"].Value.ToString();
                            string Pasting_Optstr = dataGridView5.Rows[rows.Index].Cells["Sell_Rate"].Value.ToString();

                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c35_5 = new PdfPCell(new Phrase(Width_MM_Convstr2, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));
                            PdfPCell c37 = new PdfPCell(new Phrase(Punching_Optstr, underlinBold));
                            PdfPCell c38 = new PdfPCell(new Phrase(Pasting_Optstr, underlinBold));

                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c35_5.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;
                            c37.BorderColor = BaseColor.WHITE;
                            c38.BorderColor = BaseColor.WHITE;

                            t5.AddCell(c1_1);
                            t5.AddCell(c1);
                            t5.AddCell(c32);
                            t5.AddCell(c33);
                            t5.AddCell(c34);
                            t5.AddCell(c35);
                            t5.AddCell(c35_5);
                            t5.AddCell(c36);
                            t5.AddCell(c37);
                            t5.AddCell(c38);

                            doc.Add(t5);
                            LineSeparator line5 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line5));
                        }
                        #endregion


                        #region GRID 6
                        //Itemg Grid6
                        PdfPTable t6 = new PdfPTable(10);
                        //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                        //t3.SetWidths(widthst3);
                        t6.DefaultCell.BorderWidth = 0;
                        t6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t6.DefaultCell.BorderColor = BaseColor.WHITE;
                        t6.WidthPercentage = 100;
                        // t4.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        PdfPCell Rate_Type = new PdfPCell(new Phrase("Rate Type", underlinBold));
                        PdfPCell Excise_Code = new PdfPCell(new Phrase("Excise Code", underlinBold));
                        PdfPCell Top_BF = new PdfPCell(new Phrase("Top BF", underlinBold));
                        PdfPCell Top_GSM = new PdfPCell(new Phrase("Top GSM", underlinBold));
                        PdfPCell Top_WPP = new PdfPCell(new Phrase("Top WPP", underlinBold));
                        PdfPCell Top_BFPP = new PdfPCell(new Phrase("Top BFPP", underlinBold));
                        PdfPCell Weight_Pcs = new PdfPCell(new Phrase("Weight Per Pcs", underlinBold));
                        PdfPCell BF_Pcs = new PdfPCell(new Phrase("BF Per Pcs", underlinBold));
                        PdfPCell ArtWrk_Code = new PdfPCell(new Phrase("Art Work Code", underlinBold));
                        PdfPCell Revi_No = new PdfPCell(new Phrase("Revision No", underlinBold));

                        Rate_Type.BorderColor = BaseColor.WHITE;
                        Excise_Code.BorderColor = BaseColor.WHITE;
                        Top_BF.BorderColor = BaseColor.WHITE;
                        Top_GSM.BorderColor = BaseColor.WHITE;
                        Top_WPP.BorderColor = BaseColor.WHITE;
                        Top_BFPP.BorderColor = BaseColor.WHITE;
                        Weight_Pcs.BorderColor = BaseColor.WHITE;
                        BF_Pcs.BorderColor = BaseColor.WHITE;
                        ArtWrk_Code.BorderColor = BaseColor.WHITE;
                        Revi_No.BorderColor = BaseColor.WHITE;

                        t6.AddCell(Rate_Type);
                        t6.AddCell(Excise_Code);
                        t6.AddCell(Top_BF);
                        t6.AddCell(Top_GSM);
                        t6.AddCell(Top_WPP);
                        t6.AddCell(Top_BFPP);
                        t6.AddCell(Weight_Pcs);
                        t6.AddCell(BF_Pcs);
                        t6.AddCell(ArtWrk_Code);
                        t6.AddCell(Revi_No);

                        foreach (DataGridViewRow rows in dataGridView6.Rows)
                        {
                            string Length_MMstr = dataGridView6.Rows[rows.Index].Cells["Rate_Type"].Value.ToString();
                            string Width_MMstr = dataGridView6.Rows[rows.Index].Cells["Excise_Code"].Value.ToString();

                            string Height_MMstr = dataGridView6.Rows[rows.Index].Cells["Top_BF"].Value.ToString();
                            string Dimn_Optstr = dataGridView6.Rows[rows.Index].Cells["Top_GSM"].Value.ToString();
                            string Length_MM_Convstr = dataGridView6.Rows[rows.Index].Cells["Top_WPP"].Value.ToString();
                            string Width_MM_Convstr = dataGridView6.Rows[rows.Index].Cells["Top_BFPP"].Value.ToString();
                            string Width_MM_Convstr2 = dataGridView6.Rows[rows.Index].Cells["Weight_Pcs"].Value.ToString();
                            string Height_MM_Convstr = dataGridView6.Rows[rows.Index].Cells["BF_Pcs"].Value.ToString();
                            string Punching_Optstr = dataGridView6.Rows[rows.Index].Cells["ArtWrk_Code"].Value.ToString();
                            string Pasting_Optstr = dataGridView6.Rows[rows.Index].Cells["Revi_No"].Value.ToString();

                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c35_5 = new PdfPCell(new Phrase(Width_MM_Convstr2, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));
                            PdfPCell c37 = new PdfPCell(new Phrase(Punching_Optstr, underlinBold));
                            PdfPCell c38 = new PdfPCell(new Phrase(Pasting_Optstr, underlinBold));

                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c35_5.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;
                            c37.BorderColor = BaseColor.WHITE;
                            c38.BorderColor = BaseColor.WHITE;

                            t6.AddCell(c1_1);
                            t6.AddCell(c1);
                            t6.AddCell(c32);
                            t6.AddCell(c33);
                            t6.AddCell(c34);
                            t6.AddCell(c35);
                            t6.AddCell(c35_5);
                            t6.AddCell(c36);
                            t6.AddCell(c37);
                            t6.AddCell(c38);

                            doc.Add(t6);
                            LineSeparator line5 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line5));
                        }
                        #endregion


                        #region GRID 7
                        //Itemg Grid7
                        PdfPTable t7 = new PdfPTable(8);
                        //float[] widthst3 = new float[] { 1.5f, 1.5f, 1.5f, 1.5f, 1f, 1.1f, 1.1f };
                        //t3.SetWidths(widthst3);
                        t7.DefaultCell.BorderWidth = 0;
                        t7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        t7.DefaultCell.BorderColor = BaseColor.WHITE;
                        t7.WidthPercentage = 100;
                        // t4.SpacingAfter = 4f;
                        //t1.HorizontalAlignment = Element.ALIGN_RIGHT;

                        PdfPCell Art_Dt = new PdfPCell(new Phrase("Art Dt", underlinBold));
                        PdfPCell Speci_Code = new PdfPCell(new Phrase("Specification Code", underlinBold));
                        PdfPCell For_Pedilite = new PdfPCell(new Phrase("For Pedilite", underlinBold));
                        PdfPCell Pedilite_BS = new PdfPCell(new Phrase("BS", underlinBold));
                        PdfPCell Pedilite_GSM = new PdfPCell(new Phrase("GSM", underlinBold));
                        PdfPCell Pedilite_WtBox = new PdfPCell(new Phrase("Weightt of Box", underlinBold));
                        PdfPCell Pedilite_PReq = new PdfPCell(new Phrase("Purchase Requirement", underlinBold));
                        PdfPCell I_Lock = new PdfPCell(new Phrase("Lock", underlinBold));

                        Art_Dt.BorderColor = BaseColor.WHITE;
                        Speci_Code.BorderColor = BaseColor.WHITE;
                        For_Pedilite.BorderColor = BaseColor.WHITE;
                        Pedilite_BS.BorderColor = BaseColor.WHITE;
                        Pedilite_GSM.BorderColor = BaseColor.WHITE;
                        Pedilite_WtBox.BorderColor = BaseColor.WHITE;
                        Pedilite_PReq.BorderColor = BaseColor.WHITE;
                        I_Lock.BorderColor = BaseColor.WHITE;

                        t7.AddCell(Art_Dt);
                        t7.AddCell(Speci_Code);
                        t7.AddCell(For_Pedilite);
                        t7.AddCell(Pedilite_BS);
                        t7.AddCell(Pedilite_GSM);
                        t7.AddCell(Pedilite_WtBox);
                        t7.AddCell(Pedilite_PReq);
                        t7.AddCell(I_Lock);

                        foreach (DataGridViewRow rows in dataGridView7.Rows)
                        {
                            //'',,,,,,,
                            string Length_MMstr = dataGridView7.Rows[rows.Index].Cells["Art_Dt"].Value.ToString();
                            string Width_MMstr = dataGridView7.Rows[rows.Index].Cells["Speci_Code"].Value.ToString();

                            string Height_MMstr = dataGridView7.Rows[rows.Index].Cells["For_Pedilite"].Value.ToString();
                            string Dimn_Optstr = dataGridView7.Rows[rows.Index].Cells["Pedilite_BS"].Value.ToString();
                            string Length_MM_Convstr = dataGridView7.Rows[rows.Index].Cells["Pedilite_GSM"].Value.ToString();
                            string Width_MM_Convstr = dataGridView7.Rows[rows.Index].Cells["Pedilite_WtBox"].Value.ToString();
                            string Width_MM_Convstr2 = dataGridView7.Rows[rows.Index].Cells["Pedilite_PReq"].Value.ToString();
                            string Height_MM_Convstr = dataGridView7.Rows[rows.Index].Cells["I_Lock"].Value.ToString();

                            PdfPCell c1_1 = new PdfPCell(new Phrase(Length_MMstr, underlinBold));
                            PdfPCell c1 = new PdfPCell(new Phrase(Width_MMstr, underlinBold));

                            PdfPCell c32 = new PdfPCell(new Phrase(Height_MMstr, underlinBold));
                            PdfPCell c33 = new PdfPCell(new Phrase(Dimn_Optstr, underlinBold));
                            PdfPCell c34 = new PdfPCell(new Phrase(Length_MM_Convstr, underlinBold));
                            PdfPCell c35 = new PdfPCell(new Phrase(Width_MM_Convstr, underlinBold));
                            PdfPCell c35_5 = new PdfPCell(new Phrase(Width_MM_Convstr2, underlinBold));
                            PdfPCell c36 = new PdfPCell(new Phrase(Height_MM_Convstr, underlinBold));

                            c1_1.BorderColor = BaseColor.WHITE;
                            c1.BorderColor = BaseColor.WHITE;
                            c32.BorderColor = BaseColor.WHITE;
                            c33.BorderColor = BaseColor.WHITE;
                            c34.BorderColor = BaseColor.WHITE;
                            c35.BorderColor = BaseColor.WHITE;
                            c35_5.BorderColor = BaseColor.WHITE;
                            c36.BorderColor = BaseColor.WHITE;

                            t7.AddCell(c1_1);
                            t7.AddCell(c1);
                            t7.AddCell(c32);
                            t7.AddCell(c33);
                            t7.AddCell(c34);
                            t7.AddCell(c35);
                            t7.AddCell(c35_5);
                            t7.AddCell(c36);
                            doc.Add(t7);
                            LineSeparator line5 = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                            doc.Add(new Chunk(line5));
                        }
                        #endregion

                    }
                    catch (DocumentException ex)
                    {
                        //Handle document exception
                        MessageBox.Show("The was DocumentException error While creating PDF " + ex.Message);
                    }
                    catch (IOException ex)
                    {
                        //Handle IO exception
                        MessageBox.Show("The was IOException error While creating PDF " + ex.Message);
                    }
                    catch (Exception)
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
            catch (IOException ex)
            {                
                MessageBox.Show("The was IOException error While Printing PDF " + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
