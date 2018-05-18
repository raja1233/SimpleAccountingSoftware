using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Newtonsoft.Json;
using SASClient.Accounts.Services;
using SASClient.CashBank.Services;
using SASClient.CloseRequest;
using SASClient.Product.Services;
using SDN.Common;
using SDN.Product.Services;
using SDN.UI.Entities;
using SDN.UI.Entities.Accounts;
using SDN.UI.Entities.HomeScreen;
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
    public class AccountsTransactionsViewModel : AccountsTransactionsEntity
    {

        #region  "private property" 
        private int Count = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private ObservableCollection<FormNameEntity> _formlist = new ObservableCollection<FormNameEntity>();
        IStockCardListRepository purchaseRepository = new StockCardListRepository();
        private IAccountsTransactionsRepository transactionsRepository = new AccountsTransactionsRepository();
        private List<SearchEntity> SearchValues;
        private List<AccountsTransactionsEntity> FullList;
        private List<AccountsTransactionsEntity> AccountDetailListStore;
        private IAccountsTransactionsRepository transactionRepository = new AccountsTransactionsRepository();
        StackList itemlist = new StackList();
        private string jsonSearch;
        #endregion
        #region background region
        #region "constructor"
        public AccountsTransactionsViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            SelectChangedCommand = new RelayCommand(OnSelectionChange);
            ShowAllCommand = new RelayCommand(ShowAll);
            //ShowSelectedCommand = new RelayCommand(ShowSelected);
            YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
            CalendarSelectionCommand = new RelayCommand(OnCalendarSelection);
            CloseCommand = new DelegateCommand(Close);
       
        }
        #endregion
        #region
        public ICommand CloseCommand { get; set; }
        public RelayCommand SelectChangedCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        public RelayCommand ShowSelectedCommand { get; set; }
        public RelayCommand YearQuarterSelectedCommand { get; set; }
        public RelayCommand CalendarSelectionCommand { get; set; }
       
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

            int minHeight = 500;
            int headerRows = 300;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows -10;
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
        void OnYearQuarterMonthChange(object param)
        {
            ShowAllTrue = false;
        }
        void OnCalendarSelection(object param)
        {
            ShowAllTrue = false;
        }//end
        void ShowAll(object param)
        {
            this.YearmonthQuartTrue = false;//added after client feedback
            this.StartEndDateTrue = false;//added after client feedback
           
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.AccountsTransactionNameTypeList.Count();
            else
                this.ShowSelectedCount = this.AccountsTransactionNameTypeList.Count();
            this.SelectedSearchEndDate = null;
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.SelectedSearchStartDate = null;
            this.SelectedSearchEndDate = null;
            //added on 23 may 2017
           
           
            Search(null);
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
        #endregion end background
        #region public method
        public void RefreshData()
        {
            try
            {
                this.JsonData = transactionRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.AccountTransaction)); 
                this.AccountsTransactionNameTypeList = transactionsRepository.GetAccountsTransactionNameAndType().ToList();
                FullList = this.AccountsTransactionNameTypeList;
               
            }
            catch (Exception)
            {

                throw;
            }
            this.YearRange = purchaseRepository.GetYearRange().ToList();
            SetDefaultSearchSelection();

        }
        //void ShowSelected(object param)
        //{
        //    this.ShowAllTrue = false;
        //    Search(null);
        //    Mouse.OverrideCursor = null;
        //}

        public void  OnSelectionChange(object param)
        {
            this.JsonData = transactionRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.AccountTransaction));
            if (ID!=0 && JsonData== null)
            {
                AccountsTransactionDetailList = transactionRepository.GetAccountsTransactionDetails(ID,this.JsonData);
                AccountDetailListStore = this.AccountsTransactionDetailList;
                this.ShowAllCount = this.AccountDetailListStore.Count();
                TotalAmount =Convert.ToString(AccountsTransactionDetailList.Sum(x => Convert.ToDecimal(x.AmountStr)));

                //List<AccountsTransactionsEntity> Templist = new List<AccountsTransactionsEntity>();
                //Templist.AddRange(AccountsTransactionDetailList);
                //Templist.Add(new AccountsTransactionsEntity { TransactionType = "Total", Name = "", TransactionNo = "", TransactiondateStr = "", AmountStr = String.Format("{0:#,##0.##}", Amount) });
                ////AccountsTransactionDetailList.Add(Templist.ToList());
                //AccountsTransactionDetailList = Templist;
                this.ShowSelectedCount = this.AccountsTransactionDetailList.Count();
            }
            else if(ID!=0 && !String.IsNullOrEmpty(JsonData))
            {
                AccountsTransactionDetailList = transactionRepository.GetAccountsTransactionDetails(ID, this.JsonData);
                AccountDetailListStore = this.AccountsTransactionDetailList;
                this.ShowAllCount = this.AccountDetailListStore.Count();
                TotalAmount =Convert.ToString(AccountsTransactionDetailList.Sum(x => Convert.ToDecimal(x.AmountStr)));

                //List<AccountsTransactionsEntity> Templist = new List<AccountsTransactionsEntity>();
                //Templist.AddRange(AccountsTransactionDetailList);
                //Templist.Add(new AccountsTransactionsEntity { TransactionType = "Total", Name = "", TransactionNo = "", TransactiondateStr = "", AmountStr = String.Format("{0:#,##0.##}", Amount) });
                ////AccountsTransactionDetailList.Add(Templist.ToList());
                //AccountsTransactionDetailList = Templist;
                this.ShowSelectedCount = this.AccountsTransactionDetailList.Count();
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
                    //value.FieldValue = this.SelectedSearchStartDate.ToString();
                    value.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchStartDate);
                    SearchValues.Add(value);
                    //string[] value = new string[2];
                    SearchEntity value1 = new SearchEntity();
                    value1.FieldName = "EndDate";
                    //value1.FieldValue = this.SelectedSearchEndDate.ToString();
                    value1.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchEndDate);

                    //DefaultList = FullPQList.Where(x => x.CreatedDate > this.SelectedSearchStartDate && x.CreatedDate < this.SelectedSearchEndDate).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.SalesQuotationListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.SalesQuotationListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.SalesQuotationListcmb = DefaultList;
                   
                    SearchValues.Add(value1);
                }
                else {

                    SearchEntity value = new SearchEntity();
                    value.FieldName = "StartDate";
                    value.FieldValue = "";
                    SearchValues.Add(value);
                    SearchEntity value1 = new SearchEntity();
                    value1.FieldName = "EndDate";
                    value1.FieldValue = "";
                    SearchValues.Add(value1);
                }
                //if (this.ID != 0)
                //{
                //    SearchEntity value = new SearchEntity();
                //    value.FieldName = "PandS";
                //    value.FieldValue = this.PandS.ToString();
                //    SearchValues.Add(value);
                //}
                //else
                //{
                //    SearchEntity value = new SearchEntity();
                //    value.FieldName = "PandS";
                //    value.FieldValue = "0";
                //    SearchValues.Add(value);
                //}
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
                var results = transactionsRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.AccountTransaction), "Account_transaction");
                
                
                if (Count != 0)
                {
                    if (ID != 0 && JsonData != null)
                    {
                        AccountsTransactionDetailList = transactionRepository.GetAccountsTransactionDetails(ID, this.JsonData);
                        AccountDetailListStore = this.AccountsTransactionDetailList;
                        this.ShowAllCount = this.AccountDetailListStore.Count();
                        this.ShowSelectedCount = this.AccountsTransactionDetailList.Where(x=>x.TransactionType != "Total").Count();
                        TotalAmount = Convert.ToString(AccountsTransactionDetailList.Sum(x => Convert.ToDecimal(x.AmountStr)));
                        //var Templist = new List<AccountsTransactionsEntity>();
                        //Templist.AddRange(AccountsTransactionDetailList);
                        //Templist.Add(new AccountsTransactionsEntity { TransactionType = "Total", Name = "", TransactionNo = "", TransactiondateStr = "", AmountStr = String.Format("{0:#,##0.##}", Amount) });
                        ////AccountsTransactionDetailList.Add(Templist.ToList());
                        //AccountsTransactionDetailList = Templist;
                        //this.ShowAllCount = this.AccountDetailListStore.Count();
                    }
                }
               

            }

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
        //                    this.SelectedSearchYear = item.FieldValue;
        //                    this.YearmonthQuartTrue = true;
        //                    this.StartEndDateTrue = false;
        //                    this.EnableYearDropDown = true;
        //                    this.EnableMonthDropDown = true;
        //                    this.EnableQuarterDropDown = true;
        //                    break;
        //                case "Quarter":
        //                    this.SelectedSearchQuarter = item.FieldValue;
        //                    this.YearmonthQuartTrue = true;
        //                    this.StartEndDateTrue = false;
        //                    this.EnableYearDropDown = true;
        //                    this.EnableMonthDropDown = true;
        //                    this.EnableQuarterDropDown = true;
        //                    break;
        //                case "Month":
        //                    this.SelectedSearchMonth = item.FieldValue;
        //                    this.YearmonthQuartTrue = true;
        //                    this.StartEndDateTrue = false;
        //                    this.EnableYearDropDown = true;
        //                    this.EnableMonthDropDown = true;
        //                    this.EnableQuarterDropDown = true;
        //                    break;
        //                case "StartDate":
        //                    this.SelectedSearchStartDate = Convert.ToDateTime(item.FieldValue);
        //                    this.YearmonthQuartTrue = false;
        //                    this.StartEndDateTrue = true;
        //                    this.EnableYearDropDown = false;
        //                    this.EnableMonthDropDown = false;
        //                    this.EnableQuarterDropDown = false;
        //                    break;
        //                case "EndDate":
        //                    this.SelectedSearchEndDate = Convert.ToDateTime(item.FieldValue);
        //                    this.YearmonthQuartTrue = false;
        //                    this.StartEndDateTrue = true;
        //                    this.EnableYearDropDown = false;
        //                    this.EnableMonthDropDown = false;
        //                    this.EnableQuarterDropDown = false;
        //                    break;
        //            }
        //        }
        //        Search(null);
        //    }
        //    else
        //    {
        //        this.ShowAllTrue = true;
        //        this.YearmonthQuartTrue = false;//change to false after feedback on 22 may 
        //        this.ShowSelectedTrue = false;

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
                case "SelectedSearchStartDate":
                    SetData(this.SelectedSearchStartDate.ToString(), "StartDate");
                    break;
                case "SelectedSearchEndDate":
                    SetData(this.SelectedSearchEndDate.ToString(), "EndDate");
                    break; 
            }

            base.OnPropertyChanged(name);
        }

        #endregion
    }
}

