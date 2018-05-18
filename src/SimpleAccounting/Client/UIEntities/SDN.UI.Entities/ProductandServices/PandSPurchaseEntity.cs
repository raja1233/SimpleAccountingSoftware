﻿using SDN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.ProductandServices
{
    public class PandSPurchaseEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private string _PandSCode;
        private string _PCode;
        private string _PandSName;
        private string _Category1;
        private string _Category2;
        private string _SupplierName;
        private string _QuantityStr;
        private int? _Quantity;
        private string _PriceStr;
        private decimal? _Price;
        private string _AmountStr;
        private decimal? _Amount;
        private string _SelectedStartDateStr;
        private string _SelectedEndDateStr;
        private DateTime? _SelectedStartDate;
        private DateTime? _SelectedEndDate;
        private string _SelectedSearchYear;
        private string _SelectedSearchQuarter;
        private string _SelectedSearchMonth;
        private List<PandSPurchaseEntity> _PandSPurchaseList;
        private List<PandSPurchaseEntity> _PandSPurchaseListCode;
        private List<PandSPurchaseEntity> _PandSPurchaseListName;
        private List<PandSPurchaseEntity> _PandSPurchaseListCus;
        private ObservableCollection<PandSPurchaseEntity> _PandSPurchaseListCat1;
        private ObservableCollection<PandSPurchaseEntity> _PandSPurchaseListCat2;
        private int? _ShowSelectedCount;
        private int? _ShowAllCount;
        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;
        private bool? _ShowProducts;
        private bool? _ShowServices;
        private bool? _ShowBoth;
        private bool? _YearmonthQuartTrue;
        private bool? _StartEndDateTrue;
        private bool? _EnableEndDropDown;
        private string _JsonData;
        private string _currencyName;
        private string _currencyCode;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _TaxName;
        private string _DateFormat;
        private bool? _IncludingGSTTrue;
        private bool? _IncludingGSTFalse;
        private int? _PandS;
        private bool? _EnableStartDropDown;
        private bool? _EnableYearDropDown;
        private bool? _EnableQuarterDropDown;
        private bool? _EnableMonthDropDown;
        private DateTime? _SelectedSearchStartDate;
        private DateTime? _SelectedSearchEndDate;
        private List<YearEntity> _YearRange;
        private DateTime? _EndDateValidation;
        private int? _PandSPurchaseGridHeight;
        private string _InvoiceDate;
        private string _InvoiceNo;
        private int? _ProductCount;
        private int? _ServiceCount;
        private int? _ShowBothCount;
        private string _DisplayPandSCode;
        private int? _Qty;
        private string _SelectedPandSCode;
        private string _SelectedPandSName;
        private string _SelectedSupplierName;
        private string _SelectedCategory2;
        private string _SelectedCategory1;
        private string _TotalAmount;
        private string _TotalPrice;
        private string _TotalQuantity;
        private string _AllCount;
        private bool? _IsSummary;
        private bool? _IsSummaryTrue;
        private bool? _IsSummaryFalse;
        private string _QtyStr;
        #endregion

        #region Public Properties
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
        public string PandSCode
        {
            get
            {
                return _PandSCode;
            }
            set
            {
                _PandSCode = value;
                OnPropertyChanged("PandSCode");
            }
        }
        public string PCode
        {
            get
            {
                return _PCode;
            }
            set
            {
                _PCode = value;
                OnPropertyChanged("PCode");
            }
        }
        public string PandSName
        {
            get
            {
                return _PandSName;
            }
            set
            {
                _PandSName = value;
                OnPropertyChanged("PandSName");
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
        public string QuantityStr
        {
            get
            {
                return _QuantityStr;
            }
            set
            {
                _QuantityStr = value;
                OnPropertyChanged("QuantityStr");
            }
        }
        public int? Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        public string PriceStr
        {
            get
            {
               // return _PriceStr;
                if (_PriceStr == null)
                    return this._PriceStr;
                else
                {
                    if (_PriceStr != "")
                    {
                        var balance = _PriceStr.Replace(",", "");
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
                        return this._PriceStr;
                }
            }
            set
            {
                _PriceStr = value;
                OnPropertyChanged("PriceStr");
            }
        }
        public decimal? Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
                OnPropertyChanged("Price");
            }
        }
        public string AmountStr
        {
            get
            {
                //return _AmountStr;
                 if (_AmountStr == null)
                    return this._AmountStr;
                else
                {
                    if (_AmountStr != "")
                    {
                        var balance = _AmountStr.Replace(",", "");
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
                        return this._AmountStr;
                }
            }
            set
            {
                _AmountStr = value;
                OnPropertyChanged("AmountStr");
            }
        }
        public decimal? Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
                OnPropertyChanged("Amount");
            }
        }
        public string SelectedStartDateStr
        {
            get
            {
                return _SelectedStartDateStr;
            }
            set
            {
                _SelectedStartDateStr = value;
                OnPropertyChanged("SelectedStartDateStr");
            }
        }
        public string SelectedEndtDateStr
        {
            get
            {
                return _SelectedEndDateStr;
            }
            set
            {
                _SelectedEndDateStr = value;
                OnPropertyChanged("SelectedEndDateStr");
            }
        }
        public DateTime? SelectedStartDate
        {
            get
            {
                return _SelectedStartDate;
            }
            set
            {
                _SelectedStartDate = value;
                OnPropertyChanged("SelectedStartDate");
            }
        }
        public DateTime? SelectedEndtDate
        {
            get
            {
                return _SelectedEndDate;
            }
            set
            {
                _SelectedEndDate = value;
                OnPropertyChanged("SelectedEndDate");
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
                OnPropertyChanged("SelectedSearchMonth");
            }
        }
        public List<PandSPurchaseEntity> PandSPurchaseList
        {
            get
            {
                return _PandSPurchaseList;
            }
            set
            {
                _PandSPurchaseList = value;
                OnPropertyChanged("PandSPurchaseList");
            }
        }
        public List<PandSPurchaseEntity> PandSPurchaseListCode
        {
            get
            {
                return _PandSPurchaseListCode;
            }
            set
            {
                _PandSPurchaseListCode = value;
                OnPropertyChanged("PandSPurchaseListCode");
            }
        }
        public List<PandSPurchaseEntity> PandSPurchaseListName
        {
            get
            {
                return _PandSPurchaseListName;
            }
            set
            {
                _PandSPurchaseListName = value;
                OnPropertyChanged("PandSPurchaseListName");
            }
        }
        public List<PandSPurchaseEntity> PandSPurchaseListCus
        {
            get
            {
                return _PandSPurchaseListCus;
            }
            set
            {
                _PandSPurchaseListCus = value;
                OnPropertyChanged("PandSPurchaseListCus");
            }
        }
        public ObservableCollection<PandSPurchaseEntity> PandSPurchaseListCat1
        {
            get
            {
                return _PandSPurchaseListCat1;
            }
            set
            {
                _PandSPurchaseListCat1 = value;
                OnPropertyChanged("PandSPurchaseListCat1");
            }
        }
        public ObservableCollection<PandSPurchaseEntity> PandSPurchaseListCat2
        {
            get
            {
                return _PandSPurchaseListCat2;
            }
            set
            {
                _PandSPurchaseListCat2 = value;
                OnPropertyChanged("PandSPurchaseListCat2");
            }
        }
        public int? ShowSelectedCount
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
        public int? ShowAllCount
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

        public bool? IsSummary
        {
            get
            {
                return _IsSummary;
            }
            set
            {
                _IsSummary = value;
                OnPropertyChanged("IsSummary");
            }
        }
        public bool? IsSummaryTrue
        {
            get
            {
                return _IsSummaryTrue;
            }
            set
            {
                _IsSummaryTrue = value;
                OnPropertyChanged("IsSummaryTrue");
            }
        }
        public bool? IsSummaryFalse
        {
            get
            {
                return _IsSummaryFalse;
            }
            set
            {
                _IsSummaryFalse = value;
                OnPropertyChanged("IsSummaryFalse");
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
        public bool? YearmonthQuartTrue
        {
            get
            {
                return _YearmonthQuartTrue;
            }
            set
            {
                _YearmonthQuartTrue = value;
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
                OnPropertyChanged("StartEndDateTrue");
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
        public string TaxName
        {
            get { return _TaxName; }

            set
            {
                if (_TaxName != value)
                {
                    _TaxName = value;
                    OnPropertyChanged("TaxName");
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
            get { return _DateFormat; }
            set { SetProperty(ref _DateFormat, value, "DateFormat"); }
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
        public int? PandS
        {
            get
            {
                return _PandS;
            }
            set
            {
                _PandS = value;
                OnPropertyChanged("PandS");
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
        public int? PandSPurchaseGridHeight
        {
            get
            {
                return _PandSPurchaseGridHeight;
            }
            set
            {
                _PandSPurchaseGridHeight = value;
                OnPropertyChanged("PandSPurchaseGridHeight");
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
        public int? ProductCount
        {
            get
            {
                return _ProductCount;
            }
            set
            {
                _ProductCount = value;
                OnPropertyChanged("ProductCount");
            }
        }
        public int? ServiceCount
        {
            get
            {
                return _ServiceCount;
            }
            set
            {
                _ServiceCount = value;
                OnPropertyChanged("ServiceCount");
            }
        }
        public int? ShowBothCount
        {
            get
            {
                return _ShowBothCount;
            }
            set
            {
                _ShowBothCount = value;
                OnPropertyChanged("ShowBothCount");
            }
        }
        public string DisplayPandSCode
        {
            get
            {
                return _DisplayPandSCode;
            }
            set
            {
                _DisplayPandSCode = value;
                OnPropertyChanged("DisplayPandSCode");
            }
        }
        public int? Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                _Qty = value;
                OnPropertyChanged("Qty");
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
        public string SelectedSupplierName
        {
            get
            {
                return _SelectedSupplierName;
            }
            set
            {
                _SelectedSupplierName = value;
                OnPropertyChanged("SelectedSupplierName");
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
        public string TotalQuantity
        {
            get
            {
                // return _TotalQuantity;
                if (_TotalQuantity == null)
                    return this._TotalQuantity;
                else
                {
                    if (_TotalQuantity != "")
                    {
                        var balance = _TotalQuantity.Replace(",", "");

                        return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));

                    }
                    else
                        return this._TotalQuantity;
                }
            }
            set
            {
                _TotalQuantity = value;
                OnPropertyChanged("TotalQuantity");
            }
        }
        public string TotalPrice
        {
            get
            {
                // return _TotalPrice;
                if (_TotalPrice == null)
                    return this._TotalPrice;
                else
                {
                    if (_TotalPrice != "")
                    {
                        var balance = _TotalPrice.Replace(",", "");
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
                        return this._TotalPrice;
                }
            }
            set
            {
                _TotalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }
        public string TotalAmount
        {
            get
            {
                // return _TotalAmount;
                if (_TotalAmount == null)
                    return this._TotalAmount;
                else
                {
                    if (_TotalAmount != "")
                    {
                        var balance = _TotalAmount.Replace(",", "");
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
                        return this._TotalAmount;
                }
            }
            set
            {
                _TotalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }
        public string AllCount
        {
            get
            {
                // return _AllCount;
                if (_AllCount == null)
                    return this._AllCount;
                else
                {
                    if (_AllCount != "")
                    {
                        var balance = _AllCount.Replace(",", "");
                    
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                    
                    }
                    else
                        return this._AllCount;
                }
            }
            set
            {
                _AllCount = value;
                OnPropertyChanged("AllCount");
            }
        }
        public string QtyStr
        {
            get
            {
                //return _QtyStr;
                if (_QtyStr == null)
                    return this._QtyStr;
                else
                {
                    if (_QtyStr != "")
                    {
                        var balance = _QtyStr.Replace(",", "");
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
                        return this._QtyStr;
                }
            }
            set
            {
                _QtyStr = value;
                OnPropertyChanged("QtyStr");
            }
        }
        #endregion
    }
}