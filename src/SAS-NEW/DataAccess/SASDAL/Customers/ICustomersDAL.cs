 

namespace SDN.Customers.DALInterface
{
    using System.Collections.Generic;
    using SASDAL;
    using SDN.UI.Entities;
    public interface ICustomersDAL
    {
        /// <summary>
        /// CustomerDAL interface
        /// </summary>
        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>Get All Customer</returns>
        List<Customer> GetAllCustomer();
        List<CustomerEntity> GetCustomerList();
        List<string> GetAutoFillData(string EntityType);
       
        List<CatagoryType> GetCustomerType();

        List<CatagoryType> GetCategoryType(string filter);

        int CreateCustomer(Customer entity);
        List<ShippingAddress> GetShippingAddress(int customerId);
     int GetCustomersCount(string isInActive);
        bool CanDeleteCustomer(int custId);
        bool DeleteCustomer(int custId);
        bool RefreshCustomer(int custId);

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

    }
 
