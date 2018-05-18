using SDN.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class PurchaseInvoiceListEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private int? _Sup_ID;
        private string _SupplierName;
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
        private List<PurchaseInvoiceListEntity> _PurchaseInvoiceList;
        private List<PurchaseInvoiceListEntity> _PurchaseInvoiceListcmb;
        private List<PurchaseInvoiceListEntity> _PurchaseInvoiceListcmbInv;
        private List<PurchaseInvoiceListEntity> _PurchaseInvoiceListcmbSup;
        private List<PurchaseInvoiceListEntity> _PurchaseInvoiceListcmbDebit;
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
        private string _SelectedSearchPI_Status;
        private string _SelectedDebitNoteNo;
        private bool? _IncludingGSTTrue;
        private bool? _IncludingGSTFalse;
        private string _LastupdatedDate;
        private DateTime? _CreatedDateList;
        private DateTime? _EndDateValidation;
        private DateTime? _InvoiceDateDateTime;


        private string _DebitNoteNo;
        private string _CashDebitNo;
        private string _DebitNoteDate;
        private DateTime? _DebitNoteDateDate;
        private decimal? _DebitNoteAmount;
        private string _CashChequeNo;
        private string _DebitCashNO;
        private string _CashChequeDate;
        private DateTime? _CashChequeDateDate;
        private string _DebitCashDate;
       
        private decimal? _CashChequeAmount;
        private string _DebitCashAmount;
        private byte? _Status;
        private string _StatusString;
        private int _PIGridHeight;
        private int _SortInvoiceNo;
        #endregion


        #region Public Properties
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

        public int PIGridHeight
        {
            get
            {
                return _PIGridHeight;
            }
            set
            {
                _PIGridHeight = value;
                OnPropertyChanged("PIGridHeight");
            }
        }
        
        public string DebitCashNO
        {
            get
            {
                return _DebitCashNO;
            }
            set
            {
                _DebitCashNO = value;
                OnPropertyChanged("DebitCashNO");
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
        public string DebitCashDate
        {
            get
            {
                return _DebitCashDate;
            }
            set
            {
                _DebitCashDate = value;
                OnPropertyChanged("DebitCashDate");
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
        public string DebitCashAmount
        {
            get
            {
                //return _DebitCashAmount;
                  if (_DebitCashAmount == null)
                    return this._DebitCashAmount;
                else
                {
                    if (_DebitCashAmount != "")
                    {
                        var balance = _DebitCashAmount.Replace(",", "");
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
                        return this._DebitCashAmount;
                }
            }
            set
            {
                _DebitCashAmount = value;
                OnPropertyChanged("DebitCashAmount");
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
        public decimal? DebitNoteAmount
        {
            get
            {
                return _DebitNoteAmount;
            }
            set
            {
                _DebitNoteAmount = value;
                OnPropertyChanged("DebitNoteAmount");
            }
        }
        public string DebitNoteDate
        {
            get
            {
                return _DebitNoteDate;
            }
            set
            {
                _DebitNoteDate = value;
                OnPropertyChanged("DebitNoteDate");
            }
        }
        public DateTime? DebitNoteDateDate
        {
            get
            {
                return _DebitNoteDateDate;
            }
            set
            {
                _DebitNoteDateDate = value;
                OnPropertyChanged("DebitNoteDateDate");
            }
        }
        public string DebitNoteNo
        {
            get
            {
                return _DebitNoteNo;
            }
            set
            {
                _DebitNoteNo = value;
                OnPropertyChanged("DebitNoteNo");
            }
        }
        public string CashDebitNo
        {
            get
            {
                return _CashDebitNo;
            }
            set
            {
                _CashDebitNo = value;
                OnPropertyChanged("CashDebitNo");
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
        public int? Sup_ID
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

        private decimal? iAmount;
        public decimal? IAmount
        {
            get { return iAmount; }
            set { iAmount = value;
                OnPropertyChanged("IAmount");
            }
        }
        private string totalInvoiceAmount;
        private string totalCCDAmount;
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
        public string SelectedDebitNoteNo
        {
            get
            {
                return _SelectedDebitNoteNo;
            }
            set
            {
                _SelectedDebitNoteNo = value;
                OnPropertyChanged("SelectedDebitNoteNo");
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
        public List<PurchaseInvoiceListEntity> PurchaseInvoiceList
        {
            get { return _PurchaseInvoiceList; }
            set
            {
                if (_PurchaseInvoiceList != value)
                {
                    _PurchaseInvoiceList = value;
                    OnPropertyChanged("PurchaseInvoiceList");
                }
            }
        }
        public List<PurchaseInvoiceListEntity> PurchaseInvoiceListcmb
        {
            get { return _PurchaseInvoiceListcmb; }
            set
            {
                if (_PurchaseInvoiceListcmb != value)
                {
                    _PurchaseInvoiceListcmb = value;
                    OnPropertyChanged("PurchaseInvoiceListcmb");
                }
            }
        }
        public List<PurchaseInvoiceListEntity> PurchaseInvoiceListcmbInv
        {
            get { return _PurchaseInvoiceListcmbInv; }
            set
            {
                if (_PurchaseInvoiceListcmbInv != value)
                {
                    _PurchaseInvoiceListcmbInv = value;
                    OnPropertyChanged("PurchaseInvoiceListcmbInv");
                }
            }
        }
        public List<PurchaseInvoiceListEntity> PurchaseInvoiceListcmbSup
        {
            get { return _PurchaseInvoiceListcmbSup; }
            set
            {
                if (_PurchaseInvoiceListcmbSup != value)
                {
                    _PurchaseInvoiceListcmbSup = value;
                    OnPropertyChanged("PurchaseInvoiceListcmbSup");
                }
            }
        }
        public List<PurchaseInvoiceListEntity> PurchaseInvoiceListcmbDebit
        {
            get { return _PurchaseInvoiceListcmbDebit; }
            set
            {
                if (_PurchaseInvoiceListcmbDebit != value)
                {
                    _PurchaseInvoiceListcmbDebit = value;
                    OnPropertyChanged("PurchaseInvoiceListcmbDebit");
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
