namespace SDN.Navigation.ViewModel
{
    using SDN.Common;
    using SDN.Manufacturing.View;
    using SDN.Product.View;
    using SDN.Purchasing.View;
    using SDN.Sales.Views;
    using SDN.Settings.Views;

    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Customers.Views;
    using CashBank.Views;
    using UI.Entities;
    using Purchasing.Services;

    //using Settings.Views.Company;


    /// <summary>
    /// Main View Model Class
    /// </summary>
    public sealed class MainViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The button click command
        /// </summary>
        private readonly DelegateCommand<object> salesClickCommand = null;
        /// <summary>
        /// The Settings click command
        /// </summary>
        private readonly DelegateCommand<object> settingsClickCommand = null;
        /// <summary>
        /// The Files click command
        /// </summary>
        private readonly DelegateCommand<object> filesClickCommand = null;
        /// <summary>
        /// The Cash & Bank click command
        /// </summary>
        private readonly DelegateCommand<object> cashandbankClickCommand = null;
        /// <summary>
        /// The Accounts click command
        /// </summary>
        private readonly DelegateCommand<object> AccountsClickCommand = null;
        /// <summary>
        /// The purchase click command
        /// </summary>
        private readonly DelegateCommand purchaseClickCommand = null;
        /// <summary>
        /// The CashBank click command
        /// </summary>
        private readonly DelegateCommand<object> cashBankCommand = null;
        /// <summary>
        /// The Purchasing click command
        /// </summary>
        private readonly DelegateCommand<object> purchaseCommand = null;
      

        #region "Products Click command"
        /// <summary>
        /// The product click command
        /// </summary>
        private readonly DelegateCommand productClickCommand = null;
        private readonly DelegateCommand<object> countandAdjustStockClickCommand = null;
        private readonly DelegateCommand pandSDescriptionClickCommand = null;
        private readonly DelegateCommand countandAdjustStockListClickCommand = null;
        private readonly DelegateCommand pandSSoldClickCommand = null;
        private readonly DelegateCommand pandSPurchaseClickCommand = null;
        private readonly DelegateCommand<object> pandSSoldToCustomerClickCommand = null;
        private readonly DelegateCommand topPandSClickCommand = null;

        #endregion

        #region "Settings Click command"
        /// <summary>
        /// The Settings click command
        /// </summary>
        private readonly DelegateCommand categoriesCommand = null;
        private readonly DelegateCommand companyDetailsCommand = null;
        private readonly DelegateCommand optionsCommand = null;
        private readonly DelegateCommand taxCodesRatesCommand = null;
        private readonly DelegateCommand usersAndSecurityCommand = null;

        #endregion

        #region "Sales Click command"
        private readonly DelegateCommand<object> salesQuotationListClickCommand = null;
        private readonly DelegateCommand<object> salesOrderListListClickCommand = null;
        private readonly DelegateCommand<object> salesInvoiceListCommand = null;
        private readonly DelegateCommand<object> creditNoteListListCommand = null;
        private readonly DelegateCommand<object> paymentsFromCustomersListCommand = null;

        private readonly DelegateCommand<object> salesQuotationFormClickCommand = null;
        private readonly DelegateCommand<object> salesOrderFormClickCommand = null;
        private readonly DelegateCommand<object> salesInvoiceFormCommand = null;
        private readonly DelegateCommand<object> creditNoteFormCommand = null;
        private readonly DelegateCommand<object> paymentsFromCustomersFormCommand = null;
        private readonly DelegateCommand<object> refundToCustomerFormCommand = null;
        private readonly DelegateCommand<object> refundToCustomersListCommand = null;
        
        #endregion

        #region "Purchase click Command"
        /// <summary>
        /// The region manager
        /// </summary>

        private DelegateCommand purchaseClickCommand1;
        private DelegateCommand purchaseOrderListClickCommand;
        private DelegateCommand purchaseInvoiceListClickCommand;
        private DelegateCommand debitNoteListClickCommand;
        private readonly DelegateCommand<object> paymentsToSuppliersListCommand = null;

        private DelegateCommand<object> purchaseQuoatationFormClickCommand1;
        private DelegateCommand<object> purchaseOrderFormClickCommand;
        private DelegateCommand<object> purchaseInvoiceFormClickCommand;
        private DelegateCommand<object> debitNoteFormClickCommand;
        private readonly DelegateCommand<object> paymentsToSuppliersFormCommand = null;
        private readonly DelegateCommand<object> refundFromsupplierFormCommand = null;
        private readonly DelegateCommand<object> refundFromsuppliersListCommand = null;

        #endregion

        #region "Customers Click Command"
        /// <summary>
        /// The Customers click command
        /// </summary>
        private readonly DelegateCommand<object> customersClickCommand = null;
        private readonly DelegateCommand<object> customersHistoryClickCommand = null;
        private readonly DelegateCommand<object> topCustomersClickCommand = null;
        
        #endregion

        #region "Suppliers Click Command"
        /// <summary>
        /// The Suppliers click command
        /// </summary>
        private readonly DelegateCommand<object> suppliersClickCommand = null;
        private readonly DelegateCommand<object> suppliersHistoryClickCommand = null;
        private readonly DelegateCommand<object> topSuppliersClickCommand = null;
        #endregion

        #region "Accounts Click command"
        private DelegateCommand accountFormClickCommand = null;
        #endregion

        #endregion

        #region Public Properties

        #region "Settings Click"

        /// <summary>
        /// Settings Click Command
        /// </summary>
        public DelegateCommand CompanyDetailsCommand
        {
            get
            {
                return (this.companyDetailsCommand ?? new DelegateCommand(this.ShowCompanyDetailsView));
            }
        }
        public DelegateCommand CategoriesCommand
        {
            get
            {
                return (this.categoriesCommand ?? new DelegateCommand(this.ShowCategoriesView));
            }
        }
        public DelegateCommand OptionsCommand
        {
            get
            {
                return (this.optionsCommand ?? new DelegateCommand(this.ShowOptionsView));
            }
        }
        public DelegateCommand TaxCodesRatesCommand
        {
            get
            {
                return (this.taxCodesRatesCommand ?? new DelegateCommand(this.ShowTaxCodesAndRatesView));
            }
        }
        public DelegateCommand UsersAndSecurityCommand
        {
            get
            {
                return (this.usersAndSecurityCommand ?? new DelegateCommand(this.ShowUsersSecurityView));
            }
        }

        #endregion

        #region "Product Click"
        /// <summary>
        /// Gets the products click command.
        /// </summary>
        /// <value>
        /// The products click command.
        /// </value>
        public DelegateCommand ProductsClickCommand
        {
            get
            {
                return (this.productClickCommand ?? new DelegateCommand(this.ShowProductsView));
            }
        }
        public DelegateCommand PandSSoldClickCommand
        {
            get
            {
                return (this.pandSSoldClickCommand ?? new DelegateCommand(this.PandSSoldView));
            }
        }

        public DelegateCommand PandSPurchaseClickCommand
        {
            get
            {
                return (this.pandSPurchaseClickCommand ?? new DelegateCommand(this.PandSPurchaseView));
            }
        }

        public DelegateCommand<object> CountandAdjustClickCommand
        {
            get
            {
                return (this.countandAdjustStockClickCommand ?? new DelegateCommand<object>(this.ShowCountAndAdjustStockView));
            }
        }
        public DelegateCommand PandSDescriptionClickCommand
        {
            get
            {
                return (this.pandSDescriptionClickCommand??new DelegateCommand(this.ShowProductsDescriptionView));
            }
        }
        public DelegateCommand CountandAdjustStockListClickCommand
        {
            get
            {
                return (this.countandAdjustStockListClickCommand ?? new DelegateCommand(this.ShowCountAndAdjustStockListView));
            }
        }
        public DelegateCommand TopPandSClickCommand
        {
            get
            {
                return (this.topPandSClickCommand ?? new DelegateCommand(this.ShowTopPandSView));
            }
        }
        
        #endregion

        /// <summary>
        /// Gets the purchase click command.
        /// </summary>
        /// <value>
        /// The purchase click command.
        /// </value>
        public DelegateCommand PurchaseClickCommand
        {
            get
            {
                return (this.purchaseClickCommand ?? new DelegateCommand(this.ShowPurchaseView));
            }
        }

        #region "Purchase Click"
        public DelegateCommand PurchaseClickCommand1
        {
            get
            {
                return (this.purchaseClickCommand1 ?? new DelegateCommand(this.ShowPurchaseView1));
            }
        }

        public DelegateCommand<object> PurchaseQuotationFormClickCommand1
        {
            get
            {
                return (this.purchaseQuoatationFormClickCommand1 ?? new DelegateCommand<object>(this.ShowPurchaseQuotationView));
            }
        }
        public DelegateCommand PurchaseOrderListClickCommand
        {
            get
            {
                return (this.purchaseOrderListClickCommand ?? new DelegateCommand(this.PurchaseOrderListView));
            }
        }

        public DelegateCommand<object> PurchaseOrderFormClickCommand
        {
            get
            {
                return (this.purchaseOrderFormClickCommand ?? new DelegateCommand<object>(this.PurchaseOrderFormView));
            }
        }
        public DelegateCommand PurchaseInvoiceListClickCommand
        {
            get
            {
                return (this.purchaseInvoiceListClickCommand ?? new DelegateCommand(this.PurchaseInvoiceListView));
            }
        }
        public DelegateCommand<object> PurchaseInvoiceFormClickCommand
        {
            get
            {
                return (this.purchaseInvoiceFormClickCommand ?? new DelegateCommand<object>(this.PurchaseInvoiceFormView));
            }
        }
        public DelegateCommand DebitNoteListClickCommand
        {
            get
            {
                return (this.debitNoteListClickCommand ?? new DelegateCommand(this.DebitNoteListView));
            }
        }
        public DelegateCommand<object> DebitNoteFormClickCommand
        {
            get
            {
                return (this.debitNoteFormClickCommand ?? new DelegateCommand<object>(this.DebitNoteFormView));
            }
        }
        public DelegateCommand<object> PaymentsToSuppliersListClickCommand
        {
            get
            {
                return (this.paymentsToSuppliersListCommand ?? new DelegateCommand<object>(this.ShowPaymentsToSuppliersListView));
            }
        }
        public DelegateCommand<object> PaymentsToSuppliersFormCommand
        {
            get
            {
                return (this.paymentsToSuppliersFormCommand ?? new DelegateCommand<object>(this.ShowPaymentsToSuppliersFormView));
            }
        }
        
        public DelegateCommand<object> RefundFromsupplierFormCommand
        {
            get
            {
                return (this.refundFromsupplierFormCommand ?? new DelegateCommand<object>(this.ShowRefundFromsupplierFormView));
            }
        }
        
        public DelegateCommand<object> RefundFromsuppliersListCommand
        {
            get
            {
                return (this.refundFromsuppliersListCommand ?? new DelegateCommand<object>(this.ShowRefundFromsuppliersListView));
            }
        }
        #endregion

        #region "Accounts click"
        public DelegateCommand AccountFormClickCommand
        {
            get
            {
                return (this.accountFormClickCommand ?? new DelegateCommand(this.AccountFormView));
            }
        }
        #endregion

        /// <summary>
        /// Gets the button click command.
        /// </summary>
        /// <value>
        /// The button click command.
        /// </value>
        public DelegateCommand<object> SalesClickCommand
        {
            get
            {
                return (this.salesClickCommand ?? new DelegateCommand<object>(this.ShowSalesViews));
            }
        }
        /// <summary>
        ///Gets Settings button click command
        /// </summary>
        public DelegateCommand <object> SettingsClickCommand
        {
            get
            {
                return (this.settingsClickCommand ?? new DelegateCommand<object>(this.ShowSettingsView));
            }
        }

        #region "Customers click"
        public DelegateCommand<object> CustomersClickCommand
        {
            get
            {
                return (this.customersClickCommand ?? new DelegateCommand<object>(this.ShowCustomersViews));
            }
        }
        public DelegateCommand<object> CustomersHistoryClickCommand
        {
            get
            {
                return (this.customersHistoryClickCommand ?? new DelegateCommand<object>(this.CustomersHistoryViews));
            }
        }
        public DelegateCommand<object> TopCustomersClickCommand
        {
            get
            {
                return (this.topCustomersClickCommand ?? new DelegateCommand<object>(this.ShowTopCustomersView));
            }
        }
        
        #endregion

        public DelegateCommand<object> CashBankCommand
        {
            get
            {
                return (this.cashBankCommand ?? new DelegateCommand<object>(this.ShowCashBankView));
            }
        }
        //public DelegateCommand<object> PurchaseCommand
        //{
        //    get
        //    {
        //        return (this.purchaseCommand ?? new DelegateCommand<object>(this.ShowPurchaseView));
        //    }
        //}

        #region "Suppliers Click"
        public DelegateCommand<object> SuppliersClickCommand
        {
            get
            {
                return (this.suppliersClickCommand ?? new DelegateCommand<object>(this.ShowSuppliersViews));
            }
        }
        public DelegateCommand<object> SuppliersHistoryClickCommand
        {
            get
            {
                return (this.suppliersHistoryClickCommand ?? new DelegateCommand<object>(this.SuppliersHistoryViews));
            }
        }

        public DelegateCommand<object> TopSuppliersClickCommand
        {
            get
            {
                return (this.topSuppliersClickCommand ?? new DelegateCommand<object>(this.ShowTopSuppliersViews));
            }
        }
        #endregion

        #region "Sales Click"
        public DelegateCommand<object> SalesQuotationListClickCommand
        {
            get
            {
                return (this.salesQuotationListClickCommand ?? new DelegateCommand<object>(this.ShowSalesQuotationsListView));
            }
        }

        public DelegateCommand<object> SalesQuotationFormClickCommand
        {
            get
            {
                return (this.salesQuotationFormClickCommand ?? new DelegateCommand<object>(this.ShowSalesQuotationsFormView));
            }
        }

        public DelegateCommand<object> SalesOrderListListClickCommand
        {
            get
            {
                return (this.salesOrderListListClickCommand ?? new DelegateCommand<object>(this.ShowSalesOrdersListView));
            }
        }
        public DelegateCommand<object> SalesOrderFormClickCommand
        {
            get
            {
                return (this.salesOrderFormClickCommand ?? new DelegateCommand<object>(this.ShowSalesOrdersFormView));
            }
        }

        public DelegateCommand<object> SalesInvoiceListCommand
        {
            get
            {
                return (this.salesInvoiceListCommand ?? new DelegateCommand<object>(this.ShowSalesInvoiceListView));
            }
        }
        public DelegateCommand<object> SalesInvoiceFormCommand
        {
            get
            {
                return (this.salesInvoiceFormCommand ?? new DelegateCommand<object>(this.ShowSalesInvoiceFormView));
            }
        }

        public DelegateCommand<object> CreditNoteListCommand
        {
            get
            {
                return (this.creditNoteListListCommand ?? new DelegateCommand<object>(this.ShowCreditNoteListView));
            }
        }
        public DelegateCommand<object> CreditNoteFormCommand
        {
            get
            {
                return (this.creditNoteFormCommand ?? new DelegateCommand<object>(this.ShowCreditNoteFormView));
            }
        }
        public DelegateCommand<object> PaymentsFromCustomersListCommand
        {
            get
            {
                return (this.paymentsFromCustomersListCommand ?? new DelegateCommand<object>(this.ShowPaymentsFromCustomersListView));
            }
        }
        public DelegateCommand<object> PaymentsFromCustomersFormCommand
        {
            get
            {
                return (this.paymentsFromCustomersFormCommand ?? new DelegateCommand<object>(this.ShowPaymentsFromCustomersFormView));
            }
        }
        public DelegateCommand<object> RefundToCustomerFormCommand
        {
            get
            {
                return (this.refundToCustomerFormCommand ?? new DelegateCommand<object>(this.ShowRefundToCustomerFormView));
            }
        }
        public DelegateCommand<object> RefundToCustomersListCommand
        {
            get
            {
                return (this.refundToCustomersListCommand ?? new DelegateCommand<object>(this.ShowRefundToCustomersListView));
            }
        }
        public DelegateCommand<object> PandSSoldToCustomerClickCommand
        {
            get
            {
                return (this.pandSSoldToCustomerClickCommand ?? new DelegateCommand<object>(this.pandSSoldToCustomerView));
            }
        }
        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public MainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            loadOptionsData();
        }

        #endregion

        #region Private Methods
        public void loadOptionsData()
        {
            OptionsEntity oData = new OptionsEntity();
            IPurchaseQuotationListRepository purchaseRepository = new PurchaseQuotationListRepository();
            oData = purchaseRepository.GetOptionSettings();
            SharedValues.CurrencyName = oData.CurrencyName;
            SharedValues.decimalPlaces = oData.DecimalPlaces.ToString();
            //TaxModel objDefaultTax = new TaxModel();
            //objDefaultTax = purchaseRepository.GetDefaultTaxes();

        }

        /// <summary>
        /// Shows the views.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void ShowSalesViews(object sender)
        {
            if (sender != null)
            {
                var view = ServiceLocator.Current.GetInstance<SalesQuotationListView>();

                IRegion region = this.regionManager.Regions[RegionNames.MainRegion];

                region.Add(view);
                if (region != null)
                {
                    region.Activate(view);
                }

                var view2 = ServiceLocator.Current.GetInstance<SalesTabView>();

                IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                region2.Add(view2);
                if (region2 != null)
                {
                    region2.Activate(view2);
                }
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales");
        }

        private void ShowSettingsView(object sender)
        {
            var mainview = ServiceLocator.Current.GetInstance<CompanyDetailsView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<SettingsTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Company Details");
        }

        #region "Customers Click methods"
        
        private void ShowCustomersViews(object sender)
        {
            if (sender != null)
            {
                SharedValues.getValue = "CustomerDetailTab";
                var view = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersView>();

                IRegion region = this.regionManager.Regions[RegionNames.MainRegion];

                region.Add(view);
                if (region != null)
                {
                    region.Activate(view);
                }

                var view2 = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();

                IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                region2.Add(view2);
                if (region2 != null)
                {
                    region2.Activate(view2);
                }
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details Form");
        }
        private void CustomersHistoryViews(object sender)
        {
            if (sender != null)
            {
                SharedValues.getValue = "CustomerHistoryTab";
                var view = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomerHistoryView>();

                IRegion region = this.regionManager.Regions[RegionNames.MainRegion];

                region.Add(view);
                if (region != null)
                {
                    region.Activate(view);
                }

                var view2 = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();

                IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                region2.Add(view2);
                if (region2 != null)
                {
                    region2.Activate(view2);
                }
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers History");
        }
        private void ShowTopCustomersView(object sender)
        {
            if (sender != null)
            {
                SharedValues.getValue = "TopCustomersTab";
                var view = ServiceLocator.Current.GetInstance<SDN.Customers.Views.TopCustomersView>();

                IRegion region = this.regionManager.Regions[RegionNames.MainRegion];

                region.Add(view);
                if (region != null)
                {
                    region.Activate(view);
                }

                var view2 = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();

                IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                region2.Add(view2);
                if (region2 != null)
                {
                    region2.Activate(view2);
                }
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Top Customers");
        }
        #endregion

        #region "Sales Click Methods"
        private void ShowSalesQuotationsListView(object sender)
        {
           
            SharedValues.getValue = "SalesQuotationTab";
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
           
            var mainview = ServiceLocator.Current.GetInstance<SalesQuotationListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Quotations List");
        }
        
        private void ShowSalesOrdersListView(object sender)
        {
            SharedValues.getValue = "SalesOrderTab";
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<SalesOrderListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Orders List");
        }

        private void ShowSalesInvoiceListView(object sender)
        {
            SharedValues.getValue = "SalesInvoiceTab";
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<SalesInvoiceListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoices List");
        }

        private void ShowCreditNoteListView(object param)
        {
            SharedValues.getValue = "CreditNoteTab";
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<CreditNoteListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Credit Notes List");
        }

        private void ShowPaymentsFromCustomersListView(object param)
        {
            SharedValues.getValue = "PaymentFromCustomerTab";
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PaymentFromCustomersListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payments From Customers List");
        }

        private void ShowSalesQuotationsFormView(object sender)
        {
            if (sender != null)
            {
                SharedValues.NewClick = sender.ToString();
            }
            SharedValues.getValue = "SalesQuotationTab";
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<SalesQuotationView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Quotation Form");
        }
        private void ShowSalesOrdersFormView(object sender)
        {
            if (sender != null)
            {
                SharedValues.NewClick = sender.ToString();
            }
            SharedValues.getValue = "SalesOrderTab";
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<SalesOrderView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Order Form");
        }
        private void ShowSalesInvoiceFormView(object sender)
        {
            if (sender != null)
            {
                SharedValues.NewClick = sender.ToString();
            }
            SharedValues.getValue = "SalesInvoiceTab";
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<SalesInvoiceView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoice Form");
        }
        private void ShowCreditNoteFormView(object param)
        {
            if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "CreditNoteTab";
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<CreditNoteView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Credit Note Form");
        }
        private void ShowPaymentsFromCustomersFormView(object param)
        {
            if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "PaymentFromCustomerTab";
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PaymentFromCustomersView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payment From Customer Form");
        }
        private void ShowRefundToCustomerFormView(object param)
        {
            if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "RefundToCustomerTab";
            
            var tabview = ServiceLocator.Current.GetInstance<SDN.Common.View.CashAndBankTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<RefundToCustomerView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund To Customer Form");
        }
        private void ShowRefundToCustomersListView(object param)
        {
           
            SharedValues.getValue = "RefundToCustomerTab";

            var tabview = ServiceLocator.Current.GetInstance<SDN.Common.View.CashAndBankTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<RefundToCustomersListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund To Customers List");
        }
        private void pandSSoldToCustomerView(object param)
        {

            SharedValues.getValue = "PandSSoldToCustomersTab";

            var tabview = ServiceLocator.Current.GetInstance<CustomersTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PandSSoldToCustomersView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Sold to Customers");
        }

        #endregion

        #region "Purchase click methods"

        /// <summary>
        /// Shows the purchase view.
        /// </summary>
        private void ShowPurchaseView()
        {
            SharedValues.getValue = "PurchaseQuotationTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
           
            var mainview = ServiceLocator.Current.GetInstance<PurchaseQuotationListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Quotations List");
        }
        private void ShowPurchaseView1()
        {
            SharedValues.getValue = "PurchaseQuotationTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PurchaseQuotationListView>();

            //PurchaseTabEntity tabentity = new PurchaseTabEntity();
            //var tabentityValue = tabentity as PurchaseTabEntity;
            //tabentityValue.QuotationTabTrue = true;
           

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Quotations List");
        }
        private void ShowPurchaseQuotationView(object param)
        {
            if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "PurchaseQuotationTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PurchaseQuotationView>();

            //PurchaseTabEntity tabentity = new PurchaseTabEntity();
            //var tabentityValue = tabentity as PurchaseTabEntity;
            //tabentityValue.QuotationTabTrue = true;


            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Quotation Form");
        }
        private void PurchaseOrderListView()
        {
            SharedValues.getValue = "PurchaseOrderTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            //PurchaseTabEntity tabentity = new PurchaseTabEntity();
            //var tabentityValue = tabentity as PurchaseTabEntity;
            //tabentityValue.OrderTabTrue = true;
          
            var mainview = ServiceLocator.Current.GetInstance<PurchaseOrderListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Orders List");
        }
        private void PurchaseOrderFormView(object param)
        {
            if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "PurchaseOrderTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            //PurchaseTabEntity tabentity = new PurchaseTabEntity();
            //var tabentityValue = tabentity as PurchaseTabEntity;
            //tabentityValue.OrderTabTrue = true;

            var mainview = ServiceLocator.Current.GetInstance<PurchaseOrderView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Order Form");
        }
        private void PurchaseInvoiceListView()
        {
            SharedValues.getValue = "PurchaseInvoiceTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            //PurchaseTabEntity tabentity = new PurchaseTabEntity();
            //var tabentityValue = tabentity as PurchaseTabEntity;
            //tabentityValue.OrderTabTrue = true;

            var mainview = ServiceLocator.Current.GetInstance<PurchaseInvoiceListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoices List");
        }
        private void PurchaseInvoiceFormView(object param)
        {
            if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "PurchaseInvoiceTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            //PurchaseTabEntity tabentity = new PurchaseTabEntity();
            //var tabentityValue = tabentity as PurchaseTabEntity;
            //tabentityValue.OrderTabTrue = true;

            var mainview = ServiceLocator.Current.GetInstance<PurchaseInvoicePandSView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoice Form (Products & Services)");
        }
        private void DebitNoteListView()
        {
            SharedValues.getValue = "DebitNoteTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            PurchaseTabEntity tabentity = new PurchaseTabEntity();
            var tabentityValue = tabentity as PurchaseTabEntity;
            tabentityValue.OrderTabTrue = true;

            var mainview = ServiceLocator.Current.GetInstance<DebitNoteListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Debit Notes List");
        }
        private void DebitNoteFormView(object param)
        {
            if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "DebitNoteTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            PurchaseTabEntity tabentity = new PurchaseTabEntity();
            var tabentityValue = tabentity as PurchaseTabEntity;
            tabentityValue.OrderTabTrue = true;

            var mainview = ServiceLocator.Current.GetInstance<DebitNoteView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Debit Note Form");
        }
        private void ShowPaymentsToSuppliersListView(object sender)
        {
            SharedValues.getValue = "PaymentToSupplierTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            PurchaseTabEntity tabentity = new PurchaseTabEntity();
            var tabentityValue = tabentity as PurchaseTabEntity;
            tabentityValue.OrderTabTrue = true;

            var mainview = ServiceLocator.Current.GetInstance<PaymentsToSuppliersListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payments to Suppliers List");
        }
        private void ShowPaymentsToSuppliersFormView(object param)
        {
            if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "PaymentToSupplierTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            PurchaseTabEntity tabentity = new PurchaseTabEntity();
            var tabentityValue = tabentity as PurchaseTabEntity;
            tabentityValue.OrderTabTrue = true;

            var mainview = ServiceLocator.Current.GetInstance<PaymentToSupplierView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payment to Supplier Form");
        }

        private void ShowRefundFromsupplierFormView(object param)
        {
            if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "RefundFromSupplierTab";
         
            var tabview = ServiceLocator.Current.GetInstance<SDN.Common.View.CashAndBankTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
           
            var mainview = ServiceLocator.Current.GetInstance<RefundFromSupplierView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund From Supplier Form");
        }
        private void ShowRefundFromsuppliersListView(object param)
        {
            SharedValues.getValue = "RefundFromSupplierTab";

            var tabview = ServiceLocator.Current.GetInstance<SDN.Common.View.CashAndBankTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<RefundFromSuppliersListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund From Suppliers List");
        }

        #endregion

        private void AccountFormView()
        {
            SharedValues.getValue = "AccountFormTab";
            var tabview = ServiceLocator.Current.GetInstance<AccountTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            PurchaseTabEntity tabentity = new PurchaseTabEntity();
            var tabentityValue = tabentity as PurchaseTabEntity;
            tabentityValue.OrderTabTrue = true;

            var mainview = ServiceLocator.Current.GetInstance<AccountsDetailsView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Accounts Details Form");
        }

        #region "Products Methods"
        private void ShowProductsView()
        {
            SharedValues.getValue = "PSDetailsTab";
            var tabview = ServiceLocator.Current.GetInstance<PandSDetailsView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<ProductTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products & Services Details Form");
        }
        private void PandSSoldView()
        {
            SharedValues.getValue = "PSSoldTab";
            var tabview = ServiceLocator.Current.GetInstance<PandSSoldView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<ProductTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Sold");
        }
        private void PandSPurchaseView()
        {
            SharedValues.getValue = "PSPurchasedTab";
            var tabview = ServiceLocator.Current.GetInstance<PandSPurchaseView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<ProductTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Purchased");
        }

        private void ShowProductsDescriptionView()
        {
            SharedValues.getValue = "PSDetailsSubTab";
            var tabview = ServiceLocator.Current.GetInstance<PandSDescriptionListView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<ProductTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }


            var SubTabView = ServiceLocator.Current.GetInstance<PandSSubTabView>();
            var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

            subMenuRegion.Add(SubTabView);

            if (subMenuRegion != null)
            {
                subMenuRegion.Activate(SubTabView);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Prodcts and Services Details List - Description");
        }

        private void ShowTopPandSView()
        {
            SharedValues.getValue = "TopPSTab";
            var tabview = ServiceLocator.Current.GetInstance<TopPandSView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<ProductTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }


            var SubTabView = ServiceLocator.Current.GetInstance<PandSSubTabView>();
            var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

            subMenuRegion.Add(SubTabView);

            if (subMenuRegion != null)
            {
                subMenuRegion.Activate(SubTabView);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Top Products & Services");
        }
        
        private void ShowCountAndAdjustStockView(object param)
        {
            if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "CountandAdjustStockTab";
            var tabview = ServiceLocator.Current.GetInstance<CountAndAdjustStockView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<ProductTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Count and Adjust Stock Form");
        }
        private void ShowCountAndAdjustStockListView()
        {
            SharedValues.getValue = "CountandAdjustStockTab";
            var tabview = ServiceLocator.Current.GetInstance<CountAndAdjustStockListView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<ProductTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Count and Adjust Stock List");
        }

        #endregion

        /// <summary>
        /// Shows the manufacturing view.
        /// </summary>
        private void ShowManufacturingView()
        {
            var tabview = ServiceLocator.Current.GetInstance<ManufacturingTabView>();

            var region = this.regionManager.Regions[RegionNames.MenuBarRegion];
            region.Add(tabview);
            if (region != null)
            {
                region.Activate(tabview);
            }

            var view = ServiceLocator.Current.GetInstance<BillOfMaterialView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(view);
            if (mainregion != null)
            {
                mainregion.Activate(view);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }

        #region "Settings Methods"
        private void ShowCompanyDetailsView()
        {
            SharedValues.getValue = "CompanyDetailsTab";
            var tabview = ServiceLocator.Current.GetInstance<SettingsTabView>();

            var region = this.regionManager.Regions[RegionNames.MenuBarRegion];
            region.Add(tabview);
            if (region != null)
            {
                region.Activate(tabview);
            }

            var view = ServiceLocator.Current.GetInstance<CompanyDetailsView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(view);
            if (mainregion != null)
            {
                mainregion.Activate(view);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Company Details");

        }
        private void ShowCategoriesView()
        {
            SharedValues.getValue = "CategoryTab";
            var tabview = ServiceLocator.Current.GetInstance<SettingsTabView>();

            var region = this.regionManager.Regions[RegionNames.MenuBarRegion];
            region.Add(tabview);
            if (region != null)
            {
                region.Activate(tabview);
            }

            var view = ServiceLocator.Current.GetInstance<CategoryView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(view);
            if (mainregion != null)
            {
                mainregion.Activate(view);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Categories");

        }
        private void ShowOptionsView()
        {
            SharedValues.getValue = "OptionsTab";
            var tabview = ServiceLocator.Current.GetInstance<SettingsTabView>();

            var region = this.regionManager.Regions[RegionNames.MenuBarRegion];
            region.Add(tabview);
            if (region != null)
            {
                region.Activate(tabview);
            }

            var view = ServiceLocator.Current.GetInstance<OptionsView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(view);
            if (mainregion != null)
            {
                mainregion.Activate(view);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Options");

        }
        private void ShowTaxCodesAndRatesView()
        {
            SharedValues.getValue = "CodesandRatesTab";
            var tabview = ServiceLocator.Current.GetInstance<SettingsTabView>();

            var region = this.regionManager.Regions[RegionNames.MenuBarRegion];
            region.Add(tabview);
            if (region != null)
            {
                region.Activate(tabview);
            }

            var view = ServiceLocator.Current.GetInstance<TaxCodesAndRatesView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(view);
            if (mainregion != null)
            {
                mainregion.Activate(view);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("GST/VAT Codes and Rates");

        }
        private void ShowUsersSecurityView()
        {
            SharedValues.getValue = "UsersandSecurityTab";
            var tabview = ServiceLocator.Current.GetInstance<SettingsTabView>();

            var region = this.regionManager.Regions[RegionNames.MenuBarRegion];
            region.Add(tabview);
            if (region != null)
            {
                region.Activate(tabview);
            }

            var view = ServiceLocator.Current.GetInstance<UsersSecurityView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(view);
            if (mainregion != null)
            {
                mainregion.Activate(view);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Users and Security");

        }
        #endregion

        private void ShowCashBankView(object sender)
        {
            var mainview = ServiceLocator.Current.GetInstance<CashBankDetailView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Cash & Bank Details");
        }

        #region "Suppliers Click methods"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        private void ShowSuppliersViews(object sender)
        {
            SharedValues.getValue = "SupplierDetailTab";
            var mainview = ServiceLocator.Current.GetInstance<SupplierDetailView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<SupplierTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details Form");
        }
        private void SuppliersHistoryViews(object sender)
        {
            SharedValues.getValue = "SupplierHistoryTab";
            var mainview = ServiceLocator.Current.GetInstance<SupplierHistoryView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<SupplierTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers History");
        }

        private void ShowTopSuppliersViews(object sender)
        {
            SharedValues.getValue = "TopSuppliersTab";
            var mainview = ServiceLocator.Current.GetInstance<TopSuppliersView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<SupplierTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Top Suppliers");
        }
        #endregion
        
        #endregion
    }
}
