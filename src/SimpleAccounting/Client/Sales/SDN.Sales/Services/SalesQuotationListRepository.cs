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

    public class SalesQuotationListRepository: ISalesQuotationListRepository
    {
        public List<SalesQuotationListEntity> GetAllSalesQuotationJson(string jsondata, bool? ExcincTax)
        {
            ISalesQuotationListBL salesQuotation = new SalesQuotationListBL();
            List<SalesQuotationListEntity> quotationlist = salesQuotation.GetAllSalesQuotationJson(jsondata, ExcincTax);
            return quotationlist;
        }
        public List<SalesQuotationListEntity> GetAllSalesQuotation()
        {
            ISalesQuotationListBL salesQuotation = new SalesQuotationListBL();
            List<SalesQuotationListEntity> quotationlist = salesQuotation.GetAllSalesQuotation();
            return quotationlist;
        }
        public List<YearEntity> GetYearRange()
        {
            ISalesQuotationListBL salesQuotation = new SalesQuotationListBL();
            List<YearEntity> yearrange = salesQuotation.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ISalesQuotationListBL salesQuotation = new SalesQuotationListBL();
            var result = salesQuotation.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ISalesQuotationListBL salesQuotation = new SalesQuotationListBL();
            var result = salesQuotation.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ISalesQuotationListBL salesQuotation = new SalesQuotationListBL();
            var result = salesQuotation.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            ISalesQuotationListBL salesQuotation = new SalesQuotationListBL();
            return salesQuotation.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ISalesQuotationListBL salesQuotation = new SalesQuotationListBL();
            return salesQuotation.GetOptionSettings();

        }
    }
}
