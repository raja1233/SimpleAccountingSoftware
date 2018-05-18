using SDN.Common;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    public interface IPurchaseInvoiceListRepository
    {
        List<PurchaseInvoiceListEntity> GetAllPurInvoiceJson(string jsondata, bool? ExcincTax);
        List<PurchaseInvoiceListEntity> GetAllPurInvoice();
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        List<TaxModel> GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
