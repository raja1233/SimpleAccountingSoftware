using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Product
{
    using SDN.Common;
    using System.Globalization;

    public class PandSHistoryEntity : ViewModelBase
    {
        #region "Private Properties"
        private int _ID;
        private string _ProductCode;
        private string _ProductName;
        private int _Category1Id;
        private string _Category1;
        private int _Category2Id;
        private string _Category2;

        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;
        private bool? _ShowProducts;
        private bool? _ShowServices;
        private bool? _ShowBoth;
        private string _SelectedPandSCode;
        private string _SelectedPandSName;
        private string _SelectedCategory1;
        private string _SelectedCategory2;

        private List<PandSHistoryEntity> _PandSHistoryListcmb;
        private List<PandSHistoryEntity> _PandSHistoryList;
        private List<PandSHistoryEntity> _PandSHistoryListcmbCat1;
        private List<PandSHistoryEntity> _PandSHistoryListcmbCat2;
        private string _InvoiceAmount;
        private decimal? _InvoiceAmountValue;
        private string _InvoiceAmountIncGST;
        private string _InvoiceAmountExcGST;
        private int siGridHeight;

        private string _Year;
        private string _Quater;
        private string _Month;
        private string _StartDate;
        private string _EndDate;
        private bool? _ExcludingGST;
        private bool? _IncludingGST;
        private string _Search;
        private bool? isSales;
        private bool? isSalesTrue;
        private bool? isSalesFalse;
        private int _ShowAllCount;
        private int _ShowSelectedCount;
        private bool? _ExcIncGST;

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

        private bool? _IncludingGSTTrue;
        private bool? _IncludingGSTFalse;
        private string _LastupdatedDate;
        private DateTime? _CreatedDateList;
        private DateTime? _EndDateValidation;

        private string _FirstMonth;
        private string _SecondMonth;
        private string _ThirdMonth;
        private decimal? _TotalM1;
        private string _TotalM1Str;
        private string _TotalCusM1;
        private decimal? _TotalM2;
        private string _TotalM2Str;
        private string _TotalCusM2;
        private decimal? _TotalM3;
        private string _TotalM3Str;
        private string _TotalCusM3;
        private decimal? _QuarterTotal;
        private string _QuarterTotalStr;
        private string _TotalCusQuarter;
        private decimal? _YearTotal;
        private string _YearTotalStr;
        private string _TotalCusYear;
        private string _QuarterName;
        private string _YearName;

        #endregion

        #region "Properties"
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
        public string ProductCode
        {
            get
            {
                return _ProductCode;
            }
            set
            {
                _ProductCode = value;
                OnPropertyChanged("ProductCode");
            }
        }

        public bool? ExcIncGST
        {
            get { return _ExcIncGST; }
            set { _ExcIncGST = value;
                OnPropertyChanged("ExcIncGST");
            }
        }

        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
                OnPropertyChanged("ProductName");
            }
        }
        public int Category1Id
        {
            get
            {
                return _Category1Id;
            }
            set
            {
                _Category1Id = value;
                OnPropertyChanged("Category1Id");
            }
        }
        public string Category1
        {
            get
            {
                return _Category1;
            }
            set
            {
                _Category1 = value;
                OnPropertyChanged("Category1");
            }
        }
        public int Category2Id
        {
            get
            {
                return _Category2Id;
            }
            set
            {
                _Category2Id = value;
                OnPropertyChanged("Category2Id");
            }
        }
        public string Category2
        {
            get
            {
                return _Category2;
            }
            set
            {
                _Category2 = value;
                OnPropertyChanged("Category2");
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
      

        public bool? ShowProducts
        {
            get
            {
                return _ShowProducts;
            }
            set
            {
                _ShowProducts = value;
                OnPropertyChanged("ShowProducts");
            }
        }
        public bool? ShowServices
        {
            get
            {
                return _ShowServices;
            }
            set
            {
                _ShowServices = value;
                OnPropertyChanged("ShowServices");
            }
        }


        public bool? ShowBoth
        {
            get
            {
                return _ShowBoth;
            }
            set
            {
                _ShowBoth = value;
                OnPropertyChanged("ShowBoth");
            }
        }

        public List<PandSHistoryEntity> PandSHistoryList
        {
            get
            {
                return _PandSHistoryList;
            }
            set
            {
                _PandSHistoryList = value;
                OnPropertyChanged("PandSHistoryList");
            }
        }

        public List<PandSHistoryEntity> PandSHistoryListcmb
        {
            get
            {
                return _PandSHistoryListcmb;
            }
            set
            {
                _PandSHistoryListcmb = value;
                OnPropertyChanged("PandSHistoryListcmb");
            }
        }
        public List<PandSHistoryEntity> PandSHistoryListcmbCat1
        {
            get
            {
                return _PandSHistoryListcmbCat1;
            }
            set
            {
                _PandSHistoryListcmbCat1 = value;
                OnPropertyChanged("PandSHistoryListcmbCat1");
            }
        }
        public List<PandSHistoryEntity> PandSHistoryListcmbCat2
        {
            get
            {
                return _PandSHistoryListcmbCat2;
            }
            set
            {
                _PandSHistoryListcmbCat2 = value;
                OnPropertyChanged("PandSHistoryListcmbCat2");
            }
        }

        public bool? EnableYearDropDown
        {
            get { return _EnableYearDropDown; }
            set
            {
                _EnableYearDropDown = value;
                OnPropertyChanged("EnableYearDropDown");
            }
        }
        public bool? EnableQuarterDropDown
        {
            get { return _EnableQuarterDropDown; }
            set
            {
                _EnableQuarterDropDown = value;
                OnPropertyChanged("EnableQuarterDropDown");
            }
        }
        public bool? EnableMonthDropDown
        {
            get { return _EnableMonthDropDown; }
            set
            {
                _EnableMonthDropDown = value;
                OnPropertyChanged("EnableMonthDropDown");
            }
        }
          public bool? IsSales
        {
            get { return isSales; }
            set { isSales = value;
                OnPropertyChanged("IsSales");
            }
        }
        public bool? IsSalesTrue
        {
            get { return isSalesTrue; }
            set { isSalesTrue = value;
                OnPropertyChanged("IsSalesTrue");
            }
        }
        public bool? IsSalesFalse
        {
            get { return isSalesFalse; }
            set
            {
                isSalesFalse = value;
                OnPropertyChanged("IsSalesFalse");
            }
        }
        public bool? IncludingGSTTrue
        {
            get { return _IncludingGSTTrue; }
            set
            {
                _IncludingGSTTrue = value;
                OnPropertyChanged("IncludingGSTTrue");
            }
        }
        public bool? IncludingGSTFalse
        {
            get { return _IncludingGSTFalse; }
            set
            {
                _IncludingGSTFalse = value;
                OnPropertyChanged("IncludingGSTFalse");
            }
        }
        public string LastupdatedDate
        {
            get { return _LastupdatedDate; }
            set
            {
                _LastupdatedDate = value;
                OnPropertyChanged("LastupdatedDate");
            }
        }
       
        public int SIGridHeight
        {
            get { return siGridHeight; }
            set { siGridHeight = value;
                OnPropertyChanged("SIGridHeight");
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
                _currencyName = value;
                OnPropertyChanged("CurrencyName");
            }
        }
        public string CurrencyCode
        {
            get
            {
                return _currencyCode;
            }
            set
            {
                _currencyCode = value;
                OnPropertyChanged("CurrencyCode");
            }
        }
        public string CurrencyFormat
        {
            get
            {
                return _currencyFormat;
            }
            set
            {
                _currencyFormat = value;
                OnPropertyChanged("CurrencyFormat");
            }
        }
        public string DateFormat
        {
            get
            {
                return _DateFormat;
            }
            set
            {
                _DateFormat = value;
                OnPropertyChanged("DateFormat");
            }
        }
        public decimal? DecimalPlaces
        {
            get
            {
                return _decimalPlaces;
            }
            set
            {
                _decimalPlaces = value;
                OnPropertyChanged("DecimalPlaces");
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

        public string SelectedPandSCode
        {
            get
            {
                return _SelectedPandSCode;
            }
            set
            {
                _SelectedPandSCode = value;
                OnPropertyChanged("SelectedPandSCode");
            }
        }
        public string SelectedPandSName
        {
            get
            {
                return _SelectedPandSName;
            }
            set
            {
                _SelectedPandSName = value;
                OnPropertyChanged("SelectedPandSName");
            }
        }
        public string SelectedCategory1
        {
            get
            {
                return _SelectedCategory1;
            }
            set
            {
                _SelectedCategory1 = value;
                OnPropertyChanged("SelectedCategory1");
            }
        }
        public string SelectedCategory2
        {
            get
            {
                return _SelectedCategory2;
            }
            set
            {
                _SelectedCategory2 = value;
                OnPropertyChanged("SelectedCategory2");
            }
        }
        public bool? YearmonthQuartTrue
        {
           get { return _YearmonthQuartTrue; }
            set { _YearmonthQuartTrue = value;
                OnPropertyChanged("YearmonthQuartTrue");
            }
        }
        public bool? StartEndDateTrue
        {

            get { return _StartEndDateTrue; }
            set
            {
                _StartEndDateTrue = value;
                OnPropertyChanged("StartEndDateTrue");
            }
        }
        public string YearName
        {
            get
            {
                return _YearName;
            }
            set
            {
                _YearName = value;
                OnPropertyChanged("YearName");
            }
        }
        public string QuarterName
        {
            get
            {
                return _QuarterName;
            }
            set
            {
                _QuarterName = value;
                OnPropertyChanged("QuarterName");
            }
        }
        public decimal? TotalM1
        {
            get
            {
                return _TotalM1;
            }
            set
            {
                _TotalM1 = value;
                OnPropertyChanged("TotalM1");
            }
        }
        public string TotalM1Str
        {
            get
            {
                // return _TotalM1Str;
                if (_TotalM1Str == null)
                    return this._TotalM1Str;
                else
                {
                    if (_TotalM1Str != "")
                    {
                        var balance = _TotalM1Str.Replace(",", "");
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
                        return this._TotalM1Str;
                }
            }
            set
            {
                _TotalM1Str = value;
                OnPropertyChanged("TotalM1Str");
            }
        }
        public string TotalCusM1
        {
            get
            {
                // return _TotalCusM1;
                if (_TotalCusM1 == null)
                    return this._TotalCusM1;
                else
                {
                    if (_TotalCusM1 != "")
                    {
                        var balance = _TotalCusM1.Replace(",", "");
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
                        return this._TotalCusM1;
                }
            }
            set
            {
                _TotalCusM1 = value;
                OnPropertyChanged("TotalCusM1");
            }
        }
        public decimal? TotalM2
        {
            get
            {
                return _TotalM2;
            }
            set
            {
                _TotalM2 = value;
                OnPropertyChanged("TotalM2");
            }
        }
        public string TotalM2Str
        {
            get
            {
                //return _TotalM2Str;
                if (_TotalM2Str == null)
                    return this._TotalM2Str;
                else
                {
                    if (_TotalM2Str != "")
                    {
                        var balance = _TotalM2Str.Replace(",", "");
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
                        return this._TotalM2Str;
                }
            }
            set
            {
                _TotalM2Str = value;
                OnPropertyChanged("TotalM2Str");
            }
        }
        public string TotalCusM2
        {
            get
            {
                // return _TotalCusM2;
                if (_TotalCusM2 == null)
                    return this._TotalCusM2;
                else
                {
                    if (_TotalCusM2 != "")
                    {
                        var balance = _TotalCusM2.Replace(",", "");
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
                        return this._TotalCusM2;
                }
            }
            set
            {
                _TotalCusM2 = value;
                OnPropertyChanged("TotalCusM2");
            }
        }
        public decimal? TotalM3
        {
            get
            {
                return _TotalM3;
            }
            set
            {
                _TotalM3 = value;
                OnPropertyChanged("TotalM3");
            }
        }
        public string TotalM3Str
        {
            get
            {
                //return _TotalM3Str;
                if (_TotalM3Str == null)
                    return this._TotalM3Str;
                else
                {
                    if (_TotalM3Str != "")
                    {
                        var balance = _TotalM3Str.Replace(",", "");
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
                        return this._TotalM3Str;
                }

            }
            set
            {
                _TotalM3Str = value;
                OnPropertyChanged("TotalM3Str");
            }
        }
        public string TotalCusM3
        {
            get
            {
                //return _TotalCusM3;
                if (_TotalCusM3 == null)
                    return this._TotalCusM3;
                else
                {
                    if (_TotalCusM3 != "")
                    {
                        var balance = _TotalCusM3.Replace(",", "");
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
                        return this._TotalCusM3;
                }
            }
            set
            {
                _TotalCusM3 = value;
                OnPropertyChanged("TotalCusM3");
            }
        }
        public decimal? QuarterTotal
        {
            get
            {
                return _QuarterTotal;
            }
            set
            {
                _QuarterTotal = value;
                OnPropertyChanged("QuarterTotal");
            }
        }
        public string QuarterTotalStr
        {
            get
            {
                //return _QuarterTotalStr;
                if (_QuarterTotalStr == null)
                    return this._QuarterTotalStr;
                else
                {
                    if (_QuarterTotalStr != "")
                    {
                        var balance = _QuarterTotalStr.Replace(",", "");
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
                        return this._QuarterTotalStr;
                }
            }
            set
            {
                _QuarterTotalStr = value;
                OnPropertyChanged("QuarterTotalStr");
            }
        }
        public string TotalCusQuarter
        {
            get
            {
                //return _TotalCusQuarter;
                if (_TotalCusQuarter == null)
                    return this._TotalCusQuarter;
                else
                {
                    if (_TotalCusQuarter != "")
                    {
                        var balance = _TotalCusQuarter.Replace(",", "");
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
                        return this._TotalCusQuarter;
                }
            }
            set
            {
                _TotalCusQuarter = value;
                OnPropertyChanged("TotalCusQuarter");
            }
        }
        public decimal? YearTotal
        {
            get
            {
                return _YearTotal;
            }
            set
            {
                _YearTotal = value;
                OnPropertyChanged("YearTotal");
            }
        }
        public string YearTotalStr
        {
            get
            {
                //return _YearTotalStr;
                if (_YearTotalStr == null)
                    return this._YearTotalStr;
                else
                {
                    if (_YearTotalStr != "")
                    {
                        var balance = _YearTotalStr.Replace(",", "");
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
                        return this._YearTotalStr;
                }
            }
            set
            {
                _YearTotalStr = value;
                OnPropertyChanged("YearTotalStr");
            }
        }
        public string TotalCusYear
        {
            get
            {
                //return _TotalCusYear;
                if (_TotalCusYear == null)
                    return this._TotalCusYear;
                else
                {
                    if (_TotalCusYear != "")
                    {
                        var balance = _TotalCusYear.Replace(",", "");
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
                        return this._TotalCusYear;
                }
            }
            set
            {
                _TotalCusYear = value;
                OnPropertyChanged("TotalCusYear");
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

        public string FirstMonth
        {
            get { return _FirstMonth; }

            set
            {
                if (_FirstMonth != value)
                {
                    _FirstMonth = value;
                    OnPropertyChanged("FirstMonth");
                }
            }
        }
        public string SecondMonth
        {
            get { return _SecondMonth; }

            set
            {
                if (_SecondMonth != value)
                {
                    _SecondMonth = value;
                    OnPropertyChanged("SecondMonth");
                }
            }
        }
        public string ThirdMonth
        {
            get { return _ThirdMonth; }

            set
            {
                if (_ThirdMonth != value)
                {
                    _ThirdMonth = value;
                    OnPropertyChanged("ThirdMonth");
                }
            }
        }

        #endregion
    }
}
