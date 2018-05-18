namespace SDN.Sales.Services
{
    using System.Collections.Generic;
    using SDN.Sales.BL;
    using SDN.Sales.BLInterface;
    using SDN.Sales.EDM;
    using SDN.UI.Entities;

    /// <summary>
    /// Customer Repository class
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>Get All Customers</returns>
        public IEnumerable<CustomerEntity> GetAllCustomers()
        {
            IList<CustomerEntity> CustomersList = new List<CustomerEntity>();
            ICustomerBL _customerBL = new CustomerBL();
            foreach (Customer source in _customerBL.GetAllCustomer())
            {
                CustomerEntity target = new CustomerEntity();
                target.CustomerID = source.ID;
                target.FirstName = source.Cus_Name;
                target.Address = source.Cus_Bill_to_line1;
                target.City = source.Cus_Bill_to_city;
                target.State = source.Cus_Bill_to_state;
                target.Country = source.Cus_Bill_to_country;
                target.SalesmanID = source.Cus_Salesman;//added  on 18may2017 for sales quo,order, invoice
                target.Discount = source.Cus_Discount;
                target.Inactive = source.Cus_Inactive;
                target.CreditLimitAmount = source.Cus_Credit_Limit_Amount;
                CustomersList.Add(target);
            }
            return CustomersList;
        }

        public IEnumerable<CatagoryType> GetCustomerType()
        {
            ICustomerBL _customerBL = new CustomerBL();

            var ctype = _customerBL.GetCustomerType();

            return ctype;
        }

        public IEnumerable<CatagoryType> GetCatagoryType(string cat_type)
        {
            ICustomerBL _customerBL = new CustomerBL();

            var ctype = _customerBL.GetCategoryType(cat_type);

            return ctype;
        }
    }
}
