using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.ProductandServices
{
    public class PandSCostPriceListEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private string _PandSCode;
        private string _PandSName;
        private int _Category1Id;
        private string _Category1;
        private int _Category2Id;
        private string _Category2;
        private string _StandardCostPriceStr;
        private decimal? _StandardCostPrice;
        private string _AverageCostPriceStr;
        private decimal? _AverageCostPrice;
        private string _LastPurPricStr;
        private decimal? _LastCostPrice;
        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;
        private bool? _ShowProducts;
        private bool? _ShowServices;
        private bool? _ShowBoth;
        private bool? _ShowIncTaxTrue;
        private bool? _ShowExcTaxTrue;
        private List<PandSCostPriceListEntity> _PandSCostPriceList;
        private string _PandSType;
        private decimal? _PandSStdCostPricebefGST;
        private decimal? _PandSStdCostPriceaftGST;
        private decimal? _PandSAveCostPricebefGST;
        private decimal? _PandSAveCostPriceaftGST;
        private decimal? _PandSLastPurPricebefGST;
        private decimal? _PandSLastPurPriceaftGST;
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
        private List<PandSCostPriceListEntity> _PandSCostPriceListcmb;
        private List<PandSCostPriceListEntity> _PandSCostPriceListcmbCode;
        private List<PandSCostPriceListEntity> _PandSCostPriceListcmbCat1;
        private List<PandSCostPriceListEntity> _PandSCostPriceListcmbCat2;
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
        public string StandardCostPriceStr
        {
            get
            {
                //return _StandardCostPriceStr;
                if (_StandardCostPriceStr == null)
                    return this._StandardCostPriceStr;
                else
                {
                    if (_StandardCostPriceStr != "")
                    {
                        var balance = _StandardCostPriceStr.Replace(",", "");
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
                        return this._StandardCostPriceStr;
                }
            }
            set
            {
                _StandardCostPriceStr = value;
                OnPropertyChanged("StandardCostPriceStr");
            }
        }
        public decimal? StandardCostPrice
        {
            get
            {
                return _StandardCostPrice;
            }
            set
            {
                _StandardCostPrice = value;
                OnPropertyChanged("StandardCostPrice");
            }
        }
        public string AverageCostPriceStr
        {
            get
            {
                //return _AverageCostPriceStr;
                if (_AverageCostPriceStr == null)
                    return this._AverageCostPriceStr;
                else
                {
                    if (_AverageCostPriceStr != "")
                    {
                        var balance = _AverageCostPriceStr.Replace(",", "");
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
                        return this._AverageCostPriceStr;
                }
            }
            set
            {
                _AverageCostPriceStr = value;
                OnPropertyChanged("AverageCostPriceStr");
            }
        }
        public decimal? AverageCostPrice
        {
            get
            {
                return _AverageCostPrice;
            }
            set
            {
                _AverageCostPrice = value;
                OnPropertyChanged("AverageCostPrice");
            }
        }
        public string LastPurPricStr
        {
            get
            {
                //return _LastCostPriceStr;
                if (_LastPurPricStr == null)
                    return this._LastPurPricStr;
                else
                {
                    if (_LastPurPricStr != "")
                    {
                        var balance = _LastPurPricStr.Replace(",", "");
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
                        return this._LastPurPricStr;
                }
            }
            set
            {
                _LastPurPricStr = value;
                OnPropertyChanged("LastPurPricStr");
            }
        }
        public decimal? LastCostPrice
        {
            get
            {
                return _LastCostPrice;
            }
            set
            {
                _LastCostPrice = value;
                OnPropertyChanged("LastCostPrice");
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
        public List<PandSCostPriceListEntity> PandSCostPriceList
        {
            get
            {
                return _PandSCostPriceList;
            }
            set
            {
                _PandSCostPriceList = value;
                OnPropertyChanged("PandSCostPriceList");
            }
        }
        public List<PandSCostPriceListEntity> PandSCostPriceListcmb
        {
            get
            {
                return _PandSCostPriceListcmb;
            }
            set
            {
                _PandSCostPriceListcmb = value;
                OnPropertyChanged("PandSCostPriceListcmb");
            }
        }
        public List<PandSCostPriceListEntity> PandSCostPriceListcmbCode
        {
            get
            {
                return _PandSCostPriceListcmbCode;
            }
            set
            {
                _PandSCostPriceListcmbCode = value;
                OnPropertyChanged("PandSCostPriceListcmbCode");
            }
        }
        public List<PandSCostPriceListEntity> PandSCostPriceListcmbCat1
        {
            get
            {
                return _PandSCostPriceListcmbCat1;
            }
            set
            {
                _PandSCostPriceListcmbCat1 = value;
                OnPropertyChanged("PandSCostPriceListcmbCat1");
            }
        }
        public List<PandSCostPriceListEntity> PandSCostPriceListcmbCat2
        {
            get
            {
                return _PandSCostPriceListcmbCat2;
            }
            set
            {
                _PandSCostPriceListcmbCat2 = value;
                OnPropertyChanged("PandSCostPriceListcmbCat2");
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
        public decimal? PandSStdCostPricebefGST
        {
            get
            {
                return _PandSStdCostPricebefGST;
            }
            set
            {
                _PandSStdCostPricebefGST = value;
                OnPropertyChanged("PandSStdCostPricebefGST");
            }
        }
        public decimal? PandSStdCostPriceaftGST
        {
            get
            {
                return _PandSStdCostPriceaftGST;
            }
            set
            {
                _PandSStdCostPriceaftGST = value;
                OnPropertyChanged("PandSStdCostPriceaftGST");
            }
        }
        public decimal? PandSAveCostPricebefGST
        {
            get
            {
                return _PandSAveCostPricebefGST;
            }
            set
            {
                _PandSAveCostPricebefGST = value;
                OnPropertyChanged("PandSAveCostPricebefGST");
            }
        }
        public decimal? PandSAveCostPriceaftGST
        {
            get
            {
                return _PandSAveCostPriceaftGST;
            }
            set
            {
                _PandSAveCostPriceaftGST = value;
                OnPropertyChanged("PandSAveCostPriceaftGST");
            }
        }
        public decimal? PandSLastPurPricebefGST
        {
            get
            {
                return _PandSLastPurPricebefGST;
            }
            set
            {
                _PandSLastPurPricebefGST = value;
                OnPropertyChanged("PandSLastPurPricebefGST");
            }
        }
        public decimal? PandSLastPurPriceaftGST
        {
            get
            {
                return _PandSLastPurPriceaftGST;
            }
            set
            {
                _PandSLastPurPriceaftGST = value;
                OnPropertyChanged("PandSLastPurPriceaftGST");
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
