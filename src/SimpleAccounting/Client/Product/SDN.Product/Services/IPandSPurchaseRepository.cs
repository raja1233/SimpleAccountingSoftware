using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{
    public interface IPandSPurchaseRepository
    {
        //List<PandSPurchaseEntity> GetPandSPurchaseList();
        //List<PandSPurchaseEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<PandSPurchaseEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary);
        List<PandSPurchaseEntity> GetAllSalesInvoice();
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
        string getTotalCount(int ScreenId);
    }
}
