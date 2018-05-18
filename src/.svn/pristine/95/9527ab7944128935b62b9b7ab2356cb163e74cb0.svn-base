
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

    using System.Globalization;
    using Sales.Services;
    using SASClient.CloseRequest;
    using Microsoft.Practices.Prism.Commands;
    using Settings.Services;

    public class AdjustDebitNoteViewModel : AdjustDebitNoteEntity
    {
        #region "Private Members"
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _DateErrors;
        private DateTime? _AdjustDebitDateCalender;
        ICompanyDetails CompanyD = new CompanyDetails();
        private ObservableCollection<QuarterEntity> _quarterlist = new ObservableCollection<QuarterEntity>();
        private ObservableCollection<MonthEntity> _monthlist = new ObservableCollection<MonthEntity>();
        private ISupplierRepository supplierRepository = new SupplierRepository();
        private IAdjustDebitNoteFormRepository psRepository = new AdjustDebitNoteFormRepository();
        private IPaymentToSupplierFormRepository payRepository = new PaymentToSupplierFormRepository();
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private ObservableCollection<CollectAmountDataGridViewModel> pqDetailsEntity;
        private ObservableCollection<CollectAmountDataGridViewModel> pqDetailsEntityLst;
        private AdjustDebitNoteEntity paymentToSupplierEntity;
        StackList listitem = new StackList();
        private int? selectedSupplierID;
        private string selectedSupplierName;
        private int? selectedAccountID;
        private bool? isChequeFalse;
        private bool? isChequeTrue;
        private string currencyName;
        private string dateFormat;
        private bool? isSupplierEnabled;
        private bool? isDebitNoEnabled;
        private bool? _EditDatagrid;
        private bool? isTextBoxReadOnly;
        private string _DebitNoteNo;
        private bool? _EnableSaveButton;

        #endregion

        #region "Properties"
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
        public DateTime? AdjustDebitDateCalender
        {
            get
            {
                return _AdjustDebitDateCalender;
            }
            set
            {
                _AdjustDebitDateCalender = value;
                OnPropertyChanged("AdjustDebitDateCalender");
            }
        }
        public AdjustDebitNoteEntity AdjustDebitNoteEntity
        {
            get { return paymentToSupplierEntity; }
            set
            {
                paymentToSupplierEntity = value;
                OnPropertyChanged("AdjustDebitNoteEntity");
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
            set
            {
                isSupplierEnabled = value;
                OnPropertyChanged("IsSupplierEnabled");
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
        public bool? IsDebitNoEnabled
        {
            get { return isDebitNoEnabled; }
            set
            {
                isDebitNoEnabled = value;
                OnPropertyChanged("IsDebitNoEnabled");
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

        public int? SelectedSupplierID
        {
            get { return selectedSupplierID; }
            set
            {
                selectedSupplierID = value;
                OnPropertyChanged("SelectedSupplierID");

            }
        }
        public string SelectedSupplierName
        {
            get { return selectedSupplierName; }
            set
            {
                selectedSupplierName = value;
                OnPropertyChanged("SelectedSupplierName");

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
        public string DebitNoteNo
        {
            get { return _DebitNoteNo; }
            set
            {
                _DebitNoteNo = value;
                OnPropertyChanged("DebitNoteNo");
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

        public string SelectedPurchaseNo
        {
            get; set;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderListViewModel"/> class.
        /// </summary>
        public AdjustDebitNoteViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();

            NavigateToClientCommand = new RelayCommand(NavigatetoSupplier);
            SaveCommand = new RelayCommand(OnSavePS, CanSave);
            RefreshCommand = new RelayCommand(refreshcommand);
            SelectChangedCommand = new RelayCommand(GetPSData);
            NewPSCommand = new RelayCommand(GetNewPS);
            NavigaetoPurchaseCommand = new RelayCommand(NavigatetoPurchaseOrder);
            NavigaetoOrderCommand = new RelayCommand(NavigatetoPurchaseOrder);
            PurchaseNoChangedCommand = new RelayCommand(OnPurchaseNoChange);
            CloseCommand = new DelegateCommand(Close);
            this.AdjustDebitNoteDate = DateTime.Now;
            this.AccountDetails = payRepository.GetAccountDetails().Where(e => e.AccountType == 2 || e.AccountType == 3).ToList();
            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {
                   
                    var temp = SharedValues.NewClick.ToString();
                    var sub = temp.Substring(0, 2);
                    if(sub=="DN")
                    {
                        IsSupplierEnabled = false;
                        IsDebitNoEnabled = false;
                        MustCompare = false;
                        GetAdjustDebitNoteDetails(SharedValues.NewClick);

                    }
                    else 
                    {
                        IsSupplierEnabled = false;
                        IsDebitNoEnabled = false;
                        MustCompare = true;
                        AdjustedDebitNoteDetails(SharedValues.NewClick);
                    }
                   
                }
                else if (SharedValues.NewClick == "New")
                {
                    IsSupplierEnabled = true;
                    IsDebitNoEnabled = true;
                    GetNewPS();
                }
            }
        }

        public AdjustDebitNoteViewModel()
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
            IsSupplierEnabled = true;
            IsDebitNoEnabled = true;
            PSErrors = string.Empty;
           
            GetNewPS();
            if (PQDetailsEntity != null)
            {
                if (PQDetailsEntity.Count > 0)
                {
                    PQDetailsEntity.Clear();
                    var row = new CollectAmountDataGridViewModel();
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
                string msg = ValidateAdjustDebitNote();
                AdjustDebitNoteForm PSForm = GetDataIntoModel();
                
                if (msg != string.Empty)
                {
                    PSErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                PSErrors = string.Empty;

                if (PSForm != null)
                {
                    int type = Convert.ToInt32(CashBankTransactionType.AdjustDebitNote);
                    if (IsNew == true)
                    {
                        int i = psRepository.SaveAdjustDebitNote(PSForm, type);
                    }
                    else
                    {
                        int i = psRepository.UpdateAdjustDebitNote(PSForm,type);
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
            string date = this.DateFormat as string;
            var c = CompanyD.GetCompanyDetails().Comp_year_start_date;
            if ((SelectedSupplierID != null || SelectedSupplierID != 0)
               && (SelectedAccountID != null && SelectedAccountID != 0)
               && !(string.IsNullOrEmpty(AmountStr)))
            {
                return true;
            }
            if (AdjustDebitNoteDateStr != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(AdjustDebitNoteDateStr) && !string.IsNullOrWhiteSpace(AdjustDebitNoteDateStr))
                    {

                        //item.StartDate = item.StartDate.Replace('.', '/');
                        //item.StartDate = item.StartDate.Replace('-', '/');
                        //item.EndDate = item.EndDate.Replace('.', '/');
                        //item.EndDate = item.EndDate.Replace('-', '/');
                        var Start = (DateTime.ParseExact(AdjustDebitNoteDateStr, date, CultureInfo.InvariantCulture));
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

            if (SelectedPurchaseNo != null)
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
        public AdjustDebitNoteForm GetDataIntoModel()
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            AdjustDebitNoteForm PQForm = new AdjustDebitNoteForm();
            PQForm.AdjustDebitNoteDetails = new List<AdjustDebitNoteDetailsEntity>();
            AdjustDebitNoteEntity model = new AdjustDebitNoteEntity();
            //  this.ID = pqf.AdjustDebitNote.ID;
            model.SupplierID = this.SelectedSupplierID;
            model.AccountId = this.SelectedAccountID;
            model.Date = this.Date;
            model.AmountStr = this.AmountStr;
            model.Amount = Convert.ToDecimal(this.AmountStr);
            model.IsCheque = this.IsCheque;
            //model.CashChequeNo = this.CashChequeNo;
            model.Remarks = this.Remarks;
            model.DebitNoteNo = this.DebitNoteNo;
            model.AdjustDebitNoteNumber = this.AdjustDebitNoteNumber;
            model.AdjustDebitNoteDate = DateTime.ParseExact(this.AdjustDebitNoteDateStr, oData.DateFormat, null);
            if (this.IsChequeTrue == true)
            {
                model.IsCheque = true;
            }
            else
            {
                model.IsCheque = false;
            }

            PQForm.AdjustDebitNote = model;

            foreach (var item in PQDetailsEntity.Where(e => !(string.IsNullOrEmpty(e.AmountAdjustedStr))))
            {
                AdjustDebitNoteDetailsEntity pqEntity = new AdjustDebitNoteDetailsEntity();

                pqEntity.PurchaseNo = item.PurchaseNo;
                pqEntity.PurchaseDate = item.PurchaseDate;
                pqEntity.PurchaseAmount = Convert.ToDecimal(item.PurchaseAmountStr);
                //item.PurchaseAmount=pqEntity.PurchaseAmount;
                //pqEntity.PaymentDueDate = Convert.ToDateTime(item.PaymentDueDateStr);
                pqEntity.PaymentDueDate = DateTime.ParseExact(item.PaymentDueDateStr, "dd'/'MM'/'yy", CultureInfo.InvariantCulture);
                //pqEntity.AmountDueStr = Convert.ToString(item.AmountDue);
                pqEntity.AmountDue = Convert.ToDecimal(item.AmountDueStr);
                // pqEntity.AmountAdjustedStr = Convert.ToString(item.AmountAdjusted);
                pqEntity.AmountAdjusted = Convert.ToDecimal(item.AmountAdjustedStr);

                pqEntity.Discount = Convert.ToDecimal(item.DiscountStr);
                pqEntity.CheckAmountAdjusted = item.CheckAmountAdjusted;

                PQForm.AdjustDebitNoteDetails.Add(pqEntity);
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

        private string ValidateAdjustDebitNote()
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
            }
            if (i == 0)
            {
                return msg = "Please enter Amount Adjusted";
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
                return msg = "Total of Amount Adjusted column must be equal to Debit Note Amount.";
            }

            return msg;
        }

        private void GetPSData(object param)
        {
            if (SelectedSupplierID != null && SelectedSupplierID != 0)
            {
                AdjustDebitNoteForm pqf = psRepository.GetNewPS(SelectedSupplierID);
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
            this.ListSuppliers = psRepository.GetAllSupplier().Where(e=>e.IsInActive!="Y").OrderBy(s => s.SupplierName).ToList();
        }

        private void GetModelData(AdjustDebitNoteForm pqf)
        {
            if (IsNew == false)
            {
                this.ID = pqf.AdjustDebitNote.ID;
                this.SelectedSupplierID = pqf.AdjustDebitNote.SupplierID;
                this.DebitNoteNo = pqf.AdjustDebitNote.DebitNoteNo;
                this.SelectedAccountID = pqf.AdjustDebitNote.AccountId;
                this.Date = pqf.AdjustDebitNote.Date;
                this.AmountStr = pqf.AdjustDebitNote.AmountStr;
                this.IsCheque = pqf.AdjustDebitNote.IsCheque;
                this.AdjustDebitNoteNumber = pqf.AdjustDebitNote.AdjustDebitNoteNumber;
               
               
                if (IsCheque == true)
                {
                    IsChequeTrue = true;
                }
                else
                {
                    IsChequeFalse = true;
                }
                //this.CashChequeNo = pqf.AdjustDebitNote.CashChequeNo;
                this.Remarks = pqf.AdjustDebitNote.Remarks;
                if (this.ListSuppliers != null)
                {
                    foreach (var item in this.ListSuppliers)
                    {
                        if (item.ID == this.SelectedSupplierID)
                            this.SelectedSupplierName = item.SupplierName;
                    }
                }
            }

            var result = pqf.AdjustDebitNoteDetails.OrderByDescending(e => e.UpdatedDate).GroupBy(e => e.PurchaseNo).Select(e => e.First()).ToList();
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            this.PQDetailsEntity = new ObservableCollection<CollectAmountDataGridViewModel>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    CollectAmountDataGridViewModel pqEntity = new CollectAmountDataGridViewModel();
                    pqEntity.PurchaseNo = item.PurchaseNo;
                    if(item.PurchaseDate != null)
                    {
                        pqEntity.PurchaseDate = item.PurchaseDate;
                        DateTime Dateinstr = (DateTime)item.PurchaseDate;
                        pqEntity.PurchaseDateStr = Dateinstr.ToString(oData.DateFormat);
                    }
                    else
                    {

                    }
                    pqEntity.PurchaseAmountStr = Convert.ToString(item.PurchaseAmount);
                    pqEntity.PurchaseAmount = item.PurchaseAmount;
                    if(item.PaymentDueDate != null)
                    {
                        pqEntity.PaymentDueDate = item.PaymentDueDate;
                        DateTime Dateinstr1 = (DateTime)item.PaymentDueDate;
                        pqEntity.PaymentDueDateStr = changedateformat(item.PaymentDueDate);
                    }
                    else
                    {

                    }
                    pqEntity.AmountDueStr = Convert.ToString(item.AmountDue);
                    //pqEntity.AmountDue = item.AmountDue;
                    pqEntity.AmountAdjusted = item.AmountAdjusted;
                    pqEntity.AmountAdjustedStr = Convert.ToString(item.AmountAdjusted);
                    //pqEntity.Discount = item.Discount;

                    PQDetailsEntity.Add(pqEntity);
                    TotalPurchaseAmount = Convert.ToString(PQDetailsEntity.Sum(e => e.PurchaseAmount));
                    TotalAdjutedAmount= Convert.ToString(PQDetailsEntity.Sum(e => e.AmountAdjusted));
                    OnPropertyChanged("PQDetailsEntity");
                }
            }
            PQDetailsEntityLst = PQDetailsEntity;
        }

        private void GetAdjustDebitNoteDetails(string DebitNoteNo)
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            IsNew = false;
            AdjustDebitNoteForm pqf = psRepository.GetAdjustDebitNoteDetails(DebitNoteNo);
            pqf.AdjustDebitNote.Amount = Math.Abs(decimal.Parse(pqf.AdjustDebitNote.Amount.ToString()));
            pqf.AdjustDebitNote.AmountStr = Math.Abs(decimal.Parse(pqf.AdjustDebitNote.AmountStr)).ToString();
            pqf.AdjustDebitNote.AdjustDebitNoteNumber = "AD-" + psRepository.GetLatestInvoiceNo();
            if (pqf.AdjustDebitNote.AdjustDebitNoteDate == null)
            {
                this.AdjustDebitNoteDateStr = "";
            }
            else
            {
                DateTime Dateinstr = (DateTime)pqf.AdjustDebitNote.AdjustDebitNoteDate;
                this.AdjustDebitNoteDateStr = Dateinstr.ToString(oData.DateFormat);
            }
            GetModelData(pqf);
           

        }
        private void AdjustedDebitNoteDetails(string AdjustedNo)
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            IsNew = false;
            AdjustDebitNoteForm pqf = psRepository.AdjustDebitNoteDetails(AdjustedNo);
            pqf.AdjustDebitNote.Amount = Math.Abs(decimal.Parse(pqf.AdjustDebitNote.Amount.ToString()));
            pqf.AdjustDebitNote.AmountStr = Math.Abs(decimal.Parse(pqf.AdjustDebitNote.AmountStr)).ToString();
            pqf.AdjustDebitNote.MustCompare = true;
            if (pqf.AdjustDebitNote.AdjustDebitNoteDate == null)
            {
                this.AdjustDebitNoteDateStr = "";
            }
            else
            {
                DateTime Dateinstr = (DateTime)pqf.AdjustDebitNote.AdjustDebitNoteDate;
                this.AdjustDebitNoteDateStr = Dateinstr.ToString(oData.DateFormat);
            }
            GetModelData(pqf);
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

            // decimal? totalOfAdjustedAmount = query.Sum(x => Convert.ToDecimal(x.AmountAdjustedStr)); 
            TotalAdjutedAmount = Convert.ToString(PQDetailsEntity.Sum(e => e.AmountAdjusted));
            //OnPropertyChanged("PQDetailsEntity");
        }
        public void OnAmountChangeAgain(int index)
        {
            var query = PQDetailsEntity.ToList();
            if(query!=null)
            {
                query[index].AmountAdjustedStr = query[index].AmountAdjustedStr;
                query[index].AmountAdjusted = Convert.ToDecimal(query[index].AmountAdjustedStr);
            }
            TotalAdjutedAmount = Convert.ToString(pqDetailsEntity.Sum(e => e.AmountAdjusted));
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
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 150;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.PtSFGridHeight = minHeight;

            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                //IAdjustDebitNoteFormRepository purchaseRepository = new AdjustDebitNoteFormRepository();
                this.ListSuppliers = psRepository.GetAllSupplier().OrderBy(s=>s.SupplierName).ToList();
                
                //this.ShowAllCount = purchaseRepository.GetAllPurOrder().Count();
                GetOptionsandTaxValues();
                //POCount = psRepository.GetCountOfPOSuppliers();
                PICount = psRepository.GetCountOfPISuppliers();
            }
            catch (Exception ex)
            {

            }
        }

        void GetDebitNoteList(string SupplierId)
        {
            try
            {
                this.ListDebitNoteEntity = psRepository.GetDebitNotes(SupplierId);
            }
            catch (Exception ex)
            {
                throw ex;
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
            }
            TaxModel objDefaultTax = new TaxModel();
            objDefaultTax = purchaseRepository.GetDefaultTaxes().FirstOrDefault();

        }

        string changedateformat(DateTime? datetoConvert)
        {
            string convertedDate = string.Empty;
            string date = this.DateFormat as string;
            var tempdate = Convert.ToDateTime(datetoConvert).ToString(date);
            convertedDate = tempdate.Replace('-', '/');
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
            switch (name)
            {
                case "SelectedSupplierID":
                    GetDebitNoteList(this.SelectedSupplierID.ToString());
                    break;
                case "AdjustDebitDateCalender":
                    FillStartDate();
                    break;
            }
            base.OnPropertyChanged(name);
        }
        void FillStartDate()
        {
            string date = this.DateFormat as string;
            AdjustDebitNoteDateStr = Convert.ToDateTime(this.AdjustDebitDateCalender).ToString(date);

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
