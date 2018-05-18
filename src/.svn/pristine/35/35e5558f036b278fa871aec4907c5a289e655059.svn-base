using System;
using System.Collections.Generic;
using SDN.Customers.BL;
using SDN.Customers.BLInterface;
using SDN.UI.Entities;


namespace SDN.Customers.Services
{

    /// <summary>
    /// Customer Repository class
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>Get All Customers</returns>
        public IEnumerable<SASDAL.Customer> GetAllCustomers()
        {
            IList<SASDAL.Customer> CustomersList = new List<SASDAL.Customer>();
            ICustomersBL _customerBL = new CustomersBL();

            CustomersList = _customerBL.GetAllCustomer();
            return CustomersList;
        }

        public IEnumerable<CatagoryType> GetCustomerType()
        {
            ICustomersBL _customerBL = new CustomersBL();

            var ctype = _customerBL.GetCustomerType();

            return ctype;
        }

        public IEnumerable<CatagoryType> GetCatagoryType(string cat_type)
        {
            ICustomersBL _customerBL = new CustomersBL();

            var ctype = _customerBL.GetCategoryType(cat_type);

            return ctype;
        }

        //public IEnumerable<ShippingAddress> GetShippingAddress(int customerId)
        //{
        //    ICustomersBL _customerBL = new CustomersBL();

        //    return _customerBL.GetShippingAddress(customerId);
        //}
        public int CreateCustomer(SASDAL.Customer entity)
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.CreateCustomer(entity);
        }

        public int GetCustomersCount(string isInActive)
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.GetCustomersCount(isInActive);
        }
        public bool CanDeleteCustomer(int custId)
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.CanDeleteCustomer(custId);
            //return false;
        }

        public bool DeleteCustomer(int custId)
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.DeleteCustomer(custId);
            //return false;
        }

        public bool? AllowedToChangeLimit()
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.IsAllowedToChangeLimit();
            
        }

        public bool? IsCompanyRegisteredForGST()
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.IsCompanyRegisteredForGST();
        }

        public OptionsEntity GetOptionSettings()
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.GetOptionSettings();

        }
        public TaxModel GetDefaultTaxes()
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.GetDefaultTaxes();
        }

        public bool RefreshCustomer(int custId)
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.RefreshCustomer(custId);
        }

        public List<Country> AutoFillCountry()
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.AutoFillCountry();
        }

        public List<State> AutoFillState()
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.AutoFillState();
        }

        public List<City> AutoFillCity()
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.AutoFillCity();
        }

        public List<PostalCode> AutoFillPostalCode()
        {
            ICustomersBL _customerBL = new CustomersBL();
            return _customerBL.AutoFillPostalCode();
        }

        public List<TaxModel> GetTaxCodeAndRatesList()
        {
            ICustomersBL _customerBL = new CustomersBL();

            var cTaxRateList = _customerBL.GetTaxCodeAndRate();
            if(cTaxRateList!=null)
            {
                cTaxRateList = cTaxRateList.FindAll(x => x.IsInActive != "Y");
            }
            return cTaxRateList;
            
        }

        public IEnumerable<CustomerEntity> GetCustomerList()
        {
            IList<CustomerEntity> CustomersList = new List<CustomerEntity>();
            ICustomersBL _customerBL = new CustomersBL();

            CustomersList = _customerBL.GetCustomerList();
            return CustomersList;
        }

       
    }
}
