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
    public partial class RPeP_ProgramCard : Form
    {
        string session, strSQL, Group_ID, SR_ID, SubOrder, SubItem_Of;
        string PQ_ID;
        private FunctionLib funclib;
        public RPeP_ProgramCard()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
        }

        private void RPeP_ProgramCard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Displaying Active Values 
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            monthCalendar1.Visible = false;



            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);


            SR_ID = funclib.PSPI_ID("PSPC", con, "select PSPC_ID  from ProgramCard_Details order by PSPC_ID desc");
            txtPSPI_ID.Text = SR_ID;

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


            SqlDataAdapter da3 = new SqlDataAdapter("SELECT '' as Reel_No UNION select  Reel_No from PO_ReelPurchase where Reel_Active='Yes' and Grp_ID='" + Group_ID + "'", con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Open();
            ddlReel_No.DataSource = dt3;
            ddlReel_No.DisplayMember = dt3.Columns[0].ToString();
            ddlReel_No.ValueMember = dt3.Columns[0].ToString();
            con.Close();



            SqlDataAdapter da4 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order where Order_Active='Yes' and Grp_ID='" + Group_ID + "'", con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            con.Open();
            ddlOrder_ID.DataSource = dt4;
            ddlOrder_ID.DisplayMember = dt4.Columns[0].ToString();
            ddlOrder_ID.ValueMember = dt4.Columns[0].ToString();
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

        private void cmdContracSearch_Click(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as C_ID, '' as C_Name UNION select  C_ID,C_Name from Contractor_Master where C_Active='Yes' and C_Name like '%"+txtContraSearch.Text+"%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();
            ddlC_ID.DataSource = dt;
            ddlC_ID.DisplayMember = dt.Columns[1].ToString();
            ddlC_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();
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
            else if (ddlC_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlC_ID.Focus();
            }
            else if (ddlS_ID.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlS_ID.Focus();

            }
         
            else if (ddlM_ID.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                ddlM_ID.Focus();
            }

          


            else
            {


                funclib = new FunctionLib();
                //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlConnection con1 = new SqlConnection(strcon);


                //Inserting records 


                SqlCommand cmdPositive = new SqlCommand("insert into ProgramCard_Details(PSPC_ID,Grp_ID,PSPC_Dt,M_ID,S_ID,C_ID,Add_By,Add_ByNode,Add_On) values('" + txtPSPI_ID.Text.Trim().Replace("'", "''").ToString() + "','" + Group_ID + "',convert(datetime,'" + txtPSPI_Dt.Text.Trim().Replace("'", "''").ToString() + "',103),'" + ddlM_ID.SelectedValue.ToString() + "','" + ddlS_ID.SelectedValue.ToString() + "','" + ddlC_ID.SelectedValue.ToString() + "','" + session + "','',convert(datetime,getdate(),103))", con);
                con.Open();
                int Positive = cmdPositive.ExecuteNonQuery();
                MessageBox.Show("Record Inserted");
                con.Close();
                //clearAll();
                cmdSubmit.Enabled = false;
                enableDisable(false);
                panel2.Enabled = true;
                panel3.Enabled = true;
                cmdAddDetail.Enabled = true;
                cmdOrderDetails.Enabled = true;
               

            }
        }
        protected void enableDisable(Boolean yes)
        {
            txtPSPI_ID.Enabled = yes;
            txtPSPI_Dt.Enabled = yes;
            ddlS_ID.Enabled = yes;
            ddlC_ID.Enabled = yes;
            ddlM_ID.Enabled = yes;

        }
        protected void clearAll()
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);

            SR_ID = funclib.PSPI_ID("PSPC", con, "select PSPC_ID  from ProgramCard_Details order by PSPC_ID desc");
            txtPSPI_ID.Text = SR_ID;

            enableDisable(true);
            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            txtPSPI_Dt.Text = "";
            txtPSPI_ID.Text = "";
            ddlC_ID.Text = "";
            ddlM_ID.Text = "";
            ddlS_ID.Text = "";


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

        }
        protected void ClearDetail()
        {
            ddlReel_No.Text = "";
            txtReelWg.Text = "";
            txtReelTukda.Text = "";
            txtReelSize.Text = "";
            txtReelQlty.Text = "";
            txtReelGMS.Text = "";
            txtReelConsAmt.Text = "";
            
        }
        protected void ClearDetail2()
        {
            ddlOrder_ID.Text = "";
            txtOLenght.Text = "";
            txtOPaper.Text = "";
            txtOQty.Text = "";
            txtOTopQty.Text = "";
            txtOWidth.Text = "";

        }
        private void cmdAddDetail_Click(object sender, EventArgs e)
        {
            if (ddlReel_No.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Field Cannot be Blank");
                ddlReel_No.Focus();
            }

            else if (txtReelConsAmt.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtReelConsAmt.Focus();
            }
            else if (txtReelGMS.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtReelGMS.Focus();

            }
            else if (txtReelQlty.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtReelQlty.Focus();
            }
            else if (txtReelSize.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtReelSize.Focus();
            }
            else if (txtReelTukda.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtReelTukda.Focus();
            }
            else if (txtReelWg.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtReelWg.Focus();
            }

            else
            {
              

                    funclib = new FunctionLib();
                    //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);


                    //Inserting records 


                    SqlCommand cmdPositive = new SqlCommand("insert into ProgramCard_Reel(PSPC_ID,Reel_No,PSPC_Size,PSPC_GSM,PQ_ID,PSPC_Wg,PSPC_Tukda,PSPC_ConsAmt) values('" + txtPSPI_ID.Text.Trim().Replace("'", "''").ToString() + "','" + ddlReel_No.SelectedValue.ToString() + "','" + txtReelSize.Text.ToString() + "','" + txtReelGMS.Text.Trim().Replace("'", "''").ToString() + "','" + PQ_ID + "','" + txtReelWg.Text.Trim().Replace("'", "''").ToString() + "','" + txtReelTukda.Text.Trim().Replace("'", "''").ToString() + "','" + txtReelConsAmt.Text.Trim().Replace("'", "''").ToString() + "')", con);
                    con.Open();
                    int Positive = cmdPositive.ExecuteNonQuery();
                    con.Close();
                    ClearDetail();

                    SqlDataAdapter da = new SqlDataAdapter(" select Reel_No as 'Reel No',PSPC_Size as 'Size',PSPC_GSM as 'GSM',b.PQ_Desc as 'Quality',PSPC_Wg as 'WG',PSPC_Tukda as 'Tukda',PSPC_ConsAmt as 'Cons.Amt' from ProgramCard_Reel as a,PQuality_Master as b  where a.PQ_ID=b.PQ_ID and a.PSPC_ID ='" + txtPSPI_ID.Text.ToString() + "'  order by a.Reel_No", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridViewAddDetails.DataSource = dt;

                    SqlDataAdapter da3 = new SqlDataAdapter("SELECT '' as Reel_No UNION select  Reel_No from PO_ReelPurchase where Reel_No not in (select Reel_No from ProgramCard_Reel where PSPC_ID='" + txtPSPI_ID.Text.ToString() + "') and Reel_Active='Yes' and Grp_ID='" + Group_ID + "'", con);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    con.Open();
                    ddlReel_No.DataSource = dt3;
                    ddlReel_No.DisplayMember = dt3.Columns[0].ToString();
                    ddlReel_No.ValueMember = dt3.Columns[0].ToString();
                    con.Close();

                    PQ_ID = "";


                }
               


            }
          
           
             
        

        private void ddlReel_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);

            SqlCommand cmd = new SqlCommand("select b.POR_Size,b.POR_GSM,b.PQ_ID from PO_ReelPurchase as a,PO_ReelDetail as b where a.POR_No=b.POR_No and a.Reel_No='" + ddlReel_No.SelectedValue.ToString() + "' ", con1);
            con1.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                txtReelSize.Text = Convert.ToString(dr["POR_Size"]);
                txtReelGMS.Text = Convert.ToString(dr["POR_GSM"]);
                PQ_ID = Convert.ToString(dr["PQ_ID"]);

              
            }
            dr.Close();
            con1.Close();


            SqlCommand cmd2 = new SqlCommand("select PQ_Desc from PQuality_Master where PQ_ID='" + PQ_ID + "' ", con1);
            con1.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {

                txtReelQlty.Text = Convert.ToString(dr2["PQ_Desc"]);
              

            }
            dr2.Close();
            con1.Close();
        }

        private void txtOLenght_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtOWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtOQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void cmdOrderDetails_Click(object sender, EventArgs e)
        {
            if (ddlOrder_ID.Text == "")//checking for PartyName  field 
            {
                MessageBox.Show("Field Cannot be Blank");
                ddlOrder_ID.Focus();
            }

            else if (txtOLenght.Text == "")//checking for blank name text field 
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtOLenght.Focus();
            }
            else if (txtOPaper.Text == "")//checking for blank Phone
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtOPaper.Focus();

            }
            else if (txtOQty.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtOQty.Focus();
            }
            else if (txtOTopQty.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtOTopQty.Focus();
            }
            else if (txtOWidth.Text == "")
            {
                MessageBox.Show("Field Cannot Be Balnk");
                txtOWidth.Focus();
            }
            

            else
            {


                funclib = new FunctionLib();
                //strFirstCap = funcLib.FirstCap(txtPtve_Name.Text);
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);


                //Inserting records 


                SqlCommand cmdPositive = new SqlCommand("insert into ProgramCard_Order(PSPC_ID,Order_ID,PSPC_Length,PSPC_Width,PSPC_Qty,PSPC_TopPaper,PSPC_TopQty) values('" + txtPSPI_ID.Text.Trim().Replace("'", "''").ToString() + "','" + ddlOrder_ID.SelectedValue.ToString() + "','" + txtOLenght.Text.ToString() + "','" + txtOWidth.Text.Trim().Replace("'", "''").ToString() + "','" + txtOQty.Text.Trim().Replace("'", "''").ToString() + "','" + txtOPaper.Text.Trim().Replace("'", "''").ToString() + "','" + txtOTopQty.Text.Trim().Replace("'", "''").ToString() + "')", con);
                con.Open();
                int Positive = cmdPositive.ExecuteNonQuery();
                con.Close();
                ClearDetail();

                SqlDataAdapter da = new SqlDataAdapter(" select Order_ID as 'Order No',PSPC_Length as 'Length',PSPC_Width as 'Width',PSPC_Qty as 'Qty',PSPC_TopPaper as 'Top Paper',PSPC_TopQty as 'Top Paper Qty' from ProgramCard_Order  where PSPC_ID ='" + txtPSPI_ID.Text.ToString() + "'  order by Order_ID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewAddDetails.DataSource = dt;

                SqlDataAdapter da4 = new SqlDataAdapter("SELECT '' as Order_ID UNION select  Order_ID from Item_Order where Order_Active='Yes' and Order_ID not in (select Order_ID from ProgramCard_Order where PSPC_ID='"+txtPSPI_ID.Text.ToString()+"') and Grp_ID='" + Group_ID + "'", con);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                con.Open();
                ddlOrder_ID.DataSource = dt4;
                ddlOrder_ID.DisplayMember = dt4.Columns[0].ToString();
                ddlOrder_ID.ValueMember = dt4.Columns[0].ToString();
                con.Close();

             


            }
               


         
        }

        private void txtReelConsAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtOTopQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

      

      
        
    }
}
