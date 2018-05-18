
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Sales
{
    using SDN.Common;
    using System.Globalization;

    public class CreditNoteListEntity: ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private int? _Cus_ID;
        private string _CustomerName;
        private string _CreditNo;
        private string _CreditDateStr;
        private decimal? _CreditAmount;
        private string _CreditAmountStr;
        private decimal? _CreditAmountValue;
        private string _CreditAmountIncGST;
        private string _CreditAmountExcGST;
        private string _ConvertedTo;
        private DateTime? _InvoiceDateDateTime;
        private decimal? _SalesAmount;
        private string _SalesInvoiceNo;
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
        private List<CreditNoteListEntity> _CreditNoteList;
        private List<CreditNoteListEntity> _CreditNoteListcmb;
        private List<CreditNoteListEntity> _CreditNoteListcmbInv;
        private List<CreditNoteListEntity> _CreditNoteListcmbCus;
        private List<CreditNoteListEntity> _CreditNoteListcmbCredit;
        private int _ShowAllCount;
        private int _ShowSelectedCount;
        private bool? _ConvertedToSI;
        private bool? _ConvertedToSO;
        private bool? _IsDeleted;
        private int _SelectedSearchPQList;
        private int _SelectedIndex;
        private bool? _ExcIncGST;
        private string _SelectedSearchCusName;
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
        private string _SelectedSearchPI_Status;
        private string _SelectedCreditNoteNo;
        private bool? _IncludingGSTTrue;
        private bool? _IncludingGSTFalse;
        private string _LastupdatedDate;
        private DateTime? _CreatedDateList;
        private DateTime? _EndDateValidation;
        private DateTime? _CreditDate;


        private string _CreditNoteNo;
        private string _CashCreditNo;
        private DateTime? _CreditNoteDate;
        private string _CreditNoteDateStr;
        private DateTime? _CreditNoteDateDate;
        private decimal? _CreditNoteAmount;
        private string _CreditNoteAmountStr;
        private string _CashChequeNo;
        private string _CreditCashNO;
        private string _CashChequeDate;
        private DateTime? _CashChequeDateDate;
        private string _CreditCashDate;

        private decimal? _CashChequeAmount;
        private string _CreditCashAmount;
        private byte? _Status;
        private string _StatusString;
        private int _CNGridHeight;
        private int _SortCreditNoteNo;
        private string _InvoiceNoCashChequeNo;
        private DateTime? _InvoiceCashChequeDate;
        private string _InvoiceCashChequeDateStr;
        private decimal? _InvoiceCashChequeAmount;
        private string _InvoiceCashChequeAmountStr;
        #endregion


        #region Public Properties
        public string InvoiceNoCashChequeNo
        {
            get
            {
                return _InvoiceNoCashChequeNo;
            }
            set
            {
                _InvoiceNoCashChequeNo = value;
                OnPropertyChanged("InvoiceNoCashChequeNo");
            }
        }
        public DateTime? InvoiceCashChequeDate
        {
            get
            {
                return _InvoiceCashChequeDate;
            }
            set
            {
                _InvoiceCashChequeDate = value;
                OnPropertyChanged("_InvoiceCashChequeDate");
            }
        }
        public string InvoiceCashChequeDateStr
        {
            get
            {
                return _InvoiceCashChequeDateStr;
            }
            set
            {
                _InvoiceCashChequeDateStr = value;
                OnPropertyChanged("InvoiceCashChequeDateStr");
            }
        }
        public decimal? InvoiceCashChequeAmount
        {
            get
            {
                return _InvoiceCashChequeAmount;
            }
            set
            {
                _InvoiceCashChequeAmount = value;
                OnPropertyChanged("InvoiceCashChequeAmount");
            }
        }
        public string InvoiceCashChequeAmountStr
        {
            get
            {
                return _InvoiceCashChequeAmountStr;
            }
            set
            {
                _InvoiceCashChequeAmountStr = value;
                OnPropertyChanged("InvoiceCashChequeAmountStr");
            }
        }
        public int SortCreditNoteNo
        {
            get
            {
                return _SortCreditNoteNo;
            }
            set
            {
                _SortCreditNoteNo = value;
                OnPropertyChanged("SortCreditNoteNo");
            }
        }

        public int CNGridHeight
        {
            get
            {
                return _CNGridHeight;
            }
            set
            {
                _CNGridHeight = value;
                OnPropertyChanged("CNGridHeight");
            }
        }
        public string SalesInvoiceNo
        {
            get
            {
                return _SalesInvoiceNo;
            }
            set
            {
                _SalesInvoiceNo = value;
                OnPropertyChanged("SalesInvoiceNo");
            }
        }
        public decimal? SalesAmount
        {
            get
            {
                return _SalesAmount;
            }
            set
            {
                _SalesAmount = value;
                OnPropertyChanged("SalesAmount");
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
                //return _CreditCashAmount;
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
        public string CreditNoteAmountStr
        {
            get
            {
                return _CreditNoteAmountStr;
            }
            set
            {
                _CreditNoteAmountStr = value;
                OnPropertyChanged("CreditNoteAmountStr");
            }
        }
        public DateTime? CreditNoteDate
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
        public string CreditNoteDateStr
        {
            get
            {
                return _CreditNoteDateStr;
            }
            set
            {
                _CreditNoteDateStr = value;
                OnPropertyChanged("CreditNoteDateStr");
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
                return _CashCreditNo;
            }
            set
            {
                _CashCreditNo = value;
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
        public DateTime? CreditDate
        {
            get
            {
                return _CreditDate;
            }
            set
            {
                _CreditDate = value;
                OnPropertyChanged("_CreditDate");
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
        public string CreditNo
        {
            get
            {
                return _CreditNo;
            }
            set
            {
                _CreditNo = value;
                OnPropertyChanged("CreditNo");
            }
        }
        public string CreditDateStr
        {
            get
            {
                return _CreditDateStr;
            }
            set
            {
                _CreditDateStr = value;
                OnPropertyChanged("CreditDateStr");
            }
        }

        private string totalCreditAmount;
        private string totalInvoiceCashChequeAmount;

        public string TotalInvoiceCashChequeAmount
        {
            get
            {
                //return _CreditAmount;
                if (totalInvoiceCashChequeAmount == null)
                    return this.totalInvoiceCashChequeAmount;
                else
                {
                    if (totalInvoiceCashChequeAmount != "")
                    {
                        var balance = totalInvoiceCashChequeAmount.Replace(",", "");
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
                        return this.totalInvoiceCashChequeAmount;
                }
            }
            set
            {
                totalInvoiceCashChequeAmount = value;
                OnPropertyChanged("TotalInvoiceCashChequeAmount");
            }
        }

        public string TotalCreditAmount
        {
            get
            {
                //return _CreditAmount;
                if (totalCreditAmount == null)
                    return this.totalCreditAmount;
                else
                {
                    if (totalCreditAmount != "")
                    {
                        var balance = totalCreditAmount.Replace(",", "");
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
                        return this.totalCreditAmount;
                }
            }
            set
            {
                totalCreditAmount = value;
                OnPropertyChanged("TotalCreditAmount");
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
        public string CreditAmountStr
        {
            get
            {
                return _CreditAmountStr;
            }
            set
            {
                _CreditAmountStr = value;
                OnPropertyChanged("CreditAmountStr");
            }
        }
        public decimal? CreditAmountValue
        {
            get
            {
                return _CreditAmountValue;
            }
            set
            {
                _CreditAmountValue = value;
                OnPropertyChanged("CreditAmountValue");
            }
        }
        public string CreditAmountIncGST
        {
            get
            {
                return _CreditAmountIncGST;
            }
            set
            {
                _CreditAmountIncGST = value;
                OnPropertyChanged("CreditAmountIncGST");
            }
        }
        public string CreditAmountExcGST
        {
            get
            {
                return _CreditAmountExcGST;
            }
            set
            {
                _CreditAmountExcGST = value;
                OnPropertyChanged("CreditAmountExcGST");
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
        public string SelectedSearchPI_Status
        {
            get
            {
                return _SelectedSearchPI_Status;
            }
            set
            {
                _SelectedSearchPI_Status = value;
                OnPropertyChanged("SelectedSearchPI_Status");
            }
        }
        public string SelectedCreditNoteNo
        {
            get
            {
                return _SelectedCreditNoteNo;
            }
            set
            {
                _SelectedCreditNoteNo = value;
                OnPropertyChanged("SelectedCreditNoteNo");
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
        public List<CreditNoteListEntity> CreditNoteList
        {
            get { return _CreditNoteList; }
            set
            {
                if (_CreditNoteList != value)
                {
                    _CreditNoteList = value;
                    OnPropertyChanged("CreditNoteList");
                }
            }
        }
        public List<CreditNoteListEntity> CreditNoteListcmb
        {
            get { return _CreditNoteListcmb; }
            set
            {
                if (_CreditNoteListcmb != value)
                {
                    _CreditNoteListcmb = value;
                    OnPropertyChanged("CreditNoteListcmb");
                }
            }
        }
        public List<CreditNoteListEntity> CreditNoteListcmbInv
        {
            get { return _CreditNoteListcmbInv; }
            set
            {
                if (_CreditNoteListcmbInv != value)
                {
                    _CreditNoteListcmbInv = value;
                    OnPropertyChanged("CreditNoteListcmbInv");
                }
            }
        }
        public List<CreditNoteListEntity> CreditNoteListcmbCus
        {
            get { return _CreditNoteListcmbCus; }
            set
            {
                if (_CreditNoteListcmbCus != value) 
                {
                    _CreditNoteListcmbCus = value;
                    OnPropertyChanged("CreditNoteListcmbCus");
                }
            }
        }
        public List<CreditNoteListEntity> CreditNoteListcmbCredit
        {
            get { return _CreditNoteListcmbCredit; }
            set
            {
                if (_CreditNoteListcmbCredit != value)
                {
                    _CreditNoteListcmbCredit = value;
                    OnPropertyChanged("CreditNoteListcmbCredit");
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


        public string SelectedSearchCusName
        {
            get
            {
                return _SelectedSearchCusName;
            }
            set
            {
                _SelectedSearchCusName = value;
                OnPropertyChanged("SelectedSearchCusName");
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
