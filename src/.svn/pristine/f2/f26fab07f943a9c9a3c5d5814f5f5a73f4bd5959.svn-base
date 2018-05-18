namespace SDN.Sales.ViewModel
{
    using SDN.Common;
    using SDN.Sales.Views;
    using SDN.UI.Entities.Sales;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Prism.Events;

    /// <summary>
    /// class SalesTabViewModel
    /// </summary>
    public sealed class SalesTabViewModel : SalesTabEntity
    {
        #region "Private members"

        
        public SalesTabViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

        }
        public SalesTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.setdefaultTab();
        }
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The Companydetails click command
        /// </summary>
        private readonly DelegateCommand salesQuotationClickCommand = null;
        private readonly DelegateCommand salesOrderClickCommand = null;
        private readonly DelegateCommand salesInvoiceClickCommand = null;
        private readonly DelegateCommand creditNoteClickCommand = null;
        private readonly DelegateCommand paymentFromCustomerClickCommand = null;


        #endregion

        #region "Public properties"

        /// <summary>
        /// Gets the Company details click command.
        /// </summary>
        /// <value>
        /// The Companydetails click command.
        /// </value>
        public DelegateCommand SalesQuotationClickCommand
        {
            get
            {
                return (this.salesQuotationClickCommand ?? new DelegateCommand(this.ShowSalesQuotationView));
            }
        }
        public DelegateCommand SalesOrderClickCommand
        {
            get
            {
                return (this.salesOrderClickCommand ?? new DelegateCommand(this.ShowSalesOrderView));
            }
        }
        public DelegateCommand SalesInvoiceClickCommand
        {
            get
            {
                return (this.salesInvoiceClickCommand ?? new DelegateCommand(this.ShowSalesInvoiceView));
            }
        }

        public DelegateCommand CreditNoteClickCommand
        {
            get
            {
                return (this.creditNoteClickCommand ?? new DelegateCommand(this.ShowCreditNoteView));
            }
        }

        public DelegateCommand PaymentToSupplierClickCommand
        {
            get
            {
                return (this.paymentFromCustomerClickCommand ?? new DelegateCommand(this.ShowPaymentsFromCustomersView));
            }
        }

        #endregion

        #region "Private Methods"

        public void ShowSalesQuotationView()
        {
            SharedValues.getValue = "SalesQuotationTab";
            var view = ServiceLocator.Current.GetInstance<SalesQuotationListView>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Quotations List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }
        public void ShowSalesOrderView()
        {
            SharedValues.getValue = "SalesOrderTab";
            var view = ServiceLocator.Current.GetInstance<SalesOrderListView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Orders List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }

        public void ShowSalesInvoiceView()
        {
            SharedValues.getValue = "SalesInvoiceTab";
            var view = ServiceLocator.Current.GetInstance<SalesInvoiceListView>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoices List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }
        public void ShowCreditNoteView()
        {
            SharedValues.getValue = "CreditNoteTab";
            var view = ServiceLocator.Current.GetInstance<CreditNoteListView>();

           
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Credit Notes List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }

        public void ShowPaymentsFromCustomersView()
        {
            SharedValues.getValue = "PaymentFromCustomerTab";
            var view = ServiceLocator.Current.GetInstance<PaymentFromCustomersListView>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payments From Customers List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }

        #endregion
        private void setdefaultTab()
        {
            if (SharedValues.getValue == "SalesQuotationTab")
            {
                this.QuotationTabTrue = true;
            }
            else if (SharedValues.getValue == "SalesOrderTab")
            {
                this.OrderTabTrue = true;
            }
            else if (SharedValues.getValue == "SalesInvoiceTab")
            {
                this.InvoiceTabTrue = true;
            }
            else if (SharedValues.getValue == "CreditNoteTab")
            {
                this.DebitTabTrue = true;
            }
            else if (SharedValues.getValue == "PaymentFromCustomerTab")
            {
                this.PaymentTabTrue = true;
            }
            else
            {
                this.QuotationTabTrue = true;
            }
        }
    }
}
