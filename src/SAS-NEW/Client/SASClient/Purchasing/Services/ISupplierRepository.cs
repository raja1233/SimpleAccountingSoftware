using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
   public interface ISupplierRepository
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        IEnumerable<SupplierDetailEntity> GetAllSupplier();
        List<SupplierDetailEntity> GetSupplierList();

        //IEnumerable<CatagoryType> GetCustomerType();

        //IEnumerable<CatagoryType> GetCatagoryType(string cat_type);

        //IEnumerable<ShippingAddress> GetShippingAddress(int customerId);

        /// int CreateCustomer(Customer entity, List<ShippingAddress> shippingAddress);
        bool CreateSupplier(SupplierDetailEntity entity);
        int GetSupplierCount(string isInActive);
        bool CanDeleteSupplier(int supId);
        bool DeleteSupplier(int supId);
        bool? AllowedToChangeLimit();
        OptionsEntity GetOptionSettings();
        bool RefreshSupplier(int supId);
        List<Country> AutoFillCountry();
        List<State> AutoFillState();
        List<City> AutoFillCity();
        List<PostalCode> AutoFillPostalCode();
        TaxModel GetDefaultTaxes();
        List<TaxModel> GetTaxCodeAndRatesList();
    }
}
