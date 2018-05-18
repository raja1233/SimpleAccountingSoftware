using Newtonsoft.Json;
using SDN.UI.Entities;
using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Purchasing
{
    public class PandSPurchasedFromSuppliersDAL : IPandSPurchasedFromSuppliersDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoice()
        {
            List<PandSPurchasedFromSuppliersEntity> InvoiceList = entities.Database.SqlQuery<PandSPurchasedFromSuppliersEntity>("USP_GetSuppliersHistory @Year,@Quarter,@IncGST",
                new SqlParameter("Year", 2017),
                  new SqlParameter("Quarter", 2),
                    new SqlParameter("IncGST", true)).ToList();
            return InvoiceList;
            //return null;
        }

        public List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoiceJson(string JsonData, bool? ExcincTax, bool? IsSummary)
        {
            List<PandSPurchasedFromSuppliersEntity> InvoiceList = new List<PandSPurchasedFromSuppliersEntity>();
            PandSPurchasedFromSuppliersEntity InvoiceList1 = new PandSPurchasedFromSuppliersEntity();
            List<PandSPurchasedFromSuppliersEntity> InvoiceListReturn = new List<PandSPurchasedFromSuppliersEntity>();
            if (JsonData != null)
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);

                InvoiceList = entities.Database.SqlQuery<PandSPurchasedFromSuppliersEntity>("USP_PandSPurchasedFromSuppliers @year,@Quarter,@Month,@IncGST,@ShowAll,@PandS,@SDate,@EDate,@IsSummary",
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
                InvoiceList = entities.Database.SqlQuery<PandSPurchasedFromSuppliersEntity>("USP_PandSPurchasedFromSuppliers @year,@Quarter,@Month,@IncGST,@ShowAll,@PandS,@SDate,@EDate,@IsSummary",
               new SqlParameter("Year", Convert.ToInt32("0")),
                  new SqlParameter("Quarter", Convert.ToInt32("0")),
                    new SqlParameter("Month", Convert.ToInt32("0")),
                    new SqlParameter("IncGST", ExcincTax),
                     new SqlParameter("ShowAll", Convert.ToBoolean(1)),
                       new SqlParameter("PandS", Convert.ToInt32("0")),
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
        public string getTotalCount(int ScreenId)
        {
            PandSPurchasedFromSuppliersEntity InvoiceList;
            string count = "0";
            try
            {
                InvoiceList = entities.Database.SqlQuery<PandSPurchasedFromSuppliersEntity>("USP_GetAllCountByScreenID @ScreenID",
                              new SqlParameter("ScreenID", ScreenId)
                               ).FirstOrDefault();

                if (InvoiceList.AllCount != null)
                    count = InvoiceList.AllCount;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }
    }
}
