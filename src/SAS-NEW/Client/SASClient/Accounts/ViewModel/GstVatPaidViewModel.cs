﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using SASClient.Accounts.Services;
using SASClient.Accounts.Views;
using SASClient.CashBank.Services;
using SASClient.CashBank.Views;
using SASClient.CloseRequest;
using SASClient.Product.Services;
using SDN.CashBank.Views;
using SDN.Common;
using SDN.Purchasing.View;
using SDN.Sales.Views;
using SDN.UI.Entities;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SASClient.Accounts.ViewModel
{
    public  class GstVatPaidViewModel : GstAndVatSummaryEntity
    {
        #region private member
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        IStockCardListRepository purchaseRepository = new StockCardListRepository();
        IGstAndVatReportsRepository gstAndVatReportsRepository = new GstAndVatReportsRepository();
        List<GstAndVatSummaryEntity> _fullListOFPaid = new List<GstAndVatSummaryEntity>();
        List<GstAndVatSummaryEntity> _fullListOFCollected = new List<GstAndVatSummaryEntity>();
        List<GstAndVatSummaryEntity> _fullListOFSummary = new List<GstAndVatSummaryEntity>();
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private int Count = 0;
        private string jsonSearch;
        private List<SearchEntity> SearchValues;
        public event PropertyChangedEventHandler PropertyChanged;
        StackList itemlist = new StackList();
        #endregion
        public List<GstAndVatSummaryEntity> FullListOFSummary
        {
            get
            {
                return _fullListOFSummary;
            }
            set
            {
                _fullListOFSummary = value;
                OnPropertyChanged("FullListOFSummary");
            }
        }
        public List<GstAndVatSummaryEntity> FullListOFPaid
        {
            get
            {
                return _fullListOFPaid;
            }
            set
            {
                _fullListOFPaid = value;
                OnPropertyChanged("FullListOFPaid");
            }
        }
        public List<GstAndVatSummaryEntity> FullListOFCollected
        {
            get
            {
                return _fullListOFCollected;
            }
            set
            {
                _fullListOFCollected = value;
                OnPropertyChanged("FullListOFCollected");
            }
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
        public GstVatPaidViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();

            NavigateToCustomerName = new RelayCommand(NavigateToCustomerForm);
            NavigateToInvoiceNumber = new RelayCommand(NavigateToRespectiveInvoiceNumberForCustomer);
            NavigateToSupplierName = new RelayCommand(NavigateToSupplierForm);
            NavigateToInvoiceCommand = new RelayCommand(NavigateToRespectiveInvoiceNumberForSupplier);
            ShowAllCommand = new RelayCommand(ShowAll);
            CloseCommand = new DelegateCommand(Close);
            YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
        }
        public ICommand CloseCommand { get; set; }
        public RelayCommand ShowTaxSummaryCommand { get; set; }
        public RelayCommand ShowTaxCollectedCommand { get; set; }
        public RelayCommand ShowTaxPaidDetailsCommand { get; set; }
        public RelayCommand NavigateToCustomerName { get; set; }
        public RelayCommand NavigateToInvoiceNumber { get; set; }
        public RelayCommand NavigateToSupplierName { get; set; }
        public RelayCommand NavigateToInvoiceCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        public RelayCommand YearQuarterSelectedCommand { get; set; }
       
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
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 65;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SIGridHeightPaid = minHeight;
            RefreshData();
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

        #region "public method"
        void OnYearQuarterMonthChange(object param)
        {
            ShowAllTrue = false;
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
        public void RefreshData()
        {
            this.YearRange = purchaseRepository.GetYearRange().ToList();
            this.ShowAllTrue = false;

            GetOptionsandTaxValues();
            SetDefaultSearchSelection();
            GstAndPaidDetails();
        }
        public void GstAndPaidDetails()
        {
            try
            {
                this.JsonData = gstAndVatReportsRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.GstVatSummary));
                GstAndVatPaidEntityList = gstAndVatReportsRepository.getGstAndVAtPaidDetails(this.JsonData).ToList();
                FullListOFPaid = GstAndVatPaidEntityList;
                TotalTaxInvoiceAmountS = Convert.ToString(GstAndVatPaidEntityList.Where(x => x.TaxDescriptionS != "Total").Sum(x => x.TaxInvoiceAmountS));
                TotalTaxCollectedS = Convert.ToString(GstAndVatPaidEntityList.Where(x => x.TaxDescriptionS != "Total").Sum(x => x.TaxCollectedS));
                this.ShowSelectedCount = GstAndVatPaidEntityList.Where(x => x.TaxDescriptionS != "Total").Count();
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
        public void SetDefaultSearchSelection()
        {
            String sDate = DateTime.Now.ToString();
            DateTime dateTime = DateTime.UtcNow.Date;
            var quarter = (dateTime.Month + 2) / 3;

            var lastQuarter = quarter - 1;
            if (lastQuarter == 0)
            {
                lastQuarter = 1;
            }
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            this.SelectedSearchYear = DateTime.UtcNow.Year.ToString();
            this.YearmonthQuartTrue = true;
            this.EnableYearDropDown = true;
            this.EnableMonthDropDown = true;
            this.EnableQuarterDropDown = true;
            this.SelectedSearchQuarter = lastQuarter.ToString();

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

            }

            base.OnPropertyChanged(name);

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
                    value.FieldValue = this.ShowAllTrue.ToString();
                    SearchValues.Add(value);
                }
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;

                var results = gstAndVatReportsRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.GstVatSummary), "GstVatSummaryReport");
                if (Count != 0)
                {
                    GstAndVatPaidEntityList = gstAndVatReportsRepository.getGstAndVAtPaidDetails(jsonSearch);
                    TotalTaxInvoiceAmountS = Convert.ToString(GstAndVatPaidEntityList.Where(x => x.TaxDescriptionS != "Total").Sum(x => x.TaxInvoiceAmountS));
                    TotalTaxCollectedS = Convert.ToString(GstAndVatPaidEntityList.Where(x => x.TaxDescriptionS != "Total").Sum(x => x.TaxCollectedS));
                    this.ShowSelectedCount = GstAndVatPaidEntityList.Where(x => x.TaxDescriptionS != "Total").Count();
                }

            }

        }
        public void NavigateToRespectiveInvoiceNumberForSupplier(object param)
        {
            if (param != null)
            {
                var obj = param.ToString();
                var InvoiceNumber = obj.Substring(0, 2);
                var Invoice = obj;
                if (InvoiceNumber.Equals("PI"))
                {
                    SharedValues.ScreenCheckName = "Purchases Invoice(Products and Services)";
                    SharedValues.ViewName = "Purchase Invoice (Products & Services)";
                    var accessitem = itemlist.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = Invoice;
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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
                    }
                }
                else if (InvoiceNumber.Equals("PM"))
                {
                    SharedValues.ScreenCheckName = "Pay Money";
                    SharedValues.ViewName = "Pay Money";
                    var accessitem = itemlist.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.getValue = "PayMoneyTab";
                        SharedValues.NewClick = Invoice;

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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                else if (InvoiceNumber.Equals("DN"))
                {
                    SharedValues.ScreenCheckName = "Debit Note";
                    SharedValues.ViewName = "Debit Note";
                    var accessitem = itemlist.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = Invoice;
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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                else if (InvoiceNumber.Equals("JO"))
                {
                    SharedValues.ScreenCheckName = "Journal";
                    SharedValues.ViewName = "Journal";
                    var accessitem = itemlist.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = Invoice;
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
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Journal (JO) Form");
                    }
                    else
                    {
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
            }
        }
        public void NavigateToSupplierForm(object param)
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Suppliers Details";
            var accessitem = itemlist.AddToList();
            if (accessitem == true)
            {
                if (param != null)
                {
                    List<object> values = new List<object>();
                    values = param as List<object>;
                    var SupplierID = values[0].ToString();

                    SharedValues.getValue = SupplierID;
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

        }

        public void NavigateToCustomerForm(object param)
        {
            SharedValues.ScreenCheckName = "Customers Details";
            SharedValues.ViewName = "Customers Details";
            var accessitem = itemlist.AddToList();
            if (accessitem == true)
            {
                if (param != null)
                {
                    List<object> values = new List<object>();
                    values = param as List<object>;
                    var CustomerID = values[0].ToString();
                    SharedValues.getValue = CustomerID;
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
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        public void NavigateToRespectiveInvoiceNumberForCustomer(object param)
        {

            if (param != null)
            {
                var sub = param.ToString();
                var InvoiceNumber = sub.Substring(0, 2);
                var Invoice = sub;

                if (InvoiceNumber.Equals("SI"))
                {
                    SharedValues.ScreenCheckName = "Sales Invoice";
                    SharedValues.ViewName = "Sales Invoice";
                    var accessitem = itemlist.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = Invoice;
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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                else if (InvoiceNumber.Equals("CN"))
                {
                    SharedValues.ScreenCheckName = "Credit Note";
                    SharedValues.ViewName = "Credit Note";
                    var accessitem = itemlist.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = Invoice;
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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                else if (InvoiceNumber.Equals("JO"))
                {
                    SharedValues.ScreenCheckName = "Journal";
                    SharedValues.ViewName = "Journal";
                    var accessitem = itemlist.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = Invoice;
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
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Journal (JO) Form");
                    }
                    else
                    {
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                else if (InvoiceNumber.Equals("RM"))
                {
                    SharedValues.ScreenCheckName = "Recieve Money";
                    SharedValues.ViewName = "Receive Money";
                    var accessitem = itemlist.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.NewClick = Invoice;
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
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
            }
        }
        void ShowAll(object param)
        {
            this.YearmonthQuartTrue = false;//added after client feedback
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = 0;
            else
                this.ShowSelectedCount = 0;

            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            //GstAndVatPaidEntityList = gstAndVatReportsRepository.getGstAndVAtPaidDetails(jsonSearch);
            //TotalTaxInvoiceAmountS = Convert.ToString(GstAndVatPaidEntityList.Where(x => x.TaxDescriptionS != "Total").Sum(x => x.TaxInvoiceAmountS));
            //TotalTaxCollectedS = Convert.ToString(GstAndVatPaidEntityList.Where(x => x.TaxDescriptionS != "Total").Sum(x => x.TaxCollectedS));
            //this.ShowSelectedCount = GstAndVatPaidEntityList.Where(x => x.TaxDescriptionS != "Total").Count();


            Mouse.OverrideCursor = Cursors.Wait;
            Search(null);
            Mouse.OverrideCursor = null;
        }
        #endregion
    }
}