using SDN.Products.BL;
using SDN.Products.BLInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{
    public class PandSSoldRepository: IPandSSoldRepository
    {
        public List<PandSSoldEntity> GetPandSSoldList()
        {
            IPandSSoldBL pandsSoldBL = new PandSSoldBL();
            return pandsSoldBL.GetAllSalesInvoice();
        }
       public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPandSSoldBL pandsSoldBL = new PandSSoldBL();
            return pandsSoldBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }



        public List<PandSSoldEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary)
        {

            IPandSSoldBL pandsSoldBL = new PandSSoldBL();
            List<PandSSoldEntity> quotationlist = pandsSoldBL.GetAllSalesInvoiceJson(jsondata, ExcincTax,IsSummary);
            return quotationlist;
        }
        public List<PandSSoldEntity> GetAllSalesInvoice()
        {

            IPandSSoldBL pandsSoldBL = new PandSSoldBL();
            List<PandSSoldEntity> Invoicelist = pandsSoldBL.GetAllSalesInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            IPandSSoldBL pandsSoldBL = new PandSSoldBL();
            List<YearEntity> yearrange = pandsSoldBL.GetYearRange();
            return yearrange;
        }
        
        public string GetLastSelectionData(int ScreenId)
        {
            IPandSSoldBL pandsSoldBL = new PandSSoldBL();
            var result = pandsSoldBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public string getTotalCount(int ScreenId)
        {
            IPandSSoldBL pandsSoldBL = new PandSSoldBL();
            var result = pandsSoldBL.getTotalCount(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPandSSoldBL pandsSoldBL = new PandSSoldBL();
            var result = pandsSoldBL.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IPandSSoldBL pandsSoldBL = new PandSSoldBL();
            return pandsSoldBL.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IPandSSoldBL pandsSoldBL = new PandSSoldBL();
            return pandsSoldBL.GetOptionSettings();

        }
    }
}
