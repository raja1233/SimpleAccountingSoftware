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
    using SDN.Purchasing.Services;
    using System.Windows.Input;
    using System.ComponentModel;
    using Product.Services;
    using System.Windows;
    using Microsoft.Practices.ServiceLocation;
    using View;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.Events;
    using System.Data;
    using System.Reflection;
    using SASClient.Reports.ReportsPage;
    using SASClient.CloseRequest;
    using Microsoft.Practices.Prism.Commands;
    using Settings.Services;
    using System.Globalization;
    using Sales.Services;

    public class PurchaseOrderViewModel : PurchaseOrderEntity
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
        private DateTime? _POrderDateCalender;
        private DateTime? _PDeliverDateCalender;
        ICompanyDetails CompanyD = new CompanyDetails();
        //  private string taxName;
        private ObservableCollection<DataGridViewModel> pqDetailsEntity;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private IPurchaseOrderRepository pqRepository = new PurchaseOrderRepository();
        public IPandSDetailsRepository pandsRepository = new PandSDetailsRepository();
        private ISupplierRepository supplierRepository = new SupplierRepository();
        public ObservableCollection<DataGridViewModel> lst;
        private DataGridViewModel pqdEntity;
        private PurchaseOrderEntity purchaseOrderEntity;
        //private PurchaseOrderDetailEntity selectedPandS;
        StackList listitem = new StackList();
        private int supplierId;

        private decimal? taxRate;
        //private ObservableCollection<PandSDetailsModel> productAndServices;
        private static IEnumerable<PandSListModel> ProductList;
        private ObservableCollection<PandSListModel> productAndServices;
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
        public DataGridViewModel PODEntity
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
                    OnPropertyChanged("PODEntity");
                }
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
        public DateTime? POrderDateCalender
        {
            get
            {
                return _POrderDateCalender;
            }
            set
            {
                _POrderDateCalender = value;
                OnPropertyChanged("POrderDateCalender");
            }
        }
        public DateTime? PDeliverDateCalender
        {
            get
            {
                return _PDeliverDateCalender;
            }
            set
            {
                _PDeliverDateCalender = value;
                OnPropertyChanged("PDeliverDateCalender");
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

        public PurchaseOrderEntity PurchaseOrderEntity
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
                    OnPropertyChanged("PurchaseOrderEntity");
                }
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
        public ObservableCollection<DataGridViewModel> PODetailsEntity
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
                    OnPropertyChanged("PODetailsEntity");
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

        public string POErrors
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
                    OnPropertyChanged("POErrors");
                }
            }
        }
        //public ObservableCollection<PurchaseOrderDetailEntity> PODetailsEntity
        //{
        //    get
        //    {
        //        return pqDetailsEntity;
        //    }
        //    set
        //    {
        //        pqDetailsEntity = value;
        //        OnPropertyChanged("PODetailsEntity");
        //    }
        //}

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

        //public PurchaseOrderDetailEntity SelectedPandS
        //{
        //    get
        //    {
        //        return selectedPandS;
        //    }
        //    set
        //    {
        //        selectedPandS = value;
        //        OnPropertyChanged("SelectedPandS");
        //    }
        //}

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
            set
            {
                jumptoNextrow = value;
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

        //public static PurchaseOrderViewModel _instance;

        //public static PurchaseOrderViewModel GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new PurchaseOrderViewModel();
        //    }

        //    return _instance;
        //}
        // private static IEnumerable<PandSDetailsModel> ProductList;
        private bool? jumptoNextrow;
        private bool? _disableTab;

        public PurchaseOrderViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            //ConvertToPOCommand = new RelayCommand(ConvertToPurchaseOrder, CanConvertToPO);
            ConvertToPICommand = new RelayCommand(ConvertToPurchaseInvoice, CanConvertToPI);
            SaveCommand = new RelayCommand(SavePurchaseOrder, CanSave);
            SupplierSelectionChangedCommand = new RelayCommand(OnSupplierChange);
            NewPOCommand = new RelayCommand(OnNewPO);
            DuplicateCommand = new RelayCommand(OnDuplicatePO, CanDuplicate);
            IncludeTaxCheckedCommand = new RelayCommand(OnIncludeTax);
            ExcludeTaxCheckedCommand = new RelayCommand(OnExcludeTax);
            DeleteCommand = new RelayCommand(OnDeletePO, CanDeletePO);
            NavigateToClientCommand = new RelayCommand(NavigatetoSupplier, CanNavigate);
            PayDepositCommand = new RelayCommand(PayDeposit, CanSave);
            clickCommand = new RelayCommand(PrintCommand, CanPrint);
            PurchaseOrderEntity = new PurchaseOrderEntity();
            PODetailsEntity = new ObservableCollection<DataGridViewModel>();
            CloseCommand = new DelegateCommand(Close);

            int minHeight = 300;
            int headerRows = 339;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 85;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.POFormGridHeight = minHeight;

            #region getting Options details
            GetOptionsData();
            #endregion

            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            RubberStampPI = false;
            this.OrderDate = DateTime.Now.Date;
            this.DeliveryDate = DateTime.Now.Date;

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
                    GetPurchaseOrder(SharedValues.NewClick);
                }
                else if (SharedValues.NewClick == "New")
                {
                    MustCompare = true;
                    SupplierEnabled = true;//added on 23may2017
                    GetNewPO();
                }
            }
            Mouse.OverrideCursor = null;

        }


        #endregion

        #region Relay Commands
        public ICommand CloseCommand { get; set; }
        public RelayCommand clickCommand { get; set; }
        public RelayCommand ConvertToPOCommand { get; set; }
        public RelayCommand ConvertToPICommand { get; set; }
        public RelayCommand AddNewRowCommand { get; set; }
        public RelayCommand SupplierSelectionChangedCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand PODiscountTextChangedCommand { get; set; }
        public RelayCommand POQuantityTextChangedCommand { get; set; }
        public RelayCommand NewPOCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand DuplicateCommand { get; set; }
        public RelayCommand IncludeTaxCheckedCommand { get; set; }
        public RelayCommand ExcludeTaxCheckedCommand { get; set; }
        public RelayCommand NavigateToClientCommand { get; set; }
        public RelayCommand PayDepositCommand { get; set; }
        #endregion

        #region "Member Functions"

        public void RefreshData()
        {

            #region "To get Category Contents"

            var cat1 = pqRepository.GetCategoryContent("POTC".Trim());

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
        public void OnNewPO(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            GetNewPO();
            Mouse.OverrideCursor = null;
        }

        /// <summary>
        /// This method is used to get duplicate pq
        /// </summary>
        /// <param name="param"></param>
        public void OnDuplicatePO(object param)
        {
            GetDuplicatePO();
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
            foreach (var item in PODetailsEntity)
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
            foreach (var item in PODetailsEntity)
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
        //public bool CanConvertToPO(object param)
        //{
        //    if (IsNew == true)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        if (this.PO_Conv_to_PO == true || this.PO_Conv_to_PI == true)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //}

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
        public bool CanConvertToPI(object param)
        {
            if (IsNew == true)
            {
                return false;
            }
            else
            {
                if (IsNew == false)
                {
                    if (PO_Conv_to_PI == true)
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
                else
                {
                    return true;
                }
            }
        }

        //public void ConvertToPurchaseOrder(object param)
        //{
        //    if (this.PO_Conv_to_PO == false || this.PO_Conv_to_PO == null)
        //    {
        //        PurchaseOrderForm POForm = GetDataIntoModel();
        //        int i = pqRepository.ConvertToPurchaseOrder(POForm);
        //        if (i > 0)
        //        {
        //            this.PO_Conv_to_PO = true;
        //        }
        //    }
        //    else
        //    {
        //        POErrors = "Already converted to Purchase Order";
        //    }
        //}

        public void ConvertToPurchaseInvoice(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            if (this.PO_Conv_to_PI == false || this.PO_Conv_to_PI == null)
            {
                PurchaseOrderForm POForm = GetDataIntoModel();
                int i = pqRepository.ConvertToPurchaseInvoice(POForm);
                if (i > 0)
                {
                    this.PO_Conv_to_PI = true;
                    AllFieldsReadonly = true;
                    RubberStampPI =false;
                    AllFieldsEnabled = false;
                    SupplierEnabled = false;// added on 23 may 2017
                }
            }
            else
            {
                POErrors = "Already converted to Purchase Invoice";
            }
            Mouse.OverrideCursor = null;
        }

        /// <summary>
        /// This method is used to save and edit pq
        /// </summary>
        /// <param name="param"></param>
        public void SavePurchaseOrder(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                string msg = ValidatePurchaseOrder();
                if (msg != string.Empty)
                {
                    POErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                POErrors = string.Empty;
                PurchaseOrderForm POForm = GetDataIntoModel();

                int i = 0;
                if (IsNew == true)
                {
                    i = pqRepository.AddUpdateOrder(POForm);
                }
                else
                {
                    i = pqRepository.UpdationOrder(POForm);
                }
                if (i > 0)
                {
                    // GetNewPO();
                    SupplierEnabled = false;
                    IsNew = false;// added on 23 may 2017
                }
                Mouse.OverrideCursor = null;
            }
        }
        public void PayDeposit(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                string msg = ValidatePurchaseOrder();
                if (msg != string.Empty)
                {
                    POErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                POErrors = string.Empty;
                PurchaseOrderForm POForm = GetDataIntoModel();

                int i = 0;
                if (IsNew == true)
                {
                    i = pqRepository.AddUpdateOrder(POForm);
                }
                else
                {
                    i = pqRepository.UpdationOrder(POForm);
                }
                if (i > 0)
                {
                    //GetNewPO();
                    //string obj = param.ToString();
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
                Mouse.OverrideCursor = null;
            }
        }

        public bool CanSave(object param)
        {
            string date = this.DateFormat as string;
            var c = CompanyD.GetCompanyDetails().Comp_year_start_date;
            if (SelectedSupplierID == 0 && OrderDateStr == null
               || PODetailsEntity.Count() == 0)
            {
                return false;
            }
            else
            {
                if (IsNew == false)
                {
                    if (PO_Conv_to_PI == true)
                    {
                        return false;
                    }
                    else if (Status == Convert.ToByte(PO_Status.Cancelled))
                    {
                        return false;
                    }
                    else if (Status == Convert.ToByte(PO_Status.Collected))
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
        public override void OnPropertyChanged(string name)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(name));
            }
            switch (name)
            {
                case "POrderDateCalender":
                    FillStartDate();
                    break;
                case "PDeliverDateCalender":
                    FillStartDate1();
                    break;


            }

            base.OnPropertyChanged(name);
        }
        void FillStartDate()
        {
            string date = this.DateFormat as string;
            OrderDateStr = Convert.ToDateTime(this.POrderDateCalender).ToString(date);
     
        }
        void FillStartDate1()
        {
            string date = this.DateFormat as string;
            DeliveryDateStr = Convert.ToDateTime(this.PDeliverDateCalender).ToString(date);

        }
        public bool CanDeletePO(object param)
        {
            if (this.PO_Conv_to_PI == true)
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
        /// This method is used to delete PO
        /// </summary>
        /// <param name="param"></param>
        public void OnDeletePO(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                if (pqRepository.CanDeleteOrder(ID))
                {
                    pqRepository.DeleteOrder(ID);
                    POErrors = string.Empty;
                    OnNewPO(null);
                }
                else
                {
                    POErrors = "Cannot delete Purchase Order";
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

        public PurchaseOrderForm GetDataIntoModel()
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            PurchaseOrderForm POForm = new PurchaseOrderForm();
            POForm.OrderDetails = new List<PurchaseOrderDetailEntity>();
            PurchaseOrderEntity model = new PurchaseOrderEntity();
            model.OrderNo = this.OrderNo;
            model.OrderDate = DateTime.ParseExact(this.OrderDateStr, oData.DateFormat, null);
            model.TotalBeforeTax = this.TotalBeforeTax;
            model.TotalTax = this.TotalTax;
            model.TotalAfterTax = this.TotalAfterTax;
            //model.ValidForDays = this.ValidForDays;
            model.DeliveryDate = this.DeliveryDate;
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

            POForm.Order = model;

            foreach (var item in PODetailsEntity)
            {
                PurchaseOrderDetailEntity pqEntity = new PurchaseOrderDetailEntity();
                pqEntity.PONo = Convert.ToString(item.SelectedPSID);
                pqEntity.PandSCode = item.PandSCode;
                pqEntity.PandSName = item.PandSName;
                pqEntity.POQty = item.PQQty;
                pqEntity.POPrice = item.PQPrice;
                pqEntity.PODiscount = item.PQDiscount;
                pqEntity.GSTRate = item.GSTRate;
                pqEntity.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
                pqEntity.POAmount = item.PQAmount;
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID) > 0)
                {
                    POForm.OrderDetails.Add(pqEntity);
                }
            }
            return POForm;
        }

        /// <summary>
        /// This method is used to calculate total amount of PandS with tax
        /// </summary>
        public void CalculateTotal(bool excludeTax)
        {
            decimal? totalBeforeTax = 0;
            decimal? mTotalTax = 0;
            decimal? mTotalAfterTax = 0;
            if (PODetailsEntity != null)
            {
                totalBeforeTax = PODetailsEntity.Sum(e => e.AmountBeforeTax);
                TotalBeforeTax = Math.Round(Convert.ToDecimal(totalBeforeTax), DecimalPlaces);
                mTotalTax = PODetailsEntity.Sum(e => e.TaxAmount);

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
            var sup = supplierRepository.GetAllSupplier().Where(s => s.ID == SelectedSupplierID).SingleOrDefault();
            SharedValues.SelectedSupId = SelectedSupplierID;
            if (sup != null)
            {
                this.BillToAddress = sup.ShipAddressLine1 + " " + sup.ShipAddressLine2 + " " + sup.ShipCity;
                this.ShipToAddress = sup.Sup_Bill_to_line1 + " " + sup.Sup_Bill_to_line2 + " " + sup.Sup_Bill_to_city;

            }
        }


        private string GenerateNewOrderNo()
        {
            var NewPqNo = pqRepository.GetLatestOrderNo() + 1;
            return "PO-" + NewPqNo.ToString();
        }

        public int ManageDuplicatePandS()
        {
            int rowFocusindex = -1;
            lst = new ObservableCollection<DataGridViewModel>();
            lst = PODetailsEntity;

            var query = lst.GroupBy(x => x.SelectedPSID)
              .Where(g => g.Count() > 1)
              .ToList();
            if (query.Count > 0 && PODetailsEntity.Count > 1)
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
                    PODetailsEntity[index1] = obj1;
                    var row = new DataGridViewModel(ProductList);
                    //row.PQQty = 1;
                    //row.GSTRate = TaxRate;
                    //row.GSTRateStr = Convert.ToString(TaxRate) + "%";
                    PODetailsEntity[index2] = row;
                    rowFocusindex = index2;
                }
                //for (int i = 0; i < 2; i++)
                //{ 
                //    var p = PODetailsEntity.Where(e => e.SelectedPSID == obj2.SelectedPSID ).FirstOrDefault();
                //    if (p.POPrice == null)
                //    {
                //        PODetailsEntity.Remove(p);
                //    }
                //}

                OnPropertyChanged("PODetailsEntity");

            }
            else
            {
                int count = PODetailsEntity.Count(x => x.SelectedPSID == null);
                if (count == 0)
                {
                    var row = new DataGridViewModel(ProductList);
                    //row.PQQty = 1;
                    //row.GSTRate = TaxRate;
                    //row.GSTRateStr = Convert.ToString(TaxRate) + "%";
                    PODetailsEntity.Add(row);
                    OnPropertyChanged("PODetailsEntity");
                    rowFocusindex = -1;
                }
                else
                {
                    var emptyRow = lst.Where(y => y.SelectedPSID == null).FirstOrDefault();
                    rowFocusindex = PODetailsEntity.IndexOf(emptyRow);
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



        public void GetPurchaseOrder(string pqNo)
        {
            // Mouse.OverrideCursor = Cursors.Wait;
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            PurchaseOrderForm pqf = pqRepository.GetPurchaseOrder(pqNo);

            this.ID = pqf.Order.ID;
            this.OrderNo = pqf.Order.OrderNo;
            this.OrderDateStr = pqf.Order.OrderDate.ToString(oData.DateFormat);
            //this.ValidForDays = pqf.Order.ValidForDays;
            this.DeliveryDateStr = pqf.Order.DeliveryDate.ToString(oData.DateFormat);
            this.SelectedSupplierID = pqf.Order.SupplierID;
            SharedValues.SelectedSupId = this.SelectedSupplierID;
            //if (this.SelectedSupplierID > 0)
            //{
            //    GetSupplierDetails();
            //}

            this.TermsAndConditions = pqf.Order.TermsAndConditions;

            this.TotalBeforeTax = pqf.Order.TotalBeforeTax;
            this.TotalTax = pqf.Order.TotalTax;
            this.TotalAfterTax = pqf.Order.TotalAfterTax;
            this.TotalBeforeTaxStr = Convert.ToString(this.TotalBeforeTax);
            this.TotalTaxStr = Convert.ToString(TotalTax);
            this.TotalAfterTaxStr = Convert.ToString(TotalAfterTax);
            this.PO_Conv_to_PI = pqf.Order.PO_Conv_to_PI;
            if (pqf.Order.ExcIncGST == true)
            {
                ExcludingTax = false;
                IncludingTax = true;
                //  PODEntity.GSTRate = 0;
            }
            else
            {
                ExcludingTax = true;
                IncludingTax = false;
                // PODEntity.GSTRate = TaxRate;
            }

            if (PO_Conv_to_PI == true)
            {
                AllFieldsReadonly = true;
                AllFieldsEnabled = false;
                RubberStampPI = true;
            }
            else
            {
                AllFieldsReadonly = false;
                AllFieldsEnabled = true;
                LstSuppliers = supplierRepository.GetAllSupplier().Where(s => s.IsInActive != "Y").ToList();
                ProductAndServices = ProductAndServices.OrderBy(x => x.PSName).Where(x => x.IsInActive != "Y").ToObservable();
            }

            this.Status = pqf.Order.Status;
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

            //this.PO_Conv_to_PO = pqf.Order.PO_Conv_to_PO;
            

            SupplierEnabled = false;// added on 23 may 2017

            this.PODetailsEntity = new ObservableCollection<DataGridViewModel>();
            foreach (var item in pqf.OrderDetails)
            {
                DataGridViewModel pqEntity = new DataGridViewModel(ProductList);
                pqEntity.SelectedPSID = Convert.ToString(item.PONo);
                pqEntity.PandSCode = item.PandSCode;
                pqEntity.PandSName = item.PandSName;
                pqEntity.GSTRate = Math.Round(Convert.ToDecimal(item.GSTRate), DecimalPlaces);
                pqEntity.GSTRateStr = Convert.ToString(pqEntity.GSTRate) + "%";
                pqEntity.PQQty = item.POQty;
                pqEntity.PQPrice = Convert.ToString(item.Price);
                pqEntity.PQDiscount = item.PODiscount;

                //  PODEntity.GSTRate = item.GSTRate;
                pqEntity.PQAmount = item.POAmount;

                PODetailsEntity.Add(pqEntity);
            }

        }
        public void PrintCommand(object param)
        {

            var InvoiceNumber = param.ToString();
            SharedValues.Print_Id = InvoiceNumber;
            ///PrintSalesQuotation();
            //after calling the mwthod
            var mainview = ServiceLocator.Current.GetInstance<PurchaseOrderReport>();

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
        public PurchaseOrderForm PrintPurchaseOrder()
        {
            // Mouse.OverrideCursor = Cursors.Wait;
            var siRepository = new PurchaseOrderRepository();
            var siNo = SharedValues.Print_Id;
            var sif = siRepository.GetPrintPurchaseOrder(siNo);
            //  var qf = sqRepository.GetSalesQuotation(sqNo);

            ////  DataTable dt = new DataTable();
            //  DataTable dt = LINQResultToDataTable(qf);
            //  dt = (DataTable)sqf;
            return sif;
        }

        /// <summary>
        /// This method is used to validate purchase order on Save
        /// </summary>
        /// <returns></returns>
        public string ValidatePurchaseOrder()
        {
            bool isValidData = false;
            string msg = string.Empty;
            if (SelectedSupplierID == 0)
            {
                return msg = "Please select Supplier Name";
            }
            if (OrderDateStr == null)
            {
                return msg = "Please enter Order Date";
            }
            if (PODetailsEntity.Count <= 0)
            {
                return msg = "Please add Products and Services";
            }

            foreach (var item in PODetailsEntity)
            {
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID) > 0)
                {
                    if (item.PQQty <= 0 && item.SelectedPSID != null)
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

                    //if (System.Text.RegularExpressions.Regex.IsMatch(item.POPrice.Trim(), @"[^0-9]"))
                    //{
                    //    return msg = "Please enter valid price";
                    //}
                    if (item.PQQty > 0 && item.SelectedPSID != null && Convert.ToDecimal(item.PQPrice) >= 0)
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
        /// This method is used to get new PO
        /// </summary>
        public void GetNewPO()
        {
            VisibilityForImage = Visibility.Collapsed;
            IsNew = true;
            ID = 0;
            SelectedSupplierID = 0;
            BillToAddress = string.Empty;
            ShipToAddress = string.Empty;
            //ValidForDays = 0;
            OrderNo = GenerateNewOrderNo();
            TermsAndConditions = TandC;
            OrderDate = DateTime.Now.Date;
            DeliveryDate = DateTime.Now.Date;
            TotalBeforeTax = 0;
            TotalTax = 0;
            TotalAfterTax = 0;
            TotalBeforeTaxStr = Convert.ToString(0);
            TotalTaxStr = Convert.ToString(0);
            TotalAfterTaxStr = Convert.ToString(0);
            POErrors = string.Empty;
            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            RubberStampPI = false;
          
            SupplierEnabled = true;// added on 23 may 2017
            PurchaseOrderEntity = new PurchaseOrderEntity();
            PODetailsEntity.Clear();

            LstSuppliers = supplierRepository.GetAllSupplier().Where(s => s.IsInActive != "Y").ToList();
            ProductAndServices = ProductAndServices.OrderBy(x => x.PSName).Where(x => x.IsInActive == "N").ToObservable();
            // PODetailsEntity = new ObservableCollection<DataGridViewModel>();
            var row = new DataGridViewModel(ProductList.Where(x => x.IsInActive == "N").ToList());
            //row.PQQty = 1;
            //row.PQDiscount = 0;

            //row.GSTRate = TaxRate;
            //row.GSTRateStr = Convert.ToString(TaxRate) + "%";
            PODetailsEntity.Add(row);
            OnPropertyChanged("PODetailsEntity");
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
                    //QtyJumptoNextRow = lstOptions.PSQtyJumNextLine;
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
        public void GetDuplicatePO()
        {
            VisibilityForImage = Visibility.Collapsed;
            IsNew = true;
            POErrors = string.Empty;
            OrderNo = GenerateNewOrderNo();
            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
            SupplierEnabled = true;// added on 23 may 2017
        }

        #endregion
    }
}
