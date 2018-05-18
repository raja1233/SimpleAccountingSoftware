using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class SupplierDetailEntity: ViewModelBase
    {
        #region Private Properties
        //private List<CatagoryType> _SupplierType;
        //private List<CatagoryType> _salesmanType;
        private string _CreditLimitDays;
        private string _CreditLimitAmount;
        //private List<CatagoryType> _Discount;
        private int _TotalSupplier = 0;
        private int _ActiveSupplier = 0;
        private int _InActiveSupplier = 0;
        private string _SupplierName;
        private decimal? selectedCreditLimitAmount;
        //private readonly DelegateCommand saveClickCommand = null;
        private string supp_Reg_No;
        private string balance;
        //private string _SelectedSupplierType;
        //private int? selectedSalesman;
        //private int? selectedCreditLimitDays;
        //private decimal? selectedDiscount;
        private string _Telephone;
        private string _Fax;
        private string _Email;
        private string _ContactPerson;
        private string _GstRegistrationNo;
        private bool? _ChangeSupplierGST;
        private bool? _ChangeSupplierGSTTrue;
        private bool? _ChangeSupplierGSTFalse;
        private string remarks;

        //private DelegateCommand newShippingClickCommand = null;
        private string shipAddressLine1;
        private string shipAddressLine2;
        private string shipCity;
        private string shipCountry;
        private string shipState;
        private string shipPostalCode;
        private List<SupplierDetailEntity> _SearchSupplier;
        private int _SelectedSearchSupplier;
        private string _Sup_Bill_to_city;
        private string _Sup_Bill_to_country;
        private string _Sup_Bill_to_line1;
        private string _Sup_Bill_to_line2;
        private string _Sup_Bill_to_post_code;
        private string _Sup_Bill_to_state;
        private int id;
        private string checkInActive;
        private bool? _IsAllowedToChangeCLA_and_Discount;
        private string _LastupdatedDate;
        private string _currencyName;
        private string _currencyCode;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _dateFormat;
        private bool? _IsRefreshed;
        private DateTime? _RefreshedDate;
        //private DelegateCommand sameAsBillingAddressCommand = null;
        //private DelegateCommand previousCommand = null;
        //private DelegateCommand nextCommand = null;
        //private DelegateCommand newCustomerClickCommand = null;
        //private DelegateCommand deleteCustomerClickCommand = null;
        //private string _currencyName = "USD";
        private string _GSTName = "GST";
        private string _TaxName;
        //private int loginId = 1;//Login id will be the user who logged in in the system.
        private List<TaxModel> _taxCodeandRate;
        private decimal? _defaultTaxRate;
        private int? _selectedTaxid;
        private int? _TaxId;
        private TaxModel _selectedTaxModel;
        private bool? _BackwardEnabled;
        private bool? _ForwardEnabled;
        private DateTime? _Createddate;
        #endregion

        #region Public Properties
        public DateTime? Createddate
        {
            get { return _Createddate; }

            set
            {
                if (_Createddate != value)
                {
                    _Createddate = value;
                    OnPropertyChanged("Createddate");

                }
            }
        }
        public bool? BackwardEnabled
        {
            get { return _BackwardEnabled; }

            set
            {
                if (_BackwardEnabled != value)
                {
                    _BackwardEnabled = value;
                    OnPropertyChanged("BackwardEnabled");

                }
            }
        }
        public bool? ForwardEnabled
        {
            get { return _ForwardEnabled; }

            set
            {
                if (_ForwardEnabled != value)
                {
                    _ForwardEnabled = value;
                    OnPropertyChanged("_ForwardEnabled");

                }
            }
        }

        public string SupplierName
        {
            get { return _SupplierName; }

            set
            {
                if (_SupplierName != value)
                {
                    _SupplierName = value;
                    OnPropertyChanged("SupplierName");

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

        //public List<CatagoryType> SupplierType
        //{
        //    get { return _SupplierType; }

        //    set
        //    {
        //        if (_SupplierType != value)
        //        {
        //            _SupplierType = value;
        //            OnPropertyChanged("SupplierType");

        //        }
        //    }

        //}
        public string CreditLimitDays
        {
            get { return _CreditLimitDays; }

            set
            {
                if (_CreditLimitDays != value)
                {
                    _CreditLimitDays = value;
                    OnPropertyChanged("CreditLimitDays");
                }
            }
        }
        public string CreditLimitAmount
        {
            get {

                //return _CreditLimitAmount;
                if (_CreditLimitAmount == null)
                    return this._CreditLimitAmount;
                else
                {
                    if (_CreditLimitAmount != "")
                    {
                        var balance = _CreditLimitAmount.Replace(",", "");
                        return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._CreditLimitAmount;
                }
            }

            set
            {
                if (_CreditLimitAmount != value)
                {
                    _CreditLimitAmount = value;
                    OnPropertyChanged("CreditLimitAmount");
                }
            }
        }

        public decimal? SelectedCreditLimitAmount
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
        //public List<CatagoryType> Discount
        //{
        //    get { return discount; }

        //    set
        //    {
        //        if (discount != value)
        //        {
        //            discount = value;
        //            OnPropertyChanged("Discount");
        //        }
        //    }
        //}
        //public List<CatagoryType> SalesmanType
        //{
        //    get { return _salesmanType; }

        //    set
        //    {
        //        if (_salesmanType != value)
        //        {
        //            _salesmanType = value;
        //            OnPropertyChanged("SalesmanType");

        //        }
        //    }
        //}


        public int TotalSupplier
        {
            get { return _TotalSupplier; }

            set
            {
                if (_TotalSupplier != value)
                {
                    _TotalSupplier = value;
                    OnPropertyChanged("TotalSupplier");

                }
            }
        }
        public int ActiveSupplier
        {
            get { return _ActiveSupplier; }

            set
            {
                if (_ActiveSupplier != value)
                {
                    _ActiveSupplier = value;
                    OnPropertyChanged("ActiveSupplier");

                }
            }
        }

        public int InActiveSupplier
        {
            get { return _InActiveSupplier; }

            set
            {
                if (_InActiveSupplier != value)
                {
                    _InActiveSupplier = value;
                    OnPropertyChanged("InActiveSupplier");
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
        public string Supp_Reg_No
        {
            get { return supp_Reg_No; }

            set
            {
                if (supp_Reg_No != value)
                {
                    supp_Reg_No = value;
                    OnPropertyChanged("supp_Reg_No");
                }
            }
        }
        public string Balance
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
        //public void OnPropertyChanged(string name)
        //{
        //    switch (name)
        //    {
        //        case "SelectedSearchSupplier":
        //            SupplierDetailViewModel
        //            GetData(SelectedSearchSupplier);
        //            break;
        //    }

        //    base.OnPropertyChanged(name);
        //}
        //public string SelectedCustomerType
        //{
        //    get { return selectedCustomerType; }

        //    set
        //    {
        //        if (selectedCustomerType != value)
        //        {
        //            selectedCustomerType = value;
        //            OnPropertyChanged("SelectedCustomerType");
        //        }
        //    }
        //}
        //public int? SelectedSalesman
        //{
        //    get { return selectedSalesman; }

        //    set
        //    {
        //        if (selectedSalesman != value)
        //        {
        //            selectedSalesman = value;
        //            OnPropertyChanged("SelectedSalesman");
        //        }
        //    }
        //}
        //public int? SelectedCreditLimitDays
        //{
        //    get { return selectedCreditLimitDays; }

        //    set
        //    {
        //        if (selectedCreditLimitDays != value)
        //        {
        //            selectedCreditLimitDays = value;
        //            OnPropertyChanged("SelectedCreditLimitDays");
        //        }
        //    }
        //}
        //public decimal? SelectedDiscount
        //{
        //    get { return selectedDiscount; }

        //    set
        //    {
        //        if (selectedDiscount != value)
        //        {
        //            selectedDiscount = value;
        //            OnPropertyChanged("SelectedDiscount");
        //        }
        //    }
        //}
        public string Telephone
        {
            get {

                //return _Telephone;
                if (_Telephone == null)
                    return this._Telephone;
                switch (_Telephone.Length)
                {
                    //case 7:
                    //    return Regex.Replace(_Comp_Tel, @"(\d{3})(\d{4})", "$1-$2");
                    case 10:
                        return Regex.Replace(_Telephone, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
                    //case 11:
                    //    return Regex.Replace(_Comp_Tel, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");
                    default:
                        return _Telephone;
                }
            }

            set
            {
                if (_Telephone != value)
                {
                    _Telephone = value;
                    OnPropertyChanged("Telephone");
                }
            }
        }
        public string Fax
        {
            get {
                //return _Fax;
                if (_Fax == null)
                    return this._Fax;
                switch (_Fax.Length)
                {
                    //case 7:
                    //    return Regex.Replace(_Comp_Tel, @"(\d{3})(\d{4})", "$1-$2");
                    case 10:
                        return Regex.Replace(_Fax, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
                    //case 11:
                    //    return Regex.Replace(_Comp_Tel, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");
                    default:
                        return _Fax;
                }
            }

            set
            {
                if (_Fax != value)
                {
                    _Fax = value;
                    OnPropertyChanged("Fax");
                }
            }
        }
        public string Email
        {
            get { return _Email; }

            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string ContactPerson
        {
            get { return _ContactPerson; }

            set
            {
                if (_ContactPerson != value)
                {
                    _ContactPerson = value;
                    OnPropertyChanged("ContactPerson");
                }
            }
        }
        public string GstRegistrationNo
        {
            get { return _GstRegistrationNo; }

            set
            {
                if (_GstRegistrationNo != value)
                {
                    _GstRegistrationNo = value;
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

        public bool? ChangeSupplierGST
        {
            get
            {
                return _ChangeSupplierGST;
            }
            set
            {
                //if (ChangeSupplierGSTTrue == null)
                //{
                //    ChangeSupplierGSTTrue = false;
                //    ChangeSupplierGSTFalse = true;
                //}
                 if (ChangeSupplierGSTTrue == true)
                {
                    _ChangeSupplierGST = true;
                }
                else if (ChangeSupplierGSTFalse == true)
                {
                    _ChangeSupplierGST = false;
                }
                else
                {
                    _ChangeSupplierGST = value;
                }

                OnPropertyChanged("ChangeSupplierGST");
            }
        }
        public bool? ChangeSupplierGSTTrue
        {
            get
            {
                return _ChangeSupplierGSTTrue;
            }
            set
            {
                _ChangeSupplierGSTTrue = value;
                ChangeSupplierGST = true;
                OnPropertyChanged("ChangeSupplierGSTTrue");
            }
        }
        public bool? ChangeSupplierGSTFalse
        {
            get
            {
                return _ChangeSupplierGSTFalse;
            }
            set
            {
                _ChangeSupplierGSTFalse = value;
                ChangeSupplierGST = false;
                OnPropertyChanged("ChangeSupplierGSTFalse");
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

        public List<SupplierDetailEntity> SearchSupplier
        {
            get { return _SearchSupplier; }
            set
            {
                if (_SearchSupplier != value)
                {
                    _SearchSupplier = value;
                    OnPropertyChanged("SearchSupplier");
                }
            }
        }

        public int SelectedSearchSupplier
        {
            get { return _SelectedSearchSupplier; }
            set
            {
                if (_SelectedSearchSupplier != value)
                {
                    _SelectedSearchSupplier = value;
                    //SupplierDetailViewModel
                    //GetData(value);
                    OnPropertyChanged("SelectedSearchSupplier");
                }
            }
        }

        public string Sup_Bill_to_city
        {
            get
            {
                return _Sup_Bill_to_city;
            }
            set
            {
                if (_Sup_Bill_to_city != value)
                {
                    _Sup_Bill_to_city = value;
                    OnPropertyChanged("Sup_Bill_to_city");
                }
            }
        }
        public string Sup_Bill_to_country
        {
            get
            {
                return _Sup_Bill_to_country;
            }
            set
            {
                if (_Sup_Bill_to_country != value)
                {
                    _Sup_Bill_to_country = value;
                    OnPropertyChanged("Sup_Bill_to_country");
                }
            }
        }
        public string Sup_Bill_to_line1
        {
            get
            {
                return _Sup_Bill_to_line1;
            }
            set
            {
                
                    _Sup_Bill_to_line1 = value;
                    OnPropertyChanged("Sup_Bill_to_line1");
                
            }
        }
        public string Sup_Bill_to_line2
        {
            get
            {
                return _Sup_Bill_to_line2;
            }
            set
            {
                if (_Sup_Bill_to_line2 != value)
                {
                    _Sup_Bill_to_line2 = value;
                    OnPropertyChanged("Sup_Bill_to_line2");
                }
            }
        }
        public string Sup_Bill_to_post_code
        {
            get
            {
                return _Sup_Bill_to_post_code;
            }
            set
            {
                if (_Sup_Bill_to_post_code != value)
                {
                    _Sup_Bill_to_post_code = value;
                    OnPropertyChanged("Sup_Bill_to_post_code");
                }
            }
        }
        public string Sup_Bill_to_state
        {
            get
            {
                return _Sup_Bill_to_state;
            }
            set
            {
                if (_Sup_Bill_to_state != value)
                {
                    _Sup_Bill_to_state = value;
                    OnPropertyChanged("Sup_Bill_to_state");
                }
            }
        }

        public bool? IsAllowedToChangeCLA_and_Discount
        {
            get
            {
                return _IsAllowedToChangeCLA_and_Discount;
            }
            set
            {
                if (_IsAllowedToChangeCLA_and_Discount != value)
                {
                    _IsAllowedToChangeCLA_and_Discount = value;
                    OnPropertyChanged("IsAllowedToChangeCLA_and_Discount");
                }
            }
        }
        public string LastUpdateDate
        {
            get
            {
                return _LastupdatedDate;
            }
            set
            {
                _LastupdatedDate = value;
                OnPropertyChanged("LastUpdateDate");
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
        public decimal? DecimalPlaces
        {
            get { return _decimalPlaces; }

            set
            {
                if (_decimalPlaces != value)
                {
                    _decimalPlaces = value;
                    OnPropertyChanged("DecimalPlaces");
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

        public string TaxName
        {
            get
            {
                return _TaxName;

            }
            set
            {
                if (_TaxName != value)
                {
                    _TaxName = value;
                    OnPropertyChanged("TaxName");
                }
            }

        }
        public bool? IsRefreshed
        {
            get
            {
                return _IsRefreshed;

            }
            set
            {
                
                    _IsRefreshed = value;
                    OnPropertyChanged("IsRefreshed");
               
            }

        }
        public DateTime? RefreshedDate
        {
            get
            {
                return _RefreshedDate;

            }
            set
            {

                _RefreshedDate = value;
                OnPropertyChanged("RefreshedDate");

            }

        }

        //public string CurrencyName
        //{
        //    get
        //    {
        //        return _currencyName;
        //    }
        //    set
        //    {

        //        if (_currencyName != value)
        //        {
        //            _currencyName = value;
        //            OnPropertyChanged("CurrencyName");
        //        }
        //    }
        //}

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
        public int? TaxId
        {
            get
            {
                return _TaxId;
            }
            set
            {
                if (_TaxId != value)
                {
                    _TaxId = value;
                    OnPropertyChanged("TaxId");
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
        #endregion  Public Properties
    }
}
