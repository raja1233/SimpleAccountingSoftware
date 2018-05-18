using SASDAL;
namespace SDN.Sales.BL
{
    using System.Collections.Generic;
    using SDN.Sales.BLInterface;
    using UI.Entities;
    using Customers.DALInterface;
    using Customers.DAL;
    using Customers.BLInterface;

    /// <summary>
    /// CustomerBL class 
    /// </summary>
    public class CustomerBL : ICustomerBL
    {
        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>Get All Customer</returns>
        public List<Customer> GetAllCustomer()
        {
            ICustomersDAL customerDAL = new CustomersDAL();
            List<Customer> result = customerDAL.GetAllCustomer();
            return result;
        }

        public List<CatagoryType> GetCustomerType()
        {
            ICustomersDAL customerDAL = new CustomersDAL();
            List<CatagoryType> result = customerDAL.GetCustomerType();

            return result;
        }

        public List<CatagoryType> GetCategoryType(string filter)
        {
            ICustomersDAL customerDAL = new CustomersDAL();
            List<CatagoryType> result = customerDAL.GetCategoryType(filter);

            return result;
        }
    }

     
}
