using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BLInterface
{
    public interface IPurchaseQuotationListBL
    {
        List<PurchaseQuotationListEntity> GetAllPurQuotation();
        List<PurchaseQuotationListEntity> GetAllPurQuotationJson(string jsondata, bool? ExcincTax);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        List<TaxModel> GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
