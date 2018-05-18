
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Product
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Product;
    public interface IPandSHistoryBL
    {
        List<PandSHistoryEntity> GetAllSalesInvoice();
        List<PandSHistoryEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        List<YearEntity> GetYearRange();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
