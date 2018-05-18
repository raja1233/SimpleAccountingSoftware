
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Product
{
    using SDN.Common;
    using System.Globalization;

    public class CountAndAdjustStockListEntity: ViewModelBase
    {
        #region Private Properties
        
        private string _CountAndAdjustStockNo;
        private string _CountAndAdjustStockDate;
        private DateTime? _CountAndAdjustStockDateDateTime;
        private string _AdjustedAmount;
        private decimal? _adjustedAmountd;
      
        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;
        private string _Year;
        private string _Quater;
        private string _Month;
        private string _StartDate;
        private string _EndDate;
       
        private string _Search;
        private List<CountAndAdjustStockListEntity> _CountAndAdjustStockList;
        private List<CountAndAdjustStockListEntity> _CountAndAdjustStockListDate;
        private List<CountAndAdjustStockListEntity> _CountAndAdjustStockListSCNo;
        private List<CountAndAdjustStockListEntity> _CountAndAdjustStockListAmount;
        //  private List<PurchaseQuotationListEntity> _PurchaseQuotationListInternal;
        private int _ShowAllCount;
        private int _ShowSelectedCount;
        private bool? _IsDeleted;
        private int _SelectedSearchPQList;
        private int _SelectedIndex;

        private string _SelectedSearchStockDate;
        private string _SelectedSearchStockNo;
        private string _SelectedSearchAmount;
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
        
        private string _LastupdatedDate;
        private DateTime? _CreatedDateList;
        private DateTime? _EndDateValidation;
        private string totalStockAmount;
        private int _PQGridHeight;
        
        #endregion


        #region Public Properties
        
        public int PQGridHeight
        {
            get
            {
                return _PQGridHeight;
            }
            set
            {
                _PQGridHeight = value;
                OnPropertyChanged("PQGridHeight");
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

       

        public string TotalStockAmount
        {
            get
            {
                //return _QuotationAmount;
                if (totalStockAmount == null)
                    return this.totalStockAmount;
                else
                {
                    if (totalStockAmount != "")
                    {
                        var balance = totalStockAmount.Replace(",", "");
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
                        return this.totalStockAmount;
                }
            }
            set
            {
                totalStockAmount = value;
                OnPropertyChanged("TotalStockAmount");
            }
        }
       
        public string CountAndAdjustStockNo
        {
            get
            {
                return _CountAndAdjustStockNo;
            }
            set
            {
                _CountAndAdjustStockNo = value;
                OnPropertyChanged("CountAndAdjustStockNo");
            }
        }
        public string CountAndAdjustStockDate
        {
            get
            {
                return _CountAndAdjustStockDate;
            }
            set
            {
                _CountAndAdjustStockDate = value;
                OnPropertyChanged("CountAndAdjustStockDate");
            }
        }
        public DateTime? CountAndAdjustStockDateDatetime
        {
            get
            {
                return _CountAndAdjustStockDateDateTime;
            }
            set
            {
                _CountAndAdjustStockDateDateTime = value;
                OnPropertyChanged("CountAndAdjustStockDateDatetime");
            }
        }

        public decimal? AdjustedAmountd
        {
            get { return _adjustedAmountd; }
            set {
                _adjustedAmountd = value;
                OnPropertyChanged("AdjustedAmountd");
            }
        }
        public string AdjustedAmount
        {
            get
            {
                //return _QuotationAmount;
                if (_AdjustedAmount == null)
                    return this._AdjustedAmount;
                else
                {
                    if (_AdjustedAmount != "")
                    {
                        var balance = _AdjustedAmount.Replace(",", "");
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
                        return this._AdjustedAmount;
                }
            }
            set
            {
                _AdjustedAmount = value;
                OnPropertyChanged("AdjustedAmount");
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
        public List<CountAndAdjustStockListEntity> CountAndAdjustStockList
        {
            get { return _CountAndAdjustStockList; }
            set
            {
                if (_CountAndAdjustStockList != value)
                {
                    _CountAndAdjustStockList = value;
                    OnPropertyChanged("CountAndAdjustStockList");
                }
            }
        }
        List<CountAndAdjustStockListEntity> _CountAndAdjustStockListcmb;
        public List<CountAndAdjustStockListEntity> CountAndAdjustStockListcmb
        {
            get { return _CountAndAdjustStockListcmb; }
            set
            {
                if (_CountAndAdjustStockListcmb != value)
                {
                    _CountAndAdjustStockListcmb = value;
                    OnPropertyChanged("CountAndAdjustStockListcmb");
                }
            }
        }

        public List<CountAndAdjustStockListEntity> CountAndAdjustStockListDate
        {
            get { return _CountAndAdjustStockListDate; }
            set
            {
                if (_CountAndAdjustStockListDate != value)
                {
                    _CountAndAdjustStockListDate = value;
                    OnPropertyChanged("CountAndAdjustStockListDate");
                }
            }
        }
        public List<CountAndAdjustStockListEntity> CountAndAdjustStockListSCNo
        {
            get { return _CountAndAdjustStockListSCNo; }
            set
            {
                if (_CountAndAdjustStockListSCNo != value)
                {
                    _CountAndAdjustStockListSCNo = value;
                    OnPropertyChanged("CountAndAdjustStockListSCNo");
                }
            }
        }

        public List<CountAndAdjustStockListEntity> CountAndAdjustStockListAmount
        {
            get { return _CountAndAdjustStockListAmount; }
            set
            {
                if (_CountAndAdjustStockListAmount != value)
                {
                    _CountAndAdjustStockListAmount = value;
                    OnPropertyChanged("CountAndAdjustStockListAmount");
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


        public string SelectedSearchStockDate
        {
            get
            {
                return _SelectedSearchStockDate;
            }
            set
            {
                _SelectedSearchStockDate = value;
                OnPropertyChanged("SelectedSearchStockDate");
            }
        }
        public string SelectedSearchStockNo
        {
            get
            {
                return _SelectedSearchStockNo;
            }
            set
            {
                _SelectedSearchStockNo = value;
                OnPropertyChanged("SelectedSearchStockNo");
            }
        }
        public string SelectedSearchAmount
        {
            get
            {
                return _SelectedSearchAmount;
            }
            set
            {
                _SelectedSearchAmount = value;
                OnPropertyChanged("SelectedSearchAmount");
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
