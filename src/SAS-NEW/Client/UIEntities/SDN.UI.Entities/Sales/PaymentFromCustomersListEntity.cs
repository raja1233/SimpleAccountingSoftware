
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Sales
{
    using SDN.Common;
    using System.Globalization;

    public class PaymentFromCustomersListEntity:ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private int? _Cus_ID;
        private string _CustomerName;
        private string _InvoiceNo;
        private string _InvoiceDate;
        private string _InvoiceAmount;
        private decimal? _InvoiceAmountValue;

        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;
        private string _Year;
        private string _Quater;
        private string _Month;
        private string _StartDate;
        private string _EndDate;

        private string _Search;
        private List<PaymentFromCustomersListEntity> _PaymentsFromCustomersList;
        private List<PaymentFromCustomersListEntity> _PaymentsFromCustomersListcmb;
        private List<PaymentFromCustomersListEntity> _PaymentsFromCustomersListcmbInv;
        private List<PaymentFromCustomersListEntity> _PaymentsFromCustomersListcmbSup;
        private List<PaymentFromCustomersListEntity> _PaymentsFromCustomersListcmbDebit;
        private int _ShowAllCount;
        private int _ShowSelectedCount;

        private bool? _IsDeleted;
        private int _SelectedSearchPQList;
        private int _SelectedIndex;
        private string _SelectedSearchSupName;
        private string _SelectedSearchInvoiceNo;
        private string _SelectedSearchYear;
        private string _SelectedSearchQuarter;
        private string _SelectedSearchMonth;
        private DateTime? _SelectedSearchStartDate;
        private DateTime? _SelectedSearchEndDate;
        private DateTime? _CreatedDate;


        private List<YearEntity> _YearRange;
        private List<QuarterEntity> _QuarterRange;

        private string _JsonData;
        private bool? _YearmonthQuartTrue;
        private bool? _StartEndDateTrue;
        private string _DateFormat;
        private string _TaxName;
        private bool? _EnableYearDropDown;
        private bool? _EnableQuarterDropDown;
        private bool? _EnableMonthDropDown;
        private bool? _EnableStartDropDown;
        private bool? _EnableEndDropDown;
        private string _currencyName;
        private string _currencyCode;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _SelectedCashChequeNo;

        private string _LastupdatedDate;

        private DateTime? _EndDateValidation;
        private DateTime? _InvoiceDateDateTime;
        private bool? isCheque;

        private string _CashChequeNo;
        private string _CashChequeDate;
        private DateTime? _CashChequeDateDate;

        private decimal? _CashChequeAmount;
        private string _CashAmount;
        private string totalCashChequeAmount;
        private string totalPOPIAmount;
        private int _PtSGridHeight;
        #endregion


        #region Public Properties

        public int PtSGridHeight
        {
            get
            {
                return _PtSGridHeight;
            }
            set
            {
                _PtSGridHeight = value;
                OnPropertyChanged("PtSGridHeight");
            }
        }

        public bool? IsCheque
        {
            get
            {
                return isCheque;
            }
            set
            {
                isCheque = value;
                OnPropertyChanged("IsCheque");
            }
        }

        public string CashChequeNo
        {
            get
            {
                return _CashChequeNo;
            }
            set
            {
                _CashChequeNo = value;
                OnPropertyChanged("CashChequeNo");
            }
        }
        public string CashChequeDate
        {
            get
            {
                return _CashChequeDate;
            }
            set
            {
                _CashChequeDate = value;
                OnPropertyChanged("CashChequeDate");
            }
        }
        public DateTime? CashChequeDateDate
        {
            get
            {
                return _CashChequeDateDate;
            }
            set
            {
                _CashChequeDateDate = value;
                OnPropertyChanged("CashChequeDate");
            }
        }

        public decimal? CashChequeAmount
        {
            get
            {
                return _CashChequeAmount;
            }
            set
            {
                _CashChequeAmount = value;
                OnPropertyChanged("CashChequeAmount");
            }
        }

        public string TotalCashChequeAmount
        {
            get
            {
                //return _DebitCashAmount;
                if (totalCashChequeAmount == null)
                    return this.totalCashChequeAmount;
                else
                {
                    if (totalCashChequeAmount != "")
                    {
                        var balance = totalCashChequeAmount.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.totalCashChequeAmount;
                }
            }
            set
            {
                totalCashChequeAmount = value;
                OnPropertyChanged("TotalCashChequeAmount");
            }
        }
        public string TotalPOPIAmount
        {
            get
            {
                //return _DebitCashAmount;
                if (totalPOPIAmount == null)
                    return this.totalPOPIAmount;
                else
                {
                    if (totalPOPIAmount != "")
                    {
                        var balance = totalPOPIAmount.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.totalPOPIAmount;
                }
            }
            set
            {
                totalPOPIAmount = value;
                OnPropertyChanged("TotalPOPIAmount");
            }
        }

        public string CashAmount
        {
            get
            {
                //return _DebitCashAmount;
                if (_CashAmount == null)
                    return this._CashAmount;
                else
                {
                    if (_CashAmount != "")
                    {
                        var balance = _CashAmount.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._CashAmount;
                }
            }
            set
            {
                _CashAmount = value;
                OnPropertyChanged("CashAmount");
            }
        }

        public DateTime? InvoiceDateDateTime
        {
            get
            {
                return _InvoiceDateDateTime;
            }
            set
            {
                _InvoiceDateDateTime = value;
                OnPropertyChanged("InvoiceDateDateTime");
            }
        }

        public DateTime? EndDateValidation
        {
            get
            {
                return _EndDateValidation;
            }
            set
            {
                _EndDateValidation = value;
                OnPropertyChanged("EndDateValidation");
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


        public bool? EnableStartDropDown
        {
            get
            {
                return _EnableStartDropDown;
            }
            set
            {
                _EnableStartDropDown = value;
                OnPropertyChanged("EnableStartDropDown");
            }
        }
        public bool? EnableEndDropDown
        {
            get
            {
                return _EnableEndDropDown;
            }
            set
            {
                _EnableEndDropDown = value;
                OnPropertyChanged("EnableEndDropDown");
            }
        }
        public bool? EnableYearDropDown
        {
            get
            {
                return _EnableYearDropDown;
            }
            set
            {
                _EnableYearDropDown = value;
                OnPropertyChanged("EnableYearDropDown");
            }
        }
        public bool? EnableQuarterDropDown
        {
            get
            {
                return _EnableQuarterDropDown;
            }
            set
            {
                _EnableQuarterDropDown = value;
                OnPropertyChanged("EnableQuarterDropDown");
            }
        }
        public bool? EnableMonthDropDown
        {
            get
            {
                return _EnableMonthDropDown;
            }
            set
            {
                _EnableMonthDropDown = value;
                OnPropertyChanged("EnableMonthDropDown");
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
                _TaxName = value;
                OnPropertyChanged("TaxName");
            }
        }
        public string DateFormat
        {
            get { return _DateFormat; }
            set { SetProperty(ref _DateFormat, value, "DateFormat"); }
        }
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }
        public int? Cus_ID
        {
            get
            {
                return _Cus_ID;
            }
            set
            {
                _Cus_ID = value;
                OnPropertyChanged("Cus_ID");
            }
        }
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
                OnPropertyChanged("CustomerName");
            }
        }
        public string InvoiceNo
        {
            get
            {
                return _InvoiceNo;
            }
            set
            {
                _InvoiceNo = value;
                OnPropertyChanged("InvoiceNo");
            }
        }
        public string InvoiceDate
        {
            get
            {
                return _InvoiceDate;
            }
            set
            {
                _InvoiceDate = value;
                OnPropertyChanged("InvoiceDate");
            }
        }
        public string InvoiceAmount
        {
            get
            {
                //return _InvoiceAmount;
                if (_InvoiceAmount == null)
                    return this._InvoiceAmount;
                else
                {
                    if (_InvoiceAmount != "")
                    {
                        var balance = _InvoiceAmount.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._InvoiceAmount;
                }
            }
            set
            {
                _InvoiceAmount = value;
                OnPropertyChanged("InvoiceAmount");
            }
        }
        public decimal? InvoiceAmountValue
        {
            get
            {
                return _InvoiceAmountValue;
            }
            set
            {
                _InvoiceAmountValue = value;
                OnPropertyChanged("InvoiceAmountValue");
            }
        }



        public string SelectedCashChequeNo
        {
            get
            {
                return _SelectedCashChequeNo;
            }
            set
            {
                _SelectedCashChequeNo = value;
                OnPropertyChanged("SelectedCashChequeNo");
            }
        }
        public bool? ShowAllTrue
        {
            get
            {
                return _ShowAllTrue;
            }
            set
            {
                _ShowAllTrue = value;
                OnPropertyChanged("ShowAllTrue");
            }
        }
        public bool? ShowSelectedTrue
        {
            get
            {
                return _ShowSelectedTrue;
            }
            set
            {
                _ShowSelectedTrue = value;
                OnPropertyChanged("ShowSelectedTrue");
            }
        }
        public string Year
        {
            get
            {
                return _Year;
            }
            set
            {
                _Year = value;
                OnPropertyChanged("Year");
            }
        }
        public string Quater
        {
            get
            {
                return _Quater;
            }
            set
            {
                _Quater = value;
                OnPropertyChanged("Quater");
            }
        }
        public string Month
        {
            get
            {
                return _Month;
            }
            set
            {
                _Month = value;
                OnPropertyChanged("Month");
            }
        }
        public string StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
                OnPropertyChanged("StartDate");
            }
        }
        public string EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public string Search
        {
            get
            {
                return _Search;
            }
            set
            {
                _Search = value;
                OnPropertyChanged("Search");
            }
        }
        public List<PaymentFromCustomersListEntity> PaymentsFromCustomersList
        {
            get { return _PaymentsFromCustomersList; }
            set
            {
                if (_PaymentsFromCustomersList != value)
                {
                    _PaymentsFromCustomersList = value;
                    OnPropertyChanged("PaymentsFromCustomersList");
                }
            }
        }
        public List<PaymentFromCustomersListEntity> PaymentsFromCustomersListcmb
        {
            get { return _PaymentsFromCustomersListcmb; }
            set
            {
                if (_PaymentsFromCustomersListcmb != value)
                {
                    _PaymentsFromCustomersListcmb = value;
                    OnPropertyChanged("PaymentsFromCustomersListcmb");
                }
            }
        }
        public List<PaymentFromCustomersListEntity> PaymentsFromCustomersListcmbInv
        {
            get { return _PaymentsFromCustomersListcmbInv; }
            set
            {
                if (_PaymentsFromCustomersListcmbInv != value)
                {
                    _PaymentsFromCustomersListcmbInv = value;
                    OnPropertyChanged("PaymentsFromCustomersListcmbInv");
                }
            }
        }
        public List<PaymentFromCustomersListEntity> PaymentsFromCustomersListcmbSup
        {
            get { return _PaymentsFromCustomersListcmbSup; }
            set
            {
                if (_PaymentsFromCustomersListcmbSup != value)
                {
                    _PaymentsFromCustomersListcmbSup = value;
                    OnPropertyChanged("PaymentsFromCustomersListcmbSup");
                }
            }
        }
        public List<PaymentFromCustomersListEntity> PaymentsFromCustomersListcmbDebit
        {
            get { return _PaymentsFromCustomersListcmbDebit; }
            set
            {
                if (_PaymentsFromCustomersListcmbDebit != value)
                {
                    _PaymentsFromCustomersListcmbDebit = value;
                    OnPropertyChanged("PaymentsFromCustomersListcmbDebit");
                }
            }
        }
        public int ShowAllCount
        {
            get
            {
                return _ShowAllCount;
            }
            set
            {
                _ShowAllCount = value;
                OnPropertyChanged("ShowAllCount");
            }
        }
        public int ShowSelectedCount
        {
            get
            {
                return _ShowSelectedCount;
            }
            set
            {
                _ShowSelectedCount = value;
                OnPropertyChanged("ShowSelectedCount");
            }
        }

        public bool? IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                _IsDeleted = value;
                OnPropertyChanged("IsDeleted");
            }
        }
        public int SelectedSearchPQList
        {
            get
            {
                return _SelectedSearchPQList;
            }
            set
            {
                _SelectedSearchPQList = value;
                OnPropertyChanged("SelectedSearchPQList");
            }
        }
        public int SelectedIndex
        {
            get
            {
                return _SelectedIndex;
            }
            set
            {
                _SelectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        public List<YearEntity> YearRange
        {
            get
            {
                return _YearRange;
            }
            set
            {
                _YearRange = value;
                OnPropertyChanged("YearRange");
            }
        }

        public List<QuarterEntity> QuarterRange
        {
            get
            {
                return _QuarterRange;
            }
            set
            {
                _QuarterRange = value;
                OnPropertyChanged("QuarterRange");
            }
        }


        public DateTime? CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                _CreatedDate = value;
                OnPropertyChanged("CreatedDate");
            }
        }


        public string SelectedSearchSupName
        {
            get
            {
                return _SelectedSearchSupName;
            }
            set
            {
                _SelectedSearchSupName = value;
                OnPropertyChanged("SelectedSearchSupName");
            }
        }
        public string SelectedSearchInvoiceNo
        {
            get
            {
                return _SelectedSearchInvoiceNo;
            }
            set
            {
                _SelectedSearchInvoiceNo = value;
                OnPropertyChanged("SelectedSearchInvoiceNo");
            }
        }
        public string SelectedSearchYear
        {
            get
            {
                return _SelectedSearchYear;
            }
            set
            {
                _SelectedSearchYear = value;
                OnPropertyChanged("SelectedSearchYear");
            }
        }
        public string SelectedSearchQuarter
        {
            get
            {
                return _SelectedSearchQuarter;
            }
            set
            {
                _SelectedSearchQuarter = value;
                //if (_SelectedSearchQuarter != null)
                //SelectedSearchMonth = null;
                OnPropertyChanged("SelectedSearchQuarter");
            }
        }
        public string SelectedSearchMonth
        {
            get
            {
                return _SelectedSearchMonth;
            }
            set
            {
                _SelectedSearchMonth = value;
                if (_SelectedSearchMonth != null)
                    SelectedSearchQuarter = null;
                OnPropertyChanged("SelectedSearchMonth");
            }
        }
        public DateTime? SelectedSearchStartDate
        {
            get
            {
                return _SelectedSearchStartDate;
            }
            set
            {
                _SelectedSearchStartDate = value;
                OnPropertyChanged("SelectedSearchStartDate");
            }
        }
        public DateTime? SelectedSearchEndDate
        {
            get
            {
                return _SelectedSearchEndDate;
            }
            set
            {
                _SelectedSearchEndDate = value;
                OnPropertyChanged("SelectedSearchEndDate");
            }
        }
        public string JsonData
        {
            get
            {
                return _JsonData;
            }
            set
            {
                _JsonData = value;
                OnPropertyChanged("JsonData");
            }
        }

        public bool? YearmonthQuartTrue
        {
            get
            {
                return _YearmonthQuartTrue;
            }
            set
            {
                _YearmonthQuartTrue = value;
                if (_YearmonthQuartTrue == true)
                {
                    SelectedSearchStartDate = null;
                    SelectedSearchEndDate = null;
                    EnableEndDropDown = false;
                    EnableStartDropDown = false;
                    EnableMonthDropDown = true;
                    EnableQuarterDropDown = true;
                    EnableYearDropDown = true;

                }

                OnPropertyChanged("YearmonthQuartTrue");
            }
        }
        public bool? StartEndDateTrue
        {
            get
            {
                return _StartEndDateTrue;
            }
            set
            {
                _StartEndDateTrue = value;
                if (_StartEndDateTrue == true)
                {
                    SelectedSearchMonth = null;
                    SelectedSearchQuarter = null;
                    SelectedSearchYear = null;
                    EnableYearDropDown = false;
                    EnableQuarterDropDown = false;
                    EnableMonthDropDown = false;
                    EnableStartDropDown = true;
                    if (EnableEndDropDown != null && EnableEndDropDown != false)
                        EnableEndDropDown = true;
                    else
                        EnableEndDropDown = false;
                }
                OnPropertyChanged("StartEndDateTrue");
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


        #endregion
    }
}
