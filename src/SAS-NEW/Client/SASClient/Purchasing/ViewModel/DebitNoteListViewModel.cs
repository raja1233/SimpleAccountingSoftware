﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SASClient.CloseRequest;
using SASClient.HomeScreen.Views;
using SDN.Common;
using SDN.Purchasing.Services;
using SDN.Purchasing.View;
using SDN.UI.Entities;
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

namespace SDN.Purchasing.ViewModel
{
    public class DebitNoteListViewModel : DebitNoteListEntity
    {
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private List<SearchEntity> SearchValues;
        private string jsonSearch;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private int Count = 0;
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
        /// Initializes a new instance of the <see cref="DebitNoteListViewModel"/> class.
        /// </summary>
        public DebitNoteListViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
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
            NavigaetoPurchaseCommand = new RelayCommand(NavigatetoDebitNote);
            YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
            CalendarSelectionCommand = new RelayCommand(OnCalendarSelection);
            NavigaetoPurchaseInvoiceCommand = new RelayCommand(NavigaettoPurchaseInvoice);
            CloseCommand = new DelegateCommand(Close);
            NavigateToAuditTrialCommand = new RelayCommand(NavigateToAuditTrial);

        }

        public DebitNoteListViewModel()
        {
        }
        public RelayCommand NavigateToAuditTrialCommand { get; set; }

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
        public RelayCommand NavigaetoPurchaseCommand { get; set; }
        public RelayCommand NavigaetoPurchaseInvoiceCommand { get; set; }

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
            //foreach (var item in this.DebitNoteList)
            //{
            //    //item.DebitAmount = item.DebitAmountIncGST;
            //    item.DebitAmount = Math.Round(Convert.ToDouble(item.DebitAmountIncGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.DebitNoteList = DefaultList.Where(x => x.ExcIncGST == true).ToList();
            //else
            //    this.DebitNoteList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            IDebitNoteListRepository PurchaseRepository = new DebitNoteListRepository();
            this.DebitNoteList = PurchaseRepository.GetAllPurDebitJson(this.JsonData, this.IncludingGSTTrue).OrderBy(x => x.SupplierName).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.DebitNoteList.Count();
            else
                this.ShowSelectedCount = 0;
            this.DebitNoteListcmb = this.DebitNoteList.OrderBy(x => x.SupplierName).ToList();
            this.DebitNoteListcmbDebit = this.DebitNoteList.GroupBy(x => x.InvoiceNoCashChequeNo).Select(g => g.First()).Where(y => !string.IsNullOrEmpty(y.InvoiceNoCashChequeNo) || !string.IsNullOrWhiteSpace(y.InvoiceNoCashChequeNo)).OrderBy(x => x.InvoiceNoCashChequeNo).ToList();
            this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().OrderBy(x => x.SupplierName).ToList();
            this.DebitNoteListcmbInv = this.DebitNoteList.GroupBy(x => x.DebitNo).Select(y => y.First()).Distinct().OrderBy(x => x.SortDebitNoteNo).ToList();
            DefaultList = this.DebitNoteList;
            //changedateformat(this.DebitNoteList);
            //changeNumberformat(this.DebitNoteList);
            Mouse.OverrideCursor = null;
        }
        void showexcGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);

            IDebitNoteListRepository PurchaseRepository = new DebitNoteListRepository();
            this.DebitNoteList = PurchaseRepository.GetAllPurDebitJson(this.JsonData, this.IncludingGSTTrue).OrderBy(x => x.SupplierName).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.DebitNoteList.Count();
            else
                this.ShowSelectedCount = 0;
            this.DebitNoteListcmb = this.DebitNoteList.OrderBy(x => x.SupplierName).OrderBy(x => x.SupplierName).ToList();
            this.DebitNoteListcmbDebit = this.DebitNoteList.GroupBy(x => x.InvoiceNoCashChequeNo).Select(g => g.First()).Where(y => !string.IsNullOrEmpty(y.InvoiceNoCashChequeNo) || !string.IsNullOrWhiteSpace(y.InvoiceNoCashChequeNo)).OrderBy(x => x.InvoiceNoCashChequeNo).ToList();
            this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().OrderBy(x => x.SupplierName).OrderBy(x => x.SupplierName).ToList();
            this.DebitNoteListcmbInv = this.DebitNoteList.GroupBy(x => x.DebitNo).Select(y => y.First()).Distinct().OrderBy(x => x.SortDebitNoteNo).OrderBy(x => x.SupplierName).ToList();
            DefaultList = this.DebitNoteList;

            // changeNumberformat(this.DebitNoteList);
            Mouse.OverrideCursor = null;
        }
        void NavigatetoSupplier(object param)
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Suppliers Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                string obj = param.ToString();
            SharedValues.getValue = obj;
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        void NavigatetoDebitNote(object param)
        {
            SharedValues.ScreenCheckName = "Debit Note";
            SharedValues.ViewName = "Debit Note";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                string obj = param.ToString();
            SharedValues.NewClick = obj;
           
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<DebitNoteView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Debit Note Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        void NavigateToAuditTrial(object param)
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
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        void NavigaettoPurchaseInvoice(object param)
        {
            SharedValues.ScreenCheckName = "Purchases Invoice (P & S)";
            SharedValues.ViewName = "Purchase Invoice (Products & Services)";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PurchaseInvoiceTab";
            string obj = param.ToString();
            SharedValues.NewClick = obj;
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PurchaseInvoicePandSView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoice - Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        void ShowAll(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.YearmonthQuartTrue = false;//added after client feedback
            this.StartEndDateTrue = false;//added after client feedback
            this.DebitNoteList = FullPQList.OrderBy(x => x.SupplierName).ToList();
            this.DebitNoteListcmb = FullPQList.OrderBy(x => x.SupplierName).ToList();
            this.DebitNoteListcmbDebit = this.DebitNoteList.GroupBy(x => x.InvoiceNoCashChequeNo).Select(g => g.First()).Where(y => !string.IsNullOrEmpty(y.InvoiceNoCashChequeNo) || !string.IsNullOrWhiteSpace(y.InvoiceNoCashChequeNo)).OrderBy(x => x.InvoiceNoCashChequeNo).ToList();
            this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().OrderBy(x => x.SupplierName).ToList();
            this.DebitNoteListcmbInv = this.DebitNoteList.GroupBy(x => x.DebitNo).Select(y => y.First()).Distinct().OrderBy(x => x.SortDebitNoteNo).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.DebitNoteList.Count();
            else
                this.ShowSelectedCount = 0;
            this.SelectedSearchEndDate = null;
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.SelectedSearchStartDate = null;
            this.SelectedSearchEndDate = null;
            if (this.IncludingGSTTrue == true)
                this.DebitNoteList = FullPQList.Where(x => x.ExcIncGST == true).OrderBy(x => x.SupplierName).ToList();
            else
                this.DebitNoteList = FullPQList.Where(x => x.ExcIncGST == false).OrderBy(x => x.SupplierName).ToList();
            Search(null);
            Mouse.OverrideCursor = null;
        }
        void ShowSelected(object param)
        {
            Search(null);
        }
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
                    var year = Convert.ToInt32(this.SelectedSearchYear);
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
                if (this.SelectedSearchStartDate != null && this.SelectedSearchEndDate != null)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "StartDate";
                    value.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchStartDate);
                    //SearchValues.Add(value);
                    SearchEntity value1 = new SearchEntity();
                    value1.FieldName = "EndDate";
                    value1.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchEndDate);
                    SearchValues.Add(value);
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
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;
                IDebitNoteListRepository PurchaseRepository = new DebitNoteListRepository();
                var results = PurchaseRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.DebitNoteList), "Debit_Note_List");
                if (Count != 0)
                {
                    this.DebitNoteList = PurchaseRepository.GetAllPurDebitJson(jsonSearch, this.IncludingGSTTrue).OrderBy(x => x.SupplierName).ToList();
                    // changeNumberformat(this.DebitNoteList);
                }
                this.DebitNoteListcmb = this.DebitNoteList.OrderBy(x => x.SupplierName).ToList();
                this.DebitNoteListcmbDebit = this.DebitNoteList.GroupBy(x => x.InvoiceNoCashChequeNo).Select(g => g.First()).Where(y => !string.IsNullOrEmpty(y.InvoiceNoCashChequeNo) || !string.IsNullOrWhiteSpace(y.InvoiceNoCashChequeNo)).OrderBy(x => x.InvoiceNoCashChequeNo).ToList();
                this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().OrderBy(x => x.SupplierName).ToList();
                this.DebitNoteListcmbInv = this.DebitNoteList.GroupBy(x => x.DebitNo).Select(y => y.First()).Distinct().OrderBy(x => x.SortDebitNoteNo).ToList();
                if (this.ShowAllTrue == true)
                    this.ShowSelectedCount = this.DebitNoteList.Count();
                else
                    this.ShowSelectedCount = this.DebitNoteList.Count();
                DefaultList = this.DebitNoteList;
                this.TotalDebitAmount = Convert.ToString(DebitNoteList.Sum(e => e.DebitNoteAmount));
                this.TotalDebitCashAmount = Convert.ToString(DebitNoteListcmbDebit.Sum(e => e.InvoiceCashChequeAmount));
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
        List<DebitNoteListEntity> DefaultList = new List<DebitNoteListEntity>();
        List<DebitNoteListEntity> FullPQList = new List<DebitNoteListEntity>();
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {
            //GetOptionsData();
            // var height = System.Windows.SystemParameters.PrimaryScreenHeight;
            //if (height == 768)
            //    this.DNGridHeight = 415;
            //else if (height == 1024)
            //    this.DNGridHeight = 680;
            //else if (height == 1440)
            //    this.DNGridHeight = 956;
            //else if (height == 1800)
            //    this.DNGridHeight = 1195;
            //else
            //    this.DNGridHeight = 680;
            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 98;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.DNGridHeight = minHeight;
            RefreshData();
        }

        private void RefreshData()
        {
            IDebitNoteListRepository PurchaseRepository = new DebitNoteListRepository();
            // this.DateFormat = PurchaseRepository.GetDateFormat();
            this.ShowAllCount = PurchaseRepository.GetAllPurDebit().Count();
            GetOptionsandTaxValues();
            this.JsonData = PurchaseRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.DebitNoteList));
            this.DebitNoteList = PurchaseRepository.GetAllPurDebitJson(this.JsonData, this.IncludingGSTTrue).OrderBy(x => x.SupplierName).ToList();
            //this.DebitNoteListcmb = PurchaseRepository.GetAllPurchaseDebit().OrderBy(x => x.SupplierName).ToList();
            this.ShowSelectedCount = this.DebitNoteList.Count();
            this.DebitNoteListcmbDebit = this.DebitNoteList.GroupBy(x => x.InvoiceNoCashChequeNo).Select(g => g.First()).Where(y => !string.IsNullOrEmpty(y.InvoiceNoCashChequeNo) || !string.IsNullOrWhiteSpace(y.InvoiceNoCashChequeNo)).OrderBy(x => x.InvoiceNoCashChequeNo).ToList();
            this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().OrderBy(x => x.SupplierName).ToList();
            this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().OrderBy(x => x.SupplierName).ToList();
            this.DebitNoteListcmbInv = this.DebitNoteList.GroupBy(x => x.DebitNo).Select(y => y.First()).Distinct().OrderBy(x => x.SortDebitNoteNo).ToList();
            this.YearRange = PurchaseRepository.GetYearRange().ToList();

            //changeNumberformat(this.DebitNoteList);
            //changeNumberformat(this.DebitNoteListcmb);
            DefaultList = this.DebitNoteList;
            FullPQList = this.DebitNoteList;
            //this.ShowAllCount = this.DebitNoteListcmb.Count();
            SetDefaultSearchSelection();
            //var Updateddate = this.DebitNoteListcmb.Max(x => x.CreatedDate);
            //string date = this.DateFormat as string;
            //this.LastUpdateDate = Convert.ToDateTime(Updateddate).ToString(date);

            this.TotalDebitAmount = Convert.ToString(DebitNoteList.Sum(e => e.DebitNoteAmount));
            this.TotalDebitCashAmount = Convert.ToString(DebitNoteListcmbDebit.Sum(e => e.InvoiceCashChequeAmount));
           
            //this.GetData(this.SelectedSearchSupplier);
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            IDebitNoteListRepository PurchaseRepository = new DebitNoteListRepository();
            oData = PurchaseRepository.GetOptionSettings();
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

                }
                else
                {
                    this.IncludingGSTTrue = false;
                    this.IncludingGSTFalse = true;
                    int decimalpoints = Convert.ToInt32(DecimalPlaces);

                    if (this.DebitNoteList != null)
                        this.DebitNoteList = this.DebitNoteList.OrderBy(x => x.SupplierName).ToList();
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
            objDefaultTax = PurchaseRepository.GetDefaultTaxes();
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


        //void changeNumberformat(List<DebitNoteListEntity> entity)
        //{
        //    int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
        //    string date = this.DateFormat as string;
        //    foreach (var item in entity)
        //    {
        //        //item.QuotationAmount = item.QuotationAmountIncGST;
        //        if (item.DebitAmount != null && item.DebitNoteAmount != 0)
        //            item.DebitAmount = Math.Round(Convert.ToDouble(item.DebitNoteAmount), decimalpoints).ToString();
        //        if (item.DebitCashAmount != null && item.DebitCashAmount != "")
        //            item.DebitCashAmount = Math.Round(Convert.ToDouble(item.DebitCashAmount), decimalpoints).ToString();

        //        if (item.DebitCashDate != null && item.DebitCashDate != "")
        //        {
        //            var tempdate = Convert.ToDateTime(item.DebitCashDate).ToString(date);
        //            item.DebitCashDate = tempdate.Replace('-', '/');
        //        }
        //        if (item.DebitDateDateTime != null)
        //        {
        //            var tempdate = Convert.ToDateTime(item.DebitDateDateTime).ToString(date);
        //            item.DebitDate = tempdate.Replace('-', '/');
        //        }
        //        else
        //            item.DebitDate = "";

        //    }
        //}
        //public void SetDefaultSearchSelection(string jsondata)
        //{
        //    if (jsondata != null && jsondata != "[]")
        //    {
        //        this.ShowSelectedTrue = true;
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
        //                    else
        //                        this.SelectedSearchYear = null;
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
        //                case "ShowAll":
        //                    if (!string.IsNullOrWhiteSpace(item.FieldValue) && item.FieldValue != "0")
        //                    {
        //                        if (Convert.ToBoolean(item.FieldValue) == true)
        //                        {
        //                            this.ShowAllTrue = Convert.ToBoolean(item.FieldValue);
        //                            this.ShowSelectedTrue = false;
        //                            this.YearmonthQuartTrue = true;
        //                            this.StartEndDateTrue = false;
        //                            this.EnableYearDropDown = true;
        //                            this.EnableMonthDropDown = true;
        //                            this.EnableQuarterDropDown = true;
        //                            this.SelectedSearchYear = null;
        //                            this.SelectedSearchMonth = null;
        //                            this.SelectedSearchQuarter = null;
        //                            this.SelectedSearchStartDate = null;
        //                            this.SelectedSearchEndDate = null;
        //                        }
        //                        else
        //                        {
        //                            this.ShowAllTrue = false;
        //                            this.ShowSelectedTrue = true;
        //                        }

        //                    }
        //                    break;
        //            }
        //        }
        //        Search(null);
        //    }
        //    else
        //    {
        //        this.ShowAllTrue = true;
        //        this.ShowSelectedTrue = false;
        //        this.YearmonthQuartTrue = false;
        //        this.StartEndDateTrue = false;
        //        this.ShowSelectedCount = 0;
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
        public void LoadSearchResult(string Suppliername)
        {
            IDebitNoteListRepository PurchaseRepository = new DebitNoteListRepository();
            this.ShowAllCount = PurchaseRepository.GetAllPurDebit().Count();
            this.DebitNoteList = PurchaseRepository.GetAllPurDebit().Where(x => x.SupplierName == Suppliername).OrderBy(x => x.SupplierName).ToList();
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
                case "SelectedSearchSupName":
                    GetData(this.SelectedSearchSupName, "Supplier");
                    if (this.ShowAllTrue == true)
                        this.ShowSelectedCount = this.DebitNoteList.Count();
                    else
                        this.ShowSelectedCount = this.DebitNoteList.Count();
                    break;
                case "SelectedSearchPI_Status":
                    GetData(this.SelectedSearchPI_Status, "PI_Status");
                    if (this.ShowAllTrue == true)
                        this.ShowSelectedCount = this.DebitNoteList.Count();
                    else
                        this.ShowSelectedCount = this.DebitNoteList.Count();
                    break;
                case "SelectedDebitNoteNo":
                    GetData(this.SelectedDebitNoteNo, "DebitNote");
                    if (this.ShowAllTrue == true)
                        this.ShowSelectedCount = this.DebitNoteList.Count();
                    else
                        this.ShowSelectedCount = this.DebitNoteList.Count();
                    break;
                case "SelectedSearchQNo":
                    GetData(this.SelectedSearchQNo, "CashDebitNote");
                    if (this.ShowAllTrue == true)
                        this.ShowSelectedCount = this.DebitNoteList.Count();
                    else
                        this.ShowSelectedCount = this.DebitNoteList.Count();
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
                this.YearmonthQuartTrue = true;//added after feedback
                this.ShowAllTrue = false;
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
            //IDebitNoteListRepository PurchaseRepository = new DebitNoteListRepository();
            //var result = PurchaseRepository.GetAllPurDebit().ToList();
            if (SearchFilter != null || SearchFilter == string.Empty)
            {
                if (parameter == "Supplier")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.DebitNoteList = DefaultList.Where(x => (x.SupplierName == SearchFilter || x.DebitNo == SearchFilter)).OrderBy(x => x.SupplierName).ToList();
                    }
                    else
                    {
                        this.DebitNoteList = DefaultList.Where(x => (x.SupplierName == SearchFilter || x.DebitNo == SearchFilter)).OrderBy(x => x.SupplierName).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }
                 if (parameter == "PI_Status")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        var search = SearchFilter.Split(':')[1];
                        if (search == " All")
                            this.DebitNoteList = DefaultList.OrderBy(x => x.SupplierName).ToList();
                        else if (search == " Adjusted")
                        {
                            byte adjusted = Convert.ToByte(DN_Status.Adjusted);
                            this.DebitNoteList = DefaultList.Where(x => x.StatusString == "Adjusted").OrderBy(x => x.SupplierName).ToList();
                        }
                        else if (search == " Refunded")
                        {
                            byte refunded = Convert.ToByte(DN_Status.Refunded);
                            this.DebitNoteList = DefaultList.Where(x => x.StatusString == "Refunded").OrderBy(x => x.SupplierName).ToList();
                        }
                        else if (search == " UnAdjusted")
                        {
                            byte unAdjusted = Convert.ToByte(DN_Status.UnAdjusted);
                            this.DebitNoteList = DefaultList.Where(x => x.StatusString == "UnAdjusted").OrderBy(x => x.SupplierName).ToList();
                        }
                        else
                            this.DebitNoteList = DefaultList.OrderBy(x => x.SupplierName).ToList();
                    }
                    else
                    {
                        var search = SearchFilter.Split(':')[1];
                        if (search == " All")
                            this.DebitNoteList = DefaultList.OrderBy(x => x.SupplierName).ToList();
                        else if (search == " Adjusted")
                        {
                            byte adjusted = Convert.ToByte(DN_Status.Adjusted);
                            this.DebitNoteList = DefaultList.Where(x => x.StatusString == "Adjusted").OrderBy(x => x.SupplierName).ToList();
                        }
                        else if (search == " Refunded")
                        {
                            byte refunded = Convert.ToByte(DN_Status.Refunded);
                            this.DebitNoteList = DefaultList.Where(x => x.StatusString == "Refunded").OrderBy(x => x.SupplierName).ToList();
                        }
                        else if (search == " UnAdjusted")
                        {
                            byte unAdjusted = Convert.ToByte(DN_Status.UnAdjusted);
                            this.DebitNoteList = DefaultList.Where(x => x.StatusString == "UnAdjusted").OrderBy(x => x.SupplierName).ToList();
                        }
                        else
                            this.DebitNoteList = DefaultList.OrderBy(x => x.SupplierName).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }
                if (parameter == "DebitNote")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.DebitNoteList = DefaultList.Where(x => x.DebitNo == SearchFilter).OrderBy(x => x.SupplierName).ToList();
                    }
                    else
                    {
                        this.DebitNoteList = DefaultList.Where(x => x.DebitNo == SearchFilter).OrderBy(x => x.SupplierName).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }
                if (parameter == "CashDebitNote")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.DebitNoteList = DefaultList.Where(x => x.InvoiceNoCashChequeNo == SearchFilter).OrderBy(x => x.SupplierName).ToList();
                    }
                    else
                    {
                        this.DebitNoteList = DefaultList.Where(x => x.InvoiceNoCashChequeNo == SearchFilter).OrderBy(x => x.SupplierName).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }


            }
            else
            {
                if (this.ShowAllTrue == true)
                {
                    this.DebitNoteList = DefaultList.OrderBy(x => x.SupplierName).ToList();
                }
                else
                {
                    this.DebitNoteList = DefaultList.OrderBy(x => x.SupplierName).ToList();
                }
            }
            //changedateformat(DebitNoteList);
            //changeNumberformat(DebitNoteList);
            TotalDebitAmount = Convert.ToString(DebitNoteList.Sum(e => e.DebitNoteAmount));
            TotalDebitCashAmount = Convert.ToString(DebitNoteList.Sum(e => e.InvoiceCashChequeAmount));
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