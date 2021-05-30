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
namespace ePacker1
{
    public partial class RPeP_ScoringSloting : Form
    {
        string session, strSQL, Group_ID, SR_ID, SubOrder, SubItem_Of;
        private FunctionLib funclib;
        public RPeP_ScoringSloting()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_ScoringSloting_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Displaying Active Values 
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            monthCalendar1.Visible = false;



            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);


            SR_ID = funclib.PSPI_ID("PSSC", con, "select PSSC_ID  from Scoring_Details order by PSSC_ID desc");
            txtPSSC_ID.Text = SR_ID;

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as S_ID, '' as S_Name UNION select  S_ID,S_Name from Shift_Master where S_Active='Yes'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlS_ID.DataSource = dt;
            ddlS_ID.DisplayMember = dt.Columns[1].ToString();
            ddlS_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as M_ID, '' as M_Name UNION select  M_ID,M_Name from Machine_Master where M_Active='Yes' and Grp_ID='" + Group_ID + "'", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Open();
            ddlM_ID.DataSource = dt2;
            ddlM_ID.DisplayMember = dt2.Columns[1].ToString();
            ddlM_ID.ValueMember = dt2.Columns[0].ToString();
            con.Close();

        }

        private void txtPSCA_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtPSSC_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtPSSC_Dt.Focus();
        }

        private void cmdOrderSearch_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Order_ID UNION select Order_ID from Item_Order where I_ID in (select I_ID from Item_Master where Scoring_Opt='Yes' or Slotting_Opt='Yes') and Order_ID not in (select Order_ID from Scoring_Details) and Order_Active='Yes' and Grp_ID='" + Group_ID + "' and Order_ID like '%" + txtorderSearch.Text + "%'", con);
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
            ////funclib = new FunctionLib();
            ////string strcon = funclib.setConnection();
            ////SqlConnection con1 = new SqlConnection(strcon);

            ////SqlCommand cmd = new SqlCommand("select a.Side_Canvas from dbo.Item_Master as a,Item_Order as b where a.I_ID=b.I_ID and b.Order_ID='" + ddlOrder_ID.SelectedValue.ToString() + "' ", con1);
            ////con1.Open();
            ////SqlDataReader dr = cmd.ExecuteReader();
            ////if (dr.Read())
            ////{

            ////    txtPSSC_NoPins.Text = Convert.ToString(dr["Side_Canvas"]);

            ////}


            ////dr.Close();
            ////con1.Close();
        }

        private void txtPSCA_BoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtPSCA_Side_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);

        }

        private void txtPSCA_ContrTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtPSSC_ID.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Sr No Cannot be Blank");
                txtPSSC_ID.Focus();
            }

            else if (txtPSSC_Dt.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSSC_Dt.Focus();
            }
            else if (ddlOrder_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlOrder_ID.Focus();
            }
            else if (txtPSSC_BoxQty.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSSC_BoxQty.Focus();

            }
            else if (txtPSSC_NoPins.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSSC_NoPins.Focus();
            }
            else if (ddlM_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlM_ID.Focus();
            }


            else if (txtPSSC_Mfg.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSSC_Mfg.Focus();
            }
            else if (txtPSSC_ContrTime.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSSC_ContrTime.Focus();
            }
            else if (ddlS_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlS_ID.Focus();
            }



            else
            {


                funclib = new FunctionLib();
                //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlConnection con1 = new SqlConnection(strcon);


                //Inserting records 


                SqlCommand cmdPositive = new SqlCommand("insert into Scoring_Details(PSSC_ID,Grp_ID,PSSC_Dt,Order_ID,M_ID,PSSC_BoxQty,PSSC_NoPins,PSSC_Mfg,S_ID,PSSC_ContrTime,Add_By,Add_ByNode,Add_On) values('" + txtPSSC_ID.Text.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "',convert(datetime,'" + txtPSSC_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlOrder_ID.SelectedValue.ToString() + "','" + ddlM_ID.SelectedValue.ToString() + "','" + txtPSSC_BoxQty.Text.Trim().Replace("'", "''").ToString() + "','" + txtPSSC_NoPins.Text.Trim().Replace("'", "''").ToString() + "','" + txtPSSC_Mfg.Text.Trim().Replace("'", "''").ToString() + "','" + ddlS_ID.SelectedValue.ToString() + "','" + txtPSSC_ContrTime.Text.Trim().Replace("'", "''").ToString() + "','" + session + "','',convert(datetime,getdate(),103))", con);
                con.Open();
                int Positive = cmdPositive.ExecuteNonQuery();
                MessageBox.Show("Record Inserted");
                con.Close();
                clearAll();
                fillGrid();

            }
        }
        protected void clearAll()
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);



            SR_ID = funclib.PSPI_ID("PSSC", con, "select PSSC_ID  from Scoring_Details order by PSSC_ID desc");
            txtPSSC_ID.Text = SR_ID;

            txtorderSearch.Text = "";
            txtPSSC_BoxQty.Text = "";

            txtPSSC_ContrTime.Text = "";
            txtPSSC_Dt.Text = "";
            txtPSSC_Mfg.Text = "";
            txtPSSC_NoPins.Text = "";
            ddlM_ID.Text = "";
            ddlOrder_ID.Text = "";
            ddlS_ID.Text = "";
            ddlOrder_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlOrder_ID.Enabled = true;
            txtPSSC_Dt.Enabled = true;
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

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
                SqlCommand cmd = new SqlCommand("update Scoring_Details set M_ID ='" + ddlM_ID.SelectedValue.ToString() + "',PSSC_BoxQty = '" + txtPSSC_BoxQty.Text.Trim().Replace("'", "''").ToString() + "',PSSC_NoPins = '" + txtPSSC_NoPins.Text.Trim().Replace("'", "''").ToString() + "',PSSC_Mfg = '" + txtPSSC_Mfg.Text.Trim().Replace("'", "''").ToString() + "',S_ID = '" + ddlS_ID.SelectedValue.ToString() + "',PSSC_ContrTime = '" + txtPSSC_ContrTime.Text.Trim().Replace("'", "''").ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where PSSC_ID  ='" + txtPSSC_ID.Text.Trim().Replace("'", "''").ToString() + "'", con);

                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                con.Close();

                fillGrid();
                clearAll();
            }

        }

        private void CmdSearch_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter(" select PSSC_ID,convert (varchar(20),PSSC_Dt,103) as 'Date',Order_ID as 'Order No',a.M_ID,b.M_Name as 'Machine',PSSC_BoxQty as 'Box Qty',PSSC_NoPins as 'No of Pins',PSSC_Mfg as 'Manufacturing',a.S_ID,c.S_Name as 'Shift',PSSC_ContrTime as 'Contact time' from Scoring_Details as a,Machine_Master as b,Shift_Master as c where a.M_ID=b.M_ID and a.S_ID=c.S_ID and a.Order_ID like '%" + txt_Search.Text.ToString() + "%' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.Columns[0].Visible = false;
            GridView1.Columns[3].Visible = false;
            GridView1.Columns[8].Visible = false;

        }
        protected void fillGrid()
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter(" select PSSC_ID,convert (varchar(20),PSSC_Dt,103) as 'Date',Order_ID as 'Order No',a.M_ID,b.M_Name as 'Machine',PSSC_BoxQty as 'Box Qty',PSSC_NoPins as 'No of Pins',PSSC_Mfg as 'Manufacturing',a.S_ID,c.S_Name as 'Shift',PSSC_ContrTime as 'Contact time' from Scoring_Details as a,Machine_Master as b,Shift_Master as c where a.M_ID=b.M_ID and a.S_ID=c.S_ID and a.Order_ID like '%" + txt_Search.Text.ToString() + "%' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.Columns[0].Visible = false;
            GridView1.Columns[3].Visible = false;
            GridView1.Columns[8].Visible = false;

        }
        private void GridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;

            txtPSSC_Dt.Enabled = false;
            ddlOrder_ID.Enabled = false;
            // ddlM_ID.Enabled = false;

            txtPSSC_ID.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPSSC_Dt.Text = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            ddlOrder_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlOrder_ID.Text = GridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            // ddlM_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlM_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPSSC_BoxQty.Text = GridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPSSC_NoPins.Text = GridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            txtPSSC_Mfg.Text = GridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            ddlS_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            txtPSSC_ContrTime.Text = GridView1.Rows[e.RowIndex].Cells[10].Value.ToString();



        }
    }
}

