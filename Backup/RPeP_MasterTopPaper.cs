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
using Excel = Microsoft.Office.Interop.Excel;

namespace ePacker1
{
    public partial class RPeP_MasterTopPaper : Form
    {
        string session, strSQL, Group_ID; 
        private FunctionLib funclib;
        string strFirstCap;
        private double sqMeter = 1550.00;
        private double costPaper;

        public RPeP_MasterTopPaper()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            cmdEdit.Enabled = false;
            txtTP_ID.Visible = false;
            txtTP_PPBf.Enabled = false;
            txtTP_PPGram.Enabled = false;
            txtTP_PPRate.Enabled = false;
            txtTP_OS.Enabled = false;
            txtTP_CS.Enabled = false;
            txtTP_ReLev.Enabled = false;
            txtTP_PPCost.Enabled = false;
            txtTP_LmCost.Enabled = false;
            txtTP_VrCost.Enabled = false;
            txtTP_PnCost.Enabled = false;
            txtTP_PlCost.Enabled = false;
            txtTP_PlWsAmt.Enabled = false;
            txtTP_LmRate.Enabled = false;

            filldata();

            int i=1000;
           
            while(i <= 10000)
            {
             //fill th plate divFact ddl  
              ddlTP_PlDivFact.Items.Add(i);
              i = i + 1000;

            }

        }

        private void RPeP_MasterTopPaper_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();

            ////Displayig Group Name in Combo field
            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();



            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("SELECT '' as Ptve_ID, '' as Ptve_Name UNION select Ptve_ID,Ptve_Name from Positive_Master a,Group_Master b where b.Grp_ID='" + Group_ID + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlPtve_ID.DataSource = dt;
            ddlPtve_ID.DisplayMember = dt.Columns[1].ToString();
            ddlPtve_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();

            //Displaying value for Party
            con.Open();

            SqlDataAdapter daParty = new SqlDataAdapter("SELECT '' as P_ID, '' as P_Name UNION select P_ID,P_Name from Party_Master where Grp_ID='" + Group_ID + "'", con);
            DataTable dtParty = new DataTable();
            daParty.Fill(dtParty);
            ddlP_ID.DataSource = dtParty;
            ddlP_ID.DisplayMember = dtParty.Columns[1].ToString();
            ddlP_ID.ValueMember = dtParty.Columns[0].ToString();
            con.Close();

            //Displaying value for Paper Quality
            con.Open();
            SqlDataAdapter daQuality = new SqlDataAdapter("SELECT '' as PQ_ID, '' as PQ_Desc UNION select PQ_ID,PQ_Desc from PQuality_Master where Grp_ID='" + Group_ID + "' and PQ_Active='Yes'", con);
            DataTable dtQuality = new DataTable();
            daQuality.Fill(dtQuality);
            ddlPQ_ID.DataSource = dtQuality;
            ddlPQ_ID.DisplayMember = dtQuality.Columns[1].ToString();
            ddlPQ_ID.ValueMember = dtQuality.Columns[0].ToString();
            con.Close();

            //Displaying value for Lamintion Type
            con.Open();
            SqlDataAdapter daLamintionType = new SqlDataAdapter("SELECT '' as Lamint_ID, '' as Lamint_Type UNION select Lamint_ID,(Lamint_Type+' '+Lamint_Thick) as Lamint_Type from Item_Lamint_Master where Grp_ID= '" + Group_ID + "' and Lamint_Active='yes'", con);
            DataTable dtLamint = new DataTable();
            daLamintionType.Fill(dtLamint);
            ddlTP_LmType.DataSource = dtLamint;
            ddlTP_LmType.DisplayMember = dtLamint.Columns[1].ToString();
            ddlTP_LmType.ValueMember = dtLamint.Columns[0].ToString();
            con.Close();


            //Displaying value for varnish Type
            con.Open();
            SqlDataAdapter davarnish = new SqlDataAdapter("SELECT '' as Varnish_ID, '' as Varnish_Type UNION select Varnish_ID, Varnish_Type from Item_Varnish_Master where Grp_ID='" + Group_ID + "' and Varnish_Active='yes'", con);
            DataTable dtvarnish = new DataTable();
            davarnish.Fill(dtvarnish);
            ddlTP_VrType.DataSource = dtvarnish;
            ddlTP_VrType.DisplayMember = dtvarnish.Columns[1].ToString();
            ddlTP_VrType.ValueMember = dtvarnish.Columns[0].ToString();
            con.Close();


            //on selection closing stock n opening stock text box reamin blank
            txtTP_OS.Text = "";
            txtTP_CS.Text = "";
            txtTP_ReLev.Text = "";

            //Displaying value in Active field
            ddlTP_Active.SelectedText = "Yes";
            ddlTP_Active.Enabled = false;
            ddlTP_Active.Items.Add("Yes");
            ddlTP_Active.Items.Add("No");

                   
           
            //Displaying Lamination Type in ddlTP_LmType

            //ddlTP_LmType.Items.Add("PVC");
            //ddlTP_LmType.Items.Add("BOPP 10");
            //ddlTP_LmType.Items.Add("BOPP 12");
            //ddlTP_LmType.Items.Add("BOPP 15");


            //Displaying Varnish Type in ddlTP_VrType

            //ddlTP_VrType.Items.Add("PVC");
            //ddlTP_VrType.Items.Add("BOPP 10");
            //ddlTP_VrType.Items.Add("BOPP 12");
            //ddlTP_VrType.Items.Add("BOPP 15");

            
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            //if (ddlGrp_ID.Text == "")//checking for blank Group_ID combo field 
            //{
            //    MessageBox.Show("Please Select Group ID");
            //    ddlGrp_ID.Focus();

            //}


           if (txtTP_Name.Text == "")//checking for First Name field 
            {
                MessageBox.Show("Please Top Paper Name");
                txtTP_Name.Focus();
            }
            else if (txtTP_PPLgth.Text == "")//checking for Last Name 
            {
                MessageBox.Show("Please enter Paper Length");
                txtTP_PPLgth.Focus();
            }
            else if (txtTP_PPWdth.Text == "")//checking for blank Addr1 text field 
            {
                MessageBox.Show("Please Enter Paper width");
                txtTP_PPWdth.Focus();
            }
            
            else if (txtTP_PPBf.Text == "")//Checking for blnk City field
            {
                MessageBox.Show("Please Enter Paper Bf");
                txtTP_PPBf.Focus();
            }
            else if (txtTP_PPGram.Text == "")//Checking for blnk State field
            {
                MessageBox.Show("Please enter Paper grammage");
                txtTP_PPGram.Focus();
            }
            else if (txtTP_PPRate.Text == "")//Checking for blnk PinCode field
            {
                MessageBox.Show("Enter Paper Rate");
                txtTP_PPRate.Focus();
            }
            else if (txtTP_PPCost.Text == "")//Checking for blnk Mobile field
            {
                MessageBox.Show("Enter Paper cost");
                txtTP_PPCost.Focus();
            }
            else if (txtTP_LmLgth.Text == "")//Checking for blnk BirthPlace field
            {
                MessageBox.Show("Enter Lamination Length");
                txtTP_LmLgth.Focus();
            }
            else if (txtTP_LmWdth.Text == "")//Checking for blnk ECC field
            {
                MessageBox.Show("Please Enter Lamination Width");
                txtTP_LmWdth.Focus();
            }
            else if (txtTP_LmRate.Text == "")////Checking for blnk CST field
            {
                MessageBox.Show("Enter Lamination Rate");
                txtTP_LmRate.Focus();
            }
            else if (txtTP_LmCost.Text == "")//Checking for blnk Tin field
            {
                MessageBox.Show("Enter Lamination cost");
                txtTP_LmCost.Focus();
            }
            else if (txtTP_PnColor.Text == "")//Checking for blnk Owner name field
            {
                MessageBox.Show("Enter Number of colors");
                txtTP_PnColor.Focus();
            }
            else if (txtTP_PnRate.Text == "")//Checking for blnk Address field
            {
                MessageBox.Show("Enter Printing Rate");
                txtTP_PnRate.Focus();
            }
            else if (txtTP_PnCost.Text == "")//Checking for blnk City field
            {
                MessageBox.Show("Enter Printing cost");
                txtTP_PnCost.Focus();
            }
            else if (txtTP_PlNo.Text == "")//Checking for blnk City field
            {
                MessageBox.Show("Enter Plate number");
                txtTP_PlNo.Focus();
            }
            else if(txtTP_PlRate.Text=="")
            {
                MessageBox.Show("Enter Plate Rate");
                txtTP_PlRate.Focus();

            }
            else if(txtTP_PlCost.Text=="")
            {
                MessageBox.Show("Enter Plate Cost");
                txtTP_PlCost.Focus();
            }
            else if (txtTP_PlWsCnt.Text == "")
            {
                MessageBox.Show("Enter Weight Percent");
                txtTP_PlWsCnt.Focus();
            }
                
            else if (txtTP_PlWsAmt.Text == "")
            {
                MessageBox.Show("Enter Weight Amount");
                txtTP_PlWsAmt.Focus();
            }
                else if (ddlPtve_ID.Text == "")
            {
                MessageBox.Show("select Positive id");
                ddlPtve_ID.Focus();
            }
            else if (txtTP_Rate.Text == "")
            {
                MessageBox.Show("Enter Rate");
                txtTP_Rate.Focus();
            }

            else if (txtTP_OS.Text == "")
            {
                MessageBox.Show("Enter Open Stock");
                txtTP_OS.Focus();
            }

            else if (txtTP_CS.Text == "")
            {
                MessageBox.Show("Enter Close Stock");
                txtTP_CS.Focus();
            }

            else if (txtTP_ReLev.Text == "")
            {
                MessageBox.Show("Enter Re-order rate");
                txtTP_ReLev.Focus();
            }


            else
            {
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Checking for duplicate values
                    double flag = funclib.isThere(con, "select TP_Name,Grp_ID from TopPaper_Master where TP_Name='" + txtTP_Name.Text + "'and Grp_ID='" + Group_ID + "'");
                    if (flag == 1)
                    {
                        MessageBox.Show("Cannot add this record as duplication of Top Paper Name is not allowed for the selected Group");

                    }
                    else
                    {
                        //Inserting Details into table
                        strFirstCap = funclib.FirstCap(txtTP_Name.Text);
                        string tpid = funclib.TopPaper("TP", con, "select TP_ID from TopPaper_Master order by TP_ID desc");
                        //COMMENTED ON 22/06/2011.BY ASHWIN
                        //SqlCommand cmd = new SqlCommand("insert into TopPaper_Master values('" + tpid + "','" + Group_ID + "','" + ddlP_ID.SelectedValue.ToString() + "','" + strFirstCap.Trim().Replace("'", "''").ToString() + "','" + ddlPQ_ID.SelectedValue.ToString() + "','" + txtTP_PPLgth.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PPWdth.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PPBf.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PPGram.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PPRate.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PPCost.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_LmLgth.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_LmWdth.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_LmRate.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_LmCost.Text.Trim().Replace("'", "''").ToString() + "','" + ddlTP_LmType.SelectedValue.ToString() + "','"+txtTP_VrLgth.Text.Trim().Replace("'","''").ToString()+"','"+txtTP_VrWdth.Text.Trim().Replace("'","''").ToString()+"','"+txtTP_VrRate.Text.Trim().Replace("'","''").ToString()+"','"+txtTP_VrCost.Text.Trim().Replace("'","''").ToString()+"','" + ddlTP_VrType.SelectedValue.ToString() + "','" + txtTP_PnColor.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PnRate.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PnCost.Text.Trim().Replace("'", "''").ToString() + "','" + ddlTP_PlDivFact.SelectedValue.ToString() + "','" + txtTP_PlNo.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PlRate.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PlCost.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PlWsCnt.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PlWsAmt.Text.Trim().Replace("'", "''").ToString() + "','" + ddlPtve_ID.SelectedValue.ToString() + "','" + txtTP_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_OS.Text.Trim().Replace("'", "''").ToString() + "','','" + txtTP_CS.Text.Trim().Replace("'", "''").ToString() + "','','" + txtTP_ReLev.Text.Trim().Replace("'", "''").ToString() + "','" + ddlTP_Active.SelectedValue.ToString() + "','Shirish','','','Shirish','','')", con);
                        SqlCommand cmd = new SqlCommand("insert into TopPaper_Master values('" + tpid + "','" + Group_ID + "','" + ddlP_ID.SelectedValue.ToString() + "','" + strFirstCap.Trim().Replace("'", "''").ToString() + "','" + ddlPQ_ID.SelectedValue.ToString() + "','" + txtTP_PPLgth.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PPWdth.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PPBf.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PPGram.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PPWt .Text.ToString()+ "','" + txtTP_PPRate.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PPCost.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_LmLgth.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_LmWdth.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_LmRate.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_LmCost.Text.Trim().Replace("'", "''").ToString() + "','" + ddlTP_LmType.SelectedValue.ToString() + "','" + txtTP_VrLgth.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_VrWdth.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_VrRate.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_VrCost.Text.Trim().Replace("'", "''").ToString() + "','" + ddlTP_VrType.SelectedValue.ToString() + "','" + txtTP_PnColor.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PnRate.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PnCost.Text.Trim().Replace("'", "''").ToString() + "','" + ddlTP_PlDivFact.Text + "','" + txtTP_PlNo.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PlRate.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PlCost.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PlWsCnt.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_PlWsAmt.Text.Trim().Replace("'", "''").ToString() + "','" + ddlPtve_ID.SelectedValue.ToString() + "','" + txtTP_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + txtTP_OS.Text.Trim().Replace("'", "''").ToString() + "','','" + txtTP_CS.Text.Trim().Replace("'", "''").ToString() + "','','" + txtTP_ReLev.Text.Trim().Replace("'", "''").ToString() + "','" + ddlTP_Active.Text + "','" + session + "','',convert(datetime,getdate(),103),'','','')", con);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        filldata();
                        clearAll();

                    }
                }
            }

            
        }

        private void txtTP_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validation for TP_name

            funclib = new FunctionLib();
            funclib.checkNumericChar(e);

        }

        private void txtTP_PPLgth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PPLgth
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtTP_PPWdth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PPLWdth
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);


        }

        private void txtTP_PPBf_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PPBf
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtTP_PPGram_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PPGram
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtTP_PPRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PPRate
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtTP_PPCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PPCost
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtTP_LmLgth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_LmLgth
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtTP_LmWdth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_LmWdth
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtTP_LmRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_LmRate
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
            
        }

        private void txtTP_VrRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_VrRate
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtTP_LmCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_LmCost
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTP_PnColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PnColor
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtTP_PnRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PnRate
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txttxtTP_PnCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PnCost
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtTP_PlNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PlNo
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTP_PlRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PlRate
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTP_PlCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PlCost
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtTP_PlWsCnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_WsCnt
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTP_PlWsAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_WsAmt
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTP_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_Rate
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTP_OS_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_OS
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTP_CS_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_CS
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void TP_ReLev_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_ReLev
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        
        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Displaying Value of Positive Combo box of plate

            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            //SqlConnection con = new SqlConnection(strcon);
            //SqlDataAdapter da = new SqlDataAdapter("select Ptve_ID,Ptve_Name from Positive_Master a,Group_Master b where b.Grp_ID='" + Group_ID + "'", con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlPtve_ID.DataSource = dt;
            //ddlPtve_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlPtve_ID.ValueMember = dt.Columns[0].ToString();
            //con.Close();

            ////Displaying value for Party
            //con.Open();

            //SqlDataAdapter daParty = new SqlDataAdapter("select P_ID,P_Name from Party_Master where Grp_ID='" + Group_ID + "'", con);
            //DataTable dtParty = new DataTable();
            //daParty.Fill(dtParty);
            //ddlP_ID.DataSource = dtParty;
            //ddlP_ID.DisplayMember = dtParty.Columns[1].ToString();
            //ddlP_ID.ValueMember = dtParty.Columns[0].ToString();
            //con.Close();

            ////Displaying value for Paper Quality
            //con.Open();
            //SqlDataAdapter daQuality = new SqlDataAdapter("select PQ_ID,PQ_Desc from PQuality_Master where Grp_ID='" + Group_ID + "' and PQ_Active='Yes'", con);
            //DataTable dtQuality = new DataTable();
            //daQuality.Fill(dtQuality);
            //ddlPQ_ID.DataSource = dtQuality;
            //ddlPQ_ID.DisplayMember = dtQuality.Columns[1].ToString();
            //ddlPQ_ID.ValueMember = dtQuality.Columns[0].ToString();
            //con.Close();

            ////Displaying value for Lamintion Type
            //con.Open();
            //SqlDataAdapter daLamintionType = new SqlDataAdapter("select Lamint_ID,(Lamint_Type+' '+Lamint_Thick) as Lamint_Type from Item_Lamint_Master where Grp_ID= '"+Group_ID+"' and Lamint_Active='yes'",con);
            //DataTable dtLamint = new DataTable();
            //daLamintionType.Fill(dtLamint);
            //ddlTP_LmType.DataSource = dtLamint;
            //ddlTP_LmType.DisplayMember = dtLamint.Columns[1].ToString();
            //ddlTP_LmType.ValueMember = dtLamint.Columns[0].ToString();
            //con.Close();


            ////Displaying value for varnish Type
            //con.Open();
            //SqlDataAdapter davarnish = new SqlDataAdapter("select Varnish_ID, Varnish_Type from Item_Varnish_Master where Grp_ID='" + Group_ID + "' and Varnish_Active='yes'", con);
            //DataTable dtvarnish = new DataTable();
            //davarnish.Fill(dtvarnish);
            //ddlTP_VrType.DataSource = dtvarnish;
            //ddlTP_VrType.DisplayMember = dtvarnish.Columns[1].ToString();
            //ddlTP_VrType.ValueMember = dtvarnish.Columns[0].ToString();
            //con.Close();


            ////on selection closing stock n opening stock text box reamin blank
            //txtTP_OS.Text = "";
            //txtTP_CS.Text = "";
            //txtTP_ReLev.Text = "";




        }

       
       

        private void filldata()
        {
            //to fill the grid with user details
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con4 = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select a.TP_ID as TopPaperID,b.Grp_Name as GroupName,c.P_Name as PartyName,a.TP_Name as TopPaperName,d.PQ_Desc as PaperQuality, a.TP_PPLgth as TopPaperLength, a.TP_PPWdth as PaperWidth,a.TP_PPBf as PaperBf, a.TP_PPGram as PaperGram,a.TP_PPRate as PaperRate,a.TP_PPCost as PaperCost, a.TP_LmLgth as LaminationLength,a.TP_LmWdth as LaminationWidth, a.TP_LmRate as LaminationRate,a.TP_LmCost as LaminationCost ,a.TP_LmType as LaminationType,a.TP_VrLgth as VarnishLength,a.TP_VrWdth as varnishWidth,a.TP_VrRate as vanishRate,a.TP_VrCost as VarnishCost,a.TP_VrType as varnishType, a.TP_PnColor as NoColors,a.TP_PnRate as PlateRate,a.TP_PnCost as PlateCost,a.TP_PlDivFact as Divfactor, a.TP_PlNo as PlateNo,a.TP_PlRate as PlateRate,a.TP_PlCost as PlateCost, a.TP_PlWsCnt as WeightPercnt,a.TP_PlWsAmt as WeightAmt,e.Ptve_Name as PositiveName, a.TP_Rate as Rate,a.TP_OS as OpenStock,a.TP_CS as ClosingStock,a.TP_ReLev as ReOrder, a.TP_Active as Active,a.TP_PPWt as 'Paper Weight' from TopPaper_Master a,Group_Master b ,Party_Master c,PQuality_Master d,Positive_Master e where b.Grp_ID=a.Grp_ID and a.PQ_ID=d.PQ_ID and a.P_ID=c.P_ID and a.Ptve_ID=e.Ptve_ID  and a.TP_Active='yes' ", con4);
            //SqlDataAdapter da = new SqlDataAdapter("select a.TP_ID as TopPaperID,b.Grp_Name as GroupName,c.P_Name as PartyName,a.TP_Name as TopPaperName,d.PQ_Desc as PaperQuality, a.TP_PPLgth as TopPaperLength,a.TP_PPWdth as PaperWidth,a.TP_PPBf as PaperBf, a.TP_PPGram as PaperGram,a.TP_PPRate as PaperRate,a.TP_PPCost as PaperCost, a.TP_LmLgth as LaminationLength,a.TP_LmWdth as LaminationWidth, a.TP_LmRate as LaminationRate,a.TP_LmCost as LaminationCost ,a.TP_LmType as LaminationType,a.TP_VrLgth as VarnishLength,a.TP_VrWdth as varnishWidth,a.TP_VrRate as vanishRate,a.TP_VrCost as VarnishCost,a.TP_VrType as varnishType, a.TP_PnColor as NoColors,a.TP_PnRate as PlateRate,a.TP_PnCost as PlateCost,a.TP_PlDivFact as Divfactor, a.TP_PlNo as PlateNo,a.TP_PlRate as PlateRate,a.TP_PlCost as PlateCost, a.TP_PlWsCnt as WeightPercnt,a.TP_PlWsAmt as WeightAmt,e.Ptve_Name as PositiveName, a.TP_Rate as Rate,a.TP_OS as OpenStock,a.TP_CS as ClosingStock,a.TP_ReLev as ReOrder, a.TP_Active as Active from TopPaper_Master a,Group_Master b ,Party_Master c,PQuality_Master d,Positive_Master e  where b.Grp_ID=a.Grp_ID and b.Grp_ID=c.Grp_ID and b.Grp_ID=d.Grp_ID and a.PQ_ID=d.PQ_ID and a.P_ID=c.P_ID and a.Ptve_ID=e.Ptve_ID", con4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwTopPaper_Master.DataSource = dt;
            this.dgwTopPaper_Master.Columns[0].Visible = false;

        }

        private void dgwTopPaper_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdSubmit.Enabled = false; 
            ddlTP_Active.Enabled = true;

            txtTP_Name.Enabled = false;
            ddlGrp_ID.Enabled = false;
            ddlP_ID.Enabled = false;
            //ddlPQ_ID.Enabled = false;
            //ddlPtve_ID.Enabled = false;

            //Display data in form on click of grid


            txtTP_ID.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
          //  ddlGrp_ID.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[1].Value.ToString();
            ddlP_ID.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTP_Name.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlPQ_ID.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtTP_PPLgth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtTP_PPWdth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtTP_PPBf.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtTP_PPGram.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtTP_PPRate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtTP_PPCost.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtTP_LmLgth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtTP_LmWdth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtTP_LmRate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtTP_LmCost.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[14].Value.ToString();
            ddlTP_LmType.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtTP_VrLgth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[16].Value.ToString();
            txtTP_VrWdth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtTP_VrRate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtTP_VrCost.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[19].Value.ToString();
            ddlTP_VrType.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[20].Value.ToString();

            txtTP_PnColor.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[21].Value.ToString();
            txtTP_PnRate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[22].Value.ToString();
            txtTP_PnCost.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[23].Value.ToString();
            ddlTP_PlDivFact.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[24].Value.ToString();

            txtTP_PlNo.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[25].Value.ToString();
            txtTP_PlRate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[26].Value.ToString();
            txtTP_PlCost.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[27].Value.ToString();
            txtTP_PlWsCnt.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[28].Value.ToString();
            txtTP_PlWsAmt.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[29].Value.ToString();
            ddlPtve_ID.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[30].Value.ToString();

            txtTP_Rate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[31].Value.ToString();
            txtTP_OS.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[32].Value.ToString();
            txtTP_CS.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[33].Value.ToString();
            txtTP_ReLev.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[34].Value.ToString();
            ddlTP_Active.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[35].Value.ToString();
            txtTP_PPWt.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[36].Value.ToString();
            
            PQ_ID();
            Lamit_Type();
            Varnish_Type();
            Ptve_ID();

            
        }

        private void Ptve_ID()
        {
            //Displaying Value of Positive Combo box of plate  on edit

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select Ptve_ID,Ptve_Name from Positive_Master a,Group_Master b where b.Grp_ID='" + Group_ID + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlPtve_ID.DataSource = dt;
            ddlPtve_ID.DisplayMember = dt.Columns[1].ToString();
            ddlPtve_ID.ValueMember = dt.Columns[0].ToString();
            con.Close();

        }

        private void PQ_ID()
        {
            //Displaying value for Paper Quality ON edit
            funclib = new FunctionLib();
            string str = funclib.setConnection();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlDataAdapter daQuality = new SqlDataAdapter("select PQ_ID,PQ_Desc from PQuality_Master where Grp_ID='" + Group_ID + "' and PQ_Active='Yes'", con);
            DataTable dtQuality = new DataTable();
            daQuality.Fill(dtQuality);
            ddlPQ_ID.DataSource = dtQuality;
            ddlPQ_ID.DisplayMember = dtQuality.Columns[1].ToString();
            ddlPQ_ID.ValueMember = dtQuality.Columns[0].ToString();
            con.Close();
            

        }

        private void Lamit_Type()
        {
            //Displaying value for Lamintion Type
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter daLamintionType = new SqlDataAdapter("select Lamint_ID,(Lamint_Type+' '+Lamint_Thick) as Lamint_Type from Item_Lamint_Master where Grp_ID= '" + Group_ID + "' and Lamint_Active='yes'", con);
            DataTable dtLamint = new DataTable();
            daLamintionType.Fill(dtLamint);
            ddlTP_LmType.DataSource = dtLamint;
            ddlTP_LmType.DisplayMember = dtLamint.Columns[1].ToString();
            ddlTP_LmType.ValueMember = dtLamint.Columns[0].ToString();
            con.Close();
        }

        private void Varnish_Type()
        {
            //Displaying value for varnish Type
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter davarnish = new SqlDataAdapter("select Varnish_ID, Varnish_Type from Item_Varnish_Master where Grp_ID='" + Group_ID + "' and Varnish_Active='yes'", con);
            DataTable dtvarnish = new DataTable();
            davarnish.Fill(dtvarnish);
            ddlTP_VrType.DataSource = dtvarnish;
            ddlTP_VrType.DisplayMember = dtvarnish.Columns[1].ToString();
            ddlTP_VrType.ValueMember = dtvarnish.Columns[0].ToString();
            con.Close();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            //Update data in table
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
           //SqlCommand cmd = new SqlCommand("update TopPaper_Master set Grp_ID ='" + Group_ID + "',TP_PPLgth='" + txtTP_PPLgth.Text + "',TP_PPWdth ='" + txtTP_PPWdth.Text + "',TP_PPBf ='" + txtTP_PPBf.Text + "',TP_PPGram='" + txtTP_PPGram.Text + "',TP_PPRate ='" + txtTP_PPRate.Text + "',TP_PPCost='" + txtTP_PPCost.Text + "',TP_LmLgth='" + txtTP_LmLgth.Text + "',TP_LmWdth='" + txtTP_LmWdth.Text + "',TP_LmRate='" + txtTP_LmRate.Text + "',TP_LmCost='" + txtTP_LmCost.Text + "',TP_PnColor='" + txtTP_PnColor.Text + "',TP_PnRate='" + txtTP_PnRate.Text + "',TP_PnCost='" + txtTP_PnCost.Text + "',TP_PlNo='" + txtTP_PlNo.Text + "',TP_PlRate='" + txtTP_PlRate.Text + "',TP_PlCost='" + txtTP_PlCost.Text + "',TP_PlWsCnt='" + txtTP_PlWsCnt.Text + "',TP_PlWsAmt='" + txtTP_PlWsAmt + "',Ptve_ID='" + ddlPtve_ID.SelectedItem.ToString() + "',TP_Rate='" + txtTP_Rate.Text + "',TP_OS='" + txtTP_OS.Text + "',TP_CS='" + txtTP_CS.Text + "',TP_ReLev='" + txtTP_ReLev.Text + "',TP_Active='"+ddlTP_Active.Text+"' where TP_ID='" + txtTP_ID.Text + "'", con);
           //SqlCommand cmd = new SqlCommand("update TopPaper_Master set P_ID='" + ddlP_ID.Text + "',PQ_ID='" + ddlPQ_ID.SelectedValue.ToString() + "', TP_PPLgth='" + txtTP_PPLgth.Text + "',TP_PPWdth ='" + txtTP_PPWdth.Text + "',TP_PPBf ='" + txtTP_PPBf.Text + "',TP_PPGram='" + txtTP_PPGram.Text + "',TP_PPRate ='" + txtTP_PPRate.Text + "',TP_PPCost='" + txtTP_PPCost.Text + "',TP_LmLgth='" + txtTP_LmLgth.Text + "',TP_LmWdth='" + txtTP_LmWdth.Text + "',TP_LmRate='" + txtTP_LmRate.Text + "',TP_LmCost='" + txtTP_LmCost.Text + "',TP_LmType='" + ddlTP_LmType.SelectedValue.ToString() + "',TP_VrLgth='" + txtTP_VrLgth.Text + "',TP_VrWdth='" + txtTP_VrWdth.Text + "',TP_VrRate='" + txtTP_VrRate.Text + "',TP_VrCost='" + txtTP_VrCost.Text + "',TP_VrType='" + ddlTP_VrType.SelectedValue.ToString() + "',TP_PnColor='" + txtTP_PnColor.Text + "',TP_PnRate='" + txtTP_PnRate.Text + "',TP_PnCost='" + txtTP_PnCost.Text + "',TP_PlDivFact='"+ddlTP_PlDivFact.SelectedValue.ToString()+"', TP_PlNo='" + txtTP_PlNo.Text + "',TP_PlRate='" + txtTP_PlRate.Text + "',TP_PlCost='" + txtTP_PlCost.Text + "',TP_PlWsCnt='" + txtTP_PlWsCnt.Text + "',TP_PlWsAmt='" + txtTP_PlWsAmt + "',Ptve_ID='" + ddlPtve_ID.SelectedItem.ToString() + "',TP_Rate='" + txtTP_Rate.Text + "',TP_OS='" + txtTP_OS.Text + "',TP_CS='" + txtTP_CS.Text + "',TP_ReLev='" + txtTP_ReLev.Text + "',TP_Active='" + ddlTP_Active.Text + "' where TP_ID='" + txtTP_ID.Text + "'", con);


            SqlCommand cmd = new SqlCommand("update TopPaper_Master set PQ_ID='" + ddlPQ_ID.SelectedValue.ToString() + "', TP_PPLgth='" + txtTP_PPLgth.Text + "',TP_PPWdth ='" + txtTP_PPWdth.Text + "',TP_PPBf ='" + txtTP_PPBf.Text + "',TP_PPGram='" + txtTP_PPGram.Text + "',TP_PPWt='" + txtTP_PPWt.Text.ToString() + "',TP_PPRate ='" + txtTP_PPRate.Text + "',TP_PPCost='" + txtTP_PPCost.Text + "',TP_LmLgth='" + txtTP_LmLgth.Text + "',TP_LmWdth='" + txtTP_LmWdth.Text + "',TP_LmRate='" + txtTP_LmRate.Text + "',TP_LmCost='" + txtTP_LmCost.Text + "',TP_LmType='" + ddlTP_LmType.SelectedValue.ToString() + "',TP_VrLgth='" + txtTP_VrLgth.Text + "',TP_VrWdth='" + txtTP_VrWdth.Text + "',TP_VrRate='" + txtTP_VrRate.Text + "',TP_VrCost='" + txtTP_VrCost.Text + "',TP_VrType='" + ddlTP_VrType.SelectedValue.ToString() + "',TP_PnColor='" + txtTP_PnColor.Text + "',TP_PnRate='" + txtTP_PnRate.Text + "',TP_PnCost='" + txtTP_PnCost.Text + "',TP_PlDivFact='" + ddlTP_PlDivFact.Text + "',TP_PlNo='" + txtTP_PlNo.Text + "',TP_PlRate='" + txtTP_PlRate.Text + "',TP_PlCost='" + txtTP_PlCost.Text + "',TP_PlWsCnt='" + txtTP_PlWsCnt.Text + "',TP_PlWsAmt='" + txtTP_PlWsAmt.Text + "',Ptve_ID='" + ddlPtve_ID.SelectedValue.ToString() + "',TP_Rate='" + txtTP_Rate.Text + "',TP_OS='" + txtTP_OS.Text + "',TP_CS='" + txtTP_CS.Text + "',TP_ReLev='" + txtTP_ReLev.Text + "',TP_Active='" + ddlTP_Active.Text + "',Mod_By='" + session + "',Mod_ByNode='',Mod_On= convert(datetime,getdate(),103) where TP_ID='" + txtTP_ID.Text + "'", con);
           
           
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            filldata();
            //cmdSubmit.Enabled = true; ;
            //cmdEdit.Enabled = false;
            clearAll();


        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter da = new SqlDataAdapter("select * from TopPaper_Master where TP_Name like '%" + txtSearchTopPaper.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgwTopPaper_Master.DataSource = dt;

            if (dgwTopPaper_Master.Rows.Count == 0)
            {

                cmdExcelReport.Visible = false;
            }

            else
            {
                cmdExcelReport.Visible = true;
            }

            
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            //cmdEdit.Visible = false;
            //cmdSubmit.Visible = true;
            clearAll();
        }

        private void clearAll()
        {
            
            txtTP_ID.Text = "";
            ddlGrp_ID.Text = "";
            ddlP_ID.Text = "";
            ddlPQ_ID.Text = "";
            txtTP_Name.Text = "";
            txtTP_PPLgth.Text = "";
            txtTP_PPWdth.Text = "";
            txtTP_PPBf.Text = "";
            txtTP_PPGram.Text = "";
            txtTP_PPRate.Text = "";
            txtTP_PPCost.Text = "";
            txtTP_LmLgth.Text = "";
            txtTP_LmWdth.Text ="";
            txtTP_LmRate.Text ="";
            txtTP_LmCost.Text = "";
            ddlTP_LmType.Text = "";
            txtTP_VrCost.Text = "";
            txtTP_VrLgth.Text = "";
            txtTP_VrRate.Text = "";
            txtTP_VrWdth.Text = "";
            ddlTP_VrType.Text = "";
            ddlTP_PlDivFact.Text = "";
            txtTP_PnColor.Text = "";
            txtTP_PnRate.Text = "";
            txtTP_PnCost.Text = "";
            txtTP_PlNo.Text = "";
            txtTP_PlRate.Text = "";
            txtTP_PlCost.Text = "";
            txtTP_PlWsCnt.Text = "";
            txtTP_PlWsAmt.Text = "";
            ddlPtve_ID.Text = "";
            txtTP_Rate.Text = "";
            txtTP_OS.Text = "";
            txtTP_CS.Text = "";
            txtTP_ReLev.Text = "";
            txtTP_PPWt.Text = "";
            txtTP_Name.Enabled = true;
            ddlGrp_ID.Enabled = true;
            ddlP_ID.Enabled = true;
            ddlPQ_ID.Enabled = true;
            ddlPtve_ID.Enabled = true;

            ddlTP_Active.SelectedText = "Yes";
            ddlTP_Active.Enabled = false;

            cmdEdit.Enabled = false;
            cmdSubmit.Enabled = true;

            
        }
        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void ddlPQ_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Display value in BF

            funclib = new FunctionLib();
            string strCon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmdBF = new SqlCommand("select a.BF_Value from Item_BF_Master a,PQuality_Master b where a.BF_ID=b.BF_ID and b.PQ_ID='" + ddlPQ_ID.SelectedValue.ToString() + "'",con);
            con.Open();
            SqlDataReader drBF = cmdBF.ExecuteReader();
            if (drBF.Read())
            {
                txtTP_PPBf.Text = drBF[0].ToString();

            }
            con.Close();


            //Display value in Grammage

            funclib = new FunctionLib();
            string strCon1 = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strCon1);
            SqlCommand cmdGSM = new SqlCommand("select a.GSM_Value from Item_GSM_Master a, PQuality_Master b where a.GSM_ID=b.GSM_ID and b.PQ_ID='" + ddlPQ_ID.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader drGSM = cmdGSM.ExecuteReader();
            if (drGSM.Read())
            {
                txtTP_PPGram.Text = drGSM[0].ToString();

            }
            con1.Close();


            //Display value in Rate

            funclib = new FunctionLib();
            string strCon2 = funclib.setConnection();
            SqlConnection con2 = new SqlConnection(strCon2);
            SqlCommand cmdRate = new SqlCommand("select PQ_Rate from PQuality_Master where PQ_ID='" + ddlPQ_ID.SelectedValue.ToString() + "'", con2);
            con2.Open();
            SqlDataReader drRate = cmdRate.ExecuteReader();
            if (drRate.Read())
            {
                txtTP_PPRate.Text = drRate[0].ToString();

            }
            con2.Close();


           // txtTP_PPWdth.Focus();

        }

        private void txtTP_PPWdth_Leave(object sender, EventArgs e)
        {
            //Calculating Cost of Paper
            if (txtTP_PPLgth.Text != "" && txtTP_PPWdth.Text != "" && txtTP_PPGram.Text != "")
            {
                double pLgth = Convert.ToDouble(txtTP_PPLgth.Text);
                double pwdth = Convert.ToDouble(txtTP_PPWdth.Text);
                double pGSM = Convert.ToDouble(txtTP_PPGram.Text);
                double pRate = Convert.ToDouble(txtTP_PPRate.Text);

                costPaper = ((pLgth * pwdth * pGSM * pRate) / sqMeter) / 1000;

                txtTP_PPCost.Text = costPaper.ToString("#0.00");

                double weight = (pLgth * pwdth * pGSM) / 1000;

                txtTP_PPWt.Text = Convert.ToString(Math.Round(weight,3));
            }
        }
        private void txtTP_PPLgth_Leave(object sender, EventArgs e)
        {
            if (txtTP_PPLgth.Text != "" && txtTP_PPWdth.Text != "" && txtTP_PPGram.Text != "")
            {

                double pLgth = Convert.ToDouble(txtTP_PPLgth.Text);
                double pwdth = Convert.ToDouble(txtTP_PPWdth.Text);
                double pGSM = Convert.ToDouble(txtTP_PPGram.Text);
                double weight = (pLgth * pwdth * pGSM) / 1000;

                txtTP_PPWt.Text = Convert.ToString(Math.Round(weight,3));
            }
        }
       
        private void txtTP_LmWdth_Leave(object sender, EventArgs e)
        {

            

        }

        private void txtTP_LmRate_Leave(object sender, EventArgs e)
        {
            //calculating cost of Lamination

            double lLength = Convert.ToDouble(txtTP_LmLgth.Text);
            double lWidth = Convert.ToDouble(txtTP_LmWdth.Text);
            double lRate = Convert.ToDouble(txtTP_LmRate.Text);

            
            double costLamintion = (lLength * lWidth * lRate) / 100;

            txtTP_LmCost.Text = costLamintion.ToString("#0.00");
           

        }

        private void txtTP_VrRate_Leave(object sender, EventArgs e)
        {
            //Calculating cost for Varnish

            double vlength = Convert.ToDouble(txtTP_VrLgth.Text);
            double vwidth = Convert.ToDouble(txtTP_VrWdth.Text);
            double vrate = Convert.ToDouble(txtTP_VrRate.Text);

            double costVarnish = (vlength * vwidth * vrate) / 100;

            txtTP_VrCost.Text = costVarnish.ToString("#0.00");
            
        }

        private void txtTP_PnRate_Leave(object sender, EventArgs e)
        {
            //Calculating cost for printing

            double pNo_colour = Convert.ToDouble(txtTP_PnColor.Text);
            double prate = Convert.ToDouble(txtTP_PnRate.Text);

            double pcost = (pNo_colour * prate) / 100;

            txtTP_PnCost.Text = pcost.ToString("#0.00");

        }

        private void txtTP_PlRate_Leave(object sender, EventArgs e)
        {
            //Calculating cost for plate

            double plate_colour = Convert.ToDouble(txtTP_PlNo.Text);
            double plate_rate = Convert.ToDouble(txtTP_PlRate.Text);
            double plate_DivFact = Convert.ToDouble(ddlTP_PlDivFact.Text);

            double plate_cost = (plate_colour * plate_rate) / plate_DivFact;

            txtTP_PlCost.Text = plate_cost.ToString("#0.00");


        }

        private void txtTP_PlWsCnt_Leave(object sender, EventArgs e)
        {
            //Calculating waste Amount in plate

            double pCost = Convert.ToDouble(txtTP_PlCost.Text);
            double pwaste_prcentage = Convert.ToDouble(txtTP_PlWsCnt.Text);

            double pwaste_amount = (pCost - pwaste_prcentage);

            txtTP_PlWsAmt.Text = pwaste_amount.ToString("#0.00");

        }

        private void ddlPtve_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show os Qty in textbox

            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmdOS = new SqlCommand("select Ptve_Qty_OS from Positive_Master where Ptve_ID='" + ddlPtve_ID.SelectedValue.ToString() + "'", con);
            con.Open();
            SqlDataReader dr = cmdOS.ExecuteReader();
            if (dr.Read())
            {
                txtTP_OS.Text = "";
                txtTP_OS.Text = dr[0].ToString();
            }
            con.Close();


            // show cs Qty in textbox
            funclib = new FunctionLib();
            string strcon1 = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon1);
            SqlCommand cmdCS = new SqlCommand("select Ptve_Qty_CS from Positive_Master where Ptve_ID='" + ddlPtve_ID.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmdCS.ExecuteReader();
            if (dr1.Read())
            {
               
                txtTP_CS.Text = dr1[0].ToString();
            }
            con1.Close();



            // show RO Qty in textbox
            funclib = new FunctionLib();
            string strcon2 = funclib.setConnection();
            SqlConnection con2 = new SqlConnection(strcon1);
            SqlCommand cmdRO = new SqlCommand("select Ptve_Qty_RO from Positive_Master where Ptve_ID='" + ddlPtve_ID.SelectedValue.ToString() + "'", con2);
            con2.Open();
            SqlDataReader dr2 = cmdRO.ExecuteReader();
            if (dr2.Read())
            {

                txtTP_ReLev.Text = dr2[0].ToString();
            }
            con2.Close();


        }

        private void ddlPtve_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddlTP_LmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show Lamit Rate in textbox
            funclib = new FunctionLib();
            string strcon1 = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon1);
            SqlCommand cmdRate = new SqlCommand("select Lamint_Rate from Item_Lamint_Master where Lamint_ID='"+ ddlTP_LmType.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmdRate.ExecuteReader();
            if (dr1.Read())
            {

                txtTP_LmRate.Text = dr1[0].ToString();
            }
            con1.Close();


        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "eBabyReport.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // strSQL = strSQL + " RPeB_BabyCard where Baby_Sex = '" & ddlBaby_Sex.Text.ToString() & "' and Baby_Kgs = '" & txtBaby_Kgs.Text.Trim().Replace("'", "''").ToString() & "' and Baby_Gms = '" & txtBaby_Gms.Text.Trim().Replace("'", "''").ToString() & "'"

                strSQL = strSQL + "select * from TopPaper_Master where TP_Name like '%" + txtSearchTopPaper.Text + "%'";
                //string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "eBabyReport.xls");
                string data = null;
                ////to fill the grid with user details
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con4 = new SqlConnection(strcon);
                int i = 0;
                int j = 0;
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;


                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlApp.Columns.ColumnWidth = 30;
                con4.Open();

                SqlDataAdapter da = new SqlDataAdapter(strSQL, con4);
                //da.TableMappings.Add("Item_Master", "Item_Master");
                //SqlDataAdapter da = new SqlDataAdapter("select a.TP_ID as TopPaperID,b.Grp_Name as GroupName,c.P_Name as PartyName,a.TP_Name as TopPaperName,d.PQ_Desc as PaperQuality, a.TP_PPLgth as TopPaperLength,a.TP_PPWdth as PaperWidth,a.TP_PPBf as PaperBf, a.TP_PPGram as PaperGram,a.TP_PPRate as PaperRate,a.TP_PPCost as PaperCost, a.TP_LmLgth as LaminationLength,a.TP_LmWdth as LaminationWidth, a.TP_LmRate as LaminationRate,a.TP_LmCost as LaminationCost ,a.TP_LmType as LaminationType,a.TP_VrLgth as VarnishLength,a.TP_VrWdth as varnishWidth,a.TP_VrRate as vanishRate,a.TP_VrCost as VarnishCost,a.TP_VrType as varnishType, a.TP_PnColor as NoColors,a.TP_PnRate as PlateRate,a.TP_PnCost as PlateCost,a.TP_PlDivFact as Divfactor, a.TP_PlNo as PlateNo,a.TP_PlRate as PlateRate,a.TP_PlCost as PlateCost, a.TP_PlWsCnt as WeightPercnt,a.TP_PlWsAmt as WeightAmt,e.Ptve_Name as PositiveName, a.TP_Rate as Rate,a.TP_OS as OpenStock,a.TP_CS as ClosingStock,a.TP_ReLev as ReOrder, a.TP_Active as Active from TopPaper_Master a,Group_Master b ,Party_Master c,PQuality_Master d,Positive_Master e  where b.Grp_ID=a.Grp_ID and b.Grp_ID=c.Grp_ID and b.Grp_ID=d.Grp_ID and a.PQ_ID=d.PQ_ID and a.P_ID=c.P_ID and a.Ptve_ID=e.Ptve_ID", con4);
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (i = 1; i <= ds.Tables[0].Columns.Count; i++)
                {
                    xlApp.Cells[1, i] = ds.Tables[0].Columns[i - 1].Caption.ToString();
                }
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[i + 3, j + 1] = data;
                    }


                }
                //xlApp.ActiveWorkbook.SaveCopyAs("C:\\ExcelReport.xls");
                //xlApp.ActiveWorkbook.Saved = true;
                //xlApp.Quit();
                //xlApp.ActiveWorkbook.SaveCopyAs("C:\\ExcelReport.xls");
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel File Created ");


            }

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

     

        
            
       

       
              
    }
}
