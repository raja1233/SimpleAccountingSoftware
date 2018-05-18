﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.ViewModel
{
    using Common;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Newtonsoft.Json;
    using SASClient.CloseRequest;
    using SDN.UI.Entities.Purchase;
    using Services;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using UI.Entities;
    using UI.Entities.Puchase;
    using View;

    public class SupplierHistoryViewModel : SupplierHistoryEntity
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
        /// Initializes a new instance of the <see cref="SupplierHistoryViewModel"/> class.
        /// </summary>
        public SupplierHistoryViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
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
            CloseCommand = new DelegateCommand(Close);
            //NavigaetoPurchaseCommand = new RelayCommand(NavigatetoPurchaseInvoice);
            YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
            CalendarSelectionCommand = new RelayCommand(OnCalendarSelection);
        }

        public SupplierHistoryViewModel()
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
        public RelayCommand NavigaetoPurchaseCommand { get; set; }
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
            //foreach (var item in this.SupplierHistory)
            //{
            //    //item.InvoiceAmount = item.InvoiceAmountIncGST;
            //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountIncGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.SupplierHistory = DefaultList.Where(x => x.ExcIncGST == true).ToList();
            //else
            //    this.SupplierHistory = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            ISupplierHistoryRepository purchaseRepository = new SupplierHistoryRepository();
            this.SupplierHistory = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData, this.IncludingGSTTrue).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.SupplierHistory.Count();
            else
                this.ShowSelectedCount = 0;
            this.SupplierHistorycmb = this.SupplierHistory.OrderBy(x => x.SupplierName).ToList();
            this.SupplierHistorycmbCredit = this.SupplierHistorycmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
            this.SupplierHistorycmbSup = this.SupplierHistory.GroupBy(x => x.SupplierName).Select(y => y.First()).OrderBy(x => x.SupplierName).Distinct().ToList();
            this.SupplierHistorycmbInv = this.SupplierHistory.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
            DefaultList = this.SupplierHistorycmb;

            Mouse.OverrideCursor = null;
        }
        void showexcGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);

            ISupplierHistoryRepository purchaseRepository = new SupplierHistoryRepository();
            this.SupplierHistory = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData, this.IncludingGSTTrue).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.SupplierHistory.Count();
            else
                this.ShowSelectedCount = 0;
            this.SupplierHistorycmb = this.SupplierHistory.OrderBy(x => x.SupplierName).ToList();
            this.SupplierHistorycmbCredit = this.SupplierHistorycmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
            this.SupplierHistorycmbSup = this.SupplierHistory.GroupBy(x => x.SupplierName).Select(y => y.First()).OrderBy(x => x.SupplierName).Distinct().ToList();
            this.SupplierHistorycmbInv = this.SupplierHistory.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
            DefaultList = this.SupplierHistorycmb;

            Mouse.OverrideCursor = null;
        }
        void NavigatetoSupplier(object param)
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Suppliers Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (param != null)
            {
                string obj = param.ToString();
                SharedValues.getValue = obj;
            }
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
        void NavigatetoSupplierView(object param)
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Suppliers Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (param != null)
            {
                string obj = param.ToString();
                SharedValues.NewClick = obj;
            }

            var mainview = ServiceLocator.Current.GetInstance<SupplierDetailView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoice Form");
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
            this.SupplierHistory = FullPQList.OrderBy(x => x.SupplierName).ToList();
            this.SupplierHistorycmb = FullPQList.OrderBy(x => x.SupplierName).ToList();
            this.SupplierHistorycmbCredit = this.SupplierHistorycmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
            this.SupplierHistorycmbSup = this.SupplierHistory.GroupBy(x => x.SupplierName).Select(y => y.First()).OrderBy(x => x.SupplierName).Distinct().ToList();
            this.SupplierHistorycmbInv = this.SupplierHistory.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.SupplierHistory.Count();
            else
                this.ShowSelectedCount = 0;
            this.SelectedSearchEndDate = null;
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.SelectedSearchStartDate = null;
            this.SelectedSearchEndDate = null;
            if (this.IncludingGSTTrue == true)
                this.SupplierHistory = FullPQList.Where(x => x.ExcIncGST == true).OrderBy(x => x.SupplierName).ToList();
            else
                this.SupplierHistory = FullPQList.Where(x => x.ExcIncGST == false).OrderBy(x => x.SupplierName).ToList();
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
                //this.ShowSelectedTrue = true;
                //this.ShowAllTrue = false;
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
                if (this.SelectedSearchStartDate != null && this.SelectedSearchEndDate != null)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "StartDate";
                    //value.FieldValue = this.SelectedSearchStartDate.ToString();
                    value.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchStartDate);
                    SearchValues.Add(value);
                    //string[] value = new string[2];
                    SearchEntity value1 = new SearchEntity();
                    value1.FieldName = "EndDate";
                    //value1.FieldValue = this.SelectedSearchEndDate.ToString();
                    value1.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchEndDate);
                    SearchValues.Add(value);
                    SearchValues.Add(value1);
                }
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;

                ISupplierHistoryRepository purchaseRepository = new SupplierHistoryRepository();
                var results = purchaseRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.SupplierHistory), "SupplierHistory_List");
                if (Count != 0)
                {
                    this.SupplierHistory = purchaseRepository.GetAllSalesInvoiceJson(jsonSearch, this.IncludingGSTTrue).ToList();
                    //changedateformat(this.SupplierHistory);
                    changeNumberformat(this.SupplierHistory);

                }

                this.SupplierHistorycmb = this.SupplierHistory.OrderBy(x => x.SupplierName).ToList();
                this.SupplierHistorycmbCredit = this.SupplierHistorycmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
                this.SupplierHistorycmbSup = this.SupplierHistory.GroupBy(x => x.SupplierName).Select(y => y.First()).OrderBy(x => x.SupplierName).Distinct().ToList();
                this.SupplierHistorycmbInv = this.SupplierHistory.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
                if (this.ShowAllTrue == true)
                    this.ShowSelectedCount = 0;
                else
                    this.ShowSelectedCount = this.SupplierHistory.Count();
                DefaultList = this.SupplierHistorycmb;

                TotalInvoiceAmount = Convert.ToString(SupplierHistory.Sum(e => e.InvoiceAmountValue));
                TotalCCDAmount = Convert.ToString(SupplierHistory.Sum(e => e.TotalAmount));
                this.TotalCusM1 = Convert.ToString(SupplierHistory.Sum(e => e.TotalM1));
                this.TotalCusM2 = Convert.ToString(SupplierHistory.Sum(e => e.TotalM2));
                this.TotalCusM3 = Convert.ToString(SupplierHistory.Sum(e => e.TotalM3));
                this.TotalCusQuarter = Convert.ToString(SupplierHistory.Sum(e => e.QuarterTotal));
                this.TotalCusYear = Convert.ToString(SupplierHistory.Sum(e => e.YearTotal));
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
        List<SupplierHistoryEntity> DefaultList = new List<SupplierHistoryEntity>();
        List<SupplierHistoryEntity> FullPQList = new List<SupplierHistoryEntity>();
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {
            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 45;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SIGridHeight = minHeight;
            RefreshData();
        }

        private void RefreshData()
        {
            ISupplierHistoryRepository purchaseRepository = new SupplierHistoryRepository();
            // this.DateFormat = purchaseRepository.GetDateFormat();
            //this.ShowAllCount = purchaseRepository.GetAllPurchaseInvoice().Count();
            GetOptionsandTaxValues();
            this.JsonData = purchaseRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.SupplierHistory));
            this.SupplierHistory = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData, this.IncludingGSTTrue).ToList();
            this.SupplierHistorycmb = purchaseRepository.GetAllSalesInvoice().OrderBy(x => x.SupplierName).ToList();
            this.ShowSelectedCount = this.SupplierHistory.Count();
            this.SupplierHistorycmbCredit = this.SupplierHistorycmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
            this.SupplierHistorycmbSup = this.SupplierHistory.GroupBy(x => x.SupplierName).Select(y => y.First()).OrderBy(x => x.SupplierName).Distinct().ToList();
            this.SupplierHistorycmbSup = this.SupplierHistory.GroupBy(x => x.SupplierName).Select(y => y.First()).OrderBy(x => x.SupplierName).Distinct().ToList();
            this.SupplierHistorycmbInv = this.SupplierHistory.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
            this.YearRange = purchaseRepository.GetYearRange().ToList();

            DefaultList = this.SupplierHistory;
            FullPQList = this.SupplierHistorycmb;
            //this.ShowAllCount = this.SupplierHistorycmb.Count();
            SetDefaultSearchSelection(this.JsonData);
            var Updateddate = this.SupplierHistorycmb.Max(x => x.CreatedDate);
            string date = this.DateFormat as string;
            this.LastUpdateDate = Convert.ToDateTime(Updateddate).ToString(date);

            TotalInvoiceAmount = Convert.ToString(SupplierHistory.Sum(e => e.InvoiceAmountValue));
            TotalCCDAmount = Convert.ToString(SupplierHistory.Sum(e => e.TotalAmount));
            this.TotalCusM1 = Convert.ToString(SupplierHistory.Sum(e => e.TotalM1));
            this.TotalCusM2 = Convert.ToString(SupplierHistory.Sum(e => e.TotalM2));
            this.TotalCusM3 = Convert.ToString(SupplierHistory.Sum(e => e.TotalM3));
            this.TotalCusQuarter = Convert.ToString(SupplierHistory.Sum(e => e.QuarterTotal));
            this.TotalCusYear = Convert.ToString(SupplierHistory.Sum(e => e.YearTotal));
            //this.GetData(this.SelectedSearchSupplier);
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            ISupplierHistoryRepository purchaseRepository = new SupplierHistoryRepository();
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
                    //foreach (var item in this.SupplierHistory)
                    //{
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    //this.SupplierHistory = this.SupplierHistory.Where(x => x.ExcIncGST == true).ToList();
                }
                else
                {
                    this.IncludingGSTTrue = false;
                    this.IncludingGSTFalse = true;
                    int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.SupplierHistory)
                    //{
                    //    //item.InvoiceAmount = item.InvoiceAmountExcGST;
                    //    //item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountExcGST), decimalpoints).ToString();
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    if (this.SupplierHistory != null)
                        this.SupplierHistory = this.SupplierHistory.ToList();
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

        void changedateformat(List<SupplierHistoryEntity> entity)
        {
            try
            {
                string date = this.DateFormat as string;
                foreach (var item in entity)
                {
                    if (item.CreditCashDate != null && item.CreditCashDate != "")
                    {
                        var tempdate = Convert.ToDateTime(item.CreditCashDate).ToString(date);
                        item.CreditCashDate = tempdate.Replace('-', '/');
                    }
                    if (item.InvoiceDateDateTime != null)
                    {
                        var tempdate = Convert.ToDateTime(item.InvoiceDateDateTime).ToString(date);
                        item.InvoiceDate = tempdate.Replace('-', '/');
                    }
                    else
                        item.InvoiceDate = "";
                }
            }
            catch (Exception ex)
            {

            }
        }
        void changeNumberformat(List<SupplierHistoryEntity> entity)
        {
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            string date = this.DateFormat as string;
            foreach (var item in entity)
            {
                //item.QuotationAmount = item.QuotationAmountIncGST;
                if (item.InvoiceAmount != null && item.InvoiceAmount != "")
                    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                if (item.CreditCashAmount != null && item.CreditCashAmount != "")
                    item.CreditCashAmount = Math.Round(Convert.ToDouble(item.CreditCashAmount), decimalpoints).ToString();
                if (item.CreditCashDate != null && item.CreditCashDate != "")
                {
                    var tempdate = Convert.ToDateTime(item.CreditCashDate).ToString(date);
                    item.CreditCashDate = tempdate.Replace('-', '/');
                }
                if (item.InvoiceDateDateTime != null)
                {
                    var tempdate = Convert.ToDateTime(item.InvoiceDateDateTime).ToString(date);
                    item.InvoiceDate = tempdate.Replace('-', '/');
                }
                else
                    item.InvoiceDate = "";

            }
        }
        public void SetDefaultSearchSelection(string jsondata)
        {
            if (jsondata != null && jsondata != "[]")
            {
                //this.ShowSelectedTrue = true;
                //this.ShowAllTrue = false;
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);
                foreach (var item in objResponse1)
                {
                    switch (item.FieldName)
                    {
                        case "Year":
                            this.SelectedSearchYear = item.FieldValue;
                            this.YearmonthQuartTrue = true;
                            this.StartEndDateTrue = false;
                            this.EnableYearDropDown = true;
                            this.EnableMonthDropDown = true;
                            this.EnableQuarterDropDown = true;
                            break;
                        case "Quarter":
                            this.SelectedSearchQuarter = item.FieldValue;
                            this.YearmonthQuartTrue = true;
                            this.StartEndDateTrue = false;
                            this.EnableYearDropDown = true;
                            this.EnableMonthDropDown = true;
                            this.EnableQuarterDropDown = true;
                            break;
                        case "Month":
                            this.SelectedSearchMonth = item.FieldValue;
                            this.YearmonthQuartTrue = true;
                            this.StartEndDateTrue = false;
                            this.EnableYearDropDown = true;
                            this.EnableMonthDropDown = true;
                            this.EnableQuarterDropDown = true;
                            break;
                        case "StartDate":
                            this.SelectedSearchStartDate = Convert.ToDateTime(item.FieldValue);
                            this.YearmonthQuartTrue = false;
                            this.StartEndDateTrue = true;
                            this.EnableYearDropDown = false;
                            this.EnableMonthDropDown = false;
                            this.EnableQuarterDropDown = false;
                            break;
                        case "EndDate":
                            this.SelectedSearchEndDate = Convert.ToDateTime(item.FieldValue);
                            this.YearmonthQuartTrue = false;
                            this.StartEndDateTrue = true;
                            this.EnableYearDropDown = false;
                            this.EnableMonthDropDown = false;
                            this.EnableQuarterDropDown = false;
                            break;
                    }
                }
                Search(null);
            }
            else
            {
                this.ShowAllTrue = true;
                this.ShowSelectedTrue = false;
                this.YearmonthQuartTrue = false;
                this.StartEndDateTrue = false;
                this.ShowSelectedCount = 0;
            }
        }
        public void LoadSearchResult(string customerName)
        {
            ISupplierHistoryRepository purchaseRepository = new SupplierHistoryRepository();
            this.ShowAllCount = purchaseRepository.GetAllSalesInvoice().Count();
            this.SupplierHistory = purchaseRepository.GetAllSalesInvoice().Where(x => x.SupplierName == customerName).ToList();
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
                    break;
                case "SelectedSearchPI_Status":
                    GetData(this.SelectedSearchPI_Status, "PI_Status");
                    break;
                case "SelectedCreditNoteNo":
                    GetData(this.SelectedCreditNoteNo, "CreditNote");
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

                    //case "SelectedSearchQuarter":
                    //    this.SelectedSearchMonth = null;
                    //    break;
                    //case "SelectedSearchMonth":
                    //    this.SelectedSearchQuarter = null;
                    //    break;
                    //case "SelectedSearchQNo":
                    //    GetData(this.SelectedSearchQNo , "Supplier");
                    //    break;
                    //case "SelectedSearchYear":
                    //    GetData(this.SelectedSearchYear, "SearchYear");
                    //    break;
                    //case "SelectedSearchQuater":
                    //    GetData(this.SelectedSearchQuater, "SearchQuater");
                    //    break;
                    //case "SelectedSearchMonth":
                    //    GetData(this.SelectedSearchMonth, "SearchMonth");
                    //    break;
                    //case "SelectedSearchStartDate":
                    //    GetData(this.SelectedSearchStartDate, "SearchStartDate");
                    //    break;
                    //case "SelectedSearchEndDate":
                    //    GetData(this.SelectedSearchEndDate, "SearchEndDate");
                    //    break;
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
                        this.FirstMonth = "Jan";
                        this.SecondMonth = "Feb";
                        this.ThirdMonth = "Mar";
                        this.QuarterName = "Quarter 1";
                        break;
                    case "2":
                        this.FirstMonth = "Apr";
                        this.SecondMonth = "May";
                        this.ThirdMonth = "Jun";
                        this.QuarterName = "Quarter 2";
                        break;
                    case "3":
                        this.FirstMonth = "Jul";
                        this.SecondMonth = "Aug";
                        this.ThirdMonth = "Sep";
                        this.QuarterName = "Quarter 3";
                        break;
                    case "4":
                        this.FirstMonth = "Oct";
                        this.SecondMonth = "Nov";
                        this.ThirdMonth = "Dec";
                        this.QuarterName = "Quarter 4";
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
            //ISupplierHistoryRepository purchaseRepository = new SupplierHistoryRepository();
            //var result = purchaseRepository.GetAllPurInvoice().ToList();
            if (SearchFilter != null || SearchFilter == string.Empty)
            {
                if (parameter == "Supplier")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.SupplierHistory = FullPQList.Where(x => (x.SupplierName == SearchFilter || x.InvoiceNo == SearchFilter)).ToList();
                    }
                    else
                    {
                        this.SupplierHistory = DefaultList.Where(x => (x.SupplierName == SearchFilter || x.InvoiceNo == SearchFilter)).ToList();
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
                            this.SupplierHistory = FullPQList.ToList();
                        else if (search == " Paid")
                        {
                            byte paid = Convert.ToByte(PI_Status.Paid);
                            this.SupplierHistory = FullPQList.Where(x => x.Status == paid).ToList();
                        }
                        else if (search == " Unpaid")
                        {
                            byte Unpaid = Convert.ToByte(PI_Status.UnPaid);
                            this.SupplierHistory = FullPQList.Where(x => x.Status == Unpaid).ToList();
                        }
                        else if (search == " Adjusted")
                        {
                            byte Adjusted = Convert.ToByte(PI_Status.Adjusted);
                            this.SupplierHistory = FullPQList.Where(x => x.Status == Adjusted).ToList();
                        }
                        else if (search == " Cancelled")
                        {
                            byte Cancelled = Convert.ToByte(PI_Status.Cancelled);
                            this.SupplierHistory = FullPQList.Where(x => x.Status == Cancelled).ToList();
                        }
                        else
                            this.SupplierHistory = FullPQList.ToList();
                    }
                    else
                    {
                        var search = SearchFilter.Split(':')[1];
                        if (search == " All")
                            this.SupplierHistory = DefaultList.ToList();
                        else if (search == " Paid")
                        {
                            byte paid = Convert.ToByte(PI_Status.Paid);
                            this.SupplierHistory = DefaultList.Where(x => x.Status == paid).ToList();
                        }
                        else if (search == " Unpaid")
                        {
                            byte Unpaid = Convert.ToByte(PI_Status.UnPaid);
                            this.SupplierHistory = DefaultList.Where(x => x.Status == Unpaid).ToList();
                        }
                        else if (search == " Adjusted")
                        {
                            byte Adjusted = Convert.ToByte(PI_Status.Adjusted);
                            this.SupplierHistory = DefaultList.Where(x => x.Status == Adjusted).ToList();
                        }
                        else if (search == " Cancelled")
                        {
                            byte Cancelled = Convert.ToByte(PI_Status.Cancelled);
                            this.SupplierHistory = DefaultList.Where(x => x.Status == Cancelled).ToList();
                        }
                        else
                            this.SupplierHistory = DefaultList.ToList();

                    }


                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }
                if (parameter == "CreditNote")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.SupplierHistory = FullPQList.Where(x => x.CreditNoteNo == SearchFilter).ToList();
                    }
                    else
                    {
                        this.SupplierHistory = DefaultList.Where(x => x.CreditNoteNo == SearchFilter).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }

                //if (parameter == "InvoiceNo")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SupplierHistory = DefaultList.Where(x => x.InvoiceNo == SearchFilter).ToList();
                //    DefaultList = DefaultList.Where(x => x.InvoiceNo == SearchFilter).ToList();
                //}
                //if (parameter == "SearchYear")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SupplierHistory = DefaultList.Where(x => x.CreatedDate.Value.Year.ToString() == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SupplierHistory = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SupplierHistory = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SupplierHistory = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SupplierHistory = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SupplierHistory = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                //}

            }
            else
            {
                if (this.ShowAllTrue == true)
                {
                    this.SupplierHistory = FullPQList.ToList();
                }
                else
                {
                    this.SupplierHistory = DefaultList.ToList();
                }

            }
            //changedateformat(SupplierHistory);
            //changeNumberformat(SupplierHistory);
            TotalInvoiceAmount = Convert.ToString(SupplierHistory.Sum(e => e.InvoiceAmountValue));
            TotalCCDAmount = Convert.ToString(SupplierHistory.Sum(e => e.TotalAmount));
            this.TotalCusM1 = Convert.ToString(SupplierHistory.Sum(e => e.TotalM1));
            this.TotalCusM2 = Convert.ToString(SupplierHistory.Sum(e => e.TotalM2));
            this.TotalCusM3 = Convert.ToString(SupplierHistory.Sum(e => e.TotalM3));
            this.TotalCusQuarter = Convert.ToString(SupplierHistory.Sum(e => e.QuarterTotal));
            this.TotalCusYear = Convert.ToString(SupplierHistory.Sum(e => e.YearTotal));
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
