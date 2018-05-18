using SDN.UI.Entities;
using SDN.UI.Entities.Export;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BLInterface
{
    public interface IPandSPurchaseBL
    {
        //List<PandSPurchaseEntity> GetPandSPurchaseList();
        //List<PandSPurchaseEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<PandSPurchaseEntity> GetAllSalesInvoice();
        List<PandSPurchaseEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary);
        List<ProductandServicePurchaseEntity> GetExportDataList(string jsondata, bool? ExcincTax, bool? IsSummary, string FileName);

        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
        string getTotalCount(int ScreenId);
    }
}
