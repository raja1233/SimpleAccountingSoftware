using Newtonsoft.Json;
using SASDAL;
using SDN.Purchasings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Puchase;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DAL
{

    public class SupplierHistoryDAL : ISupplierHistoryDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<SupplierHistoryEntity> GetAllSalesInvoice()
        {
            List<SupplierHistoryEntity> InvoiceList = entities.Database.SqlQuery<SupplierHistoryEntity>("USP_GetSuppliersHistory @Year,@Quarter,@IncGST",
                new SqlParameter("Year", 2017),
                  new SqlParameter("Quarter", 2),
                    new SqlParameter("IncGST", true)).ToList();
            return InvoiceList;
            //return null;
        }

        public List<SupplierHistoryEntity> GetAllSalesInvoiceJson(string JsonData, bool? ExcincTax)
        {
            string ignored = string.Empty;
            List<SupplierHistoryEntity> InvoiceList = new List<SupplierHistoryEntity>();
            SupplierHistoryEntity InvoiceList1 = new SupplierHistoryEntity();
            List<SupplierHistoryEntity> InvoiceListReturn = new List<SupplierHistoryEntity>();
            if (JsonData!=null)
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                InvoiceList = entities.Database.SqlQuery<SupplierHistoryEntity>("USP_GetSuppliersHistory @year,@Quarter,@IncGST",
                    new SqlParameter("year", Convert.ToInt32(objResponse1[0].FieldValue)),
                      new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                        new SqlParameter("IncGST", ExcincTax)).ToList();
            }
            else
            {
                ignored = JsonConvert.SerializeObject(JsonData,
                                Formatting.Indented,
                                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                InvoiceList = entities.Database.SqlQuery<SupplierHistoryEntity>("USP_GetSuppliersHistory @year,@Quarter,@IncGST",
                   new SqlParameter("year", Convert.ToInt32(0)),
                     new SqlParameter("Quarter", Convert.ToInt32(0)),
                       new SqlParameter("IncGST", ExcincTax)).ToList();
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
    }
}
