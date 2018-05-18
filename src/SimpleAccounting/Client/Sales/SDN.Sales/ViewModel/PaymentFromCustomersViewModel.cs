
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.ViewModel
{
    using SDN.UI.Entities.Sales;
    using System.Windows.Input;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using SDN.Common;
    using SDN.Sales.Services;
    using SDN.Sales.Views;
    using SDN.UI.Entities;

    using System.Windows;
    using System.Collections.ObjectModel;
    using Customers.Views;
    using System.ComponentModel;
    using CashBank.Services;

    public class PaymentFromCustomersViewModel : PaymentFromCustomerEntity
    {
        #region "Private Members"
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private ICustomerRepository CustomerRepository = new CustomerRepository();
        private IPaymentFromCustomersRepository psRepository = new PaymentFromCustomersRepository();
        private IAccountDetailsService accRepository = new AccountDetailsService();
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private ObservableCollection<CollectSalesAmountDataGridViewModel> pqDetailsEntity;
        private ObservableCollection<CollectSalesAmountDataGridViewModel> pqDetailsEntityLst;
        private PaymentFromCustomerEntity paymentFromCustomerEntity;

        private int? selectedCustomerID;
        private int? selectedAccountID;
        private bool? isChequeFalse;
        private bool? isChequeTrue;
        private string currencyName;
        private string dateFormat;
        private bool? isCustomerEnabled;
        private bool? isTextBoxReadOnly;
        private bool? isCashChequeEnabled;
        int? OptionDefId = 0;
        #endregion

        #region "Properties"
        public PaymentFromCustomerEntity PaymentFromCustomerEntity
        {
            get { return paymentFromCustomerEntity; }
            set
            {
                paymentFromCustomerEntity = value;
                OnPropertyChanged("PaymentFromCustomerEntity");
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
        public bool? IsCashChequeEnabled
        {
            get { return isCashChequeEnabled; }
            set
            {
                isCashChequeEnabled = value;
                OnPropertyChanged("IsCashChequeEnabled");
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
        public int? SelectedAccountID
        {
            get { return selectedAccountID; }
            set
            {
                selectedAccountID = value;
                OnPropertyChanged("SelectedAccountID");
                GetAccountDetails();
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

            }
        }
        public bool? IsChequeTrue
        {
            get { return isChequeTrue; }
            set
            {
                isChequeTrue = value;
                OnPropertyChanged("IsChequeTrue");

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
        private string piCount;

        public string POCount
        {
            get { return poCount; }
            set
            {
                poCount = value;
                OnPropertyChanged("POCount");
            }
        }
        public string PICount
        {
            get { return piCount; }
            set
            {
                piCount = value;
                OnPropertyChanged("PICount");
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
        public PaymentFromCustomersViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadCustomerBackground();

            NavigateToClientCommand = new RelayCommand(NavigateFromCustomer);
            SaveCommand = new RelayCommand(OnSavePS, CanSave);
            RefreshCommand = new RelayCommand(refreshcommand);
            SelectChangedCommand = new RelayCommand(GetPSData);
            NewPSCommand = new RelayCommand(GetNewPS);
            NavigaetoSalesCommand = new RelayCommand(NavigatetoSalesOrder);
            NavigaetoOrderCommand = new RelayCommand(NavigatetoSalesOrder);
            SalesNoChangedCommand = new RelayCommand(OnSalesNoChange);
            CashCheckedCommand = new RelayCommand(OnCashChecked);
            ChequeCheckedCommand = new RelayCommand(OnChequeChecked);

            this.AccountDetails = accRepository.GetAccountDetails().Where(e => e.AccountType == 2 || e.AccountType == 3).ToList();
            GetSuppliers();
            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {
                    IsCashChequeEnabled = false;
                    IsTextBoxReadOnly = true;
                    IsCustomerEnabled = false;
                    GetPaymentFromCustomerDetails(SharedValues.NewClick);
                }
                else if (SharedValues.NewClick == "New")
                {
                    IsCashChequeEnabled = true;
                    IsTextBoxReadOnly = false;
                    IsCustomerEnabled = true;
                    GetNewPS();
                }
            }
        }

        public PaymentFromCustomersViewModel()
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
        public RelayCommand CashCheckedCommand { get; set; }
        public RelayCommand ChequeCheckedCommand { get; set; }
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

            IsCashChequeEnabled = true;
            GetNewPS();
            SelectedCustomerID = 0;
            if (PQDetailsEntity != null)
            {
                if (PQDetailsEntity.Count > 0)
                {
                    PQDetailsEntity.Clear();
                    //var row = new CollectSalesAmountDataGridViewModel();
                    //PQDetailsEntity.Add(row);
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
                PaymentFromCustomerForm PSForm = GetDataIntoModel();
                string msg = ValidatePaymentFromCustomer();
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
                        int i = psRepository.SavePaymentFromCustomer(PSForm);
                        IsCustomerEnabled = false;
                        IsTextBoxReadOnly = true;
                        IsNew = false;
                    }
                    else
                    {
                        int i = psRepository.UpdatePaymentFromCustomer(PSForm);
                        IsCustomerEnabled = false;
                        IsTextBoxReadOnly = true;
                        IsNew = false;
                    }
                    Mouse.OverrideCursor = null;
                }
            }
        }

        public bool CanSave(object param)
        {
            if ((SelectedCustomerID != null || SelectedCustomerID != 0)
               && (SelectedAccountID != null || SelectedAccountID != 0)
               && !(string.IsNullOrEmpty(AmountStr)) && !(string.IsNullOrEmpty(CashChequeNo))
                && Date != null)
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

        void NavigateFromCustomer(object param)
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
                if (obj.StartsWith("SO"))
                {

                }
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
        public PaymentFromCustomerForm GetDataIntoModel()
        {
            PaymentFromCustomerForm PQForm = new PaymentFromCustomerForm();
            PQForm.PaymentFromCustomerDetails = new List<PaymentFromCustomerDetailsEntity>();
            PaymentFromCustomerEntity model = new PaymentFromCustomerEntity();
            //  this.ID = pqf.PaymentFromCustomer.ID;
            model.CustomerID = this.SelectedCustomerID;
            model.AccountId = this.SelectedAccountID;
            model.Date = this.Date;
            model.AmountStr = this.AmountStr;
            model.Amount = Convert.ToDecimal(this.AmountStr);
            model.IsCheque = this.IsCheque;
            model.CashChequeNo = this.CashChequeNo;
            model.Remarks = this.Remarks;
            if (this.IsChequeTrue == true)
            {
                model.IsCheque = true;
            }
            else
            {
                model.IsCheque = false;
            }

            PQForm.PaymentFromCustomer = model;

            foreach (var item in PQDetailsEntity)
            {
                PaymentFromCustomerDetailsEntity pqEntity = new PaymentFromCustomerDetailsEntity();

                pqEntity.SalesNo = item.SalesNo;
                pqEntity.SalesDate = item.SalesDate;
                pqEntity.SalesAmount = Convert.ToDecimal(item.SalesAmountStr);
                //item.SalesAmount=pqEntity.SalesAmount;
                if (item.PaymentDueDateStr != string.Empty)
                {
                    pqEntity.PaymentDueDate = Convert.ToDateTime(item.PaymentDueDateStr);
                }
                else
                {
                    pqEntity.PaymentDueDate = null;
                }
                //pqEntity.AmountDueStr = Convert.ToString(item.AmountDue);
                pqEntity.AmountDue = Convert.ToDecimal(item.AmountDueStr);
                // pqEntity.AmountAdjustedStr = Convert.ToString(item.AmountAdjusted);
                pqEntity.AmountAdjusted = Convert.ToDecimal(item.AmountAdjustedStr);

                pqEntity.Discount = Convert.ToDecimal(item.DiscountStr);

                PQForm.PaymentFromCustomerDetails.Add(pqEntity);
            }
            return PQForm;
        }

        private void OnCashChecked(object param)
        {
            IsTextBoxReadOnly = true;
            CashChequeNo = "PC-" + psRepository.GetLastCashNo();
        }

        private void OnChequeChecked(object param)
        {
            IsTextBoxReadOnly = false;
            CashChequeNo = string.Empty;
        }
        public void GetAccountDetails()
        {
            if (SelectedAccountID != 0 && SelectedAccountID != null && this.AccountDetails !=null)
            {
                var actType = this.AccountDetails.SingleOrDefault(e => e.AccountID == SelectedAccountID);
                if (actType != null)
                {
                    if (actType.AccountType == Convert.ToInt32(Account_Type.Bank))
                    {
                        IsChequeTrue = true;
                        IsChequeFalse = false;
                        IsTextBoxReadOnly = false;
                        CashChequeNo = string.Empty;
                    }
                    else
                    {
                        IsChequeTrue = false;
                        IsChequeFalse = true;
                        IsTextBoxReadOnly = true;
                        CashChequeNo = "PC-" + psRepository.GetLastCashNo();
                    }
                }
            }
        }
        private string ValidatePaymentFromCustomer()
        {
            string msg = string.Empty;
            foreach (var item in PQDetailsEntity)
            {
                if (string.IsNullOrEmpty(item.AmountAdjustedStr))
                {
                    return msg = "Please enter Amount Adjusted";
                }
                else
                {
                    item.AmountAdjusted = Convert.ToDecimal(item.AmountAdjustedStr);
                    item.Discount = Convert.ToDecimal(item.DiscountStr);
                }
            }

            if (IsNew == true)
            {
                if (!string.IsNullOrEmpty(CashChequeNo))
                {
                    if (psRepository.IsChequeNoPresent(CashChequeNo))
                    {
                        return msg = "Entry against Cheque No is already done";
                    }
                }
            }

            if (Convert.ToDecimal(AmountStr) != (PQDetailsEntity.Sum(e => e.AmountAdjusted)))
            {
                return msg = "Total of Amount Adjusted column must be equal to Cash/Cheque Amount.";
            }

            return msg;
        }

        private void GetPSData(object param)
        {
            if (SelectedCustomerID != null && SelectedCustomerID != 0)
            {
                PaymentFromCustomerForm pqf = psRepository.GetNewPS(SelectedCustomerID);
                GetModelData(pqf);
            }
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
        private void GetNewPS()
        {
            this.AmountStr = string.Empty;
            this.CashChequeNo = string.Empty;
            this.Remarks = string.Empty;
            IsChequeFalse = true;
            IsChequeTrue = false;
            Date = DateTime.Now.Date;
            this.ListCustomers = this.ListCustomers.OrderBy(x=>x.FirstName).Where(x => x.Inactive != "Y").ToList();
            //SelectedAccountID = OptionDefId;
            IsNew = true;
            CashChequeNo = "PC-" + psRepository.GetLastCashNo();
            IsTextBoxReadOnly = true;
            if (Convert.ToInt32(SharedValues.CollectCommand) != 0)
            {
                this.SelectedCustomerID = Convert.ToInt32(SharedValues.CollectCommand);
                GetPSData(null);
            }
        }

        private void GetModelData(PaymentFromCustomerForm pqf)
        {
            if (IsNew == false)
            {
                // this.ID = pqf.PaymentFromCustomer.ID;
                    this.SelectedCustomerID = pqf.PaymentFromCustomer.CustomerID;
                    this.SelectedAccountID = pqf.PaymentFromCustomer.AccountId;
                    this.Date = pqf.PaymentFromCustomer.Date;
                    this.AmountStr = pqf.PaymentFromCustomer.AmountStr;
                    this.IsCheque = pqf.PaymentFromCustomer.IsCheque;
                    this.CashChequeNo = pqf.PaymentFromCustomer.CashChequeNo;
                    this.Remarks = pqf.PaymentFromCustomer.Remarks;
               
                if (IsCheque == true)
                {
                    IsChequeTrue = true;
                    IsChequeFalse = false;
                }
                else
                {
                    IsChequeFalse = true;
                    IsChequeTrue = false;
                }
               
            }

            var result = pqf.PaymentFromCustomerDetails.OrderByDescending(e => e.CreatedDate).GroupBy(e => e.SalesNo).Select(e => e.First()).ToList();

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
                pqEntity.AmountDue = item.AmountDue;
                pqEntity.AmountDueStr = Convert.ToString(item.AmountDue);
                pqEntity.AmountAdjusted = item.AmountAdjusted;
                pqEntity.AmountAdjustedStr = Convert.ToString(item.AmountAdjusted);
                pqEntity.Discount = item.Discount;

                PQDetailsEntity.Add(pqEntity);
                OnPropertyChanged("PQDetailsEntity");
            }
            PQDetailsEntityLst = PQDetailsEntity;
        }

        private void GetPaymentFromCustomerDetails(string cashChequeNo)
        {
            this.ListCustomers = CustomerRepository.GetAllCustomers().ToList();
            IsNew = false;
            PaymentFromCustomerForm pqf = psRepository.GetPaymentFromCustomerDetails(cashChequeNo);
            GetModelData(pqf);

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
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 194;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.PtSFGridHeight = minHeight;

            RefreshData();
        }

        private void RefreshData()
        {
            // this.ListCustomers = CustomerRepository.GetAllCustomers().ToList();

            //this.ShowAllCount = SalesRepository.GetAllPurOrder().Count();
            GetOptionsandTaxValues();
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository SalesRepository = new SalesOrderListRepository();
            oData = SalesRepository.GetOptionSettings();
            if (oData != null)
            {
                CurrencyName = oData.CurrencyCode;
                DateFormat = oData.DateFormat;
                if (!string.IsNullOrWhiteSpace(oData.DefCashBankAcc))
                {
                    this.SelectedAccountID = Convert.ToInt32(oData.DefCashBankAcc);
                    OptionDefId = this.SelectedAccountID;
                }

            }
            TaxModel objDefaultTax = new TaxModel();
            objDefaultTax = SalesRepository.GetDefaultTaxes();

        }

        private void GetSuppliers()
        {
            IPaymentFromCustomersRepository SalesRepository = new PaymentFromCustomersRepository();
            List<CustomerEntity> lst1 = new List<CustomerEntity>();
            List<CustomerEntity> lst = new List<CustomerEntity>();
            POCount = psRepository.GetCountOfPOSuppliers(out lst1);
            PICount = psRepository.GetCountOfPISuppliers(out lst);
            if (lst != null)
            {
                var result = lst.Concat(lst1).GroupBy(e => e.CustomerID).Select(e => e.First()).ToList();
                this.ListCustomers = result;
            }
        }

        string changedateformat(DateTime? datetoConvert)
        {
            string convertedDate = string.Empty;
            string date = this.DateFormat as string;
            if (datetoConvert != null)
            {
                var tempdate = Convert.ToDateTime(datetoConvert).ToString(date);
                convertedDate = tempdate.Replace('-', '/');
            }
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
