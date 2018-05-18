using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.ProductandServices
{
    public class PandSStockValueListEntity : ViewModelBase
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
        private decimal? _StandardStockValue;
        private string _AverageCostPriceStr;
        private decimal? _AverageStockValue;
        private string _PSStockValueStr;
        private decimal? _LastStockValue;
        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;
        private bool? _ShowProducts;
        private bool? _ShowServices;
        private bool? _ShowBoth;
        private bool? _ShowIncTaxTrue;
        private bool? _ShowExcTaxTrue;
        private List<PandSStockValueListEntity> _PandSStockValueList;
        private string _PandSType;
        private decimal? _PandSStdStockValuebefGST;
        private decimal? _PandSStdStockValueaftGST;
        private decimal? _PandSAveCostPriceaftGST;
        private decimal? _PandSAveCostPricebefGST;
        private decimal? _PSStockValuebefTax;
        private decimal? _PSStockValueaftTax;
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
        private List<PandSStockValueListEntity> _PandSStockValueListcmb;
        private List<PandSStockValueListEntity> _PandSStockValueListcmbCode;
        private List<PandSStockValueListEntity> _PandSStockValueListcmbCat1;
        private List<PandSStockValueListEntity> _PandSStockValueListcmbCat2;
        private int? _GridHeight;
        private int? _QtyInStock;
        private string _TotalStockValue;
        private string _TotalAvgCostPrice;
        private string _TotalQtyInStock;

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
                //return _StandardStockValueStr;
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
        public decimal? StandardStockValue
        {
            get
            {
                return _StandardStockValue;
            }
            set
            {
                _StandardStockValue = value;
                OnPropertyChanged("StandardStockValue");
            }
        }
        public string AverageCostPriceStr
        {
            get
            {
                //return _AverageStockValueStr;
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
        public decimal? AverageStockValue
        {
            get
            {
                return _AverageStockValue;
            }
            set
            {
                _AverageStockValue = value;
                OnPropertyChanged("AverageStockValue");
            }
        }
        public string PSStockValueStr
        {
            get
            {
                //return _LastStockValueStr;
                if (_PSStockValueStr == null)
                    return this._PSStockValueStr;
                else
                {
                    if (_PSStockValueStr != "")
                    {
                        var balance = _PSStockValueStr.Replace(",", "");
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
                        return this._PSStockValueStr;
                }
            }
            set
            {
                _PSStockValueStr = value;
                OnPropertyChanged("PSStockValueStr");
            }
        }
        public decimal? LastStockValue
        {
            get
            {
                return _LastStockValue;
            }
            set
            {
                _LastStockValue = value;
                OnPropertyChanged("LastStockValue");
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
        public List<PandSStockValueListEntity> PandSStockValueList
        {
            get
            {
                return _PandSStockValueList;
            }
            set
            {
                _PandSStockValueList = value;
                OnPropertyChanged("PandSStockValueList");
            }
        }
        public List<PandSStockValueListEntity> PandSStockValueListcmb
        {
            get
            {
                return _PandSStockValueListcmb;
            }
            set
            {
                _PandSStockValueListcmb = value;
                OnPropertyChanged("PandSStockValueListcmb");
            }
        }
        public List<PandSStockValueListEntity> PandSStockValueListcmbCode
        {
            get
            {
                return _PandSStockValueListcmbCode;
            }
            set
            {
                _PandSStockValueListcmbCode = value;
                OnPropertyChanged("PandSStockValueListcmbCode");
            }
        }
        public List<PandSStockValueListEntity> PandSStockValueListcmbCat1
        {
            get
            {
                return _PandSStockValueListcmbCat1;
            }
            set
            {
                _PandSStockValueListcmbCat1 = value;
                OnPropertyChanged("PandSStockValueListcmbCat1");
            }
        }
        public List<PandSStockValueListEntity> PandSStockValueListcmbCat2
        {
            get
            {
                return _PandSStockValueListcmbCat2;
            }
            set
            {
                _PandSStockValueListcmbCat2 = value;
                OnPropertyChanged("PandSStockValueListcmbCat2");
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
        public decimal? PandSStdStockValuebefGST
        {
            get
            {
                return _PandSStdStockValuebefGST;
            }
            set
            {
                _PandSStdStockValuebefGST = value;
                OnPropertyChanged("PandSStdStockValuebefGST");
            }
        }
        public decimal? PandSStdStockValueaftGST
        {
            get
            {
                return _PandSStdStockValueaftGST;
            }
            set
            {
                _PandSStdStockValueaftGST = value;
                OnPropertyChanged("PandSStdStockValueaftGST");
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
        public decimal? PSStockValueaftTax
        {
            get
            {
                return _PSStockValueaftTax;
            }
            set
            {
                _PSStockValueaftTax = value;
                OnPropertyChanged("PSStockValueaftTax");
            }
        }
        public decimal? PSStockValuebefTax
        {
            get
            {
                return _PSStockValuebefTax;
            }
            set
            {
                _PSStockValuebefTax = value;
                OnPropertyChanged("PSStockValuebefTax");
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
        public int? QtyInStock
        {
            get
            {
                return _QtyInStock;
            }
            set
            {
                _QtyInStock = value;
                OnPropertyChanged("QtyInStock");
            }
        }
        public string TotalStockValue
        {
            get
            {
                return _TotalStockValue;
            }
            set
            {
                _TotalStockValue = value;
                OnPropertyChanged("TotalStockValue");
            }
        }
        public string TotalAvgCostPrice
        {
            get
            {
                return _TotalAvgCostPrice;
            }
            set
            {
                _TotalAvgCostPrice = value;
                OnPropertyChanged("TotalAvgCostPrice");
            }
        }
        public string TotalQtyInStock
        {
            get
            {
                return _TotalQtyInStock;
            }
            set
            {
                _TotalQtyInStock = value;
                OnPropertyChanged("TotalQtyInStock");
            }
        }

        #endregion
    }
}
