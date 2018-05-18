using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            NavigaetoPurchaseInvoiceCommand = new RelayCommand(PurchaseInvoiceCommand);


        }

        public DebitNoteListViewModel()
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
        public RelayCommand NavigaetoPurchaseCommand { get; set; }
        public RelayCommand NavigaetoPurchaseInvoiceCommand { get; set; }
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
            //foreach (var item in this.DebitNoteList)
            //{
            //    //item.DebitAmount = item.DebitAmountIncGST;
            //    item.DebitAmount = Math.Round(Convert.ToDouble(item.DebitAmountIncGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.DebitNoteList = DefaultList.Where(x => x.ExcIncGST == true).ToList();
            //else
            //    this.DebitNoteList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            IDebitNoteListRepository purchaseRepository = new DebitNoteListRepository();
            this.DebitNoteList = purchaseRepository.GetAllPurDebitJson(this.JsonData, this.IncludingGSTTrue).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.DebitNoteList.Count();
            else
                this.ShowSelectedCount = 0;
            this.DebitNoteListcmb = this.DebitNoteList;
            this.DebitNoteListcmbDebit = this.DebitNoteListcmb.GroupBy(x => x.CashDebitNo).Select(g => g.First()).Where(y => y.CashDebitNo != null).ToList();
            this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().ToList();
            this.DebitNoteListcmbInv = this.DebitNoteList.GroupBy(x => x.DebitNo).Select(y => y.First()).Distinct().OrderBy(x=>x.SortDebitNoteNo).ToList();
            DefaultList = this.DebitNoteListcmb;
            changedateformat(this.DebitNoteList);
            changeNumberformat(this.DebitNoteList);
            Mouse.OverrideCursor = null;

        }
        void showexcGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //foreach (var item in this.DebitNoteList)
            //{
            //    //item.DebitAmount = item.DebitAmountExcGST;
            //    item.DebitAmount = Math.Round(Convert.ToDouble(item.DebitAmountExcGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.DebitNoteList = DefaultList.Where(x => x.ExcIncGST == false).ToList();
            //else
            //    this.DebitNoteList = FullPQList.Where(x => x.ExcIncGST == false).ToList();
            IDebitNoteListRepository purchaseRepository = new DebitNoteListRepository();
            this.DebitNoteList = purchaseRepository.GetAllPurDebitJson(this.JsonData, this.IncludingGSTTrue).ToList();
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.DebitNoteList.Count();
            else
                this.ShowSelectedCount = 0;
            this.DebitNoteListcmb = this.DebitNoteList;
            this.DebitNoteListcmbDebit = this.DebitNoteListcmb.GroupBy(x => x.CashDebitNo).Select(g => g.First()).Where(y => y.CashDebitNo != null).ToList();
            this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().ToList();
            this.DebitNoteListcmbInv = this.DebitNoteList.GroupBy(x => x.DebitNo).Select(y => y.First()).Distinct().OrderBy(x=>x.SortDebitNoteNo).ToList();
            DefaultList = this.DebitNoteListcmb;
            changedateformat(this.DebitNoteList);
            changeNumberformat(this.DebitNoteList);
            Mouse.OverrideCursor = null;
        }
        void NavigatetoSupplier(object param)
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details");
        }
        void NavigatetoDebitNote(object param)
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
        void PurchaseInvoiceCommand(object param)
        {
            string obj = param.ToString();
            SharedValues.NewClick = obj;
            SharedValues.getValue = "PurchaseInvoiceTab";
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
        void ShowAll(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.YearmonthQuartTrue = false;//added after client feedback
            this.StartEndDateTrue = false;//added after client feedback
            this.DebitNoteList = FullPQList;
            this.DebitNoteListcmb = FullPQList;
            this.DebitNoteListcmbDebit = this.DebitNoteListcmb.GroupBy(x => x.CashDebitNo).Select(g => g.First()).Where(y => y.CashDebitNo != null).ToList();
            this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().ToList();
            this.DebitNoteListcmbInv = this.DebitNoteList.GroupBy(x => x.DebitNo).Select(y => y.First()).Distinct().OrderBy(x=>x.SortDebitNoteNo).ToList();
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
                this.DebitNoteList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            else
                this.DebitNoteList = FullPQList.Where(x => x.ExcIncGST == false).ToList();
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
                    //    this.DebitNoteListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.DebitNoteListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.DebitNoteListcmb = DefaultList;
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
                    //    this.DebitNoteListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.DebitNoteListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.DebitNoteListcmb = DefaultList;
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
                    //    this.DebitNoteListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.DebitNoteListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.DebitNoteListcmb = DefaultList;
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
                    //    this.DebitNoteListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.DebitNoteListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.DebitNoteListcmb = DefaultList;
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

                //this.DebitNoteList = this.DebitNoteListInternal;
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;

                IDebitNoteListRepository purchaseRepository = new DebitNoteListRepository();
                var results = purchaseRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.DebitNoteList), "Debit_Note_List");
                if (Count != 0)
                {
                    this.DebitNoteList = purchaseRepository.GetAllPurDebitJson(jsonSearch, this.IncludingGSTTrue);
                   // changedateformat(this.DebitNoteList);
                    changeNumberformat(this.DebitNoteList);
                }
                   
                this.DebitNoteListcmb = this.DebitNoteList;
                this.DebitNoteListcmbDebit = this.DebitNoteListcmb.GroupBy(x => x.CashDebitNo).Select(g => g.First()).Where(y => y.CashDebitNo != null).ToList();
                this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().ToList();
                this.DebitNoteListcmbInv = this.DebitNoteList.GroupBy(x => x.DebitNo).Select(y => y.First()).Distinct().OrderBy(x=>x.SortDebitNoteNo).ToList();
                if (this.ShowAllTrue == true)
                    this.ShowSelectedCount = 0;
                else
                    this.ShowSelectedCount = this.DebitNoteList.Count();
                DefaultList = this.DebitNoteListcmb;
               
                this.TotalDebitAmount = Convert.ToString(DebitNoteList.Sum(e => e.DebitAmountValue));
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
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 118;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.DNGridHeight = minHeight;
            RefreshData();
        }

        private void RefreshData()
        {
            IDebitNoteListRepository purchaseRepository = new DebitNoteListRepository();
            this.DateFormat = purchaseRepository.GetDateFormat();
            this.ShowAllCount = purchaseRepository.GetAllPurDebit().Count();
            GetOptionsandTaxValues();
            this.JsonData = purchaseRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.DebitNoteList));
            this.DebitNoteList = purchaseRepository.GetAllPurDebitJson(this.JsonData, this.IncludingGSTTrue).OrderBy(e => e.SupplierName).ToList();
            this.DebitNoteListcmb = purchaseRepository.GetAllPurDebit().OrderBy(e => e.SupplierName).ToList();
            this.ShowSelectedCount = this.DebitNoteList.Count();
            this.DebitNoteListcmbDebit = this.DebitNoteListcmb.GroupBy(x => x.CashDebitNo).Select(g => g.First()).Where(y => y.CashDebitNo != null).OrderBy(e => e.CashDebitNo).ToList();
            this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().OrderBy(e => e.SupplierName).ToList();
            this.DebitNoteListcmbSup = this.DebitNoteList.GroupBy(x => x.SupplierName).Select(y => y.First()).Distinct().OrderBy(e => e.SupplierName).ToList();
           
            this.YearRange = purchaseRepository.GetYearRange().ToList();
            //changedateformat(this.DebitNoteList);
            //changedateformat(this.DebitNoteListcmb);
            changeNumberformat(this.DebitNoteList);
            changeNumberformat(this.DebitNoteListcmb);
            this.DebitNoteListcmbInv = this.DebitNoteList.GroupBy(x => x.DebitNo).Select(y => y.First()).Distinct().OrderBy(e => e.SortDebitNoteNo).ToList();
            DefaultList = this.DebitNoteList;
            FullPQList = this.DebitNoteListcmb;
            //this.ShowAllCount = this.DebitNoteListcmb.Count();
            SetDefaultSearchSelection(this.JsonData);
            var Updateddate = this.DebitNoteListcmb.Max(x => x.CreatedDate);
            string date = this.DateFormat as string;
            this.LastUpdateDate = Convert.ToDateTime(Updateddate).ToString(date);

            TotalDebitAmount = Convert.ToString(DebitNoteList.Sum(e => e.DebitAmountValue));
            //this.GetData(this.SelectedSearchSupplier);
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            IDebitNoteListRepository purchaseRepository = new DebitNoteListRepository();
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
                    //foreach (var item in this.DebitNoteList)
                    //{
                    //    item.DebitAmount = Math.Round(Convert.ToDouble(item.DebitAmount), decimalpoints).ToString();
                    //}
                    //this.DebitNoteList = this.DebitNoteList.Where(x => x.ExcIncGST == true).ToList();
                }
                else
                {
                    this.IncludingGSTTrue = false;
                    this.IncludingGSTFalse = true;
                    int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.DebitNoteList)
                    //{
                    //    //item.DebitAmount = item.DebitAmountExcGST;
                    //    //item.DebitAmount = Math.Round(Convert.ToDouble(item.DebitAmountExcGST), decimalpoints).ToString();
                    //    item.DebitAmount = Math.Round(Convert.ToDouble(item.DebitAmount), decimalpoints).ToString();
                    //}
                    if (this.DebitNoteList != null)
                        this.DebitNoteList = this.DebitNoteList.ToList();
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

        void changedateformat(List<DebitNoteListEntity> entity)
        {
            string date = this.DateFormat as string;
            foreach (var item in entity)
            {
                if (item.DebitCashDate != null && item.DebitCashDate != "")
                {
                    var tempdate = Convert.ToDateTime(item.DebitCashDate).ToString(date);
                item.DebitCashDate = tempdate.Replace('-', '/');
                }
                if (item.DebitDateDateTime != null)
                {
                    var tempdate = Convert.ToDateTime(item.DebitDateDateTime).ToString(date);
                    item.DebitDate = tempdate.Replace('-', '/');
                }
                else
                    item.DebitDate = "";

            }
        }
        void changeNumberformat(List<DebitNoteListEntity> entity)
        {
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            string date = this.DateFormat as string;
            foreach (var item in entity)
            {
                //item.QuotationAmount = item.QuotationAmountIncGST;
                if (item.DebitAmount != null && item.DebitNoteAmount != 0)
                    item.DebitAmount = Math.Round(Convert.ToDouble(item.DebitNoteAmount), decimalpoints).ToString();
                if (item.DebitCashAmount != null && item.DebitCashAmount != "")
                    item.DebitCashAmount = Math.Round(Convert.ToDouble(item.DebitCashAmount), decimalpoints).ToString();

                if (item.DebitCashDate != null && item.DebitCashDate != "")
                {
                    var tempdate = Convert.ToDateTime(item.DebitCashDate).ToString(date);
                    item.DebitCashDate = tempdate.Replace('-', '/');
                }
                if (item.DebitDateDateTime != null)
                {
                    var tempdate = Convert.ToDateTime(item.DebitDateDateTime).ToString(date);
                    item.DebitDate = tempdate.Replace('-', '/');
                }
                else
                    item.DebitDate = "";
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
            IDebitNoteListRepository purchaseRepository = new DebitNoteListRepository();
            this.ShowAllCount = purchaseRepository.GetAllPurDebit().Count();
            this.DebitNoteList = purchaseRepository.GetAllPurDebit().Where(x => x.SupplierName == Suppliername).ToList();
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
                case "SelectedDebitNoteNo":
                    GetData(this.SelectedDebitNoteNo, "DebitNote");
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
            //IDebitNoteListRepository purchaseRepository = new DebitNoteListRepository();
            //var result = purchaseRepository.GetAllPurDebit().ToList();
            if (SearchFilter != null || SearchFilter == string.Empty)
            {
                if (parameter == "Supplier")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.DebitNoteList = FullPQList.Where(x => (x.SupplierName == SearchFilter || x.DebitNo == SearchFilter)).ToList();
                    }
                    else
                    {
                        this.DebitNoteList = DefaultList.Where(x => (x.SupplierName == SearchFilter || x.DebitNo == SearchFilter)).ToList();
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
                            this.DebitNoteList = FullPQList.ToList();
                        else if (search == " Adjusted")
                        {
                            byte adjusted = Convert.ToByte(DN_Status.Adjusted);
                            this.DebitNoteList = FullPQList.Where(x => x.Status == adjusted).ToList();
                        }
                        else if (search == " Refunded")
                        {
                            byte refunded = Convert.ToByte(DN_Status.Refunded);
                            this.DebitNoteList = FullPQList.Where(x => x.Status == refunded).ToList();
                        }
                        else if (search == " UnAdjusted")
                        {
                            byte unAdjusted = Convert.ToByte(DN_Status.UnAdjusted);
                            this.DebitNoteList = FullPQList.Where(x => x.Status == unAdjusted).ToList();
                        }
                        else
                            this.DebitNoteList = FullPQList.ToList();
                    }
                    else
                    {
                        var search = SearchFilter.Split(':')[1];
                        if (search == " All")
                            this.DebitNoteList = DefaultList.ToList();
                        else if (search == " Adjusted")
                        {
                            byte adjusted = Convert.ToByte(DN_Status.Adjusted);
                            this.DebitNoteList = DefaultList.Where(x => x.Status == adjusted).ToList();
                        }
                        else if (search == " Refunded")
                        {
                            byte refunded = Convert.ToByte(DN_Status.Refunded);
                            this.DebitNoteList = DefaultList.Where(x => x.Status == refunded).ToList();
                        }
                        else if (search == " UnAdjusted")
                        {
                            byte unAdjusted = Convert.ToByte(DN_Status.UnAdjusted);
                            this.DebitNoteList = DefaultList.Where(x => x.Status == unAdjusted).ToList();
                        }
                        else
                            this.DebitNoteList = DefaultList.ToList();
                    }
                    
                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }
               if (parameter == "DebitNote")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.DebitNoteList = FullPQList.Where(x => x.CashDebitNo == SearchFilter).ToList();
                    }
                    else
                    {
                        this.DebitNoteList = DefaultList.Where(x => x.CashDebitNo == SearchFilter).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }
                if (parameter == "DebitNote")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.DebitNoteList = FullPQList.Where(x => x.CashDebitNo == SearchFilter).ToList();
                    }
                    else
                    {
                        this.DebitNoteList = DefaultList.Where(x => x.CashDebitNo == SearchFilter).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }
                //if (parameter == "DebitNo")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.DebitNoteList = DefaultList.Where(x => x.DebitNo == SearchFilter).ToList();
                //    DefaultList = DefaultList.Where(x => x.DebitNo == SearchFilter).ToList();
                //}
                //if (parameter == "SearchYear")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.DebitNoteList = DefaultList.Where(x => x.CreatedDate.Value.Year.ToString() == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.DebitNoteList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.DebitNoteList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.DebitNoteList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.DebitNoteList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                //}
                //if (parameter == "Supplier")
                //{
                //    this.ShowAllCount = this.ShowAllCount;
                //    this.DebitNoteList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                //}

            }
            else
            {
                if (this.ShowAllTrue == true)
                {
                    this.DebitNoteList = FullPQList.ToList();
                }
                else
                {
                    this.DebitNoteList = DefaultList.ToList();
                }              
            }
            //changedateformat(DebitNoteList);
            //changeNumberformat(DebitNoteList);
            TotalDebitAmount = Convert.ToString(DebitNoteList.Sum(e => e.DebitAmountValue));
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
