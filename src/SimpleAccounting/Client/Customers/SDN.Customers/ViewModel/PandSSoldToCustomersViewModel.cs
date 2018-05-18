﻿using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using SDN.Common;
using SDN.Customers.Services;
using SDN.Customers.Views;
using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SDN.Customers.ViewModel
{
    public class PandSSoldToCustomersViewModel : PandSSoldToCustomersEntity
    {
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private List<SearchEntity> SearchValues;
        private string jsonSearch;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private int Count = 0;
        PandSSoldToCustomersEntity allPosition = new PandSSoldToCustomersEntity();

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
        /// Initializes a new instance of the <see cref="PandSSoldToCustomersListViewModel"/> class.
        /// </summary>
        public PandSSoldToCustomersViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
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
            NavigaetoSalesCommand = new RelayCommand(NavigatetoSalesInvoice);
            YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
            CalendarSelectionCommand = new RelayCommand(OnCalendarSelection);
            ShowProductCommand = new RelayCommand(ShowProduct);
            ShowServiceCommand = new RelayCommand(ShowService);
            ShowBothTrueCommand = new RelayCommand(ShowBothTrue);
            ShowIncludingTaxCommand = new RelayCommand(ShowIncludingTax);
            ShowExcludingTaxCommand = new RelayCommand(ShowExcludingTax);
            ShowSummaryCommand = new RelayCommand(ShowSummary);
            ShowDetailCommand = new RelayCommand(ShowDetails);
            NavigateToProductCommand = new RelayCommand(NavigateToProduct);
            NavigateToCustomerCommand = new RelayCommand(NavigateToCustomer);

        }

        public PandSSoldToCustomersViewModel()
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
        public RelayCommand ShowProductCommand { get; set; }
        public RelayCommand ShowServiceCommand { get; set; }
        public RelayCommand ShowBothTrueCommand { get; set; }
        public RelayCommand ShowIncludingTaxCommand { get; set; }
        public RelayCommand ShowExcludingTaxCommand { get; set; }
        public RelayCommand ShowSummaryCommand { get; set; }
        public RelayCommand ShowDetailCommand { get; set; }
        public RelayCommand NavigateToProductCommand { get; set; }
        public RelayCommand NavigateToCustomerCommand { get; set; }

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
            this.ShowSelectedTrue = true;
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
            this.ShowSelectedTrue = true;
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.EnableYearDropDown = false;
            this.EnableQuarterDropDown = false;
            this.StartEndDateTrue = true;
            this.EnableMonthDropDown = false;
            //this.EnableEndDropDown = true;

        }//end
        void showincGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //foreach (var item in this.PandSSoldToCustomersList)
            //{
            //    //item.InvoiceAmount = item.InvoiceAmountIncGST;
            //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountIncGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.PandSSoldToCustomersList = DefaultList.Where(x => x.ExcIncGST == true).ToList();
            //else
            //    this.PandSSoldToCustomersList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            IPandSSoldToCustomersRepository purchaseRepository = new PandSSoldToCustomersRepository();
            this.PandSSoldToCustomersList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData, this.IncludingGSTTrue,this.IsSummary).ToList();
            DefaultList = this.PandSSoldToCustomersList;
            this.PandSSoldToCustomersListCode = this.PandSSoldToCustomersList.GroupBy(x => x.PandSCode).Select(y => y.First()).OrderBy(x => x.PandSCode).ToList();
            this.PandSSoldToCustomersListName = this.PandSSoldToCustomersList.GroupBy(x => x.PandSName).Select(y => y.First()).OrderBy(x => x.PandSName).ToList();
            this.PandSSoldToCustomersListCus = this.PandSSoldToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).ToList();
            //this.PandSSoldToCustomersListCat1 = this.PandSSoldToCustomersList.GroupBy(x => x.Category1).Select(y => y.First()).OrderBy(x => x.Category1).Where(x => x.Category1 != string.Empty && x.Category1 != null).ToList();
            //this.PandSSoldToCustomersListCat2 = this.PandSSoldToCustomersList.GroupBy(x => x.Category2).Select(y => y.First()).OrderBy(x => x.Category2).Where(x => x.Category2 != string.Empty && x.Category2 != null).ToList();
            //allPosition.Category1 = "All";
            //allPosition.Category2 = "All";
            //this.PandSSoldToCustomersListCat1.Insert(0, allPosition);
            //this.PandSSoldToCustomersListCat2.Insert(0, allPosition);
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.PandSSoldToCustomersList.Count();
            else
                this.ShowSelectedCount = 0;
            // this.PandSSoldToCustomersListcmb = this.PandSSoldToCustomersList.OrderBy(x => x.CustomerName).ToList();
            // this.PandSSoldToCustomersListcmbCredit = this.PandSSoldToCustomersListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
            // this.PandSSoldToCustomersListcmbSup = this.PandSSoldToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
            // this.PandSSoldToCustomersListcmbInv = this.PandSSoldToCustomersList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();

            Mouse.OverrideCursor = null;
        }
        void showexcGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //foreach (var item in this.PandSSoldToCustomersList)
            //{
            //    //item.InvoiceAmount = item.InvoiceAmountExcGST;
            //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountExcGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.PandSSoldToCustomersList = DefaultList.Where(x => x.ExcIncGST == false).ToList();
            //else
            //    this.PandSSoldToCustomersList = FullPQList.Where(x => x.ExcIncGST == false).ToList();
            IPandSSoldToCustomersRepository purchaseRepository = new PandSSoldToCustomersRepository();
            this.PandSSoldToCustomersList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData, this.IncludingGSTTrue,this.IsSummary).ToList();
            DefaultList = this.PandSSoldToCustomersList;
            this.PandSSoldToCustomersListCode = this.PandSSoldToCustomersList.GroupBy(x => x.PandSCode).Select(y => y.First()).OrderBy(x => x.PandSCode).ToList();
            this.PandSSoldToCustomersListName = this.PandSSoldToCustomersList.GroupBy(x => x.PandSName).Select(y => y.First()).OrderBy(x => x.PandSName).ToList();
            this.PandSSoldToCustomersListCus = this.PandSSoldToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).ToList();
            //this.PandSSoldToCustomersListCat1 = this.PandSSoldToCustomersList.GroupBy(x => x.Category1).Select(y => y.First()).OrderBy(x => x.Category1).Where(x => x.Category1 != string.Empty).ToList();
            //this.PandSSoldToCustomersListCat2 = this.PandSSoldToCustomersList.GroupBy(x => x.Category2).Select(y => y.First()).OrderBy(x => x.Category2).Where(x => x.Category1 != string.Empty).ToList();
            //allPosition.Category1 = "All";
            //allPosition.Category2 = "All";
            //this.PandSSoldToCustomersListCat1.Insert(0, allPosition);
            //this.PandSSoldToCustomersListCat2.Insert(0, allPosition);
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.PandSSoldToCustomersList.Count();
            else
                this.ShowSelectedCount = 0;
            //this.PandSSoldToCustomersListcmb = this.PandSSoldToCustomersList.OrderBy(x => x.CustomerName).ToList();
            //this.PandSSoldToCustomersListcmbCredit = this.PandSSoldToCustomersListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
            //this.PandSSoldToCustomersListcmbSup = this.PandSSoldToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
            //this.PandSSoldToCustomersListcmbInv = this.PandSSoldToCustomersList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
            //DefaultList = this.PandSSoldToCustomersListcmb;
            ////changedateformat(this.PandSSoldToCustomersList);
            ////changedateformat(this.PandSSoldToCustomersListcmb);
            //changeNumberformat(this.PandSSoldToCustomersList);
            //changeNumberformat(this.PandSSoldToCustomersListcmb);
            Mouse.OverrideCursor = null;
        }
        void NavigatetoSupplier(object param)
        {
            //if (param != null)
            //{
            //    string obj = param.ToString();
            //    SharedValues.getValue = obj;
            //}
            //var mainview = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersView>();
            //var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            //mainregion.Add(mainview);
            //if (mainregion != null)
            //{
            //    mainregion.Activate(mainview);
            //}


            //var tabview = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();
            //var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            //tabregion.Add(tabview);
            //if (tabregion != null)
            //{
            //    tabregion.Activate(tabview);
            //}

            //eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details Form");
        }
        void NavigatetoSalesInvoice(object param)
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

            //var mainview = ServiceLocator.Current.GetInstance<SalesInvoiceView>();

            //var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            //mainregion.Add(mainview);
            //if (mainregion != null)
            //{
            //    mainregion.Activate(mainview);
            //}////
            //eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoice Form");
        }
        void NavigateToProduct(object param)
        {
            //if (param != null)
            //{
            //    string obj = param.ToString();
            //    SharedValues.getValue = obj;
            //}
            //var mainview = ServiceLocator.Current.GetInstance<PandSDetailsView>();
            //var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            //mainregion.Add(mainview);
            //if (mainregion != null)
            //{
            //    mainregion.Activate(mainview);
            //}


            //var tabview = ServiceLocator.Current.GetInstance<ProductTabView>();
            //var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            //tabregion.Add(tabview);
            //if (tabregion != null)
            //{
            //    tabregion.Activate(tabview);
            //}

            //eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Details form");
        }
        void NavigateToCustomer(object param)
        {
            if (param != null)
            {
                string obj = param.ToString();
                SharedValues.getValue = obj;
            }
            var mainview = ServiceLocator.Current.GetInstance<CustomersView>();
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customer Detail Form");
        }
        void ShowSummary(object param)
        {
            this.IsSummary = true;
            IPandSSoldToCustomersRepository purchaseRepository = new PandSSoldToCustomersRepository();
            this.PandSSoldToCustomersList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData, this.IncludingGSTTrue, this.IsSummary).ToList();
            DefaultList = this.PandSSoldToCustomersList;
            this.PandSSoldToCustomersListCode = this.PandSSoldToCustomersList.GroupBy(x => x.PandSCode).Select(y => y.First()).OrderBy(x => x.PandSCode).ToList();
            this.PandSSoldToCustomersListName = this.PandSSoldToCustomersList.GroupBy(x => x.PandSName).Select(y => y.First()).OrderBy(x => x.PandSName).ToList();
            this.PandSSoldToCustomersListCus = this.PandSSoldToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).ToList();
            Mouse.OverrideCursor = null;
        }
        void ShowDetails(object param)
        {
            this.IsSummary = false;
            Search(null);
            IPandSSoldToCustomersRepository purchaseRepository = new PandSSoldToCustomersRepository();
            this.PandSSoldToCustomersList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData, this.IncludingGSTTrue, this.IsSummary).ToList();
            DefaultList = this.PandSSoldToCustomersList;
            this.PandSSoldToCustomersListCode = this.PandSSoldToCustomersList.GroupBy(x => x.PandSCode).Select(y => y.First()).OrderBy(x => x.PandSCode).ToList();
            this.PandSSoldToCustomersListName = this.PandSSoldToCustomersList.GroupBy(x => x.PandSName).Select(y => y.First()).OrderBy(x => x.PandSName).ToList();
            this.PandSSoldToCustomersListCus = this.PandSSoldToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).ToList();
            Mouse.OverrideCursor = null;
        }
        void ShowAll(object param)
        {
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.SelectedSearchStartDate = null;
            this.SelectedSearchEndDate = null;
            this.ShowSelectedCount = 0;
            this.ShowAllTrue = true;
            Search(null);
            this.SelectedCategory1 = "All";
            this.SelectedCategory2 = "All";
            Mouse.OverrideCursor = null;
        }
        void ShowProduct(object param)
        {
            this.PandS = 1;
            Search(null);
            this.SelectedCategory1 = "All";
            this.SelectedCategory2 = "All";
            Mouse.OverrideCursor = null;
        }
        void ShowService(object param)
        {

            this.PandS = 2;
            Search(null);
            this.SelectedCategory1 = "All";
            this.SelectedCategory2 = "All";
            Mouse.OverrideCursor = null;
        }
        void ShowBothTrue(object param)
        {

            this.PandS = 0;
            Search(null);
            this.SelectedCategory1 = "All";
            this.SelectedCategory2 = "All";
            Mouse.OverrideCursor = null;
        }
        void ShowExcludingTax(object param)
        {

            this.IncludingGSTTrue = false;
            Search(null);
            this.SelectedCategory1 = "All";
            this.SelectedCategory2 = "All";
            Mouse.OverrideCursor = null;
        }
        void ShowIncludingTax(object param)
        {

            this.IncludingGSTTrue = true;
            Search(null);
            this.SelectedCategory1 = "All";
            this.SelectedCategory2 = "All";
            Mouse.OverrideCursor = null;
        }

        void ShowSelected(object param)
        {
            this.ShowAllTrue = false;
            Search(null);
            this.SelectedCategory1 = "All";
            this.SelectedCategory2 = "All";
            Mouse.OverrideCursor = null;
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

                IPandSSoldToCustomersRepository purchaseRepository = new PandSSoldToCustomersRepository();
                var results = purchaseRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.PandSSoldToCustomers), "PandS_Sold_List");
                if (Count != 0)
                {
                    this.PandSSoldToCustomersList = purchaseRepository.GetAllSalesInvoiceJson(jsonSearch, this.IncludingGSTTrue,this.IsSummary).ToList();
                    DefaultList = this.PandSSoldToCustomersList;
                    this.TotalQuantity = Convert.ToString(this.PandSSoldToCustomersList.Sum(e => e.Qty));
                    this.TotalPrice = Convert.ToString(this.PandSSoldToCustomersList.Sum(e => e.Price));
                    this.TotalAmount = Convert.ToString(this.PandSSoldToCustomersList.Sum(e => e.Amount));
                    this.PandSSoldToCustomersListCode = this.PandSSoldToCustomersList.GroupBy(x => x.PandSCode).Select(y => y.First()).OrderBy(x => x.PandSCode).ToList();
                    this.PandSSoldToCustomersListName = this.PandSSoldToCustomersList.GroupBy(x => x.PandSName).Select(y => y.First()).OrderBy(x => x.PandSName).ToList();
                    this.PandSSoldToCustomersListCus = this.PandSSoldToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).ToList();
                    this.PandSSoldToCustomersListCat1 = this.PandSSoldToCustomersList.GroupBy(x => x.Category1).Select(y => y.First()).OrderBy(x => x.Category1).Where(x => x.Category1 != string.Empty && x.Category1 != null).ToObservable();
                    this.PandSSoldToCustomersListCat2 = this.PandSSoldToCustomersList.GroupBy(x => x.Category2).Select(y => y.First()).OrderBy(x => x.Category2).Where(x => x.Category2 != string.Empty && x.Category2 != null).ToObservable();
                    allPosition.Category1 = "All";
                    allPosition.Category2 = "All";
                    this.PandSSoldToCustomersListCat1.Insert(0, allPosition);
                    this.PandSSoldToCustomersListCat2.Insert(0, allPosition);
                    this.SelectedCategory1 = "All";
                    this.SelectedCategory2 = "All";
                    //changedateformat(this.PandSSoldToCustomersList);
                    //changeNumberformat(this.PandSSoldToCustomersList);

                }

                //this.PandSSoldToCustomersListcmb = this.PandSSoldToCustomersList.OrderBy(x => x.CustomerName).ToList();
                //this.PandSSoldToCustomersListcmbCredit = this.PandSSoldToCustomersListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
                //this.PandSSoldToCustomersListcmbSup = this.PandSSoldToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
                //this.PandSSoldToCustomersListcmbInv = this.PandSSoldToCustomersList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
                if (this.ShowAllTrue == true)
                    this.ShowSelectedCount = this.ShowSelectedCount;
                else
                    this.ShowSelectedCount = this.PandSSoldToCustomersList.Count();
                //DefaultList = this.PandSSoldToCustomersListcmb;
                //
                //TotalInvoiceAmount = Convert.ToString(PandSSoldToCustomersList.Sum(e => e.InvoiceAmountValue));
                //TotalCCDAmount = Convert.ToString(PandSSoldToCustomersList.Sum(e => e.TotalAmount));
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
        List<PandSSoldToCustomersEntity> DefaultList = new List<PandSSoldToCustomersEntity>();
        List<PandSSoldToCustomersEntity> FullPQList = new List<PandSSoldToCustomersEntity>();
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {

            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 115;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.PandSSoldToCustomersGridHeight = minHeight;
            RefreshData();
        }

        private void RefreshData()
        {
            IPandSSoldToCustomersRepository purchaseRepository = new PandSSoldToCustomersRepository();
            this.DateFormat = purchaseRepository.GetDateFormat();
            this.ShowAllCount = purchaseRepository.GetAllSalesInvoice().Count();
            GetOptionsandTaxValues();
            this.AllCount = purchaseRepository.getTotalCount(Convert.ToInt32(ScreenId.PandSSoldToCustomers));
            this.JsonData = purchaseRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.PandSSoldToCustomers));
            this.IsSummary = true;
            this.IsSummaryTrue = true;
            this.IsSummaryFalse = false;
            this.PandSSoldToCustomersList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData, this.IncludingGSTTrue,this.IsSummary).ToList();
            DefaultList = this.PandSSoldToCustomersList;
            this.TotalQuantity = Convert.ToString(this.PandSSoldToCustomersList.Sum(e => e.Qty));
            this.TotalPrice = Convert.ToString(this.PandSSoldToCustomersList.Sum(e => e.Price));
            this.TotalAmount = Convert.ToString(this.PandSSoldToCustomersList.Sum(e => e.Amount));
            this.PandSSoldToCustomersListCode = this.PandSSoldToCustomersList.GroupBy(x => x.PandSCode).Select(y => y.First()).OrderBy(x => x.PandSCode).ToList();
            this.PandSSoldToCustomersListName = this.PandSSoldToCustomersList.GroupBy(x => x.PandSName).Select(y => y.First()).OrderBy(x => x.PandSName).ToList();
            this.PandSSoldToCustomersListCus = this.PandSSoldToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).ToList();
            this.PandSSoldToCustomersListCat1 = this.PandSSoldToCustomersList.GroupBy(x => x.Category1).Select(y => y.First()).OrderBy(x => x.Category1).Where(x => x.Category1 != string.Empty && x.Category1 != null).ToObservable();
            this.PandSSoldToCustomersListCat2 = this.PandSSoldToCustomersList.GroupBy(x => x.Category2).Select(y => y.First()).OrderBy(x => x.Category2).Where(x => x.Category2 != string.Empty && x.Category2 != null).ToObservable();
            allPosition.Category1 = "All";
            allPosition.Category2 = "All";
            this.PandSSoldToCustomersListCat1.Insert(0, allPosition);
            this.PandSSoldToCustomersListCat2.Insert(0, allPosition);

            if (this.JsonData != null)
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                if (objResponse1[6].FieldValue == "True")
                {
                    this.ShowAllTrue = true;
                    this.ShowSelectedTrue = false;
                    this.YearmonthQuartTrue = true;
                    this.StartEndDateTrue = false;
                }
            }
            else
            {
                this.ShowAllTrue = true;
                this.ShowSelectedTrue = false;
                this.YearmonthQuartTrue = true;
                this.StartEndDateTrue = false;
            }

            this.ShowSelectedCount = this.PandSSoldToCustomersList.Count();

            this.YearRange = purchaseRepository.GetYearRange().ToList();

            SetDefaultSearchSelection(this.JsonData);

        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            IPandSSoldToCustomersRepository purchaseRepository = new PandSSoldToCustomersRepository();
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
                    //foreach (var item in this.PandSSoldToCustomersList)
                    //{
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    //this.PandSSoldToCustomersList = this.PandSSoldToCustomersList.Where(x => x.ExcIncGST == true).ToList();
                }
                else
                {
                    this.IncludingGSTTrue = false;
                    this.IncludingGSTFalse = true;
                    int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.PandSSoldToCustomersList)
                    //{
                    //    //item.InvoiceAmount = item.InvoiceAmountExcGST;
                    //    //item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountExcGST), decimalpoints).ToString();
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    if (this.PandSSoldToCustomersList != null)
                        this.PandSSoldToCustomersList = this.PandSSoldToCustomersList.ToList();
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

        void changedateformat(List<PandSSoldToCustomersEntity> entity)
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
        void changeNumberformat(List<PandSSoldToCustomersEntity> entity)
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
                        case "PandS":
                            if (!string.IsNullOrWhiteSpace(item.FieldValue))
                            {
                                if (Convert.ToInt16(item.FieldValue) == 0)
                                {
                                    this.ShowBoth = true;
                                    this.ShowProducts = false;
                                    this.ShowServices = false;
                                }
                                if (Convert.ToInt16(item.FieldValue) == 1)
                                {
                                    this.ShowBoth = false;
                                    this.ShowProducts = true;
                                    this.ShowServices = false;
                                }
                                if (Convert.ToInt16(item.FieldValue) == 2)
                                {
                                    this.ShowBoth = false;
                                    this.ShowProducts = false;
                                    this.ShowServices = true;
                                }
                            }

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
        public void LoadSearchResult(string customerName)
        {
            IPandSSoldToCustomersRepository purchaseRepository = new PandSSoldToCustomersRepository();
            //this.ShowAllCount = purchaseRepository.GetAllSalesInvoice().Count();
            //this.PandSSoldToCustomersList = purchaseRepository.GetAllSalesInvoice().Where(x => x.CustomerName == customerName).ToList();
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
                //case "SelectedSearchSupName":
                //    GetData(this.SelectedSearchSupName, "Supplier");
                //    break;
                //case "SelectedSearchPI_Status":
                //    GetData(this.SelectedSearchPI_Status, "PI_Status");
                //    break;
                //case "SelectedCreditNoteNo":
                //    GetData(this.SelectedCreditNoteNo, "CreditNote");
                //    break;
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
                case "SelectedPandSCode":
                    GetData(this.SelectedPandSCode, "SelectedPandSCode");
                    break;
                case "SelectedPandSName":
                    GetData(this.SelectedPandSName, "SelectedPandSName");
                    break;
                case "SelectedCustomerName":
                    GetData(this.SelectedCustomerName, "SelectedCustomerName");
                    break;
                case "SelectedCategory1":
                    GetData(this.SelectedCategory1, "SelectedCategory1");
                    break;
                case "SelectedCategory2":
                    GetData(this.SelectedCategory2, "SelectedCategory2");
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
            //IPandSSoldToCustomersListRepository purchaseRepository = new PandSSoldToCustomersListRepository();
            //var result = purchaseRepository.GetAllPurInvoice().ToList();

            if (parameter == "SelectedPandSCode")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {
                    this.PandSSoldToCustomersList = DefaultList.Where(x => x.PandSCode == SearchFilter).ToList();
                }
                else
                {
                    this.PandSSoldToCustomersList = DefaultList.ToList();
                }
            }
            if (parameter == "SelectedPandSName")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {
                    this.PandSSoldToCustomersList = DefaultList.Where(x => x.PandSName == SearchFilter).ToList();
                }
                else
                {
                    this.PandSSoldToCustomersList = DefaultList.ToList();
                }
            }
            if (parameter == "SelectedCustomerName")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {
                    this.PandSSoldToCustomersList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                }
                else
                {
                    this.PandSSoldToCustomersList = DefaultList.ToList();
                }
            }
            if (parameter == "SelectedCategory1")
            {
                if (!string.IsNullOrWhiteSpace(SearchFilter))
                {
                    if (SearchFilter != "All")
                    {
                        if (this.SelectedCategory2 != "All")
                        {
                            this.PandSSoldToCustomersList = DefaultList.Where(x => x.Category1 == SearchFilter && x.Category2 == this.SelectedCategory2).ToList();
                        }
                        else
                            this.PandSSoldToCustomersList = DefaultList.Where(x => x.Category1 == SearchFilter).ToList();
                        //DefaultList = this.PandSCostPriceList;
                    }
                    else if (this.SelectedCategory2 != "All")
                    {
                        this.PandSSoldToCustomersList = DefaultList.Where(x => x.Category2 == this.SelectedCategory2).ToList();
                    }

                    else { this.PandSSoldToCustomersList = DefaultList; }
                }

                else
                {
                    this.PandSSoldToCustomersList = DefaultList;
                    //allPosition.Category1 = "All";

                    //this.PandSSoldToCustomersListCat1.Insert(0, allPosition);

                    this.SelectedCategory1 = "All";
                }

            }
            if (parameter == "SelectedCategory2")
            {
                if (!string.IsNullOrWhiteSpace(SearchFilter))
                {
                    if (SearchFilter != "All")
                    {
                        if (this.SelectedCategory1 != "All")
                        {
                            this.PandSSoldToCustomersList = DefaultList.Where(x => x.Category2 == SearchFilter && x.Category1 == this.SelectedCategory1).ToList();
                        }
                        else
                            this.PandSSoldToCustomersList = DefaultList.Where(x => x.Category2 == SearchFilter).ToList();
                        //DefaultList = this.PandSCostPriceList;
                    }
                    else if (this.SelectedCategory1 != "All")
                    {
                        this.PandSSoldToCustomersList = DefaultList.Where(x => x.Category1 == this.SelectedCategory1).ToList();
                    }

                    else { this.PandSSoldToCustomersList = DefaultList; }
                }
                else
                {
                    this.PandSSoldToCustomersList = DefaultList;

                    //allPosition.Category2 = "All";

                    //this.PandSSoldToCustomersListCat2.Insert(0, allPosition);
                    this.SelectedCategory2 = "All";
                }

            }
        }
        //else
        //{

        //        this.PandSSoldToCustomersList = DefaultList.ToList();
        //    this.PandSSoldToCustomersListCode = this.PandSSoldToCustomersList.GroupBy(x => x.PandSCode).Select(y => y.First()).OrderBy(x => x.PandSCode).ToList();
        //    this.PandSSoldToCustomersListName = this.PandSSoldToCustomersList.GroupBy(x => x.PandSName).Select(y => y.First()).OrderBy(x => x.PandSName).ToList();
        //    this.PandSSoldToCustomersListCus = this.PandSSoldToCustomersList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).ToList();
        //this.PandSSoldToCustomersListCat1 = this.PandSSoldToCustomersList.GroupBy(x => x.Category1).Select(y => y.First()).OrderBy(x => x.Category1).Where(x => x.Category1 != string.Empty && x.Category1 != null).ToList();
        //this.PandSSoldToCustomersListCat2 = this.PandSSoldToCustomersList.GroupBy(x => x.Category2).Select(y => y.First()).OrderBy(x => x.Category2).Where(x => x.Category2 != string.Empty && x.Category2 != null).ToList();
        //allPosition.Category1 = "All";
        //allPosition.Category2 = "All";
        //this.PandSSoldToCustomersListCat1.Insert(0, allPosition);
        //this.PandSSoldToCustomersListCat2.Insert(0, allPosition);


        //}
        //changedateformat(PandSSoldToCustomersList);
        //changeNumberformat(PandSSoldToCustomersList);
        // TotalInvoiceAmount = Convert.ToString(PandSSoldToCustomersList.Sum(e => e.InvoiceAmountValue));
        // TotalCCDAmount = Convert.ToString(PandSSoldToCustomersList.Sum(e => e.TotalAmount));
        //}
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