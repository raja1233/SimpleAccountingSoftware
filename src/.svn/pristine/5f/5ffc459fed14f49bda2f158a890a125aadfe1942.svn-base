 

namespace SDN.Navigation.ViewModel
{
    using SDN.Common;
    using SDN.Navigation.View;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using SDN.Navigation.Services;
    using SDN.Settings.ViewModel;
    using SDN.UI.Entities;

   public sealed class FooterViewModel:ViewModelBase
    {
        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private string companyName="Company Name";
        INavigationRepository navRepository = new NavigationRepository();
        // CompanyViewModel compViewModel = new CompanyViewModel();
      
       
        
        /// <summary>
        /// The event aggregator
        /// </summary>
        

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public FooterViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<CompanynameChangedEvent>().Subscribe(this.CompanyNameChanged);
            
        }
        private void CompanyNameChanged(string companyname)
        {
            this.companyName = companyname;
            this.OnPropertyChanged("CompanyName");
        }
        #endregion
        public string CompanyName
        {
            get
            {
                return this.companyName = navRepository.GetCompanyDetails().CompanyName;
            }
            set
            {
                companyName = value;
                this.OnPropertyChanged("CompanyName");
            }
        }
    }
}
