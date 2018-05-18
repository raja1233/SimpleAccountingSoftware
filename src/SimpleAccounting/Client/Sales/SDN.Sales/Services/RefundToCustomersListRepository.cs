
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using SDN.Sales.BL;
    using SDN.Sales.BLInterface;
    using SDN.UI.Entities.Sales;
    using UI.Entities;

    public class RefundToCustomersListRepository: IRefundToCustomersListRepository
    {
        public List<RefundToCustomersListEntity> GetAllPurInvoiceJson(string jsondata)
        {
            IRefundToCustomersListBL purInvoice = new RefundToCustomersListBL();
            List<RefundToCustomersListEntity> quotationlist = purInvoice.GetAllPurInvoiceJson(jsondata);
            return quotationlist;
        }
        public List<RefundToCustomersListEntity> GetAllPurInvoice()
        {
            IRefundToCustomersListBL purInvoice = new RefundToCustomersListBL();
            List<RefundToCustomersListEntity> Invoicelist = purInvoice.GetAllPurInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            IRefundToCustomersListBL purInvoice = new RefundToCustomersListBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IRefundToCustomersListBL purInvoice = new RefundToCustomersListBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IRefundToCustomersListBL purInvoice = new RefundToCustomersListBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IRefundToCustomersListBL purInvoice = new RefundToCustomersListBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IRefundToCustomersListBL purInvoice = new RefundToCustomersListBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IRefundToCustomersListBL purInvoice = new RefundToCustomersListBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
