﻿using System;
using SDN.Settings.BL;
using SDN.Settings.BLInterface;
using SDN.UI.Entities;

namespace SDN.Settings.Services
{
    public class CompanyDetails:ICompanyDetails
    {
        public CompanyDetailsEntities GetCompanyDetails()
        {
            //CompanyDetailsEntities result = new CompanyDetailsEntities();
            ICompanyBL companyBL = new CompanyBL();
            CompanyDetailsEntities result = companyBL.GetCompanyDetails();
            //foreach (products.Product source in productList)
            //{
            //    ProductEntity target = new ProductEntity();
            //    target.ProductID = source.ProductID;
            //    target.Category = source.Category;
            //    target.SubCategory = source.Subcategory;
            //    target.Model = source.Model;
            //    target.Product = source.Product1;
            //    result.Add(target);
            //}
            return result;
        }
        public void AddCompanyLogo(byte[] Image)
        {
            //CompanyDetailsEntities result = new CompanyDetailsEntities();
            ICompanyBL companyBL = new CompanyBL();
            companyBL.AddCompanyLogo(Image);
            //foreach (products.Product source in productList)
            //{
            //    ProductEntity target = new ProductEntity();
            //    target.ProductID = source.ProductID;
            //    target.Category = source.Category;
            //    target.SubCategory = source.Subcategory;
            //    target.Model = source.Model;
            //    target.Product = source.Product1;
            //    result.Add(target);
            //}
        
        }
        //public IEnumerable<ShippingAddressEntity> GetShippingDetails(int CompanyId, string EntityType)
        //{
        //    ICompanyBL companyBL = new CompanyBL();
        //    IEnumerable<ShippingAddressEntity> result = companyBL.GetShippingDetails(CompanyId, EntityType);
        //    return result;
        //}
        //public IEnumerable<ShippingAddressEntity> GetSelectedShipDetails(int ShipId)
        //{
        //    ICompanyBL companyBL = new CompanyBL();
        //    IEnumerable<ShippingAddressEntity> result = companyBL.GetSelectedShipDetails(ShipId);
        //    return result;
        //}


        public bool AddCompany(CompanyDetailsEntities companyDetail)
        {
            ICompanyBL AddCompanyBL = new CompanyBL();
            var addcomp = AddCompanyBL.AddCompany(companyDetail);
            var abc = companyDetail;
            return addcomp;
        }

        public CompanyDetailsEntities StartNewFinancialYear(string status)
        {
            ICompanyBL obj = new CompanyBL();
            return obj.StartNewFinancialYear(status);
        }
        //public bool DeleteShippingaddress(int ShippingId)
        //{
        //    ICompanyBL CompanyBL = new CompanyBL();
        //    var addcomp = CompanyBL.DeleteShippingaddress(ShippingId);
        //    return addcomp;
        //}
        //public IList<CountryDropDown> GetAllCountryModel()
        //{
        //    IList<CountryDropDown> result = new List<CountryDropDown>();
        //    ICompanyBL countryModelBL = new CompanyBL();
        //    List<Country> countryList = countryModelBL.GetAllCountryModel();
        //    foreach (Country source in countryList)
        //    {
        //        CountryDropDown target = new CountryDropDown();
        //        target.CountryCode = source.CountryId.ToString();
        //        target.CountryName = source.CountryName;
        //        result.Add(target);
        //    }
        //    return result;
        //}
        //public IList<StateDropDown> GetStates()
        //{
        //    IList<StateDropDown> result = new List<StateDropDown>();
        //    ICompanyBL stateModelBL = new CompanyBL();
        //    List<State> stateList = stateModelBL.GetAllStateModel();
        //    foreach (State source in stateList)
        //    {
        //        StateDropDown target = new StateDropDown();
        //        target.CountryCode = source.CountryId.ToString();
        //        target.StateName = source.StateName;
        //        target.StateCode = source.StateCode;
        //        result.Add(target);
        //    }
        //    return result;
        //}


    }
    }

