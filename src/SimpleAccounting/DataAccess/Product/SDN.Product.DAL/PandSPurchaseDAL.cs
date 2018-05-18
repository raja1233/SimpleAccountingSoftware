using Newtonsoft.Json;
using SDN.ProductEDM;
using SDN.Products.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DAL
{

    public class PandSPurchaseDAL : IPandSPurchaseDAL
    {
        SDNProductDBEntities entities = new SDNProductDBEntities();
        public List<PandSPurchaseEntity> GetAllSalesInvoice()
        {
            List<PandSPurchaseEntity> InvoiceList = entities.Database.SqlQuery<PandSPurchaseEntity>("USP_GetSuppliersHistory @Year,@Quarter,@IncGST",
                new SqlParameter("Year", 2017),
                  new SqlParameter("Quarter", 2),
                    new SqlParameter("IncGST", true)).ToList();
            return InvoiceList;
            //return null;
        }

        public List<PandSPurchaseEntity> GetAllSalesInvoiceJson(string JsonData, bool? ExcincTax, bool? IsSummary)
        {
            List<PandSPurchaseEntity> InvoiceList = new List<PandSPurchaseEntity>();
            PandSPurchaseEntity InvoiceList1 = new PandSPurchaseEntity();
            List<PandSPurchaseEntity> InvoiceListReturn = new List<PandSPurchaseEntity>();
            if (JsonData != null)
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                InvoiceList = entities.Database.SqlQuery<PandSPurchaseEntity>("USP_PandSPurchase @year,@Quarter,@Month,@IncGST,@ShowAll,@PandS,@SDate,@EDate,@IsSummary",
                   new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                      new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                        new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                        new SqlParameter("IncGST", ExcincTax),
                         new SqlParameter("ShowAll", Convert.ToBoolean(objResponse1[6].FieldValue)),
                           new SqlParameter("PandS", Convert.ToInt32(objResponse1[5].FieldValue)),
                          new SqlParameter("SDate", objResponse1[3].FieldValue),
                            new SqlParameter("EDate", objResponse1[4].FieldValue),
                            new SqlParameter("IsSummary", IsSummary)
                       ).ToList();

            }
            else
            {
                InvoiceList = entities.Database.SqlQuery<PandSPurchaseEntity>("USP_PandSPurchase @year,@Quarter,@Month,@IncGST,@ShowAll,@PandS,@SDate,@EDate,@IsSummary",
               new SqlParameter("year", Convert.ToInt32("0")),
                  new SqlParameter("Quarter", Convert.ToInt32("0")),
                    new SqlParameter("Month", Convert.ToInt32("0")),
                    new SqlParameter("IncGST", ExcincTax),
                     new SqlParameter("ShowAll", Convert.ToBoolean(1)),
                       new SqlParameter("PandS", Convert.ToInt32("0")),
                      new SqlParameter("SDate", ""),
                        new SqlParameter("EDate", ""),
                        new SqlParameter("IsSummary", IsSummary)
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
        public string getTotalCount(int ScreenId)
        {
            PandSPurchaseEntity InvoiceList;
            string count = "0";
            try
            {
                InvoiceList = entities.Database.SqlQuery<PandSPurchaseEntity>("USP_GetAllCountByScreenID @ScreenID",
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
    }
}
