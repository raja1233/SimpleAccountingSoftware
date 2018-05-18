using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities;

namespace SDN.Navigation.Services
{
    using SDN.Settings.BL;
    using SDN.Settings.BLInterface;
    using SDN.UI.Entities;
    using Settings.BL;
    using Settings.BLInterface;

    public class NavigationRepository : INavigationRepository
    {
        public CompanyDetailsEntities GetCompanyDetails()
        {
            ICompanyBL companyBL = new CompanyBL();
            CompanyDetailsEntities companyDetails = companyBL.GetCompanyDetails();
            return companyDetails;
        }
    }
}
