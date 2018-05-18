using System;
using System.Collections.Generic;
using SDN.UI.Entities;
using SDN.Customers.BLInterface;
using SDN.Customers.DAL;
using SDN.Customers.DALInterface;
using SASDAL;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;

namespace SDN.Customers.BL
{

    /// <summary>
    /// CustomerBL class 
    /// </summary>
    public class CustomersBL : ICustomersBL
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
            //foreach(var item in result)
            //{
            //  item.Cat_Contents_Display =   Convert.ToDecimal(item.Cat_Contents).ToString("N", new CultureInfo(SharedValues.CurrencyName));
            //}

            return result;
        }

        //public IEnumerable<ShippingAddress> GetShippingAddress(int customerId)
        //{
        //    ICustomersDAL customerDAL = new CustomersDAL();
        //    return customerDAL.GetShippingAddress(customerId);
        //}
        public int CreateCustomer(SASDAL.Customer entity)
        {
            ICustomersDAL customerDAL = new CustomersDAL();
            return customerDAL.CreateCustomer(entity);
        }

        public int GetCustomersCount(string isInActive)
        {
            ICustomersDAL customerDAL = new CustomersDAL();
            return customerDAL.GetCustomersCount(isInActive);
        }

        public bool CanDeleteCustomer(int custId)
        {
            ICustomersDAL customerDAL = new CustomersDAL();
            return customerDAL.CanDeleteCustomer(custId);
        }

        public bool DeleteCustomer(int custId)
        {
            ICustomersDAL customerDAL = new CustomersDAL();
            return customerDAL.DeleteCustomer(custId);
            
        }
        public bool? IsAllowedToChangeLimit()
        {
            bool? result = false;
            //IOptionsDAL optionsDAL = new OptionsDAL();
            //OptionsEntity optionData=new OptionsEntity();
            //     optionData = optionsDAL.GetOptionsDetails();
            //if (optionData==null)
            //{
            //    result = false;
            //}else
            //{
            //    result = optionData.CusDetailAllowChgLimit;
            //}

            return result;
        }
       
        public bool? IsCompanyRegisteredForGST()
        { 
            bool? result = false;
            ICompanyDAL companyDAL = new CompanyDAL();

            var data = companyDAL.GetCompanyDetails();
            if (data!= null)
            {
                string regNo = data.Comp_GST_Reg_No;
                DateTime? comp_Gst_DeregDate = null;
                comp_Gst_DeregDate = data.Comp_GST_Dereg_Date;

                if(regNo!=null && regNo != string.Empty)
                {
                    if(comp_Gst_DeregDate!=null)
                    {
                        if (comp_Gst_DeregDate < System.DateTime.UtcNow)
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;

                        }

                    }
                    else
                    {
                        result = true;
                    }


                }
                else
                {
                    result = false;

                }
               
            }
            return result;
        }

        public OptionsEntity GetOptionSettings()
        {
             
            IOptionsDAL optionsDAL = new OptionsDAL();           
              return optionsDAL.GetOptionsDetails();
         }
       public  TaxModel GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
                return objTax.GetDefaultTaxes();
        } 
        public List<TaxModel> GetTaxCodeAndRate()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetAllTaxes();
        }
        public bool RefreshCustomer(int custId)
        {
            ICustomersDAL customerDAL = new CustomersDAL();
            return customerDAL.RefreshCustomer(custId);
        }
       public  List<UI.Entities.Country> AutoFillCountry()
        {    int autoId = 1;            
            
              List<UI.Entities.Country> countryList;
               ICustomersDAL customerDAL = new CustomersDAL();
            List<string> strlist = customerDAL.GetAutoFillData("country");
            
             countryList = new List<UI.Entities.Country>();
            if (strlist != null)
            {
                foreach (string name in strlist)
                {
                    UI.Entities.Country lst = new UI.Entities.Country();
                    lst.CountryID = autoId;
                    lst.Name = name;
                    countryList.Add(lst);
                    autoId++;
                }
            }
            return countryList;
        }

        public List<UI.Entities.State> AutoFillState()
        {
            int autoId = 1;

            List<UI.Entities.State> stateList;
            ICustomersDAL customerDAL = new CustomersDAL();
            List<string> strlist = customerDAL.GetAutoFillData("state");

            stateList = new List<UI.Entities.State>();
            if (strlist != null)
            {
                foreach (string name in strlist)
                {
                    UI.Entities.State lst = new UI.Entities.State();
                    lst.StateID = autoId;
                    lst.Name = name;
                    stateList.Add(lst);
                    autoId++;
                }
            }
            return stateList;
        }

        public List<City> AutoFillCity()
        {
            int autoId = 1;

            List<City> cityList;
            ICustomersDAL customerDAL = new CustomersDAL();
            List<string> strlist = customerDAL.GetAutoFillData("city");

            cityList = new List<City>();
            if (strlist != null)
            {
                foreach (string name in strlist)
                {
                    City lst = new City();
                    lst.CityID = autoId;
                    lst.Name = name;
                    cityList.Add(lst);
                    autoId++;
                }
            }
            return cityList;
        }

        public List<PostalCode> AutoFillPostalCode()
        {
            int autoId = 1;

            List<PostalCode> postalcodeList;
            ICustomersDAL customerDAL = new CustomersDAL();
            List<string> strlist = customerDAL.GetAutoFillData("postalcode");

            postalcodeList = new List<PostalCode>();
            if (strlist != null)
            {
                foreach (string name in strlist)
                {
                    PostalCode lst = new PostalCode();
                    lst.PostalCodeID = autoId;
                    lst.Name = name;
                    postalcodeList.Add(lst);
                    autoId++;
                }
            }
            return postalcodeList;
        }

        public List<CustomerEntity> GetCustomerList()
        {
            ICustomersDAL customerDAL = new CustomersDAL();
            List<CustomerEntity> result = customerDAL.GetCustomerList();
            return result;
        }
    }

   
}
