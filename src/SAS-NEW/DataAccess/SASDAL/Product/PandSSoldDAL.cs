﻿using Newtonsoft.Json;
using SASDAL;
using SDN.Products.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Export;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DAL
{

    public class PandSSoldDAL : IPandSSoldDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<PandSSoldEntity> GetAllSalesInvoice()
        {
            List<PandSSoldEntity> InvoiceList = entities.Database.SqlQuery<PandSSoldEntity>("USP_GetSuppliersHistory @Year,@Quarter,@IncGST",
                new SqlParameter("Year", 2017),
                  new SqlParameter("Quarter", 2),
                    new SqlParameter("IncGST", true)).ToList();
            return InvoiceList;
            //return null;
        }

        public List<PandSSoldEntity> GetAllSalesInvoiceJson(string JsonData, bool? ExcincTax, bool? IsSummary)
        {
            string ignored = string.Empty;
            List<PandSSoldEntity> InvoiceList = new List<PandSSoldEntity>();
            PandSSoldEntity InvoiceList1 = new PandSSoldEntity();
            List<PandSSoldEntity> InvoiceListReturn = new List<PandSSoldEntity>();
            if (JsonData != null)
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);

                InvoiceList = entities.Database.SqlQuery<PandSSoldEntity>("USP_PandSSold @year,@Quarter,@Month,@IncGST,@ShowAll,@PandS,@SDate,@EDate,@IsSummary",
                   new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                      new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                        new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                        new SqlParameter("IncGST", ExcincTax),
                         new SqlParameter("ShowAll", Convert.ToBoolean(objResponse1[6].FieldValue)),
                           new SqlParameter("PandS", Convert.ToInt32(objResponse1[5].FieldValue)),
                          new SqlParameter("SDate", objResponse1[3].FieldValue),
                            new SqlParameter("EDate", objResponse1[4].FieldValue),
                            new SqlParameter("IsSummary", Convert.ToBoolean(0))
                       ).ToList();
            }
            else
            {
                ignored = JsonConvert.SerializeObject(JsonData,
                                 Formatting.Indented,
                                 new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                InvoiceList = entities.Database.SqlQuery<PandSSoldEntity>("USP_PandSSold @year,@Quarter,@Month,@IncGST,@ShowAll,@PandS,@SDate,@EDate,@IsSummary",
               new SqlParameter("Year", Convert.ToInt32(0)),
                  new SqlParameter("Quarter", Convert.ToInt32(0)),
                    new SqlParameter("Month", Convert.ToInt32(0)),
                    new SqlParameter("IncGST", ExcincTax),
                     new SqlParameter("ShowAll", 1),
                       new SqlParameter("PandS", Convert.ToInt32(0)),
                      new SqlParameter("SDate", "0"),
                        new SqlParameter("EDate", "0"),
                        new SqlParameter("IsSummary", Convert.ToBoolean(0))
                   ).ToList();

            }

            return InvoiceList;
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
                    objResponse1[6].FieldValue = "False";
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

        public string getTotalCount(int ScreenId)
        {
            PandSSoldEntity InvoiceList;
            string count = "0";
            try
            {
                InvoiceList = entities.Database.SqlQuery<PandSSoldEntity>("USP_GetAllCountByScreenID @ScreenID",
                              new SqlParameter("ScreenID", ScreenId)
                               ).FirstOrDefault();
                if (InvoiceList != null)
                {
                    if (InvoiceList.AllCount != null)
                        count = InvoiceList.AllCount;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
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
        public List<ProductandServiceSoldEntity> GetExportDataList(string jsondata, bool? ExcincTax, bool? IsSummary,string FileName)
        {
            List<ProductandServiceSoldEntity> exportdata = new List<ProductandServiceSoldEntity>();
            try
            {
                if (jsondata != null)
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);

                    exportdata = entities.Database.SqlQuery<ProductandServiceSoldEntity>("USP_PandSSold @year,@Quarter,@Month,@IncGST,@ShowAll,@PandS,@SDate,@EDate,@IsSummary",
                       new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                          new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                            new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                            new SqlParameter("IncGST", ExcincTax),
                             new SqlParameter("ShowAll", Convert.ToBoolean(objResponse1[6].FieldValue)),
                               new SqlParameter("PandS", Convert.ToInt32(objResponse1[5].FieldValue)),
                              new SqlParameter("SDate", objResponse1[3].FieldValue),
                                new SqlParameter("EDate", objResponse1[4].FieldValue),
                                new SqlParameter("IsSummary", Convert.ToBoolean(0))
                           ).ToList();
                }
                else
                {
                    exportdata = entities.Database.SqlQuery<ProductandServiceSoldEntity>("USP_PandSSold @year,@Quarter,@Month,@IncGST,@ShowAll,@PandS,@SDate,@EDate,@IsSummary",
                   new SqlParameter("Year", 0),
                      new SqlParameter("Quarter", 0),
                        new SqlParameter("Month", 0),
                        new SqlParameter("IncGST", ExcincTax),
                         new SqlParameter("ShowAll", 1),
                           new SqlParameter("PandS", 0),
                          new SqlParameter("SDate", "0"),
                            new SqlParameter("EDate", "0"),
                            new SqlParameter("IsSummary", Convert.ToBoolean(0))
                       ).ToList();

                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return exportdata;
        }
        
    }
}
