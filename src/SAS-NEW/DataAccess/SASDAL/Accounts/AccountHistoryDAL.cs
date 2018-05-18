﻿using Newtonsoft.Json;
using SASDAL;
using SDN.UI.Entities;
using SDN.UI.Entities.Accounts;
using SDN.UI.Entities.Export;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Accounts
{
    public class AccountHistoryDAL : IAccountHistoryDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();

        public List<AccountHistoryEntity> GetAllSalesInvoiceJson(string JsonData)
        {
            List<AccountHistoryEntity> InvoiceList = new List<AccountHistoryEntity>();
            try
            {

                if(JsonData!=null)
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                    InvoiceList = entities.Database.SqlQuery<AccountHistoryEntity>("USP_GetAccountHistoryList @Year,@Quarter",
                        new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                          new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue))).ToList();
                }
                else
                {
                    InvoiceList = entities.Database.SqlQuery<AccountHistoryEntity>("USP_GetAccountHistoryList @Year,@Quarter",
                        new SqlParameter("Year", Convert.ToInt32("0")),
                          new SqlParameter("Quarter", Convert.ToInt32("0"))).ToList();
                }
                
            }
            catch (Exception e)
            {

                throw e;
            }
            
            return InvoiceList;
        }
        public List<Account_History_List> ExportAccountHistory(string JsonData,string FileName)
        {
            List<Account_History_List> AccountList = new List<Account_History_List>();
            try
            {
                if (JsonData != null)
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                    AccountList = entities.Database.SqlQuery<Account_History_List>("USP_GetAccountHistoryList @Year,@Quarter",
                        new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                          new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue))).ToList();
                }
                else
                {
                    AccountList = entities.Database.SqlQuery<Account_History_List>("USP_GetAccountHistoryList @Year,@Quarter",
                        new SqlParameter("Year", Convert.ToInt32("0")),
                          new SqlParameter("Quarter", Convert.ToInt32("0"))).ToList();
                }

            }
            catch (Exception e)
            {

                throw e;
            }

            return AccountList;
        }
        public string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Invoice";
            else if (ConvertedToPO == true)
                return "Invoice";
            else
                return "";
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

        public string GetLastSelectionData(int ScreenId)
        {
            try
            {
                DateTime dateTime = DateTime.UtcNow.Date;
                var quarter = (dateTime.Month + 2) / 3;

                var lastQuarter = quarter - 1;
                if (lastQuarter == 0)
                {
                    lastQuarter = 1;
                }
                var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null)
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(result.Last_Selection);
                    objResponse1[0].FieldValue = DateTime.UtcNow.Year.ToString();
                    objResponse1[1].FieldValue = lastQuarter.ToString();
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


        public string GetDateFormat()
        {
            try
            {
                var DateFormatResult = entities.Options.FirstOrDefault();
                string DateFormat = null;
                if (DateFormatResult != null)
                {
                    return DateFormat = DateFormatResult.Date_Format;
                }
                else
                {
                    return DateFormat = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
