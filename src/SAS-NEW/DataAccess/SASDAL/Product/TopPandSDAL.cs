
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Product
{
    using Newtonsoft.Json;
    using SDN.UI.Entities;
    using SDN.UI.Entities.ProductandServices;
    using System.Data.SqlClient;

    public class TopPandSDAL : ITopPandSDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<TopPandSEntity> GetPandSList(string JsonData)
        {
            List<TopPandSEntity> topPandS = new List<TopPandSEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    if (JsonData != null && JsonData != "[]")
                    {
                        var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                        topPandS = entities.Database.SqlQuery<TopPandSEntity>("USP_GetTopPandS @year, @Quarter,@Month,@IncGST,@ShowAll,@PandS,@SDate,@EDate",
                        new Object[] { new SqlParameter("year", Convert.ToInt64(objResponse1[0].FieldValue)),
                                       new SqlParameter("Quarter", Convert.ToInt64(objResponse1[1].FieldValue)),
                                       new SqlParameter("Month", Convert.ToInt64(objResponse1[2].FieldValue)),
                                       new SqlParameter("IncGST", objResponse1[3].FieldValue),
                                       new SqlParameter("ShowAll", objResponse1[4].FieldValue),
                                       new SqlParameter("PandS", Convert.ToInt64(objResponse1[5].FieldValue)),
                                       new SqlParameter("SDate", objResponse1[6].FieldValue),

                                       new SqlParameter("EDate", objResponse1[7].FieldValue),

                        }
                        ).ToList();
                    }
                    else
                    {
                        topPandS = entities.Database.SqlQuery<TopPandSEntity>("USP_GetTopPandS @year,@Quarter,@Month,@IncGST,@ShowAll,@PandS,@SDate,@EDate",

                                       new SqlParameter("year", Convert.ToInt64(0)),
                                       new SqlParameter("Quarter", Convert.ToInt64(0)),
                                       new SqlParameter("Month", Convert.ToInt64(0)),
                                       new SqlParameter("IncGST", true),
                                       new SqlParameter("ShowAll", true),
                                       new SqlParameter("PandS", Convert.ToInt64(0)),
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

        //List<TopPandSEntity> GetPandSList(string jsonData)

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

        //public string GetLastSelectionData(int ScreenId)
        //{
        //    try
        //    {
        //        var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
        //        if (result != null)
        //            return result.Last_Selection;
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
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
                    objResponse1[2].FieldValue = "0";
                    objResponse1[4].FieldValue = "False";
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
