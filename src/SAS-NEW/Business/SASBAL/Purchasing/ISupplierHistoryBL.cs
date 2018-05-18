using SDN.UI.Entities;
using SDN.UI.Entities.Puchase;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SDN.Purchasings.BLInterface
{
    public interface ISupplierHistoryBL
    {
        List<SupplierHistoryEntity> GetAllSalesInvoice();
        List<SupplierHistoryEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
