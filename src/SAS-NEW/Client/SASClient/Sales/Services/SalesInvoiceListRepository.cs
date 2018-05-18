using SDN.Sales.BL;
using SDN.Sales.BLInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    public class SalesInvoiceListRepository: ISalesInvoiceListRepository
    {
        public List<SalesInvoiceListEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax)
        {
            ISalesInvoiceListBL purInvoice = new SalesInvoiceListBL();
            List<SalesInvoiceListEntity> quotationlist = purInvoice.GetAllSalesInvoiceJson(jsondata, ExcincTax);
            return quotationlist;
        }
        public List<SalesInvoiceListEntity> GetAllSalesInvoice()
        {
            ISalesInvoiceListBL purInvoice = new SalesInvoiceListBL();
            List<SalesInvoiceListEntity> Invoicelist = purInvoice.GetAllSalesInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            ISalesInvoiceListBL purInvoice = new SalesInvoiceListBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ISalesInvoiceListBL purInvoice = new SalesInvoiceListBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData()
        {
            ISalesInvoiceListBL purInvoice = new SalesInvoiceListBL();
            var result = purInvoice.GetLastSelectionData();
            return result;
        }
        public string GetDateFormat()
        {
            ISalesInvoiceListBL purInvoice = new SalesInvoiceListBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            ISalesInvoiceListBL purInvoice = new SalesInvoiceListBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ISalesInvoiceListBL purInvoice = new SalesInvoiceListBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
