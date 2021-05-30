
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
    public partial class RPeP_PlanningMachine : Form
    {
        string session, strSQL, Group_ID, SR_ID, SubOrder, SubItem_Of;
        private FunctionLib funclib;
        public RPeP_PlanningMachine()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

      
        private void RPeP_PlanningMachine_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Displaying Active Values 
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            monthCalendar1.Visible = false;



            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);


            SR_ID = funclib.PSPI_ID("PSPM", con, "select PSPM_ID  from ProductionMachine_Details order by PSPM_ID desc");
            txtPSST_ID.Text = SR_ID;

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as M_ID, '' as M_Name UNION select  M_ID,M_Name from Machine_Master where M_Active='Yes' and Grp_ID='" + Group_ID + "'", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Open();
            ddlM_ID.DataSource = dt2;
            ddlM_ID.DisplayMember = dt2.Columns[1].ToString();
            ddlM_ID.ValueMember = dt2.Columns[0].ToString();
            con.Close();

        }

        private void txtPSST_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void cmdOrderSearch_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Order_ID UNION select Order_ID from Item_Order where I_ID in (select I_ID from Item_Master) and Order_ID not in (select Order_ID from ProductionMachine_Details) and Order_Active='Yes' and Grp_ID='" + Group_ID + "' and Order_ID like '%" + txtorderSearch.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlOrder_ID.DataSource = dt;
            ddlOrder_ID.DisplayMember = dt.Columns[0].ToString();
            ddlOrder_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtPSST_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtPSST_Dt.Focus();
        }

        private void ddlOrder_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlConnection con1 = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as I_ID, '' as I_Name UNION select a.I_ID,a.I_Name from Item_Master as a,Item_Order as b where a.I_ID=b.I_ID and b.Order_ID ='" + ddlOrder_ID.SelectedValue.ToString() + "' and a.Grp_ID='" + Group_ID + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlI_ID.DataSource = dt;
            ddlI_ID.DisplayMember = dt.Columns[1].ToString();
            ddlI_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtPSST_ID.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Sr No Cannot be Blank");
                txtPSST_ID.Focus();
            }

            else if (txtPSST_Dt.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSST_Dt.Focus();
            }
            else if (ddlOrder_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlOrder_ID.Focus();
            }

            else if (ddlM_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlM_ID.Focus();
            }
            else if (ddlI_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlI_ID.Focus();
            }
            else if (txtPSPM_Type.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPM_Type.Focus();
            }




            else
            {


                funclib = new FunctionLib();
                //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlConnection con1 = new SqlConnection(strcon);


                //Inserting records 


                SqlCommand cmdPositive = new SqlCommand("insert into ProductionMachine_Details(PSPM_ID,Grp_ID,PSPM_Dt,Order_ID,I_ID,PSPM_Type,M_ID,Add_By,Add_ByNode,Add_On) values('" + txtPSST_ID.Text.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "',convert(datetime,'" + txtPSST_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlOrder_ID.SelectedValue.ToString() + "','" + ddlI_ID.SelectedValue.ToString() + "','" + txtPSPM_Type.Text.Trim().Replace("'", "''").ToString() + "','"+ddlM_ID.SelectedValue.ToString()+"','" + session + "','',convert(datetime,getdate(),103))", con);
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


            SR_ID = funclib.PSPI_ID("PSPM", con, "select PSPM_ID  from ProductionMachine_Details order by PSPM_ID desc");
            txtPSST_ID.Text = SR_ID;

            txtorderSearch.Text = "";



            txtPSST_Dt.Text = "";
            ddlM_ID.Text = "";
            txtPSPM_Type.Text = "";
            ddlI_ID.Text = "";
            ddlOrder_ID.Text = "";

            ddlOrder_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlI_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlOrder_ID.Enabled = true;
            txtPSST_Dt.Enabled = true;
            ddlI_ID.Enabled = true;
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;
          
            txtPSPM_Type.Text = "";
          

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
                SqlCommand cmd = new SqlCommand("update ProductionMachine_Details set PSPM_Type='"+txtPSPM_Type.Text.ToString()+"',M_ID='" + ddlM_ID.SelectedValue.ToString() + "', Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where PSPM_ID  ='" + txtPSST_ID.Text.Trim().Replace("'", "''").ToString() + "'", con);

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
            SqlDataAdapter da = new SqlDataAdapter(" select PSPM_ID,convert (varchar(20),PSPM_Dt,103) as 'Date',Order_ID as 'Order No',a.I_ID,b.I_Name as 'Item',PSPM_Type as 'Type',a.M_ID,c.M_Name as 'Machine' from ProductionMachine_Details as a,Item_Master as b,Machine_Master as c where a.I_ID=b.I_ID and a.M_ID=c.M_ID  and a.Order_ID like '%" + txt_Search.Text.ToString() + "%' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.Columns[0].Visible = false;
            GridView1.Columns[3].Visible = false;


        }
        protected void fillGrid()
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter(" select PSPM_ID,convert (varchar(20),PSPM_Dt,103) as 'Date',Order_ID as 'Order No',a.I_ID,b.I_Name as 'Item',PSPM_Type as 'Type',a.M_ID,c.M_Name as 'Machine' from ProductionMachine_Details as a,Item_Master as b,Machine_Master as c where a.I_ID=b.I_ID and a.M_ID=c.M_ID  and a.Order_ID like '%" + txt_Search.Text.ToString() + "%' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.Columns[0].Visible = false;
            GridView1.Columns[3].Visible = false;
            GridView1.Columns[6].Visible = false;


        }
        private void GridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;

            txtPSST_Dt.Enabled = false;
            ddlOrder_ID.Enabled = false;
            ddlI_ID.Enabled = false;
           // txtPSPM_Type.Enabled = false;

           

            txtPSST_ID.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPSST_Dt.Text = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            ddlOrder_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlOrder_ID.Text = GridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            ddlI_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlI_ID.Text = GridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            
            
            txtPSPM_Type.Text = GridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            ddlM_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[6].Value.ToString();





        }
   
    }
}

