

namespace SDN.Purchasing.ViewModel
{
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.ServiceLocation;
    using SDN.Common;
    using SDN.Purchasing.View;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UI.Entities;

    public class SupplierTabViewModel:SupplierTabEntity
    {
        #region Private Properties
        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;

        private readonly IEventAggregator eventAggregator;
        /// <summary>
        /// The customers details click command
        /// </summary>
        private readonly DelegateCommand supplierDetailClickCommand = null;

        /// <summary>
        /// The Customers history click command
        /// </summary>
        private readonly DelegateCommand supplierHistoryClickCommand = null;

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
        private readonly DelegateCommand topSuppliersClickCommand = null;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the customer click command.
        /// </summary>
        /// <value>
        /// The customer click command.
        /// </value>
        public DelegateCommand SupplierDetailsClickCommand
        {
            get
            {
                return (this.supplierDetailClickCommand ?? new DelegateCommand(this.ShowSupplierView));

            }
        }
        public DelegateCommand TopSuppliersClickCommand
        {
            get
            {
                return (this.topSuppliersClickCommand ?? new DelegateCommand(this.ShowTopSuppliersView));

            }
        }


        /// <summary>
        /// Gets the Customers history click command.
        /// </summary>
        /// <value>
        /// The customers history click command.
        /// </value>
        public DelegateCommand SupplierHistoryClickCommand
        {
            get
            {
                return (this.supplierHistoryClickCommand ?? new DelegateCommand(this.ShowSupplierHistoryView));

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
      
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersTabViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public SupplierTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
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
        private void ShowSupplierView()
        {
            var view = ServiceLocator.Current.GetInstance<SupplierDetailView>();

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
        private void ShowSupplierHistoryView()
        {
            var view = ServiceLocator.Current.GetInstance<SupplierHistoryView>();

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
            //var view = ServiceLocator.Current.GetInstance<CustomersStatementView>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }

        /// <summary>
        /// Shows the P and S Sold to customers view.
        /// </summary>
        private void ShowPandStoSodCustomersView()
        {
            //var view = ServiceLocator.Current.GetInstance<PandSSoldToCustomersView>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }
        private void ShowTopCustomersView()
        {
            //var view = ServiceLocator.Current.GetInstance<TopCustomersView>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }
        private void ShowTopSuppliersView()
        {
            SharedValues.getValue = "TopSuppliersTab";
            var view = ServiceLocator.Current.GetInstance<TopSuppliersView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Top Suppliers");
        }
        
        #endregion
        private void setdefaultTab()
        {
            if (SharedValues.getValue == "SupplierDetailTab")
            {
                this.SupplierDetailTabTrue = true;
            }
            else if (SharedValues.getValue == "SupplierHistoryTab")
            {
                this.SupplierHistoryTrue = true;
            }
            else if (SharedValues.getValue == "TopSuppliersTab")
            {
                this.TopSuppliersTabTrue = true;
            }
            else if (SharedValues.getValue == "DebitNoteTab")
            {
                this.DebitTabTrue = true;
            }
            else if (SharedValues.getValue == "PaymentToSupplierTab")
            {
                this.PaymentTabTrue = true;
            }
            else
            {
                this.SupplierDetailTabTrue = true;
            }
        }
    }
}
