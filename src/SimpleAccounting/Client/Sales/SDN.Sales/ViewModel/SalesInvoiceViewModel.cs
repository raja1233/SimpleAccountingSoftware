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
    using Product.Services;
    using SDN.UI.Entities.Sales;
    using Services;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using UI.Entities;
    using Views;

    public class SalesInvoiceViewModel: SalesInvoiceEntity
    {
        #region "Private members"

        //private ObservableCollection<PandSDetailsModel> pands;
        private string currencyName;
        //  private string taxName;
        private ObservableCollection<DataGridViewModel> sqDetailsEntity;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private ISalesQuotationRepository squRepository = new SalesQuotationRepository();
        private ISalesInvoiceRepository sqRepository = new SalesInvoiceRepository();
        public IPandSDetailsRepository pandsRepository = new PandSDetailsRepository();
        private ICustomerRepository customerRepository = new CustomerRepository();
        public ObservableCollection<DataGridViewModel> lst;
        private DataGridViewModel sqdEntity;
        private SalesInvoiceEntity salesInvoiceEntity;
        //private SalesInvoiceDetailEntity selectedPandS;

        private int customerId;

        private decimal? taxRate;
       // private ObservableCollection<PandSDetailsModel> productAndServices;
        private ObservableCollection<PandSListModel> productAndServices;
        //private int? sqQty;
        //private decimal? sqPrice;
        //private decimal? sqAmount;
        //private decimal? sqDiscount;
        //private decimal? gstRate;
        private int? defaultPSID;
        private int? selectedSalemanID;
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
        private string startingSINo;
        private decimal? customerDiscount;//added on 19June2017
        private decimal? creditLimitAmount;//added on 22June2017
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
        public string StatusString
        {
            get { return statusString; }
            set
            {
                statusString = value;
                OnPropertyChanged("StatusString");
            }
        }

        //added on 22june2017
        public decimal? CreditLimitAmount
        {
            get { return creditLimitAmount;
            }
            set { creditLimitAmount = value;
                OnPropertyChanged("CreditLimitAmount");
            }
        }


        //added on 19June2017
        public decimal? CustomerDiscount
        {
            get { return customerDiscount; }
            set
            {
                customerDiscount = value;
                OnPropertyChanged("CustomerDiscount");
            }
        }//end
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
        public string TandC
        {
            get; set;
        }
        public string StartingSINo
        {
            get
            {
                return startingSINo;
            }
            set
            {
                startingSINo = value;
                OnPropertyChanged("StartingSINo");
            }
        }
        public DataGridViewModel SQDEntity
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
                    OnPropertyChanged("SQDEntity");
                }
            }
        }


        public SalesInvoiceEntity SalesInvoiceEntity
        {
            get
            {
                return salesInvoiceEntity;
            }
            set
            {
                if (salesInvoiceEntity != value)
                {
                    salesInvoiceEntity = value;
                    OnPropertyChanged("SalesInvoiceEntity");
                }
            }
        }
        
        public ObservableCollection<DataGridViewModel> SQDetailsEntity
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
                    OnPropertyChanged("SQDetailsEntity");
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

        public string SQErrors
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
                    OnPropertyChanged("SQErrors");
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

        public int? SelectedSalesmanID
        {
            get { return selectedSalemanID; }
            set { selectedSalemanID = value;
                OnPropertyChanged("SelectedSalemanID");
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

        //public static SalesInvoiceViewModel _instance;

        //public static SalesInvoiceViewModel GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new SalesInvoiceViewModel();
        //    }

        //    return _instance;
        //}
       // private static IEnumerable<PandSDetailsModel> ProductList;
        private static IEnumerable<PandSListModel> ProductList;
        private bool? jumptoNextrow;
        private bool? _disableTab;

        public SalesInvoiceViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;

            SaveCommand = new RelayCommand(SaveSalesInvoice, CanSave);
            CustomerSelectionChangedCommand = new RelayCommand(OnCustomerChange);
            NewSQCommand = new RelayCommand(OnNewSQ);
            DuplicateCommand = new RelayCommand(OnDuplicateSQ, CanDuplicate);
            IncludeTaxCheckedCommand = new RelayCommand(OnIncludeTax);
            ExcludeTaxCheckedCommand = new RelayCommand(OnExcludeTax);
            DeleteCommand = new RelayCommand(OnDeleteSQ, CanDeleteSQ);
            NavigateToClientCommand = new RelayCommand(NavigatetoCustomer,CanNavigate);
            PaymentToCustomerCommand = new RelayCommand(OnPaymentToCustomer, CanPaymentToCustomer);
            SalesInvoiceEntity = new SalesInvoiceEntity();
            SQDetailsEntity = new ObservableCollection<DataGridViewModel>();


               int minHeight = 300;
            int headerRows = 339;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows-108;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SIFormGridHeight = minHeight;
            SharedValues.CustomerDiscount = null;

            #region "Get Customer Details"

            var customers = customerRepository.GetAllCustomers();
            if (customers != null)
            {
                LstCustomers = customers.ToList();
            }

            var cat2 = squRepository.GetAllSalesman("SM".Trim());

            if (cat2 != null)
            {
                this.LstSalesman = cat2;
            }
            #endregion

            #region getting Options details
            GetOptionsData();
            #endregion

            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            this.InvoiceDate = DateTime.Now.Date;

            LoadCustomerBackground();

            //ProductList = pandsRepository.GetAllPandS();            
            //ProductAndServices = new ObservableCollection<PandSDetailsModel>(ProductList);
            ProductList = pandsRepository.GetPandSComboList();
            ProductAndServices = new ObservableCollection<PandSListModel>(ProductList);
            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {
                    CustomerEnabled = false;//added on 23may2017
                    GetSalesInvoice(SharedValues.NewClick);
                }
                else if (SharedValues.NewClick == "New")
                {
                    CustomerEnabled = true;//added on 23may2017
                    GetNewSQ();
                }
            }
            Mouse.OverrideCursor = null;

        }


        #endregion

        #region Relay Commands

        public RelayCommand ConvertToPOCommand { get; set; }
        public RelayCommand ConvertToSICommand { get; set; }
        public RelayCommand AddNewRowCommand { get; set; }
        public RelayCommand CustomerSelectionChangedCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand SQDiscountTextChangedCommand { get; set; }
        public RelayCommand SQQuantityTextChangedCommand { get; set; }
        public RelayCommand NewSQCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand DuplicateCommand { get; set; }
        public RelayCommand IncludeTaxCheckedCommand { get; set; }
        public RelayCommand ExcludeTaxCheckedCommand { get; set; }
        public RelayCommand NavigateToClientCommand { get; set; }
        public RelayCommand PaymentToCustomerCommand { get; set; }
        #endregion

        #region "Member Functions"

        public void RefreshData()
        {
            #region "To get Category Contents"

            var cat1 = sqRepository.GetCategoryContent("SITC".Trim());

            if (cat1 != null)
            {
                this.TermsAndConditions = Convert.ToString(cat1);
                TandC = Convert.ToString(cat1);
            }
            #endregion
            
        }
        void NavigatetoCustomer(object param)
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
        /// <summary>
        /// This method is used to get new sq
        /// </summary>
        /// <param name="param"></param>
        public void OnNewSQ(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            GetNewSQ();
            Mouse.OverrideCursor = null;
        }

        /// <summary>
        /// This method is used to get duplicate sq
        /// </summary>
        /// <param name="param"></param>
        public void OnDuplicateSQ(object param)
        {
            GetDuplicateSQ();
        }

        /// <summary>
        /// This method is used to get taxrate on click on Inc tax radio button
        /// </summary>
        /// <param name="param"></param>
        public void OnIncludeTax(object param)
        {
            //foreach (var item in SQDetailsEntity)
            //{
            //    var data = ProductAndServices.SingleOrDefault(e => e.ID == Convert.ToInt64(item.SelectedPSID));
            //    if (data != null)
            //    {
            //        item.GSTRate = Math.Round(Convert.ToDecimal(data.TaxRate), 2);
            //        item.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
            //    }
            //     item.SQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.ProductAndServices.Where(e => e.PSCode == item.PandSCode).Select(e => e.SellPriceIncludingTax).SingleOrDefault()), DecimalPlaces));
            //    item.OnQuantityChangeCalculatePrice();
            //    item.ExcludingTax = false;
            //}
            //CalculateTotal();
            SharedValues.IsIncludeTax = true;
            foreach (var item in SQDetailsEntity)
            {
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
            //  CalculateTotal(false);
        }

        /// <summary>
        /// This method is used to exclude on click on excl tax radio button
        /// </summary>
        /// <param name="param"></param>
        public void OnExcludeTax(object param)
        {

            //foreach (var item in SQDetailsEntity)
            //{
            //    var data = ProductAndServices.SingleOrDefault(e => e.ID == Convert.ToInt64(item.SelectedPSID));
            //    if (data != null)
            //    {
            //        item.GSTRate = Math.Round(Convert.ToDecimal(data.TaxRate), 2);
            //        item.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
            //    }
            //    item.SQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.ProductAndServices.Where(e => e.PSCode == item.PandSCode).Select(e => e.SellPriceExcludingTax).SingleOrDefault()), DecimalPlaces));
            //    item.OnQuantityChangeCalculatePrice();
            //    item.ExcludingTax = true;
            //}
            //CalculateTotal();

            ExcIncGST = true;
            SharedValues.IsIncludeTax = false;
            foreach (var item in SQDetailsEntity)
            {
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
        }

        public void OnPaymentToCustomer(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                string msg = ValidateSalesInvoice();
                if (msg != string.Empty)
                {
                    SQErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                SQErrors = string.Empty;
                SalesInvoiceForm SQForm = GetDataIntoModel();

                int i = 0;
                if (IsNew == true)
                {
                    i = sqRepository.AddUpdateInvoice(SQForm);
                }
                else
                {
                    i = sqRepository.UpdationInvoice(SQForm);
                }
                if (i > 0)
                {
                    SharedValues.CollectCommand = this.SelectedCustomerID.ToString();
                    SharedValues.NewClick = "New";
                    SharedValues.getValue = "PaymentToSupplierTab";
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

        /// <summary>
        /// This method is used to save and edit sq
        /// </summary>
        /// <param name="param"></param>
        public void SaveSalesInvoice(object param)
        {
            SalesInvoiceForm SQForm = GetDataIntoModel();
            MessageBoxResult result;
            var creditLimit = SQForm.InvoiceDetails.Sum(e => e.SIAmount);

            if (creditLimit > CreditLimitAmount)
            {
               result = System.Windows.MessageBox.Show("Customer has exceeded credit limit. Save Sales Invoice ?", "Save Confirmation", MessageBoxButton.YesNo);
            }
            else
            {
                 result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            }
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                string msg = ValidateSalesInvoice();
                if (msg != string.Empty)
                {
                    SQErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                SQErrors = string.Empty;
              

                int i = 0;
                if (IsNew == true)
                {
                    i = sqRepository.AddUpdateInvoice(SQForm);
                }
                else
                {
                    i = sqRepository.UpdationInvoice(SQForm);
                }
                if (i > 0)
                {
                    //GetNewSQ();
                    CustomerEnabled = false;
                    IsNew = false;// added on 23 may 2017
                }
                Mouse.OverrideCursor = null;
            }
        }

        public bool CanPaymentToCustomer(object param)
        {
            if (SelectedCustomerID == 0 || InvoiceDate == null || CreditDays == null
               || SQDetailsEntity.Count() == 0)
            {
                return false;
            }
            else if (SIStatus == Convert.ToByte(SI_Status.Cancelled))
            {
                return false;
            }
            else if (SIStatus == Convert.ToByte(SI_Status.Paid))
            {
                return false;
            }
            else if (SIStatus == Convert.ToByte(SI_Status.Adjusted))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CanSave(object param)
        {
            if (SelectedCustomerID == 0 || InvoiceDate == null || CreditDays == null
               || SQDetailsEntity.Count() == 0)
            {
                return false;
            }
            else if (SIStatus == Convert.ToByte(SI_Status.Cancelled))
            {
                return false;
            }
            else if (SIStatus == Convert.ToByte(SI_Status.Paid))
            {
                return false;
            }
            else if (SIStatus == Convert.ToByte(SI_Status.Adjusted))
            {
                return false;
            }
            else
            {
                return true;
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

        public bool CanDeleteSQ(object param)
        {
            if (IsNew == true)
            {
                return false;
            }
            else if (SIStatus == Convert.ToByte(SI_Status.Cancelled))
            {
                return false;
            }
            else if (SIStatus == Convert.ToByte(SI_Status.Paid))
            {
                return false;
            }
            else if (SIStatus == Convert.ToByte(SI_Status.Adjusted))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// This method is used to delete SQ
        /// </summary>
        /// <param name="param"></param>
        public void OnDeleteSQ(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                int i = sqRepository.DeleteInvoice(InvoiceNo);
                if (i == Convert.ToByte(SI_Status.Cancelled))
                {
                    SQErrors = string.Empty;
                    GetNewSQ();
                }
                else 
                {
                    SQErrors = "Cannot delete Sales Invoice";
                    AllFieldsEnabled = false;
                    AllFieldsReadonly = true;
                    CustomerEnabled = false;
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

        public SalesInvoiceForm GetDataIntoModel()
        {
            SalesInvoiceForm SQForm = new SalesInvoiceForm();
            SQForm.InvoiceDetails = new List<SalesInvoiceDetailEntity>();
            SalesInvoiceEntity model = new SalesInvoiceEntity();
            model.InvoiceNo = this.InvoiceNo;
            model.InvoiceDate = this.InvoiceDate;
            model.TotalBeforeTax = this.TotalBeforeTax;
            model.TotalTax = this.TotalTax;
            model.TotalAfterTax = this.TotalAfterTax;
            model.CreditDays = this.CreditDays;
            model.OurSONo = this.OurSONo;
            model.CustomerID = this.SelectedCustomerID;
            model.SalesmanID = this.SelectedSalesmanID;
            model.TermsAndConditions = this.TermsAndConditions;
            if (ExcludingTax == true)
            {
                model.ExcIncGST = false;
            }
            else
            {
                model.ExcIncGST = true;
            }

            SQForm.Invoice = model;

            foreach (var item in SQDetailsEntity)
            {
                SalesInvoiceDetailEntity sqEntity = new SalesInvoiceDetailEntity();
                sqEntity.SINo = Convert.ToString(item.SelectedPSID);
                sqEntity.PandSCode = item.PandSCode;
                sqEntity.PandSName = item.PandSName;
                sqEntity.SIQty = item.SQQty;
                sqEntity.SIPrice = item.SQPrice;
                sqEntity.SIDiscount = item.SQDiscount;
                sqEntity.GSTRate = item.GSTRate;
                sqEntity.GSTRateStr = Convert.ToString(item.GSTRate)+"%";
                sqEntity.SIAmount = item.SQAmount;
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID) > 0)
                {
                    SQForm.InvoiceDetails.Add(sqEntity);
                }
            }
            return SQForm;
        }

        /// <summary>
        /// This method is used to calculate total amount of PandS with tax
        /// </summary>
        //public void CalculateTotal()
        //{
        //    if (SQDetailsEntity != null)
        //    {
        //        TotalBeforeTax = SQDetailsEntity.Sum(e => e.AmountBeforeTax);
        //        TotalBeforeTax = Math.Round(Convert.ToDecimal(TotalBeforeTax), DecimalPlaces);
        //        TotalTax = SQDetailsEntity.Sum(e => e.TaxAmount);
        //        TotalTax = Math.Round(Convert.ToDecimal(TotalTax), DecimalPlaces);
        //        TotalAfterTax = SQDetailsEntity.Sum(e => e.SQAmount);
        //        TotalAfterTax = Math.Round(Convert.ToDecimal(TotalAfterTax), DecimalPlaces);

        //        TotalBeforeTaxStr = Convert.ToString(TotalBeforeTax);
        //        TotalTaxStr = Convert.ToString(TotalTax);
        //        TotalAfterTaxStr = Convert.ToString(TotalAfterTax);
        //    }
        //}
        public void CalculateTotal(bool excludeTax)
        {
            decimal? totalBeforeTax = 0;
            decimal? mTotalTax = 0;
            decimal? mTotalAfterTax = 0;
            if (SQDetailsEntity != null)
            {
                totalBeforeTax = SQDetailsEntity.Sum(e => e.AmountBeforeTax);
                TotalBeforeTax = Math.Round(Convert.ToDecimal(totalBeforeTax), DecimalPlaces);
                mTotalTax = SQDetailsEntity.Sum(e => e.TaxAmount);
               
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
            //added on 19June2017
            string str = string.Empty;
            var sup = customerRepository.GetAllCustomers().Where(s => s.CustomerID == SelectedCustomerID).SingleOrDefault();
            if (sup != null)
            {
                if (sup.CreditLimitAmount != null)
                {
                    CreditLimitAmount = sup.CreditLimitAmount;
                }
                else
                {
                    CreditLimitAmount = 0;
                }

                //getting all the discounts from CategoryContent
                var lst = squRepository.GetAllSalesman("CD");
                if (lst != null)
                {
                    str = lst.Where(e => e.ContentID == sup.Discount).Select(e => e.ContentName).SingleOrDefault();
                }
                foreach (var item in SQDetailsEntity)
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
                        
                    }
                    
                }
                else
                {
                    if (SelectedSalesmanID != 0)
                    {
                        if (LstSalesman != null)
                        {
                            var salesman = LstSalesman.Where(e => e.ContentID == SelectedSalesmanID).FirstOrDefault();
                            if (salesman != null)
                            {
                                SelectedSalesmanID = salesman.ContentID;
                            }
                        }
                    }
                    
                }
            }
        }

        private string GenerateNewInvoiceNo()
        {
            int n;
           bool i=  int.TryParse(sqRepository.GetLatestInvoiceNo(), out n);
           var NewPqNo = n + 1;
            return "SI-" + NewPqNo.ToString();
        }

        public int ManageDuplicatePandS()
        {
            int rowFocusindex = -1;
            lst = new ObservableCollection<DataGridViewModel>();
            lst = SQDetailsEntity;

            var query = lst.GroupBy(x => x.SelectedPSID)
              .Where(g => g.Count() > 1)
              .ToList();
            if (query.Count > 0 && SQDetailsEntity.Count > 1)
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
                    //SQDetailsEntity[index1] = obj1;
                    var row = new DataGridViewModel(ProductList);
                    //row.SQQty = 1;
                    //added on 19June2017
                    //row.GSTRate = TaxRate;
                    //row.GSTRateStr = Convert.ToString(TaxRate)+"%";
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
                    SQDetailsEntity[index2] = row;
                    rowFocusindex = index2;
                }
                //for (int i = 0; i < 2; i++)
                //{ 
                //    var p = SQDetailsEntity.Where(e => e.SelectedPSID == obj2.SelectedPSID ).FirstOrDefault();
                //    if (p.SQPrice == null)
                //    {
                //        SQDetailsEntity.Remove(p);
                //    }
                //}

                OnPropertyChanged("SQDetailsEntity");

            }
            else
            {
                int count = SQDetailsEntity.Count(x => x.SelectedPSID == null);
                if (count == 0)
                {
                    var row = new DataGridViewModel(ProductList);
                    //                    row.SQQty = 1;
                    //                    row.GSTRate = TaxRate;
                    //                    row.GSTRateStr = Convert.ToString(row.GSTRate) + "%"
                    //;                    //added on 19June2017
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
                    SQDetailsEntity.Add(row);
                    OnPropertyChanged("SQDetailsEntity");
                    rowFocusindex = -1;
                }
                else
                {
                    var emptyRow = lst.Where(y => y.SelectedPSID == null).FirstOrDefault();
                    rowFocusindex = SQDetailsEntity.IndexOf(emptyRow);
                }


            }

            return rowFocusindex;
        }

        public void GetSalesInvoice(string sqNo)
        {
            // Mouse.OverrideCursor = Cursors.Wait;
            SalesInvoiceForm sqf = sqRepository.GetSalesInvoice(sqNo);

            this.ID = sqf.Invoice.ID;
            this.InvoiceNo = sqf.Invoice.InvoiceNo;
            this.OurSONo= sqf.Invoice.OurSONo;
            this.InvoiceDate = sqf.Invoice.InvoiceDate;
            this.CreditDays = sqf.Invoice.CreditDays;

            this.SelectedCustomerID = sqf.Invoice.CustomerID;
            if (sqf.Invoice.SalesmanID != 0)
            {
                this.SelectedSalesmanID = sqf.Invoice.SalesmanID;
            }

            this.TermsAndConditions = sqf.Invoice.TermsAndConditions;

            this.TotalBeforeTax = sqf.Invoice.TotalBeforeTax;
            this.TotalTax = sqf.Invoice.TotalTax;
            this.TotalAfterTax = sqf.Invoice.TotalAfterTax;
            this.TotalBeforeTaxStr = Convert.ToString(this.TotalBeforeTax);
            this.TotalTaxStr = Convert.ToString(TotalTax);
            this.TotalAfterTaxStr = Convert.ToString(TotalAfterTax);

            if (sqf.Invoice.ExcIncGST == true)
            {
                ExcludingTax = false;
                IncludingTax = true;
                //  SQDEntity.GSTRate = 0;
            }
            else
            {
                ExcludingTax = true;
                IncludingTax = false;
                // SQDEntity.GSTRate = TaxRate;
            }

            if (this.SIStatus == Convert.ToByte(SI_Status.Paid))
            {
                AllFieldsReadonly = true;
                AllFieldsEnabled = false;
            }
            else
            {
                AllFieldsReadonly = false;
                AllFieldsEnabled = true;
                ProductAndServices = ProductAndServices.OrderBy(x => x.PSName).Where(x => x.IsInActive != "Y").ToObservable();
                LstCustomers = LstCustomers.OrderBy(x => x.FirstName).Where(x => x.Inactive != "Y").ToList();
            }

            this.SIStatus = sqf.Invoice.SIStatus;
            if (SIStatus == Convert.ToByte(SI_Status.Cancelled))
            {
                StatusString = "Cancelled";
                VisibilityForImage = Visibility.Visible;
                AllFieldsEnabled = false;
                AllFieldsReadonly = true;
            }
            else if (SIStatus == Convert.ToByte(SI_Status.Paid))
            {
                StatusString = "   Paid";
                VisibilityForImage = Visibility.Visible;
                AllFieldsEnabled = false;
                AllFieldsReadonly = true;
            }
            else if (SIStatus == Convert.ToByte(SI_Status.Adjusted))
            {
                StatusString = "Adjusted";
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

          

            CustomerEnabled = false;// added on 23 may 2017
            this.SQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            foreach (var item in sqf.InvoiceDetails)
            {
                DataGridViewModel sqEntity = new DataGridViewModel(ProductList);
                sqEntity.SelectedPSID = Convert.ToString(item.SINo);
                sqEntity.PandSCode = item.PandSCode;
                sqEntity.PandSName = item.PandSName;
                sqEntity.GSTRate = item.GSTRate;
                sqEntity.GSTRateStr = Convert.ToString(item.GSTRate)+"%";
                sqEntity.SQQty = item.SIQty;
                sqEntity.SQPrice = Convert.ToString(item.Price);
                sqEntity.SQDiscount = item.SIDiscount;

                //  SQDEntity.GSTRate = item.GSTRate;
                sqEntity.SQAmount = item.SIAmount;
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
                SQDetailsEntity.Add(sqEntity);
            }

        }

        /// <summary>
        /// This method is used to validate sales quotation on Save
        /// </summary>
        /// <returns></returns>
        public string ValidateSalesInvoice()
        {
            bool isValidData = false;
            string msg = string.Empty;
            if (SelectedCustomerID == 0)
            {
                return msg = "Please select Customer Name";
            }
            if (InvoiceDate == null)
            {
                return msg = "Please enter Invoice Date";
            }
            if (CreditDays == null)
            {
                return msg = "Please enter Credit Days";
            }
            if (SQDetailsEntity.Count <= 0)
            {
                return msg = "Please add Products and Services";
            }

            foreach (var item in SQDetailsEntity)
            {
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID) > 0)
                {
                    if (item.SQQty == 0 && item.SelectedPSID != null)
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

                    //if (System.Text.RegularExpressions.Regex.IsMatch(item.SQPrice.Trim(), @"[^0-9]"))
                    //{
                    //    return msg = "Please enter valid price";
                    //}
                    if ( item.SelectedPSID != null && Convert.ToDecimal(item.SQPrice) >= 0)
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
        /// This method is used to get new SQ
        /// </summary>
        public void GetNewSQ()
        {
            VisibilityForImage = Visibility.Collapsed;
            IsNew = true;
            ID = 0;
            SelectedCustomerID = 0;
            SelectedSalesmanID = 0;
            BillToAddress = string.Empty;
            ShipToAddress = string.Empty;
            // ValidForDays = 0;
            InvoiceNo = GenerateNewInvoiceNo();
            TermsAndConditions = TandC;
            TotalBeforeTax = 0;
            TotalTax = 0;
            TotalAfterTax = 0;
            TotalBeforeTaxStr = Convert.ToString(0);
            TotalTaxStr = Convert.ToString(0);
            TotalAfterTaxStr = Convert.ToString(0);
            SQErrors = string.Empty;
            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            CustomerEnabled = true;// added on 23 may 2017
            this.CreditDays = 0;
            this.OurSONo = string.Empty;
            SharedValues.CustomerDiscount = null;
            SalesInvoiceEntity = new SalesInvoiceEntity();
            SQDetailsEntity.Clear();
            // SQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            ProductAndServices = ProductAndServices.OrderBy(x=>x.PSName).Where(x => x.IsInActive != "Y").ToObservable();
            LstCustomers = LstCustomers.OrderBy(x=>x.FirstName).Where(x => x.Inactive != "Y").ToList();
            var row = new DataGridViewModel(ProductList);
            //row.SQQty = 1;
            //row.SQDiscount = 0;
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
            //row.GSTRate = TaxRate;
            //row.GSTRateStr = Convert.ToString(TaxRate)+"%";
            SQDetailsEntity.Add(row);
            OnPropertyChanged("SQDetailsEntity");

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
                if(lstOptions.StartingSalesInvNo!=null)
                {
                    StartingSINo = lstOptions.StartingSalesInvNo;
                }

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
        public void GetDuplicateSQ()
        {
            VisibilityForImage = Visibility.Collapsed;
            IsNew = true;
            SQErrors = string.Empty;
            InvoiceNo = GenerateNewInvoiceNo();
            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            CustomerEnabled = true;// added on 23 may 2017
        }

        #endregion
    }
}