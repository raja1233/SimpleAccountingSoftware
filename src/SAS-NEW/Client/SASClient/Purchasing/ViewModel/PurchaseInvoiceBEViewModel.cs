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
    using Customers.Services;
    using SASClient.CashBank.Services;
    using SASClient.CloseRequest;
    using Microsoft.Practices.Prism.Commands;
    using Settings.Services;
    using System.Globalization;
 

    public class PurchaseInvoiceBEViewModel: PurchaseInvoiceEntity
    {
        #region "Private members"

        //private ObservableCollection<PandSDetailsModel> pands;
        private string currencyName;
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _DateErrors;
        private DateTime? _InvoiceDateCalender;
        private DateTime? _PayDueDateCalender;
        ICompanyDetails CompanyD = new CompanyDetails();
        //  private string taxName;
        private ObservableCollection<AccountDataGridViewModel> beDetailsEntity;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private IPurchaseInvoiceBERepository pqRepository = new PurchaseInvoiceBERepository();
        public IPandSDetailsRepository pandsRepository = new PandSDetailsRepository();
        private ISupplierRepository supplierRepository = new SupplierRepository();
        public ObservableCollection<AccountDataGridViewModel> lst;
        //private AccountDataGridViewModel pqdEntity;
        private PurchaseInvoiceEntity purchaseInvoiceEntity;
        private IReceiveMoneyRepository rmRepository = new ReceiveMoneyRepository();
        ICustomerRepository customerRepository = new CustomerRepository();
        StackList listitem = new StackList();
        private int selectedSupplierId;

        private decimal? taxRate;
        private ObservableCollection<AccountsEntity> accounts;
        private static IEnumerable<AccountsEntity> AccountsList;
        private ObservableCollection<TaxModel> taxes;
        private static IEnumerable<TaxModel> TaxList;
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
        private bool? isDiscountEditable;
        private bool? isHideDiscColumn;
        private bool? isPriceEditable;
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
        
        public ObservableCollection<AccountDataGridViewModel> BEDetailsEntity
        {
            get
            {
                return beDetailsEntity;
            }
            set
            {
                if (beDetailsEntity != value)
                {
                    beDetailsEntity = value;
                    OnPropertyChanged("BEDetailsEntity");
                }
            }
        }
        //  private ObservableCollection<DataGridViewModel> lstItems = new ObservableCollection<DataGridViewModel>();
        public ObservableCollection<TaxModel> Taxes
        {
            get
            {
                return taxes;
            }
            set
            {
                if (taxes != value)
                {
                    taxes = value;
                    OnPropertyChanged("Taxes");
                }
            }
        }

        public ObservableCollection<AccountsEntity> Accounts
        {
            get
            {
                return accounts;
            }
            set
            {
                if (accounts != value)
                {
                    accounts = value;
                    OnPropertyChanged("Accounts");
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
                return selectedSupplierId;
            }
            set
            {
                selectedSupplierId = value;
                    OnPropertyChanged("SelectedSupplierID");
                
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
        private static IEnumerable<PandSDetailsModel> ProductList;
        private bool? jumptoNextrow;
        private bool? _disableTab;

        public PurchaseInvoiceBEViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
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
            //DeleteCommand = new RelayCommand(OnDeletePQ, CanDeletePQ);
            NavigateToClientCommand = new RelayCommand(NavigatetoSupplier, CanNavigate);
            PaymentToSupplierCommand = new RelayCommand(OnPaymentToSupplier, CanPaymentToSupplier);
            NavigateToPICommand= new RelayCommand(OnNavigateToPI);
            PurchaseInvoiceEntity = new PurchaseInvoiceEntity();
            BEDetailsEntity = new ObservableCollection<AccountDataGridViewModel>();
            CloseCommand = new DelegateCommand(Close);
            AccountsList = rmRepository.GetAccountDetails();
            //change in accounts type show
            var linkedAcnts = rmRepository.GetAccountDetails().Where(t => t.AccountType == Convert.ToByte(Account_TypeCode.UserCreatedExpenses) ||
            t.AccountType == Convert.ToByte(Account_TypeCode.UserCreatedAsset) || t.AccountType == Convert.ToByte(Account_TypeCode.UserCreatedCost)).ToList();
            //change account type show by 24th defects list

            Accounts = new ObservableCollection<AccountsEntity>(linkedAcnts).OrderBy(x => x.AccountName).ToObservable();
            TaxList = customerRepository.GetTaxCodeAndRatesList();
            Taxes = new ObservableCollection<TaxModel>(TaxList).OrderBy(x => x.TaxName).ToObservable();

            #region getting Options details
            GetOptionsData();
            #endregion

            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            this.InvoiceDate = DateTime.Now.Date;

            int minHeight = 300;
            int headerRows = 369;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 80;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.PIFormGridHeight = minHeight;

            LoadSupplierBackground();

            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {
                    MustCompare = false;
                    GetPurchaseInvoice(SharedValues.NewClick);
                }
                else if (SharedValues.NewClick == "New")
                {
                    MustCompare = true;
                    GetNewPQ();
                }
            }
            Mouse.OverrideCursor = null;

        }


        #endregion

        #region Relay Commands
        public ICommand CloseCommand { get; set; }
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
        public RelayCommand NavigateToPICommand { get; set; }
        
        #endregion

        #region "Member Functions"

        public void RefreshData()
        {

            //ProductList = pandsRepository.GetPandSComboList();
            //ProductAndServices = new ObservableCollection<PandSListModel>(ProductList);

            #region "To get Category Contents"

            var cat1 = pqRepository.GetCategoryContent("PITC".Trim());

            if (cat1 != null)
            {
                this.TermsAndConditions = Convert.ToString(cat1);
            }
            #endregion

            #region "Get Supplier Details"

            var suppliers = supplierRepository.GetAllSupplier();
            if (suppliers != null)
            {
                LstSuppliers = suppliers.ToList();
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

        void OnNavigateToPI(object param)
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

            //        IsNew = false;// added on 23 may 2017   
            //    }
            //    Mouse.OverrideCursor = null;
            //}
            SharedValues.ScreenCheckName = "Purchases Invoice(Products and Services)";
            SharedValues.ViewName = "Purchase Invoice (Products & Services)";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.NewClick = this.InvoiceNo;
            var mainview = ServiceLocator.Current.GetInstance<PurchaseInvoicePandSView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoice Form (Products & Services)");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

         bool CanNavigateToPI(object param)
        {
            if (SelectedSupplierID == 0 || InvoiceDateStr == null || PaymentDueDateStr == null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
       
        /// <summary>
        /// This method is used to get taxrate on click on Inc tax radio button
        /// </summary>
        /// <param name="param"></param>
        public void OnIncludeTax(object param)
        {
            var data = pandsRepository.GetTaxes().Where(t => t.IsDefault == true).FirstOrDefault();
            if (data != null)
            {
                TaxRate = data.TaxRate;
            }
            foreach (var item in BEDetailsEntity)
            {
                item.GSTRate = TaxRate;
               // item.OnQuantityChangeCalculatePrice();
               // item.ExcludingTax = false;
            }

            //   PQDEntity.GSTRate = TaxRate;

            CalculateTotal();

        }

        /// <summary>
        /// This method is used to exclude on click on excl tax radio button
        /// </summary>
        /// <param name="param"></param>
        public void OnExcludeTax(object param)
        {
            TaxRate = 0;
            foreach (var item in BEDetailsEntity)
            {
                item.GSTRate = 0;
               // item.OnQuantityChangeCalculatePrice();
               // item.ExcludingTax = true;
            }
            CalculateTotal();
            // PQDEntity.GSTRate = 0;
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
                    //SupplierEnabled = false;
                    IsNew = false;
                    //GetNewPQ();
                }
                Mouse.OverrideCursor = null;
            }
        }

        public bool CanPaymentToSupplier(object param)
        {
            if (SelectedSupplierID == 0 || InvoiceDateStr == null || PaymentDueDateStr == null
               || BEDetailsEntity.Count() == 0)
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
            string date = this.DateFormat as string;
            var c = CompanyD.GetCompanyDetails().Comp_year_start_date;

            if (SelectedSupplierID == 0 || InvoiceDateStr == null || PaymentDueDateStr == null
               || BEDetailsEntity.Count() == 0)
            {
                return false;
            }
            if (InvoiceDateStr != null && PaymentDueDateStr != null)
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
            else
            {
                return true;
            }
        }

        /// <summary>
        /// This method is used to delete PQ
        /// </summary>
        /// <param name="param"></param>
        //public void OnDeletePQ(object param)
        //{
        //    MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButton.YesNo);
        //    if (result == MessageBoxResult.Yes)
        //    {
        //        Mouse.OverrideCursor = Cursors.Wait;
        //        int i = pqRepository.DeleteInvoice(InvoiceNo);
        //        if (i == Convert.ToByte(PI_Status.Cancelled))
        //        {
        //            PQErrors = "Cannot delete Purchase Invoice";
        //        }
        //        else if (i == Convert.ToByte(PI_Status.Paid))
        //        {
        //            PQErrors = string.Empty;
        //            AllFieldsEnabled = false;
        //            AllFieldsReadonly = true;
        //        }
        //        else
        //        {
        //            PQErrors = string.Empty;
        //        }

        //        Mouse.OverrideCursor = null;
        //    }
        //}


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
            try
            {
                OptionsEntity oData = new OptionsEntity();
                oData = customerRepository.GetOptionSettings();
                PurchaseInvoiceForm PQForm = new PurchaseInvoiceForm();
                PQForm.BEInvoiceDetails = new List<PurchaseInvoiceBEDetailsEntity>();
                PurchaseInvoiceEntity model = new PurchaseInvoiceEntity();
               // model.InvoiceNo = this.InvoiceNo;
                model.InvoiceDate = DateTime.ParseExact(this.InvoiceDateStr, oData.DateFormat, null);
                model.TotalBeforeTax = this.TotalBeforeTax;
                model.TotalTax = this.TotalTax;
                model.TotalAfterTax = this.TotalAfterTax;
                model.PaymentDueDate = DateTime.ParseExact(this.PaymentDueDateStr, oData.DateFormat, null);
                model.OurPONo = this.OurPONo;
                if (!string.IsNullOrEmpty(InvoiceNo))
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

                foreach (var item in BEDetailsEntity)
                {
                    PurchaseInvoiceBEDetailsEntity pqEntity = new PurchaseInvoiceBEDetailsEntity();
                    pqEntity.SelectedAccountId = item.SelectedAccountId;
                    if (item.SelectedAccountId != null)
                    {
                        var acc = Accounts.Where(e => e.AccountID == item.SelectedAccountId).SingleOrDefault();
                        if (acc != null)
                        {
                            pqEntity.AccountName = acc.AccountName;
                            
                        }
                    }
                    pqEntity.Description = item.Description;
                    pqEntity.SelectedTaxID = item.SelectedTaxID;
                    if (item.SelectedTaxID != null)
                    {
                        var tax = Taxes.Where(e => e.TaxID == item.SelectedTaxID).SingleOrDefault();
                        if (tax != null)
                        {
                            pqEntity.GSTCode = tax.TaxCode;
                            pqEntity.GSTRate = tax.TaxRate;
                        }
                    }
                    pqEntity.PQAmountStr = item.PQAmountStr;
                    pqEntity.PQAmount = Convert.ToDecimal(item.PQAmountStr);
                    //pqEntity.TaxList = item.TaxList;
                    pqEntity.PIType = "BE";
                    //pqEntity.Amount= item.PQAmountStr;
                    //pqEntity.AmountBeforeTax= Convert.ToDecimal(item.PQAmountStr);
                    //pqEntity.TaxAmount = Convert.ToDecimal(item.PQAmountStr) * pqEntity.GSTRate;
                    //pqEntity.AmountAfterTax = pqEntity.AmountBeforeTax + pqEntity.TaxAmount;
                    if (item.SelectedAccountId != null && Convert.ToInt32(item.SelectedAccountId) > 0)
                    {
                        PQForm.BEInvoiceDetails.Add(pqEntity);
                    }
                }
                return PQForm;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        /// <summary>
        /// This method is used to calculate total amount of PandS with tax
        /// </summary>
        public void CalculateTotal()
        {
            if (BEDetailsEntity != null)
            {
                TotalBeforeTax = BEDetailsEntity.Sum(e => e.AmountBeforeTax);
                TotalBeforeTax = Math.Round(Convert.ToDecimal(TotalBeforeTax), DecimalPlaces);
                TotalTax = BEDetailsEntity.Sum(e => e.TaxAmount);
                TotalTax = Math.Round(Convert.ToDecimal(TotalTax), DecimalPlaces);
                TotalAfterTax = BEDetailsEntity.Sum(e => e.AmountAfterTax);
                TotalAfterTax = Math.Round(Convert.ToDecimal(TotalAfterTax), DecimalPlaces);

                TotalBeforeTaxStr = Convert.ToString(TotalBeforeTax);
                TotalTaxStr = Convert.ToString(TotalTax);
                TotalAfterTaxStr = Convert.ToString(TotalAfterTax);
            }
        }
        
        private string GenerateNewInvoiceNo()
        {
            var NewPqNo = pqRepository.GetLatestInvoiceNo() + 1;
            return "PO-" + NewPqNo.ToString();
        }

        public int ManageDuplicatePandS()
        {
            int rowFocusindex = -1;
            lst = new ObservableCollection<AccountDataGridViewModel>();
            lst = BEDetailsEntity;

            var query = lst.GroupBy(x => x.SelectedAccountId)
              .Where(g => g.Count() > 1)
              .ToList();
            if (query.Count > 0 && BEDetailsEntity.Count > 1)
            {

                var obj1 = query[0].ElementAt(0);
                var obj2 = query[0].ElementAt(1);
               
                var index1 = lst.IndexOf(query[0].ElementAt(0));
                var index2 = lst.IndexOf(query[0].ElementAt(1));


                //obj1.PQQty = qty;
                //obj1.PQPrice = Convert.ToString(productPrice2);
                //obj1.PQDiscount = discountP2;
                BEDetailsEntity[index1] = obj1;
                var row = new AccountDataGridViewModel(AccountsList);
               
                row.GSTRate = TaxRate;

                BEDetailsEntity[index2] = row;
                rowFocusindex = index2;
            
                //for (int i = 0; i < 2; i++)
                //{ 
                //    var p = PQDetailsEntity.Where(e => e.SelectedPSID == obj2.SelectedPSID ).FirstOrDefault();
                //    if (p.PQPrice == null)
                //    {
                //        PQDetailsEntity.Remove(p);
                //    }
                //}

                OnPropertyChanged("BEDetailsEntity");

            }
            else
            {

                int count = BEDetailsEntity.Count(x => x.SelectedAccountId == null);
                if (count == 0)
                {
                    var row = new AccountDataGridViewModel(AccountsList);
                    //row.PQQty = 1;
                    //row.GSTRate = TaxRate;
                    //row.GSTRateStr = Convert.ToString(TaxRate) + "%";
                    BEDetailsEntity.Add(row);
                    OnPropertyChanged("BEDetailsEntity");
                    rowFocusindex = -1;
                }
                else
                {
                    var emptyRow = lst.Where(y => y.SelectedAccountId == null).FirstOrDefault();
                    rowFocusindex = BEDetailsEntity.IndexOf(emptyRow);
                }


            }

            return rowFocusindex;
        }

        public void GetPurchaseInvoice(string pqNo)
        {
            OptionsEntity oData = new OptionsEntity();
            IPurchaseQuotationListRepository purchaseRepository = new PurchaseQuotationListRepository();
            oData = purchaseRepository.GetOptionSettings();
            // Mouse.OverrideCursor = Cursors.Wait;
            PurchaseInvoiceForm pqf = pqRepository.GetPurchaseInvoice(pqNo);
            if (pqf.Invoice != null)
            {
                this.ID = pqf.Invoice.ID;
                this.InvoiceNo = pqf.Invoice.InvoiceNo;
                this.OurPONo = pqf.Invoice.OurPONo;
                this.InvoiceDateStr = pqf.Invoice.InvoiceDate.ToString(oData.DateFormat);
                DateTime Dateinstr = (DateTime)pqf.Invoice.PaymentDueDate;
                this.PaymentDueDateStr = Dateinstr.ToString(oData.DateFormat);

                this.SelectedSupplierID = pqf.Invoice.SupplierID;
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
                this.PIStatus = pqf.Invoice.PIStatus;
                if (this.PIStatus == Convert.ToByte(PI_Status.Paid))
                {
                    AllFieldsReadonly = true;
                    AllFieldsEnabled = false;
                }
                else
                {
                    AllFieldsReadonly = false;
                    AllFieldsEnabled = true;
                }

                this.BEDetailsEntity = new ObservableCollection<AccountDataGridViewModel>();
                if (pqf.BEInvoiceDetails.Count() > 0)
                {
                    foreach (var item in pqf.BEInvoiceDetails)
                    {
                        AccountDataGridViewModel pqEntity = new AccountDataGridViewModel(AccountsList);
                        pqEntity.SelectedAccountName = item.AccountName;

                        var acc = Accounts.Where(e => e.AccountName == item.AccountName).FirstOrDefault();
                        if(acc!=null)
                        {
                            pqEntity.SelectedAccountId = acc.AccountID;
                        }
                        pqEntity.PQAmount = item.PQAmount;
                        pqEntity.PQAmountStr = Convert.ToString(item.PQAmount);
                        pqEntity.GSTRate = item.GSTRate;
                        pqEntity.Description = item.Description;
                        var tax = Taxes.Where(e => e.TaxRate == item.GSTRate).FirstOrDefault();
                        if (tax != null)
                        {
                            pqEntity.SelectedTaxID = tax.TaxID;
                        }
                        BEDetailsEntity.Add(pqEntity);
                    }
                }
                else
                {
                    var row = new AccountDataGridViewModel(AccountsList);
                    BEDetailsEntity.Add(row);
                    OnPropertyChanged("BEDetailsEntity");
                }
            }
            else
            {
                GetNewPQ();
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
            if (BEDetailsEntity.Count <= 0)
            {
                return msg = "Please add Business Expenses";
            }

            foreach (var item in BEDetailsEntity)
            {
                if (item.SelectedAccountId != null && Convert.ToInt32(item.SelectedAccountId) > 0)
                {
                    isValidData = true;
                }
            }
            if (isValidData == false)
            {
                msg = "Please add valid expense details";
            }
            return msg;
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
        /// <summary>
        /// This method is used to get new PQ
        /// </summary>
        public void GetNewPQ()
        {
            IsNew = true;
            ID = 0;
            SelectedSupplierID = 0;
            BillToAddress = string.Empty;
            ShipToAddress = string.Empty;
            // ValidForDays = 0;
            InvoiceNo = string.Empty;
            // PQDetailsEntity.Clear();
            this.OurPONo = GenerateNewInvoiceNo();
            TotalBeforeTax = 0;
            TotalTax = 0;
            TotalAfterTax = 0;
            TotalBeforeTaxStr = Convert.ToString(0);
            TotalTaxStr = Convert.ToString(0);
            TotalAfterTaxStr = Convert.ToString(0);
            PQErrors = string.Empty;
            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            this.PaymentDueDateStr = null;
            this.InvoiceNo = "PI-" + pqRepository.GetNewLatestInvoiceNo();
            PurchaseInvoiceEntity = new PurchaseInvoiceEntity();
            BEDetailsEntity.Clear();
            LstSuppliers = supplierRepository.GetAllSupplier().Where(s => s.IsInActive != "Y").ToList();

            Accounts = Accounts.OrderBy(x => x.AccountName).Where(x => x.IsInactive == "N").ToObservable();
            //PQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            var row = new AccountDataGridViewModel(AccountsList.Where(x => x.IsInactive == "N").ToList());
            row.TaxList = Taxes.ToList(); ;
            BEDetailsEntity.Add(row);
            OnPropertyChanged("BEDetailsEntity");

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
                }
                else
                {
                    IncludingTax = false;
                    ExcludingTax = true;
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
                if (sup != null)
                {
                    Sup_Balance = sup.Balance;
                    Sup_CreditLimitAmount = sup.CreditLimitAmount;
                }
            }
        }
        /// <summary>
        /// This method is used to get duplicate pq
        /// </summary>
        public void GetDuplicatePQ()
        {
            IsNew = true;
            PQErrors = string.Empty;
            InvoiceNo = string.Empty;
            OurPONo= GenerateNewInvoiceNo();
        }

        #endregion
    }
}