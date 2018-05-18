using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Accounts
{
    public  class LedgerEntity :ViewModelBase
    {
        #region "Private Entity region"
        private List<LedgerEntity> ledgerList;
        private DateTime? _TransactionDateTime;
        private string _TransactionDate;
        private string _TransactionNo;
        private string _AccountName;
        private decimal? _DebitAmount;
        private string _Debit;
        private decimal? _CreditAmount;
        private string _Credit;
        private int _LedgerGridHeight;
        private string _SelectedSearchQuarter;
        private string _SelectedSearchMonth;
        private DateTime? _SelectedSearchStartDate;
        private DateTime? _SelectedSearchEndDate;
        private List<YearEntity> _YearRange;
        private List<QuarterEntity> _QuarterRange;
        private string _JsonData;
        private bool? _YearmonthQuartTrue;
        private bool? _StartEndDateTrue;
        private bool? _EnableYearDropDown;
        private bool? _EnableQuarterDropDown;
        private bool? _EnableMonthDropDown;
        private bool? _EnableStartDropDown;
        private bool? _EnableEndDropDown;
        private string _SelectedSearchYear;
        private bool? _ShowSelectedTrue;
        private bool? _ShowAllTrue;
        private string _currencyFormat;
        private string _currencyName;
        private string _currencyCode;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private DateTime? _EndDateValidation;
        private List<LedgerEntity> _LedgerList;
        #endregion
        #region "Public region"
        public List<LedgerEntity> LedgerList
        {
            get { return ledgerList; }
            set
            {
                ledgerList = value;
                OnPropertyChanged("LedgerList");
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
            get { return _DateFormat; }
            set { SetProperty(ref _DateFormat, value, "DateFormat"); }
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
        public int LedgerGridHeight
        {
            get
            {
                return _LedgerGridHeight;
            }
            set
            {
                _LedgerGridHeight = value;
                OnPropertyChanged("LedgerGridHeight");
            }
        }
        public DateTime? TransactionDateTime
        {
            get
            {
                return _TransactionDateTime;
            }
            set
            {
                _TransactionDateTime = value;
                OnPropertyChanged("TransactionDateTime");
            }
        }
        public string TransactionDate
        {
            get
            {
                return _TransactionDate;
            }
            set
            {
                _TransactionDate = value;
                OnPropertyChanged("TransactionDate");
            }
        }
        public string TransactionNo
        {
            get
            {
                return _TransactionNo;
            }
            set
            {
                _TransactionNo = value;
                OnPropertyChanged("TransactionNo");
            }
        }
        public string  AccountName
        {
            get
            {
                return _AccountName;
            }
            set
            {
                _AccountName = value;
                OnPropertyChanged("AccountName");
            }
        }
        public decimal? DebitAmount
        {
            get
            {
                return _DebitAmount;
            }
            set
            {
                _DebitAmount = value;
                OnPropertyChanged("DebitAmount");
            }
        }
        public string Debit
        {
            get
            {
                return _Debit;
            }
            set
            {
                _Debit = value;
                OnPropertyChanged("Debit");
            }
        }
        public decimal? CreditAmount
        {
            get
            {
                return _CreditAmount;
            }
            set
            {
                _CreditAmount = value;
                OnPropertyChanged("CreditAmount");
            }
        }
        public string  Credit
        {
            get
            {
                return _Credit;
            }
            set
            {
                _Credit = value;
                OnPropertyChanged("Credit");
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
        #endregion

    }
}
