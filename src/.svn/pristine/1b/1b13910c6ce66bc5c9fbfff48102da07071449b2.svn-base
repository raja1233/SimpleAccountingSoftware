using SDN.Products.BL;
using SDN.Products.BLInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Export;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{
    public class PandSPurchaseRepository : IPandSPurchaseRepository
    {
        public List<PandSPurchaseEntity> GetPandSPurchaseList()
        {
            IPandSPurchaseBL pandsPurchaseBL = new PandSPurchaseBL();
            return pandsPurchaseBL.GetAllSalesInvoice();
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPandSPurchaseBL pandsPurchaseBL = new PandSPurchaseBL();
            return pandsPurchaseBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }

        public List<ProductandServicePurchaseEntity> GetExportDataList(string jsondata, bool? ExcincTax, bool? IsSummary, string FileName)
        {
            IPandSPurchaseBL exportdata = new PandSPurchaseBL();
            return exportdata.GetExportDataList(jsondata, ExcincTax, IsSummary, FileName);
        }

        public List<PandSPurchaseEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax,bool? IsSummary)
        {

            IPandSPurchaseBL pandsPurchaseBL = new PandSPurchaseBL();
            List<PandSPurchaseEntity> quotationlist = pandsPurchaseBL.GetAllSalesInvoiceJson(jsondata, ExcincTax, IsSummary);
            return quotationlist;
        }
        public List<PandSPurchaseEntity> GetAllSalesInvoice()
        {

            IPandSPurchaseBL pandsPurchaseBL = new PandSPurchaseBL();
            List<PandSPurchaseEntity> Invoicelist = pandsPurchaseBL.GetAllSalesInvoice();
            return Invoicelist;
        }

        public string getTotalCount(int ScreenId)
        {
            IPandSPurchaseBL pandsSoldBL = new PandSPurchaseBL();
            var result = pandsSoldBL.getTotalCount(ScreenId);
            return result;
        }

        public List<YearEntity> GetYearRange()
        {
            IPandSPurchaseBL pandsPurchaseBL = new PandSPurchaseBL();
            List<YearEntity> yearrange = pandsPurchaseBL.GetYearRange();
            return yearrange;
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IPandSPurchaseBL pandsPurchaseBL = new PandSPurchaseBL();
            var result = pandsPurchaseBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPandSPurchaseBL pandsPurchaseBL = new PandSPurchaseBL();
            var result = pandsPurchaseBL.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IPandSPurchaseBL pandsPurchaseBL = new PandSPurchaseBL();
            return pandsPurchaseBL.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IPandSPurchaseBL pandsPurchaseBL = new PandSPurchaseBL();
            return pandsPurchaseBL.GetOptionSettings();

        }
    }
}
