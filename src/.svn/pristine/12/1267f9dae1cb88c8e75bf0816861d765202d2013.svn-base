

namespace SDN.Purchasings.BL
{
    using BLInterface;
    using UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;
    using DALInterface;
    using Settings.DALInterface;
    using Settings.DAL;

    public class SupplierBL:ISupplierBL
    {
        public List<SupplierDetailEntity> GetAllSupplier()
        {
            SupplierDAL supplierDAL = new SupplierDAL();
            List<SupplierDetailEntity> result = supplierDAL.GetAllSupplier();
            return result;
        }

        //public List<CatagoryType> GetCustomerType()
        //{
        //    ICustomersDAL customerDAL = new CustomersDAL();
        //    List<CatagoryType> result = customerDAL.GetCustomerType();

        //    return result;
        //}

        //public List<CatagoryType> GetCategoryType(string filter)
        //{
        //    ICustomersDAL customerDAL = new CustomersDAL();
        //    List<CatagoryType> result = customerDAL.GetCategoryType(filter);

        //    return result;
        //}

        //public IEnumerable<ShippingAddress> GetShippingAddress(int customerId)
        //{
        //    ICustomersDAL customerDAL = new CustomersDAL();
        //    return customerDAL.GetShippingAddress(customerId);
        //}
        public bool CreateSupplier(SupplierDetailEntity entity)
        {
            ISupplierDAL supplierDAL = new SupplierDAL();
            return supplierDAL.CreateSupplier(entity);
        }

        public int GetSupplierCount(string isInActive)
        {
            ISupplierDAL supplierDAL = new SupplierDAL();
            return supplierDAL.GetSupplierCount(isInActive);
        }

        public bool CanDeleteSupplier(int supId)
        {
            ISupplierDAL supplierDAL = new SupplierDAL();
            return supplierDAL.CanDeleteSupplier(supId);
        }

        public bool DeleteSupplier(int supId)
        {
            ISupplierDAL supplierDAL = new SupplierDAL();
            return supplierDAL.DeleteSupplier(supId);

        }
        public bool? IsAllowedToChangeLimit()
        {
            bool? result = false;
            IOptionsDAL optionsDAL = new OptionsDAL();
            OptionsEntity optionData = new OptionsEntity();
            optionData = optionsDAL.GetOptionsDetails();
            if (optionData == null)
            {
                result = false;
            }
            else
            {
                result = optionData.CusDetailAllowChgLimit;
            }

            return result;
        }

        public OptionsEntity GetOptionSettings()
        {

            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }
        public bool RefreshSupplier(int supId)
        {
            ISupplierDAL supplierDAL = new SupplierDAL();
            return supplierDAL.RefreshSupplier(supId);
        }
        //public List<CountryEntity> GetCountries()
        //{
        //    IMasterData objMaster = new MasterData();
        //    List<CountryEntity> result = objMaster.GetCountries();
        //    return result;
        //}

        #region AutoFill
        public List<Country> AutoFillCountry()
        {
            int autoId = 1;

            List<Country> countryList;
            ISupplierDAL supplierDAL = new SupplierDAL();
            List<string> strlist = supplierDAL.GetAutoFillData("country");

            countryList = new List<Country>();
            if (strlist != null)
            {
                foreach (string name in strlist)
                {
                    Country lst = new Country();
                    lst.CountryID = autoId;
                    lst.Name = name;
                    countryList.Add(lst);
                    autoId++;
                }
            }
            return countryList;
        }

        public List<State> AutoFillState()
        {
            int autoId = 1;

            List<State> stateList;
            ISupplierDAL supplierDAL = new SupplierDAL();
            List<string> strlist = supplierDAL.GetAutoFillData("state");

            stateList = new List<State>();
            if (strlist != null)
            {
                foreach (string name in strlist)
                {
                    State lst = new State();
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
            ISupplierDAL supplierDAL = new SupplierDAL();
            List<string> strlist = supplierDAL.GetAutoFillData("city");

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
            ISupplierDAL supplierDAL = new SupplierDAL();
            List<string> strlist = supplierDAL.GetAutoFillData("postalcode");

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
        public TaxModel GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetDefaultTaxes();
        }
        public List<TaxModel> GetTaxCodeAndRate()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetAllTaxes();
        }

        #endregion
    }
}
