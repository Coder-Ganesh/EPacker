using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ePacker1
{
    public partial class RPeP_MasterMDI : Form
    {
       // private int childFormNumber = 0;

        public RPeP_MasterMDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            //childForm.Show();

            //Displaying Master Form
            RPeP_MasterGroup frmMaster = new RPeP_MasterGroup();
            frmMaster.MdiParent = this;
            frmMaster.Text = "RPeP_GroupMaster";
            frmMaster.Show();

           
            
        }

        private void OpenFile(object sender, EventArgs e)
        {
            

            //Displaying User_Master Form
            RPeP_UserMaster frmUser = new RPeP_UserMaster();
            frmUser.MdiParent = this;
            frmUser.Text = "User_Master";
            frmUser.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = saveFileDialog.FileName;
            //}

            //Displaying State form
            RPeP_StateMaster frmState = new RPeP_StateMaster();
            frmState.MdiParent = this;
            frmState.Text = "City";
            frmState.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displaying Party Form
            RPeP_MasterParty frmParty = new RPeP_MasterParty();
            frmParty.MdiParent = this;
            frmParty.Text = "RPeP_MasterParty";
            frmParty.Show();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Dispalying Master Agent Form

            RPeP_MasterAgent frmAgent = new RPeP_MasterAgent();
            frmAgent.MdiParent = this;
            frmAgent.Text = "RPeP_Agent";
            frmAgent.Show();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Displaying the Master Mill form
            RPeP_MasterMill frmMasterMill = new RPeP_MasterMill();
            frmMasterMill.MdiParent = this;
            frmMasterMill.Text = "RPeP_MasterMill";
            frmMasterMill.Show();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displaying Paper Quality Form

            RPeP_MasterPQuality frmQuality = new RPeP_MasterPQuality();
            frmQuality.MdiParent = this;
            frmQuality.Text = "RPeP_MasterPQuality Form";
            frmQuality.Show();
            
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dispalying Party(Main) Form

            RPeP_MasterPartyMain frmParty = new RPeP_MasterPartyMain();
            frmParty.MdiParent = this;
            frmParty.Text = "RPeP_MasterPartyMain";
            frmParty.Show();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dispalying Master Agent Mill Form

            RPeP_MasterAgentMill frmAgentMill = new RPeP_MasterAgentMill();
            frmAgentMill.MdiParent = this;
            frmAgentMill.Text = "RpeP_MasterAgentMill";
            frmAgentMill.Show();
        }

        private void contractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dispalying Master Contractor Form

            RPeP_MasterContractor frmContractor = new RPeP_MasterContractor();
            frmContractor.MdiParent = this;
            frmContractor.Text = "RPeP_MasterContractor";
            frmContractor.Show();
        }

        private void positiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////Dispalying Master Positive Form

            RPeP_MasterPositive frmPositive = new RPeP_MasterPositive();
            frmPositive.MdiParent = this;
            frmPositive.Text = "RPeP_MasterPositive";
            frmPositive.Show();
        }

        private void regionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //To display Region Form
            RPeP_MasterRegion frmRegion = new RPeP_MasterRegion();
            frmRegion.MdiParent = this;
            frmRegion.Text = "RPeP_MasterRegion";
            frmRegion.Show();
        }

        private void deliveryPlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //To Display Delivery Form

            RPeP_MasterDelivery frmDelivery = new RPeP_MasterDelivery();
            frmDelivery.MdiParent = this;
            frmDelivery.Text = "RPeP_MasterDelivery";
            frmDelivery.Show();
        }

        private void machineTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //To display Machine Type Form

            RPeP_MasterMachineType frmMachineType = new RPeP_MasterMachineType();
            frmMachineType.MdiParent = this;
            frmMachineType.Text = "RPeP_MasterMachineType";
            frmMachineType.Show();
        }

        private void machineToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Displaying Machine Form

            RPeP_MasterMachine frmMachine = new RPeP_MasterMachine();
            frmMachine.MdiParent = this;
            frmMachine.Text = "RPeP_MasterMachine";
            frmMachine.Show();
        }

        private void driverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displaying Driver Form

            RPeP_MasterDriver frmDriver = new RPeP_MasterDriver();
            frmDriver.MdiParent = this;
            frmDriver.Text = "RPeP_MasterDriver";
            frmDriver.Show();
        }

        private void shiftToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //To Display Shift Form

            RPeP_MasterShift frmShift = new RPeP_MasterShift();
            frmShift.MdiParent = this;
            frmShift.Text = "RPeP_MasterShift";
            frmShift.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripButton_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //Displaying Year
        }

        private void newToolStripButton_Click_2(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Displaying Calculator
            Process.Start("calc.exe");
            
        }

        private void saveToolStripButton_Click_1(object sender, EventArgs e)
        {
            //Displaying Clock
            
        }

        

        private void topPaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displaying TopPaper_Master form

            RPeP_MasterTopPaper frmTopPaper = new RPeP_MasterTopPaper();
            frmTopPaper.MdiParent = this;
            frmTopPaper.Text = "RPeP_MasterTopPaper";
            frmTopPaper.Show();
        }

        private void topPaperPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displaying PaperParty form

            RPeP_TopPaperParty frmParty = new RPeP_TopPaperParty();
            frmParty.MdiParent = this;
            frmParty.Text = "RPeP_TopPaperParty";
            frmParty.Show();
        }

        //private void storeItemToolStripMenuItem_Click(object sender, EventArgs e)
        //{
           
        //}

        private void editMenu_Click(object sender, EventArgs e)
        {

        }

        private void uMToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //Dispaly UMO Master Item form

            RPeP_MasterUOM frmUOM = new RPeP_MasterUOM();
            frmUOM.MdiParent = this;
            frmUOM.Text = "RPeP_MasterUOM";
            frmUOM.Show();
        
        }

        private void toolsMenu_Click(object sender, EventArgs e)
        {

        }

        private void gSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displaying GSM Form

                RPeP_MasterItemGSM frmGSM = new RPeP_MasterItemGSM();
                frmGSM.MdiParent = this;
                frmGSM.Text = "RPeP_MasterItemGSM";
                frmGSM.Show();
        }

        private void bFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //Displaying BF Form
            RPeP_MasterItemBF frmBF= new RPeP_MasterItemBF();
            frmBF.MdiParent = this;
            frmBF.Text = "RPeP_MasterItemBF";
            frmBF.Show();
        }

        private void standardPaperToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Displaying Standard Paper Form
            RPeP_MasterItemStdPaper frmStdPaper = new RPeP_MasterItemStdPaper();
            frmStdPaper.MdiParent = this;
            frmStdPaper.Text = "RPeP_MasterItemStdPaper";
            frmStdPaper.Show();

        }

        private void varnishToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Displaying Standard Paper Form
            RPeP_MasterItemVarnish frmVarnish = new RPeP_MasterItemVarnish();
            frmVarnish.MdiParent = this;
            frmVarnish.Text = "RPeP_MasterItemVarnish";
            frmVarnish.Show();


        }

        private void punchingMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Displaying Punching Machine Form
            RPeP_MasterItemPunchMach frmPunchMach = new RPeP_MasterItemPunchMach();
            frmPunchMach.MdiParent = this;
            frmPunchMach.Text = "RPeP_MasterItemPunchMach";
            frmPunchMach.Show();


        }

        private void laminationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displaying Lamination Form
            RPeP_MasterItemLamint frmLamint = new RPeP_MasterItemLamint();
            frmLamint.MdiParent = this;
            frmLamint.Text = "RPeP_MasterItemLamint";
            frmLamint.Show();

        }

        private void printingMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displaying Printing Machine Form
            RPeP_MasterItemPrntMach frmPrntMach = new RPeP_MasterItemPrntMach();
            frmPrntMach.MdiParent = this;
            frmPrntMach.Text = "RPeP_MasterItemPrntMach";
            frmPrntMach.Show();
        }

        private void paperQualityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displaying Paper Quality Form
            RPeP_MasterPQuality frmPQuality = new RPeP_MasterPQuality();
            frmPQuality.MdiParent = this;
            frmPQuality.Text = "RPeP_MasterPQuality";
            frmPQuality.Show();
        }

        private void miscellaneousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displaying Miscllaniaous Form
            RPeP_MasterItemMisc frmMisc = new RPeP_MasterItemMisc();
            frmMisc.MdiParent = this;
            frmMisc.Text = "RPeP_MasterItemMisc";
            frmMisc.Show();
        }

        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Displaying Style Form
            RPeP_MasterItemStyle frmStyle = new RPeP_MasterItemStyle();
            frmStyle.MdiParent = this;
            frmStyle.Text = "RPeP_MasterItemStyle";
            frmStyle.Show();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Make it a child of this MDI form before showing it.
            RPeP_CityMaster frmCity = new RPeP_CityMaster();
            frmCity.MdiParent = this;
            frmCity.Text = "City";
            frmCity.Show();
        }

        //private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //Exit Application
        //    Application.Exit();

        //}

        private void toolBarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Toggling Toolbar

            toolStrip1.Visible = toolBarToolStripMenuItem.Checked;

           
        }

        private void statusBarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Toggling statusbar
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;

        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    toolStripStatusLabel.Text = DateTime.Now.ToString() + "  " + "ePacker Developed by ROPRAS Solution";
        //}

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            //Open Excel

            Process.Start("excel.exe");


            
        }

        private void machineContractorLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Displaying Machine Contractor

            RPeP_MasterMachineContractor frmMachContr = new RPeP_MasterMachineContractor();
            frmMachContr.MdiParent = this;
            frmMachContr.Text = "MachineContractor";
            frmMachContr.Show();

        }

        private void RPeP_MasterMDI_Load(object sender, EventArgs e)
        {

        }

        private void inwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_PurchaseItemIn frmPurc = new RPeP_PurchaseItemIn();
            frmPurc.MdiParent = this;
            frmPurc.Text = "PurchaseInward";
            frmPurc.Show();

        }

        private void damageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_PurchaseItemDmg dm = new RPeP_PurchaseItemDmg();
            dm.MdiParent = this;
            dm.Text = "Purchase Damage";
            dm.Show();
        }

        private void partyBuyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_PartyBuyer pb = new RPeP_PartyBuyer();
            pb.MdiParent = this;
            pb.Text = "Party Buyer";
            pb.Show();
                
        }

        private void outwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseItemOut po = new PurchaseItemOut();
            po.MdiParent = this;
            po.Text = "Purchase Outward";
            po.Show();
        }

        private void itemGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_MasterItemGrp mi = new RPeP_MasterItemGrp();
            mi.MdiParent = this;
            mi.Text = "Item Management";
            mi.Show();
        }

        //private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        //{
            
        //}

        private void prchaseItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dispaly Store Item form

            RPeP_MasterPurchaseItem frmPurch = new RPeP_MasterPurchaseItem();
            frmPurch.MdiParent = this;
            frmPurch.Text = "RPeP_MasterPurchaseItem";
            frmPurch.Show();
        }

        private void inwardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //RPeP_MasterPurchaseItemIn  Moved to Purchases Menu
           

        }

        private void outwardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PurchaseItemOut PurchsOut = new PurchaseItemOut();
            PurchsOut.MdiParent = this;
            PurchsOut.Text = "PurchaseItem Out";
            PurchsOut.Show();

        }

        private void damageToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RPeP_PurchaseItemDmg PurchsDamg = new RPeP_PurchaseItemDmg();
            PurchsDamg.MdiParent = this;
            PurchsDamg.Text = "PurchaseItem Damage";
            PurchsDamg.Show();
        }

        private void newItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_MasterItem Item = new RPeP_MasterItem();
            Item.MdiParent = this;
            Item.Text = "Master Item";
            Item.Show();

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void masterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RPePExcelReport re = new RPePExcelReport();
            //re.MdiParent = this;
            //re.Text = "Report";
            //re.Show();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = DateTime.Now.ToString() + "  " + "ePacker Developed by ROPRAS Solution";
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_OrderProc re = new RPeP_OrderProc();
            re.MdiParent = this;
            re.Text = "Order";
            re.Show();

        }

        private void newChallanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_DispNewChallan re = new RPeP_DispNewChallan();
            re.MdiParent = this;
            re.Text = "Dispatch : New Challan";
            re.Show();
        }

        private void formNo57F4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_DispForm57F4 re = new RPeP_DispForm57F4();
            re.MdiParent = this;
            re.Text = "Dispatch : Form No.57F(4)";
            re.Show();
        }

        private void dispatchInvoiceCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_DispInvCopy re = new RPeP_DispInvCopy();
            re.MdiParent = this;
            re.Text = "Dispatch : Invoice Copy";
            re.Show();
        }

        private void form404ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_DispForm404 re = new RPeP_DispForm404();
            re.MdiParent = this;
            re.Text = "Form No. 404";
            re.Show();
        }

        private void form403ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_DispForm403 re = new RPeP_DispForm403();
            re.MdiParent = this;
            re.Text = "Form No. 403";
            re.Show();

        }

        private void craftPaperReelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_POCraftPaperReel re = new RPeP_POCraftPaperReel();
            re.MdiParent = this;
            re.Text = "Craft Paper / Reel";
            re.Show();
        }

        private void storeItemPurchaseItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_POStoreItem re = new RPeP_POStoreItem();
            re.MdiParent = this;
            re.Text = "Store Item / Purchase Item";
            re.Show();

        }

        private void craftPaperReelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RPeP_PurCraftPaperReel re = new RPeP_PurCraftPaperReel();
            re.MdiParent = this;
            re.Text = "Purchases – Craft Paper / Reel";
            re.Show();

        }

        private void storeItemPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_PurchaseItemIn inward = new RPeP_PurchaseItemIn();
            inward.MdiParent = this;
            inward.Text = "PurchaseItem Inward";
            inward.Show();
        }

        private void topPaperToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RPeP_PurTopPaper inward = new RPeP_PurTopPaper();
            inward.MdiParent = this;
            inward.Text = "Purchases – Top Paper";
            inward.Show();
        }

        private void piningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_Pining inward = new RPeP_Pining();
            inward.MdiParent = this;
            inward.Text = "Production Card For Pinning";
            inward.Show();
        }

        private void canvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_Canvas inward = new RPeP_Canvas();
            inward.MdiParent = this;
            inward.Text = "Production Card For Canvas";
            inward.Show();
        }

        private void scoringSlottingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_ScoringSloting inward = new RPeP_ScoringSloting();
            inward.MdiParent = this;
            inward.Text = "Production Card For Scoring/Sloting";
            inward.Show();
        }

        private void stereoPrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_PrintingStereo inward = new RPeP_PrintingStereo();
            inward.MdiParent = this;
            inward.Text = "Production Card For Top Printing (Not Paper Printed)";
            inward.Show();
        }

        private void punchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_Punching inward = new RPeP_Punching();
            inward.MdiParent = this;
            inward.Text = "Production Card For Punching";
            inward.Show();
        }

        private void pastingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_Pasting inward = new RPeP_Pasting();
            inward.MdiParent = this;
            inward.Text = "Production Card For Pasting";
            inward.Show();
        }

        private void sidePastingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_SidePasting inward = new RPeP_SidePasting();
            inward.MdiParent = this;
            inward.Text = "Production Card For Side Pasting";
            inward.Show();
        }

        private void storeItemIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_StoreItemIssue inward = new RPeP_StoreItemIssue();
            inward.MdiParent = this;
            inward.Text = "Store Item Issue";
            inward.Show();
        }

        private void productionPlanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_ProductionPlaning inward = new RPeP_ProductionPlaning();
            inward.MdiParent = this;
            inward.Text = "Production Planning";
            inward.Show();
        }

        private void planningMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_PlanningMachine inward = new RPeP_PlanningMachine();
            inward.MdiParent = this;
            inward.Text = "Production Planning Machine";
            inward.Show();
        }

        private void programCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPeP_ProgramCard inward = new RPeP_ProgramCard();
            inward.MdiParent = this;
            inward.Text = "Program Card";
            inward.Show();
        }


       
        //private void ShowMasterGroup(object sender, EventArgs e)
        //{
        //    //Displaying Master Form
        //    RPeP_MasterGroup frmMaster = new RPeP_MasterGroup();
        //    frmMaster.MdiParent = this;
        //    frmMaster.Text = "RPeP_GroupMaster";
        //    frmMaster.Show();
        //}

    
    }
}
