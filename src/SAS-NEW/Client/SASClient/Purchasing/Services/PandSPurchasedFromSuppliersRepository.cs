using SASBAL.Purchasing;
using SDN.UI.Entities;
using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.Services
{
    public class PandSPurchasedFromSuppliersRepository : IPandSPurchasedFromSuppliersRepository
    {
        public List<PandSPurchasedFromSuppliersEntity> GetPandSPurchasedFromSuppliersList()
        {
            IPandSPurchasedFromSuppliersBL pandsSoldBL = new PandSPurchasedFromSuppliersBL();
            return pandsSoldBL.GetAllSalesInvoice();
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPandSPurchasedFromSuppliersBL pandsSoldBL = new PandSPurchasedFromSuppliersBL();
            return pandsSoldBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }



        public List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary)
        {

            IPandSPurchasedFromSuppliersBL pandsSoldBL = new PandSPurchasedFromSuppliersBL();
            List<PandSPurchasedFromSuppliersEntity> quotationlist = pandsSoldBL.GetAllSalesInvoiceJson(jsondata, ExcincTax, IsSummary);
            return quotationlist;
        }
        public List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoice()
        {

            IPandSPurchasedFromSuppliersBL pandsSoldBL = new PandSPurchasedFromSuppliersBL();
            List<PandSPurchasedFromSuppliersEntity> Invoicelist = pandsSoldBL.GetAllSalesInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            IPandSPurchasedFromSuppliersBL pandsSoldBL = new PandSPurchasedFromSuppliersBL();
            List<YearEntity> yearrange = pandsSoldBL.GetYearRange();
            return yearrange;
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IPandSPurchasedFromSuppliersBL pandsSoldBL = new PandSPurchasedFromSuppliersBL();
            var result = pandsSoldBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPandSPurchasedFromSuppliersBL pandsSoldBL = new PandSPurchasedFromSuppliersBL();
            var result = pandsSoldBL.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IPandSPurchasedFromSuppliersBL pandsSoldBL = new PandSPurchasedFromSuppliersBL();
            return pandsSoldBL.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IPandSPurchasedFromSuppliersBL pandsSoldBL = new PandSPurchasedFromSuppliersBL();
            return pandsSoldBL.GetOptionSettings();

        }
        public string getTotalCount(int ScreenId)
        {
            IPandSPurchasedFromSuppliersBL pandsSoldBL = new PandSPurchasedFromSuppliersBL();
            var result = pandsSoldBL.getTotalCount(ScreenId);
            return result;
        }

    }
}
