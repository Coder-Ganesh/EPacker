using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using ePacker1.App_Code;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;



namespace ePacker1
{
    public partial class RPeP_MasterItem : Form
    {
        private FunctionLib funclib;
       // private BindingManagerBase _bmbEmployees;
       // private DataSet _dataSet;
       //// private System.Windows.Forms.PictureBox pictureBox1;

        double Inch1, Inch2, Inch3, strTPPBF, strTPGsm, LenInchsheet, WidInchsheet, LenInchsheet1, WidInchsheet1;
        string pid, strSession, Group_ID;
        public RPeP_MasterItem()
        {
            InitializeComponent();
            strSession = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;

            ThreePly.Visible = false;
            FivePly.Visible = false;
            SevenPly.Visible = false;
            NinePly.Visible = false;
            ElevenPly.Visible = false;
            monthCalendar1.Visible = false;

            
           
        }

        private void RPeP_MasterItem_Load(object sender, EventArgs e)
        {
            txtI_ID.Visible = false;
            //ddlP_ID.Text = "";
            //ddlPB_ID.Text = "";
            //ddlTP_ID.Text = "";
            ////ddlGrp_ID.Text = "";
           txtTop_BF.Text = "0";
            //txtTop_GSM.Text = "";
            //txtTop_WPP.Text = "";
            //txtTop_BFPP.Text = "";
            //ddlStyle_ID.Text = "";
            // inserting item in ddlPly_Sheet
            //ddlPly_Sheet.Items.Add("1");
            ddlPly_Sheet.Items.Add("3");
            ddlPly_Sheet.Items.Add("5");
            ddlPly_Sheet.Items.Add("7");
            ddlPly_Sheet.Items.Add("9");
            ddlPly_Sheet.Items.Add("11");


            // inserting item in ddlDimn_Opt
            ddlDimn_Opt.Items.Add("Outer");
            ddlDimn_Opt.Items.Add("Inner");

            // inserting item in ddlEF_NF_PC

            ddlEF_NF_PC.Items.Add("EF");
            ddlEF_NF_PC.Items.Add("NF");
            ddlEF_NF_PC.Items.Add("PC");


            ddlCorrugation_Opt.Items.Add("Yes");
            ddlCorrugation_Opt.Items.Add("No");


            ddlPaper_Cutting.Items.Add("Yes");
            ddlPaper_Cutting.Items.Add("No");


            ddlPinning_Opt.Items.Add("Yes");
            ddlPinning_Opt.Items.Add("No");


            ddlPaper_Printed.Items.Add("Yes");
            ddlPaper_Printed.Items.Add("No");


            ddlScoring_Opt.Items.Add("Yes");
            ddlScoring_Opt.Items.Add("No");


            ddlPunching_Opt.Items.Add("Yes");
            ddlPunching_Opt.Items.Add("No");


            ddlPasting_Opt.Items.Add("Yes");
            ddlPasting_Opt.Items.Add("No");


            ddlSlotting_Opt.Items.Add("Yes");
            ddlSlotting_Opt.Items.Add("No");


            ddlPrinting_Opt.Items.Add("Yes");
            ddlPrinting_Opt.Items.Add("No");

            ddlPinning_InOut.Items.Add("Inside");
            ddlPinning_InOut.Items.Add("Outside");

            ddlSide_Pasting.Items.Add("Yes");
            ddlSide_Pasting.Items.Add("No");


            ddlCanvas_Opt.Items.Add("Yes");
            ddlCanvas_Opt.Items.Add("No");


            ddlRate_Type.Items.Add("Average Weight");
            ddlRate_Type.Items.Add("Total Weight");
            ddlRate_Type.Items.Add("Piece");


            ddlFor_Pedilite.Items.Add("Yes");
            ddlFor_Pedilite.Items.Add("No");


            ddlI_Active.Items.Add("Yes");
            ddlI_Active.Items.Add("No");
            ddlI_Active.SelectedText = "Yes";
            ddlI_Active.Enabled = false;


            ddlI_Lock.Items.Add("Yes");
            ddlI_Lock.Items.Add("No");
            ddlI_Lock.SelectedText = "No";
            ddlI_Lock.Enabled = false;

            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();

            ////Displaying values in Group Combobox
            //SqlConnection con1 = new SqlConnection(strcon);
            //con1.Open();
            //SqlDataAdapter da = new SqlDataAdapter("select Grp_ID,(Grp_SName +' ('+ Grp_Name +')') as Grp_Data from Group_Master  where Grp_Active='yes' ", con1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //ddlGrp_ID.DataSource = dt;
            //ddlGrp_ID.DisplayMember = dt.Columns[1].ToString();
            //ddlGrp_ID.ValueMember = dt.Columns[0].ToString();
            //con1.Close();



            //ddlP_ID.Text = "";
            //ddlPB_ID.Text = "";
            //ddlTP_ID.Text = "";
            //ddlGrp_ID.Text = "";
            //txtTop_BF.Text = "";
            //txtTop_GSM.Text = "";
            //txtTop_WPP.Text = "";
            //txtTop_BFPP.Text = "";
            //ddlStyle_ID.Text = "";
            //pictureBox1.Visible = false;

            //Displaying values in P_ID Combobox
            
            ddlP_ID.Text = "";
            SqlConnection con2 = new SqlConnection(strcon);
            con2.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT '' as P_ID, '' as P_Name UNION select a.P_ID,a.P_Name from Party_Master as a,Group_Master as b where P_Active='Yes' and a.Grp_ID='" + Group_ID + "' and a.Grp_ID=b.Grp_ID and P_Active='Yes'", con2);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            ddlP_ID.DataSource = dt1;
            ddlP_ID.DisplayMember = dt1.Columns[1].ToString();
            ddlP_ID.ValueMember = dt1.Columns[0].ToString();
            con2.Close();



            //Displaying values in Style_ID Combobox
            ddlStyle_ID.Text = "";
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as Style_ID, '' as Style_No UNION select a.Style_ID,a.Style_No from Item_Style_Master as a,Group_Master as b where Style_Active='Yes' and a.Grp_ID='" + Group_ID + "' and a.Grp_ID=b.Grp_ID and Style_Active='Yes'", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            ddlStyle_ID.DataSource = dt2;
            ddlStyle_ID.DisplayMember = dt2.Columns[1].ToString();
            ddlStyle_ID.ValueMember = dt2.Columns[0].ToString();
            con.Close();


            //Displaying values in TopPapare Combobox
            ddlTP_ID.Text = "";
            SqlConnection con3 = new SqlConnection(strcon);
            con3.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("SELECT '' as TP_ID, '' as TP_Name UNION select a.TP_ID,a.TP_Name from TopPaper_Master as a,Group_Master as b where a.Grp_ID='" + Group_ID + "' and a.Grp_ID=b.Grp_ID and a.TP_Active='Yes'", con3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            ddlTP_ID.DataSource = dt3;
            ddlTP_ID.DisplayMember = dt3.Columns[1].ToString();
            ddlTP_ID.ValueMember = dt3.Columns[0].ToString();
            con.Close();
            

            // DisplayItem();




        }

        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           // ddlP_ID.Text = "";
           // ddlPB_ID.Text = "";
           // ddlTP_ID.Text = "";
           // ddlGrp_ID.Text = "";
           // txtTop_BF.Text = "";
           // txtTop_GSM.Text = "";
           // txtTop_WPP.Text = "";
           // txtTop_BFPP.Text = "";
           // ddlStyle_ID.Text = "";
           // pictureBox1.Visible = false;

           // //Displaying values in P_ID Combobox
           // funclib = new FunctionLib();
           // string strcon = funclib.setConnection();
           // ddlP_ID.Text = "";
           // SqlConnection con2 = new SqlConnection(strcon);
           // con2.Open();
           // SqlDataAdapter da1 = new SqlDataAdapter("select a.P_ID,a.P_Name from Party_Master as a,Group_Master as b where P_Active='Yes' and a.Grp_ID='" + Group_ID + "' and a.Grp_ID=b.Grp_ID and P_Active='Yes'", con2);
           // DataTable dt1 = new DataTable();
           // da1.Fill(dt1);
           // ddlP_ID.DataSource = dt1;
           // ddlP_ID.DisplayMember = dt1.Columns[1].ToString();
           // ddlP_ID.ValueMember = dt1.Columns[0].ToString();
           // con2.Close();

           // //Displaying values in Style_ID Combobox
           // ddlStyle_ID.Text = "";
           // SqlConnection con = new SqlConnection(strcon);
           // con.Open();
           // SqlDataAdapter da2 = new SqlDataAdapter("select a.Style_ID,a.Style_No from Item_Style_Master as a,Group_Master as b where Style_Active='Yes' and a.Grp_ID='"+Group_ID+"' and a.Grp_ID=b.Grp_ID and Style_Active='Yes'", con);
           // DataTable dt2 = new DataTable();
           // da2.Fill(dt2);
           // ddlStyle_ID.DataSource = dt2;
           // ddlStyle_ID.DisplayMember = dt2.Columns[1].ToString();
           // ddlStyle_ID.ValueMember = dt2.Columns[0].ToString();
           // con.Close();


           // //Displaying values in TopPapare Combobox
           // ddlTP_ID.Text = "";
           // SqlConnection con3 = new SqlConnection(strcon);
           // con3.Open();
           // SqlDataAdapter da3 = new SqlDataAdapter("select a.TP_ID,a.TP_Name from TopPaper_Master as a,Group_Master as b where a.Grp_ID='"+Group_ID+"' and a.Grp_ID=b.Grp_ID and a.TP_Active='Yes'", con3);
           // DataTable dt3 = new DataTable();
           // da3.Fill(dt3);
           // ddlTP_ID.DataSource = dt3;
           // ddlTP_ID.DisplayMember = dt3.Columns[1].ToString();
           // ddlTP_ID.ValueMember = dt3.Columns[0].ToString();
           // con.Close();

           //// DisplayItem();

        }

        private void ddlP_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlPB_ID.Text = "";
            ////Displaying values in PB_ID Combobox
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con3 = new SqlConnection(strcon);
            con3.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as PB_ID, '' as PB_Name UNION select a.PB_ID,a.PB_Name from Party_Buyer as a,Party_Master as b where PB_Active='Yes' and a.P_ID='" + ddlP_ID.SelectedValue.ToString() + "' and a.P_ID=b.P_ID and PB_Active='Yes'", con3);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            ddlPB_ID.DataSource = dt2;
            ddlPB_ID.DisplayMember = dt2.Columns[1].ToString();
            ddlPB_ID.ValueMember = dt2.Columns[0].ToString();
            con3.Close();


        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {

            //if (ddlGrp_ID.Text == "")//checking for blank Grp_ID combo field 
            //{
            //    MessageBox.Show("Please select Group ID");
            //    ddlGrp_ID.Focus();
            //}
          if (ddlP_ID.Text == "")//checking for blank PQ_BF text field 
            {
                MessageBox.Show("Please Select P_ID");
                ddlP_ID.Focus();
            }
            else if (ddlPB_ID.Text == "")//checking for blank GSM text field 
            {
                MessageBox.Show("Please Select PB_ID");
                ddlPB_ID.Focus();
            }
            else if (txtI_Name.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Name");
                txtI_Name.Focus();
            }
            else if (ddlStyle_ID.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Style_ID");
                ddlStyle_ID.Focus();
            }

            else if (ddlPly_Sheet.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Ply_Sheet");
                ddlPly_Sheet.Focus();
            }
            else if (txtLength_Inch.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Length_Inch");
                txtLength_Inch.Focus();
            }



            else if (txtWidth_Inch.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Width_Inch");
                txtWidth_Inch.Focus();
            }
            else if (txtHeight_Inch.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Height_Inch");
                txtHeight_Inch.Focus();
            }

            else if (txtLength_MM.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Length_MM");
                txtLength_MM.Focus();
            }
            else if (txtWidth_MM.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Width_MM");
                txtWidth_MM.Focus();
            }





            else if (txtHeight_MM.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Height_MM");
                txtHeight_MM.Focus();
            }
            else if (ddlDimn_Opt.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Dimn_Opt");
                ddlDimn_Opt.Focus();
            }

            else if (txtLength_Inch_Sheet.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Length_Inch_Sheet");
                txtLength_Inch_Sheet.Focus();
            }
            else if (txtWidth_Inch_Sheet.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Width_Inch_Sheet");
                txtWidth_Inch_Sheet.Focus();
            }



            else if (ddlEF_NF_PC.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please select EF_NF_PC");
                ddlEF_NF_PC.Focus();
            }
            else if (txtBundle_Packet.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Bundle_Packet");
                txtBundle_Packet.Focus();
            }
            else if (txtBox_PerSheet.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Box_PerSheet ");
                txtBox_PerSheet.Focus();
            }
            else if (ddlCorrugation_Opt.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Corrugation_Opt");
                ddlCorrugation_Opt.Focus();
            }

            else if (ddlPaper_Cutting.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please select Paper_Cutting");
                ddlPaper_Cutting.Focus();
            }
            else if (ddlPrinting_Opt.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Printing_Opt");
                ddlPrinting_Opt.Focus();
            }

            
            else if (ddlPaper_Printed.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please select Paper_Printed");
                ddlPaper_Printed.Focus();
            }
            else if (ddlTP_ID.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select TP_ID");
                ddlTP_ID.Focus();
            }




            else if (ddlScoring_Opt.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please select Scoring_Opt");
                ddlScoring_Opt.Focus();
            }
            else if (ddlPunching_Opt.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select ddlPunching_Opt");
                ddlPunching_Opt.Focus();
            }

            else if (ddlPasting_Opt.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please select Pasting_Opt ");
                ddlPasting_Opt.Focus();
            }
            else if (ddlSlotting_Opt.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Slotting_Opt");
                ddlSlotting_Opt.Focus();
            }
            else if (ddlPinning_Opt.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please Select Pinning_Opt ");
                ddlPinning_Opt.Focus();
            }
           
            else if (ddlSide_Pasting.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Side_Pasting");
                ddlSide_Pasting.Focus();
            }

           
           

            else if (txtSell_Rate.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Sell_Rate");
                txtSell_Rate.Focus();
            }
            else if (ddlRate_Type.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Rate_Type");
                ddlRate_Type.Focus();
            }

            else if (txtExcise_Code.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Excise_Code");
                txtExcise_Code.Focus();
            }
            else if (txtTop_BF.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select Top_BF");
                txtTop_BF.Focus();
            }
            else if (txtTop_GSM.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Top_GSM ");
                txtTop_GSM.Focus();
            }
            else if (txtTop_WPP.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please enter Top_WPP");
                txtTop_WPP.Focus();
            }

            else if (txtTop_BFPP.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Top_BFPP");
                txtTop_BFPP.Focus();
            }
            else if (txtWeight_Pcs.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please enter Weight_Pcs");
                txtWeight_Pcs.Focus();
            }

            else if (txtBF_Pcs.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter BF_Pcs");
                txtBF_Pcs.Focus();
            }
            else if (txtArtWrk_Code.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter ArtWrk_Code ");
                txtArtWrk_Code.Focus();
            }
            else if (txtRevi_No.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please enter Revi_No");
                txtRevi_No.Focus();
            }

            else if (txtArt_Dt.Text == "")//checking for blank PQ_Rate text field 
            {
                MessageBox.Show("Please enter Art_Dt");
                txtArt_Dt.Focus();
            }
            else if (txtSpeci_Code.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please enter Speci_Code");
                txtSpeci_Code.Focus();
            }

            
            

            else
            {
                if (ddlPly_Sheet.Text == "3")
                {

                    string txtTopBF3 = Convert.ToString(txtTop_BF3.Text);
                    txtTop_BF.Text = txtTopBF3.ToString();

                    string txtTopGsm = Convert.ToString(txtTop_GSM3.Text);
                    txtTop_GSM.Text = txtTopGsm.ToString();

                    string txtTopWpp = Convert.ToString(txtTop_WPP3.Text);
                    txtTop_WPP.Text = txtTopWpp.ToString();


                    string txtTopBFPP = Convert.ToString(txtTop_BFPP3.Text);
                    txtTop_BFPP.Text = txtTopBFPP.ToString();
                }

                if (ddlPly_Sheet.Text == "5")
                {

                    string txtTopBF3 = Convert.ToString(txtTop_BF5.Text);
                    txtTop_BF.Text = txtTopBF3.ToString();

                    string txtTopGsm = Convert.ToString(txtTop_GSM5.Text);
                    txtTop_GSM.Text = txtTopGsm.ToString();

                    string txtTopWpp = Convert.ToString(txtTop_WPP5.Text);
                    txtTop_WPP.Text = txtTopWpp.ToString();


                    string txtTopBFPP = Convert.ToString(txtTop_BFPP5.Text);
                    txtTop_BFPP.Text = txtTopBFPP.ToString();
                }

                if (ddlPly_Sheet.Text == "7")
                {

                    string txtTopBF3 = Convert.ToString(txtTop_BF.Text);
                    txtTop_BF.Text = txtTopBF3.ToString();

                    string txtTopGsm = Convert.ToString(txtTop_GSM.Text);
                    txtTop_GSM.Text = txtTopGsm.ToString();

                    string txtTopWpp = Convert.ToString(txtTop_WPP.Text);
                    txtTop_WPP.Text = txtTopWpp.ToString();


                    string txtTopBFPP = Convert.ToString(txtTop_BFPP.Text);
                    txtTop_BFPP.Text = txtTopBFPP.ToString();
                }

                if (ddlPly_Sheet.Text == "9")
                {

                    string txtTopBF3 = Convert.ToString(txtTop_BF9.Text);
                    txtTop_BF.Text = txtTopBF3.ToString();

                    string txtTopGsm = Convert.ToString(txtTop_GSM9.Text);
                    txtTop_GSM.Text = txtTopGsm.ToString();

                    string txtTopWpp = Convert.ToString(txtTop_WPP9.Text);
                    txtTop_WPP.Text = txtTopWpp.ToString();


                    string txtTopBFPP = Convert.ToString(txtTop_BFPP9.Text);
                    txtTop_BFPP.Text = txtTopBFPP.ToString();
                }

                if (ddlPly_Sheet.Text == "11")
                {

                    string txtTopBF3 = Convert.ToString(txtTop_BF11.Text);
                    txtTop_BF.Text = txtTopBF3.ToString();

                    string txtTopGsm = Convert.ToString(txtTop_GSM11.Text);
                    txtTop_GSM.Text = txtTopGsm.ToString();

                    string txtTopWpp = Convert.ToString(txtTop_WPP11.Text);
                    txtTop_WPP.Text = txtTopWpp.ToString();


                    string txtTopBFPP = Convert.ToString(txtTop_BFPP11.Text);
                    txtTop_BFPP.Text = txtTopBFPP.ToString();
                }
                //Insert the details into the table
                funclib = new FunctionLib();

                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);

                if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtI_Name.Text = funclib.FirstCap(txtI_Name.Text);
                    pid = funclib.I_ID("I", con, "select I_ID from Item_Master order by I_ID desc");
                    // con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Item_Master values('" + pid + "','" + Group_ID + "','" + ddlP_ID.SelectedValue.ToString() + "','" + ddlPB_ID.SelectedValue.ToString() + "','" + txtI_Name.Text.Trim().Replace("'", "''").ToString() + "','" + ddlStyle_ID.SelectedValue.ToString() + "','" + ddlPly_Sheet.Text + "','" + txtLength_Inch.Text.Trim().Replace("'", "''").ToString() + "','" + txtWidth_Inch.Text.Trim().Replace("'", "''").ToString() + "','" + txtHeight_Inch.Text.Trim().Replace("'", "''").ToString() + "','" + txtLength_MM.Text.Trim().Replace("'", "''").ToString() + "','" + txtWidth_MM.Text.Trim().Replace("'", "''").ToString() + "','" + txtHeight_MM.Text.Trim().Replace("'", "''").ToString() + "','" + ddlDimn_Opt.Text + "','" + txtLength_MM_Conv.Text.Trim().Replace("'", "''").ToString() + "','" + txtWidth_MM_Conv.Text.Trim().Replace("'", "''").ToString() + "','" + txtHeight_MM_Conv.Text.Trim().Replace("'", "''").ToString() + "','" + txtLength_Inch_Sheet.Text.Trim().Replace("'", "''").ToString() + "','" + txtWidth_Inch_Sheet.Text.Trim().Replace("'", "''").ToString() + "','" + txtLength_Inch_Sheet1.Text.Trim().Replace("'", "''").ToString() + "','" + txtWidth_Inch_Sheet1.Text.Trim().Replace("'", "''").ToString() + "','" + ddlEF_NF_PC.Text + "','" + txtBundle_Packet.Text.Trim().Replace("'", "''").ToString() + "','" + txtBox_PerSheet.Text.Trim().Replace("'", "''").ToString() + "','" + ddlCorrugation_Opt.Text + "','" + ddlPaper_Cutting.Text + "','" + ddlPrinting_Opt.Text + "','" + txtNo_Colors.Text.Trim().Replace("'", "''").ToString() + "','" + txtPrntColor_Name.Text.Trim().Replace("'", "''").ToString() + "','" + ddlPaper_Printed.Text + "','" + ddlTP_ID.SelectedValue.ToString() + "','" + ddlScoring_Opt.Text + "','" + ddlPunching_Opt.Text + "','" + ddlPasting_Opt.Text + "','" + ddlSlotting_Opt.Text + "','" + ddlPinning_Opt.Text + "','" + txtNo_Pins.Text.Trim().Replace("'", "''").ToString() + "','" + ddlPinning_InOut.Text + "','" + ddlSide_Pasting.Text + "','" + txtRate_SidePastg.Text.Trim().Replace("'", "''").ToString() + "','" + ddlCanvas_Opt.Text + "','" + txtSide_Canvas.Text.Trim().Replace("'", "''").ToString() + "','" + txtCanvColor_Name.Text.Trim().Replace("'", "''").ToString() + "','" + txtSell_Rate.Text.Trim().Replace("'", "''").ToString() + "','" + ddlRate_Type.Text + "','" + txtExcise_Code.Text.Trim().Replace("'", "''").ToString() + "','" + txtTop_BF.Text.Trim().Replace("'", "''").ToString() + "','" + txtTop_GSM.Text.Trim().Replace("'", "''").ToString() + "','" + txtTop_WPP.Text.Trim().Replace("'", "''").ToString() + "','" + txtTop_BFPP.Text.Trim().Replace("'", "''").ToString() + "','" + txtWeight_Pcs.Text.Trim().Replace("'", "''").ToString() + "','" + txtBF_Pcs.Text.Trim().Replace("'", "''").ToString() + "','" + txtArtWrk_Code.Text.Trim().Replace("'", "''").ToString() + "','" + txtRevi_No.Text.Trim().Replace("'", "''").ToString() + "',convert(datetime,'" + txtArt_Dt.Text.Trim().ToString() + "',103),'" + txtSpeci_Code.Text.Trim().Replace("'", "''").ToString() + "','" + ddlFor_Pedilite.Text + "','" + txtPedilite_BS.Text.Trim().Replace("'", "''").ToString() + "','" + txtPedilite_GSM.Text.Trim().Replace("'", "''").ToString() + "','" + txtPedilite_WtBox.Text.Trim().Replace("'", "''").ToString() + "','" + Pedilite_PReq.Text.Trim().Replace("'", "''").ToString() + "','" + ddlI_Lock.Text + "','" + ddlI_Active.Text + "','" + strSession + "','',convert(datetime,getdate(),103),'" + strSession + "','',convert(datetime,getdate(),103))", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
             
                    con.Close();

                    if (i > 0)
                    {

                        if (ddlPly_Sheet.Text == "3")
                        {
                            //Insert For Backing In ThreePly
                            funclib = new FunctionLib();
                            string strcon1 = funclib.setConnection();
                            SqlConnection con1 = new SqlConnection(strcon1);
                            string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + txtTop_BF31.Text.Trim().Replace("'", "''").ToString() + "','" + txtTop_GSM31.Text.Trim().Replace("'", "''").ToString() + "','" + txtTop_WPP31.Text.Trim().Replace("'", "''").ToString() + "','" + txtTop_BFPP31.Text.Trim().Replace("'", "''").ToString() + "')", con1);
                            con1.Open();
                            int A = cmd1.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con1.Close();


                            //Insert For Flute In ThreePly
                            funclib = new FunctionLib();
                            string strcon2 = funclib.setConnection();
                            SqlConnection con2 = new SqlConnection(strcon2);
                            string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + txtTop_BF32.Text.Trim().Replace("'", "''").ToString() + "','" + txtTop_GSM32.Text.Trim().Replace("'", "''").ToString() + "','" + txtTop_WPP32.Text.Trim().Replace("'", "''").ToString() + "','" + txtTop_BFPP32.Text.Trim().Replace("'", "''").ToString() + "')", con2);
                            con2.Open();
                            int B = cmd2.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con2.Close();

                        }
                        if (ddlPly_Sheet.Text == "5")
                        {
                            //Insert For Backing In FivePly
                            funclib = new FunctionLib();
                            string strcon1 = funclib.setConnection();
                            SqlConnection con1 = new SqlConnection(strcon1);
                            string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + txtTop_BF51.Text.Trim().Replace("'", "''").ToString() + "','" + textBox35.Text.Trim().Replace("'", "''").ToString() + "','" + textBox34.Text.Trim().Replace("'", "''").ToString() + "','" + textBox33.Text.Trim().Replace("'", "''").ToString() + "')", con1);
                            con1.Open();
                            int A = cmd1.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con1.Close();


                            //Insert For Flute In FivePly
                            funclib = new FunctionLib();
                            string strcon2 = funclib.setConnection();
                            SqlConnection con2 = new SqlConnection(strcon2);
                            string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + txtTop_BF52.Text.Trim().Replace("'", "''").ToString() + "','" + textBox31.Text.Trim().Replace("'", "''").ToString() + "','" + textBox30.Text.Trim().Replace("'", "''").ToString() + "','" + textBox29.Text.Trim().Replace("'", "''").ToString() + "')", con2);
                            con2.Open();
                            int B = cmd2.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con2.Close();


                            //Insert For Backing In FivePly
                            funclib = new FunctionLib();
                            string strcon3 = funclib.setConnection();
                            SqlConnection con3 = new SqlConnection(strcon3);
                            string Rid2 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd3 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid2 + "','Backing','" + txtTop_BF53.Text.Trim().Replace("'", "''").ToString() + "','" + textBox15.Text.Trim().Replace("'", "''").ToString() + "','" + textBox14.Text.Trim().Replace("'", "''").ToString() + "','" + textBox13.Text.Trim().Replace("'", "''").ToString() + "')", con3);
                            con3.Open();
                            int C = cmd3.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con3.Close();


                            //Insert For Flute In FivePly
                            funclib = new FunctionLib();
                            string strcon4 = funclib.setConnection();
                            SqlConnection con4 = new SqlConnection(strcon4);
                            string Rid4 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd4 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid4 + "','Flute','" + txtTop_BF54.Text.Trim().Replace("'", "''").ToString() + "','" + textBox11.Text.Trim().Replace("'", "''").ToString() + "','" + textBox10.Text.Trim().Replace("'", "''").ToString() + "','" + textBox9.Text.Trim().Replace("'", "''").ToString() + "')", con4);
                            con4.Open();
                            int D = cmd4.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con4.Close();

                        }

                        if (ddlPly_Sheet.Text == "7")
                        {
                            //Insert For Backing In FivePly
                            funclib = new FunctionLib();
                            string strcon1 = funclib.setConnection();
                            SqlConnection con1 = new SqlConnection(strcon1);
                            string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + textBox80.Text.Trim().Replace("'", "''").ToString() + "','" + textBox79.Text.Trim().Replace("'", "''").ToString() + "','" + textBox78.Text.Trim().Replace("'", "''").ToString() + "','" + textBox77.Text.Trim().Replace("'", "''").ToString() + "')", con1);
                            con1.Open();
                            int A = cmd1.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con1.Close();


                            //Insert For Flute In FivePly
                            funclib = new FunctionLib();
                            string strcon2 = funclib.setConnection();
                            SqlConnection con2 = new SqlConnection(strcon2);
                            string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + textBox76.Text.Trim().Replace("'", "''").ToString() + "','" + textBox75.Text.Trim().Replace("'", "''").ToString() + "','" + textBox74.Text.Trim().Replace("'", "''").ToString() + "','" + textBox73.Text.Trim().Replace("'", "''").ToString() + "')", con2);
                            con2.Open();
                            int B = cmd2.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con2.Close();


                            //Insert For Backing In FivePly
                            funclib = new FunctionLib();
                            string strcon3 = funclib.setConnection();
                            SqlConnection con3 = new SqlConnection(strcon3);
                            string Rid2 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd3 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid2 + "','Backing','" + textBox72.Text.Trim().Replace("'", "''").ToString() + "','" + textBox71.Text.Trim().Replace("'", "''").ToString() + "','" + textBox70.Text.Trim().Replace("'", "''").ToString() + "','" + textBox69.Text.Trim().Replace("'", "''").ToString() + "')", con3);
                            con3.Open();
                            int C = cmd3.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con3.Close();


                            //Insert For Flute In FivePly
                            funclib = new FunctionLib();
                            string strcon4 = funclib.setConnection();
                            SqlConnection con4 = new SqlConnection(strcon4);
                            string Rid4 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd4 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid4 + "','Flute','" + textBox68.Text.Trim().Replace("'", "''").ToString() + "','" + textBox67.Text.Trim().Replace("'", "''").ToString() + "','" + textBox66.Text.Trim().Replace("'", "''").ToString() + "','" + textBox65.Text.Trim().Replace("'", "''").ToString() + "')", con4);
                            con4.Open();
                            int D = cmd4.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con4.Close();



                            //Insert For Backing In FivePly
                            funclib = new FunctionLib();
                            string strcon5 = funclib.setConnection();
                            SqlConnection con5 = new SqlConnection(strcon5);
                            string Rid5 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd5 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid5 + "','Backing','" + textBox64.Text.Trim().Replace("'", "''").ToString() + "','" + textBox63.Text.Trim().Replace("'", "''").ToString() + "','" + textBox62.Text.Trim().Replace("'", "''").ToString() + "','" + textBox61.Text.Trim().Replace("'", "''").ToString() + "')", con5);
                            con5.Open();
                            int E = cmd5.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con5.Close();


                            //Insert For Flute In FivePly
                            funclib = new FunctionLib();
                            string strcon6 = funclib.setConnection();
                            SqlConnection con6 = new SqlConnection(strcon6);
                            string Rid6 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd6 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid6 + "','Flute','" + textBox60.Text.Trim().Replace("'", "''").ToString() + "','" + textBox59.Text.Trim().Replace("'", "''").ToString() + "','" + textBox58.Text.Trim().Replace("'", "''").ToString() + "','" + textBox57.Text.Trim().Replace("'", "''").ToString() + "')", con6);
                            con6.Open();
                            int F = cmd6.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con6.Close();

                        }



                        if (ddlPly_Sheet.Text == "9")
                        {
                            //Insert For Backing In NinePly
                            funclib = new FunctionLib();
                            string strcon1 = funclib.setConnection();
                            SqlConnection con1 = new SqlConnection(strcon1);
                            string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + textBox56.Text.Trim().Replace("'", "''").ToString() + "','" + textBox55.Text.Trim().Replace("'", "''").ToString() + "','" + textBox54.Text.Trim().Replace("'", "''").ToString() + "','" + textBox53.Text.Trim().Replace("'", "''").ToString() + "')", con1);
                            con1.Open();
                            int A = cmd1.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con1.Close();


                            //Insert For Flute In NinePly
                            funclib = new FunctionLib();
                            string strcon2 = funclib.setConnection();
                            SqlConnection con2 = new SqlConnection(strcon2);
                            string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + textBox52.Text.Trim().Replace("'", "''").ToString() + "','" + textBox51.Text.Trim().Replace("'", "''").ToString() + "','" + textBox50.Text.Trim().Replace("'", "''").ToString() + "','" + textBox49.Text.Trim().Replace("'", "''").ToString() + "')", con2);
                            con2.Open();
                            int B = cmd2.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con2.Close();


                            //Insert For Backing In NinePly
                            funclib = new FunctionLib();
                            string strcon3 = funclib.setConnection();
                            SqlConnection con3 = new SqlConnection(strcon3);
                            string Rid2 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd3 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid2 + "','Backing','" + textBox48.Text.Trim().Replace("'", "''").ToString() + "','" + textBox47.Text.Trim().Replace("'", "''").ToString() + "','" + textBox46.Text.Trim().Replace("'", "''").ToString() + "','" + textBox45.Text.Trim().Replace("'", "''").ToString() + "')", con3);
                            con3.Open();
                            int C = cmd3.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con3.Close();


                            //Insert For Flute In NinePly
                            funclib = new FunctionLib();
                            string strcon4 = funclib.setConnection();
                            SqlConnection con4 = new SqlConnection(strcon4);
                            string Rid4 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd4 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid4 + "','Flute','" + textBox44.Text.Trim().Replace("'", "''").ToString() + "','" + textBox43.Text.Trim().Replace("'", "''").ToString() + "','" + textBox42.Text.Trim().Replace("'", "''").ToString() + "','" + textBox41.Text.Trim().Replace("'", "''").ToString() + "')", con4);
                            con4.Open();
                            int D = cmd4.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con4.Close();



                            //Insert For Backing In NinePly
                            funclib = new FunctionLib();
                            string strcon5 = funclib.setConnection();
                            SqlConnection con5 = new SqlConnection(strcon5);
                            string Rid5 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd5 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid5 + "','Backing','" + textBox8.Text.Trim().Replace("'", "''").ToString() + "','" + textBox7.Text.Trim().Replace("'", "''").ToString() + "','" + textBox6.Text.Trim().Replace("'", "''").ToString() + "','" + textBox5.Text.Trim().Replace("'", "''").ToString() + "')", con5);
                            con5.Open();
                            int E = cmd5.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con5.Close();


                            //Insert For Flute In NinePly
                            funclib = new FunctionLib();
                            string strcon6 = funclib.setConnection();
                            SqlConnection con6 = new SqlConnection(strcon6);
                            string Rid6 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd6 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid6 + "','Flute','" + textBox4.Text.Trim().Replace("'", "''").ToString() + "','" + textBox3.Text.Trim().Replace("'", "''").ToString() + "','" + textBox2.Text.Trim().Replace("'", "''").ToString() + "','" + textBox1.Text.Trim().Replace("'", "''").ToString() + "')", con6);
                            con6.Open();
                            int F = cmd6.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con6.Close();


                            //Insert For Backing In NinePly
                            funclib = new FunctionLib();
                            string strcon7 = funclib.setConnection();
                            SqlConnection con7 = new SqlConnection(strcon7);
                            string Rid7 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd7 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid7 + "','Backing','" + textBox92.Text.Trim().Replace("'", "''").ToString() + "','" + textBox91.Text.Trim().Replace("'", "''").ToString() + "','" + textBox90.Text.Trim().Replace("'", "''").ToString() + "','" + textBox89.Text.Trim().Replace("'", "''").ToString() + "')", con7);
                            con7.Open();
                            int G = cmd7.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con7.Close();


                            //Insert For Flute In NinePly
                            funclib = new FunctionLib();
                            string strcon8 = funclib.setConnection();
                            SqlConnection con8 = new SqlConnection(strcon8);
                            string Rid8 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd8 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid8 + "','Flute','" + textBox88.Text.Trim().Replace("'", "''").ToString() + "','" + textBox87.Text.Trim().Replace("'", "''").ToString() + "','" + textBox86.Text.Trim().Replace("'", "''").ToString() + "','" + textBox85.Text.Trim().Replace("'", "''").ToString() + "')", con8);
                            con8.Open();
                            int H = cmd8.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con8.Close();

                        }

                        //Insert Into ElevenPly
                        if (ddlPly_Sheet.Text == "11")
                        {
                            //Insert For Backing In ElevenPly
                            funclib = new FunctionLib();
                            string strcon1 = funclib.setConnection();
                            SqlConnection con1 = new SqlConnection(strcon1);
                            string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + textBox124.Text.Trim().Replace("'", "''").ToString() + "','" + textBox123.Text.Trim().Replace("'", "''").ToString() + "','" + textBox122.Text.Trim().Replace("'", "''").ToString() + "','" + textBox121.Text.Trim().Replace("'", "''").ToString() + "')", con1);
                            con1.Open();
                            int A = cmd1.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con1.Close();


                            //Insert For Flute In ElevenPly
                            funclib = new FunctionLib();
                            string strcon2 = funclib.setConnection();
                            SqlConnection con2 = new SqlConnection(strcon2);
                            string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + textBox120.Text.Trim().Replace("'", "''").ToString() + "','" + textBox119.Text.Trim().Replace("'", "''").ToString() + "','" + textBox118.Text.Trim().Replace("'", "''").ToString() + "','" + textBox117.Text.Trim().Replace("'", "''").ToString() + "')", con2);
                            con2.Open();
                            int B = cmd2.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con2.Close();


                            //Insert For Backing In ElevenPly
                            funclib = new FunctionLib();
                            string strcon3 = funclib.setConnection();
                            SqlConnection con3 = new SqlConnection(strcon3);
                            string Rid2 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd3 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid2 + "','Backing','" + textBox116.Text.Trim().Replace("'", "''").ToString() + "','" + textBox115.Text.Trim().Replace("'", "''").ToString() + "','" + textBox114.Text.Trim().Replace("'", "''").ToString() + "','" + textBox113.Text.Trim().Replace("'", "''").ToString() + "')", con3);
                            con3.Open();
                            int C = cmd3.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con3.Close();


                            //Insert For Flute In ElevenPly
                            funclib = new FunctionLib();
                            string strcon4 = funclib.setConnection();
                            SqlConnection con4 = new SqlConnection(strcon4);
                            string Rid4 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd4 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid4 + "','Flute','" + textBox112.Text.Trim().Replace("'", "''").ToString() + "','" + textBox111.Text.Trim().Replace("'", "''").ToString() + "','" + textBox110.Text.Trim().Replace("'", "''").ToString() + "','" + textBox109.Text.Trim().Replace("'", "''").ToString() + "')", con4);
                            con4.Open();
                            int D = cmd4.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con4.Close();



                            //Insert For Backing In ElevenPly
                            funclib = new FunctionLib();
                            string strcon5 = funclib.setConnection();
                            SqlConnection con5 = new SqlConnection(strcon5);
                            string Rid5 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd5 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid5 + "','Backing','" + textBox108.Text.Trim().Replace("'", "''").ToString() + "','" + textBox107.Text.Trim().Replace("'", "''").ToString() + "','" + textBox106.Text.Trim().Replace("'", "''").ToString() + "','" + textBox105.Text.Trim().Replace("'", "''").ToString() + "')", con5);
                            con5.Open();
                            int E = cmd5.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con5.Close();


                            //Insert For Flute In ElevenPly
                            funclib = new FunctionLib();
                            string strcon6 = funclib.setConnection();
                            SqlConnection con6 = new SqlConnection(strcon6);
                            string Rid6 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd6 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid6 + "','Flute','" + textBox104.Text.Trim().Replace("'", "''").ToString() + "','" + textBox103.Text.Trim().Replace("'", "''").ToString() + "','" + textBox102.Text.Trim().Replace("'", "''").ToString() + "','" + textBox101.Text.Trim().Replace("'", "''").ToString() + "')", con6);
                            con6.Open();
                            int F = cmd6.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con6.Close();


                            //Insert For Backing In ElevenPly
                            funclib = new FunctionLib();
                            string strcon7 = funclib.setConnection();
                            SqlConnection con7 = new SqlConnection(strcon7);
                            string Rid7 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd7 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid7 + "','Backing','" + textBox100.Text.Trim().Replace("'", "''").ToString() + "','" + textBox99.Text.Trim().Replace("'", "''").ToString() + "','" + textBox98.Text.Trim().Replace("'", "''").ToString() + "','" + textBox97.Text.Trim().Replace("'", "''").ToString() + "')", con7);
                            con7.Open();
                            int G = cmd7.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con7.Close();


                            //Insert For Flute In ElevenPly
                            funclib = new FunctionLib();
                            string strcon8 = funclib.setConnection();
                            SqlConnection con8 = new SqlConnection(strcon8);
                            string Rid8 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd8 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid8 + "','Flute','" + textBox96.Text.Trim().Replace("'", "''").ToString() + "','" + textBox95.Text.Trim().Replace("'", "''").ToString() + "','" + textBox94.Text.Trim().Replace("'", "''").ToString() + "','" + textBox93.Text.Trim().Replace("'", "''").ToString() + "')", con8);
                            con8.Open();
                            int H = cmd8.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con8.Close();



                            //Insert For Backing In ElevenPly
                            funclib = new FunctionLib();
                            string strcon9 = funclib.setConnection();
                            SqlConnection con9 = new SqlConnection(strcon9);
                            string Rid9 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd9 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid9 + "','Backing','" + textBox136.Text.Trim().Replace("'", "''").ToString() + "','" + textBox135.Text.Trim().Replace("'", "''").ToString() + "','" + textBox134.Text.Trim().Replace("'", "''").ToString() + "','" + textBox133.Text.Trim().Replace("'", "''").ToString() + "')", con9);
                            con9.Open();
                            int J = cmd9.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con9.Close();


                            //Insert For Flute In ElevenPly
                            funclib = new FunctionLib();
                            string strcon10 = funclib.setConnection();
                            SqlConnection con10 = new SqlConnection(strcon10);
                            string Rid10 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                            // con.Open();
                            SqlCommand cmd10 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid10 + "','Flute','" + textBox132.Text.Trim().Replace("'", "''").ToString() + "','" + textBox131.Text.Trim().Replace("'", "''").ToString() + "','" + textBox130.Text.Trim().Replace("'", "''").ToString() + "','" + textBox129.Text.Trim().Replace("'", "''").ToString() + "')", con10);
                            con10.Open();
                            int K = cmd10.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            con10.Close();


                        }
                    }

                    MessageBox.Show("Record Inserted Successfully");

                }   
                    
                    //filldata();
                clearall();
                txtLength_MM.Enabled = true;
                txtWidth_MM.Enabled = true;
                txtHeight_MM.Enabled = true;
                txtLength_Inch_Sheet.Enabled = true;
                txtWidth_Inch_Sheet.Enabled = true;
                txtNo_Colors.Enabled = true;
                txtPrntColor_Name.Enabled = true;
                txtSide_Canvas.Enabled = true;
                txtCanvColor_Name.Enabled = true;

                    //}

                //}
                //else
                //{
                //    cmdSubmit.Focus();
                //}




            }


        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearall();
        }

        private void txtI_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtLength_Inch_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtWidth_Inch_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtHeight_Inch_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }
        private void txtLength_Inch_Sheet1_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtWidth_Inch_Sheet1_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtBundle_Packet_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtBox_PerSheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtNo_Colors_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);

        }

        private void txtPrntColor_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtNo_Pins_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtRate_SidePastg_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtSide_Canvas_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtCanvColor_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtSell_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtExcise_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtTop_BF_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTop_GSM_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTop_WPP_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTop_BFPP_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtWeight_Pcs_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtBF_Pcs_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtArtWrk_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtRevi_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtSpeci_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtPedilite_BS_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPedilite_GSM_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtPedilite_WtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void Pedilite_PReq_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        private void txtLength_Inch_Leave(object sender, EventArgs e)
        {
            double LengthInch = Convert.ToDouble(txtLength_Inch.Text);
            //double Inch = Convert.ToDouble(25.4);
             Inch1 = (LengthInch * 25.4);
            txtLength_MM.Text = Inch1.ToString();
            txtLength_MM.Enabled = false;

        }

        private void txtWidth_Inch_Leave(object sender, EventArgs e)
        {
            double WidthInch = Convert.ToDouble(txtWidth_Inch.Text);
            //double Inch = Convert.ToDouble(25.4);
            Inch2 = (WidthInch * 25.4);
            txtWidth_MM.Text = Inch2.ToString();
            txtWidth_MM.Enabled = false;

        }

        private void txtHeight_Inch_Leave(object sender, EventArgs e)
        {
            double HightInch = Convert.ToDouble(txtHeight_Inch.Text);
            //double Inch = Convert.ToDouble(25.4);
            Inch3 = (HightInch * 25.4);
            txtHeight_MM.Text = Inch3.ToString();
            txtHeight_MM.Enabled = false;

        }

        private void ddlDimn_Opt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDimn_Opt.Text == "Outer")
            {
                if (ddlPly_Sheet.Text == "3")
                {
                    double LengthConv = (Inch1 + 3);
                    txtLength_MM_Conv.Text = LengthConv.ToString();

                    double WidthConv = (Inch2 + 3);
                    txtWidth_MM_Conv.Text = WidthConv.ToString();

                    double HightConv = (Inch3 + 5);
                    txtHeight_MM_Conv.Text = HightConv.ToString();


                     LenInchsheet = (Inch2 + Inch3 + 5) / 25.4;
                     
                    txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet.Enabled = false;
                    LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);

                     WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 30) / 25.4;
                     
                    txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet.Enabled = false;
                    WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);

                }
                if(ddlPly_Sheet.Text == "5")
                {

                    double LengthConv1 = (Inch1 + 5);
                    txtLength_MM_Conv.Text = LengthConv1.ToString();

                    double WidthConv1 = (Inch2 + 5);
                    txtWidth_MM_Conv.Text = WidthConv1.ToString();

                    double HightConv1 = (Inch3 + 8);
                    txtHeight_MM_Conv.Text = HightConv1.ToString();


                     LenInchsheet = (Inch2 + Inch3 + 7) / 25.4;
                     
                    txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet.Enabled = false;
                    LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);

                     WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 40) / 25.4;
                     
                    txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet.Enabled = false;
                    WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);


                }
                if (ddlPly_Sheet.Text == "7")
                {

                    double LengthConv2 = (Inch1 + 5);
                    txtLength_MM_Conv.Text = LengthConv2.ToString();

                    double WidthConv2 = (Inch2 + 5);
                    txtWidth_MM_Conv.Text = WidthConv2.ToString();

                    double HightConv2 = (Inch3 + 10);
                    txtHeight_MM_Conv.Text = HightConv2.ToString();


                     LenInchsheet = (Inch2 + Inch3 + 10) / 25.4;
                     
                    txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet.Enabled = false;
                    LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);

                     WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
                    
                    txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet.Enabled = false;
                    WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);



                }

                if (ddlPly_Sheet.Text == "9")
                {

                    double LengthConv3 = (Inch1 + 7);
                    txtLength_MM_Conv.Text = LengthConv3.ToString();

                    double WidthConv3 = (Inch2 + 7);
                    txtWidth_MM_Conv.Text = WidthConv3.ToString();

                    double HightConv3 = (Inch3 + 12);
                    txtHeight_MM_Conv.Text = HightConv3.ToString();


                     LenInchsheet = (Inch2 + Inch3 + 13) / 25.4;
                     
                    txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet.Enabled = false;
                    LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);

                    WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
                    
                    txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet.Enabled = false;
                    WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);


                }
                if (ddlPly_Sheet.Text == "11")
                {

                    double LengthConv4 = (Inch1 + 9);
                    txtLength_MM_Conv.Text = LengthConv4.ToString();

                    double WidthConv4 = (Inch2 + 9);
                    txtWidth_MM_Conv.Text = WidthConv4.ToString();

                    double HightConv4 = (Inch3 + 15);
                    txtHeight_MM_Conv.Text = HightConv4.ToString();

                     LenInchsheet = (Inch2 + Inch3 + 15) / 25.4;
                     
                    txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet.Enabled = false;
                    LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);

                     WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
                    
                    txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet.Enabled = false;
                    WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);


                }
            }



            if (ddlDimn_Opt.Text == "Inner")
            {
                if (ddlPly_Sheet.Text == "3")
                {
                    double LengthConv = (Inch1 - 3);
                    txtLength_MM_Conv.Text = LengthConv.ToString();

                    double WidthConv = (Inch2 - 3);
                    txtWidth_MM_Conv.Text = WidthConv.ToString();

                    double HightConv = (Inch3 - 5);
                    txtHeight_MM_Conv.Text = HightConv.ToString();

                     LenInchsheet = (Inch2 + Inch3 + 5) / 25.4;
                     
                     
                    txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet.Enabled = false;
                    LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);

                    WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 30) / 25.4;
                    
                    txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet.Enabled = false;
                    WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);


                }
                if (ddlPly_Sheet.Text == "5")
                {

                    double LengthConv1 = (Inch1 - 5);
                    txtLength_MM_Conv.Text = LengthConv1.ToString();

                    double WidthConv1 = (Inch2 - 5);
                    txtWidth_MM_Conv.Text = WidthConv1.ToString();

                    double HightConv1 = (Inch3 - 8);
                    txtHeight_MM_Conv.Text = HightConv1.ToString();


                     LenInchsheet = (Inch2 + Inch3 + 7) / 25.4;
                     
                    txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet.Enabled = false;
                    LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);

                     WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 40) / 25.4;
                     
                    txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet.Enabled = false;
                    WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);


                }
                if (ddlPly_Sheet.Text == "7")
                {

                    double LengthConv2 = (Inch1 - 5);
                    txtLength_MM_Conv.Text = LengthConv2.ToString();

                    double WidthConv2 = (Inch2 - 5);
                    txtWidth_MM_Conv.Text = WidthConv2.ToString();

                    double HightConv2 = (Inch3 - 10);
                    txtHeight_MM_Conv.Text = HightConv2.ToString();

                     LenInchsheet = (Inch2 + Inch3 + 10) / 25.4;
                    
                    txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet.Enabled = false;
                    LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);

                     WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
                     
                    txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet.Enabled = false;
                    WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);



                }

                if (ddlPly_Sheet.Text == "9")
                {

                    double LengthConv3 = (Inch1 - 7);
                    txtLength_MM_Conv.Text = LengthConv3.ToString();

                    double WidthConv3 = (Inch2 - 7);
                    txtWidth_MM_Conv.Text = WidthConv3.ToString();

                    double HightConv3 = (Inch3 - 12);
                    txtHeight_MM_Conv.Text = HightConv3.ToString();



                     LenInchsheet = (Inch2 + Inch3 + 13) / 25.4;
                     
                    txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet.Enabled = false;
                    LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);

                    WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
                    
                    txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet.Enabled = false;
                    WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);


                }
                if (ddlPly_Sheet.Text == "11")
                {

                    double LengthConv4 = (Inch1 - 9);
                    txtLength_MM_Conv.Text = LengthConv4.ToString();

                    double WidthConv4 = (Inch2 - 9);
                    txtWidth_MM_Conv.Text = WidthConv4.ToString();

                    double HightConv4 = (Inch3 - 15);
                    txtHeight_MM_Conv.Text = HightConv4.ToString();

                     LenInchsheet = (Inch2 + Inch3 + 15) / 25.4;
                     
                    txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
                    txtLength_Inch_Sheet.Enabled = false;
                    LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);

                    WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
                   
                    txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
                    txtWidth_Inch_Sheet.Enabled = false;
                    WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);


                }
            }






        }

        private void ddlPly_Sheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPly_Sheet.Text == "3")
            {
                ThreePly.Visible = true;
                
                FivePly.Visible = false;
                SevenPly.Visible = false;
                NinePly.Visible = false;
                ElevenPly.Visible = false;
           



            }

            if (ddlPly_Sheet.Text == "5")
            {
                FivePly.Visible = true;
                ThreePly.Visible = false;
                
                SevenPly.Visible = false;
                NinePly.Visible = false;
                ElevenPly.Visible = false;
           

            }

            if (ddlPly_Sheet.Text == "7")
            {
                SevenPly.Visible = true;
                ThreePly.Visible = false;
                FivePly.Visible = false;
                
                NinePly.Visible = false;
                ElevenPly.Visible = false;
           

            }

            if (ddlPly_Sheet.Text == "9")
            {
                NinePly.Visible = true;
                ThreePly.Visible = false;
                FivePly.Visible = false;
                SevenPly.Visible = false;
                
                ElevenPly.Visible = false;
           

            }

            if (ddlPly_Sheet.Text == "11")
            {
                ElevenPly.Visible = true;
                ThreePly.Visible = false;
                FivePly.Visible = false;
                SevenPly.Visible = false;
                NinePly.Visible = false;
               
           

            }
        }

        private void ddlPrinting_Opt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPrinting_Opt.Text == "Yes")
            {

                ddlPaper_Printed.Text = "No";
                if (txtNo_Colors.Text == "")//checking for blank PQ_Rate text field 
                {
                    MessageBox.Show("Please enter No_Colors");
                    txtNo_Colors.Focus();
                }
                if (txtPrntColor_Name.Text == "")//checking for blank Paper Active combo field 
                {
                    MessageBox.Show("Please Select PrntColor_Name");
                    txtPrntColor_Name.Focus();
                }

                txtNo_Colors.Enabled = true;
                txtPrntColor_Name.Enabled = true;




            }
            else
            {
                ddlPaper_Printed.Text = "";
                txtNo_Colors.Enabled = false;
                txtPrntColor_Name.Enabled = false;

            }
                

        }

        private void ddlPaper_Printed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaper_Printed.Text == "Yes")
            {
             
                if (ddlTP_ID.Text == "")//checking for blank Paper Active combo field 
            {
                MessageBox.Show("Please Select TP_ID");
                ddlTP_ID.Focus();
            }

            }
        }

        private void ddlScoring_Opt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlScoring_Opt.Text == "Yes")
            {
                ddlPunching_Opt.Text = "No";
            }
            else
            {
                ddlPunching_Opt.Text = "";
            }
        }

        private void ddlPinning_Opt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPinning_Opt.Text == "Yes")
            {
                ddlSide_Pasting.Text = "No";

                if (txtNo_Pins.Text == "")//checking for blank Paper Active combo field 
                {
                    MessageBox.Show("Please Select No_Pins");
                    txtNo_Pins.Focus();
                }

                if (ddlPinning_InOut.Text == "")//checking for blank PQ_Rate text field 
                {
                    MessageBox.Show("Please select Pinning_InOut");
                    ddlPinning_InOut.Focus();
                }
            }
            else
            {
                ddlSide_Pasting.Text = "";
            }
        }

        private void ddlSide_Pasting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSide_Pasting.Text == "Yes")
            {
                if (txtRate_SidePastg.Text == "")//checking for blank PQ_Rate text field 
                {
                    MessageBox.Show("Please enter Rate_SidePastg");
                    txtRate_SidePastg.Focus();
                }

            }
        }

        private void ddlCanvas_Opt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCanvas_Opt.Text == "Yes")
            {

                if (txtSide_Canvas.Text == "")//checking for blank PQ_Rate text field 
                {
                    MessageBox.Show("Please enter Side_Canvas");
                    txtSide_Canvas.Focus();
                }
                


                else if (txtCanvColor_Name.Text == "")//checking for blank Paper Active combo field 
                {
                    MessageBox.Show("Please enter CanvColor_Name");
                    txtCanvColor_Name.Focus();
                }

            }
            else
            {
                txtSide_Canvas.Enabled = false;
                txtCanvColor_Name.Enabled = false;
            }
        }

        private void txtTop_GSM_Leave(object sender, EventArgs e)
        {
           
        }

        private void ddlTP_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
           // ddlTP_ID.Text = "";
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con2 = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("select TP_PPBf from TopPaper_Master where TP_ID='"+ddlTP_ID.SelectedValue.ToString()+"'",con2);
            con2.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                string TPPBF = Convert.ToString(dr["TP_PPBf"]);

                if (TPPBF == "")
                {
                    TPPBF = "0";
                }

                strTPPBF = Convert.ToDouble(TPPBF);
                
              //  strTPPBF = Convert.ToDouble(dr["TP_PPBf"]);
                txtTop_BF.Text = strTPPBF.ToString();
                txtTop_BF3.Text = strTPPBF.ToString();
                txtTop_BF5.Text = strTPPBF.ToString();
                txtTop_BF9.Text = strTPPBF.ToString();
                txtTop_BF11.Text = strTPPBF.ToString();

            }
            con2.Close();
            dr.Close();




            funclib = new FunctionLib();
            string strcon1 = funclib.setConnection();
            SqlConnection con3 = new SqlConnection(strcon1);
            SqlCommand cmd1 = new SqlCommand("select TP_PPGram from TopPaper_Master where TP_ID='" + ddlTP_ID.SelectedValue.ToString() + "'", con3);
            con3.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {

                string TPGsm = Convert.ToString(dr1["TP_PPGram"]);

                if (TPGsm == "")
                {
                    TPGsm = "0";
                }

                strTPGsm = Convert.ToDouble(TPGsm);

                //strTPGsm = Convert.ToDouble(dr1["TP_PPGram"]);
                txtTop_GSM.Text = strTPGsm.ToString();
                txtTop_GSM3.Text = strTPGsm.ToString();
                txtTop_GSM5.Text = strTPGsm.ToString();
                txtTop_GSM9.Text = strTPGsm.ToString();
                txtTop_GSM11.Text = strTPGsm.ToString();

            }
            con2.Close();
            dr.Close();

            //double LenSheet = Convert.ToDouble(txtLength_Inch_Sheet.Text);
            //double WidthSheet = Convert.ToDouble(txtWidth_Inch_Sheet.Text);

            //For SevenPly
            double Gsm = Convert.ToDouble(txtTop_GSM.Text);
            double TopBF = Convert.ToDouble(txtTop_BF.Text);


            double TopWpp = ((LenInchsheet1 * WidInchsheet1) * Gsm / 1550) / 1000;
            txtTop_WPP.Text = TopWpp.ToString();

            double TopBFPP = ((TopBF * Gsm) / 1000);
            txtTop_BFPP.Text = TopBFPP.ToString();

            //For ThreePly

            double Gsm3 = Convert.ToDouble(txtTop_GSM3.Text);
            double TopBF3 = Convert.ToDouble(txtTop_BF3.Text);


            double TopWpp3 = ((LenInchsheet1 * WidInchsheet1) * Gsm3 / 1550) / 1000;
            txtTop_WPP3.Text = TopWpp3.ToString();

            double TopBFPP3 = ((TopBF3 * Gsm3) / 1000);
            txtTop_BFPP3.Text = TopBFPP3.ToString();


            //For FivePly

            double Gsm5 = Convert.ToDouble(txtTop_GSM5.Text);
            double TopBF5 = Convert.ToDouble(txtTop_BF5.Text);


            double TopWpp5 = ((LenInchsheet1 * WidInchsheet1) * Gsm5 / 1550) / 1000;
            txtTop_WPP5.Text = TopWpp5.ToString();

            double TopBFPP5 = ((TopBF5 * Gsm5) / 1000);
            txtTop_BFPP5.Text = TopBFPP5.ToString();


            //For NinePly

            double Gsm9 = Convert.ToDouble(txtTop_GSM9.Text);
            double TopBF9 = Convert.ToDouble(txtTop_BF9.Text);


            double TopWpp9 = ((LenInchsheet1 * WidInchsheet1) * Gsm9 / 1550) / 1000;
            txtTop_WPP9.Text = TopWpp9.ToString();

            double TopBFPP9 = ((TopBF9 * Gsm9) / 1000);
            txtTop_BFPP9.Text = TopBFPP9.ToString();


            //For ElevenPly

            double Gsm11 = Convert.ToDouble(txtTop_GSM11.Text);
            double TopBF11 = Convert.ToDouble(txtTop_BF11.Text);


            double TopWpp11 = ((LenInchsheet1 * WidInchsheet1) * Gsm11 / 1550) / 1000;
            txtTop_WPP11.Text = TopWpp11.ToString();

            double TopBFPP11 = ((TopBF11 * Gsm11) / 1000);
            txtTop_BFPP11.Text = TopBFPP11.ToString();

            

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTop_GSM31_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Threeply
            double txtTopBF31 = Convert.ToDouble(txtTop_BF31.Text);
            double txtTopGSM31 = Convert.ToDouble(txtTop_GSM31.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            txtTop_BFPP31.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            txtTop_WPP31.Text = txtTopWPP31.ToString();

        }

        private void txtTop_GSM32_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Threeply
            double txtTopBF32 = Convert.ToDouble(txtTop_BF32.Text);
            double txtTopGSM32 = Convert.ToDouble(txtTop_GSM32.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            txtTop_BFPP32.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4); 
            txtTop_WPP32.Text = txtTopWPP32.ToString();

            //double TopWpp = Convert.ToDouble(txtTop_GSM3.Text);
            double txtWpp1 = Convert.ToDouble(txtTop_WPP3.Text);
            double txtWpp2 = Convert.ToDouble(txtTop_WPP31.Text);
            double txtWpp3 = Convert.ToDouble(txtTop_WPP32.Text);

            double WeightPcs = ( txtWpp1 + txtWpp2 + txtWpp3);
            txtWeight_Pcs.Text = WeightPcs.ToString();

            //double TopGsm1 = Convert.ToDouble(txtTop_GSM3.Text);
            double txtBff1 = Convert.ToDouble(txtTop_BFPP3.Text);
            double txtBff2 = Convert.ToDouble(txtTop_BFPP31.Text);
            double txtBff3 = Convert.ToDouble(txtTop_BFPP32.Text);

            double BFPcs = (txtBff1 + txtBff2 + txtBff3);
            txtBF_Pcs.Text = BFPcs.ToString();
        }

        private void textBox35_Leave(object sender, EventArgs e)
        {

            //Calculate Backing Value of Fiveply
            double txtTopBF31 = Convert.ToDouble(txtTop_BF51.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox35.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox33.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox34.Text = txtTopWPP31.ToString();


        }

        private void textBox31_Leave(object sender, EventArgs e)
        {

            //Calculate Flute Value of Fiveply
            double txtTopBF32 = Convert.ToDouble(txtTop_BF52.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox31.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox29.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox30.Text = txtTopWPP32.ToString();

        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Fiveply
            double txtTopBF31 = Convert.ToDouble(txtTop_BF53.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox15.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox13.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox14.Text = txtTopWPP31.ToString();


        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Fiveply
            double txtTopBF32 = Convert.ToDouble(txtTop_BF54.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox11.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox9.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox10.Text = txtTopWPP32.ToString();


            double txtWpp1 = Convert.ToDouble(txtTop_WPP5.Text);
            double txtWpp2 = Convert.ToDouble(textBox34.Text);
            double txtWpp3 = Convert.ToDouble(textBox30.Text);
            double txtWpp4 = Convert.ToDouble(textBox14.Text);
            double txtWpp5 = Convert.ToDouble(textBox10.Text);


            double WeightPcs = (txtWpp1 + txtWpp2 + txtWpp3 + txtWpp4 + txtWpp5);
            txtWeight_Pcs.Text = WeightPcs.ToString();

            //double TopGsm1 = Convert.ToDouble(txtTop_GSM3.Text);
            double txtBff1 = Convert.ToDouble(txtTop_BFPP5.Text);
            double txtBff2 = Convert.ToDouble(textBox33.Text);
            double txtBff3 = Convert.ToDouble(textBox29.Text);
            double txtBff4 = Convert.ToDouble(textBox13.Text);
            double txtBff5 = Convert.ToDouble(textBox9.Text);


            double BFPcs = (txtBff1 + txtBff2 + txtBff3 + txtBff4 + txtBff5);
            txtBF_Pcs.Text = BFPcs.ToString();

        }

        private void textBox79_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Sevenply
            double txtTopBF31 = Convert.ToDouble(textBox80.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox79.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox77.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox78.Text = txtTopWPP31.ToString();

        }

        private void textBox75_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Sevenply
            double txtTopBF32 = Convert.ToDouble(textBox76.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox75.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox73.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox74.Text = txtTopWPP32.ToString();

        }

        private void textBox71_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Sevenply
            double txtTopBF31 = Convert.ToDouble(textBox72.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox71.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox69.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox70.Text = txtTopWPP31.ToString();

        }

        private void textBox67_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Sevenply
            double txtTopBF32 = Convert.ToDouble(textBox68.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox67.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox65.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox66.Text = txtTopWPP32.ToString();

        }

        private void textBox63_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Sevenply
            double txtTopBF31 = Convert.ToDouble(textBox64.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox63.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox61.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox62.Text = txtTopWPP31.ToString();

        }

        private void textBox59_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Sevenply
            double txtTopBF32 = Convert.ToDouble(textBox60.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox59.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox57.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox58.Text = txtTopWPP32.ToString();


            double txtWpp1 = Convert.ToDouble(txtTop_WPP.Text);
            double txtWpp2 = Convert.ToDouble(textBox78.Text);
            double txtWpp3 = Convert.ToDouble(textBox74.Text);
            double txtWpp4 = Convert.ToDouble(textBox70.Text);
            double txtWpp5 = Convert.ToDouble(textBox66.Text);
            double txtWpp6 = Convert.ToDouble(textBox62.Text);
            double txtWpp7 = Convert.ToDouble(textBox58.Text);




            double WeightPcs = (txtWpp1 + txtWpp2 + txtWpp3 + txtWpp4 + txtWpp5 + txtWpp6 + txtWpp7);
            txtWeight_Pcs.Text = WeightPcs.ToString();

            //double TopGsm1 = Convert.ToDouble(txtTop_GSM3.Text);
            double txtBff1 = Convert.ToDouble(txtTop_BFPP.Text);
            double txtBff2 = Convert.ToDouble(textBox77.Text);
            double txtBff3 = Convert.ToDouble(textBox73.Text);
            double txtBff4 = Convert.ToDouble(textBox69.Text);
            double txtBff5 = Convert.ToDouble(textBox65.Text);
            double txtBff6 = Convert.ToDouble(textBox61.Text);
            double txtBff7 = Convert.ToDouble(textBox57.Text);



            double BFPcs = (txtBff1 + txtBff2 + txtBff3 + txtBff4 + txtBff5 + txtBff6 + txtBff7);
            txtBF_Pcs.Text = BFPcs.ToString();

        }

        private void textBox55_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Nineply
            double txtTopBF31 = Convert.ToDouble(textBox56.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox55.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox53.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox54.Text = txtTopWPP31.ToString();
        }

        private void textBox51_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Nineply
            double txtTopBF32 = Convert.ToDouble(textBox52.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox51.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox49.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox50.Text = txtTopWPP32.ToString();

        }

        private void textBox47_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Nineply
            double txtTopBF31 = Convert.ToDouble(textBox48.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox47.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox45.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox46.Text = txtTopWPP31.ToString();
        }

        private void textBox43_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Nineply
            double txtTopBF32 = Convert.ToDouble(textBox44.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox43.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox41.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox42.Text = txtTopWPP32.ToString();

        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Nineply
            double txtTopBF31 = Convert.ToDouble(textBox8.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox7.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox5.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox6.Text = txtTopWPP31.ToString();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Nineply
            double txtTopBF32 = Convert.ToDouble(textBox4.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox3.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox1.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox2.Text = txtTopWPP32.ToString();

        }

        private void textBox91_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Nineply
            double txtTopBF31 = Convert.ToDouble(textBox92.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox91.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox89.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox90.Text = txtTopWPP31.ToString();
        }

        private void textBox87_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Nineply
            double txtTopBF32 = Convert.ToDouble(textBox88.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox87.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox85.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox86.Text = txtTopWPP32.ToString();


            double txtWpp1 = Convert.ToDouble(txtTop_WPP9.Text);
            double txtWpp2 = Convert.ToDouble(textBox54.Text);
            double txtWpp3 = Convert.ToDouble(textBox50.Text);
            double txtWpp4 = Convert.ToDouble(textBox46.Text);
            double txtWpp5 = Convert.ToDouble(textBox42.Text);
            double txtWpp6 = Convert.ToDouble(textBox6.Text);
            double txtWpp7 = Convert.ToDouble(textBox2.Text);
            double txtWpp8 = Convert.ToDouble(textBox90.Text);
            double txtWpp9 = Convert.ToDouble(textBox86.Text);





            double WeightPcs = (txtWpp1 + txtWpp2 + txtWpp3 + txtWpp4 + txtWpp5 + txtWpp6 + txtWpp7 + txtWpp8 + txtWpp9);
            txtWeight_Pcs.Text = WeightPcs.ToString();

            //double TopGsm1 = Convert.ToDouble(txtTop_GSM3.Text);
            double txtBff1 = Convert.ToDouble(txtTop_BFPP9.Text);
            double txtBff2 = Convert.ToDouble(textBox53.Text);
            double txtBff3 = Convert.ToDouble(textBox49.Text);
            double txtBff4 = Convert.ToDouble(textBox45.Text);
            double txtBff5 = Convert.ToDouble(textBox41.Text);
            double txtBff6 = Convert.ToDouble(textBox5.Text);
            double txtBff7 = Convert.ToDouble(textBox1.Text);
            double txtBff8 = Convert.ToDouble(textBox89.Text);
            double txtBff9 = Convert.ToDouble(textBox85.Text);




            double BFPcs = (txtBff1 + txtBff2 + txtBff3 + txtBff4 + txtBff5 + txtBff6 + txtBff7 + txtBff8 + txtBff9);
            txtBF_Pcs.Text = BFPcs.ToString();
        }

        private void textBox123_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Elevenply
            double txtTopBF31 = Convert.ToDouble(textBox124.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox123.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox121.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox122.Text = txtTopWPP31.ToString();
        }

        private void textBox119_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Elevenply
            double txtTopBF32 = Convert.ToDouble(textBox120.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox119.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox117.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox118.Text = txtTopWPP32.ToString();
        }

        private void textBox115_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Elevenply
            double txtTopBF31 = Convert.ToDouble(textBox116.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox115.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox113.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox114.Text = txtTopWPP31.ToString();
        }

        private void textBox111_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Elevenply
            double txtTopBF32 = Convert.ToDouble(textBox112.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox111.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox109.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox110.Text = txtTopWPP32.ToString();
        }

        private void textBox107_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Elevenply
            double txtTopBF31 = Convert.ToDouble(textBox108.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox107.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox105.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox106.Text = txtTopWPP31.ToString();
        }

        private void textBox103_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Elevenply
            double txtTopBF32 = Convert.ToDouble(textBox104.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox103.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox101.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox102.Text = txtTopWPP32.ToString();
        }

        private void textBox99_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Elevenply
            double txtTopBF31 = Convert.ToDouble(textBox100.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox99.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox97.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox98.Text = txtTopWPP31.ToString();
        }

        private void textBox95_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Elevenply
            double txtTopBF32 = Convert.ToDouble(textBox96.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox95.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox93.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox94.Text = txtTopWPP32.ToString();
        }

        private void textBox135_Leave(object sender, EventArgs e)
        {
            //Calculate Backing Value of Elevenply
            double txtTopBF31 = Convert.ToDouble(textBox136.Text);
            double txtTopGSM31 = Convert.ToDouble(textBox135.Text);

            double txtTopBFPP31 = ((txtTopBF31 * txtTopGSM31) / 1000);
            textBox133.Text = txtTopBFPP31.ToString();

            double txtTopWPP31 = ((LenInchsheet1 * WidInchsheet1) * txtTopGSM31 / 1550) / 1000;
            textBox134.Text = txtTopWPP31.ToString();
        }

        private void textBox131_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Elevenply
            double txtTopBF32 = Convert.ToDouble(textBox132.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox131.Text);

            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000)/2;
            textBox129.Text = txtTopBFPP32.ToString();

            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            textBox130.Text = txtTopWPP32.ToString();

            double txtWpp1 = Convert.ToDouble(txtTop_WPP11.Text);
            double txtWpp2 = Convert.ToDouble(textBox122.Text);
            double txtWpp3 = Convert.ToDouble(textBox118.Text);
            double txtWpp4 = Convert.ToDouble(textBox114.Text);
            double txtWpp5 = Convert.ToDouble(textBox110.Text);
            double txtWpp6 = Convert.ToDouble(textBox106.Text);
            double txtWpp7 = Convert.ToDouble(textBox102.Text);
            double txtWpp8 = Convert.ToDouble(textBox98.Text);
            double txtWpp9 = Convert.ToDouble(textBox94.Text);
            double txtWpp10 = Convert.ToDouble(textBox134.Text);
            double txtWpp11 = Convert.ToDouble(textBox130.Text);






            double WeightPcs = (txtWpp1 + txtWpp2 + txtWpp3 + txtWpp4 + txtWpp5 + txtWpp6 + txtWpp7 + txtWpp8 + txtWpp9 + txtWpp10 + txtWpp11);
            txtWeight_Pcs.Text = WeightPcs.ToString();

            //double TopGsm1 = Convert.ToDouble(txtTop_GSM3.Text);
            double txtBff1 = Convert.ToDouble(txtTop_BFPP11.Text);
            double txtBff2 = Convert.ToDouble(textBox121.Text);
            double txtBff3 = Convert.ToDouble(textBox117.Text);
            double txtBff4 = Convert.ToDouble(textBox113.Text);
            double txtBff5 = Convert.ToDouble(textBox109.Text);
            double txtBff6 = Convert.ToDouble(textBox105.Text);
            double txtBff7 = Convert.ToDouble(textBox101.Text);
            double txtBff8 = Convert.ToDouble(textBox97.Text);
            double txtBff9 = Convert.ToDouble(textBox93.Text);
            double txtBff10 = Convert.ToDouble(textBox133.Text);
            double txtBff11 = Convert.ToDouble(textBox129.Text);





            double BFPcs = (txtBff1 + txtBff2 + txtBff3 + txtBff4 + txtBff5 + txtBff6 + txtBff7 + txtBff8 + txtBff9 + txtBff10 + txtBff11);
            txtBF_Pcs.Text = BFPcs.ToString();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtArt_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;

            txtArt_Dt.Focus();
        }

        private void txtArt_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void ddlFor_Pedilite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFor_Pedilite.Text == "Yes")
            {
                if (txtPedilite_BS.Text == "")//checking for blank PQ_Rate text field 
                {
                    MessageBox.Show("Please enter Pedilite_BS");
                    txtPedilite_BS.Focus();
                }
                 if (txtPedilite_GSM.Text == "")//checking for blank PQ_Rate text field 
                {
                    MessageBox.Show("Please enter Pedilite_GSM");
                    txtPedilite_GSM.Focus();
                }
                 if (txtPedilite_WtBox.Text == "")//checking for blank Paper Active combo field 
                {
                    MessageBox.Show("Please enter Pedilite_WtBox");
                    txtPedilite_WtBox.Focus();
                }

                else if (Pedilite_PReq.Text == "")//checking for blank PQ_Rate text field 
                {
                    MessageBox.Show("Please enter Pedilite_PReq");
                    Pedilite_PReq.Focus();
                }
            }
        }

        
        protected void clearall()
        {
            ddlGrp_ID.Text = "";
            ddlP_ID.Text = "";
            ddlPB_ID.Text = "";
            txtI_Name.Text = "";
            ddlStyle_ID.Text = "";
            ddlPly_Sheet.Text = "";
            txtLength_Inch.Text = "";
            txtWidth_Inch.Text = "";
            txtHeight_Inch.Text = "";
            txtLength_MM.Text = "";
            txtWidth_MM.Text = "";
            txtHeight_MM.Text = "";
            ddlDimn_Opt.Text = "";
            txtLength_MM_Conv.Text = "";
            txtWidth_MM_Conv.Text = "";
            txtHeight_MM_Conv.Text = "";
            txtLength_Inch_Sheet.Text = "";
            txtWidth_Inch_Sheet.Text = "";
            txtLength_Inch_Sheet1.Text = "";
            txtWidth_Inch_Sheet1.Text = "";
            ddlEF_NF_PC.Text = "";
            txtBundle_Packet.Text = "";
            txtBox_PerSheet.Text = "";
            ddlCorrugation_Opt.Text = "";
            ddlPaper_Cutting.Text = "";
            ddlPrinting_Opt.Text = "";
            txtNo_Colors.Text = "";
            txtPrntColor_Name.Text = "";
            ddlPaper_Printed.Text = "";
            ddlTP_ID.Text = "";
            ddlScoring_Opt.Text = "";
            ddlPunching_Opt.Text = "";
            ddlPasting_Opt.Text = "";
            ddlSlotting_Opt.Text = "";
            ddlPinning_Opt.Text = "";
            txtNo_Pins.Text = "";
            ddlPinning_InOut.Text = "";
            ddlSide_Pasting.Text = "";
            txtRate_SidePastg.Text = "";
            ddlCanvas_Opt.Text = "";
            txtSide_Canvas.Text = "";
            txtCanvColor_Name.Text = "";
            txtSell_Rate.Text = "";
            ddlRate_Type.Text = "";
            txtExcise_Code.Text = "";
            txtTop_BF.Text = "";
            txtTop_GSM.Text = "";
            txtTop_WPP.Text = "";
            txtTop_BFPP.Text = "";
            txtWeight_Pcs.Text = "";
            txtBF_Pcs.Text = "";
            txtArtWrk_Code.Text = "";
            txtRevi_No.Text = "";
            txtArt_Dt.Text = "";
            txtSpeci_Code.Text = "";
            ddlFor_Pedilite.Text = "";
            txtPedilite_BS.Text = "";
            txtPedilite_GSM.Text = "";
            txtPedilite_WtBox.Text = "";
            Pedilite_PReq.Text = "";
            ddlI_Lock.Text = "";
            ddlI_Active.Text = "";
            ThreePly.Visible = false;
            FivePly.Visible = false;
            SevenPly.Visible = false;
            NinePly.Visible = false;
            ElevenPly.Visible = false;
            pictureBox1.Visible = false;
            ddlI_Active.SelectedText = "Yes";

            
        }

        //private void PictureFormat(object sender, ConvertEventArgs e)
        //{
        //    // e.Value is the original value
        //    Byte[] img = (Byte[])e.Value;

        //    MemoryStream ms = new MemoryStream();
        //    int offset = 78;
        //    ms.Write(img, offset, img.Length - offset);
        //    Bitmap bmp = new Bitmap(ms);
        //    ms.Close();

        //    // Writes the new value back
        //    e.Value = bmp;
        //}

        private void ddlStyle_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlPB_ID.Text = "";
            //ddlStyle_ID.Text = "";
            ////Displaying values in PB_ID Combobox
            pictureBox1.Visible = true;
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con3 = new SqlConnection(strcon);
            con3.Open();
            //Retrieve BLOB from database into DataSet.
            SqlCommand cmd = new SqlCommand("select Style_ID,Image_Sheet from Item_Style_Master where Style_ID='"+ddlStyle_ID.SelectedValue.ToString()+"'", con3);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Item_Style_Master");
            int c = ds.Tables["Item_Style_Master"].Rows.Count;

            if (c > 0)
            {   //BLOB is read into Byte array, then used to construct MemoryStream,
                //then passed to PictureBox.
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])(ds.Tables["Item_Style_Master"].Rows[c - 1]["Image_Sheet"]);
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                pictureBox1.Image = Image.FromStream(stmBLOBData);
            }
            con3.Close();
            
            //DataTable dt2 = new DataTable();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLength_MM_Conv_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox135_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.MaxDate = System.DateTime.Now;

        }
        //private void DisplayItem()
        //{
        //    string data = null;
        //    ////to fill the grid with user details
        //    funclib = new FunctionLib();
        //    string strcon = funclib.setConnection();
        //    SqlConnection con4 = new SqlConnection(strcon);
        //    int i = 0;
        //    int j = 0;
        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;
        //    object misValue = System.Reflection.Missing.Value;


        //    xlApp = new Excel.ApplicationClass();
        //    xlWorkBook = xlApp.Workbooks.Add(misValue);
        //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        //    con4.Open();

        //    SqlDataAdapter da = new SqlDataAdapter("select b.Grp_Name as Groups,a.I_ID,a.I_Name,c.P_Name,d.PB_Name from Item_Master as a,Party_Buyer as d,Party_Master as c,Group_Master as b where a.Grp_ID='" + Group_ID + "' and a.Grp_ID=b.Grp_ID and a.P_ID=c.P_ID and a.PB_ID=d.PB_ID", con4);
        //    //SqlDataAdapter da = new SqlDataAdapter("select a.TP_ID as TopPaperID,b.Grp_Name as GroupName,c.P_Name as PartyName,a.TP_Name as TopPaperName,d.PQ_Desc as PaperQuality, a.TP_PPLgth as TopPaperLength,a.TP_PPWdth as PaperWidth,a.TP_PPBf as PaperBf, a.TP_PPGram as PaperGram,a.TP_PPRate as PaperRate,a.TP_PPCost as PaperCost, a.TP_LmLgth as LaminationLength,a.TP_LmWdth as LaminationWidth, a.TP_LmRate as LaminationRate,a.TP_LmCost as LaminationCost ,a.TP_LmType as LaminationType,a.TP_VrLgth as VarnishLength,a.TP_VrWdth as varnishWidth,a.TP_VrRate as vanishRate,a.TP_VrCost as VarnishCost,a.TP_VrType as varnishType, a.TP_PnColor as NoColors,a.TP_PnRate as PlateRate,a.TP_PnCost as PlateCost,a.TP_PlDivFact as Divfactor, a.TP_PlNo as PlateNo,a.TP_PlRate as PlateRate,a.TP_PlCost as PlateCost, a.TP_PlWsCnt as WeightPercnt,a.TP_PlWsAmt as WeightAmt,e.Ptve_Name as PositiveName, a.TP_Rate as Rate,a.TP_OS as OpenStock,a.TP_CS as ClosingStock,a.TP_ReLev as ReOrder, a.TP_Active as Active from TopPaper_Master a,Group_Master b ,Party_Master c,PQuality_Master d,Positive_Master e  where b.Grp_ID=a.Grp_ID and b.Grp_ID=c.Grp_ID and b.Grp_ID=d.Grp_ID and a.PQ_ID=d.PQ_ID and a.P_ID=c.P_ID and a.Ptve_ID=e.Ptve_ID", con4);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        //    {
        //        for (j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
        //        {
        //            data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
        //            xlWorkSheet.Cells[i + 1, j + 1] = data;
        //        }


        //    }
        //    xlApp.ActiveWorkbook.SaveCopyAs("C:\\test.xls");
        //    xlApp.ActiveWorkbook.Saved = true;
        //    xlApp.Quit();
        //    //xlApp.ActiveWorkbook.SaveCopyAs("C:\\test.xls")
        //    //xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        //    //xlWorkBook.Close(true, misValue, misValue);
        //    //xlApp.Quit();

        //    //releaseObject(xlWorkSheet);
        //    //releaseObject(xlWorkBook);
        //    //releaseObject(xlApp);

        //    MessageBox.Show("Excel file created");

        //}
        //private void releaseObject(object obj)
        //{
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        //        obj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        obj = null;
        //        MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}
        //private void BindControl()
        //{
        //    //pictureBox1.DataBindings.Add(new Binding("Image", _dataSet, "Item_Style_Master.Image_Sheet"));
        //    //pictureBox1.DataBindings.Add(new Binding("Image", _dataSet, "Item_Style_Master"));
        //    Binding bdPhoto = new Binding("Image", _dataSet, "Item_Style_Master.pictureBox1");
        //    bdPhoto.Format += new ConvertEventHandler(this.PictureFormat);
        //    pictureBox1.DataBindings.Add(bdPhoto);
        //}

        //Fill Grid
        //private void fillGrid()
        //{
        //    //to fill the grid with user details
        //    funclib = new FunctionLib();
        //    string strcon = funclib.setConnection();
        //    SqlConnection con4 = new SqlConnection(strcon);
        //    SqlDataAdapter da = new SqlDataAdapter("select a.I_ID,a.I_Name as ItemName,a.P_ID as PartyName,a.PB_ID as ByerName,b.Grp_Name as Groups,a.Invoice_No,a.Credit_Period,a.Grand_Amt,convert(varchar(20),a.SIIn_Dt,103) as SIIn_Dt ,convert(varchar(20),a.PO_Dt,103) as PO_Dt,convert(varchar(20),a.Invoice_Dt,103) as Invoice_Dt,a.SIIn_FromAddr,a.SIIn_Place,a.Credit_Period,a.Total_Amt,a.Disc_Amt,a.Net_Amt,a.Excise_Amt,a.Cess_Amt,a.HSCess_Amt,a.CSTVAT_Amt,a.Insu_Amt,a.Other_Amt from Purchase_ItemIn as a,Group_Master as b where a.Grp_ID=b.Grp_ID ", con4);
        //    //SqlDataAdapter da = new SqlDataAdapter("select * from Purchase_ItemIn ", con4);
        //    //SqlDataAdapter da = new SqlDataAdapter("select a.TP_ID as TopPaperID,b.Grp_Name as GroupName,c.P_Name as PartyName,a.TP_Name as TopPaperName,d.PQ_Desc as PaperQuality, a.TP_PPLgth as TopPaperLength,a.TP_PPWdth as PaperWidth,a.TP_PPBf as PaperBf, a.TP_PPGram as PaperGram,a.TP_PPRate as PaperRate,a.TP_PPCost as PaperCost, a.TP_LmLgth as LaminationLength,a.TP_LmWdth as LaminationWidth, a.TP_LmRate as LaminationRate,a.TP_LmCost as LaminationCost ,a.TP_LmType as LaminationType,a.TP_VrLgth as VarnishLength,a.TP_VrWdth as varnishWidth,a.TP_VrRate as vanishRate,a.TP_VrCost as VarnishCost,a.TP_VrType as varnishType, a.TP_PnColor as NoColors,a.TP_PnRate as PlateRate,a.TP_PnCost as PlateCost,a.TP_PlDivFact as Divfactor, a.TP_PlNo as PlateNo,a.TP_PlRate as PlateRate,a.TP_PlCost as PlateCost, a.TP_PlWsCnt as WeightPercnt,a.TP_PlWsAmt as WeightAmt,e.Ptve_Name as PositiveName, a.TP_Rate as Rate,a.TP_OS as OpenStock,a.TP_CS as ClosingStock,a.TP_ReLev as ReOrder, a.TP_Active as Active from TopPaper_Master a,Group_Master b ,Party_Master c,PQuality_Master d,Positive_Master e  where b.Grp_ID=a.Grp_ID and b.Grp_ID=c.Grp_ID and b.Grp_ID=d.Grp_ID and a.PQ_ID=d.PQ_ID and a.P_ID=c.P_ID and a.Ptve_ID=e.Ptve_ID", con4);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    dataGridView2.DataSource = dt;
        //    this.dataGridView2.Columns[0].Visible = false;

        //}



    }
}
