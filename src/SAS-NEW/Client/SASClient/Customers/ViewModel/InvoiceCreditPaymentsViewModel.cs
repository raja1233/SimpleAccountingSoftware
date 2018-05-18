﻿
using System;

using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Customers.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Customers;
    using Services;
    using SDN.Common;
    using Newtonsoft.Json;
    using System.Windows.Input;
    using SDN.Customers.Services;
    using SDN.Customer.Services;
    using System.Globalization;
    using Reports.ReportsPage;
    using Microsoft.Practices.ServiceLocation;
    using CloseRequest;
    using Microsoft.Practices.Prism.Commands;
    using System.Windows;

    public class InvoiceCreditPaymentsViewModel : InvoiceCreditPaymentsEntity
    {
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private List<SearchEntity> SearchValues;
        private string jsonSearch;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IRegionManager regionManager;
        //private bool isSelected;
        private readonly IEventAggregator eventAggregator;
        private int Count = 0;
        StackList itemlist = new StackList();
        IInvoiceCreditPaymentsRepository invRepository = new InvoiceCreditPaymentsRepository();
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
        /// Initializes a new instance of the <see cref="CustomerHistoryViewModel"/> class.
        /// </summary>
        public InvoiceCreditPaymentsViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadCustomerBackground();
            SearchCommand = new RelayCommand(Search);
            SelectChangedCommand = new RelayCommand(OnSelectionChange);
            PrintCommand = new RelayCommand(PrintDocument, CanPrint);
            CloseCommand = new DelegateCommand(Close);
            this.YearRange = invRepository.GetYearRange().ToList();
            if ((DateTime.Now.Month - 1) == 0)
            {
                SelectedSearchMonth = Convert.ToString(12);
            }
            else
            {
                SelectedSearchMonth = Convert.ToString(DateTime.Now.Month - 1);
            }
        }

        public InvoiceCreditPaymentsViewModel()
        {
        }
        public ICommand CloseCommand { get; set; }
        public RelayCommand SelectChangedCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand PrintCommand { get; set; }

        #endregion  Constructor

        #region ButtonCommands
        void refreshcommand(object param)
        {
            RefreshData();
        }
        public void Close()
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
        void OnSelectionChange(object param)
        {
            if (SelectedCustomerID != 0)
            {
                LstInvoiceDetails = invRepository.GetUnPaidInvoices(SelectedCustomerID, JsonData);
                //LstInvoiceDetails = LstInvoiceDetails.OrderBy(x =>x.TransactionDate).ToList();


            }
        }

        public void PrintDocument(object param)
        {
            LstCustomers.RemoveAll(s => s.IsSelected == false);
            IEnumerable<int> selectedcustomers = (IEnumerable<int>)LstCustomers.Select(v => v.CustomerID);
            var SelectedDate = param.ToString();
            SharedValues.CustomersID = selectedcustomers;
            SharedValues.Print_Id = SelectedCustomerID.ToString();

            var mainview = ServiceLocator.Current.GetInstance<SalesInvoiceCreditPayementReport>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


        }
        public bool CanPrint(object param)
        {
            //bool a = false;
            List<InvoiceCreditPaymentsEntity> demo = new List<InvoiceCreditPaymentsEntity>();
            if (LstCustomers != null)
                demo =  LstCustomers.Where(x=>x.IsSelected == true).ToList();
            else
                return false;

            if (demo.Count <= 0)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        void NavigatetoCustomer(object param)
        {
            //if (param != null)
            //{
            //    string obj = param.ToString();
            //    SharedValues.getValue = obj;
            //}
            //var mainview = ServiceLocator.Current.GetInstance<CustomerDetailView>();
            //var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            //mainregion.Add(mainview);
            //if (mainregion != null)
            //{
            //    mainregion.Activate(mainview);
            //}


            //var tabview = ServiceLocator.Current.GetInstance<CustomerTabView>();
            //var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            //tabregion.Add(tabview);
            //if (tabregion != null)
            //{
            //    tabregion.Activate(tabview);
            //}

            //eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details Form");
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

                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Month";
                    value.FieldValue = "0";
                    SearchValues.Add(value);
                }

                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;
                SharedValues.JsonDataValues = JsonData;
                IInvoiceCreditPaymentsRepository invRepository = new InvoiceCreditPaymentsRepository();
                var results = invRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.InvoiceCreditPaymentsList), "InvoiceCreditPayments_List");
                if (Count != 0)
                {
                    this.LstCustomers = invRepository.GetCustomersList(jsonSearch).ToList();

                    var sup = LstCustomers.FirstOrDefault();
                    if (sup != null)
                    {
                        SelectedCustomerID = sup.SelectedCustomerID;
                    }
                }

            }

        }
        #endregion

        #region BackgroundWorked
        private void LoadCustomerBackground()
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

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

        private void LoadCustomerBackground(object sender, DoWorkEventArgs e)
        {
            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 87;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.GridHeight = minHeight;
            RefreshData();

        }

        private void RefreshData()
        {
            IInvoiceCreditPaymentsRepository invRepository = new InvoiceCreditPaymentsRepository();

            GetOptionsandTaxValues();
            this.JsonData = invRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.InvoiceCreditPaymentsList));
            LstCustomers = invRepository.GetCustomersList(JsonData);


            //this.ShowAllCount = this.CustomerHistorycmb.Count();
            SetDefaultSearchSelection();

        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            ICustomerHistoryRepository purchaseRepository = new CustomerHistoryRepository();
            oData = purchaseRepository.GetOptionSettings();
            if (oData != null)
            {
                this.CurrencyName = oData.CurrencyCode;     //there is no currency name field in database         

                TaxModel objDefaultTax = new TaxModel();
                objDefaultTax = purchaseRepository.GetDefaultTaxes();
                if (objDefaultTax != null)
                {
                    this.TaxName = objDefaultTax.TaxName;

                }
                else
                {
                    this.TaxName = "GST";

                }
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

        //                    break;
        //                case "Quarter":
        //                    this.SelectedSearchQuarter = item.FieldValue;

        //                    break;
        //                case "Month":
        //                    this.SelectedSearchMonth = item.FieldValue;

        //                    break;

        //            }
        //        }
        //        Search(null);
        //    }

        //}
        public void SetDefaultSearchSelection()
        {
            var Quarter = 0;
            var lastQuarter = 0;
            String sDate = DateTime.Now.ToString();
            DateTime dateTime = DateTime.UtcNow.Date;
            var month = dateTime.Month;
            if (month == 1 || month == 2 || month == 3)
            {
                Quarter = 1;
                lastQuarter = Quarter;
            }
            else if (month == 4 || month == 5 || month == 6)
            {
                Quarter = 2;
                lastQuarter = Quarter - 1;
            }
            else if (month == 7 || month == 8 || month == 9)
            {
                Quarter = 3;
                lastQuarter = Quarter - 1;
            }
            else if (month == 10 || month == 11 || month == 12)
            {
                Quarter = 4;
                lastQuarter = Quarter - 1;
            }
            var lastMonth = month - 1;
            if (lastMonth == 0)
            {
                lastMonth = 1;
            }
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            this.SelectedSearchYear = DateTime.UtcNow.Year.ToString();
            this.SelectedSearchMonth = lastMonth.ToString();
            this.SelectedSearchQuarter = Quarter.ToString();
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
                case "SelectedSearchMonth":
                    SetData(this.SelectedSearchMonth, "Month");
                    break;
                case "SelectedSearchQuarter":
                    SetData(this.SelectedSearchQuarter, "Quarter");
                    break;
                case "SelectedSearchYear":
                    SetData(this.SelectedSearchYear, "Year");
                    break;

            }

            base.OnPropertyChanged(name);
        }

        public void SetData(string SearchFilter, string parameter)
        {
            if (parameter == "Year" && SearchFilter != string.Empty && SearchFilter != null)
            {
                Search(null);
            }

            if (parameter == "Quarter" && SearchFilter != string.Empty && SearchFilter != null)
            {

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
