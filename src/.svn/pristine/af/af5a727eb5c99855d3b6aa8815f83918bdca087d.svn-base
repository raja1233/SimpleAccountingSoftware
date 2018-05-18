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
    public interface ISupplierHistoryRepository
    {
        List<SupplierHistoryEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax);
        List<SupplierHistoryEntity> GetAllSalesInvoice();
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
