namespace SDN.Sales.DALInterface
{
    using System.Collections.Generic;
    using SDN.Sales.EDM;
    using SDN.UI.Entities;
    

    /// <summary>
    /// ContactDAL interface
    /// </summary>
    //public interface IContactDAL
    //{
    //    /// <summary>
    //    /// Gets all contact.
    //    /// </summary>
    //    /// <returns>Get All Contact</returns>
    //    List<Contact> GetAllContact();
    //}

    /// <summary>
    /// CustomerDAL interface
    /// </summary>
    public interface ICustomerDAL
    {
        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>Get All Customer</returns>
        List<Customer> GetAllCustomer();

        List<CatagoryType> GetCustomerType();

        List<CatagoryType> GetCategoryType(string filter);

        int CreateCustomer(Customer entity, List<ShippingAddress> shippingAddress);


    }


    /// <summary>
    /// StoreDAL interface
    /// </summary>
    public interface ICategoryContentDAL
    {
        /// <summary>
        /// Gets all store.
        /// </summary>
        /// <returns>Ge tAll Store</returns>
        List<CategoriesContent> GetAllCategoryContent();
    }

    /// <summary>
    /// StoreDAL interface
    /// </summary>
    //public interface IStoreDAL
    //{
    //    /// <summary>
    //    /// Gets all store.
    //    /// </summary>
    //    /// <returns>Ge tAll Store</returns>
    //    List<Store> GetAllStore();
    //}

    /// <summary>
    /// CountryRegionDAL interface
    /// </summary>
    //public interface ICountryRegionDAL
    //{
    //    /// <summary>
    //    /// Gets the country region.
    //    /// </summary>
    //    /// <returns>Get Country Region</returns>
    //    List<Country> GetCountryRegion();
    //}
}
