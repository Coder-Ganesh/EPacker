using ePacker1.App_Code;
using ePacker1.Business_Logic;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;



namespace ePacker1
{
    public partial class RPeP_MasterItem : Form
    {
        private FunctionLib funclib;

        double Inch1, Inch2, Inch3, strTPPBF, strTPGsm, LenInchsheet, WidInchsheet, LenInchsheet1, WidInchsheet1;
        string pid, strSession, Group_ID;
        AllBusinessLogic bl = new AllBusinessLogic();

        /// <summary>
        /// 
        /// </summary>
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
            GetAllItemDataToGrid();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetAllItemDataToGrid()
        {
            try
            {
                DataTable lstAllItems = bl.GetAllItemDataByNameCode(Group_ID, "");
                if (lstAllItems != null)
                {
                    dgwMasterItem.DataSource = lstAllItems;
                    this.dgwMasterItem.Columns[0].Visible = false;
                    this.dgwMasterItem.Columns[1].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while fetching Item Master Data " + ex.Message); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RPeP_MasterItem_Load(object sender, EventArgs e)
        {
            try
            {
                BindParty();
                //BindBoxStyle();
                BindPlySheets();
                BindTopPaper();

                txtI_ID.Visible = false;
                txtTop_BF.Text = "0";

                // inserting item in ddlDimn_Opt
                //ddlDimn_Opt.Items.Add("Outer");
                //ddlDimn_Opt.Items.Add("Inner");

                // inserting item in ddlEF_NF_PC
                ddlEF_NF_PC.Items.Add("EF");
                ddlEF_NF_PC.Items.Add("NF");
                ddlEF_NF_PC.Items.Add("PC");

                cmbUnits.Items.Add("Inch");
                cmbUnits.Items.Add("CM");
                cmbUnits.Items.Add("MM");
                cmbUnits.SelectedText = "Inch";

                DataTable dtActiveddlCorrugation_Opt = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlCorrugation_Opt);
                ddlCorrugation_Opt.DataSource = dtActiveddlCorrugation_Opt;
                ddlCorrugation_Opt.DisplayMember = dtActiveddlCorrugation_Opt.Columns[0].ToString();
                ddlCorrugation_Opt.ValueMember = dtActiveddlCorrugation_Opt.Columns[0].ToString();


                DataTable dtActiveddlPaper_Cutting = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlPaper_Cutting);
                ddlPaper_Cutting.DataSource = dtActiveddlPaper_Cutting;
                ddlPaper_Cutting.DisplayMember = dtActiveddlPaper_Cutting.Columns[0].ToString();
                ddlPaper_Cutting.ValueMember = dtActiveddlPaper_Cutting.Columns[0].ToString();

                DataTable dtActiveddlPinning_Opt = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlPinning_Opt);
                ddlPinning_Opt.DataSource = dtActiveddlPinning_Opt;
                ddlPinning_Opt.DisplayMember = dtActiveddlPinning_Opt.Columns[0].ToString();
                ddlPinning_Opt.ValueMember = dtActiveddlPinning_Opt.Columns[0].ToString();

                DataTable dtActiveddlPaper_Printed = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlPaper_Printed);
                ddlPaper_Printed.DataSource = dtActiveddlPaper_Printed;
                ddlPaper_Printed.DisplayMember = dtActiveddlPaper_Printed.Columns[0].ToString();
                ddlPaper_Printed.ValueMember = dtActiveddlPaper_Printed.Columns[0].ToString();

                DataTable dtActiveddlScoring_Opt = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlScoring_Opt);
                ddlScoring_Opt.DataSource = dtActiveddlScoring_Opt;
                ddlScoring_Opt.DisplayMember = dtActiveddlScoring_Opt.Columns[0].ToString();
                ddlScoring_Opt.ValueMember = dtActiveddlScoring_Opt.Columns[0].ToString();

                DataTable dtActiveddlPunching_Opt = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlPunching_Opt);
                ddlPunching_Opt.DataSource = dtActiveddlPunching_Opt;
                ddlPunching_Opt.DisplayMember = dtActiveddlPunching_Opt.Columns[0].ToString();
                ddlPunching_Opt.ValueMember = dtActiveddlPunching_Opt.Columns[0].ToString();

                DataTable dtActiveddlPasting_Opt = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlPasting_Opt);
                ddlPasting_Opt.DataSource = dtActiveddlPasting_Opt;
                ddlPasting_Opt.DisplayMember = dtActiveddlPasting_Opt.Columns[0].ToString();
                ddlPasting_Opt.ValueMember = dtActiveddlPasting_Opt.Columns[0].ToString();

                DataTable dtActiveddlSlotting_Opt = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlSlotting_Opt);
                ddlSlotting_Opt.DataSource = dtActiveddlSlotting_Opt;
                ddlSlotting_Opt.DisplayMember = dtActiveddlSlotting_Opt.Columns[0].ToString();
                ddlSlotting_Opt.ValueMember = dtActiveddlSlotting_Opt.Columns[0].ToString();

                DataTable dtActiveddlPrinting_Opt = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlPrinting_Opt);
                ddlPrinting_Opt.DataSource = dtActiveddlPrinting_Opt;
                ddlPrinting_Opt.DisplayMember = dtActiveddlPrinting_Opt.Columns[0].ToString();
                ddlPrinting_Opt.ValueMember = dtActiveddlPrinting_Opt.Columns[0].ToString();

                DataTable dtActiveddlSide_Pasting = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlSide_Pasting);
                ddlSide_Pasting.DataSource = dtActiveddlSide_Pasting;
                ddlSide_Pasting.DisplayMember = dtActiveddlSide_Pasting.Columns[0].ToString();
                ddlSide_Pasting.ValueMember = dtActiveddlSide_Pasting.Columns[0].ToString();

                DataTable dtActiveddlCanvas_Opt = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlCanvas_Opt);
                ddlCanvas_Opt.DataSource = dtActiveddlCanvas_Opt;
                ddlCanvas_Opt.DisplayMember = dtActiveddlCanvas_Opt.Columns[0].ToString();
                ddlCanvas_Opt.ValueMember = dtActiveddlCanvas_Opt.Columns[0].ToString();

                DataTable dtActiveddlFor_Pedilite = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlFor_Pedilite);
                ddlFor_Pedilite.DataSource = dtActiveddlFor_Pedilite;
                ddlFor_Pedilite.DisplayMember = dtActiveddlFor_Pedilite.Columns[0].ToString();
                ddlFor_Pedilite.ValueMember = dtActiveddlFor_Pedilite.Columns[0].ToString();

                DataTable dtActiveddlI_Active = new DataTable();
                GlobalFunctions.AddYesNoOptions(ref dtActiveddlI_Active);
                ddlI_Active.DataSource = dtActiveddlI_Active;
                ddlI_Active.DisplayMember = dtActiveddlI_Active.Columns[0].ToString();
                ddlI_Active.ValueMember = dtActiveddlI_Active.Columns[0].ToString();
                ddlI_Active.SelectedText = "Yes";
                ddlI_Active.Enabled = false;

                //DataTable dtPleaseSelect = new DataTable();
                //GlobalFunctions.AddPleaseSelect(ref dtPleaseSelect);

                //ddlPinning_InOut.DataSource = dtPleaseSelect;
                ddlPinning_InOut.Items.Add("Inside");
                ddlPinning_InOut.Items.Add("Outside");

                //ddlRate_Type.DataSource = dtPleaseSelect;
                ddlRate_Type.Items.Add("Average Weight");
                ddlRate_Type.Items.Add("Total Weight");
                ddlRate_Type.Items.Add("Piece");

                ddlI_Lock.Items.Add("Yes");
                ddlI_Lock.Items.Add("No");
                ddlI_Lock.SelectedText = "No";
                ddlI_Lock.Enabled = false;

                this.WindowState = FormWindowState.Maximized;
                //funclib = new FunctionLib();
                //string strcon = funclib.setConnection();
                //ddlPartyMain.Text = "";
                //SqlConnection con2 = new SqlConnection(strcon);
                //con2.Open();
                //SqlDataAdapter da1 = new SqlDataAdapter("SELECT '' as P_ID, '' as P_Name UNION select a.P_ID,a.P_Name from Party_Master as a,Group_Master as b where P_Active='Yes' and a.Grp_ID='" + Group_ID + "' and a.Grp_ID=b.Grp_ID and P_Active='Yes'", con2);
                //DataTable dt1 = new DataTable();
                //da1.Fill(dt1);
                //ddlPartyMain.DataSource = dt1;
                //ddlPartyMain.DisplayMember = dt1.Columns[1].ToString();
                //ddlPartyMain.ValueMember = dt1.Columns[0].ToString();
                //con2.Close();
                ////Displaying values in Style_ID Combobox
                //ddlStyle_ID.Text = "";
                //SqlConnection con = new SqlConnection(strcon);
                //con.Open();
                //SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as Style_ID, '' as Style_No UNION select a.Style_ID,a.Style_No from Item_Style_Master as a,Group_Master as b where Style_Active='Yes' and a.Grp_ID='" + Group_ID + "' and a.Grp_ID=b.Grp_ID and Style_Active='Yes'", con);
                //DataTable dt2 = new DataTable();
                //da2.Fill(dt2);
                //ddlStyle_ID.DataSource = dt2;
                //ddlStyle_ID.DisplayMember = dt2.Columns[1].ToString();
                //ddlStyle_ID.ValueMember = dt2.Columns[0].ToString();
                //con.Close();
                //Displaying values in TopPapare Combobox
                //ddlTP_ID.Text = "";
                //SqlConnection con3 = new SqlConnection(strcon);
                //con3.Open();
                //SqlDataAdapter da3 = new SqlDataAdapter("SELECT '' as TP_ID, '' as TP_Name UNION select a.TP_ID,a.TP_Name from TopPaper_Master as a,Group_Master as b where a.Grp_ID='" + Group_ID + "' and a.Grp_ID=b.Grp_ID and a.TP_Active='Yes'", con3);
                //DataTable dt3 = new DataTable();
                //da3.Fill(dt3);
                //ddlTP_ID.DataSource = dt3;
                //ddlTP_ID.DisplayMember = dt3.Columns[1].ToString();
                //ddlTP_ID.ValueMember = dt3.Columns[0].ToString();
                //con.Close();
                ddlParty.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Loading Page " + ex.Message);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlGrp_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlP_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //ddlPB_ID.Text = "";
                ////Displaying values in PB_ID Combobox
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con3 = new SqlConnection(strcon);
                con3.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT '' as PB_ID, '' as PB_Name UNION select a.PB_ID,a.PB_Name from Party_Buyer as a,Party_Master as b where PB_Active='Yes' and a.P_ID='" + ddlPartyMain.SelectedValue.ToString() + "' and a.P_ID=b.P_ID and PB_Active='Yes'", con3);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                //ddlPB_ID.DataSource = dt2;
                //ddlPB_ID.DisplayMember = dt2.Columns[1].ToString();
                //ddlPB_ID.ValueMember = dt2.Columns[0].ToString();
                con3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Party Change " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLength_Inch_Sheet1_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWidth_Inch_Sheet1_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlParty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtProductCode.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtI_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtI_Name_Leave(object sender, EventArgs e)
        {
            ddlPly_Sheet.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            txtI_Name.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlPly_Sheet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (ddlPly_Sheet.Text == "1" || ddlPly_Sheet.Text == "2")
                { ShowHideFieldsFor1n2Ply(); }
                else if (ddlPly_Sheet.Text == "3")
                { ShowHideFieldsFor3Ply(); }
                else if (ddlPly_Sheet.Text == "5")
                { ShowHideFieldsFor5Ply(); }
                else if (ddlPly_Sheet.Text == "7")
                { ShowHideFieldsFor7Ply(); }
                else if (ddlPly_Sheet.Text == "9")
                { ShowHideFieldsFor9Ply(); }
                else if (ddlPly_Sheet.Text == "11")
                { ShowHideFieldsFor11Ply(); }
                else if (ddlPly_Sheet.Text == "13")
                { ShowHideFieldsFor13Ply(); }
                else if (ddlPly_Sheet.Text == "15")
                { ShowHideFieldsFor15Ply(); }

                cmbUnits.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Ply Change " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbUnits_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbUnits.Text == "Inch" || cmbUnits.Text == "CM" || cmbUnits.Text == "MM")
                {
                    txtBoxLength.Enabled = true;
                    txtBoxWidth.Enabled = true;
                    txtBoxHeight.Enabled = true;

                    txtBoxLength.Text = "0.00";
                    txtBoxWidth.Text = "0.00";
                    txtBoxHeight.Text = "0.00";

                    txtBoxLength_Conv.Text = "0.00";
                    txtBoxWidth_Conv.Text = "0.00";
                    txtBoxHeight_Conv.Text = "0.00";

                    txtLength_Inch_Sheet.Text = "0.00";
                    txtWidth_Inch_Sheet.Text = "0.00";
                }
                else
                {
                    txtBoxLength.Enabled = false;
                    txtBoxWidth.Enabled = false;
                    txtBoxHeight.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while CmbUnit Change " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowHideFieldsFor1n2Ply()
        {
            txt3BackingBF.Visible = false;
            txt3BackingGSM.Visible = false;
            txt3BackingBFPerPpr.Visible = false;
            txt3BackingWtPerPpr.Visible = false;
            txt3FluteBF.Visible = false;
            txt3FluteGSM.Visible = false;
            Txt3FluteBFPrPPr.Visible = false;
            txt3FluteWtPerPpr.Visible = false;
            lbl3Backing.Visible = false;
            lbl3Flute.Visible = false;

            txt5BackBF.Visible = false;
            txt5BackGSM.Visible = false;
            txt5BackBFPrPpr.Visible = false;
            txt5BackWtPrPpr.Visible = false;
            txt5FluteBF.Visible = false;
            txt5FluteGSM.Visible = false;
            txt5FluteBFPrPpr.Visible = false;
            txt5FluteWtPrPpr.Visible = false;
            lbl5backing.Visible = false;
            lbl5Flute.Visible = false;

            txt7BackBF.Visible = false;
            txt7BackGSM.Visible = false;
            txt7BackBFPrppr.Visible = false;
            txt7BackWtPrPpr.Visible = false;
            txt7FluteBF.Visible = false;
            txt7FluteGSM.Visible = false;
            txt7FluteBFPrPpr.Visible = false;
            txt7FluteWtPerPpr.Visible = false;
            lbl7Backing.Visible = false;
            lbl7Flute.Visible = false;

            txt9BackBF.Visible = false;
            txt9BackGSM.Visible = false;
            txt9BackBFPrPpr.Visible = false;
            txt9BackWtPrPpr.Visible = false;
            txt9FluteBF.Visible = false;
            txt9FluteGSM.Visible = false;
            txt9FluteBFPrPpr.Visible = false;
            txt9FluteWtPrPpr.Visible = false;
            lbl9Backing.Visible = false;
            lbl9Flute.Visible = false;

            txt11BackBF.Visible = false;
            txt11BackGSM.Visible = false;
            txt11BackBFPrPpr.Visible = false;
            txt11BackWtPrPpr.Visible = false;
            txt11FluteBF.Visible = false;
            txt11FluteGSM.Visible = false;
            txt11FluteBFPrPpr.Visible = false;
            txt11FluteWtPrPpr.Visible = false;
            lbl11Backing.Visible = false;
            lbl11Flute.Visible = false;

            txt13BackBF.Visible = false;
            txt13BackGSM.Visible = false;
            txt13BackBFPrPpr.Visible = false;
            txt13BackWtPrPpr.Visible = false;
            txt13FluteBF.Visible = false;
            txt13FluteGSM.Visible = false;
            txt13FluteBFPrPpr.Visible = false;
            txt13FluteWtPrPpr.Visible = false;
            lbl13Backing.Visible = false;
            lbl13Flute.Visible = false;

            txt15BackBF.Visible = false;
            txt15BackGSM.Visible = false;
            txt15BackBFPrPpr.Visible = false;
            txt15BackWtPrPpr.Visible = false;
            txt15FluteBF.Visible = false;
            txt15FluteGSM.Visible = false;
            txt15FluteBFPrPpr.Visible = false;
            txt15FluteWtPrPpr.Visible = false;
            lbl15Backing.Visible = false;
            lbl15Flute.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowHideFieldsFor3Ply()
        {
            txt3BackingBF.Visible = true;
            txt3BackingGSM.Visible = true;
            txt3BackingBFPerPpr.Visible = true;
            txt3BackingWtPerPpr.Visible = true;
            txt3FluteBF.Visible = true;
            txt3FluteGSM.Visible = true;
            Txt3FluteBFPrPPr.Visible = true;
            txt3FluteWtPerPpr.Visible = true;
            lbl3Backing.Visible = true;
            lbl3Flute.Visible = true;

            txt5BackBF.Visible = false;
            txt5BackGSM.Visible = false;
            txt5BackBFPrPpr.Visible = false;
            txt5BackWtPrPpr.Visible = false;
            txt5FluteBF.Visible = false;
            txt5FluteGSM.Visible = false;
            txt5FluteBFPrPpr.Visible = false;
            txt5FluteWtPrPpr.Visible = false;
            lbl5backing.Visible = false;
            lbl5Flute.Visible = false;

            txt7BackBF.Visible = false;
            txt7BackGSM.Visible = false;
            txt7BackBFPrppr.Visible = false;
            txt7BackWtPrPpr.Visible = false;
            txt7FluteBF.Visible = false;
            txt7FluteGSM.Visible = false;
            txt7FluteBFPrPpr.Visible = false;
            txt7FluteWtPerPpr.Visible = false;
            lbl7Backing.Visible = false;
            lbl7Flute.Visible = false;

            txt9BackBF.Visible = false;
            txt9BackGSM.Visible = false;
            txt9BackBFPrPpr.Visible = false;
            txt9BackWtPrPpr.Visible = false;
            txt9FluteBF.Visible = false;
            txt9FluteGSM.Visible = false;
            txt9FluteBFPrPpr.Visible = false;
            txt9FluteWtPrPpr.Visible = false;
            lbl9Backing.Visible = false;
            lbl9Flute.Visible = false;

            txt11BackBF.Visible = false;
            txt11BackGSM.Visible = false;
            txt11BackBFPrPpr.Visible = false;
            txt11BackWtPrPpr.Visible = false;
            txt11FluteBF.Visible = false;
            txt11FluteGSM.Visible = false;
            txt11FluteBFPrPpr.Visible = false;
            txt11FluteWtPrPpr.Visible = false;
            lbl11Backing.Visible = false;
            lbl11Flute.Visible = false;

            txt13BackBF.Visible = false;
            txt13BackGSM.Visible = false;
            txt13BackBFPrPpr.Visible = false;
            txt13BackWtPrPpr.Visible = false;
            txt13FluteBF.Visible = false;
            txt13FluteGSM.Visible = false;
            txt13FluteBFPrPpr.Visible = false;
            txt13FluteWtPrPpr.Visible = false;
            lbl13Backing.Visible = false;
            lbl13Flute.Visible = false;

            txt15BackBF.Visible = false;
            txt15BackGSM.Visible = false;
            txt15BackBFPrPpr.Visible = false;
            txt15BackWtPrPpr.Visible = false;
            txt15FluteBF.Visible = false;
            txt15FluteGSM.Visible = false;
            txt15FluteBFPrPpr.Visible = false;
            txt15FluteWtPrPpr.Visible = false;
            lbl15Backing.Visible = false;
            lbl15Flute.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowHideFieldsFor5Ply()
        {
            txt3BackingBF.Visible = true;
            txt3BackingGSM.Visible = true;
            txt3BackingBFPerPpr.Visible = true;
            txt3BackingWtPerPpr.Visible = true;
            txt3FluteBF.Visible = true;
            txt3FluteGSM.Visible = true;
            Txt3FluteBFPrPPr.Visible = true;
            txt3FluteWtPerPpr.Visible = true;
            lbl3Backing.Visible = true;
            lbl3Flute.Visible = true;

            txt5BackBF.Visible = true;
            txt5BackGSM.Visible = true;
            txt5BackBFPrPpr.Visible = true;
            txt5BackWtPrPpr.Visible = true;
            txt5FluteBF.Visible = true;
            txt5FluteGSM.Visible = true;
            txt5FluteBFPrPpr.Visible = true;
            txt5FluteWtPrPpr.Visible = true;
            lbl5backing.Visible = true;
            lbl5Flute.Visible = true;

            txt7BackBF.Visible = false;
            txt7BackGSM.Visible = false;
            txt7BackBFPrppr.Visible = false;
            txt7BackWtPrPpr.Visible = false;
            txt7FluteBF.Visible = false;
            txt7FluteGSM.Visible = false;
            txt7FluteBFPrPpr.Visible = false;
            txt7FluteWtPerPpr.Visible = false;
            lbl7Backing.Visible = false;
            lbl7Flute.Visible = false;

            txt9BackBF.Visible = false;
            txt9BackGSM.Visible = false;
            txt9BackBFPrPpr.Visible = false;
            txt9BackWtPrPpr.Visible = false;
            txt9FluteBF.Visible = false;
            txt9FluteGSM.Visible = false;
            txt9FluteBFPrPpr.Visible = false;
            txt9FluteWtPrPpr.Visible = false;
            lbl9Backing.Visible = false;
            lbl9Flute.Visible = false;

            txt11BackBF.Visible = false;
            txt11BackGSM.Visible = false;
            txt11BackBFPrPpr.Visible = false;
            txt11BackWtPrPpr.Visible = false;
            txt11FluteBF.Visible = false;
            txt11FluteGSM.Visible = false;
            txt11FluteBFPrPpr.Visible = false;
            txt11FluteWtPrPpr.Visible = false;
            lbl11Backing.Visible = false;
            lbl11Flute.Visible = false;

            txt13BackBF.Visible = false;
            txt13BackGSM.Visible = false;
            txt13BackBFPrPpr.Visible = false;
            txt13BackWtPrPpr.Visible = false;
            txt13FluteBF.Visible = false;
            txt13FluteGSM.Visible = false;
            txt13FluteBFPrPpr.Visible = false;
            txt13FluteWtPrPpr.Visible = false;
            lbl13Backing.Visible = false;
            lbl13Flute.Visible = false;

            txt15BackBF.Visible = false;
            txt15BackGSM.Visible = false;
            txt15BackBFPrPpr.Visible = false;
            txt15BackWtPrPpr.Visible = false;
            txt15FluteBF.Visible = false;
            txt15FluteGSM.Visible = false;
            txt15FluteBFPrPpr.Visible = false;
            txt15FluteWtPrPpr.Visible = false;
            lbl15Backing.Visible = false;
            lbl15Flute.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowHideFieldsFor7Ply()
        {
            txt3BackingBF.Visible = true;
            txt3BackingGSM.Visible = true;
            txt3BackingBFPerPpr.Visible = true;
            txt3BackingWtPerPpr.Visible = true;
            txt3FluteBF.Visible = true;
            txt3FluteGSM.Visible = true;
            Txt3FluteBFPrPPr.Visible = true;
            txt3FluteWtPerPpr.Visible = true;
            lbl3Backing.Visible = true;
            lbl3Flute.Visible = true;

            txt5BackBF.Visible = true;
            txt5BackGSM.Visible = true;
            txt5BackBFPrPpr.Visible = true;
            txt5BackWtPrPpr.Visible = true;
            txt5FluteBF.Visible = true;
            txt5FluteGSM.Visible = true;
            txt5FluteBFPrPpr.Visible = true;
            txt5FluteWtPrPpr.Visible = true;
            lbl5backing.Visible = true;
            lbl5Flute.Visible = true;

            txt7BackBF.Visible = true;
            txt7BackGSM.Visible = true;
            txt7BackBFPrppr.Visible = true;
            txt7BackWtPrPpr.Visible = true;
            txt7FluteBF.Visible = true;
            txt7FluteGSM.Visible = true;
            txt7FluteBFPrPpr.Visible = true;
            txt7FluteWtPerPpr.Visible = true;
            lbl7Backing.Visible = true;
            lbl7Flute.Visible = true;

            txt9BackBF.Visible = false;
            txt9BackGSM.Visible = false;
            txt9BackBFPrPpr.Visible = false;
            txt9BackWtPrPpr.Visible = false;
            txt9FluteBF.Visible = false;
            txt9FluteGSM.Visible = false;
            txt9FluteBFPrPpr.Visible = false;
            txt9FluteWtPrPpr.Visible = false;
            lbl9Backing.Visible = false;
            lbl9Flute.Visible = false;

            txt11BackBF.Visible = false;
            txt11BackGSM.Visible = false;
            txt11BackBFPrPpr.Visible = false;
            txt11BackWtPrPpr.Visible = false;
            txt11FluteBF.Visible = false;
            txt11FluteGSM.Visible = false;
            txt11FluteBFPrPpr.Visible = false;
            txt11FluteWtPrPpr.Visible = false;
            lbl11Backing.Visible = false;
            lbl11Flute.Visible = false;

            txt13BackBF.Visible = false;
            txt13BackGSM.Visible = false;
            txt13BackBFPrPpr.Visible = false;
            txt13BackWtPrPpr.Visible = false;
            txt13FluteBF.Visible = false;
            txt13FluteGSM.Visible = false;
            txt13FluteBFPrPpr.Visible = false;
            txt13FluteWtPrPpr.Visible = false;
            lbl13Backing.Visible = false;
            lbl13Flute.Visible = false;

            txt15BackBF.Visible = false;
            txt15BackGSM.Visible = false;
            txt15BackBFPrPpr.Visible = false;
            txt15BackWtPrPpr.Visible = false;
            txt15FluteBF.Visible = false;
            txt15FluteGSM.Visible = false;
            txt15FluteBFPrPpr.Visible = false;
            txt15FluteWtPrPpr.Visible = false;
            lbl15Backing.Visible = false;
            lbl15Flute.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowHideFieldsFor9Ply()
        {
            txt3BackingBF.Visible = true;
            txt3BackingGSM.Visible = true;
            txt3BackingBFPerPpr.Visible = true;
            txt3BackingWtPerPpr.Visible = true;
            txt3FluteBF.Visible = true;
            txt3FluteGSM.Visible = true;
            Txt3FluteBFPrPPr.Visible = true;
            txt3FluteWtPerPpr.Visible = true;
            lbl3Backing.Visible = true;
            lbl3Flute.Visible = true;

            txt5BackBF.Visible = true;
            txt5BackGSM.Visible = true;
            txt5BackBFPrPpr.Visible = true;
            txt5BackWtPrPpr.Visible = true;
            txt5FluteBF.Visible = true;
            txt5FluteGSM.Visible = true;
            txt5FluteBFPrPpr.Visible = true;
            txt5FluteWtPrPpr.Visible = true;
            lbl5backing.Visible = true;
            lbl5Flute.Visible = true;

            txt7BackBF.Visible = true;
            txt7BackGSM.Visible = true;
            txt7BackBFPrppr.Visible = true;
            txt7BackWtPrPpr.Visible = true;
            txt7FluteBF.Visible = true;
            txt7FluteGSM.Visible = true;
            txt7FluteBFPrPpr.Visible = true;
            txt7FluteWtPerPpr.Visible = true;
            lbl7Backing.Visible = true;
            lbl7Flute.Visible = true;

            txt9BackBF.Visible = true;
            txt9BackGSM.Visible = true;
            txt9BackBFPrPpr.Visible = true;
            txt9BackWtPrPpr.Visible = true;
            txt9FluteBF.Visible = true;
            txt9FluteGSM.Visible = true;
            txt9FluteBFPrPpr.Visible = true;
            txt9FluteWtPrPpr.Visible = true;
            lbl9Backing.Visible = true;
            lbl9Flute.Visible = true;

            txt11BackBF.Visible = false;
            txt11BackGSM.Visible = false;
            txt11BackBFPrPpr.Visible = false;
            txt11BackWtPrPpr.Visible = false;
            txt11FluteBF.Visible = false;
            txt11FluteGSM.Visible = false;
            txt11FluteBFPrPpr.Visible = false;
            txt11FluteWtPrPpr.Visible = false;
            lbl11Backing.Visible = false;
            lbl11Flute.Visible = false;

            txt13BackBF.Visible = false;
            txt13BackGSM.Visible = false;
            txt13BackBFPrPpr.Visible = false;
            txt13BackWtPrPpr.Visible = false;
            txt13FluteBF.Visible = false;
            txt13FluteGSM.Visible = false;
            txt13FluteBFPrPpr.Visible = false;
            txt13FluteWtPrPpr.Visible = false;
            lbl13Backing.Visible = false;
            lbl13Flute.Visible = false;

            txt15BackBF.Visible = false;
            txt15BackGSM.Visible = false;
            txt15BackBFPrPpr.Visible = false;
            txt15BackWtPrPpr.Visible = false;
            txt15FluteBF.Visible = false;
            txt15FluteGSM.Visible = false;
            txt15FluteBFPrPpr.Visible = false;
            txt15FluteWtPrPpr.Visible = false;
            lbl15Backing.Visible = false;
            lbl15Flute.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowHideFieldsFor11Ply()
        {
            txt3BackingBF.Visible = true;
            txt3BackingGSM.Visible = true;
            txt3BackingBFPerPpr.Visible = true;
            txt3BackingWtPerPpr.Visible = true;
            txt3FluteBF.Visible = true;
            txt3FluteGSM.Visible = true;
            Txt3FluteBFPrPPr.Visible = true;
            txt3FluteWtPerPpr.Visible = true;
            lbl3Backing.Visible = true;
            lbl3Flute.Visible = true;

            txt5BackBF.Visible = true;
            txt5BackGSM.Visible = true;
            txt5BackBFPrPpr.Visible = true;
            txt5BackWtPrPpr.Visible = true;
            txt5FluteBF.Visible = true;
            txt5FluteGSM.Visible = true;
            txt5FluteBFPrPpr.Visible = true;
            txt5FluteWtPrPpr.Visible = true;
            lbl5backing.Visible = true;
            lbl5Flute.Visible = true;

            txt7BackBF.Visible = true;
            txt7BackGSM.Visible = true;
            txt7BackBFPrppr.Visible = true;
            txt7BackWtPrPpr.Visible = true;
            txt7FluteBF.Visible = true;
            txt7FluteGSM.Visible = true;
            txt7FluteBFPrPpr.Visible = true;
            txt7FluteWtPerPpr.Visible = true;
            lbl7Backing.Visible = true;
            lbl7Flute.Visible = true;

            txt9BackBF.Visible = true;
            txt9BackGSM.Visible = true;
            txt9BackBFPrPpr.Visible = true;
            txt9BackWtPrPpr.Visible = true;
            txt9FluteBF.Visible = true;
            txt9FluteGSM.Visible = true;
            txt9FluteBFPrPpr.Visible = true;
            txt9FluteWtPrPpr.Visible = true;
            lbl9Backing.Visible = true;
            lbl9Flute.Visible = true;

            txt11BackBF.Visible = true;
            txt11BackGSM.Visible = true;
            txt11BackBFPrPpr.Visible = true;
            txt11BackWtPrPpr.Visible = true;
            txt11FluteBF.Visible = true;
            txt11FluteGSM.Visible = true;
            txt11FluteBFPrPpr.Visible = true;
            txt11FluteWtPrPpr.Visible = true;
            lbl11Backing.Visible = true;
            lbl11Flute.Visible = true;

            txt13BackBF.Visible = false;
            txt13BackGSM.Visible = false;
            txt13BackBFPrPpr.Visible = false;
            txt13BackWtPrPpr.Visible = false;
            txt13FluteBF.Visible = false;
            txt13FluteGSM.Visible = false;
            txt13FluteBFPrPpr.Visible = false;
            txt13FluteWtPrPpr.Visible = false;
            lbl13Backing.Visible = false;
            lbl13Flute.Visible = false;

            txt15BackBF.Visible = false;
            txt15BackGSM.Visible = false;
            txt15BackBFPrPpr.Visible = false;
            txt15BackWtPrPpr.Visible = false;
            txt15FluteBF.Visible = false;
            txt15FluteGSM.Visible = false;
            txt15FluteBFPrPpr.Visible = false;
            txt15FluteWtPrPpr.Visible = false;
            lbl15Backing.Visible = false;
            lbl15Flute.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowHideFieldsFor13Ply()
        {
            txt3BackingBF.Visible = true;
            txt3BackingGSM.Visible = true;
            txt3BackingBFPerPpr.Visible = true;
            txt3BackingWtPerPpr.Visible = true;
            txt3FluteBF.Visible = true;
            txt3FluteGSM.Visible = true;
            Txt3FluteBFPrPPr.Visible = true;
            txt3FluteWtPerPpr.Visible = true;
            lbl3Backing.Visible = true;
            lbl3Flute.Visible = true;

            txt5BackBF.Visible = true;
            txt5BackGSM.Visible = true;
            txt5BackBFPrPpr.Visible = true;
            txt5BackWtPrPpr.Visible = true;
            txt5FluteBF.Visible = true;
            txt5FluteGSM.Visible = true;
            txt5FluteBFPrPpr.Visible = true;
            txt5FluteWtPrPpr.Visible = true;
            lbl5backing.Visible = true;
            lbl5Flute.Visible = true;

            txt7BackBF.Visible = true;
            txt7BackGSM.Visible = true;
            txt7BackBFPrppr.Visible = true;
            txt7BackWtPrPpr.Visible = true;
            txt7FluteBF.Visible = true;
            txt7FluteGSM.Visible = true;
            txt7FluteBFPrPpr.Visible = true;
            txt7FluteWtPerPpr.Visible = true;
            lbl7Backing.Visible = true;
            lbl7Flute.Visible = true;

            txt9BackBF.Visible = true;
            txt9BackGSM.Visible = true;
            txt9BackBFPrPpr.Visible = true;
            txt9BackWtPrPpr.Visible = true;
            txt9FluteBF.Visible = true;
            txt9FluteGSM.Visible = true;
            txt9FluteBFPrPpr.Visible = true;
            txt9FluteWtPrPpr.Visible = true;
            lbl9Backing.Visible = true;
            lbl9Flute.Visible = true;

            txt11BackBF.Visible = true;
            txt11BackGSM.Visible = true;
            txt11BackBFPrPpr.Visible = true;
            txt11BackWtPrPpr.Visible = true;
            txt11FluteBF.Visible = true;
            txt11FluteGSM.Visible = true;
            txt11FluteBFPrPpr.Visible = true;
            txt11FluteWtPrPpr.Visible = true;
            lbl11Backing.Visible = true;
            lbl11Flute.Visible = true;

            txt13BackBF.Visible = true;
            txt13BackGSM.Visible = true;
            txt13BackBFPrPpr.Visible = true;
            txt13BackWtPrPpr.Visible = true;
            txt13FluteBF.Visible = true;
            txt13FluteGSM.Visible = true;
            txt13FluteBFPrPpr.Visible = true;
            txt13FluteWtPrPpr.Visible = true;
            lbl13Backing.Visible = true;
            lbl13Flute.Visible = true;

            txt15BackBF.Visible = false;
            txt15BackGSM.Visible = false;
            txt15BackBFPrPpr.Visible = false;
            txt15BackWtPrPpr.Visible = false;
            txt15FluteBF.Visible = false;
            txt15FluteGSM.Visible = false;
            txt15FluteBFPrPpr.Visible = false;
            txt15FluteWtPrPpr.Visible = false;
            lbl15Backing.Visible = false;
            lbl15Flute.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowHideFieldsFor15Ply()
        {
            txt3BackingBF.Visible = true;
            txt3BackingGSM.Visible = true;
            txt3BackingBFPerPpr.Visible = true;
            txt3BackingWtPerPpr.Visible = true;
            txt3FluteBF.Visible = true;
            txt3FluteGSM.Visible = true;
            Txt3FluteBFPrPPr.Visible = true;
            txt3FluteWtPerPpr.Visible = true;
            lbl3Backing.Visible = true;
            lbl3Flute.Visible = true;

            txt5BackBF.Visible = true;
            txt5BackGSM.Visible = true;
            txt5BackBFPrPpr.Visible = true;
            txt5BackWtPrPpr.Visible = true;
            txt5FluteBF.Visible = true;
            txt5FluteGSM.Visible = true;
            txt5FluteBFPrPpr.Visible = true;
            txt5FluteWtPrPpr.Visible = true;
            lbl5backing.Visible = true;
            lbl5Flute.Visible = true;

            txt7BackBF.Visible = true;
            txt7BackGSM.Visible = true;
            txt7BackBFPrppr.Visible = true;
            txt7BackWtPrPpr.Visible = true;
            txt7FluteBF.Visible = true;
            txt7FluteGSM.Visible = true;
            txt7FluteBFPrPpr.Visible = true;
            txt7FluteWtPerPpr.Visible = true;
            lbl7Backing.Visible = true;
            lbl7Flute.Visible = true;

            txt9BackBF.Visible = true;
            txt9BackGSM.Visible = true;
            txt9BackBFPrPpr.Visible = true;
            txt9BackWtPrPpr.Visible = true;
            txt9FluteBF.Visible = true;
            txt9FluteGSM.Visible = true;
            txt9FluteBFPrPpr.Visible = true;
            txt9FluteWtPrPpr.Visible = true;
            lbl9Backing.Visible = true;
            lbl9Flute.Visible = true;

            txt11BackBF.Visible = true;
            txt11BackGSM.Visible = true;
            txt11BackBFPrPpr.Visible = true;
            txt11BackWtPrPpr.Visible = true;
            txt11FluteBF.Visible = true;
            txt11FluteGSM.Visible = true;
            txt11FluteBFPrPpr.Visible = true;
            txt11FluteWtPrPpr.Visible = true;
            lbl11Backing.Visible = true;
            lbl11Flute.Visible = true;

            txt13BackBF.Visible = true;
            txt13BackGSM.Visible = true;
            txt13BackBFPrPpr.Visible = true;
            txt13BackWtPrPpr.Visible = true;
            txt13FluteBF.Visible = true;
            txt13FluteGSM.Visible = true;
            txt13FluteBFPrPpr.Visible = true;
            txt13FluteWtPrPpr.Visible = true;
            lbl13Backing.Visible = true;
            lbl13Flute.Visible = true;

            txt15BackBF.Visible = true;
            txt15BackGSM.Visible = true;
            txt15BackBFPrPpr.Visible = true;
            txt15BackWtPrPpr.Visible = true;
            txt15FluteBF.Visible = true;
            txt15FluteGSM.Visible = true;
            txt15FluteBFPrPpr.Visible = true;
            txt15FluteWtPrPpr.Visible = true;
            lbl15Backing.Visible = true;
            lbl15Flute.Visible = true;
        }

        #region BOX SIZE EVENTS

        #region INCH SELECTION
        //private void chkBoxInch_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkBoxInch.Checked == true)
        //    {
        //        txtLength_Inch.Enabled = true;
        //        txtWidth_Inch.Enabled = true;
        //        txtHeight_Inch.Enabled = true;
        //        txtBoxCmLength.Enabled = false;
        //        txtBoxCmWidth.Enabled = false;
        //        txtBoxCmHeight.Enabled = false;
        //        txtLength_MM.Enabled = false;
        //        txtWidth_MM.Enabled = false;
        //        txtHeight_MM.Enabled = false;

        //        chkBoxCM.Enabled = false;
        //        chkBoxMM.Enabled = false;

        //        txtLength_Inch.Focus();
        //    }
        //    else
        //    {
        //        txtBoxCmLength.Enabled = true;
        //        txtBoxCmWidth.Enabled = true;
        //        txtBoxCmHeight.Enabled = true;
        //        txtBoxCmLength.Text = "0";
        //        txtBoxCmWidth.Text = "0";
        //        txtBoxCmHeight.Text = "0";

        //        txtLength_MM.Enabled = true;
        //        txtWidth_MM.Enabled = true;
        //        txtHeight_MM.Enabled = true;
        //        txtLength_MM.Text = "0";
        //        txtWidth_MM.Text = "0";
        //        txtHeight_MM.Text = "0";

        //        txtLength_Inch.Enabled = true;
        //        txtWidth_Inch.Enabled = true;
        //        txtHeight_Inch.Enabled = true;
        //        txtLength_Inch.Text = "0";
        //        txtWidth_Inch.Text = "0";
        //        txtHeight_Inch.Text = "0";

        //        chkBoxCM.Enabled = true;
        //        chkBoxMM.Enabled = true;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLength_Inch_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtLength_Inch_Leave(object sender, EventArgs e)
        {
            double LengthInch = Convert.ToDouble(txtBoxLength.Text);
            double lengthCM = Math.Round((LengthInch * 2.54), 2);
            double lengthMM = Math.Round((LengthInch * 25.4), 2);

            //txtBoxCmLength.Text = Convert.ToString(lengthCM);
            //txtBoxCmLength.Enabled = false;

            //txtLength_MM.Text = lengthMM.ToString();
            //txtLength_MM.Enabled = false;

            txtBoxWidth.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWidth_Inch_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtWidth_Inch_Leave(object sender, EventArgs e)
        {
            double WidthInch = Convert.ToDouble(txtBoxWidth.Text);
            double widthCM = Math.Round((WidthInch * 2.54), 2);
            double widthMM = Math.Round((WidthInch * 25.4), 2);

            //txtBoxCmWidth.Text = Convert.ToString(widthCM);
            //txtBoxCmWidth.Enabled = false;

            //txtWidth_MM.Text = widthMM.ToString();
            //txtWidth_MM.Enabled = false;

            txtBoxHeight.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHeight_Inch_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtHeight_Inch_Leave(object sender, EventArgs e)
        {
            double heightInch = Convert.ToDouble(txtBoxHeight.Text);
            double heightCM = Math.Round((heightInch * 2.54), 2);
            double heightMM = Math.Round((heightInch * 25.4), 2);

            //txtBoxCmHeight.Text = Convert.ToString(heightCM);
            //txtBoxCmHeight.Enabled = false;

            //txtWidth_MM.Text = heightMM.ToString();
            //txtWidth_MM.Enabled = false;

            chkBoxConvInside.Focus();
        }
        #endregion


        #region CM SELECTION
        //private void chkBoxCM_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkBoxCM.Checked == true)
        //    {
        //        txtLength_Inch.Enabled = false;
        //        txtWidth_Inch.Enabled = false;
        //        txtHeight_Inch.Enabled = false;
        //        txtBoxCmLength.Enabled = true;
        //        txtBoxCmWidth.Enabled = true;
        //        txtBoxCmHeight.Enabled = true;
        //        txtLength_MM.Enabled = false;
        //        txtWidth_MM.Enabled = false;
        //        txtHeight_MM.Enabled = false;

        //        chkBoxInch.Enabled = false;
        //        chkBoxMM.Enabled = false;

        //        txtBoxCmLength.Focus();
        //    }
        //    else
        //    {
        //        txtBoxCmLength.Enabled = true;
        //        txtBoxCmWidth.Enabled = true;
        //        txtBoxCmHeight.Enabled = true;
        //        txtBoxCmLength.Text = "0";
        //        txtBoxCmWidth.Text = "0";
        //        txtBoxCmHeight.Text = "0";

        //        txtLength_MM.Enabled = true;
        //        txtWidth_MM.Enabled = true;
        //        txtHeight_MM.Enabled = true;
        //        txtLength_MM.Text = "0";
        //        txtWidth_MM.Text = "0";
        //        txtHeight_MM.Text = "0";

        //        txtLength_Inch.Enabled = true;
        //        txtWidth_Inch.Enabled = true;
        //        txtHeight_Inch.Enabled = true;
        //        txtLength_Inch.Text = "0";
        //        txtWidth_Inch.Text = "0";
        //        txtHeight_Inch.Text = "0";

        //        chkBoxInch.Enabled = true;
        //        chkBoxMM.Enabled = true;
        //    }
        //}

        private void txtBoxCmLength_Leave(object sender, EventArgs e)
        {
            //double lengthCM = Convert.ToDouble(txtBoxCmLength.Text);
            //double lengthInch = Math.Round((lengthCM / 2.54), 2);
            //double lengthMM = Math.Round((lengthCM * 10), 2);

            //txtBoxLength.Text = Convert.ToString(lengthInch);
            //txtBoxLength.Enabled = false;

            //txtLength_MM.Text = lengthMM.ToString();
            //txtLength_MM.Enabled = false;

            //txtBoxCmWidth.Focus();
        }

        private void txtBoxCmWidth_Leave(object sender, EventArgs e)
        {
            //double widthCM = Convert.ToDouble(txtBoxCmWidth.Text);
            //double widthInch = Math.Round((widthCM / 2.54), 2);
            //double widthMM = Math.Round((widthCM * 10), 2);

            //txtBoxWidth.Text = Convert.ToString(widthInch);
            //txtBoxWidth.Enabled = false;

            //txtWidth_MM.Text = widthMM.ToString();
            //txtWidth_MM.Enabled = false;

            //txtBoxCmHeight.Focus();
        }

        private void txtBoxCmHeight_Leave(object sender, EventArgs e)
        {
            //double heightCM = Convert.ToDouble(txtBoxCmWidth.Text);
            //double heightInch = Math.Round((heightCM / 2.54), 2);
            //double heightMM = Math.Round((heightCM * 10), 2);

            //txtBoxHeight.Text = Convert.ToString(heightInch);
            //txtBoxHeight.Enabled = false;

            //txtLength_MM.Text = heightMM.ToString();
            //txtLength_MM.Enabled = false;

            //chkBoxConvInside.Focus();
        }
        #endregion


        #region MM SELECTION
        //private void chkBoxMM_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkBoxMM.Checked == true)
        //    {
        //        txtLength_Inch.Enabled = false;
        //        txtWidth_Inch.Enabled = false;
        //        txtHeight_Inch.Enabled = false;
        //        txtBoxCmLength.Enabled = false;
        //        txtBoxCmWidth.Enabled = false;
        //        txtBoxCmHeight.Enabled = false;
        //        txtLength_MM.Enabled = true;
        //        txtWidth_MM.Enabled = true;
        //        txtHeight_MM.Enabled = true;

        //        chkBoxInch.Enabled = false;
        //        chkBoxCM.Enabled = false;

        //        txtLength_MM.Focus();
        //    }
        //    else
        //    {
        //        txtBoxCmLength.Enabled = true;
        //        txtBoxCmWidth.Enabled = true;
        //        txtBoxCmHeight.Enabled = true;
        //        txtBoxCmLength.Text = "0";
        //        txtBoxCmWidth.Text = "0";
        //        txtBoxCmHeight.Text = "0";

        //        txtLength_MM.Enabled = true;
        //        txtWidth_MM.Enabled = true;
        //        txtHeight_MM.Enabled = true;
        //        txtLength_MM.Text = "0";
        //        txtWidth_MM.Text = "0";
        //        txtHeight_MM.Text = "0";

        //        txtLength_Inch.Enabled = true;
        //        txtWidth_Inch.Enabled = true;
        //        txtHeight_Inch.Enabled = true;
        //        txtLength_Inch.Text = "0";
        //        txtWidth_Inch.Text = "0";
        //        txtHeight_Inch.Text = "0";

        //        chkBoxInch.Enabled = true;
        //        chkBoxCM.Enabled = true;
        //    }
        //}

        private void txtLength_MM_Leave(object sender, EventArgs e)
        {
            //double lengthMM = Convert.ToDouble(txtLength_MM.Text);
            //double lengthInch = Math.Round((lengthMM / 25.4), 2);
            //double lengthCM = Math.Round((lengthMM / 10), 2);

            //txtBoxLength.Text = Convert.ToString(lengthInch);
            //txtBoxLength.Enabled = false;

            //txtBoxCmLength.Text = lengthCM.ToString();
            //txtBoxCmLength.Enabled = false;

            //txtWidth_MM.Focus();
        }

        private void txtWidth_MM_Leave(object sender, EventArgs e)
        {
            //double widthMM = Convert.ToDouble(txtWidth_MM.Text);
            //double widthInch = Math.Round((widthMM / 25.4), 2);
            //double widthCM = Math.Round((widthMM / 10), 2);

            //txtBoxWidth.Text = Convert.ToString(widthInch);
            //txtBoxWidth.Enabled = false;

            //txtBoxCmWidth.Text = widthCM.ToString();
            //txtBoxCmWidth.Enabled = false;

            //txtHeight_MM.Focus();
        }

        private void txtHeight_MM_Leave(object sender, EventArgs e)
        {
            //double heightMM = Convert.ToDouble(txtHeight_MM.Text);
            //double heightInch = Math.Round((heightMM / 25.4), 2);
            //double heightCM = Math.Round((heightMM / 10), 2);

            //txtBoxHeight.Text = Convert.ToString(heightInch);
            //txtBoxHeight.Enabled = false;

            //txtBoxCmHeight.Text = heightCM.ToString();
            //txtBoxCmHeight.Enabled = false;

            //chkBoxConvInside.Focus();
        }
        #endregion


        #region BOX CONVERSION SELECTION
        private void chkBoxConvInside_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxConvInside.Checked == true)
            {
                if (cmbUnits.SelectedItem == "Inch")
                {
                    if (ddlPly_Sheet.SelectedValue == "1" || ddlPly_Sheet.SelectedValue == "2")
                    {
                        txtBoxLength_Conv.Text = txtBoxLength.Text;
                        txtBoxWidth_Conv.Text = txtBoxWidth.Text;
                        txtBoxHeight_Conv.Text = txtBoxHeight.Text;

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text);
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text);
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text);

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 10) / 25.4, 2));
                    }
                    else if (ddlPly_Sheet.SelectedValue == "3")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxLength.Text) + 0.118, 2));
                        txtBoxWidth_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxWidth.Text) + 0.118, 2));
                        txtBoxHeight_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxHeight.Text) + 0.196, 2));

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text);
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text);
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text);

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 30) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "5")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxLength.Text) + 0.196, 2));
                        txtBoxWidth_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxWidth.Text) + 0.196, 2));
                        txtBoxHeight_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxHeight.Text) + 0.314, 2));

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text);
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text);
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text);

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 40) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "7")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxLength.Text) + 0.196, 2));
                        txtBoxWidth_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxWidth.Text) + 0.196, 2));
                        txtBoxHeight_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxHeight.Text) + 0.314, 2));

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text);
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text);
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text);

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "9")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxLength.Text) + 0.196, 2));
                        txtBoxWidth_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxWidth.Text) + 0.196, 2));
                        txtBoxHeight_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxHeight.Text) + 0.393, 2));

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text);
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text);
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text);

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "11")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxLength.Text) + 0.275, 2));
                        txtBoxWidth_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxWidth.Text) + 0.275, 2));
                        txtBoxHeight_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxHeight.Text) + 0.472, 2));

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text);
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text);
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text);

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "13" || ddlPly_Sheet.SelectedValue == "15")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxLength.Text) + 0.393, 2));
                        txtBoxWidth_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxWidth.Text) + 0.393, 2));
                        txtBoxHeight_Conv.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxHeight.Text) + 0.59, 2));

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text);
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text);
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text);

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else
                    {
                        txtBoxLength_Conv.Text = txtBoxLength.Text;
                        txtBoxWidth_Conv.Text = txtBoxWidth.Text;
                        txtBoxHeight_Conv.Text = txtBoxHeight.Text;

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text);
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text);
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text);

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBoxWidth) + Convert.ToDouble(txtBoxHeight), 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((Convert.ToDouble(txtBoxLength.Text) + Convert.ToDouble(txtBoxWidth.Text) + Convert.ToDouble(txtBoxLength.Text) + Convert.ToDouble(txtBoxWidth.Text) + 10) / 25.4, 2));
                    }
                    ChkBoxConvOutside.Enabled = false;
                    ddlEF_NF_PC.Focus();
                }
                else if (cmbUnits.SelectedItem == "CM")
                {
                    if (ddlPly_Sheet.SelectedValue == "1" || ddlPly_Sheet.SelectedValue == "2")
                    {
                        txtBoxLength_Conv.Text = txtBoxLength.Text;
                        txtBoxWidth_Conv.Text = txtBoxWidth.Text;
                        txtBoxHeight_Conv.Text = txtBoxHeight.Text;

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 2.54;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 2.54;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 2.54;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 10) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "3")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 0.3);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 0.3);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 0.5);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 2.54;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 2.54;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 2.54;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 30) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "5")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 0.5);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 0.5);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 0.8);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 2.54;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 2.54;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 2.54;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 40) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "7")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 0.5);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 0.5);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 0.8);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 2.54;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 2.54;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 2.54;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "9")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 0.5);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 0.5);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 1);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 2.54;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 2.54;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 2.54;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "11")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 0.7);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 0.7);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 1.2);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 2.54;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 2.54;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 2.54;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "13" || ddlPly_Sheet.SelectedValue == "15")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 1.0);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 1.0);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 1.5);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 2.54;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 2.54;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 2.54;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else
                    {
                        txtBoxLength_Conv.Text = txtBoxLength.Text;
                        txtBoxWidth_Conv.Text = txtBoxWidth.Text;
                        txtBoxHeight_Conv.Text = txtBoxHeight.Text;

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 2.54;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 2.54;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 2.54;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 10) / 25.4, 2));

                    }
                    ChkBoxConvOutside.Enabled = false;
                    ddlEF_NF_PC.Focus();
                }
                else if (cmbUnits.SelectedItem == "MM")
                {
                    if (ddlPly_Sheet.SelectedValue == "1" || ddlPly_Sheet.SelectedValue == "2")
                    {
                        txtBoxLength_Conv.Text = txtBoxLength.Text;
                        txtBoxWidth_Conv.Text = txtBoxWidth.Text;
                        txtBoxHeight_Conv.Text = txtBoxHeight.Text;

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 25.4;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 25.4;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 25.4;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 10) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "3")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 3);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 3);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 5);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 25.4;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 25.4;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 25.4;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 30) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "5")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 5);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 5);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 8);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 25.4;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 25.4;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 25.4;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 40) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "7")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 5);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 5);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 8);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 25.4;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 25.4;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 25.4;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "9")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 5);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 5);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 10);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 25.4;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 25.4;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 25.4;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "11")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 7);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 7);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 12);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 25.4;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 25.4;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 25.4;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else if (ddlPly_Sheet.SelectedValue == "13" || ddlPly_Sheet.SelectedValue == "15")
                    {
                        txtBoxLength_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxLength.Text) + 10);
                        txtBoxWidth_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxWidth.Text) + 10);
                        txtBoxHeight_Conv.Text = Convert.ToString(Convert.ToDouble(txtBoxHeight.Text) + 15);

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 25.4;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 25.4;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 25.4;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));

                    }
                    else
                    {
                        txtBoxLength_Conv.Text = txtBoxLength.Text;
                        txtBoxWidth_Conv.Text = txtBoxWidth.Text;
                        txtBoxHeight_Conv.Text = txtBoxHeight.Text;

                        double boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 25.4;
                        double boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 25.4;
                        double boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 25.4;

                        //Calculation for Deckle
                        txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                        //Calculation for Cutting Size
                        txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 10) / 25.4, 2));

                    }
                    ChkBoxConvOutside.Enabled = false;
                    ddlEF_NF_PC.Focus();
                }
            }
            else
            {
                txtBoxLength_Conv.Text = "0.00";
                txtBoxWidth_Conv.Text = "0.00";
                txtBoxHeight_Conv.Text = "0.00";
                ChkBoxConvOutside.Enabled = true;
            }





            #region OLD CODE
            //if (chkBoxConvInside.Checked == true)
            //{
            //    if (ddlPly_Sheet.SelectedValue == "1" || ddlPly_Sheet.SelectedValue == "2")
            //    {
            //        txtLength_MM_Conv.Text = txtLength_MM.Text;
            //        txtWidth_MM_Conv.Text = txtWidth_MM.Text;
            //        txtHeight_MM_Conv.Text = txtHeight_MM.Text;
            //    }
            //    else if (ddlPly_Sheet.SelectedValue == "3")
            //    {
            //        txtLength_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtLength_MM.Text) + 3);
            //        txtWidth_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtWidth_MM.Text) + 3);
            //        txtHeight_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtHeight_MM.Text) + 5);
            //    }
            //    else if (ddlPly_Sheet.SelectedValue == "5" || ddlPly_Sheet.SelectedValue == "7")
            //    {
            //        txtLength_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtLength_MM.Text) + 5);
            //        txtWidth_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtWidth_MM.Text) + 5);
            //        txtHeight_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtHeight_MM.Text) + 8);
            //    }
            //    else if (ddlPly_Sheet.SelectedValue == "9")
            //    {
            //        txtLength_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtLength_MM.Text) + 5);
            //        txtWidth_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtWidth_MM.Text) + 5);
            //        txtHeight_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtHeight_MM.Text) + 10);
            //    }
            //    else if (ddlPly_Sheet.SelectedValue == "11")
            //    {
            //        txtLength_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtLength_MM.Text) + 7);
            //        txtWidth_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtWidth_MM.Text) + 7);
            //        txtHeight_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtHeight_MM.Text) + 12);
            //    }
            //    else if (ddlPly_Sheet.SelectedValue == "13" || ddlPly_Sheet.SelectedValue == "15")
            //    {
            //        txtLength_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtLength_MM.Text) + 10);
            //        txtWidth_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtWidth_MM.Text) + 10);
            //        txtHeight_MM_Conv.Text = Convert.ToString(Convert.ToDouble(txtHeight_MM.Text) + 15);
            //    }
            //    else
            //    {
            //        txtLength_MM_Conv.Text = txtLength_MM.Text;
            //        txtWidth_MM_Conv.Text = txtWidth_MM.Text;
            //        txtHeight_MM_Conv.Text = txtHeight_MM.Text;
            //    }
            //    ChkBoxConvOutside.Enabled = false;
            //}
            //else
            //{
            //    txtLength_MM_Conv.Text = "0.00";
            //    txtWidth_MM_Conv.Text = "0.00";
            //    txtHeight_MM_Conv.Text = "0.00";
            //    ChkBoxConvOutside.Enabled = true;
            //} 
            #endregion
        }

        private void ChkBoxConvOutside_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBoxConvOutside.Checked == true)
            {
                txtBoxLength_Conv.Text = txtBoxLength.Text;
                txtBoxWidth_Conv.Text = txtBoxWidth.Text;
                txtBoxHeight_Conv.Text = txtBoxHeight.Text;
                chkBoxConvInside.Enabled = false;

                double boxLengthInch = 0.00, boxWidthInch = 0.00, boxHeightInch = 0.00;

                if (cmbUnits.SelectedText == "Inch")
                {
                    boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text);
                    boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text);
                    boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text);
                }
                else if (cmbUnits.SelectedText == "CM")
                {
                    boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 2.54;
                    boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 2.54;
                    boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 2.54;
                }
                else if (cmbUnits.SelectedText == "MM")
                {
                    boxLengthInch = Convert.ToDouble(txtBoxLength_Conv.Text) / 25.4;
                    boxWidthInch = Convert.ToDouble(txtBoxWidth_Conv.Text) / 25.4;
                    boxHeightInch = Convert.ToDouble(txtBoxHeight_Conv.Text) / 25.4;
                }
                if (ddlPly_Sheet.SelectedValue == "1" || ddlPly_Sheet.SelectedValue == "2")
                {
                    //Calculation for Deckle
                    txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                    //Calculation for Cutting Size
                    txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 10) / 25.4, 2));
                }
                else if (ddlPly_Sheet.SelectedValue == "3")
                {
                    //Calculation for Deckle
                    txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                    //Calculation for Cutting Size
                    txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 30) / 25.4, 2));
                }
                else if (ddlPly_Sheet.SelectedValue == "5")
                {
                    //Calculation for Deckle
                    txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                    //Calculation for Cutting Size
                    txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 40) / 25.4, 2));
                }
                else if (ddlPly_Sheet.SelectedValue == "7" || ddlPly_Sheet.SelectedValue == "9" || ddlPly_Sheet.SelectedValue == "11" || ddlPly_Sheet.SelectedValue == "13" || ddlPly_Sheet.SelectedValue == "15")
                {
                    //Calculation for Deckle
                    txtLength_Inch_Sheet.Text = Convert.ToString(Math.Round(boxWidthInch + boxHeightInch, 2));

                    //Calculation for Cutting Size
                    txtWidth_Inch_Sheet.Text = Convert.ToString(Math.Round((boxLengthInch + boxWidthInch + boxLengthInch + boxWidthInch + 50) / 25.4, 2));
                }
                ddlEF_NF_PC.Focus();
            }
            else
            {
                txtBoxLength_Conv.Text = "0.00";
                txtBoxWidth_Conv.Text = "0.00";
                txtBoxHeight_Conv.Text = "0.00";
                txtLength_Inch_Sheet.Text = "0.00";
                txtWidth_Inch_Sheet.Text = "0.00";
                chkBoxConvInside.Enabled = true;
                ddlEF_NF_PC.Focus();
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlDimn_Opt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (ddlDimn_Opt.Text == "Outer")
            //{
            //    if (ddlPly_Sheet.Text == "3")
            //    {
            //        double LengthConv = (Inch1 + 3);
            //        txtBoxLength_Conv.Text = LengthConv.ToString();

            //        double WidthConv = (Inch2 + 3);
            //        txtBoxWidth_Conv.Text = WidthConv.ToString();

            //        double HightConv = (Inch3 + 5);
            //        txtBoxHeight_Conv.Text = HightConv.ToString();

            //        LenInchsheet = (Inch2 + Inch3 + 5) / 25.4;
            //        txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet.Enabled = false;
            //        LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);

            //        WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 30) / 25.4;
            //        txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet.Enabled = false;
            //        WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);
            //    }
            //    if (ddlPly_Sheet.Text == "5")
            //    {
            //        double LengthConv1 = (Inch1 + 5);
            //        txtBoxLength_Conv.Text = LengthConv1.ToString();
            //        double WidthConv1 = (Inch2 + 5);
            //        txtBoxWidth_Conv.Text = WidthConv1.ToString();
            //        double HightConv1 = (Inch3 + 8);
            //        txtBoxHeight_Conv.Text = HightConv1.ToString();
            //        LenInchsheet = (Inch2 + Inch3 + 7) / 25.4;
            //        txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet.Enabled = false;
            //        LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);
            //        WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 40) / 25.4;
            //        txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet.Enabled = false;
            //        WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);
            //    }
            //    if (ddlPly_Sheet.Text == "7")
            //    {
            //        double LengthConv2 = (Inch1 + 5);
            //        txtBoxLength_Conv.Text = LengthConv2.ToString();
            //        double WidthConv2 = (Inch2 + 5);
            //        txtBoxWidth_Conv.Text = WidthConv2.ToString();
            //        double HightConv2 = (Inch3 + 10);
            //        txtBoxHeight_Conv.Text = HightConv2.ToString();
            //        LenInchsheet = (Inch2 + Inch3 + 10) / 25.4;
            //        txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet.Enabled = false;
            //        LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);
            //        WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
            //        txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet.Enabled = false;
            //        WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);
            //    }

            //    if (ddlPly_Sheet.Text == "9")
            //    {
            //        double LengthConv3 = (Inch1 + 7);
            //        txtBoxLength_Conv.Text = LengthConv3.ToString();
            //        double WidthConv3 = (Inch2 + 7);
            //        txtBoxWidth_Conv.Text = WidthConv3.ToString();
            //        double HightConv3 = (Inch3 + 12);
            //        txtBoxHeight_Conv.Text = HightConv3.ToString();
            //        LenInchsheet = (Inch2 + Inch3 + 13) / 25.4;
            //        txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet.Enabled = false;
            //        LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);
            //        WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
            //        txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet.Enabled = false;
            //        WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);
            //    }
            //    if (ddlPly_Sheet.Text == "11")
            //    {
            //        double LengthConv4 = (Inch1 + 9);
            //        txtBoxLength_Conv.Text = LengthConv4.ToString();
            //        double WidthConv4 = (Inch2 + 9);
            //        txtBoxWidth_Conv.Text = WidthConv4.ToString();
            //        double HightConv4 = (Inch3 + 15);
            //        txtBoxHeight_Conv.Text = HightConv4.ToString();
            //        LenInchsheet = (Inch2 + Inch3 + 15) / 25.4;
            //        txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet.Enabled = false;
            //        LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);
            //        WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
            //        txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet.Enabled = false;
            //        WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);
            //    }
            //}

            //if (ddlDimn_Opt.Text == "Inner")
            //{
            //    if (ddlPly_Sheet.Text == "3")
            //    {
            //        double LengthConv = (Inch1 - 3);
            //        txtBoxLength_Conv.Text = LengthConv.ToString();
            //        double WidthConv = (Inch2 - 3);
            //        txtBoxWidth_Conv.Text = WidthConv.ToString();
            //        double HightConv = (Inch3 - 5);
            //        txtBoxHeight_Conv.Text = HightConv.ToString();
            //        LenInchsheet = (Inch2 + Inch3 + 5) / 25.4;
            //        txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet.Enabled = false;
            //        LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);
            //        WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 30) / 25.4;
            //        txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet.Enabled = false;
            //        WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);
            //    }
            //    if (ddlPly_Sheet.Text == "5")
            //    {
            //        double LengthConv1 = (Inch1 - 5);
            //        txtBoxLength_Conv.Text = LengthConv1.ToString();
            //        double WidthConv1 = (Inch2 - 5);
            //        txtBoxWidth_Conv.Text = WidthConv1.ToString();
            //        double HightConv1 = (Inch3 - 8);
            //        txtBoxHeight_Conv.Text = HightConv1.ToString();
            //        LenInchsheet = (Inch2 + Inch3 + 7) / 25.4;
            //        txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet.Enabled = false;
            //        LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);
            //        WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 40) / 25.4;
            //        txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet.Enabled = false;
            //        WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);
            //    }
            //    if (ddlPly_Sheet.Text == "7")
            //    {
            //        double LengthConv2 = (Inch1 - 5);
            //        txtBoxLength_Conv.Text = LengthConv2.ToString();
            //        double WidthConv2 = (Inch2 - 5);
            //        txtBoxWidth_Conv.Text = WidthConv2.ToString();
            //        double HightConv2 = (Inch3 - 10);
            //        txtBoxHeight_Conv.Text = HightConv2.ToString();
            //        LenInchsheet = (Inch2 + Inch3 + 10) / 25.4;
            //        txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet.Enabled = false;
            //        LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);
            //        WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
            //        txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet.Enabled = false;
            //        WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);
            //    }
            //    if (ddlPly_Sheet.Text == "9")
            //    {
            //        double LengthConv3 = (Inch1 - 7);
            //        txtBoxLength_Conv.Text = LengthConv3.ToString();
            //        double WidthConv3 = (Inch2 - 7);
            //        txtBoxWidth_Conv.Text = WidthConv3.ToString();
            //        double HightConv3 = (Inch3 - 12);
            //        txtBoxHeight_Conv.Text = HightConv3.ToString();
            //        LenInchsheet = (Inch2 + Inch3 + 13) / 25.4;
            //        txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet.Enabled = false;
            //        LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);
            //        WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
            //        txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet.Enabled = false;
            //        WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);
            //    }
            //    if (ddlPly_Sheet.Text == "11")
            //    {
            //        double LengthConv4 = (Inch1 - 9);
            //        txtBoxLength_Conv.Text = LengthConv4.ToString();
            //        double WidthConv4 = (Inch2 - 9);
            //        txtBoxWidth_Conv.Text = WidthConv4.ToString();
            //        double HightConv4 = (Inch3 - 15);
            //        txtBoxHeight_Conv.Text = HightConv4.ToString();
            //        LenInchsheet = (Inch2 + Inch3 + 15) / 25.4;
            //        txtLength_Inch_Sheet.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet1.Text = LenInchsheet.ToString();
            //        txtLength_Inch_Sheet.Enabled = false;
            //        LenInchsheet1 = Convert.ToDouble(txtLength_Inch_Sheet1.Text);
            //        WidInchsheet = (Inch1 + Inch2 + Inch1 + Inch2 + 50) / 25.4;
            //        txtWidth_Inch_Sheet.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet1.Text = WidInchsheet.ToString();
            //        txtWidth_Inch_Sheet.Enabled = false;
            //        WidInchsheet1 = Convert.ToDouble(txtWidth_Inch_Sheet1.Text);
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlEF_NF_PC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtBundle_Packet.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBundle_Packet_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBundle_Packet_Leave(object sender, EventArgs e)
        {
            txtBox_PerSheet.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_PerSheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_PerSheet_Leave(object sender, EventArgs e)
        {
            ddlCorrugation_Opt.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCorrugation_Opt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ddlPaper_Cutting.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlPaper_Cutting_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ddlPrinting_Opt.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlPrinting_Opt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ddlPrinting_Opt.SelectedValue == "Yes")
            {
                txtNo_Colors.Enabled = true;
                txtPrntColor_Name.Enabled = true;

                txtNo_Colors.Focus();
            }
            else
            {
                txtNo_Colors.Enabled = false;
                txtPrntColor_Name.Enabled = false;

                txtNo_Colors.Text = "";
                txtPrntColor_Name.Text = "";

                ddlPaper_Printed.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNo_Colors_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNo_Colors_Leave(object sender, EventArgs e)
        {
            txtPrntColor_Name.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrntColor_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrntColor_Name_Leave(object sender, EventArgs e)
        {
            ddlPaper_Printed.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlPaper_Printed_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ddlPaper_Printed.SelectedValue.ToString() == "Yes")
            {
                ddlTP_ID.Enabled = true;
                if (ddlTP_ID.Text == "")
                {
                    //MessageBox.Show("Please Select TP_ID");
                    ddlTP_ID.Focus();
                }
            }
            else if (ddlPaper_Printed.SelectedValue.ToString() == "No")
            {
                ddlTP_ID.Enabled = false;
                if (txtTopBF.Visible == true)
                {
                    txtTopBF.Enabled = true;
                    txtTopGSM.Enabled = true;
                    txtTopWtPerPpr.Enabled = true;
                    txtTopBfPerPpr.Enabled = true;
                }
                if (txt3BackingBF.Visible == true)
                {
                    txt3BackingBF.Enabled = true;
                    txt3BackingGSM.Enabled = true;
                    txt3BackingWtPerPpr.Enabled = true;
                    txt3BackingBFPerPpr.Enabled = true;

                    txt3FluteBF.Enabled = true;
                    txt3FluteGSM.Enabled = true;
                    txt3FluteWtPerPpr.Enabled = true;
                    Txt3FluteBFPrPPr.Enabled = true;
                }
                else
                {
                    txt3BackingBF.Enabled = false;
                    txt3BackingGSM.Enabled = false;
                    txt3BackingWtPerPpr.Enabled = false;
                    txt3BackingBFPerPpr.Enabled = false;

                    txt3FluteBF.Enabled = false;
                    txt3FluteGSM.Enabled = false;
                    txt3FluteWtPerPpr.Enabled = false;
                    Txt3FluteBFPrPPr.Enabled = false;
                }
                if (txt5BackBF.Visible == true)
                {
                    txt5BackBF.Enabled = true;
                    txt5BackGSM.Enabled = true;
                    txt5BackWtPrPpr.Enabled = true;
                    txt5BackBFPrPpr.Enabled = true;

                    txt5FluteBF.Enabled = true;
                    txt5FluteGSM.Enabled = true;
                    txt5FluteWtPrPpr.Enabled = true;
                    txt5FluteBFPrPpr.Enabled = true;
                }
                else
                {
                    txt5BackBF.Enabled = false;
                    txt5BackGSM.Enabled = false;
                    txt5BackWtPrPpr.Enabled = false;
                    txt5BackBFPrPpr.Enabled = false;

                    txt5FluteBF.Enabled = false;
                    txt5FluteGSM.Enabled = false;
                    txt5FluteWtPrPpr.Enabled = false;
                    txt5FluteBFPrPpr.Enabled = false;
                }
                if (txt7BackBF.Visible == true)
                {
                    txt7BackBF.Enabled = true;
                    txt7BackGSM.Enabled = true;
                    txt7BackWtPrPpr.Enabled = true;
                    txt7BackBFPrppr.Enabled = true;

                    txt7FluteBF.Enabled = true;
                    txt7FluteGSM.Enabled = true;
                    txt7FluteWtPerPpr.Enabled = true;
                    txt7FluteBFPrPpr.Enabled = true;
                }
                else
                {
                    txt7BackBF.Enabled = false;
                    txt7BackGSM.Enabled = false;
                    txt7BackWtPrPpr.Enabled = false;
                    txt7BackBFPrppr.Enabled = false;

                    txt7FluteBF.Enabled = false;
                    txt7FluteGSM.Enabled = false;
                    txt7FluteWtPerPpr.Enabled = false;
                    txt7FluteBFPrPpr.Enabled = false;
                }
                if (txt9BackBF.Visible == true)
                {
                    txt9BackBF.Enabled = true;
                    txt9BackGSM.Enabled = true;
                    txt9BackWtPrPpr.Enabled = true;
                    txt9BackBFPrPpr.Enabled = true;

                    txt9FluteBF.Enabled = true;
                    txt9FluteGSM.Enabled = true;
                    txt9FluteWtPrPpr.Enabled = true;
                    txt9FluteBFPrPpr.Enabled = true;
                }
                else
                {
                    txt9BackBF.Enabled = false;
                    txt9BackGSM.Enabled = false;
                    txt9BackWtPrPpr.Enabled = false;
                    txt9BackBFPrPpr.Enabled = false;

                    txt9FluteBF.Enabled = false;
                    txt9FluteGSM.Enabled = false;
                    txt9FluteWtPrPpr.Enabled = false;
                    txt9FluteBFPrPpr.Enabled = false;
                }
                if (txt11BackBF.Visible == true)
                {
                    txt11BackBF.Enabled = true;
                    txt11BackGSM.Enabled = true;
                    txt11BackWtPrPpr.Enabled = true;
                    txt11BackBFPrPpr.Enabled = true;

                    txt11FluteBF.Enabled = true;
                    txt11FluteGSM.Enabled = true;
                    txt11FluteWtPrPpr.Enabled = true;
                    txt11FluteBFPrPpr.Enabled = true;
                }
                else
                {
                    txt11BackBF.Enabled = false;
                    txt11BackGSM.Enabled = false;
                    txt11BackWtPrPpr.Enabled = false;
                    txt11BackBFPrPpr.Enabled = false;

                    txt11FluteBF.Enabled = false;
                    txt11FluteGSM.Enabled = false;
                    txt11FluteWtPrPpr.Enabled = false;
                    txt11FluteBFPrPpr.Enabled = false;
                }
                if (txt13BackBF.Visible == true)
                {
                    txt13BackBF.Enabled = true;
                    txt13BackGSM.Enabled = true;
                    txt13BackWtPrPpr.Enabled = true;
                    txt13BackBFPrPpr.Enabled = true;

                    txt13FluteBF.Enabled = true;
                    txt13FluteGSM.Enabled = true;
                    txt13FluteWtPrPpr.Enabled = true;
                    txt13FluteBFPrPpr.Enabled = true;
                }
                else
                {
                    txt13BackBF.Enabled = false;
                    txt13BackGSM.Enabled = false;
                    txt13BackWtPrPpr.Enabled = false;
                    txt13BackBFPrPpr.Enabled = false;

                    txt13FluteBF.Enabled = false;
                    txt13FluteGSM.Enabled = false;
                    txt13FluteWtPrPpr.Enabled = false;
                    txt13FluteBFPrPpr.Enabled = false;
                }
                if (txt15BackBF.Visible == true)
                {
                    txt15BackBF.Enabled = true;
                    txt15BackGSM.Enabled = true;
                    txt15BackWtPrPpr.Enabled = true;
                    txt15BackBFPrPpr.Enabled = true;

                    txt15FluteBF.Enabled = true;
                    txt15FluteGSM.Enabled = true;
                    txt15FluteWtPrPpr.Enabled = true;
                    txt15FluteBFPrPpr.Enabled = true;
                }
                else
                {
                    txt15BackBF.Enabled = false;
                    txt15BackGSM.Enabled = false;
                    txt15BackWtPrPpr.Enabled = false;
                    txt15BackBFPrPpr.Enabled = false;

                    txt15FluteBF.Enabled = false;
                    txt15FluteGSM.Enabled = false;
                    txt15FluteWtPrPpr.Enabled = false;
                    txt15FluteBFPrPpr.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlTP_ID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                // ddlTP_ID.Text = "";
                string TPPBF = string.Empty, TPGsm = string.Empty;
                double dblTPPBF = 0.00, dblTPGSM = 0.00;
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con2 = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("select TP_PPBf,TP_PPGram from TopPaper_Master where TP_ID='" + ddlTP_ID.SelectedValue.ToString() + "'", con2);
                con2.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    TPPBF = Convert.ToString(dr["TP_PPBf"]);
                    TPGsm = Convert.ToString(dr["TP_PPGram"]);
                    if (string.IsNullOrEmpty(TPPBF))
                    {
                        TPPBF = "0";
                    }
                    if (string.IsNullOrEmpty(TPGsm))
                    {
                        TPGsm = "0";
                    }

                    dblTPPBF = Math.Round(Convert.ToDouble(TPPBF), 2);
                    dblTPGSM = Math.Round(Convert.ToDouble(TPGsm), 2);

                    //strTPPBF = Convert.ToDouble(TPPBF);
                    ////  strTPPBF = Convert.ToDouble(dr["TP_PPBf"]);
                    //txtTop_BF.Text = strTPPBF.ToString();
                    //txtTop_BF3.Text = strTPPBF.ToString();
                    //txtTop_BF5.Text = strTPPBF.ToString();
                    //txtTop_BF9.Text = strTPPBF.ToString();
                    //txtTop_BF11.Text = strTPPBF.ToString();
                }
                con2.Close();
                dr.Close();

                //funclib = new FunctionLib();
                //string strcon1 = funclib.setConnection();
                //SqlConnection con3 = new SqlConnection(strcon1);
                //SqlCommand cmd1 = new SqlCommand("select TP_PPGram from TopPaper_Master where TP_ID='" + ddlTP_ID.SelectedValue.ToString() + "'", con3);
                //con3.Open();
                //SqlDataReader dr1 = cmd1.ExecuteReader();
                //if (dr1.Read())
                //{
                //    TPGsm = Convert.ToString(dr1["TP_PPGram"]);
                //    if (TPGsm == "")
                //    {
                //        TPGsm = "0";
                //    }

                #region OLD CODE
                //    //strTPGsm = Convert.ToDouble(TPGsm);
                //    ////strTPGsm = Convert.ToDouble(dr1["TP_PPGram"]);
                //    //txtTop_GSM.Text = strTPGsm.ToString();
                //    //txtTop_GSM3.Text = strTPGsm.ToString();
                //    //txtTop_GSM5.Text = strTPGsm.ToString();
                //    //txtTop_GSM9.Text = strTPGsm.ToString();
                //    //txtTop_GSM11.Text = strTPGsm.ToString();

                //    //txtTopGSM.Text = strTPGsm.ToString();
                //    //txt3BackingGSM.Text = strTPGsm.ToString();
                //    //txt3FluteGSM.Text = strTPGsm.ToString();
                //    //txt5BackGSM.Text = strTPGsm.ToString();
                //    //txt5FluteGSM.Text = strTPGsm.ToString();
                //    //txt7BackGSM.Text = strTPGsm.ToString();
                //    //txt7FluteGSM.Text = strTPGsm.ToString();
                //    //txt9BackGSM.Text = strTPGsm.ToString();
                //    //txt9FluteGSM.Text = strTPGsm.ToString();
                //    //txt11BackGSM.Text = strTPGsm.ToString();
                //    //txt11FluteGSM.Text = strTPGsm.ToString();
                //    //txt13BackGSM.Text = strTPGsm.ToString();
                //    //txt13FluteGSM.Text = strTPGsm.ToString(); 
                #endregion

                //}
                //con2.Close();
                //dr.Close();

                double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
                double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

                //For One and Two Ply
                if (ddlPly_Sheet.Text == "1" || ddlPly_Sheet.Text == "2")
                {
                    //double Gsm3 = Convert.ToDouble(TPGsm);
                    //double TopBF3 = Convert.ToDouble(TPPBF);
                    //double TopWpp3 = ((LenInchsheet1 * WidInchsheet1) * Gsm3 / 1550) / 1000;
                    //txtTopWtPerPpr.Text = TopWpp3.ToString();
                    //double TopBFPP3 = ((TopBF3 * Gsm3) / 1000);
                    //txtTopBfPerPpr.Text = TopBFPP3.ToString();

                    txtTopBF.Text = TPPBF;
                    txtTopGSM.Text = TPGsm;
                    txtTopWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txtTopBfPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txtWeight_Pcs.Text = txtTopWtPerPpr.Text;
                    txtBF_Pcs.Text = txtTopBfPerPpr.Text;



                    txtTopBF.Enabled = false;
                    txtTopGSM.Enabled = false;
                    txtTopWtPerPpr.Enabled = false;
                    txtTopBfPerPpr.Enabled = false;

                }

                //For ThreePly
                if (ddlPly_Sheet.Text == "3")
                {
                    //double Gsm3 = Convert.ToDouble(TPGsm);
                    //double TopBF3 = Convert.ToDouble(TPPBF);
                    //double TopWpp3 = ((LenInchsheet1 * WidInchsheet1) * Gsm3 / 1550) / 1000;
                    //txtTopWtPerPpr.Text = TopWpp3.ToString();
                    //double TopBFPP3 = ((TopBF3 * Gsm3) / 1000);
                    //txtTopBfPerPpr.Text = TopBFPP3.ToString();

                    txtTopBF.Text = TPPBF;
                    txtTopGSM.Text = TPGsm;
                    txtTopWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txtTopBfPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txtTopBF.Enabled = false;
                    txtTopGSM.Enabled = false;
                    txtTopWtPerPpr.Enabled = false;
                    txtTopBfPerPpr.Enabled = false;

                    txt3BackingBF.Text = TPPBF;
                    txt3BackingGSM.Text = TPGsm;
                    txt3BackingWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt3BackingBFPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt3BackingBF.Enabled = false;
                    txt3BackingGSM.Enabled = false;
                    txt3BackingWtPerPpr.Enabled = false;
                    txt3BackingBFPerPpr.Enabled = false;

                    txt3FluteBF.Text = TPPBF;
                    txt3FluteGSM.Text = TPGsm;
                    txt3FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    Txt3FluteBFPrPPr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt3FluteBF.Enabled = false;
                    txt3FluteGSM.Enabled = false;
                    txt3FluteWtPerPpr.Enabled = false;
                    Txt3FluteBFPrPPr.Enabled = false;

                    txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text), 2));
                    txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text), 2));

                }

                //For FivePly
                if (ddlPly_Sheet.Text == "5")
                {
                    //double Gsm5 = Convert.ToDouble(TPGsm);
                    //double TopBF5 = Convert.ToDouble(TPPBF);
                    //double TopWpp5 = ((LenInchsheet1 * WidInchsheet1) * Gsm5 / 1550) / 1000;
                    //txtTopWtPerPpr.Text = TopWpp5.ToString();
                    //double TopBFPP5 = ((TopBF5 * Gsm5) / 1000);
                    //txtTopBfPerPpr.Text = TopBFPP5.ToString();

                    txtTopBF.Text = TPPBF;
                    txtTopGSM.Text = TPGsm;
                    txtTopWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txtTopBfPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txtTopBF.Enabled = false;
                    txtTopGSM.Enabled = false;
                    txtTopWtPerPpr.Enabled = false;
                    txtTopBfPerPpr.Enabled = false;

                    txt3BackingBF.Text = TPPBF;
                    txt3BackingGSM.Text = TPGsm;
                    txt3BackingWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt3BackingBFPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt3BackingBF.Enabled = false;
                    txt3BackingGSM.Enabled = false;
                    txt3BackingWtPerPpr.Enabled = false;
                    txt3BackingBFPerPpr.Enabled = false;

                    txt3FluteBF.Text = TPPBF;
                    txt3FluteGSM.Text = TPGsm;
                    txt3FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    Txt3FluteBFPrPPr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt3FluteBF.Enabled = false;
                    txt3FluteGSM.Enabled = false;
                    txt3FluteWtPerPpr.Enabled = false;
                    Txt3FluteBFPrPPr.Enabled = false;

                    txt5BackBF.Text = TPPBF;
                    txt5BackGSM.Text = TPGsm;
                    txt5BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt5BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt5BackBF.Enabled = false;
                    txt5BackGSM.Enabled = false;
                    txt5BackWtPrPpr.Enabled = false;
                    txt5BackBFPrPpr.Enabled = false;

                    txt5FluteBF.Text = TPPBF;
                    txt5FluteGSM.Text = TPGsm;
                    txt5FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt5FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt5FluteBF.Enabled = false;
                    txt5FluteGSM.Enabled = false;
                    txt5FluteWtPrPpr.Enabled = false;
                    txt5FluteBFPrPpr.Enabled = false;

                    txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text), 2));
                    txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text), 2));

                }

                //For SevenPly
                if (ddlPly_Sheet.Text == "7")
                {
                    //double Gsm = Convert.ToDouble(TPGsm);
                    //double TopBF = Convert.ToDouble(TPPBF);
                    //double TopWpp = ((LenInchsheet1 * WidInchsheet1) * Gsm / 1550) / 1000;
                    //txtTopWtPerPpr.Text = TopWpp.ToString();
                    //double TopBFPP = ((TopBF * Gsm) / 1000);
                    //txtTopBfPerPpr.Text = TopBFPP.ToString();

                    txtTopBF.Text = TPPBF;
                    txtTopGSM.Text = TPGsm;
                    txtTopWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txtTopBfPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txtTopBF.Enabled = false;
                    txtTopGSM.Enabled = false;
                    txtTopWtPerPpr.Enabled = false;
                    txtTopBfPerPpr.Enabled = false;

                    txt3BackingBF.Text = TPPBF;
                    txt3BackingGSM.Text = TPGsm;
                    txt3BackingWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt3BackingBFPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt3BackingBF.Enabled = false;
                    txt3BackingGSM.Enabled = false;
                    txt3BackingWtPerPpr.Enabled = false;
                    txt3BackingBFPerPpr.Enabled = false;

                    txt3FluteBF.Text = TPPBF;
                    txt3FluteGSM.Text = TPGsm;
                    txt3FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    Txt3FluteBFPrPPr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt3FluteBF.Enabled = false;
                    txt3FluteGSM.Enabled = false;
                    txt3FluteWtPerPpr.Enabled = false;
                    Txt3FluteBFPrPPr.Enabled = false;

                    txt5BackBF.Text = TPPBF;
                    txt5BackGSM.Text = TPGsm;
                    txt5BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt5BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt5BackBF.Enabled = false;
                    txt5BackGSM.Enabled = false;
                    txt5BackWtPrPpr.Enabled = false;
                    txt5BackBFPrPpr.Enabled = false;

                    txt5FluteBF.Text = TPPBF;
                    txt5FluteGSM.Text = TPGsm;
                    txt5FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt5FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt5FluteBF.Enabled = false;
                    txt5FluteGSM.Enabled = false;
                    txt5FluteWtPrPpr.Enabled = false;
                    txt5FluteBFPrPpr.Enabled = false;

                    txt7BackBF.Text = TPPBF;
                    txt7BackGSM.Text = TPGsm;
                    txt7BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt7BackBFPrppr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt7BackBF.Enabled = false;
                    txt7BackGSM.Enabled = false;
                    txt7BackWtPrPpr.Enabled = false;
                    txt7BackBFPrppr.Enabled = false;

                    txt7FluteBF.Text = TPPBF;
                    txt7FluteGSM.Text = TPGsm;
                    txt7FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt7FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt7FluteBF.Enabled = false;
                    txt7FluteGSM.Enabled = false;
                    txt7FluteWtPerPpr.Enabled = false;
                    txt7FluteBFPrPpr.Enabled = false;

                    txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text), 2));
                    txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text), 2));
                }

                //For NinePly
                if (ddlPly_Sheet.Text == "9")
                {
                    //double Gsm9 = Convert.ToDouble(TPGsm);
                    //double TopBF9 = Convert.ToDouble(TPPBF);
                    //double TopWpp9 = ((LenInchsheet1 * WidInchsheet1) * Gsm9 / 1550) / 1000;
                    //txtTopWtPerPpr.Text = TopWpp9.ToString();
                    //double TopBFPP9 = ((TopBF9 * Gsm9) / 1000);
                    //txtTopBfPerPpr.Text = TopBFPP9.ToString();

                    txtTopBF.Text = TPPBF;
                    txtTopGSM.Text = TPGsm;
                    txtTopWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txtTopBfPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txtTopBF.Enabled = false;
                    txtTopGSM.Enabled = false;
                    txtTopWtPerPpr.Enabled = false;
                    txtTopBfPerPpr.Enabled = false;

                    txt3BackingBF.Text = TPPBF;
                    txt3BackingGSM.Text = TPGsm;
                    txt3BackingWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt3BackingBFPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt3BackingBF.Enabled = false;
                    txt3BackingGSM.Enabled = false;
                    txt3BackingWtPerPpr.Enabled = false;
                    txt3BackingBFPerPpr.Enabled = false;

                    txt3FluteBF.Text = TPPBF;
                    txt3FluteGSM.Text = TPGsm;
                    txt3FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    Txt3FluteBFPrPPr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt3FluteBF.Enabled = false;
                    txt3FluteGSM.Enabled = false;
                    txt3FluteWtPerPpr.Enabled = false;
                    Txt3FluteBFPrPPr.Enabled = false;

                    txt5BackBF.Text = TPPBF;
                    txt5BackGSM.Text = TPGsm;
                    txt5BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt5BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt5BackBF.Enabled = false;
                    txt5BackGSM.Enabled = false;
                    txt5BackWtPrPpr.Enabled = false;
                    txt5BackBFPrPpr.Enabled = false;

                    txt5FluteBF.Text = TPPBF;
                    txt5FluteGSM.Text = TPGsm;
                    txt5FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt5FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt5FluteBF.Enabled = false;
                    txt5FluteGSM.Enabled = false;
                    txt5FluteWtPrPpr.Enabled = false;
                    txt5FluteBFPrPpr.Enabled = false;

                    txt7BackBF.Text = TPPBF;
                    txt7BackGSM.Text = TPGsm;
                    txt7BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt7BackBFPrppr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt7BackBF.Enabled = false;
                    txt7BackGSM.Enabled = false;
                    txt7BackWtPrPpr.Enabled = false;
                    txt7BackBFPrppr.Enabled = false;

                    txt7FluteBF.Text = TPPBF;
                    txt7FluteGSM.Text = TPGsm;
                    txt7FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt7FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt7FluteBF.Enabled = false;
                    txt7FluteGSM.Enabled = false;
                    txt7FluteWtPerPpr.Enabled = false;
                    txt7FluteBFPrPpr.Enabled = false;

                    txt9BackBF.Text = TPPBF;
                    txt9BackGSM.Text = TPGsm;
                    txt9BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt9BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt9BackBF.Enabled = false;
                    txt9BackGSM.Enabled = false;
                    txt9BackWtPrPpr.Enabled = false;
                    txt9BackBFPrPpr.Enabled = false;

                    txt9FluteBF.Text = TPPBF;
                    txt9FluteGSM.Text = TPGsm;
                    txt9FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt9FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt9FluteBF.Enabled = false;
                    txt9FluteGSM.Enabled = false;
                    txt9FluteWtPrPpr.Enabled = false;
                    txt9FluteBFPrPpr.Enabled = false;

                    txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text) + Convert.ToDouble(txt9FluteWtPrPpr.Text), 2));
                    txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text), 2));

                }

                //For ElevenPly
                if (ddlPly_Sheet.Text == "11")
                {
                    //double Gsm11 = Convert.ToDouble(TPGsm);
                    //double TopBF11 = Convert.ToDouble(TPPBF);
                    //double TopWpp11 = ((LenInchsheet1 * WidInchsheet1) * Gsm11 / 1550) / 1000;
                    //txtTopWtPerPpr.Text = TopWpp11.ToString();
                    //double TopBFPP11 = ((TopBF11 * Gsm11) / 1000);
                    //txtTopBfPerPpr.Text = TopBFPP11.ToString();

                    txtTopBF.Text = TPPBF;
                    txtTopGSM.Text = TPGsm;
                    txtTopWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txtTopBfPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txtTopBF.Enabled = false;
                    txtTopGSM.Enabled = false;
                    txtTopWtPerPpr.Enabled = false;
                    txtTopBfPerPpr.Enabled = false;

                    txt3BackingBF.Text = TPPBF;
                    txt3BackingGSM.Text = TPGsm;
                    txt3BackingWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt3BackingBFPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt3BackingBF.Enabled = false;
                    txt3BackingGSM.Enabled = false;
                    txt3BackingWtPerPpr.Enabled = false;
                    txt3BackingBFPerPpr.Enabled = false;

                    txt3FluteBF.Text = TPPBF;
                    txt3FluteGSM.Text = TPGsm;
                    txt3FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    Txt3FluteBFPrPPr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt3FluteBF.Enabled = false;
                    txt3FluteGSM.Enabled = false;
                    txt3FluteWtPerPpr.Enabled = false;
                    Txt3FluteBFPrPPr.Enabled = false;

                    txt5BackBF.Text = TPPBF;
                    txt5BackGSM.Text = TPGsm;
                    txt5BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt5BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt5BackBF.Enabled = false;
                    txt5BackGSM.Enabled = false;
                    txt5BackWtPrPpr.Enabled = false;
                    txt5BackBFPrPpr.Enabled = false;

                    txt5FluteBF.Text = TPPBF;
                    txt5FluteGSM.Text = TPGsm;
                    txt5FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt5FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt5FluteBF.Enabled = false;
                    txt5FluteGSM.Enabled = false;
                    txt5FluteWtPrPpr.Enabled = false;
                    txt5FluteBFPrPpr.Enabled = false;

                    txt7BackBF.Text = TPPBF;
                    txt7BackGSM.Text = TPGsm;
                    txt7BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt7BackBFPrppr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt7BackBF.Enabled = false;
                    txt7BackGSM.Enabled = false;
                    txt7BackWtPrPpr.Enabled = false;
                    txt7BackBFPrppr.Enabled = false;

                    txt7FluteBF.Text = TPPBF;
                    txt7FluteGSM.Text = TPGsm;
                    txt7FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt7FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt7FluteBF.Enabled = false;
                    txt7FluteGSM.Enabled = false;
                    txt7FluteWtPerPpr.Enabled = false;
                    txt7FluteBFPrPpr.Enabled = false;

                    txt9BackBF.Text = TPPBF;
                    txt9BackGSM.Text = TPGsm;
                    txt9BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt9BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt9BackBF.Enabled = false;
                    txt9BackGSM.Enabled = false;
                    txt9BackWtPrPpr.Enabled = false;
                    txt9BackBFPrPpr.Enabled = false;

                    txt9FluteBF.Text = TPPBF;
                    txt9FluteGSM.Text = TPGsm;
                    txt9FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt9FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt9FluteBF.Enabled = false;
                    txt9FluteGSM.Enabled = false;
                    txt9FluteWtPrPpr.Enabled = false;
                    txt9FluteBFPrPpr.Enabled = false;

                    txt11BackBF.Text = TPPBF;
                    txt11BackGSM.Text = TPGsm;
                    txt11BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt11BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt11BackBF.Enabled = false;
                    txt11BackGSM.Enabled = false;
                    txt11BackWtPrPpr.Enabled = false;
                    txt11BackBFPrPpr.Enabled = false;

                    txt11FluteBF.Text = TPPBF;
                    txt11FluteGSM.Text = TPGsm;
                    txt11FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt11FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt11FluteBF.Enabled = false;
                    txt11FluteGSM.Enabled = false;
                    txt11FluteWtPrPpr.Enabled = false;
                    txt11FluteBFPrPpr.Enabled = false;

                    txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text) + Convert.ToDouble(txt9FluteWtPrPpr.Text) + Convert.ToDouble(txt11BackWtPrPpr.Text) + Convert.ToDouble(txt11FluteWtPrPpr.Text), 2));
                    txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt11FluteBFPrPpr.Text) + Convert.ToDouble(txt11FluteBFPrPpr.Text), 2));

                }

                //For ThirteenPly
                if (ddlPly_Sheet.Text == "13")
                {
                    //double Gsm13 = Convert.ToDouble(TPGsm);
                    //double TopBF13 = Convert.ToDouble(TPPBF);
                    //double TopWpp13 = ((LenInchsheet1 * WidInchsheet1) * Gsm13 / 1550) / 1000;
                    //txtTopWtPerPpr.Text = TopWpp13.ToString();
                    //double TopBFPP13 = ((TopBF13 * Gsm13) / 1000);
                    //txtTopBfPerPpr.Text = TopBFPP13.ToString();

                    txtTopBF.Text = TPPBF;
                    txtTopGSM.Text = TPGsm;
                    txtTopWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txtTopBfPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txtTopBF.Enabled = false;
                    txtTopGSM.Enabled = false;
                    txtTopWtPerPpr.Enabled = false;
                    txtTopBfPerPpr.Enabled = false;

                    txt3BackingBF.Text = TPPBF;
                    txt3BackingGSM.Text = TPGsm;
                    txt3BackingWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt3BackingBFPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt3BackingBF.Enabled = false;
                    txt3BackingGSM.Enabled = false;
                    txt3BackingWtPerPpr.Enabled = false;
                    txt3BackingBFPerPpr.Enabled = false;

                    txt3FluteBF.Text = TPPBF;
                    txt3FluteGSM.Text = TPGsm;
                    txt3FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    Txt3FluteBFPrPPr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt3FluteBF.Enabled = false;
                    txt3FluteGSM.Enabled = false;
                    txt3FluteWtPerPpr.Enabled = false;
                    Txt3FluteBFPrPPr.Enabled = false;

                    txt5BackBF.Text = TPPBF;
                    txt5BackGSM.Text = TPGsm;
                    txt5BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt5BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt5BackBF.Enabled = false;
                    txt5BackGSM.Enabled = false;
                    txt5BackWtPrPpr.Enabled = false;
                    txt5BackBFPrPpr.Enabled = false;

                    txt5FluteBF.Text = TPPBF;
                    txt5FluteGSM.Text = TPGsm;
                    txt5FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt5FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt5FluteBF.Enabled = false;
                    txt5FluteGSM.Enabled = false;
                    txt5FluteWtPrPpr.Enabled = false;
                    txt5FluteBFPrPpr.Enabled = false;

                    txt7BackBF.Text = TPPBF;
                    txt7BackGSM.Text = TPGsm;
                    txt7BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt7BackBFPrppr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt7BackBF.Enabled = false;
                    txt7BackGSM.Enabled = false;
                    txt7BackWtPrPpr.Enabled = false;
                    txt7BackBFPrppr.Enabled = false;

                    txt7FluteBF.Text = TPPBF;
                    txt7FluteGSM.Text = TPGsm;
                    txt7FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt7FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt7FluteBF.Enabled = false;
                    txt7FluteGSM.Enabled = false;
                    txt7FluteWtPerPpr.Enabled = false;
                    txt7FluteBFPrPpr.Enabled = false;

                    txt9BackBF.Text = TPPBF;
                    txt9BackGSM.Text = TPGsm;
                    txt9BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt9BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt9BackBF.Enabled = false;
                    txt9BackGSM.Enabled = false;
                    txt9BackWtPrPpr.Enabled = false;
                    txt9BackBFPrPpr.Enabled = false;

                    txt9FluteBF.Text = TPPBF;
                    txt9FluteGSM.Text = TPGsm;
                    txt9FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt9FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt9FluteBF.Enabled = false;
                    txt9FluteGSM.Enabled = false;
                    txt9FluteWtPrPpr.Enabled = false;
                    txt9FluteBFPrPpr.Enabled = false;

                    txt11BackBF.Text = TPPBF;
                    txt11BackGSM.Text = TPGsm;
                    txt11BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt11BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt11BackBF.Enabled = false;
                    txt11BackGSM.Enabled = false;
                    txt11BackWtPrPpr.Enabled = false;
                    txt11BackBFPrPpr.Enabled = false;

                    txt11FluteBF.Text = TPPBF;
                    txt11FluteGSM.Text = TPGsm;
                    txt11FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt11FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt11FluteBF.Enabled = false;
                    txt11FluteGSM.Enabled = false;
                    txt11FluteWtPrPpr.Enabled = false;
                    txt11FluteBFPrPpr.Enabled = false;

                    txt13BackBF.Text = TPPBF;
                    txt13BackGSM.Text = TPGsm;
                    txt13BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt13BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt13BackBF.Enabled = false;
                    txt13BackGSM.Enabled = false;
                    txt13BackWtPrPpr.Enabled = false;
                    txt13BackBFPrPpr.Enabled = false;

                    txt13FluteBF.Text = TPPBF;
                    txt13FluteGSM.Text = TPGsm;
                    txt13FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt13FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt13FluteBF.Enabled = false;
                    txt13FluteGSM.Enabled = false;
                    txt13FluteWtPrPpr.Enabled = false;
                    txt13FluteBFPrPpr.Enabled = false;

                    txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text) + Convert.ToDouble(txt9FluteWtPrPpr.Text) + Convert.ToDouble(txt11BackWtPrPpr.Text) + Convert.ToDouble(txt11FluteWtPrPpr.Text) + Convert.ToDouble(txt13BackWtPrPpr.Text) + Convert.ToDouble(txt13FluteWtPrPpr.Text), 2));
                    txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt11FluteBFPrPpr.Text) + Convert.ToDouble(txt11FluteBFPrPpr.Text) + Convert.ToDouble(txt13FluteBFPrPpr.Text) + Convert.ToDouble(txt13FluteBFPrPpr.Text), 2));

                }

                //For FifteenPly
                if (ddlPly_Sheet.Text == "15")
                {
                    //double Gsm15 = Convert.ToDouble(TPGsm);
                    //double TopBF15 = Convert.ToDouble(TPPBF);
                    //double TopWpp15 = ((LenInchsheet1 * WidInchsheet1) * Gsm15 / 1550) / 1000;
                    //txtTopWtPerPpr.Text = TopWpp15.ToString();
                    //double TopBFPP15 = ((TopBF15 * Gsm15) / 1000);
                    //txtTopBfPerPpr.Text = TopBFPP15.ToString();

                    txtTopBF.Text = TPPBF;
                    txtTopGSM.Text = TPGsm;
                    txtTopWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txtTopBfPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txtTopBF.Enabled = false;
                    txtTopGSM.Enabled = false;
                    txtTopWtPerPpr.Enabled = false;
                    txtTopBfPerPpr.Enabled = false;

                    txt3BackingBF.Text = TPPBF;
                    txt3BackingGSM.Text = TPGsm;
                    txt3BackingWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt3BackingBFPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt3BackingBF.Enabled = false;
                    txt3BackingGSM.Enabled = false;
                    txt3BackingWtPerPpr.Enabled = false;
                    txt3BackingBFPerPpr.Enabled = false;

                    txt3FluteBF.Text = TPPBF;
                    txt3FluteGSM.Text = TPGsm;
                    txt3FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    Txt3FluteBFPrPPr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt3FluteBF.Enabled = false;
                    txt3FluteGSM.Enabled = false;
                    txt3FluteWtPerPpr.Enabled = false;
                    Txt3FluteBFPrPPr.Enabled = false;

                    txt5BackBF.Text = TPPBF;
                    txt5BackGSM.Text = TPGsm;
                    txt5BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt5BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt5BackBF.Enabled = false;
                    txt5BackGSM.Enabled = false;
                    txt5BackWtPrPpr.Enabled = false;
                    txt5BackBFPrPpr.Enabled = false;

                    txt5FluteBF.Text = TPPBF;
                    txt5FluteGSM.Text = TPGsm;
                    txt5FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt5FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt5FluteBF.Enabled = false;
                    txt5FluteGSM.Enabled = false;
                    txt5FluteWtPrPpr.Enabled = false;
                    txt5FluteBFPrPpr.Enabled = false;

                    txt7BackBF.Text = TPPBF;
                    txt7BackGSM.Text = TPGsm;
                    txt7BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt7BackBFPrppr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt7BackBF.Enabled = false;
                    txt7BackGSM.Enabled = false;
                    txt7BackWtPrPpr.Enabled = false;
                    txt7BackBFPrppr.Enabled = false;

                    txt7FluteBF.Text = TPPBF;
                    txt7FluteGSM.Text = TPGsm;
                    txt7FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt7FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt7FluteBF.Enabled = false;
                    txt7FluteGSM.Enabled = false;
                    txt7FluteWtPerPpr.Enabled = false;
                    txt7FluteBFPrPpr.Enabled = false;

                    txt9BackBF.Text = TPPBF;
                    txt9BackGSM.Text = TPGsm;
                    txt9BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt9BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt9BackBF.Enabled = false;
                    txt9BackGSM.Enabled = false;
                    txt9BackWtPrPpr.Enabled = false;
                    txt9BackBFPrPpr.Enabled = false;

                    txt9FluteBF.Text = TPPBF;
                    txt9FluteGSM.Text = TPGsm;
                    txt9FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt9FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt9FluteBF.Enabled = false;
                    txt9FluteGSM.Enabled = false;
                    txt9FluteWtPrPpr.Enabled = false;
                    txt9FluteBFPrPpr.Enabled = false;

                    txt11BackBF.Text = TPPBF;
                    txt11BackGSM.Text = TPGsm;
                    txt11BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt11BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt11BackBF.Enabled = false;
                    txt11BackGSM.Enabled = false;
                    txt11BackWtPrPpr.Enabled = false;
                    txt11BackBFPrPpr.Enabled = false;

                    txt11FluteBF.Text = TPPBF;
                    txt11FluteGSM.Text = TPGsm;
                    txt11FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt11FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt11FluteBF.Enabled = false;
                    txt11FluteGSM.Enabled = false;
                    txt11FluteWtPrPpr.Enabled = false;
                    txt11FluteBFPrPpr.Enabled = false;

                    txt13BackBF.Text = TPPBF;
                    txt13BackGSM.Text = TPGsm;
                    txt13BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt13BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt13BackBF.Enabled = false;
                    txt13BackGSM.Enabled = false;
                    txt13BackWtPrPpr.Enabled = false;
                    txt13BackBFPrPpr.Enabled = false;

                    txt13FluteBF.Text = TPPBF;
                    txt13FluteGSM.Text = TPGsm;
                    txt13FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt13FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt13FluteBF.Enabled = false;
                    txt13FluteGSM.Enabled = false;
                    txt13FluteWtPrPpr.Enabled = false;
                    txt13FluteBFPrPpr.Enabled = false;

                    txt15BackBF.Text = TPPBF;
                    txt15BackGSM.Text = TPGsm;
                    txt15BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
                    txt15BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

                    txt15BackBF.Enabled = false;
                    txt15BackGSM.Enabled = false;
                    txt15BackWtPrPpr.Enabled = false;
                    txt15BackBFPrPpr.Enabled = false;

                    txt15FluteBF.Text = TPPBF;
                    txt15FluteGSM.Text = TPGsm;
                    txt15FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
                    txt15FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

                    txt15FluteBF.Enabled = false;
                    txt15FluteGSM.Enabled = false;
                    txt15FluteWtPrPpr.Enabled = false;
                    txt15FluteBFPrPpr.Enabled = false;

                    txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text) + Convert.ToDouble(txt9FluteWtPrPpr.Text) + Convert.ToDouble(txt11BackWtPrPpr.Text) + Convert.ToDouble(txt11FluteWtPrPpr.Text) + Convert.ToDouble(txt13BackWtPrPpr.Text) + Convert.ToDouble(txt13FluteWtPrPpr.Text) + Convert.ToDouble(txt15BackWtPrPpr.Text) + Convert.ToDouble(txt15FluteWtPrPpr.Text), 2));
                    txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt11FluteBFPrPpr.Text) + Convert.ToDouble(txt11FluteBFPrPpr.Text) + Convert.ToDouble(txt13FluteBFPrPpr.Text) + Convert.ToDouble(txt13FluteBFPrPpr.Text) + Convert.ToDouble(txt15FluteBFPrPpr.Text) + Convert.ToDouble(txt15FluteBFPrPpr.Text), 2));

                }
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                ddlScoring_Opt.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while Top Paper Change " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTopGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txtTopBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txtTopGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txtTopWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
            txtTopBfPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

            txtWeight_Pcs.Text = txtTopWtPerPpr.Text;
            txtBF_Pcs.Text = txtTopBfPerPpr.Text;

            if (ddlPly_Sheet.SelectedText == "1" || ddlPly_Sheet.SelectedText == "2")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt3BackingGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt3BackingBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt3BackingGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt3BackingWtPerPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
            txt3BackingBFPerPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "3")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt3FluteGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt3FluteBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt3FluteGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt3FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
            Txt3FluteBFPrPPr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "3")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt5BackGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt5BackBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt5BackGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt5BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
            txt5BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "5")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt5FluteGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt5FluteBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt5FluteGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt5FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
            txt5FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "5")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt7BackGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt7BackBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt7BackGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt7BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
            txt7BackBFPrppr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7BackBFPrppr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "7")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt7FluteGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt7FluteBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt7FluteGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt7FluteWtPerPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
            txt7FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7BackBFPrppr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "7")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt9BackGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt9BackBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt9BackGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt9BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
            txt9BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7BackBFPrppr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9BackBFPrPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "9")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt9FluteGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt9FluteBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt9FluteGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt9FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
            txt9FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text) + Convert.ToDouble(txt9FluteWtPrPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7BackBFPrppr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9BackBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "9")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt11BackGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt11BackBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt11BackGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt11BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
            txt11BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text) + Convert.ToDouble(txt9FluteWtPrPpr.Text) + Convert.ToDouble(txt11BackWtPrPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7BackBFPrppr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9BackBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt11BackBFPrPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "11")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt11FluteGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt11FluteBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt11FluteGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt11FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
            txt11FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text) + Convert.ToDouble(txt9FluteWtPrPpr.Text) + Convert.ToDouble(txt11BackWtPrPpr.Text) + Convert.ToDouble(txt11FluteWtPrPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7BackBFPrppr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9BackBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt11BackBFPrPpr.Text) + Convert.ToDouble(txt11FluteBFPrPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "11")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt13BackGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt11FluteBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt11FluteGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt13BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
            txt13BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text) + Convert.ToDouble(txt9FluteWtPrPpr.Text) + Convert.ToDouble(txt11BackWtPrPpr.Text) + Convert.ToDouble(txt11FluteWtPrPpr.Text) + Convert.ToDouble(txt13BackWtPrPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7BackBFPrppr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9BackBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt11BackBFPrPpr.Text) + Convert.ToDouble(txt11FluteBFPrPpr.Text) + Convert.ToDouble(txt13BackWtPrPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "13")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt13FluteGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt11FluteBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt11FluteGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt13FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
            txt13FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text) + Convert.ToDouble(txt9FluteWtPrPpr.Text) + Convert.ToDouble(txt11BackWtPrPpr.Text) + Convert.ToDouble(txt11FluteWtPrPpr.Text) + Convert.ToDouble(txt13BackWtPrPpr.Text) + Convert.ToDouble(txt13FluteWtPrPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7BackBFPrppr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9BackBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt11BackBFPrPpr.Text) + Convert.ToDouble(txt11FluteBFPrPpr.Text) + Convert.ToDouble(txt13BackWtPrPpr.Text) + Convert.ToDouble(txt13FluteBFPrPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "13")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt15BackGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt11FluteBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt11FluteGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt15BackWtPrPpr.Text = Convert.ToString(Math.Round((dblDeckle * dblCuttingSize * dblTPGSM / 1550) / 1000, 2));
            txt15BackBFPrPpr.Text = Convert.ToString(Math.Round(dblTPPBF * dblTPGSM / 1000, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text) + Convert.ToDouble(txt9FluteWtPrPpr.Text) + Convert.ToDouble(txt11BackWtPrPpr.Text) + Convert.ToDouble(txt11FluteWtPrPpr.Text) + Convert.ToDouble(txt13BackWtPrPpr.Text) + Convert.ToDouble(txt13FluteWtPrPpr.Text) + Convert.ToDouble(txt15BackWtPrPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7BackBFPrppr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9BackBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt11BackBFPrPpr.Text) + Convert.ToDouble(txt11FluteBFPrPpr.Text) + Convert.ToDouble(txt13BackWtPrPpr.Text) + Convert.ToDouble(txt13FluteBFPrPpr.Text) + Convert.ToDouble(txt15BackBFPrPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "15")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt15FluteGSM_Leave(object sender, EventArgs e)
        {
            double dblTPPBF = 0.00, dblTPGSM = 0.00;

            dblTPPBF = Math.Round(Convert.ToDouble(txt11FluteBF.Text), 2);
            dblTPGSM = Math.Round(Convert.ToDouble(txt11FluteGSM.Text), 2);

            double dblDeckle = Math.Round(Convert.ToDouble(txtLength_Inch_Sheet.Text), 2);
            double dblCuttingSize = Math.Round(Convert.ToDouble(txtWidth_Inch_Sheet.Text), 2);

            txt15FluteWtPrPpr.Text = Convert.ToString(Math.Round(((dblDeckle * dblCuttingSize * dblTPGSM + 0.4 * (dblDeckle * dblCuttingSize * dblTPGSM)) / 1550) / 1000, 2));
            txt15FluteBFPrPpr.Text = Convert.ToString(Math.Round((dblTPPBF * dblTPGSM / 1000) / 2, 2));

            txtWeight_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopWtPerPpr.Text) + Convert.ToDouble(txt3BackingWtPerPpr.Text) + Convert.ToDouble(txt3FluteWtPerPpr.Text) + Convert.ToDouble(txt5BackWtPrPpr.Text) + Convert.ToDouble(txt5FluteWtPrPpr.Text) + Convert.ToDouble(txt7BackWtPrPpr.Text) + Convert.ToDouble(txt7FluteWtPerPpr.Text) + Convert.ToDouble(txt9BackWtPrPpr.Text) + Convert.ToDouble(txt9FluteWtPrPpr.Text) + Convert.ToDouble(txt11BackWtPrPpr.Text) + Convert.ToDouble(txt11FluteWtPrPpr.Text) + Convert.ToDouble(txt13BackWtPrPpr.Text) + Convert.ToDouble(txt13FluteWtPrPpr.Text) + Convert.ToDouble(txt15BackWtPrPpr.Text) + Convert.ToDouble(txt15FluteWtPrPpr.Text), 2));
            txtBF_Pcs.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtTopBfPerPpr.Text) + Convert.ToDouble(txt3BackingBFPerPpr.Text) + Convert.ToDouble(Txt3FluteBFPrPPr.Text) + Convert.ToDouble(txt5BackBFPrPpr.Text) + Convert.ToDouble(txt5FluteBFPrPpr.Text) + Convert.ToDouble(txt7BackBFPrppr.Text) + Convert.ToDouble(txt7FluteBFPrPpr.Text) + Convert.ToDouble(txt9BackBFPrPpr.Text) + Convert.ToDouble(txt9FluteBFPrPpr.Text) + Convert.ToDouble(txt11BackBFPrPpr.Text) + Convert.ToDouble(txt11FluteBFPrPpr.Text) + Convert.ToDouble(txt13BackWtPrPpr.Text) + Convert.ToDouble(txt13FluteBFPrPpr.Text) + Convert.ToDouble(txt15BackBFPrPpr.Text) + Convert.ToDouble(txt15FluteBFPrPpr.Text), 2));

            if (ddlPly_Sheet.SelectedText == "15")
            {
                txtPedilite_WtBox.Text = Convert.ToString(Math.Round(0.03 * Convert.ToDouble(txtWeight_Pcs.Text), 2));
                txtArtWrk_Code.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlScoring_Opt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ddlScoring_Opt.Text == "Yes")
            {
                ddlPunching_Opt.Text = "No";
            }
            else
            {
                ddlPunching_Opt.Text = "";
            }
            ddlPunching_Opt.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlPunching_Opt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ddlPasting_Opt.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlPasting_Opt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ddlSlotting_Opt.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlSlotting_Opt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ddlPinning_Opt.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlPinning_Opt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ddlPinning_Opt.Text == "Yes")
            {
                ddlSide_Pasting.Text = "No";
                ddlSide_Pasting.SelectedText = "No";
                ddlSide_Pasting.Enabled = false;
                txtRate_SidePastg.Enabled = false;
                txtNo_Pins.Focus();
            }
            else
            {
                ddlSide_Pasting.SelectedText = "Yes";
                ddlSide_Pasting.Enabled = true;
                txtRate_SidePastg.Enabled = true;

                txtNo_Pins.Enabled = false;
                ddlPinning_InOut.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNo_Pins_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNo_Pins_Leave(object sender, EventArgs e)
        {
            ddlPinning_InOut.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlPinning_InOut_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ddlSide_Pasting.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlSide_Pasting_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ddlSide_Pasting.Text == "Yes")
            {
                if (txtRate_SidePastg.Text == "")
                {
                    MessageBox.Show("Please enter Rate_SidePastg");
                    txtRate_SidePastg.Focus();
                }
            }
            //txtRate_SidePastg.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRate_SidePastg_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRate_SidePastg_Leave(object sender, EventArgs e)
        {
            ddlCanvas_Opt.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCanvas_Opt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ddlCanvas_Opt.Text == "Yes")
            {
                txtSide_Canvas.Focus();

                if (txtSide_Canvas.Text == "")
                {
                    MessageBox.Show("Please enter Side_Canvas");

                }
                else if (txtCanvColor_Name.Text == "")
                {
                    MessageBox.Show("Please enter CanvColor_Name");
                    txtCanvColor_Name.Focus();
                }
                txtSide_Canvas.Enabled = true;
                txtCanvColor_Name.Enabled = true;
            }
            else
            {
                txtSide_Canvas.Enabled = false;
                txtCanvColor_Name.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSide_Canvas_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSide_Canvas_Leave(object sender, EventArgs e)
        {
            txtCanvColor_Name.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCanvColor_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCanvColor_Name_Leave(object sender, EventArgs e)
        {
            txtSell_Rate.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSell_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSell_Rate_Leave(object sender, EventArgs e)
        {
            ddlRate_Type.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlRate_Type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtExcise_Code.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.MaxDate = System.DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindBoxStyle()
        {
            try
            {
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select a.Style_ID,a.Style_No as StyleNo from Item_Style_Master a,Group_Master b where a.Grp_ID=b.Grp_ID  and a.Grp_ID = '" + Group_ID + "' and a.Grp_ID=b.Grp_ID and Style_Active='Yes'", con);
                SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                da.Fill(dt);
                if (dt != null)
                {
                    GlobalFunctions.AddPleaseSelect(ref dt);
                    ddlStyle_ID.DataSource = dt;
                    ddlStyle_ID.DisplayMember = dt.Columns[1].ToString();
                    ddlStyle_ID.ValueMember = dt.Columns[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while fetching Styles" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindParty()
        {
            try
            {
                //DataTable dtAllPartyMainMasterData = bl.GetAllActivePartyMainMasterData(Group_ID);
                //if (dtAllPartyMainMasterData != null)
                //{
                //    GlobalFunctions.AddPleaseSelect(ref dtAllPartyMainMasterData);
                //    ddlPartyMain.DataSource = dtAllPartyMainMasterData;
                //    ddlPartyMain.DisplayMember = dtAllPartyMainMasterData.Columns[1].ToString();
                //    ddlPartyMain.ValueMember = dtAllPartyMainMasterData.Columns[0].ToString();
                //}
                DataTable dtParty = new DataTable();
                dtParty = bl.GetAllActivePartyMasterData(Group_ID);
                if (dtParty != null)
                {
                    if (dtParty.Rows.Count > 0)
                    {
                        GlobalFunctions.AddPleaseSelect(ref dtParty);
                        ddlParty.DataSource = dtParty;
                        ddlParty.DisplayMember = dtParty.Columns[1].ToString();
                        ddlParty.ValueMember = dtParty.Columns[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while fetching Party " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindPlySheets()
        {
            try
            {
                DataTable dtPlySheets = new DataTable();
                GlobalFunctions.GetPlySheets(ref dtPlySheets);
                ddlPly_Sheet.DataSource = dtPlySheets;
                ddlPly_Sheet.DisplayMember = dtPlySheets.Columns[0].ToString();
                ddlPly_Sheet.ValueMember = dtPlySheets.Columns[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while fetching Ply Sheets" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindTopPaper()
        {
            try
            {
                //to fill the grid with user details
                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con = new SqlConnection(strcon);
                SqlDataAdapter da = new SqlDataAdapter("SELECT TP_ID,TP_Name from TopPaper_Master where TP_Active = 'Yes' and Grp_ID='" + Group_ID + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    GlobalFunctions.AddPleaseSelect(ref dt);
                    ddlTP_ID.DataSource = dt;
                    ddlTP_ID.DisplayMember = dt.Columns[1].ToString();
                    ddlTP_ID.ValueMember = dt.Columns[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading TopPaper " + ex.Message);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtExcise_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtArtWrk_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtArtWrk_Code_Leave(object sender, EventArgs e)
        {
            txtRevi_No.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRevi_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRevi_No_Leave(object sender, EventArgs e)
        {
            txtArt_Dt.Focus();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtArt_Dt.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = false;
            txtArt_Dt.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtArt_Dt_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSpeci_Code_Leave(object sender, EventArgs e)
        {
            ddlFor_Pedilite.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSpeci_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPedilite_BS_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPedilite_GSM_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPedilite_WtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pedilite_PReq_KeyPress(object sender, KeyPressEventArgs e)
        {
            funclib = new FunctionLib();
            funclib.checkNumericChar(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlFor_Pedilite_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ddlFor_Pedilite.Text == "Yes")
            {
                if (txtPedilite_BS.Text == "")
                {
                    MessageBox.Show("Please enter Pedilite_BS");
                    txtPedilite_BS.Focus();
                }
                if (txtPedilite_GSM.Text == "")
                {
                    MessageBox.Show("Please enter Pedilite_GSM");
                    txtPedilite_GSM.Focus();
                }
                if (txtPedilite_WtBox.Text == "")
                {
                    MessageBox.Show("Please enter Pedilite_WtBox");
                    txtPedilite_WtBox.Focus();
                }
                else if (Pedilite_PReq.Text == "")
                {
                    MessageBox.Show("Please enter Pedilite_PReq");
                    Pedilite_PReq.Focus();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void clearall()
        {
            ddlParty.SelectedText = "Please Select";
            txtProductCode.Text = "";
            ddlPartyMain.Text = "";
            //ddlPB_ID.Text = "";
            txtI_Name.Text = "";
            ddlStyle_ID.Text = "";
            ddlPly_Sheet.Text = "Please Select";
            cmbUnits.Text = "";
            txtBoxLength.Text = "";
            txtBoxWidth.Text = "";
            txtBoxHeight.Text = "";
            txtBoxLength_Conv.Text = "";
            txtBoxWidth_Conv.Text = "";
            txtBoxHeight_Conv.Text = "";
            txtLength_Inch_Sheet.Text = "";
            txtWidth_Inch_Sheet.Text = "";
            chkBoxConvInside.Checked = false;
            ChkBoxConvOutside.Checked = false;

            ddlEF_NF_PC.Text = "";
            txtBundle_Packet.Text = "";
            txtBox_PerSheet.Text = "";
            ddlCorrugation_Opt.Text = "Please Select";
            ddlPaper_Cutting.Text = "Please Select";
            ddlPrinting_Opt.Text = "Please Select";
            txtNo_Colors.Text = "";
            txtPrntColor_Name.Text = "";
            ddlPaper_Printed.Text = "Please Select";
            ddlTP_ID.Text = "Please Select";
            ddlScoring_Opt.Text = "Please Select";
            ddlPunching_Opt.Text = "Please Select";
            ddlPasting_Opt.Text = "Please Select";
            ddlSlotting_Opt.Text = "Please Select";
            ddlPinning_Opt.Text = "Please Select";
            txtNo_Pins.Text = "";
            ddlPinning_InOut.Text = "Please Select";
            ddlSide_Pasting.Text = "Please Select";
            txtRate_SidePastg.Text = "";
            ddlCanvas_Opt.Text = "Please Select";
            txtSide_Canvas.Text = "";
            txtCanvColor_Name.Text = "";
            txtSell_Rate.Text = "";
            ddlRate_Type.Text = "Please Select";
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
            ddlFor_Pedilite.Text = "Please Select";
            txtPedilite_BS.Text = "";
            txtPedilite_GSM.Text = "";
            txtPedilite_WtBox.Text = "";
            Pedilite_PReq.Text = "";
            //ddlI_Lock.Text = "";
            ddlI_Active.Text = "";
            ThreePly.Visible = false;
            FivePly.Visible = false;
            SevenPly.Visible = false;
            NinePly.Visible = false;
            ElevenPly.Visible = false;
            pictureBox1.Visible = false;
            ddlI_Active.SelectedText = "Yes";
            ddlI_Active.Enabled = false;
            ddlDimn_Opt.Text = "";
            //txtLength_Inch_Sheet1.Text = "";
            //txtWidth_Inch_Sheet1.Text = "";


            this.Controls.Clear();
            this.InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdReset_Click(object sender, EventArgs e)
        {
            clearall();
            //this.InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlParty.Text == "")
                {
                    MessageBox.Show("Please Select Party");
                    ddlParty.Focus();
                }
                else if (txtProductCode.Text == "")
                {
                    MessageBox.Show("Please enter Product Code");
                    txtProductCode.Focus();
                }
                else if (txtI_Name.Text == "")
                {
                    MessageBox.Show("Please enter Item Name");
                    txtI_Name.Focus();
                }
                else if (ddlPly_Sheet.Text == "Please Select")
                {
                    MessageBox.Show("Please Select Ply of Sheet");
                    ddlPly_Sheet.Focus();
                }
                else if (cmbUnits.Text == "")
                {
                    MessageBox.Show("Please Select Box Length Unit");
                    cmbUnits.Focus();
                }
                else if (txtBoxLength.Text == "")
                {
                    MessageBox.Show("Please Select Box Length");
                    txtBoxLength.Focus();
                }
                else if (txtBoxWidth.Text == "")
                {
                    MessageBox.Show("Please Select Box Width");
                    txtBoxWidth.Focus();
                }
                else if (txtBoxHeight.Text == "")
                {
                    MessageBox.Show("Please Select Box Height");
                    txtBoxHeight.Focus();
                }
                else if (txtBoxLength_Conv.Text == "")
                {
                    MessageBox.Show("Please Select Box Length Conversion");
                    txtBoxLength.Focus();
                }
                else if (txtBoxWidth_Conv.Text == "")
                {
                    MessageBox.Show("Please Select Box Width Conversion");
                    txtBoxWidth.Focus();
                }
                else if (txtBoxHeight_Conv.Text == "")
                {
                    MessageBox.Show("Please Select Box Height Conversion");
                    txtBoxHeight.Focus();
                }
                else if (chkBoxConvInside.Checked == false && ChkBoxConvOutside.Checked == false)
                {
                    MessageBox.Show("Select Inside/Outside Conversion");
                    txtBoxHeight.Focus();
                }
                else if (ddlPly_Sheet.Text == "")
                {
                    MessageBox.Show("Please enter Ply_Sheet");
                    ddlPly_Sheet.Focus();
                }
                else if (txtLength_Inch_Sheet.Text == "")
                {
                    MessageBox.Show("Please enter Length_Inch_Sheet");
                    txtLength_Inch_Sheet.Focus();
                }
                else if (txtWidth_Inch_Sheet.Text == "")
                {
                    MessageBox.Show("Please Select Width_Inch_Sheet");
                    txtWidth_Inch_Sheet.Focus();
                }
                else if (ddlEF_NF_PC.Text == "")
                {
                    MessageBox.Show("Please select EF_NF_PC");
                    ddlEF_NF_PC.Focus();
                }
                else if (txtBundle_Packet.Text == "")
                {
                    MessageBox.Show("Please Select Bundle_Packet");
                    txtBundle_Packet.Focus();
                }
                else if (txtBox_PerSheet.Text == "")
                {
                    MessageBox.Show("Please enter Box_PerSheet ");
                    txtBox_PerSheet.Focus();
                }
                else if (ddlCorrugation_Opt.Text == "")
                {
                    MessageBox.Show("Please Select Corrugation_Opt");
                    ddlCorrugation_Opt.Focus();
                }
                else if (ddlPaper_Cutting.Text == "")
                {
                    MessageBox.Show("Please select Paper_Cutting");
                    ddlPaper_Cutting.Focus();
                }
                else if (ddlPrinting_Opt.Text == "")
                {
                    MessageBox.Show("Please Select Printing_Opt");
                    ddlPrinting_Opt.Focus();
                }
                else if (ddlPaper_Printed.Text == "")
                {
                    MessageBox.Show("Please select Paper_Printed");
                    ddlPaper_Printed.Focus();
                }
                else if (ddlTP_ID.Text == "")
                {
                    MessageBox.Show("Please Select TP_ID");
                    ddlTP_ID.Focus();
                }
                else if (ddlScoring_Opt.Text == "")
                {
                    MessageBox.Show("Please select Scoring_Opt");
                    ddlScoring_Opt.Focus();
                }
                else if (ddlPunching_Opt.Text == "")
                {
                    MessageBox.Show("Please Select ddlPunching_Opt");
                    ddlPunching_Opt.Focus();
                }
                else if (ddlPasting_Opt.Text == "")
                {
                    MessageBox.Show("Please select Pasting_Opt ");
                    ddlPasting_Opt.Focus();
                }
                else if (ddlSlotting_Opt.Text == "")
                {
                    MessageBox.Show("Please Select Slotting_Opt");
                    ddlSlotting_Opt.Focus();
                }
                else if (ddlPinning_Opt.Text == "")
                {
                    MessageBox.Show("Please Select Pinning_Opt ");
                    ddlPinning_Opt.Focus();
                }
                else if (ddlSide_Pasting.Text == "")
                {
                    MessageBox.Show("Please Select Side_Pasting");
                    ddlSide_Pasting.Focus();
                }
                else if (txtSell_Rate.Text == "")
                {
                    MessageBox.Show("Please enter Sell_Rate");
                    txtSell_Rate.Focus();
                }
                else if (ddlRate_Type.Text == "")
                {
                    MessageBox.Show("Please Select Rate_Type");
                    ddlRate_Type.Focus();
                }
                else if (txtExcise_Code.Text == "")
                {
                    MessageBox.Show("Please enter Excise_Code");
                    txtExcise_Code.Focus();
                }
                else if (txtTopBF.Text == "")
                {
                    MessageBox.Show("Please Select Top_BF");
                    txtTopBF.Focus();
                }
                else if (txtTopGSM.Text == "")
                {
                    MessageBox.Show("Please enter Top_GSM ");
                    txtTopGSM.Focus();
                }
                else if (txtTopWtPerPpr.Text == "")
                {
                    MessageBox.Show("Please enter Top_WPP");
                    txtTopWtPerPpr.Focus();
                }
                else if (txtTopBfPerPpr.Text == "")
                {
                    MessageBox.Show("Please enter Top_BFPP");
                    txtTopBfPerPpr.Focus();
                }
                else if (txtWeight_Pcs.Text == "")
                {
                    MessageBox.Show("Please enter Weight_Pcs");
                    txtWeight_Pcs.Focus();
                }
                else if (txtBF_Pcs.Text == "")
                {
                    MessageBox.Show("Please enter BF_Pcs");
                    txtBF_Pcs.Focus();
                }
                else if (txtArtWrk_Code.Text == "")
                {
                    MessageBox.Show("Please enter ArtWrk_Code ");
                    txtArtWrk_Code.Focus();
                }
                else if (txtRevi_No.Text == "")
                {
                    MessageBox.Show("Please enter Revi_No");
                    txtRevi_No.Focus();
                }
                else if (txtArt_Dt.Text == "")
                {
                    MessageBox.Show("Please enter Art_Dt");
                    txtArt_Dt.Focus();
                }
                else if (txtSpeci_Code.Text == "")
                {
                    MessageBox.Show("Please enter Special_Code");
                    txtSpeci_Code.Focus();
                }
                else
                {
                    string TopBF = txtTopBF.Text;
                    string TopGSM = txtTopGSM.Text;
                    string TopWtPerPpr = txtTopWtPerPpr.Text;
                    string TopBfPerPpr = txtTopBfPerPpr.Text;

                    #region OLD CODE 05th Feb 2021
                    //if (ddlPly_Sheet.Text == "1" || ddlPly_Sheet.Text == "2")
                    //{                   
                    //    string TopBF = txtTopBF.Text;
                    //    txtTop_BF.Text = txtTopBF.ToString();

                    //    string TopGsm = txtTopGSM.Text;
                    //    txtTop_GSM.Text = txtTopGsm.ToString();

                    //    string txtTopWpp = Convert.ToString(txtTop_WPP3.Text);
                    //    txtTop_WPP.Text = txtTopWpp.ToString();


                    //    string txtTopBFPP = Convert.ToString(txtTop_BFPP3.Text);
                    //    txtTop_BFPP.Text = txtTopBFPP.ToString();
                    //}

                    //if (ddlPly_Sheet.Text == "3")
                    //{

                    //    string txtTopBF3 = Convert.ToString(txtTop_BF3.Text);
                    //    txtTop_BF.Text = txtTopBF3;

                    //    string txtTopGsm = Convert.ToString(txtTop_GSM3.Text);
                    //    txtTop_GSM.Text = txtTopGsm.ToString();

                    //    string txtTopWpp = Convert.ToString(txtTop_WPP3.Text);
                    //    txtTop_WPP.Text = txtTopWpp.ToString();


                    //    string txtTopBFPP = Convert.ToString(txtTop_BFPP3.Text);
                    //    txtTop_BFPP.Text = txtTopBFPP.ToString();
                    //}

                    //if (ddlPly_Sheet.Text == "5")
                    //{

                    //    string txtTopBF3 = Convert.ToString(txtTop_BF5.Text);
                    //    txtTop_BF.Text = txtTopBF3.ToString();

                    //    string txtTopGsm = Convert.ToString(txtTop_GSM5.Text);
                    //    txtTop_GSM.Text = txtTopGsm.ToString();

                    //    string txtTopWpp = Convert.ToString(txtTop_WPP5.Text);
                    //    txtTop_WPP.Text = txtTopWpp.ToString();


                    //    string txtTopBFPP = Convert.ToString(txtTop_BFPP5.Text);
                    //    txtTop_BFPP.Text = txtTopBFPP.ToString();
                    //}

                    //if (ddlPly_Sheet.Text == "7")
                    //{

                    //    string txtTopBF3 = Convert.ToString(txtTop_BF.Text);
                    //    txtTop_BF.Text = txtTopBF3.ToString();

                    //    string txtTopGsm = Convert.ToString(txtTop_GSM.Text);
                    //    txtTop_GSM.Text = txtTopGsm.ToString();

                    //    string txtTopWpp = Convert.ToString(txtTop_WPP.Text);
                    //    txtTop_WPP.Text = txtTopWpp.ToString();


                    //    string txtTopBFPP = Convert.ToString(txtTop_BFPP.Text);
                    //    txtTop_BFPP.Text = txtTopBFPP.ToString();
                    //}

                    //if (ddlPly_Sheet.Text == "9")
                    //{

                    //    string txtTopBF3 = Convert.ToString(txtTop_BF9.Text);
                    //    txtTop_BF.Text = txtTopBF3.ToString();

                    //    string txtTopGsm = Convert.ToString(txtTop_GSM9.Text);
                    //    txtTop_GSM.Text = txtTopGsm.ToString();

                    //    string txtTopWpp = Convert.ToString(txtTop_WPP9.Text);
                    //    txtTop_WPP.Text = txtTopWpp.ToString();


                    //    string txtTopBFPP = Convert.ToString(txtTop_BFPP9.Text);
                    //    txtTop_BFPP.Text = txtTopBFPP.ToString();
                    //}

                    //if (ddlPly_Sheet.Text == "11")
                    //{

                    //    string txtTopBF3 = Convert.ToString(txtTop_BF11.Text);
                    //    txtTop_BF.Text = txtTopBF3.ToString();

                    //    string txtTopGsm = Convert.ToString(txtTop_GSM11.Text);
                    //    txtTop_GSM.Text = txtTopGsm.ToString();

                    //    string txtTopWpp = Convert.ToString(txtTop_WPP11.Text);
                    //    txtTop_WPP.Text = txtTopWpp.ToString();


                    //    string txtTopBFPP = Convert.ToString(txtTop_BFPP11.Text);
                    //    txtTop_BFPP.Text = txtTopBFPP.ToString();
                    //} 
                    #endregion
                    //Insert the details into the table
                    funclib = new FunctionLib();

                    string strcon = funclib.setConnection();
                    SqlConnection con = new SqlConnection(strcon);

                    if (MessageBox.Show("Do you wish to add this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtI_Name.Text = funclib.FirstCap(txtI_Name.Text);
                        pid = funclib.I_ID("I", con, "select I_ID from Item_Master order by I_ID desc");

                        bool result = AddEditDeleteItemMasterData("A", pid);
                        if (result)
                        {
                            try
                            {
                                //Insert Into Three Ply
                                if (ddlPly_Sheet.Text == "3")
                                {
                                    #region Insert In ThreePly
                                    //Insert For Backing In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon1 = funclib.setConnection();
                                    SqlConnection con1 = new SqlConnection(strcon1);
                                    string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + txt3BackingBF.Text.Trim().Replace("'", "''") + "','" + txt3BackingGSM.Text.Trim().Replace("'", "''") + "','" + txt3BackingWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt3BackingBFPerPpr.Text.Trim().Replace("'", "''") + "')", con1);
                                    con1.Open();
                                    int A = cmd1.ExecuteNonQuery();
                                    con1.Close();

                                    //Insert For Flute In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon2 = funclib.setConnection();
                                    SqlConnection con2 = new SqlConnection(strcon2);
                                    string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + txt3FluteBF.Text.Trim().Replace("'", "''") + "','" + txt3FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt3FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + Txt3FluteBFPrPPr.Text.Trim().Replace("'", "''") + "')", con2);
                                    con2.Open();
                                    int B = cmd2.ExecuteNonQuery();
                                    con2.Close();
                                    #endregion

                                }

                                //Insert Into Five Ply
                                if (ddlPly_Sheet.Text == "5")
                                {
                                    #region Insert In ThreePly
                                    //Insert For Backing In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon1 = funclib.setConnection();
                                    SqlConnection con1 = new SqlConnection(strcon1);
                                    string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + txt3BackingBF.Text.Trim().Replace("'", "''") + "','" + txt3BackingGSM.Text.Trim().Replace("'", "''") + "','" + txt3BackingWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt3BackingBFPerPpr.Text.Trim().Replace("'", "''") + "')", con1);
                                    con1.Open();
                                    int A = cmd1.ExecuteNonQuery();
                                    con1.Close();

                                    //Insert For Flute In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon2 = funclib.setConnection();
                                    SqlConnection con2 = new SqlConnection(strcon2);
                                    string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + txt3FluteBF.Text.Trim().Replace("'", "''") + "','" + txt3FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt3FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + Txt3FluteBFPrPPr.Text.Trim().Replace("'", "''") + "')", con2);
                                    con2.Open();
                                    int B = cmd2.ExecuteNonQuery();
                                    con2.Close();
                                    #endregion


                                    #region Insert In 5 PLY
                                    //Insert For Backing In FivePly
                                    funclib = new FunctionLib();
                                    string strcon3 = funclib.setConnection();
                                    SqlConnection con3 = new SqlConnection(strcon3);
                                    string Rid2 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd3 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid2 + "','Backing','" + txt5BackBF.Text.Trim().Replace("'", "''") + "','" + txt5BackGSM.Text.Trim().Replace("'", "''") + "','" + txt5BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con3);
                                    con3.Open();
                                    int C = cmd3.ExecuteNonQuery();
                                    con3.Close();

                                    //Insert For Flute In FivePly
                                    funclib = new FunctionLib();
                                    string strcon4 = funclib.setConnection();
                                    SqlConnection con4 = new SqlConnection(strcon4);
                                    string Rid4 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd4 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid4 + "','Flute','" + txt5FluteBF.Text.Trim().Replace("'", "''").ToString() + "','" + txt5FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt5FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con4);
                                    con4.Open();
                                    int D = cmd4.ExecuteNonQuery();
                                    con4.Close();
                                    #endregion

                                }

                                //Insert Into Seven Ply
                                if (ddlPly_Sheet.Text == "7")
                                {
                                    #region Insert In ThreePly
                                    //Insert For Backing In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon1 = funclib.setConnection();
                                    SqlConnection con1 = new SqlConnection(strcon1);
                                    string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + txt3BackingBF.Text.Trim().Replace("'", "''") + "','" + txt3BackingGSM.Text.Trim().Replace("'", "''") + "','" + txt3BackingWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt3BackingBFPerPpr.Text.Trim().Replace("'", "''") + "')", con1);
                                    con1.Open();
                                    int A = cmd1.ExecuteNonQuery();
                                    con1.Close();

                                    //Insert For Flute In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon2 = funclib.setConnection();
                                    SqlConnection con2 = new SqlConnection(strcon2);
                                    string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + txt3FluteBF.Text.Trim().Replace("'", "''") + "','" + txt3FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt3FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + Txt3FluteBFPrPPr.Text.Trim().Replace("'", "''") + "')", con2);
                                    con2.Open();
                                    int B = cmd2.ExecuteNonQuery();
                                    con2.Close();
                                    #endregion


                                    #region Insert In 5 PLY
                                    //Insert For Backing In FivePly
                                    funclib = new FunctionLib();
                                    string strcon3 = funclib.setConnection();
                                    SqlConnection con3 = new SqlConnection(strcon3);
                                    string Rid2 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd3 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid2 + "','Backing','" + txt5BackBF.Text.Trim().Replace("'", "''") + "','" + txt5BackGSM.Text.Trim().Replace("'", "''") + "','" + txt5BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con3);
                                    con3.Open();
                                    int C = cmd3.ExecuteNonQuery();
                                    con3.Close();

                                    //Insert For Flute In FivePly
                                    funclib = new FunctionLib();
                                    string strcon4 = funclib.setConnection();
                                    SqlConnection con4 = new SqlConnection(strcon4);
                                    string Rid4 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd4 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid4 + "','Flute','" + txt5FluteBF.Text.Trim().Replace("'", "''").ToString() + "','" + txt5FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt5FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con4);
                                    con4.Open();
                                    int D = cmd4.ExecuteNonQuery();
                                    con4.Close();
                                    #endregion


                                    #region Insert in 7 PLY
                                    //Insert For Backing In 7 Ply
                                    funclib = new FunctionLib();
                                    string strcon5 = funclib.setConnection();
                                    SqlConnection con5 = new SqlConnection(strcon5);
                                    string Rid5 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd5 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid5 + "','Backing','" + txt7BackBF.Text.Trim().Replace("'", "''") + "','" + txt7BackGSM.Text.Trim().Replace("'", "''") + "','" + txt7BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt7BackBFPrppr.Text.Trim().Replace("'", "''") + "')", con5);
                                    con5.Open();
                                    int E = cmd5.ExecuteNonQuery();
                                    con5.Close();

                                    //Insert For Flute In 7 Ply
                                    funclib = new FunctionLib();
                                    string strcon6 = funclib.setConnection();
                                    SqlConnection con6 = new SqlConnection(strcon6);
                                    string Rid6 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd6 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid6 + "','Flute','" + txt7FluteBF.Text.Trim().Replace("'", "''") + "','" + txt7FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt7FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt7BackBFPrppr.Text.Trim().Replace("'", "''") + "')", con6);
                                    con6.Open();
                                    int F = cmd6.ExecuteNonQuery();
                                    con6.Close();
                                    #endregion

                                }

                                //Insert Into Nine Ply
                                if (ddlPly_Sheet.Text == "9")
                                {
                                    #region Insert In ThreePly
                                    //Insert For Backing In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon1 = funclib.setConnection();
                                    SqlConnection con1 = new SqlConnection(strcon1);
                                    string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + txt3BackingBF.Text.Trim().Replace("'", "''") + "','" + txt3BackingGSM.Text.Trim().Replace("'", "''") + "','" + txt3BackingWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt3BackingBFPerPpr.Text.Trim().Replace("'", "''") + "')", con1);
                                    con1.Open();
                                    int A = cmd1.ExecuteNonQuery();
                                    con1.Close();

                                    //Insert For Flute In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon2 = funclib.setConnection();
                                    SqlConnection con2 = new SqlConnection(strcon2);
                                    string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + txt3FluteBF.Text.Trim().Replace("'", "''") + "','" + txt3FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt3FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + Txt3FluteBFPrPPr.Text.Trim().Replace("'", "''") + "')", con2);
                                    con2.Open();
                                    int B = cmd2.ExecuteNonQuery();
                                    con2.Close();
                                    #endregion


                                    #region Insert In 5 PLY
                                    //Insert For Backing In FivePly
                                    funclib = new FunctionLib();
                                    string strcon3 = funclib.setConnection();
                                    SqlConnection con3 = new SqlConnection(strcon3);
                                    string Rid2 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd3 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid2 + "','Backing','" + txt5BackBF.Text.Trim().Replace("'", "''") + "','" + txt5BackGSM.Text.Trim().Replace("'", "''") + "','" + txt5BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con3);
                                    con3.Open();
                                    int C = cmd3.ExecuteNonQuery();
                                    con3.Close();

                                    //Insert For Flute In FivePly
                                    funclib = new FunctionLib();
                                    string strcon4 = funclib.setConnection();
                                    SqlConnection con4 = new SqlConnection(strcon4);
                                    string Rid4 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd4 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid4 + "','Flute','" + txt5FluteBF.Text.Trim().Replace("'", "''").ToString() + "','" + txt5FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt5FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con4);
                                    con4.Open();
                                    int D = cmd4.ExecuteNonQuery();
                                    con4.Close();
                                    #endregion


                                    #region Insert in 7 PLY
                                    //Insert For Backing In 7 Ply
                                    funclib = new FunctionLib();
                                    string strcon5 = funclib.setConnection();
                                    SqlConnection con5 = new SqlConnection(strcon5);
                                    string Rid5 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd5 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid5 + "','Backing','" + txt7BackBF.Text.Trim().Replace("'", "''") + "','" + txt7BackGSM.Text.Trim().Replace("'", "''") + "','" + txt7BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt7BackBFPrppr.Text.Trim().Replace("'", "''") + "')", con5);
                                    con5.Open();
                                    int E = cmd5.ExecuteNonQuery();
                                    con5.Close();

                                    //Insert For Flute In 7 Ply
                                    funclib = new FunctionLib();
                                    string strcon6 = funclib.setConnection();
                                    SqlConnection con6 = new SqlConnection(strcon6);
                                    string Rid6 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd6 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid6 + "','Flute','" + txt7FluteBF.Text.Trim().Replace("'", "''") + "','" + txt7FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt7FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt7BackBFPrppr.Text.Trim().Replace("'", "''") + "')", con6);
                                    con6.Open();
                                    int F = cmd6.ExecuteNonQuery();
                                    con6.Close();
                                    #endregion


                                    #region Insert in 9 PLY
                                    //Insert For Backing In NinePly
                                    funclib = new FunctionLib();
                                    string strcon7 = funclib.setConnection();
                                    SqlConnection con7 = new SqlConnection(strcon7);
                                    string Rid7 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd7 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid7 + "','Backing','" + txt9BackBF.Text.Trim().Replace("'", "''") + "','" + txt9BackGSM.Text.Trim().Replace("'", "''") + "','" + txt9BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt9BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con7);
                                    con7.Open();
                                    int G = cmd7.ExecuteNonQuery();
                                    con7.Close();


                                    //Insert For Flute In NinePly
                                    funclib = new FunctionLib();
                                    string strcon8 = funclib.setConnection();
                                    SqlConnection con8 = new SqlConnection(strcon8);
                                    string Rid8 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd8 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid8 + "','Flute','" + txt9FluteBF.Text.Trim().Replace("'", "''") + "','" + txt9FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt9FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt9FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con8);
                                    con8.Open();
                                    int H = cmd8.ExecuteNonQuery();
                                    con8.Close();
                                    #endregion

                                }

                                //Insert Into Eleven Ply
                                if (ddlPly_Sheet.Text == "11")
                                {
                                    #region Insert In ThreePly
                                    //Insert For Backing In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon1 = funclib.setConnection();
                                    SqlConnection con1 = new SqlConnection(strcon1);
                                    string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + txt3BackingBF.Text.Trim().Replace("'", "''") + "','" + txt3BackingGSM.Text.Trim().Replace("'", "''") + "','" + txt3BackingWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt3BackingBFPerPpr.Text.Trim().Replace("'", "''") + "')", con1);
                                    con1.Open();
                                    int A = cmd1.ExecuteNonQuery();
                                    con1.Close();

                                    //Insert For Flute In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon2 = funclib.setConnection();
                                    SqlConnection con2 = new SqlConnection(strcon2);
                                    string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + txt3FluteBF.Text.Trim().Replace("'", "''") + "','" + txt3FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt3FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + Txt3FluteBFPrPPr.Text.Trim().Replace("'", "''") + "')", con2);
                                    con2.Open();
                                    int B = cmd2.ExecuteNonQuery();
                                    con2.Close();
                                    #endregion


                                    #region Insert In 5 PLY
                                    //Insert For Backing In FivePly
                                    funclib = new FunctionLib();
                                    string strcon3 = funclib.setConnection();
                                    SqlConnection con3 = new SqlConnection(strcon3);
                                    string Rid2 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd3 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid2 + "','Backing','" + txt5BackBF.Text.Trim().Replace("'", "''") + "','" + txt5BackGSM.Text.Trim().Replace("'", "''") + "','" + txt5BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con3);
                                    con3.Open();
                                    int C = cmd3.ExecuteNonQuery();
                                    con3.Close();

                                    //Insert For Flute In FivePly
                                    funclib = new FunctionLib();
                                    string strcon4 = funclib.setConnection();
                                    SqlConnection con4 = new SqlConnection(strcon4);
                                    string Rid4 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd4 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid4 + "','Flute','" + txt5FluteBF.Text.Trim().Replace("'", "''").ToString() + "','" + txt5FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt5FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con4);
                                    con4.Open();
                                    int D = cmd4.ExecuteNonQuery();
                                    con4.Close();
                                    #endregion


                                    #region Insert in 7 PLY
                                    //Insert For Backing In 7 Ply
                                    funclib = new FunctionLib();
                                    string strcon5 = funclib.setConnection();
                                    SqlConnection con5 = new SqlConnection(strcon5);
                                    string Rid5 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd5 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid5 + "','Backing','" + txt7BackBF.Text.Trim().Replace("'", "''") + "','" + txt7BackGSM.Text.Trim().Replace("'", "''") + "','" + txt7BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt7BackBFPrppr.Text.Trim().Replace("'", "''") + "')", con5);
                                    con5.Open();
                                    int E = cmd5.ExecuteNonQuery();
                                    con5.Close();

                                    //Insert For Flute In 7 Ply
                                    funclib = new FunctionLib();
                                    string strcon6 = funclib.setConnection();
                                    SqlConnection con6 = new SqlConnection(strcon6);
                                    string Rid6 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd6 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid6 + "','Flute','" + txt7FluteBF.Text.Trim().Replace("'", "''") + "','" + txt7FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt7FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt7BackBFPrppr.Text.Trim().Replace("'", "''") + "')", con6);
                                    con6.Open();
                                    int F = cmd6.ExecuteNonQuery();
                                    con6.Close();
                                    #endregion


                                    #region Insert in 9 PLY
                                    //Insert For Backing In NinePly
                                    funclib = new FunctionLib();
                                    string strcon7 = funclib.setConnection();
                                    SqlConnection con7 = new SqlConnection(strcon7);
                                    string Rid7 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd7 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid7 + "','Backing','" + txt9BackBF.Text.Trim().Replace("'", "''") + "','" + txt9BackGSM.Text.Trim().Replace("'", "''") + "','" + txt9BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt9BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con7);
                                    con7.Open();
                                    int G = cmd7.ExecuteNonQuery();
                                    con7.Close();


                                    //Insert For Flute In NinePly
                                    funclib = new FunctionLib();
                                    string strcon8 = funclib.setConnection();
                                    SqlConnection con8 = new SqlConnection(strcon8);
                                    string Rid8 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd8 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid8 + "','Flute','" + txt9FluteBF.Text.Trim().Replace("'", "''") + "','" + txt9FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt9FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt9FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con8);
                                    con8.Open();
                                    int H = cmd8.ExecuteNonQuery();
                                    con8.Close();
                                    #endregion


                                    #region Insert in 11 PLY
                                    //Insert For Backing In ElevenPly
                                    funclib = new FunctionLib();
                                    string strcon9 = funclib.setConnection();
                                    SqlConnection con9 = new SqlConnection(strcon9);
                                    string Rid9 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd9 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid9 + "','Backing','" + txt11BackBF.Text.Trim().Replace("'", "''") + "','" + txt11BackGSM.Text.Trim().Replace("'", "''") + "','" + txt11BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt11BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con9);
                                    con9.Open();
                                    int J = cmd9.ExecuteNonQuery();
                                    con9.Close();

                                    //Insert For Flute In ElevenPly
                                    funclib = new FunctionLib();
                                    string strcon10 = funclib.setConnection();
                                    SqlConnection con10 = new SqlConnection(strcon10);
                                    string Rid10 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd10 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid10 + "','Flute','" + txt11FluteBF.Text.Trim().Replace("'", "''") + "','" + txt11FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt11FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt11FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con10);
                                    con10.Open();
                                    int K = cmd10.ExecuteNonQuery();
                                    con10.Close();
                                    #endregion


                                }

                                //Insert Into Thirteen Ply
                                if (ddlPly_Sheet.Text == "13")
                                {
                                    #region Insert In ThreePly
                                    //Insert For Backing In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon1 = funclib.setConnection();
                                    SqlConnection con1 = new SqlConnection(strcon1);
                                    string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + txt3BackingBF.Text.Trim().Replace("'", "''") + "','" + txt3BackingGSM.Text.Trim().Replace("'", "''") + "','" + txt3BackingWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt3BackingBFPerPpr.Text.Trim().Replace("'", "''") + "')", con1);
                                    con1.Open();
                                    int A = cmd1.ExecuteNonQuery();
                                    con1.Close();

                                    //Insert For Flute In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon2 = funclib.setConnection();
                                    SqlConnection con2 = new SqlConnection(strcon2);
                                    string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + txt3FluteBF.Text.Trim().Replace("'", "''") + "','" + txt3FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt3FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + Txt3FluteBFPrPPr.Text.Trim().Replace("'", "''") + "')", con2);
                                    con2.Open();
                                    int B = cmd2.ExecuteNonQuery();
                                    con2.Close();
                                    #endregion


                                    #region Insert In 5 PLY
                                    //Insert For Backing In FivePly
                                    funclib = new FunctionLib();
                                    string strcon3 = funclib.setConnection();
                                    SqlConnection con3 = new SqlConnection(strcon3);
                                    string Rid2 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd3 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid2 + "','Backing','" + txt5BackBF.Text.Trim().Replace("'", "''") + "','" + txt5BackGSM.Text.Trim().Replace("'", "''") + "','" + txt5BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con3);
                                    con3.Open();
                                    int C = cmd3.ExecuteNonQuery();
                                    con3.Close();

                                    //Insert For Flute In FivePly
                                    funclib = new FunctionLib();
                                    string strcon4 = funclib.setConnection();
                                    SqlConnection con4 = new SqlConnection(strcon4);
                                    string Rid4 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd4 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid4 + "','Flute','" + txt5FluteBF.Text.Trim().Replace("'", "''").ToString() + "','" + txt5FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt5FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con4);
                                    con4.Open();
                                    int D = cmd4.ExecuteNonQuery();
                                    con4.Close();
                                    #endregion


                                    #region Insert in 7 PLY
                                    //Insert For Backing In 7 Ply
                                    funclib = new FunctionLib();
                                    string strcon5 = funclib.setConnection();
                                    SqlConnection con5 = new SqlConnection(strcon5);
                                    string Rid5 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd5 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid5 + "','Backing','" + txt7BackBF.Text.Trim().Replace("'", "''") + "','" + txt7BackGSM.Text.Trim().Replace("'", "''") + "','" + txt7BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt7BackBFPrppr.Text.Trim().Replace("'", "''") + "')", con5);
                                    con5.Open();
                                    int E = cmd5.ExecuteNonQuery();
                                    con5.Close();

                                    //Insert For Flute In 7 Ply
                                    funclib = new FunctionLib();
                                    string strcon6 = funclib.setConnection();
                                    SqlConnection con6 = new SqlConnection(strcon6);
                                    string Rid6 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd6 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid6 + "','Flute','" + txt7FluteBF.Text.Trim().Replace("'", "''") + "','" + txt7FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt7FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt7BackBFPrppr.Text.Trim().Replace("'", "''") + "')", con6);
                                    con6.Open();
                                    int F = cmd6.ExecuteNonQuery();
                                    con6.Close();
                                    #endregion


                                    #region Insert in 9 PLY
                                    //Insert For Backing In NinePly
                                    funclib = new FunctionLib();
                                    string strcon7 = funclib.setConnection();
                                    SqlConnection con7 = new SqlConnection(strcon7);
                                    string Rid7 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd7 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid7 + "','Backing','" + txt9BackBF.Text.Trim().Replace("'", "''") + "','" + txt9BackGSM.Text.Trim().Replace("'", "''") + "','" + txt9BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt9BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con7);
                                    con7.Open();
                                    int G = cmd7.ExecuteNonQuery();
                                    con7.Close();


                                    //Insert For Flute In NinePly
                                    funclib = new FunctionLib();
                                    string strcon8 = funclib.setConnection();
                                    SqlConnection con8 = new SqlConnection(strcon8);
                                    string Rid8 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd8 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid8 + "','Flute','" + txt9FluteBF.Text.Trim().Replace("'", "''") + "','" + txt9FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt9FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt9FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con8);
                                    con8.Open();
                                    int H = cmd8.ExecuteNonQuery();
                                    con8.Close();
                                    #endregion


                                    #region Insert in 11 PLY
                                    //Insert For Backing In ElevenPly
                                    funclib = new FunctionLib();
                                    string strcon9 = funclib.setConnection();
                                    SqlConnection con9 = new SqlConnection(strcon9);
                                    string Rid9 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd9 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid9 + "','Backing','" + txt11BackBF.Text.Trim().Replace("'", "''") + "','" + txt11BackGSM.Text.Trim().Replace("'", "''") + "','" + txt11BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt11BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con9);
                                    con9.Open();
                                    int J = cmd9.ExecuteNonQuery();
                                    con9.Close();

                                    //Insert For Flute In ElevenPly
                                    funclib = new FunctionLib();
                                    string strcon10 = funclib.setConnection();
                                    SqlConnection con10 = new SqlConnection(strcon10);
                                    string Rid10 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd10 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid10 + "','Flute','" + txt11FluteBF.Text.Trim().Replace("'", "''") + "','" + txt11FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt11FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt11FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con10);
                                    con10.Open();
                                    int K = cmd10.ExecuteNonQuery();
                                    con10.Close();
                                    #endregion


                                    #region Insert in 13 PLY
                                    //Insert For Backing In 13 Ply
                                    funclib = new FunctionLib();
                                    string strcon11 = funclib.setConnection();
                                    SqlConnection con11 = new SqlConnection(strcon11);
                                    string Rid11 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd11 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid11 + "','Backing','"
                                        + txt13BackBF.Text.Trim().Replace("'", "''") + "','" + txt13BackGSM.Text.Trim().Replace("'", "''") + "','"
                                        + txt13BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt13BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con11);
                                    con11.Open();
                                    int L = cmd11.ExecuteNonQuery();
                                    con11.Close();


                                    //Insert For Flute In 13 Ply
                                    funclib = new FunctionLib();
                                    string strcon12 = funclib.setConnection();
                                    SqlConnection con12 = new SqlConnection(strcon12);
                                    string Rid12 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd12 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid12 + "','Flute','"
                                        + txt13FluteBF.Text.Trim().Replace("'", "''") + "','" + txt13FluteGSM.Text.Trim().Replace("'", "''") + "','"
                                        + txt13FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt13FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con12);
                                    con12.Open();
                                    int M = cmd12.ExecuteNonQuery();
                                    con12.Close();
                                    #endregion
                                }

                                //Insert Into 15 Ply
                                if (ddlPly_Sheet.Text == "15")
                                {
                                    #region Insert In ThreePly
                                    //Insert For Backing In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon1 = funclib.setConnection();
                                    SqlConnection con1 = new SqlConnection(strcon1);
                                    string Rid = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd1 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid + "','Backing','" + txt3BackingBF.Text.Trim().Replace("'", "''") + "','" + txt3BackingGSM.Text.Trim().Replace("'", "''") + "','" + txt3BackingWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt3BackingBFPerPpr.Text.Trim().Replace("'", "''") + "')", con1);
                                    con1.Open();
                                    int A = cmd1.ExecuteNonQuery();
                                    con1.Close();

                                    //Insert For Flute In ThreePly
                                    funclib = new FunctionLib();
                                    string strcon2 = funclib.setConnection();
                                    SqlConnection con2 = new SqlConnection(strcon2);
                                    string Rid1 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd2 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid1 + "','Flute','" + txt3FluteBF.Text.Trim().Replace("'", "''") + "','" + txt3FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt3FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + Txt3FluteBFPrPPr.Text.Trim().Replace("'", "''") + "')", con2);
                                    con2.Open();
                                    int B = cmd2.ExecuteNonQuery();
                                    con2.Close();
                                    #endregion


                                    #region Insert In 5 PLY
                                    //Insert For Backing In FivePly
                                    funclib = new FunctionLib();
                                    string strcon3 = funclib.setConnection();
                                    SqlConnection con3 = new SqlConnection(strcon3);
                                    string Rid2 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd3 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid2 + "','Backing','" + txt5BackBF.Text.Trim().Replace("'", "''") + "','" + txt5BackGSM.Text.Trim().Replace("'", "''") + "','" + txt5BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con3);
                                    con3.Open();
                                    int C = cmd3.ExecuteNonQuery();
                                    con3.Close();

                                    //Insert For Flute In FivePly
                                    funclib = new FunctionLib();
                                    string strcon4 = funclib.setConnection();
                                    SqlConnection con4 = new SqlConnection(strcon4);
                                    string Rid4 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd4 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid4 + "','Flute','" + txt5FluteBF.Text.Trim().Replace("'", "''").ToString() + "','" + txt5FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt5FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt5FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con4);
                                    con4.Open();
                                    int D = cmd4.ExecuteNonQuery();
                                    con4.Close();
                                    #endregion


                                    #region Insert in 7 PLY
                                    //Insert For Backing In 7 Ply
                                    funclib = new FunctionLib();
                                    string strcon5 = funclib.setConnection();
                                    SqlConnection con5 = new SqlConnection(strcon5);
                                    string Rid5 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd5 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid5 + "','Backing','" + txt7BackBF.Text.Trim().Replace("'", "''") + "','" + txt7BackGSM.Text.Trim().Replace("'", "''") + "','" + txt7BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt7BackBFPrppr.Text.Trim().Replace("'", "''") + "')", con5);
                                    con5.Open();
                                    int E = cmd5.ExecuteNonQuery();
                                    con5.Close();

                                    //Insert For Flute In 7 Ply
                                    funclib = new FunctionLib();
                                    string strcon6 = funclib.setConnection();
                                    SqlConnection con6 = new SqlConnection(strcon6);
                                    string Rid6 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd6 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid6 + "','Flute','" + txt7FluteBF.Text.Trim().Replace("'", "''") + "','" + txt7FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt7FluteWtPerPpr.Text.Trim().Replace("'", "''") + "','" + txt7BackBFPrppr.Text.Trim().Replace("'", "''") + "')", con6);
                                    con6.Open();
                                    int F = cmd6.ExecuteNonQuery();
                                    con6.Close();
                                    #endregion


                                    #region Insert in 9 PLY
                                    //Insert For Backing In NinePly
                                    funclib = new FunctionLib();
                                    string strcon7 = funclib.setConnection();
                                    SqlConnection con7 = new SqlConnection(strcon7);
                                    string Rid7 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd7 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid7 + "','Backing','" + txt9BackBF.Text.Trim().Replace("'", "''") + "','" + txt9BackGSM.Text.Trim().Replace("'", "''") + "','" + txt9BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt9BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con7);
                                    con7.Open();
                                    int G = cmd7.ExecuteNonQuery();
                                    con7.Close();


                                    //Insert For Flute In NinePly
                                    funclib = new FunctionLib();
                                    string strcon8 = funclib.setConnection();
                                    SqlConnection con8 = new SqlConnection(strcon8);
                                    string Rid8 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd8 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid8 + "','Flute','" + txt9FluteBF.Text.Trim().Replace("'", "''") + "','" + txt9FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt9FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt9FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con8);
                                    con8.Open();
                                    int H = cmd8.ExecuteNonQuery();
                                    con8.Close();
                                    #endregion


                                    #region Insert in 11 PLY
                                    //Insert For Backing In ElevenPly
                                    funclib = new FunctionLib();
                                    string strcon9 = funclib.setConnection();
                                    SqlConnection con9 = new SqlConnection(strcon9);
                                    string Rid9 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd9 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid9 + "','Backing','" + txt11BackBF.Text.Trim().Replace("'", "''") + "','" + txt11BackGSM.Text.Trim().Replace("'", "''") + "','" + txt11BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt11BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con9);
                                    con9.Open();
                                    int J = cmd9.ExecuteNonQuery();
                                    con9.Close();

                                    //Insert For Flute In ElevenPly
                                    funclib = new FunctionLib();
                                    string strcon10 = funclib.setConnection();
                                    SqlConnection con10 = new SqlConnection(strcon10);
                                    string Rid10 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd10 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid10 + "','Flute','" + txt11FluteBF.Text.Trim().Replace("'", "''") + "','" + txt11FluteGSM.Text.Trim().Replace("'", "''") + "','" + txt11FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt11FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con10);
                                    con10.Open();
                                    int K = cmd10.ExecuteNonQuery();
                                    con10.Close();
                                    #endregion


                                    #region Insert in 13 PLY
                                    //Insert For Backing In 13 Ply
                                    funclib = new FunctionLib();
                                    string strcon11 = funclib.setConnection();
                                    SqlConnection con11 = new SqlConnection(strcon11);
                                    string Rid11 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd11 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid11 + "','Backing','"
                                        + txt13BackBF.Text.Trim().Replace("'", "''") + "','" + txt13BackGSM.Text.Trim().Replace("'", "''") + "','"
                                        + txt13BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt13BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con11);
                                    con11.Open();
                                    int L = cmd11.ExecuteNonQuery();
                                    con11.Close();


                                    //Insert For Flute In 13 Ply
                                    funclib = new FunctionLib();
                                    string strcon12 = funclib.setConnection();
                                    SqlConnection con12 = new SqlConnection(strcon12);
                                    string Rid12 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd12 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid12 + "','Flute','"
                                        + txt13FluteBF.Text.Trim().Replace("'", "''") + "','" + txt13FluteGSM.Text.Trim().Replace("'", "''") + "','"
                                        + txt13FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt13FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con12);
                                    con12.Open();
                                    int M = cmd12.ExecuteNonQuery();
                                    con12.Close();
                                    #endregion


                                    #region Insert in 15 PLY
                                    //Insert For Backing In 15 Ply
                                    funclib = new FunctionLib();
                                    string strcon13 = funclib.setConnection();
                                    SqlConnection con13 = new SqlConnection(strcon13);
                                    string Rid13 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "'  order by Row_ID desc");
                                    SqlCommand cmd13 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid13 + "','Backing','"
                                        + txt13BackBF.Text.Trim().Replace("'", "''") + "','" + txt13BackGSM.Text.Trim().Replace("'", "''") + "','"
                                        + txt13BackWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt13BackBFPrPpr.Text.Trim().Replace("'", "''") + "')", con13);
                                    con13.Open();
                                    int N = cmd13.ExecuteNonQuery();
                                    con13.Close();


                                    //Insert For Flute In 13 Ply
                                    funclib = new FunctionLib();
                                    string strcon14 = funclib.setConnection();
                                    SqlConnection con14 = new SqlConnection(strcon14);
                                    string Rid14 = funclib.RowID("R", con, "select Row_ID from Item_Master_BkFl where I_ID='" + pid + "' order by Row_ID desc");
                                    SqlCommand cmd14 = new SqlCommand("insert into Item_Master_BkFl values('" + pid + "','" + Rid14 + "','Flute','"
                                        + txt13FluteBF.Text.Trim().Replace("'", "''") + "','" + txt13FluteGSM.Text.Trim().Replace("'", "''") + "','"
                                        + txt13FluteWtPrPpr.Text.Trim().Replace("'", "''") + "','" + txt13FluteBFPrPpr.Text.Trim().Replace("'", "''") + "')", con14);
                                    con14.Open();
                                    int O = cmd14.ExecuteNonQuery();
                                    con14.Close();
                                    #endregion
                                }

                                MessageBox.Show("Record Inserted Successfully");
                            }
                            catch (Exception)
                            {
                                bool deleteResult = AddEditDeleteItemMasterData("D", pid);

                                MessageBox.Show("There was an error while inserting data");
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("There was an error while inserting data");
                            return;
                        }
                        con.Close();
                        this.InitializeComponent();
                    }

                    //filldata();
                    clearall();
                    //txtLength_MM.Enabled = true;
                    //txtWidth_MM.Enabled = true;
                    //txtHeight_MM.Enabled = true;
                    txtLength_Inch_Sheet.Enabled = true;
                    txtWidth_Inch_Sheet.Enabled = true;
                    txtNo_Colors.Enabled = true;
                    txtPrntColor_Name.Enabled = true;
                    txtSide_Canvas.Enabled = true;
                    txtCanvColor_Name.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error while inserting data");
                return;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="ItemId"></param>
        /// <returns></returns>
        private bool AddEditDeleteItemMasterData(string action, string ItemId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("I_ID", ItemId);
                dictionaryInstance.Add("Grp_ID", Group_ID);
                dictionaryInstance.Add("P_ID", Convert.ToString(ddlParty.SelectedValue));
                dictionaryInstance.Add("Product_Code", funclib.FirstCap(txtProductCode.Text));
                dictionaryInstance.Add("I_Name", funclib.FirstCap(txtI_Name.Text));
                dictionaryInstance.Add("Ply_Sheet", Convert.ToString(ddlPly_Sheet.Text));
                dictionaryInstance.Add("Box_Measurement_Unit", Convert.ToString(cmbUnits.Text));
                dictionaryInstance.Add("Length_Inch", Convert.ToString(txtBoxLength.Text));
                dictionaryInstance.Add("Width_Inch", Convert.ToString(txtBoxWidth.Text));
                dictionaryInstance.Add("Height_Inch", Convert.ToString(txtBoxHeight.Text));
                dictionaryInstance.Add("Length_MM_Conv", Convert.ToString(txtBoxLength_Conv.Text));
                dictionaryInstance.Add("Width_MM_Conv", Convert.ToString(txtBoxWidth_Conv.Text));
                dictionaryInstance.Add("Height_MM_Conv", Convert.ToString(txtBoxHeight_Conv.Text));
                if (chkBoxConvInside.Checked == true)
                {
                    dictionaryInstance.Add("Box_Conv_Inside", "Yes");
                    dictionaryInstance.Add("Box_Conv_Outside", "No");
                }
                else
                {
                    dictionaryInstance.Add("Box_Conv_Inside", "Yes");
                    dictionaryInstance.Add("Box_Conv_Outside", "No");
                }

                dictionaryInstance.Add("Length_Inch_Sheet", Convert.ToString(txtLength_Inch_Sheet.Text));
                dictionaryInstance.Add("Width_Inch_Sheet", Convert.ToString(txtWidth_Inch_Sheet.Text));
                dictionaryInstance.Add("EF_NF_PC", Convert.ToString(ddlEF_NF_PC.Text));
                dictionaryInstance.Add("Bundle_Packet", txtBundle_Packet.Text);
                dictionaryInstance.Add("txtBox_PerSheet", Convert.ToString(txtBox_PerSheet.Text));
                dictionaryInstance.Add("ddlCorrugation_Opt", Convert.ToString(ddlCorrugation_Opt.Text));
                dictionaryInstance.Add("ddlPaper_Cutting", Convert.ToString(ddlPaper_Cutting.Text));
                dictionaryInstance.Add("ddlPrinting_Opt", Convert.ToString(ddlPrinting_Opt.Text));
                dictionaryInstance.Add("txtNo_Colors", txtNo_Colors.Text);
                dictionaryInstance.Add("txtPrntColor_Name", Convert.ToString(txtPrntColor_Name.Text));
                dictionaryInstance.Add("ddlPaper_Printed", Convert.ToString(ddlPaper_Printed.Text));
                dictionaryInstance.Add("ddlTP_ID", Convert.ToString(ddlTP_ID.SelectedValue));
                dictionaryInstance.Add("ddlScoring_Opt", Convert.ToString(ddlScoring_Opt.Text));
                dictionaryInstance.Add("ddlPunching_Opt", Convert.ToString(ddlPunching_Opt.Text));
                dictionaryInstance.Add("ddlPasting_Opt", Convert.ToString(ddlPasting_Opt.Text));
                dictionaryInstance.Add("ddlSlotting_Opt", Convert.ToString(ddlSlotting_Opt.Text));
                dictionaryInstance.Add("ddlPinning_Opt", Convert.ToString(ddlPinning_Opt.Text));
                dictionaryInstance.Add("txtNo_Pins", txtNo_Pins.Text);
                dictionaryInstance.Add("ddlPinning_InOut", Convert.ToString(ddlPinning_InOut.Text));
                dictionaryInstance.Add("ddlSide_Pasting", Convert.ToString(ddlSide_Pasting.Text));
                dictionaryInstance.Add("txtRate_SidePastg", Convert.ToString(txtRate_SidePastg.Text));
                dictionaryInstance.Add("ddlCanvas_Opt", Convert.ToString(ddlCanvas_Opt.Text));
                dictionaryInstance.Add("txtSide_Canvas", Convert.ToString(txtSide_Canvas.Text));
                dictionaryInstance.Add("txtCanvColor_Name", Convert.ToString(txtCanvColor_Name.Text));
                dictionaryInstance.Add("txtSell_Rate", Convert.ToString(txtSell_Rate.Text));
                dictionaryInstance.Add("ddlRate_Type", Convert.ToString(ddlRate_Type.Text));
                dictionaryInstance.Add("txtExcise_Code", txtExcise_Code.Text);
                dictionaryInstance.Add("txtTopBF", Convert.ToString(txtTopBF.Text));
                dictionaryInstance.Add("txtTopGSM", Convert.ToString(txtTopGSM.Text));
                dictionaryInstance.Add("txtTopWtPerPpr", txtTopWtPerPpr.Text);
                dictionaryInstance.Add("txtTopBfPerPpr", txtTopBfPerPpr.Text);
                dictionaryInstance.Add("txtWeight_Pcs", Convert.ToString(txtWeight_Pcs.Text));
                dictionaryInstance.Add("txtBF_Pcs", Convert.ToString(txtBF_Pcs.Text));
                dictionaryInstance.Add("txtArtWrk_Code", Convert.ToString(txtArtWrk_Code.Text));
                dictionaryInstance.Add("txtRevi_No", Convert.ToString(txtRevi_No.Text));
                dictionaryInstance.Add("txtArt_Dt", Convert.ToString(txtArt_Dt.Text));
                dictionaryInstance.Add("txtSpeci_Code", Convert.ToString(txtSpeci_Code.Text));
                dictionaryInstance.Add("ddlFor_Pedilite", Convert.ToString(ddlFor_Pedilite.Text));
                dictionaryInstance.Add("txtPedilite_BS", Convert.ToString(txtPedilite_BS.Text));
                dictionaryInstance.Add("txtPedilite_GSM", Convert.ToString(txtPedilite_GSM.Text));
                dictionaryInstance.Add("txtPedilite_WtBox", Convert.ToString(txtPedilite_WtBox.Text));
                dictionaryInstance.Add("Pedilite_PReq", Convert.ToString(Pedilite_PReq.Text));
                dictionaryInstance.Add("ddlI_Active", Convert.ToString(ddlI_Active.Text));
                dictionaryInstance.Add("User", Convert.ToString(strSession));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeleteItemMasterData(dictionaryInstance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgwMasterItem_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlI_Active.Enabled = true;

            txtI_ID.Text = dgwMasterItem.Rows[e.RowIndex].Cells[0].Value.ToString();
            ddlParty.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtProductCode.Text = dgwMasterItem.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtI_Name.Text = dgwMasterItem.Rows[e.RowIndex].Cells[4].Value.ToString();
            ddlPly_Sheet.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[5].Value.ToString();

            if (ddlPly_Sheet.Text == "1" || ddlPly_Sheet.Text == "2")
            {
                ShowHideFieldsFor1n2Ply();
            }
            else if (ddlPly_Sheet.Text == "3")
            {
                ShowHideFieldsFor3Ply();

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con3 = new SqlConnection(strcon);
                con3.Open();
                SqlDataAdapter da3 = new SqlDataAdapter("select BF_Value,GSM_Value,WPP_Value,BFPP_Value from Item_Master_BkFl where I_ID='" + txtI_ID.Text + "'", con3);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);

                if (dt3 != null)
                {
                    if (dt3.Rows.Count > 0)
                    {
                        txt3BackingBF.Text = Convert.ToString(dt3.Rows[0][0]);
                        txt3BackingGSM.Text = Convert.ToString(dt3.Rows[0][1]);
                        txt3BackingWtPerPpr.Text = Convert.ToString(dt3.Rows[0][2]);
                        txt3BackingBFPerPpr.Text = Convert.ToString(dt3.Rows[0][3]);

                        txt3FluteBF.Text = Convert.ToString(dt3.Rows[1][0]);
                        txt3FluteGSM.Text = Convert.ToString(dt3.Rows[1][1]);
                        txt3FluteWtPerPpr.Text = Convert.ToString(dt3.Rows[1][2]);
                        Txt3FluteBFPrPPr.Text = Convert.ToString(dt3.Rows[1][3]);                       
                    }
                }
                con3.Close();
            }
            else if (ddlPly_Sheet.Text == "5")
            {
                ShowHideFieldsFor5Ply();

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con5 = new SqlConnection(strcon);
                con5.Open();
                SqlDataAdapter da5 = new SqlDataAdapter("select BF_Value,GSM_Value,WPP_Value,BFPP_Value from Item_Master_BkFl where I_ID='" + txtI_ID.Text + "'", con5);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);

                if (dt5 != null)
                {
                    if (dt5.Rows.Count > 0)
                    {
                        txt3BackingBF.Text = Convert.ToString(dt5.Rows[0][0]);
                        txt3BackingGSM.Text = Convert.ToString(dt5.Rows[0][1]);
                        txt3BackingWtPerPpr.Text = Convert.ToString(dt5.Rows[0][2]);
                        txt3BackingBFPerPpr.Text = Convert.ToString(dt5.Rows[0][3]);

                        txt3FluteBF.Text = Convert.ToString(dt5.Rows[1][0]);
                        txt3FluteGSM.Text = Convert.ToString(dt5.Rows[1][1]);
                        txt3FluteWtPerPpr.Text = Convert.ToString(dt5.Rows[1][2]);
                        Txt3FluteBFPrPPr.Text = Convert.ToString(dt5.Rows[1][3]);

                        txt5BackBF.Text = Convert.ToString(dt5.Rows[2][0]);
                        txt5BackGSM.Text = Convert.ToString(dt5.Rows[2][1]);
                        txt5BackWtPrPpr.Text = Convert.ToString(dt5.Rows[2][2]);
                        txt5BackBFPrPpr.Text = Convert.ToString(dt5.Rows[2][3]);

                        txt5FluteBF.Text = Convert.ToString(dt5.Rows[3][0]);
                        txt5FluteGSM.Text = Convert.ToString(dt5.Rows[3][1]);
                        txt5FluteWtPrPpr.Text = Convert.ToString(dt5.Rows[3][2]);
                        txt5FluteBFPrPpr.Text = Convert.ToString(dt5.Rows[3][3]);
                    }
                }
                con5.Close();                
            }
            else if (ddlPly_Sheet.Text == "7")
            {
                ShowHideFieldsFor7Ply();

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con7 = new SqlConnection(strcon);
                con7.Open();
                SqlDataAdapter da7 = new SqlDataAdapter("select BF_Value,GSM_Value,WPP_Value,BFPP_Value from Item_Master_BkFl where I_ID='" + txtI_ID.Text + "'", con7);
                DataTable dt7 = new DataTable();
                da7.Fill(dt7);

                if (dt7 != null)
                {
                    if (dt7.Rows.Count > 0)
                    {
                        txt3BackingBF.Text = Convert.ToString(dt7.Rows[0][0]);
                        txt3BackingGSM.Text = Convert.ToString(dt7.Rows[0][1]);
                        txt3BackingWtPerPpr.Text = Convert.ToString(dt7.Rows[0][2]);
                        txt3BackingBFPerPpr.Text = Convert.ToString(dt7.Rows[0][3]);

                        txt3FluteBF.Text = Convert.ToString(dt7.Rows[1][0]);
                        txt3FluteGSM.Text = Convert.ToString(dt7.Rows[1][1]);
                        txt3FluteWtPerPpr.Text = Convert.ToString(dt7.Rows[1][2]);
                        Txt3FluteBFPrPPr.Text = Convert.ToString(dt7.Rows[1][3]);

                        txt5BackBF.Text = Convert.ToString(dt7.Rows[2][0]);
                        txt5BackGSM.Text = Convert.ToString(dt7.Rows[2][1]);
                        txt5BackWtPrPpr.Text = Convert.ToString(dt7.Rows[2][2]);
                        txt5BackBFPrPpr.Text = Convert.ToString(dt7.Rows[2][3]);

                        txt5FluteBF.Text = Convert.ToString(dt7.Rows[3][0]);
                        txt5FluteGSM.Text = Convert.ToString(dt7.Rows[3][1]);
                        txt5FluteWtPrPpr.Text = Convert.ToString(dt7.Rows[3][2]);
                        txt5FluteBFPrPpr.Text = Convert.ToString(dt7.Rows[3][3]);

                        txt7BackBF.Text = Convert.ToString(dt7.Rows[4][0]);
                        txt7BackGSM.Text = Convert.ToString(dt7.Rows[4][1]);
                        txt7BackWtPrPpr.Text = Convert.ToString(dt7.Rows[4][2]);
                        txt7BackBFPrppr.Text = Convert.ToString(dt7.Rows[4][3]);

                        txt7FluteBF.Text = Convert.ToString(dt7.Rows[5][0]);
                        txt7FluteGSM.Text = Convert.ToString(dt7.Rows[5][1]);
                        txt7FluteWtPerPpr.Text = Convert.ToString(dt7.Rows[5][2]);
                        txt7FluteBFPrPpr.Text = Convert.ToString(dt7.Rows[5][3]);                     
                    }
                }
                con7.Close();
            }
            else if (ddlPly_Sheet.Text == "9")
            {
                ShowHideFieldsFor9Ply();

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con9 = new SqlConnection(strcon);
                con9.Open();
                SqlDataAdapter da9 = new SqlDataAdapter("select BF_Value,GSM_Value,WPP_Value,BFPP_Value from Item_Master_BkFl where I_ID='" + txtI_ID.Text + "'", con9);
                DataTable dt9 = new DataTable();
                da9.Fill(dt9);

                if (dt9 != null)
                {
                    if (dt9.Rows.Count > 0)
                    {
                        txt3BackingBF.Text = Convert.ToString(dt9.Rows[0][0]);
                        txt3BackingGSM.Text = Convert.ToString(dt9.Rows[0][1]);
                        txt3BackingWtPerPpr.Text = Convert.ToString(dt9.Rows[0][2]);
                        txt3BackingBFPerPpr.Text = Convert.ToString(dt9.Rows[0][3]);

                        txt3FluteBF.Text = Convert.ToString(dt9.Rows[1][0]);
                        txt3FluteGSM.Text = Convert.ToString(dt9.Rows[1][1]);
                        txt3FluteWtPerPpr.Text = Convert.ToString(dt9.Rows[1][2]);
                        Txt3FluteBFPrPPr.Text = Convert.ToString(dt9.Rows[1][3]);

                        txt5BackBF.Text = Convert.ToString(dt9.Rows[2][0]);
                        txt5BackGSM.Text = Convert.ToString(dt9.Rows[2][1]);
                        txt5BackWtPrPpr.Text = Convert.ToString(dt9.Rows[2][2]);
                        txt5BackBFPrPpr.Text = Convert.ToString(dt9.Rows[2][3]);

                        txt5FluteBF.Text = Convert.ToString(dt9.Rows[3][0]);
                        txt5FluteGSM.Text = Convert.ToString(dt9.Rows[3][1]);
                        txt5FluteWtPrPpr.Text = Convert.ToString(dt9.Rows[3][2]);
                        txt5FluteBFPrPpr.Text = Convert.ToString(dt9.Rows[3][3]);

                        txt7BackBF.Text = Convert.ToString(dt9.Rows[4][0]);
                        txt7BackGSM.Text = Convert.ToString(dt9.Rows[4][1]);
                        txt7BackWtPrPpr.Text = Convert.ToString(dt9.Rows[4][2]);
                        txt7BackBFPrppr.Text = Convert.ToString(dt9.Rows[4][3]);

                        txt7FluteBF.Text = Convert.ToString(dt9.Rows[5][0]);
                        txt7FluteGSM.Text = Convert.ToString(dt9.Rows[5][1]);
                        txt7FluteWtPerPpr.Text = Convert.ToString(dt9.Rows[5][2]);
                        txt7FluteBFPrPpr.Text = Convert.ToString(dt9.Rows[5][3]);

                        txt9BackBF.Text = Convert.ToString(dt9.Rows[6][0]);
                        txt9BackGSM.Text = Convert.ToString(dt9.Rows[6][1]);
                        txt9BackWtPrPpr.Text = Convert.ToString(dt9.Rows[6][2]);
                        txt9BackBFPrPpr.Text = Convert.ToString(dt9.Rows[6][3]);

                        txt9FluteBF.Text = Convert.ToString(dt9.Rows[7][0]);
                        txt9FluteGSM.Text = Convert.ToString(dt9.Rows[7][1]);
                        txt9FluteWtPrPpr.Text = Convert.ToString(dt9.Rows[7][2]);
                        txt9FluteBFPrPpr.Text = Convert.ToString(dt9.Rows[7][3]);                        
                    }
                }
                con9.Close();
            }
            else if (ddlPly_Sheet.Text == "11")
            {
                ShowHideFieldsFor11Ply();

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con11 = new SqlConnection(strcon);
                con11.Open();
                SqlDataAdapter da11 = new SqlDataAdapter("select BF_Value,GSM_Value,WPP_Value,BFPP_Value from Item_Master_BkFl where I_ID='" + txtI_ID.Text + "'", con11);
                DataTable dt11 = new DataTable();
                da11.Fill(dt11);

                if (dt11 != null)
                {
                    if (dt11.Rows.Count > 0)
                    {
                        txt3BackingBF.Text = Convert.ToString(dt11.Rows[0][0]);
                        txt3BackingGSM.Text = Convert.ToString(dt11.Rows[0][1]);
                        txt3BackingWtPerPpr.Text = Convert.ToString(dt11.Rows[0][2]);
                        txt3BackingBFPerPpr.Text = Convert.ToString(dt11.Rows[0][3]);

                        txt3FluteBF.Text = Convert.ToString(dt11.Rows[1][0]);
                        txt3FluteGSM.Text = Convert.ToString(dt11.Rows[1][1]);
                        txt3FluteWtPerPpr.Text = Convert.ToString(dt11.Rows[1][2]);
                        Txt3FluteBFPrPPr.Text = Convert.ToString(dt11.Rows[1][3]);

                        txt5BackBF.Text = Convert.ToString(dt11.Rows[2][0]);
                        txt5BackGSM.Text = Convert.ToString(dt11.Rows[2][1]);
                        txt5BackWtPrPpr.Text = Convert.ToString(dt11.Rows[2][2]);
                        txt5BackBFPrPpr.Text = Convert.ToString(dt11.Rows[2][3]);

                        txt5FluteBF.Text = Convert.ToString(dt11.Rows[3][0]);
                        txt5FluteGSM.Text = Convert.ToString(dt11.Rows[3][1]);
                        txt5FluteWtPrPpr.Text = Convert.ToString(dt11.Rows[3][2]);
                        txt5FluteBFPrPpr.Text = Convert.ToString(dt11.Rows[3][3]);

                        txt7BackBF.Text = Convert.ToString(dt11.Rows[4][0]);
                        txt7BackGSM.Text = Convert.ToString(dt11.Rows[4][1]);
                        txt7BackWtPrPpr.Text = Convert.ToString(dt11.Rows[4][2]);
                        txt7BackBFPrppr.Text = Convert.ToString(dt11.Rows[4][3]);

                        txt7FluteBF.Text = Convert.ToString(dt11.Rows[5][0]);
                        txt7FluteGSM.Text = Convert.ToString(dt11.Rows[5][1]);
                        txt7FluteWtPerPpr.Text = Convert.ToString(dt11.Rows[5][2]);
                        txt7FluteBFPrPpr.Text = Convert.ToString(dt11.Rows[5][3]);

                        txt9BackBF.Text = Convert.ToString(dt11.Rows[6][0]);
                        txt9BackGSM.Text = Convert.ToString(dt11.Rows[6][1]);
                        txt9BackWtPrPpr.Text = Convert.ToString(dt11.Rows[6][2]);
                        txt9BackBFPrPpr.Text = Convert.ToString(dt11.Rows[6][3]);

                        txt9FluteBF.Text = Convert.ToString(dt11.Rows[7][0]);
                        txt9FluteGSM.Text = Convert.ToString(dt11.Rows[7][1]);
                        txt9FluteWtPrPpr.Text = Convert.ToString(dt11.Rows[7][2]);
                        txt9FluteBFPrPpr.Text = Convert.ToString(dt11.Rows[7][3]);

                        txt11BackBF.Text = Convert.ToString(dt11.Rows[8][0]);
                        txt11BackGSM.Text = Convert.ToString(dt11.Rows[8][1]);
                        txt11BackWtPrPpr.Text = Convert.ToString(dt11.Rows[8][2]);
                        txt11BackBFPrPpr.Text = Convert.ToString(dt11.Rows[8][3]);

                        txt11FluteBF.Text = Convert.ToString(dt11.Rows[9][0]);
                        txt11FluteGSM.Text = Convert.ToString(dt11.Rows[9][1]);
                        txt11FluteWtPrPpr.Text = Convert.ToString(dt11.Rows[9][2]);
                        txt11FluteBFPrPpr.Text = Convert.ToString(dt11.Rows[9][3]);                 
                    }
                }
                con11.Close();
            }
            else if (ddlPly_Sheet.Text == "13")
            {
                ShowHideFieldsFor13Ply();

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con13 = new SqlConnection(strcon);
                con13.Open();
                SqlDataAdapter da13 = new SqlDataAdapter("select BF_Value,GSM_Value,WPP_Value,BFPP_Value from Item_Master_BkFl where I_ID='" + txtI_ID.Text + "'", con13);
                DataTable dt13 = new DataTable();
                da13.Fill(dt13);

                if (dt13 != null)
                {
                    if (dt13.Rows.Count > 0)
                    {
                        txt3BackingBF.Text = Convert.ToString(dt13.Rows[0][0]);
                        txt3BackingGSM.Text = Convert.ToString(dt13.Rows[0][1]);
                        txt3BackingWtPerPpr.Text = Convert.ToString(dt13.Rows[0][2]);
                        txt3BackingBFPerPpr.Text = Convert.ToString(dt13.Rows[0][3]);

                        txt3FluteBF.Text = Convert.ToString(dt13.Rows[1][0]);
                        txt3FluteGSM.Text = Convert.ToString(dt13.Rows[1][1]);
                        txt3FluteWtPerPpr.Text = Convert.ToString(dt13.Rows[1][2]);
                        Txt3FluteBFPrPPr.Text = Convert.ToString(dt13.Rows[1][3]);

                        txt5BackBF.Text = Convert.ToString(dt13.Rows[2][0]);
                        txt5BackGSM.Text = Convert.ToString(dt13.Rows[2][1]);
                        txt5BackWtPrPpr.Text = Convert.ToString(dt13.Rows[2][2]);
                        txt5BackBFPrPpr.Text = Convert.ToString(dt13.Rows[2][3]);

                        txt5FluteBF.Text = Convert.ToString(dt13.Rows[3][0]);
                        txt5FluteGSM.Text = Convert.ToString(dt13.Rows[3][1]);
                        txt5FluteWtPrPpr.Text = Convert.ToString(dt13.Rows[3][2]);
                        txt5FluteBFPrPpr.Text = Convert.ToString(dt13.Rows[3][3]);

                        txt7BackBF.Text = Convert.ToString(dt13.Rows[4][0]);
                        txt7BackGSM.Text = Convert.ToString(dt13.Rows[4][1]);
                        txt7BackWtPrPpr.Text = Convert.ToString(dt13.Rows[4][2]);
                        txt7BackBFPrppr.Text = Convert.ToString(dt13.Rows[4][3]);

                        txt7FluteBF.Text = Convert.ToString(dt13.Rows[5][0]);
                        txt7FluteGSM.Text = Convert.ToString(dt13.Rows[5][1]);
                        txt7FluteWtPerPpr.Text = Convert.ToString(dt13.Rows[5][2]);
                        txt7FluteBFPrPpr.Text = Convert.ToString(dt13.Rows[5][3]);

                        txt9BackBF.Text = Convert.ToString(dt13.Rows[6][0]);
                        txt9BackGSM.Text = Convert.ToString(dt13.Rows[6][1]);
                        txt9BackWtPrPpr.Text = Convert.ToString(dt13.Rows[6][2]);
                        txt9BackBFPrPpr.Text = Convert.ToString(dt13.Rows[6][3]);

                        txt9FluteBF.Text = Convert.ToString(dt13.Rows[7][0]);
                        txt9FluteGSM.Text = Convert.ToString(dt13.Rows[7][1]);
                        txt9FluteWtPrPpr.Text = Convert.ToString(dt13.Rows[7][2]);
                        txt9FluteBFPrPpr.Text = Convert.ToString(dt13.Rows[7][3]);

                        txt11BackBF.Text = Convert.ToString(dt13.Rows[8][0]);
                        txt11BackGSM.Text = Convert.ToString(dt13.Rows[8][1]);
                        txt11BackWtPrPpr.Text = Convert.ToString(dt13.Rows[8][2]);
                        txt11BackBFPrPpr.Text = Convert.ToString(dt13.Rows[8][3]);

                        txt11FluteBF.Text = Convert.ToString(dt13.Rows[9][0]);
                        txt11FluteGSM.Text = Convert.ToString(dt13.Rows[9][1]);
                        txt11FluteWtPrPpr.Text = Convert.ToString(dt13.Rows[9][2]);
                        txt11FluteBFPrPpr.Text = Convert.ToString(dt13.Rows[9][3]);

                        txt13BackBF.Text = Convert.ToString(dt13.Rows[10][0]);
                        txt13BackGSM.Text = Convert.ToString(dt13.Rows[10][1]);
                        txt13BackWtPrPpr.Text = Convert.ToString(dt13.Rows[10][2]);
                        txt13BackBFPrPpr.Text = Convert.ToString(dt13.Rows[10][3]);

                        txt13FluteBF.Text = Convert.ToString(dt13.Rows[11][0]);
                        txt13FluteGSM.Text = Convert.ToString(dt13.Rows[11][1]);
                        txt13FluteWtPrPpr.Text = Convert.ToString(dt13.Rows[11][2]);
                        txt13FluteBFPrPpr.Text = Convert.ToString(dt13.Rows[11][3]);                       
                    }
                }
                con13.Close();
            }
            else if (ddlPly_Sheet.Text == "15")
            {
                ShowHideFieldsFor15Ply();

                funclib = new FunctionLib();
                string strcon = funclib.setConnection();
                SqlConnection con15 = new SqlConnection(strcon);
                con15.Open();
                SqlDataAdapter da15 = new SqlDataAdapter("select BF_Value,GSM_Value,WPP_Value,BFPP_Value from Item_Master_BkFl where I_ID='" + txtI_ID.Text + "'", con15);
                DataTable dt15 = new DataTable();
                da15.Fill(dt15);

                if (dt15 != null)
                {
                    if (dt15.Rows.Count > 0)
                    {
                        txt3BackingBF.Text = Convert.ToString(dt15.Rows[0][0]);
                        txt3BackingGSM.Text = Convert.ToString(dt15.Rows[0][1]);
                        txt3BackingWtPerPpr.Text = Convert.ToString(dt15.Rows[0][2]);
                        txt3BackingBFPerPpr.Text = Convert.ToString(dt15.Rows[0][3]);

                        txt3FluteBF.Text = Convert.ToString(dt15.Rows[1][0]);
                        txt3FluteGSM.Text = Convert.ToString(dt15.Rows[1][1]);
                        txt3FluteWtPerPpr.Text = Convert.ToString(dt15.Rows[1][2]);
                        Txt3FluteBFPrPPr.Text = Convert.ToString(dt15.Rows[1][3]);

                        txt5BackBF.Text = Convert.ToString(dt15.Rows[2][0]);
                        txt5BackGSM.Text = Convert.ToString(dt15.Rows[2][1]);
                        txt5BackWtPrPpr.Text = Convert.ToString(dt15.Rows[2][2]);
                        txt5BackBFPrPpr.Text = Convert.ToString(dt15.Rows[2][3]);

                        txt5FluteBF.Text = Convert.ToString(dt15.Rows[3][0]);
                        txt5FluteGSM.Text = Convert.ToString(dt15.Rows[3][1]);
                        txt5FluteWtPrPpr.Text = Convert.ToString(dt15.Rows[3][2]);
                        txt5FluteBFPrPpr.Text = Convert.ToString(dt15.Rows[3][3]);

                        txt7BackBF.Text = Convert.ToString(dt15.Rows[4][0]);
                        txt7BackGSM.Text = Convert.ToString(dt15.Rows[4][1]);
                        txt7BackWtPrPpr.Text = Convert.ToString(dt15.Rows[4][2]);
                        txt7BackBFPrppr.Text = Convert.ToString(dt15.Rows[4][3]);

                        txt7FluteBF.Text = Convert.ToString(dt15.Rows[5][0]);
                        txt7FluteGSM.Text = Convert.ToString(dt15.Rows[5][1]);
                        txt7FluteWtPerPpr.Text = Convert.ToString(dt15.Rows[5][2]);
                        txt7FluteBFPrPpr.Text = Convert.ToString(dt15.Rows[5][3]);

                        txt9BackBF.Text = Convert.ToString(dt15.Rows[6][0]);
                        txt9BackGSM.Text = Convert.ToString(dt15.Rows[6][1]);
                        txt9BackWtPrPpr.Text = Convert.ToString(dt15.Rows[6][2]);
                        txt9BackBFPrPpr.Text = Convert.ToString(dt15.Rows[6][3]);

                        txt9FluteBF.Text = Convert.ToString(dt15.Rows[7][0]);
                        txt9FluteGSM.Text = Convert.ToString(dt15.Rows[7][1]);
                        txt9FluteWtPrPpr.Text = Convert.ToString(dt15.Rows[7][2]);
                        txt9FluteBFPrPpr.Text = Convert.ToString(dt15.Rows[7][3]);

                        txt11BackBF.Text = Convert.ToString(dt15.Rows[8][0]);
                        txt11BackGSM.Text = Convert.ToString(dt15.Rows[8][1]);
                        txt11BackWtPrPpr.Text = Convert.ToString(dt15.Rows[8][2]);
                        txt11BackBFPrPpr.Text = Convert.ToString(dt15.Rows[8][3]);

                        txt11FluteBF.Text = Convert.ToString(dt15.Rows[9][0]);
                        txt11FluteGSM.Text = Convert.ToString(dt15.Rows[9][1]);
                        txt11FluteWtPrPpr.Text = Convert.ToString(dt15.Rows[9][2]);
                        txt11FluteBFPrPpr.Text = Convert.ToString(dt15.Rows[9][3]);

                        txt13BackBF.Text = Convert.ToString(dt15.Rows[10][0]);
                        txt13BackGSM.Text = Convert.ToString(dt15.Rows[10][1]);
                        txt13BackWtPrPpr.Text = Convert.ToString(dt15.Rows[10][2]);
                        txt13BackBFPrPpr.Text = Convert.ToString(dt15.Rows[10][3]);

                        txt13FluteBF.Text = Convert.ToString(dt15.Rows[11][0]);
                        txt13FluteGSM.Text = Convert.ToString(dt15.Rows[11][1]);
                        txt13FluteWtPrPpr.Text = Convert.ToString(dt15.Rows[11][2]);
                        txt13FluteBFPrPpr.Text = Convert.ToString(dt15.Rows[11][3]);

                        txt15BackBF.Text = Convert.ToString(dt15.Rows[12][0]);
                        txt15BackGSM.Text = Convert.ToString(dt15.Rows[12][1]);
                        txt15BackWtPrPpr.Text = Convert.ToString(dt15.Rows[12][2]);
                        txt15BackBFPrPpr.Text = Convert.ToString(dt15.Rows[12][3]);

                        txt15FluteBF.Text = Convert.ToString(dt15.Rows[13][0]);
                        txt15FluteGSM.Text = Convert.ToString(dt15.Rows[13][1]);
                        txt15FluteWtPrPpr.Text = Convert.ToString(dt15.Rows[13][2]);
                        txt15FluteBFPrPpr.Text = Convert.ToString(dt15.Rows[13][3]);
                    }
                }
                con15.Close();
            }

            cmbUnits.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[6].Value.ToString();

            txtBoxLength.Text = dgwMasterItem.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtBoxWidth.Text = dgwMasterItem.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtBoxHeight.Text = dgwMasterItem.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtBoxLength_Conv.Text = dgwMasterItem.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtBoxWidth_Conv.Text = dgwMasterItem.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtBoxHeight_Conv.Text = dgwMasterItem.Rows[e.RowIndex].Cells[12].Value.ToString();

            if (dgwMasterItem.Rows[e.RowIndex].Cells[13].Value.ToString() == "Yes")
            {
                chkBoxConvInside.Checked = true;
                ChkBoxConvOutside.Checked = false;
            }
            if (dgwMasterItem.Rows[e.RowIndex].Cells[14].Value.ToString() == "Yes")
            {
                chkBoxConvInside.Checked = false;
                ChkBoxConvOutside.Checked = true;
            }
            //chkBoxConvInside.Text = dgwMasterItem.Rows[e.RowIndex].Cells[13].Value.ToString();
            //ChkBoxConvOutside.Text = dgwMasterItem.Rows[e.RowIndex].Cells[14].Value.ToString();

            txtLength_Inch_Sheet.Text = dgwMasterItem.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtWidth_Inch_Sheet.Text = dgwMasterItem.Rows[e.RowIndex].Cells[16].Value.ToString();

            ddlEF_NF_PC.Text = dgwMasterItem.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtBundle_Packet.Text = dgwMasterItem.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtBox_PerSheet.Text = dgwMasterItem.Rows[e.RowIndex].Cells[19].Value.ToString();
            ddlCorrugation_Opt.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[20].Value.ToString();
            ddlPaper_Cutting.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[21].Value.ToString();
            ddlPrinting_Opt.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[22].Value.ToString();
            txtNo_Colors.Text = dgwMasterItem.Rows[e.RowIndex].Cells[23].Value.ToString();

            txtPrntColor_Name.Text = dgwMasterItem.Rows[e.RowIndex].Cells[24].Value.ToString();
            ddlPaper_Printed.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[25].Value.ToString();
            ddlTP_ID.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[26].Value.ToString();
            ddlScoring_Opt.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[27].Value.ToString();
            ddlPunching_Opt.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[28].Value.ToString();
            ddlPasting_Opt.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[29].Value.ToString();
            ddlSlotting_Opt.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[30].Value.ToString();

            ddlPinning_Opt.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[31].Value.ToString();
            txtNo_Pins.Text = dgwMasterItem.Rows[e.RowIndex].Cells[32].Value.ToString();
            ddlPinning_InOut.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[33].Value.ToString();

            ddlSide_Pasting.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[34].Value.ToString();
            txtRate_SidePastg.Text = dgwMasterItem.Rows[e.RowIndex].Cells[35].Value.ToString();
            ddlCanvas_Opt.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[36].Value.ToString();
            txtSide_Canvas.Text = dgwMasterItem.Rows[e.RowIndex].Cells[37].Value.ToString();

            txtCanvColor_Name.Text = dgwMasterItem.Rows[e.RowIndex].Cells[38].Value.ToString();
            txtSell_Rate.Text = dgwMasterItem.Rows[e.RowIndex].Cells[39].Value.ToString();
            ddlRate_Type.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[40].Value.ToString();

            txtExcise_Code.Text = dgwMasterItem.Rows[e.RowIndex].Cells[41].Value.ToString();

            txtTopBF.Text = dgwMasterItem.Rows[e.RowIndex].Cells[42].Value.ToString();
            txtTopGSM.Text = dgwMasterItem.Rows[e.RowIndex].Cells[43].Value.ToString();
            txtTopWtPerPpr.Text = dgwMasterItem.Rows[e.RowIndex].Cells[44].Value.ToString();
            txtTopBfPerPpr.Text = dgwMasterItem.Rows[e.RowIndex].Cells[45].Value.ToString();

            txtWeight_Pcs.Text = dgwMasterItem.Rows[e.RowIndex].Cells[46].Value.ToString();
            txtBF_Pcs.Text = dgwMasterItem.Rows[e.RowIndex].Cells[47].Value.ToString();
            txtArtWrk_Code.Text = dgwMasterItem.Rows[e.RowIndex].Cells[48].Value.ToString();
            txtRevi_No.Text = dgwMasterItem.Rows[e.RowIndex].Cells[49].Value.ToString();
            txtArt_Dt.Text = dgwMasterItem.Rows[e.RowIndex].Cells[50].Value.ToString();
            txtSpeci_Code.Text = dgwMasterItem.Rows[e.RowIndex].Cells[51].Value.ToString();
            ddlFor_Pedilite.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[52].Value.ToString();

            txtPedilite_BS.Text = dgwMasterItem.Rows[e.RowIndex].Cells[53].Value.ToString();
            txtPedilite_GSM.Text = dgwMasterItem.Rows[e.RowIndex].Cells[54].Value.ToString();
            txtPedilite_WtBox.Text = dgwMasterItem.Rows[e.RowIndex].Cells[55].Value.ToString();
            Pedilite_PReq.Text = dgwMasterItem.Rows[e.RowIndex].Cells[56].Value.ToString();
            ddlI_Active.SelectedValue = dgwMasterItem.Rows[e.RowIndex].Cells[57].Value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlParty.Text == "")
                {
                    MessageBox.Show("Please Select Party");
                    ddlParty.Focus();
                }
                else if (txtProductCode.Text == "")
                {
                    MessageBox.Show("Please enter Product Code");
                    txtProductCode.Focus();
                }
                else if (txtI_Name.Text == "")
                {
                    MessageBox.Show("Please enter Item Name");
                    txtI_Name.Focus();
                }
                else if (ddlPly_Sheet.Text == "Please Select")
                {
                    MessageBox.Show("Please Select Ply of Sheet");
                    ddlPly_Sheet.Focus();
                }
                else if (cmbUnits.Text == "")
                {
                    MessageBox.Show("Please Select Box Length Unit");
                    cmbUnits.Focus();
                }
                else if (txtBoxLength.Text == "")
                {
                    MessageBox.Show("Please Select Box Length");
                    txtBoxLength.Focus();
                }
                else if (txtBoxWidth.Text == "")
                {
                    MessageBox.Show("Please Select Box Width");
                    txtBoxWidth.Focus();
                }
                else if (txtBoxHeight.Text == "")
                {
                    MessageBox.Show("Please Select Box Height");
                    txtBoxHeight.Focus();
                }
                else if (txtBoxLength_Conv.Text == "")
                {
                    MessageBox.Show("Please Select Box Length Conversion");
                    txtBoxLength.Focus();
                }
                else if (txtBoxWidth_Conv.Text == "")
                {
                    MessageBox.Show("Please Select Box Width Conversion");
                    txtBoxWidth.Focus();
                }
                else if (txtBoxHeight_Conv.Text == "")
                {
                    MessageBox.Show("Please Select Box Height Conversion");
                    txtBoxHeight.Focus();
                }
                else if (chkBoxConvInside.Checked == false && ChkBoxConvOutside.Checked == false)
                {
                    MessageBox.Show("Select Inside/Outside Conversion");
                    txtBoxHeight.Focus();
                }
                else if (ddlPly_Sheet.Text == "")
                {
                    MessageBox.Show("Please enter Ply_Sheet");
                    ddlPly_Sheet.Focus();
                }
                else if (txtLength_Inch_Sheet.Text == "")
                {
                    MessageBox.Show("Please enter Length_Inch_Sheet");
                    txtLength_Inch_Sheet.Focus();
                }
                else if (txtWidth_Inch_Sheet.Text == "")
                {
                    MessageBox.Show("Please Select Width_Inch_Sheet");
                    txtWidth_Inch_Sheet.Focus();
                }
                else if (ddlEF_NF_PC.Text == "")
                {
                    MessageBox.Show("Please select EF_NF_PC");
                    ddlEF_NF_PC.Focus();
                }
                else if (txtBundle_Packet.Text == "")
                {
                    MessageBox.Show("Please Select Bundle_Packet");
                    txtBundle_Packet.Focus();
                }
                else if (txtBox_PerSheet.Text == "")
                {
                    MessageBox.Show("Please enter Box_PerSheet ");
                    txtBox_PerSheet.Focus();
                }
                else if (ddlCorrugation_Opt.Text == "")
                {
                    MessageBox.Show("Please Select Corrugation_Opt");
                    ddlCorrugation_Opt.Focus();
                }
                else if (ddlPaper_Cutting.Text == "")
                {
                    MessageBox.Show("Please select Paper_Cutting");
                    ddlPaper_Cutting.Focus();
                }
                else if (ddlPrinting_Opt.Text == "")
                {
                    MessageBox.Show("Please Select Printing_Opt");
                    ddlPrinting_Opt.Focus();
                }
                else if (ddlPaper_Printed.Text == "")
                {
                    MessageBox.Show("Please select Paper_Printed");
                    ddlPaper_Printed.Focus();
                }
                else if (ddlTP_ID.Text == "")
                {
                    MessageBox.Show("Please Select TP_ID");
                    ddlTP_ID.Focus();
                }
                else if (ddlScoring_Opt.Text == "")
                {
                    MessageBox.Show("Please select Scoring_Opt");
                    ddlScoring_Opt.Focus();
                }
                else if (ddlPunching_Opt.Text == "")
                {
                    MessageBox.Show("Please Select ddlPunching_Opt");
                    ddlPunching_Opt.Focus();
                }
                else if (ddlPasting_Opt.Text == "")
                {
                    MessageBox.Show("Please select Pasting_Opt ");
                    ddlPasting_Opt.Focus();
                }
                else if (ddlSlotting_Opt.Text == "")
                {
                    MessageBox.Show("Please Select Slotting_Opt");
                    ddlSlotting_Opt.Focus();
                }
                else if (ddlPinning_Opt.Text == "")
                {
                    MessageBox.Show("Please Select Pinning_Opt ");
                    ddlPinning_Opt.Focus();
                }
                else if (ddlSide_Pasting.Text == "")
                {
                    MessageBox.Show("Please Select Side_Pasting");
                    ddlSide_Pasting.Focus();
                }
                else if (txtSell_Rate.Text == "")
                {
                    MessageBox.Show("Please enter Sell_Rate");
                    txtSell_Rate.Focus();
                }
                else if (ddlRate_Type.Text == "")
                {
                    MessageBox.Show("Please Select Rate_Type");
                    ddlRate_Type.Focus();
                }
                else if (txtExcise_Code.Text == "")
                {
                    MessageBox.Show("Please enter Excise_Code");
                    txtExcise_Code.Focus();
                }
                else if (txtTopBF.Text == "")
                {
                    MessageBox.Show("Please Select Top_BF");
                    txtTopBF.Focus();
                }
                else if (txtTopGSM.Text == "")
                {
                    MessageBox.Show("Please enter Top_GSM ");
                    txtTopGSM.Focus();
                }
                else if (txtTopWtPerPpr.Text == "")
                {
                    MessageBox.Show("Please enter Top_WPP");
                    txtTopWtPerPpr.Focus();
                }
                else if (txtTopBfPerPpr.Text == "")
                {
                    MessageBox.Show("Please enter Top_BFPP");
                    txtTopBfPerPpr.Focus();
                }
                else if (txtWeight_Pcs.Text == "")
                {
                    MessageBox.Show("Please enter Weight_Pcs");
                    txtWeight_Pcs.Focus();
                }
                else if (txtBF_Pcs.Text == "")
                {
                    MessageBox.Show("Please enter BF_Pcs");
                    txtBF_Pcs.Focus();
                }
                else if (txtArtWrk_Code.Text == "")
                {
                    MessageBox.Show("Please enter ArtWrk_Code ");
                    txtArtWrk_Code.Focus();
                }
                else if (txtRevi_No.Text == "")
                {
                    MessageBox.Show("Please enter Revi_No");
                    txtRevi_No.Focus();
                }
                else if (txtArt_Dt.Text == "")
                {
                    MessageBox.Show("Please enter Art_Dt");
                    txtArt_Dt.Focus();
                }
                else if (txtSpeci_Code.Text == "")
                {
                    MessageBox.Show("Please enter Special_Code");
                    txtSpeci_Code.Focus();
                }
                else
                {
                    if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool result = AddEditDeleteItemMasterData("E", txtI_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        //BindAgentMasterDataToGrid();
                        //clearAll();
                        this.InitializeComponent();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while Editing Values " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = AddEditDeleteItemMasterData("D", txtI_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    //BindAgentMasterDataToGrid();
                    //clearAll();
                }
                else
                {
                    cmdSubmit.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while deleting data  " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable lstAllItem = bl.GetAllItemDataByNameCode(Group_ID, Convert.ToString(txtItem_Search.Text));
                if (lstAllItem != null)
                {
                    dgwMasterItem.DataSource = lstAllItem;
                    this.dgwMasterItem.Columns[0].Visible = false;
                    if (dgwMasterItem.Rows.Count == 0)
                    {
                        cmdExcelReport.Visible = false;
                    }
                    else
                    {
                        cmdExcelReport.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while Searching " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.InitialDirectory = "C:";
                saveFileDialog1.Title = "Save as Excel file";
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "Excel Files(2003) |*.xls|Excel Files(2007) |*.xlsx";
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        System.Data.DataTable table = dgwMasterItem.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("ItemMaster");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwMasterItem.Columns.Count])
                        {
                            rng.Style.Font.Bold = true;
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }
                        FileInfo excelFile = new FileInfo(saveFileDialog1.FileName);
                        pck.SaveAs(excelFile);
                    }
                    MessageBox.Show("Data Exported Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while exporting excel  " + ex.Message);
            }
        }













































        //private void ddlPrinting_Opt_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlPrinting_Opt.Text == "Yes")
        //    {
        //        ddlPaper_Printed.Text = "No";
        //        if (txtNo_Colors.Text == "") 
        //        {
        //            MessageBox.Show("Please enter No_Colors");
        //            txtNo_Colors.Focus();
        //        }
        //        if (txtPrntColor_Name.Text == "") 
        //        {
        //            MessageBox.Show("Please Select PrntColor_Name");
        //            txtPrntColor_Name.Focus();
        //        }
        //        txtNo_Colors.Enabled = true;
        //        txtPrntColor_Name.Enabled = true;
        //    }
        //    else
        //    {
        //        ddlPaper_Printed.Text = "";
        //        txtNo_Colors.Enabled = false;
        //        txtPrntColor_Name.Enabled = false;
        //    }
        //}                          

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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
            txtTop_BFPP32.Text = txtTopBFPP32.ToString();
            double txtTopWPP32 = (((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) + ((((LenInchsheet1 * WidInchsheet1) * txtTopGSM32 / 1550) / 1000) * 0.4);
            txtTop_WPP32.Text = txtTopWPP32.ToString();
            //double TopWpp = Convert.ToDouble(txtTop_GSM3.Text);
            double txtWpp1 = Convert.ToDouble(txtTop_WPP3.Text);
            double txtWpp2 = Convert.ToDouble(txtTop_WPP31.Text);
            double txtWpp3 = Convert.ToDouble(txtTop_WPP32.Text);
            double WeightPcs = (txtWpp1 + txtWpp2 + txtWpp3);
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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

        private void ddlPartyMain_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (ddlPartyMain.SelectedIndex == 0)
                {
                    ddlParty.SelectedIndex = 0;
                    ddlParty.Enabled = false;
                }
                else
                {
                    DataTable dt = bl.GetAllPartyMasterDataByMainPartyId(Group_ID, Convert.ToString(ddlPartyMain.SelectedValue), "");
                    if (dt != null)
                    {
                        ddlParty.Enabled = true;
                        GlobalFunctions.AddPleaseSelect(ref dt);
                        ddlParty.DataSource = dt;
                        ddlParty.DisplayMember = dt.Columns[4].ToString();
                        ddlParty.ValueMember = dt.Columns[0].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No Data Found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error while loading party " + ex.Message);
            }
        }

        private void textBox131_Leave(object sender, EventArgs e)
        {
            //Calculate Flute Value of Elevenply
            double txtTopBF32 = Convert.ToDouble(textBox132.Text);
            double txtTopGSM32 = Convert.ToDouble(textBox131.Text);
            double txtTopBFPP32 = ((txtTopBF32 * txtTopGSM32) / 1000) / 2;
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







        //private void ddlPly_Sheet_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlPly_Sheet.Text == "3")
        //    {
        //        ThreePly.Visible = false;
        //        FivePly.Visible = false;
        //        SevenPly.Visible = false;
        //        NinePly.Visible = false;
        //        ElevenPly.Visible = false;
        //    }
        //    if (ddlPly_Sheet.Text == "5")
        //    {
        //        FivePly.Visible = false;
        //        ThreePly.Visible = false;
        //        SevenPly.Visible = false;
        //        NinePly.Visible = false;
        //        ElevenPly.Visible = false;
        //    }
        //    if (ddlPly_Sheet.Text == "7")
        //    {
        //        SevenPly.Visible = false;
        //        ThreePly.Visible = false;
        //        FivePly.Visible = false;
        //        NinePly.Visible = false;
        //        ElevenPly.Visible = false;
        //    }
        //    if (ddlPly_Sheet.Text == "9")
        //    {
        //        NinePly.Visible = false;
        //        ThreePly.Visible = false;
        //        FivePly.Visible = false;
        //        SevenPly.Visible = false;
        //        ElevenPly.Visible = false;
        //    }
        //    if (ddlPly_Sheet.Text == "11")
        //    {
        //        ElevenPly.Visible = false;
        //        ThreePly.Visible = false;
        //        FivePly.Visible = false;
        //        SevenPly.Visible = false;
        //        NinePly.Visible = false;
        //    }
        //}



        //private void ddlStyle_ID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //ddlPB_ID.Text = "";
        //    //ddlStyle_ID.Text = "";
        //    ////Displaying values in PB_ID Combobox
        //    pictureBox1.Visible = true;
        //    funclib = new FunctionLib();
        //    string strcon = funclib.setConnection();
        //    SqlConnection con3 = new SqlConnection(strcon);
        //    con3.Open();
        //    //Retrieve BLOB from database into DataSet.
        //    SqlCommand cmd = new SqlCommand("select Style_ID,Image_Sheet from Item_Style_Master where Style_ID='" + ddlStyle_ID.SelectedValue.ToString() + "'", con3);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds, "Item_Style_Master");
        //    int c = ds.Tables["Item_Style_Master"].Rows.Count;

        //    if (c > 0)
        //    {   //BLOB is read into Byte array, then used to construct MemoryStream,
        //        //then passed to PictureBox.
        //        Byte[] byteBLOBData = new Byte[0];
        //        byteBLOBData = (Byte[])(ds.Tables["Item_Style_Master"].Rows[c - 1]["Image_Sheet"]);
        //        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
        //        pictureBox1.Image = Image.FromStream(stmBLOBData);
        //    }
        //    con3.Close();
        //    //DataTable dt2 = new DataTable();
        //}



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
