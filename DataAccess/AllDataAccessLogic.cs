using ePacker1.App_Code;
using ePacker1.Business_Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ePacker1.DataAccess
{
    class AllDataAccessLogic
    {
        public DataTable GetAllCityMaster(string spName)
        {
            DataTable dtGetAllCityMaster = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                       
                        ConnectionInstance.Open();
                        using (SqlDataAdapter daGetAllCityMaster = new SqlDataAdapter(CommandInstance))
                        {
                            daGetAllCityMaster.Fill(dtGetAllCityMaster);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dtGetAllCityMaster;
        }

        public DataTable GetAllStateMaster(string spName)
        {
            DataTable dtGetAllStateMaster = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        ConnectionInstance.Open();
                        using (SqlDataAdapter daGetAllStateMaster = new SqlDataAdapter(CommandInstance))
                        {
                            daGetAllStateMaster.Fill(dtGetAllStateMaster);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dtGetAllStateMaster;
        }

        #region PAPER QUALITY MASTER
        public DataTable GetAllItemBFMasterData(string spName, Dictionary<string, string> param)
        {
            DataTable dtAllItemBFMaster = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter daAllItemBFMaster = new SqlDataAdapter(CommandInstance))
                        {
                            daAllItemBFMaster.Fill(dtAllItemBFMaster);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dtAllItemBFMaster;
        }

        public DataTable GetAllGSMMasterData(string spName, Dictionary<string, string> param)
        {
            DataTable dtAllGSMMaster = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter daAllGSMMaster = new SqlDataAdapter(CommandInstance))
                        {
                            daAllGSMMaster.Fill(dtAllGSMMaster);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dtAllGSMMaster;
        }

        public DataTable GetAllPaperQualityData(string spName, Dictionary<string, string> param)
        {
            DataTable dtAllPaperQualityData = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter daAllPaperQualityData = new SqlDataAdapter(CommandInstance))
                        {
                            daAllPaperQualityData.Fill(dtAllPaperQualityData);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dtAllPaperQualityData;
        }

        public void AddEditDeletePaperQualityData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }

                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();

                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }

        public DataTable GetAllPaperQualityDataById(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }
        #endregion

        #region PARTY MAIN MASTER

        public DataTable GetAllPartyMainMasterData(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public DataTable GetAllActivePartyMainMasterData(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public void AddEditDeletePartyMainMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }

                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();

                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }

        public DataTable GetAllActivePaperQualityMasterData(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        #endregion

        #region PARTY MASTER

        public DataTable GetAllPartyMasterDataByMainPartyId(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public void AddEditDeletePartyMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }

                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();

                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }

        public DataTable GetAllActivePartyMasterData(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        #endregion

        #region AGENT MASTER     

        public DataTable GetAllAgentDataByAgentName(string spName, Dictionary<string, string> param)
        {
            DataTable lstGetAllAgentDataByAgentName = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(lstGetAllAgentDataByAgentName);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return lstGetAllAgentDataByAgentName;
        }

        public void AddEditDeleteAgentMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }

                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();

                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }
        #endregion

        #region Mill MASTER

        public DataTable GetAllMillDataByMillName(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public void AddEditDeleteMillMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }

                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();

                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }
        #endregion

        #region AGENT MILL LINK MASTER

        public DataTable GetAllAgentMillLinkMasterDataByAgent(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public void AddDeleteAgentMillLinkData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }

                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();

                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }
        #endregion

        #region CONTRACTOR MASTER

        public DataTable GetAllContractorDataByContractorName(string spName, Dictionary<string, string> param)
        {
            DataTable dtGetAllContractorDataByContractorName = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dtGetAllContractorDataByContractorName);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dtGetAllContractorDataByContractorName;
        }

        public void AddEditDeleteContractorMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }

                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();

                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region MACHINE TYPE MASTER

        public DataTable GetAllActiveMachineType(string spName)
        {
            DataTable dtGetAllActiveMachineType = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        ConnectionInstance.Open();
                        using (SqlDataAdapter daGetAllActiveMachineType = new SqlDataAdapter(CommandInstance))
                        {
                            daGetAllActiveMachineType.Fill(dtGetAllActiveMachineType);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dtGetAllActiveMachineType;
        }

        #endregion

        #region REGION MASTER

        public DataTable GetAllRegionDataByRegionName(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public void AddEditDeleteRegionMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }
                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();
                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region DELIVERY MASTER REGION

        public DataTable GetAllDeliveryMasterDataByPartyIdName(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public void AddEditDeleteDeliveryMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }
                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();
                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region MACHINE TYPE MASTER

        public void AddEditDeleteMachineTypeMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }
                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();
                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region MACHINE MASTER

        public void AddEditDeleteMachineMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }
                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();
                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region DRIVER MASTER

        public DataTable GetAllDriverDataByDriverName(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public void AddEditDeleteDriverMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }
                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();
                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region LAMINATION MASTER

        public DataTable GetAllActiveLaminationData(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }
        #endregion

        #region VARNISH MASTER

        public DataTable GetAllActiveVarnishData(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }
        #endregion

        #region POSITIVE MASTER

        public DataTable GetAllActivePositiveData(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public DataTable GetAllPositiveMasterData(string spName, Dictionary<string, string> param)
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public void AddEditDeletePositiveMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }

                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();

                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }
        #endregion

        #region TOP PAPER

        public void AddEditDeleteTopPaperMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }

                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();

                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region ITEM STYLE MASTER

        public void AddEditDeleteItemStyleMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }

                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();

                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region ITEM MASTER

        public DataTable GetAllItemDataByName(string spName, Dictionary<string, string> param)
        {
            DataTable lstGetAllItemDataByName = new DataTable();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;
                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            { CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value); }
                        }
                        ConnectionInstance.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandInstance))
                        {
                            da.Fill(lstGetAllItemDataByName);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return lstGetAllItemDataByName;
        }

        public void AddEditDeleteItemMasterData(string spName, Dictionary<string, string> param, ref Dictionary<string, string> paramOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            try
            {
                using (SqlConnection ConnectionInstance = new SqlConnection(connectionString))
                {
                    using (SqlCommand CommandInstance = new SqlCommand(spName, ConnectionInstance))
                    {
                        CommandInstance.CommandTimeout = 500;
                        CommandInstance.CommandType = CommandType.StoredProcedure;

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, string> para in param)
                            {
                                CommandInstance.Parameters.AddWithValue(string.Format("@{0}", para.Key), para.Value);
                            }
                        }

                        if (paramOut != null)
                        {
                            foreach (KeyValuePair<string, string> para in paramOut)
                            {
                                SqlParameter parameterInstance = new SqlParameter();
                                parameterInstance.ParameterName = string.Format("@{0}", para.Key);
                                TypeConverter tc = TypeDescriptor.GetConverter(parameterInstance.DbType);
                                parameterInstance.DbType = (DbType)tc.ConvertFrom(Type.GetType(para.Value).Name);
                                parameterInstance.Direction = ParameterDirection.Output;
                                CommandInstance.Parameters.Add(parameterInstance);
                            }
                        }
                        ConnectionInstance.Open();
                        SqlDataReader ReaderInstance = CommandInstance.ExecuteReader();

                        Dictionary<string, string> paramOutClone = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> para in paramOut)
                        {
                            paramOutClone.Add(para.Key, Convert.ToString(CommandInstance.Parameters[string.Format("@{0}", para.Key)].Value));
                        }
                        paramOut = paramOutClone;
                        paramOutClone = null;
                    }
                }
            }
            catch (Exception ex) {

            }
        }

        #endregion

    }
}
