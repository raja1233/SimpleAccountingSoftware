﻿using Newtonsoft.Json;
using SDN.Sales.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SASDAL;
using System.Data.SqlClient;

namespace SDN.Sales.DAL
{
    public class CreditNoteListDAL: ICreditNoteListDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<CreditNoteListEntity> GetAllSalesCredit() 
        {
            List<CreditNoteListEntity> CreditList = entities.Database.SqlQuery<CreditNoteListEntity>("PRC_CreditNoteList").ToList();

            return CreditList;
        }

        public List<CreditNoteListEntity> GetAllSalesCreditJson(string JsonData, bool? ExcincTax)
        {
            string ignored = string.Empty;
            List<CreditNoteListEntity> CreditList = new List<CreditNoteListEntity>();
            CreditNoteListEntity CreditList1 = new CreditNoteListEntity();
            List<CreditNoteListEntity> CreditListReturn = new List<CreditNoteListEntity>();
           
            if (JsonData!=null)
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                CreditList = entities.Database.SqlQuery<CreditNoteListEntity>("USP_CreditNoteList @year,@Quarter,@Month,@ShowAll,@SDate,@EDate",
                    new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                          new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                            new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                             new SqlParameter("ShowAll", Convert.ToBoolean(objResponse1[3].FieldValue)),
                              new SqlParameter("SDate", objResponse1[4].FieldValue),
                                new SqlParameter("EDate", objResponse1[5].FieldValue)
                                ).ToList();
            }else
            {
                ignored = JsonConvert.SerializeObject(JsonData,
                               Formatting.Indented,
                               new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                CreditList = entities.Database.SqlQuery<CreditNoteListEntity>("USP_CreditNoteList @year,@Quarter,@Month,@ShowAll,@SDate,@EDate",
                   new SqlParameter("Year", Convert.ToInt32(0)),
                         new SqlParameter("Quarter", Convert.ToInt32(0)),
                           new SqlParameter("Month", Convert.ToInt32(0)),
                            new SqlParameter("ShowAll", Convert.ToBoolean(1)),
                             new SqlParameter("SDate", ""),
                               new SqlParameter("EDate", "")
                               ).ToList();
            }
           
            return CreditList;
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
                    objResponse1[2].FieldValue = "0";
                    objResponse1[3].FieldValue = "False";
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
