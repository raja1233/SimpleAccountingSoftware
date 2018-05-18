
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Sales
{
    using SDN.Common;
    using System.Globalization;

    public class SalesQuotationListEntity: ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private int _Cus_ID;
        private string _CustomerName;
        private string _QuotationNo;
        private string _QuotationDate;
        private DateTime? _QuotationDateDateTime;
        private string _QuotationAmount;
        private string _QuotationAmountIncGST;
        private string _QuotationAmountExcGST;
        private string _ConvertedTo;
        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;
        private string _Year;
        private string _Quater;
        private string _Month;
        private string _StartDate;
        private string _EndDate;
        private bool? _ExcludingGST;
        private bool? _IncludingGST;
        private bool? _ExcIncGST;
        private string _Search;
        private List<SalesQuotationListEntity> _SalesQuotationList;
        private List<SalesQuotationListEntity> _SalesQuotationListcmb;
        private List<SalesQuotationListEntity> _SalesQuotationListcmbQNo;
        private List<SalesQuotationListEntity> _SalesQuotationListcmbSup;
        private List<SalesQuotationListEntity> _SalesQuotationListInternal;
        private int _ShowAllCount;
        private int _ShowSelectedCount;
        private bool? _ConvertedToSI;
        private bool? _ConvertedToSO;
        private bool? _IsDeleted;
        private int _SelectedSearchPQList;
        private int _SelectedIndex;

        private string _SelectedSearchSupName;
        private string _SelectedSearchQNo;
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
        private string _SelectedSearchConvertedTo;
        private bool? _IncludingGSTTrue;
        private bool? _IncludingGSTFalse;
        private string _LastupdatedDate;
        private DateTime? _CreatedDateList;
        private DateTime? _EndDateValidation;
        private int _SQGridHeight;
        private string _ConvertedToNo;
        private int _SortQuotationNo;
        #endregion


        #region Public Properties

        public int SortQuotationNo
        {
            get
            {
                return _SortQuotationNo;
            }
            set
            {
                _SortQuotationNo = value;
                OnPropertyChanged("SortQuotationNo");
            }
        }
        public string ConvertedToNo
        {
            get
            {
                return _ConvertedToNo;
            }
            set
            {
                _ConvertedToNo = value;
                OnPropertyChanged("ConvertedToNo");
            }
        }
        public int SQGridHeight
        {
            get
            {
                return _SQGridHeight;
            }
            set
            {
                _SQGridHeight = value;
                OnPropertyChanged("SQGridHeight");
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
        public DateTime? CreatedDateList
        {
            get
            {
                return _CreatedDateList;
            }
            set
            {
                _CreatedDateList = value;
                OnPropertyChanged("CreatedDateList");
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
        public bool? IncludingGSTTrue
        {
            get
            {
                return _IncludingGSTTrue;
            }
            set
            {
                _IncludingGSTTrue = value;
                OnPropertyChanged("IncludingGSTTrue");
            }
        }
        public bool? IncludingGSTFalse
        {
            get
            {
                return _IncludingGSTFalse;
            }
            set
            {
                _IncludingGSTFalse = value;
                OnPropertyChanged("IncludingGSTFalse");
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
        public int Cus_ID
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
        public string QuotationNo
        {
            get
            {
                return _QuotationNo;
            }
            set
            {
                _QuotationNo = value;
                OnPropertyChanged("QuotationNo");
            }
        }
        public string QuotationDate
        {
            get
            {
                return _QuotationDate;
            }
            set
            {
                _QuotationDate = value;
                OnPropertyChanged("QuotationDate");
            }
        }
        public DateTime? QuotationDateDateTime
        {
            get
            {
                return _QuotationDateDateTime;
            }
            set
            {
                _QuotationDateDateTime = value;
                OnPropertyChanged("QuotationDateDateTime");
            }
        }
        public string QuotationAmount
        {
            get
            {
                //return _QuotationAmount;
                if (_QuotationAmount == null)
                    return this._QuotationAmount;
                else
                {
                    if (_QuotationAmount != "")
                    {
                        var balance = _QuotationAmount.Replace(",", "");
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
                        return this._QuotationAmount;
                }
            }
            set
            {
                _QuotationAmount = value;
                OnPropertyChanged("QuotationAmount");
            }
        }

        private decimal? qAmount;
        public decimal? QAmount
        {
            get { return qAmount; }
            set
            {
                qAmount = value;
                OnPropertyChanged("QAmount");
            }
        }
        public string QuotationAmountIncGST
        {
            get
            {
                return _QuotationAmountIncGST;
            }
            set
            {
                _QuotationAmountIncGST = value;
                OnPropertyChanged("QuotationAmountIncGST");
            }
        }
        public string QuotationAmountExcGST
        {
            get
            {
                return _QuotationAmountExcGST;
            }
            set
            {
                _QuotationAmountExcGST = value;
                OnPropertyChanged("QuotationAmountExcGST");
            }
        }
        public string ConvertedTo
        {
            get
            {
                return _ConvertedTo;
            }
            set
            {
                _ConvertedTo = value;
                OnPropertyChanged("ConvertedTo");
            }
        }
        public string SelectedSearchConvertedTo
        {
            get
            {
                return _SelectedSearchConvertedTo;
            }
            set
            {
                _SelectedSearchConvertedTo = value;
                OnPropertyChanged("SelectedSearchConvertedTo");
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
        public bool? ExcludingGST
        {
            get
            {
                return _ExcludingGST;
            }
            set
            {
                _ExcludingGST = value;
                OnPropertyChanged("ExcludingGST");
            }
        }
        public bool? IncludingGST
        {
            get
            {
                return _IncludingGST;
            }
            set
            {
                _IncludingGST = value;
                OnPropertyChanged("IncludingGST");
            }
        }
        public bool? ExcIncGST
        {
            get
            {
                return _ExcIncGST;
            }
            set
            {
                _ExcIncGST = value;
                OnPropertyChanged("ExcIncGST");
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
        public List<SalesQuotationListEntity> SalesQuotationList
        {
            get { return _SalesQuotationList; }
            set
            {
                if (_SalesQuotationList != value)
                {
                    _SalesQuotationList = value;
                    OnPropertyChanged("SalesQuotationList");
                }
            }
        }
        public List<SalesQuotationListEntity> SalesQuotationListInternal
        {
            get { return _SalesQuotationList; }
            set
            {
                if (_SalesQuotationList != value)
                {
                    _SalesQuotationList = value;
                    OnPropertyChanged("SalesQuotationList");
                }
            }
        }
        public List<SalesQuotationListEntity> SalesQuotationListcmbQNo
        {
            get { return _SalesQuotationListcmbQNo; }
            set
            {
                if (_SalesQuotationListcmbQNo != value)
                {
                    _SalesQuotationListcmbQNo = value;
                    OnPropertyChanged("SalesQuotationListcmbQNo");
                }
            }
        }

        public List<SalesQuotationListEntity> SalesQuotationListcmbSup
        {
            get { return _SalesQuotationListcmbSup; }
            set { _SalesQuotationListcmbSup = value;
                OnPropertyChanged("SalesQuotationListcmbSup");
            }
        }

        public List<SalesQuotationListEntity> SalesQuotationListcmb
        {
            get { return _SalesQuotationListcmb; }
            set
            {
                if (_SalesQuotationListcmb != value)
                {
                    _SalesQuotationListcmb = value;
                    OnPropertyChanged("SalesQuotationListcmb");
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
        public bool? ConvertedToSI
        {
            get
            {
                return _ConvertedToSI;
            }
            set
            {
                _ConvertedToSI = value;
                OnPropertyChanged("ConvertedToSI");
            }
        }
        public bool? ConvertedToSO
        {
            get
            {
                return _ConvertedToSO;
            }
            set
            {
                _ConvertedToSO = value;
                OnPropertyChanged("ConvertedToSO");
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
        public string SelectedSearchQNo
        {
            get
            {
                return _SelectedSearchQNo;
            }
            set
            {
                _SelectedSearchQNo = value;
                OnPropertyChanged("SelectedSearchQNo");
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

        private string totalAmount;
        public string TotalAmount
        {
            get
            {
                //return _OrderAmount;
                if (totalAmount == null)
                    return this.totalAmount;
                else
                {
                    if (totalAmount != "")
                    {
                        var balance = totalAmount.Replace(",", "");
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
                        return this.totalAmount;
                }
            }
            set
            {
                totalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        #endregion

    }
}
