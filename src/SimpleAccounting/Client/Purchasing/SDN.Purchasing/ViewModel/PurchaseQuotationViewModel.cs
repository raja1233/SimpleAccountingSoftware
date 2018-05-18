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

    public class PurchaseQuotationViewModel : PurchaseQuotationEntity
    {
        #region "Private members"

        //private ObservableCollection<PandSDetailsModel> pands;
        private string currencyName;
        //  private string taxName;
        private ObservableCollection<DataGridViewModel> pqDetailsEntity;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private IPurchaseQuotationRepository pqRepository = new PurchaseQuotationRepository();
        public IPandSDetailsRepository pandsRepository = new PandSDetailsRepository();
        private ISupplierRepository supplierRepository = new SupplierRepository();
        public ObservableCollection<DataGridViewModel> lst;
        private DataGridViewModel pqdEntity;
        private PurchaseQuotationEntity purchaseQuotationEntity;
        //private PurchaseQuotationDetailEntity selectedPandS;

        private int supplierId;

        private decimal? taxRate;
        private static IEnumerable<PandSListModel> ProductList;
        private ObservableCollection<PandSListModel> productAndServices;
        //private ObservableCollection<PandSDetailsModel> productAndServices;
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


        public PurchaseQuotationEntity PurchaseQuotationEntity
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
                    OnPropertyChanged("PurchaseQuotationEntity");
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
        private bool supplierEnabled;
        public bool SupplierEnabled
        {
            get { return supplierEnabled; }
            set { supplierEnabled = value;
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
        //public ObservableCollection<PurchaseQuotationDetailEntity> PQDetailsEntity
        //{
        //    get
        //    {
        //        return pqDetailsEntity;
        //    }
        //    set
        //    {
        //        pqDetailsEntity = value;
        //        OnPropertyChanged("PQDetailsEntity");
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

        //public PurchaseQuotationDetailEntity SelectedPandS
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
        public string TandC
        {
             get;set;
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
        private bool? qtyJumptoNextRwo;
        public bool? QtyJumptoNextRow
        {
            get {
                return qtyJumptoNextRwo=false;
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

        //public static PurchaseQuotationViewModel _instance;

        //public static PurchaseQuotationViewModel GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new PurchaseQuotationViewModel();
        //    }

        //    return _instance;
        //}
        //private static IEnumerable<PandSDetailsModel> ProductList;
        private bool? jumptoNextrow;
        private bool? _disableTab;

        public PurchaseQuotationViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            Mouse.OverrideCursor = Cursors.Wait;
            ConvertToPOCommand = new RelayCommand(ConvertToPurchaseOrder, CanConvertToPO);
            ConvertToPICommand = new RelayCommand(ConvertToPurchaseInvoice, CanConvertToPI);
            SaveCommand = new RelayCommand(SavePurchaseQuotation, CanSave);
            SupplierSelectionChangedCommand = new RelayCommand(OnSupplierChange);           
            NewPQCommand = new RelayCommand(OnNewPQ);
            DuplicateCommand = new RelayCommand(OnDuplicatePQ, CanDuplicate);
            IncludeTaxCheckedCommand = new RelayCommand(OnIncludeTax);
            ExcludeTaxCheckedCommand = new RelayCommand(OnExcludeTax);
            DeleteCommand = new RelayCommand(OnDeletePQ, CanDeletePQ);
            NavigateToClientCommand = new RelayCommand(NavigatetoSupplier,CanNavigate);

            PurchaseQuotationEntity = new PurchaseQuotationEntity();
            PQDetailsEntity = new ObservableCollection<DataGridViewModel>();

            int minHeight = 300;
            int headerRows = 339;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows-85;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.PQFormGridHeight = minHeight;


            #region getting Options details
            GetOptionsData();
            #endregion

            AllFieldsEnabled = true;
           
            AllFieldsReadonly = false;
            this.QuotationDate = DateTime.Now.Date;

            LoadSupplierBackground();
            //ProductList = pandsRepository.GetAllPandS().OrderBy(e => e.PSName);
            //ProductAndServices = new ObservableCollection<PandSDetailsModel>(ProductList);
            ProductList = pandsRepository.GetPandSComboList();
            ProductAndServices = new ObservableCollection<PandSListModel>(ProductList).OrderBy(x => x.PSName).ToObservable();
            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {
                    SupplierEnabled = false;
                    GetPurchaseQuotation(SharedValues.NewClick);
                }
                else if (SharedValues.NewClick == "New")
                {
                    SupplierEnabled = true;
                    GetNewPQ();
                }
            }
            Mouse.OverrideCursor = null;

        }


        #endregion

        #region Relay Commands

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
        #endregion

        #region "Member Functions"

        public void RefreshData()
        {
           
            #region "To get Category Contents"

            var cat1 = pqRepository.GetCategoryContent("PQTC".Trim());

            if (cat1 != null)
            {
                this.TermsAndConditions = Convert.ToString(cat1);
                TandC= Convert.ToString(cat1);
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details Form");
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

        public bool CanNavigate(object param)
        {
            if(SelectedSupplierID!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CanConvertToPO(object param)
        {
            if (IsNew == true)
            {
                return false;
            }
            else
            {
                if (this.PQ_Conv_to_PO == true|| this.PQ_Conv_to_PI==true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
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
                if (this.PQ_Conv_to_PI == true || this.PQ_Conv_to_PO == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void ConvertToPurchaseOrder(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            if (this.PQ_Conv_to_PO == false || this.PQ_Conv_to_PO == null)
            {
                PurchaseQuotationForm PQForm = GetDataIntoModel();
                int i = pqRepository.ConvertToPurchaseOrder(PQForm);
                if (i > 0)
                {
                    this.PQ_Conv_to_PO = true;
                    AllFieldsReadonly = true;
                    AllFieldsEnabled = false;
                    SupplierEnabled = false;
                }
            }
            else
            {
                PQErrors = "Already converted to Purchase Order";
            }
            Mouse.OverrideCursor = null;
        }

        public void ConvertToPurchaseInvoice(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            if (this.PQ_Conv_to_PI == false|| this.PQ_Conv_to_PI==null)
            {
                PurchaseQuotationForm PQForm = GetDataIntoModel();
                int i = pqRepository.ConvertToPurchaseInvoice(PQForm);
                if (i > 0)
                {
                    this.PQ_Conv_to_PI = true;
                    AllFieldsReadonly = true;
                    AllFieldsEnabled = false;
                    SupplierEnabled = false;
                }
            }
            else
            {
                PQErrors = "Already converted to Purchase Invoice";
            }
            Mouse.OverrideCursor = null;
        }

        /// <summary>
        /// This method is used to save and edit pq
        /// </summary>
        /// <param name="param"></param>
        public void SavePurchaseQuotation(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                string msg = ValidatePurchaseQuotation();
                if (msg != string.Empty)
                {
                    PQErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                PQErrors = string.Empty;
                PurchaseQuotationForm PQForm = GetDataIntoModel();

                int i = 0;
                if (IsNew == true)
                {
                    i = pqRepository.AddUpdateQuotation(PQForm);
                }
                else
                {
                    i = pqRepository.UpdationQuotation(PQForm);
                }
                if (i > 0)
                {
                    //  GetNewPQ();
                    IsNew = false;
                    SupplierEnabled = false;
                }
                Mouse.OverrideCursor = null;
            }
        }

        public bool CanSave(object param)
        {
            if (SelectedSupplierID == 0 || QuotationDate == null
               || PQDetailsEntity.Count() == 0)
            {
                return false;
            }
            else
            {
                if (IsNew == false)
                {
                    if (PQ_Conv_to_PO == true)
                    {
                        return false;
                    }
                    else if (PQ_Conv_to_PI == true)
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
            if (PQ_Conv_to_PO == true)
            {
                return false;
            }
            else if (PQ_Conv_to_PI == true)
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
        /// This method is used to delete PQ
        /// </summary>
        /// <param name="param"></param>
        public void OnDeletePQ(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                if (pqRepository.CanDeleteQuotation(ID))
                {
                    pqRepository.DeleteQuotation(ID);
                    PQErrors = string.Empty;
                    OnNewPQ(null);
                }
                else
                {
                    PQErrors = "Cannot delete Purchase Quotation";
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

        public PurchaseQuotationForm GetDataIntoModel()
        {
            PurchaseQuotationForm PQForm = new PurchaseQuotationForm();
            PQForm.QuotationDetails = new List<PurchaseQuotationDetailEntity>();
            PurchaseQuotationEntity model = new PurchaseQuotationEntity();
            model.QuotationNo = this.QuotationNo;
            model.QuotationDate = this.QuotationDate;
            model.TotalBeforeTax = this.TotalBeforeTax;
            model.TotalTax = this.TotalTax;
            model.TotalAfterTax = this.TotalAfterTax;
            model.ValidForDays = this.ValidForDays;
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

            PQForm.Quotation = model;

            foreach (var item in PQDetailsEntity)
            {
                PurchaseQuotationDetailEntity pqEntity = new PurchaseQuotationDetailEntity();
                pqEntity.PQNo = Convert.ToString(item.SelectedPSID);
                pqEntity.PandSCode = item.PandSCode;
                pqEntity.PandSName = item.PandSName;
                pqEntity.PQQty = item.PQQty;
                pqEntity.PQPrice = item.PQPrice;
                pqEntity.PQDiscount = item.PQDiscount;
                pqEntity.GSTRate = item.GSTRate;
                pqEntity.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
                pqEntity.PQAmount = item.PQAmount;
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID) > 0)
                {
                    PQForm.QuotationDetails.Add(pqEntity);
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
            var sup = supplierRepository.GetAllSupplier().Where(s => s.ID == SelectedSupplierID).SingleOrDefault();
            if (sup != null)
            {
                this.BillToAddress = sup.ShipAddressLine1 + " " + sup.ShipAddressLine2 + " " + sup.ShipCity;
                this.ShipToAddress = sup.Sup_Bill_to_line1 + " " + sup.Sup_Bill_to_line2 + " " + sup.Sup_Bill_to_city;
                
            }
        }

      
        private string GenerateNewQuotationNo()
        {
            var NewPqNo = pqRepository.GetLatestQuotationNo()+1;
            return "PQ-" + NewPqNo.ToString();
        }

        public int ManageDuplicatePandS()
        {
            int rowFocusindex = -1;
            lst = new ObservableCollection<DataGridViewModel>();
            lst = PQDetailsEntity;

            var query = lst.GroupBy(x => x.SelectedPSID)
              .Where(g => g.Count() > 1)
              .ToList();
            if (query.Count > 0 && PQDetailsEntity.Count>1)
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

                if(productPrice2!=null)
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

        public void GetPurchaseQuotation(string pqNo)
        {
           // Mouse.OverrideCursor = Cursors.Wait;
            PurchaseQuotationForm pqf = pqRepository.GetPurchaseQuotation(pqNo);

            this.ID = pqf.Quotation.ID;
            this.QuotationNo = pqf.Quotation.QuotationNo;
            this.QuotationDate = pqf.Quotation.QuotationDate;
            this.ValidForDays = pqf.Quotation.ValidForDays;
            this.SelectedSupplierID = pqf.Quotation.SupplierID;
            //if (this.SelectedSupplierID > 0)
            //{
            //    GetSupplierDetails();
            //}

            this.TermsAndConditions = pqf.Quotation.TermsAndConditions;
            
            this.TotalBeforeTax = pqf.Quotation.TotalBeforeTax;
            this.TotalTax = pqf.Quotation.TotalTax;
            this.TotalAfterTax = pqf.Quotation.TotalAfterTax;
            this.TotalBeforeTaxStr = Convert.ToString(this.TotalBeforeTax);
            this.TotalTaxStr = Convert.ToString(TotalTax);
            this.TotalAfterTaxStr = Convert.ToString(TotalAfterTax);

            if (pqf.Quotation.ExcIncGST == true)
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

            this.PQ_Conv_to_PO = pqf.Quotation.PQ_Conv_to_PO;
            this.PQ_Conv_to_PI = pqf.Quotation.PQ_Conv_to_PI;

            if (PQ_Conv_to_PO == true || PQ_Conv_to_PI == true)
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
            SupplierEnabled = false;


            this.PQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            foreach (var item in pqf.QuotationDetails)
            {
                DataGridViewModel pqEntity = new DataGridViewModel(ProductList);
                pqEntity.SelectedPSID = Convert.ToString(item.PQNo);
                pqEntity.PandSCode = item.PandSCode;
                pqEntity.PandSName = item.PandSName;
                pqEntity.GSTRate = Math.Round(Convert.ToDecimal(item.GSTRate),DecimalPlaces);
                pqEntity.GSTRateStr = Convert.ToString(pqEntity.GSTRate) + "%";
                pqEntity.PQQty = item.PQQty;
                pqEntity.PQPrice = Convert.ToString(item.Price);
                pqEntity.PQDiscount = item.PQDiscount;
               
              //  PQDEntity.GSTRate = item.GSTRate;
                pqEntity.PQAmount = item.PQAmount;

                PQDetailsEntity.Add(pqEntity);
            }
           
        }

        /// <summary>
        /// This method is used to validate purchase quotation on Save
        /// </summary>
        /// <returns></returns>
        public string ValidatePurchaseQuotation()
        {
            bool isValidData = false;
            string msg = string.Empty;
            if (SelectedSupplierID == 0)
            {
                return msg = "Please select Supplier Name";
            }
            if (QuotationDate == null)
            {
                return msg = "Please enter Quotation Date";
            }
            if (PQDetailsEntity.Count <= 0)
            {
                return msg = "Please add Products and Services";
            }

            foreach (var item in PQDetailsEntity)
            {
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID)>0)
                {
                    if (item.PQQty <= 0 && item.SelectedPSID != null)
                    {
                        return msg = "Quantity should be greater than zero";
                    }

                    //if (item.PQDiscount==null)
                    //{
                    //    return msg = "Please enter valid Discount";
                    //}
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

                    if(item.PQQty==null)
                    {
                        return msg = "Please enter valid Quantity";
                    }
                    
                    //if (!System.Text.RegularExpressions.Regex.IsMatch(taxModel.TaxRate.ToString(), @"^\d+([.]\d{1,2})?%?$"))
                    //{
                    //    msg.Append("Enter valid Tax Rate.\n");
                    //}

                    //if (System.Text.RegularExpressions.Regex.IsMatch(item.PQPrice.Trim(), @"[^0-9]"))
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
        /// This method is used to get new PQ
        /// </summary>
        public void GetNewPQ()
        {
            
            IsNew = true;
            ID = 0;
            SelectedSupplierID = 0;
            BillToAddress = string.Empty;
            ShipToAddress = string.Empty;
            ValidForDays = 0;
            QuotationNo = GenerateNewQuotationNo();
            TermsAndConditions = TandC;
            QuotationDate = DateTime.Now.Date;
            TotalBeforeTax = 0;
            TotalTax = 0;
            TotalAfterTax = 0;
            TotalBeforeTaxStr = Convert.ToString(0);
            TotalTaxStr = Convert.ToString(0);
            TotalAfterTaxStr = Convert.ToString(0);
            PQErrors = string.Empty;
            AllFieldsEnabled = true;
            SupplierEnabled = true;
            AllFieldsReadonly = false;            
            PurchaseQuotationEntity = new PurchaseQuotationEntity();
             PQDetailsEntity.Clear();
            LstSuppliers = supplierRepository.GetAllSupplier().Where(s => s.IsInActive != "Y").ToList();
            ProductAndServices = ProductAndServices.OrderBy(x => x.PSName).Where(x => x.IsInActive == "N").ToObservable();
            // PQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            var row = new DataGridViewModel(ProductList.Where(x => x.IsInActive == "N").ToList());
            //row.PQQty = 1;
            //row.PQDiscount = 0;
            //row.GSTRateStr = Convert.ToString(TaxRate) + "%";
            //row.GSTRate = TaxRate;
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
            IsNew = true;
            PQErrors = string.Empty;
            QuotationNo = GenerateNewQuotationNo();
            AllFieldsEnabled = true;
            SupplierEnabled = true;
            AllFieldsReadonly = false;
        }

        #endregion

    }
}