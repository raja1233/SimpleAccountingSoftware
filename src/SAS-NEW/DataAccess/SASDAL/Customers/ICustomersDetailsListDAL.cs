
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Customers
{
    using SDN.UI.Entities.Customers;
    public interface ICustomersDetailsListDAL
    {
        List<CustomersDetailsListEntity> GetCustomersList(string json);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        List<CustomersDetailsListEntity> GetCustomerStatusCount(int ScreenID);
    }
}
