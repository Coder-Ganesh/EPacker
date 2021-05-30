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
using System.Net;

namespace ePacker1
{
    public partial class PurchaseItemOut : Form
    {
        private FunctionLib funclib;
        string session, Group_ID, Si_outid, strsiid1, stripAssress, strCuStock, strMinLevel, strDiff, strCurrentStock, strsiid, strPurCurrentStock, NewCurrentStock, outQty, strstock;

        public PurchaseItemOut()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            monthCalendar1.Visible = false;
            monthCalendar2.Visible = false;
            monthCalendar3.Visible = false;
            cmddelTemp.Visible = false;
            funclib = new FunctionLib();
            string strcon6 = funclib.setConnection();
            SqlConnection con9 = new SqlConnection(strcon6);
            SqlCommand cmd9 = new SqlCommand("delete from Purchase_ItemOut_Det_Temp where Add_By='" + session + "'", con9);
            con9.Open();
            int n = cmd9.ExecuteNonQuery();
            con9.Close();
        }

        private void PurchaseItemOut_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strcon);
                con1.Open();
                //Displayig PurchaseItem in Grid Combo field
                SqlDataAdapter da = new SqlDataAdapter("SELECT SI_ID,SI_Name from Purchase_Item where SI_Active='Yes' and SI_ID not in (select SI_ID from Purchase_ItemIn_Det_Temp where Add_By='" + session + "')", con1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GlobalFunctions.AddPleaseSelect(ref dt);
                ddlSI_ID.DataSource = dt;
                ddlSI_ID.DisplayMember = dt.Columns[1].ToString();
                ddlSI_ID.ValueMember = dt.Columns[0].ToString();
                con1.Close();
                filldata();
                fillGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while  loading the page " + ex.Message);
            }
        }

        private void filldata()
        {
            try
            {
                //to fill the grid with user details
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select a.SI_ID,b.SI_Name as PurchaseItem,a.SI_CuStock as CuStock,a.SI_OutQty as Quantity from Purchase_Item as b,Purchase_ItemOut_Det_Temp as a where a.SI_ID=b.SI_ID and SI_Active='Yes'", con4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                PurchaseItemOut_Temp.DataSource = dt;
                this.PurchaseItemOut_Temp.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading data " + ex.Message);
            }
        }

        private void fillGrid()
        {
            try
            {
                //to fill the grid with user details
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                //SqlDataAdapter da = new SqlDataAdapter(" select * from dbo.Purchase_ItemOut_Det", con4);
                SqlDataAdapter da = new SqlDataAdapter(" SELECT a.SIOut_ID as OutwardNo,a.SIOut_Dt as OutwardDate,d.Grp_Name as Groups,C.SI_Name,b.SI_OutQty as Quantity from Purchase_ItemOut as a,Purchase_ItemOut_Det as b,Purchase_Item AS C,Group_Master AS d where a.SIOut_ID=b.SIOut_ID AND B.SI_ID=C.SI_ID and a.Grp_ID=d.Grp_ID", con4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPurchaseItemOut.DataSource = dt;
                this.dgvPurchaseItemOut.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading grid " + ex.Message);
            }
        }

        private void ddlSI_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSI_ID.SelectedIndex == 0)
            {
                clearall();
            }
            else
            {
                funclib = new FunctionLib();
                string strcon1 = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon1);
                SqlCommand cmd2 = new SqlCommand("select SI_CuStock,SI_ID from Purchase_Item where SI_ID='" + ddlSI_ID.SelectedValue.ToString() + "'", con);
                con.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    strCurrentStock = Convert.ToString(dr["SI_CuStock"]);
                    strsiid = Convert.ToString(dr["SI_ID"]);
                }
                con.Close();
            }
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSI_ID.SelectedIndex == 0)//Checking for blnk PinCode field
                {
                    MessageBox.Show("Please Select Purchase Item");
                    ddlSI_ID.Focus();
                }
                if (string.IsNullOrEmpty(txtSIOut_Dt.Text))//Checking for blnk Mobile field
                {
                    MessageBox.Show("Please Select Date");
                    txtSIOut_Dt.Focus();
                }
                else
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    if (MessageBox.Show("Do you wish to add this record ? Please check as no changes will be allowed later.", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string year = Convert.ToString(System.DateTime.Now.Year);
                        year = year + "SIO";
                        //Inserting Details into table
                        Si_outid = funclib.PurchYear(year, con, "select SIOut_ID  from Purchase_ItemOut order by SIOut_ID  desc");
                        txtSIOut_ID.Text = Si_outid;
                        SqlCommand cmd = new SqlCommand("insert into Purchase_ItemOut(SIOut_ID,Grp_ID,SIOut_Dt,SIOut_Active,Add_By,Add_ByNode,Add_On) values('" + txtSIOut_ID.Text + "','" + Group_ID + "',Convert(datetime,'" + txtSIOut_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'Yes','" + session + "','',convert(datetime,getdate(),103))", con);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        funclib = new FunctionLib();
                        string strcon2 = funclib.setConnection();
                        SqlConnection con1 = new SqlConnection(strcon2);
                        SqlCommand cmd3 = new SqlCommand("select SI_ID,SI_CuStock,SI_OutQty from Purchase_ItemOut_Det_Temp where Add_By='" + session + "'", con1);
                        con1.Open();
                        SqlDataReader dr1 = cmd3.ExecuteReader();
                        while (dr1.Read())
                        {
                            strsiid1 = Convert.ToString(dr1["SI_ID"]);
                            strstock = Convert.ToString(dr1["SI_CuStock"]);
                            outQty = Convert.ToString(dr1["SI_OutQty"]);
                            funclib = new FunctionLib();
                            string strcon3 = funclib.setConnection();
                            SqlConnection con2 = new SqlConnection(strcon3);
                            SqlCommand cmd6 = new SqlCommand("select SI_CuStock from Purchase_Item where SI_ID='" + strsiid1 + "'", con2);
                            con2.Open();
                            SqlDataReader dr4 = cmd6.ExecuteReader();
                            if (dr4.Read())
                            {
                                strPurCurrentStock = Convert.ToString(dr4["SI_CuStock"]);
                                NewCurrentStock = Convert.ToString(Math.Round(Convert.ToDecimal(strPurCurrentStock), 2) - Math.Round(Convert.ToDecimal(outQty), 2));
                            }
                            dr4.Close();
                            con2.Close();
                            //Insert Into Purchase_ItemOut_Det
                            funclib = new FunctionLib();
                            string strcon4 = funclib.setConnection();
                            SqlConnection con3 = new SqlConnection(strcon4);
                            SqlCommand cmd5 = new SqlCommand("insert into Purchase_ItemOut_Det(SIOut_ID,SI_ID,SI_CuStock,SI_OutQty) values('" + txtSIOut_ID.Text + "','" + strsiid1 + "','" + strstock + "','" + outQty + "')", con3);
                            con3.Open();
                            int k = cmd5.ExecuteNonQuery();
                            con3.Close();
                            //Delete record from Purchase_Itemout_Det_Temp
                            funclib = new FunctionLib();
                            string strcon6 = funclib.setConnection();
                            SqlConnection con9 = new SqlConnection(strcon6);
                            SqlCommand cmd9 = new SqlCommand("delete from Purchase_ItemOut_Det_Temp where Add_By='" + session + "'", con9);
                            con9.Open();
                            int n = cmd9.ExecuteNonQuery();
                            con9.Close();
                            //Update CuStock of Purchase_Item
                            funclib = new FunctionLib();
                            string strcon5 = funclib.setConnection();
                            SqlConnection con4 = new SqlConnection(strcon5);
                            SqlCommand cmd7 = new SqlCommand("update Purchase_Item set SI_CuStock='" + NewCurrentStock + "' where SI_ID='" + strsiid1 + "'", con4);
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
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while inserting data " + ex.Message);
            }          
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Visible = true;
            monthCalendar1.MaxDate = System.DateTime.Now;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSIOut_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            monthCalendar1.MaxDate = System.DateTime.Now;
            txtSIOut_Dt.Focus();
        }

        private void cmdTemp_Submit_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon1 = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon1);
            if (ddlSI_ID.SelectedIndex == 0)//Checking for blnk PinCode field
            {
                MessageBox.Show("Please Select Purchase Item");
                ddlSI_ID.Focus();
            }
            else if (txtSI_OutQty.Text == "")//Checking for blnk BirthPlace field
            {
                MessageBox.Show("Enter Quantity");
                txtSI_OutQty.Focus();
            }
            else
            {
                funclib = new FunctionLib();
                //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                string strcon = funclib.setConnection();
                SqlConnection con5 = new SqlConnection(strcon);
                //con.Open();
                SqlCommand cmd2 = new SqlCommand("select SI_CuStock,SI_MinLev from Purchase_Item where SI_ID='" + ddlSI_ID.SelectedValue.ToString() + "' ", con5);
                con5.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    strCuStock = Convert.ToString(dr["SI_CuStock"]);
                    strMinLevel = Convert.ToString(dr["SI_MinLev"]);
                }
                dr.Close();
                con5.Close();
                strDiff = Convert.ToString(Math.Round(Convert.ToDecimal(strCuStock), 2) - Math.Round(Convert.ToDecimal(strMinLevel), 2));
                if (Convert.ToDouble(txtSI_OutQty.Text) <= Convert.ToDouble(strDiff))
                {
                    double flag = funclib.isThere(con, "select SI_ID from Purchase_ItemOut_Det_Temp where  SI_ID='" + ddlSI_ID.SelectedValue.ToString() + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Purchase Item is not allowed");
                    }
                    else
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Purchase_ItemOut_Det_Temp(Add_By,SI_ID,SI_CuStock,SI_OutQty) values('" + session + "','" + strsiid + "','" + strCurrentStock + "','" + txtSI_OutQty.Text + "')", con);
                        con.Open();
                        int i = cmd1.ExecuteNonQuery();
                        con.Close();
                    }
                   //clearall1();
                    filldata();
                }
                else
                {
                    MessageBox.Show("Sorry, cannot issue Purchase Item as insufficient stock available.");
                }
            }
        }

        private void PurchaseItemOut_Temp_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdTemp_Submit.Visible = false;
            cmddelTemp.Visible = true;
            ddlSI_ID.Text = PurchaseItemOut_Temp.Rows[e.RowIndex].Cells[0].Value.ToString();
            string strSI_Name = PurchaseItemOut_Temp.Rows[e.RowIndex].Cells[1].Value.ToString();
            string strSI_CuStock = PurchaseItemOut_Temp.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSI_OutQty.Text = PurchaseItemOut_Temp.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlSI_ID.Enabled = false;
        }

        private void cmddelTemp_Click(object sender, EventArgs e)
        {
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from Purchase_ItemOut_Det_Temp where SI_ID ='" + ddlSI_ID.SelectedValue.ToString() + "'", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted");
            filldata();
            clearall1();
            cmdTemp_Submit.Visible = true;
            cmddelTemp.Visible = false;
            ddlSI_ID.Enabled = true;
        }

        private void txtSIOut_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            txtSIOut_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = true;
            monthCalendar1.MaxDate = System.DateTime.Now;
        }

        private void txtSIOut_Dt_Leave(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar2.Visible = true;
            monthCalendar2.MaxDate = System.DateTime.Now;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDateFrom.Text = monthCalendar2.SelectionStart.ToShortDateString();
            monthCalendar2.Visible = false;
            monthCalendar2.MaxDate = System.DateTime.Now;
            txtDateFrom.Focus();
        }

        private void txtDateFrom_Click(object sender, EventArgs e)
        {
            txtDateFrom.Text = monthCalendar2.SelectionStart.ToShortDateString();
            monthCalendar2.Visible = true;
            monthCalendar2.MaxDate = System.DateTime.Now;
        }

        private void txtDateFrom_Leave(object sender, EventArgs e)
        {
            monthCalendar2.Visible = false;
        }

        private void monthCalendar3_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar3.Visible = true;
            monthCalendar3.MaxDate = System.DateTime.Now;
        }

        private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDateTo.Text = monthCalendar3.SelectionStart.ToShortDateString();
            monthCalendar3.Visible = false;
            monthCalendar3.MaxDate = System.DateTime.Now;
            txtDateTo.Focus();
        }

        private void txtDateTo_Click(object sender, EventArgs e)
        {
            txtDateTo.Text = monthCalendar3.SelectionStart.ToShortDateString();
            monthCalendar3.Visible = true;
            monthCalendar3.MaxDate = System.DateTime.Now;
        }

        private void txtDateTo_Leave(object sender, EventArgs e)
        {
            monthCalendar3.Visible = false;
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearall();
            clearall1();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void clearall1()
        {
            ddlSI_ID.SelectedIndex = 0;
            txtSI_OutQty.Text = "";
        }

        protected void clearall()
        {
            ddlGrp_ID.Text = "";
            txtSIOut_Dt.Text = "";
            txtSIOut_ID.Text = "";
            ddlSI_ID.Enabled = true;
            ddlSI_ID.SelectedIndex = 0;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (txtDateFrom.Text == "")//Checking for blnk PinCode field
            {
                MessageBox.Show("Please Select From Date");
                txtDateFrom.Focus();
            }
            else if (txtDateTo.Text == "")//Checking for blnk BirthPlace field
            {
                MessageBox.Show("Please Select To Date");
                txtDateTo.Focus();
            }
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("SELECT a.SIOut_ID as OutwardNo,a.SIOut_Dt as OutwardDate,d.Grp_Name as Groups,C.SI_Name,b.SI_OutQty as Quantity from Purchase_ItemOut as a,Purchase_ItemOut_Det as b,Purchase_Item AS C,Group_Master AS d where a.SIOut_Dt between  convert(datetime,'" + txtDateFrom.Text + "',103) and convert(datetime,'" + txtDateTo.Text + "',103) and a.SIOut_ID=b.SIOut_ID AND B.SI_ID=C.SI_ID and a.Grp_ID=d.Grp_ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPurchaseItemOut.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

    }
}

