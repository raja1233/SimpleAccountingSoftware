
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using BL;
    using BLInterface;
    using SDN.UI.Entities.Sales;
    using UI.Entities;

    public class PaymentFromCustomersListRepository : IPaymentFromCustomersListRepository
    {
        public List<PaymentFromCustomersListEntity> GetAllPurInvoiceJson(string jsondata)
        {
            IPaymentFromCustomersListBL purInvoice = new PaymentFromCustomersListBL();
            List<PaymentFromCustomersListEntity> quotationlist = purInvoice.GetAllPurInvoiceJson(jsondata);
            return quotationlist;
        }
        public List<PaymentFromCustomersListEntity> GetAllPurInvoice()
        {
            IPaymentFromCustomersListBL purInvoice = new PaymentFromCustomersListBL();
            List<PaymentFromCustomersListEntity> Invoicelist = purInvoice.GetAllPurInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            IPaymentFromCustomersListBL purInvoice = new PaymentFromCustomersListBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPaymentFromCustomersListBL purInvoice = new PaymentFromCustomersListBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IPaymentFromCustomersListBL purInvoice = new PaymentFromCustomersListBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPaymentFromCustomersListBL purInvoice = new PaymentFromCustomersListBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IPaymentFromCustomersListBL purInvoice = new PaymentFromCustomersListBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IPaymentFromCustomersListBL purInvoice = new PaymentFromCustomersListBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
