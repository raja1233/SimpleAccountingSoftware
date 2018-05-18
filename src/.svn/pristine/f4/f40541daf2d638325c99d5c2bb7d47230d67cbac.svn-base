using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DALInterface
{
    using SDN.UI.Entities.Sales;
    public interface ISalesOrderListDAL
    {
        List<SalesOrderListEntity> GetAllSalesOrder();
        List<SalesOrderListEntity> GetAllSalesOrderJson(string jsondata, bool? ExcincTax);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
    }
}
