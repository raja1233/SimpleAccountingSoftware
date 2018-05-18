﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using SASClient.CashBank.Services;
using SASClient.CashBank.Views;
using SASClient.CloseRequest;
using SASClient.Product.Services;
using SDN.CashBank.Views;
using SDN.Common;
using SDN.Purchasing.Services;
using SDN.Purchasing.View;
using SDN.Sales.Views;
using SDN.UI.Entities;
using SDN.UI.Entities.CashandBank;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SASClient.CashBank.ViewModels
{
    public class CashBankStatementViewModel : CashBankStatementEntity
    {

        #region private member
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private List<CashBankStatementEntity> DefaultList = new List<CashBankStatementEntity>();
        private List<CashBankStatementEntity> FullList = new List<CashBankStatementEntity>();
       
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private int Count = 0;
        private string jsonSearch;
        private string _SelectedName;
        private List<SearchEntity> SearchValues;
        private ICashBankStatementRepository CashBankStatementRepository = new CashBankStatementRepository();
        IStockCardListRepository purchaseRepository = new StockCardListRepository();
        //private IPayMoneyRepository rmRepository = new PayMoneyRepository();
        public event PropertyChangedEventHandler PropertyChanged;
        StackList listitem = new StackList();


        #endregion
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
        #region constructor

        public CashBankStatementViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            NavigateToRespectiveForm = new RelayCommand(NavigatetoForm);
            NavigatetoName = new RelayCommand(NavigateToFormDetails);
            SelectChangedCommand = new RelayCommand(onSelectionChange);
            CloseCommand = new DelegateCommand(Close);
            NavigateToCashChequeNo = new RelayCommand(NavigatetoCashChequeNumberForm);
            ExportCommand = new RelayCommand(ExportCommands);
            CheckISActive = new RelayCommand(checkisactive);
        }



        #region 
        public RelayCommand ExportCommand { get; set; }
        public RelayCommand SelectChangedCommand { get; set; }
        public RelayCommand NavigateToRespectiveForm { get; set; }
        public RelayCommand NavigateToCashChequeNo { get; set; }
        public RelayCommand NavigatetoName { get; set; }
        public RelayCommand CheckISActive { get; set; }
        public ICommand CloseCommand { get; set; }
        #endregion
        public CashBankStatementViewModel()
        {

        }
        //private void GoBack()
        //{
        //    /*GoForward()*/
        //    //CloseRequest obj = new CloseRequest();
        //    var y = regionManager.Regions[RegionNames.MainRegion].Views;
        //    var view = y.Reverse().Skip(1).First();
        //    IRegion region = regionManager.Regions[RegionNames.MainRegion];
        //    var f = view.GetType();
        //    var z = f.Name;
        //    var n = view;
        //    CloseRequestNew obj = new CloseRequestNew(regionManager, eventAggregator);
        //    obj.CloseViewRequest(z, region);

        //    //region.NavigationService.Journal.GoBack();

        //}
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
        public void ShowSelected()
        {
            if(!string.IsNullOrEmpty(SelectedName))
            {
                CashBankStatementDetailList = FullList.Where(x => (x.Name == SelectedName)).ToList();
                CashBankStatementSearchList = CashBankStatementDetailList;
            }
            else
            {
                CashBankStatementSearchList = CashBankStatementDetailList;
            }
            OnPropertyChanged("CashBankStatementDetailList");
        }
        void NavigateToFormDetails(object param)
        {
            if (param != null)
            {
                
                List<object> values = new List<object>();
                values = param as List<object>;
                var TransType = values[1];
                if (TransType.Equals("PM") || TransType.Equals("TM") || TransType.Equals("RM"))
                {
                    SharedValues.ScreenCheckName = "Accounts Details";
                    SharedValues.ViewName = "Accounts Details";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = "New";
                    var tabview = ServiceLocator.Current.GetInstance<SASClient.Accounts.Views.AccountsTabView>();

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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
                    }
                }
                else if (TransType.Equals("RC") || TransType.Equals("PC"))
                {

                    SharedValues.ScreenCheckName = "Customers Details";
                    SharedValues.ViewName = "Customers Details";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = values[0].ToString();
                    SharedValues.getValue = values[0].ToString();
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
                    eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                    eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details Form");
                    }
                    else
                    {
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                else if (TransType.Equals("RS"))
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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
                    }

                }


            }


        }


        void NavigatetoCashChequeNumberForm(object param)
        {

            try
            {
                //var sub = param.ToString();
                //var comp = sub.Substring(0, 2);
                //List<object> list = new List<object>();
                //var z = list[0];


                if (param != null)
                {
                    List<object> values = new List<object>();
                    values = param as List<object>;
                    var ChequeNumber = values[0].ToString();
                    var TransType = values[1].ToString();
                   // string obj = param.ToString();
                    SharedValues.NewClick = ChequeNumber;

                    if (TransType == "PC")
                    {
                        SharedValues.ScreenCheckName = "Payment from Customer";
                        SharedValues.ViewName = "Payment from Customer";
                        var accessitem = listitem.AddToList();
                        if (accessitem == true)
                        {
                            SharedValues.NewClick = ChequeNumber;
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
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
                        }
                    }
                    else if (TransType == "PS")
                    {
                        SharedValues.ScreenCheckName = "Payment to Suplier";
                        SharedValues.ViewName = "Payment to Supplier";
                        var accessitem = listitem.AddToList();
                        if (accessitem == true)
                        {
                            SharedValues.NewClick = ChequeNumber;
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
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
                        }
                    }
                    else if (TransType == "TM")
                    {
                        SharedValues.ScreenCheckName = "Transfer Money";
                        SharedValues.ViewName = "Transfer Money";
                        var accessitem = listitem.AddToList();
                        if (accessitem == true)
                        {
                            SharedValues.NewClick = ChequeNumber;
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
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
                        }
                    }
                    else if (TransType == "RM")
                    {
                        SharedValues.ScreenCheckName = "Recieve Money";
                        SharedValues.ViewName = "Receive Money";
                        var accessitem = listitem.AddToList();
                        if (accessitem == true)
                        {
                            SharedValues.NewClick = ChequeNumber;
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
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
                        }
                    }
                    else if (TransType == "PM")
                    {
                        SharedValues.ScreenCheckName = "Pay Money";
                        SharedValues.ViewName = "Pay Money";
                        var accessitem = listitem.AddToList();
                        if (accessitem == true)
                        {
                            SharedValues.getValue = "PayMoneyTab";
                        SharedValues.NewClick = ChequeNumber;

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
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
                        }
                    }
                    else if (TransType == "RS")
                    {
                        SharedValues.ScreenCheckName = "Refund to Supplier";
                        SharedValues.ViewName = "Refund From Supplier";
                        var accessitem = listitem.AddToList();
                        if (accessitem == true)
                        {
                            if (param != null)
                        {
                            SharedValues.NewClick = ChequeNumber;
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
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
                        }
                    }
                    else if (TransType == "RC")
                    {
                        SharedValues.ScreenCheckName = "Refund To Customer";
                        SharedValues.ViewName = "Refund To Customer";
                        var accessitem = listitem.AddToList();
                        if (accessitem == true)
                        {
                            if (param != null)
                        {
                            SharedValues.NewClick = ChequeNumber;
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
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
                        }
                    }
                    //else if (comp2 == "HDFC" || comp3 == "ICICI")
                    //{
                    //    var mainview = ServiceLocator.Current.GetInstance<CashBankDetailView>();
                    //    var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                    //    mainregion.Add(mainview);
                    //    if (mainregion != null)
                    //    {
                    //        mainregion.Activate(mainview);
                    //    }


                    //    var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();
                    //    var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                    //    tabregion.Add(tabview);
                    //    if (tabregion != null)
                    //    {
                    //        tabregion.Activate(tabview);
                    //    }

                    //    eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                    //    eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                    //    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Cash & Bank Details");
                    //}

                }
                //else
                //{
                //    var comp2 = sub.Substring(0, 4);
                //    if (comp2 == "HDFC")
                //    {
                //        string obj = param.ToString();
                //        SharedValues.NewClick = obj;
                //        SharedValues.getValue = "TransferMoneyTab";
                //        var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

                //        var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                //        tabregion.Add(tabview);
                //        if (tabregion != null)
                //        {
                //            tabregion.Activate(tabview);
                //        }

                //        var mainview = ServiceLocator.Current.GetInstance<TransferMoneyView>();

                //        var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                //        mainregion.Add(mainview);
                //        if (mainregion != null)
                //        {
                //            mainregion.Activate(mainview);
                //        }////
                //        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);

                //        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Transfer Money Form");
                //    }
                //    else
                //    {
                //        var comp3 = sub.Substring(0, 5);
                //        if (comp3 == "ICICI")
                //        {
                //            SharedValues.NewClick = param.ToString();
                //            SharedValues.getValue = "TransferMoneyTab";
                //            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();

                //            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                //            tabregion.Add(tabview);
                //            if (tabregion != null)
                //            {
                //                tabregion.Activate(tabview);
                //            }

                //            var mainview = ServiceLocator.Current.GetInstance<TransferMoneyView>();

                //            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                //            mainregion.Add(mainview);
                //            if (mainregion != null)
                //            {
                //                mainregion.Activate(mainview);
                //            }////
                //            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);

                //            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Transfer Money Form");
                //        }

                //    }

                //}
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            IReceiveMoneyListRepository purchaseRepository = new ReceiveMoneyListRepository();
            oData = purchaseRepository.GetOptionSettings();
            if (oData != null)
            {
                this.CurrencyName = oData.CurrencyCode;     //there is no currency name field in database         
                this.CurrencyCode = oData.CurrencyCode;
                this.CurrencyFormat = oData.NumberFormat;
                this.DateFormat = oData.DateFormat;
                this.DecimalPlaces = oData.DecimalPlaces;

            }
            else
            {
                this.CurrencyName = "USD";
                this.CurrencyCode = "USD";
                this.CurrencyFormat = "en-US";
                this.DateFormat = "dd/MM/yyyy";
            }
        }
        public void NavigatetoForm(object param)
        {
            if (param != null)
            {
                SharedValues.ViewName = "CustomersView";
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
   
        public void onSelectionChange(object param)
        {
            try
            {
                if (CashBankAccountID != 0)
                {
                    
                    CashBankStatementDetailList = CashBankStatementRepository.GetAccountDetailList(CashBankAccountID, this.JsonData).ToList();
                    FullList = CashBankStatementDetailList;
                    this.CashBankStatementSearchList = FullList.GroupBy(x => x.Name).Select(x => x.First()).Where(x => x.Name != "Opening Balance" && x.Name != "Closing Balance").ToList();
                    this.StockCardListcmbTranType = FullList.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
                    CashBankStatementList.Where(c => c.CashBankAccountID == CashBankAccountID).ToList().ForEach(cc => cc.IsChecked = true);
                    CashBankStatementList.Where(c => c.CashBankAccountID != CashBankAccountID).ToList().ForEach(cc => cc.IsChecked = false);
                    
                }

            }

            catch (Exception e)
            {
                throw e;
            }

        }


        public void checkisactive(object param)
        {
            List<object> values = new List<object>();
            values = param as List<object>;
            var TransType = values[0];

            if (TransType.ToString() == "True")
            {
                foreach (var item in CashBankStatementList)
                {

                    item.IsChecked = true;
                }

            }
            else
            {
                foreach (var item in CashBankStatementList)
                {
                    item.IsChecked = false;

                }

            }
        }

     

        public void SetData(string SearchFilter, string parameter)
        {

            if (parameter == "SelectedFormName" && SearchFilter != string.Empty && SearchFilter != null)
            {
                Search(null);
            }
            if (parameter == "Year" && SearchFilter != string.Empty && SearchFilter != null)
            {
                this.ShowSelectedTrue = true;
                //this.ShowAllTrue = false;
                this.YearmonthQuartTrue = true;//change after client feedback on 22 may 2017
                Search(null);
            }

            if (parameter == "Quarter" && SearchFilter != string.Empty && SearchFilter != null)
            {
                this.ShowSelectedTrue = true;
                //this.ShowAllTrue = false;
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
                //this.ShowAllTrue = false;
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
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;
                var results = CashBankStatementRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.CashandBankStatement), "CashandBankStatement");
                if (Count != 0)
                {
                    CashBankStatementDetailList = CashBankStatementRepository.GetAccountDetailList(CashBankAccountID, this.JsonData).ToList();
                    FullList = CashBankStatementDetailList;
                }
                this.CashBankStatementSearchList = this.CashBankStatementDetailList.GroupBy(x=>x.Name).Select(x=>x.FirstOrDefault()).OrderBy(x => x.Name).ToList();
                this.StockCardListcmbTranType = this.CashBankStatementDetailList.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
            }

        }
        #endregion
        #region background region
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
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {

            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 67;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SIGridHeight = minHeight;

            RefreshData();
            GetOptionsandTaxValues();
        }


        private void LoadSupplierBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {

        }
        private void LoadSupplierBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = null;
            Count = 1;

        }

        #endregion end background
        #region public method
        public void RefreshData()
        {
            try
            {
                ICashBankStatementRepository CashBankStatementRepository = new CashBankStatementRepository();
                this.JsonData = CashBankStatementRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.CashandBankStatement));
                //this.CashBankStatementList = CashBankStatementRepository.GetAccountDetailList(CashBankAccountID,this.JsonData).ToList();
                this.CashBankStatementList = CashBankStatementRepository.GetAccountList().ToList();
                DefaultList = this.CashBankStatementList;
                CashBankStatementDetailList = CashBankStatementSearchList;
                CashBankStatementSearchList = CashBankStatementDetailList;
                SetDefaultSearchSelection();

            }
            catch (Exception e)
            {
                throw e;
            }
            this.YearRange = purchaseRepository.GetYearRange().ToList();

        }
        public void ExportCommands(object param)
        {
            
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Excel file (*.xlxs)|*.xlxs|Excel file (*.xls)|*.xls ";
            if (saveFileDialog.ShowDialog() == true)
            {

                Mouse.OverrideCursor = Cursors.Wait;
                var abc = CashBankStatementRepository.GetExportDataList(this.CashBankAccountID, this.JsonData, saveFileDialog.FileName);
                Mouse.OverrideCursor = null;
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
                case "SelectedSearchQuarter":
                    SetData(this.SelectedSearchQuarter, "Quarter");
                    break;
                case "SelectedSearchMonth":
                    SetData(this.SelectedSearchMonth, "Month");
                    break;
                case "SelectedSearchYear":
                    SetData(this.SelectedSearchYear, "Year");
                    break;
                case "SelectedName":
                    GetData(this.SelectedName, "SelectedName");
                    break;
                case "SelectedTransactionType":
                    GetData(this.SelectedTransactionType, "SelectedTransactionType");
                    break;

            }

            base.OnPropertyChanged(name);
        }
        public void SetDefaultSearchSelection()
        {
            String sDate = DateTime.Now.ToString();
            DateTime dateTime = DateTime.UtcNow.Date;
            var month = dateTime.Month;

            var lastMonth = month - 1;
            if (lastMonth == 0)
            {
                lastMonth = 1;
            }
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            this.SelectedSearchYear = DateTime.UtcNow.Year.ToString();
            this.SelectedSearchMonth = lastMonth.ToString();

        }
        public void GetData(string SearchFilter, string parameter)
        {

            //int count = 0;
            if (parameter == "SelectedName")
            {
                if (!string.IsNullOrEmpty(SearchFilter))
                {

                    this.CashBankStatementDetailList = FullList.Where(x => (x.Name == SearchFilter)).ToList();
                    this.CashBankStatementDetailList = CashBankStatementDetailList;
                    //CashBankStatementSearchList = CashBankStatementDetailList;
                }
                else
                {
                    this.CashBankStatementDetailList = FullList;
                }
            }
            else if (parameter == "SelectedTransactionType")
            {
                if (!string.IsNullOrEmpty(SearchFilter))
                {

                    this.CashBankStatementDetailList = FullList.Where(x => (x.TransactionType == SearchFilter)).ToList();
                    this.CashBankStatementDetailList = CashBankStatementDetailList;
                    //CashBankStatementSearchList = CashBankStatementDetailList;
                }
                else
                {
                    this.CashBankStatementDetailList = FullList;
                }

            }

            //TotalInvoiceAmount = Convert.ToString(StockCardList.Sum(e => e.InvoiceAmountValue));
            //TotalCCDAmount = Convert.ToString(StockCardList.Sum(e => e.TotalAmount));
        }
        #endregion end public method


    }
}