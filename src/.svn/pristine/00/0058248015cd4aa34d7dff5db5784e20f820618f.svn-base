using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Purchasing
{
    public interface IPandSPurchasedFromSuppliersDAL
    {
        //List<PandSPurchasedFromSuppliersEntity> GetPandSPurchasedFromSuppliersList();
        //List<PandSPurchasedFromSuppliersEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoice();
        List<PandSPurchasedFromSuppliersEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
    }
}
