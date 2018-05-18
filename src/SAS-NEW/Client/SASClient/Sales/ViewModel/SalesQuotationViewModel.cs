using System;
using System.Collections.Generic;
using System.Linq;
using SDN.Customers.BL;
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
    using UI.Entities.Sales;
    using Services;
    using Product.Services;
    using Customers.Views;
    using Microsoft.Practices.Prism.Events;
    using Customers.Services;
    using SASClient.Reports.ReportsPage;
    using System.Data;
    using System.Reflection;
    using SASClient.CloseRequest;
    using Microsoft.Practices.Prism.Commands;
    using System.Globalization;
    using Settings.Services;

    public class SalesQuotationViewModel : SalesQuotationEntity
    {
        #region "Private members"

        //private ObservableCollection<PandSDetailsModel> pands;
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string currencyName;
        //  private string taxName;
        private ObservableCollection<DataGridViewModel> sqDetailsEntity;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private ISalesQuotationRepository sqRepository = new SalesQuotationRepository();
        public IPandSDetailsRepository pandsRepository = new PandSDetailsRepository();
        private Customers.Services.ICustomerRepository customerRepository = new CustomerRepository();
        public ObservableCollection<DataGridViewModel> lst;
        private DataGridViewModel sqdEntity;
        private SalesQuotationEntity purchaseQuotationEntity;
        private ObservableCollection<SalesQuotationEntity> validatedate;
        private static IEnumerable<PandSListModel> ProductList;
        private DateTime? _QuotationDateCalender;
        StackList listitem = new StackList();
        private int customerId;
        private string _DateErrors;
        private decimal? taxRate;
        //private ObservableCollection<PandSDetailsModel> productAndServices;
        private ObservableCollection<PandSListModel> productAndServices;
        private ObservableCollection<SalesQuotationEntity> _SQEntity = new ObservableCollection<SalesQuotationEntity>();
        private int? defaultPSID;
        private int? selectedSalesmanID;
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
        private decimal? customerDiscount;
        ICompanyDetails CompanyD = new CompanyDetails();
        //CompanyDetailsEntities cmp = new CompanyDetailsEntities();
        #endregion

        #region "Public Properties"
        
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
        public DateTime? QuotationDateCalender
        {
            get
            {
                return _QuotationDateCalender;
            }
            set
            {
                _QuotationDateCalender = value;
                OnPropertyChanged("QuotationDateCalender");
            }
        }
        public string TandC
        {
            get; set;
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
        
        public decimal? CustomerDiscount
        {
            get {return  customerDiscount; }
            set { customerDiscount = value;
                OnPropertyChanged("CustomerDiscount");
            }
        }

        public SalesQuotationEntity SalesQuotationEntity
        {
            get
            {
                return purchaseQuotationEntity;
            }
            set
            {
                if (purchaseQuotationEntity != value)
                {
                    purchaseQuotationEntity = value;
                    OnPropertyChanged("SalesQuotationEntity");
                }
            }
        }
        public ObservableCollection<SalesQuotationEntity> SQEntity
        {
            get
            {
                // _Transactionlist.Clear();
                // TransactionData();
                return _SQEntity;
            }
            set
            {
                _SQEntity = value;
                OnPropertyChanged("SQEntity");
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
        public ObservableCollection<SalesQuotationEntity> Validatedate
        {
            get
            {
                return validatedate;
            }
            set
            {
                if (validatedate != value)
                {
                    validatedate = value;
                    OnPropertyChanged("Validatedate");
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

        //public static SalesQuotationViewModel _instance;

        //public static SalesQuotationViewModel GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new SalesQuotationViewModel();
        //    }

        //    return _instance;
        //}
      
        private bool? jumptoNextrow;
        private bool? _disableTab;

        public SalesQuotationViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            LoadCustomerBackground();
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            Mouse.OverrideCursor = Cursors.Wait;
            ConvertToSOCommand = new RelayCommand(ConvertToSalesOrder, CanConvertToSO);
            ConvertToSICommand = new RelayCommand(ConvertToSalesInvoice, CanConvertToSI);
            SaveCommand = new RelayCommand(SaveSalesQuotation, CanSave);
            CustomerSelectionChangedCommand = new RelayCommand(OnCustomerChange);
            NewSQCommand = new RelayCommand(OnNewSQ);
            DuplicateCommand = new RelayCommand(OnDuplicateSQ, CanDuplicate);
            IncludeTaxCheckedCommand = new RelayCommand(OnIncludeTax);
            ExcludeTaxCheckedCommand = new RelayCommand(OnExcludeTax);
            DeleteCommand = new RelayCommand(OnDeleteSQ, CanDeleteSQ);
            NavigateToClientCommand = new RelayCommand(NavigatetoCustomer, CanNavigate);
            CloseCommand = new DelegateCommand(Close);
            SalesQuotationEntity = new SalesQuotationEntity();
            SQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            clickCommand = new RelayCommand(PrintCommand, CanPrint);

            int minHeight = 300;
            int headerRows = 339;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 84;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SQFormGridHeight = minHeight;
            #region "Get Customer Details"

            var customers = customerRepository.GetCustomerList();
            if (customers != null)
            {
                LstCustomers = customers.OrderBy(x => x.FirstName).ToList();
            }
            #endregion
            #region getting Options details
            GetOptionsData();
            #endregion

            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            RubberStampSO = false;
            RubberStampSI = false;
            //this.QuotationDate = DateTime.Now.Date;
            SharedValues.CustomerDiscount = null;
            //ProductList = pandsRepository.GetAllPandS();
            //ProductAndServices = new ObservableCollection<PandSDetailsModel>(ProductList).OrderBy(x => x.PSName).ToObservable();
            ProductList = pandsRepository.GetPandSComboList();
            ProductAndServices = new ObservableCollection<PandSListModel>(ProductList).OrderBy(x => x.PSName).ToObservable();

            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {
                    MustCompare = false;
                    CustomerEnabled = false;//added on 23may2017
                    GetSalesQuotation(SharedValues.NewClick);
                }
                else if (SharedValues.NewClick == "New")
                {
                    MustCompare = true;
                    CustomerEnabled = true;//added on 23may2017
                    GetNewSQ();
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
        public RelayCommand SQDiscountTextChangedCommand { get; set; }
        public RelayCommand SQQuantityTextChangedCommand { get; set; }
        public RelayCommand NewSQCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand DuplicateCommand { get; set; }
        public RelayCommand IncludeTaxCheckedCommand { get; set; }
        public RelayCommand ExcludeTaxCheckedCommand { get; set; }
        public RelayCommand NavigateToClientCommand { get; set; }
        public RelayCommand clickCommand { get; set; }
        #endregion

        #region "Member Functions"

        public void RefreshData()
        {
            #region "To get Category Contents"

            var cat1 = sqRepository.GetCategoryContent("SQTC".Trim());

            if (cat1 != null)
            {
                this.TermsAndConditions = Convert.ToString(cat1);
                TandC= Convert.ToString(cat1);
            }

           

            var cat2 = sqRepository.GetAllSalesman("SM".Trim());

            if (cat2 != null)
            {
                this.LstSalesman = cat2.OrderBy(x=>x.ContentName).ToList();
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
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
            // ExcIncGST = false;
            //  ExcludingTax = false;
            SharedValues.IsIncludeTax = true;
            foreach (var item in SQDetailsEntity)
            {  if (item.SelectedPSID != null)
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
                                
             //   item.OnQtyChangeTotalAmt(false);//Exceluded tax=false


            }
            
         //  CalculateTotal(false);

        }

        /// <summary>
        /// This method is used to exclude on click on excl tax radio button
        /// </summary>
        /// <param name="param"></param>
        public void OnExcludeTax(object param)
        {
            ExcIncGST = true;
            SharedValues.IsIncludeTax = false;
            foreach (var item in SQDetailsEntity)
            {
                if (item.SelectedPSID != null)
                {
                    item.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
                   // if (item.ExcludingTax == false)
                    if(SharedValues.IsIncludeTax == false)
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
               
           // item.OnQtyChangeTotalAmt(true); //Exceluded tax=True

            }
         //  CalculateTotal(true);
        }

        public bool CanConvertToSO(object param)
        {
            if (IsNew == true)
            {
                return false;
            }
            else
            {
                if (this.SQ_Conv_to_SO == true || this.SQ_Conv_to_SI == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
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
                if (this.SQ_Conv_to_SI == true || this.SQ_Conv_to_SO == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void ConvertToSalesOrder(object param)
        {
            if (this.SQ_Conv_to_SO == false || this.SQ_Conv_to_SO == null)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                SalesQuotationForm SQForm = GetDataIntoModel();
                int i = sqRepository.ConvertToSalesOrder(SQForm);
                if (i > 0)
                {
                    this.SQ_Conv_to_SO = true;
                    AllFieldsReadonly = true;
                    AllFieldsEnabled = false;
                    CustomerEnabled = false;// added on 23 may 2017
                }
                Mouse.OverrideCursor = null;
            }
            else
            {
                SQErrors = "Already converted to Sales Order";
            }
        }

        public void ConvertToSalesInvoice(object param)
        {
            if (this.SQ_Conv_to_SI == false || this.SQ_Conv_to_SI == null)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                SalesQuotationForm SQForm = GetDataIntoModel();
                int i = sqRepository.ConvertToSalesInvoice(SQForm);
                if (i > 0)
                {
                    this.SQ_Conv_to_SI = true;
                    AllFieldsReadonly = true;
                    AllFieldsEnabled = false;
                    CustomerEnabled = false;// added on 23 may 2017
                }
                Mouse.OverrideCursor = null;
            }
            else
            {
                SQErrors = "Already converted to Sales Invoice";
            }
        }

        /// <summary>
        /// This method is used to save and edit sq
        /// </summary>
        /// <param name="param"></param>
        public void SaveSalesQuotation(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                string msg = ValidateSalesQuotation();
                if (msg != string.Empty)
                {
                    SQErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                SQErrors = string.Empty;
                SalesQuotationForm SQForm = GetDataIntoModel();

                int i = 0;
                if (IsNew == true)
                {
                    i = sqRepository.AddUpdateQuotation(SQForm);
                }
                else
                {
                    i = sqRepository.UpdationQuotation(SQForm);
                }
                if (i > 0)
                {
                    // GetNewSQ();
                    CustomerEnabled = false;
                    IsNew = false;// added on 23 may 2017
                }
                Mouse.OverrideCursor = null;
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
        public bool CanSave(object param)
        {
        
            string date = this.DateFormat as string;
            var c = CompanyD.GetCompanyDetails().Comp_year_start_date;
            
            if (SelectedCustomerID == 0 || QuotationDateStr == null
               || SQDetailsEntity.Count() == 0 )
            {
                
                return false;
            }
            else
            {
                if (IsNew == false)
                {
                    if (SQ_Conv_to_SO == true)
                    {
                        return false;
                    }
                    else if (SQ_Conv_to_SI == true)
                    {
                        return false;
                    }
                    
                    else
                    {
                        return true;
                    }
                }
                if (QuotationDateStr != null) {
                    try
                    {
                        if (!string.IsNullOrEmpty(QuotationDateStr) && !string.IsNullOrWhiteSpace(QuotationDateStr))
                        {

                            //item.StartDate = item.StartDate.Replace('.', '/');
                            //item.StartDate = item.StartDate.Replace('-', '/');
                            //item.EndDate = item.EndDate.Replace('.', '/');
                            //item.EndDate = item.EndDate.Replace('-', '/');
                            var Start = (DateTime.ParseExact(QuotationDateStr, date, CultureInfo.InvariantCulture));
                            this.DateErrors = "";
                            //var End = (DateTime.ParseExact(item.EndDate, date, CultureInfo.InvariantCulture));
                            if (Start < c)
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

        public bool CanDeleteSQ(object param)
        {
            if (SQ_Conv_to_SO == true)
            {
                return false;
            }
            else if (SQ_Conv_to_SI == true)
            {
                return false;
            }
            else if (IsNew == true)
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
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete?\n"+ "@ Simple Accounting Software Pte Ltd", "Delete Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                if (sqRepository.CanDeleteQuotation(ID))
                {
                    sqRepository.DeleteQuotation(ID);
                    SQErrors = string.Empty;
                    OnNewSQ(null);
                }
                else
                {
                    SQErrors = "Cannot delete Sales Quotation";
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

        public SalesQuotationForm GetDataIntoModel()
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            SalesQuotationForm SQForm = new SalesQuotationForm();
            SQForm.QuotationDetails = new List<SalesQuotationDetailEntity>();
            SalesQuotationEntity model = new SalesQuotationEntity();
            model.QuotationNo = this.QuotationNo;
            model.QuotationDate = DateTime.ParseExact(this.QuotationDateStr, oData.DateFormat, null);
            model.TotalBeforeTax = this.TotalBeforeTax;
            model.TotalTax = this.TotalTax;
            model.TotalAfterTax = this.TotalAfterTax;
            model.ValidForDays = this.ValidForDays;
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

            SQForm.Quotation = model;

            foreach (var item in SQDetailsEntity)
            {
                SalesQuotationDetailEntity sqEntity = new SalesQuotationDetailEntity();
                sqEntity.SQNo = Convert.ToString(item.SelectedPSID);
                sqEntity.PandSCode = item.PandSCode;
                sqEntity.PandSName = item.PandSName;
                sqEntity.SQQty = item.SQQty;
                sqEntity.SQPrice = item.SQPrice;
                sqEntity.SQDiscount = item.SQDiscount;
                sqEntity.GSTRate = item.GSTRate;
                sqEntity.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
                sqEntity.SQAmount = item.SQAmount;
                //sqEntity.PriceIncTax = item.PriceIncTax;
                //sqEntity.PriceExcTax = item.PriceExcTax;
                
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID) > 0)
                {
                    SQForm.QuotationDetails.Add(sqEntity);
                }
            }
            return SQForm;
        }

        /// <summary>
        /// This method is used to calculate total amount of PandS with tax
        /// </summary>
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
            SharedValues.SelectedCusId = SelectedCustomerID;
            var sup = customerRepository.GetAllCustomers().Where(s => s.ID == SelectedCustomerID).SingleOrDefault();
            if (sup != null)
            {
                //getting all the discounts from CategoryContent
                var lst = sqRepository.GetAllSalesman("CD");
                if(lst!=null)
                {
                    str = lst.Where(e => e.ContentID == sup.Cus_Discount).Select(e=>e.ContentName).SingleOrDefault();
                }
                
                foreach(var item in SQDetailsEntity)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        CustomerDiscount = Convert.ToDecimal(str);
                    }
                    else
                    {
                        CustomerDiscount = 0;
                    }
                    if(item.SelectedPSID!=null)
                    {
                        item.SQDiscount = CustomerDiscount;
                    }
                    SharedValues.CustomerDiscount = CustomerDiscount;
                }//end

                if (IsNew == true)
                {
                    if (sup.Cus_Salesman != 0)
                    {
                        var salesman = LstSalesman.Where(e => e.ContentID == sup.Cus_Salesman).FirstOrDefault();
                        if (salesman != null)
                        {
                            SelectedSalesmanID = sup.Cus_Salesman;
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
                else
                {
                    if (SelectedSalesmanID != 0 && SelectedSalesmanID!=null)
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


        private string GenerateNewQuotationNo()
        {
            var NewPqNo = sqRepository.GetLatestQuotationNo() + 1;
            return "SQ-" + NewPqNo.ToString();
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
                

                OnPropertyChanged("SQDetailsEntity");

            }
            else
            {
                int count = SQDetailsEntity.Count(x => x.SelectedPSID == null);
                if (count == 0)
                {
                    var row = new DataGridViewModel(ProductList);
                    //row.SQQty = 1;
                    //row.GSTRate = TaxRate;
                    //row.GSTRateStr = Convert.ToString(TaxRate)+"%";
                    //added on 19June2017
                    //if (CustomerDiscount != null)
                    //{
                    //    row.SQDiscount = CustomerDiscount;
                    //}
                    //else
                    //{
                    //    row.SQDiscount = 0;
                    //}
                    //end
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

        public DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        {
            DataTable dt = new DataTable();


            PropertyInfo[] columns = null;

            if (Linqlist == null) return dt;

            foreach (T Record in Linqlist)
            {

                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }

                DataRow dr = dt.NewRow();

                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }

        // }
     
        public void GetSalesQuotation(string sqNo)
        {
            // Mouse.OverrideCursor = Cursors.Wait;
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            SalesQuotationForm sqf = sqRepository.GetSalesQuotation(sqNo);

            this.ID = sqf.Quotation.ID;
            this.QuotationNo = sqf.Quotation.QuotationNo;
            this.QuotationDateStr = sqf.Quotation.QuotationDate.ToString(oData.DateFormat);
            this.ValidForDays = sqf.Quotation.ValidForDays;
            this.SelectedCustomerID = sqf.Quotation.CustomerID;
            SharedValues.SelectedCusId = this.SelectedCustomerID;
            if (sqf.Quotation.SalesmanID != 0)
            {
                this.SelectedSalesmanID = sqf.Quotation.SalesmanID;
            }
            //if (this.SelectedCustomerID > 0)
            //{
            //    GetCustomerDetails();
            //}

            this.TermsAndConditions = sqf.Quotation.TermsAndConditions;

            this.TotalBeforeTax = sqf.Quotation.TotalBeforeTax;
            this.TotalTax = sqf.Quotation.TotalTax;
            this.TotalAfterTax = sqf.Quotation.TotalAfterTax;
            this.TotalBeforeTaxStr = Convert.ToString(this.TotalBeforeTax);
            this.TotalTaxStr = Convert.ToString(TotalTax);
            this.TotalAfterTaxStr = Convert.ToString(TotalAfterTax);

            if (sqf.Quotation.ExcIncGST == true)
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

            this.SQ_Conv_to_SO = sqf.Quotation.SQ_Conv_to_SO;
            this.SQ_Conv_to_SI = sqf.Quotation.SQ_Conv_to_SI;

            if (SQ_Conv_to_SO == true )
            {
                AllFieldsReadonly = true;
                AllFieldsEnabled = false;
                RubberStampSO = true;
                RubberStampSI = false;
                //sqf.QuotationDetails = sqf.QuotationDetails.Where(x=>x.activ)
               
            }
            if (SQ_Conv_to_SI == true)
            {
                AllFieldsReadonly = true;
                AllFieldsEnabled = false;
                RubberStampSO = false;
                RubberStampSI = true;
                //sqf.QuotationDetails = sqf.QuotationDetails.Where(x=>x.activ)

            }
         
            else
            {
                AllFieldsReadonly = false;
                AllFieldsEnabled = true;
                ProductAndServices = ProductAndServices.OrderBy(x=>x.PSName).Where(x => x.IsInActive != "Y").ToObservable();
                LstCustomers = LstCustomers.OrderBy(x=>x.FirstName).Where(x => x.Inactive != "Y").ToList();
            }
            CustomerEnabled = false;// added on 23 may 2017

            this.SQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            foreach (var item in sqf.QuotationDetails)
            {
                DataGridViewModel sqEntity = new DataGridViewModel(ProductList);
                sqEntity.SelectedPSID = Convert.ToString(item.SQNo);
                sqEntity.PandSCode = item.PandSCode;
                sqEntity.PandSName = item.PandSName;
                sqEntity.GSTRate = item.GSTRate;
                sqEntity.GSTRateStr = Convert.ToString(item.GSTRate)+"%";
                sqEntity.SQQty = item.SQQty;
                sqEntity.SQPrice = Convert.ToString(item.Price);
                sqEntity.SQDiscount = item.SQDiscount;
                //sqdEntity.PriceExcTax = item.PriceExcludedTax ?? null as decimal?;
                //sqdEntity.PriceIncTax = item.PriceIncludedTax ?? null as decimal?;
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
                //  SQDEntity.GSTRate = item.GSTRate;
                sqEntity.SQAmount = item.SQAmount;

                SQDetailsEntity.Add(sqEntity);
            }

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
                case "QuotationDateCalender":
                    FillStartDate();
                    break;
              

            }

            base.OnPropertyChanged(name);
        }
        void FillStartDate()
        {
            string date = this.DateFormat as string;
                QuotationDateStr = Convert.ToDateTime(this.QuotationDateCalender).ToString(date);
                QuotationDateDate = this.QuotationDateCalender;
        }
        public void PrintCommand(object param)
        {

            var QuotationNumber = param.ToString();
            SharedValues.Print_Id = QuotationNumber;
            ///PrintSalesQuotation();
            //after calling the mwthod
            var mainview = ServiceLocator.Current.GetInstance<SalesQuotationReport>();

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
        public SalesQuotationForm PrintSalesQuotation()
        {
            // Mouse.OverrideCursor = Cursors.Wait;
            var  sqRepository = new SalesQuotationRepository();
            var sqNo = SharedValues.Print_Id;
            var sqf = sqRepository.GetPrintSalesQuotation(sqNo);
          //  var qf = sqRepository.GetSalesQuotation(sqNo);
            
          ////  DataTable dt = new DataTable();
          //  DataTable dt = LINQResultToDataTable(qf);
          //  dt = (DataTable)sqf;
            return sqf;
        }

        //public void PrintSalesQuotation()
        //{
        //    // Mouse.OverrideCursor = Cursors.Wait;
        //    var sqNo = SharedValues.Print_Id;
        //    SalesQuotationForm sqf = sqRepository.GetSalesQuotation(sqNo);

        //    this.ID = sqf.Quotation.ID;
        //    this.QuotationNo = sqf.Quotation.QuotationNo;
        //    this.QuotationDate = sqf.Quotation.QuotationDate;
        //    this.ValidForDays = sqf.Quotation.ValidForDays;
        //    this.SelectedCustomerID = sqf.Quotation.CustomerID;
        //    if (sqf.Quotation.SalesmanID != 0)
        //    {
        //        this.SelectedSalesmanID = sqf.Quotation.SalesmanID;
        //    }
        //    //if (this.SelectedCustomerID > 0)
        //    //{
        //    //    GetCustomerDetails();
        //    //}

        //    this.TermsAndConditions = sqf.Quotation.TermsAndConditions;

        //    this.TotalBeforeTax = sqf.Quotation.TotalBeforeTax;
        //    this.TotalTax = sqf.Quotation.TotalTax;
        //    this.TotalAfterTax = sqf.Quotation.TotalAfterTax;
        //    this.TotalBeforeTaxStr = Convert.ToString(this.TotalBeforeTax);
        //    this.TotalTaxStr = Convert.ToString(TotalTax);
        //    this.TotalAfterTaxStr = Convert.ToString(TotalAfterTax);

        //    if (sqf.Quotation.ExcIncGST == true)
        //    {
        //        ExcludingTax = false;
        //        IncludingTax = true;
        //        //  SQDEntity.GSTRate = 0;
        //    }
        //    else
        //    {
        //        ExcludingTax = true;
        //        IncludingTax = false;
        //        // SQDEntity.GSTRate = TaxRate;
        //    }

        //    this.SQ_Conv_to_SO = sqf.Quotation.SQ_Conv_to_SO;
        //    this.SQ_Conv_to_SI = sqf.Quotation.SQ_Conv_to_SI;

        //    if (SQ_Conv_to_SO == true)
        //    {
        //        AllFieldsReadonly = true;
        //        AllFieldsEnabled = false;
        //        RubberStampSO = true;
        //        RubberStampSI = false;
        //        //sqf.QuotationDetails = sqf.QuotationDetails.Where(x=>x.activ)

        //    }
        //    if (SQ_Conv_to_SI == true)
        //    {
        //        AllFieldsReadonly = true;
        //        AllFieldsEnabled = false;
        //        RubberStampSO = false;
        //        RubberStampSI = true;
        //        //sqf.QuotationDetails = sqf.QuotationDetails.Where(x=>x.activ)

        //    }

        //    else
        //    {
        //        AllFieldsReadonly = false;
        //        AllFieldsEnabled = true;
        //        ProductAndServices = ProductAndServices.OrderBy(x => x.PSName).Where(x => x.IsInActive != "Y").ToObservable();
        //        LstCustomers = LstCustomers.OrderBy(x => x.FirstName).Where(x => x.Inactive != "Y").ToList();
        //    }
        //    CustomerEnabled = false;// added on 23 may 2017

        //    this.SQDetailsEntity = new ObservableCollection<DataGridViewModel>();
        //    foreach (var item in sqf.QuotationDetails)
        //    {
        //        DataGridViewModel sqEntity = new DataGridViewModel(ProductList);
        //        sqEntity.SelectedPSID = Convert.ToString(item.SQNo);
        //        sqEntity.PandSCode = item.PandSCode;
        //        sqEntity.PandSName = item.PandSName;
        //        sqEntity.GSTRate = item.GSTRate;
        //        sqEntity.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
        //        sqEntity.SQQty = item.SQQty;
        //        sqEntity.SQPrice = Convert.ToString(item.Price);
        //        sqEntity.SQDiscount = item.SQDiscount;
        //        //sqdEntity.PriceExcTax = item.PriceExcludedTax ?? null as decimal?;
        //        //sqdEntity.PriceIncTax = item.PriceIncludedTax ?? null as decimal?;
        //        if (IsDiscountEditable == true)
        //        {
        //            sqEntity.IsAllowEditDiscount = true;
        //        }
        //        else
        //        {
        //            sqEntity.IsAllowEditDiscount = false;
        //        }
        //        if (IsPriceEditable == true)
        //        {
        //            sqEntity.IsAllowEditPrice = true;
        //        }
        //        else
        //        {
        //            sqEntity.IsAllowEditPrice = false;
        //        }
        //        if (IsHideDiscColumn == true)
        //        {
        //            sqEntity.IsHideDisc = false;
        //        }
        //        else
        //        {
        //            sqEntity.IsHideDisc = true;
        //        }
        //        //  SQDEntity.GSTRate = item.GSTRate;
        //        sqEntity.SQAmount = item.SQAmount;

        //        SQDetailsEntity.Add(sqEntity);
        //    }

        //}
        /// <summary>
        /// This method is used to validate purchase quotation on Save
        /// </summary>
        /// <returns></returns>
        public string ValidateSalesQuotation()
        {
            string date = this.DateFormat as string;
            bool isValidData = false;
            string msg = string.Empty;
            if (SelectedCustomerID == 0)
            {
                return msg = "Please select Customer Name";
            }
            if (QuotationDateStr == null)
            {
                return msg = "Please enter Quotation Date";
            }
            if (SQDetailsEntity.Count <= 0)
            {
                return msg = "Please add Products and Services";
            }

            foreach (var item in SQDetailsEntity)
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

                    //if (System.Text.RegularExpressions.Regex.IsMatch(item.SQPrice.Trim(), @"[^0-9]"))
                    //{
                    //    return msg = "Please enter valid price";
                    //}
                    if (item.SQQty > 0 && item.SelectedPSID != null && Convert.ToDecimal(item.SQPrice) >= 0)
                    {
                        isValidData = true;
                    }

                }
            }
     
                //try
                //{
                //    if (!string.IsNullOrEmpty(QuotationDate.ToString()) && !string.IsNullOrWhiteSpace(QuotationDate.ToString()))
                //    {

                //        var Start = (DateTime.ParseExact(QuotationDate.ToString(), date, CultureInfo.InvariantCulture));
                //        this.DateErrors = "";
                    
                //    }
                    
                //}
                //catch (Exception ex)
                //{
                //    this.DateErrors = "Please enter the date in " + date + " format!";
                    
                //}
            
           
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
            IsNew = true;
            ID = 0;
            SelectedCustomerID = 0;
            SelectedSalesmanID = 0;
            BillToAddress = string.Empty;
            ShipToAddress = string.Empty;
            ValidForDays = 0;
            QuotationNo = GenerateNewQuotationNo();
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
            RubberStampSI = false;
            RubberStampSO = false;
            SharedValues.CustomerDiscount = null;
            CustomerEnabled = true;// added on 23 may 2017
            SalesQuotationEntity = new SalesQuotationEntity();
            SQDetailsEntity.Clear();
            // SQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            ProductAndServices = ProductAndServices.OrderBy(x=>x.PSName).Where(x => x.IsInActive == "N").ToObservable();
            LstCustomers = LstCustomers.OrderBy(x=>x.FirstName).Where(x => x.Inactive != "Y").ToList();
            var row = new DataGridViewModel(ProductList.Where(x=>x.IsInActive=="N").ToList());
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
            //row.GSTRateStr = Convert.ToString(TaxRate) +"%";
            SQDetailsEntity.Add(row);
            OnPropertyChanged("SQDetailsEntity");

        }

        private void GetOptionsData()
        {  
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
        public void GetDuplicateSQ()
        {
            IsNew = true;
            SQErrors = string.Empty;
            QuotationNo = GenerateNewQuotationNo();
            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            CustomerEnabled = true;// added on 23 may 2017
        }

        #endregion
    }
}
