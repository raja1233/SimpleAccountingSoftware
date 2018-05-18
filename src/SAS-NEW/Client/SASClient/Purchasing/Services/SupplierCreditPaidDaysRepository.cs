using SASBAL.Purchasing;
using SDN.UI.Entities;
using SDN.UI.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.Services
{
    public class SupplierCreditPaidDaysRepository : ISupplierCreditPaidDaysRepository
    {
        public List<SupplierCreditPaidDaysEntity> GetAllSalesInvoiceJson(string jsondata)
        {
            ISupplierCreditPaidDaysBL purInvoice = new SupplierCreditPaidDaysBL();
            List<SupplierCreditPaidDaysEntity> quotationlist = purInvoice.GetAllSalesInvoiceJson(jsondata);
            return quotationlist;
        }
       
        public List<YearEntity> GetYearRange()
        {
            ISupplierCreditPaidDaysBL purInvoice = new SupplierCreditPaidDaysBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ISupplierCreditPaidDaysBL purInvoice = new SupplierCreditPaidDaysBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ISupplierCreditPaidDaysBL purInvoice = new SupplierCreditPaidDaysBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ISupplierCreditPaidDaysBL purInvoice = new SupplierCreditPaidDaysBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            ISupplierCreditPaidDaysBL purInvoice = new SupplierCreditPaidDaysBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ISupplierCreditPaidDaysBL purInvoice = new SupplierCreditPaidDaysBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
