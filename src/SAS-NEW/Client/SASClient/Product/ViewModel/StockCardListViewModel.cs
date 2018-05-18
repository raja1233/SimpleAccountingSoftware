﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using SASBAL.Product;
using SASClient.CashBank.Views;
using SASClient.CloseRequest;
using SASClient.Product.Services;
using SDN.CashBank.Views;
using SDN.Common;
using SDN.Product.Services;
using SDN.Product.View;
using SDN.Product.ViewModel;
using SDN.Purchasing.View;
using SDN.Sales.Views;
using SDN.UI.Entities;
using SDN.UI.Entities.HomeScreen;
using SDN.UI.Entities.Product;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SASClient.Product.ViewModel
{
    public class StockCardListViewModel : StockCardListEntity
    {
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private ObservableCollection<FormNameEntity> _formlist = new ObservableCollection<FormNameEntity>();
        public IPandSDetailsRepository pandsRepository = new PandSDetailsRepository();
        private static IEnumerable<PandSQtyAndStockModel> ProductList;
        private List<SearchEntity> SearchValues;
        private string jsonSearch;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private int _SelectedCategoryType1;
        private int _SelectedCategoryType2;
       
        private ObservableCollection<DataGridViewModel> psDetailsEntity;
        public ObservableCollection<DataGridViewModel> lst;
        public List<StockCardListEntity> tempList;
        //delegate void ThreadStart ThreadProc();
        StockCardListEntity allPosition = new StockCardListEntity();
        StackList listitem = new StackList();
        private int Count = 0;
        

        IStockCardListRepository purchaseRepository = new StockCardListRepository();

        public ObservableCollection<QuarterEntity> QuarterList
        {
            get
            {
                _quarterlist.Clear();
                QuarterData();
                return _quarterlist;
            }
        }
        private ObservableCollection<PandSQtyAndStockModel> productAndServices;
        public ObservableCollection<PandSQtyAndStockModel> ProductAndServices
        {
            get
            {
                return productAndServices;
            }
            set
            {
                if (productAndServices != value)
                {
                    productAndServices = value;
                    OnPropertyChanged("ProductAndServices");
                }
            }
        }
   
        public int SelectedCategoryType1
        {
            get
            {
                return _SelectedCategoryType1;
            }
            set
            {
                _SelectedCategoryType1 = value;
                OnPropertyChanged("SelectedCategoryType1");
                if (_SelectedCategoryType1 != 0)
                {
                    ShowSelected();
                }
            }
        }

        //public ObservableCollection<DataGridViewModel> PSDetailsEntity
        //{
        //    get { return psDetailsEntity; }
        //    set
        //    {
        //        psDetailsEntity = value;
        //        OnPropertyChanged("PSDetailsEntity");

        //    }
        //}

        //public ObservableCollection<DataGridViewModel> Lst
        //{
        //    get { return lst; }
        //    set
        //    {
        //        lst = value;
        //        OnPropertyChanged("Lst");
        //    }
        //}
        public int SelectedCategoryType2
        {
            get
            {
                return _SelectedCategoryType2;
            }
            set
            {
                _SelectedCategoryType2 = value;
                OnPropertyChanged("SelectedCategoryType2");
                if (_SelectedCategoryType2 != 0)
                {
                    ShowSelected();
                }

            }
        }

        //public ObservableCollection<StockCardListViewModel> ProductAndServices
        //{
        //    get
        //    {
        //        return productAndServices;
        //    }
        //    set
        //    {
        //        if (productAndServices != value)
        //        {
        //            productAndServices = value;
        //            OnPropertyChanged("ProductAndServices");
        //        }
        //    }
        //}
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
        /// Initializes a new instance of the <see cref="StockCardListViewModel"/> class.
        /// </summary>
        public StockCardListViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            SearchCommand = new RelayCommand(Search);
            
            ShowSelectedCommand = new RelayCommand(ShowSelected);
            NavigateToClientCommand = new RelayCommand(NavigatetoSupplier);
            ShowIncGSTCommand = new RelayCommand(showincGST);
            ShowExcGSTCommand = new RelayCommand(showexcGST);
            RefreshCommand = new RelayCommand(refreshcommand);
            CloseCommand = new DelegateCommand(Close);
            SelectChangedCommand = new RelayCommand(OnSelectionChange);
            NavigaetoStockCommand = new RelayCommand(NavigatetoStockInvoice);
            //YearQuarterSelectedCommand = new RelayCommand(OnYearQuarterMonthChange);
            //CalendarSelectionCommand = new RelayCommand(OnCalendarSelection);
            //NavigaetoTranCommand = new RelayCommand(NavigaetoTranView);

        }

        public StockCardListViewModel()
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
        public RelayCommand NavigaetoTranCommand { get; set; }
        public RelayCommand SelectChangedCommand { get; set; }
        public RelayCommand NavigaetoStockCommand { get; set; }
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
        //void OnYearQuarterMonthChange(object param)
        //{
        //    ShowAllTrue = false;
        //}
        //void OnCalendarSelection(object param)
        //{
        //    ShowAllTrue = false;
        //}//end
        void showincGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //foreach (var item in this.StockCardList)
            //{
            //    //item.InvoiceAmount = item.InvoiceAmountIncGST;
            //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountIncGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.StockCardList = DefaultList.Where(x => x.ExcIncGST == true).ToList();
            //else
            //    this.StockCardList = FullPQList.Where(x => x.ExcIncGST == true).ToList();
            IStockCardListRepository purchaseRepository = new StockCardListRepository();
            //this.StockCardList = purchaseRepository.GetAllStockCardJson(this.JsonData).OrderBy(x => x.CustomerName).ToList();
          
            this.ShowSelectedCount = 0;
            this.StockCardListcmbTranType = this.StockCardList.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
            //this.StockCardListcmbName = this.StockCardList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).Where(y => y.Name != null).ToList();
            //this.StockCardListcmbTranNo = this.StockCardList.GroupBy(x => x.TransactionNo).Select(y => y.First()).OrderBy(x => x.TransactionNo).Distinct().ToList();
            this.StockCardListcmbDate = this.StockCardList.GroupBy(x => x.TransactionDate).Select(y => y.First()).OrderBy(x => x.TransactionDate).Where(y => y.TransactionDate != null).Distinct().ToList();
            this.StockCardListcmbAmount = this.StockCardList.GroupBy(x => x.Amount).Select(y => y.First()).OrderBy(x => x.Amount).Distinct().Where(y => y.Amount != null).ToList();
            // this.StockCardListcmbUserName = this.StockCardList.GroupBy(x => x.UserName).Select(y => y.First()).OrderBy(x => x.UserName).Distinct().ToList();
            DefaultList = this.StockCardList;
            //StockCardListcmbDefault = this.StockCardListProductDetails;

            Mouse.OverrideCursor = null;
        }

        void NavigatetoStockInvoice(object param)
        {

            try
            {
                var sub = param.ToString();
                var comp = sub.Substring(0, 2);

                if (param != null)
                {
                    string obj = param.ToString();
                    SharedValues.NewClick = obj;

                    if (comp == "PI")
                    {
                        SharedValues.ScreenCheckName = "Purchases Invoice (P & S)";
                        SharedValues.ViewName = "Purchase Invoice (Products & Services)";
                        var accessitem = listitem.AddToList();
                        if (accessitem == true)
                        {
                            var tabview1 = ServiceLocator.Current.GetInstance<PurchaseTabView>();

                        var tabregion1 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion1.Add(tabview1);
                        if (tabregion1 != null)
                        {
                            tabregion1.Activate(tabview1);
                        }

                        var mainview1 = ServiceLocator.Current.GetInstance<PurchaseInvoicePandSView>();

                        var mainregion1 = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion1.Add(mainview1);
                        if (mainregion1 != null)
                        {
                            mainregion1.Activate(mainview1);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoice Form (Products & Services)");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
                        }
                    }
                    else if (comp == "SI")
                    {
                        SharedValues.ScreenCheckName = "Sales Invoice";
                        SharedValues.ViewName = "Sales Invoice";
                        var accessitem = listitem.AddToList();
                        if (accessitem == true)
                        {
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
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
                        }
                    }
                    else if (comp == "SC")
                    {
                        SharedValues.ScreenCheckName = "Count & Adjust Stock";
                        SharedValues.ViewName = "Count & Adjust Stock";
                        var accessitem = listitem.AddToList();
                        if (accessitem == true)
                        {
                            var tabview = ServiceLocator.Current.GetInstance<ProductTabView>();

                        var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        tabregion.Add(tabview);
                        if (tabregion != null)
                        {
                            tabregion.Activate(tabview);
                        }

                        var mainview = ServiceLocator.Current.GetInstance<CountAndAdjustStockView>();

                        var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                        mainregion.Add(mainview);
                        if (mainregion != null)
                        {
                            mainregion.Activate(mainview);
                        }////
                        eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        eventAggregator.GetEvent<TitleChangedEvent>().Publish("Count And Adjust Stock Form");
                        }
                        else
                        {
                            MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
                        }
                    }
                }
                else
                {

                }
            }
            catch(Exception e)
            {
                throw e;
            }
              
        }
        public void ShowSelected()
        {

            // List<DataGridViewModel> lst = new List<DataGridViewModel>();

            if (SelectedCategoryType1 != 0 && SelectedCategoryType2 != 0)
            {
                //StockCardList = new ObservableCollection<DataGridViewModel>(Lst.Where(e => e.PSCat1 == SelectedCategoryType1 && e.PSCat2 == SelectedCategoryType2));
                StockCardList= DefaultList.Where(x => (x.Category1 ==SelectedCategoryType1 && x.Category2== SelectedCategoryType2)).GroupBy(x => x.ProductCode).Select(x => x.FirstOrDefault()).OrderBy(x => x.ProductCode).ToList();
            }
            else if (SelectedCategoryType1 != 0)
            {
                //PSDetailsEntity = new ObservableCollection<DataGridViewModel>(Lst.Where(e => e.PSCat1 == SelectedCategoryType1));
                StockCardList = DefaultList.Where(x => (x.Category1 == SelectedCategoryType1 )).GroupBy(x => x.ProductCode).Select(x => x.FirstOrDefault()).OrderBy(x => x.ProductCode).ToList();
            }
            else if (SelectedCategoryType2 != 0)
            {
                //PSDetailsEntity = new ObservableCollection<DataGridViewModel>(Lst.Where(e => e.PSCat2 == SelectedCategoryType2));
                StockCardList = DefaultList.Where(x => (x.Category2 == SelectedCategoryType2 )).GroupBy(x => x.ProductCode).Select(x => x.FirstOrDefault()).OrderBy(x => x.ProductCode).ToList();
            }
            //ShowAllrdn = false;
            //ShowSelectedrdn = true;
            //ShowSelectedCount = PSDetailsEntity.Where(e => e.SelectedPSID != 0).Count();
            OnPropertyChanged("StockCardList");
        }
        public void SelectedFilter()
        {
            try
            {
                if (!String.IsNullOrEmpty(SelectedName))
                {
                    StockCardListProductDetails = StockCardListcmbDefault.Where(x => x.Name == SelectedName).ToList();
                }
                else
                {
                    StockCardListProductDetails = StockCardListcmbDefault;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            
            OnPropertyChanged("StockCardListProductDetails");
        }

        void showexcGST(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //foreach (var item in this.StockCardList)
            //{
            //    //item.InvoiceAmount = item.InvoiceAmountExcGST;
            //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountExcGST), decimalpoints).ToString();
            //}
            //if (this.ShowAllTrue == false)
            //    this.StockCardList = DefaultList.Where(x => x.ExcIncGST == false).ToList();
            //else
            //    this.StockCardList = FullPQList.Where(x => x.ExcIncGST == false).ToList();
            IStockCardListRepository purchaseRepository = new StockCardListRepository();
            //this.StockCardList = purchaseRepository.GetProductsDetails(this.JsonData, this.IncludingGSTTrue, this.ProductCode);

            //this.StockCardList = purchaseRepository.GetAllStockCardJson(this.JsonData).OrderBy(x => x.CustomerName).ToList();
            this.ShowSelectedCount = 0;
            this.StockCardListcmbTranType = this.StockCardList.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
            this.StockCardListcmbName = this.StockCardList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).Where(y => y.Name != null).ToList();
            //this.StockCardListcmbTranNo = this.StockCardList.GroupBy(x => x.TransactionNo).Select(y => y.First()).OrderBy(x => x.TransactionNo).Distinct().ToList();
            this.StockCardListcmbDate = this.StockCardList.GroupBy(x => x.TransactionDate).Select(y => y.First()).OrderBy(x => x.TransactionDate).Where(y => y.TransactionDate != null).Distinct().ToList();
            this.StockCardListcmbAmount = this.StockCardList.GroupBy(x => x.Amount).Select(y => y.First()).OrderBy(x => x.Amount).Distinct().Where(y => y.Amount != null).ToList();
            //this.StockCardListcmbUserName = this.StockCardList.GroupBy(x => x.UserName).Select(y => y.First()).OrderBy(x => x.UserName).Distinct().ToList();
            DefaultList = this.StockCardList;
           // StockCardListcmbDefault = this.StockCardListProductDetails;

            Mouse.OverrideCursor = null;
        }
        void NavigatetoSupplier(object param)
        {

            if (param != null)
            {

                List<object> listItem = new List<object>();
                listItem = param as List<object>;
                var CusupID = listItem[0].ToString();
                var TransType = listItem[1].ToString();
                if (TransType.Equals("SI"))
                {
                    SharedValues.ScreenCheckName = "Customers Details";
                    SharedValues.ViewName = "Customers Details";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.getValue = CusupID;
                    var view = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersView>();

                    IRegion region = this.regionManager.Regions[RegionNames.MainRegion];

                    region.Add(view);
                    if (region != null)
                    {
                        region.Activate(view);
                    }

                    var view2 = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();

                    IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                    region2.Add(view2);
                    if (region2 != null)
                    {
                        region2.Activate(view2);
                    }
                    eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                    eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details Form");
                    }
                    else
                    {
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
                    }
                }
              


            
                else if(TransType.Equals("PI"))
                {

                    SharedValues.ScreenCheckName = "Suppliers Details";
                    SharedValues.ViewName = "Suppliers Details";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    {
                        SharedValues.getValue = CusupID;
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
                    eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details Form");
                    }
                    else
                    {
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
                    }
                }
                //string obj = param.ToString();
                //SharedValues.getValue = obj;
            }
            

        
            
        }

        public void showStockList()
        {


            this.StockCardList = purchaseRepository.GetAllStockCard();
        }
        //public string SelectedName
        //{
        //    get
        //    {
        //        return _SelectedName;
        //    }
        //    set
        //    {
        //        _SelectedName = value;
        //        OnPropertyChanged("SelectedName");
        //        //if (!String.IsNullOrEmpty(_SelectedName))
        //        //{
        //        //    SelectedFilter();
        //        //}
        //    }
        //}


        void OnSelectionChange(object param)
        {
            //jsonSearch = JsonConvert.SerializeObject(SearchValues);
            //this.JsonData = jsonSearch;
           
            if ((ProductCode != null && !String.IsNullOrEmpty(JsonData)))
            {
                StockCardListProductDetails = purchaseRepository.GetProductsDetails(this.JsonData, this.IncludingGSTTrue, ProductCode).ToList();
                tempList = StockCardListProductDetails.GroupBy(x => x.Name).Select(g => g.First()).Where(x => !string.IsNullOrEmpty(x.Name) || !string.IsNullOrWhiteSpace(x.Name)).ToList();
                this.StockCardNameListDetails = tempList.GroupBy(x => x.Name).Select(g => g.First()).Where(x => x.Name != "Opening Balance" && x.Name != "Closing Balance").ToList();
                this.StockCardListcmbTranType = this.StockCardListProductDetails.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
                this.StockCardListcmbDefault = StockCardListProductDetails;
            }
            else
            {
                if(ProductCode == null && JsonData ==null)
                {
                    StockCardListProductDetails = purchaseRepository.GetProductsDetails(this.JsonData, this.IncludingGSTFalse, ProductCode).ToList();
                    StockCardListcmbDefault = StockCardListProductDetails;
                }
                else
                {
                    StockCardListProductDetails = purchaseRepository.GetProductsDetails(this.JsonData, this.IncludingGSTTrue, ProductCode).ToList();
                   StockCardListcmbDefault = StockCardListProductDetails;
                    tempList = StockCardListProductDetails.GroupBy(x => x.Name).Select(g => g.First()).Where(x => !string.IsNullOrEmpty(x.Name) || !string.IsNullOrWhiteSpace(x.Name)).ToList();
                    this.StockCardNameListDetails = tempList.GroupBy(x => x.Name).Select(g => g.First()).Where(x => x.Name != "Opening Balance" && x.Name != "Closing Balance").ToList();
                    this.StockCardListcmbTranType = this.StockCardListProductDetails.GroupBy(x => x.TransactionType).Select(g => g.First()).Where(x => x.TransactionType != null && x.Name != "Opening Balance" && x.Name != "Closing Balance").ToList();
                }
                
            }                   
        }
        void ShowSelected(object param)
        {

            Search(null);
        }
        List<StockCardListEntity> ProductDetailDefault = new List<StockCardListEntity>();
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
                //if (this.SelectedSearchStartDate != null && this.SelectedSearchEndDate != null)
                //{
                //    SearchEntity value = new SearchEntity();
                //    value.FieldName = "StartDate";
                //    value.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchStartDate);
                //    SearchValues.Add(value);
                //    SearchEntity value1 = new SearchEntity();
                //    value1.FieldName = "EndDate";
                //    value1.FieldValue = string.Format("{0:MMM/dd/yyyy}", this.SelectedSearchEndDate);
                //    SearchValues.Add(value1);
                //}
                //else
                //{
                //    SearchEntity value = new SearchEntity();
                //    value.FieldName = "StartDate";
                //    value.FieldValue = "0";
                //    //SearchValues.Add(value);
                //    SearchEntity value1 = new SearchEntity();
                //    value1.FieldName = "EndDate";
                //    value1.FieldValue = "0";
                //    SearchValues.Add(value);
                //    SearchValues.Add(value1);
                //}

                //if (this.ShowAllTrue == true)
                //{
                //    SearchEntity value = new SearchEntity();
                //    value.FieldName = "ShowAll";
                //    value.FieldValue = this.ShowAllTrue.ToString();
                //    SearchValues.Add(value);
                //}
                //else
                //{
                //    SearchEntity value = new SearchEntity();
                //    value.FieldName = "ShowAll";
                //    value.FieldValue = "false";
                //    SearchValues.Add(value);
                //}
                if (this.SelectedFormName != null && this.SelectedFormName != string.Empty)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "ScreenName";
                    value.FieldValue = this.SelectedFormName.ToString();
                    SearchValues.Add(value);
                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "ScreenName";
                    value.FieldValue = "Customers Details";
                    SearchValues.Add(value);
                }
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;
               
                IStockCardListRepository purchaseRepository = new StockCardListRepository();
                var results = purchaseRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.StockCardList), "StockCardList");

                //var results = purchaseRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.StockCardList), "StockCardList");
                if (Count != 0)
                {
                    //this.StockCardList = purchaseRepository.GetAllStockCardJson(jsonSearch).ToList();
                    //FullPQList = this.StockCardList;
                    //DefaultList = this.StockCardList;
                    //this.JsonData = purchaseRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.StockCardList));
                    this.StockCardListProductDetails = purchaseRepository.GetProductsDetails(this.JsonData, this.IncludingGSTTrue, this.ProductCode).ToList();
                    tempList = this.StockCardListProductDetails.GroupBy(x => x.Name).Select(g => g.First()).Where(x => !string.IsNullOrEmpty(x.Name) || !string.IsNullOrWhiteSpace(x.Name)).ToList();
                    this.StockCardNameListDetails = this.StockCardListProductDetails.GroupBy(x => x.Name).Select(g => g.First()).Where(x => x.Name != "Opening Balance" && x.Name != "Closing Balance").ToList();
                    //this.ProductDetailDefault = StockCardListProductDetails;
                    //if(StockCardListProductDetails.Count() == 0)
                    //{
                    //    this.StockCardList = DefaultList;
                    //}
                    //else
                    //{
                    //    DefaultList = this.StockCardList;
                    //}

                    this.StockCardListcmbTranType = this.StockCardList.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
                    //allPosition.TransactionType = "All";
                    //allPosition.Category2 = "All";
                    //this.StockCardListcmbTranType.Insert(0, allPosition);
                    //this.SelectedTransactionType = "All";
                    this.StockCardListcmbName = this.StockCardList.GroupBy(x => x.Name).Select(g => g.First()).OrderBy(x => x.Name).Where(y => y.Name != null).ToList();
                    //this.StockCardListcmbTranNo = this.StockCardList.GroupBy(x => x.TransactionNo).Select(y => y.First()).OrderBy(x => x.TransactionNo).Distinct().ToList();
                    //this.StockCardListcmbDate = this.StockCardList.GroupBy(x => x.TransactionDate).Select(y => y.First()).OrderBy(x => x.TransactionDate).Where(y => y.TransactionDate != null).Distinct().ToList();
                    //this.StockCardListcmbAmount = this.StockCardList.GroupBy(x => x.Amount).Select(y => y.First()).OrderBy(x => x.Amount).Distinct().Where(y => y.Amount != null).ToList();
                    // FullPQList = this.StockCardListcmb;
                    //allPosition.TransactionType = "All";
                    ////allPosition.Category2 = "All";
                    //this.StockCardListcmbTranType.Insert(0, allPosition);
                    //this.PandSSellPriceListcmbCat2.Insert(0, allPosition);

                }
                this.StockCardListcmb = this.StockCardList.OrderBy(x => x.ProductCode).ToList();
                this.StockCardListcmb = this.StockCardList.OrderBy(x => x.ProductName).ToList();
                DefaultList = this.StockCardListcmb;
              
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
        List<StockCardListEntity> DefaultList = new List<StockCardListEntity>();
        List<StockCardListEntity> StockCardListcmbDefault = new List<StockCardListEntity>();
        List<StockCardListEntity> FullPQList = new List<StockCardListEntity>();
      
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {

            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 70;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SIGridHeight = minHeight;
            RefreshData();
        }

        //public void ShowSelected()
        //{

        //    // List<DataGridViewModel> lst = new List<DataGridViewModel>();

        //    if (!String.IsNullOrEmpty(SelectedCategoryType1) && !String.IsNullOrEmpty(SelectedCategoryType2))
        //    {
        //        PSDetailsEntity = new ObservableCollection<StockCardListViewModel>(Lst.Where(e => e.PSCategory1.ToString() == SelectedCategoryType1 && e.PSCategory1.ToString() == SelectedCategoryType1));
        //    }
        //    else if (!String.IsNullOrEmpty(SelectedCategoryType1))
        //    {
        //        PSDetailsEntity = new ObservableCollection<StockCardListViewModel>(Lst.Where(e => e.PSCategory1.ToString() == SelectedCategoryType1));
        //    }
        //    else if (!String.IsNullOrEmpty(SelectedCategoryType2))
        //    {
        //        PSDetailsEntity = new ObservableCollection<StockCardListViewModel>(Lst.Where(e => e.PSCategory1.ToString() == SelectedCategoryType1));
        //    }  
        //    OnPropertyChanged("PSDetailsEntity");
        //}

        private void RefreshData()
        {
            //IStockCardListRepository purchaseRepository = new StockCardListRepository();

       
            ProductList = pandsRepository.GetPandSList().Where(e => e.PSType == "P" && e.IsInActive != "Y");
            if (ProductList != null)
            {
                ProductAndServices = new ObservableCollection<PandSQtyAndStockModel>(ProductList);
            }

            this.DateFormat = purchaseRepository.GetDateFormat();
            this.ShowAllCount = purchaseRepository.GetAllStockCard().Count();
            
            var pscat1 = pandsRepository.GetCategoryContent("PSC01");
            var pscat2 = pandsRepository.GetCategoryContent("PSC02");
            if (pscat1 != null)
            {
                PSCategory1 = pscat1.ToList();
            }
            if (pscat2 != null) { PSCategory2 = pscat2.ToList(); }
            //showStockList();
            GetOptionsandTaxValues();

            this.JsonData = purchaseRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.StockCardList));
            //this.StockCardList = purchaseRepository.GetAllStockCardJson(this.JsonData).OrderBy(x => x.CustomerName).ToList();
            this.StockCardList = purchaseRepository.GetAllStockCard().GroupBy(x=>x.ProductCode).Select(x=>x.FirstOrDefault()).OrderBy(x => x.ProductCode).ToList();

            this.ShowSelectedCount = this.StockCardList.Count();
            this.StockCardListcmbTranType = this.StockCardList.GroupBy(x => x.TransactionType).Select(g => g.First()).OrderBy(x => x.TransactionType).Where(y => y.TransactionType != null).ToList();
            
            this.YearRange = purchaseRepository.GetYearRange().ToList();
            DefaultList = this.StockCardList;
            FullPQList = this.StockCardList;
            StockCardListcmb = StockCardList.GroupBy(x=>x.ProductCode).Select(x=>x.FirstOrDefault()).OrderBy(x=>x.ProductCode).ToList();
            
            StockCardListcmbPn = StockCardList.GroupBy(x => x.ProductName).Select(x => x.FirstOrDefault()).OrderBy(x => x.ProductName).ToList();
            //StockCardListcmbDefault = this.StockCardListProductDetails;
            //this.ShowAllCount = this.StockCardListcmb.Count();
            SetDefaultSearchSelection();
            allPosition.TransactionType = "All";
            this.SelectedTransactionType = "All";
            //allPosition.Category2 = "All";
            this.StockCardListcmbTranType.Insert(0, allPosition);
           
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            IStockCardListRepository purchaseRepository = new StockCardListRepository();
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
                    //foreach (var item in this.StockCardList)
                    //{
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    //this.StockCardList = this.StockCardList.Where(x => x.ExcIncGST == true).ToList();
                }
                else
                {
                    this.IncludingGSTTrue = false;
                    this.IncludingGSTFalse = true;
                    int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.StockCardList)
                    //{
                    //    //item.InvoiceAmount = item.InvoiceAmountExcGST;
                    //    //item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmountExcGST), decimalpoints).ToString();
                    //    item.InvoiceAmount = Math.Round(Convert.ToDouble(item.InvoiceAmount), decimalpoints).ToString();
                    //}
                    if (this.StockCardList != null)
                        this.StockCardList = this.StockCardList.ToList();
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
        public void LoadSearchResult(string customerName)
        {
            IStockCardListRepository purchaseRepository = new StockCardListRepository();
            this.ShowAllCount = purchaseRepository.GetAllStockCard().Count();
            this.StockCardList = purchaseRepository.GetAllStockCard().Where(x => x.CustomerName == customerName).ToList();
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
                //case "SelectedTransactionType":
                //    GetData(this.SelectedTransactionType, "SelectedTransactionType");
                //    break;
                case "SelectedPandSCode":
                    GetData(this.SelectedPandSCode, "ProductCode");
                    break;
                case "SelectedPandSName":
                    GetData(this.SelectedPandSName, "ProductName");
                    break;
                //case "selectedcategorytype1":
                //    GetData(this.SelectedCategoryType1.ToString(), "PSCategory1");
                //    break;
                //case "selectedcategorytype2":
                //    GetData(this.SelectedCategoryType2.ToString(), "PSCategory2");
                //    break;
                case "SelectedName":
                    GetData(this.SelectedName, "SelectedName");
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
                case "SelectedFormName":
                    SetData(this.SelectedFormName.ToString(), "SelectedFormName");
                    break;
                case "SelectedTransactionType":
                    GetData(this.SelectedTransactionType, "SelectedTransactionType");
                    break;
            }

            base.OnPropertyChanged(name);
        }

        public void SetData(string SearchFilter, string parameter)
        {
           
            if (parameter == "SelectedFormName" && SearchFilter != string.Empty && SearchFilter != null)
            {
                Search(null);
            }
            if (parameter == "Year" && SearchFilter != string.Empty && SearchFilter != null)
            {
                this.ShowSelectedTrue = true;
                //this.ShowAllTrue = false;
                this.YearmonthQuartTrue = true;//change after client feedback on 22 may 2017
                Search(null);
            }
           
            if (parameter == "Quarter" && SearchFilter != string.Empty && SearchFilter != null)
            {
                this.ShowSelectedTrue = true;
                //this.ShowAllTrue = false;
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
                //this.ShowAllTrue = false;
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
           
            if (parameter == "ProductCode")
            {
                if (!string.IsNullOrEmpty(SearchFilter))
                {
                    this.StockCardList = DefaultList.Where(x => (x.ProductCode == SearchFilter)).ToList();
                  

                }
                else
                {
                    this.StockCardList = DefaultList;
                }
            }
               
            if (parameter == "ProductName")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {

                    this.ShowAllCount = this.ShowAllCount;

                    this.StockCardList = DefaultList.Where(x => (x.ProductName == SearchFilter)).ToList();
                }
                else
                {
                    this.StockCardList = DefaultList.ToList();
                    this.ProductName = "All";
                }
            }

            //if (parameter == "PSCategory1")
            //{
            //    if (SearchFilter != null || SearchFilter == string.Empty)
            //    {
                   
            //        this.StockCardList = DefaultList.Where(x => (x.Category1 == Convert.ToInt32(SearchFilter))).GroupBy(x => x.ProductCode).Select(x => x.FirstOrDefault()).OrderBy(x => x.ProductCode).ToList();
                   
            //    }
            //    else
            //    {
            //        this.StockCardList = DefaultList;
            //        this.ProductName = "All";
            //    }
            //}
            //if (parameter == "PSCategory2")
            //{
            //    if (SearchFilter != null || SearchFilter == string.Empty)
            //    {
                    
            //        this.StockCardList = DefaultList.Where(x => (x.Category2 == Convert.ToInt32(SearchFilter))).GroupBy(x => x.ProductCode).Select(x => x.FirstOrDefault()).OrderBy(x => x.ProductCode).ToList();

            //    }
            //    else
            //    {
            //        this.StockCardList = DefaultList;
            //        this.ProductName = "All";
            //    }
            //}

            if (parameter == "SelectedName")
            {
                if (SearchFilter != null|| SearchFilter == string.Empty)
                {
                    this.ShowAllCount = this.ShowAllCount;
                    this.StockCardListProductDetails = StockCardListcmbDefault.Where(x => x.Name == SearchFilter).ToList();
                }
                else
                {
                    this.StockCardListProductDetails = StockCardListcmbDefault;
                }
               
            }
            if (parameter == "SelectedTransactionType")
            {
                if (SearchFilter != null || SearchFilter == string.Empty)
                {
                    this.ShowAllCount = this.ShowAllCount;
                    this.StockCardListProductDetails = StockCardListcmbDefault.Where(x => x.TransactionType == SearchFilter).ToList();
                }
                else
                {
                    this.StockCardListProductDetails = StockCardListcmbDefault;
                }
            }

            //TotalInvoiceAmount = Convert.ToString(StockCardList.Sum(e => e.InvoiceAmountValue));
            //TotalCCDAmount = Convert.ToString(StockCardList.Sum(e => e.TotalAmount));
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
