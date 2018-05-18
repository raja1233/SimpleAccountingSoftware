﻿using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.ProductandServices
{
    public class StockCardListEntity : ViewModelBase
    {

        #region Private Properties
        private int? _ID;
        private int? _Cus_ID;
        private string _CustomerName;
        private string _InvoiceNo;
        private string _InvoiceDate;
        private string _InvoiceAmount;
        private decimal? _InvoiceAmountValue;
        private string _InvoiceAmountIncGST;
        private string _InvoiceAmountExcGST;
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
        private List<StockCardListEntity> _StockCardList;
        private List<StockCardListEntity> _StockCardListcmb;
        private List<StockCardListEntity> _StockCardListProductDetails;
        private List<StockCardListEntity> _StockCardListcmbDate;
        private List<StockCardListEntity> _StockCardListcmbAmount;
        private List<StockCardListEntity> _StockCardListcmbPn;
        private List<StockCardListEntity> _StockCardListcmbName;
        private List<StockCardListEntity> _StockCardListcmbTranType;
        private int _ShowAllCount;
        private string _QtyIn;
        private string _QtyOut;
        private int _ShowSelectedCount;
        private bool? _ConvertedToSI;
        private bool? _ConvertedToSO;
        private bool? _IsDeleted;
        private int _SelectedSearchPQList;
        private int _SelectedIndex;
        private bool? _ExcIncGST;
        private string _SelectedTransactionType;
        private List<ContentModel> _psCategory1;
        private List<ContentModel> _psCategory2;
        private int _Category1;
        private int _Category2;
        private string _SelectedFormName;
        private string _SelectedSearchQNo;
        private string _SelectedSearchYear;
        private string _SelectedSearchQuarter;
        private string _SelectedSearchMonth;
        private DateTime? _SelectedSearchStartDate;
        private DateTime? _SelectedSearchEndDate;
        private DateTime? _CreatedDate;
        private string _selectedcategorytype1;
        private string _selectedcategorytype2;

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
        private string _productName;
        private string _SelectedPandSCode;
        private string _SelectedPandSName;
        private string _SelectedTransactionNo;
        private string _SelectedTranDate;
        private string _ProductCode;
        private bool? _IncludingGSTTrue;
        private bool? _IncludingGSTFalse;
        private string _LastupdatedDate;
        private DateTime? _CreatedDateList;
        private DateTime? _EndDateValidation;
        private DateTime? _InvoiceDateDateTime;
        private string _SelectedName;

        //private int _selectedProductID;
        private string _CreditNoteNo;
        private string _CashDebitNo;
        private string _CreditNoteDate;
        private DateTime? _CreditNoteDateDate;
        private decimal? _CreditNoteAmount;
        private string _CashChequeNo;
        private string _CreditCashNO;
        private string _CashChequeDate;
        private DateTime? _CashChequeDateDate;
        private string _CreditCashDate;

        private decimal? _CashChequeAmount;
        private string _CreditCashAmount;
        private byte? _Status;
        private string _StatusString;
        private int _SIGridHeight;
        private int _SortInvoiceNo;
        private string _Price;
       

        /// <summary>

        private string _TransactionType;
        private string _TransactionNo;
        private DateTime? _TransactionDate;
        private string _TransactionDateStr;
        private decimal? _Amount;
        private string _AmountStr;
        private int? _CustomerID;
        private int? _ScreenNo;
        private int? _SIID;

        private string _Name;
        private string _Balance;
        private bool _NoHyperLink;

        #endregion


        #region Public Properties

        public string Balance
        {
            get
            {
                return _Balance;
            }
            set
            {
                _Balance = value;
                OnPropertyChanged("Balance");
            }
        }
       
        public bool NoHyperLink
        {
            get
            {
                return _NoHyperLink;
            }
            set
            {
                _NoHyperLink = value;
                OnPropertyChanged("NoHyperLink");
            }
        }


        public string SelectedName
        {
            get
            {
                return _SelectedName;
            }
            set
            {
                _SelectedName = value;
                OnPropertyChanged("SelectedName");
             }
        }
        public int? SIID
        {
            get
            {
                return _SIID;
            }
            set
            {
                _SIID = value;
                OnPropertyChanged("SIID");
            }
        }
        public string QtyIn
        {
            get
            {
                return _QtyIn;
            }
            set
            {
                _QtyIn = value;
                OnPropertyChanged("QtyIn");
            }
        }
        public string QtyOut
        {
            get
            {
                return _QtyOut;
            }
            set
            {
                _QtyOut = value;
                OnPropertyChanged("QtyOut");
            }
        }
        public int Category1
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
        public int Category2
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
        public  string Price
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


        public List<StockCardListEntity> StockCardListProductDetails
        {
            get { return _StockCardListProductDetails; }
            set
            {
             
                    _StockCardListProductDetails = value;
                    OnPropertyChanged("StockCardListProductDetails");
             
            }
        }
        private List<StockCardListEntity> _StockCardNameListDetails;
        public List<StockCardListEntity> StockCardNameListDetails
        {
            get { return _StockCardNameListDetails; }
            set
            {

                _StockCardNameListDetails = value;
                OnPropertyChanged("StockCardNameListDetails");

            }
        }
        //public int SelectedProductID
        //{
        //    get
        //    {
        //        return _selectedProductID;
        //    }
        //    set
        //    {
        //        _selectedProductID = value;
        //        OnPropertyChanged("SelectedProductID");
        //    }
        //}
        public int? ScreenNo
        {
            get
            {
                return _ScreenNo;
            }
            set
            {
                _ScreenNo = value;
                OnPropertyChanged("ScreenNo");
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public int? CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
                OnPropertyChanged("CustomerID");
            }
        }
        public string AmountStr
        {
            get
            {
                return _AmountStr;
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
        public string TransactionDateStr
        {
            get
            {
                return _TransactionDateStr;
            }
            set
            {
                _TransactionDateStr = value;
                OnPropertyChanged("TransactionDateStr");
            }
        }
        public DateTime? TransactionDate
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
        public string TransactionType
        {
            get
            {
                return _TransactionType;
            }
            set
            {
                _TransactionType = value;
                OnPropertyChanged("TransactionType");
            }
        }
        public int SortInvoiceNo
        {
            get
            {
                return _SortInvoiceNo;
            }
            set
            {
                _SortInvoiceNo = value;
                OnPropertyChanged("SortInvoiceNo");
            }
        }
        public int SIGridHeight
        {
            get
            {
                return _SIGridHeight;
            }
            set
            {
                _SIGridHeight = value;
                OnPropertyChanged("SIGridHeight");
            }
        }
        public string CreditCashNO
        {
            get
            {
                return _CreditCashNO;
            }
            set
            {
                _CreditCashNO = value;
                OnPropertyChanged("CreditCashNO");
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
        public string CreditCashDate
        {
            get
            {
                return _CreditCashDate;
            }
            set
            {
                _CreditCashDate = value;
                OnPropertyChanged("CreditCashDate");
            }
        }
        private string totalInvoiceAmount;
        private string totalCCDAmount;
        private decimal? totalAmount;

        public decimal? TotalAmount
        {
            get { return totalAmount; }
            set
            {
                totalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        public string TotalInvoiceAmount
        {
            get
            {
                //return _InvoiceAmount;
                if (totalInvoiceAmount == null)
                    return this.totalInvoiceAmount;
                else
                {
                    if (totalInvoiceAmount != "")
                    {
                        var balance = totalInvoiceAmount.Replace(",", "");
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
                        return this.totalInvoiceAmount;
                }
            }
            set
            {
                totalInvoiceAmount = value;
                OnPropertyChanged("TotalInvoiceAmount");
            }
        }
        public string TotalCCDAmount
        {
            get
            {
                //return _InvoiceAmount;
                if (totalCCDAmount == null)
                    return this.totalCCDAmount;
                else
                {
                    if (totalCCDAmount != "")
                    {
                        var balance = totalCCDAmount.Replace(",", "");
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
                        return this.totalCCDAmount;
                }
            }
            set
            {
                totalCCDAmount = value;
                OnPropertyChanged("TotalCCDAmount");
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
        public string CreditCashAmount
        {
            get
            {
                //return _DebitCashAmount;
                if (_CreditCashAmount == null)
                    return this._CreditCashAmount;
                else
                {
                    if (_CreditCashAmount != "")
                    {
                        var balance = _CreditCashAmount.Replace(",", "");
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
                        return this._CreditCashAmount;
                }
            }
            set
            {
                _CreditCashAmount = value;
                OnPropertyChanged("CreditCashAmount");
            }
        }
        public byte? Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
                OnPropertyChanged("Status");
            }
        }
        public string StatusString
        {
            get
            {
                return _StatusString;
            }
            set
            {
                _StatusString = value;
                OnPropertyChanged("StatusString");
            }
        }
        public decimal? CreditNoteAmount
        {
            get
            {
                return _CreditNoteAmount;
            }
            set
            {
                _CreditNoteAmount = value;
                OnPropertyChanged("CreditNoteAmount");
            }
        }
        public string CreditNoteDate
        {
            get
            {
                return _CreditNoteDate;
            }
            set
            {
                _CreditNoteDate = value;
                OnPropertyChanged("CreditNoteDate");
            }
        }
        public DateTime? CreditNoteDateDate
        {
            get
            {
                return _CreditNoteDateDate;
            }
            set
            {
                _CreditNoteDateDate = value;
                OnPropertyChanged("CreditNoteDateDate");
            }
        }
        public string CreditNoteNo
        {
            get
            {
                return _CreditNoteNo;
            }
            set
            {
                _CreditNoteNo = value;
                OnPropertyChanged("CreditNoteNo");
            }
        }
        public string CashCreditNo
        {
            get
            {
                return _CashDebitNo;
            }
            set
            {
                _CashDebitNo = value;
                OnPropertyChanged("CashCreditNo");
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
        public int? ID
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
        public string InvoiceAmountIncGST
        {
            get
            {
                return _InvoiceAmountIncGST;
            }
            set
            {
                _InvoiceAmountIncGST = value;
                OnPropertyChanged("InvoiceAmountIncGST");
            }
        }
        public string InvoiceAmountExcGST
        {
            get
            {
                return _InvoiceAmountExcGST;
            }
            set
            {
                _InvoiceAmountExcGST = value;
                OnPropertyChanged("InvoiceAmountExcGST");
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
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        //public string SelectedTransactionNo
        //{
        //    get
        //    {
        //        return _SelectedTransactionNo;
        //    }
        //    set
        //    {
        //        _SelectedTransactionNo = value;
        //        OnPropertyChanged("SelectedTransactionNo");
        //    }
        //}
        //public string SelectedTranDate
        //{
        //    get
        //    {
        //        return _SelectedTranDate;
        //    }
        //    set
        //    {
        //        _SelectedTranDate = value;
        //        OnPropertyChanged("SelectedTranDate");
        //    }
        //}
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
        //public bool? ShowAllTrue
        //{
        //    get
        //    {
        //        return _ShowAllTrue;
        //    }
        //    set
        //    {
        //        _ShowAllTrue = value;
        //        OnPropertyChanged("ShowAllTrue");
        //    }
        //}
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
        public List<StockCardListEntity> StockCardList
        {
            get { return _StockCardList; }
            set
            {
                if (_StockCardList != value)
                {
                    _StockCardList = value;
                    OnPropertyChanged("StockCardList");
                }
            }
        }
        public List<StockCardListEntity> StockCardListcmb
        {
            get { return _StockCardListcmb; }
            set
            {
                if (_StockCardListcmb != value)
                {
                    _StockCardListcmb = value;
                    OnPropertyChanged("StockCardListcmb");
                }
            }
        }
        public List<StockCardListEntity> StockCardListcmbDate
        {
            get { return _StockCardListcmbDate; }
            set
            {
                if (_StockCardListcmbDate != value)
                {
                    _StockCardListcmbDate = value;
                    OnPropertyChanged("StockCardListcmbDate");
                }
            }
        }
        public List<StockCardListEntity> StockCardListcmbAmount
        {
            get { return _StockCardListcmbAmount; }
            set
            {
                if (_StockCardListcmbAmount != value)
                {
                    _StockCardListcmbAmount = value;
                    OnPropertyChanged("StockCardListcmbAmount");
                }
            }
        }
        public List<StockCardListEntity> StockCardListcmbPn
        {
            get { return _StockCardListcmbPn; }
            set
            {
                if (_StockCardListcmbPn != value)
                {
                    _StockCardListcmbPn = value;
                    OnPropertyChanged("StockCardListcmbPn");
                }
            }
        }
        public List<StockCardListEntity> StockCardListcmbName
        {
            get { return _StockCardListcmbName; }
            set
            {
                if (_StockCardListcmbName != value)
                {
                    _StockCardListcmbName = value;
                    OnPropertyChanged("StockCardListcmbName");
                }
            }
        }
       
        public List<StockCardListEntity> StockCardListcmbTranType
        {
            get { return _StockCardListcmbTranType; }
            set
            {
                if (_StockCardListcmbTranType != value)
                {
                    _StockCardListcmbTranType = value;
                    OnPropertyChanged("StockCardListcmbTranType");
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
        public List<ContentModel> PSCategory1
        {
            get { return _psCategory1; }
            set
            {
                _psCategory1 = value;
                OnPropertyChanged("PSCategory1");
            }
        }
        public List<ContentModel> PSCategory2
        {
            get { return _psCategory2; }
            set
            {
                _psCategory2 = value;
                OnPropertyChanged("PSCategory2");
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



        public string SelectedTransactionType
        {
            get
            {
                return _SelectedTransactionType;
            }
            set
            {
                _SelectedTransactionType = value;
                OnPropertyChanged("SelectedTransactionType");
            }
        }
        //public string SelectedCategoryType1
        //{
        //    get
        //    {
        //        return _SelectedCategoryType1;
        //    }
        //    set
        //    {
        //        _SelectedCategoryType1 = value;
        //        OnPropertyChanged("SelectedCategoryType1");
        //    }
        //}
        //public string SelectedCategoryType2
        //{
        //    get
        //    {
        //        return _SelectedCategoryType2;
        //    }
        //    set
        //    {
        //        _SelectedCategoryType2 = value;
        //        OnPropertyChanged("SelectedCategoryType2");
        //    }
        //}
        public string SelectedFormName
        {
            get
            {
                return _SelectedFormName;
            }
            set
            {
                _SelectedFormName = value;
                OnPropertyChanged("SelectedFormName");
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
                    //SelectedSearchStartDate = null;
                    //SelectedSearchEndDate = null;
                    //EnableEndDropDown = false;
                    //EnableStartDropDown = false;
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
