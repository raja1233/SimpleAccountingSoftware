//using Newtonsoft.Json;
using Newtonsoft.Json;
using SDN.Purchasings.DALInterface;
using SDN.PurchasingsEDM;
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
        SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities();
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
            ////InvoiceList = entities.PurchaseInvoices.Join(entities.Suppliers, y => y.Sup_Id, x => x.ID, (x, y) => new PurchaseInvoiceListEntity
            ////{
            ////    ID = x.ID,
            ////    SupplierName = y.Sup_Name,
            ////    Sup_ID = x.Sup_Id,
            ////    InvoiceNo = x.PI_No,
            ////    InvoiceDate = x.PI_Date.ToString(),
            ////    InvoiceAmount = x.PI_Tot_aft_Tax.ToString(),
            ////    InvoiceAmountIncGST = x.PI_Tot_aft_Tax.ToString(),
            ////    InvoiceAmountExcGST = x.PI_Tot_bef_Tax.ToString(),
            ////    //ConvertedToPI = x.PO_Conv_to_PI,
            ////    //ConvertedToPO = x.PO_Conv_to_PO,
            ////    IsDeleted = x.IsDeleted,
            ////    SelectedSearchPQList = x.ID,
            ////    CreatedDate = x.PI_Date,
            ////    CreatedDateList = x.CreatedDate,
            ////    ExcIncGST = x.Exc_Inc_GST,
            ////    InvoiceDateDateTime = x.PI_Date
            ////}).Where(w => w.IsDeleted != true && w.ExcIncGST == ExcincTax).ToList();

            //InvoiceList = (from i in entities.PurchaseInvoices
            //               join s in entities.Suppliers
            //               on i.Sup_Id equals s.ID
            //               join cbt in entities.CashAndBankTransactions
            //               on s.ID equals cbt.Cus_Sup_Id into cbtej
            //               from cbt in cbtej.DefaultIfEmpty()
            //               join d in entities.DebitNotes on i.ID equals d.PI_Id into ej
            //               from d in ej.DefaultIfEmpty()
            //               where i.IsDeleted != true && d.IsDeleted != true
            //               select new PurchaseInvoiceListEntity
            //               {
            //                   ID = i.ID,
            //                   Sup_ID = i.Sup_Id,
            //                   ExcIncGST = i.Exc_Inc_GST,
            //                   DebitNoteAmount = d.Sup_CN_Amount,
            //                   DebitNoteDate = d.DN_Date.ToString(),
            //                   DebitNoteNo = d.DN_No,
            //                   SupplierName = s.Sup_Name,
            //                   Status = i.PI_Status,
            //                   InvoiceNo = i.PI_No,
            //                   InvoiceDate = i.PI_Date.ToString(),
            //                   InvoiceAmount = i.PI_Tot_aft_Tax.ToString(),
            //                   IsDeleted = i.IsDeleted,
            //                   CashChequeAmount = cbt.Amount,
            //                   CashChequeDate = cbt.Cash_Cheque_Date.ToString(),
            //                   CashChequeNo = cbt.Cash_Cheque_No

            //               }).ToList();

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
                            InvoiceList = InvoiceList.Where(x => x.InvoiceDateDateTime.Value.Month == month).ToList();
                            break;
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
