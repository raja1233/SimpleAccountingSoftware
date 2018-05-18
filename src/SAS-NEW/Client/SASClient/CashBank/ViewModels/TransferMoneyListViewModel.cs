﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using SASClient.Accounts.Views;
using SASClient.CashBank.Services;
using SASClient.CashBank.Views;
using SASClient.CloseRequest;
using SDN.CashBank.Views;
using SDN.Common;
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
    public class TransferMoneyListViewModel : TransferMoneyListEntity
    {
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private List<SearchEntity> SearchValues;
        private string jsonSearch;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private int Count = 0;
        TransferMoneyListEntity allPosition = new TransferMoneyListEntity();
        StackList listitem = new StackList();

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
        /// Initializes a new instance of the <see cref="TransferMoneyListViewModel"/> class.
        /// </summary>
        public TransferMoneyListViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            SearchCommand = new RelayCommand(Search);
            ShowAllCommand = new RelayCommand(ShowAll);
            //ShowSelectedCommand = new RelayCommand(ShowSelected);

            ShowIncGSTCommand = new RelayCommand(showincGST);
            ShowExcGSTCommand = new RelayCommand(showexcGST);
            RefreshCommand = new RelayCommand(refreshcommand);
            CloseCommand = new DelegateCommand(Close);
            YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
            CalendarSelectionCommand = new RelayCommand(OnCalendarSelection);
            ShowProductCommand = new RelayCommand(ShowProduct);
            ShowServiceCommand = new RelayCommand(ShowService);
            ShowBothTrueCommand = new RelayCommand(ShowBothTrue);
            ShowIncludingTaxCommand = new RelayCommand(ShowIncludingTax);
            ShowExcludingTaxCommand = new RelayCommand(ShowExcludingTax);
            NavigateToTransferFormCommand = new RelayCommand(NavigateToTransferForm);
            NavigateToAccountCommand = new RelayCommand(NavigateToAccountView);
            ShowSummaryCommand = new RelayCommand(ShowSummary);
            ShowDetailCommand = new RelayCommand(ShowDetails);
            NavigaetoFormCommand = new RelayCommand(NavigaetoForm);

        }

        public TransferMoneyListViewModel()
        {
        }
        public ICommand CloseCommand { get; set; }
        public RelayCommand YearQuarterSelectedCommand { get; set; }
        public RelayCommand CalendarSelectionCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        //public RelayCommand ShowSelectedCommand { get; set; }
        public RelayCommand NavigateToAccountCommand { get; set; }
        public RelayCommand NavigateToTransferFormCommand { get; set; }
        public RelayCommand ShowIncGSTCommand { get; set; }
        public RelayCommand ShowExcGSTCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }

        public RelayCommand ShowProductCommand { get; set; }
        public RelayCommand ShowServiceCommand { get; set; }
        public RelayCommand ShowBothTrueCommand { get; set; }
        public RelayCommand ShowIncludingTaxCommand { get; set; }
        public RelayCommand ShowExcludingTaxCommand { get; set; }

        public RelayCommand ShowSummaryCommand { get; set; }
        public RelayCommand ShowDetailCommand { get; set; }
        public RelayCommand NavigaetoFormCommand { get; set; }


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
            //this.ShowSelectedTrue = true;
            this.SelectedSearchEndDate = null;
            this.SelectedSearchStartDate = null;
            this.StartEndDateTrue = false;
            this.EnableYearDropDown = true;
            this.EnableQuarterDropDown = true;
            this.EnableMonthDropDown = true;
            this.EnableEndDropDown = false;


        }
        void OnCalendarSelection(object param)
        {

            ShowAllTrue = false;
            //this.ShowSelectedTrue = true;
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.EnableYearDropDown = false;
            this.EnableQuarterDropDown = false;
            this.StartEndDateTrue = true;
            this.EnableMonthDropDown = false;
            //this.EnableEndDropDown = true;

        }//end

        void ShowSummary(object param)
        {

            ITransferMoneyListRepository purchaseRepository = new TransferMoneyListRepository();
            this.TransferMoneyList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData).ToList();
            DefaultList = this.TransferMoneyList;
            this.TransferMoneyListCash = this.TransferMoneyList.OrderBy(x => x.CashChequeNo).ToList();
            this.TransferMoneyListFrom = this.TransferMoneyList.GroupBy(x => x.FromAccountName).Select(g => g.First()).OrderBy(x => x.FromAccountName).ToList();
            this.TransferMoneyListTo = this.TransferMoneyList.GroupBy(x => x.ToAccountName).Select(g => g.First()).OrderBy(x => x.ToAccountName).ToList();

            Mouse.OverrideCursor = null;
        }
        void ShowDetails(object param)
        {

            Search(null);
            ITransferMoneyListRepository purchaseRepository = new TransferMoneyListRepository();
            this.TransferMoneyList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData).ToList();
            DefaultList = this.TransferMoneyList;
            this.TransferMoneyListCash = this.TransferMoneyList.OrderBy(x => x.CashChequeNo).ToList();
            this.TransferMoneyListFrom = this.TransferMoneyList.GroupBy(x => x.FromAccountName).Select(g => g.First()).OrderBy(x => x.FromAccountName).ToList();
            this.TransferMoneyListTo = this.TransferMoneyList.GroupBy(x => x.ToAccountName).Select(g => g.First()).OrderBy(x => x.ToAccountName).ToList();

            Mouse.OverrideCursor = null;
        }

        void showincGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //foreach (var item in this.TransferMoneyList)
            //{
            //    //item.InvoiceAmount = item.InvoiceAmountIncGST;
            //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountIncGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.TransferMoneyList = DefaultList.Where(x => x.ExcIncGST == true).ToList();
            //else
            //    this.TransferMoneyList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            ITransferMoneyListRepository purchaseRepository = new TransferMoneyListRepository();
            this.TransferMoneyList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData).ToList();
            DefaultList = this.TransferMoneyList;
            this.TransferMoneyListCash = this.TransferMoneyList.OrderBy(x => x.CashChequeNo).ToList();
            this.TransferMoneyListFrom = this.TransferMoneyList.GroupBy(x => x.FromAccountName).Select(g => g.First()).OrderBy(x => x.FromAccountName).ToList();
            this.TransferMoneyListTo = this.TransferMoneyList.GroupBy(x => x.ToAccountName).Select(g => g.First()).OrderBy(x => x.ToAccountName).ToList();

            //if (this.ShowAllTrue == false)
            //    this.ShowSelectedCount = this.TransferMoneyList.Count();
            //else
            //    this.ShowSelectedCount = 0;

            Mouse.OverrideCursor = null;
        }
        void showexcGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //foreach (var item in this.TransferMoneyList)
            //{
            //    //item.InvoiceAmount = item.InvoiceAmountExcGST;
            //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountExcGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.TransferMoneyList = DefaultList.Where(x => x.ExcIncGST == false).ToList();
            //else
            //    this.TransferMoneyList = FullPQList.Where(x => x.ExcIncGST == false).ToList();
            ITransferMoneyListRepository purchaseRepository = new TransferMoneyListRepository();
            this.TransferMoneyList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData).ToList();
            DefaultList = this.TransferMoneyList;
            this.TransferMoneyListCash = this.TransferMoneyList.OrderBy(x => x.CashChequeNo).ToList();
            this.TransferMoneyListFrom = this.TransferMoneyList.GroupBy(x => x.FromAccountName).Select(g => g.First()).OrderBy(x => x.FromAccountName).ToList();
            this.TransferMoneyListTo = this.TransferMoneyList.GroupBy(x => x.ToAccountName).Select(g => g.First()).OrderBy(x => x.ToAccountName).ToList();

            //if (this.ShowAllTrue == false)
            //    this.ShowSelectedCount = this.TransferMoneyList.Count();
            //else
            //    this.ShowSelectedCount = 0;

            Mouse.OverrideCursor = null;
        }

        void NavigateToTransferForm(object param)
        {
            if (param != null)
            {
                SharedValues.ScreenCheckName = "Transfer Money";
                SharedValues.ViewName = "Transfer Money";
                var accessitem = listitem.AddToList();
                if (accessitem == true)
                {
                    string obj = param.ToString();
                SharedValues.NewClick = obj;
                SharedValues.getValue = "TransferMoneyTab";
            }
            var mainview = ServiceLocator.Current.GetInstance<TransferMoneyView>();
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Transfer Money Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
            }
        }
        void NavigaetoForm(object param)
        {
            if (param != null)
            {
                SharedValues.ScreenCheckName = "Transfer Money";
                SharedValues.ViewName = "Transfer Money";
                var accessitem = listitem.AddToList();
                if (accessitem == true)
                {
                    string obj = param.ToString();
                SharedValues.NewClick = obj;
                SharedValues.getValue = "TransferMoneyTab";
            }
            var mainview = ServiceLocator.Current.GetInstance<TransferMoneyView>();
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Transfer Money Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
            }
        }

        void NavigateToAccountView(object param)
        {
            if (param != null)
            {
                SharedValues.ScreenCheckName = "Accounts Details";
                SharedValues.ViewName = "Accounts Details";
                var accessitem = listitem.AddToList();
                if (accessitem == true)
                {
                    string obj = param.ToString();
                SharedValues.NewClick = obj;
                SharedValues.getValue = "AccountFormTab";
            }
            var mainview = ServiceLocator.Current.GetInstance<AccountsDetailsView>();
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Accounts Details Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+ "@ Simple Accounting Software Pte Ltd");
            }
        }

        void ShowAll(object param)
        {
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.SelectedSearchStartDate = null;
            this.SelectedSearchEndDate = null;
            //this.ShowSelectedCount = 0;
            this.ShowAllTrue = true;
            Search(null);

            Mouse.OverrideCursor = null;
        }
        void ShowProduct(object param)
        {
            this.PandS = 1;
            Search(null);

            Mouse.OverrideCursor = null;
        }
        void ShowService(object param)
        {

            this.PandS = 2;
            Search(null);

            Mouse.OverrideCursor = null;
        }
        void ShowBothTrue(object param)
        {

            this.PandS = 0;
            Search(null);

            Mouse.OverrideCursor = null;
        }
        void ShowExcludingTax(object param)
        {

            this.IncludingGSTTrue = false;
            Search(null);

            Mouse.OverrideCursor = null;
        }
        void ShowIncludingTax(object param)
        {

            this.IncludingGSTTrue = true;
            Search(null);

            Mouse.OverrideCursor = null;
        }

        //void ShowSelected(object param)
        //{
        //    this.ShowAllTrue = false;
        //    Search(null);

        //    Mouse.OverrideCursor = null;
        //}
        void Search(object param)
        {

            if (Count != 0)
            {
                SearchValues = new List<SearchEntity>();
                if (this.SelectedSearchYear != null || this.SelectedSearchYear == string.Empty)
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

                if (this.SelectedSearchQuarter != null || this.SelectedSearchQuarter == string.Empty)
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

                if (this.SelectedSearchMonth != null || this.SelectedSearchMonth == string.Empty)
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
                if (this.PandS != null)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "PandS";
                    value.FieldValue = this.PandS.ToString();
                    SearchValues.Add(value);
                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "PandS";
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
                    value.FieldValue = "false";
                    SearchValues.Add(value);
                }
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;

                ITransferMoneyListRepository purchaseRepository = new TransferMoneyListRepository();
                var results = purchaseRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.TransferMoneyList), "PandS_Sold_List");
                if (Count != 0)
                {
                    this.TransferMoneyList = purchaseRepository.GetAllSalesInvoiceJson(jsonSearch).ToList();
                    DefaultList = this.TransferMoneyList;
                    this.TransferMoneyListCash = this.TransferMoneyList.OrderBy(x => x.CashChequeNo).ToList();
                    this.TransferMoneyListFrom = this.TransferMoneyList.GroupBy(x => x.FromAccountName).Select(g => g.First()).OrderBy(x => x.FromAccountName).ToList();
                    this.TransferMoneyListTo = this.TransferMoneyList.GroupBy(x => x.ToAccountName).Select(g => g.First()).OrderBy(x => x.ToAccountName).ToList();

                    this.TotalAmount = Convert.ToString(this.TransferMoneyList.Sum(e => e.Amount));

                }


                //if (this.ShowAllTrue == true)
                //    this.ShowSelectedCount = this.ShowSelectedCount;
                //else
                //    this.ShowSelectedCount = this.TransferMoneyList.Count();

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
        List<TransferMoneyListEntity> DefaultList = new List<TransferMoneyListEntity>();
        List<TransferMoneyListEntity> FullPQList = new List<TransferMoneyListEntity>();
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {

            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 75;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.TransferMoneyListGridHeight = minHeight;
            RefreshData();
        }

        private void RefreshData()
        {
            ITransferMoneyListRepository purchaseRepository = new TransferMoneyListRepository();
            this.DateFormat = purchaseRepository.GetDateFormat();
            this.ShowAllCount = purchaseRepository.GetAllSalesInvoice().Count();
            GetOptionsandTaxValues();
            this.AllCount = purchaseRepository.getTotalCount(Convert.ToInt32(ScreenId.TransferMoneyList));
            this.JsonData = purchaseRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.TransferMoneyList));

            this.TransferMoneyList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData).ToList();
            DefaultList = this.TransferMoneyList;
            this.TransferMoneyListCash = this.TransferMoneyList.OrderBy(x => x.CashChequeNo).ToList();
            this.TransferMoneyListFrom = this.TransferMoneyList.GroupBy(x => x.FromAccountName).Select(g => g.First()).OrderBy(x => x.FromAccountName).ToList();
            this.TransferMoneyListTo = this.TransferMoneyList.GroupBy(x => x.ToAccountName).Select(g => g.First()).OrderBy(x => x.ToAccountName).ToList();

            this.TotalAmount = Convert.ToString(this.TransferMoneyList.Sum(e => e.Amount));


            if (this.JsonData != null)
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                if (objResponse1[6].FieldValue == "True")
                {
                    this.ShowAllTrue = true;
                    //this.ShowSelectedTrue = false;
                    this.YearmonthQuartTrue = true;
                    this.StartEndDateTrue = false;
                }
            }
            else
            {
                this.ShowAllTrue = true;
                //this.ShowSelectedTrue = false;
                this.YearmonthQuartTrue = true;
                this.StartEndDateTrue = false;
            }

            //this.ShowSelectedCount = this.TransferMoneyList.Count();

            this.YearRange = purchaseRepository.GetYearRange().ToList();

            SetDefaultSearchSelection();

        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            ITransferMoneyListRepository purchaseRepository = new TransferMoneyListRepository();
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
                    //foreach (var item in this.TransferMoneyList)
                    //{
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    //this.TransferMoneyList = this.TransferMoneyList.Where(x => x.ExcIncGST == true).ToList();
                }
                else
                {
                    this.IncludingGSTTrue = false;
                    this.IncludingGSTFalse = true;
                    int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.TransferMoneyList)
                    //{
                    //    //item.InvoiceAmount = item.InvoiceAmountExcGST;
                    //    //item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountExcGST), decimalpoints).ToString();
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    if (this.TransferMoneyList != null)
                        this.TransferMoneyList = this.TransferMoneyList.ToList();
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

        void changedateformat(List<TransferMoneyListEntity> entity)
        {
            //    try
            //    {
            //        string date = this.DateFormat as string;
            //        foreach (var item in entity)
            //        {
            //            if (item.CreditCashDate != null && item.CreditCashDate != "")
            //            {
            //                var tempdate = Convert.ToDateTime(item.CreditCashDate).ToString(date);
            //                item.CreditCashDate = tempdate.Replace('-', '/');
            //            }
            //            if (item.InvoiceDateDateTime != null)
            //            {
            //                var tempdate = Convert.ToDateTime(item.InvoiceDateDateTime).ToString(date);
            //                item.InvoiceDate = tempdate.Replace('-', '/');
            //            }
            //            else
            //                item.InvoiceDate = "";
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //    }
        }
        void changeNumberformat(List<TransferMoneyListEntity> entity)
        {
            //int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //string date = this.DateFormat as string;
            //foreach (var item in entity)
            //{
            //    //item.QuotationAmount = item.QuotationAmountIncGST;
            //    if (item.InvoiceAmount != null && item.InvoiceAmount != "")
            //        item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
            //    if (item.CreditCashAmount != null && item.CreditCashAmount != "")
            //        item.CreditCashAmount = Math.Round(Convert.ToDouble(item.CreditCashAmount), decimalpoints).ToString();
            //    if (item.CreditCashDate != null && item.CreditCashDate != "")
            //    {
            //        var tempdate = Convert.ToDateTime(item.CreditCashDate).ToString(date);
            //        item.CreditCashDate = tempdate.Replace('-', '/');
            //    }
            //    if (item.InvoiceDateDateTime != null)
            //    {
            //        var tempdate = Convert.ToDateTime(item.InvoiceDateDateTime).ToString(date);
            //        item.InvoiceDate = tempdate.Replace('-', '/');
            //    }
            //    else
            //        item.InvoiceDate = "";

            //}
        }
        //public void SetDefaultSearchSelection(string jsondata)
        //{
        //    if (jsondata != null && jsondata != "[]")
        //    {
        //        //this.ShowSelectedTrue = true;
        //        //this.ShowAllTrue = false;
        //        var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);
        //        foreach (var item in objResponse1)
        //        {
        //            switch (item.FieldName)
        //            {
        //                case "Year":
        //                    if (!string.IsNullOrWhiteSpace(item.FieldValue) && item.FieldValue != "0")
        //                    {
        //                        this.SelectedSearchYear = item.FieldValue;
        //                        this.YearmonthQuartTrue = true;
        //                        this.StartEndDateTrue = false;
        //                        this.EnableYearDropDown = true;
        //                        this.EnableMonthDropDown = true;
        //                        this.EnableQuarterDropDown = true;
        //                    }
        //                    else this.SelectedSearchYear = null;

        //                    break;
        //                case "Quarter":
        //                    if (!string.IsNullOrWhiteSpace(item.FieldValue) && item.FieldValue != "0")
        //                    {
        //                        this.SelectedSearchQuarter = item.FieldValue;
        //                        this.YearmonthQuartTrue = true;
        //                        this.StartEndDateTrue = false;
        //                        this.EnableYearDropDown = true;
        //                        this.EnableMonthDropDown = true;
        //                        this.EnableQuarterDropDown = true;
        //                    }
        //                    else this.SelectedSearchQuarter = null;
        //                    break;
        //                case "Month":
        //                    if (!string.IsNullOrWhiteSpace(item.FieldValue) && item.FieldValue != "0")
        //                    {
        //                        this.SelectedSearchMonth = item.FieldValue;
        //                        this.YearmonthQuartTrue = true;
        //                        this.StartEndDateTrue = false;
        //                        this.EnableYearDropDown = true;
        //                        this.EnableMonthDropDown = true;
        //                        this.EnableQuarterDropDown = true;
        //                    }
        //                    else this.SelectedSearchMonth = null;
        //                    break;
        //                case "StartDate":
        //                    if (!string.IsNullOrWhiteSpace(item.FieldValue) && item.FieldValue != "0")
        //                    {
        //                        this.SelectedSearchStartDate = Convert.ToDateTime(item.FieldValue);
        //                        this.YearmonthQuartTrue = false;
        //                        this.StartEndDateTrue = true;
        //                        this.EnableYearDropDown = false;
        //                        this.EnableMonthDropDown = false;
        //                        this.EnableQuarterDropDown = false;
        //                    }
        //                    else this.SelectedSearchStartDate = null;
        //                    break;
        //                case "EndDate":
        //                    if (!string.IsNullOrWhiteSpace(item.FieldValue) && item.FieldValue != "0")
        //                    {
        //                        this.SelectedSearchEndDate = Convert.ToDateTime(item.FieldValue);
        //                        this.YearmonthQuartTrue = false;
        //                        this.StartEndDateTrue = true;
        //                        this.EnableYearDropDown = false;
        //                        this.EnableMonthDropDown = false;
        //                        this.EnableQuarterDropDown = false;
        //                    }
        //                    else this.SelectedSearchEndDate = null;
        //                    break;

        //            }
        //        }

        //        Search(null);

        //    }
        //    else
        //    {
        //        this.ShowAllTrue = true;
        //        //this.ShowSelectedTrue = false;
        //        this.YearmonthQuartTrue = false;//change after feedback
        //        this.StartEndDateTrue = false;
        //        //this.ShowSelectedCount = 0;
        //    }
        //}
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
            this.StartEndDateTrue = false;
            this.EnableYearDropDown = true;
            this.EnableMonthDropDown = true;
            this.EnableQuarterDropDown = true;
            this.SelectedSearchQuarter = lastQuarter.ToString();
            
        }
        public void LoadSearchResult(string customerName)
        {
            ITransferMoneyListRepository purchaseRepository = new TransferMoneyListRepository();
            //this.ShowAllCount = purchaseRepository.GetAllSalesInvoice().Count();
            //this.TransferMoneyList = purchaseRepository.GetAllSalesInvoice().Where(x => x.CustomerName == customerName).ToList();
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
                case "SelectedCashChequeNo":
                    GetData(this.SelectedCashChequeNo, "SelectedCashChequeNo");
                    break;
                case "SelectedFromAccount":
                    GetData(this.SelectedFromAccount, "SelectedFromAccount");
                    break;
                case "SelectedToAccount":
                    GetData(this.SelectedToAccount, "SelectedToAccount");
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

            }

            base.OnPropertyChanged(name);
        }

        public void SetData(string SearchFilter, string parameter)
        {
            if (parameter == "Year" && SearchFilter != string.Empty && SearchFilter != null)
            {
                //this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.YearmonthQuartTrue = true;//change after client feedback on 22 may 2017
                Search(null);
            }
            if (parameter == "StartDate")
            {
                if (SearchFilter != string.Empty && SearchFilter != null)
                {
                    //this.ShowSelectedTrue = true;
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
                //this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.StartEndDateTrue = true;//added after feedback
                Search(null);
            }
            if (parameter == "Quarter" && SearchFilter != string.Empty && SearchFilter != null)
            {
                //this.ShowSelectedTrue = true;
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
                //this.ShowSelectedTrue = true;
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
            if (parameter == "SelectedCashChequeNo")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {
                    this.TransferMoneyList = DefaultList.Where(x => x.CashChequeNo == SearchFilter).ToList();
                }
                else
                {
                    this.TransferMoneyList = DefaultList.ToList();
                }
            }
            if (parameter == "SelectedFromAccount")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {
                    this.TransferMoneyList = DefaultList.Where(x => x.FromAccountName == SearchFilter).ToList();
                }
                else
                {
                    this.TransferMoneyList = DefaultList.ToList();
                }
            }
            if (parameter == "SelectedToAccount")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {
                    this.TransferMoneyList = DefaultList.Where(x => x.ToAccountName == SearchFilter).ToList();
                }
                else
                {
                    this.TransferMoneyList = DefaultList.ToList();
                }
            }
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