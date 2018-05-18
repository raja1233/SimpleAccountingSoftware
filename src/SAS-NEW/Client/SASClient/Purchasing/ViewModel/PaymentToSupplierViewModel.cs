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
    using SDN.Purchasing.Services;
    using SDN.Purchasing.View;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    using System.Windows;
    using SASClient.CashBank.Services;
    using SASClient.CloseRequest;
    using Microsoft.Practices.Prism.Commands;
    using Settings.Services;
    using System.Globalization;
    using Sales.Services;

    public class PaymentToSupplierViewModel : PaymentToSupplierEntity
    {
        #region "Private Members"
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _DateErrors;
        private DateTime? _PayToSupDateCalender;
        ICompanyDetails CompanyD = new CompanyDetails();
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private ISupplierRepository supplierRepository = new SupplierRepository();
        private IReceiveMoneyRepository rmRepository = new ReceiveMoneyRepository();
        private IPaymentToSupplierFormRepository psRepository = new PaymentToSupplierFormRepository();
      //  private IAccountDetailsService accRepository = new AccountDetailsService();
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private ObservableCollection<CollectAmountDataGridViewModel> pqDetailsEntity;
        private ObservableCollection<CollectAmountDataGridViewModel> pqDetailsEntityLst;
        private PaymentToSupplierEntity paymentToSupplierEntity;
        StackList listitem = new StackList();

        private int? selectedSupplierID;
        private int? selectedAccountID;
        private bool? isChequeFalse;
        private bool? isChequeTrue;
        private string currencyName;
        private string dateFormat;
        private bool? isSupplierEnabled;
        private bool? isCashChequeEnabled;
        private bool? isTextBoxReadOnly;
        private int piGridHeight;


        #endregion

        #region "Properties"
        public PaymentToSupplierEntity PaymentToSupplierEntity
        {
            get { return paymentToSupplierEntity; }
            set { paymentToSupplierEntity = value;
                OnPropertyChanged("PaymentToSupplierEntity");
            }
        }
        public ObservableCollection<CollectAmountDataGridViewModel> PQDetailsEntity
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
        public DateTime? PayToSupDateCalender
        {
            get
            {
                return _PayToSupDateCalender;
            }
            set
            {
                _PayToSupDateCalender = value;
                OnPropertyChanged("PayToSupDateCalender");
            }
        }
        public ObservableCollection<CollectAmountDataGridViewModel> PQDetailsEntityLst
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

        public bool? IsSupplierEnabled
        {
            get { return isSupplierEnabled; }
            set { isSupplierEnabled = value;
                OnPropertyChanged("IsSupplierEnabled");
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
        public int? SelectedSupplierID
        {
            get { return selectedSupplierID; }
            set { selectedSupplierID = value;
                OnPropertyChanged("SelectedSupplierID");
               // GetPSData(null);
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
            set { isTextBoxReadOnly = value;
                OnPropertyChanged("IsTextBoxReadOnly");
            }
        }

        public bool? IsChequeFalse
        {
            get { return isChequeFalse; }
            set { isChequeFalse = value;
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
        public string PSErrors { get { return psErrors; }
            set
            {
                psErrors = value;
                OnPropertyChanged("PSErrors");
            }
        }

        public int PIGridHeight
        {
              get { return piGridHeight; }
            set
            {
                piGridHeight = value;
                OnPropertyChanged("PIGridHeight");
            }
        }
        
        private bool? isNew;
        public bool? IsNew { get { return isNew; } set { isNew = value;
                OnPropertyChanged("IsNew");
            } }
        public string CurrencyName
        {
            get { return currencyName; }
            set { currencyName = value;
                OnPropertyChanged("CurrencyName");
            }
        }

        private  string poCount;
        private string piCount;

        public string POCount {
            get { return poCount; }
            set { poCount = value;
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
            set { dateFormat = value;
                OnPropertyChanged("DateFormat");
            }
        }

        public string SelectedPurchaseNo
        {
            get;set;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderListViewModel"/> class.
        /// </summary>
        public PaymentToSupplierViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            CloseCommand = new DelegateCommand(Close);
            NavigateToClientCommand = new RelayCommand(NavigatetoSupplier);
            SaveCommand = new RelayCommand(OnSavePS,CanSave);
            RefreshCommand = new RelayCommand(refreshcommand);
            SelectChangedCommand = new RelayCommand(GetPSData);
            NewPSCommand = new RelayCommand(GetNewPS);
            NavigaetoPurchaseCommand = new RelayCommand(NavigatetoPurchaseOrder);
            NavigaetoOrderCommand = new RelayCommand(NavigatetoPurchaseOrder);
            PurchaseNoChangedCommand = new RelayCommand(OnPurchaseNoChange);
            CashCheckedCommand = new RelayCommand(OnCashChecked);
            ChequeCheckedCommand = new RelayCommand(OnChequeChecked);

            this.AccountDetails = rmRepository.GetAccountDetails().Where(e => e.AccountType == Convert.ToInt32(Account_Type.Bank) || e.AccountType == Convert.ToInt32(Account_Type.Cash) || e.AccountType == Convert.ToByte(Account_Type.CreditCard)).ToList();
            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {
                    MustCompare = false;
                    IsCashChequeEnabled = false;
                    IsTextBoxReadOnly = true;
                       IsSupplierEnabled = false;
                    GetPaymentToSupplierDetails(SharedValues.NewClick);
                }
                else if (SharedValues.NewClick == "New")
                {
                    MustCompare = true;
                    IsCashChequeEnabled = true;
                    IsTextBoxReadOnly = false;
                       IsSupplierEnabled = true;
                    GetNewPS();
                }
            }
        }

        public PaymentToSupplierViewModel()
        {
        }
        public ICommand CloseCommand { get; set; }
        public RelayCommand NewPSCommand { get; set; }
        public RelayCommand NavigateToClientCommand { get; set; }
        public RelayCommand PurchaseNoChangedCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand NavigaetoPurchaseCommand { get; set; }
        public RelayCommand NavigaetoOrderCommand { get; set; }
        public RelayCommand CashCheckedCommand { get; set; }
        public RelayCommand ChequeCheckedCommand { get; set; }
        public RelayCommand SelectChangedCommand { get; set; }

        #endregion  Constructor

        #region ButtonCommands
        void refreshcommand(object param)
        {
            RefreshData();
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
        void GetNewPS(object param)
        {
            IsNew = true;
            // SelectedSupplierID = 0;
            IsCashChequeEnabled = true;
             IsSupplierEnabled = true;
            IsTextBoxReadOnly = false;
            PSErrors = string.Empty;
            
            GetNewPS();
            SelectedSupplierID = 0;
            if (PQDetailsEntity != null)
            {
                if (PQDetailsEntity.Count > 0)
                {
                     PQDetailsEntity.Clear();
                    // var row = new CollectAmountDataGridViewModel();
                    //  PQDetailsEntity.Add(row);
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
                PaymentToSupplierForm PSForm = GetDataIntoModel();
                string msg = ValidatePaymentToSupplier();
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
                        int i = psRepository.SavePaymentToSupplier(PSForm);
                        IsSupplierEnabled = false;
                        IsTextBoxReadOnly = true;
                        IsNew = false;
                    }
                    else
                    {
                        int i = psRepository.UpdatePaymentToSupplier(PSForm);
                        IsNew = false;
                        IsSupplierEnabled = false;
                        IsTextBoxReadOnly = true;
                    }
                   
                    Mouse.OverrideCursor = null;   
                }
            }
        }

      
        public bool CanSave(object param)
        {
            string date = this.DateFormat as string;
            var c = CompanyD.GetCompanyDetails().Comp_year_start_date;

            if ((SelectedSupplierID != null || SelectedSupplierID != 0)
               && (SelectedAccountID != null || SelectedAccountID != 0)
               && !(string.IsNullOrEmpty(AmountStr)) && !(string.IsNullOrEmpty(CashChequeNo)) 
              && Date!=null)
            {
                return true;
            }
            if (DateStr != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(DateStr) && !string.IsNullOrWhiteSpace(DateStr))
                    {

                        //item.StartDate = item.StartDate.Replace('.', '/');
                        //item.StartDate = item.StartDate.Replace('-', '/');
                        //item.EndDate = item.EndDate.Replace('.', '/');
                        //item.EndDate = item.EndDate.Replace('-', '/');
                        var Start = (DateTime.ParseExact(DateStr, date, CultureInfo.InvariantCulture));
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
                return false;
            }
        }

        void OnPurchaseNoChange(object param)
        {
           
            if (SelectedPurchaseNo!=null)
            {
                PQDetailsEntity = new ObservableCollection<CollectAmountDataGridViewModel>(PQDetailsEntityLst.Where(e => e.PurchaseNo == SelectedPurchaseNo).ToList());
            }
            else
            {
                PQDetailsEntity = PQDetailsEntityLst;
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
        void NavigatetoPurchaseOrder(object param)
        {
            SharedValues.ScreenCheckName = "Purchase Order";
            SharedValues.ViewName = "Purchase Order";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                if (param != null)
            {
                string obj = param.ToString();
                SharedValues.NewClick = obj;
            }
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PurchaseOrderView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Order Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        #endregion

        #region "Private methods"
        public void GetAccountDetails()
        {
            if (SelectedAccountID != 0  || SelectedAccountID!=null)
            {
                var actType = AccountDetails.SingleOrDefault(e => e.AccountID == SelectedAccountID);
                if (actType != null)
                {
                    if (actType.AccountType == Convert.ToByte(Account_Type.Cash) && actType.IsLinked == true)
                    {
                        IsChequeTrue = false;
                        IsChequeFalse = true;
                        IsTextBoxReadOnly = true;
                        CashChequeNo = "PS-" + psRepository.GetLastCashNo();
                        IsCheque = false;
                    }
                    else
                    {
                        IsChequeTrue = true;
                        IsChequeFalse = false;
                        IsTextBoxReadOnly = false;
                        CashChequeNo = string.Empty;
                        IsCheque = true;
                    }
                }
            }
        }
        public PaymentToSupplierForm GetDataIntoModel()
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            PaymentToSupplierForm PQForm = new PaymentToSupplierForm();
            PQForm.PaymentToSupplierDetails = new List<PaymentToSupplierDetailsEntity>();
            PaymentToSupplierEntity model = new PaymentToSupplierEntity();
            //  this.ID = pqf.PaymentToSupplier.ID;
            model.SupplierID = this.SelectedSupplierID;
            model.AccountId = this.SelectedAccountID;
            model.Date = DateTime.ParseExact(this.DateStr, oData.DateFormat, null);
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

            PQForm.PaymentToSupplier = model;

            foreach (var item in PQDetailsEntity.Where(e=> Convert.ToDecimal(e.AmountAdjustedStr)!=0))
            {
                PaymentToSupplierDetailsEntity pqEntity = new PaymentToSupplierDetailsEntity();

                pqEntity.PurchaseNo=item.PurchaseNo;
                pqEntity.PurchaseDate=item.PurchaseDate ;
                pqEntity.PurchaseAmount= Convert.ToDecimal(item.PurchaseAmountStr);
                //item.PurchaseAmount=pqEntity.PurchaseAmount;
                if (item.PaymentDueDateStr != string.Empty)
                {
                    // pqEntity.PaymentDueDate = Convert.ToDateTime(item.PaymentDueDateStr);
                    pqEntity.PaymentDueDate = Utility.SimpleDateTime(item.PaymentDueDateStr);
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

                PQForm.PaymentToSupplierDetails.Add(pqEntity);
            }
            return PQForm;
        }

   
        private void OnCashChecked(object param)
        {
            IsTextBoxReadOnly = true;
            CashChequeNo = "PS-" + psRepository.GetLastCashNo();
        }

        private void OnChequeChecked(object param)
        {
            IsTextBoxReadOnly = false;
            CashChequeNo = string.Empty;
        }

        private string ValidatePaymentToSupplier()
        {
            string msg = string.Empty;
            foreach (var item in PQDetailsEntity)
            {
                if(string.IsNullOrEmpty(item.AmountAdjustedStr))
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

        public void OnAmountChanged()
        {
            // PQDetailsEntity.Select(t => t.AmountDueStr);
        }

        private void GetPSData(object param)
        {
            if (SelectedSupplierID != null && SelectedSupplierID!=0)
            {
                PaymentToSupplierForm pqf = psRepository.GetNewPS(SelectedSupplierID);
                GetModelData(pqf);
            }
        }

        private void GetNewPS()
        {
            this.AmountStr = string.Empty;
            this.CashChequeNo = string.Empty;
            this.Remarks = string.Empty;
            IsChequeFalse = true;
            IsChequeTrue = false;
            Date = DateTime.Now.Date;
            IsNew = true;
            CashChequeNo = "PS-" + psRepository.GetLastCashNo();
            IsTextBoxReadOnly = true;
            this.ListSuppliers = supplierRepository.GetAllSupplier().Where(e => e.IsInActive != "Y").OrderBy(s => s.SupplierName).ToList();
            if (Convert.ToInt32(SharedValues.CollectCommand) != 0)
            {
                this.SelectedSupplierID = Convert.ToInt32(SharedValues.CollectCommand);
                GetPSData(null);
            }
        }

        private void GetModelData(PaymentToSupplierForm pqf)
        { 
            if(IsNew==false)
            {
           // this.ID = pqf.PaymentToSupplier.ID;
            this.SelectedSupplierID = pqf.PaymentToSupplier.SupplierID;
            this.SelectedAccountID = pqf.PaymentToSupplier.AccountId;
           
            this.AmountStr = pqf.PaymentToSupplier.AmountStr;
            this.IsCheque = pqf.PaymentToSupplier.IsCheque;
                if(IsCheque==true)
                {
                    IsChequeTrue = true;
                    IsChequeFalse = false;
                }
                else
                {
                    IsChequeFalse = true;
                    IsChequeTrue = false;
                }
            this.CashChequeNo = pqf.PaymentToSupplier.CashChequeNo;
            this.Remarks = pqf.PaymentToSupplier.Remarks;
            }

            var result = pqf.PaymentToSupplierDetails.OrderByDescending(e => e.CreatedDate).GroupBy(e => e.PurchaseNo).Select(e => e.First()).ToList();

            this.PQDetailsEntity = new ObservableCollection<CollectAmountDataGridViewModel>();
            foreach (var item in result)
            {
                CollectAmountDataGridViewModel pqEntity = new CollectAmountDataGridViewModel();
                pqEntity.PurchaseNo = item.PurchaseNo;
                pqEntity.PurchaseDate = item.PurchaseDate;
                pqEntity.PurchaseDateStr = changedateformat(item.PurchaseDate);
                pqEntity.PurchaseAmountStr = Convert.ToString(item.PurchaseAmount);
                pqEntity.PurchaseAmount = item.PurchaseAmount;
                pqEntity.PaymentDueDate = item.PaymentDueDate;
                pqEntity.PaymentDueDateStr = changedateformat(item.PaymentDueDate);
                pqEntity.AmountDue = item.AmountDue;
                pqEntity.AmountDueStr = Convert.ToString(item.AmountDue);             
                pqEntity.AmountAdjusted = item.AmountAdjusted;
                pqEntity.AmountAdjustedStr = Convert.ToString(item.AmountAdjusted);
                pqEntity.Discount = item.Discount;
                pqEntity.DiscountStr = Convert.ToString(item.Discount);

                PQDetailsEntity.Add(pqEntity);
                OnPropertyChanged("PQDetailsEntity");
            }

            TotalSalesAmount = Convert.ToString(PQDetailsEntity.Sum(e => e.PurchaseAmount));
            TotalAmountDue = Convert.ToString(PQDetailsEntity.Sum(e => e.AmountDue));
            TotalAmountPaid = Convert.ToString(PQDetailsEntity.Sum(e => e.AmountAdjusted));

            PQDetailsEntityLst = PQDetailsEntity;
        }
      

        private void GetPaymentToSupplierDetails(string cashChequeNo)
        {

            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            this.ListSuppliers = supplierRepository.GetAllSupplier().ToList();
            IsNew = false;
            PaymentToSupplierForm pqf = psRepository.GetPaymentToSupplierDetails(cashChequeNo);
            DateTime Dateinstr = (DateTime)pqf.PaymentToSupplier.Date;
            this.DateStr = Dateinstr.ToString(oData.DateFormat);
            GetModelData(pqf);
            
        }

        #endregion

        #region BackgroundWorked
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
        List<PurchaseOrderListEntity> DefaultList = new List<PurchaseOrderListEntity>();
        List<PurchaseOrderListEntity> FullPQList = new List<PurchaseOrderListEntity>();
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {
           
            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 205;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.PtSFGridHeight = minHeight;

            RefreshData();
        }

        public void OnAmountChange(int index)
        {
            var query = PQDetailsEntity.ToList();
          
            if (query != null)
            {
               query[index].AmountAdjustedStr = query[index].AmountDueStr;
                query[index].AmountAdjusted = Convert.ToDecimal(query[index].AmountAdjustedStr);
                //query[index].AmountDueStr = Convert.ToString("0");
            }

            TotalSalesAmount = Convert.ToString(PQDetailsEntity.Sum(e => e.PurchaseAmount));
            TotalAmountDue = Convert.ToString(PQDetailsEntity.Sum(e => e.AmountDue));
            TotalAmountPaid = Convert.ToString(PQDetailsEntity.Sum(e => e.AmountAdjusted));
            // OnPropertyChanged("PQDetailsEntity");
        }
        public void OnAmountChangeAgain(int index)
        {
            var query = PQDetailsEntity.ToList();
            if (query != null)
            {
                query[index].AmountAdjustedStr = query[index].AmountAdjustedStr;
                query[index].AmountAdjusted = Convert.ToDecimal(query[index].AmountAdjustedStr);
            }
            TotalAmountPaid = Convert.ToString(pqDetailsEntity.Sum(e => e.AmountAdjusted));
        }

        private void RefreshData()
        {
            try
            {
                List<SupplierDetailEntity> lst1 = new List<SupplierDetailEntity>();
                List<SupplierDetailEntity> lst = new List<SupplierDetailEntity>();
                IPaymentToSupplierFormRepository purchaseRepository = new PaymentToSupplierFormRepository();
                //this.ListSuppliers = supplierRepository.GetAllSupplier().ToList();

                POCount = psRepository.GetCountOfPOSuppliers(out lst1);
                PICount = psRepository.GetCountOfPISuppliers(out lst);
                if (lst != null)
                {
                    var result = lst.Concat(lst1).GroupBy(e => e.ID).Select(e => e.First()).ToList();
                    ListSuppliers = result.OrderBy(e=>e.SupplierName).ToList();
                }
                GetOptionsandTaxValues();
               
            }
            catch(Exception ex)
            {

            }
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            IPurchaseOrderListRepository purchaseRepository = new PurchaseOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            if (oData != null)
            {
                CurrencyName = oData.CurrencyCode;
                DateFormat = oData.DateFormat;
                if (!string.IsNullOrWhiteSpace(oData.DefCashBankAcc))
                {
                    this.SelectedAccountID = Convert.ToInt32(oData.DefCashBankAcc);
                }
            }
            TaxModel objDefaultTax = new TaxModel();
            objDefaultTax = purchaseRepository.GetDefaultTaxes().FirstOrDefault();
           
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
        void changeNumberformat(List<PurchaseOrderListEntity> entity)
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
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(name));
            }
            switch (name)
            {
                case "PayToSupDateCalender":
                    FillStartDate();
                    break;


            }
            base.OnPropertyChanged(name);
        }
        void FillStartDate()
        {
            string date = this.DateFormat as string;
            DateStr = Convert.ToDateTime(this.PayToSupDateCalender).ToString(date);
           
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
    }
}
