using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DALInterface
{
    using SDN.UI.Entities.Sales;
    using UI.Entities.Puchase;

    public interface ISupplierHistoryDAL
    {

        List<SupplierHistoryEntity> GetAllSalesInvoice();
        List<SupplierHistoryEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
    }
}
