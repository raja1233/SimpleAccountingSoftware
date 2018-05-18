﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Customers.DAL
{
    using Newtonsoft.Json;
    using SDN.Customers.DALInterface;
    using SDN.Customers.EDM;
    using System.Data.SqlClient;
    using UI.Entities;

    public class TopCustomersDAL: ITopCustomersDAL
    {
        SDNCustomersDBEntities entities = new SDNCustomersDBEntities();
        public List<TopCustomersEntity> GetPandSList(string JsonData)
        {
            List<TopCustomersEntity> topPandS = new List<TopCustomersEntity>();
            try
            {
                using (SDNCustomersDBEntities entities = new SDNCustomersDBEntities())
                {
                    if (JsonData != null && JsonData != "[]")
                    {
                        var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                        topPandS = entities.Database.SqlQuery<TopCustomersEntity>("USP_GetTopCustomers @year, @Quarter,@Month,@IncGST,@ShowAll,@SDate,@EDate",
                        new Object[] { new SqlParameter("year", Convert.ToInt64(objResponse1[0].FieldValue)),
                                       new SqlParameter("Quarter", Convert.ToInt64(objResponse1[1].FieldValue)),
                                       new SqlParameter("Month", Convert.ToInt64(objResponse1[2].FieldValue)),
                                       new SqlParameter("IncGST", objResponse1[3].FieldValue),
                                       new SqlParameter("ShowAll", objResponse1[4].FieldValue),
                                       //new SqlParameter("PandS", Convert.ToInt64(objResponse1[5].FieldValue)),
                                       new SqlParameter("SDate", objResponse1[6].FieldValue),

                                       new SqlParameter("EDate", objResponse1[7].FieldValue),

                        }
                        ).ToList();
                    }
                    else
                    {
                        topPandS = entities.Database.SqlQuery<TopCustomersEntity>("USP_GetTopCustomers @year,@Quarter,@Month,@IncGST,@ShowAll,@SDate,@EDate",

                                       new SqlParameter("year", Convert.ToInt64(0)),
                                       new SqlParameter("Quarter", Convert.ToInt64(0)),
                                       new SqlParameter("Month", Convert.ToInt64(0)),
                                       new SqlParameter("IncGST", true),
                                       new SqlParameter("ShowAll", true),
                                       //new SqlParameter("PandS", Convert.ToInt64(0)),
                                       new SqlParameter("SDate", ""),
                                       new SqlParameter("EDate", "")
                                    ).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return topPandS;
        }

        //List<TopCustomersEntity> GetPandSList(string jsonData)

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
                var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null)
                    return result.Last_Selection;
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
