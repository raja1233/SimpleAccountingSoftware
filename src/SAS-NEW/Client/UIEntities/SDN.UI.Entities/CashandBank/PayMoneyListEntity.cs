﻿using SDN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.CashandBank
{
    public class PayMoneyListEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private string _AmountStr;
        private decimal? _Amount;
        private string _SelectedStartDateStr;
        private string _SelectedEndDateStr;
        private DateTime? _SelectedStartDate;
        private DateTime? _SelectedEndDate;
        private string _SelectedSearchYear;
        private string _SelectedSearchQuarter;
        private string _SelectedSearchMonth;
        private List<PayMoneyListEntity> _PayMoneyList;
        private List<PayMoneyListEntity> _PayMoneyListCode;
        private List<PayMoneyListEntity> _PayMoneyListName;
        private List<PayMoneyListEntity> _PayMoneyListCash;
        private ObservableCollection<PayMoneyListEntity> _PayMoneyListCat1;
        private ObservableCollection<PayMoneyListEntity> _PayMoneyListCat2;
        private int? _ShowSelectedCount;
        private int? _ShowAllCount;
        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;

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
        private int? _PayMoneyListGridHeight;
        private string _InvoiceDate;
        private string _InvoiceNo;
        private int? _ProductCount;
        private int? _ServiceCount;
        private int? _ShowBothCount;
        private string _DisplayPandSCode;
        private int? _Qty;
        private string _QtyStr;
        private string _TotalQuantity;
        private string _TotalAmount;
        private string _TotalPrice;
        private string _AllCount;
        private int? _LinkedAccountID;
        private int? _CashBankAccountID;
        private string _CashBankAccountName;
        private string _CashChequeNo;
        private string _CashChequeDateStr;
        private DateTime? _CashChequeDate;
        private string _AccountName;
        private string _Remarks;
        private string _SelectedCashChequeNo;
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
        public List<PayMoneyListEntity> PayMoneyList
        {
            get
            {
                return _PayMoneyList;
            }
            set
            {
                _PayMoneyList = value;
                OnPropertyChanged("PayMoneyList");
            }
        }
        public List<PayMoneyListEntity> PayMoneyListCode
        {
            get
            {
                return _PayMoneyListCode;
            }
            set
            {
                _PayMoneyListCode = value;
                OnPropertyChanged("PayMoneyListCode");
            }
        }
        public List<PayMoneyListEntity> PayMoneyListName
        {
            get
            {
                return _PayMoneyListName;
            }
            set
            {
                _PayMoneyListName = value;
                OnPropertyChanged("PayMoneyListName");
            }
        }
        public List<PayMoneyListEntity> PayMoneyListCash
        {
            get
            {
                return _PayMoneyListCash;
            }
            set
            {
                _PayMoneyListCash = value;
                OnPropertyChanged("PayMoneyListCash");
            }
        }
        public ObservableCollection<PayMoneyListEntity> PayMoneyListCat1
        {
            get
            {
                return _PayMoneyListCat1;
            }
            set
            {
                _PayMoneyListCat1 = value;
                OnPropertyChanged("PayMoneyListCat1");
            }
        }
        public ObservableCollection<PayMoneyListEntity> PayMoneyListCat2
        {
            get
            {
                return _PayMoneyListCat2;
            }
            set
            {
                _PayMoneyListCat2 = value;
                OnPropertyChanged("PayMoneyListCat2");
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
        public int? PayMoneyListGridHeight
        {
            get
            {
                return _PayMoneyListGridHeight;
            }
            set
            {
                _PayMoneyListGridHeight = value;
                OnPropertyChanged("PayMoneyListGridHeight");
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
                // return _TotalAmount;
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
        public int? LinkedAccountID
        {
            get
            {
                return _LinkedAccountID;
            }
            set
            {
                _LinkedAccountID = value;
                OnPropertyChanged("LinkedAccountID");
            }
        }
        public int? CashBankAccountID
        {
            get
            {
                return _CashBankAccountID;
            }
            set
            {
                _CashBankAccountID = value;
                OnPropertyChanged("CashBankAccountID");
            }
        }
        public string CashBankAccountName
        {
            get
            {
                return _CashBankAccountName;
            }
            set
            {

                if (_CashBankAccountName != value)
                {
                    _CashBankAccountName = value;
                    OnPropertyChanged("CashBankAccountName");
                }
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

                if (_CashChequeNo != value)
                {
                    _CashChequeNo = value;
                    OnPropertyChanged("CashChequeNo");
                }
            }
        }
        public string CashChequeDateStr
        {
            get
            {
                return _CashChequeDateStr;
            }
            set
            {

                if (_CashChequeDateStr != value)
                {
                    _CashChequeDateStr = value;
                    OnPropertyChanged("CashChequeDateStr");
                }
            }
        }
        public DateTime? CashChequeDate
        {
            get
            {
                return _CashChequeDate;
            }
            set
            {

                if (_CashChequeDate != value)
                {
                    _CashChequeDate = value;
                    OnPropertyChanged("CashChequeDate");
                }
            }
        }
        public string AccountName
        {
            get
            {
                return _AccountName;
            }
            set
            {

                if (_AccountName != value)
                {
                    _AccountName = value;
                    OnPropertyChanged("AccountName");
                }
            }
        }
        public string Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {

                if (_Remarks != value)
                {
                    _Remarks = value;
                    OnPropertyChanged("Remarks");
                }
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

                if (_SelectedCashChequeNo != value)
                {
                    _SelectedCashChequeNo = value;
                    OnPropertyChanged("SelectedCashChequeNo");
                }
            }
        }
        #endregion
    }
}
