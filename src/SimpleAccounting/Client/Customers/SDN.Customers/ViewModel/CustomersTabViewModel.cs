 

namespace SDN.Customers.ViewModel
{
    using SDN.Common;
    using SDN.Customers.Views;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Prism.Events;
    using UI.Entities;

    /// <summary>
    /// Customers tab view
    /// </summary>
    public class CustomersTabViewModel: CustomerTabEntity
    {
        #region Private Properties
        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;
        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The customers details click command
        /// </summary>
        private readonly DelegateCommand customersDetailsClickCommand = null;

        /// <summary>
        /// The Customers history click command
        /// </summary>
        private readonly DelegateCommand customersHistoryClickCommand = null;

        /// <summary>
        /// The Customers statement click command
        /// </summary>
        private readonly DelegateCommand customersStatementClickCommand = null;

        /// <summary>
        /// The P & S Sold to customers click command
        /// </summary>
        private readonly DelegateCommand pandsSoldtoCustomersClickCommand = null;

        /// <summary>
        /// The P & S Sold to customers click command
        /// </summary>
        private readonly DelegateCommand topCustomersClickCommand = null;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the customer click command.
        /// </summary>
        /// <value>
        /// The customer click command.
        /// </value>
        public DelegateCommand CustomerDetailsClickCommand
        {
            get
            {
                return (this.customersDetailsClickCommand ?? new DelegateCommand(this.ShowCustomersView));
                
            }
        }


        /// <summary>
        /// Gets the Customers history click command.
        /// </summary>
        /// <value>
        /// The customers history click command.
        /// </value>
        public DelegateCommand CustomersHistoryClickCommand
        {
            get
            {
                return (this.customersHistoryClickCommand ?? new DelegateCommand(this.ShowCustomersHistoryView));
              
            }
        }

        /// <summary>
        /// Gets the Customers Statement click command.
        /// </summary>
        /// <value>
        /// The Customers Statement click command.
        /// </value>
        public DelegateCommand CustomersStatementClickCommand
        {
            get
            {
                 return (this.customersStatementClickCommand ?? new DelegateCommand(this.ShowCustomersStatementView));
               
            }
        }

        /// <summary>
        /// Gets the P & S to sold customers click command.
        /// </summary>
        /// <value>
        /// The PandStoSoldCustomers click command.
        /// </value>
        public DelegateCommand PandStoSoldCustomersClickCommand
        {
            get
            {
                return (this.pandsSoldtoCustomersClickCommand ?? new DelegateCommand(this.ShowPandStoSodCustomersView));
                
            }
        }
        public DelegateCommand TopCustomersClickCommand
        {
            get
            {
                return (this.topCustomersClickCommand ?? new DelegateCommand(this.ShowTopCustomersView));

            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersTabViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public CustomersTabViewModel(IRegionManager regionManager,IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.setdefaultTab();
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Shows the customers view.
        /// </summary>
        private void ShowCustomersView()
        {
            var view = ServiceLocator.Current.GetInstance<CustomersView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }

        /// <summary>
        /// Shows the customers history view.
        /// </summary>
        private void ShowCustomersHistoryView()
        {
            var view = ServiceLocator.Current.GetInstance<CustomerHistoryView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }

        /// <summary>
        /// Shows the Customer statement view.
        /// </summary>
        private void ShowCustomersStatementView()
        {
            var view = ServiceLocator.Current.GetInstance<CustomersStatementView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }

        /// <summary>
        /// Shows the P and S Sold to customers view.
        /// </summary>
        private void ShowPandStoSodCustomersView()
        {
            SharedValues.getValue = "PandSSoldToCustomersTab";
            var view = ServiceLocator.Current.GetInstance<PandSSoldToCustomersView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Sold to Customers");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }
        private void ShowTopCustomersView()
        {
            SharedValues.getValue = "TopCustomersTab";
            var view = ServiceLocator.Current.GetInstance<TopCustomersView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Top Customers");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }
        #endregion

        private void setdefaultTab()
        {
            if (SharedValues.getValue == "CustomerDetailTab")
            {
                this.CustomerDetailTabTrue = true;
            }
            else if (SharedValues.getValue == "CustomerHistoryTab")
            {
                this.CustomerHistoryTrue = true;
            }
            else if (SharedValues.getValue == "PurchaseInvoiceTab")
            {
                this.InvoiceTabTrue = true;
            }
            else if (SharedValues.getValue == "PandSSoldToCustomersTab")
            {
                this.PandSSoldToCustomersTabTrue = true;
            }
            else if (SharedValues.getValue == "PaymentToCustomerTab")
            {
                this.PaymentTabTrue = true;
            }
            else if (SharedValues.getValue == "TopCustomersTab")
            {
                this.TopCustomersTabTrue = true;
            }
            else
            {
                this.CustomerDetailTabTrue = true;
            }
        }
    }
}