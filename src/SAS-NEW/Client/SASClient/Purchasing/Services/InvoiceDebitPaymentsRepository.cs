﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.Services
{
    using SASBAL.Purchasing;
    using SDN.Settings.DAL;
    using SDN.Settings.DALInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Suppliers;
    public class InvoiceDebitPaymentsRepository: IInvoiceDebitPaymentsRepository
    {
        public List<InvoiceDebitPaymentsEntity> GetSuppliersList(string json)
        {
            IInvoiceDebitPaymentsBL pBL = new InvoiceDebitPaymentsBL();
            return pBL.GetSuppliersList(json);
        }
        public List<InvDebitPaymentsDetailsEntity> GetUnPaidInvoices(int supplierID,string json)
        {
            IInvoiceDebitPaymentsBL pBL = new InvoiceDebitPaymentsBL();
            return pBL.GetUnPaidInvoices(supplierID, json);
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IInvoiceDebitPaymentsBL pBL = new InvoiceDebitPaymentsBL();
            return pBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IInvoiceDebitPaymentsBL pBL = new InvoiceDebitPaymentsBL();
            return pBL.GetLastSelectionData(ScreenId);
        }

        public List<YearEntity> GetYearRange()
        {
            IOptionsDAL YearInfo = new OptionsDAL();
            var StartYear = YearInfo.GetYearStart();
            List<YearEntity> YearRange = new List<YearEntity>();
            YearEntity obj = new YearEntity();
            if (StartYear == 0)
            {
                obj.Year = (DateTime.Today.Year - 1).ToString();
                YearRange.Add(obj);

                obj.Year = DateTime.Today.Year.ToString();
                YearRange.Add(obj);
                return YearRange;
            }
            else
            {
                int diff = DateTime.Now.Year - StartYear;
                for (int i = 0; i <= diff; i++)
                {
                    obj = new YearEntity();
                    obj.Year = StartYear.ToString();
                    obj.ID = i;
                    YearRange.Add(obj);
                    StartYear++;
                }
                return YearRange;
            }
        }

        public InvoiceDebitPaymentsEntity GetPrintPurchaseInvoiceDebitPayment(int supplierID,string jsondata)
        {
            IInvoiceDebitPaymentsBL piBL = new InvoiceDebitPaymentsBL();
            return piBL.GetPrintPurchaseInvoiceDebitPayment(supplierID, jsondata);
        }
    }
}