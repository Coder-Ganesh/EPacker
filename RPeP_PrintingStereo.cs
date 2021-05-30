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
    public partial class RPeP_PrintingStereo : Form
    {
        string session, strSQL, Group_ID, SR_ID, SubOrder, SubItem_Of;
        private FunctionLib funclib;
        public RPeP_PrintingStereo()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_PrintingStereo_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Displaying Active Values 
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            monthCalendar1.Visible = false;



            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);


            SR_ID = funclib.PSPI_ID("PSPR", con, "select PSPR_ID  from Printing_Details order by PSPR_ID desc");
            txtPSPR_ID.Text = SR_ID;

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

        private void txtPSSC_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtPSPR_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtPSPR_Dt.Focus();
        }

        private void cmdOrderSearch_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Order_ID UNION select Order_ID from Item_Order where I_ID in (select I_ID from Item_Master where Printing_Opt='Yes') and Order_ID not in (select Order_ID from Printing_Details) and Order_Active='Yes' and Grp_ID='" + Group_ID + "' and Order_ID like '%" + txtorderSearch.Text + "%'", con);
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

            SqlCommand cmd = new SqlCommand("select a.No_Colors from dbo.Item_Master as a,Item_Order as b where a.I_ID=b.I_ID and b.Order_ID='" + ddlOrder_ID.SelectedValue.ToString() + "' ", con1);
            con1.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                txtPSPR_NoColrs.Text = Convert.ToString(dr["No_Colors"]);

            }


            dr.Close();
            con1.Close();
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
            if (txtPSPR_ID.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Sr No Cannot be Blank");
                txtPSPR_ID.Focus();
            }

            else if (txtPSPR_Dt.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPR_Dt.Focus();
            }
            else if (ddlOrder_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlOrder_ID.Focus();
            }
            else if (txtPSPR_Paper.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPR_Paper.Focus();

            }
            else if (txtPSPR_NoColrs.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPR_NoColrs.Focus();
            }
            else if (ddlM_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlM_ID.Focus();
            }


            else if (txtPSPR_Mfg.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPR_Mfg.Focus();
            }
            else if (txtPSPR_ContrTime.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPR_ContrTime.Focus();
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


                SqlCommand cmdPositive = new SqlCommand("insert into Printing_Details(PSPR_ID,Grp_ID,PSPR_Dt,Order_ID,M_ID,PSPR_Paper,PSPR_NoColrs,PSPR_Mfg,S_ID,PSPR_ContrTime,Add_By,Add_ByNode,Add_On) values('" + txtPSPR_ID.Text.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "',convert(datetime,'" + txtPSPR_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlOrder_ID.SelectedValue.ToString() + "','" + ddlM_ID.SelectedValue.ToString() + "','" + txtPSPR_Paper.Text.Trim().Replace("'", "''").ToString() + "','" + txtPSPR_NoColrs.Text.Trim().Replace("'", "''").ToString() + "','" + txtPSPR_Mfg.Text.Trim().Replace("'", "''").ToString() + "','" + ddlS_ID.SelectedValue.ToString() + "','" + txtPSPR_ContrTime.Text.Trim().Replace("'", "''").ToString() + "','" + session + "','',convert(datetime,getdate(),103))", con);
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



            SR_ID = funclib.PSPI_ID("PSPR", con, "select PSPR_ID  from Printing_Details order by PSPR_ID desc");
            txtPSPR_ID.Text = SR_ID;

            txtorderSearch.Text = "";
            txtPSPR_Paper.Text = "";

            txtPSPR_ContrTime.Text = "";
            txtPSPR_Dt.Text = "";
            txtPSPR_Mfg.Text = "";
            txtPSPR_NoColrs.Text = "";
            ddlM_ID.Text = "";
            ddlOrder_ID.Text = "";
            ddlS_ID.Text = "";
            ddlOrder_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlOrder_ID.Enabled = true;
            txtPSPR_Dt.Enabled = true;
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
                SqlCommand cmd = new SqlCommand("update Printing_Details set M_ID ='" + ddlM_ID.SelectedValue.ToString() + "',PSPR_Paper = '" + txtPSPR_Paper.Text.Trim().Replace("'", "''").ToString() + "',PSPR_NoColrs = '" + txtPSPR_NoColrs.Text.Trim().Replace("'", "''").ToString() + "',PSPR_Mfg = '" + txtPSPR_Mfg.Text.Trim().Replace("'", "''").ToString() + "',S_ID = '" + ddlS_ID.SelectedValue.ToString() + "',PSPR_ContrTime = '" + txtPSPR_ContrTime.Text.Trim().Replace("'", "''").ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where PSPR_ID  ='" + txtPSPR_ID.Text.Trim().Replace("'", "''").ToString() + "'", con);

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
            SqlDataAdapter da = new SqlDataAdapter(" select PSPR_ID,convert (varchar(20),PSPR_Dt,103) as 'Date',Order_ID as 'Order No',a.M_ID,b.M_Name as 'Machine',PSPR_Paper as 'Paper',PSPR_NoColrs as 'No of Colors',PSPR_Mfg as 'Manufacturing',a.S_ID,c.S_Name as 'Shift',PSPR_ContrTime as 'Contact time' from Printing_Details as a,Machine_Master as b,Shift_Master as c where a.M_ID=b.M_ID and a.S_ID=c.S_ID and a.Order_ID like '%" + txt_Search.Text.ToString() + "%' ", con);
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
            SqlDataAdapter da = new SqlDataAdapter(" select PSPR_ID,convert (varchar(20),PSPR_Dt,103) as 'Date',Order_ID as 'Order No',a.M_ID,b.M_Name as 'Machine',PSPR_Paper as 'Paper',PSPR_NoColrs as 'No of Colors',PSPR_Mfg as 'Manufacturing',a.S_ID,c.S_Name as 'Shift',PSPR_ContrTime as 'Contact time' from Printing_Details as a,Machine_Master as b,Shift_Master as c where a.M_ID=b.M_ID and a.S_ID=c.S_ID and a.Order_ID like '%" + txt_Search.Text.ToString() + "%' ", con);
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

            txtPSPR_Dt.Enabled = false;
            ddlOrder_ID.Enabled = false;
            // ddlM_ID.Enabled = false;

            txtPSPR_ID.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPSPR_Dt.Text = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            ddlOrder_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlOrder_ID.Text = GridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            // ddlM_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlM_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPSPR_Paper.Text = GridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPSPR_NoColrs.Text = GridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            txtPSPR_Mfg.Text = GridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            ddlS_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            txtPSPR_ContrTime.Text = GridView1.Rows[e.RowIndex].Cells[10].Value.ToString();



        }
    }
}

