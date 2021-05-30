using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePacker1.Business_Entity;
using ePacker1.DataAccess;

namespace ePacker1.Business_Logic
{
    class AllBusinessLogic
    {

        public DataTable GetAllCityMaster()
        {
            DataTable dtGetAllCityMaster = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                dtGetAllCityMaster = da.GetAllCityMaster("USP_GetAllCityMasterData");
            }
            catch (Exception) { }
            return dtGetAllCityMaster;
        }

        public DataTable GetAllStateMaster()
        {
            DataTable dtGetAllStateMaster = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                dtGetAllStateMaster = da.GetAllStateMaster("USP_GetAllStateMasterData");
            }
            catch (Exception) { }
            return dtGetAllStateMaster;
        }

        #region PAPER QUALITY REGION
        public DataTable GetAllItemBFMasterData(string Group_ID)
        {
            DataTable dtAllItemBFMaster = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dtAllItemBFMaster = da.GetAllItemBFMasterData("USP_GetAllItemBFMasterData", dictionaryInstance);
            }
            catch (Exception) { }
            return dtAllItemBFMaster;
        }

        public DataTable GetAllGSMMasterData(string Group_ID)
        {
            DataTable dtAllGSMMaster = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dtAllGSMMaster = da.GetAllGSMMasterData("USP_GetAllGSMMasterData", dictionaryInstance);
            }
            catch (Exception) { }
            return dtAllGSMMaster;
        }

        public DataTable GetAllPaperQualityData(string Group_ID)
        {
            DataTable dtGetAllPaperQualityData = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dtGetAllPaperQualityData = da.GetAllPaperQualityData("USP_GetAllPaperQualityData", dictionaryInstance);
            }
            catch (Exception) { }
            return dtGetAllPaperQualityData;
        }

        public bool AddEditDeletePaperQualityData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeletePaperQualityData("USP_AddEditDeletePaperQualityData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        public DataTable GetAllActivePaperQualityMasterData(string Group_ID)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dt = da.GetAllActivePaperQualityMasterData("USP_GetAllActivePaperQualityMasterData", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable GetAllPaperQualityDataById(string Group_ID,string PqId)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dictionaryInstance.Add("PQ_Id", Convert.ToString(PqId));
                dt = da.GetAllPaperQualityData("USP_GetAllPaperQualityDataById", dictionaryInstance);
            }
            catch (Exception) { }
            return dt;
        }

        #endregion

        #region PARTY MAIN MASTER
        public DataTable GetAllPartyMainMasterData(string Group_ID)
        {
            DataTable dtGetAllPartyMainMasterData = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dtGetAllPartyMainMasterData = da.GetAllPartyMainMasterData("USP_GetAllPartyMainMasterData", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dtGetAllPartyMainMasterData;
        }

        public DataTable GetAllActivePartyMainMasterData(string Group_ID)
        {
            DataTable dtGetAllPartyMainMasterData = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dtGetAllPartyMainMasterData = da.GetAllActivePartyMainMasterData("USP_GetAllActivePartyMainMasterData", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dtGetAllPartyMainMasterData;
        }

        public bool AddEditDeletePartyMainMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeletePartyMainMasterData("USP_AddEditDeletePartyMainMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }
        #endregion

        #region PARTY MASTER

        public DataTable GetAllPartyMasterDataByMainPartyId(string GroupId, string MainPartyId, string PartyName)
        {
            DataTable dtGetAllPartyMasterData = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                if (MainPartyId == "0")
                {
                    MainPartyId = "";
                }
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(GroupId));
                dictionaryInstance.Add("PartyMainId", Convert.ToString(MainPartyId));
                dictionaryInstance.Add("PartyName", Convert.ToString(PartyName));
                dtGetAllPartyMasterData = da.GetAllPartyMasterDataByMainPartyId("USP_GetAllPartyMasterDataByMainPartyId", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dtGetAllPartyMasterData;
        }

        public bool AddEditDeletePartyMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeletePartyMasterData("USP_AddEditDeletePartyMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        public DataTable GetAllActivePartyMasterData(string Group_ID)
        {
            DataTable dtGetAllPartyMainMasterData = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dtGetAllPartyMainMasterData = da.GetAllActivePartyMasterData ("USP_GetAllActivePartyMasterData", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dtGetAllPartyMainMasterData;
        }

        #endregion

        #region AGENT REGION

        public DataTable GetAllActiveAgentDataByAgentName(string GroupId, string AgentName)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(GroupId));
                dictionaryInstance.Add("AgentName", Convert.ToString(AgentName));
                dt = da.GetAllAgentDataByAgentName("USP_GetAllActiveAgentDataByAgentName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable GetAllAgentDataByAgentName(string GroupId, string AgentName)
        {
            DataTable lstGetAllAgentDataByAgentName = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(GroupId));
                dictionaryInstance.Add("AgentName", Convert.ToString(AgentName));
                lstGetAllAgentDataByAgentName = da.GetAllAgentDataByAgentName("USP_GetAllAgentDataByAgentName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return lstGetAllAgentDataByAgentName;
        }

        public bool AddEditDeleteAgentMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeleteAgentMasterData("USP_AddEditDeleteAgentMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region MILL REGION

        public DataTable GetAllActiveMillDataByMillName(string GroupId, string MillName)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(GroupId));
                dictionaryInstance.Add("MillName", Convert.ToString(MillName));
                dt = da.GetAllMillDataByMillName("USP_GetAllActiveMillDataByMillName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable GetAllMillDataByMillName(string GroupId, string MillName)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(GroupId));
                dictionaryInstance.Add("MillName", Convert.ToString(MillName));
                dt = da.GetAllMillDataByMillName("USP_GetAllMillDataByMillName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        public bool AddEditDeleteMillMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeleteMillMasterData("USP_AddEditDeleteMillMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region AGENT MILL LINK REGION

        public DataTable GetAllAgentMillLinkMasterDataByAgent(string GroupId, string AgentName)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(GroupId));
                dictionaryInstance.Add("AgentName", Convert.ToString(AgentName));
                dt = da.GetAllAgentMillLinkMasterDataByAgent("USP_GetAllAgentMillLinkMasterDataByAgentName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        public bool AddDeleteAgentMillLinkData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddDeleteAgentMillLinkData("USP_AddDeleteAgentMillLinkData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region CONTRACTOR REGION

        public DataTable GetAllContractorDataByContractorName(string GroupId, string ContractorName)
        {
            DataTable ldtGetAllContractorDataByContractorName = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(GroupId));
                dictionaryInstance.Add("ContractorName", Convert.ToString(ContractorName));
                ldtGetAllContractorDataByContractorName = da.GetAllAgentDataByAgentName("USP_GetAllContractorDataByContractorName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return ldtGetAllContractorDataByContractorName;
        }

        public bool AddEditDeleteContractorMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeleteContractorMasterData("USP_AddEditDeleteContractorMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region MACHINE TYPE REGION

        public DataTable GetAllActiveMachineType()
        {
            DataTable dtGetAllActiveMachineType = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                dtGetAllActiveMachineType = da.GetAllActiveMachineType("USP_GetAllActiveMachineType");
            }
            catch (Exception) { }
            return dtGetAllActiveMachineType;
        }

        #endregion

        #region REGION MASTER

        public DataTable GetAllRegionDataByRegionName(string GroupId, string AgentName)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(GroupId));
                dictionaryInstance.Add("RegionName", Convert.ToString(AgentName));
                dt = da.GetAllRegionDataByRegionName("USP_GetAllRegionDataByRegionName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        public bool AddEditDeleteRegionMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeleteRegionMasterData("USP_AddEditDeleteRegionMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region DELIVERY MASTER REGION


        public DataTable GetAllDeliveryMasterDataByPartyIdName(string Group_ID, string PartyId, string PartyName)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                if (PartyId == "0")
                {
                    PartyId = "";
                }
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dictionaryInstance.Add("PartyMainId", Convert.ToString(PartyId));
                dictionaryInstance.Add("PartyName", Convert.ToString(PartyName));
                dt = da.GetAllDeliveryMasterDataByPartyIdName("USP_GetAllDeliveryMasterDataByPartyIdName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        public bool AddEditDeleteDeliveryMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeleteRegionMasterData("USP_AddEditDeleteDeliveryMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region MACHINE TYPE MASTER

        public bool AddEditDeleteMachineTypeMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeleteMachineTypeMasterData("USP_AddEditDeleteMachineTypeMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region MACHINE MASTER

        public bool AddEditDeleteMachineMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeleteMachineMasterData("USP_AddEditDeleteMachineMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region DRIVER MASTER

        public DataTable GetAllDriverDataByDriverName(string GroupId, string DriverName)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(GroupId));
                dictionaryInstance.Add("DriverName", Convert.ToString(DriverName));
                dt = da.GetAllDriverDataByDriverName("USP_GetAllDriverDataByDriverName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        public bool AddEditDeleteDriverMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeleteDriverMasterData("USP_AddEditDeleteDriverMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region LAMINATION MASTER

        public DataTable GetAllActiveLaminationData(string Group_ID)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dt = da.GetAllActiveLaminationData("USP_GetAllActiveLaminationData", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        #endregion

        #region VARNISH MASTER

        public DataTable GetAllActiveVarnishData(string Group_ID)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dt = da.GetAllActiveVarnishData("USP_GetAllActiveVarnishData", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        #endregion

        #region POSITIVE MASTER

        public DataTable GetAllActivePositiveData(string Group_ID)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dt = da.GetAllActivePositiveData("USP_GetAllActivePositiveData", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        public DataTable GetAllPositiveMasterData(string Group_ID, string AgentName)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(Group_ID));
                dictionaryInstance.Add("AgentName", Convert.ToString(AgentName));
                dt = da.GetAllPositiveMasterData("USP_GetAllPositiveMasterDataByAgentName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        public bool AddEditDeletePositiveMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeletePositiveMasterData("USP_AddEditDeletePositiveMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region TOP PAPER MASTER

        public DataTable GetAllTopPaperDataByTPName(string GroupId, string TopPaper)
        {
            DataTable dt = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(GroupId));
                dictionaryInstance.Add("TopPaper", Convert.ToString(TopPaper));
                dt = da.GetAllAgentDataByAgentName("USP_GetAllTopPaperDataByTPName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return dt;
        }

        public bool AddEditDeleteTopPaperMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeleteTopPaperMasterData("USP_AddEditDeleteTopPaperMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region STYLE MASTER

        public bool AddEditDeleteItemStyleMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeleteItemStyleMasterData("USP_AddEditDeleteItemStyleMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

        #region ITEM MASTER

        public DataTable GetAllItemDataByNameCode(string GroupId, string ItemNameCode)
        {
            DataTable lstGetAllItemDataByNameCode = new DataTable();
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> dictionaryInstance = new Dictionary<string, string>();
                dictionaryInstance.Add("GroupId", Convert.ToString(GroupId));
                dictionaryInstance.Add("ItemNameCode", Convert.ToString(ItemNameCode));
                lstGetAllItemDataByNameCode = da.GetAllAgentDataByAgentName("USP_GetAllItemDataByName", dictionaryInstance);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return lstGetAllItemDataByNameCode;
        }

        public bool AddEditDeleteItemMasterData(Dictionary<string, string> param)
        {
            bool IsSequenceSet = false;
            AllDataAccessLogic da = new AllDataAccessLogic();
            try
            {
                Dictionary<string, string> SequenceInstance = new Dictionary<string, string>();
                SequenceInstance.Add("IsSequenceSet", Convert.ToString(typeof(bool)));
                da.AddEditDeleteItemMasterData("USP_AddEditDeleteItemMasterData", param, ref SequenceInstance);
                IsSequenceSet = Convert.ToBoolean(SequenceInstance["IsSequenceSet"]);
            }
            catch (Exception ex) { return IsSequenceSet; }
            return IsSequenceSet;
        }

        #endregion

    }
}
