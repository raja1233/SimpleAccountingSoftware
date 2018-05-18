﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using Newtonsoft.Json;
using SDN.UI.Entities;
using System.Data.SqlClient;

namespace SASDAL.Accounts
{
    public class LedgerDAL : ILedgerDAL
    {
        SASEntitiesEDM entity = new SASEntitiesEDM();
        public List<LedgerEntity> LedgerList(string jsondata)
        {
            string ignored = string.Empty;
            List<LedgerEntity> list = new List<LedgerEntity>();
            try
            {
                if (jsondata==null && jsondata != "[]")
                {
                   
                    ignored = JsonConvert.SerializeObject(jsondata,
                             Formatting.Indented,
                             new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    list = entity.Database.SqlQuery<LedgerEntity>("USP_Ledger @year,@Quarter,@Month,@ShowAll,@SDate,@EDate",
                                 new SqlParameter("Year", Convert.ToInt32(0)),
                                   new SqlParameter("Quarter", Convert.ToInt32(0)),
                                     new SqlParameter("Month", Convert.ToInt32(0)),
                                      new SqlParameter("ShowAll", Convert.ToBoolean(1)),
                                       new SqlParameter("SDate", "0"),
                                         new SqlParameter("EDate", "0")).ToList();
                }
                else
                {
                    if(jsondata != null)
                    {
                        var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);
                        list = entity.Database.SqlQuery<LedgerEntity>("USP_Ledger @year,@Quarter,@Month,@ShowAll,@SDate,@EDate",
                                new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                                 new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                                   new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                                    new SqlParameter("ShowAll", Convert.ToBoolean(objResponse1[5].FieldValue)),
                                     new SqlParameter("SDate", objResponse1[3].FieldValue),
                                       new SqlParameter("EDate", objResponse1[4].FieldValue)).ToList();

                       
                    }

                }
                
            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            try
            {
                var result = entity.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null)
                {
                    result.Last_Selection = jsonSearch;
                    result.Last_Updated = DateTime.Now;
                    entity.SaveChanges();
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
                    entity.LastSelectionHistories.Add(lastSelection);
                    entity.SaveChanges();
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
                var result = entity.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null )
                    return result.Last_Selection;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}