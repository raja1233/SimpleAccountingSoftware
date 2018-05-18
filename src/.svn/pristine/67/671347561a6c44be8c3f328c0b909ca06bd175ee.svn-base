using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DALInterface
{
    public interface IPurchaseInvoiceListDAL
    {
        List<PurchaseInvoiceListEntity> GetAllPurInvoice();
        List<PurchaseInvoiceListEntity> GetAllPurInvoiceJson(string jsondata, bool? ExcincTax);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
    }
}
