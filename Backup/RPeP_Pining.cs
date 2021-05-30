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
    public partial class RPeP_Pining : Form
    {
        string session, strSQL, Group_ID, SR_ID, SubOrder, SubItem_Of;
        private FunctionLib funclib;
        public RPeP_Pining()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

    

        private void RPeP_Pining_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Displaying Active Values 
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            monthCalendar1.Visible = false;


         
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);


            SR_ID = funclib.PSPI_ID("PSPI", con, "select PSPI_ID  from Pining_Details order by PSPI_ID desc");
            txtPSPI_ID.Text = SR_ID;

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as S_ID, '' as S_Name UNION select  S_ID,S_Name from Shift_Master where S_Active='Yes'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlS_ID.DataSource = dt;
            ddlS_ID.DisplayMember = dt.Columns[1].ToString();
            ddlS_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as M_ID, '' as M_Name UNION select  M_ID,M_Name from Machine_Master where M_Active='Yes' and Grp_ID='"+Group_ID+"'", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Open();
            ddlM_ID.DataSource = dt2;
            ddlM_ID.DisplayMember = dt2.Columns[1].ToString();
            ddlM_ID.ValueMember = dt2.Columns[0].ToString();
            con.Close();


       

          
        }

        private void txtPSPI_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtPSPI_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtPSPI_Dt.Focus();
        }

        private void cmdOrderSearch_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Order_ID UNION select Order_ID from Item_Order where I_ID in (select I_ID from Item_Master where Pinning_Opt='Yes') and Order_ID not in (select Order_ID from Pining_Details) and Order_Active='Yes' and Grp_ID='" + Group_ID + "' and Order_ID like '%"+ txtorderSearch.Text+"%'", con);
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

            SqlCommand cmd = new SqlCommand("select a.No_Pins from dbo.Item_Master as a,Item_Order as b where a.I_ID=b.I_ID and b.Order_ID='"+ddlOrder_ID.SelectedValue.ToString()+"' ", con1);
            con1.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                txtPSPI_NoPins.Text = Convert.ToString(dr["No_Pins"]);

            }
            dr.Close();
            con1.Close();
        }

        private void txtPSPI_BoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtPSPI_NoPins_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtPSPI_ConsPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtPSPI_ID.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Sr No Cannot be Blank");
                txtPSPI_ID.Focus();
            }

            else if (txtPSPI_Dt.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPI_Dt.Focus();
            }
            else if (ddlOrder_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlOrder_ID.Focus();
            }
            else if (txtPSPI_BoxQty.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPI_BoxQty.Focus();

            }
            else if (txtPSPI_NoPins.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPI_NoPins.Focus();
            }
            else if (ddlM_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlM_ID.Focus();
            }

            else if (txtPSPI_ConsPin.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPI_ConsPin.Focus();
            }
            else if (txtPSPI_Mfg.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPI_Mfg.Focus();
            }
            else if (txtPSPI_ContrTime.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtPSPI_ContrTime.Focus();
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


                SqlCommand cmdPositive = new SqlCommand("insert into Pining_Details(PSPI_ID,Grp_ID,PSPI_Dt,Order_ID,M_ID,PSPI_BoxQty,PSPI_NoPins,PSPI_ConsPin,PSPI_Mfg,S_ID,PSPI_ContrTime,Add_By,Add_ByNode,Add_On) values('" + txtPSPI_ID.Text.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "',convert(datetime,'" + txtPSPI_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlOrder_ID.SelectedValue.ToString() + "','" + ddlM_ID.SelectedValue.ToString() + "','" + txtPSPI_BoxQty.Text.Trim().Replace("'", "''").ToString() + "','" + txtPSPI_NoPins.Text.Trim().Replace("'", "''").ToString() + "','" + txtPSPI_ConsPin.Text.Trim().Replace("'", "''").ToString() + "','" + txtPSPI_Mfg.Text.Trim().Replace("'", "''").ToString() + "','" + ddlS_ID.SelectedValue.ToString() + "','" + txtPSPI_ContrTime.Text.Trim().Replace("'", "''").ToString() + "','" + session + "','',convert(datetime,getdate(),103))", con);
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


            SR_ID = funclib.PSPI_ID("PSPI", con, "select PSPI_ID  from Pining_Details order by PSPI_ID desc");
            txtPSPI_ID.Text = SR_ID;

            txtorderSearch.Text = "";
            txtPSPI_BoxQty.Text = "";
            txtPSPI_ConsPin.Text = "";
            txtPSPI_ContrTime.Text = "";
            txtPSPI_Dt.Text = "";
            txtPSPI_Mfg.Text = "";
            txtPSPI_NoPins.Text = "";
            ddlM_ID.Text = "";
            ddlOrder_ID.Text = "";
            ddlS_ID.Text = "";
            ddlOrder_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPSPI_Dt.Enabled = true;
            ddlOrder_ID.Enabled = true;
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
                SqlCommand cmd = new SqlCommand("update Pining_Details set M_ID ='" + ddlM_ID.SelectedValue.ToString() + "',PSPI_BoxQty = '" + txtPSPI_BoxQty.Text.Trim().Replace("'", "''").ToString() + "',PSPI_NoPins = '" + txtPSPI_NoPins.Text.Trim().Replace("'", "''").ToString() + "',PSPI_ConsPin = '" + txtPSPI_ConsPin.Text.Trim().Replace("'", "''").ToString() + "',PSPI_Mfg = '" + txtPSPI_Mfg.Text.Trim().Replace("'", "''").ToString() + "',S_ID = '" + ddlS_ID.SelectedValue.ToString() + "',PSPI_ContrTime = '" + txtPSPI_ContrTime.Text.Trim().Replace("'", "''").ToString() + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where PSPI_ID  ='" + txtPSPI_ID.Text.Trim().Replace("'", "''").ToString() + "'", con);

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
            SqlDataAdapter da = new SqlDataAdapter(" select PSPI_ID,convert (varchar(20),PSPI_Dt,103) as 'Date',Order_ID as 'Order No',a.M_ID,b.M_Name as 'Machine',PSPI_BoxQty as 'Box Qty',PSPI_NoPins as 'No of Pins',PSPI_ConsPin as 'Cons.Pin',PSPI_Mfg as 'Manufacturing',a.S_ID,c.S_Name as 'Shift',PSPI_ContrTime as 'Contact time' from Pining_Details as a,Machine_Master as b,Shift_Master as c where a.M_ID=b.M_ID and a.S_ID=c.S_ID and a.Order_ID like '%" + txt_Search.Text.ToString() + "%' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.Columns[0].Visible = false;
            GridView1.Columns[3].Visible = false;
            GridView1.Columns[9].Visible = false;

        }
        protected void fillGrid()
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter(" select PSPI_ID,convert (varchar(20),PSPI_Dt,103) as 'Date',Order_ID as 'Order No',a.M_ID,b.M_Name as 'Machine',PSPI_BoxQty as 'Box Qty',PSPI_NoPins as 'No of Pins',PSPI_ConsPin as 'Cons.Pin',PSPI_Mfg as 'Manufacturing',a.S_ID,c.S_Name as 'Shift',PSPI_ContrTime as 'Contact time' from Pining_Details as a,Machine_Master as b,Shift_Master as c where a.M_ID=b.M_ID and a.S_ID=c.S_ID and a.Order_ID like '%" + txt_Search.Text.ToString() + "%' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.Columns[0].Visible = false;
            GridView1.Columns[3].Visible = false;
            GridView1.Columns[9].Visible = false;

        }
        private void GridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false;
            
            txtPSPI_Dt.Enabled = false;
            ddlOrder_ID.Enabled = false;
           // ddlM_ID.Enabled = false;
            
            txtPSPI_ID.Text = GridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPSPI_Dt.Text = GridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            
            ddlOrder_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlOrder_ID.Text = GridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

           // ddlM_ID.DropDownStyle = ComboBoxStyle.Simple;
            ddlM_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPSPI_BoxQty.Text = GridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPSPI_NoPins.Text = GridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtPSPI_ConsPin.Text = GridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtPSPI_Mfg.Text = GridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            ddlS_ID.SelectedValue = GridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

            txtPSPI_ContrTime.Text = GridView1.Rows[e.RowIndex].Cells[11].Value.ToString();

                

        }
    }
}
