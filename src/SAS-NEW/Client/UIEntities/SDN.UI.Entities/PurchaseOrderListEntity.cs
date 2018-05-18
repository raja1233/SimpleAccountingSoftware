using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class PurchaseOrderListEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private int _Sup_ID;
        private string _SupplierName;
        private string _OrderNo;
        private string _OrderDate;
        private string _OrderAmount;
        private string depositAmount;
        private string _OrderAmountIncGST;
        private string _OrderAmountExcGST;
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
        private string _Search;
        private List<PurchaseOrderListEntity> _PurchaseOrderList;
        private List<PurchaseOrderListEntity> _PurchaseOrderListcmb;
        private List<PurchaseOrderListEntity> _PurchaseOrderListcmbSup;
        private List<PurchaseOrderListEntity> _PurchaseOrderListcmbONo;
        
        private int _ShowAllCount;
        private int _ShowSelectedCount;
        private bool? _ConvertedToPI;
        private bool? _ConvertedToPO;
        private bool? _IsDeleted;
        private int _SelectedSearchPQList;
        private int _SelectedIndex;
        private bool? _ExcIncGST;
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
        private DateTime? _OrderDateDateTime;
        private DateTime? _DeliveryDateDateTime;
        private string _DeliveryDateTime;
        private int _POGridHeight;
        private string _AmountDeposited;
        private string _DepositTotal;
        private int _SortOrderNo;
        #endregion


        #region Public Properties

        public int SortOrderNo
        {
            get
            {
                return _SortOrderNo;
            }
            set
            {
                _SortOrderNo = value;
                OnPropertyChanged("SortOrderNo");
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
        public string AmountDeposited
        {
            get
            {
                //return _AmountDeposited;
                if (_AmountDeposited == null)
                    return this._AmountDeposited;
                else
                {
                    if (_AmountDeposited != "")
                    {
                        var balance = _AmountDeposited.Replace(",", "");
                        
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
                        return this._AmountDeposited;
                }


            }
            set
            {
                _AmountDeposited = value;
                OnPropertyChanged("AmountDeposited");
            }
        }

        public string DepositTotal
        {
            get
            {
                //return _DepositTotal;
                if (_DepositTotal == null)
                    return this._DepositTotal;
                else
                {
                    if (_DepositTotal != "")
                    {
                        var balance = _DepositTotal.Replace(",", "");
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
                        return this._DepositTotal;
                }

            }
            set
            {
                _DepositTotal = value;
                OnPropertyChanged("DepositTotal");
            }
        }

        public int POGridHeight
        {
            get
            {
                return _POGridHeight;
            }
            set
            {
                _POGridHeight = value;
                OnPropertyChanged("POGridHeight");
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
        public DateTime? OrderDateDateTime
        {
            get
            {
                return _OrderDateDateTime;
            }
            set
            {
                _OrderDateDateTime = value;
                OnPropertyChanged("OrderDateDateTime");
            }
        }
        public DateTime? DeliveryDateDateTime
        {
            get
            {
                return _DeliveryDateDateTime;
            }
            set
            {
                _DeliveryDateDateTime = value;
                OnPropertyChanged("DeliveryDateDateTime");
            }
        }
        public string DeliveryDateTime
        {
            get
            {
                return _DeliveryDateTime;
            }
            set
            {
                _DeliveryDateTime = value;
                OnPropertyChanged("DeliveryDateTime");
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

        public  string DepositAmount
        {
            get
            {
                //return _OrderAmount;
                if (depositAmount == null)
                    return this.depositAmount;
                else
                {
                    if (depositAmount != "")
                    {
                        var balance = depositAmount.Replace(",", "");
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
                        return this.depositAmount;
                }
            }
            set
            {
                depositAmount = value;
                OnPropertyChanged("DepositAmount");
            }
        }

        private decimal? dAmount;
        public decimal? DAmount
        {
            get { return dAmount; }
            set
            {
                dAmount = value;
                OnPropertyChanged("DAmount");
            }
        }

        private decimal? oAmount;
        public decimal? OAmount
        {
            get { return oAmount; }
            set { oAmount = value;
                OnPropertyChanged("OAmount");
            }
        }
        
        private string totalAmount;
        private string _ConvertedToNo;

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

        //private string _depositTotal;
        //public string DepositTotal
        //{
        //    get
        //    {
        //        return this._depositTotal;
        //    }
        //    set
        //    {
        //        _depositTotal = value;
        //        OnPropertyChanged("DepositTotal");
        //    }

        //}
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
        public int Sup_ID
        {
            get
            {
                return _Sup_ID;
            }
            set
            {
                _Sup_ID = value;
                OnPropertyChanged("Sup_ID");
            }
        }
        public string SupplierName
        {
            get
            {
                return _SupplierName;
            }
            set
            {
                _SupplierName = value;
                OnPropertyChanged("SupplierName");
            }
        }
        public string OrderNo
        {
            get
            {
                return _OrderNo;
            }
            set
            {
                _OrderNo = value;
                OnPropertyChanged("OrderNo");
            }
        }
        public string OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
                OnPropertyChanged("OrderDate");
            }
        }
        public string OrderAmount
        {
            get
            {
                //return _OrderAmount;
                  if (_OrderAmount == null)
                    return this._OrderAmount;
                else
                {
                    if (_OrderAmount != "")
                    {
                        var balance = _OrderAmount.Replace(",", "");
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
                        return this._OrderAmount;
                }
            }
            set
            {
                _OrderAmount = value;
                OnPropertyChanged("OrderAmount");
            }
        }
        public string OrderAmountIncGST
        {
            get
            {
                return _OrderAmountIncGST;
            }
            set
            {
                _OrderAmountIncGST = value;
                OnPropertyChanged("OrderAmountIncGST");
            }
        }
        public string OrderAmountExcGST
        {
            get
            {
                return _OrderAmountExcGST;
            }
            set
            {
                _OrderAmountExcGST = value;
                OnPropertyChanged("OrderAmountExcGST");
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
        public List<PurchaseOrderListEntity> PurchaseOrderList
        {
            get { return _PurchaseOrderList; }
            set
            {
                if (_PurchaseOrderList != value)
                {
                    _PurchaseOrderList = value;
                    OnPropertyChanged("PurchaseOrderList");
                }
            }
        }
        public List<PurchaseOrderListEntity> PurchaseOrderListcmb
        {
            get { return _PurchaseOrderListcmb; }
            set
            {
                if (_PurchaseOrderListcmb != value)
                {
                    _PurchaseOrderListcmb = value;
                    OnPropertyChanged("PurchaseOrderListcmb");
                }
            }
        }
        public List<PurchaseOrderListEntity> PurchaseOrderListcmbSup
        {
            get { return _PurchaseOrderListcmbSup; }
            set
            {
                if (_PurchaseOrderListcmbSup != value)
                {
                    _PurchaseOrderListcmbSup = value;
                    OnPropertyChanged("PurchaseOrderListcmbSup");
                }
            }
        }
        public List<PurchaseOrderListEntity> PurchaseOrderListcmbONo
        {
            get { return _PurchaseOrderListcmbONo; }
            set
            {
                if (_PurchaseOrderListcmbONo != value)
                {
                    _PurchaseOrderListcmbONo = value;
                    OnPropertyChanged("PurchaseOrderListcmbONo");
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
        public bool? ConvertedToPI
        {
            get
            {
                return _ConvertedToPI;
            }
            set
            {
                _ConvertedToPI = value;
                OnPropertyChanged("ConvertedToPI");
            }
        }
        public bool? ConvertedToPO
        {
            get
            {
                return _ConvertedToPO;
            }
            set
            {
                _ConvertedToPO = value;
                OnPropertyChanged("ConvertedToPO");
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


        #endregion
    }
}
