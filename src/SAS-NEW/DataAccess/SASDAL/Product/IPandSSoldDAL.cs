using SDN.UI.Entities.Export;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DALInterface
{
    public interface IPandSSoldDAL
    {
        //List<PandSSoldEntity> GetPandSSoldList();
        //List<PandSSoldEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<PandSSoldEntity> GetAllSalesInvoice();
        List<PandSSoldEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        List<ProductandServiceSoldEntity> GetExportDataList(string jsondata, bool? ExcincTax, bool? IsSummary, string FileName);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
    }
}
