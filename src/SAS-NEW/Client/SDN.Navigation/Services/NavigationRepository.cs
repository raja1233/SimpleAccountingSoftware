namespace SDN.Navigation.Services
{
    using Settings.BL;
    using SDN.UI.Entities;     
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
