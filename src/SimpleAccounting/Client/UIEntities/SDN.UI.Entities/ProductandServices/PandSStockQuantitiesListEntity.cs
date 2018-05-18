using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.ProductandServices
{
    public class PandSStockQuantitiesListEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private string _PandSCode;
        private string _PandSName;
        private int _Category1Id;
        private string _Category1;
        private int _Category2Id;
        private string _Category2;
        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;
        private bool? _ShowProducts;
        private bool? _ShowServices;
        private bool? _ShowBoth;
        private bool? _ShowIncTaxTrue;
        private bool? _ShowExcTaxTrue;
        private List<PandSStockQuantitiesListEntity> _PandSStockQuantitiesList;
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
        private List<PandSStockQuantitiesListEntity> _PandSStockQuantitiesListcmb;
        private List<PandSStockQuantitiesListEntity> _PandSStockQuantitiesListcmbCode;
        private List<PandSStockQuantitiesListEntity> _PandSStockQuantitiesListcmbCat1;
        private List<PandSStockQuantitiesListEntity> _PandSStockQuantitiesListcmbCat2;
        private int? _GridHeight;
        private string _MinQty;
        private string _QtyInStock;
        private string _ReservedForSales;
        private string _OnPurchaseOrder;
        private string _AvailableForSales;
        private System.Windows.Media.Brush _foregroundColor;
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
        public List<PandSStockQuantitiesListEntity> PandSStockQuantitiesList
        {
            get
            {
                return _PandSStockQuantitiesList;
            }
            set
            {
                _PandSStockQuantitiesList = value;
                OnPropertyChanged("PandSStockQuantitiesList");
            }
        }
        public List<PandSStockQuantitiesListEntity> PandSStockQuantitiesListcmb
        {
            get
            {
                return _PandSStockQuantitiesListcmb;
            }
            set
            {
                _PandSStockQuantitiesListcmb = value;
                OnPropertyChanged("PandSStockQuantitiesListcmb");
            }
        }
        public List<PandSStockQuantitiesListEntity> PandSStockQuantitiesListcmbCode
        {
            get
            {
                return _PandSStockQuantitiesListcmbCode;
            }
            set
            {
                _PandSStockQuantitiesListcmbCode = value;
                OnPropertyChanged("PandSStockQuantitiesListcmbCode");
            }
        }
        public List<PandSStockQuantitiesListEntity> PandSStockQuantitiesListcmbCat1
        {
            get
            {
                return _PandSStockQuantitiesListcmbCat1;
            }
            set
            {
                _PandSStockQuantitiesListcmbCat1 = value;
                OnPropertyChanged("PandSStockQuantitiesListcmbCat1");
            }
        }
        public List<PandSStockQuantitiesListEntity> PandSStockQuantitiesListcmbCat2
        {
            get
            {
                return _PandSStockQuantitiesListcmbCat2;
            }
            set
            {
                _PandSStockQuantitiesListcmbCat2 = value;
                OnPropertyChanged("PandSStockQuantitiesListcmbCat2");
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
        public string MinQty
        {
            get
            {
                //return _MinQty;
                if (_MinQty == null)
                    return this._MinQty;
                else
                {
                    if (_MinQty != "")
                    {
                        var balance = _MinQty.Replace(",", "");
                       
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                       
                            //return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._MinQty;
                }
            }
            set
            {
                _MinQty = value;
                OnPropertyChanged("MinQty");
            }
        }
        public string QtyInStock
        {
            get
            {
                //return _QtyInStock;
                if (_QtyInStock == null)
                    return this._QtyInStock;
                else
                {
                    if (_QtyInStock != "")
                    {
                        var balance = _QtyInStock.Replace(",", "");
                        
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                     
                            //return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._QtyInStock;
                }
            }
            set
            {
                _QtyInStock = value;
                OnPropertyChanged("QtyInStock");
            }
        }
        public string ReservedForSales
        {
            get
            {
                //return _ReservedForSales;
                if (_ReservedForSales == null)
                    return this._ReservedForSales;
                else
                {
                    if (_ReservedForSales != "")
                    {
                        var balance = _ReservedForSales.Replace(",", "");
                       
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                       
                            //return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._ReservedForSales;
                }
            }
            set
            {
                _ReservedForSales = value;
                OnPropertyChanged("ReservedForSales");
            }
        }
        public string OnPurchaseOrder
        {
            get
            {
                //return _OnPurchaseOrder;
                if (_OnPurchaseOrder == null)
                    return this._OnPurchaseOrder;
                else
                {
                    if (_OnPurchaseOrder != "")
                    {
                        var balance = _OnPurchaseOrder.Replace(",", "");
                        return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));

                      //  return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._OnPurchaseOrder;
                }
            }
            set
            {
                _OnPurchaseOrder = value;
                OnPropertyChanged("OnPurchaseOrder");
            }
        }
        public string AvailableForSales
        {
            get
            {
                //return _AvailableForSales;
                if (_AvailableForSales == null)
                    return this._AvailableForSales;
                else
                {
                    if (_AvailableForSales != "")
                    {
                        var balance = _AvailableForSales.Replace(",", "");
                        return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this._AvailableForSales;
                }
            }
            set
            {
                _AvailableForSales = value;
                OnPropertyChanged("AvailableForSales");
            }
        }
        public System.Windows.Media.Brush ForegroundColor
        {
            get { return _foregroundColor; }
            set
            {
                _foregroundColor = value;
                OnPropertyChanged("ForegroundColor");
            }
        }
        #endregion
    }
}
