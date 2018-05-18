
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Customers.Services
{
    using SASBAL.Customers;
    using SDN.Settings.DAL;
    using SDN.Settings.DALInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Customers;
    public class CustomersDetailsListRepository: ICustomersDetailsListRepository
    {
        public List<CustomersDetailsListEntity> GetCustomersList(string json)
        {
            ICustomersDetailsListBL cdDAL = new CustomersDetailsListBL();
            return cdDAL.GetCustomersList(json);
        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICustomersDetailsListBL cdDAL = new CustomersDetailsListBL();
            return cdDAL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ICustomersDetailsListBL cdDAL = new CustomersDetailsListBL();
            return cdDAL.GetLastSelectionData(ScreenId);
        }
        public TaxModel GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetAllTaxes().FirstOrDefault();
        }
        public OptionsEntity GetOptionSettings()
        {
            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }
        public List<CustomersDetailsListEntity> GetCustomerStatusCount(int ScreenID)
        {
            ICustomersDetailsListBL obj = new CustomersDetailsListBL();
            return obj.GetCustomerStatusCount(ScreenID);
        }
    }
}
