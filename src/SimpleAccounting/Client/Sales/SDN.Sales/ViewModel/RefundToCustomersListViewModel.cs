﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.ViewModel
{
    using Common;
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

    public class RefundToCustomersListViewModel: RefundToCustomersListEntity
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
        /// Initializes a new instance of the <see cref="PurchaseInvoiceListViewModel"/> class.
        /// </summary>
        public RefundToCustomersListViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            SearchCommand = new RelayCommand(Search);
            ShowAllCommand = new RelayCommand(ShowAll);
            ShowSelectedCommand = new RelayCommand(ShowSelected);
            NavigateToClientCommand = new RelayCommand(NavigatetoSupplier);

            RefreshCommand = new RelayCommand(refreshcommand);
            NavigateToPSCommand = new RelayCommand(NavigateToPS);
            NavigaetoPaymentCommand = new RelayCommand(NavigatetoPaymentForm);
            YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
            CalendarSelectionCommand = new RelayCommand(OnCalendarSelection);
            InvoiceOrderCommand = new RelayCommand(NavigatetoInvoiceOrder);
        }

        public RefundToCustomersListViewModel()
        {
        }
        public RelayCommand YearQuarterSelectedCommand { get; set; }
        public RelayCommand CalendarSelectionCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        public RelayCommand ShowSelectedCommand { get; set; }
        public RelayCommand NavigateToClientCommand { get; set; }
        public RelayCommand NavigateToPSCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand NavigaetoPaymentCommand { get; set; }
        public RelayCommand InvoiceOrderCommand { get; set; }

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
        void NavigatetoSupplier(object param)
        {
            string obj = param.ToString();
            SharedValues.getValue = obj;
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

        void NavigatetoInvoiceOrder(object param)
        {
            string obj = param.ToString();
            SharedValues.NewClick = obj;

            var checkOrderInvoice = obj.Split('-')[0];
            if (checkOrderInvoice == "SO")
            {
                SharedValues.getValue = "SalesOrderTab";
                var mainview = ServiceLocator.Current.GetInstance<SalesOrderView>();
                var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                mainregion.Add(mainview);
                if (mainregion != null)
                {
                    mainregion.Activate(mainview);
                }


                var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();
                var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                tabregion.Add(tabview);
                if (tabregion != null)
                {
                    tabregion.Activate(tabview);
                }

                eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Order - Form");
            }
            else if (checkOrderInvoice == "CN")
            {
                SharedValues.getValue = "CreditNoteTab";
                var mainview = ServiceLocator.Current.GetInstance<CreditNoteView>();
                var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                mainregion.Add(mainview);
                if (mainregion != null)
                {
                    mainregion.Activate(mainview);
                }


                var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();
                var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                tabregion.Add(tabview);
                if (tabregion != null)
                {
                    tabregion.Activate(tabview);
                }

                eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                eventAggregator.GetEvent<TitleChangedEvent>().Publish("Credit Note Form");
            }

        }

        void NavigateToPS(object param)
        {
            if (param != null)
            {
                string obj = param.ToString();
                SharedValues.NewClick = obj;
                SharedValues.getValue = "RefundToCustomerTab";
                SharedValues.CollectCommand = "0";
            }
            var mainview = ServiceLocator.Current.GetInstance<RefundToCustomerView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<SDN.Common.View.CashAndBankTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund To Customer Form");
        }

        void NavigatetoPaymentForm(object param)
        {
            string obj = param.ToString();
            SharedValues.getValue = obj;
            var mainview = ServiceLocator.Current.GetInstance<RefundToCustomerView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<SDN.Common.View.CashAndBankTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Order");
        }
        void ShowAll(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.YearmonthQuartTrue = false;//added after client feedback
            this.StartEndDateTrue = false;//added after client feedback
            this.RefundToCustomersList = FullPQList.OrderBy(x => x.CustomerName).ToList();
            this.RefundToCustomersListcmb = FullPQList.OrderBy(x => x.CustomerName).ToList();
            // this.RefundToCustomersListcmbDebit = this.RefundToCustomersListcmb.GroupBy(x => x.CashDebitNo).Select(g => g.First()).Where(y => y.CashDebitNo != null).ToList();
            this.RefundToCustomersListcmbSup = this.RefundToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).Distinct().OrderBy(x => x.CustomerName).ToList();
            this.RefundToCustomersListcmbInv = this.RefundToCustomersList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).Distinct().OrderBy(x => x.InvoiceNo).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.RefundToCustomersList.Count();
            else
                this.ShowSelectedCount = 0;
            this.SelectedSearchEndDate = null;
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.SelectedSearchStartDate = null;
            this.SelectedSearchEndDate = null;

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
                    DefaultList = FullPQList.Where(x => x.CreatedDate.Value.Year == year).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.PurchaseInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.PurchaseInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    this.RefundToCustomersList = DefaultList.OrderBy(x => x.CustomerName).ToList();
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
                    DefaultList = FullPQList.Where(x => x.CreatedDate.Value.Month == month1 || x.CreatedDate.Value.Month == month2 || x.CreatedDate.Value.Month == month3).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.PurchaseInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.PurchaseInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    this.RefundToCustomersList = DefaultList.OrderBy(x => x.CustomerName).ToList();
                    SearchValues.Add(value);
                }
                if (this.SelectedSearchMonth != null || this.SelectedSearchMonth == string.Empty)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Month";
                    value.FieldValue = this.SelectedSearchMonth;
                    SearchValues.Add(value);
                    var month = Convert.ToInt32(this.SelectedSearchMonth);
                    DefaultList = FullPQList.Where(x => x.CreatedDate.Value.Month == month).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.PurchaseInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.PurchaseInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    this.RefundToCustomersList = DefaultList.OrderBy(x => x.CustomerName).ToList();
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

                    DefaultList = FullPQList.Where(x => x.CreatedDate > this.SelectedSearchStartDate && x.CreatedDate < this.SelectedSearchEndDate).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.PurchaseInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.PurchaseInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    this.RefundToCustomersList = DefaultList.OrderBy(x => x.CustomerName).ToList();
                    SearchValues.Add(value);
                    SearchValues.Add(value1);
                }
                //if (this.SelectedSearchEndDate != null || this.SelectedSearchEndDate == string.Empty)
                //{
                //    string[] value = new string[2];
                //    value[0] = "EndDate";
                //    value[1] = this.SelectedSearchEndDate;
                //    SearchValues.Add(value);
                //}

                //this.PurchaseInvoiceList = this.PurchaseInvoiceListInternal;
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;

                IRefundToCustomersListRepository purchaseRepository = new RefundToCustomersListRepository();
                var results = purchaseRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.RefundToCustomersList), "Payments_To_Suppliers_List");
                if (Count != 0)
                    this.RefundToCustomersList = purchaseRepository.GetAllPurInvoiceJson(jsonSearch).OrderBy(x => x.CustomerName).ToList();
                this.RefundToCustomersListcmb = this.RefundToCustomersList;
                this.RefundToCustomersListcmbDebit = this.RefundToCustomersListcmb.GroupBy(x => x.CashChequeNo).Select(g => g.First()).Where(y => y.CashChequeNo != null).OrderBy(x => x.CashChequeNo).ToList();
                this.RefundToCustomersListcmbSup = this.RefundToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).Distinct().ToList();
                this.RefundToCustomersListcmbInv = this.RefundToCustomersList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).Distinct().OrderBy(x => x.InvoiceNo).ToList();
                if (this.ShowAllTrue == true)
                    this.ShowSelectedCount = 0;
                else
                    this.ShowSelectedCount = this.RefundToCustomersList.Count();
                DefaultList = this.RefundToCustomersListcmb;
                changedateformat(this.RefundToCustomersList);
                changedateformat(this.RefundToCustomersListcmb);
                changeNumberformat(this.RefundToCustomersList);
                changeNumberformat(this.RefundToCustomersListcmb);
            }
            TotalCashChequeAmount = Convert.ToString(RefundToCustomersList.Sum(e => e.CashChequeAmount));
            TotalPOPIAmount = Convert.ToString(RefundToCustomersList.Sum(e => e.InvoiceAmountValue));
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
        List<RefundToCustomersListEntity> DefaultList = new List<RefundToCustomersListEntity>();
        List<RefundToCustomersListEntity> FullPQList = new List<RefundToCustomersListEntity>();
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {
            //GetOptionsData();
            //var height = System.Windows.SystemParameters.PrimaryScreenHeight;
            //if (height == 768)
            //    this.PtSGridHeight = 425;
            //else if (height == 1024)
            //    this.PtSGridHeight = 680;
            //else if (height == 1440)
            //    this.PtSGridHeight = 956;
            //else if (height == 1800)
            //    this.PtSGridHeight = 1195;
            //else
            //    this.PtSGridHeight = 680;
            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 95;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.PtSGridHeight = minHeight;
            RefreshData();
        }

        private void RefreshData()
        {
            IRefundToCustomersListRepository purchaseRepository = new RefundToCustomersListRepository();
            this.DateFormat = purchaseRepository.GetDateFormat();
            this.ShowAllCount = purchaseRepository.GetAllPurInvoice().Count();
            GetOptionsandTaxValues();
            this.JsonData = purchaseRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.RefundToCustomersList));
            this.RefundToCustomersList = purchaseRepository.GetAllPurInvoiceJson(this.JsonData).OrderBy(x => x.CustomerName).ToList();
            this.RefundToCustomersListcmb = purchaseRepository.GetAllPurInvoice().OrderBy(x => x.CustomerName).ToList();
            this.ShowSelectedCount = this.RefundToCustomersList.Count();
            this.RefundToCustomersListcmbDebit = this.RefundToCustomersListcmb.GroupBy(x => x.CashChequeNo).Select(g => g.First()).Where(y => y.CashChequeNo != null).OrderBy(x => x.CashChequeNo).ToList();
            this.RefundToCustomersListcmbSup = this.RefundToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).Distinct().OrderBy(x => x.CustomerName).ToList();

            this.RefundToCustomersListcmbInv = this.RefundToCustomersList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).Distinct().OrderBy(x => x.InvoiceNo).ToList();
            this.YearRange = purchaseRepository.GetYearRange().ToList();
            changedateformat(this.RefundToCustomersList);
            changedateformat(this.RefundToCustomersListcmb);
            changeNumberformat(this.RefundToCustomersList);
            changeNumberformat(this.RefundToCustomersListcmb);
            DefaultList = this.RefundToCustomersList;
            FullPQList = this.RefundToCustomersListcmb;
            //this.ShowAllCount = this.PurchaseInvoiceListcmb.Count();
            SetDefaultSearchSelection(this.JsonData);
            var Updateddate = this.RefundToCustomersListcmb.Max(x => x.CreatedDate);
            string date = this.DateFormat as string;
            this.LastUpdateDate = Convert.ToDateTime(Updateddate).ToString(date);

            TotalCashChequeAmount = Convert.ToString(RefundToCustomersList.Sum(e => e.CashChequeAmount));
            TotalPOPIAmount = Convert.ToString(RefundToCustomersList.Sum(e => e.InvoiceAmountValue));
            //this.GetData(this.SelectedSearchSupplier);
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            IRefundToCustomersListRepository purchaseRepository = new RefundToCustomersListRepository();
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

        void changedateformat(List<RefundToCustomersListEntity> entity)
        {
            string date = this.DateFormat as string;
            foreach (var item in entity)
            {

                if (item.InvoiceDateDateTime != null)
                {
                    // item.InvoiceDate = Convert.ToDateTime(item.InvoiceDateDateTime).ToString(date);
                    var tempdate = Convert.ToDateTime(item.InvoiceDateDateTime).ToString(date);
                    item.InvoiceDate = tempdate.Replace('-', '/');
                }
                else
                    item.InvoiceDate = "";
                if (item.CashChequeDateDate != null)
                {
                    //item.CashChequeDate = Convert.ToDateTime(item.CashChequeDateDate).ToString(date);
                    var tempdate = Convert.ToDateTime(item.CashChequeDateDate).ToString(date);
                    item.CashChequeDate = tempdate.Replace('-', '/');
                }
                else
                    item.CashChequeDate = "";

            }
        }
        void changeNumberformat(List<RefundToCustomersListEntity> entity)
        {
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            foreach (var item in entity)
            {
                //item.QuotationAmount = item.QuotationAmountIncGST;
                if (item.InvoiceAmount != null && item.InvoiceAmount != "")
                    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                if (item.CashAmount != null && item.CashAmount != "")
                    item.CashAmount = Math.Round(Convert.ToDouble(item.CashAmount), decimalpoints).ToString();
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
        public void LoadSearchResult(string Suppliername)
        {
            IRefundToCustomersListRepository purchaseRepository = new RefundToCustomersListRepository();
            this.ShowAllCount = purchaseRepository.GetAllPurInvoice().Count();
            this.RefundToCustomersList = purchaseRepository.GetAllPurInvoice().Where(x => x.CustomerName == Suppliername).OrderBy(x => x.CustomerName).ToList();
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
                case "SelectedCashChequeNo":
                    GetData(this.SelectedCashChequeNo, "CashChequeNo");
                    break;
                case "SelectedSearchInvoiceNo":
                    GetData(this.SelectedSearchInvoiceNo, "InvoiceNo");
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
            //IPurchaseInvoiceListRepository purchaseRepository = new PurchaseInvoiceListRepository();
            //var result = purchaseRepository.GetAllPurInvoice().ToList();
            if (SearchFilter != null || SearchFilter == string.Empty)
            {
                if (parameter == "Supplier")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.RefundToCustomersList = FullPQList.Where(x => (x.CustomerName == SearchFilter)).OrderBy(x => x.CustomerName).ToList();
                    }
                    else
                    {
                        this.RefundToCustomersList = DefaultList.Where(x => (x.CustomerName == SearchFilter)).OrderBy(x => x.CustomerName).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }

                //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();

                if (parameter == "CashChequeNo")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.RefundToCustomersList = FullPQList.Where(x => x.CashChequeNo == SearchFilter).OrderBy(x => x.CustomerName).ToList();
                    }
                    else
                    {
                        this.RefundToCustomersList = DefaultList.Where(x => x.CashChequeNo == SearchFilter).OrderBy(x => x.CustomerName).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }

                if (parameter == "InvoiceNo")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.RefundToCustomersList = FullPQList.Where(x => x.InvoiceNo == SearchFilter).OrderBy(x => x.CustomerName).ToList();
                    }
                    else
                    {
                        this.RefundToCustomersList = DefaultList.Where(x => x.InvoiceNo == SearchFilter).OrderBy(x => x.CustomerName).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }

            }
            else
            {
                if (this.ShowAllTrue == true)
                {
                    this.RefundToCustomersList = FullPQList.OrderBy(x => x.CustomerName).ToList();
                }
                else
                {
                    this.RefundToCustomersList = DefaultList.OrderBy(x => x.CustomerName).ToList();
                }
            }
            TotalCashChequeAmount = Convert.ToString(RefundToCustomersList.Sum(e => e.CashChequeAmount));
            TotalPOPIAmount = Convert.ToString(RefundToCustomersList.Sum(e => e.InvoiceAmountValue));
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
