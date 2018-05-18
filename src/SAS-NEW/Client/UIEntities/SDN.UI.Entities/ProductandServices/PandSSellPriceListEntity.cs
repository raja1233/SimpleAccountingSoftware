using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.ProductandServices
{
    public class PandSSellPriceListEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private string _PandSCode;
        private string _PandSName;
        private int _Category1Id;
        private string _Category1;
        private int _Category2Id;
        private string _Category2;
        private string _StandardSellPriceStr;
        private decimal? _StandardSellPrice;
        private string _AverageSellPriceStr;
        private decimal? _AverageSellPrice;
        private string _LastSellPriceStr;
        private decimal? _LastSellPrice;
        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;
        private bool? _ShowProducts;
        private bool? _ShowServices;
        private bool? _ShowBoth;
        private bool? _ShowIncTaxTrue;
        private bool? _ShowExcTaxTrue;
        private List<PandSSellPriceListEntity> _PandSSellPriceList;
        private string _PandSType;
        private decimal? _PandSStdSellPricebefGST;
        private decimal? _PandSStdSellPriceaftGST;
        private decimal? _PandSAveSellPricebefGST;
        private decimal? _PandSAveSellPriceaftGST;
        private decimal? _PandSLastSoldPricebefGST;
        private decimal? _PandSLastSoldPriceaftGST;
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
        private List<PandSSellPriceListEntity> _PandSSellPriceListcmb;
        private List<PandSSellPriceListEntity> _PandSSellPriceListcmbCode;
        private List<PandSSellPriceListEntity> _PandSSellPriceListcmbCat1;
        private List<PandSSellPriceListEntity> _PandSSellPriceListcmbCat2;
        private int? _GridHeight;
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
        public string StandardSellPriceStr
        {
            get
            {
                //return _StandardSellPriceStr;
                if (_StandardSellPriceStr == null)
                    return this._StandardSellPriceStr;
                else
                {
                    if (_StandardSellPriceStr != "")
                    {
                        var balance = _StandardSellPriceStr.Replace(",", "");
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
                        return this._StandardSellPriceStr;
                }
            }
            set
            {
                _StandardSellPriceStr = value;
                OnPropertyChanged("StandardSellPriceStr");
            }
        }
        public decimal? StandardSellPrice
        {
            get
            {
                return _StandardSellPrice;
            }
            set
            {
                _StandardSellPrice = value;
                OnPropertyChanged("StandardSellPrice");
            }
        }
        public string AverageSellPriceStr
        {
            get
            {
                //return _AverageSellPriceStr;
                if (_AverageSellPriceStr == null)
                    return this._AverageSellPriceStr;
                else
                {
                    if (_AverageSellPriceStr != "")
                    {
                        var balance = _AverageSellPriceStr.Replace(",", "");
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
                        return this._AverageSellPriceStr;
                }
            }
            set
            {
                _AverageSellPriceStr = value;
                OnPropertyChanged("AverageSellPriceStr");
            }
        }
        public decimal? AverageSellPrice
        {
            get
            {
                return _AverageSellPrice;
            }
            set
            {
                _AverageSellPrice = value;
                OnPropertyChanged("AverageSellPrice");
            }
        }
        public string LastSellPriceStr
        {
            get
            {
                //return _LastSellPriceStr;
                if (_LastSellPriceStr == null)
                    return this._LastSellPriceStr;
                else
                {
                    if (_LastSellPriceStr != "")
                    {
                        var balance = _LastSellPriceStr.Replace(",", "");
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
                        return this._LastSellPriceStr;
                }
            }
            set
            {
                _LastSellPriceStr = value;
                OnPropertyChanged("LastSellPriceStr");
            }
        }
        public decimal? LastSellPrice
        {
            get
            {
                return _LastSellPrice;
            }
            set
            {
                _LastSellPrice = value;
                OnPropertyChanged("LastSellPrice");
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
        public List<PandSSellPriceListEntity> PandSSellPriceList
        {
            get
            {
                return _PandSSellPriceList;
            }
            set
            {
                _PandSSellPriceList = value;
                OnPropertyChanged("PandSSellPriceList");
            }
        }
        public List<PandSSellPriceListEntity> PandSSellPriceListcmb
        {
            get
            {
                return _PandSSellPriceListcmb;
            }
            set
            {
                _PandSSellPriceListcmb = value;
                OnPropertyChanged("PandSSellPriceListcmb");
            }
        }
        public List<PandSSellPriceListEntity> PandSSellPriceListcmbCode
        {
            get
            {
                return _PandSSellPriceListcmbCode;
            }
            set
            {
                _PandSSellPriceListcmbCode = value;
                OnPropertyChanged("PandSSellPriceListcmbCode");
            }
        }
        public List<PandSSellPriceListEntity> PandSSellPriceListcmbCat1
        {
            get
            {
                return _PandSSellPriceListcmbCat1;
            }
            set
            {
                _PandSSellPriceListcmbCat1 = value;
                OnPropertyChanged("PandSSellPriceListcmbCat1");
            }
        }
        public List<PandSSellPriceListEntity> PandSSellPriceListcmbCat2
        {
            get
            {
                return _PandSSellPriceListcmbCat2;
            }
            set
            {
                _PandSSellPriceListcmbCat2 = value;
                OnPropertyChanged("PandSSellPriceListcmbCat2");
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
        public decimal? PandSStdSellPricebefGST
        {
            get
            {
                return _PandSStdSellPricebefGST;
            }
            set
            {
                _PandSStdSellPricebefGST = value;
                OnPropertyChanged("PandSStdSellPricebefGST");
            }
        }
        public decimal? PandSStdSellPriceaftGST
        {
            get
            {
                return _PandSStdSellPriceaftGST;
            }
            set
            {
                _PandSStdSellPriceaftGST = value;
                OnPropertyChanged("PandSStdSellPriceaftGST");
            }
        }
        public decimal? PandSAveSellPricebefGST
        {
            get
            {
                return _PandSAveSellPricebefGST;
            }
            set
            {
                _PandSAveSellPricebefGST = value;
                OnPropertyChanged("PandSAveSellPricebefGST");
            }
        }
        public decimal? PandSAveSellPriceaftGST
        {
            get
            {
                return _PandSAveSellPriceaftGST;
            }
            set
            {
                _PandSAveSellPriceaftGST = value;
                OnPropertyChanged("PandSAveSellPriceaftGST");
            }
        }
        public decimal? PandSLastSoldPricebefGST
        {
            get
            {
                return _PandSLastSoldPricebefGST;
            }
            set
            {
                _PandSLastSoldPricebefGST = value;
                OnPropertyChanged("PandSLastSoldPricebefGST");
            }
        }
        public decimal? PandSLastSoldPriceaftGST
        {
            get
            {
                return _PandSLastSoldPriceaftGST;
            }
            set
            {
                _PandSLastSoldPriceaftGST = value;
                OnPropertyChanged("PandSLastSoldPriceaftGST");
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
        #endregion
    }
}
