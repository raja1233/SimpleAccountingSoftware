
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.ProductandServices
{
    using SDN.Common;
    using System.Globalization;

    public class TopPandSEntity:ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private string _PandSCode;
        private string _PandSName;
        private int _Category1Id;
        private string _Category1;
        private int _Category2Id;
        private string _Category2;
        private string _SalesAmountStr;
        private decimal? _SalesAmount;
        private string _PurchaseAmountStr;
        private decimal? _PurchaseAmount;
        private string _ProfitAmountStr;
        private decimal? _ProfitAmount;
        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;
        private bool? _ShowProducts;
        private bool? _ShowServices;
        private bool? _ShowBoth;
        private bool? _ShowIncTaxTrue;
        private bool? _ShowExcTaxTrue;
        private List<TopPandSEntity> _TopPandSList;
        private string _PandSType;

        private string _CurrencyName;
        private string _CurrencyCode;
        private string _CurrencyFormat;
        private string _DateFormat;
        private int? _DecimalPlaces;
        private string _TaxName;
        private int? _ShowAllCount;
        private int? _ShowSelectedCount;
        private string _SelectedPandSCode;
        private string _SelectedPandSName;
        private string _SelectedCategory1;
        private string _SelectedCategory2;
        private List<TopPandSEntity> _TopPandSListcmb;
        private List<TopPandSEntity> _TopPandSListcmbCode;
        private List<TopPandSEntity> _TopPandSListcmbCat1;
        private List<TopPandSEntity> _TopPandSListcmbCat2;
        private int? _GridHeight;

        // private bool? _ShowAllTrue;
        //   private bool? _ShowSelectedTrue;
        private string _Year;
        private string _Quater;
        private string _Month;
        private string _StartDate;
        private string _EndDate;

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

        private bool? _EnableYearDropDown;
        private bool? _EnableQuarterDropDown;
        private bool? _EnableMonthDropDown;
        private bool? _EnableStartDropDown;
        private bool? _EnableEndDropDown;
        private string _LastupdatedDate;
        private DateTime? _CreatedDateList;
        private DateTime? _EndDateValidation;
        private List<ContentModel> psCategory1;
        private List<ContentModel> psCategory2;
        private string _Search;
        private int psID;
        private string totalSalesAmountStr;
        private string totalPurchaseAmountStr;

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

        public int PSID
        {
            get { return psID; }
            set
            {
                psID = value;
                OnPropertyChanged("PSID");
            }
        }
        public List<ContentModel> PSCategory1
        {
            get { return psCategory1; }
            set
            {
                psCategory1 = value;
                OnPropertyChanged("PSCategory1");
            }
        }
        public List<ContentModel> PSCategory2
        {
            get { return psCategory2; }
            set
            {
                psCategory2 = value;
                OnPropertyChanged("PSCategory2");
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
        public string SalesAmountStr
        {
            get
            {
                //return _StandardSellPriceStr;
                if (_SalesAmountStr == null)
                    return this._SalesAmountStr;
                else
                {
                    if (_SalesAmountStr != "")
                    {
                        var balance = _SalesAmountStr.Replace(",", "");
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
                        return this._SalesAmountStr;
                }
            }
            set
            {
                _SalesAmountStr = value;
                OnPropertyChanged("SalesAmountStr");
            }
        }

        public string TotalSalesAmountStr
        {
            get
            {
                //return _StandardSellPriceStr;
                if (totalSalesAmountStr == null)
                    return this.totalSalesAmountStr;
                else
                {
                    if (totalSalesAmountStr != "")
                    {
                        var balance = totalSalesAmountStr.Replace(",", "");
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
                        return this.totalSalesAmountStr;
                }
            }
            set
            {
                totalSalesAmountStr = value;
                OnPropertyChanged("TotalSalesAmountStr");
            }
        }
        public string TotalPurchaseAmountStr
        {
            get
            {
                //return _StandardSellPriceStr;
                if (totalPurchaseAmountStr == null)
                    return this.totalPurchaseAmountStr;
                else
                {
                    if (totalPurchaseAmountStr != "")
                    {
                        var balance = totalPurchaseAmountStr.Replace(",", "");
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
                        return this.totalPurchaseAmountStr;
                }
            }
            set
            {
                totalPurchaseAmountStr = value;
                OnPropertyChanged("TotalPurchaseAmountStr");
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
        public decimal? Sales
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
        public string PurchaseAmountStr
        {
            get
            {
                //return _AverageSellPriceStr;
                if (_PurchaseAmountStr == null)
                    return this._PurchaseAmountStr;
                else
                {
                    if (_PurchaseAmountStr != "")
                    {
                        var balance = _PurchaseAmountStr.Replace(",", "");
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
                        return this._PurchaseAmountStr;
                }
            }
            set
            {
                _PurchaseAmountStr = value;
                OnPropertyChanged("PurchaseAmountStr");
            }
        }
        public decimal? Purchase
        {
            get
            {
                return _PurchaseAmount;
            }
            set
            {
                _PurchaseAmount = value;
                OnPropertyChanged("PurchaseAmount");
            }
        }
        public string ProfitAmountStr
        {
            get
            {
                //return _LastSellPriceStr;
                if (_ProfitAmountStr == null)
                    return this._ProfitAmountStr;
                else
                {
                    if (_ProfitAmountStr != "")
                    {
                        var balance = _ProfitAmountStr.Replace(",", "");
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
                        return this._ProfitAmountStr;
                }
            }
            set
            {
                _ProfitAmountStr = value;
                OnPropertyChanged("ProfitAmountStr");
            }
        }
        public decimal? Profit
        {
            get
            {
                return _ProfitAmount;
            }
            set
            {
                _ProfitAmount = value;
                OnPropertyChanged("ProfitAmount");
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
        public bool? ShowIncTaxTrue
        {
            get
            {
                return _ShowIncTaxTrue;
            }
            set
            {
                _ShowIncTaxTrue = value;
                OnPropertyChanged("ShowIncTaxTrue");
            }
        }
        public bool? ShowExcTaxTrue
        {
            get
            {
                return _ShowExcTaxTrue;
            }
            set
            {
                _ShowExcTaxTrue = value;
                OnPropertyChanged("ShowExcTaxTrue");
            }
        }
        public List<TopPandSEntity> TopPandSList
        {
            get
            {
                return _TopPandSList;
            }
            set
            {
                _TopPandSList = value;
                OnPropertyChanged("TopPandSList");
            }
        }
        public List<TopPandSEntity> TopPandSListcmb
        {
            get
            {
                return _TopPandSListcmb;
            }
            set
            {
                _TopPandSListcmb = value;
                OnPropertyChanged("TopPandSListcmb");
            }
        }
        public List<TopPandSEntity> TopPandSListcmbCode
        {
            get
            {
                return _TopPandSListcmbCode;
            }
            set
            {
                _TopPandSListcmbCode = value;
                OnPropertyChanged("TopPandSListcmbCode");
            }
        }
        public List<TopPandSEntity> TopPandSListcmbCat1
        {
            get
            {
                return _TopPandSListcmbCat1;
            }
            set
            {
                _TopPandSListcmbCat1 = value;
                OnPropertyChanged("TopPandSListcmbCat1");
            }
        }
        public List<TopPandSEntity> TopPandSListcmbCat2
        {
            get
            {
                return _TopPandSListcmbCat2;
            }
            set
            {
                _TopPandSListcmbCat2 = value;
                OnPropertyChanged("TopPandSListcmbCat2");
            }
        }
        public string PandSType
        {
            get
            {
                return _PandSType;
            }
            set
            {
                _PandSType = value;
                OnPropertyChanged("PandSType");
            }
        }

        public string CurrencyName
        {
            get
            {
                return _CurrencyName;
            }
            set
            {
                _CurrencyName = value;
                OnPropertyChanged("CurrencyName");
            }
        }
        public string CurrencyCode
        {
            get
            {
                return _CurrencyCode;
            }
            set
            {
                _CurrencyCode = value;
                OnPropertyChanged("CurrencyCode");
            }
        }
        public string CurrencyFormat
        {
            get
            {
                return _CurrencyFormat;
            }
            set
            {
                _CurrencyFormat = value;
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
        public int? DecimalPlaces
        {
            get
            {
                return _DecimalPlaces;
            }
            set
            {
                _DecimalPlaces = value;
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
        public int? GridHeight
        {
            get
            {
                return _GridHeight;
            }
            set
            {
                _GridHeight = value;
                OnPropertyChanged("GridHeight");
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



        #endregion
    }
}
