using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BLInterface
{
    public interface IPurchaseOrderListBL
    {
        List<PurchaseOrderListEntity> GetAllPurOrder();
        List<PurchaseOrderListEntity> GetAllPurOrderJson(string jsondata, bool? ExcincTax);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
        List<TaxModel> GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
