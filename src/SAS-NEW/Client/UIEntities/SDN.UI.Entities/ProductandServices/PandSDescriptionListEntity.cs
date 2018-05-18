using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.ProductandServices
{
    public class PandSDescriptionListEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private string _PandSCode;
        private string _PandSName;
        private int _Category1Id;
        private string _Category1;
        private int _Category2Id;
        private string _Category2;
        private string _StandardDescriptionStr;
        private decimal? _StandardDescription;
        private string _AverageDescriptionStr;
        private decimal? _AverageDescription;
        private string _LastDescriptionStr;
        private decimal? _LastDescription;
        private bool? _ShowActiveTrue;
        private bool? _ShowInactiveTrue;
        private bool? _ShowProducts;
        private bool? _ShowServices;
        private bool? _ShowBoth;
        private bool? _ShowBothTrue;
      
        private List<PandSDescriptionListEntity> _PandSDescriptionList;
        private string _PandSType;
        private decimal? _PandSStdDescriptionbefGST;
        private decimal? _PandSStdDescriptionaftGST;
        private decimal? _PandSAveDescriptionbefGST;
        private decimal? _PandSAveDescriptionaftGST;
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
        private List<PandSDescriptionListEntity> _PandSDescriptionListcmb;
        private List<PandSDescriptionListEntity> _PandSDescriptionListcmbCode;
        private List<PandSDescriptionListEntity> _PandSDescriptionListDesc;
        private List<PandSDescriptionListEntity> _PandSDescriptionListcmbCat2;
        private int? _GridHeight;
        private string _PSDescription;
        private string _IsInactive;
        private int _ActiveCount;
        private int _InActiveCount;
        private int _ServiceCount;
        private int _ProductCount;
        private string _SelectedPSDescription;
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
        public string StandardDescriptionStr
        {
            get
            {
                //return _StandardDescriptionStr;
                if (_StandardDescriptionStr == null)
                    return this._StandardDescriptionStr;
                else
                {
                    if (_StandardDescriptionStr != "")
                    {
                        var balance = _StandardDescriptionStr.Replace(",", "");
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
                        return this._StandardDescriptionStr;
                }
            }
            set
            {
                _StandardDescriptionStr = value;
                OnPropertyChanged("StandardDescriptionStr");
            }
        }
        public decimal? StandardDescription
        {
            get
            {
                return _StandardDescription;
            }
            set
            {
                _StandardDescription = value;
                OnPropertyChanged("StandardDescription");
            }
        }
        public string AverageDescriptionStr
        {
            get
            {
                //return _AverageDescriptionStr;
                if (_AverageDescriptionStr == null)
                    return this._AverageDescriptionStr;
                else
                {
                    if (_AverageDescriptionStr != "")
                    {
                        var balance = _AverageDescriptionStr.Replace(",", "");
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
                        return this._AverageDescriptionStr;
                }
            }
            set
            {
                _AverageDescriptionStr = value;
                OnPropertyChanged("AverageDescriptionStr");
            }
        }
        public decimal? AverageDescription
        {
            get
            {
                return _AverageDescription;
            }
            set
            {
                _AverageDescription = value;
                OnPropertyChanged("AverageDescription");
            }
        }
        public string LastDescriptionStr
        {
            get
            {
                //return _LastDescriptionStr;
                if (_LastDescriptionStr == null)
                    return this._LastDescriptionStr;
                else
                {
                    if (_LastDescriptionStr != "")
                    {
                        var balance = _LastDescriptionStr.Replace(",", "");
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
                        return this._LastDescriptionStr;
                }
            }
            set
            {
                _LastDescriptionStr = value;
                OnPropertyChanged("LastDescriptionStr");
            }
        }
        public decimal? LastDescription
        {
            get
            {
                return _LastDescription;
            }
            set
            {
                _LastDescription = value;
                OnPropertyChanged("LastDescription");
            }
        }
        public bool? ShowActiveTrue
        {
            get
            {
                return _ShowActiveTrue;
            }
            set
            {
                _ShowActiveTrue = value;
                OnPropertyChanged("ShowActiveTrue");
            }
        }
        public bool? ShowInactiveTrue
        {
            get
            {
                return _ShowInactiveTrue;
            }
            set
            {
                _ShowInactiveTrue = value;
                OnPropertyChanged("ShowInactiveTrue");
            }
        }
        public bool? ShowBothTrue
        {
            get
            {
                return _ShowBothTrue;
            }
            set
            {
                _ShowBothTrue = value;
                OnPropertyChanged("ShowBothTrue");
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
     

        public List<PandSDescriptionListEntity> PandSDescriptionList
        {
            get
            {
                return _PandSDescriptionList;
            }
            set
            {
                _PandSDescriptionList = value;
                OnPropertyChanged("PandSDescriptionList");
            }
        }
        public List<PandSDescriptionListEntity> PandSDescriptionListcmb
        {
            get
            {
                return _PandSDescriptionListcmb;
            }
            set
            {
                _PandSDescriptionListcmb = value;
                OnPropertyChanged("PandSDescriptionListcmb");
            }
        }
        public List<PandSDescriptionListEntity> PandSDescriptionListcmbCode
        {
            get
            {
                return _PandSDescriptionListcmbCode;
            }
            set
            {
                _PandSDescriptionListcmbCode = value;
                OnPropertyChanged("PandSDescriptionListcmbCode");
            }
        }
        public List<PandSDescriptionListEntity> PandSDescriptionListDesc
        {
            get
            {
                return _PandSDescriptionListDesc;
            }
            set
            {
                _PandSDescriptionListDesc = value;
                OnPropertyChanged("PandSDescriptionListDesc");
            }
        }
        public List<PandSDescriptionListEntity> PandSDescriptionListcmbCat2
        {
            get
            {
                return _PandSDescriptionListcmbCat2;
            }
            set
            {
                _PandSDescriptionListcmbCat2 = value;
                OnPropertyChanged("PandSDescriptionListcmbCat2");
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
        public decimal? PandSStdDescriptionbefGST
        {
            get
            {
                return _PandSStdDescriptionbefGST;
            }
            set
            {
                _PandSStdDescriptionbefGST = value;
                OnPropertyChanged("PandSStdDescriptionbefGST");
            }
        }
        public decimal? PandSStdDescriptionaftGST
        {
            get
            {
                return _PandSStdDescriptionaftGST;
            }
            set
            {
                _PandSStdDescriptionaftGST = value;
                OnPropertyChanged("PandSStdDescriptionaftGST");
            }
        }
        public decimal? PandSAveDescriptionbefGST
        {
            get
            {
                return _PandSAveDescriptionbefGST;
            }
            set
            {
                _PandSAveDescriptionbefGST = value;
                OnPropertyChanged("PandSAveDescriptionbefGST");
            }
        }
        public decimal? PandSAveDescriptionaftGST
        {
            get
            {
                return _PandSAveDescriptionaftGST;
            }
            set
            {
                _PandSAveDescriptionaftGST = value;
                OnPropertyChanged("PandSAveDescriptionaftGST");
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
        public string PSDescription
        {
            get
            {
                return _PSDescription;
            }
            set
            {
                _PSDescription = value;
                OnPropertyChanged("PSDescription");
            }
        }
        public string IsInactive
        {
            get
            {
                return _IsInactive;
            }
            set
            {
                _IsInactive = value;
                OnPropertyChanged("IsInactive");
            }
        }
        public int ActiveCount
        {
            get
            {
                return _ActiveCount;
            }
            set
            {
                _ActiveCount = value;
                OnPropertyChanged("ActiveCount");
            }
        }
        public int InActiveCount
        {
            get
            {
                return _InActiveCount;
            }
            set
            {
                _InActiveCount = value;
                OnPropertyChanged("InActiveCount");
            }
        }
        public int ProductCount
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
        public int ServiceCount
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
        public string SelectedPSDescription
        {
            get
            {
                return _SelectedPSDescription;
            }
            set
            {
                _SelectedPSDescription = value;
                OnPropertyChanged("SelectedPSDescription");
            }
        }
        #endregion
    }
}
