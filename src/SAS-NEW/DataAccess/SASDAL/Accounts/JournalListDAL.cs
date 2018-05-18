﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using System.Data.SqlClient;
using Newtonsoft.Json;
using SDN.UI.Entities;

namespace SASDAL.Accounts
{
    public class JournalListDAL : IJournalListDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
       
        public List<JournalListViewEntity> getJournalDetails(string JSonData)
        {
            List<JournalListViewEntity> listDetails = new List<JournalListViewEntity>();
            try
            {
                if(JSonData==null)
                {
                    listDetails = entities.Database.SqlQuery<JournalListViewEntity>("USP_JournalDetails @year,@Quarter,@Month,@ShowAll,@SDate,@EDate",
                      new SqlParameter("year", Convert.ToInt32(0)),
                      new SqlParameter("Quarter", Convert.ToInt32(0)),
                      new SqlParameter("Month", Convert.ToInt32(0)),
                      new SqlParameter("ShowAll", Convert.ToBoolean(1)),
                      new SqlParameter("SDate", "0"),
                      new SqlParameter("EDate", "0")).ToList();
                }
                else
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JSonData);
                    listDetails = entities.Database.SqlQuery<JournalListViewEntity>("USP_JournalDetails @year,@Quarter,@Month,@ShowAll,@SDate,@EDate",
                      new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                      new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                      new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                      new SqlParameter("ShowAll", Convert.ToBoolean(objResponse1[5].FieldValue)),
                      new SqlParameter("SDate", objResponse1[3].FieldValue),
                      new SqlParameter("EDate", objResponse1[4].FieldValue)).ToList();
                }
                
            }
            catch (Exception e)
            {

                throw e;
            }
            return listDetails;
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
                    //objResponse1[2].FieldValue = "0";
                    //objResponse1[5].FieldValue = "False";
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
