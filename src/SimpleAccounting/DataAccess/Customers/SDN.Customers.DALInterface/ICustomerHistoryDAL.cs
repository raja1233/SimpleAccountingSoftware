using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Customers.DALInterface
{
    using SDN.UI.Entities.Sales;
    public interface ICustomerHistoryDAL
    {

        List<CustomerHistoryEntity> GetAllSalesInvoice();
        List<CustomerHistoryEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
    }
}
