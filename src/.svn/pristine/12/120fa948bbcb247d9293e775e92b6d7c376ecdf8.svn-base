
using SDN.Settings.BL;
using SDN.Settings.BLInterface;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.SettingsEDM;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.BL
{
    public class CompanyBL : ICompanyBL
    {

        public bool AddCompany(CompanyDetailsEntities companyDetail)
        {
            ICompanyDAL addCompanyDAL = new CompanyDAL();
            var companyDAL = addCompanyDAL.AddCompanyDAL(companyDetail);
            var abc = companyDetail;
            return companyDAL;
        }
        public void AddCompanyLogo(byte[] Image)
        {
            ICompanyDAL addCompanyDAL = new CompanyDAL();
             addCompanyDAL.AddCompanyLogo(Image);
        }
        public bool DeleteShippingaddress(int ShippingId)
        {
            //ICompanyDAL CompanyDAL = new CompanyDAL();
            //var companyDAL = CompanyDAL.DeleteShippingaddress(ShippingId);
            //return companyDAL;
            return false;
        }


        public CompanyDetailsEntities GetCompanyDetails()
        {
            ICompanyDAL compDetials = new CompanyDAL();
            var companyDAL = compDetials.GetCompanyDetails();
            return companyDAL;
        }

        //public IEnumerable<ShippingAddressEntity> GetShippingDetails(int CompanyId, string EntityType)
        //{

        //   CompanyDetailsEntities result = new CompanyDetailsEntities();
        //    ICompanyDAL compDetials = new CompanyDAL();
        //    IEnumerable<ShippingAddressEntity> result = compDetials.ShippingAddressDetails(CompanyId, EntityType);
        //    var Number = 1;
        //    foreach (var item in result)
        //    {
        //        item.ShippingTitle = "Address " + Number;
        //        Number++;
        //    }
        //    return result;

        //}


        //public IEnumerable<ShippingAddressEntity> GetSelectedShipDetails(int ShipId)
        //{

        //    //CompanyDetailsEntities result = new CompanyDetailsEntities();
        //    ICompanyDAL compDetials = new CompanyDAL();
        //    IEnumerable<ShippingAddressEntity> result = compDetials.ShippingAddressDetails(ShipId);
           
        //    return result;
        //}

        //public List<Country> GetAllCountryModel()
        //{
        //    ICompanyDAL getCountryDAL = new CompanyDAL();
        //    List<Country> result = getCountryDAL.GetAllCountryModel();
        //    return result;
        //}
        //public List<State> GetAllStateModel()
        //{
        //    ICompanyDAL getStateDAL = new CompanyDAL();
        //    List<State> result = getStateDAL.GetAllStateModel();
        //    return result;
        //}
    }
}

