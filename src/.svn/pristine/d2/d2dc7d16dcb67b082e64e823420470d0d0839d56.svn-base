using SASBAL.Product;
using SDN.UI.Entities;
using SDN.UI.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Product.Services
{
   public class PandSHistoryRepository: IPandSHistoryRepository
    {
        public List<PandSHistoryEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax)
        {
            IPandSHistoryBL purInvoice = new PandSHistoryBL();
            List<PandSHistoryEntity> quotationlist = purInvoice.GetAllSalesInvoiceJson(jsondata, ExcincTax);
            return quotationlist;
        }
        public List<PandSHistoryEntity> GetAllSalesInvoice()
        {
            IPandSHistoryBL purInvoice = new PandSHistoryBL();
            List<PandSHistoryEntity> Invoicelist = purInvoice.GetAllSalesInvoice();
            return Invoicelist;
        }
       
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPandSHistoryBL purInvoice = new PandSHistoryBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IPandSHistoryBL purInvoice = new PandSHistoryBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPandSHistoryBL purInvoice = new PandSHistoryBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IPandSHistoryBL purInvoice = new PandSHistoryBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IPandSHistoryBL purInvoice = new PandSHistoryBL();
            return purInvoice.GetOptionSettings();

        }
        public List<YearEntity> GetYearRange()
        {
            IPandSHistoryBL purInvoice = new PandSHistoryBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
    }
}
