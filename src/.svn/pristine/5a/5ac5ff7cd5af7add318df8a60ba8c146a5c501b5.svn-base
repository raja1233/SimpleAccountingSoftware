

using SDN.Purchasings.BL;
using SDN.Purchasings.BLInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Puchase;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    public class SupplierHistoryRepository : ISupplierHistoryRepository
    {
        public List<SupplierHistoryEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax)
        {
            ISupplierHistoryBL purInvoice = new SupplierHistoryBL();
            List<SupplierHistoryEntity> quotationlist = purInvoice.GetAllSalesInvoiceJson(jsondata, ExcincTax);
            return quotationlist;
        }
        public List<SupplierHistoryEntity> GetAllSalesInvoice()
        {
            ISupplierHistoryBL purInvoice = new SupplierHistoryBL();
            List<SupplierHistoryEntity> Invoicelist = purInvoice.GetAllSalesInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            ISupplierHistoryBL purInvoice = new SupplierHistoryBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ISupplierHistoryBL purInvoice = new SupplierHistoryBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ISupplierHistoryBL purInvoice = new SupplierHistoryBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ISupplierHistoryBL purInvoice = new SupplierHistoryBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            ISupplierHistoryBL purInvoice = new SupplierHistoryBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ISupplierHistoryBL purInvoice = new SupplierHistoryBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
