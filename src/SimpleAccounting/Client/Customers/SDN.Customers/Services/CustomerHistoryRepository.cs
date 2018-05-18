
using SDN.Customers.BL;
using SDN.Customers.BLInterface;
using SDN.Customers.Services;
using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Customer.Services
{
    public class CustomerHistoryRepository : ICustomerHistoryRepository
    {
        public List<CustomerHistoryEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax)
        {
            ICustomerHistoryBL purInvoice = new CustomerHistoryBL();
            List<CustomerHistoryEntity> quotationlist = purInvoice.GetAllSalesInvoiceJson(jsondata, ExcincTax);
            return quotationlist;
        }
        public List<CustomerHistoryEntity> GetAllSalesInvoice()
        {
            ICustomerHistoryBL purInvoice = new CustomerHistoryBL();
            List<CustomerHistoryEntity> Invoicelist = purInvoice.GetAllSalesInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            ICustomerHistoryBL purInvoice = new CustomerHistoryBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICustomerHistoryBL purInvoice = new CustomerHistoryBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ICustomerHistoryBL purInvoice = new CustomerHistoryBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ICustomerHistoryBL purInvoice = new CustomerHistoryBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            ICustomerHistoryBL purInvoice = new CustomerHistoryBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ICustomerHistoryBL purInvoice = new CustomerHistoryBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
