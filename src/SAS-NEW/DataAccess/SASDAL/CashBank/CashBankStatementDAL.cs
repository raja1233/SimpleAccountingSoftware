﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.CashandBank;
using System.Data.SqlClient;
using Newtonsoft.Json;
using SDN.UI.Entities;
using SDN.UI.Entities.Export;

namespace SASDAL.CashBank
{
    public class CashBankStatementDAL : ICashBankStatementDAL
    {

        SASEntitiesEDM entities = new SASEntitiesEDM();
       
        /// <summary>
        /// method to bring account name from db
        /// </summary>
        /// <returns></returns>
        public List<CashBankStatementEntity> GetBankAccountList()
        {

            List<CashBankStatementEntity> AccountList = new List<CashBankStatementEntity>();
            try
            {
                AccountList = entities.Database.SqlQuery<CashBankStatementEntity>("USP_GetBankAccountName").ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return AccountList;
        }


        /// <summary>
        /// method to bring detail list from  db
        /// </summary>
        /// <returns></returns>
        /// 

        public List<CashBankStatementEntity> GetAccountDetailList(int CashBankStatementID, string jsondata)
        {


            List<CashBankStatementEntity> AccountDetailList = new List<CashBankStatementEntity>();
           
            try
            {
                if (CashBankStatementID != 0 && jsondata == null)
                {

                    AccountDetailList = entities.Database.SqlQuery<CashBankStatementEntity>("USP_GetBankAccountDetailtest @CashBankStatementID,@year,@Quarter,@Month",
                        new SqlParameter("CashBankStatementID", CashBankStatementID),
                        new SqlParameter("year", Convert.ToInt32(0)),
                        new SqlParameter("Quarter", Convert.ToInt32(0)),
                        new SqlParameter("Month", Convert.ToInt32(0))).ToList();

                } 
                else if(CashBankStatementID!=0)
                {
                   
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);
                    AccountDetailList = entities.Database.SqlQuery<CashBankStatementEntity>("USP_GetBankAccountDetailtest @CashBankStatementID,@year,@Quarter,@Month",
                      new SqlParameter("CashBankStatementID", CashBankStatementID),
                      new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                        new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                          new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue))).ToList();

                }
               
            }
            catch (Exception e)
            {
                throw e;
            }
            return AccountDetailList;
        }
        public List<Cash_and_Bank_Statement> GetExportDataList(int CashBankStatementID, string jsondata, string FileName)
        {
            List<Cash_and_Bank_Statement> exportdata = new List<Cash_and_Bank_Statement>();
            try
            {
                if (CashBankStatementID != 0 && jsondata==null)
                {

                    exportdata = entities.Database.SqlQuery<Cash_and_Bank_Statement>("USP_ExportGetBankAccountDetail @CashBankStatementID,@year,@Quarter,@Month",
                        new SqlParameter("CashBankStatementID", CashBankStatementID),
                        new SqlParameter("year", Convert.ToInt32(0)),
                        new SqlParameter("Quarter", Convert.ToInt32(0)),
                        new SqlParameter("Month", Convert.ToInt32(0))).ToList();

                }
                else
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);
                    exportdata = entities.Database.SqlQuery<Cash_and_Bank_Statement>("USP_ExportGetBankAccountDetail @CashBankStatementID,@year,@Quarter,@Month",
                      new SqlParameter("CashBankStatementID", CashBankStatementID),
                      new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                        new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                          new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue))).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return exportdata;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            try
            {
                DateTime dateTime = DateTime.UtcNow.Date;
                var month = dateTime.Month;

                var lastMonth = month - 1;
                if (lastMonth == 0)
                {
                    lastMonth = 1;
                }
                var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null)
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(result.Last_Selection);
                    objResponse1[0].FieldValue = DateTime.UtcNow.Year.ToString();
                    objResponse1[1].FieldValue = "0";
                    objResponse1[2].FieldValue = lastMonth.ToString();
                    var finalresult = JsonConvert.SerializeObject(objResponse1);
                    return finalresult;
                }

                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            try
            {
                var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null)
                {
                    result.Last_Selection = jsonSearch;
                    result.Last_Updated = DateTime.Now;
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    LastSelectionHistory lastSelection = new LastSelectionHistory()
                    {
                        Screen_Id = ScreenId,
                        Screen_Name = ScreenName,
                        Last_Selection = jsonSearch,
                        Last_Updated = DateTime.Now
                    };
                    entities.LastSelectionHistories.Add(lastSelection);
                    entities.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

