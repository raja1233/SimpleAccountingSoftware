﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DAL
{
    using EDM;
    using Newtonsoft.Json;
    using SDN.Sales.DALInterface;
    using System.Globalization;
    using UI.Entities;
    using UI.Entities.Sales;

    public class PaymentFromCustomersListDAL: IPaymentFromCustomersListDAL
    {
        SDNSalesDBEntities entities = new SDNSalesDBEntities();
        public List<PaymentFromCustomersListEntity> GetAllPurInvoice()
        {
            List<PaymentFromCustomersListEntity> InvoiceList = new List<PaymentFromCustomersListEntity>();
            var invoiceList = (from cb in entities.CashAndBankTransactions
                               join s in entities.Customers
                               on cb.Cus_Sup_Id equals s.ID
                               where cb.Type=="C"
                               select new PaymentFromCustomersListEntity
                               {
                                   ID = cb.ID,
                                   Cus_ID = s.ID,
                                   CustomerName = s.Cus_Name,
                                   CashChequeNo = cb.Cash_Cheque_No,
                                   CashChequeDateDate = cb.Cash_Cheque_Date,
                                   CashChequeAmount = cb.Amount,
                                   InvoiceNo = cb.SO_CN_PO_DN_No,
                                   InvoiceDateDateTime = cb.SO_CN_PO_DN_Date,
                                   InvoiceAmountValue = cb.SO_CN_PO_DN_Amt,
                                   IsCheque = cb.Is_Cheque,
                                   CreatedDate = cb.UpdatedDate
                               }).ToList<PaymentFromCustomersListEntity>();

            if (invoiceList != null)
            {
                InvoiceList = invoiceList;
            }
            return InvoiceList;
        }

        public List<PaymentFromCustomersListEntity> GetAllPurInvoiceJson(string JsonData)
        {
            List<PaymentFromCustomersListEntity> InvoiceList = new List<PaymentFromCustomersListEntity>();
            PaymentFromCustomersListEntity InvoiceList1 = new PaymentFromCustomersListEntity();
            List<PaymentFromCustomersListEntity> InvoiceListReturn = new List<PaymentFromCustomersListEntity>();


            // InvoiceList = entities.Database.SqlQuery<PaymentFromCustomersListEntity>("Sp_PurchaseInvoiceList").ToList();

            var invoiceList = (from cb in entities.CashAndBankTransactions
                               join s in entities.Customers
                               on cb.Cus_Sup_Id equals s.ID
                               where cb.Type == "C"
                               select new PaymentFromCustomersListEntity
                               {
                                   ID = cb.ID,
                                   Cus_ID = s.ID,
                                   CustomerName = s.Cus_Name,
                                   CashChequeNo = cb.Cash_Cheque_No,
                                   CashChequeDateDate = cb.Cash_Cheque_Date,
                                   CashChequeAmount = cb.Amount,
                                   InvoiceNo = cb.SO_CN_PO_DN_No,
                                   InvoiceDateDateTime = cb.SO_CN_PO_DN_Date,
                                   InvoiceAmountValue = cb.SO_CN_PO_DN_Amt,
                                   IsCheque = cb.Is_Cheque,
                                   CreatedDate = cb.UpdatedDate
                               }).ToList<PaymentFromCustomersListEntity>();

            if (invoiceList != null)
            {
                InvoiceList = invoiceList;
            }

            if (JsonData != null && JsonData != "[]")
            {
                DateTime startDate = new DateTime();
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                foreach (var item in objResponse1)
                {
                    switch (item.FieldName)
                    {
                        case "Year":
                            var year = Convert.ToInt32(item.FieldValue);
                            InvoiceList = InvoiceList.Where(x => x.CreatedDate.Value.Year == year).ToList();
                            break;
                        case "Quarter":
                            switch (item.FieldValue)
                            {
                                case "1":
                                    InvoiceList = InvoiceList.Where(x => x.CreatedDate.Value.Month == 1 || x.CreatedDate.Value.Month == 2 || x.CreatedDate.Value.Month == 3).ToList();
                                    break;
                                case "2":
                                    InvoiceList = InvoiceList.Where(x => x.CreatedDate.Value.Month == 4 || x.CreatedDate.Value.Month == 5 || x.CreatedDate.Value.Month == 6).ToList();
                                    break;
                                case "3":
                                    InvoiceList = InvoiceList.Where(x => x.CreatedDate.Value.Month == 7 || x.CreatedDate.Value.Month == 8 || x.CreatedDate.Value.Month == 9).ToList();
                                    break;
                                case "4":
                                    InvoiceList = InvoiceList.Where(x => x.CreatedDate.Value.Month == 10 || x.CreatedDate.Value.Month == 11 || x.CreatedDate.Value.Month == 12).ToList();
                                    break;
                            }
                            break;
                        case "Month":
                            var month = Convert.ToInt32(item.FieldValue);
                            InvoiceList = InvoiceList.Where(x => x.CreatedDate.Value.Month == month).ToList();
                            break;
                        case "StartDate":
                            //startDate = Convert.ToDateTime(item.FieldValue);
                            startDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);
                            //InvoiceList = InvoiceList.Where(x => x.InvoiceDateDateTime ).ToList();
                            break;
                        case "EndDate":
                            //DateTime endDate = Convert.ToDateTime(item.FieldValue);
                            DateTime endDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);
                            InvoiceList = InvoiceList.Where(x => x.CreatedDate > startDate && x.CreatedDate < endDate).ToList();
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