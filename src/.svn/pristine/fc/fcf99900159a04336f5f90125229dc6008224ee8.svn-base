using SDN.UI.Entities;
using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Purchasing
{
    public interface IPandSPurchasedFromSuppliersBL
    {

        List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoice();
        List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
