using SDN.UI.Entities;
using SDN.UI.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Customers.Services
{
   public interface ICustomersDetailsListRepository
    {
        List<CustomersDetailsListEntity> GetCustomersList(string json);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        OptionsEntity GetOptionSettings();
        TaxModel GetDefaultTaxes();
        List<CustomersDetailsListEntity> GetCustomerStatusCount(int ScreenID);
    }
}
