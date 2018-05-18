using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.ProductandServices
{
    public class PandSCodesAndRatesListEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private string _PandSCode;
        private string _PandSName;
        private int _Category1Id;
        private string _Category1;
        private int _Category2Id;
        private string _Category2;
        private string _StandardCodesAndRatesStr;
        private decimal? _StandardCodesAndRates;
        private string _AverageCodesAndRatesStr;
        private decimal? _AverageCodesAndRates;
        private string _LastCodesAndRatesStr;
        private decimal? _LastCodesAndRates;
        private bool? _ShowAllTrue;
        private string _SelectedPSTaxName;
        private string _SelectedPSTaxRate;
        private bool? _ShowSelectedTrue;
        private bool? _ShowProducts;
        private bool? _ShowServices;
        private bool? _ShowBoth;
        private bool? _ShowIncTaxTrue;
        private bool? _ShowExcTaxTrue;
        private List<PandSCodesAndRatesListEntity> _PandSCodesAndRatesList;
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
        private List<PandSCodesAndRatesListEntity> _PandSCodesAndRatesListcmb;
        private List<PandSCodesAndRatesListEntity> _PandSCodesAndRatesListcmbCode;
        private List<PandSCodesAndRatesListEntity> _PandSCodesAndRatesListcmbCat1;
        private List<PandSCodesAndRatesListEntity> _PandSCodesAndRatesListcmbCat2;
        private List<PandSCodesAndRatesListEntity> _PandSCodesAndRatesListcmbTCode;
        private List<PandSCodesAndRatesListEntity> _PandSCodesAndRatesListcmbTRate;
        private string _PSTaxName;
        private int? _GridHeight;
        private decimal? _PSTaxRate;
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
        public string StandardCodesAndRatesStr
        {
            get
            {
                //return _StandardCodesAndRatesStr;
                if (_StandardCodesAndRatesStr == null)
                    return this._StandardCodesAndRatesStr;
                else
                {
                    if (_StandardCodesAndRatesStr != "")
                    {
                        var balance = _StandardCodesAndRatesStr.Replace(",", "");
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
                        return this._StandardCodesAndRatesStr;
                }
            }
            set
            {
                _StandardCodesAndRatesStr = value;
                OnPropertyChanged("StandardCodesAndRatesStr");
            }
        }
        public decimal? StandardCodesAndRates
        {
            get
            {
                return _StandardCodesAndRates;
            }
            set
            {
                _StandardCodesAndRates = value;
                OnPropertyChanged("StandardCodesAndRates");
            }
        }
        public string AverageCodesAndRatesStr
        {
            get
            {
                //return _AverageCodesAndRatesStr;
                if (_AverageCodesAndRatesStr == null)
                    return this._AverageCodesAndRatesStr;
                else
                {
                    if (_AverageCodesAndRatesStr != "")
                    {
                        var balance = _AverageCodesAndRatesStr.Replace(",", "");
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
                        return this._AverageCodesAndRatesStr;
                }
            }
            set
            {
                _AverageCodesAndRatesStr = value;
                OnPropertyChanged("AverageCodesAndRatesStr");
            }
        }
        public decimal? AverageCodesAndRates
        {
            get
            {
                return _AverageCodesAndRates;
            }
            set
            {
                _AverageCodesAndRates = value;
                OnPropertyChanged("AverageCodesAndRates");
            }
        }
        public string LastCodesAndRatesStr
        {
            get
            {
                //return _LastCodesAndRatesStr;
                if (_LastCodesAndRatesStr == null)
                    return this._LastCodesAndRatesStr;
                else
                {
                    if (_LastCodesAndRatesStr != "")
                    {
                        var balance = _LastCodesAndRatesStr.Replace(",", "");
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
                        return this._LastCodesAndRatesStr;
                }
            }
            set
            {
                _LastCodesAndRatesStr = value;
                OnPropertyChanged("LastCodesAndRatesStr");
            }
        }
        public decimal? LastCodesAndRates
        {
            get
            {
                return _LastCodesAndRates;
            }
            set
            {
                _LastCodesAndRates = value;
                OnPropertyChanged("LastCodesAndRates");
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
        public string SelectedPSTaxName
        {
            get
            {
                return _SelectedPSTaxName;
            }
            set
            {
                _SelectedPSTaxName = value;
                OnPropertyChanged("SelectedPSTaxName");
            }
        }
        public string SelectedPSTaxRate
        {
            get
            {
                return _SelectedPSTaxRate;
            }
            set
            {
                _SelectedPSTaxRate = value;
                OnPropertyChanged("SelectedPSTaxRate");
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
        public List<PandSCodesAndRatesListEntity> PandSCodesAndRatesList
        {
            get
            {
                return _PandSCodesAndRatesList;
            }
            set
            {
                _PandSCodesAndRatesList = value;
                OnPropertyChanged("PandSCodesAndRatesList");
            }
        }
        public List<PandSCodesAndRatesListEntity> PandSCodesAndRatesListcmb
        {
            get
            {
                return _PandSCodesAndRatesListcmb;
            }
            set
            {
                _PandSCodesAndRatesListcmb = value;
                OnPropertyChanged("PandSCodesAndRatesListcmb");
            }
        }
        public List<PandSCodesAndRatesListEntity> PandSCodesAndRatesListcmbCode
        {
            get
            {
                return _PandSCodesAndRatesListcmbCode;
            }
            set
            {
                _PandSCodesAndRatesListcmbCode = value;
                OnPropertyChanged("PandSCodesAndRatesListcmbCode");
            }
        }
        public List<PandSCodesAndRatesListEntity> PandSCodesAndRatesListcmbCat1
        {
            get
            {
                return _PandSCodesAndRatesListcmbCat1;
            }
            set
            {
                _PandSCodesAndRatesListcmbCat1 = value;
                OnPropertyChanged("PandSCodesAndRatesListcmbCat1");
            }
        }
        public List<PandSCodesAndRatesListEntity> PandSCodesAndRatesListcmbCat2
        {
            get
            {
                return _PandSCodesAndRatesListcmbCat2;
            }
            set
            {
                _PandSCodesAndRatesListcmbCat2 = value;
                OnPropertyChanged("PandSCodesAndRatesListcmbCat2");
            }
        }
        public List<PandSCodesAndRatesListEntity> PandSCodesAndRatesListcmbTCode
        {
            get
            {
                return _PandSCodesAndRatesListcmbTCode;
            }
            set
            {
                _PandSCodesAndRatesListcmbTCode = value;
                OnPropertyChanged("PandSCodesAndRatesListcmbTCode");
            }
        }
        public List<PandSCodesAndRatesListEntity> PandSCodesAndRatesListcmbTRate
        {
            get
            {
                return _PandSCodesAndRatesListcmbTRate;
            }
            set
            {
                _PandSCodesAndRatesListcmbTRate = value;
                OnPropertyChanged("PandSCodesAndRatesListcmbTRate");
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
        public string PSTaxName
        {
            get
            {
                return _PSTaxName;
            }
            set
            {
                _PSTaxName = value;
                OnPropertyChanged("PSTaxName");
            }
        }
        public decimal? PSTaxRate
        {
            get
            {
                return _PSTaxRate;
            }
            set
            {
                _PSTaxRate = value;
                OnPropertyChanged("PSTaxRate");
            }
        }
        #endregion
    }
}
