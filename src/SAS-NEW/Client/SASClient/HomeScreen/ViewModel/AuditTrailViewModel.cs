﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using SASClient.Accounts.Views;
using SASClient.CashBank.Views;
using SASClient.CloseRequest;
using SASClient.HomeScreen.Services;
using SDN.CashBank.Views;
using SDN.Common;
using SDN.Product.View;
using SDN.Purchasing.View;
using SDN.Sales.Views;
using SDN.UI.Entities;
using SDN.UI.Entities.HomeScreen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SASClient.HomeScreen.ViewModel
{
    public class AuditTrailListViewModel : AuditTrailListEntity
    {
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private ObservableCollection<FormNameEntity> _formlist = new ObservableCollection<FormNameEntity>();
        StackList listitem = new StackList();
        private List<SearchEntity> SearchValues;
        private string jsonSearch;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        //delegate void ThreadStart ThreadProc();
        AuditTrailListEntity allPosition = new AuditTrailListEntity();
       
        private int Count = 0;

        public ObservableCollection<FormNameEntity> FormList
        {
            get
            {
                _formlist.Clear();
                Formdata();
                return _formlist;
            }
        }
       
        private void Formdata()
        {
            //_formlist.Add(new FormNameEntity { ID = 1, Name = "Customers Details" });
            //_formlist.Add(new FormNameEntity { ID = 2, Name = "Suppliers Details" });
            //_formlist.Add(new FormNameEntity { ID = 3, Name = "Products & Services Details" });
            //_formlist.Add(new FormNameEntity { ID = 4, Name = "Accounts Details" });
            _formlist.Add(new FormNameEntity { ID = 5, Name = "Sales Quotations" });
            _formlist.Add(new FormNameEntity { ID = 6, Name = "Sales Orders" });
            _formlist.Add(new FormNameEntity { ID = 7, Name = "Sales Invoices" });
            _formlist.Add(new FormNameEntity { ID = 8, Name = "Credit Notes" });
            _formlist.Add(new FormNameEntity { ID = 9, Name = "Adjust Credit Notes" });
            _formlist.Add(new FormNameEntity { ID = 10, Name = "Purchase Quotations" });
            _formlist.Add(new FormNameEntity { ID = 11, Name = "Purchase Orders" });
            _formlist.Add(new FormNameEntity { ID = 12, Name = "Purchase Invoices" });
            _formlist.Add(new FormNameEntity { ID = 13, Name = "Debit Notes" });
            _formlist.Add(new FormNameEntity { ID = 14, Name = "Adjust Debit Notes" });
            _formlist.Add(new FormNameEntity { ID = 15, Name = "Payment from Customers" });
            _formlist.Add(new FormNameEntity { ID = 16, Name = "Refund to Customers" });
            _formlist.Add(new FormNameEntity { ID = 17, Name = "Payment to Suppliers" });
            _formlist.Add(new FormNameEntity { ID = 18, Name = "Refund from Suppliers" });
            _formlist.Add(new FormNameEntity { ID = 19, Name = "Receive Money" });
            _formlist.Add(new FormNameEntity { ID = 20, Name = "Pay Money" });
            _formlist.Add(new FormNameEntity { ID = 21, Name = "Transfer Money" });
            _formlist.Add(new FormNameEntity { ID = 22, Name = "Count & Adjust Stock" });
            _formlist.Add(new FormNameEntity { ID = 23, Name = "Journal" });
          
        }
        public ObservableCollection<QuarterEntity> QuarterList
        {
            get
            {
                _quarterlist.Clear();
                QuarterData();
                return _quarterlist;
            }
        }
        private void QuarterData()
        {
            _quarterlist.Add(new QuarterEntity { ID = 1, Quarter = "Jan-Mar" });
            _quarterlist.Add(new QuarterEntity { ID = 2, Quarter = "Apr-Jun" });
            _quarterlist.Add(new QuarterEntity { ID = 3, Quarter = "Jul-Sep" });
            _quarterlist.Add(new QuarterEntity { ID = 4, Quarter = "Oct-Dec" });
        }
        public ObservableCollection<MonthEntity> MonthList
        {
            get
            {
                _monthlist.Clear();
                MonthData();
                return _monthlist;
            }
        }
        private void MonthData()
        {
            _monthlist.Add(new MonthEntity { ID = 1, Month = "Jan" });
            _monthlist.Add(new MonthEntity { ID = 2, Month = "Feb" });
            _monthlist.Add(new MonthEntity { ID = 3, Month = "Mar" });
            _monthlist.Add(new MonthEntity { ID = 4, Month = "Apr" });
            _monthlist.Add(new MonthEntity { ID = 5, Month = "May" });
            _monthlist.Add(new MonthEntity { ID = 6, Month = "June" });
            _monthlist.Add(new MonthEntity { ID = 7, Month = "July" });
            _monthlist.Add(new MonthEntity { ID = 8, Month = "Aug" });
            _monthlist.Add(new MonthEntity { ID = 9, Month = "Sept" });
            _monthlist.Add(new MonthEntity { ID = 10, Month = "Oct" });
            _monthlist.Add(new MonthEntity { ID = 11, Month = "Nov" });
            _monthlist.Add(new MonthEntity { ID = 12, Month = "Dec" });

        }

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditTrailListViewModel"/> class.
        /// </summary>
        public AuditTrailListViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            SearchCommand = new RelayCommand(Search);
            ShowAllCommand = new RelayCommand(ShowAll);
            ShowSelectedCommand = new RelayCommand(ShowSelected);
            NavigateToClientCommand = new RelayCommand(NavigatetoSupplier);
            ShowIncGSTCommand = new RelayCommand(showincGST);
            ShowExcGSTCommand = new RelayCommand(showexcGST);
            RefreshCommand = new RelayCommand(refreshcommand);
            NavigaetoSalesCommand = new RelayCommand(NavigatetoAuditTrail);
            YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
            CalendarSelectionCommand = new RelayCommand(OnCalendarSelection);
            NavigaetoTranCommand = new RelayCommand(NavigaetoTranView);
            NavigatetoNameCommand = new RelayCommand(NavigatetoNameView);
            CloseCommand = new DelegateCommand(Close);
        }

        public AuditTrailListViewModel()
        {
        }
        public ICommand CloseCommand { get; set; }
        public RelayCommand YearQuarterSelectedCommand { get; set; }
        public RelayCommand CalendarSelectionCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        public RelayCommand ShowSelectedCommand { get; set; }
        public RelayCommand NavigateToClientCommand { get; set; }
        public RelayCommand ShowIncGSTCommand { get; set; }
        public RelayCommand ShowExcGSTCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand NavigaetoSalesCommand { get; set; }
        public RelayCommand NavigaetoTranCommand { get; set; }
        public RelayCommand NavigatetoNameCommand { get; set; }
        #endregion  Constructor

        #region ButtonCommands
        void refreshcommand(object param)
        {
            RefreshData();
        }
        private void Close()
        {
            try
            {
                List<string> listview = (List<string>)Application.Current.Resources["views"];
                var secondlast = listview.AsEnumerable().Reverse().Skip(1).First();
                CloseView close = new CloseView(regionManager, eventAggregator);
                close.CloseViewRequest(secondlast, true);
                listview.RemoveAt(listview.Count - 1);
            }
            catch (Exception)
            {
                List<string> listview = (List<string>)Application.Current.Resources["views"];
                CloseView close = new CloseView(regionManager, eventAggregator);
                close.CloseViewRequest("MainView", true);
                listview.RemoveAt(listview.Count - 1);
            }
            //List<string> calledlist = stack.x();
        }
        //added after feedback
        void OnYearQuarterMonthChange(object param)
        {
            ShowAllTrue = false;
        }
        void OnCalendarSelection(object param)
        {
            ShowAllTrue = false;
        }//end
        void showincGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //foreach (var item in this.AuditTrailList)
            //{
            //    //item.InvoiceAmount = item.InvoiceAmountIncGST;
            //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountIncGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.AuditTrailList = DefaultList.Where(x => x.ExcIncGST == true).ToList();
            //else
            //    this.AuditTrailList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            IAuditTrailListRepository purchaseRepository = new AuditTrailListRepository();
            this.AuditTrailList = purchaseRepository.GetAllAuditTrailJson(this.JsonData).OrderBy(x => x.CustomerName).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.AuditTrailList.Count();
            else
                this.ShowSelectedCount = 0;
            this.AuditTrailListcmbTranType = this.AuditTrailList.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
            this.AuditTrailListcmbName = this.AuditTrailList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).Where(y => y.Name != null).ToList();
            this.AuditTrailListcmbTranNo = this.AuditTrailList.GroupBy(x => x.TransactionNo).Select(y => y.First()).OrderBy(x => x.TransactionNo).Distinct().ToList();
            this.AuditTrailListcmbDate = this.AuditTrailList.GroupBy(x => x.TransactionDate).Select(y => y.First()).OrderBy(x => x.TransactionDate).Where(y => y.TransactionDate != null).Distinct().ToList();
            this.AuditTrailListcmbAmount = this.AuditTrailList.GroupBy(x => x.Amount).Select(y => y.First()).OrderBy(x => x.Amount).Distinct().Where(y => y.Amount != null).ToList();
            // this.AuditTrailListcmbUserName = this.AuditTrailList.GroupBy(x => x.UserName).Select(y => y.First()).OrderBy(x => x.UserName).Distinct().ToList();
            DefaultList = this.AuditTrailList;

            Mouse.OverrideCursor = null;
        }
        void showexcGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //foreach (var item in this.AuditTrailList)
            //{
            //    //item.InvoiceAmount = item.InvoiceAmountExcGST;
            //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountExcGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.AuditTrailList = DefaultList.Where(x => x.ExcIncGST == false).ToList();
            //else
            //    this.AuditTrailList = FullPQList.Where(x => x.ExcIncGST == false).ToList();
            IAuditTrailListRepository purchaseRepository = new AuditTrailListRepository();
            this.AuditTrailList = purchaseRepository.GetAllAuditTrailJson(this.JsonData).OrderBy(x => x.CustomerName).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.AuditTrailList.Count();
            else
                this.ShowSelectedCount = 0;
            this.AuditTrailListcmbTranType = this.AuditTrailList.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
            this.AuditTrailListcmbName = this.AuditTrailList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).Where(y => y.Name != null).ToList();
            this.AuditTrailListcmbTranNo = this.AuditTrailList.GroupBy(x => x.TransactionNo).Select(y => y.First()).OrderBy(x => x.TransactionNo).Distinct().ToList();
            this.AuditTrailListcmbDate = this.AuditTrailList.GroupBy(x => x.TransactionDate).Select(y => y.First()).OrderBy(x => x.TransactionDate).Where(y => y.TransactionDate != null).Distinct().ToList();
            this.AuditTrailListcmbAmount = this.AuditTrailList.GroupBy(x => x.Amount).Select(y => y.First()).OrderBy(x => x.Amount).Distinct().Where(y => y.Amount != null).ToList();
            //this.AuditTrailListcmbUserName = this.AuditTrailList.GroupBy(x => x.UserName).Select(y => y.First()).OrderBy(x => x.UserName).Distinct().ToList();
            DefaultList = this.AuditTrailList;

            Mouse.OverrideCursor = null;
        }
        void NavigatetoSupplier(object param)
        {
            SharedValues.ScreenCheckName = "Customers Details";
            SharedValues.ViewName = "Customers Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (param != null)
            {
                string obj = param.ToString();
                SharedValues.getValue = obj;
            }
            var mainview = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        void NavigatetoAuditTrail(object param)
        {
            //if (param != null)
            //{
            //    string obj = param.ToString();
            //    SharedValues.NewClick = obj;
            //}
            //var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            //var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            //tabregion.Add(tabview);
            //if (tabregion != null)
            //{
            //    tabregion.Activate(tabview);
            //}

            //var mainview = ServiceLocator.Current.GetInstance<AuditTrailView>();

            //var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            //mainregion.Add(mainview);
            //if (mainregion != null)
            //{
            //    mainregion.Activate(mainview);
            //}////
            //eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoice Form");
        }
        void NavigaetoTranView(object param)
        {
            if (param != null)
            {
                //object[] values =param as object[];
                List<object> values = param as List<object>;
                var screen = (int)values[1];
                
                switch (screen)
                {
                    case 1:
                        SharedValues.ScreenCheckName = "Sales Quotation";
                        SharedValues.ViewName = "Sales Quotation";
                        var accessitem = listitem.AddToList();
                        if (accessitem == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
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
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 2:
                        SharedValues.ScreenCheckName = "Sales Order";
                        SharedValues.ViewName = "Sales Order";
                        var accessitem2 = listitem.AddToList();
                        if (accessitem2 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "SalesOrderTab";
                        var tabview1 = ServiceLocator.Current.GetInstance<SalesTabView>();
                        var tabregion1 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion1.Add(tabview1);
                        if (tabregion1 != null)
                        {
                            tabregion1.Activate(tabview1);
                        }
                        var mainview1 = ServiceLocator.Current.GetInstance<SalesOrderView>();
                        var mainregion1 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion1.Add(mainview1);
                        if (mainregion1 != null)
                        {
                            mainregion1.Activate(mainview1);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Order Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 3:
                        SharedValues.ScreenCheckName = "Sales Invoice";
                        SharedValues.ViewName = "Sales Invoice";
                        var accessitem3 = listitem.AddToList();
                        if (accessitem3 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "SalesInvoiceTab";
                        var tabview2 = ServiceLocator.Current.GetInstance<SalesTabView>();
                        var tabregion2 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion2.Add(tabview2);
                        if (tabregion2 != null)
                        {
                            tabregion2.Activate(tabview2);
                        }
                        var mainview2 = ServiceLocator.Current.GetInstance<SalesInvoiceView>();
                        var mainregion2 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion2.Add(mainview2);
                        if (mainregion2 != null)
                        {
                            mainregion2.Activate(mainview2);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoice Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;

                    case 4:
                        SharedValues.ScreenCheckName = "Credit Note";
                        SharedValues.ViewName = "Credit Note";
                        var accessitem4 = listitem.AddToList();
                        if (accessitem4 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "CreditNoteTab";
                        var tabview3 = ServiceLocator.Current.GetInstance<SalesTabView>();
                        var tabregion3 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion3.Add(tabview3);
                        if (tabregion3 != null)
                        {
                            tabregion3.Activate(tabview3);
                        }
                        var mainview3 = ServiceLocator.Current.GetInstance<CreditNoteView>();
                        var mainregion3 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion3.Add(mainview3);
                        if (mainregion3 != null)
                        {
                            mainregion3.Activate(mainview3);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Credit Note Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 5:
                        SharedValues.ScreenCheckName = "Purchase Quotation";
                        SharedValues.ViewName = "Purchase Quotation";
                        var accessitem5 = listitem.AddToList();
                        if (accessitem5 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "PurchaseQuotationTab";
                        var tabview5 = ServiceLocator.Current.GetInstance<PurchaseTabView>();
                        var tabregion5 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion5.Add(tabview5);
                        if (tabregion5 != null)
                        {
                            tabregion5.Activate(tabview5);
                        }
                        var mainview5 = ServiceLocator.Current.GetInstance<PurchaseQuotationView>();
                        var mainregion5 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion5.Add(mainview5);
                        if (mainregion5 != null)
                        {
                            mainregion5.Activate(mainview5);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Quotations Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 6:
                        SharedValues.ScreenCheckName = "Purchase Order";
                        SharedValues.ViewName = "Purchase Order";
                        var accessitem6 = listitem.AddToList();
                        if (accessitem6 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "PurchaseOrderTab";
                        var tabview6 = ServiceLocator.Current.GetInstance<PurchaseTabView>();
                        var tabregion6 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion6.Add(tabview6);
                        if (tabregion6 != null)
                        {
                            tabregion6.Activate(tabview6);
                        }
                        var mainview6 = ServiceLocator.Current.GetInstance<PurchaseOrderView>();
                        var mainregion6 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion6.Add(mainview6);
                        if (mainregion6 != null)
                        {
                            mainregion6.Activate(mainview6);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Order ");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 7:
                        SharedValues.ScreenCheckName = "Purchases Invoice (P & S)";
                        SharedValues.ViewName = "Purchase Invoice (Products & Services)";
                        var accessitem7 = listitem.AddToList();
                        if (accessitem7 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "PurchaseInvoiceTab";
                        var tabview7 = ServiceLocator.Current.GetInstance<PurchaseTabView>();
                        var tabregion7 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion7.Add(tabview7);
                        if (tabregion7 != null)
                        {
                            tabregion7.Activate(tabview7);
                        }
                        var mainview7 = ServiceLocator.Current.GetInstance<PurchaseInvoicePandSView>();
                        var mainregion7 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion7.Add(mainview7);
                        if (mainregion7 != null)
                        {
                            mainregion7.Activate(mainview7);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoice");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 8:
                        SharedValues.ScreenCheckName = "Debit Note";
                        SharedValues.ViewName = "Debit Note";
                        var accessitem8 = listitem.AddToList();
                        if (accessitem8 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "DebitNoteTab";
                        var tabview8 = ServiceLocator.Current.GetInstance<PurchaseTabView>();
                        var tabregion8 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion8.Add(tabview8);
                        if (tabregion8 != null)
                        {
                            tabregion8.Activate(tabview8);
                        }
                        var mainview8 = ServiceLocator.Current.GetInstance<DebitNoteView>();
                        var mainregion8 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion8.Add(mainview8);
                        if (mainregion8 != null)
                        {
                            mainregion8.Activate(mainview8);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Debit Note Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 9:
                        SharedValues.ScreenCheckName = "Pay Money";
                        SharedValues.ViewName = "Pay Money";
                        var accessitem9 = listitem.AddToList();
                        if (accessitem9 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "PayMoneyTab";
                        var tabview9 = ServiceLocator.Current.GetInstance<CashBankTabView>();
                        var tabregion9 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion9.Add(tabview9);
                        if (tabregion9 != null)
                        {
                            tabregion9.Activate(tabview9);
                        }
                        var mainview9 = ServiceLocator.Current.GetInstance<PayMoneyView>();
                        var mainregion9 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion9.Add(mainview9);
                        if (mainregion9 != null)
                        {
                            mainregion9.Activate(mainview9);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Pay Money");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;

                    case 10:
                        SharedValues.ScreenCheckName = "Recieve Money";
                        SharedValues.ViewName = "Receive Money";
                        var accessitem10 = listitem.AddToList();
                        if (accessitem10 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "ReceiveMoneyTab";
                        var tabview10 = ServiceLocator.Current.GetInstance<CashBankTabView>();
                        var tabregion10 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion10.Add(tabview10);
                        if (tabregion10 != null)
                        {
                            tabregion10.Activate(tabview10);
                        }
                        var mainview10 = ServiceLocator.Current.GetInstance<ReceiveMoneyView>();
                        var mainregion10 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion10.Add(mainview10);
                        if (mainregion10 != null)
                        {
                            mainregion10.Activate(mainview10);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Receive Money Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 11:
                        SharedValues.ScreenCheckName = "Transfer Money";
                        SharedValues.ViewName = "Transfer Money";
                        var accessitem11 = listitem.AddToList();
                        if (accessitem11 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "TransferMoneyTab";
                        var tabview11 = ServiceLocator.Current.GetInstance<CashBankTabView>();
                        var tabregion11 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion11.Add(tabview11);
                        if (tabregion11 != null)
                        {
                            tabregion11.Activate(tabview11);
                        }
                        var mainview11 = ServiceLocator.Current.GetInstance<TransferMoneyView>();
                        var mainregion11 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion11.Add(mainview11);
                        if (mainregion11 != null)
                        {
                            mainregion11.Activate(mainview11);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Transfer Money Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 12:
                        SharedValues.ScreenCheckName = "Payment from Customer";
                        SharedValues.ViewName = "Payment from Customer";
                        var accessitem12 = listitem.AddToList();
                        if (accessitem12 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "PaymentFromCustomerTab";
                        var tabview12 = ServiceLocator.Current.GetInstance<SalesTabView>();
                        var tabregion12 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion12.Add(tabview12);
                        if (tabregion12 != null)
                        {
                            tabregion12.Activate(tabview12);
                        }
                        var mainview12 = ServiceLocator.Current.GetInstance<PaymentFromCustomersView>();
                        var mainregion12 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion12.Add(mainview12);
                        if (mainregion12 != null)
                        {
                            mainregion12.Activate(mainview12);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payment From Customer Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;

                    case 13:
                        SharedValues.ScreenCheckName = "Payment to Suplier";
                        SharedValues.ViewName = "Payment to Supplier";
                        var accessitem13 = listitem.AddToList();
                        if (accessitem13 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "PaymentToSupplierTab";
                        var tabview13 = ServiceLocator.Current.GetInstance<PurchaseTabView>();
                        var tabregion13 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion13.Add(tabview13);
                        if (tabregion13 != null)
                        {
                            tabregion13.Activate(tabview13);
                        }
                        var mainview13 = ServiceLocator.Current.GetInstance<PaymentToSupplierView>();
                        var mainregion13 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion13.Add(mainview13);
                        if (mainregion13 != null)
                        {
                            mainregion13.Activate(mainview13);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payment to Supplier Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 14:
                        SharedValues.ScreenCheckName = "Refund To Customer";
                        SharedValues.ViewName = "Refund To Customer";
                        var accessitem14 = listitem.AddToList();
                        if (accessitem14 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "RefundToCustomerTab";
                        var tabview14 = ServiceLocator.Current.GetInstance<CashBankTabView>();
                        var tabregion14 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion14.Add(tabview14);
                        if (tabregion14 != null)
                        {
                            tabregion14.Activate(tabview14);
                        }
                        var mainview14 = ServiceLocator.Current.GetInstance<RefundToCustomerView>();
                        var mainregion14 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion14.Add(mainview14);
                        if (mainregion14 != null)
                        {
                            mainregion14.Activate(mainview14);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund To Customer Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 15:
                        SharedValues.ScreenCheckName = "Refund to Supplier";
                        SharedValues.ViewName = "Refund From Supplier";
                        var accessitem15 = listitem.AddToList();
                        if (accessitem15 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "RefundFromSupplierTab";
                        var tabview15 = ServiceLocator.Current.GetInstance<CashBankTabView>();
                        var tabregion15 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion15.Add(tabview15);
                        if (tabregion15 != null)
                        {
                            tabregion15.Activate(tabview15);
                        }
                        var mainview15 = ServiceLocator.Current.GetInstance<RefundFromSupplierView>();
                        var mainregion15 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion15.Add(mainview15);
                        if (mainregion15 != null)
                        {
                            mainregion15.Activate(mainview15);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund From Supplier Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 16:
                        SharedValues.ScreenCheckName = "Adjust Debit Note";
                        SharedValues.ViewName = "Adjust Debit Note";
                        var accessitem16 = listitem.AddToList();
                        if (accessitem16 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "DebitNoteTab";
                        var mainview16 = ServiceLocator.Current.GetInstance<AdjustDebitNoteFormView>();
                        var mainregion16 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion16.Add(mainview16);
                        if (mainregion16 != null)
                        {
                            mainregion16.Activate(mainview16);
                        }


                        var tabview16 = ServiceLocator.Current.GetInstance<PurchaseTabView>();
                        var tabregion16 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion16.Add(tabview16);
                        if (tabregion16 != null)
                        {
                            tabregion16.Activate(tabview16);
                        }

                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Adjust Debit Note");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 17:
                        SharedValues.ScreenCheckName = "Adjust Credit Note";
                        SharedValues.ViewName = "Adjust Credit Note";
                        var accessitem17 = listitem.AddToList();
                        if (accessitem17 == true)
                        {
                            SharedValues.NewClick = values[0].ToString();
                        SharedValues.getValue = "CreditNoteTab";
                        var mainview17 = ServiceLocator.Current.GetInstance<AdjustCreditNoteFormView>();
                        var mainregion17 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion17.Add(mainview17);
                        if (mainregion17 != null)
                        {
                            mainregion17.Activate(mainview17);
                        }


                        var tabview17 = ServiceLocator.Current.GetInstance<SalesTabView>();
                        var tabregion17 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion17.Add(tabview17);
                        if (tabregion17 != null)
                        {
                            tabregion17.Activate(tabview17);
                        }

                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Adjust Credit Note");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;
                    case 18:
                        SharedValues.ScreenCheckName = "Journal";
                        SharedValues.ViewName = "Journal";
                        var accessitem18 = listitem.AddToList();
                        if (accessitem18 == true)
                        {
                            SharedValues.getValue = "JournalTab";
                        SharedValues.NewClick = values[0].ToString();
                        var mainview18 = ServiceLocator.Current.GetInstance<JournalView>();
                        var mainregion18 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion18.Add(mainview18);
                        if (mainregion18 != null)
                        {
                            mainregion18.Activate(mainview18);
                        }
                        var tabview18 = ServiceLocator.Current.GetInstance<AccountsTabView>();
                        var tabregion18 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion18.Add(tabview18);
                        if (tabregion18 != null)
                        {
                            tabregion18.Activate(tabview18);
                        }
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Journal  Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                        }
                        break;

                }
            }
        }
        void NavigatetoNameView(object param)
        {
            if (param != null)
            {
                List<object> values = param as List<object>;
                var TransactionType = values[1];
                if (TransactionType.Equals("Sales Invoices") || TransactionType.Equals("Sales Orders") || TransactionType.Equals("Sales Quotations") || TransactionType.Equals("Payment From Customers") || TransactionType.Equals("Refund To Customers") || TransactionType.Equals("Credit Notes") || TransactionType.Equals("Adjust Credit Notes") || TransactionType.Equals("Customers Details"))
                {
                    SharedValues.ScreenCheckName = "Customers Details";
                    SharedValues.ViewName = "Customers Details";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = values[0].ToString();
                    SharedValues.getValue = values[0].ToString();
                    var mainview = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersView>();
                    var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                    mainregion.Add(mainview);
                    if (mainregion != null)
                    {
                        mainregion.Activate(mainview);
                    }


                    var tabview = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();
                    var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                    tabregion.Add(tabview);
                    if (tabregion != null)
                    {
                        tabregion.Activate(tabview);
                    }

                    eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customer Details Form");
                    }
                    else
                    {
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }

                }
                else if (TransactionType.Equals("Payment to Suppliers") || TransactionType.Equals("Purchase Invoices") || TransactionType.Equals("Purchase Orders") || TransactionType.Equals("Debit Notes") || TransactionType.Equals("Suppliers Details") || TransactionType.Equals("Adjust Debit Notes") || TransactionType.Equals("Purchase Quotations"))
                {
                    SharedValues.ScreenCheckName = "Suppliers Details";
                    SharedValues.ViewName = "Suppliers Details";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = values[0].ToString();
                    SharedValues.getValue = values[0].ToString();
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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }

                }
                else if (TransactionType.Equals("Transfer Money") || TransactionType.Equals("Receive Money") || TransactionType.Equals("Pay Money")|| TransactionType.Equals("Accounts Details"))
                {
                    SharedValues.ScreenCheckName = "Accounts Details";
                    SharedValues.ViewName = "Accounts Details";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = values[0].ToString();
                    SharedValues.getValue = values[0].ToString();
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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                else if(TransactionType.Equals("Products & Services Details")){
                    SharedValues.ScreenCheckName = "P & S Details Form";
                    SharedValues.ViewName = "Products & Services Details";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = values[0].ToString();
                    SharedValues.getValue = values[0].ToString();
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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                else if(TransactionType.Equals("Count & Adjust Stocks"))
                {
                    SharedValues.ScreenCheckName = "Count & Adjust Stock";
                    SharedValues.ViewName = "Count & Adjust Stock";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = values[0].ToString();
                    SharedValues.getValue = values[0].ToString();
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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }

                }

            }

        }
        void ShowAll(object param)
        {
            //Mouse.OverrideCursor = Cursors.Wait;
            //this.YearmonthQuartTrue = false;//added after client feedback
            //this.StartEndDateTrue = false;//added after client feedback
            //this.AuditTrailList = FullPQList.OrderBy(x => x.CustomerName).ToList();
            //this.AuditTrailListcmbTranType = this.AuditTrailList.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
            //this.AuditTrailListcmbName = this.AuditTrailList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).Where(y => y.Name != null).ToList();
            //this.AuditTrailListcmbTranNo = this.AuditTrailList.GroupBy(x => x.TransactionNo).Select(y => y.First()).OrderBy(x => x.TransactionNo).Distinct().ToList();
            //this.AuditTrailListcmbDate = this.AuditTrailList.GroupBy(x => x.TransactionDate).Select(y => y.First()).OrderBy(x => x.TransactionDate).Where(y => y.TransactionDate != null).Distinct().ToList();
            //this.AuditTrailListcmbAmount = this.AuditTrailList.GroupBy(x => x.Amount).Select(y => y.First()).OrderBy(x => x.Amount).Distinct().Where(y => y.Amount != null).ToList();
            ////this.AuditTrailListcmbUserName = this.AuditTrailList.GroupBy(x => x.UserName).Select(y => y.First()).OrderBy(x => x.UserName).Distinct().ToList();
            //if (this.ShowAllTrue == false)
            //    this.ShowSelectedCount = this.AuditTrailList.Count();
            //else
            //    this.ShowSelectedCount = 0;
            //this.SelectedSearchEndDate = null;
            //this.SelectedSearchMonth = null;
            //this.SelectedSearchQuarter = null;
            //this.SelectedSearchYear = null;
            //this.SelectedSearchStartDate = null;
            //this.SelectedSearchEndDate = null;
            //if (this.IncludingGSTTrue == true)
            //    this.AuditTrailList = FullPQList.Where(x => x.ExcIncGST == true).OrderBy(x => x.CustomerName).ToList();
            //else
            //    this.AuditTrailList = FullPQList.Where(x => x.ExcIncGST == false).OrderBy(x => x.CustomerName).ToList();
            //Search(null);
            //Mouse.OverrideCursor = null;
        }
        void ShowSelected(object param)
        {
            Search(null);
        }
        void Search(object param)
        {
            //UIServices.SetBusyState();
            //DoProcessing();
            if (Count != 0)
            {
                SearchValues = new List<SearchEntity>();
                if (this.SelectedSearchYear != null && this.SelectedSearchYear != string.Empty)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Year";
                    value.FieldValue = this.SelectedSearchYear;
                    SearchValues.Add(value);
                    var year = Convert.ToInt32(this.SelectedSearchYear);
                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Year";
                    value.FieldValue = "0";
                    SearchValues.Add(value);
                }

                if (this.SelectedSearchQuarter != null && this.SelectedSearchQuarter != string.Empty)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Quarter";
                    value.FieldValue = this.SelectedSearchQuarter;
                    int month1;
                    int month2;
                    int month3;
                    if (Convert.ToInt32(this.SelectedSearchQuarter) == 1)
                    {
                        month1 = 1;
                        month2 = 2;
                        month3 = 3;
                    }
                    else if (Convert.ToInt32(this.SelectedSearchQuarter) == 2)
                    {
                        month1 = 4;
                        month2 = 5;
                        month3 = 6;
                    }
                    else if (Convert.ToInt32(this.SelectedSearchQuarter) == 3)
                    {
                        month1 = 7;
                        month2 = 8;
                        month3 = 9;
                    }
                    else
                    {
                        month1 = 10;
                        month2 = 11;
                        month3 = 12;
                    }
                    SearchValues.Add(value);
                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Quarter";
                    value.FieldValue = "0";
                    SearchValues.Add(value);
                }

                if (this.SelectedSearchMonth != null && this.SelectedSearchMonth != string.Empty)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Month";
                    value.FieldValue = this.SelectedSearchMonth;
                    SearchValues.Add(value);
                    var month = Convert.ToInt32(this.SelectedSearchMonth);
                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Month";
                    value.FieldValue = "0";
                    SearchValues.Add(value);
                }
                if (this.SelectedSearchStartDate != null && this.SelectedSearchEndDate != null)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "StartDate";
                    value.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchStartDate);
                    SearchValues.Add(value);
                    SearchEntity value1 = new SearchEntity();
                    value1.FieldName = "EndDate";
                    value1.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchEndDate);
                    SearchValues.Add(value1);
                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "StartDate";
                    value.FieldValue = "0";
                    //SearchValues.Add(value);
                    SearchEntity value1 = new SearchEntity();
                    value1.FieldName = "EndDate";
                    value1.FieldValue = "0";
                    SearchValues.Add(value);
                    SearchValues.Add(value1);
                }

                if (this.ShowAllTrue == true)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "ShowAll";
                    value.FieldValue = this.ShowAllTrue.ToString();
                    SearchValues.Add(value);
                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "ShowAll";
                    value.FieldValue = "false";
                    SearchValues.Add(value);
                }
                if (this.SelectedFormName != null && this.SelectedFormName != string.Empty)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "ScreenName";
                    value.FieldValue = this.SelectedFormName.ToString();
                    SearchValues.Add(value);
                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "ScreenName";
                    value.FieldValue = "Customers Details";
                    SearchValues.Add(value);
                }
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;

                IAuditTrailListRepository purchaseRepository = new AuditTrailListRepository();
                //var results = purchaseRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.AuditTrailList), "AuditTrailList");
                if (Count != 0)
                {
                    this.AuditTrailList = purchaseRepository.GetAllAuditTrailJson(jsonSearch).ToList();
                    FullPQList = this.AuditTrailList;
                    DefaultList = this.AuditTrailList;
                    this.AuditTrailListcmbTranType = this.AuditTrailList.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
                    allPosition.TransactionType = "All";
                    //allPosition.Category2 = "All";
                    this.AuditTrailListcmbTranType.Insert(0, allPosition);
                    this.SelectedTransactionType = "All";
                    this.AuditTrailListcmbName = this.AuditTrailList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).Where(y => y.Name != null).ToList();
                    this.AuditTrailListcmbTranNo = this.AuditTrailList.GroupBy(x => x.TransactionNo).Select(y => y.First()).OrderBy(x => x.TransactionNo).Distinct().ToList();
                    this.AuditTrailListcmbDate = this.AuditTrailList.GroupBy(x => x.TransactionDate).Select(y => y.First()).OrderBy(x => x.TransactionDate).Where(y => y.TransactionDate != null).Distinct().ToList();
                    this.AuditTrailListcmbAmount = this.AuditTrailList.GroupBy(x => x.Amount).Select(y => y.First()).OrderBy(x => x.Amount).Distinct().Where(y => y.Amount != null).ToList();
                    // FullPQList = this.AuditTrailListcmb;
                    allPosition.TransactionType = "All";
                    //allPosition.Category2 = "All";
                    this.AuditTrailListcmbTranType.Insert(0, allPosition);
                    //this.PandSSellPriceListcmbCat2.Insert(0, allPosition);

                }

                //this.AuditTrailListcmb = this.AuditTrailList.OrderBy(x => x.CustomerName).ToList();
                //this.AuditTrailListcmbCredit = this.AuditTrailListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
                //this.AuditTrailListcmbSup = this.AuditTrailList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
                //this.AuditTrailListcmbInv = this.AuditTrailList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
                if (this.ShowAllTrue == true)
                    this.ShowSelectedCount = this.AuditTrailList.Count();
                else
                    this.ShowSelectedCount = this.AuditTrailList.Count();
                //DefaultList = this.AuditTrailListcmb;
                //
                TotalInvoiceAmount = Convert.ToString(AuditTrailList.Sum(e => e.Amount));
                //TotalCCDAmount = Convert.ToString(AuditTrailList.Sum(e => e.TotalAmount));
            }

        }
        #endregion

        #region BackgroundWorked
        private void LoadSupplierBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;

            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;


            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadSupplierBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadSupplierBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadSupplierBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }
        List<AuditTrailListEntity> DefaultList = new List<AuditTrailListEntity>();
        List<AuditTrailListEntity> FullPQList = new List<AuditTrailListEntity>();
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {

            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 72;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SIGridHeight = minHeight;
            RefreshData();
        }

        private void RefreshData()
        {
            IAuditTrailListRepository purchaseRepository = new AuditTrailListRepository();
            this.DateFormat = purchaseRepository.GetDateFormat();
            this.ShowAllCount = purchaseRepository.GetAllAuditTrail().Count();
            GetOptionsandTaxValues();
            //this.JsonData = purchaseRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.AuditTrailList));
            this.AuditTrailList = purchaseRepository.GetAllAuditTrailJson(this.JsonData).OrderBy(x => x.CustomerName).ToList();
            //this.AuditTrailListcmb = purchaseRepository.GetAllAuditTrail().OrderBy(x => x.CustomerName).ToList();
            this.ShowSelectedCount = this.AuditTrailList.Count();
            this.AuditTrailListcmbTranType = this.AuditTrailList.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
            this.AuditTrailListcmbName = this.AuditTrailList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).Where(y => y.Name != null).ToList();
            this.AuditTrailListcmbTranNo = this.AuditTrailList.GroupBy(x => x.TransactionNo).Select(y => y.First()).OrderBy(x => x.TransactionNo).Distinct().ToList();
          
            this.AuditTrailListcmbDate = this.AuditTrailList.GroupBy(x => x.TransactionDate).Select(y => y.First()).OrderBy(x => x.TransactionDate).Where(y => y.TransactionDate != null).Distinct().ToList();
            this.AuditTrailListcmbAmount = this.AuditTrailList.GroupBy(x => x.Amount).Select(y => y.First()).OrderBy(x => x.Amount).Distinct().Where(y => y.Amount != null).ToList();
            //this.AuditTrailListcmbUserName = this.AuditTrailList.GroupBy(x => x.UserName).Select(y => y.First()).OrderBy(x => x.UserName).Distinct().ToList();
            this.YearRange = purchaseRepository.GetYearRange().ToList();
            DefaultList = this.AuditTrailList;
            FullPQList = this.AuditTrailList;
            //this.ShowAllCount = this.AuditTrailListcmb.Count();
            SetDefaultSearchSelection(this.JsonData);
            allPosition.TransactionType = "All";
            this.SelectedTransactionType = "All";
            //allPosition.Category2 = "All";
            this.AuditTrailListcmbTranType.Insert(0, allPosition);
            //this.PandSSellPriceListcmbCat2.Insert(0, allPosition);


            TotalInvoiceAmount = Convert.ToString(AuditTrailList.Sum(e => e.Amount));
            TotalCCDAmount = Convert.ToString(AuditTrailList.Sum(e => e.TotalAmount));
            //this.GetData(this.SelectedSearchSupplier);
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            IAuditTrailListRepository purchaseRepository = new AuditTrailListRepository();
            oData = purchaseRepository.GetOptionSettings();
            if (oData != null)
            {
                this.CurrencyName = oData.CurrencyCode;     //there is no currency name field in database         
                this.CurrencyCode = oData.CurrencyCode;
                this.CurrencyFormat = oData.NumberFormat;
                this.DateFormat = oData.DateFormat;
                this.DecimalPlaces = oData.DecimalPlaces;
                if (oData.ShowAmountIncGST == true)
                {
                    this.IncludingGSTTrue = true;
                    this.IncludingGSTFalse = false;
                    //int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.AuditTrailList)
                    //{
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    //this.AuditTrailList = this.AuditTrailList.Where(x => x.ExcIncGST == true).ToList();
                }
                else
                {
                    this.IncludingGSTTrue = false;
                    this.IncludingGSTFalse = true;
                    int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.AuditTrailList)
                    //{
                    //    //item.InvoiceAmount = item.InvoiceAmountExcGST;
                    //    //item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountExcGST), decimalpoints).ToString();
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    if (this.AuditTrailList != null)
                        this.AuditTrailList = this.AuditTrailList.ToList();
                }
            }
            else
            {
                this.CurrencyName = "USD";
                this.CurrencyCode = "USD";
                this.CurrencyFormat = "en-US";
                this.DateFormat = "dd/MM/yyyy";
            }



            TaxModel objDefaultTax = new TaxModel();
            objDefaultTax = purchaseRepository.GetDefaultTaxes();
            if (objDefaultTax != null)
            {
                this.TaxName = objDefaultTax.TaxName;
                //this.TaxName = objDefaultTax.TaxRate;
            }
            else
            {
                this.TaxName = "GST Free";
                //this.TaxRate = 0;
            }
        }



        public void SetDefaultSearchSelection(string jsondata)
        {
            if (jsondata != null && jsondata != "[]")
            {
                //this.ShowSelectedTrue = true;
                //this.ShowAllTrue = false;
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);
                if (objResponse1[5].FieldValue != "True")
                {
                    foreach (var item in objResponse1)
                    {

                        switch (item.FieldName)
                        {
                            case "Year":
                                if (!string.IsNullOrWhiteSpace(item.FieldValue) && item.FieldValue != "0")
                                {
                                    this.SelectedSearchYear = item.FieldValue;
                                    this.YearmonthQuartTrue = true;
                                    this.StartEndDateTrue = false;
                                    this.EnableYearDropDown = true;
                                    this.EnableMonthDropDown = true;
                                    this.EnableQuarterDropDown = true;
                                }
                                else this.SelectedSearchYear = null;

                                break;
                            case "Quarter":
                                if (!string.IsNullOrWhiteSpace(item.FieldValue) && item.FieldValue != "0")
                                {
                                    this.SelectedSearchQuarter = item.FieldValue;
                                    this.YearmonthQuartTrue = true;
                                    this.StartEndDateTrue = false;
                                    this.EnableYearDropDown = true;
                                    this.EnableMonthDropDown = true;
                                    this.EnableQuarterDropDown = true;
                                }
                                else this.SelectedSearchQuarter = null;
                                break;
                            case "Month":
                                if (!string.IsNullOrWhiteSpace(item.FieldValue) && item.FieldValue != "0")
                                {
                                    this.SelectedSearchMonth = item.FieldValue;
                                    this.YearmonthQuartTrue = true;
                                    this.StartEndDateTrue = false;
                                    this.EnableYearDropDown = true;
                                    this.EnableMonthDropDown = true;
                                    this.EnableQuarterDropDown = true;
                                }
                                else this.SelectedSearchMonth = null;
                                break;
                            case "StartDate":
                                if (!string.IsNullOrWhiteSpace(item.FieldValue) && item.FieldValue != "0")
                                {
                                    this.SelectedSearchStartDate = Convert.ToDateTime(item.FieldValue);
                                    this.YearmonthQuartTrue = false;
                                    this.StartEndDateTrue = true;
                                    this.EnableYearDropDown = false;
                                    this.EnableMonthDropDown = false;
                                    this.EnableQuarterDropDown = false;
                                }
                                else this.SelectedSearchStartDate = null;
                                break;
                            case "EndDate":
                                if (!string.IsNullOrWhiteSpace(item.FieldValue) && item.FieldValue != "0")
                                {
                                    this.SelectedSearchEndDate = Convert.ToDateTime(item.FieldValue);
                                    this.YearmonthQuartTrue = false;
                                    this.StartEndDateTrue = true;
                                    this.EnableYearDropDown = false;
                                    this.EnableMonthDropDown = false;
                                    this.EnableQuarterDropDown = false;
                                }
                                else this.SelectedSearchEndDate = null;
                                break;
                        }
                    }
                    Search(null);
                }

                else
                {
                    this.ShowAllTrue = true;
                    this.ShowSelectedTrue = false;
                    this.YearmonthQuartTrue = false;//change after feedback
                    this.StartEndDateTrue = false;
                    this.ShowSelectedCount = 0;
                }

            }
            else
            {
                this.ShowAllTrue = true;
                this.ShowSelectedTrue = false;
                this.YearmonthQuartTrue = false;//change after feedback
                this.StartEndDateTrue = false;
                this.ShowSelectedCount = 0;
            }
        }
        public void LoadSearchResult(string customerName)
        {
            IAuditTrailListRepository purchaseRepository = new AuditTrailListRepository();
            this.ShowAllCount = purchaseRepository.GetAllAuditTrail().Count();
            this.AuditTrailList = purchaseRepository.GetAllAuditTrail().Where(x => x.CustomerName == customerName).ToList();
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
                case "SelectedTransactionType":
                    GetData(this.SelectedTransactionType, "SelectedTransactionType");
                    break;
                case "SelectedName":
                    GetData(this.SelectedName, "SelectedName");
                    break;
                case "SelectedTransactionNo":
                    GetData(this.SelectedTransactionNo, "SelectedTransactionNo");
                    break;
                case "SelectedTranDate":
                    GetData(this.SelectedTranDate, "SelectedTranDate");
                    break;
                case "SelectedAmountStr":
                    GetData(this.SelectedAmountStr, "SelectedAmountStr");
                    break;
                case "SelectedSearchQuarter":
                    SetData(this.SelectedSearchQuarter, "Quarter");
                    break;
                case "SelectedSearchMonth":
                    SetData(this.SelectedSearchMonth, "Month");
                    break;
                case "SelectedSearchYear":
                    SetData(this.SelectedSearchYear, "Year");
                    break;
                case "SelectedSearchStartDate":
                    SetData(this.SelectedSearchStartDate.ToString(), "StartDate");
                    break;
                case "SelectedSearchEndDate":
                    SetData(this.SelectedSearchEndDate.ToString(), "EndDate");
                    break;
                case "ShowAllTrue":
                    SetData(this.ShowAllTrue.ToString(), "ShowAllTrue");
                    break;
                case "SelectedFormName":
                    SetData(this.SelectedFormName.ToString(), "SelectedFormName");
                    break;
            }
          
            base.OnPropertyChanged(name);
        }

        public void SetData(string SearchFilter, string parameter)
        {
            if (parameter == "ShowAllTrue" && SearchFilter != string.Empty && SearchFilter != null)
            {
                if (SearchFilter == "True")
                {
                  
                    //Mouse.OverrideCursor = Cursors.Wait;
                    this.ShowSelectedTrue = false;
                    //this.SelectedSearchYear = "";
                    //this.SelectedSearchQuarter = "";
                    //this.SelectedSearchMonth = "";
                    //this.SelectedSearchEndDate = null;
                    //this.SelectedSearchStartDate = null;
                    Search(null);
                    //Mouse.OverrideCursor = null;
                }
            }
            if (parameter == "SelectedFormName" && SearchFilter != string.Empty && SearchFilter != null)
            {
                    Search(null);
            }
            if (parameter == "Year" && SearchFilter != string.Empty && SearchFilter != null)
            {
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.YearmonthQuartTrue = true;//change after client feedback on 22 may 2017
                Search(null);
            }
            if (parameter == "StartDate")
            {
                if (SearchFilter != string.Empty && SearchFilter != null)
                {
                    this.ShowSelectedTrue = true;
                    this.ShowAllTrue = false;
                    this.StartEndDateTrue = true;//added after feedback
                    this.EndDateValidation = Convert.ToDateTime(SearchFilter);
                    this.EnableEndDropDown = true;
                }
                else
                    this.EnableEndDropDown = false;
            }
            if (parameter == "EndDate" && SearchFilter != string.Empty && SearchFilter != null)
            {
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.StartEndDateTrue = true;//added after feedback
                Search(null);
            }
            if (parameter == "Quarter" && SearchFilter != string.Empty && SearchFilter != null)
            {
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.YearmonthQuartTrue = true;//added after feedback
                if (this.SelectedSearchYear == null)
                    this.SelectedSearchYear = DateTime.Now.Year.ToString();
                switch (SearchFilter)
                {
                    case "1":
                        if (this.SelectedSearchMonth == "1" || this.SelectedSearchMonth == "2" || this.SelectedSearchMonth == "3")
                            break;
                        else
                            this.SelectedSearchMonth = null;
                        break;
                    case "2":
                        if (this.SelectedSearchMonth == "4" || this.SelectedSearchMonth == "5" || this.SelectedSearchMonth == "6")
                            break;
                        else
                            this.SelectedSearchMonth = null;
                        break;
                    case "3":
                        if (this.SelectedSearchMonth == "7" || this.SelectedSearchMonth == "8" || this.SelectedSearchMonth == "9")
                            break;
                        else
                            this.SelectedSearchMonth = null;
                        break;
                    case "4":
                        if (this.SelectedSearchMonth == "10" || this.SelectedSearchMonth == "11" || this.SelectedSearchMonth == "12")
                            break;
                        else
                            this.SelectedSearchMonth = null;
                        break;
                }
                //this.SelectedSearchMonth = null;
                Search(null);
            }
            if (parameter == "Month" && SearchFilter != string.Empty && SearchFilter != null)
            {
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.YearmonthQuartTrue = true;//added after feedback
                if (this.SelectedSearchYear == null)
                    this.SelectedSearchYear = DateTime.Now.Year.ToString();
                if (this.SelectedSearchQuarter == null)
                {
                    if (SearchFilter == "1" || SearchFilter == "2" || SearchFilter == "3")
                        this.SelectedSearchQuarter = 1.ToString();
                    if (SearchFilter == "4" || SearchFilter == "5" || SearchFilter == "6")
                        this.SelectedSearchQuarter = 2.ToString();
                    if (SearchFilter == "7" || SearchFilter == "8" || SearchFilter == "9")
                        this.SelectedSearchQuarter = 3.ToString();
                    if (SearchFilter == "10" || SearchFilter == "11" || SearchFilter == "12")
                        this.SelectedSearchQuarter = 4.ToString();

                }
                else
                {
                    if (SearchFilter == "1" || SearchFilter == "2" || SearchFilter == "3")
                        this.SelectedSearchQuarter = 1.ToString();
                    if (SearchFilter == "4" || SearchFilter == "5" || SearchFilter == "6")
                        this.SelectedSearchQuarter = 2.ToString();
                    if (SearchFilter == "7" || SearchFilter == "8" || SearchFilter == "9")
                        this.SelectedSearchQuarter = 3.ToString();
                    if (SearchFilter == "10" || SearchFilter == "11" || SearchFilter == "12")
                        this.SelectedSearchQuarter = 4.ToString();
                }
                Search(null);
            }
        }

        public void SearchPQList()
        {

        }

        public void GetData(string SearchFilter, string parameter)
        {
            //IAuditTrailListRepository purchaseRepository = new AuditTrailListRepository();
            //var result = purchaseRepository.GetAllPurInvoice().ToList();
            if (parameter == "SelectedTransactionType")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {
                    this.ShowAllCount = this.ShowAllCount;
                    if (SearchFilter == "All")
                    {
                        this.AuditTrailList = DefaultList;
                    }
                    else
                    {
                        if (this.ShowAllTrue == true)
                        {
                            this.AuditTrailList = FullPQList.Where(x => (x.TransactionType == SearchFilter)).ToList();
                        }
                        else
                        {
                            this.AuditTrailList = DefaultList.Where(x => (x.TransactionType == SearchFilter)).ToList();
                        }
                    }
                }
                else
                {
                    if (this.ShowAllTrue == true)
                    {
                        this.AuditTrailList = FullPQList.ToList();
                        this.SelectedTransactionType = "All";
                    }
                    else
                    {
                        this.AuditTrailList = DefaultList.ToList();
                        this.SelectedTransactionType = "All";
                    }

                }
            }
            if (parameter == "SelectedName")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {

                    this.ShowAllCount = this.ShowAllCount;
                    if (this.ShowAllTrue == true)
                    {
                        this.AuditTrailList = FullPQList.Where(x => (x.Name == SearchFilter)).ToList();
                    }
                    else
                    {
                        this.AuditTrailList = DefaultList.Where(x => (x.Name == SearchFilter)).ToList();
                    }
                }

                else
                {
                    if (this.ShowAllTrue == true)
                    {
                        this.AuditTrailList = FullPQList.ToList();
                    }
                    else
                    {
                        this.AuditTrailList = DefaultList.ToList();
                    }

                }
            }
            if (parameter == "SelectedTransactionNo")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {
                    this.ShowAllCount = this.ShowAllCount;
                    if (this.ShowAllTrue == true)
                    {
                        this.AuditTrailList = FullPQList.Where(x => (x.TransactionNo == SearchFilter)).ToList();
                    }
                    else
                    {
                        this.AuditTrailList = DefaultList.Where(x => (x.TransactionNo == SearchFilter)).ToList();
                    }
                }

                else
                {
                    if (this.ShowAllTrue == true)
                    {
                        this.AuditTrailList = FullPQList.ToList();
                    }
                    else
                    {
                        this.AuditTrailList = DefaultList.ToList();
                    }

                }
            }

            if (parameter == "SelectedTranDate")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {
                    this.ShowAllCount = this.ShowAllCount;
                    if (this.ShowAllTrue == true)
                    {
                        this.AuditTrailList = FullPQList.Where(x => (x.TransactionDateStr == SearchFilter)).ToList();
                    }
                    else
                    {
                        this.AuditTrailList = DefaultList.Where(x => (x.TransactionDateStr == SearchFilter)).ToList();
                    }
                }
                else
                {
                    if (this.ShowAllTrue == true)
                    {
                        this.AuditTrailList = FullPQList.ToList();
                    }
                    else
                    {
                        this.AuditTrailList = DefaultList.ToList();
                    }

                }
            }

            if (parameter == "SelectedAmountStr")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {
                    this.ShowAllCount = this.ShowAllCount;
                    if (this.ShowAllTrue == true)
                    {
                        this.AuditTrailList = FullPQList.Where(x => (x.AmountStr == SearchFilter)).ToList();
                    }
                    else
                    {
                        this.AuditTrailList = DefaultList.Where(x => (x.AmountStr == SearchFilter)).ToList();
                    }
                }
                else
                {
                    if (this.ShowAllTrue == true)
                    {
                        this.AuditTrailList = FullPQList.ToList();
                    }
                    else
                    {
                        this.AuditTrailList = DefaultList.ToList();
                    }

                }
            }


            TotalInvoiceAmount = Convert.ToString(AuditTrailList.Sum(e => e.InvoiceAmountValue));
            TotalCCDAmount = Convert.ToString(AuditTrailList.Sum(e => e.TotalAmount));
        }
        /// <summary>
        ///  Occurs when System.ComponentModel.BackgroundWorker.ReportProgress(System.Int32) is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void LoadSupplierBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {

        }

        ///// <summary>
        /////  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        ///// </summary>
        ///// <param name="sender">The sender.</param>
        ///// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadSupplierBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {

            Mouse.OverrideCursor = null;
            Count = 1;
        }


        #endregion
    }
}
