using SDN.Purchasings.BL;
using SDN.Purchasings.BLInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    public class RefundFromSuppliersListRepository: IRefundFromSuppliersListRepository
    {
        public List<RefundFromSuppliersListEntity> GetAllPurInvoiceJson(string jsondata)
        {
            IRefundFromSuppliersListBL purInvoice = new RefundFromSuppliersListBL();
            List<RefundFromSuppliersListEntity> quotationlist = purInvoice.GetAllPurInvoiceJson(jsondata);
            return quotationlist;
        }
        public List<RefundFromSuppliersListEntity> GetAllPurInvoice()
        {
            IRefundFromSuppliersListBL purInvoice = new RefundFromSuppliersListBL();
            List<RefundFromSuppliersListEntity> Invoicelist = purInvoice.GetAllPurInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            IRefundFromSuppliersListBL purInvoice = new RefundFromSuppliersListBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IRefundFromSuppliersListBL purInvoice = new RefundFromSuppliersListBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData()
        {
            IRefundFromSuppliersListBL purInvoice = new RefundFromSuppliersListBL();
            var result = purInvoice.GetLastSelectionData();
            return result;
        }
        public string GetDateFormat()
        {
            IRefundFromSuppliersListBL purInvoice = new RefundFromSuppliersListBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IRefundFromSuppliersListBL purInvoice = new RefundFromSuppliersListBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IRefundFromSuppliersListBL purInvoice = new RefundFromSuppliersListBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
