
using Newtonsoft.Json;
using SASDAL;
using SDN.Purchasings.DALInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DAL
{
    public class PurchaseInvoiceListDAL : IPurchaseInvoiceListDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<PurchaseInvoiceListEntity> GetAllPurInvoice()
        {
            List<PurchaseInvoiceListEntity> InvoiceList = entities.Database.SqlQuery<PurchaseInvoiceListEntity>("SP_PurchaseInvoiceList").ToList();
            return InvoiceList;
        }

        public List<PurchaseInvoiceListEntity> GetAllPurInvoiceJson(string JsonData, bool? ExcincTax)
        {
            List<PurchaseInvoiceListEntity> InvoiceList = new List<PurchaseInvoiceListEntity>();
            PurchaseInvoiceListEntity InvoiceList1 = new PurchaseInvoiceListEntity();
            List<PurchaseInvoiceListEntity> InvoiceListReturn = new List<PurchaseInvoiceListEntity>();
           
            InvoiceList = entities.Database.SqlQuery<PurchaseInvoiceListEntity>("SP_PurchaseInvoiceList").ToList();
            
            if (JsonData != null && JsonData != "[]")
            {
                DateTime startDate = new DateTime();
                //DateTime endDate = new DateTime();
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                foreach (var item in objResponse1)
                {
                    switch (item.FieldName)
                    {
                        case "Year":
                            var year = Convert.ToInt32(item.FieldValue);
                            InvoiceList = InvoiceList.Where(x => x.InvoiceDateDateTime.Value.Year == year).ToList();
                            break;
                        case "Quarter":
                            switch (item.FieldValue)
                            {
                                case "1":
                                    InvoiceList = InvoiceList.Where(x => x.InvoiceDateDateTime.Value.Month == 1 || x.InvoiceDateDateTime.Value.Month == 2 || x.InvoiceDateDateTime.Value.Month == 3).ToList();
                                    break;
                                case "2":
                                    InvoiceList = InvoiceList.Where(x => x.InvoiceDateDateTime.Value.Month == 4 || x.InvoiceDateDateTime.Value.Month == 5 || x.InvoiceDateDateTime.Value.Month == 6).ToList();
                                    break;
                                case "3":
                                    InvoiceList = InvoiceList.Where(x => x.InvoiceDateDateTime.Value.Month == 7 || x.InvoiceDateDateTime.Value.Month == 8 || x.InvoiceDateDateTime.Value.Month == 9).ToList();
                                    break;
                                case "4":
                                    InvoiceList = InvoiceList.Where(x => x.InvoiceDateDateTime.Value.Month == 10 || x.InvoiceDateDateTime.Value.Month == 11 || x.InvoiceDateDateTime.Value.Month == 12).ToList();
                                    break;
                            }
                            break;
                        case "Month":
                            var month = Convert.ToInt32(item.FieldValue);
                            if(month == 0)
                            {
                                break;
                            }
                            else
                            {
                                InvoiceList = InvoiceList.Where(x => x.InvoiceDateDateTime.Value.Month == month).ToList();
                                break;
                            }
                           
                        case "StartDate":
                            //bool dateValid = DateTime.TryParse(item.FieldValue, out startDate);
                            startDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);
                            //startDate = Convert.ToDateTime(item.FieldValue);
                            //InvoiceList = InvoiceList.Where(x => x.InvoiceDateDateTime ).ToList();
                            break;
                        case "EndDate":
                            //bool dateValid1 = DateTime.TryParse(item.FieldValue, out endDate);
                            DateTime endDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);
                            //  DateTime endDate = Convert.ToDateTime(item.FieldValue);
                            InvoiceList = InvoiceList.Where(x => x.InvoiceDateDateTime > startDate && x.InvoiceDateDateTime < endDate).ToList();
                            break;
                    }
                }
                InvoiceListReturn = InvoiceList;
            }
            else
            {
                InvoiceListReturn = InvoiceList;
            }
            return InvoiceListReturn;
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
        public string GetLastSelectionData()
        {
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    DateTime dateTime = DateTime.UtcNow.Date;
                    var quarter = (dateTime.Month + 2) / 3;

                    var lastQuarter = quarter - 1;
                    if (lastQuarter == 0)
                    {
                        lastQuarter = 1;
                    }
                    var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == 26).FirstOrDefault();
                    if (result != null)
                    {
                        var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(result.Last_Selection);

                        objResponse1[0].FieldValue = DateTime.UtcNow.Year.ToString();
                        objResponse1[1].FieldValue = lastQuarter.ToString();
                        objResponse1[2].FieldValue = "0";
                        var finalresult = JsonConvert.SerializeObject(objResponse1);
                        return finalresult;

                    }
                    else
                        return null;
                }
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
