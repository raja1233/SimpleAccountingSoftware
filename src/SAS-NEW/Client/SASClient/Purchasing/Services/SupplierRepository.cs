using SDN.Purchasings.BL;
using SDN.Purchasings.BLInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    public class SupplierRepository:ISupplierRepository
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>Get All Customers</returns>
        public IEnumerable<SupplierDetailEntity> GetAllSupplier()
        {
            ISupplierBL _supplierBL = new SupplierBL();

            IList<SupplierDetailEntity> SupplierList = new List<SupplierDetailEntity>();
           

            SupplierList = _supplierBL.GetAllSupplier();
            return SupplierList;
        }

        public List<SupplierDetailEntity> GetSupplierList()
        {
            ISupplierBL _supplierBL = new SupplierBL();

            List<SupplierDetailEntity> SupplierList = new List<SupplierDetailEntity>();
            SupplierList = _supplierBL.GetSupplierList();
            return SupplierList;
        }
        //public IEnumerable<CatagoryType> GetCustomerType()
        //{
        //    ICustomersBL _customerBL = new CustomersBL();

        //    var ctype = _customerBL.GetCustomerType();

        //    return ctype;
        //}

        //public IEnumerable<CatagoryType> GetCatagoryType(string cat_type)
        //{
        //    ICustomersBL _customerBL = new CustomersBL();

        //    var ctype = _customerBL.GetCategoryType(cat_type);

        //    return ctype;
        //}

        //public IEnumerable<ShippingAddress> GetShippingAddress(int customerId)
        //{
        //    ICustomersBL _customerBL = new CustomersBL();

        //    return _customerBL.GetShippingAddress(customerId);
        //}
        public bool CreateSupplier(SupplierDetailEntity entity)
        {
            ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.CreateSupplier(entity);
        }

        public int GetSupplierCount(string isInActive)
        {
              ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.GetSupplierCount(isInActive);
        }
        public bool CanDeleteSupplier(int supId)
        {
            ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.CanDeleteSupplier(supId);
            //return false;
        }

        public bool DeleteSupplier(int supId)
        {
            ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.DeleteSupplier(supId);
            //return false;
        }

        public bool? AllowedToChangeLimit()
        {
             ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.IsAllowedToChangeLimit();

        }

        public OptionsEntity GetOptionSettings()
        {
            ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.GetOptionSettings();

        }
        public bool RefreshSupplier(int supId)
        {
            ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.RefreshSupplier(supId);
        }

        #region AutoFill
        public List<Country> AutoFillCountry()
        {
            ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.AutoFillCountry();
        }

        public List<State> AutoFillState()
        {
            ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.AutoFillState();
        }

        public List<City> AutoFillCity()
        {
            ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.AutoFillCity();
        }

        public List<PostalCode> AutoFillPostalCode()
        {
            ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.AutoFillPostalCode();
        }
        public TaxModel GetDefaultTaxes()
        {
            ISupplierBL _supplierBL = new SupplierBL();
            return _supplierBL.GetDefaultTaxes();
        }
        public List<TaxModel> GetTaxCodeAndRatesList()
        {
            ISupplierBL _supplierBL = new SupplierBL();

            var cTaxRateList = _supplierBL.GetTaxCodeAndRate();
            if (cTaxRateList != null)
            {
                cTaxRateList = cTaxRateList.FindAll(x => x.IsInActive != "Y");
            }
            return cTaxRateList;

        }

        #endregion
    }
}
