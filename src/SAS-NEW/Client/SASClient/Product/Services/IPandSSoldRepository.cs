using SDN.UI.Entities;
using SDN.UI.Entities.Export;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{
    public interface IPandSSoldRepository
    {
        //List<PandSSoldEntity> GetPandSSoldList();
        //List<PandSSoldEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<PandSSoldEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary);
        List<PandSSoldEntity> GetAllSalesInvoice();
        List<YearEntity> GetYearRange();
        List<ProductandServiceSoldEntity> GetExportDataList(string jsondata, bool? ExcincTax, bool? IsSummary, string FileName);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
