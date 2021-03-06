﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.ViewModel
{
    using SDN.Common;
    using System.Collections.ObjectModel;
    using SDN.UI.Entities;

    using System.Windows.Input;
    using System.ComponentModel;

    using System.Windows;
    using Microsoft.Practices.ServiceLocation;

    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.Events;
    using UI.Entities.Sales;
    using Services;
    using Product.Services;
    using Customers.Views;
    using Views;
    using Customers.Services;
    using SASClient.Reports.ReportsPage;
    using SASClient.CloseRequest;
    using Microsoft.Practices.Prism.Commands;
    using Settings.Services;
    using System.Globalization;

    public class SalesOrderViewModel : SalesOrderEntity
    {
        #region "Private members"
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        ICompanyDetails CompanyD = new CompanyDetails();
        private string _DateErrors;
        //private ObservableCollection<PandSDetailsModel> pands;
        private string currencyName;
        //  private string taxName;
        private ObservableCollection<DataGridViewModel> sqDetailsEntity;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private ISalesOrderRepository soRepository = new SalesOrderRepository();
        private ISalesQuotationRepository sqRepository = new SalesQuotationRepository();
        public IPandSDetailsRepository pandsRepository = new PandSDetailsRepository();
        private Customers.Services.ICustomerRepository customerRepository = new CustomerRepository();
        public ObservableCollection<DataGridViewModel> lst;
        private DataGridViewModel sqdEntity;
        private SalesOrderEntity purchaseOrderEntity;
        //private SalesOrderDetailEntity selectedPandS;
        private decimal? customerDiscount;
        private int customerId;
        StackList listitem = new StackList();
        private decimal? taxRate;
        //private ObservableCollection<PandSDetailsModel> productAndServices;
        private ObservableCollection<PandSListModel> productAndServices;
        //private int? sqQty;
        //private decimal? sqPrice;
        //private decimal? sqAmount;
        //private decimal? sqDiscount;
        //private decimal? gstRate;
        private int? defaultPSID;
        private DateTime? _OrderDateCalender;
        private DateTime? _DeliveryDateCalender;
        private decimal? amountBeforeTax;
        private decimal? taxAmount;
        private string sqErrros;
        private bool isNew;
        private bool allFieldsReadonly;
        private bool allFieldsEnabled;
        private int decimalPlaces;
        private string dateFormat;
        private bool? isDiscountEditable;
        private bool? isHideDiscColumn;
        private bool? isPriceEditable;
        private int? selectedSalesmanID;
        private System.Windows.Visibility visibilityForImage;
        private string statusString;
        #endregion

        #region "Public Properties"
        public System.Windows.Visibility VisibilityForImage
        {
            get
            {
                return visibilityForImage;
            }
            set
            {
                visibilityForImage = value;
                OnPropertyChanged("VisibilityForImage");
            }
        }
        public string DateErrors
        {
            get
            {
                return _DateErrors;
            }
            set
            {
                _DateErrors = value;
                OnPropertyChanged("DateErrors");
            }
        }
        public DateTime? OrderDateCalender
        {
            get
            {
                return _OrderDateCalender;
            }
            set
            {
                _OrderDateCalender = value;
                OnPropertyChanged("OrderDateCalender");
            }
        }
        public DateTime? DeliveryDateCalender
        {
            get
            {
                return _DeliveryDateCalender;
            }
            set
            {
                _DeliveryDateCalender = value;
                OnPropertyChanged("DeliveryDateCalender");
            }
        }
        public string StatusString
        {
            get { return statusString; }
            set
            {
                statusString = value;
                OnPropertyChanged("StatusString");
            }
        }
        public int? SelectedSalesmanID
        {
            get
            {
                return selectedSalesmanID;
            }
            set
            {
                if (selectedSalesmanID != value)
                {
                    selectedSalesmanID = value;
                    OnPropertyChanged("SelectedSalesmanID");
                }
            }
        }
        public string TandC
        {
            get; set;
        }
        public string CurrencyName
        {
            get
            {
                return currencyName;
            }
            set
            {
                if (currencyName != value)
                {
                    currencyName = value;
                    OnPropertyChanged("CurrencyName");
                }
            }
        }


        public DataGridViewModel SODEntity
        {
            get
            {
                return sqdEntity;
            }
            set
            {
                if (sqdEntity != value)
                {
                    sqdEntity = value;
                    OnPropertyChanged("SODEntity");
                }
            }
        }


        public SalesOrderEntity SalesOrderEntity
        {
            get
            {
                return purchaseOrderEntity;
            }
            set
            {
                if (purchaseOrderEntity != value)
                {
                    purchaseOrderEntity = value;
                    OnPropertyChanged("SalesOrderEntity");
                }
            }
        }

        public decimal? CustomerDiscount
        {
            get { return customerDiscount; }
            set
            {
                customerDiscount = value;
                OnPropertyChanged("CustomerDiscount");
            }
        }


        public ObservableCollection<DataGridViewModel> SODetailsEntity
        {
            get
            {
                return sqDetailsEntity;
            }
            set
            {
                if (sqDetailsEntity != value)
                {
                    sqDetailsEntity = value;
                    OnPropertyChanged("SODetailsEntity");
                }
            }
        }
        //  private ObservableCollection<DataGridViewModel> lstItems = new ObservableCollection<DataGridViewModel>();

        //public ObservableCollection<PandSDetailsModel> ProductAndServices
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
        public ObservableCollection<PandSListModel> ProductAndServices
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
        public decimal? TaxRate
        {
            get
            {
                return taxRate;
            }
            set
            {
                if (taxRate != value)
                {
                    taxRate = value;
                    OnPropertyChanged("TaxRate");
                }
            }
        }
        //added on 23 may 2017
        private bool customerEnabled;
        public bool CustomerEnabled
        {
            get { return customerEnabled; }
            set
            {
                customerEnabled = value;
                OnPropertyChanged("CustomerEnabled");
            }
        }
        public bool AllFieldsEnabled
        {
            get
            {
                return allFieldsEnabled;
            }
            set
            {
                if (allFieldsEnabled != value)
                {
                    allFieldsEnabled = value;
                    OnPropertyChanged("AllFieldsEnabled");
                }
            }
        }

        public bool AllFieldsReadonly
        {
            get
            {
                return allFieldsReadonly;
            }
            set
            {
                if (allFieldsReadonly != value)
                {
                    allFieldsReadonly = value;
                    OnPropertyChanged("AllFieldsReadonly");
                }
            }
        }

        public string DateFormat
        {
            get
            {
                return dateFormat;
            }
            set
            {
                if (dateFormat != value)
                {
                    dateFormat = value;
                    OnPropertyChanged("DateFormat");
                }
            }
        }

        public int DecimalPlaces
        {
            get
            {
                return decimalPlaces;
            }
            set
            {
                if (decimalPlaces != value)
                {
                    decimalPlaces = value;
                    OnPropertyChanged("DecimalPlaces");
                }
            }
        }

        public string SOErrors
        {
            get
            {
                return sqErrros;
            }
            set
            {
                if (sqErrros != value)
                {
                    sqErrros = value;
                    OnPropertyChanged("SOErrors");
                }
            }
        }

        public int SelectedCustomerID
        {
            get
            {
                return customerId;
            }
            set
            {
                if (customerId != value)
                {
                    customerId = value;
                    OnPropertyChanged("SelectedCustomerID");
                }
            }
        }

        public int? DefaultPSID
        {
            get
            {
                return defaultPSID;
            }
            set
            {
                if (defaultPSID != value)
                {
                    defaultPSID = value;
                    OnPropertyChanged("DefaultPSID");
                }
            }
        }

        public bool IsNew
        {
            get
            {
                return isNew;
            }
            set
            {
                isNew = value;
                OnPropertyChanged("IsNew");
            }
        }

        public decimal? AmountBeforeTax
        {
            get
            {
                return amountBeforeTax;
            }
            set
            {
                amountBeforeTax = value;
                OnPropertyChanged("AmountBeforeTax");
            }
        }
        public decimal? TaxAmount
        {
            get
            {
                return taxAmount;
            }
            set
            {
                taxAmount = value;
                OnPropertyChanged("TaxAmount");
            }
        }

        public bool? IsTabkeyStop
        {
            get
            {
                return _disableTab;
            }
            private set
            {
                if (_disableTab != value)
                {
                    _disableTab = value;
                    OnPropertyChanged("DisableTabkey");
                }
            }
        }
        public bool? QtyJumptoNextRow
        {
            get
            {
                return jumptoNextrow;
            }
            private set
            {
                if (jumptoNextrow != value)
                {
                    jumptoNextrow = value;
                    OnPropertyChanged("QtyJumptoNextRow");
                }
            }
        }
        public bool? IsDiscountEditable
        {
            get
            {
                return isDiscountEditable;
            }
            private set
            {
                if (isDiscountEditable != value)
                {
                    isDiscountEditable = value;
                    OnPropertyChanged("IsDiscountEditable");
                }
            }
        }

        public bool? IsHideDiscColumn
        {
            get
            {
                return isHideDiscColumn;
            }
            set
            {
                if (isHideDiscColumn != value)
                {
                    isHideDiscColumn = value;
                    OnPropertyChanged("IsHideDiscColumn");
                }
            }
        }

        public bool? IsPriceEditable
        {
            get
            {
                return isPriceEditable;
            }
            set
            {
                if (isPriceEditable != value)
                {
                    isPriceEditable = value;
                    OnPropertyChanged("IsPriceEditable");
                }
            }
        }

        #endregion

        #region BackGround Worker
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

        private void LoadCustomerBackground(object sender, DoWorkEventArgs e)
        {
            RefreshData();
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

        }



        #endregion

        #region "Constructors"

        //public static SalesOrderViewModel _instance;

        //public static SalesOrderViewModel GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new SalesOrderViewModel();
        //    }

        //    return _instance;
        //}
        //   private static IEnumerable<PandSDetailsModel> ProductList;
        private static IEnumerable<PandSListModel> ProductList;
        private bool? jumptoNextrow;
        private bool? _disableTab;
        
        public SalesOrderViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            :base()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            NavigateToClientCommand = new RelayCommand(NavigatetoCustomer, CanNavigate);
            CloseCommand = new DelegateCommand(Close);
            //sConvertToSOCommand = new RelayCommand(ConvertToSalesOrder, CanConvertToSO);
            ConvertToSICommand = new RelayCommand(ConvertToSalesInvoice, CanConvertToSI);
            SaveCommand = new RelayCommand(SaveSalesOrder, CanSave);
            CustomerSelectionChangedCommand = new RelayCommand(OnCustomerChange);
            NewSOCommand = new RelayCommand(OnNewSO);
            DuplicateCommand = new RelayCommand(OnDuplicateSO, CanDuplicate);
            IncludeTaxCheckedCommand = new RelayCommand(OnIncludeTax);
            ExcludeTaxCheckedCommand = new RelayCommand(OnExcludeTax);
            DeleteCommand = new RelayCommand(OnDeleteSO, CanDeleteSO);
            CollectDepositCommand = new RelayCommand(CollectDeposit, CanSave);
            PrintClickCommand = new RelayCommand(PrintFunction, CanPrint);
            SalesOrderEntity = new SalesOrderEntity();
            SODetailsEntity = new ObservableCollection<DataGridViewModel>();


            int minHeight = 300;
            int headerRows = 339;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 110;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SOFormGridHeight = minHeight;

            #region "Get Customer Details"

            var custList = customerRepository.GetCustomerList();
            if (custList != null)
            {
                LstCustomers = custList.ToList();
            }


            #endregion

            #region getting Options details
            GetOptionsData();
            #endregion

            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            RubberStampSI = false;
            this.OrderDate = DateTime.Now.Date;
            this.DeliveryDate= DateTime.Now.Date;
            LoadCustomerBackground();
            SharedValues.CustomerDiscount = null;
            //ProductList = pandsRepository.GetAllPandS();
            //ProductAndServices = new ObservableCollection<PandSDetailsModel>(ProductList).OrderBy(x => x.PSName).Where(x => x.IsInActive == "N").ToObservable(); ;
            ProductList = pandsRepository.GetPandSComboList();
            ProductAndServices = new ObservableCollection<PandSListModel>(ProductList).OrderBy(x => x.PSName).Where(x => x.IsInActive == "N").ToObservable(); ;
            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {
                    MustCompare = false;
                    CustomerEnabled = false;//added on 23may2017
                    GetSalesOrder(SharedValues.NewClick);
                }
                else if (SharedValues.NewClick == "New")
                {
                    MustCompare = true;
                    CustomerEnabled = true;//added on 23may2017
                    GetNewSO();
                }
            }
            Mouse.OverrideCursor = null;
        }


        #endregion

        #region Relay Commands
        public ICommand CloseCommand { get; set; }
        public RelayCommand ConvertToSOCommand { get; set; }
        public RelayCommand ConvertToSICommand { get; set; }
        public RelayCommand AddNewRowCommand { get; set; }
        public RelayCommand CustomerSelectionChangedCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand SODiscountTextChangedCommand { get; set; }
        public RelayCommand SOQuantityTextChangedCommand { get; set; }
        public RelayCommand NewSOCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand DuplicateCommand { get; set; }
        public RelayCommand IncludeTaxCheckedCommand { get; set; }
        public RelayCommand ExcludeTaxCheckedCommand { get; set; }
        public RelayCommand NavigateToClientCommand { get; set; }
        public RelayCommand CollectDepositCommand { get; set; }
        public RelayCommand PrintClickCommand { get; set; }
        #endregion

        #region "Member Functions"

        public void RefreshData()
        {
            var cat2 = sqRepository.GetAllSalesman("SM".Trim());
            if (cat2 != null)
            {
                this.LstSalesman = cat2;
            }
            #region "To get Category Contents"

            var cat1 = soRepository.GetCategoryContent("SOTC".Trim());

            if (cat1 != null)
            {
                this.TermsAndConditions = Convert.ToString(cat1);
                TandC= Convert.ToString(cat1);
            }
            #endregion
            
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
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        public void CollectDeposit(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                string msg = ValidateSalesOrder();
                if (msg != string.Empty)
                {
                    SOErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                SOErrors = string.Empty;
                SalesOrderForm SOForm = GetDataIntoModel();

                int i = 0;
                if (IsNew == true)
                {
                    i = soRepository.AddUpdateOrder(SOForm);
                }
                else
                {
                    i = soRepository.UpdationOrder(SOForm);
                }
                if (i > 0)
                {
                    //GetNewSO();
                    //string obj = param.ToString();
                    SharedValues.ScreenCheckName = "Payment from Customer";
                    SharedValues.ViewName = "Payment from Customer";
                    var accessitem = listitem.AddToList();
                    if (accessitem == true)
                    { SharedValues.CollectCommand = this.SelectedCustomerID.ToString();
                    SharedValues.NewClick = "New";
                    SharedValues.getValue = "PaymentFromCustomerTab";
                    var mainview = ServiceLocator.Current.GetInstance<PaymentFromCustomersView>();
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
                    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payment From Customer Form");
                    }
                    else
                    {
                        MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
                    }
                }
                Mouse.OverrideCursor = null;
            }
        }
        /// <summary>
        /// This method is used to get new sq
        /// </summary>
        /// <param name="param"></param>
        public void OnNewSO(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            GetNewSO();
            Mouse.OverrideCursor = null;
        }

        /// <summary>
        /// This method is used to get duplicate sq
        /// </summary>
        /// <param name="param"></param>
        public void OnDuplicateSO(object param)
        {
            GetDuplicateSO();
        }

        /// <summary>
        /// This method is used to get taxrate on click on Inc tax radio button
        /// </summary>
        /// <param name="param"></param>
        public void OnIncludeTax(object param)
        {
            ExcIncGST = true;
            var data = pandsRepository.GetTaxes().Where(t => t.IsDefault == true).FirstOrDefault();
            if (data != null)
            {
                TaxRate = data.TaxRate;
            }
            SharedValues.IsIncludeTax = true;
            foreach (var item in SODetailsEntity)
            {
                //item.GSTRate = TaxRate;
                //item.GSTRateStr = Convert.ToString(TaxRate)+"%";
                ////added on 19june2017
                //item.SQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.ProductAndServices.Where(e => e.PSCode == item.PandSCode).Select(e => e.SellPriceIncludingTax).SingleOrDefault()), DecimalPlaces));
                //item.OnQuantityChangeCalculatePrice();
                //item.ExcludingTax = false;
                if (item.SelectedPSID != null)
                {
                    item.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
                    if (SharedValues.IsIncludeTax == true)
                    {
                        item.ExcludingTax = false;
                        item.SQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.PriceIncTax), DecimalPlaces));
                    }
                    else
                    {
                        item.ExcludingTax = false;
                        item.SQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.PriceExcTax), DecimalPlaces));
                    }
                }
            }

            //   SODEntity.GSTRate = TaxRate;

            //CalculateTotal();

        }

        /// <summary>
        /// This method is used to exclude on click on excl tax radio button
        /// </summary>
        /// <param name="param"></param>
        public void OnExcludeTax(object param)
        {
            SharedValues.IsIncludeTax = false;
            foreach (var item in SODetailsEntity)
            {
                //item.GSTRate = TaxRate;
                //item.GSTRateStr = Convert.ToString(TaxRate)+"%";
                ////added on 19june2017
                //item.SQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.ProductAndServices.Where(e => e.PSCode == item.PandSCode).Select(e => e.SellPriceExcludingTax).SingleOrDefault()), DecimalPlaces));
                //item.OnQuantityChangeCalculatePrice();
                //item.ExcludingTax = true;
                if (item.SelectedPSID != null)
                {
                    item.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
                    if (SharedValues.IsIncludeTax == false)
                    {
                        SharedValues.IsIncludeTax = false;
                        item.ExcludingTax = true;
                        item.SQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.PriceExcTax), DecimalPlaces));
                    }
                    else
                    {
                        SharedValues.IsIncludeTax = true;
                        item.ExcludingTax = true;
                        item.SQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.PriceIncTax), DecimalPlaces));

                    }
                }
            }
            //CalculateTotal();
            // SODEntity.GSTRate = 0;
        }

        public bool CanConvertToSO(object param)
        {
            if (IsNew == true)
            {
                return false;
            }
            else
            {
                if (this.SO_Conv_to_SO == true || this.SO_Conv_to_SI == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public bool CanNavigate(object param)
        {
            if (SelectedCustomerID != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CanConvertToSI(object param)
        {
            if (IsNew == true)
            {
                return false;
            }
            else
            {
                if (this.SO_Conv_to_SI == true)
                {
                    return false;
                }
                else if (Status == Convert.ToByte(PO_Status.Cancelled))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //public void ConvertToSalesOrder(object param)
        //{
        //    if (this.SO_Conv_to_SO == false || this.SO_Conv_to_SO == null)
        //    {
        //        Mouse.OverrideCursor = Cursors.Wait;
        //        SalesOrderForm SOForm = GetDataIntoModel();
        //        int i = soRepository.ConvertToSalesOrder(SOForm);
        //        if (i > 0)
        //        {
        //            this.SO_Conv_to_SO = true;
        //        }
        //        Mouse.OverrideCursor = null;
        //    }
        //    else
        //    {
        //        SOErrors = "Already converted to Sales Order";
        //    }
        //}

        public void ConvertToSalesInvoice(object param)
        {
            if (this.SO_Conv_to_SI == false || this.SO_Conv_to_SI == null)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                SalesOrderForm SOForm = GetDataIntoModel();
                int i = soRepository.ConvertToSalesInvoice(SOForm);
                if (i > 0)
                {
                    this.SO_Conv_to_SI = true;
                    AllFieldsReadonly = true;
                    RubberStampSI = false;
                    AllFieldsEnabled = false;
                    CustomerEnabled = false;// added on 23 may 2017
                }
                Mouse.OverrideCursor = null;
            }
            else
            {
                SOErrors = "Already converted to Sales Invoice";
            }
        }

        /// <summary>
        /// This method is used to save and edit sq
        /// </summary>
        /// <param name="param"></param>
        public void SaveSalesOrder(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                string msg = ValidateSalesOrder();
                if (msg != string.Empty)
                {
                    SOErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                SOErrors = string.Empty;
                SalesOrderForm SOForm = GetDataIntoModel();

                int i = 0;
                if (IsNew == true)
                {
                    i = soRepository.AddUpdateOrder(SOForm);
                }
                else
                {
                    i = soRepository.UpdationOrder(SOForm);
                }
                if (i > 0)
                {
                    //GetNewSO();
                    CustomerEnabled = false;
                    IsNew = false;// added on 23 may 2017
                }
                Mouse.OverrideCursor = null;
            }
        }

        public bool CanSave(object param)
        {
            string date = this.DateFormat as string;
            var c = CompanyD.GetCompanyDetails().Comp_year_start_date;
            if (SelectedCustomerID == 0 && OrderDateStr == null
                || SODetailsEntity.Count() == 0)
            {
                return false;
            }
            else
            {
                if (IsNew == false)
                {
                    if (SO_Conv_to_SI == true)
                    {
                        return false;
                    }
                    else if (Status == Convert.ToByte(PO_Status.Collected))
                    {
                        return false;
                    }
                    else if (Status == Convert.ToByte(PO_Status.Cancelled))
                    {
                        return false;
                    }
                    else if (Status == Convert.ToByte(PO_Status.Refunded))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                if (OrderDateStr != null && DeliveryDateStr != null)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(OrderDateStr) && !string.IsNullOrWhiteSpace(OrderDateStr) && !string.IsNullOrEmpty(DeliveryDateStr) && !string.IsNullOrWhiteSpace(DeliveryDateStr))
                        {

                            //item.StartDate = item.StartDate.Replace('.', '/');
                            //item.StartDate = item.StartDate.Replace('-', '/');
                            //item.EndDate = item.EndDate.Replace('.', '/');
                            //item.EndDate = item.EndDate.Replace('-', '/');
                            var orderStart = (DateTime.ParseExact(OrderDateStr, date, CultureInfo.InvariantCulture));
                            var deliveryStart = (DateTime.ParseExact(DeliveryDateStr, date, CultureInfo.InvariantCulture));
                            this.DateErrors = "";
                            //var End = (DateTime.ParseExact(item.EndDate, date, CultureInfo.InvariantCulture));
                            if (orderStart < c || deliveryStart < c)
                            {
                                this.DateErrors = "Date should be greater than Start Financial year";
                                return false;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        this.DateErrors = "Please enter the date in " + date + " format!";
                        return false;
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool CanDuplicate(object param)
        {
            if (IsNew == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanDeleteSO(object param)
        {
            if (this.SO_Conv_to_SI == true)
            {
                return false;
            }
            else if (IsNew == true)
            {
                return false;
            }
            else if (Status == Convert.ToByte(PO_Status.Collected))
            {
                return false;
            }
            else if (Status == Convert.ToByte(PO_Status.Cancelled))
            {
                return false;
            }
            else if (Status == Convert.ToByte(PO_Status.Refunded))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// This method is used to delete SO
        /// </summary>
        /// <param name="param"></param>
        public void OnDeleteSO(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete?\n"+"@ Simple Accounting Software Pte Ltd", "Delete Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                if (soRepository.CanDeleteOrder(ID))
                {
                    soRepository.DeleteOrder(ID);
                    SOErrors = string.Empty;
                    OnNewSO(null);
                }
                else
                {
                    SOErrors = "Cannot delete Sales Order";
                }
                Mouse.OverrideCursor = null;
            }
        }


        /// <summary>
        /// This method is used to get customer details on selection
        /// </summary>
        /// <param name="param"></param>
        public void OnCustomerChange(object param)
        {
            GetCustomerDetails();
        }

        public SalesOrderForm GetDataIntoModel()
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            SalesOrderForm SOForm = new SalesOrderForm();
            SOForm.OrderDetails = new List<SalesOrderDetailEntity>();
            SalesOrderEntity model = new SalesOrderEntity();
            model.OrderNo = this.OrderNo;
            model.OrderDate = DateTime.ParseExact(this.OrderDateStr,oData.DateFormat,null);
            model.Cus_Po_No = this.Cus_Po_No;
            model.TotalBeforeTax = this.TotalBeforeTax;
            model.TotalTax = this.TotalTax;
            model.TotalAfterTax = this.TotalAfterTax;
            model.ValidForDays = this.ValidForDays;
            model.CustomerID = this.SelectedCustomerID;
            model.SalesmanID = this.SelectedSalesmanID;
            model.DeliveryDate = DateTime.ParseExact(this.DeliveryDateStr, oData.DateFormat, null);
           
            model.TermsAndConditions = this.TermsAndConditions;
            if (ExcludingTax == true)
            {
                model.ExcIncGST = false;
            }
            else
            {
                model.ExcIncGST = true;
            }

            SOForm.Order = model;

            foreach (var item in SODetailsEntity)
            {
                SalesOrderDetailEntity sqEntity = new SalesOrderDetailEntity();
                sqEntity.SONo = Convert.ToString(item.SelectedPSID);
                sqEntity.PandSCode = item.PandSCode;
                sqEntity.PandSName = item.PandSName;
                sqEntity.SOQty = item.SQQty;
                sqEntity.SOPrice = item.SQPrice;
                sqEntity.SODiscount = item.SQDiscount;
                sqEntity.GSTRate = item.GSTRate;
                sqEntity.GSTRateStr = Convert.ToString(item.GSTRate)+"%";
                sqEntity.SOAmount = item.SQAmount;
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID) > 0)
                {
                    SOForm.OrderDetails.Add(sqEntity);
                }
            }
            return SOForm;
        }

        /// <summary>
        /// This method is used to calculate total amount of PandS with tax
        /// </summary>
        //public void CalculateTotal()
        //{
        //    if (SODetailsEntity != null)
        //    {
        //        TotalBeforeTax = SODetailsEntity.Sum(e => e.AmountBeforeTax);
        //        TotalBeforeTax = Math.Round(Convert.ToDecimal(TotalBeforeTax), DecimalPlaces);
        //        TotalTax = SODetailsEntity.Sum(e => e.TaxAmount);
        //        TotalTax = Math.Round(Convert.ToDecimal(TotalTax), DecimalPlaces);
        //        TotalAfterTax = SODetailsEntity.Sum(e => e.SQAmount);
        //        TotalAfterTax = Math.Round(Convert.ToDecimal(TotalAfterTax), DecimalPlaces);

        //        TotalBeforeTaxStr = Convert.ToString(TotalBeforeTax);
        //        TotalTaxStr = Convert.ToString(TotalTax);
        //        TotalAfterTaxStr = Convert.ToString(TotalAfterTax);
        //    }
        //}
        /// <summary>
        /// This method is used to calculate total amount of PandS with tax
        /// </summary>
        public void CalculateTotal(bool excludeTax)
         {
            decimal? totalBeforeTax = 0;
            decimal? mTotalTax = 0;
            decimal? mTotalAfterTax = 0;
            if (SODetailsEntity != null)
            {
                totalBeforeTax = SODetailsEntity.Sum(e => e.AmountBeforeTax);
                TotalBeforeTax = Math.Round(Convert.ToDecimal(totalBeforeTax), DecimalPlaces);
                mTotalTax = SODetailsEntity.Sum(e => e.TaxAmount);
                
                TotalTax = Math.Round(Convert.ToDecimal(mTotalTax), DecimalPlaces);

                mTotalAfterTax = totalBeforeTax + mTotalTax;
                TotalAfterTax = Math.Round(Convert.ToDecimal(mTotalAfterTax), DecimalPlaces);
                TotalBeforeTaxStr = Convert.ToString(TotalBeforeTax);
                TotalTaxStr = Convert.ToString(TotalTax);
                TotalAfterTaxStr = Convert.ToString(TotalAfterTax);
            }
        }


        /// <summary>
        /// This method is used to get customer details
        /// </summary>
        private void GetCustomerDetails()
        {
            //var sup = customerRepository.GetAllCustomers().Where(s => s.CustomerID == SelectedCustomerID).SingleOrDefault();
            //if (sup != null)
            //{
            //    //this.BillToAddress = sup.a + " " + sup.ShipAddressLine2 + " " + sup.ShipCity;
            //    //this.ShipToAddress = sup.Sup_Bill_to_line1 + " " + sup.Sup_Bill_to_line2 + " " + sup.Sup_Bill_to_city;

            //}
            //added on 19June2017
            string str = string.Empty;
            SharedValues.SelectedCusId = SelectedCustomerID;
            var sup = customerRepository.GetCustomerList().Where(s => s.CustomerID == SelectedCustomerID).SingleOrDefault();
            if (sup != null)
            {
                if (sup.Cus_BalanceStr != null)
                {
                    Cus_Balance = sup.Cus_BalanceStr;
                }
                else
                {
                    Cus_Balance = string.Empty;
                }
                if(sup.CusCreditLimitAmountStr!=null)
                {
                    Cus_CreditLimitAmount = sup.CusCreditLimitAmountStr;
                }
                else
                {
                    Cus_CreditLimitAmount = string.Empty;
                }

                //getting all the discounts from CategoryContent
                var lst = sqRepository.GetAllSalesman("CD");
                if (lst != null)
                {
                    str = lst.Where(e => e.ContentID == sup.Discount).Select(e => e.ContentName).SingleOrDefault();
                }


                foreach (var item in SODetailsEntity)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        CustomerDiscount = Convert.ToDecimal(str);
                    }
                    else
                    {
                        CustomerDiscount = 0;
                    }
                    if (item.SelectedPSID != null)
                    {
                        item.SQDiscount = CustomerDiscount;
                    }
                    SharedValues.CustomerDiscount = CustomerDiscount;
                }//end
                if (IsNew == true)
                {
                    if (sup.SalesmanID != 0)
                    {
                        var salesman = LstSalesman.Where(e => e.ContentID == sup.SalesmanID).FirstOrDefault();
                        if (salesman != null)
                        {
                            SelectedSalesmanID = sup.SalesmanID;
                        }
                    //    else
                    //    {
                    //        SelectedSalesmanID = 1;
                    //    }
                    }
                    //else
                    //{
                    //    SelectedSalesmanID = 1;
                    //}
                }
                else
                {
                    if (SelectedSalesmanID != null)
                    {
                        var salesman = LstSalesman.Where(e => e.ContentID == SelectedSalesmanID).FirstOrDefault();
                        if (salesman != null)
                        {
                            SelectedSalesmanID = salesman.ContentID;
                        }
                        //else
                        //{
                        //    SelectedSalesmanID = 1;
                        //}
                    }
                    //else
                    //{
                    //    SelectedSalesmanID = 1;
                    //}
                }
                //this.BillToAddress = sup.a + " " + sup.ShipAddressLine2 + " " + sup.ShipCity;
                //this.ShipToAddress = sup.Sup_Bill_to_line1 + " " + sup.Sup_Bill_to_line2 + " " + sup.Sup_Bill_to_city;
            }
        }


        private string GenerateNewOrderNo()
        {
            var NewPqNo = soRepository.GetLatestOrderNo();
            return "SO-" + NewPqNo.ToString();
        }

        public int ManageDuplicatePandS()
        {
            int rowFocusindex = -1;
            lst = new ObservableCollection<DataGridViewModel>();
            lst = SODetailsEntity;

            var query = lst.GroupBy(x => x.SelectedPSID)
              .Where(g => g.Count() > 1)
              .ToList();
            if (query.Count > 0 && SODetailsEntity.Count > 1)
            {

                var obj1 = query[0].ElementAt(0);
                var obj2 = query[0].ElementAt(1);
                int? qty = 1;
                decimal? productPrice2 = 0;
                decimal? discountP2 = 0;
                qty = query[0].ElementAt(0).SQQty + query[0].ElementAt(1).SQQty;
                productPrice2 = Convert.ToDecimal(query[0].ElementAt(1).SQPrice);
                discountP2 = query[0].ElementAt(1).SQDiscount;

                var index1 = lst.IndexOf(query[0].ElementAt(0));
                var index2 = lst.IndexOf(query[0].ElementAt(1));

                if (productPrice2 != null)
                {
                    obj1.SQQty = qty;
                    obj1.SQPrice = Convert.ToString(productPrice2);
                    obj1.SQDiscount = discountP2;
                    // SODetailsEntity[index1] = obj1;
                    var row = new DataGridViewModel(ProductList);
                    //row.SQQty = 1;
                    //row.GSTRate = TaxRate;
                    //row.GSTRateStr = Convert.ToString(TaxRate)+"%";
                    //if (CustomerDiscount != null)
                    //{
                    //    row.SQDiscount = CustomerDiscount;
                    //}
                    //else
                    //{
                    //    row.SQDiscount = 0;
                    //}
                    if (IsDiscountEditable == true)
                    {
                        row.IsAllowEditDiscount = true;
                    }
                    else
                    {
                        row.IsAllowEditDiscount = false;
                    }
                    if (IsPriceEditable == true)
                    {
                        row.IsAllowEditPrice = true;
                    }
                    else
                    {
                        row.IsAllowEditPrice = false;
                    }
                    if (IsHideDiscColumn == true)
                    {
                        row.IsHideDisc = false;
                    }
                    else
                    {
                        row.IsHideDisc = true;
                    }
                    SODetailsEntity[index2] = row;
                    rowFocusindex = index2;
                }
                //for (int i = 0; i < 2; i++)
                //{ 
                //    var p = SODetailsEntity.Where(e => e.SelectedPSID == obj2.SelectedPSID ).FirstOrDefault();
                //    if (p.SOPrice == null)
                //    {
                //        SODetailsEntity.Remove(p);
                //    }
                //}

                OnPropertyChanged("SODetailsEntity");

            }
            else
            {
                int count = SODetailsEntity.Count(x => x.SelectedPSID == null);
                if (count == 0)
                {
                    var row = new DataGridViewModel(ProductList);
                    //row.SQQty = 1;
                    //row.GSTRate = TaxRate;//added by 19june2017
                    //row.GSTRateStr = Convert.ToString(TaxRate)+"%";//added by 19june2017
                    //added on 19June2017
                    //if (CustomerDiscount != null)
                    //{
                    //    row.SQDiscount = CustomerDiscount;
                    //}
                    //else
                    //{
                    //    row.SQDiscount = 0;
                    //}//end
                    if (IsDiscountEditable == true)
                    {
                        row.IsAllowEditDiscount = true;
                    }
                    else
                    {
                        row.IsAllowEditDiscount = false;
                    }
                    if (IsPriceEditable == true)
                    {
                        row.IsAllowEditPrice = true;
                    }
                    else
                    {
                        row.IsAllowEditPrice = false;
                    }
                    if (IsHideDiscColumn == true)
                    {
                        row.IsHideDisc = false;
                    }
                    else
                    {
                        row.IsHideDisc = true;
                    }
                    SODetailsEntity.Add(row);
                    OnPropertyChanged("SODetailsEntity");
                    rowFocusindex = -1;
                }
                else
                {
                    var emptyRow = lst.Where(y => y.SelectedPSID == null).FirstOrDefault();
                    rowFocusindex = SODetailsEntity.IndexOf(emptyRow);
                }


            }

            return rowFocusindex;
        }

        public void GetSalesOrder(string sqNo)
        {
            // Mouse.OverrideCursor = Cursors.Wait;
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            SalesOrderForm sqf = soRepository.GetSalesOrder(sqNo);

            this.ID = sqf.Order.ID;
            this.OrderNo = sqf.Order.OrderNo;
            this.Cus_Po_No = sqf.Order.Cus_Po_No;
            this.OrderDateStr = sqf.Order.OrderDate.ToString(oData.DateFormat);
            this.ValidForDays = sqf.Order.ValidForDays;
            this.SelectedCustomerID = sqf.Order.CustomerID;
            SharedValues.SelectedCusId = this.SelectedCustomerID;
            if (sqf.Order.SalesmanID != null)
            {
                this.SelectedSalesmanID = sqf.Order.SalesmanID;
            }
            if (this.SelectedCustomerID > 0)
            {
                GetCustomerDetails();
            }

            this.DeliveryDateStr = sqf.Order.DeliveryDate.ToString(oData.DateFormat);
            this.TermsAndConditions = sqf.Order.TermsAndConditions;

            this.TotalBeforeTax = sqf.Order.TotalBeforeTax;
            this.TotalTax = sqf.Order.TotalTax;
            this.TotalAfterTax = sqf.Order.TotalAfterTax;
            this.TotalBeforeTaxStr = Convert.ToString(this.TotalBeforeTax);
            this.TotalTaxStr = Convert.ToString(TotalTax);
            this.TotalAfterTaxStr = Convert.ToString(TotalAfterTax);
            this.SO_Conv_to_SO = sqf.Order.SO_Conv_to_SO;
            this.SO_Conv_to_SI = sqf.Order.SO_Conv_to_SI;

            if (SO_Conv_to_SO == true )
            {
                AllFieldsReadonly = true;
                AllFieldsEnabled = false;
                //sqf.OrderDetails = sqf.OrderDetails.OrderBy(x=>x.PandSName).Where
            }
            if (SO_Conv_to_SI == true)
            {
                AllFieldsReadonly = true;
                RubberStampSI = true;
                AllFieldsEnabled = false;
            }
            else
            {
                AllFieldsReadonly = false;
                AllFieldsEnabled = true;
                ProductAndServices = ProductAndServices.OrderBy(x => x.PSName).Where(x => x.IsInActive != "Y").ToObservable();
                LstCustomers = LstCustomers.OrderBy(x => x.Name).Where(x => x.Inactive != "Y").ToList();
            }


            this.Status = sqf.Order.Status;
            if (Status == Convert.ToByte(PO_Status.Cancelled))
            {
                StatusString = "Cancelled";
                VisibilityForImage = Visibility.Visible;
                AllFieldsEnabled = false;
                AllFieldsReadonly = true;

            }
            else if (Status == Convert.ToByte(PO_Status.Collected))
            {
                StatusString = "Collected";
                VisibilityForImage = Visibility.Visible;
                AllFieldsEnabled = false;
                AllFieldsReadonly = true;

            }
            else if (Status == Convert.ToByte(PO_Status.Refunded))
            {
                StatusString = "Refunded";
                VisibilityForImage = Visibility.Visible;
                AllFieldsEnabled = false;
                AllFieldsReadonly = true;

            }
            else
            {
                StatusString = "";
                VisibilityForImage = Visibility.Collapsed;
                AllFieldsEnabled = true;
                AllFieldsReadonly = false;

            }

            if (sqf.Order.ExcIncGST == true)
            {
                ExcludingTax = false;
                IncludingTax = true;
                //  SODEntity.GSTRate = 0;
            }
            else
            {
                ExcludingTax = true;
                IncludingTax = false;
                // SODEntity.GSTRate = TaxRate;
            }

            CustomerEnabled = false;// added on 23 may 2017

            this.SODetailsEntity = new ObservableCollection<DataGridViewModel>();
            foreach (var item in sqf.OrderDetails)
            {
                DataGridViewModel sqEntity = new DataGridViewModel(ProductList);
                sqEntity.SelectedPSID = Convert.ToString(item.SONo);
                sqEntity.PandSCode = item.PandSCode;
                sqEntity.PandSName = item.PandSName;
                sqEntity.GSTRate = item.GSTRate;
                sqEntity.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
                sqEntity.SQQty = item.SOQty;
                sqEntity.SQPrice = Convert.ToString(item.Price);
                sqEntity.SQDiscount = item.SODiscount;
                if (IsDiscountEditable == true)
                {
                    sqEntity.IsAllowEditDiscount = true;
                }
                else
                {
                    sqEntity.IsAllowEditDiscount = false;
                }
                if (IsPriceEditable == true)
                {
                    sqEntity.IsAllowEditPrice = true;
                }
                else
                {
                    sqEntity.IsAllowEditPrice = false;
                }
                if (IsHideDiscColumn == true)
                {
                    sqEntity.IsHideDisc = false;
                }
                else
                {
                    sqEntity.IsHideDisc = true;
                }
                //  SODEntity.GSTRate = item.GSTRate;
                sqEntity.SQAmount = item.SOAmount;

                SODetailsEntity.Add(sqEntity);
            }

        }
        public void PrintFunction(object param)
        {
            var QuotationNumber = param.ToString();
            SharedValues.Print_Id = QuotationNumber;
            ///PrintSalesQuotation();
            //after calling the mwthod
            var mainview = ServiceLocator.Current.GetInstance<SalesOrderReport>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
        }
        public bool CanPrint(object param)
        {
            if (IsNew == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public SalesOrderForm PrintSalesOrder()
        {
            // Mouse.OverrideCursor = Cursors.Wait;
            var sqRepository = new SalesOrderRepository();
            var sqNo = SharedValues.Print_Id;
            var sqf = sqRepository.GetPrintSalesOrder(sqNo);
            //  var qf = sqRepository.GetSalesQuotation(sqNo);

            ////  DataTable dt = new DataTable();
            //  DataTable dt = LINQResultToDataTable(qf);
            //  dt = (DataTable)sqf;
            return sqf;
        }

        /// <summary>
        /// This method is used to validate purchase quotation on Save
        /// </summary>
        /// <returns></returns>
        public string ValidateSalesOrder()
        {
            bool isValidData = false;
            string msg = string.Empty;
            if (SelectedCustomerID == 0)
            {
                return msg = "Please select Customer Name";
            }
            if (OrderDateStr == null)
            {
                return msg = "Please enter Order Date";
            }
            if (SODetailsEntity.Count <= 0)
            {
                return msg = "Please add Products and Services";
            }

            foreach (var item in SODetailsEntity)
            {
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID) > 0)
                {
                    if (item.SQQty <= 0 && item.SelectedPSID != null)
                    {
                        return msg = "Quantity should be greater than zero";
                    }
                    if (item.SQDiscount != null)
                    {
                        if (!(item.SQDiscount >= 0 && item.SQDiscount <= 100))
                        {
                            return msg = "Discount should be between 0 to 100";
                        }
                    }

                    if (!string.IsNullOrEmpty(item.SQPrice))
                    {
                        if (Convert.ToDecimal(item.SQPrice) <= 0)
                        {
                            return msg = "Price should be greater than zero";
                        }
                    }
                    else
                    {
                        return msg = "Please enter valid price";
                    }
                    //if (!System.Text.RegularExpressions.Regex.IsMatch(taxModel.TaxRate.ToString(), @"^\d+([.]\d{1,2})?%?$"))
                    //{
                    //    msg.Append("Enter valid Tax Rate.\n");
                    //}

                    //if (System.Text.RegularExpressions.Regex.IsMatch(item.SOPrice.Trim(), @"[^0-9]"))
                    //{
                    //    return msg = "Please enter valid price";
                    //}
                    if (item.SQQty > 0 && item.SelectedPSID != null && Convert.ToDecimal(item.SQPrice) >= 0)
                    {
                        isValidData = true;
                    }
                }
            }
            if (isValidData == false)
            {
                msg = "Please add valid product and services";
            }
            return msg;
        }


        /// <summary>
        /// This method is used to get new SO
        /// </summary>
        public void GetNewSO()
        {
            VisibilityForImage = Visibility.Collapsed;
            IsNew = true;
            ID = 0;
            SelectedCustomerID = 0;
            SelectedSalesmanID = 0;
            BillToAddress = string.Empty;
            ShipToAddress = string.Empty;
            ValidForDays = 0;
            OrderNo = GenerateNewOrderNo();
            TermsAndConditions = TandC;
            DeliveryDate = DateTime.Now.Date;
            OrderDate = DateTime.Now.Date;
            TotalBeforeTax = 0;
            TotalTax = 0;
            TotalAfterTax = 0;
            TotalBeforeTaxStr = Convert.ToString(0);
            TotalTaxStr = Convert.ToString(0);
            TotalAfterTaxStr = Convert.ToString(0);
            SOErrors = string.Empty;
            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            RubberStampSI = false;
            CustomerEnabled = true;// added on 23 may 2017
            SharedValues.CustomerDiscount = null;
            SalesOrderEntity = new SalesOrderEntity();
            SODetailsEntity.Clear();
            // SODetailsEntity = new ObservableCollection<DataGridViewModel>();
            ProductAndServices = ProductAndServices.OrderBy(x=>x.PSName).Where(x => x.IsInActive != "Y").ToObservable();
            LstCustomers = LstCustomers.OrderBy(x=>x.FirstName).Where(x => x.Inactive != "Y").ToList();
            var row = new DataGridViewModel(ProductList);
            
            //row.SQQty = 1;
            //row.SQDiscount = 0;


            if (IsDiscountEditable == true)
            {
                row.IsAllowEditDiscount = true;
            }
            else
            {
                row.IsAllowEditDiscount = false;
            }
            if (IsPriceEditable == true)
            {
                row.IsAllowEditPrice = true;
            }
            else
            {
                row.IsAllowEditPrice = false;
            }
            if (IsHideDiscColumn == true)
            {
                row.IsHideDisc = false;
            }
            else
            {
                row.IsHideDisc = true;
            }
            var lstOptions = pandsRepository.GetOptionDetails();
            bool? tax = lstOptions.ShowAmountIncGST;
            if (tax == true)
            {
                ExcludingTax = false;
                IncludingTax = true;
            }
            else
            {
                IncludingTax = false;
                ExcludingTax = true;
            }
            //row.GSTRate = TaxRate;
            //row.GSTRateStr= Convert.ToString(TaxRate)+"%";
            SODetailsEntity.Add(row);
            OnPropertyChanged("SODetailsEntity");

        }
        public override void OnPropertyChanged(string name)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(name));
            }
            switch (name)
            {
                case "OrderDateCalender":
                    FillStartDate();
                    break;
                case "DeliveryDateCalender":
                    FillStartDate2();
                    break;

            }

            base.OnPropertyChanged(name);
        }
        void FillStartDate()
        {
            string date = this.DateFormat as string;
            OrderDateStr = Convert.ToDateTime(this.OrderDateCalender).ToString(date);
        }
        void FillStartDate2()
        {
            string date = this.DateFormat as string;
            DeliveryDateStr = Convert.ToDateTime(this.DeliveryDateCalender).ToString(date);
        }
        private void GetOptionsData()
        { //[TermsAndConditions]
            //var cat1 = pandsRepository.GetCategoryContent("PTC".Trim()); ;
            //if (cat1 != null)
            //{
            //    LstTermsAndConditions = cat1.ToList();
            //}
            var lstOptions = pandsRepository.GetOptionDetails();

            if (lstOptions != null)
            {
                if (lstOptions.DecimalPlaces > 0)
                {
                    DecimalPlaces = lstOptions.DecimalPlaces;
                }
                else
                {
                    DecimalPlaces = 4;
                }
                if (lstOptions.AllowEditDiscount != null)
                {
                    if (lstOptions.AllowEditDiscount == true)
                    {
                        IsDiscountEditable = true;
                    }
                    else
                    {
                        IsDiscountEditable = false;
                    }
                }
                if (lstOptions.HideDiscColumn != null)
                {
                    if (lstOptions.HideDiscColumn == true)
                    {
                        IsHideDiscColumn = true;
                    }
                    else
                    {
                        IsHideDiscColumn = false;
                    }
                }
                if (lstOptions.AllowEditPSPrice != null)
                {
                    if (lstOptions.AllowEditPSPrice == true)
                    {
                        IsPriceEditable = true;
                    }
                    else
                    {
                        IsPriceEditable = false;
                    }
                }
                if (lstOptions.PSQtyJumNextLine != null)
                {
                    QtyJumptoNextRow = lstOptions.PSQtyJumNextLine;
                    if (lstOptions.PSQtyJumNextLine == true)
                    {
                        IsTabkeyStop = true;

                    }
                    else
                    {
                        IsTabkeyStop = false;
                    }
                }
                else
                {
                    QtyJumptoNextRow = false;
                    IsTabkeyStop = false;
                }
                if (lstOptions.DateFormat != null)
                {
                    DateFormat = lstOptions.DateFormat;
                }
                else
                {
                    DateFormat = "mm/dd/yy";
                }

                CurrencyName = lstOptions.CurrencyCode;
                bool? tax = lstOptions.ShowAmountIncGST;
                if (tax == true)
                {
                    ExcludingTax = false;
                    IncludingTax = true;
                    SharedValues.IsIncludeTax = true;
                }
                else
                {
                    IncludingTax = false;
                    ExcludingTax = true;
                    SharedValues.IsIncludeTax = false;
                }

                var data = pandsRepository.GetTaxes().Where(t => t.IsDefault == true).FirstOrDefault();
                if (data != null)
                {
                    TaxName = data.TaxName;
                    TaxRate = data.TaxRate;
                }
                else
                {
                    TaxName = "GST";
                    TaxRate = 0;
                }
            }
        }

        /// <summary>
        /// This method is used to get duplicate sq
        /// </summary>
        public void GetDuplicateSO()
        {
            VisibilityForImage = Visibility.Collapsed;
            IsNew = true;
            SOErrors = string.Empty;
            OrderNo = GenerateNewOrderNo();
            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            RubberStampSI = false;
            CustomerEnabled = true;// added on 23 may 2017
        }

        #endregion
    }
}
