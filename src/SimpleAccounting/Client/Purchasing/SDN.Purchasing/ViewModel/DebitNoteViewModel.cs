﻿using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

using SDN.Common;
using SDN.Common.View;
using SDN.Product.Services;
using SDN.Purchasing.Services;
using SDN.Purchasing.View;
using SDN.UI.Entities;
using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SDN.Purchasing.ViewModel
{
    public class DebitNoteViewModel:DebitNoteEntity
    {
        #region "Private members"

        //private ObservableCollection<PandSDetailsModel> pands;
        private string currencyName;
        //  private string taxName;
        private ObservableCollection<DataGridViewModel> pqDetailsEntity;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private IPurchaseInvoicePandSRepository pqRepository = new PurchaseInvoicePandSRepository();
        private IDebitNoteRepository dnRepository = new DebitNoteRepository();
        public IPandSDetailsRepository pandsRepository = new PandSDetailsRepository();
        private ISupplierRepository supplierRepository = new SupplierRepository();
        public ObservableCollection<DataGridViewModel> lst;
        private DataGridViewModel pqdEntity;
        private DebitNoteEntity debitNoteEntity;
        //private PurchaseInvoiceDetailEntity selectedPandS;

        private int supplierId;

        private decimal? taxRate;
        // private ObservableCollection<PandSDetailsModel> productAndServices;
        private static IEnumerable<PandSListModel> ProductList;
        private ObservableCollection<PandSListModel> productAndServices;
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
        public string TandC
        {
            get; set;
        }

        public DebitNoteEntity DebitNoteEntity
        {
            get
            {
                return debitNoteEntity;
            }
            set
            {
                if (debitNoteEntity != value)
                {
                    debitNoteEntity = value;
                    OnPropertyChanged("DebitNoteEntity");
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

      //  private static IEnumerable<PandSDetailsModel> ProductList;
      
        public DebitNoteViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            
            DebitNoteEntity = new DebitNoteEntity();
            PQDetailsEntity = new ObservableCollection<DataGridViewModel>();
            
            int minHeight = 300;
            int headerRows = 369;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 80;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.PIFormGridHeight = minHeight;

            #region getting Options details
            GetOptionsData();
            #endregion

            AllFieldsEnabled = true;
            AllFieldsReadonly = false;
          
            LoadSupplierBackground();

            NavigateToClientCommand = new RelayCommand(NavigatetoSupplier);
            SaveCommand = new RelayCommand(UpdateDebitNote);
            CollectMoneyFromSupplierCommand = new RelayCommand(CollectMoneyFromSupplier, CanCollect);
            AdjustDebitNoteCommand = new RelayCommand(AdjustDebitNote, CanAdjust);
            NavigateToPICommand = new RelayCommand(NavigateToPI);

            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {                    
                    GetDebitNote(SharedValues.NewClick);
                }
                
            }
            Mouse.OverrideCursor = null;
        
        }
        
        #endregion

        #region Relay Commands

         public RelayCommand SaveCommand { get; set; }
        public RelayCommand NavigateToClientCommand { get; set; }
        public RelayCommand CollectMoneyFromSupplierCommand { get; set; }
        public RelayCommand AdjustDebitNoteCommand { get; set; }
        public RelayCommand NavigateToPICommand { get; set; }

        #endregion

        #region "Member Functions"

        public void RefreshData()
        {

            ProductList = pandsRepository.GetPandSComboList();
            ProductAndServices = new ObservableCollection<PandSListModel>(ProductList).OrderBy(x => x.PSName).ToObservable();

            #region "To get Category Contents"

            var cat1 = pqRepository.GetCategoryContent("DNR".Trim());

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
                LstSuppliers = suppliers.ToList();
            }
            #endregion

        }

        public void NavigateToPI(object param)
        {
            if (param != null)
            {
                string obj = param.ToString();
                SharedValues.NewClick = obj;
                SharedValues.getValue = "PurchaseInvoiceTab";
            }
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoice Form (Products & Services)");
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

        public void CollectMoneyFromSupplier(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;

                PQErrors = string.Empty;
                DebitNoteForm PQForm = GetDataIntoModel();

                if (PQForm != null)
                {
                    dnRepository.UpdateDebitNote(PQForm);
                }
                if (param != null)
                {
                    SharedValues.NewClick = param.ToString();
                }
                SharedValues.getValue = "RefundFromSupplierTab";
                SharedValues.CollectCommand = Convert.ToString(this.SelectedSupplierID);
                var tabview = ServiceLocator.Current.GetInstance<SDN.Common.View.CashAndBankTabView>();

                var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                tabregion.Add(tabview);
                if (tabregion != null)
                {
                    tabregion.Activate(tabview);
                }

                var mainview = ServiceLocator.Current.GetInstance<RefundFromSupplierView>();

                var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                mainregion.Add(mainview);
                if (mainregion != null)
                {
                    mainregion.Activate(mainview);
                }
                eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund From Supplier Form");
                Mouse.OverrideCursor = null;
            }
        }
        public bool CanCollect(object param)
        {
            if(this.Status ==Convert.ToByte(DN_Status.Adjusted))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void AdjustDebitNote(object param)
        {
            string obj = param.ToString();
            SharedValues.NewClick = obj;
            var mainview = ServiceLocator.Current.GetInstance<AdjustDebitNoteFormView>();
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Adjust Debit Note");
        }
        public bool CanAdjust(object param)
        {
            if (this.Status == Convert.ToByte(DN_Status.Adjusted))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void GetDebitNote(object param)
        {
            if (param != null)
            {
                DebitNoteForm pqf = dnRepository.GetDebitNoteDetails(Convert.ToString(param));

                this.ID = pqf.DebitNote.ID;
                this.DebitNo = pqf.DebitNote.DebitNo;
                this.DebitDate = pqf.DebitNote.DebitDate;
                this.SupplierCreditNoteNo = pqf.DebitNote.SupplierCreditNoteNo;
                this.SupplierCreditNoteDate = pqf.DebitNote.SupplierCreditNoteDate;
                this.SupplierCreditNoteAmount = pqf.DebitNote.SupplierCreditNoteAmount;
                this.SelectedSupplierID = pqf.DebitNote.SupplierID;
                this.PurchaseInvoiceID = pqf.DebitNote.PurchaseInvoiceID;
                this.PurchaseInvoiceNo = pqf.DebitNote.PurchaseInvoiceNo;
                this.TermsAndConditions = pqf.DebitNote.TermsAndConditions;

                this.TotalBeforeTax = pqf.DebitNote.TotalBeforeTax;
                this.TotalTax = pqf.DebitNote.TotalTax;
                this.TotalAfterTax = pqf.DebitNote.TotalAfterTax;
                this.TotalBeforeTaxStr = Convert.ToString(this.TotalBeforeTax);
                this.TotalTaxStr = Convert.ToString(TotalTax);
                this.TotalAfterTaxStr = Convert.ToString(TotalAfterTax);

                this.Status = pqf.DebitNote.Status;
               
               
                this.PQDetailsEntity = new ObservableCollection<DataGridViewModel>();
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
                    pqEntity.PQDiscount = Math.Round((decimal)item.PIDiscount,2);

                    //  PQDEntity.GSTRate = item.GSTRate;
                    pqEntity.PQAmount = item.PIAmount;

                    PQDetailsEntity.Add(pqEntity);
                }
            }
        }

        /// <summary>
        /// This method is used to save and edit pq
        /// </summary>
        /// <param name="param"></param>
        public void UpdateDebitNote(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
               
                PQErrors = string.Empty;
                DebitNoteForm PQForm = GetDataIntoModel();

                if (PQForm != null)
                {
                    dnRepository.UpdateDebitNote(PQForm);
                }
              
                Mouse.OverrideCursor = null;
            }
        }

        public DebitNoteForm GetDataIntoModel()
        {
            DebitNoteForm PQForm = new DebitNoteForm();
            PQForm.InvoiceDetails = new List<PurchaseInvoiceDetailEntity>();
            DebitNoteEntity model = new DebitNoteEntity();
            model.DebitNo = this.DebitNo;
            model.DebitDate = this.DebitDate;
            model.TotalBeforeTax = this.TotalBeforeTax;
            model.TotalTax = this.TotalTax;
            model.TotalAfterTax = this.TotalAfterTax;
            model.SupplierCreditNoteNo = this.SupplierCreditNoteNo;
            model.SupplierCreditNoteDate = this.SupplierCreditNoteDate;
            model.SupplierCreditNoteAmount = this.SupplierCreditNoteAmount;
            model.SupplierID = this.SelectedSupplierID;
            
            model.TermsAndConditions = this.TermsAndConditions;
           
            PQForm.DebitNote = model;

            foreach (var item in PQDetailsEntity)
            {
                PurchaseInvoiceDetailEntity pqEntity = new PurchaseInvoiceDetailEntity();
                pqEntity.PINo = Convert.ToString(item.SelectedPSID);
                pqEntity.PandSCode = item.PandSCode;
                pqEntity.PandSName = item.PandSName;
                pqEntity.PIQty = item.PQQty;
                pqEntity.PIPrice = item.PQPrice;
                pqEntity.PIDiscount = Math.Round((decimal)item.PQDiscount,2);
                pqEntity.GSTRate = item.GSTRate;
                pqEntity.GSTRateStr = Convert.ToString(item.GSTRate) + "%";
                pqEntity.PIAmount = item.PQAmount;
                if (item.SelectedPSID != null && Convert.ToInt32(item.SelectedPSID) > 0)
                {
                    PQForm.InvoiceDetails.Add(pqEntity);
                }
            }
            return PQForm;
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

        

        #endregion
    }
}
