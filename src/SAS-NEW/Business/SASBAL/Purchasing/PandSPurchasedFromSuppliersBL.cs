﻿using SASDAL.Purchasing;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Purchasing
{
    public class PandSPurchasedFromSuppliersBL : IPandSPurchasedFromSuppliersBL
    {
        public List<PandSPurchasedFromSuppliersEntity> GetPandSPurchasedFromSuppliersList()
        {
            IPandSPurchasedFromSuppliersDAL pandsSoldDAl = new PandSPurchasedFromSuppliersDAL();
            return pandsSoldDAl.GetAllSalesInvoice();
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPandSPurchasedFromSuppliersDAL pandsSoldBL = new PandSPurchasedFromSuppliersDAL();
            return pandsSoldBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }




        public List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoice()
        {
            IPandSPurchasedFromSuppliersDAL pandsSoldDAl = new PandSPurchasedFromSuppliersDAL();
            var Invoicelist = pandsSoldDAl.GetAllSalesInvoice();

            return Invoicelist;
        }
        public List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary)
        {
            IPandSPurchasedFromSuppliersDAL pandsSoldDAl = new PandSPurchasedFromSuppliersDAL();
            var Invoicelist = pandsSoldDAl.GetAllSalesInvoiceJson(jsondata, ExcincTax, IsSummary);

            return Invoicelist;
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IPandSPurchasedFromSuppliersDAL pandsSoldDAl = new PandSPurchasedFromSuppliersDAL();
            var result = pandsSoldDAl.GetLastSelectionData(ScreenId);
            return result;
        }
        public string getTotalCount(int ScreenId)
        {
            IPandSPurchasedFromSuppliersDAL pandsSoldDAl = new PandSPurchasedFromSuppliersDAL();
            var result = pandsSoldDAl.getTotalCount(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPandSPurchasedFromSuppliersDAL pandsSoldDAl = new PandSPurchasedFromSuppliersDAL();
            var result = pandsSoldDAl.GetDateFormat();
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
            return objTax.GetAllTaxes().FirstOrDefault();
        }
        public OptionsEntity GetOptionSettings()
        {

            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }
    }
}
