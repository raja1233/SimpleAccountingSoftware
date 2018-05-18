
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Product.Services
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Product;
    using SDN.UI.Entities.Sales;
    public interface IPandSHistoryRepository
    {
        List<PandSHistoryEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax);
        List<PandSHistoryEntity> GetAllSalesInvoice();
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
