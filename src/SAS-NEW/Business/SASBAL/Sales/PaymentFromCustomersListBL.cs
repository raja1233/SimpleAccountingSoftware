﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BL
{
    using BLInterface;
    using DAL;
    using DALInterface;
    using SDN.UI.Entities;
    using Settings.DAL;
    using Settings.DALInterface;
    using UI.Entities.Sales;

    public class PaymentFromCustomersListBL : IPaymentFromCustomersListBL
    {
        public List<PaymentFromCustomersListEntity> GetAllPurInvoice()
        {
            IPaymentFromCustomersListDAL purInvoice = new PaymentFromCustomersListDAL();
            var Invoicelist = purInvoice.GetAllPurInvoice();
            foreach (var item in Invoicelist)
            {
                if (item.InvoiceDateDateTime != null)
                {
                    item.InvoiceDate = Convert.ToString(item.InvoiceDateDateTime);

                }
                if (item.InvoiceAmountValue != null)
                {
                    item.InvoiceAmount = Convert.ToString(item.InvoiceAmountValue);
                }

                if (item.CashChequeAmount != null)
                {
                    item.CashAmount = Convert.ToString(item.CashChequeAmount);
                }

                if (item.CashChequeDateDate != null)
                {
                    item.CashChequeDate = Convert.ToString(item.CashChequeDateDate);
                }
            }
            return Invoicelist;
        }

        public List<PaymentFromCustomersListEntity> GetAllPurInvoiceJson(string jsondata)
        {
            IPaymentFromCustomersListDAL purInvoice = new PaymentFromCustomersListDAL();
            var Invoicelist = purInvoice.GetAllPurInvoiceJson(jsondata);
            foreach (var item in Invoicelist)
            {
                if (item.InvoiceDateDateTime != null)
                {
                    item.InvoiceDate = Convert.ToString(item.InvoiceDateDateTime);

                }
                if (item.InvoiceAmountValue != null)
                {
                    item.InvoiceAmount = Convert.ToString(item.InvoiceAmountValue);
                }

                if (item.CashChequeAmount != null)
                {
                    item.CashAmount = Convert.ToString(item.CashChequeAmount);
                }

                if (item.CashChequeDateDate != null)
                {
                    item.CashChequeDate = Convert.ToString(item.CashChequeDateDate);
                }
            }
            return Invoicelist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ISalesInvoiceListDAL purInvoice = new SalesInvoiceListDAL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData()
        {
            IPaymentFromCustomersListDAL purInvoice = new PaymentFromCustomersListDAL();
            var result = purInvoice.GetLastSelectionData();
            return result;
        }
        public string GetDateFormat()
        {
            IPaymentFromCustomersListDAL purInvoice = new PaymentFromCustomersListDAL();
            var result = purInvoice.GetDateFormat();
            return result;
        }

        private string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Invoice";
            else if (ConvertedToPO == true)
                return "Invoice";
            else
                return "";
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

        public TaxModel GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {

            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }

    }
}
