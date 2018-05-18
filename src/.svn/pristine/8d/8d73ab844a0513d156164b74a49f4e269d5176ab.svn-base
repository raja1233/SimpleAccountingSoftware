
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public interface ISalesQuotationListRepository
    {
        List<SalesQuotationListEntity> GetAllSalesQuotationJson(string jsondata, bool? ExcincTax);
        List<SalesQuotationListEntity> GetAllSalesQuotation();
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
