using SDN.UI.Entities;
using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.Services
{
    public interface IPandSPurchasedFromSuppliersRepository
    {
        //List<PandSPurchasedFromSuppliersEntity> GetPandSPurchasedFromSuppliersList();
        //List<PandSPurchasedFromSuppliersEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary);
        List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoice();
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
        string getTotalCount(int ScreenId);
    }
}
