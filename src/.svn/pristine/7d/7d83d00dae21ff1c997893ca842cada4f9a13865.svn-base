using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    using SDN.UI.Entities;
    using Purchasings.BLInterface;
    using Purchasings.BL;

    public class PaymentsToSuppliersRepository : IPaymentsToSuppliersRepository
    {
        public List<PaymentsToSuppliersListEntity> GetAllPurInvoiceJson(string jsondata)
        {
            IPaymentsToSuppliersListBL purInvoice = new PaymentsToSuppliersListBL();
            List<PaymentsToSuppliersListEntity> quotationlist = purInvoice.GetAllPurInvoiceJson(jsondata);
            return quotationlist;
        }
        public List<PaymentsToSuppliersListEntity> GetAllPurInvoice()
        {
            IPaymentsToSuppliersListBL purInvoice = new PaymentsToSuppliersListBL();
            List<PaymentsToSuppliersListEntity> Invoicelist = purInvoice.GetAllPurInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            IPaymentsToSuppliersListBL purInvoice = new PaymentsToSuppliersListBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPaymentsToSuppliersListBL purInvoice = new PaymentsToSuppliersListBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IPaymentsToSuppliersListBL purInvoice = new PaymentsToSuppliersListBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPaymentsToSuppliersListBL purInvoice = new PaymentsToSuppliersListBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IPaymentsToSuppliersListBL purInvoice = new PaymentsToSuppliersListBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IPaymentsToSuppliersListBL purInvoice = new PaymentsToSuppliersListBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
