﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SDN.Purchasing.ViewModel
{
    using System.Windows.Input;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    //using SDN.CashBank.Services;
    using SDN.Common;


    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    using System.Windows;

    using System.Globalization;

    using Sales.Services;
    using Sales.ViewModel;
    using Customers.Views;
    using Sales.Views;
    using CashBank.Services;

    public class AdjustCreditNoteViewModel : AdjustCreditNoteEntity
    {
        #region "Private Members"
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private ICustomerRepository supplierRepository = new CustomerRepository();
        private IAdjustCreditNoteFormRepository psRepository = new AdjustCreditNoteFormRepository();
        private IAccountDetailsService accRepository = new AccountDetailsService();
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private ObservableCollection<CollectSalesAmountDataGridViewModel> pqDetailsEntity;
        private ObservableCollection<CollectSalesAmountDataGridViewModel> pqDetailsEntityLst;
        private AdjustCreditNoteEntity paymentToCustomerEntity;

        private int? selectedCustomerID;
        private string selectedCustomerName;
        private int? selectedAccountID;
        private bool? isChequeFalse;
        private bool? isChequeTrue;
        private string currencyName;
        private string dateFormat;
        private bool? isCustomerEnabled;
        private bool? isCreditNoEnabled;
        private bool? _EditDatagrid;
        private bool? isTextBoxReadOnly;
        private string _CreditNoteNo;
        private bool? _EnableSaveButton;

        #endregion

        #region "Properties"
        public AdjustCreditNoteEntity AdjustCreditNoteEntity
        {
            get { return paymentToCustomerEntity; }
            set
            {
                paymentToCustomerEntity = value;
                OnPropertyChanged("AdjustCreditNoteEntity");
            }
        }
        public ObservableCollection<CollectSalesAmountDataGridViewModel> PQDetailsEntity
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
        public ObservableCollection<CollectSalesAmountDataGridViewModel> PQDetailsEntityLst
        {
            get
            {
                return pqDetailsEntityLst;
            }
            set
            {
                if (pqDetailsEntityLst != value)
                {
                    pqDetailsEntityLst = value;
                    OnPropertyChanged("PQDetailsEntityLst");
                }
            }
        }
        public bool? IsCustomerEnabled
        {
            get { return isCustomerEnabled; }
            set
            {
                isCustomerEnabled = value;
                OnPropertyChanged("IsCustomerEnabled");
            }
        }
        public bool? EnableSaveButton
        {
            get { return _EnableSaveButton; }
            set
            {
                _EnableSaveButton = value;
                OnPropertyChanged("EnableSaveButton");
            }
        }
        public bool? IsCreditNoEnabled
        {
            get { return isCreditNoEnabled; }
            set
            {
                isCreditNoEnabled = value;
                OnPropertyChanged("IsCreditNoEnabled");
            }
        }

        public bool? EditDatagrid
        {
            get { return _EditDatagrid; }
            set
            {
                _EditDatagrid = value;
                OnPropertyChanged("EditDatagrid");
            }
        }

        public int? SelectedCustomerID
        {
            get { return selectedCustomerID; }
            set
            {
                selectedCustomerID = value;
                OnPropertyChanged("SelectedCustomerID");

            }
        }
        public string SelectedCustomerName
        {
            get { return selectedCustomerName; }
            set
            {
                selectedCustomerName = value;
                OnPropertyChanged("SelectedCustomerName");

            }
        }

        public int? SelectedAccountID
        {
            get { return selectedAccountID; }
            set
            {
                selectedAccountID = value;
                OnPropertyChanged("SelectedAccountID");
            }
        }
        public string CreditNoteNo
        {
            get { return _CreditNoteNo; }
            set
            {
                _CreditNoteNo = value;
                OnPropertyChanged("CreditNoteNo");
            }
        }

        public bool? IsTextBoxReadOnly
        {
            get { return isTextBoxReadOnly; }
            set
            {
                isTextBoxReadOnly = value;
                OnPropertyChanged("IsTextBoxReadOnly");
            }
        }

        public bool? IsChequeFalse
        {
            get { return isChequeFalse; }
            set
            {
                isChequeFalse = value;
                OnPropertyChanged("IsChequeFalse");
                //OnCashChecked();
            }
        }
        public bool? IsChequeTrue
        {
            get { return isChequeTrue; }
            set
            {
                isChequeTrue = value;
                OnPropertyChanged("IsChequeTrue");
                // OnChequeChecked();
            }
        }
        private string psErrors;
        public string PSErrors
        {
            get { return psErrors; }
            set
            {
                psErrors = value;
                OnPropertyChanged("PSErrors");
            }
        }

        private bool? isNew;
        public bool? IsNew
        {
            get { return isNew; }
            set
            {
                isNew = value;
                OnPropertyChanged("IsNew");
            }
        }
        public string CurrencyName
        {
            get { return currencyName; }
            set
            {
                currencyName = value;
                OnPropertyChanged("CurrencyName");
            }
        }

        private string poCount;
        private string siCount;

        public string POCount
        {
            get { return poCount; }
            set
            {
                poCount = value;
                OnPropertyChanged("POCount");
            }
        }
        public string SICount
        {
            get { return siCount; }
            set
            {
                siCount = value;
                OnPropertyChanged("SICount");
            }
        }

        public string DateFormat
        {
            get { return dateFormat; }
            set
            {
                dateFormat = value;
                OnPropertyChanged("DateFormat");
            }
        }

        public string SelectedSalesNo
        {
            get; set;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderListViewModel"/> class.
        /// </summary>
        public AdjustCreditNoteViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadCustomerBackground();

            NavigateToClientCommand = new RelayCommand(NavigatetoCustomer);
            SaveCommand = new RelayCommand(OnSavePS, CanSave);
            RefreshCommand = new RelayCommand(refreshcommand);
            SelectChangedCommand = new RelayCommand(GetPSData);
            NewPSCommand = new RelayCommand(GetNewPS);
            NavigaetoSalesCommand = new RelayCommand(NavigatetoSalesOrder);
            NavigaetoOrderCommand = new RelayCommand(NavigatetoSalesOrder);
            SalesNoChangedCommand = new RelayCommand(OnSalesNoChange);

            this.AccountDetails = accRepository.GetAccountDetails().Where(e => e.AccountType == 2 || e.AccountType == 3).ToList();
            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {
                    IsCustomerEnabled = false;
                    IsCreditNoEnabled = false;
                    GetAdjustCreditNoteDetails(SharedValues.NewClick);
                }
                else if (SharedValues.NewClick == "New")
                {
                    IsCustomerEnabled = true;
                    IsCreditNoEnabled = true;
                    GetNewPS();
                }
            }
        }

        public AdjustCreditNoteViewModel()
        {
        }

        public RelayCommand NewPSCommand { get; set; }
        public RelayCommand NavigateToClientCommand { get; set; }
        public RelayCommand SalesNoChangedCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand NavigaetoSalesCommand { get; set; }
        public RelayCommand NavigaetoOrderCommand { get; set; }
        public RelayCommand SelectChangedCommand { get; set; }

        #endregion  Constructor

        #region ButtonCommands
        void refreshcommand(object param)
        {
            RefreshData();
        }

        void GetNewPS(object param)
        {
            IsNew = true;
            // SelectedCustomerID = 0;
            IsCustomerEnabled = true;
            IsCreditNoEnabled = true;
            PSErrors = string.Empty;
            GetNewPS();
            if (PQDetailsEntity != null)
            {
                if (PQDetailsEntity.Count > 0)
                {
                    PQDetailsEntity.Clear();
                    var row = new CollectSalesAmountDataGridViewModel();
                    PQDetailsEntity.Add(row);
                    OnPropertyChanged("PQDetailsEntity");
                }
            }
        }

        void OnSavePS(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                AdjustCreditNoteForm PSForm = GetDataIntoModel();
                string msg = ValidateAdjustCreditNote();
                if (msg != string.Empty)
                {
                    PSErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                PSErrors = string.Empty;

                if (PSForm != null)
                {
                    if (IsNew == true)
                    {
                        int i = psRepository.SaveAdjustCreditNote(PSForm);
                    }
                    else
                    {
                        int i = psRepository.UpdateAdjustCreditNote(PSForm);
                        if (i != null || i != 0)
                            this.EnableSaveButton = false;
                        else
                            this.EnableSaveButton = true;


                    }

                    Mouse.OverrideCursor = null;
                }
            }
        }

        public bool CanSave(object param)
        {
            if ((SelectedCustomerID != null || SelectedCustomerID != 0)
               && (SelectedAccountID != null || SelectedAccountID != 0)
               && !(string.IsNullOrEmpty(AmountStr)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void OnSalesNoChange(object param)
        {

            if (SelectedSalesNo != null)
            {
                PQDetailsEntity = new ObservableCollection<CollectSalesAmountDataGridViewModel>(PQDetailsEntityLst.Where(e => e.SalesNo == SelectedSalesNo).ToList());
            }
            else
            {
                PQDetailsEntity = PQDetailsEntityLst;
            }
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
        void NavigatetoSalesOrder(object param)
        {
            if (param != null)
            {
                string obj = param.ToString();
                SharedValues.NewClick = obj;
            }
            var tabview = ServiceLocator.Current.GetInstance<SalesTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<SalesOrderView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Order Form");
        }

        #endregion

        #region "Private methods"
        public AdjustCreditNoteForm GetDataIntoModel()
        {
            AdjustCreditNoteForm PQForm = new AdjustCreditNoteForm();
            PQForm.AdjustCreditNoteDetails = new List<AdjustCreditNoteDetailsEntity>();
            AdjustCreditNoteEntity model = new AdjustCreditNoteEntity();
            //  this.ID = pqf.AdjustCreditNote.ID;
            model.CustomerID = this.SelectedCustomerID;
            model.AccountId = this.SelectedAccountID;
            model.Date = this.Date;
            model.AmountStr = this.AmountStr;
            model.Amount = Convert.ToDecimal(this.AmountStr);
            model.IsCheque = this.IsCheque;
            //model.CashChequeNo = this.CashChequeNo;
            model.Remarks = this.Remarks;
            model.CreditNoteNo = this.CreditNoteNo;
            if (this.IsChequeTrue == true)
            {
                model.IsCheque = true;
            }
            else
            {
                model.IsCheque = false;
            }

            PQForm.AdjustCreditNote = model;

            foreach (var item in PQDetailsEntity)
            {
                AdjustCreditNoteDetailsEntity pqEntity = new AdjustCreditNoteDetailsEntity();

                pqEntity.SalesNo = item.SalesNo;
                pqEntity.SalesDate = item.SalesDate;
                pqEntity.SalesAmount = Convert.ToDecimal(item.SalesAmountStr);
                //item.SalesAmount=pqEntity.SalesAmount;
                //pqEntity.PaymentDueDate = Convert.ToDateTime(item.PaymentDueDateStr);
                pqEntity.PaymentDueDate = DateTime.ParseExact(item.PaymentDueDateStr, "dd'/'MM'/'yyyy", CultureInfo.InvariantCulture);
                //pqEntity.AmountDueStr = Convert.ToString(item.AmountDue);
                pqEntity.AmountDue = Convert.ToDecimal(item.AmountDueStr);
                // pqEntity.AmountAdjustedStr = Convert.ToString(item.AmountAdjusted);
                pqEntity.AmountAdjusted = Convert.ToDecimal(item.AmountAdjustedStr);

                pqEntity.Discount = Convert.ToDecimal(item.DiscountStr);
                pqEntity.CheckAmountAdjusted = item.CheckAmountAdjusted;

                PQForm.AdjustCreditNoteDetails.Add(pqEntity);
            }
            return PQForm;
        }

        private void OnCashChecked()
        {
            IsTextBoxReadOnly = false;
        }

        private void OnChequeChecked()
        {
            IsTextBoxReadOnly = false;
        }

        private string ValidateAdjustCreditNote()
        {
            string msg = string.Empty;
            int i = 0;
            foreach (var item in PQDetailsEntity)
            {

                if (string.IsNullOrEmpty(item.AmountAdjustedStr))
                {
                    //return msg = "Please enter Amount Adjusted";
                    item.CheckAmountAdjusted = false;
                }
                else
                {
                    i++;
                    item.CheckAmountAdjusted = true;
                    item.AmountAdjusted = Convert.ToDecimal(item.AmountAdjustedStr);
                    item.Discount = Convert.ToDecimal(item.DiscountStr);
                }

                if (i == 0)
                {
                    return msg = "Please enter Amount Adjusted";
                }
            }

            if (IsNew == true)
            {
                //if (!string.IsNullOrEmpty(CashChequeNo))
                //{
                //    if (psRepository.IsChequeNoPresent(CashChequeNo))
                //    {
                //        return msg = "Entry against Cheque No is already done";
                //    }
                //}
            }

            if (Convert.ToDecimal(AmountStr) != (PQDetailsEntity.Sum(e => e.AmountAdjusted)))
            {
                return msg = "Total of Amount Adjusted column must be equal to Credit Note Amount.";
            }

            return msg;
        }

        private void GetPSData(object param)
        {
            if (SelectedCustomerID != null && SelectedCustomerID != 0)
            {
                AdjustCreditNoteForm pqf = psRepository.GetNewPS(SelectedCustomerID);
                GetModelData(pqf);
            }
        }

        private void GetNewPS()
        {
            this.AmountStr = string.Empty;
            // this.CashChequeNo = string.Empty;
            this.Remarks = string.Empty;
            IsChequeFalse = true;
            IsChequeTrue = false;
            Date = DateTime.Now.Date;
            SelectedAccountID = 0;
            this.ListCustomers = this.ListCustomers.OrderBy(x=>x.FirstName).Where(x => x.Inactive != "Y").ToList();

        }

        private void GetModelData(AdjustCreditNoteForm pqf)
        {
            if (IsNew == false)
            {
                this.ID = pqf.AdjustCreditNote.ID;
                this.SelectedCustomerID = pqf.AdjustCreditNote.CustomerID;
                this.CreditNoteNo = pqf.AdjustCreditNote.CreditNoteNo;
                this.SelectedAccountID = pqf.AdjustCreditNote.AccountId;
                this.Date = pqf.AdjustCreditNote.Date;
                this.AmountStr = pqf.AdjustCreditNote.AmountStr;
                this.IsCheque = pqf.AdjustCreditNote.IsCheque;
                if (IsCheque == true)
                {
                    IsChequeTrue = true;
                }
                else
                {
                    IsChequeFalse = true;
                }
                //this.CashChequeNo = pqf.AdjustCreditNote.CashChequeNo;
                this.Remarks = pqf.AdjustCreditNote.Remarks;
                if (this.ListCustomers != null)
                {
                    foreach (var item in this.ListCustomers)
                    {
                        if (item.CustomerID == this.SelectedCustomerID)
                            this.SelectedCustomerName = item.Name;
                    }
                }
            }

            var result = pqf.AdjustCreditNoteDetails.OrderByDescending(e => e.UpdatedDate).GroupBy(e => e.SalesNo).Select(e => e.First()).ToList();

            this.PQDetailsEntity = new ObservableCollection<CollectSalesAmountDataGridViewModel>();
            foreach (var item in result)
            {
                CollectSalesAmountDataGridViewModel pqEntity = new CollectSalesAmountDataGridViewModel();
                pqEntity.SalesNo = item.SalesNo;
                pqEntity.SalesDate = item.SalesDate;
                pqEntity.SalesDateStr = changedateformat(item.SalesDate);
                pqEntity.SalesAmountStr = Convert.ToString(item.SalesAmount);
                pqEntity.SalesAmount = item.SalesAmount;
                pqEntity.PaymentDueDate = item.PaymentDueDate;
                pqEntity.PaymentDueDateStr = changedateformat(item.PaymentDueDate);
                pqEntity.AmountDueStr = Convert.ToString(item.AmountDue);
                //pqEntity.AmountDue = item.AmountDue;
                //pqEntity.AmountAdjusted = item.AmountAdjusted;
                //pqEntity.AmountAdjustedStr = Convert.ToString(item.AmountAdjusted);
                //pqEntity.Discount = item.Discount;

                PQDetailsEntity.Add(pqEntity);
                OnPropertyChanged("PQDetailsEntity");
            }
            PQDetailsEntityLst = PQDetailsEntity;
        }

        private void GetAdjustCreditNoteDetails(string CreditNoteNo)
        {
            IsNew = false;
            AdjustCreditNoteForm pqf = psRepository.GetAdjustCreditNoteDetails(CreditNoteNo);
            pqf.AdjustCreditNote.Amount = Math.Abs(decimal.Parse(pqf.AdjustCreditNote.Amount.ToString()));
            pqf.AdjustCreditNote.AmountStr = Math.Abs(decimal.Parse(pqf.AdjustCreditNote.AmountStr)).ToString();
            GetModelData(pqf);

        }

        public void OnAmountChange(int index)
        {
            var query = PQDetailsEntity.ToList();

            if (query != null)
            {
                query[index].AmountAdjustedStr = query[index].AmountDueStr;
                //query[index].AmountDueStr = Convert.ToString("0");
            }
            // OnPropertyChanged("PQDetailsEntity");
        }

        #endregion

        #region BackgroundWorked
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
        List<SalesOrderListEntity> DefaultList = new List<SalesOrderListEntity>();
        List<SalesOrderListEntity> FullPQList = new List<SalesOrderListEntity>();
        private void LoadCustomerBackground(object sender, DoWorkEventArgs e)
        {

            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 120;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.PtSFGridHeight = minHeight;

            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                //IAdjustCreditNoteFormRepository purchaseRepository = new AdjustCreditNoteFormRepository();
                this.ListCustomers = psRepository.GetAllCustomer().ToList();



                //this.ShowAllCount = purchaseRepository.GetAllPurOrder().Count();
                GetOptionsandTaxValues();
                //POCount = psRepository.GetCountOfPOCustomers();
                SICount = psRepository.GetCountOfSICustomers();
            }
            catch (Exception ex)
            {

            }
        }

        void GetCreditNoteList(string CustomerId)
        {
            try
            {
                this.ListCreditNoteEntity = psRepository.GetCreditNotes(CustomerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            if (oData != null)
            {
                CurrencyName = oData.CurrencyCode;
                DateFormat = oData.DateFormat;
            }
            TaxModel objDefaultTax = new TaxModel();
            objDefaultTax = purchaseRepository.GetDefaultTaxes();

        }

        string changedateformat(DateTime? datetoConvert)
        {
            string convertedDate = string.Empty;
            string date = this.DateFormat as string;
            var tempdate = Convert.ToDateTime(datetoConvert).ToString(date);
            convertedDate = tempdate.Replace('-', '/');
            return convertedDate;
        }
        void changeNumberformat(List<SalesOrderListEntity> entity)
        {
            //int decimalpoints = Convert.ToInt32(this.DecimalPlaces);
            //foreach (var item in entity)
            //{
            //    //item.QuotationAmount = item.QuotationAmountIncGST;
            //    if (item.OrderAmount != null && item.OrderAmount != "")
            //        item.OrderAmount = Math.Round(Convert.ToDouble(item.OrderAmount), decimalpoints).ToString();
            //}
        }

        protected override void OnPropertyChanged(string name)
        {
            switch (name)
            {
                case "SelectedCustomerID":
                    GetCreditNoteList(this.SelectedCustomerID.ToString());
                    break;
            }
            base.OnPropertyChanged(name);
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
    }
}