using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Export
{
    public class ProductandServiceSoldEntity : ViewModelBase
    {
        #region Private Properties

        private string _PandSCode;
        private string _PandSName;
        private string _CustomerName;
        private string _PriceStr;
        private string _AmountStr;
        private string _InvoiceDate;
        private string _InvoiceNo;
        private int? _Qty;
   
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
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
                OnPropertyChanged("CustomerName");
            }
        }
      
        
        public string PriceStr
        {
            get
            {
                //return _PriceStr;
                if (_PriceStr == null)
                    return this._PriceStr;
                else
                {
                    if (_PriceStr != "")
                    {
                        var balance = _PriceStr.Replace(",", "");
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
                        return this._PriceStr;
                }
            }
            set
            {
                _PriceStr = value;
                OnPropertyChanged("PriceStr");
            }
        }
      
        public string AmountStr
        {
            get
            {
                //return _AmountStr;
                if (_AmountStr == null)
                    return this._AmountStr;
                else
                {
                    if (_AmountStr != "")
                    {
                        var balance = _AmountStr.Replace(",", "");
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
                        return this._AmountStr;
                }
            }
            set
            {
                _AmountStr = value;
                OnPropertyChanged("AmountStr");
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
       
        public int? Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                _Qty = value;
                OnPropertyChanged("Qty");
            }
        }
        
       
        #endregion
    }
}
