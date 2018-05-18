using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Puchase
{
    public class SupplierHistoryEntity : ViewModelBase
    {

        #region Private Properties
        private int _ID;
        private int? _Cus_ID;
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
        private List<SupplierHistoryEntity> _SupplierHistory;
        private List<SupplierHistoryEntity> _SupplierHistorycmb;
        private List<SupplierHistoryEntity> _SupplierHistorycmbInv;
        private List<SupplierHistoryEntity> _SupplierHistorycmbSup;
        private List<SupplierHistoryEntity> _SupplierHistorycmbCredit;
        private int _ShowAllCount;
        private int _ShowSelectedCount;
        private bool? _ConvertedToSI;
        private bool? _ConvertedToSO;
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
        private string _SelectedCreditNoteNo;
        private bool? _IncludingGSTTrue;
        private bool? _IncludingGSTFalse;
        private string _LastupdatedDate;
        private DateTime? _CreatedDateList;
        private DateTime? _EndDateValidation;
        private DateTime? _InvoiceDateDateTime;


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

        #region Public Properties
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
        public List<SupplierHistoryEntity> SupplierHistory
        {
            get { return _SupplierHistory; }
            set
            {
                if (_SupplierHistory != value)
                {
                    _SupplierHistory = value;
                    OnPropertyChanged("SupplierHistory");
                }
            }
        }
        public List<SupplierHistoryEntity> SupplierHistorycmb
        {
            get { return _SupplierHistorycmb; }
            set
            {
                if (_SupplierHistorycmb != value)
                {
                    _SupplierHistorycmb = value;
                    OnPropertyChanged("SupplierHistorycmb");
                }
            }
        }
        public List<SupplierHistoryEntity> SupplierHistorycmbInv
        {
            get { return _SupplierHistorycmbInv; }
            set
            {
                if (_SupplierHistorycmbInv != value)
                {
                    _SupplierHistorycmbInv = value;
                    OnPropertyChanged("SupplierHistorycmbInv");
                }
            }
        }
        public List<SupplierHistoryEntity> SupplierHistorycmbSup
        {
            get { return _SupplierHistorycmbSup; }
            set
            {
                if (_SupplierHistorycmbSup != value)
                {
                    _SupplierHistorycmbSup = value;
                    OnPropertyChanged("SupplierHistorycmbSup");
                }
            }
        }
        public List<SupplierHistoryEntity> SupplierHistorycmbCredit
        {
            get { return _SupplierHistorycmbCredit; }
            set
            {
                if (_SupplierHistorycmbCredit != value)
                {
                    _SupplierHistorycmbCredit = value;
                    OnPropertyChanged("SupplierHistorycmbCredit");
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
