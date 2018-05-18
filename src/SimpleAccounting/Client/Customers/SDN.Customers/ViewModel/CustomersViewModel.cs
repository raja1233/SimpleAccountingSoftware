﻿

namespace SDN.Customers.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using SDN.Common;
    using SDN.Customers.Services;
    using SDN.UI.Entities;
    using SDN.Customers.EDM;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Practices.Prism.Commands;
    using System.Text;

    using System.Text.RegularExpressions;
    using System.Globalization;

    public sealed class CustomersViewModel : ViewModelBase
    {

        #region Private Properties

        /// <summary>
        /// The customer collection
        /// </summary>
       // private List<CustomersEntity> customersData = new List<CustomersEntity>();
        private List<CatagoryType> _customerType;
        private List<CatagoryType> _salesmanType;
        private List<CatagoryType> creditLimitDays;
        private List<CatagoryType> creditLimitAmount;
        private List<CatagoryType> discount;
        private int _totalCustomer = 0;
        private int activeCustomer = 0;
        private int inActiveCustomer = 0;
        private string customerName;
        private int? selectedCreditLimitAmount;
        private readonly DelegateCommand saveClickCommand = null;
        private string comp_Reg_No;
        private Decimal? balance;
        private string selectedCustomerType;
        private int? selectedSalesman;
        private int? selectedCreditLimitDays;
        private int? selectedDiscount;
        private string telephone;
        private string fax;
        private string email;
        private string contactPerson;
        private string gstRegistrationNo;
        private bool? changeCustomerGST;
        private bool? _changeCustomerGSTTrue;
        private bool? _changeCustomerGSTFalse;
        private string remarks;


        private DelegateCommand newShippingClickCommand = null;
        private string shipAddressLine1;
        private string shipAddressLine2;
        private string shipCity;
        private string shipCountry;
        private string shipState;
        private string shipPostalCode;
        private List<Customer> _SearchCustomer;
        private int _SelectedSearchCustmer;
        private string _Cus_Bill_to_city;
        private string _Cus_Bill_to_country;
        private string _Cus_Bill_to_line1;
        private string _Cus_Bill_to_line2;
        private string _Cus_Bill_to_post_code;
        private string _Cus_Bill_to_state;
        private int id;
        private string checkInActive;
        private DelegateCommand sameAsBillingAddressCommand = null;
        private DelegateCommand previousCommand = null;
        private DelegateCommand nextCommand = null;
        private DelegateCommand newCustomerClickCommand = null;
        private DelegateCommand deleteCustomerClickCommand = null;
        private string _currencyName = "USD";
        private string _GSTName = "GST";
        private int loginId = 1;//Login id will be the user who logged in in the system.
        public bool isNew = false;
        private DelegateCommand cancelClickCommand;
        private bool? canchangClADiscount;
        private bool? compRegiteredForGST;
        private string _currencyFormat;
        private string _currencyCode;
        private string _dateFormat = "dd/MM/yyyy";
        private string _defaultTaxName;
        private decimal? _defaultTaxRate;
        private string _lastupdatedDate;
        private DelegateCommand refreshCommand;
        private bool? _BackwardEnabled;
        private bool? _ForwardEnabled;


        #endregion  Private Properties

        #region Public Properties


        public string CustomerName
        {
            get { return customerName; }

            set
            {
                if (customerName != value)
                {
                    customerName = value;
                    OnPropertyChanged("CustomerName");

                }
            }
        }

        public int ID
        {
            get { return id; }

            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("ID");

                }
            }
        }

        public List<CatagoryType> CustomerType
        {
            get { return _customerType; }

            set
            {
                if (_customerType != value)
                {
                    _customerType = value;
                    OnPropertyChanged("CustomerType");

                }
            }

        }
        public List<CatagoryType> CreditLimitDays
        {
            get { return creditLimitDays; }

            set
            {
                if (creditLimitDays != value)
                {
                    creditLimitDays = value;
                    OnPropertyChanged("CreditLimitDays");
                }
            }
        }
        public List<CatagoryType> CreditLimitAmount
        {
            get { return creditLimitAmount; }

            set
            {
                if (creditLimitAmount != value)
                {
                    creditLimitAmount = value;
                    OnPropertyChanged("CreditLimitAmount");
                }
            }
        }

        public int? SelectedCreditLimitAmount
        {
            get { return selectedCreditLimitAmount; }

            set
            {
                if (selectedCreditLimitAmount != value)
                {
                    selectedCreditLimitAmount = value;
                    OnPropertyChanged("SelectedCreditLimitAmount");
                }
            }
        }
        public List<CatagoryType> Discount
        {
            get { return discount; }

            set
            {
                if (discount != value)
                {
                    discount = value;
                    OnPropertyChanged("Discount");
                }
            }
        }
        public List<TaxModel> TaxandRateList
        {
            get { return _taxCodeandRate; }

            set
            {
                if (_taxCodeandRate != value)
                {
                    _taxCodeandRate = value;
                    OnPropertyChanged("TaxandRateList");
                }
            }
        }
        public int? SelectedTaxId
        {
            get
            {
                return _selectedTaxid;
            }
            set
            {
                if (_selectedTaxid != value)
                {
                    _selectedTaxid = value;
                    OnPropertyChanged("SelectedTaxId");
                }
            }
        }
        public TaxModel SelectedTaxModel
        {
            get
            {

                return _selectedTaxModel;
            }
            set
            {
                _selectedTaxModel = value;
                OnPropertyChanged("SelectedTaxModel");
            }
        }
        public List<CatagoryType> SalesmanType
        {
            get { return _salesmanType; }

            set
            {
                if (_salesmanType != value)
                {
                    _salesmanType = value;
                    OnPropertyChanged("SalesmanType");

                }
            }
        }


        public int TotalCustomer
        {
            get { return _totalCustomer; }

            set
            {
                if (_totalCustomer != value)
                {
                    _totalCustomer = value;
                    OnPropertyChanged("TotalCustomer");

                }
            }
        }
        public int ActiveCustomer
        {
            get { return activeCustomer; }

            set
            {
                if (activeCustomer != value)
                {
                    activeCustomer = value;
                    OnPropertyChanged("ActiveCustomer");

                }
            }
        }

        public int InActiveCustomer
        {
            get { return inActiveCustomer; }

            set
            {
                if (inActiveCustomer != value)
                {
                    inActiveCustomer = value;
                    OnPropertyChanged("InActiveCustomer");
                }
            }
        }
        public string IsInActive
        {
            get
            {

                return checkInActive;
            }

            set
            {

                if (checkInActive != value)
                {
                    checkInActive = value;
                    OnPropertyChanged("IsInActive");
                }

            }
        }
        public string Comp_Reg_No
        {
            get { return comp_Reg_No; }

            set
            {
                if (comp_Reg_No != value)
                {
                    comp_Reg_No = value;
                    OnPropertyChanged("Comp_Reg_No");
                }
            }
        }
        public Decimal? Balance
        {
            get { return balance; }

            set
            {
                if (balance != value)
                {
                    balance = value;
                    OnPropertyChanged("Balance");
                }
            }
        }
        public string SelectedCustomerType
        {
            get { return selectedCustomerType; }

            set
            {
                if (selectedCustomerType != value)
                {
                    selectedCustomerType = value;
                    OnPropertyChanged("SelectedCustomerType");
                }
            }
        }
        public int? SelectedSalesman
        {
            get { return selectedSalesman; }

            set
            {
                if (selectedSalesman != value)
                {
                    selectedSalesman = value;
                    OnPropertyChanged("SelectedSalesman");
                }
            }
        }
        public int? SelectedCreditLimitDays
        {
            get { return selectedCreditLimitDays; }

            set
            {
                if (selectedCreditLimitDays != value)
                {
                    selectedCreditLimitDays = value;
                    OnPropertyChanged("SelectedCreditLimitDays");
                }
            }
        }
        public int? SelectedDiscount
        {
            get { return selectedDiscount; }

            set
            {
                if (selectedDiscount != value)
                {
                    selectedDiscount = value;
                    OnPropertyChanged("SelectedDiscount");
                }
            }
        }
        public string Telephone
        {

            get
            {

                if (telephone == null)
                {
                    return this.telephone;
                }
                else if (telephone.Length > 3 && telephone.Length < 7)
                {
                    return Regex.Replace(telephone, @"(\d{3})(\d{4})", "$1-$2");
                }
                else if (telephone.Length > 9 && telephone.Length <= 10)
                {
                    return Regex.Replace(telephone, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");

                }
                else if (telephone.Length > 10)
                {
                    return Regex.Replace(telephone, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");
                }
                else
                {
                    return telephone;
                }
            }
            set
            {
                if (telephone != value)
                {
                    telephone = value;
                    OnPropertyChanged("Telephone");
                }
            }
        }
        public string Fax
        {
            get
            {

                if (fax == null)
                {
                    return this.fax;
                }
                else if (fax.Length >= 3 && fax.Length < 7)
                {
                    return Regex.Replace(fax, @"(\d{3})(\d{4})", "$1-$2");
                }
                else if (fax.Length > 9 && fax.Length <= 10)
                {
                    return Regex.Replace(fax, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");

                }
                else if (fax.Length > 10)
                {
                    return Regex.Replace(fax, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");
                }
                else
                {
                    return fax;
                }
            }

            set
            {
                if (fax != value)
                {
                    fax = value;
                    OnPropertyChanged("Fax");
                }
            }
        }
        public string Email
        {
            get { return email; }

            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string ContactPerson
        {
            get { return contactPerson; }

            set
            {
                if (contactPerson != value)
                {
                    contactPerson = value;
                    OnPropertyChanged("ContactPerson");
                }
            }
        }
        public string GstRegistrationNo
        {
            get { return gstRegistrationNo; }

            set
            {
                if (gstRegistrationNo != value)
                {
                    gstRegistrationNo = value;
                    OnPropertyChanged("GstRegistrationNo");
                }
            }
        }
        //public bool? ChangeCustomerGST
        //{
        //    get { return changeCustomerGST; }

        //    set
        //    {
        //        if (changeCustomerGST != value)
        //        {
        //            changeCustomerGST = value;
        //            OnPropertyChanged("ChangeCustomerGST");
        //        }
        //    }
        //}

        public bool? ChangeCustomerGST
        {
            get
            {
                return changeCustomerGST;
            }
            set
            {
                if (ChangeCustomerGSTTrue == true)
                {
                    changeCustomerGST = true;
                }
                else if (ChangeCustomerGSTFalse == true)
                {
                    changeCustomerGST = false;
                }
                else
                {
                    changeCustomerGST = value;
                }

                OnPropertyChanged("ChangeCustomerGST");
            }
        }
        public bool? ChangeCustomerGSTTrue
        {
            get
            {
                return _changeCustomerGSTTrue;
            }
            set
            {
                _changeCustomerGSTTrue = value;
                ChangeCustomerGST = true;
                OnPropertyChanged("ChangeCustomerGSTTrue");
            }
        }
        public bool? ChangeCustomerGSTFalse
        {
            get
            {
                return _changeCustomerGSTFalse;
            }
            set
            {
                _changeCustomerGSTFalse = value;
                ChangeCustomerGST = false;
                OnPropertyChanged("ChangeCustomerGSTFalse");
            }
        }

        public string Remarks
        {
            get { return remarks; }

            set
            {
                if (remarks != value)
                {
                    remarks = value;
                    OnPropertyChanged("Remarks");
                }
            }
        }
        //public int SelectedShippingAddress
        //{
        //    get { return selectedShippingAddress; }

        //    set
        //    {
        //        if (selectedShippingAddress != value)
        //        {
        //            selectedShippingAddress = value;
        //            OnChangeShippingAddress();
        //            OnPropertyChanged("SelectedShippingAddress");
        //        }
        //    }
        //}
        //private void OnChangeShippingAddress()
        //{

        //    this.ClearShippingAddress();
        //    var shipAddress = this.ShippingAddresses.FirstOrDefault(x => x.ID == this.SelectedShippingAddress);
        //    if (shipAddress != null)
        //    {
        //        this.ShipAddressLine1 = shipAddress.Ship_to_line1;
        //        this.ShipAddressLine2 = shipAddress.Ship_to_line2;
        //        this.ShipCity = shipAddress.Ship_to_city;
        //        this.ShipCountry = shipAddress.Ship_to_country;
        //        this.ShipState = shipAddress.Ship_to_state;
        //        this.ShipPostalCode = shipAddress.Ship_to_post_code;
        //    }
        //}
        public string ShipAddressLine1
        {
            get { return shipAddressLine1; }

            set
            {
                if (shipAddressLine1 != value)
                {
                    shipAddressLine1 = value;
                    OnPropertyChanged("ShipAddressLine1");
                }
            }
        }
        public string ShipAddressLine2
        {
            get { return shipAddressLine2; }

            set
            {
                if (shipAddressLine2 != value)
                {
                    shipAddressLine2 = value;
                    OnPropertyChanged("ShipAddressLine2");
                }
            }
        }
        public string ShipCity
        {
            get { return shipCity; }

            set
            {
                if (shipCity != value)
                {
                    shipCity = value;
                    OnPropertyChanged("ShipCity");
                }
            }
        }
        public string ShipCountry
        {
            get { return shipCountry; }

            set
            {
                if (shipCountry != value)
                {
                    shipCountry = value;
                    OnPropertyChanged("ShipCountry");
                }
            }
        }
        public string ShipState
        {
            get { return shipState; }

            set
            {
                if (shipState != value)
                {
                    shipState = value;
                    OnPropertyChanged("ShipState");
                }
            }
        }
        public string CurrencyFormat
        {
            get { return _currencyFormat; }

            set
            {
                if (_currencyFormat != value)
                {
                    _currencyFormat = value;
                    OnPropertyChanged("CurrencyFormat");
                }
            }
        }

        public string DateFormat
        {
            get
            {
                return _dateFormat;

            }
            set
            {
                if (_dateFormat != value)
                {
                    _dateFormat = value;
                    OnPropertyChanged("DateFormat");
                }
            }

        }
        public string CurrencyCode
        {
            get { return _currencyCode; }

            set
            {
                if (_currencyCode != value)
                {
                    _currencyCode = value;
                    OnPropertyChanged("CurrencyCode");
                }
            }
        }
        public string ShipPostalCode
        {
            get { return shipPostalCode; }

            set
            {
                if (shipPostalCode != value)
                {
                    shipPostalCode = value;
                    OnPropertyChanged("ShipPostalCode");
                }
            }
        }

        public List<Customer> SearchCustomer
        {
            get { return _SearchCustomer; }
            set
            {
                if (_SearchCustomer != value)
                {
                    _SearchCustomer = value;
                    OnPropertyChanged("SearchCustomer");
                }
            }
        }

        public int SelectedSearchCustmer
        {
            get { return _SelectedSearchCustmer; }
            set
            {
                if (_SelectedSearchCustmer != value)
                {
                    _SelectedSearchCustmer = value;
                    OnPropertyChanged("SelectedSearchCustmer");
                }
            }
        }

        public string Cus_Bill_to_city
        {
            get
            {
                return _Cus_Bill_to_city;
            }
            set
            {
                if (_Cus_Bill_to_city != value)
                {
                    _Cus_Bill_to_city = value;
                    OnPropertyChanged("Cus_Bill_to_city");
                }
            }
        }
        public string Cus_Bill_to_country
        {
            get
            {
                return _Cus_Bill_to_country;
            }
            set
            {
                if (_Cus_Bill_to_country != value)
                {
                    _Cus_Bill_to_country = value;
                    OnPropertyChanged("Cus_Bill_to_country");
                }
            }
        }
        public string Cus_Bill_to_line1
        {
            get
            {
                return _Cus_Bill_to_line1;
            }
            set
            {
                if (_Cus_Bill_to_line1 != value)
                {
                    _Cus_Bill_to_line1 = value;
                    OnPropertyChanged("Cus_Bill_to_line1");
                }
            }
        }
        public string Cus_Bill_to_line2
        {
            get
            {
                return _Cus_Bill_to_line2;
            }
            set
            {
                if (_Cus_Bill_to_line2 != value)
                {
                    _Cus_Bill_to_line2 = value;
                    OnPropertyChanged("Cus_Bill_to_line2");
                }
            }
        }
        public string Cus_Bill_to_post_code
        {
            get
            {
                return _Cus_Bill_to_post_code;
            }
            set
            {
                if (_Cus_Bill_to_post_code != value)
                {
                    _Cus_Bill_to_post_code = value;
                    OnPropertyChanged("Cus_Bill_to_post_code");
                }
            }
        }
        public string Cus_Bill_to_state
        {
            get
            {
                return _Cus_Bill_to_state;
            }
            set
            {
                if (_Cus_Bill_to_state != value)
                {
                    _Cus_Bill_to_state = value;
                    OnPropertyChanged("Cus_Bill_to_state");
                }
            }
        }

        public string CurrencyName
        {
            get
            {
                return _currencyName;
            }
            set
            {

                if (_currencyName != value)
                {
                    _currencyName = value;
                    OnPropertyChanged("CurrencyName");
                }
            }
        }

        public string GSTName
        {
            get
            {
                return _GSTName;
            }
            set
            {

                if (_GSTName != value)
                {
                    _GSTName = value;
                    OnPropertyChanged("GSTName");
                }
            }
        }

        private string errors;
        private int? _selectedTaxid;
        private List<TaxModel> _taxCodeandRate;
        private string _selectedTaxRate;
        private TaxModel _selectedTaxModel;

        public string CustomerErrors
        {
            get
            {
                return errors;
            }
            set
            {
                errors = value;
                OnPropertyChanged("CustomerErrors");
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

        public bool? IsAllowedToChangeCLA_and_Discount
        {

            get
            {
                return canchangClADiscount;
            }
            set
            {
                canchangClADiscount = value;
                OnPropertyChanged("IsAllowedToChangeCLA_and_Discount");
            }

        }
        public bool? IsCompanyRegisteredForGST
        {

            get
            {
                return compRegiteredForGST;
            }
            set
            {
                compRegiteredForGST = value;
                OnPropertyChanged("IsCompanyRegisteredForGST");
            }

        }

        public string TaxName
        {
            get
            {
                return _defaultTaxName;
            }
            set
            {
                _defaultTaxName = value;
                OnPropertyChanged("TaxName");
            }
        }
        public decimal? TaxRate
        {
            get
            {
                return _defaultTaxRate;
            }
            set
            {
                _defaultTaxRate = value;
                OnPropertyChanged("TaxRate");
            }
        }

        public bool? ForwardEnabled
        {
            get
            {
                return _ForwardEnabled;
            }
            set
            {
                _ForwardEnabled = value;
                OnPropertyChanged("ForwardEnabled");
            }
        }

        public bool? BackwardEnabled
        {
            get
            {
                return _BackwardEnabled;
            }
            set
            {
                _BackwardEnabled = value;
                OnPropertyChanged("BackwardEnabled");
            }
        }


        #endregion  Public Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersViewModel"/> class.
        /// </summary>
        public CustomersViewModel()
            : base()
        {
            SaveClickCommand = new RelayCommand(OnSaveCustomer, CanSave);
            DeleteCustomerClickCommand = new RelayCommand(OnDeleteCustomer, CanDelete);
            this.LoadCustomersBackground();
        }
        #endregion  Constructor
        #region Relay Commands

        public RelayCommand SaveClickCommand { get; set; }
        public RelayCommand DeleteCustomerClickCommand { get; set; }

        #endregion
        #region Background Worker

        /// <summary>
        /// Loads the customers background.
        /// </summary>
        private void LoadCustomersBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;

            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadCustomersBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadCustomersBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadCustomersBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadCustomersBackground(object sender, DoWorkEventArgs e)
        {
            GetOptionsAndTaxData();
            GetCustomerCreditLimit();
            //  ICustomerRepository customerRepository = new CustomerRepository();           
            //this.CustomerType = customerRepository.GetCatagoryType("CT").ToList();
            //this.SalesmanType = customerRepository.GetCatagoryType("SM").ToList();      

            RefreshData();
        }

        private void GetCustomerCreditLimit()
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            this.CustomerType = customerRepository.GetCatagoryType("CT").ToList();
            this.SalesmanType = customerRepository.GetCatagoryType("SM").ToList();
            this.CreditLimitDays = customerRepository.GetCatagoryType("CCLD").ToList();
            this.CreditLimitAmount = customerRepository.GetCatagoryType("CCLA").ToList();
            foreach (var item in this.CreditLimitAmount)
            {
                if (item.Cat_Contents != null && item.Cat_Contents != "")
                {
                    item.Cat_Contents_Display = Convert.ToInt32(item.Cat_Contents).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                    //item.Cat_Contents_Display = decimal.ToInt32(Convert.ToDecimal(withdecimal)).ToString();
                }

            }
            this.Discount = customerRepository.GetCatagoryType("CD").ToList();
            if (this.ID == -1)
            {
                var data = CreditLimitDays.Where(y => y.SetDefault == true).Select(x => x.ID).FirstOrDefault();
                if (data != 0)
                {
                    SelectedCreditLimitDays = Convert.ToInt32(data);
                }
                var data2 = CreditLimitAmount.Where(y => y.SetDefault == true).Select(x => x.ID).FirstOrDefault();
                if (data2 != 0)
                {
                    SelectedCreditLimitAmount = Convert.ToInt32(data2);
                }
                var data3 = Discount.Where(y => y.SetDefault == true).Select(x => x.ID).FirstOrDefault();
                if (data3 != 0)
                {
                    SelectedDiscount = Convert.ToInt32(data3);
                }
            }

        }
        private void GetOptionsAndTaxData()
        {
            OptionsEntity oData = new OptionsEntity();
            ICustomerRepository customerRepository = new CustomerRepository();
            oData = customerRepository.GetOptionSettings();
            if (oData != null)
            {
                this.CurrencyName = oData.CurrencyCode;     //there is no currency name field in database         
                this.CurrencyCode = oData.CurrencyCode;
                this.CurrencyFormat = oData.NumberFormat;
                this.DateFormat = oData.DateFormat;
            }
            else
            {
                this.CurrencyName = "USD";
                this.CurrencyCode = "USD";
                this.CurrencyFormat = "en-US";
                this.DateFormat = "dd/MM/yyyy";
            }
            this.TaxandRateList = customerRepository.GetTaxCodeAndRatesList();
            if (TaxandRateList != null)
            {
                this.TaxName = TaxandRateList.FirstOrDefault().TaxName;
            }
            else
            {
                this.TaxName = "GST";
            }

            TaxModel objDefaultTax = new TaxModel();
            objDefaultTax = customerRepository.GetDefaultTaxes();
            if (objDefaultTax != null)
            {
                
                this.TaxRate = objDefaultTax.TaxRate;
                this.SelectedTaxId = objDefaultTax.TaxID;
            }
            else
            {
               
                this.TaxRate = 0;
            }

        }
        private void RefreshData()
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            this.TotalCustomer = customerRepository.GetAllCustomers().Count();
            this.InActiveCustomer = customerRepository.GetCustomersCount("Y");
            this.ActiveCustomer = TotalCustomer - InActiveCustomer;
            this.SearchCustomer = customerRepository.GetAllCustomers().OrderBy(e=>e.Cus_Name).ToList();
            //  this.IsAllowedToChangeCLA_and_Discount = customerRepository.AllowedToChangeLimit();
            this.IsCompanyRegisteredForGST = customerRepository.IsCompanyRegisteredForGST();
            string setdateFormat = this.DateFormat == null ? "{0:dd/MM/yyyy}" : "{0:" + this.DateFormat + "}";
            int custId = 0;
            DateTime? dtRefresh = DateTime.UtcNow;
            if (SearchCustomer.Count > 0)
            {
                //var dataRefresh = SearchCustomer.Find(x => x.IsRefreshed != null && x.IsRefreshed == true);
                //if (dataRefresh != null)
                //{
                //    custId = dataRefresh.ID;
                //    this.SelectedSearchCustmer = custId;
                //    dtRefresh = (dataRefresh.RefreshedDate != null) ? DateTime.UtcNow : dataRefresh.RefreshedDate;
                //}
                //else
                //{

                int CustomerSelectedId = 0;
                if (SharedValues.getValue != null)
                {
                   bool isValid= Int32.TryParse(SharedValues.getValue,out CustomerSelectedId);
                }
                if (CustomerSelectedId != 0)
                {
                    this.SelectedSearchCustmer = CustomerSelectedId;
                }
                else
                {
                    custId = SearchCustomer[0].ID;
                    this.SelectedSearchCustmer = custId;
                    this.LastUpdateDate = String.Format(setdateFormat, this.SearchCustomer.OrderByDescending(x => x.CreatedDate).FirstOrDefault().CreatedDate);
                }
                //}
                //  this.LastUpdateDate = String.Format(setdateFormat, dtRefresh);
            }
            else
            {
                this.SelectedSearchCustmer = custId;
                this.ChangeCustomerGST = IsCompanyRegisteredForGST;
                this.LastUpdateDate = String.Format(setdateFormat, System.DateTime.Now);
            }
            this.GetData(this.SelectedSearchCustmer);

        }
        protected void OnPropertyChanged(string name)
        {
            switch (name)
            {
                case "SelectedSearchCustmer":
                    GetData(this.SelectedSearchCustmer);
                    break;
            }

            base.OnPropertyChanged(name);
        }
        public bool CanDelete(object param)
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

        public bool CanSave(object param)
        {
            if (!String.IsNullOrEmpty(CustomerName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string LastUpdateDate
        {
            get
            {
                return _lastupdatedDate;
            }
            set
            {
                _lastupdatedDate = value;
                OnPropertyChanged("LastUpdateDate");
            }
        }

        void GetData(int customerId)
        {
            ICustomerRepository repo = new CustomerRepository();
            var customer = repo.GetAllCustomers().FirstOrDefault(x => x.ID == customerId && x.IsDeleted != true);

            if (customer != null)
            {
                this.SelectedSearchCustmer = customer.ID;

                this.CustomerName = customer.Cus_Name;
                this.Email = customer.Cus_Email;
                this.Fax = customer.Cus_Fax;
                this.SelectedSalesman = customer.Cus_Salesman;
                this.SelectedCustomerType = customer.Cus_Type;
                this.SelectedCreditLimitDays = customer.Cus_Credit_Limit_Days;
                this.SelectedCreditLimitAmount = customer.Cus_Credit_Limit_Amount;
                this.Telephone = customer.Cus_Telephone;
                this.SelectedDiscount = customer.Cus_Discount;
                this.Comp_Reg_No = customer.Cus_Company_Reg_no;
                this.Cus_Bill_to_city = customer.Cus_Bill_to_city;
                this.Cus_Bill_to_country = customer.Cus_Bill_to_country;
                this.Cus_Bill_to_line1 = customer.Cus_Bill_to_line1;
                this.Cus_Bill_to_line2 = customer.Cus_Bill_to_line2;
                this.Cus_Bill_to_post_code = customer.Cus_Bill_to_post_code;
                this.Cus_Bill_to_state = customer.Cus_Bill_to_state;
                this.ShipAddressLine1 = customer.Cus_Ship_to_line1;
                this.ShipAddressLine2 = customer.Cus_Ship_to_line2;
                this.ShipCity = customer.Cus_Ship_to_city;
                this.ShipCountry = customer.Cus_Ship_to_country;
                this.ShipState = customer.Cus_Ship_to_state;
                this.ShipPostalCode = customer.Cus_Ship_to_post_code;
                this.ContactPerson = customer.Cus_Contact_Person;
                this.GstRegistrationNo = customer.Cus_GST_Reg_No;
                this.Remarks = customer.Cus_Remarks;
                this.IsInActive = customer.Cus_Inactive;
                this.ChangeCustomerGST = customer.Cus_Charge_GST;
                this.Balance = customer.Cus_Balance;
                this.ID = customer.ID;
                if (customer.TaxId == null && customer.Cus_Charge_GST == false)
                {
                    this.SelectedTaxId = 0;
                }
                else
                {
                    this.SelectedTaxId = customer.TaxId;
                }
                //decimal taxRate = 0;
                //if (TaxandRateList != null)
                //{
                //    var data = TaxandRateList.Find(x => x.TaxID == customer.TaxId);
                //    if (data != null)
                //    {
                //        taxRate = data.TaxRate;
                //    }
                //}
                //this.selectedTaxRate = taxRate.ToString() +"%";
                if (customer.Cus_Charge_GST == true)
                {
                    this.ChangeCustomerGSTTrue = customer.Cus_Charge_GST;
                    this.ChangeCustomerGSTFalse = false;
                }
                else
                {
                    this.ChangeCustomerGSTTrue = false;
                    this.ChangeCustomerGSTFalse = true;
                }

                ///Disable Privous button
                var current = SearchCustomer.FirstOrDefault(x => x.ID == SelectedSearchCustmer);

                int index = SearchCustomer.IndexOf(current);
                if (index - 1 <= 0)
                {
                    this.BackwardEnabled = false;
                    if (index >= SearchCustomer.Count - 1)
                    {
                        this.ForwardEnabled = false;
                    }
                    else
                    {
                        this.ForwardEnabled = true;
                    }
                }
                else
                {
                    this.BackwardEnabled = true;
                    if (index >= SearchCustomer.Count - 1)
                    {
                        this.ForwardEnabled = true;
                    }
                    else
                    {
                        this.ForwardEnabled = true;
                    }
                }
                ///disable next button
                var current1 = SearchCustomer.FirstOrDefault(x => x.ID == SelectedSearchCustmer);

                int index1 = SearchCustomer.IndexOf(current);


                if (index1 >= SearchCustomer.Count - 1)
                {
                    this.ForwardEnabled = false;
                    if (index1 <= 0)
                        this.BackwardEnabled = false;
                    else
                        this.BackwardEnabled = true;
                }

                else
                {
                    this.ForwardEnabled = true;
                    if (index1 <= 0)
                        this.BackwardEnabled = false;
                    else
                        this.BackwardEnabled = true;
                }

            }

        }

        /// <summary>
        ///  Occurs when System.ComponentModel.BackgroundWorker.ReportProgress(System.Int32) is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void LoadCustomersBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {

        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadCustomersBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {

            Mouse.OverrideCursor = null;

        }

        //public DelegateCommand SaveClickCommand
        //{
        //    get
        //    {
        //        return (this.saveClickCommand ?? new DelegateCommand(this.OnSaveCustomer));
        //    }
        //}

        public DelegateCommand SameAsBillingAddressCommand
        {
            get
            {
                return (this.sameAsBillingAddressCommand ?? new DelegateCommand(OnSameAsBillAddress));
            }
        }

        private void OnSameAsBillAddress()
        {
            //var shippingAddress = new ShippingAddress();
            this.ShipCity = this.Cus_Bill_to_city;
            this.ShipAddressLine1 = this.Cus_Bill_to_line1;
            this.ShipAddressLine2 = this.Cus_Bill_to_line2;
            this.ShipState = this.Cus_Bill_to_state;
            this.ShipPostalCode = this.Cus_Bill_to_post_code;
            this.ShipCountry = this.Cus_Bill_to_country;

        }

        public DelegateCommand NewShippingClickCommand
        {
            get
            {
                return (this.newShippingClickCommand ?? new DelegateCommand(this.OnNewShippingAddress));
            }
        }
        public DelegateCommand RefreshCommand
        {
            get
            {
                return (this.refreshCommand ?? new DelegateCommand(this.RefreshCustomersData));
            }
        }

        private void RefreshCustomersData()
        {
            //bool IsSuccess = false;
            //if (this.ID > 0)
            //{
            //    ICustomerRepository repo = new CustomerRepository();
            //    //MessageBoxResult result = MessageBox.Show("Do you want to refresh data?", "Refresh data", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //    //if (result == MessageBoxResult.Yes) { 
            //    IsSuccess = repo.RefreshCustomer(this.ID);
            //    if (IsSuccess == false)
            //    {
            //        MessageBox.Show("Error while refreshing data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }

            //    //}

            //}
            //else
            //{
            //    MessageBox.Show("Can't refresh data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            this.SelectedSearchCustmer = 0;
            this.LoadCustomersBackground();
        }

        public DelegateCommand PreviousCommand
        {
            get
            {
                return (this.previousCommand ?? new DelegateCommand(this.OnPreviouClick));
            }
        }

        public DelegateCommand NextCommand
        {
            get
            {
                return (this.nextCommand ?? new DelegateCommand(this.OnNextClick));
            }
        }

        public DelegateCommand NewCustomerClickCommand
        {
            get
            {
                return (this.newCustomerClickCommand ?? new DelegateCommand(this.OnNewCustomer));
            }
        }
        public DelegateCommand CancelClickCommand
        {
            get
            {
                return (this.cancelClickCommand ?? new DelegateCommand(this.OnCancelClick));
            }
        }

        public string selectedTaxRate
        {
            get
            {
                return _selectedTaxRate;
            }
            set
            {

                if (_selectedTaxRate != value)
                {
                    _selectedTaxRate = value;
                    OnPropertyChanged("selectedTaxRate");
                }
            }
        }
        private void OnCancelClick()
        {
            GetData(this.SelectedSearchCustmer);
            IsNew = false;
        }

        //public DelegateCommand DeleteCustomerClickCommand
        //{
        //    get
        //    {
        //        return (this.deleteCustomerClickCommand ?? new DelegateCommand(this.OnDeleteCustomer));
        //    }
        //}
        private void OnDeleteCustomer(object param)
        {
            IsNew = false;
            int custId = this.SelectedSearchCustmer;
            bool canDelete = false;
            ICustomerRepository repo = new CustomerRepository();
            canDelete = repo.CanDeleteCustomer(custId);
            if (canDelete)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete customer?", "Delete Customer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    canDelete = repo.DeleteCustomer(custId);
                    if (canDelete)
                    {
                        RefreshData();
                    }
                }
            }

        }
        private void OnNewShippingAddress()
        {
            this.ClearShippingAddress();
            var address = new ShippingAddress();

        }

        private void OnSaveCustomer(object param)
        {

            int CustomerIdSelected = 0;

            CustomerErrors = ValidateCustomer();
            if (CustomerErrors != string.Empty)
            {
                return;
            }
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Customers Details", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                ICustomerRepository repo = new CustomerRepository();
                var customer = repo.GetAllCustomers().FirstOrDefault(x => x.ID == this.ID & x.IsDeleted != true);

                if (customer == null)
                {
                    customer = new Customer();
                    customer.ID = -1;
                    customer.CreatedBy = loginId;
                    customer.CreatedDate = System.DateTime.UtcNow;
                }
                else
                {
                    customer.ModifiedBy = loginId;
                    customer.ModifiedDate = System.DateTime.UtcNow;
                    CustomerIdSelected = this.SelectedSearchCustmer;
                }

                customer.Cus_Name = CustomerName;
                customer.Cus_Email = Email;
                customer.Cus_Fax = Fax;
                customer.Cus_Discount = SelectedDiscount;
                customer.Cus_Company_Reg_no = Comp_Reg_No;
                customer.Cus_Bill_to_city = Cus_Bill_to_city;
                customer.Cus_Bill_to_country = Cus_Bill_to_country;
                customer.Cus_Bill_to_line1 = Cus_Bill_to_line1;
                customer.Cus_Bill_to_line2 = Cus_Bill_to_line2;
                customer.Cus_Bill_to_post_code = Cus_Bill_to_post_code;
                customer.Cus_Bill_to_state = Cus_Bill_to_state;
                customer.Cus_Ship_to_line1 = ShipAddressLine1;
                customer.Cus_Ship_to_line2 = ShipAddressLine2;
                customer.Cus_Ship_to_city = ShipCity;
                customer.Cus_Ship_to_state = ShipState;
                customer.Cus_Ship_to_country = ShipCountry;
                customer.Cus_Ship_to_post_code = ShipPostalCode;
                customer.Cus_Charge_GST = ChangeCustomerGST;
                customer.Cus_Salesman = SelectedSalesman;
                customer.Cus_Telephone = Telephone;
                customer.Cus_Type = SelectedCustomerType;
                customer.Cus_Credit_Limit_Days = SelectedCreditLimitDays;

                customer.Cus_Credit_Limit_Amount = SelectedCreditLimitAmount;
                customer.Cus_Contact_Person = ContactPerson;
                customer.Cus_GST_Reg_No = GstRegistrationNo;
                customer.Cus_Inactive = IsInActive;
                customer.Cus_Remarks = Remarks;
                customer.TaxId = SelectedTaxId;

                repo.CreateCustomer(customer);
                // MessageBox.Show("Customers detail saved successfully","Customers Details",MessageBoxButton.OK,MessageBoxImage.Information);
                IsNew = false;

                this.TotalCustomer = repo.GetAllCustomers().Count();
                this.InActiveCustomer = repo.GetCustomersCount("Y");
                this.ActiveCustomer = TotalCustomer - InActiveCustomer;

                if (customer.ID < 0)
                {
                    this.SearchCustomer = repo.GetAllCustomers().ToList();
                    CustomerIdSelected = this.SearchCustomer[this.SearchCustomer.Count - 1].ID;
                    this.SelectedSearchCustmer = CustomerIdSelected;
                }
            }
            else
            {
                IsNew = true;
            }
        }

        private void OnNextClick()
        {
            var current = SearchCustomer.FirstOrDefault(x => x.ID == SelectedSearchCustmer);

            int index = SearchCustomer.IndexOf(current);

            if (index < SearchCustomer.Count - 1)
            {
                var next = SearchCustomer.ElementAt(index + 1);
                this.SelectedSearchCustmer = next.ID;

            }
            if (index >= SearchCustomer.Count - 2)
            {
                this.ForwardEnabled = false;
                if (index - 1 <= 0)
                    this.BackwardEnabled = false;
                else
                    this.BackwardEnabled = true;
            }

            else
            {
                this.ForwardEnabled = true;
                if (index - 1 <= 0)
                    this.BackwardEnabled = true;
                else
                    this.BackwardEnabled = true;
            }


        }

        private void OnPreviouClick()
        {
            var current = SearchCustomer.FirstOrDefault(x => x.ID == SelectedSearchCustmer);

            int index = SearchCustomer.IndexOf(current);

            if (index > 0)
            {
                var next = SearchCustomer.ElementAt(index - 1);
                this.SelectedSearchCustmer = next.ID;
            }
            if (index - 1 <= 0)
            {
                this.BackwardEnabled = false;
                if (index >= SearchCustomer.Count - 2)
                {
                    this.ForwardEnabled = false;
                }
                else
                {
                    this.ForwardEnabled = true;
                }
            }
            else
            {
                this.BackwardEnabled = true;
                if (index >= SearchCustomer.Count - 2)
                {
                    this.ForwardEnabled = true;
                }
                else
                {
                    this.ForwardEnabled = true;
                }
            }
        }
        private string ValidateCustomer()
        {
            string EmailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string PhonePattern = @"\+?\d[\d -]{8,15}\d";

            StringBuilder msg = new StringBuilder();
            if (CustomerName == null || CustomerName.Trim() == string.Empty)
            {
                msg.Append("Customer Name is Required.\n");
            }

            if (!String.IsNullOrEmpty(Email))
            {
                if (!Regex.IsMatch(Email, EmailPattern))
                {
                    msg.Append("Invalid Email Address.\n");
                }
            }

            if (!String.IsNullOrEmpty(Telephone))
            {
                if (!Regex.IsMatch(Telephone, PhonePattern))
                {
                    msg.Append("Invalid Phone No.\n");
                }
            }
            return msg.ToString();
        }
        private void ClearShippingAddress()
        {
            this.ShipAddressLine1 = string.Empty;
            this.ShipAddressLine2 = string.Empty;
            this.ShipCity = string.Empty;
            this.ShipCountry = string.Empty;
            this.ShipState = string.Empty;
            this.ShipPostalCode = string.Empty;
        }

        private void OnNewCustomer()
        {
            this.ID = -1;
            this.CustomerName = string.Empty;
            this.Email = string.Empty;
            this.Fax = string.Empty;
            this.SelectedSalesman = null;
            this.SelectedCustomerType = "-1";
            this.SelectedCreditLimitDays = null;
            this.SelectedCreditLimitAmount = null;
            this.Telephone = string.Empty;
            this.SelectedDiscount = null;
            this.Comp_Reg_No = string.Empty;
            this.Cus_Bill_to_city = string.Empty;
            this.Cus_Bill_to_country = string.Empty;
            this.Cus_Bill_to_line1 = string.Empty;
            this.Cus_Bill_to_line2 = string.Empty;
            this.Cus_Bill_to_post_code = string.Empty;
            this.Cus_Bill_to_state = string.Empty;
            this.ShipAddressLine1 = string.Empty;
            this.ShipAddressLine2 = string.Empty;
            this.ShipCity = string.Empty;
            this.ShipCountry = string.Empty;
            this.ShipState = string.Empty;
            this.ShipPostalCode = string.Empty;
            this.ContactPerson = string.Empty;
            this.GstRegistrationNo = string.Empty;
            this.ChangeCustomerGST = IsCompanyRegisteredForGST;
            if (IsCompanyRegisteredForGST == true)
            {
                ChangeCustomerGSTTrue = true;
                ChangeCustomerGSTFalse = false;
            }
            else
            {
                ChangeCustomerGSTTrue = false;
                ChangeCustomerGSTFalse = true;
            }
            this.Balance = null;

            this.IsInActive = "N";
            this.Remarks = string.Empty;
            IsNew = true;
            GetCustomerCreditLimit();
        }

        #endregion Background Worker


        public List<Country> AutoFillCountry()
        {

            ICustomerRepository repo = new CustomerRepository();
            return repo.AutoFillCountry();

        }

        public List<State> AutoFillState()
        {

            ICustomerRepository repo = new CustomerRepository();
            return repo.AutoFillState();

        }
        public List<City> AutoFillCity()
        {

            ICustomerRepository repo = new CustomerRepository();
            return repo.AutoFillCity();

        }
        public List<PostalCode> AutoFillPostalCode()
        {

            ICustomerRepository repo = new CustomerRepository();
            return repo.AutoFillPostalCode();

        }

    }
}