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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using ePacker1.Business_Logic;

namespace ePacker1
{
    public partial class RPeP_MasterTopPaper : Form
    {
        string session, Group_ID;
        private FunctionLib funclib;
        string strFirstCap, strcon;
        private double sqMeter = 1550.00;
        private double costPaper;
        AllBusinessLogic bl = new AllBusinessLogic();

        public RPeP_MasterTopPaper()
        {
            InitializeComponent();
            session = RPeP_LogIn.strUser;
            Group_ID = RPeP_LogIn.strGroup;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            txtTP_ID.Visible = false;
            txtTP_PPBf.Enabled = false;
            txtTP_PPGram.Enabled = false;
            txtTP_PPRate.Enabled = false;
            txtTP_OS.Enabled = true;
            txtTP_CS.Enabled = false;
            txtTP_ReLev.Enabled = false;
            txtTP_PPCost.Enabled = false;
            txtTP_LmCost.Enabled = false;
            txtTP_VrCost.Enabled = false;
            txtTP_PnCost.Enabled = false;
            txtTP_PlCost.Enabled = false;
            txtTP_PlWsAmt.Enabled = false;
            txtTP_LmRate.Enabled = false;

            BindTopPaperMasterDataToGrid();
            DataTable dtDivFactors = new DataTable();
            GlobalFunctions.AddDivisionFactorsForPlate(ref dtDivFactors);
            if (dtDivFactors != null)
            {
                if (dtDivFactors.Rows.Count > 0)
                {
                    ddlTP_PlDivFact.DataSource = dtDivFactors;
                    ddlTP_PlDivFact.DisplayMember = dtDivFactors.Columns[0].ToString();
                    ddlTP_PlDivFact.ValueMember = dtDivFactors.Columns[0].ToString();
                }
            }

        }

        private void RPeP_MasterTopPaper_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            funclib = new FunctionLib();
            strcon = funclib.setConnection();
            DataTable dtParty = new DataTable();
            dtParty = bl.GetAllActivePartyMasterData(Group_ID);
            if (dtParty != null)
            {
                if (dtParty.Rows.Count > 0)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtParty);
                    ddlP_ID.DataSource = dtParty;
                    ddlP_ID.DisplayMember = dtParty.Columns[1].ToString();
                    ddlP_ID.ValueMember = dtParty.Columns[0].ToString();
                }
            }

            PQ_ID();
            BindPaperQuality();
            Ptve_ID();
            BindPositive();
            Lamit_Type();
            BindLamination();
            Varnish_Type();
            BindVarnish();
            BindMachines();
            //on selection closing stock n opening stock text box reamin blank
            txtTP_OS.Text = "";
            txtTP_CS.Text = "";
            txtTP_ReLev.Text = "";
            //Displaying value in Active field          
            DataTable dtActive = new DataTable();
            GlobalFunctions.AddYesNoOptions(ref dtActive);
            ddlTP_Active.DataSource = dtActive;
            ddlTP_Active.DisplayMember = dtActive.Columns[0].ToString();
            ddlTP_Active.ValueMember = dtActive.Columns[0].ToString();
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

        private void BindTopPaperMasterDataToGrid()
        {
            try
            {
                DataTable dt = bl.GetAllTopPaperDataByTPName(Group_ID, "");
                if (dt != null)
                {
                    dgwTopPaper_Master.DataSource = dt;
                    this.dgwTopPaper_Master.Columns[0].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error while Binding Top Paper Master Data " + ex.Message); }
        }

        #region PAPER QUALITY

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

        private void BindPaperQuality()
        {
            DataTable dtQuality = new DataTable();
            dtQuality = bl.GetAllActivePaperQualityMasterData(Group_ID);
            if (dtQuality != null)
            {
                if (dtQuality.Rows.Count > 0)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtQuality);
                    ddlPQ_ID.DataSource = dtQuality;
                    ddlPQ_ID.DisplayMember = dtQuality.Columns[1].ToString();
                    ddlPQ_ID.ValueMember = dtQuality.Columns[0].ToString();
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
            funclib.onlyNumbersnDot(e);
        }

        private void txtTP_PPWdth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PPLWdth
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
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

        private void ddlPQ_ID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (ddlPQ_ID.SelectedIndex > 0)
                {
                    DataTable dt = new DataTable();
                    dt = bl.GetAllPaperQualityDataById(Group_ID, ddlPQ_ID.SelectedValue.ToString());
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                txtTP_PPBf.Text = dt.Rows[0][0].ToString();
                                txtTP_PPGram.Text = dt.Rows[0][1].ToString();
                                txtTP_PPRate.Text = dt.Rows[0][2].ToString();
                                CalculateWeightOfPaper();
                                CalculateCostOfPaper();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while getting data " + ex.Message);
            }
        }

        private void txtTP_PPLgth_Leave(object sender, EventArgs e)
        {
            CalculateWeightOfPaper();
            CalculateCostOfPaper();
        }

        private void txtTP_PPWdth_Leave(object sender, EventArgs e)
        {
            CalculateWeightOfPaper();
            CalculateCostOfPaper();
        }

        private void CalculateCostOfPaper()
        {
            //Calculating Cost of Paper
            if (!string.IsNullOrEmpty(txtTP_PPLgth.Text) && !string.IsNullOrEmpty(txtTP_PPWdth.Text) && !string.IsNullOrEmpty(txtTP_PPGram.Text))
            {
                double pLgth = Convert.ToDouble(txtTP_PPLgth.Text);
                double pwdth = Convert.ToDouble(txtTP_PPWdth.Text);
                double pGSM = Convert.ToDouble(txtTP_PPGram.Text);
                double pRate = Convert.ToDouble(txtTP_PPRate.Text);
                costPaper = ((pLgth * pwdth * pGSM * pRate) / sqMeter) / 1000;
                txtTP_PPCost.Text = costPaper.ToString("#0.00");
                double weight = (pLgth * pwdth * pGSM) / 1000;
                txtTP_PPWt.Text = Convert.ToString(Math.Round(weight, 3));
                CalculateWasteAmount();
            }
        }

        private void CalculateWeightOfPaper()
        {
            if (!string.IsNullOrEmpty(txtTP_PPLgth.Text) && !string.IsNullOrEmpty(txtTP_PPWdth.Text) && !string.IsNullOrEmpty(txtTP_PPGram.Text))
            {
                double pLgth = Convert.ToDouble(txtTP_PPLgth.Text);
                double pwdth = Convert.ToDouble(txtTP_PPWdth.Text);
                double pGSM = Convert.ToDouble(txtTP_PPGram.Text);
                double weight = (pLgth * pwdth * pGSM) / 1000;
                txtTP_PPWt.Text = Convert.ToString(Math.Round(weight, 3));
            }
        }

        #endregion

        #region LAMINATION
        private void ddlTP_LmType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // show Lamit Rate in textbox
            funclib = new FunctionLib();
            string strcon1 = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon1);
            SqlCommand cmdRate = new SqlCommand("select Lamint_Rate from Item_Lamint_Master where Lamint_ID='" + ddlTP_LmType.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmdRate.ExecuteReader();
            if (dr1.Read())
            {
                txtTP_LmRate.Text = dr1[0].ToString();
                CalculateCostForLamination();
            }
            con1.Close();
        }

        private void txtTP_LmWdth_Leave(object sender, EventArgs e)
        {
            CalculateCostForLamination();
        }

        private void txtTP_LmLgth_Leave(object sender, EventArgs e)
        {
            CalculateCostForLamination();
        }

        private void txtTP_LmRate_Leave(object sender, EventArgs e)
        {
        }

        private void txtTP_LmLgth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_LmLgth
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtTP_LmWdth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_LmWdth
            funclib = new FunctionLib();
            funclib.onlyNumbersnDot(e);
        }

        private void txtTP_LmRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_LmRate
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTP_LmCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_LmCost
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
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

        private void BindLamination()
        {
            DataTable dtLamination = new DataTable();
            dtLamination = bl.GetAllActiveLaminationData(Group_ID);
            if (dtLamination != null)
            {
                if (dtLamination.Rows.Count > 0)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtLamination);
                    ddlTP_LmType.DataSource = dtLamination;
                    ddlTP_LmType.DisplayMember = dtLamination.Columns[1].ToString();
                    ddlTP_LmType.ValueMember = dtLamination.Columns[0].ToString();
                }
            }
        }

        private void CalculateCostForLamination()
        {
            if (!string.IsNullOrEmpty(txtTP_LmLgth.Text) && !string.IsNullOrEmpty(txtTP_LmWdth.Text) && !string.IsNullOrEmpty(txtTP_LmRate.Text))
            {
                //calculating cost of Lamination
                double lLength = Convert.ToDouble(txtTP_LmLgth.Text);
                double lWidth = Convert.ToDouble(txtTP_LmWdth.Text);
                double lRate = Convert.ToDouble(txtTP_LmRate.Text);
                double costLamintion = (lLength * lWidth * lRate) / 1000;
                txtTP_LmCost.Text = costLamintion.ToString("#0.00");
            }
        }
        #endregion

        #region VARNISH
        private void txtTP_VrRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_VrRate
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void ddlTP_VrType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // show Lamit Rate in textbox
            funclib = new FunctionLib();
            string strcon1 = funclib.setConnection();
            SqlConnection con1 = new SqlConnection(strcon1);
            SqlCommand cmdRate = new SqlCommand("select VarnishRate from Item_Varnish_Master where Varnish_ID ='" + ddlTP_VrType.SelectedValue.ToString() + "'", con1);
            con1.Open();
            SqlDataReader dr1 = cmdRate.ExecuteReader();
            if (dr1.Read())
            {
                txtTP_VrRate.Text = dr1[0].ToString();
                CalculateCostForVarnish();
            }
            con1.Close();
        }

        private void txtTP_VrRate_Leave(object sender, EventArgs e)
        {
        }

        private void txtTP_VrLgth_Leave(object sender, EventArgs e)
        {
            CalculateCostForVarnish();
        }

        private void txtTP_VrWdth_Leave(object sender, EventArgs e)
        {
            CalculateCostForVarnish();
        }

        private void CalculateCostForVarnish()
        {
            if (!string.IsNullOrEmpty(txtTP_VrLgth.Text) && !string.IsNullOrEmpty(txtTP_VrWdth.Text) && !string.IsNullOrEmpty(txtTP_VrRate.Text))
            {
                //calculating cost of Varnish
                double V_Length = Convert.ToDouble(txtTP_VrLgth.Text);
                double V_Width = Convert.ToDouble(txtTP_VrWdth.Text);
                double V_Rate = Convert.ToDouble(txtTP_VrRate.Text);
                double costVarnish = (V_Length * V_Width * V_Rate) / 1000;
                txtTP_VrCost.Text = costVarnish.ToString("#0.00");
            }
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

        private void BindVarnish()
        {
            DataTable dtVarnish = new DataTable();
            dtVarnish = bl.GetAllActiveVarnishData(Group_ID);
            if (dtVarnish != null)
            {
                if (dtVarnish.Rows.Count > 0)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtVarnish);
                    ddlTP_VrType.DataSource = dtVarnish;
                    ddlTP_VrType.DisplayMember = dtVarnish.Columns[1].ToString();
                    ddlTP_VrType.ValueMember = dtVarnish.Columns[0].ToString();
                }
            }
        }
        #endregion

        #region PRINTING

        private void BindMachines()
        {
            SqlConnection con1 = new SqlConnection(strcon);
            con1.Open();
            SqlDataAdapter daMach = new SqlDataAdapter("select a.M_ID,a.M_Name from Machine_Master a,MachType_Master b  where a.Grp_ID='" + Group_ID + "' and a.M_Type=b.M_Type and a.M_Active = 'Yes'  ", con1);
            DataTable dtMach = new DataTable();
            daMach.Fill(dtMach);
            GlobalFunctions.AddPleaseSelect(ref dtMach);
            ddlM_ID.DataSource = dtMach;
            ddlM_ID.DisplayMember = dtMach.Columns[1].ToString();
            ddlM_ID.ValueMember = dtMach.Columns[0].ToString();
            con1.Close();
        }

        private void txtTP_Pr_MinQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from txtTP_Pr_MinQty
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void CalculateCostOfPrinting()
        {
            if (!string.IsNullOrEmpty(txtTP_PnColor.Text) && !string.IsNullOrEmpty(txtTP_Pr_MinQty.Text) && !string.IsNullOrEmpty(txtTP_PnRate.Text))
            {
                //calculating cost of Printing
                double P_NoOfColor = Convert.ToDouble(txtTP_PnColor.Text);
                double P_MinQty = Convert.ToDouble(txtTP_Pr_MinQty.Text);
                double P_Rate = Convert.ToDouble(txtTP_PnRate.Text);
                double costPrinting = (P_NoOfColor * P_MinQty * P_Rate) / 1000;
                txtTP_PnCost.Text = costPrinting.ToString("#0.00");
                CalculateWasteAmount();
            }
        }

        private void txtTP_PnColor_Leave(object sender, EventArgs e)
        {
            CalculateCostOfPrinting();
        }

        private void txtTP_PnColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PnColor
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTP_PnRate_Leave(object sender, EventArgs e)
        {
            CalculateCostOfPrinting();
        }

        private void txtTP_PnRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PnRate
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        private void txtTP_Pr_MinQty_Leave(object sender, EventArgs e)
        {
            var minQty = Convert.ToInt32(txtTP_Pr_MinQty.Text);
            if (minQty < 1000)
            {
                MessageBox.Show("Minimum Quantity for Printing should be 1000 or more");
            }
            else
            {
                CalculateCostOfPrinting();
            }
        }

        private void txttxtTP_PnCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation from TP_PnCost
            funclib = new FunctionLib();
            funclib.onlyNumbers(e);
        }

        #endregion

        #region PLATE

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

        private void ddlTP_PlDivFact_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ddlTP_PlDivFact.SelectedIndex != 0)
            {
                CalculateCostOfPlate();
            }
        }

        private void CalculateCostOfPlate()
        {
            if (ddlTP_PlDivFact.SelectedIndex != 0 && !string.IsNullOrEmpty(txtTP_PlNo.Text) && !string.IsNullOrEmpty(txtTP_PlRate.Text))
            {
                //calculating cost of Plate
                double Pl_NoOfColor = Convert.ToDouble(txtTP_PlNo.Text);
                double Pl_DivFactor = Convert.ToDouble(ddlTP_PlDivFact.SelectedValue);
                double Pl_Rate = Convert.ToDouble(txtTP_PlRate.Text);
                double costPlate = (Pl_NoOfColor * Pl_Rate) / Pl_DivFactor;
                txtTP_PlCost.Text = costPlate.ToString("#0.00");
                CalculateWasteAmount();
            }
        }

        private void txtTP_PlNo_Leave(object sender, EventArgs e)
        {
            CalculateCostOfPlate();
        }

        private void txtTP_PlRate_Leave(object sender, EventArgs e)
        {
            CalculateCostOfPlate();
        }

        #endregion

        #region WASTE

        private void txtTP_PlWsCnt_Leave(object sender, EventArgs e)
        {
            CalculateWasteAmount();
        }

        private void CalculateWasteAmount()
        {
            if (!string.IsNullOrEmpty(txtTP_PPCost.Text) && !string.IsNullOrEmpty(txtTP_PnCost.Text) && !string.IsNullOrEmpty(txtTP_PlCost.Text) && !string.IsNullOrEmpty(txtTP_PlWsCnt.Text))
            {
                double PP_Cost = Convert.ToDouble(txtTP_PPCost.Text);
                double PN_Cost = Convert.ToDouble(txtTP_PnCost.Text);
                double PL_Cost = Convert.ToDouble(txtTP_PlCost.Text);
                double wastePC = Convert.ToDouble(txtTP_PlWsCnt.Text);
                double wasteAmt = ((PP_Cost + PN_Cost + PL_Cost) * wastePC / 100);
                txtTP_PlWsAmt.Text = wasteAmt.ToString("#0.00");
                txtTP_Rate.Text = (PP_Cost + PN_Cost + PL_Cost).ToString("#0.00");
            }
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

        #endregion

        #region POSITIVE

        private void BindPositive()
        {
            DataTable dtPositive = new DataTable();
            dtPositive = bl.GetAllActivePositiveData(Group_ID);
            if (dtPositive != null)
            {
                if (dtPositive.Rows.Count > 0)
                {
                    GlobalFunctions.AddPleaseSelect(ref dtPositive);
                    ddlPtve_ID.DataSource = dtPositive;
                    ddlPtve_ID.DisplayMember = dtPositive.Columns[1].ToString();
                    ddlPtve_ID.ValueMember = dtPositive.Columns[0].ToString();
                }
            }
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

        private void ddlPtve_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show os Qty in textbox
            //funclib = new FunctionLib();
            //string strcon = funclib.setConnection();
            //SqlConnection con = new SqlConnection(strcon);
            //SqlCommand cmdOS = new SqlCommand("select Ptve_Qty_OS from Positive_Master where Ptve_ID='" + ddlPtve_ID.SelectedValue.ToString() + "'", con);
            //con.Open();
            //SqlDataReader dr = cmdOS.ExecuteReader();
            //if (dr.Read())
            //{
            //    txtTP_OS.Text = "";
            //    txtTP_OS.Text = dr[0].ToString();
            //}
            //con.Close();
            // show cs Qty in textbox
            //funclib = new FunctionLib();
            //string strcon1 = funclib.setConnection();
            //SqlConnection con1 = new SqlConnection(strcon1);
            //SqlCommand cmdCS = new SqlCommand("select Ptve_Qty_CS from Positive_Master where Ptve_ID='" + ddlPtve_ID.SelectedValue.ToString() + "'", con1);
            //con1.Open();
            //SqlDataReader dr1 = cmdCS.ExecuteReader();
            //if (dr1.Read())
            //{
            //    txtTP_CS.Text = dr1[0].ToString();
            //}
            //con1.Close();
            // show RO Qty in textbox
            //funclib = new FunctionLib();
            //string strcon2 = funclib.setConnection();
            //SqlConnection con2 = new SqlConnection(strcon1);
            //SqlCommand cmdRO = new SqlCommand("select Ptve_Qty_RO from Positive_Master where Ptve_ID='" + ddlPtve_ID.SelectedValue.ToString() + "'", con2);
            //con2.Open();
            //SqlDataReader dr2 = cmdRO.ExecuteReader();
            //if (dr2.Read())
            //{
            //    txtTP_ReLev.Text = dr2[0].ToString();
            //}
            //con2.Close();
        }

        #endregion       

        private void cmdSubmit_Click(object sender, EventArgs e)
        {           
            try
            {
                string strValidationError = Validation();
                if (string.IsNullOrEmpty(strValidationError))
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
                            bool result = AddEditDeleteTopPaperMasterData("A", tpid);
                            if (result)
                            {
                                MessageBox.Show("Record Inserted Sucessfully");
                            }
                            else
                            { MessageBox.Show("There was an error while inserting data"); }
                            BindTopPaperMasterDataToGrid();
                            clearAll();
                        }
                    }
                    else
                    {
                        cmdSubmit.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while inserting data. " + ex.Message);
            }
        }

        private void dgwTopPaper_Master_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdEdit.Enabled = true;
            cmdEdit.Visible = true;
            btnDelete.Visible = true;
            cmdSubmit.Enabled = false;
            cmdSubmit.Visible = false;
            ddlTP_Active.Enabled = true;
            txtTP_Name.Enabled = false;
            ddlP_ID.Enabled = false;
            //ddlPQ_ID.Enabled = false;            
            //Display data in form on click of grid
            txtTP_ID.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[0].Value.ToString();
            ddlP_ID.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTP_Name.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[3].Value.ToString();
            ddlPQ_ID.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtTP_PPLgth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtTP_PPWdth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtTP_PPBf.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtTP_PPGram.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtTP_PPWt.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtTP_PPRate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtTP_PPCost.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtTP_LmLgth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtTP_LmWdth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtTP_LmRate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtTP_LmCost.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[15].Value.ToString();
            ddlTP_LmType.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[16].Value.ToString();
            txtTP_VrLgth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtTP_VrWdth.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtTP_VrRate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[19].Value.ToString();
            txtTP_VrCost.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[20].Value.ToString();
            ddlTP_VrType.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[21].Value.ToString();
            ddlM_ID.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[22].Value.ToString();
            txtTP_Pr_MinQty.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[23].Value.ToString();
            txtTP_PnColor.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[24].Value.ToString();
            txtTP_PnRate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[25].Value.ToString();
            txtTP_PnCost.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[26].Value.ToString();
            ddlTP_PlDivFact.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[27].Value.ToString();
            txtTP_PlNo.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[28].Value.ToString();
            txtTP_PlRate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[29].Value.ToString();
            txtTP_PlCost.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[30].Value.ToString();
            txtTP_PlWsCnt.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[31].Value.ToString();
            txtTP_PlWsAmt.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[32].Value.ToString();
            ddlPtve_ID.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[33].Value.ToString();
            txtTP_Rate.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[34].Value.ToString();
            txtTP_OS.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[35].Value.ToString();
            //txtTP_CS.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[33].Value.ToString();
            //txtTP_ReLev.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[34].Value.ToString();
            ddlTP_Active.Text = dgwTopPaper_Master.Rows[e.RowIndex].Cells[36].Value.ToString();           
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string strValidationError = Validation();
                if (string.IsNullOrEmpty(strValidationError))
                {
                    if (MessageBox.Show("Do you wish to Update this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool result = AddEditDeleteTopPaperMasterData("E", txtTP_ID.Text);
                        if (result)
                        {
                            MessageBox.Show("Record Updated");
                        }
                        else
                        { MessageBox.Show("There was an error while updating data"); }
                        BindTopPaperMasterDataToGrid();
                        clearAll();
                    }
                }
                else
                {
                    MessageBox.Show(strValidationError);
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
                if (MessageBox.Show("Do you wish to Delete this records", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = AddEditDeleteTopPaperMasterData("D", txtTP_ID.Text);
                    if (result)
                    {
                        MessageBox.Show("Record Deleted");
                    }
                    else
                    { MessageBox.Show("There was an error while deleting data"); }
                    BindTopPaperMasterDataToGrid();
                    clearAll();
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

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //Search data from table        
            try
            {
                DataTable dt = bl.GetAllTopPaperDataByTPName(Group_ID, txtSearchTopPaper.Text);
                if (dt != null)
                {
                    dgwTopPaper_Master.DataSource = dt;
                    this.dgwTopPaper_Master.Columns[0].Visible = false;
                    if (dgwTopPaper_Master.Rows.Count == 0)
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

        private void cmdReset_Click(object sender, EventArgs e)
        {
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
            txtTP_LmWdth.Text = "";
            txtTP_LmRate.Text = "";
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
            ddlTP_Active.SelectedIndex = 0;
            cmdEdit.Enabled = false;
            cmdEdit.Visible = false;
            btnDelete.Visible = false;
            cmdSubmit.Enabled = true;
            cmdSubmit.Visible = true;
            ddlP_ID.SelectedIndex = 0;
            ddlPQ_ID.SelectedIndex = 0;
            ddlTP_LmType.SelectedIndex = 0;
            ddlTP_VrType.SelectedIndex = 0;
            ddlM_ID.SelectedIndex = 0;
            ddlTP_PlDivFact.SelectedIndex = 0;
            ddlPtve_ID.SelectedIndex = 0;
            txtTP_Pr_MinQty.Text = "";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
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
                        System.Data.DataTable table = dgwTopPaper_Master.DataSource as DataTable;
                        System.Data.DataTable filtered = table.DefaultView.ToTable();
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("TopPaperMaster");
                        ws.Cells["A1"].LoadFromDataTable(((System.Data.DataTable)filtered), true, OfficeOpenXml.Table.TableStyles.Light1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, dgwTopPaper_Master.Columns.Count])
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

        private bool AddEditDeleteTopPaperMasterData(string action, string TopPaperId)
        {
            bool result = false;
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("TopPaperId", TopPaperId);
                dictionaryInstance.Add("PartyId", Convert.ToString(ddlP_ID.SelectedValue));
                dictionaryInstance.Add("TopPaperName", funclib.FirstCap(txtTP_Name.Text));

                dictionaryInstance.Add("PaperQuality", Convert.ToString(ddlPQ_ID.SelectedValue));
                dictionaryInstance.Add("PPLength", txtTP_PPLgth.Text);
                dictionaryInstance.Add("PPWidth", txtTP_PPWdth.Text);
                dictionaryInstance.Add("PPBF", txtTP_PPBf.Text);
                dictionaryInstance.Add("PPGrammage", txtTP_PPGram.Text);
                dictionaryInstance.Add("PPRate", txtTP_PPRate.Text);
                dictionaryInstance.Add("PPCost", txtTP_PPCost.Text);
                dictionaryInstance.Add("PPWeight", txtTP_PPWt.Text);

                dictionaryInstance.Add("LaminationType", Convert.ToString(ddlTP_LmType.SelectedValue));
                dictionaryInstance.Add("LMLength", txtTP_LmLgth.Text);
                dictionaryInstance.Add("LMWidth", txtTP_LmWdth.Text);
                dictionaryInstance.Add("LMRate", txtTP_LmRate.Text);
                dictionaryInstance.Add("LMCost", txtTP_LmCost.Text);

                dictionaryInstance.Add("VarnishType", Convert.ToString(ddlTP_VrType.SelectedValue));
                dictionaryInstance.Add("VRLength", txtTP_VrLgth.Text);
                dictionaryInstance.Add("VRWidth", txtTP_VrWdth.Text);
                dictionaryInstance.Add("VRRate", txtTP_VrRate.Text);
                dictionaryInstance.Add("VRCost", txtTP_VrCost.Text);

                dictionaryInstance.Add("MachineId", Convert.ToString(ddlM_ID.SelectedValue));
                dictionaryInstance.Add("PNMinQty", txtTP_Pr_MinQty.Text);
                dictionaryInstance.Add("PNNoColor", txtTP_PnColor.Text);
                dictionaryInstance.Add("PNRate", txtTP_PnRate.Text);
                dictionaryInstance.Add("PNCost", txtTP_PnCost.Text);

                dictionaryInstance.Add("DivFactor", Convert.ToString(ddlTP_PlDivFact.SelectedValue));
                dictionaryInstance.Add("PLNoColor", txtTP_PlNo.Text);
                dictionaryInstance.Add("PLRate", txtTP_PlRate.Text);
                dictionaryInstance.Add("PLCost", txtTP_PlCost.Text);

                dictionaryInstance.Add("WastePC", txtTP_PlWsCnt.Text);
                dictionaryInstance.Add("WasteAmt", txtTP_PlWsAmt.Text);

                dictionaryInstance.Add("PositiveId", Convert.ToString(ddlPtve_ID.SelectedValue));
                dictionaryInstance.Add("OpenStockQty", Convert.ToString(txtTP_OS.Text));

                dictionaryInstance.Add("TPRate", Convert.ToString(txtTP_Rate.Text));

                dictionaryInstance.Add("IsActive", Convert.ToString(ddlTP_Active.SelectedValue));
                dictionaryInstance.Add("Group_ID", Group_ID);
                dictionaryInstance.Add("User", Convert.ToString(session));
                dictionaryInstance.Add("Action", action);
                result = bl.AddEditDeleteTopPaperMasterData(dictionaryInstance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        private string Validation()
        {
            string strError = "";
            try
            {
                if (string.IsNullOrEmpty(txtTP_Name.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Top Paper Name   ";
                }
                if (ddlP_ID.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Party   ";
                }

                if (ddlPQ_ID.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Paper Quality   ";
                }
                if (string.IsNullOrEmpty(txtTP_PPLgth.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Plain Paper Length   ";
                }
                if (string.IsNullOrEmpty(txtTP_PPWdth.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Plain Paper Width   ";
                }
                if (string.IsNullOrEmpty(txtTP_PPBf.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Plain Paper BF   ";
                }
                if (string.IsNullOrEmpty(txtTP_PPGram.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Plain Paper Grammage   ";
                }
                if (string.IsNullOrEmpty(txtTP_PPRate.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Plain Paper Rate   ";
                }
                if (string.IsNullOrEmpty(txtTP_PPCost.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Plain Paper Cost   ";
                }
                if (ddlTP_LmType.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Lamination Type   ";
                }
                if (string.IsNullOrEmpty(txtTP_LmRate.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Lamination Rate   ";
                }
                if (string.IsNullOrEmpty(txtTP_LmLgth.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Lamination Length   ";
                }
                if (string.IsNullOrEmpty(txtTP_LmCost.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Lamination Cost   ";
                }
                if (ddlTP_VrType.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Varnish Type   ";
                }
                if (string.IsNullOrEmpty(txtTP_VrLgth.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Varnish Length   ";
                }
                if (string.IsNullOrEmpty(txtTP_VrWdth.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Varnish Width   ";
                }
                if (string.IsNullOrEmpty(txtTP_VrRate.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Varnish Rate   ";
                }
                if (string.IsNullOrEmpty(txtTP_VrCost.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Varnish Cost   ";
                }
                if (ddlM_ID.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Machine   ";
                }
                if (string.IsNullOrEmpty(txtTP_PnRate.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Printing Rate   ";
                }
                if (string.IsNullOrEmpty(txtTP_PnCost.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Printing Cost   ";
                }
                if (string.IsNullOrEmpty(txtTP_PnColor.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Printing Color   ";
                }
                if (string.IsNullOrEmpty(txtTP_Pr_MinQty.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Printing Min Qty   ";
                }
                if (ddlTP_PlDivFact.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Division Factor   ";
                }
                if (string.IsNullOrEmpty(txtTP_PlCost.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Plate Cost   ";
                }
                if (string.IsNullOrEmpty(txtTP_PlNo.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Plate No   ";
                }
                if (string.IsNullOrEmpty(txtTP_PlRate.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Plate Rate   ";
                }
                if (string.IsNullOrEmpty(txtTP_PlWsCnt.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Weight %   ";
                }
                if (string.IsNullOrEmpty(txtTP_PlWsAmt.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Weight Amount   ";
                }
                if (ddlPtve_ID.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Positive   ";
                }
                if (string.IsNullOrEmpty(txtTP_Rate.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Top Paper Rate   ";
                }
                if (string.IsNullOrEmpty(txtTP_OS.Text))
                {
                    strError = strError + Environment.NewLine + "Please Enter Opening Stock Qty   ";
                }
                if (ddlTP_Active.SelectedIndex == 0)
                {
                    strError = strError + Environment.NewLine + "Please Select Active   ";
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                MessageBox.Show("There was an Error while Validating Values " + ex.Message);
            }
            return strError;
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

    }
}
