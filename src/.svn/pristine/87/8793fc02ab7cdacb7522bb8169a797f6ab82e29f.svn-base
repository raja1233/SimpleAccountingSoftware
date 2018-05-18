
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Customers
{
    using SASDAL.Customers;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Customers;
    public class CustomersDetailsListBL: ICustomersDetailsListBL
    {
        public List<CustomersDetailsListEntity> GetCustomersList(string json)
        {
            ICustomersDetailsListDAL cdDAL = new CustomersDetailsListDAL();
            return cdDAL.GetCustomersList(json);
        }
       public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICustomersDetailsListDAL cdDAL = new CustomersDetailsListDAL();
            return cdDAL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ICustomersDetailsListDAL cdDAL = new CustomersDetailsListDAL();
            return cdDAL.GetLastSelectionData(ScreenId);
        }
        public List<CustomersDetailsListEntity> GetCustomerStatusCount(int ScreenID)
        {
            ICustomersDetailsListDAL obj = new CustomersDetailsListDAL();
            return obj.GetCustomerStatusCount(ScreenID);
        }

    }
}
