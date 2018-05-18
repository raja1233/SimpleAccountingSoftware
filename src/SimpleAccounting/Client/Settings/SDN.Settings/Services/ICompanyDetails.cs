using SDN.Common;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.Services
{
   public interface ICompanyDetails
    {
        CompanyDetailsEntities GetCompanyDetails();
        bool AddCompany(CompanyDetailsEntities companyDetail);
        //IEnumerable<ShippingAddressEntity> GetShippingDetails(int CompanyId, string EntityType);
        //IEnumerable<ShippingAddressEntity> GetSelectedShipDetails(int ShipId);
        //bool DeleteShippingaddress(int ShippingId);
        void AddCompanyLogo(byte[] Image);
        //IList<CountryDropDown> GetAllCountryModel();
        //IList<StateDropDown> GetStates();
    }
}
