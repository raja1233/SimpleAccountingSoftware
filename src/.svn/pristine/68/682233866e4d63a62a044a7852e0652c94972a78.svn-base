using SDN.Common;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    public interface IPurchaseQuotationListRepository
    {
        List<PurchaseQuotationListEntity> GetAllPurQuotationJson(string jsondata,bool? ExcincTax);
        List<PurchaseQuotationListEntity> GetAllPurQuotation();
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        List<TaxModel> GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
