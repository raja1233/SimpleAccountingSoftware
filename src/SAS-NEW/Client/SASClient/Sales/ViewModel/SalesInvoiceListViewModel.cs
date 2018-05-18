﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.ViewModel
{
    using Common;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Newtonsoft.Json;
    using Purchasing.View;
    using SASClient.CloseRequest;
    using SASClient.HomeScreen.Views;
    using SDN.UI.Entities.Sales;
    using Services;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using UI.Entities;
    using Views;

    public class SalesInvoiceListViewModel : SalesInvoiceListEntity
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
        /// Initializes a new instance of the <see cref="SalesInvoiceListViewModel"/> class.
        /// </summary>
        public SalesInvoiceListViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
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
            NavigaetoCreditNoteCommand = new RelayCommand(NavigaetoCreditNote);
            CloseCommand = new DelegateCommand(Close);
            NavigateToDoListCommand = new RelayCommand(NavigateToDoList);
        }

        public SalesInvoiceListViewModel()
        {
        }
        public RelayCommand NavigateToDoListCommand { get; set; }
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
        public RelayCommand NavigaetoCreditNoteCommand { get; set; }
        public ICommand CloseCommand { get; set; }
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
            //foreach (var item in this.SalesInvoiceList)
            //{
            //    //item.InvoiceAmount = item.InvoiceAmountIncGST;
            //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountIncGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.SalesInvoiceList = DefaultList.Where(x => x.ExcIncGST == true).ToList();
            //else
            //    this.SalesInvoiceList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            ISalesInvoiceListRepository purchaseRepository = new SalesInvoiceListRepository();
            this.SalesInvoiceList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData, this.IncludingGSTTrue).OrderBy(x => x.CustomerName).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.SalesInvoiceList.Count();
            else
                this.ShowSelectedCount = 0;
            this.SalesInvoiceListcmb = this.SalesInvoiceList.OrderBy(x => x.CustomerName).ToList();
            this.SalesInvoiceListcmbCredit = this.SalesInvoiceListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
            this.SalesInvoiceListcmbSup = this.SalesInvoiceList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
            this.SalesInvoiceListcmbInv = this.SalesInvoiceList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
            DefaultList = this.SalesInvoiceListcmb;
            //changedateformat(this.SalesInvoiceList);
            //changedateformat(this.SalesInvoiceListcmb);
            changeNumberformat(this.SalesInvoiceList);
            changeNumberformat(this.SalesInvoiceListcmb);
            Mouse.OverrideCursor = null;
        }
        void showexcGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //foreach (var item in this.SalesInvoiceList)
            //{
            //    //item.InvoiceAmount = item.InvoiceAmountExcGST;
            //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountExcGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.SalesInvoiceList = DefaultList.Where(x => x.ExcIncGST == false).ToList();
            //else
            //    this.SalesInvoiceList = FullPQList.Where(x => x.ExcIncGST == false).ToList();
            ISalesInvoiceListRepository purchaseRepository = new SalesInvoiceListRepository();
            this.SalesInvoiceList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData, this.IncludingGSTTrue).OrderBy(x => x.CustomerName).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.SalesInvoiceList.Count();
            else
                this.ShowSelectedCount = 0;
            this.SalesInvoiceListcmb = this.SalesInvoiceList.OrderBy(x => x.CustomerName).ToList();
            this.SalesInvoiceListcmbCredit = this.SalesInvoiceListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
            this.SalesInvoiceListcmbSup = this.SalesInvoiceList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
            this.SalesInvoiceListcmbInv = this.SalesInvoiceList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
            DefaultList = this.SalesInvoiceListcmb;
            //changedateformat(this.SalesInvoiceList);
            //changedateformat(this.SalesInvoiceListcmb);
            changeNumberformat(this.SalesInvoiceList);
            changeNumberformat(this.SalesInvoiceListcmb);
            Mouse.OverrideCursor = null;
        }
        void NavigatetoSupplier(object param)
        {
            SharedValues.ScreenCheckName = "Payment from Customer";
            SharedValues.ViewName = "Payment from Customer";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (param != null)
            {
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        void NavigateToDoList(object param)
        {
            SharedValues.ScreenCheckName = "To Do List";
            SharedValues.ViewName = "To Do List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "TodoListTabTrue";
            var mainview = ServiceLocator.Current.GetInstance<ToDoUnpaidDetailView>();
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("To Do List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        void NavigatetoSalesInvoice(object param)
        {
            SharedValues.ScreenCheckName = "Sales Invoice";
            SharedValues.ViewName = "Sales Invoice";
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

            var mainview = ServiceLocator.Current.GetInstance<SalesInvoiceView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoice Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        void NavigaetoCreditNote(object param)
        {
            if (param != null)
            {
                
                string str = param.ToString().Substring(0, 3);
                string obj = param.ToString();
                SharedValues.NewClick = obj;
              
                if (str == "CN-")
                {
                    SharedValues.ScreenCheckName = "Adjust Credit Note";
                    SharedValues.ViewName = "Adjust Credit Note";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.getValue = "CreditNoteTab";
                    var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();
                    var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                    tabregion.Add(tabview);
                    if (tabregion != null)
                    {
                        tabregion.Activate(tabview);
                    }
                    var mainview = ServiceLocator.Current.GetInstance<AdjustCreditNoteFormView>();
                    var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                    mainregion.Add(mainview);
                    if (mainregion != null)
                    {
                        mainregion.Activate(mainview);
                    }////
                    eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Adjust Credit Note(AC)");
                    }
                    else
                    {
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                else
                {
                    SharedValues.ScreenCheckName = "Payment from Customer";
                    SharedValues.ViewName = "Payment from Customer";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.getValue = "PaymentFromCustomerTab";
                    SharedValues.CollectCommand = "0";
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
                    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payment From Customer Form");
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
            Mouse.OverrideCursor = Cursors.Wait;
            this.YearmonthQuartTrue = false;//added after client feedback
            this.StartEndDateTrue = false;//added after client feedback
            this.SalesInvoiceList = FullPQList.OrderBy(x => x.CustomerName).ToList();
            this.SalesInvoiceListcmb = FullPQList.OrderBy(x => x.CustomerName).ToList();
            this.SalesInvoiceListcmbCredit = this.SalesInvoiceListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
            this.SalesInvoiceListcmbSup = this.SalesInvoiceList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
            this.SalesInvoiceListcmbInv = this.SalesInvoiceList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.SalesInvoiceList.Count();
            else
                this.ShowSelectedCount = 0;
            this.SelectedSearchEndDate = null;
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.SelectedSearchStartDate = null;
            this.SelectedSearchEndDate = null;
            if (this.IncludingGSTTrue == true)
                this.SalesInvoiceList = FullPQList.Where(x => x.ExcIncGST == true).OrderBy(x => x.CustomerName).ToList();
            else
                this.SalesInvoiceList = FullPQList.Where(x => x.ExcIncGST == false).OrderBy(x => x.CustomerName).ToList();
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
                    //    this.SalesInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.SalesInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.SalesInvoiceListcmb = DefaultList;
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
                    //    this.SalesInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.SalesInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.SalesInvoiceListcmb = DefaultList;
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
                    //    this.SalesInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.SalesInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.SalesInvoiceListcmb = DefaultList;
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
                    //    this.SalesInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.SalesInvoiceListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.SalesInvoiceListcmb = DefaultList;
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

                //this.SalesInvoiceList = this.SalesInvoiceListInternal;
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;

                ISalesInvoiceListRepository purchaseRepository = new SalesInvoiceListRepository();
                var results = purchaseRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.SalesInvoiceList), "Sales_Invoice_List");
                if (Count != 0)
                {
                    this.SalesInvoiceList = purchaseRepository.GetAllSalesInvoiceJson(jsonSearch, this.IncludingGSTTrue).OrderBy(x => x.CustomerName).ToList();
                    //changedateformat(this.SalesInvoiceList);
                    changeNumberformat(this.SalesInvoiceList);

                }
                    
                this.SalesInvoiceListcmb = this.SalesInvoiceList.OrderBy(x => x.CustomerName).ToList();
                this.SalesInvoiceListcmbCredit = this.SalesInvoiceListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
                this.SalesInvoiceListcmbSup = this.SalesInvoiceList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
                this.SalesInvoiceListcmbInv = this.SalesInvoiceList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
                if (this.ShowAllTrue == true)
                    this.ShowSelectedCount = this.SalesInvoiceList.Count();
                else
                    this.ShowSelectedCount = this.SalesInvoiceList.Count();
                DefaultList = this.SalesInvoiceListcmb;
                
                TotalInvoiceAmount = Convert.ToString(SalesInvoiceList.Sum(e => e.InvoiceAmountValue));
                TotalCCDAmount = Convert.ToString(SalesInvoiceList.Sum(e => e.TotalAmount));
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
        List<SalesInvoiceListEntity> DefaultList = new List<SalesInvoiceListEntity>();
        List<SalesInvoiceListEntity> FullPQList = new List<SalesInvoiceListEntity>();
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {
            //GetOptionsData();
            //var height = System.Windows.SystemParameters.PrimaryScreenHeight;
            //if (height == 768)
            //    this.SIGridHeight = 425;
            //else if (height == 1024)
            //    this.SIGridHeight = 680;
            //else if (height == 1440)
            //    this.SIGridHeight = 956;
            //else if (height == 1800)
            //    this.SIGridHeight = 1195;
            //else
            //    this.SIGridHeight = 680;
            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 67;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SIGridHeight = minHeight;
            RefreshData();
        }

        private void RefreshData()
        {
            ISalesInvoiceListRepository purchaseRepository = new SalesInvoiceListRepository();
            this.DateFormat = purchaseRepository.GetDateFormat();
            this.ShowAllCount = purchaseRepository.GetAllSalesInvoice().Count();
            GetOptionsandTaxValues();
            this.JsonData = purchaseRepository.GetLastSelectionData();
            this.SalesInvoiceList = purchaseRepository.GetAllSalesInvoiceJson(this.JsonData, this.IncludingGSTTrue).OrderBy(x => x.CustomerName).ToList();
            this.SalesInvoiceListcmb = purchaseRepository.GetAllSalesInvoice().OrderBy(x => x.CustomerName).ToList();
            this.ShowSelectedCount = this.SalesInvoiceList.Count();
            this.SalesInvoiceListcmbCredit = this.SalesInvoiceListcmb.GroupBy(x => x.CashCreditNo).Select(g => g.First()).OrderBy(x => x.CreditCashNO).Where(y => y.CashCreditNo != null).ToList();
            this.SalesInvoiceListcmbSup = this.SalesInvoiceList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
            this.SalesInvoiceListcmbSup = this.SalesInvoiceList.GroupBy(x => x.CustomerName).Select(y => y.First()).OrderBy(x => x.CustomerName).Distinct().ToList();
            this.SalesInvoiceListcmbInv = this.SalesInvoiceList.GroupBy(x => x.InvoiceNo).Select(y => y.First()).OrderBy(x => x.SortInvoiceNo).Distinct().ToList();
            this.YearRange = purchaseRepository.GetYearRange().ToList();
            //changedateformat(this.SalesInvoiceList);
            //changedateformat(this.SalesInvoiceListcmb);
            changeNumberformat(this.SalesInvoiceList);
            changeNumberformat(this.SalesInvoiceListcmb);
            DefaultList = this.SalesInvoiceList;
            FullPQList = this.SalesInvoiceListcmb;
            this.ShowAllCount = this.SalesInvoiceListcmb.Count();
            SetDefaultSearchSelection();
            var Updateddate = this.SalesInvoiceListcmb.Max(x => x.CreatedDate);
            string date = this.DateFormat as string;
            this.LastUpdateDate = Convert.ToDateTime(Updateddate).ToString(date);

            TotalInvoiceAmount = Convert.ToString(SalesInvoiceList.Sum(e => e.InvoiceAmountValue));
            TotalCCDAmount = Convert.ToString(SalesInvoiceList.Sum(e => e.TotalAmount));
            //this.GetData(this.SelectedSearchSupplier);
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesInvoiceListRepository purchaseRepository = new SalesInvoiceListRepository();
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
                    //foreach (var item in this.SalesInvoiceList)
                    //{
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    //this.SalesInvoiceList = this.SalesInvoiceList.Where(x => x.ExcIncGST == true).ToList();
                }
                else
                {
                    this.IncludingGSTTrue = false;
                    this.IncludingGSTFalse = true;
                    int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.SalesInvoiceList)
                    //{
                    //    //item.InvoiceAmount = item.InvoiceAmountExcGST;
                    //    //item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountExcGST), decimalpoints).ToString();
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    if (this.SalesInvoiceList != null)
                        this.SalesInvoiceList = this.SalesInvoiceList.ToList();
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

        void changedateformat(List<SalesInvoiceListEntity> entity)
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
        void changeNumberformat(List<SalesInvoiceListEntity> entity)
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
        //        //this.ShowSelectedTrue = false;
        //        this.YearmonthQuartTrue = false;
        //        this.StartEndDateTrue = false;
        //        //this.ShowSelectedCount = 0;
        //    }
        //}
        public void LoadSearchResult(string customerName)
        {
            ISalesInvoiceListRepository purchaseRepository = new SalesInvoiceListRepository();
            this.ShowAllCount = purchaseRepository.GetAllSalesInvoice().Count();
            this.SalesInvoiceList = purchaseRepository.GetAllSalesInvoice().Where(x => x.CustomerName == customerName).ToList();
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
                        this.ShowSelectedCount = this.SalesInvoiceList.Count();
                    else
                        this.ShowSelectedCount = this.SalesInvoiceList.Count();
                    break;
                case "SelectedSearchPI_Status":
                    GetData(this.SelectedSearchPI_Status, "PI_Status");
                    if (this.ShowAllTrue == true)
                        this.ShowSelectedCount = this.SalesInvoiceList.Count();
                    else
                        this.ShowSelectedCount = this.SalesInvoiceList.Count();
                    break;                 
                case "SelectedCreditNoteNo":
                    GetData(this.SelectedCreditNoteNo, "CreditNote");
                    if (this.ShowAllTrue == true)
                        this.ShowSelectedCount = this.SalesInvoiceList.Count();
                    else
                        this.ShowSelectedCount = this.SalesInvoiceList.Count();
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
            //ISalesInvoiceListRepository purchaseRepository = new SalesInvoiceListRepository();
            //var result = purchaseRepository.GetAllPurInvoice().ToList();
            if (SearchFilter != null || SearchFilter == string.Empty)
            {
                if (parameter == "Supplier")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.SalesInvoiceList = FullPQList.Where(x => (x.CustomerName == SearchFilter || x.InvoiceNo == SearchFilter)).ToList();
                    }
                    else
                    {
                        this.SalesInvoiceList = DefaultList.Where(x => (x.CustomerName == SearchFilter || x.InvoiceNo == SearchFilter)).ToList();
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
                            this.SalesInvoiceList = FullPQList.ToList();
                        else if (search == " Paid")
                        {
                            byte paid = Convert.ToByte(PI_Status.Paid);
                            this.SalesInvoiceList = FullPQList.Where(x => x.Status == paid).ToList();
                        }
                        else if (search == " Unpaid")
                        {
                            byte Unpaid = Convert.ToByte(PI_Status.UnPaid);
                            this.SalesInvoiceList = FullPQList.Where(x => x.Status == Unpaid).ToList();
                        }
                        else if (search == " Adjusted")
                        {
                            byte Adjusted = Convert.ToByte(PI_Status.Adjusted);
                            this.SalesInvoiceList = FullPQList.Where(x => x.Status == Adjusted).ToList();
                        }
                        //else if (search == " Cancelled")
                        //{
                        //    byte Cancelled = Convert.ToByte(PI_Status.Cancelled);
                        //    this.SalesInvoiceList = FullPQList.Where(x => x.Status == Cancelled).ToList();
                        //}
                        else
                            this.SalesInvoiceList = FullPQList.ToList();
                    }
                    else
                    {
                        var search = SearchFilter.Split(':')[1];
                        if (search == " All")
                            this.SalesInvoiceList = DefaultList.ToList();
                        else if (search == " Paid")
                        {
                            byte paid = Convert.ToByte(PI_Status.Paid);
                            this.SalesInvoiceList = DefaultList.Where(x => x.Status == paid).ToList();
                        }
                        else if (search == " Unpaid")
                        {
                            byte Unpaid = Convert.ToByte(PI_Status.UnPaid);
                            this.SalesInvoiceList = DefaultList.Where(x => x.Status == Unpaid).ToList();
                        }
                        else if (search == " Adjusted")
                        {
                            byte Adjusted = Convert.ToByte(PI_Status.Adjusted);
                            this.SalesInvoiceList = DefaultList.Where(x => x.Status == Adjusted).ToList();
                        }
                        //else if (search == " Cancelled")
                        //{
                        //    byte Cancelled = Convert.ToByte(PI_Status.Cancelled);
                        //    this.SalesInvoiceList = DefaultList.Where(x => x.Status == Cancelled).ToList();
                        //}
                        else
                            this.SalesInvoiceList = DefaultList.ToList();

                    }


                    //DefaultList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                }
                if (parameter == "CreditNote")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.SalesInvoiceList = FullPQList.Where(x => x.CreditNoteNo == SearchFilter).ToList();
                    }
                    else
                    {
                        this.SalesInvoiceList = DefaultList.Where(x => x.CreditNoteNo == SearchFilter).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                }

                //if (parameter == "InvoiceNo")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SalesInvoiceList = DefaultList.Where(x => x.InvoiceNo == SearchFilter).ToList();
                //    DefaultList = DefaultList.Where(x => x.InvoiceNo == SearchFilter).ToList();
                //}
                //if (parameter == "SearchYear")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SalesInvoiceList = DefaultList.Where(x => x.CreatedDate.Value.Year.ToString() == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SalesInvoiceList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SalesInvoiceList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SalesInvoiceList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SalesInvoiceList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.SalesInvoiceList = DefaultList.Where(x => x.CustomerName == SearchFilter).ToList();
                //}

            }
            else
            {
                if (this.ShowAllTrue == true)
                {
                    this.SalesInvoiceList = FullPQList.ToList();
                }
                else
                {
                    this.SalesInvoiceList = DefaultList.ToList();
                }

            }
            //changedateformat(SalesInvoiceList);
            //changeNumberformat(SalesInvoiceList);
            TotalInvoiceAmount = Convert.ToString(SalesInvoiceList.Sum(e => e.InvoiceAmountValue));
            TotalCCDAmount = Convert.ToString(SalesInvoiceList.Sum(e => e.TotalAmount));
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
