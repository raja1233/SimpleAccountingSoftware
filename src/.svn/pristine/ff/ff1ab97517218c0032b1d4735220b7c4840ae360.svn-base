

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
    using SASClient.Purchasing.View;
    using SASClient.CloseRequest;
    using System.Windows;

    public class SupplierTabViewModel : SupplierTabEntity
    {
        #region Private Properties
        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;
        StackList listitem = new StackList();
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

        private readonly DelegateCommand pandSPurchasedfromSupplierClickCommand = null;

        private readonly DelegateCommand supplierStatementClickCommand = null;
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
        public DelegateCommand SupplierStatementClickCommand
        {
            get
            {
                return (this.supplierStatementClickCommand ?? new DelegateCommand(this.ShowSuppliersStatementView));

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
        /// <summary>
        /// Gets the P & S to sold customers click command.
        /// </summary>
        /// <value>
        /// The PandStoSoldCustomers click command.
        /// </value>
        public DelegateCommand PandSPurchasedfromSupplierClickCommand
        {
            get
            {
                return (this.pandSPurchasedfromSupplierClickCommand ?? new DelegateCommand(this.PandSPurchasedfromSupplierView));

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
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Suppliers Details List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "SupplierDetailTab";
            var view = ServiceLocator.Current.GetInstance<SuppliersDetailsList1View>();

            var view2 = ServiceLocator.Current.GetInstance<SupplierTabView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }

            var SubTabView = ServiceLocator.Current.GetInstance<SuppliersDetailsSubTabView>();
            var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

            subMenuRegion.Add(SubTabView);

            if (subMenuRegion != null)
            {
                subMenuRegion.Activate(SubTabView);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details List ");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        /// <summary>
        /// Shows the customers history view.
        /// </summary>
        private void ShowSupplierHistoryView()
        {
            SharedValues.ScreenCheckName = "Suppliers History";
            SharedValues.ViewName = "Suppliers History";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                var view = ServiceLocator.Current.GetInstance<SupplierHistoryView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers History");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        /// <summary>
        /// Shows the Customer statement view.
        /// </summary>
        private void ShowSuppliersStatementView()
        {
            SharedValues.ScreenCheckName = "Suppliers Statement";
            SharedValues.ViewName = "Suppliers UnPaid Invoices";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "SupplierStatementTab";
            var view = ServiceLocator.Current.GetInstance<SuppliersUnPaidInvoicesView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }

            var view2 = ServiceLocator.Current.GetInstance<SupplierTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }

            var SubTabView = ServiceLocator.Current.GetInstance<StatementSubTabView>();
            var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

            subMenuRegion.Add(SubTabView);

            if (subMenuRegion != null)
            {
                subMenuRegion.Activate(SubTabView);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Statement ");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
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

        private void PandSPurchasedfromSupplierView()
        {
            SharedValues.ScreenCheckName = "P & S Purchased";
            SharedValues.ViewName = "Products and Services Purchased From Supplier";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PandSPurchasedFromSupplier";
            var view = ServiceLocator.Current.GetInstance<PandSPurchasedFromSuppliersView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Purchased From Supplier");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        private void ShowTopSuppliersView()
        {
            SharedValues.ScreenCheckName = "Top Suppliers";
            SharedValues.ViewName = "Top Suppliers";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
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
            else if (SharedValues.getValue == "SupplierStatementTab")
            {
                this.SupplierStatementTabTrue = true;
            }
            else if (SharedValues.getValue == "PaymentToSupplierTab")
            {
                this.PaymentTabTrue = true;
            }
            else if (SharedValues.getValue == "PandSPurchasedFromSupplier")
            {
               this.PandSPurchasedTabTrue = true;
            }
            else
            {
                this.SupplierDetailTabTrue = true;
            }
        }
    }
}
