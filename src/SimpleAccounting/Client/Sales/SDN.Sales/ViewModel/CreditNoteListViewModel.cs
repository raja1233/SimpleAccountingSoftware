﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.ViewModel
{
    using Common;
    using Customers.Views;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Newtonsoft.Json;
    using SDN.UI.Entities.Sales;
    using Services;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using UI.Entities;
    using Views;

    public class CreditNoteListViewModel:CreditNoteListEntity
    {
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private List<SearchEntity> SearchValues;
        private string jsonSearch;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private int Count = 0;

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
        /// Initializes a new instance of the <see cref="CreditNoteListViewModel"/> class.
        /// </summary>
        public CreditNoteListViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadCustomerBackground();
            SearchCommand = new RelayCommand(Search);
            ShowAllCommand = new RelayCommand(ShowAll);
            ShowSelectedCommand = new RelayCommand(ShowSelected);
            NavigateToClientCommand = new RelayCommand(NavigatetoCustomer);
            ShowIncGSTCommand = new RelayCommand(showincGST);
            ShowExcGSTCommand = new RelayCommand(showexcGST);
            RefreshCommand = new RelayCommand(refreshcommand);
            NavigaetoSalesCommand = new RelayCommand(NavigatetoCreditNote);
            YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
            CalendarSelectionCommand = new RelayCommand(OnCalendarSelection);
            NavigaetoSalesInvoiceCommand = new RelayCommand(NavigaettoSalesInvoice);
        }

        public CreditNoteListViewModel()
        {
        }
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
        public RelayCommand NavigaetoSalesInvoiceCommand { get; set; }
        
        #endregion  Constructor

        #region ButtonCommands
        void refreshcommand(object param)
        {
            RefreshData();
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
            //foreach (var item in this.CreditNoteList)
            //{
            //    //item.CreditAmount = item.CreditAmountIncGST;
            //    item.CreditAmount = Math.Round(Convert.ToDouble(item.CreditAmountIncGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.CreditNoteList = DefaultList.Where(x => x.ExcIncGST == true).ToList();
            //else
            //    this.CreditNoteList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            ICreditNoteListRepository SalesRepository = new CreditNoteListRepository();
            this.CreditNoteList = SalesRepository.GetAllSalesCreditJson(this.JsonData, this.IncludingGSTTrue).OrderBy(x => x.CustomerName).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.CreditNoteList.Count();
            else
                this.ShowSelectedCount = 0;
            this.CreditNoteListcmb = this.CreditNoteList.OrderBy(x => x.CustomerName).ToList();
            this.CreditNoteListcmbCredit = this.CreditNoteListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).Where(y => y.CashCreditNo != null).OrderBy(x => x.CustomerName).ToList();
            this.CreditNoteListcmbCus = this.CreditNoteList.GroupBy(x => x.CustomerName).Select(y => y.First()).Distinct().OrderBy(x => x.CustomerName).ToList();
            this.CreditNoteListcmbInv = this.CreditNoteList.GroupBy(x => x.CreditNo).Select(y => y.First()).Distinct().OrderBy(x => x.SortCreditNoteNo).ToList();
            DefaultList = this.CreditNoteListcmb;
            //changedateformat(this.CreditNoteList);
           changeNumberformat(this.CreditNoteList);
            Mouse.OverrideCursor = null;
        }
        void showexcGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
          
            ICreditNoteListRepository SalesRepository = new CreditNoteListRepository();
            this.CreditNoteList = SalesRepository.GetAllSalesCreditJson(this.JsonData, this.IncludingGSTTrue).OrderBy(x => x.CustomerName).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.CreditNoteList.Count();
            else
                this.ShowSelectedCount = 0;
            this.CreditNoteListcmb = this.CreditNoteList.OrderBy(x => x.CustomerName).OrderBy(x => x.CustomerName).ToList();
            this.CreditNoteListcmbCredit = this.CreditNoteListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).Where(y => y.CashCreditNo != null).OrderBy(x => x.CreditCashNO).OrderBy(x => x.CustomerName).ToList();
            this.CreditNoteListcmbCus = this.CreditNoteList.GroupBy(x => x.CustomerName).Select(y => y.First()).Distinct().OrderBy(x => x.CustomerName).OrderBy(x => x.CustomerName).ToList();
            this.CreditNoteListcmbInv = this.CreditNoteList.GroupBy(x => x.CreditNo).Select(y => y.First()).Distinct().OrderBy(x => x.SortCreditNoteNo).OrderBy(x => x.CustomerName).ToList();
            DefaultList = this.CreditNoteListcmb;
            
          changeNumberformat(this.CreditNoteList);
            Mouse.OverrideCursor = null;
        }
        void NavigatetoCustomer(object param)
        {
            string obj = param.ToString();
            SharedValues.getValue = obj;
            var mainview = ServiceLocator.Current.GetInstance<CustomerView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<CustomersTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details Form");
        }
        void NavigatetoCreditNote(object param)
        {
            string obj = param.ToString();
            SharedValues.NewClick = obj;
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Credit Note Form");
        }

        void NavigaettoSalesInvoice(object param)
        {
            SharedValues.getValue = "SalesInvoiceTab";
            string obj = param.ToString();
            SharedValues.NewClick = obj;
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoice - Form");
        }

        void ShowAll(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.YearmonthQuartTrue = false;//added after client feedback
            this.StartEndDateTrue = false;//added after client feedback
            this.CreditNoteList = FullPQList.OrderBy(x => x.CustomerName).ToList();
            this.CreditNoteListcmb = FullPQList.OrderBy(x => x.CustomerName).ToList();
            this.CreditNoteListcmbCredit = this.CreditNoteListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).Where(y => y.CashCreditNo != null).OrderBy(x => x.CreditCashNO).ToList();
            this.CreditNoteListcmbCus = this.CreditNoteList.GroupBy(x => x.CustomerName).Select(y => y.First()).Distinct().OrderBy(x => x.CustomerName).ToList();
            this.CreditNoteListcmbInv = this.CreditNoteList.GroupBy(x => x.CreditNo).Select(y => y.First()).Distinct().OrderBy(x => x.SortCreditNoteNo).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.CreditNoteList.Count();
            else
                this.ShowSelectedCount = 0;
            this.SelectedSearchEndDate = null;
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.SelectedSearchStartDate = null;
            this.SelectedSearchEndDate = null;
            if (this.IncludingGSTTrue == true)
                this.CreditNoteList = FullPQList.Where(x => x.ExcIncGST == true).OrderBy(x => x.CustomerName).ToList();
            else
                this.CreditNoteList = FullPQList.Where(x => x.ExcIncGST == false).OrderBy(x => x.CustomerName).ToList();
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
                    //DefaultList = FullPQList.Where(x => x.CreatedDate.Value.Year == year).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.CreditNoteListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.CreditNoteListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.CreditNoteListcmb = DefaultList;
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
                    //DefaultList = FullPQList.Where(x => x.CreatedDate.Value.Month == month1 || x.CreatedDate.Value.Month == month2 || x.CreatedDate.Value.Month == month3).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.CreditNoteListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.CreditNoteListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.CreditNoteListcmb = DefaultList;
                    SearchValues.Add(value);
                }
                if (this.SelectedSearchMonth != null || this.SelectedSearchMonth == string.Empty)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Month";
                    value.FieldValue = this.SelectedSearchMonth;
                    SearchValues.Add(value);
                    var month = Convert.ToInt32(this.SelectedSearchMonth);
                    //DefaultList = FullPQList.Where(x => x.CreatedDate.Value.Month == month).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.CreditNoteListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.CreditNoteListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.CreditNoteListcmb = DefaultList;
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

                ICreditNoteListRepository SalesRepository = new CreditNoteListRepository();
                var results = SalesRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.CreditNoteList), "Credit_Note_List"); 
                if (Count != 0)
                {
                    this.CreditNoteList = SalesRepository.GetAllSalesCreditJson(jsonSearch, this.IncludingGSTTrue).OrderBy(x => x.CustomerName).ToList();
                   
                  changeNumberformat(this.CreditNoteList);
                }
                    
                this.CreditNoteListcmb = this.CreditNoteList.OrderBy(x => x.CustomerName).ToList();
                this.CreditNoteListcmbCredit = this.CreditNoteListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).Where(y => y.CashCreditNo != null).OrderBy(x => x.CreditCashNO).ToList();
                this.CreditNoteListcmbCus = this.CreditNoteList.GroupBy(x => x.CustomerName).Select(y => y.First()).Distinct().OrderBy(x => x.CustomerName).ToList();
                this.CreditNoteListcmbInv = this.CreditNoteList.GroupBy(x => x.CreditNo).Select(y => y.First()).Distinct().OrderBy(x => x.SortCreditNoteNo).ToList();
                if (this.ShowAllTrue == true)
                    this.ShowSelectedCount = 0;
                else
                    this.ShowSelectedCount = this.CreditNoteList.Count();
                DefaultList = this.CreditNoteListcmb;
                
                this.TotalCreditAmount = Convert.ToString(CreditNoteList.Sum(e => e.CreditAmountValue));
            }

        }
        #endregion

        #region BackgroundWorked
        private void LoadCustomerBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;

            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;


            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadCustomerBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadCustomerBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadCustomerBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }
        List<CreditNoteListEntity> DefaultList = new List<CreditNoteListEntity>();
        List<CreditNoteListEntity> FullPQList = new List<CreditNoteListEntity>();
        private void LoadCustomerBackground(object sender, DoWorkEventArgs e)
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
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 119;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.CNGridHeight = minHeight;
            RefreshData();
        }

        private void RefreshData()
        {
            ICreditNoteListRepository SalesRepository = new CreditNoteListRepository();
           // this.DateFormat = SalesRepository.GetDateFormat();
            this.ShowAllCount = SalesRepository.GetAllSalesCredit().Count();
            GetOptionsandTaxValues();
            this.JsonData = SalesRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.CreditNoteList));
            this.CreditNoteList = SalesRepository.GetAllSalesCreditJson(this.JsonData, this.IncludingGSTTrue).OrderBy(x=>x.CustomerName).ToList();
            this.CreditNoteListcmb = SalesRepository.GetAllSalesCredit().OrderBy(x => x.CustomerName).ToList();
            this.ShowSelectedCount = this.CreditNoteList.Count();
            this.CreditNoteListcmbCredit = this.CreditNoteListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).Where(y => y.CashCreditNo != null).OrderBy(x => x.CreditCashNO).ToList();
            this.CreditNoteListcmbCus = this.CreditNoteList.GroupBy(x => x.CustomerName).Select(y => y.First()).Distinct().OrderBy(x => x.CustomerName).ToList();
            this.CreditNoteListcmbCus = this.CreditNoteList.GroupBy(x => x.CustomerName).Select(y => y.First()).Distinct().OrderBy(x => x.CustomerName).ToList();
            this.CreditNoteListcmbInv = this.CreditNoteList.GroupBy(x => x.CreditNo).Select(y => y.First()).Distinct().OrderBy(x => x.SortCreditNoteNo).ToList();
            this.YearRange = SalesRepository.GetYearRange().ToList();
            
            changeNumberformat(this.CreditNoteList);
            changeNumberformat(this.CreditNoteListcmb);
            DefaultList = this.CreditNoteList;
            FullPQList = this.CreditNoteListcmb;
            //this.ShowAllCount = this.CreditNoteListcmb.Count();
            SetDefaultSearchSelection(this.JsonData);
            var Updateddate = this.CreditNoteListcmb.Max(x => x.CreatedDate);
            string date = this.DateFormat as string;
            this.LastUpdateDate = Convert.ToDateTime(Updateddate).ToString(date);

            this.CreditAmount = Convert.ToString(CreditNoteList.Sum(e => e.CreditAmountValue));
            //this.GetData(this.SelectedSearchCustomer);
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            ICreditNoteListRepository SalesRepository = new CreditNoteListRepository();
            oData = SalesRepository.GetOptionSettings();
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
                
                    if (this.CreditNoteList != null)
                        this.CreditNoteList = this.CreditNoteList.OrderBy(x => x.CustomerName).ToList();
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
            objDefaultTax = SalesRepository.GetDefaultTaxes();
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

        
        void changeNumberformat(List<CreditNoteListEntity> entity)
        {
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            string date = this.DateFormat as string;
            foreach (var item in entity)
            {
                //item.QuotationAmount = item.QuotationAmountIncGST;
                if (item.CreditAmount != null && item.CreditNoteAmount != 0)
                    item.CreditAmount = Math.Round(Convert.ToDouble(item.CreditNoteAmount), decimalpoints).ToString();
                if (item.CreditCashAmount != null && item.CreditCashAmount != "")
                    item.CreditCashAmount = Math.Round(Convert.ToDouble(item.CreditCashAmount), decimalpoints).ToString();

                if (item.CreditCashDate != null && item.CreditCashDate != "")
                {
                    var tempdate = Convert.ToDateTime(item.CreditCashDate).ToString(date);
                    item.CreditCashDate = tempdate.Replace('-', '/');
                }
                if (item.CreditDateDateTime != null)
                {
                    var tempdate = Convert.ToDateTime(item.CreditDateDateTime).ToString(date);
                    item.CreditDate = tempdate.Replace('-', '/');
                }
                else
                    item.CreditDate = "";

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
        public void LoadSearchResult(string Customername)
        {
            ICreditNoteListRepository SalesRepository = new CreditNoteListRepository();
            this.ShowAllCount = SalesRepository.GetAllSalesCredit().Count();
            this.CreditNoteList = SalesRepository.GetAllSalesCredit().Where(x => x.CustomerName == Customername).OrderBy(x => x.CustomerName).ToList();
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
                case "SelectedSearchCusName":
                    GetData(this.SelectedSearchCusName, "Customer");
                    break;
                case "SelectedSearchPI_Status":
                    GetData(this.SelectedSearchPI_Status, "PI_Status");
                    break;
                case "SelectedCreditNoteNo":
                    GetData(this.SelectedCreditNoteNo, "CreditNote");
                    break;
                case "SelectedSearchQNo":
                    GetData(this.SelectedSearchQNo, "CashCreditNote");
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
            //ICreditNoteListRepository SalesRepository = new CreditNoteListRepository();
            //var result = SalesRepository.GetAllPurCredit().ToList();
            if (SearchFilter != null || SearchFilter == string.Empty)
            {
                if (parameter == "Customer")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CreditNoteList = FullPQList.Where(x => (x.CustomerName == SearchFilter || x.CreditNo == SearchFilter)).OrderBy(x => x.CustomerName).ToList();
                    }
                    else
                    {
                        this.CreditNoteList = DefaultList.Where(x => (x.CustomerName == SearchFilter || x.CreditNo == SearchFilter)).OrderBy(x => x.CustomerName).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                }
                if (parameter == "PI_Status")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        var search = SearchFilter.Split(':')[1];
                        if (search == " All")
                            this.CreditNoteList = FullPQList.OrderBy(x => x.CustomerName).ToList();
                        else if (search == " Adjusted")
                        {
                            byte adjusted = Convert.ToByte(DN_Status.Adjusted);
                            this.CreditNoteList = FullPQList.Where(x => x.Status == adjusted).OrderBy(x => x.CustomerName).ToList();
                        }
                        else if (search == " Refunded")
                        {
                            byte refunded = Convert.ToByte(DN_Status.Refunded);
                            this.CreditNoteList = FullPQList.Where(x => x.Status == refunded).OrderBy(x => x.CustomerName).ToList();
                        }
                        else if (search == " UnAdjusted")
                        {
                            byte unAdjusted = Convert.ToByte(DN_Status.UnAdjusted);
                            this.CreditNoteList = FullPQList.Where(x => x.Status == unAdjusted).ToList();
                        }
                        else
                            this.CreditNoteList = FullPQList.OrderBy(x => x.CustomerName).ToList();
                    }
                    else
                    {
                        var search = SearchFilter.Split(':')[1];
                        if (search == " All")
                            this.CreditNoteList = DefaultList.OrderBy(x => x.CustomerName).ToList();
                        else if (search == " Adjusted")
                        {
                            byte adjusted = Convert.ToByte(DN_Status.Adjusted);
                            this.CreditNoteList = DefaultList.Where(x => x.Status == adjusted).OrderBy(x => x.CustomerName).ToList();
                        }
                        else if (search == " Refunded")
                        {
                            byte refunded = Convert.ToByte(DN_Status.Refunded);
                            this.CreditNoteList = DefaultList.Where(x => x.Status == refunded).OrderBy(x => x.CustomerName).ToList();
                        }
                        else if (search == " UnAdjusted")
                        {
                            byte unAdjusted = Convert.ToByte(DN_Status.UnAdjusted);
                            this.CreditNoteList = DefaultList.Where(x => x.Status == unAdjusted).OrderBy(x => x.CustomerName).ToList();
                        }
                        else
                            this.CreditNoteList = DefaultList.OrderBy(x => x.CustomerName).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                }
                if (parameter == "CreditNote")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CreditNoteList = FullPQList.Where(x => x.CreditNo == SearchFilter).OrderBy(x => x.CustomerName).ToList();
                    }
                    else
                    {
                        this.CreditNoteList = DefaultList.Where(x => x.CreditNo == SearchFilter).OrderBy(x => x.CustomerName).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                }
                if (parameter == "CashCreditNote")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CreditNoteList = FullPQList.Where(x => x.CashCreditNo == SearchFilter).OrderBy(x => x.CustomerName).ToList();
                    }
                    else
                    {
                        this.CreditNoteList = DefaultList.Where(x => x.CashCreditNo == SearchFilter).OrderBy(x => x.CustomerName).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                }

                
            }
            else
            {
                if (this.ShowAllTrue == true)
                {
                    this.CreditNoteList = FullPQList.OrderBy(x => x.CustomerName).ToList();
                }
                else
                {
                    this.CreditNoteList = DefaultList.OrderBy(x => x.CustomerName).ToList();
                }
            }
            //changedateformat(CreditNoteList);
            changeNumberformat(CreditNoteList);
            TotalCreditAmount = Convert.ToString(CreditNoteList.Sum(e => e.CreditAmountValue));
        }
        /// <summary>
        ///  Occurs when System.ComponentModel.BackgroundWorker.ReportProgress(System.Int32) is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void LoadCustomerBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {

        }

        ///// <summary>
        /////  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        ///// </summary>
        ///// <param name="sender">The sender.</param>
        ///// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadCustomerBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {

            Mouse.OverrideCursor = null;
            Count = 1;
        }

       
        #endregion
    }
}
