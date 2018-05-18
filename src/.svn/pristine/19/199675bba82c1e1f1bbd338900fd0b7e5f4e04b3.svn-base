

namespace SDN.Purchasings.BLInterface
{
    using UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface ISupplierBL
    {
        List<SupplierDetailEntity> GetAllSupplier();

        //List<CatagoryType> GetCustomerType();

        //List<CatagoryType> GetCategoryType(string filter);
        //IEnumerable<ShippingAddress> GetShippingAddress(int customerId);
        bool CreateSupplier(SupplierDetailEntity entity);
        int GetSupplierCount(string isInActive);
        bool CanDeleteSupplier(int supId);
        bool DeleteSupplier(int supId);
        bool? IsAllowedToChangeLimit();
        OptionsEntity GetOptionSettings();
        bool RefreshSupplier(int supId);

        List<Country> AutoFillCountry();
        List<State> AutoFillState();
        List<City> AutoFillCity();
        List<PostalCode> AutoFillPostalCode();
        TaxModel GetDefaultTaxes();
        List<TaxModel> GetTaxCodeAndRate();
    }
}
