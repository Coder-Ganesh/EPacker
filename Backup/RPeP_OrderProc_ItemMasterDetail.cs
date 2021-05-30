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
using System.Windows;
namespace ePacker1
{
    public partial class RPeP_OrderProc_ItemMasterDetail : Form
    {
        private FunctionLib funclib;
        string Group_ID,I_ID;
        public RPeP_OrderProc_ItemMasterDetail()
        {
            InitializeComponent();
            Group_ID = RPeP_LogIn.strGroup;
            I_ID = RPeP_OrderProc.I_ID;
        }

        private void RPeP_OrderProc_ItemMasterDetail_Load(object sender, EventArgs e)
        {
            funclib = new FunctionLib();
            string strcon = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon);
            SqlConnection con = new SqlConnection(strcon);


            txtI_ID.Visible = false;
         
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
           
         

            ddlP_ID.Text = "";
            SqlConnection con2 = new SqlConnection(strcon);
            con2.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select a.P_ID,a.P_Name from Party_Master as a,Group_Master as b where P_Active='Yes' and a.Grp_ID='" + Group_ID + "' and a.Grp_ID=b.Grp_ID and P_Active='Yes'", con2);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            ddlP_ID.DataSource = dt1;
            ddlP_ID.DisplayMember = dt1.Columns[1].ToString();
            ddlP_ID.ValueMember = dt1.Columns[0].ToString();
            con2.Close();



            //Displaying values in Style_ID Combobox
            ddlStyle_ID.Text = "";
       
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select a.Style_ID,a.Style_No from Item_Style_Master as a,Group_Master as b where Style_Active='Yes' and a.Grp_ID='" + Group_ID + "' and a.Grp_ID=b.Grp_ID and Style_Active='Yes'", con);
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
            SqlDataAdapter da3 = new SqlDataAdapter("select a.TP_ID,a.TP_Name from TopPaper_Master as a,Group_Master as b where a.Grp_ID='" + Group_ID + "' and a.Grp_ID=b.Grp_ID and a.TP_Active='Yes'", con3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            ddlTP_ID.DataSource = dt3;
            ddlTP_ID.DisplayMember = dt3.Columns[1].ToString();
            ddlTP_ID.ValueMember = dt3.Columns[0].ToString();
            con3.Close();


            // DisplayItem();

            SqlCommand cmd3 = new SqlCommand("select P_ID,I_Name,Style_ID,Ply_Sheet,Length_Inch,Width_Inch,Height_Inch,Length_MM,Width_MM,Height_MM,Dimn_Opt,Length_MM_Conv,Width_MM_Conv,Height_MM_Conv,Length_Inch_Sheet,Width_Inch_Sheet,Length_Inch_Sheet1,Width_Inch_Sheet1,EF_NF_PC,Bundle_Packet,Box_PerSheet,Corrugation_Opt,Paper_Cutting,Printing_Opt,No_Colors,PrntColor_Name,Paper_Printed,TP_ID,Scoring_Opt,Punching_Opt,Pasting_Opt,Slotting_Opt,Pinning_Opt,No_Pins,Pinning_InOut,Side_Pasting,Rate_SidePastg,Canvas_Opt,Side_Canvas,CanvColor_Name,Sell_Rate,Rate_Type,Excise_Code,Top_BF,Top_GSM,Top_WPP,Top_BFPP,Weight_Pcs,BF_Pcs,ArtWrk_Code,Revi_No,Convert(varchar(20),Art_Dt,103) as 'Art_Dt',Speci_Code,For_Pedilite,Pedilite_BS,Pedilite_GSM,Pedilite_WtBox,Pedilite_PReq,I_Lock,I_Active from Item_Master where I_ID='" + I_ID.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmd3.ExecuteReader();
            if (dr1.Read())
            {

                ddlP_ID.SelectedValue = Convert.ToString(dr1["P_ID"]);
                txtI_Name.Text = Convert.ToString(dr1["I_Name"]);
                ddlStyle_ID.SelectedValue = Convert.ToString(dr1["Style_ID"]);
                ddlPly_Sheet.Text = Convert.ToString(dr1["Ply_Sheet"]);
                txtLength_Inch.Text = Convert.ToString(dr1["Length_Inch"]);
                txtWidth_Inch.Text = Convert.ToString(dr1["Width_Inch"]);
                txtHeight_Inch.Text = Convert.ToString(dr1["Height_Inch"]);
                txtLength_MM.Text = Convert.ToString(dr1["Length_MM"]);
                txtWidth_MM.Text = Convert.ToString(dr1["Width_MM"]);
                txtHeight_MM.Text = Convert.ToString(dr1["Height_MM"]);
                ddlDimn_Opt.Text = Convert.ToString(dr1["Dimn_Opt"]);
                txtLength_MM_Conv.Text = Convert.ToString(dr1["Length_MM_Conv"]);
                txtWidth_MM_Conv.Text = Convert.ToString(dr1["Width_MM_Conv"]);
                txtHeight_MM_Conv.Text = Convert.ToString(dr1["Height_MM_Conv"]);
                txtLength_Inch_Sheet.Text = Convert.ToString(dr1["Length_Inch_Sheet"]);
                txtWidth_Inch_Sheet.Text = Convert.ToString(dr1["Width_Inch_Sheet"]);
                txtLength_Inch_Sheet1.Text = Convert.ToString(dr1["Length_Inch_Sheet1"]);
                txtWidth_Inch_Sheet1.Text = Convert.ToString(dr1["Width_Inch_Sheet1"]);
                ddlEF_NF_PC.Text = Convert.ToString(dr1["EF_NF_PC"]);
                txtBundle_Packet.Text = Convert.ToString(dr1["Bundle_Packet"]);
                txtBox_PerSheet.Text = Convert.ToString(dr1["Box_PerSheet"]);
                ddlCorrugation_Opt.Text = Convert.ToString(dr1["Corrugation_Opt"]);
                ddlPaper_Cutting.Text = Convert.ToString(dr1["Paper_Cutting"]);
                ddlPrinting_Opt.Text = Convert.ToString(dr1["Printing_Opt"]);
                txtNo_Colors.Text = Convert.ToString(dr1["No_Colors"]);
                txtPrntColor_Name.Text = Convert.ToString(dr1["PrntColor_Name"]);
                ddlPaper_Printed.Text = Convert.ToString(dr1["Paper_Printed"]);
                ddlTP_ID.Text = Convert.ToString(dr1["TP_ID"]);
                ddlScoring_Opt.Text = Convert.ToString(dr1["Scoring_Opt"]);
                ddlPunching_Opt.Text = Convert.ToString(dr1["Punching_Opt"]);
                ddlPasting_Opt.Text = Convert.ToString(dr1["Pasting_Opt"]);
                ddlSlotting_Opt.Text = Convert.ToString(dr1["Slotting_Opt"]);
                ddlPinning_Opt.Text = Convert.ToString(dr1["Pinning_Opt"]);
                txtNo_Pins.Text = Convert.ToString(dr1["No_Pins"]);
                ddlPinning_InOut.Text = Convert.ToString(dr1["Pinning_InOut"]);
                ddlSide_Pasting.Text = Convert.ToString(dr1["Side_Pasting"]);
                txtRate_SidePastg.Text = Convert.ToString(dr1["Rate_SidePastg"]);
                ddlCanvas_Opt.Text = Convert.ToString(dr1["Canvas_Opt"]);
                txtSide_Canvas.Text = Convert.ToString(dr1["Side_Canvas"]);
                txtCanvColor_Name.Text = Convert.ToString(dr1["CanvColor_Name"]);
                txtSell_Rate.Text = Convert.ToString(dr1["Sell_Rate"]);
                ddlRate_Type.Text = Convert.ToString(dr1["Rate_Type"]);
                txtExcise_Code.Text = Convert.ToString(dr1["Excise_Code"]);
                txtTop_BF.Text = Convert.ToString(dr1["Top_BF"]);
                txtTop_GSM.Text = Convert.ToString(dr1["Top_GSM"]);
                txtTop_WPP.Text = Convert.ToString(dr1["Top_WPP"]);
                txtTop_BFPP.Text = Convert.ToString(dr1["Top_BFPP"]);
                txtWeight_Pcs.Text = Convert.ToString(dr1["Weight_Pcs"]);
                txtBF_Pcs.Text = Convert.ToString(dr1["BF_Pcs"]);
                txtArtWrk_Code.Text = Convert.ToString(dr1["ArtWrk_Code"]);
                txtArt_Dt.Text = Convert.ToString(dr1["Art_Dt"]);
                txtSpeci_Code.Text = Convert.ToString(dr1["Speci_Code"]);
                ddlFor_Pedilite.Text = Convert.ToString(dr1["For_Pedilite"]);
                txtPedilite_BS.Text = Convert.ToString(dr1["Pedilite_BS"]);
                txtPedilite_GSM.Text = Convert.ToString(dr1["Pedilite_GSM"]);
                txtPedilite_WtBox.Text = Convert.ToString(dr1["Pedilite_WtBox"]);
                Pedilite_PReq.Text = Convert.ToString(dr1["Pedilite_PReq"]);
                ddlI_Lock.Text = Convert.ToString(dr1["I_Lock"]);
                ddlI_Active.Text = Convert.ToString(dr1["I_Active"]);
             
            }
            dr1.Close();
            con1.Close();


          
            con3.Open();
            SqlDataAdapter da8 = new SqlDataAdapter("select a.PB_ID,a.PB_Name from Party_Buyer as a,Party_Master as b where PB_Active='Yes' and a.P_ID='" + ddlP_ID.SelectedValue.ToString() + "' and a.P_ID=b.P_ID and PB_Active='Yes'", con3);
            DataTable dt8 = new DataTable();
            da8.Fill(dt8);
            ddlPB_ID.DataSource = dt8;
            ddlPB_ID.DisplayMember = dt8.Columns[1].ToString();
            ddlPB_ID.ValueMember = dt8.Columns[0].ToString();
            con3.Close();




            pictureBox1.Visible = true;
          
            con3.Open();
            //Retrieve BLOB from database into DataSet.
            SqlCommand cmd = new SqlCommand("select Style_ID,Image_Sheet from Item_Style_Master where Style_ID='" + ddlStyle_ID.SelectedValue.ToString() + "'", con3);
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
            

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
