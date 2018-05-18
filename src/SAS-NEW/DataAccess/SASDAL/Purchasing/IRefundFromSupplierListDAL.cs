
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DALInterface
{
    using SDN.UI.Entities.Purchase;
    public interface IRefundFromSupplierListDAL
    {
        List<RefundFromSuppliersListEntity> GetAllPurInvoice();
        List<RefundFromSuppliersListEntity> GetAllPurInvoiceJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
    }
}
