﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.ViewModel
{
    using Common;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Newtonsoft.Json;
    using SDN.UI.Entities.ProductandServices;
    using Services;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using UI.Entities;
    using View;

    public class TopPandSViewModel: TopPandSEntity
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public event PropertyChangedEventHandler PropertyChanged;
        public ITopPandSRepository topPandSRepository = new TopPandSRepository();
        public IPandSDetailsRepository psRepository = new PandSDetailsRepository();
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private List<SearchEntity> SearchValues;
        private string jsonSearch;
        private List<TopPandSEntity> DefaultList = new List<TopPandSEntity>();
        private List<TopPandSEntity> FullList = new List<TopPandSEntity>();
        private List<TopPandSEntity> cmbList = new List<TopPandSEntity>();
        TopPandSEntity allPosition = new TopPandSEntity();
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
        /// Initializes a new instance of the <see cref="PurchaseQuotationListViewModel"/> class.
        /// </summary>
        public TopPandSViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            TopPandSEntity allPosition = new TopPandSEntity();
            allPosition.Category1 = "All";
            allPosition.Category2 = "All";
            IncludeTaxCommand = new RelayCommand(OnIncludeTax);
            ExcludeTaxCommand = new RelayCommand(OnExcludeTax);
            SearchCommand = new RelayCommand(Search);
            ShowAllCommand = new RelayCommand(ShowAll);
            ShowSelectedCommand = new RelayCommand(ShowSelected);
            ShowProductsCommand = new RelayCommand(OnShowProducts);
            ShowServiceCommand = new RelayCommand(OnShowServices);
            ShowBothCommand = new RelayCommand(OnShowBoth);
            YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
            CalendarSelectionCommand = new RelayCommand(OnCalendarSelection);
            NavigateToPandSFormCommand = new RelayCommand(NavigateToPandSForm);
        }

        public TopPandSViewModel()
        {
        }
        public RelayCommand ShowBothCommand { get; set; }
        public RelayCommand ShowProductsCommand { get; set; }
        public RelayCommand ShowServiceCommand { get; set; }
        public RelayCommand YearQuarterSelectedCommand { get; set; }
        public RelayCommand CalendarSelectionCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        public RelayCommand ShowSelectedCommand { get; set; }
        public RelayCommand NavigateToPandSFormCommand { get; set; }
        public RelayCommand ShowIncGSTCommand { get; set; }
        public RelayCommand ShowExcGSTCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand IncludeTaxCommand { get; set; }
        public RelayCommand ExcludeTaxCommand { get; set; }
        #endregion  Constructor

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
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {
            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 115;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.GridHeight = minHeight;
            RefreshData();
        }
        //List<TopPandSEntity> DefaultList = new List<TopPandSEntity>();
        //List<TopPandSEntity> FullList = new List<TopPandSEntity>();
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

        void OnShowProducts(object param)
        {
            ShowProducts = true;
            ShowServices = false;
            ShowBoth = false;
        }
        void OnShowServices(object param)
        {
            ShowProducts = false;
            ShowServices = true;
            ShowBoth = false;
        }
        void OnShowBoth(object param)
        {
            ShowProducts = false;
            ShowServices = false;
            ShowBoth = true;
        }
        void OnIncludeTax(object param)
        {
            ShowIncTaxTrue = true;
            ShowExcTaxTrue = false;
            Search(null);
        }
        void OnExcludeTax(object param)
        {
            ShowExcTaxTrue = true;
            ShowIncTaxTrue = false;
            Search(null);
        }

        void NavigateToPandSForm(object param)
        {
            //SharedValues.NewClick = null;
            //string obj = param.ToString();
            //SharedValues.getValue = obj;
            //var mainview = ServiceLocator.Current.GetInstance<PandSDetailsView>();
            //var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            //mainregion.Add(mainview);
            //if (mainregion != null)
            //{
            //    mainregion.Activate(mainview);
            //}


            ////var tabview = ServiceLocator.Current.GetInstance<>();
            ////var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            ////tabregion.Add(tabview);
            ////if (tabregion != null)
            ////{
            ////    tabregion.Activate(tabview);
            ////}

            //eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            //eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products & Services Details Form");
        }
        void NavigaetoPandSNew(object param)
        {
            string obj = param.ToString();
            SharedValues.NewClick = obj;
            var mainview = ServiceLocator.Current.GetInstance<PandSDetailsView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customer Details Form");
        }

        private void RefreshData()
        {
            ITopPandSRepository pandsRepository = new TopPandSRepository();

            this.TopPandSList = pandsRepository.GetPandSList(null).OrderByDescending(x => x.Sales).ToList();
            this.ShowAllCount = this.TopPandSList.Count();
            this.ShowSelectedCount = 0;
            FullList = this.TopPandSList.ToList();
            DefaultList = this.TopPandSList.ToList();
         //   this.TopPandSListcmb = this.TopPandSList.OrderBy(x => x.PandSName).ToList();
            //this.TopPandSListcmbCode = this.TopPandSList.OrderBy(x => x.PandSCode).ToList();
            //this.TopPandSListcmbCat1 = this.TopPandSList.GroupBy(x => x.Category1).Select(e => e.First()).OrderBy(x => x.Category1).ToList();
            //this.TopPandSListcmbCat2 = this.TopPandSList.GroupBy(x => x.Category2).Select(e => e.First()).OrderBy(x => x.Category2).ToList();

            //allPosition.Category1 = "All";
            //allPosition.Category2 = "All";
            //this.TopPandSListcmbCat1.Insert(0, allPosition);
            //this.TopPandSListcmbCat2.Insert(0, allPosition);
            GetOptionsandTaxValues();
            this.ShowAllTrue = true;
            this.ShowBoth = true;
            this.ShowSelectedTrue = false;
            this.ShowProducts = false;
            this.ShowServices = false;

            this.YearRange = pandsRepository.GetYearRange().ToList();

            TotalSalesAmountStr = Convert.ToString(TopPandSList.Sum(e => e.Sales));
            TotalPurchaseAmountStr = Convert.ToString(TopPandSList.Sum(e => e.Purchase));
            //if (this.ShowIncTaxTrue == true)
            //{
            //    foreach (var item in this.TopPandSList)
            //    {
            //        //item.StandardSellPriceStr = item.PandSStdSellPriceaftGST.ToString();
            //        //item.AverageSellPriceStr = item.PandSAveSellPriceaftGST.ToString();
            //        //item.LastSellPriceStr = item.PandSLastSoldPriceaftGST.ToString();
            //    }
            //}
            //else
            //{
            //    foreach (var item in DefaultList)
            //    {
            //        //item.StandardSellPriceStr = item.PandSStdSellPricebefGST.ToString();
            //        //item.AverageSellPriceStr = item.PandSAveSellPricebefGST.ToString();
            //        //item.LastSellPriceStr = item.PandSLastSoldPricebefGST.ToString();
            //    }
            //}
            SetDefaultSearchSelection(this.JsonData);
            var pscat1 = psRepository.GetCategoryContent("PSC01");
            var pscat2 = psRepository.GetCategoryContent("PSC02");
            if (pscat1 != null)
            {
                PSCategory1 = pscat1.ToList();
            }
            if (pscat2 != null) { PSCategory2 = pscat2.ToList(); }
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

        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            ITopPandSRepository pandsRepository = new TopPandSRepository();
            oData = pandsRepository.GetOptionDetails();
            if (oData != null)
            {
                this.CurrencyName = oData.CurrencyCode;     //there is no currency name field in database         
                this.CurrencyCode = oData.CurrencyCode;
                this.CurrencyFormat = oData.NumberFormat;
                this.DateFormat = oData.DateFormat;
                this.DecimalPlaces = oData.DecimalPlaces;
                if (oData.ShowAmountIncGST == true)
                {
                    this.ShowIncTaxTrue = true;
                    this.ShowExcTaxTrue = false;
                    //int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.PurchaseQuotationList)
                    //{
                    //    item.QuotationAmount = Math.Round(Convert.ToDouble(item.QuotationAmount), decimalpoints).ToString();
                    //}
                    //this.PurchaseQuotationList = this.PurchaseQuotationList.Where(x => x.ExcIncGST == true).ToList();
                }
                else
                {
                    this.ShowIncTaxTrue = false;
                    this.ShowExcTaxTrue = true;
                    int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.PurchaseQuotationList)
                    //{
                    //    //item.QuotationAmount = item.QuotationAmountExcGST;
                    //    //item.QuotationAmount = Math.Round(Convert.ToDouble(item.QuotationAmountExcGST), decimalpoints).ToString();
                    //    item.QuotationAmount = Math.Round(Convert.ToDouble(item.QuotationAmount), decimalpoints).ToString();
                    //}
                    //commented on 23 May 2017
                    //if (this.PurchaseQuotationList != null)
                    //    this.PurchaseQuotationList = this.PurchaseQuotationList.Where(x => x.ExcIncGST == false).ToList();
                }
            }
            else
            {
                this.CurrencyName = "USD";
                this.CurrencyCode = "USD";
                this.CurrencyFormat = "en-US";
                this.DateFormat = "dd/MM/yyyy";
            }
            var objDefaultTax = pandsRepository.GetTaxes().FirstOrDefault();
            if (objDefaultTax != null)
            {
                this.TaxName = objDefaultTax.TaxName;
            }
            else
            {
                this.TaxName = "GST";
            }
        }
        void ShowAll(object param)
        {
            this.YearmonthQuartTrue = false;//added after client feedback
            this.StartEndDateTrue = false;//added after client feedback

            this.TopPandSList = FullList;
            this.TopPandSListcmb = FullList;
            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.TopPandSList.Count();
            else
                this.ShowSelectedCount = 0;
            this.SelectedSearchEndDate = null;
            this.SelectedSearchMonth = null;
            this.SelectedSearchQuarter = null;
            this.SelectedSearchYear = null;
            this.SelectedSearchStartDate = null;
            this.SelectedSearchEndDate = null;

            //commented and added on 23 may 2017
            this.TopPandSList = FullList.ToList();
            //this.TopPandSListDate = this.TopPandSList.GroupBy(x => x.CountAndAdjustStockDateDatetime).Select(y => y.First()).OrderBy(x => x.CountAndAdjustStockDateDatetime).Distinct().ToList();
            //this.TopPandSListSCNo = TopPandSList.OrderBy(e => e.CountAndAdjustStockNo).ToList();
            //this.TopPandSListAmount = this.TopPandSList.GroupBy(x => x.AdjustedAmountd).Select(y => y.First()).OrderBy(x => x.AdjustedAmountd).Distinct().ToList();
            //if (this.IncludingGSTTrue == true)
            //    this.PurchaseQuotationList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            //else
            //    this.PurchaseQuotationList = FullPQList.Where(x => x.ExcIncGST == false).ToList();
            Mouse.OverrideCursor = Cursors.Wait;
            Search(null);
            Mouse.OverrideCursor = null;
        }
        void ShowSelected(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Search(null);
            Mouse.OverrideCursor = null;
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
                    //var year = Convert.ToInt32(this.SelectedSearchYear);
                    //DefaultList = FullList.Where(x => x.CreatedDate.Value.Year == year).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.PurchaseQuotationListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.PurchaseQuotationListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.PurchaseQuotationListcmb = DefaultList;
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
                    //DefaultList = FullList.Where(x => x.CreatedDate.Value.Month == month1 || x.CreatedDate.Value.Month == month2 || x.CreatedDate.Value.Month == month3).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.PurchaseQuotationListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.PurchaseQuotationListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.PurchaseQuotationListcmb = DefaultList;
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
                    //var month = Convert.ToInt32(this.SelectedSearchMonth);
                    //DefaultList = FullPQList.Where(x => x.CreatedDate.Value.Month == month).ToList();
                    //if (this.IncludingGSTTrue == true)
                    //    this.PurchaseQuotationListInternal = DefaultList.Where(x => x.ExcIncGST == true).ToList();
                    //else
                    //    this.PurchaseQuotationListInternal = DefaultList.Where(x => x.ExcIncGST == false).ToList();
                    //this.PurchaseQuotationListcmb = DefaultList;
                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Month";
                    value.FieldValue = "0";
                    SearchValues.Add(value);
                }

                if(ShowIncTaxTrue==true)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "IncExcGST";
                    value.FieldValue = "true";
                    SearchValues.Add(value);
                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "IncExcGST";
                    value.FieldValue = "false";
                    SearchValues.Add(value);
                }

                if(ShowAllTrue==true)
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

                if (ShowProducts == true)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Products";
                    value.FieldValue = "1";
                    SearchValues.Add(value);
                }
                else if (ShowServices == true)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Products";
                    value.FieldValue = "2";
                    SearchValues.Add(value);
                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "Products";
                    value.FieldValue = "0";
                    SearchValues.Add(value);
                }

                if (this.SelectedSearchStartDate != null && this.SelectedSearchEndDate != null)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "StartDate";
                    value.FieldValue = this.SelectedSearchStartDate.ToString();
                    value.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchStartDate);
                    SearchValues.Add(value);
                   
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
                    value.FieldValue = "";
                    //value.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchStartDate);
                   // SearchValues.Add(value);

                    SearchEntity value1 = new SearchEntity();
                    value1.FieldName = "EndDate";
                    value1.FieldValue = "";
                    SearchValues.Add(value);
                    SearchValues.Add(value1);
                }


                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;

                ITopPandSRepository casRepository = new TopPandSRepository();
                var results = casRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.TopPandS), "TopPandS_List");
                if (Count != 0)
                {
                    this.TopPandSList = casRepository.GetPandSList(jsonSearch);
                }
                TotalSalesAmountStr = Convert.ToString(TopPandSList.Sum(e => e.Sales));
                TotalPurchaseAmountStr = Convert.ToString(TopPandSList.Sum(e => e.Purchase));
                //this.TopPandSListcmb = this.TopPandSList.OrderBy(e => e.CountAndAdjustStockNo).ToList();
                //this.TopPandSListDate = this.TopPandSList.GroupBy(x => x.CountAndAdjustStockDateDatetime).Select(y => y.First()).OrderBy(x => x.CountAndAdjustStockDateDatetime).Distinct().ToList();
                //this.TopPandSListSCNo = casRepository.GetAllStockCount().OrderBy(e => e.TopPandSListSCNo).ToList();
                //this.TopPandSListAmount = casRepository.GetAllStockCount().GroupBy(x => x.AdjustedAmountd).Select(y => y.First()).OrderBy(x => x.AdjustedAmountd).Distinct().ToList();
                if (this.ShowAllTrue == true)
                    this.ShowSelectedCount = 0;
                else
                    this.ShowSelectedCount = this.TopPandSList.Count();
                DefaultList = this.TopPandSListcmb;

              
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
                this.YearmonthQuartTrue = false;//change after feedback
                this.StartEndDateTrue = false;
                this.ShowSelectedCount = 0;
            }
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
                //case "ShowIncTaxTrue":
                //    GetData(this.ShowIncTaxTrue.ToString(), "ShowIncTaxTrue");
                //    break;
                //case "ShowExcTaxTrue":
                //    GetData(this.ShowExcTaxTrue.ToString(), "ShowExcTaxTrue");
                //    break;
                //case "ShowProducts":
                //    GetData(this.ShowProducts.ToString(), "ShowProducts");
                //    break;
                //case "ShowServices":
                //    GetData(this.ShowServices.ToString(), "ShowServices");
                //    break;
                //case "ShowBoth":
                //    GetData(this.ShowBoth.ToString(), "ShowBoth");
                //    break;
                //case "ShowAllTrue":
                //    GetData(this.ShowAllTrue.ToString(), "ShowAllTrue");
                //    break;
                //case "ShowSelectedTrue":
                //    GetData(this.ShowSelectedTrue.ToString(), "ShowSelectedTrue");
                //    break;
                
                //case "SelectedCategory1":
                //    GetData(this.SelectedCategory1, "SelectedCategory1");
                //    break;
                //case "SelectedCategory2":
                //    GetData(this.SelectedCategory2, "SelectedCategory2");
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
                //case "ShowAll":
                //    GetData(this.ShowAllTrue.ToString(), "ShowAll");
                //    break;
                    //case "ShowSelectedTrue":
                    //    GetData(this.ShowSelectedTrue.ToString(), "ShowSelectedTrue");
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
        public void GetData(string SearchFilter, string parameter)
        {
            if (parameter == "ShowIncTaxTrue" && SearchFilter == "True")
            {
                //ShowExcTaxTrue = false;
                //ShowIncTaxTrue = true;
                //foreach (var item in this.TopPandSList)
                //{
                //    item.StandardSellPriceStr = item.PandSStdSellPriceaftGST.ToString();
                //    item.AverageSellPriceStr = item.PandSAveSellPriceaftGST.ToString();
                //    item.LastSellPriceStr = item.PandSLastSoldPriceaftGST.ToString();
                //}
            }
            if (parameter == "ShowExcTaxTrue" && SearchFilter == "True")
            {
                //ShowExcTaxTrue = true;
                //ShowIncTaxTrue = false;
                //foreach (var item in this.TopPandSList)
                //{
                //    item.StandardSellPriceStr = item.PandSStdSellPricebefGST.ToString();
                //    item.AverageSellPriceStr = item.PandSAveSellPricebefGST.ToString();
                //    item.LastSellPriceStr = item.PandSLastSoldPricebefGST.ToString();
                //}
            }
            if (parameter == "ShowAllTrue" && SearchFilter == "True")
            {
                this.SelectedCategory1 = null;
                this.SelectedCategory2 = null;
                this.SelectedPandSCode = null;
                this.SelectedPandSName = null;
                this.TopPandSList = FullList.ToList();
                DefaultList = this.TopPandSList;
                this.TopPandSListcmb = this.TopPandSList;
                this.TopPandSListcmbCat1 = this.TopPandSList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                this.TopPandSListcmbCat2 = this.TopPandSList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                allPosition.Category1 = "All";
                allPosition.Category2 = "All";
                this.TopPandSListcmbCat1.Insert(0, allPosition);
                this.TopPandSListcmbCat2.Insert(0, allPosition);
                this.ShowSelectedTrue = false;
                this.ShowAllTrue = true;
                this.ShowSelectedCount = 0;
                //ShowProducts = false;
                //ShowServices = false;
                //ShowBoth = true;
            }
            if (parameter == "ShowProducts" && SearchFilter == "True")
            {
                //this.SelectedCategory1 = null;
                //this.SelectedCategory2 = null;
                this.SelectedPandSCode = null;
                this.SelectedPandSName = null;
                //this.TopPandSList = FullList.Where(x => x.PandSType == "P").ToList();
                //DefaultList = this.TopPandSList;
                //this.TopPandSListcmb = this.TopPandSList;
                ////this.TopPandSListcmbCat1 = this.TopPandSList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                ////this.TopPandSListcmbCat2 = this.TopPandSList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                //allPosition.Category1 = "All";
                //allPosition.Category2 = "All";
                //this.TopPandSListcmbCat1.Insert(0, allPosition);
                //this.TopPandSListcmbCat2.Insert(0, allPosition);
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.ShowSelectedCount = this.TopPandSList.Count();
                //ShowProducts = true;
                //ShowServices = false;
                //ShowBoth = false;
            }
            if (parameter == "ShowServices" && SearchFilter == "True")
            {
                //this.SelectedCategory1 = null;
                //this.SelectedCategory2 = null;
                //this.SelectedPandSCode = null;
                //this.SelectedPandSName = null;
                //this.TopPandSList = FullList.Where(x => x.PandSType == "S").ToList();
                //DefaultList = this.TopPandSList;
                //this.TopPandSListcmb = this.TopPandSList;
                ////this.TopPandSListcmbCat1 = this.TopPandSList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                ////this.TopPandSListcmbCat2 = this.TopPandSList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                //allPosition.Category1 = "All";
                //allPosition.Category2 = "All";
                //this.TopPandSListcmbCat1.Insert(0, allPosition);
                //this.TopPandSListcmbCat2.Insert(0, allPosition);
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.ShowSelectedCount = this.TopPandSList.Count();

                //ShowProducts = false;
                //ShowServices = true;
                //ShowBoth = false;
            }
            if (parameter == "ShowBoth" && SearchFilter == "True")
            {
                //this.SelectedCategory1 = null;
                //this.SelectedCategory2 = null;
                //this.SelectedPandSCode = null;
                //this.SelectedPandSName = null;
                //this.TopPandSList = FullList.ToList();
                //DefaultList = this.TopPandSList;
                ////this.TopPandSListcmb = this.TopPandSList;
                ////this.TopPandSListcmbCat1 = this.TopPandSList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                ////this.TopPandSListcmbCat2 = this.TopPandSList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                //allPosition.Category1 = "All";
                //allPosition.Category2 = "All";
                //this.TopPandSListcmbCat1.Insert(0, allPosition);
                //this.TopPandSListcmbCat2.Insert(0, allPosition);
                this.ShowSelectedTrue = false;
                this.ShowAllTrue = true;
                this.ShowSelectedCount = 0;
                //ShowProducts = false;
                //ShowServices = false;
                //ShowBoth = true;
            }
          
            //if (parameter == "SelectedCategory1")
            //{
            //    if (!string.IsNullOrWhiteSpace(SearchFilter))
            //    {
            //        if (SearchFilter != "All")
            //        {
            //            if (this.SelectedCategory2 != "All")
            //            {
            //                this.TopPandSList = DefaultList.Where(x => x.Category1 == SearchFilter && x.Category2 == this.SelectedCategory2).ToList();

            //            }
            //            else this.TopPandSList = DefaultList.Where(x => x.Category1 == SearchFilter).ToList();
            //        }

            //        else if (this.SelectedCategory2 != "All")
            //        {
            //            this.TopPandSList = DefaultList.Where(x => x.Category2 == this.SelectedCategory2).ToList();
            //        }

            //        else { this.TopPandSList = DefaultList; }
            //    }

            //    else
            //    {
            //        this.TopPandSList = DefaultList;
            //        this.SelectedCategory1 = "All";
            //    }

            //}
            //if (parameter == "SelectedCategory2")
            //{
            //    if (!string.IsNullOrWhiteSpace(SearchFilter))
            //    {
            //        if (SearchFilter != "All")
            //        {
            //            if (this.SelectedCategory1 != "All")
            //            {
            //                this.TopPandSList = DefaultList.Where(x => x.Category2 == SearchFilter && x.Category1 == this.SelectedCategory1).ToList();
            //            }
            //            else
            //                this.TopPandSList = DefaultList.Where(x => x.Category2 == SearchFilter).ToList();
            //        }
            //        else if (this.SelectedCategory1 != "All")
            //        {
            //            this.TopPandSList = DefaultList.Where(x => x.Category1 == this.SelectedCategory1).ToList();
            //        }

            //        else { this.TopPandSList = DefaultList; }
            //    }

            //    else
            //    {
            //        this.TopPandSList = DefaultList;
            //        this.SelectedCategory2 = "All";
            //    }

            //}
            Search(null);
        }

    }
}
