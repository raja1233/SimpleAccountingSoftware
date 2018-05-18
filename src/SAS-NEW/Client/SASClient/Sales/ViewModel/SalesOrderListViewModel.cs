﻿
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using Microsoft.Practices.Prism.Events;
//using Purchasing.View;
using SDN.UI.Entities.Sales;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using SDN.UI.Entities;
using SDN.Common;
using SDN.Sales.Services;
using SDN.Sales.Views;
using Microsoft.Practices.Prism.Commands;
using SASClient.CloseRequest;
using System.Windows;

namespace SDN.Sales.ViewModel
{
   

    public class SalesOrderListViewModel : SalesOrderListEntity
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
        /// Initializes a new instance of the <see cref="SalesOrderListViewModel"/> class.
        /// </summary>
        public SalesOrderListViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            SearchCommand = new RelayCommand(Search);
            ShowAllCommand = new RelayCommand(ShowAll);
            ShowSelectedCommand = new RelayCommand(ShowSelected);
            NavigateToClientCommand = new RelayCommand(NavigatetoCustomer);
            ShowIncGSTCommand = new RelayCommand(showincGST);
            ShowExcGSTCommand = new RelayCommand(showexcGST);
            RefreshCommand = new RelayCommand(refreshcommand);
            NavigaetoSalesCommand = new RelayCommand(NavigatetoSalesOrder);
            YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
            CalendarSelectionCommand = new RelayCommand(OnCalendarSelection);
            NavigateToConvertedToCommand = new RelayCommand(NavigateToSOSI);
            CloseCommand = new DelegateCommand(Close);
        }

        public SalesOrderListViewModel()
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
        public RelayCommand NavigateToConvertedToCommand { get; set; }
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
            IncludingGSTTrue = true;
            IncludingGSTFalse = false;
            //foreach (var item in this.SalesOrderList)
            //{
            //    //item.OrderAmount = item.OrderAmountIncGST;
            //    item.OrderAmount = Math.Round(Convert.ToDouble(item.OrderAmountIncGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.SalesOrderList = DefaultList.Where(x => x.ExcIncGST == true).ToList();
            //else
            //    this.SalesOrderList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            this.SalesOrderList = purchaseRepository.GetAllSalesOrderJson(this.JsonData, this.IncludingGSTTrue).ToList();
            this.SalesOrderListcmbSup = this.SalesOrderList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x=>x.CustomerName).Distinct().ToList();
            this.SalesOrderListcmbONo = this.SalesOrderList.GroupBy(x => x.OrderNo).Select(y => y.First()).OrderBy(x => x.SortOrderNo).Distinct().ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.SalesOrderList.Count();
            else
                this.ShowSelectedCount = 0;
            this.SalesOrderListcmb = this.SalesOrderList;
            DefaultList = this.SalesOrderListcmb;
            changedateformat(this.SalesOrderList);
            changeNumberformat(this.SalesOrderList);
            TotalOrderAmount = Convert.ToString(SalesOrderList.Sum(e => e.OAmount));
            TotalDepositAmount = Convert.ToString(SalesOrderList.Sum(e => e.DAmount));
            Mouse.OverrideCursor = null;
        }
        void showexcGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            IncludingGSTTrue = false;
            IncludingGSTFalse = true;
            //foreach (var item in this.SalesOrderList)
            //{
            //    //item.OrderAmount = item.OrderAmountExcGST;
            //    item.OrderAmount = Math.Round(Convert.ToDouble(item.OrderAmountExcGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.SalesOrderList = DefaultList.Where(x => x.ExcIncGST == false).ToList();
            //else
            //    this.SalesOrderList = FullPQList.Where(x => x.ExcIncGST == false).ToList();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            this.SalesOrderList = purchaseRepository.GetAllSalesOrderJson(this.JsonData, this.IncludingGSTTrue).OrderBy(x => x.CustomerName).ToList();
            this.SalesOrderListcmbSup = this.SalesOrderList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
            this.SalesOrderListcmbONo = this.SalesOrderList.GroupBy(x => x.OrderNo).Select(y => y.First()).OrderBy(x => x.SortOrderNo).Distinct().ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.SalesOrderList.Count();
            else
                this.ShowSelectedCount = 0;
            this.SalesOrderListcmb = this.SalesOrderList;
            DefaultList = this.SalesOrderListcmb;
            changedateformat(this.SalesOrderList);
            changeNumberformat(this.SalesOrderList);
            TotalOrderAmount = Convert.ToString(SalesOrderList.Sum(e => e.OAmount));
            TotalDepositAmount = Convert.ToString(SalesOrderList.Sum(e => e.DAmount));
            Mouse.OverrideCursor = null;
        }
        void NavigatetoCustomer(object param)
        {
            SharedValues.ScreenCheckName = "Customers Details";
            SharedValues.ViewName = "Customers Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customer Details Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        void NavigatetoSalesOrder(object param)
        {
            SharedValues.ScreenCheckName = "Sales Order";
            SharedValues.ViewName = "Sales Order";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (param != null)
            {
                string obj = param.ToString();
                SharedValues.NewClick = obj;
            }
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<SalesOrderView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Order Form");
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
            this.ShowAllTrue = true;
            this.SalesOrderList = FullPQList;
            this.SalesOrderListcmb = FullPQList;
            //this.ShowAllTrue = true;
            this.SalesOrderListcmbSup = this.SalesOrderList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
            this.SalesOrderListcmbONo = this.SalesOrderList.GroupBy(x => x.OrderNo).Select(y => y.First()).OrderBy(x => x.SortOrderNo).Distinct().ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.SalesOrderList.Count();
            else
                this.ShowSelectedCount = this.SalesOrderList.Count();
            this.SelectedSearchEndDate = null;
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.SelectedSearchStartDate = null;
            this.SelectedSearchEndDate = null;
            this.SalesOrderList = FullPQList.ToList();
            if (this.IncludingGSTTrue == true)
                this.SalesOrderList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            else
                this.SalesOrderList = FullPQList.Where(x => x.ExcIncGST == false).ToList();
            Search(null);
            Mouse.OverrideCursor = null;
        }
        void ShowSelected(object param)
        {
            Search(null);
        }

        private void NavigateToSOSI(object param)
        {
            SharedValues.ViewName = "SalesOrderView";
            if (param != null)
            {
                string obj = param.ToString();
                SharedValues.NewClick = obj;
                var checkOrderInvoice = obj.Split('-')[0];

                if (checkOrderInvoice == "SO")
                {
                    SharedValues.ScreenCheckName = "Sales Order";
                    SharedValues.ViewName = "Sales Order";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.getValue = "SalesOrderTab";
                    var mainview = ServiceLocator.Current.GetInstance<SalesOrderView>();

                    var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                    mainregion.Add(mainview);
                    if (mainregion != null)
                    {
                        mainregion.Activate(mainview);
                    }

                    eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Order Form");
                    }
                    else
                    {
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                else if (checkOrderInvoice == "SI")
                {
                    SharedValues.ScreenCheckName = "Sales Invoice";
                    SharedValues.ViewName = "Sales Invoice";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.getValue = "SalesInvoiceTab";
                    var mainview = ServiceLocator.Current.GetInstance<SalesInvoiceView>();
                    var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                    mainregion.Add(mainview);
                    if (mainregion != null)
                    {
                        mainregion.Activate(mainview);
                    }
                    eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoice Form");
                    }
                    else
                    {
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();
                var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                tabregion.Add(tabview);
                if (tabregion != null)
                {
                    tabregion.Activate(tabview);
                }
                
            }

        }
        void Search(object param)
        {

            if (Count != 0)
            {


                SearchValues = new List<SearchEntity>();
                this.ShowSelectedTrue = true;
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
                    //    this.SalesOrderListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.SalesOrderListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.SalesOrderListcmb = DefaultList;
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
                    //    this.SalesOrderListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.SalesOrderListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.SalesOrderListcmb = DefaultList;
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
                    //    this.SalesOrderListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.SalesOrderListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.SalesOrderListcmb = DefaultList;
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
                    //    this.SalesOrderListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.SalesOrderListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.SalesOrderListcmb = DefaultList;
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

                //this.SalesOrderList = this.SalesOrderListInternal;
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;

                ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
                var results = purchaseRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.SalesOrderList), "Sales_Order_List");
                if (Count != 0)
                    this.SalesOrderList = purchaseRepository.GetAllSalesOrderJson(jsonSearch, this.IncludingGSTTrue);
                if(this.SalesOrderList!=null)
                {
                    changedateformat(this.SalesOrderList);
                    changeNumberformat(this.SalesOrderList);
                }
                this.SalesOrderListcmb = this.SalesOrderList;
                this.SalesOrderListcmbSup = this.SalesOrderList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
                this.SalesOrderListcmbONo = this.SalesOrderList.GroupBy(x => x.OrderNo).Select(y => y.First()).OrderBy(x => x.SortOrderNo).Distinct().ToList();
                if (this.ShowAllTrue == true)
                    this.ShowSelectedCount = this.SalesOrderListcmb.Count();
                else
                    this.ShowSelectedCount = this.SalesOrderList.Count();
                DefaultList = this.SalesOrderListcmb;
                
                TotalOrderAmount = Convert.ToString(SalesOrderList.Sum(e => e.OAmount));
                TotalDepositAmount = Convert.ToString(SalesOrderList.Sum(e => e.DAmount));
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
        List<SalesOrderListEntity> DefaultList = new List<SalesOrderListEntity>();
        List<SalesOrderListEntity> FullPQList = new List<SalesOrderListEntity>();
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {
            //GetOptionsData();
            //var height = System.Windows.SystemParameters.PrimaryScreenHeight;
            //if (height == 768)
            //    this.SOGridHeight = 425;
            //else if (height == 1024)
            //    this.SOGridHeight = 680;
            //else if (height == 1440)
            //    this.SOGridHeight = 956;
            //else if (height == 1800)
            //    this.SOGridHeight = 1195;
            //else
            //    this.SOGridHeight = 680;
            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 56;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SOGridHeight = minHeight;
            RefreshData();
        }

        private void RefreshData()
        {
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            this.DateFormat = purchaseRepository.GetDateFormat();
            this.ShowAllCount = purchaseRepository.GetAllSalesOrder().Count();
            GetOptionsandTaxValues();
            this.JsonData = purchaseRepository.GetLastSelectionData();
            this.SalesOrderList = purchaseRepository.GetAllSalesOrderJson(this.JsonData, this.IncludingGSTTrue).OrderBy(x=>x.CustomerName).ToList();
            this.ShowSelectedCount = this.SalesOrderList.Count();
            this.SalesOrderListcmb = purchaseRepository.GetAllSalesOrder().OrderBy(x=>x.CustomerName).ToList();
            changedateformat(this.SalesOrderListcmb);
            //changeNumberformat(this.SalesOrderListcmb);
            changedateformat(this.SalesOrderList);
            //changeNumberformat(this.SalesOrderList);
           
            FullPQList = this.SalesOrderListcmb;
            DefaultList = this.SalesOrderList;
         
            this.YearRange = purchaseRepository.GetYearRange().ToList();
            
            TotalOrderAmount = Convert.ToString(SalesOrderList.Sum(e => e.OAmount));
            TotalDepositAmount = Convert.ToString(SalesOrderList.Sum(e => e.DAmount));
            this.ShowAllCount = this.SalesOrderListcmb.Count();
            SetDefaultSearchSelection();
            var Updateddate = this.SalesOrderListcmb.Max(x => x.CreatedDateList);
            string date = this.DateFormat as string;
            this.LastUpdateDate = Convert.ToDateTime(Updateddate).ToString(date);

            //TotalOrderAmount = Convert.ToString(SalesOrderList.Sum(e => e.OAmount));
            //TotalDepositAmount = Convert.ToString(SalesOrderList.Sum(e => e.DAmount));
            //this.GetData(this.SelectedSearchSupplier);
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
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
                    //foreach (var item in this.SalesOrderList)
                    //{
                    //    item.OrderAmount = Math.Round(Convert.ToDouble(item.OrderAmount), decimalpoints).ToString();
                    //}
                    //this.SalesOrderList = this.SalesOrderList.Where(x => x.ExcIncGST == true).ToList();
                }
                else
                {
                    this.IncludingGSTTrue = false;
                    this.IncludingGSTFalse = true;
                    int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.SalesOrderList)
                    //{
                    //    //item.OrderAmount = item.OrderAmountExcGST;
                    //    //item.OrderAmount = Math.Round(Convert.ToDouble(item.OrderAmountExcGST), decimalpoints).ToString();
                    //    item.OrderAmount = Math.Round(Convert.ToDouble(item.OrderAmount), decimalpoints).ToString();
                    //}
                    //if (this.SalesOrderList != null)
                    //    this.SalesOrderList = this.SalesOrderList.Where(x => x.ExcIncGST == false).ToList();
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

        void changedateformat(List<SalesOrderListEntity> entity)
        {
            string date = this.DateFormat as string;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            foreach (var item in entity)
            {
                item.SortOrderNo = Convert.ToInt32(item.OrderNo.Substring(3));
                item.OrderDate = Convert.ToDateTime(item.OrderDate).ToString(date).Replace('-','/');
                item.DeliveryDateTime = Convert.ToDateTime(item.DeliveryDateTime).ToString(date).Replace('-', '/');
                if (item.OrderAmount != null && item.OrderAmount != "")
                    item.OrderAmount = Math.Round(Convert.ToDouble(item.OrderAmount), decimalpoints).ToString();
            }
        }
        void changeNumberformat(List<SalesOrderListEntity> entity)
        {
          
            //foreach (var item in entity)
            //{
               
            //}
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
            this.StartEndDateTrue = false;
            this.EnableYearDropDown = true;
            this.EnableMonthDropDown = true;
            this.EnableQuarterDropDown = true;
            this.SelectedSearchQuarter = lastQuarter.ToString();

        }
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
        //        //this.ShowSelectedTrue = false;
        //        this.YearmonthQuartTrue = false;//change to false after feedback on 22 may 
        //        this.StartEndDateTrue = false;
        //        //this.ShowSelectedCount = 0;
        //    }
        //}
        public void LoadSearchResult(string customerName)
        {
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            this.ShowAllCount = purchaseRepository.GetAllSalesOrder().Count();
            this.SalesOrderList = purchaseRepository.GetAllSalesOrder().Where(x => x.CustomerName == customerName).OrderBy(x=>x.CustomerName).ToList();
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
                    GetData(this.SelectedSearchSupName, "Customer");
                    if (this.ShowAllTrue == true)
                        this.ShowSelectedCount = this.SalesOrderList.Count();
                    else
                        this.ShowSelectedCount = this.SalesOrderList.Count();
                    break;

                case "SelectedSearchConvertedTo":
                    GetData(this.SelectedSearchConvertedTo, "ConvertedTo");
                    if (this.ShowAllTrue == true)
                        this.ShowSelectedCount = this.SalesOrderList.Count();
                    else
                        this.ShowSelectedCount = this.SalesOrderList.Count();
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
                this.YearmonthQuartTrue = true;//added after feedback
                this.ShowAllTrue = false;
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
            //ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            //var result = purchaseRepository.GetAllPurOrder().ToList();
            if (SearchFilter != null || SearchFilter == string.Empty)
            {
                if (parameter == "Customer")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        //commented and added on 23 May 2017
                        this.SalesOrderList = FullPQList.Where(x => (x.CustomerName == SearchFilter || x.OrderNo == SearchFilter || x.ConvertedTo == SearchFilter)).OrderBy(x=>x.CustomerName).ToList();
                        //if (this.IncludingGSTTrue == true)
                        //{
                        //    this.SalesOrderList = FullPQList.Where(x => (x.CustomerName == SearchFilter || x.OrderNo == SearchFilter || x.ConvertedTo == SearchFilter) && x.ExcIncGST == true).ToList();
                        //}
                        //else
                        //{
                        //    this.SalesOrderList = FullPQList.Where(x => (x.CustomerName == SearchFilter || x.OrderNo == SearchFilter || x.ConvertedTo == SearchFilter) && x.ExcIncGST == false).ToList();
                        //}
                    }
                    else
                    {
                        //commented and added on 23 May 2017
                        this.SalesOrderList = this.SalesOrderList = DefaultList.Where(x => (x.CustomerName == SearchFilter || x.OrderNo == SearchFilter || x.ConvertedTo == SearchFilter)).OrderBy(x=>x.CustomerName).ToList();
                        //if (this.IncludingGSTTrue == true)
                        //{
                        //    this.SalesOrderList = DefaultList.Where(x => (x.CustomerName == SearchFilter || x.OrderNo == SearchFilter || x.ConvertedTo == SearchFilter) && x.ExcIncGST == true).ToList();
                        //}
                        //else
                        //{
                        //    this.SalesOrderList = DefaultList.Where(x => (x.CustomerName == SearchFilter || x.OrderNo == SearchFilter || x.ConvertedTo == SearchFilter) && x.ExcIncGST == false).ToList();
                        //}
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }
                if (parameter == "ConvertedTo")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        var search = SearchFilter.Split(':')[1];
                        if (search == " Converted to SO")
                            this.SalesOrderList = FullPQList.Where(x => x.ConvertedToSO == true).ToList();
                        else if (search == " Converted to SI")
                            this.SalesOrderList = FullPQList.Where(x => x.ConvertedToSI == true).ToList();
                        else if (search == " Not Converted")
                        {
                            this.SalesOrderList = FullPQList.Where(x => (x.ConvertedToSI == false || x.ConvertedToSI == null) && (x.ConvertedToSO == false || x.ConvertedToSO == null)).ToList();
                        }
                        else if (search == " All")
                        {
                            this.SalesOrderList = FullPQList.ToList();
                        }
                    }
                    else
                    {
                        var search = SearchFilter.Split(':')[1];
                        if (search == " Converted to SO")
                            this.SalesOrderList = DefaultList.Where(x => x.ConvertedToSO == true).ToList();
                        else if (search == " Converted to SI")
                            this.SalesOrderList = DefaultList.Where(x => x.ConvertedToSI == true).ToList();
                        else if (search == " Not Converted")
                        {
                            this.SalesOrderList = DefaultList.Where(x => (x.ConvertedToSI == false || x.ConvertedToSI == null) && (x.ConvertedToSO == false || x.ConvertedToSO == null)).ToList();
                        }
                        else if (search == " All")
                        {
                            this.SalesOrderList = DefaultList.ToList();
                        }
                    }

                //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
            }
            //if (parameter == "OrderNo")
            //{
            //    this.ShowAllCount = this.ShowAllCount;
            //    this.SalesOrderList = DefaultList.Where(x => x.OrderNo == SearchFilter).ToList();
            //    DefaultList = DefaultList.Where(x => x.OrderNo == SearchFilter).ToList();
            //}
            //if (parameter == "SearchYear")
            //{
            //    this.ShowAllCount = this.ShowAllCount;
            //    this.SalesOrderList = DefaultList.Where(x => x.CreatedDate.Value.Year.ToString() == SearchFilter).ToList();
            //}
            //if (parameter == "Supplier")
            //{
            //    this.ShowAllCount = this.ShowAllCount;
            //    this.SalesOrderList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
            //}
            //if (parameter == "Supplier")
            //{
            //    this.ShowAllCount = this.ShowAllCount;
            //    this.SalesOrderList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
            //}
            //if (parameter == "Supplier")
            //{
            //    this.ShowAllCount = this.ShowAllCount;
            //    this.SalesOrderList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
            //}
            //if (parameter == "Supplier")
            //{
            //    this.ShowAllCount = this.ShowAllCount;
            //    this.SalesOrderList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
            //}
            //if (parameter == "Supplier")
            //{
            //    this.ShowAllCount = this.ShowAllCount;
            //    this.SalesOrderList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
            //}

        }
            else
            {
                if (this.ShowAllTrue == true)
                {
                    //commented and added on 23 May 2017
                    this.SalesOrderList = FullPQList.OrderBy(x => x.CustomerName).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.SalesOrderList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.SalesOrderList = FullPQList.Where(x => x.ExcIncGST == false).ToList();
                }
                else
                {
                    this.SalesOrderList = DefaultList.OrderBy(x => x.CustomerName).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.SalesOrderList = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.SalesOrderList = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                }


            }
            //changedateformat(SalesOrderList);
            //changeNumberformat(SalesOrderList);
            TotalOrderAmount = Convert.ToString(SalesOrderList.Sum(e => e.OAmount));
            TotalDepositAmount = Convert.ToString(SalesOrderList.Sum(e => e.DAmount));
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
            this.SalesOrderListcmbSup = this.SalesOrderList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
            this.SalesOrderListcmbONo = this.SalesOrderList.GroupBy(x => x.OrderNo).Select(y => y.First()).OrderBy(x => x.SortOrderNo).Distinct().ToList();
            Mouse.OverrideCursor = null;
            Count = 1;
        }

        //private void GetOptionsData()
        //{
        //    OptionsEntity oData = new OptionsEntity();
        //    ISupplierRepository supplierRepository = new SupplierRepository();
        //    oData = supplierRepository.GetOptionSettings();
        //    if (oData != null)
        //    {
        //        this.CurrencyName = oData.CurrencyCode;     //there is no currency name field in database         
        //        this.CurrencyCode = oData.CurrencyCode;
        //        this.CurrencyFormat = oData.NumberFormat;
        //        this.DateFormat = oData.DateFormat;
        //    }
        //    else
        //    {
        //        this.CurrencyName = "USD";
        //        this.CurrencyCode = "USD";
        //        this.CurrencyFormat = "en-US";
        //        this.DateFormat = "dd/MM/yyyy";
        //    }

        //    #endregion

        //}
        #endregion
    }
}