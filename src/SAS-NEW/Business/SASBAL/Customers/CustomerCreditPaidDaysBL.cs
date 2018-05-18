﻿using SASDAL.Customers;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Customers
{
    public class CustomerCreditPaidDaysBL : ICustomerCreditPaidDaysBL
    {

        public List<CustomerCreditPaidDaysEntity> GetAllSalesInvoiceJson(string jsondata)
        {
            ICustomerCreditPaidDaysDAL purInvoice = new CustomerCreditPaidDaysDAL();
            var Invoicelist = purInvoice.GetAllSalesInvoiceJson(jsondata);
            return Invoicelist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICustomerCreditPaidDaysDAL purInvoice = new CustomerCreditPaidDaysDAL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ICustomerCreditPaidDaysDAL purInvoice = new CustomerCreditPaidDaysDAL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ICustomerCreditPaidDaysDAL purInvoice = new CustomerCreditPaidDaysDAL();
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
                    obj.Year = StartYear.ToString();
                    YearRange.Add(obj);
                    StartYear++;
                }
                return YearRange;
            }
        }

        public TaxModel GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetAllTaxes().FirstOrDefault();
        }
        public OptionsEntity GetOptionSettings()
        {

            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }
    }
}
