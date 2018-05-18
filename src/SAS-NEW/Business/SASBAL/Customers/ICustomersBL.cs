 using System.Collections.Generic;
     using SASDAL;
    using SDN.UI.Entities;
namespace SDN.Customers.BLInterface{
  
    
    /// <summary>
    /// CustomersBL interface
    /// </summary>
    public interface ICustomersBL
    {
        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>Get All Customer</returns>
        List<Customer> GetAllCustomer();
        List<CustomerEntity> GetCustomerList();
        List<CatagoryType> GetCustomerType();

        List<CatagoryType> GetCategoryType(string filter);
       // IEnumerable<ShippingAddress> GetShippingAddress(int customerId);
        int CreateCustomer(Customer entity);
        int GetCustomersCount(string isInActive);
        bool CanDeleteCustomer(int custId);
        bool DeleteCustomer(int custId);
        bool? IsAllowedToChangeLimit();
        bool? IsCompanyRegisteredForGST();
        OptionsEntity GetOptionSettings();
        TaxModel GetDefaultTaxes();
        bool RefreshCustomer(int custId);
       List<UI.Entities.Country> AutoFillCountry();
        List<UI.Entities.State> AutoFillState();
        List<City> AutoFillCity();
        List<PostalCode> AutoFillPostalCode();
        List<TaxModel> GetTaxCodeAndRate();


    }

   
}
