using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Export
{
    public class ProductandServiceStockQuantitiesListEntity : ViewModelBase
    {
        #region Private Properties
        
        private string _PandSCode;
        private string _PandSName;
        private string _Category1;
        private string _Category2;
        private string _MinQty;
        private string _QtyInStock;
        private string _ReservedForSales;
        private string _OnPurchaseOrder;
        private string _AvailableForSales;
        #endregion
        #region Public Properties
     
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
      
        #endregion
    }
}
