﻿
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SASClient.Accounts.Views;
using SASClient.CashBank.Views;
using SASClient.CloseRequest;
using SASClient.Customers.Views;
using SASClient.File.Views;
using SASClient.HomeScreen.Views;
using SASClient.Product.View;
using SASClient.Purchasing.View;
using SDN.CashBank.Views;

using SDN.Common;
using SDN.Customers.Views;
using SDN.Navigation.View;
using SDN.Product.View;
using SDN.Purchasing.Services;
using SDN.Purchasing.View;
using SDN.Sales.Views;
using SDN.Settings.Views;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace SDN.Navigation.ViewModel
{

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
        private ObservableCollection<string> _reportitem;
        public event PropertyChangedEventHandler PropertyChanged;
        LoginUserViewModel loginuser;
        private string _screenName;
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
        private string _SelectedReportItem;

        /// <summary>
        /// The Purchasing click commandScreenName
        /// </summary>
        #region public properties
        public string SelectedReportItem
        {
            get
            {
                return _SelectedReportItem;
            }
            set
            {
                _SelectedReportItem = value;
                OnPropertyChanged("SelectedReportItem");
            }
        }
        public ObservableCollection<string> ReportItem
        {
            get
            {
                return _reportitem;
            }
            set
            {
                _reportitem = value;
                OnPropertyChanged("ReportItem");
            }
        }
        public string ScreenName
        {
            get
            {
                return _screenName;
            }
            set
            {
                _screenName = value;
                OnPropertyChanged("ScreenName");
            }
        }

        #endregion

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
        private readonly DelegateCommand pandSHistoryClickCommand = null;

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
        #region "ExportData Click command"
        /// <summary>
        /// The Settings click command
        /// </summary>
        private readonly DelegateCommand openCompanyFileCommand = null;
        private readonly DelegateCommand exportDataCommand = null;
        private readonly DelegateCommand importDataCommand = null;
        private readonly DelegateCommand backupDataCommand = null;
        private readonly DelegateCommand restoreDataCommand = null;

        #endregion


        #region "Stock click command"
        private readonly DelegateCommand stockInAndOut = null;
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
        private readonly DelegateCommand<object> payMoneyCommand = null;

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
        private DelegateCommand<object> purchasedFromSupplierClickCommand = null;

        #endregion

        #region "Customers Click Command"
        /// <summary>
        /// The Customers click command
        /// </summary>
        private readonly DelegateCommand<object> customersClickCommand = null;
        private readonly DelegateCommand<object> customersHistoryClickCommand = null;
        private readonly DelegateCommand<object> topCustomersClickCommand = null;
        private readonly DelegateCommand<object> customersDetailsClickCommand = null;
        #endregion

        #region "Suppliers Click Command"
        /// <summary>
        /// The Suppliers click command
        /// </summary>
        private readonly DelegateCommand<object> suppliersClickCommand = null;
        private readonly DelegateCommand<object> suppliersHistoryClickCommand = null;
        private readonly DelegateCommand<object> topSuppliersClickCommand = null;
        private readonly DelegateCommand<object> suppliersStatementUnPaidInvoicesClickCommand = null;
        private readonly DelegateCommand<object> customersStatementUnPaidInvoicesClickCommand = null;
        private readonly DelegateCommand<object> suppliersDetailsListClickCommand = null;
        #endregion

        #region "Accounts Click command"
        private DelegateCommand accountFormClickCommand = null;
        private DelegateCommand accountTrialBalanceClickCommand = null;
        private DelegateCommand gstAndVatClickCommand = null;
        private DelegateCommand accountsTransactionClickCommand = null;
        private readonly DelegateCommand<object> accountsHistoryClickCommand = null;
        private DelegateCommand<object> journalFormClickCommand = null;
        //private DelegateCommand profitAndLossStatementClickCommand = null;
        private DelegateCommand journalListClickCommand = null;
        private DelegateCommand ledgerClickCommand = null;
        private readonly DelegateCommand<object> accountsDetailsClickCommand = null;
        private DelegateCommand balanceSheetClickCommand = null;
        #endregion

        #region "Cash And Bank Click Command"
        private DelegateCommand receiveMoneyFormClickCommand = null;
        private DelegateCommand transferMoneyFormClickCommand = null;

        private DelegateCommand receiveMoneyListClickCommand = null;
        private DelegateCommand payMoneyListClickCommand = null;
        private DelegateCommand transferMoneyListClickCommand = null;
        private DelegateCommand cashBankStatementCommand = null;

        #endregion
        #region "Home Screen Click Command"
        private DelegateCommand<object> notificationClickCommand = null;
        private DelegateCommand<object> auditTrailClickCommand = null;
        private DelegateCommand<object> todoListClickCommand = null;


        #endregion

        #endregion

        #region Public Properties

        #region "Settings Click"

        /// <summary>
        /// Settings Click Command
        /// </summary>

        StackList listitem = new StackList();
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
                return (this.pandSDescriptionClickCommand ?? new DelegateCommand(this.ShowProductsDescriptionView));
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

        public DelegateCommand PandSHistoryClickCommand
        {
            get
            {
                return (this.pandSHistoryClickCommand ?? new DelegateCommand(this.ShowPandSHistoryView));
            }
        }


        #endregion
        #region "File Click"
        /// <summary>
        /// Gets the products click command.
        /// </summary>
        /// <value>
        /// The products click command.
        /// </value>
        public DelegateCommand ExportDataCommand
        {
            get
            {
                return (this.exportDataCommand ?? new DelegateCommand(this.ExportDataView));
            }
        }
        public DelegateCommand OpenCompanyFileCommand
        {
            get
            {
                return (this.openCompanyFileCommand ?? new DelegateCommand(this.OpenCompanyFileView));
            }
        }
        public DelegateCommand ImportDataCommand
        {
            get
            {
                return (this.importDataCommand ?? new DelegateCommand(this.ImportDataView));
            }
        }

        public DelegateCommand BackupDataCommand
        {
            get
            {
                return (this.backupDataCommand ?? new DelegateCommand(this.BackupDataView));
            }
        }
        public DelegateCommand RestoreDataCommand
        {
            get
            {
                return (this.restoreDataCommand ?? new DelegateCommand(this.RestoreDataView));
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

        #region "stock click command region"
        public DelegateCommand StockInAndOut
        {
            get
            {
                return (this.stockInAndOut ?? new DelegateCommand(this.StockInAndOutView));
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
        public DelegateCommand<object> AccountsDetailsClickCommand
        {
            get
            {
                return (this.accountsDetailsClickCommand ?? new DelegateCommand<object>(this.ShowAccountsDetailsListView));
            }
        }
        public DelegateCommand<object> AccountsHistoryClickCommand
        {
            get
            {
                return (this.accountsHistoryClickCommand ?? new DelegateCommand<object>(this.ShowAccountsHistoryListView));
            }
        }
        #endregion
        #region "TrailBalance"
        public DelegateCommand AccountTrialBalanceClickCommand
        {
            get
            {
                return (this.accountTrialBalanceClickCommand ?? new DelegateCommand(this.TrailBalanceView));
            }
        }
        public DelegateCommand GstAndVatClickCommand
        {
            get
            {
                return (this.gstAndVatClickCommand ?? new DelegateCommand(this.GstAndVatView));
            }
        }
        public DelegateCommand AccountsTransactionClickCommand
        {
            get
            {
                return (this.accountsTransactionClickCommand ?? new DelegateCommand(this.AccountsTransactionHomeView));
            }
        }
        
        public DelegateCommand <object> JournalFormClickCommand
        {
            get
            {
                return (this.journalFormClickCommand ?? new DelegateCommand<object>(this.JournalView));
            }
        }
        public DelegateCommand JournalListClickCommand
        {
            get
            {
                return (this.journalListClickCommand ?? new DelegateCommand(this.JournalListView));
            }
        }
        public DelegateCommand LedgerClickCommand
        {
            get
            {
                return (this.ledgerClickCommand ?? new DelegateCommand(this.LedgerView));
            }
        }
        public DelegateCommand BalanceSheetClickCommand
        {
            get
            {
                return (this.balanceSheetClickCommand ?? new DelegateCommand(this.BalanceSheetView));
            }
        }
        #endregion

        #region "Cash And Bank Click "
        public DelegateCommand<object> CashBankCommand
        {
            get
            {
                return (this.cashBankCommand ?? new DelegateCommand<object>(this.ShowCashBankView));
            }
        }
        public DelegateCommand CashAndBankClickCommand
        {
            get
            {
                return (this.cashBankStatementCommand ?? new DelegateCommand(this.CashBankStatementView));
            }
        }
        public DelegateCommand ReceiveMoneyFormClickCommand
        {
            get
            {
                return (this.receiveMoneyFormClickCommand ?? new DelegateCommand(this.ShowReceiveMoneyForm));
            }
        }
        public DelegateCommand TransferMoneyFormClickCommand
        {
            get
            {
                return (this.transferMoneyFormClickCommand ?? new DelegateCommand(this.ShowTransferMoneyForm));
            }
        }
        public DelegateCommand ReceiveMoneyListClickCommand
        {
            get
            {
                return (this.receiveMoneyListClickCommand ?? new DelegateCommand(this.ReceiveMoneyListView));
            }
        }
        public DelegateCommand PayMoneyListClickCommand
        {
            get
            {
                return (this.payMoneyListClickCommand ?? new DelegateCommand(this.PayMoneyListView));
            }
        }
        public DelegateCommand TransferMoneyListClickCommand 
        {
            get
            {
                return (this.transferMoneyListClickCommand  ?? new DelegateCommand(this.TransferMoneyListView ));
            }
        }

        #endregion
        #region Home Screen Click "
        public DelegateCommand<object> NotificationClickCommand
        {
            get
            {
                return (this.notificationClickCommand ?? new DelegateCommand<object>(this.NotificationView));
            }
        }

        public DelegateCommand<object> AuditTrailClickCommand 
        {
            get
            {
                return (this.auditTrailClickCommand ?? new DelegateCommand<object>(this.AuditTrailView));
            }
        }
        public DelegateCommand<object> TodoListClickCommand
        {
            get
            {
                return (this.todoListClickCommand ?? new DelegateCommand<object>(this.TodoListView));
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
        public DelegateCommand<object> SettingsClickCommand
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
        public DelegateCommand<object> CustomersDetailsClickCommand
        {
            get
            {
                return (this.customersDetailsClickCommand ?? new DelegateCommand<object>(this.ShowCustomersDetailsListView));
            }
        }
        
        public DelegateCommand<object> PurchasedFromSupplierClickCommand
        {
            get
            {
                return (this.purchasedFromSupplierClickCommand ?? new DelegateCommand<object>(this.PurchasedFromSupplierView));
            }
        }

        #endregion

      
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
        public DelegateCommand<object> SuppliersStatementUnPaidInvoicesClickCommand
        {
            get
            {
                return (this.suppliersStatementUnPaidInvoicesClickCommand ?? new DelegateCommand<object>(this.ShowSuppliersStatementUnPaidInvoicesView));
            }
        }
        public DelegateCommand<object> CustomersStatementUnPaidInvoicesClickCommand
        {
            get
            {
                return (this.customersStatementUnPaidInvoicesClickCommand ?? new DelegateCommand<object>(this.ShowCustomersStatementUnPaidInvoicesView));
            }
        }
        public DelegateCommand<object> SuppliersDetailsListClickCommand
        {
            get
            {
                return (this.suppliersDetailsListClickCommand ?? new DelegateCommand<object>(this.ShowSuppliersDetailsListView));
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
        public DelegateCommand<object> PayMoneyCommand
        {
            get
            {
                return (this.payMoneyCommand ?? new DelegateCommand<object>(this.PayMoneyView));
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
            eventAggregator.GetEvent<HeaderVisibilityChangeEvent>().Publish(true);
            eventAggregator.GetEvent<FooterVisibilityChangeEvent>().Publish(true);
            eventAggregator.GetEvent<BlankHeaderVisibilityChangeEvent>().Publish(false);
            loadOptionsData();
            reportlist();
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
            SharedValues.ScreenCheckName = "Sales Quotation";
            SharedValues.ViewName = "Sales Quotation List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
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
            SharedValues.ScreenCheckName = "Customers Details";
            SharedValues.ViewName = "Customers Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowCustomersDetailsListView(object sender)
        {
            SharedValues.ScreenCheckName = "Customers Details";
            SharedValues.ViewName = "Customers Details List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (sender != null)
            {
                SharedValues.getValue = "CustomersDetailsListTab";
                var view = ServiceLocator.Current.GetInstance<CustomersDetailsList1View>();
                var region = this.regionManager.Regions[RegionNames.MainRegion];
                region.Add(view);
                if (region != null)
                {
                    region.Activate(view);
                }

                var view2 = ServiceLocator.Current.GetInstance<CustomersTabView>();

                IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                region2.Add(view2);
                if (region2 != null)
                {
                    region2.Activate(view2);
                }

                var SubTabView = ServiceLocator.Current.GetInstance<CustomersDetailsSubTabView>();
                var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

                subMenuRegion.Add(SubTabView);

                if (subMenuRegion != null)
                {
                    subMenuRegion.Activate(SubTabView);
                }

            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        

        private void CustomersHistoryViews(object sender)
        {
            SharedValues.ScreenCheckName = "Customers History";
            SharedValues.ViewName = "Customers History";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowTopCustomersView(object sender)
        {
            SharedValues.ScreenCheckName = "Top Customers";
            SharedValues.ViewName = "Top Customers";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void PurchasedFromSupplierView(object sender)
        {
            SharedValues.ScreenCheckName = "P & S Purchased";
            SharedValues.ViewName = "Products and Services Purchased From Supplier";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PandSPurchasedFromSupplier";
            var tabview = ServiceLocator.Current.GetInstance<SupplierTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PandSPurchasedFromSuppliersView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Purchased From Supplier");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        #endregion

        #region "Sales Click Methods"
        private void ShowSalesQuotationsListView(object sender)
        {
            SharedValues.ScreenCheckName = "Sales Quotation";
            SharedValues.ViewName = "Sales Quotation List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }

    }

        private void ShowSalesOrdersListView(object sender)
        {
            SharedValues.ScreenCheckName = "Sales Order";
            SharedValues.ViewName = "Sales Order List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }


        }

        private void ShowSalesInvoiceListView(object sender)
        {
            SharedValues.ScreenCheckName = "Sales Invoice";
            SharedValues.ViewName = "Sales Invoice List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoices List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }

        }

        private void ShowCreditNoteListView(object param)
        {
            SharedValues.ScreenCheckName = "Credit Note";
            SharedValues.ViewName = "Credit Note List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }

        }

        private void ShowPaymentsFromCustomersListView(object param)
        {
            SharedValues.ScreenCheckName = "Payment from Customer";
            SharedValues.ViewName = "Payment From Customers List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        private void ShowSalesQuotationsFormView(object sender)
        {
            SharedValues.ScreenCheckName = "Sales Quotation";
            SharedValues.ViewName = "Sales Quotation";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowSalesOrdersFormView(object sender)
        {
            SharedValues.ScreenCheckName = "Sales Order";
            SharedValues.ViewName = "Sales Order";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
}
        private void ShowSalesInvoiceFormView(object sender)
        {
            SharedValues.ScreenCheckName = "Sales Invoice";
            SharedValues.ViewName = "Sales Invoice";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowCreditNoteFormView(object param)
        {
            SharedValues.ScreenCheckName = "Credit Note";
            SharedValues.ViewName = "Credit Note";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowPaymentsFromCustomersFormView(object param)
        {
            SharedValues.ScreenCheckName = "Payment from Customer";
            SharedValues.ViewName = "Payment from Customer";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowRefundToCustomerFormView(object param)
        {
            SharedValues.ScreenCheckName = "Refund To Customer";
            SharedValues.ViewName = "Refund To Customer";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            
            SharedValues.getValue = "RefundToCustomerTab";

            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowRefundToCustomersListView(object param)
        {
            SharedValues.ScreenCheckName = "Refund To Customer";
            SharedValues.ViewName = "Refund To Customers List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "RefundToCustomerTab";
           
            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void PayMoneyView(object param)
        {
            SharedValues.ScreenCheckName = "Pay Money";
            SharedValues.ViewName = "Pay Money";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PayMoneyTab";
            SharedValues.NewClick = "New";

            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PayMoneyView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Pay Money");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
      
        private void pandSSoldToCustomerView(object param)
        {
            SharedValues.ScreenCheckName = "P & S Sold";
            SharedValues.ViewName = "Products and Services Sold to Customers";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        #endregion

        #region "Purchase click methods"

        /// <summary>
        /// Shows the purchase view.
        /// </summary>
        private void ShowPurchaseView()
        {
            SharedValues.ScreenCheckName = "Purchase Quotation";
            SharedValues.ViewName = "Purchase Quotation List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowPurchaseView1()
        {
            SharedValues.ScreenCheckName = "Purchase Quotation";
            SharedValues.ViewName = "Purchase Quotation List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowPurchaseQuotationView(object param)
        {
            SharedValues.ScreenCheckName = "Purchase Quotation";
            SharedValues.ViewName = "Purchase Quotation";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void PurchaseOrderListView()
        {
            SharedValues.ScreenCheckName = "Purchase Order";
            SharedValues.ViewName = "Purchase Order List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void PurchaseOrderFormView(object param)
        {
            SharedValues.ScreenCheckName = "Purchase Order";
            SharedValues.ViewName = "Purchase Order";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void PurchaseInvoiceListView()
        {
            SharedValues.ScreenCheckName = "Purchases Invoice (P & S)";
            SharedValues.ViewName = "Purchase Invoice (Products & Services) List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void PurchaseInvoiceFormView(object param)
        {
            SharedValues.ScreenCheckName = "Purchases Invoice (P & S)";
            SharedValues.ViewName = "Purchase Invoice (Products & Services)";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void DebitNoteListView()
        {
            SharedValues.ScreenCheckName = "Debit Note";
            SharedValues.ViewName = "Debit Note List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void DebitNoteFormView(object param)
        {
            SharedValues.ScreenCheckName = "Debit Note";
            SharedValues.ViewName = "Debit Note";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowPaymentsToSuppliersListView(object sender)
        {
            SharedValues.ScreenCheckName = "Payment to Suplier";
            SharedValues.ViewName = "Payments To Suppliers List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowPaymentsToSuppliersFormView(object param)
        {
            SharedValues.ScreenCheckName = "Payment to Suplier";
            SharedValues.ViewName = "Payment to Supplier";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        private void ShowRefundFromsupplierFormView(object param)
        {
            SharedValues.ScreenCheckName = "Refund to Supplier";
            SharedValues.ViewName = "Refund From Supplier";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "RefundFromSupplierTab";

            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
       
        private void ShowAccountsDetailsListView(object sender)
        {
            SharedValues.ScreenCheckName = "Accounts Details";
            SharedValues.ViewName = "Accounts Details List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (sender != null)
            {
                SharedValues.getValue = "AccountsDetailsTab";
                var view = ServiceLocator.Current.GetInstance<AccountsDetailsListView>();
                var region = this.regionManager.Regions[RegionNames.MainRegion];
                region.Add(view);
                if (region != null)
                {
                    region.Activate(view);
                }

                var tabview = ServiceLocator.Current.GetInstance<SASClient.Accounts.Views.AccountsTabView>();
                var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                tabregion.Add(tabview);
                if (tabregion != null)
                {
                    tabregion.Activate(tabview);
                }
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Accounts Details List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowAccountsHistoryListView(object sender)
        {
            SharedValues.ScreenCheckName = "Profit & Loss Statement";
            SharedValues.ViewName = "Profit & Loss Statement";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (sender != null)
            {
                SharedValues.getValue = "ProfitAndLosStatementTab";
                var view = ServiceLocator.Current.GetInstance<AccountHistoryView>();
                var region = this.regionManager.Regions[RegionNames.MainRegion];
                region.Add(view);
                if (region != null)
                {
                    region.Activate(view);
                }

                var tabview = ServiceLocator.Current.GetInstance<SASClient.Accounts.Views.AccountsTabView>();
                var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                tabregion.Add(tabview);
                if (tabregion != null)
                {
                    tabregion.Activate(tabview);
                }
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Profit & Loss Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        private void AccountsTransactionHomeView()
        {
            SharedValues.ScreenCheckName = "Accounts Transactions";
            SharedValues.ViewName = "Accounts Transactions";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "AccountsTransactionsTab";

            var view = ServiceLocator.Current.GetInstance<AccountsTransactionsView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }

            var view2 = ServiceLocator.Current.GetInstance<AccountsTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }

         
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Accounts Transactions");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowRefundFromsuppliersListView(object param)
        {
            SharedValues.ScreenCheckName = "Refund to Supplier";
            SharedValues.ViewName = "Refund to Supplier List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "RefundFromSupplierTab";
           
            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        private void StockInAndOutView()
        {
            SharedValues.ScreenCheckName = "Stock in/out card";
            SharedValues.ViewName = "Stock in/out card";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "StockInOutCardTab";

            var tabview = ServiceLocator.Current.GetInstance<ProductTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PandSStockCardView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Stock In/Out Card");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        #endregion

        #region "Cash And Bank Click methods"
        private void ShowReceiveMoneyForm()
        {
            SharedValues.ScreenCheckName = "Recieve Money";
            SharedValues.ViewName = "Receive Money";
            var accessitem = listitem.AddToList();
           if (accessitem == true)
           {
            SharedValues.NewClick = "New";
            SharedValues.getValue = "ReceiveMoneyTab";
            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<ReceiveMoneyView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
           
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Receive Money Form");
                        }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowTransferMoneyForm()
        {
            SharedValues.ScreenCheckName = "Transfer Money";
            SharedValues.ViewName = "Transfer Money";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.NewClick = "New";
            SharedValues.getValue = "TransferMoneyTab";
           
            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<TransferMoneyView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Transfer Money Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ReceiveMoneyListView()
        {
            //SharedValues.NewClick = "New";
            SharedValues.ScreenCheckName = "Recieve Money";
            SharedValues.ViewName = "Receive Money List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "ReceiveMoneyTab";
            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<ReceiveMoneyListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Receive Money List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void PayMoneyListView()
        {
            //SharedValues.NewClick = "New";
            SharedValues.ScreenCheckName = "Pay Money";
            SharedValues.ViewName = "Pay Money List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PayMoneyTab";
            
            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PayMoneyListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Pay Money List");
           
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void TransferMoneyListView ()
        {
            //SharedValues.NewClick = "New";
            SharedValues.ScreenCheckName = "Transfer Money";
            SharedValues.ViewName = "Transfer Money List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "TransferMoneyTab";
            
            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<TransferMoneyListView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Transfer Money List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        #endregion

        private void TrailBalanceView()
        {
            SharedValues.ScreenCheckName = "Trail Balance";
            SharedValues.ViewName = "Trail Balance";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "TrailBalanceTab";
                var mainview = ServiceLocator.Current.GetInstance<TrailBalanceView>();
                var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                mainregion.Add(mainview);
                if (mainregion != null)
                {
                    mainregion.Activate(mainview);
                }


                var tabview = ServiceLocator.Current.GetInstance<AccountsTabView>();
                var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                tabregion.Add(tabview);
                if (tabregion != null)
                {
                    tabregion.Activate(tabview);
                }

                eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                eventAggregator.GetEvent<TitleChangedEvent>().Publish("Trial Balance");
                //SharedValues.NewClick = "New";    

            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }

        }
        public void  BalanceSheetView()
        {
            SharedValues.ScreenCheckName = "Balance Sheet";
            SharedValues.ViewName = "Balance Sheet";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "BalanceSheetTab";
            var mainview = ServiceLocator.Current.GetInstance<BalanceSheetView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<AccountsTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Balance Sheet");
                //SharedValues.NewClick = "New";    
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void JournalView(object param)
        {
            SharedValues.ScreenCheckName = "Journal";
            SharedValues.ViewName = "Journal";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (param != null)
            {
                SharedValues.NewClick = param.ToString();
            }
            SharedValues.getValue = "JournalTab";
            var mainview = ServiceLocator.Current.GetInstance<JournalView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<AccountsTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Journal  Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        public void JournalListView()
        {
            SharedValues.ScreenCheckName = "Journal";
            SharedValues.ViewName = "Journal List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "JournalTab";
            var mainview = ServiceLocator.Current.GetInstance<JournalListView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<AccountsTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Journals  List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        public void LedgerView()
        {
            SharedValues.ScreenCheckName = "Ledger";
            SharedValues.ViewName = "Ledger";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "LedgerTab";
            var mainview = ServiceLocator.Current.GetInstance<LedgerView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<AccountsTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Ledger");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        public void GstAndVatView()
        {
            SharedValues.ScreenCheckName = "GST Reports";
            SharedValues.ViewName = "GST Reports";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "GSTAndVatTab";
            //SharedValues.NewClick = "New";
            var tabview = ServiceLocator.Current.GetInstance<AccountsTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            PurchaseTabEntity tabentity = new PurchaseTabEntity();
            var tabentityValue = tabentity as PurchaseTabEntity;
            tabentityValue.OrderTabTrue = true;

            var mainview = ServiceLocator.Current.GetInstance<GstAndVatSummaryView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            var SubTabView = ServiceLocator.Current.GetInstance<GstAndVatSubTab>();
            var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

            subMenuRegion.Add(SubTabView);

            if (subMenuRegion != null)
            {
                subMenuRegion.Activate(SubTabView);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish(" GST / VAT Reports");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void AccountFormView()
        {
            SharedValues.ScreenCheckName = "Accounts Details";
            SharedValues.ViewName = "Accounts Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "AccountsDetailsTab";
            SharedValues.NewClick = "New";
            var tabview = ServiceLocator.Current.GetInstance<AccountsTabView>();

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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }

        }

        #region "Products Methods"
        private void ShowProductsView()
        {
            SharedValues.ScreenCheckName = "P & S Details";
            SharedValues.ViewName = "Products & Services Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ExportDataView()
        {
            SharedValues.ScreenCheckName = "Export Data";
            SharedValues.ViewName = "Export Data";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "ExportDataTab";
                var tabview = ServiceLocator.Current.GetInstance<ExportDataView>();

                var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
                tabregion.Add(tabview);
                if (tabregion != null)
                {
                    tabregion.Activate(tabview);
                }

                var view2 = ServiceLocator.Current.GetInstance<FileTabView>();

                IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                region2.Add(view2);
                if (region2 != null)
                {
                    region2.Activate(view2);
                }
                var SubTabView = ServiceLocator.Current.GetInstance<FileSubTabView>();
                var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

                subMenuRegion.Add(SubTabView);

                if (subMenuRegion != null)
                {
                    subMenuRegion.Activate(SubTabView);
                }

                eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                eventAggregator.GetEvent<TitleChangedEvent>().Publish("Export Data");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }

        }
        private void OpenCompanyFileView()
        {

            //SharedValues.ViewName = "OpenCompanyFile";
               // SharedValues.getValue = "ExportDataTab";
                var tabview = ServiceLocator.Current.GetInstance<OpenCompanyFileView>();

                var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
                tabregion.Add(tabview);
                if (tabregion != null)
                {
                    tabregion.Activate(tabview);
                }
        }
        private void ImportDataView()
        {
            SharedValues.ScreenCheckName = "Import Data";
            SharedValues.ViewName = "Import Data";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
            SharedValues.getValue = "ImportDataTab";
            var tabview = ServiceLocator.Current.GetInstance<ImportDataView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<FileTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            var SubTabView = ServiceLocator.Current.GetInstance<FileSubTabView>();
            var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

            subMenuRegion.Add(SubTabView);

            if (subMenuRegion != null)
            {
                subMenuRegion.Activate(SubTabView);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Import Data");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        private void BackupDataView()
        {
            SharedValues.ScreenCheckName = "Backup Data";
            SharedValues.ViewName = "Backup Data";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
            SharedValues.getValue = "BackupDataTab";
            var tabview = ServiceLocator.Current.GetInstance<BackupDataView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<FileTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Backup Data");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void RestoreDataView()
        {
            SharedValues.ScreenCheckName = "Restore Data";
            SharedValues.ViewName = "Restore Data";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "RestoreDataTab";
            var tabview = ServiceLocator.Current.GetInstance<RestoreDataView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<FileTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Restore Data");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void PandSSoldView()
        {
            SharedValues.ScreenCheckName = "P & S Sold";
            SharedValues.ViewName = "P & S Sold";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("P & S Sold");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void PandSPurchaseView()
        {
            SharedValues.ScreenCheckName = "P & S Purchased";
            SharedValues.ViewName = "P & S Purchased";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("P & S Purchased");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        private void ShowProductsDescriptionView()
        {
            SharedValues.ScreenCheckName = "P & S Details List";
            SharedValues.ViewName = "P&S Details (Description) List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PSDetailsTab";
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products & Services  Details List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowPandSHistoryView()
        {
            SharedValues.ScreenCheckName = "P&S History";
            SharedValues.ViewName = "P&S History";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PSHistoryTab";
            var tabview = ServiceLocator.Current.GetInstance<PandSHistoryView>();

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
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("P & S History");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        

        private void ShowTopPandSView()
        {
            SharedValues.ScreenCheckName = "Top Products & Services";
            SharedValues.ViewName = "Top Products & Services";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Top P & S");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        private void ShowCountAndAdjustStockView(object param)
        {
            SharedValues.ScreenCheckName = "Count & Adjust Stock";
            SharedValues.ViewName = "Count & Adjust Stock";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
          //  eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Count and Adjust Stock Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowCountAndAdjustStockListView()
        {
            SharedValues.ScreenCheckName = "Count & Adjust Stock";
            SharedValues.ViewName = "Count And Adjust Stock List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
           // eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Count and Adjust Stock List");
                      }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        #endregion
        
        #region "Settings Methods"
        private void ShowCompanyDetailsView()
        {
           SharedValues.ScreenCheckName = "Company Details";
           SharedValues.ViewName = "Company Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }

        }
        private void ShowCategoriesView()
        {
            SharedValues.ScreenCheckName = "Categories";
            SharedValues.ViewName = "Categories";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }

        }
        private void ShowOptionsView()
        {
            SharedValues.ScreenCheckName = "Options";
                SharedValues.ViewName = "Options";
                var accessitem = listitem.AddToList();
                if (accessitem == true)
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
          
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }

        }
        private void ShowTaxCodesAndRatesView()
        {
            SharedValues.ScreenCheckName = "GST/VAT Codes & Rates";
            SharedValues.ViewName = "GST/VAT Codes and Rates";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }

        }
        private void ShowUsersSecurityView()
        {
            SharedValues.ScreenCheckName = "Users & Security";
            SharedValues.ViewName = "Users and Security";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
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
        private void CashBankStatementView()
        {
            SharedValues.ScreenCheckName = "Cash & Bank Statement";
            SharedValues.ViewName = "Cash & Bank Statement";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "CashBankStatementTab";
            var mainview = ServiceLocator.Current.GetInstance<CashBankStatement>();
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Cash & Bank Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void NotificationView(object sender)
        {
            SharedValues.ScreenCheckName = "Notifications";
            SharedValues.ViewName = "Notifications";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "NotificationTab";
            var mainview = ServiceLocator.Current.GetInstance<NotificationsView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<HomeScreenTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Notifications");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        private void AuditTrailView(object sender)
        {
            SharedValues.ScreenCheckName = "Audit Trail";
            SharedValues.ViewName = "Audit Trail";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "AuditTrailTabTrue";
            var mainview = ServiceLocator.Current.GetInstance<AuditTrailView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<HomeScreenTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Audit Trail");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void TodoListView(object sender)
        {
            SharedValues.ScreenCheckName = "To Do List";
            SharedValues.ViewName = "To Do List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "TodoListTabTrue";
            var mainview = ServiceLocator.Current.GetInstance<ToDoUnpaidDetailView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<HomeScreenTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("To Do List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        #region "Suppliers Click methods"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        private void ShowSuppliersViews(object sender)
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Suppliers Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        private void ShowSuppliersDetailsListView(object sender)
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Suppliers Details List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (sender != null)
            {
                
                SharedValues.getValue = "SuppliersDetailsListTab";
                var view = ServiceLocator.Current.GetInstance<SuppliersDetailsList1View>();
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

                var SubTabView = ServiceLocator.Current.GetInstance<SuppliersDetailsSubTabView>();
                var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

                subMenuRegion.Add(SubTabView);

                if (subMenuRegion != null)
                {
                    subMenuRegion.Activate(SubTabView);
                }

            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void SuppliersHistoryViews(object sender)
        {
            SharedValues.ScreenCheckName = "Suppliers History";
            SharedValues.ViewName = "Suppliers History";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        private void ShowTopSuppliersViews(object sender)
        {
            SharedValues.ScreenCheckName = "Top Suppliers";
            SharedValues.ViewName = "Top Suppliers";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        private void ShowSuppliersStatementUnPaidInvoicesView(object sender)
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

            var SubTabView = ServiceLocator.Current.GetInstance<SASClient.Purchasing.View.StatementSubTabView>();
            var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

            subMenuRegion.Add(SubTabView);

            if (subMenuRegion != null)
            {
                subMenuRegion.Activate(SubTabView);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        private void ShowCustomersStatementUnPaidInvoicesView(object sender)
        {
            SharedValues.ScreenCheckName = "Customers Statement";
            SharedValues.ViewName = "Customers Unpaid Invoices";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "CustomerStatementTab";

            var view = ServiceLocator.Current.GetInstance<CustomersUnPaidInvoicesView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }

            var view2 = ServiceLocator.Current.GetInstance<CustomersTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }

            var SubTabView = ServiceLocator.Current.GetInstance<SASClient.Customers.Views.StatementSubTabView>();
            var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

            subMenuRegion.Add(SubTabView);

            if (subMenuRegion != null)
            {
                subMenuRegion.Activate(SubTabView);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        public void reportlist()
        {
            try
            {
                List<string> reportlst = new List<string>();

                reportlst.Add("Customers Details");
                reportlst.Add("Customers History");
                reportlst.Add("Customers Statement");
                reportlst.Add("P&S Sold to Customers");
                reportlst.Add("Top Customers");
                reportlst.Add("Suppliers Details");
                reportlst.Add("Suppliers History");
                reportlst.Add("Suppliers Statement");
                reportlst.Add("P&S Purchased from Suppliers");
                reportlst.Add("Top Suppliers");
                reportlst.Add("P&S Details");
                reportlst.Add("P&S History");
                reportlst.Add("Stock in/out card");
                reportlst.Add("P & S Sold");
                reportlst.Add("P & S Purchased");
                reportlst.Add("Top Products & Services");
                reportlst.Add("Cash & Bank Statement");
                reportlst.Add("Accounts Details");
                reportlst.Add("Accounts Transactions");
                reportlst.Add("Ledger");
                reportlst.Add("Trial Balance");
                reportlst.Add("Profit & Loss Statement");
                reportlst.Add("Balance Sheet");
                reportlst.Add("GST/VAT Reports");
                reportlst.Add("Notifications");
                reportlst.Add("To Do List");
                reportlst.Add("Audit Trail");
                if (reportlst.Count > 0)
                {
                    ReportItem = new ObservableCollection<string>(reportlst);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        protected override void OnPropertyChanged(string name)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(name));
            }
            switch (name)
            {
                case "SelectedReportItem":

                    if (SelectedReportItem == "Customers Details")
                        ShowCustomersDetailsListView(SelectedReportItem);
                    if (SelectedReportItem == "Customers History")
                        CustomersHistoryViews(SelectedReportItem);
                    else if (SelectedReportItem == "Customers Statement")
                        ShowCustomersStatementUnPaidInvoicesView(SelectedReportItem);
                    else if (SelectedReportItem == "P&S Sold to Customers")
                        pandSSoldToCustomerView(SelectedReportItem);
                    else if (SelectedReportItem == "Top Customers")
                        ShowTopCustomersView(SelectedReportItem);
                    else if (SelectedReportItem == "Suppliers Details")
                        ShowSuppliersDetailsListView(SelectedReportItem);
                    else if (SelectedReportItem == "Suppliers History")
                        SuppliersHistoryViews(SelectedReportItem);
                    else if (SelectedReportItem == "Suppliers Statement")
                        ShowSuppliersStatementUnPaidInvoicesView(SelectedReportItem);
                    else if (SelectedReportItem == "P&S Purchased from Suppliers")
                        PurchasedFromSupplierView(SelectedReportItem);
                    else if (SelectedReportItem == "Top Suppliers")
                        ShowTopSuppliersViews(SelectedReportItem);
                    else if (SelectedReportItem == "P&S Details")
                        ShowProductsDescriptionView();
                    else if (SelectedReportItem == "P&S History")
                        ShowPandSHistoryView();
                    else if (SelectedReportItem == "Stock in/out card")
                        StockInAndOutView();
                    else if (SelectedReportItem == "P & S Sold")
                        PandSSoldView();
                    else if (SelectedReportItem == "P & S Purchased")
                        PandSPurchaseView();
                    else if (SelectedReportItem == "Top Products & Services")
                        ShowTopPandSView();
                    else if (SelectedReportItem == "Cash & Bank Statement")
                        CashBankStatementView();
                    else if (SelectedReportItem == "Accounts Details")
                        ShowAccountsDetailsListView(SelectedReportItem);
                    else if (SelectedReportItem == "Accounts Transactions")
                        AccountsTransactionHomeView();
                    else if (SelectedReportItem == "Ledger")
                        LedgerView();                
                    else if (SelectedReportItem == "Trial Balance")
                        TrailBalanceView();
                    else if (SelectedReportItem == "Profit & Loss Statement")
                        ShowAccountsHistoryListView(SelectedReportItem);
                    else if (SelectedReportItem == "Balance Sheet")
                        BalanceSheetView();
                    else if (SelectedReportItem == "GST/VAT Reports")
                        GstAndVatView();
                    else if (SelectedReportItem == "Notifications")
                        NotificationView(SelectedReportItem);
                    else if (SelectedReportItem == "To Do List")
                        TodoListView(SelectedReportItem);
                    else if (SelectedReportItem == "Audit Trail")
                        AuditTrailView(SelectedReportItem);  
                    break;
            }


            base.OnPropertyChanged(name);
        }
        #endregion

        #endregion
    }
}