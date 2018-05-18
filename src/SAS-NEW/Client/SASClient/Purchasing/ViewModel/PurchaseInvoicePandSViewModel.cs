﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.ViewModel
{
    using SDN.Common;
    using System.Collections.ObjectModel;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    using SDN.Purchasing.Services;
    using System.Windows.Input;
    using System.ComponentModel;
    using Product.Services;
    using System.Windows;
    using Microsoft.Practices.ServiceLocation;
    using View;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.Events;
    using SASClient.CloseRequest;
    using Microsoft.Practices.Prism.Commands;
    using Settings.Services;
    using System.Globalization;
    using Sales.Services;

    public class PurchaseInvoicePandSViewModel: PurchaseInvoiceEntity
    {
        #region "Private members"
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _DateErrors;
        private DateTime? _InvoiceDateCalender;
        private DateTime? _PayDueDateCalender;
        ICompanyDetails CompanyD = new CompanyDetails();
        //private ObservableCollection<PandSDetailsModel> pands;
        private string currencyName;
        //  private string taxName;
        private ObservableCollection<DataGridViewModel> pqDetailsEntity;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private IPurchaseInvoicePandSRepository pqRepository = new PurchaseInvoicePandSRepository();
        public IPandSDetailsRepository pandsRepository = new PandSDetailsRepository();
        private ISupplierRepository supplierRepository = new SupplierRepository();
        public ObservableCollection<DataGridViewModel> lst;
        private DataGridViewModel pqdEntity;
        private PurchaseInvoiceEntity purchaseInvoiceEntity;
        //private PurchaseInvoiceDetailEntity selectedPandS;
        StackList listitem = new StackList();
        private int supplierId;

        private decimal? taxRate;
        private static IEnumerable<PandSListModel> ProductList;
        private ObservableCollection<PandSListModel> productAndServices;
        // private ObservableCollection<PandSDetailsModel> productAndServices;
        //private int? pqQty;
        //private decimal? pqPrice;
        //private decimal? pqAmount;
        //private decimal? pqDiscount;
        //private decimal? gstRate;
        private int? defaultPSID;

        private decimal? amountBeforeTax;
        private decimal? taxAmount;
        private string pqErrros;
        private bool isNew;
        private bool allFieldsReadonly;
        private bool allFieldsEnabled;
        private int decimalPlaces;
        private string dateFormat;
        private System.Windows.Visibility visibilityForImage;
        private string statusString;
        #endregion

        #region "Public Properties"
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
        public DateTime? PayDueDateCalender
        {
            get
            {
                return _PayDueDateCalender;
            }
            set
            {
                _PayDueDateCalender = value;
                OnPropertyChanged("PayDueDateCalender");
            }
        }
        public DateTime? InvoiceDateCalender
        {
            get
            {
                return _InvoiceDateCalender;
            }
            set
            {
                _InvoiceDateCalender = value;
                OnPropertyChanged("InvoiceDateCalender");
            }
        }
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


        public DataGridViewModel PQDEntity
        {
            get
            {
                return pqdEntity;
            }
            set
            {
                if (pqdEntity != value)
                {
                    pqdEntity = value;
                    OnPropertyChanged("PQDEntity");
                }
            }
        }
        public string TandC
        {
            get; set;
        }

        public PurchaseInvoiceEntity PurchaseInvoiceEntity
        {
            get
            {
                return purchaseInvoiceEntity;
            }
            set
            {
                if (purchaseInvoiceEntity != value)
                {
                    purchaseInvoiceEntity = value;
                    OnPropertyChanged("PurchaseInvoiceEntity");
                }
            }
        }

        public ObservableCollection<DataGridViewModel> PQDetailsEntity
        {
            get
            {
                return pqDetailsEntity;
            }
            set
            {
                if (pqDetailsEntity != value)
                {
                    pqDetailsEntity = value;
                    OnPropertyChanged("PQDetailsEntity");
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
        private bool supplierEnabled;
        public bool SupplierEnabled
        {
            get { return supplierEnabled; }
            set
            {
                supplierEnabled = value;
                OnPropertyChanged("SupplierEnabled");
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

        public string PQErrors
        {
            get
            {
                return pqErrros;
            }
            set
            {
                if (pqErrros != value)
                {
                    pqErrros = value;
                    OnPropertyChanged("PQErrors");
                }
            }
        }

        public int SelectedSupplierID
        {
            get
            {
                return supplierId;
            }
            set
            {
                if (supplierId != value)
                {
                    supplierId = value;
                    OnPropertyChanged("SelectedSupplierID");
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
                return jumptoNextrow = false;
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


        #endregion

        #region BackGround Worker
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
            RefreshData();
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
        }



        #endregion

        #region "Constructors"

        //public static PurchaseInvoiceViewModel _instance;

        //public static PurchaseInvoiceViewModel GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new PurchaseInvoiceViewModel();
        //    }

        //    return _instance;
        //}
        //  private static IEnumerable<PandSDetailsModel> ProductList;
        private bool? jumptoNextrow;
        private bool? _disableTab;

        public PurchaseInvoicePandSViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;

            SaveCommand = new RelayCommand(SavePurchaseInvoice, CanSave);
            SupplierSelectionChangedCommand = new RelayCommand(OnSupplierChange);
            NewPQCommand = new RelayCommand(OnNewPQ);
            DuplicateCommand = new RelayCommand(OnDuplicatePQ, CanDuplicate);
            IncludeTaxCheckedCommand = new RelayCommand(OnIncludeTax);
            ExcludeTaxCheckedCommand = new RelayCommand(OnExcludeTax);
            DeleteCommand = new RelayCommand(OnDeletePQ, CanDeletePQ);
            NavigateToClientCommand = new RelayCommand(NavigatetoSupplier, CanNavigate);
            PaymentToSupplierCommand = new RelayCommand(OnPaymentToSupplier, CanPaymentToSupplier);
            PurchaseInvoiceEntity = new PurchaseInvoiceEntity();
            PQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            NavigateToBECommand = new RelayCommand(OnNavigateToBE);
            CloseCommand = new DelegateCommand(Close);
            int minHeight = 300;
            int headerRows = 369;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 80;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.PIFormGridHeight = minHeight;

            #region getting Options details
            GetOptionsData();
            #endregion

            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            this.InvoiceDate = DateTime.Now.Date;

            LoadSupplierBackground();

            //ProductList = pandsRepository.GetAllPandS().OrderBy(e => e.PSName);
            //ProductAndServices = new ObservableCollection<PandSDetailsModel>(ProductList);
            ProductList = pandsRepository.GetPandSComboList();
            ProductAndServices = new ObservableCollection<PandSListModel>(ProductList).OrderBy(x => x.PSName).ToObservable();

            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {
                    MustCompare = false;
                    SupplierEnabled = false;//added on 23may2017
                    GetPurchaseInvoice(SharedValues.NewClick);
                }
                else if (SharedValues.NewClick == "New")
                {
                    MustCompare = true;
                    SupplierEnabled = true;//added on 23may2017
                    GetNewPQ();

                }
            }
            Mouse.OverrideCursor = null;

        }

        #endregion

        #region Relay Commands
        public ICommand CloseCommand { get; set; }
        public RelayCommand NavigateToBECommand { get; set; }
        public RelayCommand ConvertToPOCommand { get; set; }
        public RelayCommand ConvertToPICommand { get; set; }
        public RelayCommand AddNewRowCommand { get; set; }
        public RelayCommand SupplierSelectionChangedCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand PQDiscountTextChangedCommand { get; set; }
        public RelayCommand PQQuantityTextChangedCommand { get; set; }
        public RelayCommand NewPQCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand DuplicateCommand { get; set; }
        public RelayCommand IncludeTaxCheckedCommand { get; set; }
        public RelayCommand ExcludeTaxCheckedCommand { get; set; }
        public RelayCommand NavigateToClientCommand { get; set; }
        public RelayCommand PaymentToSupplierCommand { get; set; }
        #endregion

        #region "Member Functions"

        public void RefreshData()
        {
            #region "To get Category Contents"

            var cat1 = pqRepository.GetCategoryContent("PITC".Trim());

            if (cat1 != null)
            {
                this.TermsAndConditions = Convert.ToString(cat1);
                TandC = Convert.ToString(cat1);
            }
            #endregion

            #region "Get Supplier Details"

            var suppliers = supplierRepository.GetAllSupplier();
            if (suppliers != null)
            {
                LstSuppliers = suppliers.OrderBy(e => e.SupplierName).ToList();
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

        void OnNavigateToBE(object param)
        {
            //MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            //if (result == MessageBoxResult.Yes)
            //{
            //    Mouse.OverrideCursor = Cursors.Wait;
            //    string msg = ValidatePurchaseInvoice();
            //    if (msg != string.Empty)
            //    {
            //        PQErrors = msg;
            //        Mouse.OverrideCursor = null;
            //        return;
            //    }

            //    PQErrors = string.Empty;
            //    PurchaseInvoiceForm PQForm = GetDataIntoModel();

            //    int i = 0;
            //    if (IsNew == true)
            //    {
            //        i = pqRepository.AddUpdateInvoice(PQForm);
            //    }
            //    else
            //    {
            //        i = pqRepository.UpdationInvoice(PQForm);
            //    }
            //    if (i > 0)
            //    {
            //        //GetNewPQ();
            //        SupplierEnabled = false;// added on 23 may 2017
            //        IsNew = false;// added on 23 may 2017

            //    }
            //    Mouse.OverrideCursor = null;
            //}
            SharedValues.ScreenCheckName = "Purchases Invoice(Business Expenses)";
            SharedValues.ViewName = "Purchase Invoice Business Expenses";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.NewClick = "New";
            var mainview = ServiceLocator.Current.GetInstance<PurchaseInvoiceBEView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoice Form (Business Expenses)");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }


        }
        void NavigatetoSupplier(object param)
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Suppliers Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        /// <summary>
        /// This method is used to get new pq
        /// </summary>
        /// <param name="param"></param>
        public void OnNewPQ(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            GetNewPQ();
            Mouse.OverrideCursor = null;
        }

        /// <summary>
        /// This method is used to get duplicate pq
        /// </summary>
        /// <param name="param"></param>
        public void OnDuplicatePQ(object param)
        {
            GetDuplicatePQ();
        }

        public bool CanNavigate(object param)
        {
            if (SelectedSupplierID != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            foreach (var item in PQDetailsEntity)
            {
                if (item.SelectedPSID != null)
                {
                    item.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
                    if (SharedValues.IsIncludeTax == true)
                    {
                        item.ExcludingTax = false;
                        item.PQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.PriceIncTax), DecimalPlaces));
                    }
                    else
                    {
                        item.ExcludingTax = false;
                        item.PQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.PriceExcTax), DecimalPlaces));
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
            foreach (var item in PQDetailsEntity)
            {
                if (item.SelectedPSID != null)
                {
                    item.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
                    if (SharedValues.IsIncludeTax == false)
                    {
                        SharedValues.IsIncludeTax = false;
                        item.ExcludingTax = true;
                        item.PQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.PriceExcTax), DecimalPlaces));
                    }
                    else
                    {
                        SharedValues.IsIncludeTax = true;
                        item.ExcludingTax = true;
                        item.PQPrice = Convert.ToString(Math.Round(Convert.ToDecimal(item.PriceIncTax), DecimalPlaces));

                    }
                }

                // item.OnQtyChangeTotalAmt(true); //Exceluded tax=True

            }
            //  CalculateTotal(true);
        }

        public void OnPaymentToSupplier(object param)
        {
            SavePurchaseInvoice(null);
            SharedValues.ScreenCheckName = "Payment to Suplier";
            SharedValues.ViewName = "Payment to Supplier";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.CollectCommand = this.SelectedSupplierID.ToString();
            SharedValues.NewClick = "New";
            SharedValues.getValue = "PaymentToSupplierTab";
            var mainview = ServiceLocator.Current.GetInstance<PaymentToSupplierView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payment To Supplier Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        /// <summary>
        /// This method is used to save and edit pq
        /// </summary>
        /// <param name="param"></param>
        public void SavePurchaseInvoice(object param)
        {

            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                string msg = ValidatePurchaseInvoice();
                if (msg != string.Empty)
                {
                    PQErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                PQErrors = string.Empty;
                PurchaseInvoiceForm PQForm = GetDataIntoModel();

                int i = 0;
                if (IsNew == true)
                {
                    i = pqRepository.AddUpdateInvoice(PQForm);
                }
                else
                {
                    i = pqRepository.UpdationInvoice(PQForm);
                }
                if (i > 0)
                {
                    //GetNewPQ();
                    SupplierEnabled = false;// added on 23 may 2017
                    IsNew = false;// added on 23 may 2017
                }
                Mouse.OverrideCursor = null;
            }
        }

        public bool CanPaymentToSupplier(object param)
        {
            if (SelectedSupplierID == 0 || InvoiceDateStr == null || PaymentDueDateStr == null
               || PQDetailsEntity.Count() == 0)
            {
                return false;
            }
            else if (PIStatus == Convert.ToByte(PI_Status.Cancelled))
            {
                return false;
            }
            else if (PIStatus == Convert.ToByte(PI_Status.Paid))
            {
                return false;
            }
            else if (PIStatus == Convert.ToByte(PI_Status.Adjusted))
            {
                return false;
            }
            else
            {
                return true;
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
                case "InvoiceDateCalender":
                    FillStartDate();
                    break;
                case "PayDueDateCalender":
                    FillStartDate1();
                    break;

            }

            base.OnPropertyChanged(name);
        }
        void FillStartDate()
        {
            string date = this.DateFormat as string;
            InvoiceDateStr = Convert.ToDateTime(this.InvoiceDateCalender).ToString(date);
          
        }
        void FillStartDate1()
        {
            string date = this.DateFormat as string;
            PaymentDueDateStr = Convert.ToDateTime(this.PayDueDateCalender).ToString(date);

        }
        public bool CanSave(object param)
        {
            string date = this.DateFormat as string;
            var c = CompanyD.GetCompanyDetails().Comp_year_start_date;

            //if (SelectedSupplierID == 0 || InvoiceDateStr == null || PaymentDueDateStr == null
            //   || PQDetailsEntity.Where(e=>e.SelectedPSID!=null).Count() == 0)
            //{
            //    return false;
            //}

            if (SelectedSupplierID == 0 || InvoiceDateStr == null || PaymentDueDateStr == null
               || PQDetailsEntity.Count() == 0)
            {
                return false;
            }
            else if (PIStatus == Convert.ToByte(PI_Status.Cancelled))
            {
                return false;
            }
            else if (PIStatus == Convert.ToByte(PI_Status.Paid))
            {
                return false;
            }
            else if (PIStatus == Convert.ToByte(PI_Status.Adjusted))
            {
                return false;
            }
            else if (InvoiceDateStr != null && PaymentDueDateStr != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(InvoiceDateStr) && !string.IsNullOrWhiteSpace(InvoiceDateStr) && !string.IsNullOrEmpty(PaymentDueDateStr) && !string.IsNullOrWhiteSpace(PaymentDueDateStr))
                    {

                        //item.StartDate = item.StartDate.Replace('.', '/');
                        //item.StartDate = item.StartDate.Replace('-', '/');
                        //item.EndDate = item.EndDate.Replace('.', '/');
                        //item.EndDate = item.EndDate.Replace('-', '/');
                        var Invoicedate = (DateTime.ParseExact(InvoiceDateStr, date, CultureInfo.InvariantCulture));
                        var Payduedate = (DateTime.ParseExact(PaymentDueDateStr, date, CultureInfo.InvariantCulture));

                        this.DateErrors = "";
                        //var End = (DateTime.ParseExact(item.EndDate, date, CultureInfo.InvariantCulture));
                        if (Invoicedate < c || Payduedate < c)
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

        public bool CanNavigateToBE(object param)
        {
            if (SelectedSupplierID == 0 || InvoiceDate == null || PaymentDueDate == null)
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

        public bool CanDeletePQ(object param)
        {
            if (IsNew == true)
            {
                return false;
            }
            else if (PIStatus == Convert.ToByte(PI_Status.Cancelled))
            {
                return false;
            }
            else if (PIStatus == Convert.ToByte(PI_Status.Paid))
            {
                return false;
            }
            else if (PIStatus == Convert.ToByte(PI_Status.Adjusted))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// This method is used to delete PQ
        /// </summary>
        /// <param name="param"></param>
        public void OnDeletePQ(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                int i = pqRepository.DeleteInvoice(InvoiceNo);
                if (i == Convert.ToByte(PI_Status.Cancelled))
                {
                    PQErrors = string.Empty;
                    GetNewPQ();
                }
                else
                {
                    PQErrors = "Cannot delete Purchase Invoice";
                    AllFieldsEnabled = false;
                    AllFieldsReadonly = true;
                    SupplierEnabled = false;
                }


                Mouse.OverrideCursor = null;
            }
        }


        /// <summary>
        /// This method is used to get supplier details on selection
        /// </summary>
        /// <param name="param"></param>
        public void OnSupplierChange(object param)
        {
            GetSupplierDetails();
        }

        public PurchaseInvoiceForm GetDataIntoModel()
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            PurchaseInvoiceForm PQForm = new PurchaseInvoiceForm();
            PQForm.InvoiceDetails = new List<PurchaseInvoiceDetailEntity>();
            PurchaseInvoiceEntity model = new PurchaseInvoiceEntity();
            
            model.InvoiceDate = DateTime.ParseExact(this.InvoiceDateStr, oData.DateFormat, null);
            model.TotalBeforeTax = this.TotalBeforeTax;
            model.TotalTax = this.TotalTax;
            model.TotalAfterTax = this.TotalAfterTax;
            model.PaymentDueDate = DateTime.ParseExact(this.PaymentDueDateStr, oData.DateFormat, null);
            model.OurPONo = this.OurPONo;
            if(!string.IsNullOrEmpty(InvoiceNo))
            {
                model.InvoiceNo = this.InvoiceNo;
            }
            else
            {
                model.InvoiceNo = this.OurPONo;
                this.InvoiceNo = this.OurPONo;
            }
            model.SupplierID = this.SelectedSupplierID;

            model.TermsAndConditions = this.TermsAndConditions;
            if (ExcludingTax == true)
            {
                model.ExcIncGST = false;
            }
            else
            {
                model.ExcIncGST = true;
            }

            PQForm.Invoice = model;

            foreach (var item in PQDetailsEntity)
            {
                PurchaseInvoiceDetailEntity pqEntity = new PurchaseInvoiceDetailEntity();
                pqEntity.PINo = Convert.ToString(item.SelectedPSID);
                pqEntity.PandSCode = item.PandSCode;
                pqEntity.PandSName = item.PandSName;
                pqEntity.PIQty = item.PQQty;
                pqEntity.PIPrice = item.PQPrice;
                pqEntity.PIDiscount = item.PQDiscount;
                pqEntity.GSTRate = item.GSTRate;
                pqEntity.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
                pqEntity.PIAmount = item.PQAmount;
                pqEntity.PIType = "PI";
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID) > 0)
                {
                    PQForm.InvoiceDetails.Add(pqEntity);
                }
            }
            return PQForm;
        }

        /// <summary>
        /// This method is used to calculate total amount of PandS with tax
        /// </summary>
        public void CalculateTotal(bool excludeTax)
        {
            decimal? totalBeforeTax = 0;
            decimal? mTotalTax = 0;
            decimal? mTotalAfterTax = 0;
            if (PQDetailsEntity != null)
            {
                totalBeforeTax = PQDetailsEntity.Sum(e => e.AmountBeforeTax);
                TotalBeforeTax = Math.Round(Convert.ToDecimal(totalBeforeTax), DecimalPlaces);
                mTotalTax = PQDetailsEntity.Sum(e => e.TaxAmount);

                TotalTax = Math.Round(Convert.ToDecimal(mTotalTax), DecimalPlaces);

                mTotalAfterTax = totalBeforeTax + mTotalTax;
                TotalAfterTax = Math.Round(Convert.ToDecimal(mTotalAfterTax), DecimalPlaces);
                TotalBeforeTaxStr = Convert.ToString(TotalBeforeTax);
                TotalTaxStr = Convert.ToString(TotalTax);
                TotalAfterTaxStr = Convert.ToString(TotalAfterTax);
            }
        }


        /// <summary>
        /// This method is used to get supplier details
        /// </summary>
        private void GetSupplierDetails()
        {
            //var sup = supplierRepository.GetAllSupplier().Where(s => s.ID == SelectedSupplierID).SingleOrDefault();
            //if (sup != null)
            //{
            //    this.BillToAddress = sup.ShipAddressLine1 + " " + sup.ShipAddressLine2 + " " + sup.ShipCity;
            //    this.ShipToAddress = sup.Sup_Bill_to_line1 + " " + sup.Sup_Bill_to_line2 + " " + sup.Sup_Bill_to_city;

            //}
            if (SelectedSupplierID != 0)
            {
                var sup = supplierRepository.GetSupplierList().Where(s => s.ID == SelectedSupplierID).SingleOrDefault();
                SharedValues.SelectedSupId = SelectedSupplierID;
                if (sup != null)
                {
                    Sup_Balance = sup.Balance;
                    Sup_CreditLimitAmount = sup.CreditLimitAmount;
                }
            }
        }

        private string GenerateNewInvoiceNo()
        {
            var NewPqNo = pqRepository.GetLastInvoiceNo() + 1;
            return "PO-" + NewPqNo.ToString();
        }
        //private void GenerateNewPurchaseInvoiceNo()
        //{
            
            
        //}

        public int ManageDuplicatePandS()
        {
            int rowFocusindex = -1;
            lst = new ObservableCollection<DataGridViewModel>();
            lst = PQDetailsEntity;

            var query = lst.GroupBy(x => x.SelectedPSID)
              .Where(g => g.Count() > 1)
              .ToList();
            if (query.Count > 0 && PQDetailsEntity.Count > 1)
            {

                var obj1 = query[0].ElementAt(0);
                var obj2 = query[0].ElementAt(1);
                int? qty = 1;
                decimal? productPrice2 = 0;
                decimal? discountP2 = 0;
                qty = query[0].ElementAt(0).PQQty + query[0].ElementAt(1).PQQty;
                productPrice2 = Convert.ToDecimal(query[0].ElementAt(1).PQPrice);
                discountP2 = query[0].ElementAt(1).PQDiscount;

                var index1 = lst.IndexOf(query[0].ElementAt(0));
                var index2 = lst.IndexOf(query[0].ElementAt(1));

                if (productPrice2 != null)
                {
                    obj1.PQQty = qty;
                    obj1.PQPrice = Convert.ToString(productPrice2);
                    obj1.PQDiscount = discountP2;
                    PQDetailsEntity[index1] = obj1;
                    var row = new DataGridViewModel(ProductList);
                    //row.PQQty = 1;
                    //row.GSTRate = TaxRate;
                    //row.GSTRateStr = Convert.ToString(TaxRate) + "%";
                    PQDetailsEntity[index2] = row;
                    rowFocusindex = index2;
                }
                //for (int i = 0; i < 2; i++)
                //{ 
                //    var p = PQDetailsEntity.Where(e => e.SelectedPSID == obj2.SelectedPSID ).FirstOrDefault();
                //    if (p.PQPrice == null)
                //    {
                //        PQDetailsEntity.Remove(p);
                //    }
                //}

                OnPropertyChanged("PQDetailsEntity");

            }
            else
            {
                int count = PQDetailsEntity.Count(x => x.SelectedPSID == null);
                if (count == 0)
                {
                    var row = new DataGridViewModel(ProductList);
                    //row.PQQty = 1;
                    //row.GSTRate = TaxRate;
                    //row.GSTRateStr = Convert.ToString(TaxRate) + "%";
                    PQDetailsEntity.Add(row);
                    OnPropertyChanged("PQDetailsEntity");
                    rowFocusindex = -1;
                }
                else
                {
                    var emptyRow = lst.Where(y => y.SelectedPSID == null).FirstOrDefault();
                    rowFocusindex = PQDetailsEntity.IndexOf(emptyRow);
                }


            }

            return rowFocusindex;
        }

        public void GetPurchaseInvoice(string pqNo)
        {
            // Mouse.OverrideCursor = Cursors.Wait;
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            PurchaseInvoiceForm pqf = pqRepository.GetPurchaseInvoice(pqNo);

            this.ID = pqf.Invoice.ID;
            this.InvoiceNo = pqf.Invoice.InvoiceNo;
            this.OurPONo = pqf.Invoice.OurPONo;
            this.InvoiceDateStr = pqf.Invoice.InvoiceDate.ToString(oData.DateFormat);
            if(PaymentDueDate == null)
            {
                this.PaymentDueDate = pqf.Invoice.PaymentDueDate;
            }
            else
            {
                DateTime Dateinstr = (DateTime)pqf.Invoice.PaymentDueDate;
                this.PaymentDueDateStr = Dateinstr.ToString(oData.DateFormat);
            }
            

            this.SelectedSupplierID = pqf.Invoice.SupplierID;
            SharedValues.SelectedSupId = this.SelectedSupplierID;
            if (this.SelectedSupplierID > 0)
            {
                GetSupplierDetails();
            }

            this.TermsAndConditions = pqf.Invoice.TermsAndConditions;

            this.TotalBeforeTax = pqf.Invoice.TotalBeforeTax;
            this.TotalTax = pqf.Invoice.TotalTax;
            this.TotalAfterTax = pqf.Invoice.TotalAfterTax;
            this.TotalBeforeTaxStr = Convert.ToString(this.TotalBeforeTax);
            this.TotalTaxStr = Convert.ToString(TotalTax);
            this.TotalAfterTaxStr = Convert.ToString(TotalAfterTax);

            if (pqf.Invoice.ExcIncGST == true)
            {
                ExcludingTax = false;
                IncludingTax = true;
                //  PQDEntity.GSTRate = 0;
            }
            else
            {
                ExcludingTax = true;
                IncludingTax = false;
                // PQDEntity.GSTRate = TaxRate;
            }

            if (this.PIStatus == Convert.ToByte(PI_Status.Paid))
            {
                AllFieldsReadonly = true;
                AllFieldsEnabled = false;
            }
            else
            {
                AllFieldsReadonly = false;
                AllFieldsEnabled = true;
                LstSuppliers = supplierRepository.GetAllSupplier().Where(s => s.IsInActive != "Y").ToList();
                ProductAndServices = ProductAndServices.OrderBy(x => x.PSName).Where(x => x.IsInActive != "Y").ToObservable();
            }

            this.PIStatus = pqf.Invoice.PIStatus;
            if (PIStatus == Convert.ToByte(PI_Status.Cancelled))
            {
                StatusString = "Cancelled";
                VisibilityForImage = Visibility.Visible;
                AllFieldsEnabled = false;
                AllFieldsReadonly = true;

            }
            else if (PIStatus == Convert.ToByte(PI_Status.Paid))
            {
                StatusString = "    Paid";
                VisibilityForImage = Visibility.Visible;
                AllFieldsEnabled = false;
                AllFieldsReadonly = true;

            }
            else if (PIStatus == Convert.ToByte(PI_Status.Adjusted))
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


            SupplierEnabled = false;// added on 23 may 2017
            this.PQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            if (pqf.InvoiceDetails.Count()>0)
            {
                foreach (var item in pqf.InvoiceDetails)
                {
                    DataGridViewModel pqEntity = new DataGridViewModel(ProductList);
                    pqEntity.SelectedPSID = Convert.ToString(item.PINo);
                    pqEntity.PandSCode = item.PandSCode;
                    pqEntity.PandSName = item.PandSName;
                    pqEntity.GSTRate = Math.Round(Convert.ToDecimal(item.GSTRate), DecimalPlaces);
                    pqEntity.GSTRateStr = Convert.ToString(pqEntity.GSTRate) + "%";
                    pqEntity.PQQty = item.PIQty;
                    pqEntity.PQPrice = Convert.ToString(item.Price);
                    pqEntity.PQDiscount = item.PIDiscount;

                    //  PQDEntity.GSTRate = item.GSTRate;
                    pqEntity.PQAmount = item.PIAmount;

                    PQDetailsEntity.Add(pqEntity);
                }
            }
            else
            {
                var row = new DataGridViewModel(ProductList.Where(x => x.IsInActive == "N").ToList());
                
                PQDetailsEntity.Add(row);
                OnPropertyChanged("PQDetailsEntity");
            }

        }

        /// <summary>
        /// This method is used to validate purchase quotation on Save
        /// </summary>
        /// <returns></returns>
        public string ValidatePurchaseInvoice()
        {
            bool isValidData = false;
            string msg = string.Empty;
            if (SelectedSupplierID == 0)
            {
                return msg = "Please select Supplier Name";
            }
            if (InvoiceDateStr == null)
            {
                return msg = "Please enter Invoice Date";
            }
            if (PaymentDueDateStr == null)
            {
                return msg = "Please enter Payment Due Date";
            }
            //if (PQDetailsEntity.Count <= 0)
            //{
            //    return msg = "Please add Products and Services";
            //}

            foreach (var item in PQDetailsEntity)
            {
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID) > 0)
                {
                    if (item.PQQty == 0 && item.SelectedPSID != null)
                    {
                        return msg = "Quantity should be greater than zero";
                    }
                    if (item.PQDiscount != null)
                    {
                        if (!(item.PQDiscount >= 0 && item.PQDiscount <= 100))
                        {
                            return msg = "Discount should be between 0 to 100";
                        }
                    }

                    if (!string.IsNullOrEmpty(item.PQPrice))
                    {
                        if (Convert.ToDecimal(item.PQPrice) <= 0)
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

                    //if (System.Text.RegularExpressions.Regex.IsMatch(item.PQPrice.Trim(), @"[^0-9]"))
                    //{
                    //    return msg = "Please enter valid price";
                    //}
                    //if (item.SelectedPSID != null && Convert.ToDecimal(item.PQPrice) >= 0)
                    //{
                    //    isValidData = true;
                    //}
                }
            }
            //if (isValidData == false)
            //{
            //    msg = "Please add valid product and services";
            //}
            return msg;
        }


        /// <summary>
        /// This method is used to get new PQ
        /// </summary>
        public void GetNewPQ()
        {
           
            VisibilityForImage = Visibility.Collapsed;
            IsNew = true;
            ID = 0;
            SelectedSupplierID = 0;
            BillToAddress = string.Empty;
            ShipToAddress = string.Empty;
            // ValidForDays = 0;
            OurPONo = GenerateNewInvoiceNo();
            TermsAndConditions = TandC;
            TotalBeforeTax = 0;
            TotalTax = 0;
            TotalAfterTax = 0;
            TotalBeforeTaxStr = Convert.ToString(0);
           
            TotalTaxStr = Convert.ToString(0);
            TotalAfterTaxStr = Convert.ToString(0);
            PQErrors = string.Empty;
            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            SupplierEnabled = true;// added on 23 may 2017
            this.PaymentDueDateStr = null;
            this.InvoiceNo = "PI-" + pqRepository.GetLatestInvoiceNo();
            PurchaseInvoiceEntity = new PurchaseInvoiceEntity();
            PQDetailsEntity.Clear();

            LstSuppliers = supplierRepository.GetAllSupplier().Where(s => s.IsInActive != "Y").ToList();
            ProductAndServices = ProductAndServices.OrderBy(x => x.PSName).Where(x => x.IsInActive == "N").ToObservable();
            // PQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            var row = new DataGridViewModel(ProductList.Where(x => x.IsInActive == "N").ToList());
            //row.PQQty = 1;
            //row.PQDiscount = 0;

            //row.GSTRate = TaxRate;
            //row.GSTRateStr = Convert.ToString(TaxRate) + "%";
            PQDetailsEntity.Add(row);
            OnPropertyChanged("PQDetailsEntity");
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

                if (lstOptions.PSQtyJumNextLine != null)
                {
                    //  QtyJumptoNextRow = lstOptions.PSQtyJumNextLine;
                    QtyJumptoNextRow = false;
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
        /// This method is used to get duplicate pq
        /// </summary>
        public void GetDuplicatePQ()
        {
            VisibilityForImage = Visibility.Collapsed;
            IsNew = true;
            PQErrors = string.Empty;
            OurPONo = GenerateNewInvoiceNo();
            InvoiceNo = string.Empty;
            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            SupplierEnabled = true;// added on 23 may 2017
        }

        #endregion
    }
}