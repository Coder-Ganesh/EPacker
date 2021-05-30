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


namespace ePacker1
{
    public partial class RPeP_PurchaseItemDmg : Form
    {
        string session, Group_ID;

        private FunctionLib funclib;
        string strCuStock, strDiff, strMinLevel;

        public RPeP_PurchaseItemDmg()
        {
            InitializeComponent();
            txtSI_CuStock.Enabled = false;
            monthCalendar1.Visible = false;
            cmdEdit.Visible = false;
            cmdSubmit.Visible = true;
            btnDelete.Visible = false;
            ddlSI_ID.Enabled = true;
            filldata();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_PurchaseItemDmg_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                funclib = new FunctionLib();
                string strCon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strCon);

                // displaying Item In Search Ddl
                con1.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT SI_ID,SI_Name from Purchase_Item where SI_Active ='Yes'", con1);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                GlobalFunctions.AddPleaseSelect(ref dt2);
                ddlItemSearch.DataSource = dt2;
                ddlItemSearch.DisplayMember = dt2.Columns[1].ToString();
                ddlItemSearch.ValueMember = dt2.Columns[0].ToString();
                con1.Close();

                ddlSI_ID.Text = "";
                txtSI_CuStock.Clear();
                con1.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT SI_ID,SI_Name from Purchase_Item where Grp_ID = '" + Group_ID + "' and SI_Active ='Yes' ", con1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                GlobalFunctions.AddPleaseSelect(ref dt1);
                ddlSI_ID.DataSource = dt1;
                ddlSI_ID.DisplayMember = dt1.Columns[1].ToString();
                ddlSI_ID.ValueMember = dt1.Columns[0].ToString();
                con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading page " + ex.Message);
            }          
        }

        private void txtSI_DmgQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void ddlSI_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSI_ID.SelectedIndex != 0)
            {
                funclib = new FunctionLib();
                string strCon = funclib.setConnection();
                SqlConnection con1 = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand("select SI_CuStock from Purchase_Item where SI_ID='" + ddlSI_ID.SelectedValue.ToString() + "' ", con1);
                con1.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtSI_CuStock.Text = Convert.ToString(dr["SI_CuStock"]);
                }
                dr.Close();
                con1.Close();
            }
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSIDmg_Dt.Text == "")//checking for PartyName  field 
                {
                    MessageBox.Show("Please Select Date");
                    txtSIDmg_Dt.Focus();
                }
                else if (ddlSI_ID.Text == "")//checking for blank name text field 
                {
                    MessageBox.Show("Please Select Item ");
                    ddlSI_ID.Focus();
                }
                else if (txtSI_CuStock.Text == "")//checking for blank Phone
                {
                    MessageBox.Show("Enter Current Stock");
                    txtSI_CuStock.Focus();
                }
                else if (txtSI_DmgQty.Text == "")
                {
                    MessageBox.Show("Please Enter Damage Quantity");
                    txtSI_DmgQty.Focus();
                }
                else if (txtSI_DmgNote.Text == "")
                {
                    MessageBox.Show("Please Enter Note");
                    txtSI_DmgNote.Focus();
                }
                else
                {
                    funclib = new FunctionLib();
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlCommand cmd2 = new SqlCommand("select SI_CuStock,SI_MinLev from Purchase_Item where SI_ID='" + ddlSI_ID.SelectedValue.ToString() + "' ", con);
                    con.Open();
                    SqlDataReader dr = cmd2.ExecuteReader();
                    if (dr.Read())
                    {
                        strCuStock = Convert.ToString(dr["SI_CuStock"]);
                        strMinLevel = Convert.ToString(dr["SI_MinLev"]);
                    }
                    dr.Close();
                    con.Close();
                    strDiff = Convert.ToString(Math.Round(Convert.ToDecimal(strCuStock), 2) - Math.Round(Convert.ToDecimal(strMinLevel), 2));
                    if (Convert.ToDouble(txtSI_DmgQty.Text) <= Convert.ToDouble(strDiff))
                    {
                        if (MessageBox.Show("Do you wish to add this record ? Editing is not allowed. Please re-check before confirmation", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //Checking for duplicate values
                            double flag = funclib.isThere(con, "select SI_ID,SIDmg_Dt,SI_DmgQty  from Purchase_ItemDmg where SI_ID='" + ddlSI_ID.SelectedValue.ToString() + "' and SIDmg_Dt= " + txtSIDmg_Dt.Text + " and SI_DmgQty='" + txtSI_DmgQty.Text + "'");
                            if (flag == 1)
                            {
                                MessageBox.Show("Cannot add this record as duplication of Item, Date and Quantity  is not allowed");
                            }
                            else
                            {
                                //Inserting records in Purchase_ItemDmg
                                string year = Convert.ToString(System.DateTime.Today.Year);
                                year = year + "SID";
                                string SID = funclib.PurchYear(year, con, "select SIDmg_ID from Purchase_ItemDmg order by SIDmg_ID desc");
                                txtSIDmg_ID.Text = SID;
                                SqlCommand cmdPositive = new SqlCommand("insert into Purchase_ItemDmg(SIDmg_ID,Grp_ID,SIDmg_Dt,SI_ID,SI_CuStock,SI_DmgQty,SI_DmgNote,Add_By,Add_ByNode,Add_On) values('" + txtSIDmg_ID.Text.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "',convert(datetime,'" + txtSIDmg_Dt.Text.ToString() + "',103),'" + ddlSI_ID.SelectedValue.ToString() + "','" + txtSI_CuStock.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_DmgQty.Text.Trim().Replace("'", "''").ToString() + "','" + txtSI_DmgNote.Text.Trim().Replace("'", "''").ToString() + "','" + session + "','',convert(datetime,getdate(),103))", con);
                                con.Open();
                                int Positive = cmdPositive.ExecuteNonQuery();
                                con.Close();
                                string NewSi_CuStock = Convert.ToString(Math.Round(Convert.ToDecimal(txtSI_CuStock.Text), 2) - Math.Round(Convert.ToDecimal(txtSI_DmgQty.Text), 2));
                                SqlCommand cmd = new SqlCommand("Update Purchase_Item set SI_CuStock='" + NewSi_CuStock + "',Mod_By='" + session + "',Mod_On=convert(datetime,getdate(),103) where SI_ID='" + ddlSI_ID.SelectedValue.ToString() + "' ", con);
                                con.Open();
                                int p = cmd.ExecuteNonQuery();
                                MessageBox.Show("Record Inserted");
                                con.Close();
                                filldata();
                                clearAll();
                                strDiff = "";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Damage Quantity Can Not Be More Than Minimum level Qty");
                        strDiff = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while inserting data " + ex.Message);
            }          
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            ddlGrp_ID.Text = "";
            ddlSI_ID.SelectedIndex = 0;
            txtSI_DmgNote.Clear();
            txtSI_CuStock.Clear();
            txtSI_DmgNote.Clear();
            txtSI_DmgQty.Clear();
            txtSIDmg_Dt.Clear();
            cmdEdit.Visible = false;
            cmdSubmit.Visible = true;
            btnDelete.Visible = false;
            ddlSI_ID.Enabled = true;
            txtSIDmg_Dt.Enabled = true;
            txtSI_CuStock.Enabled = true;
        }

        private void filldata()
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            //SqlDataAdapter da = new SqlDataAdapter("Select * from Purchase_ItemDmg ", con4);
            SqlDataAdapter da = new SqlDataAdapter("select a.SIDmg_ID,b.SI_Name as Item, a.SIDmg_Dt as DamageDate,a.SI_CuStock as CuStockBeforeDamageRecord,a.SI_DmgQty as DamageQty,a.SI_DmgNote as Note from  Purchase_ItemDmg as a,Purchase_Item as b where a.SI_ID=b.SI_ID ", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwRPeP_ItemDamage.DataSource = dt;
            // this.dgwRPeP_MasterParty.Columns[0].Visible = false; 
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (ddlItemSearch.SelectedIndex != 0)
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("select b.SI_Name as Item, a.SIDmg_Dt as DamageDate,a.SI_CuStock as CuStockBeforeDamageRecord,a.SI_DmgQty as DamageQty,a.SI_DmgNote as Note from  Purchase_ItemDmg as a,Purchase_Item as b where a.SI_ID ='" + ddlItemSearch.SelectedValue.ToString() + "' and a.SI_ID=b.SI_ID ", con4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgwRPeP_ItemDamage.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please select an Item for Search");
            }
        }

        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd2 = new SqlCommand("select SI_CuStock,SI_MinLev from Purchase_Item where SI_ID='" + ddlSI_ID.SelectedValue.ToString() + "' ", con);
                con.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    strCuStock = Convert.ToString(dr["SI_CuStock"]);
                    strMinLevel = Convert.ToString(dr["SI_MinLev"]);
                }
                dr.Close();
                con.Close();
                strDiff = Convert.ToString(Math.Round(Convert.ToDecimal(strCuStock), 2) - Math.Round(Convert.ToDecimal(strMinLevel), 2));
                if (Convert.ToDouble(txtSI_DmgQty.Text) <= Convert.ToDouble(strDiff))
                {
                    if (MessageBox.Show("Do you wish to Update this record", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string strCon = funclib.setConnection();
                        con.Open();
                        SqlCommand cmd = new SqlCommand("update Purchase_ItemDmg set SI_DmgQty='" + txtSI_DmgQty.Text + "', SI_DmgNote = '" + txtSI_DmgNote.Text + "',     Mod_By='" + session + "',Mod_On= convert(datetime,getdate(),103) where SIDmg_ID ='" + txtSIDmg_ID + "' and Grp_ID ='" + Group_ID + "'", con);
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Updated");
                        filldata();
                        clearAll();
                    }
                }
                else
                {
                    MessageBox.Show(" Damage Quantity Can Not Be More Than Minimum level Qty");
                    strDiff = "";
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
                if (MessageBox.Show("Do you wish to Delete this record", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string strCon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strCon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Purchase_ItemDmg where SIDmg_ID ='" + txtSIDmg_ID + "' ", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted");
                    filldata();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while Deleted Values " + ex.Message);
            }
        }

        private void txtSIDmg_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }
      
        private void dgwRPeP_ItemDamage_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //txtSIDmg_ID.Text = dgwRPeP_ItemDamage.Rows[e.RowIndex].Cells[0].Value.ToString();
            //ddlSI_ID.SelectedText = dgwRPeP_ItemDamage.Rows[e.RowIndex].Cells[1].Value.ToString();
            //txtSIDmg_Dt.Text = dgwRPeP_ItemDamage.Rows[e.RowIndex].Cells[2].Value.ToString();
            //txtSI_CuStock.Text = dgwRPeP_ItemDamage.Rows[e.RowIndex].Cells[3].Value.ToString();
            //txtSI_DmgQty.Text  = dgwRPeP_ItemDamage.Rows[e.RowIndex].Cells[4].Value.ToString();
            //txtSI_DmgNote.Text = dgwRPeP_ItemDamage.Rows[e.RowIndex].Cells[5].Value.ToString();

            //cmdEdit.Visible = true;
            //cmdSubmit.Visible = false;
            //btnDelete.Visible = true;
            //ddlSI_ID.Enabled = false;
            //txtSIDmg_Dt.Enabled = false;
            //txtSI_CuStock.Enabled = false;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtSIDmg_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            monthCalendar1.MaxDate = System.DateTime.Now;
            txtSIDmg_Dt.Focus();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Visible = true;
            monthCalendar1.MaxDate = System.DateTime.Now;
        }

        private void txtSIDmg_Dt_Leave(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
        }

    }
}
