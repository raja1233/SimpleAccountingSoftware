namespace SDN.Customers.Services
{
    using System.Collections.Generic;
    using SDN.UI.Entities;
    using SASDAL;

    /// <summary>
    /// Customer Repository interface
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<CustomerEntity> GetCustomerList();
        IEnumerable<CatagoryType> GetCustomerType();

        IEnumerable<CatagoryType> GetCatagoryType(string cat_type);

       // IEnumerable<ShippingAddress> GetShippingAddress(int customerId);

       /// int CreateCustomer(Customer entity, List<ShippingAddress> shippingAddress);
        int CreateCustomer(Customer entity);
        int GetCustomersCount(string isInActive);
        bool CanDeleteCustomer(int custId);
        bool DeleteCustomer(int custId);
        bool? AllowedToChangeLimit();
        bool? IsCompanyRegisteredForGST();
        OptionsEntity GetOptionSettings();
        TaxModel GetDefaultTaxes();
        bool RefreshCustomer(int custId);
        List<UI.Entities.Country> AutoFillCountry();
        List<UI.Entities.State> AutoFillState();
        List<City> AutoFillCity();
        List<PostalCode> AutoFillPostalCode();
        List<TaxModel> GetTaxCodeAndRatesList();

    }
}
