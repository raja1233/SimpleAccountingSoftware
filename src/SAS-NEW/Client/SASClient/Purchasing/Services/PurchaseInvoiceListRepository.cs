using SDN.Purchasings.BL;
using SDN.Purchasings.BLInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    public class PurchaseInvoiceListRepository : IPurchaseInvoiceListRepository
    {

        public List<PurchaseInvoiceListEntity> GetAllPurInvoiceJson(string jsondata, bool? ExcincTax)
        {
            IPurchaseInvoiceListBL purInvoice = new PurchaseInvoiceListBL();
            List<PurchaseInvoiceListEntity> quotationlist = purInvoice.GetAllPurInvoiceJson(jsondata, ExcincTax);
            return quotationlist;
        }
        public List<PurchaseInvoiceListEntity> GetAllPurInvoice()
        {
            IPurchaseInvoiceListBL purInvoice = new PurchaseInvoiceListBL();
            List<PurchaseInvoiceListEntity> Invoicelist = purInvoice.GetAllPurInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            IPurchaseInvoiceListBL purInvoice = new PurchaseInvoiceListBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPurchaseInvoiceListBL purInvoice = new PurchaseInvoiceListBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData()
        {
            IPurchaseInvoiceListBL purInvoice = new PurchaseInvoiceListBL();
            var result = purInvoice.GetLastSelectionData();
            return result;
        }
        public string GetDateFormat()
        {
            IPurchaseInvoiceListBL purInvoice = new PurchaseInvoiceListBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public List<TaxModel> GetDefaultTaxes()
        {
            IPurchaseInvoiceListBL purInvoice = new PurchaseInvoiceListBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IPurchaseInvoiceListBL purInvoice = new PurchaseInvoiceListBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
