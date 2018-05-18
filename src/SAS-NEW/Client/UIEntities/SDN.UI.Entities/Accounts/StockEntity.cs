using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Accounts
{
    public class StockEntity : ViewModelBase
    {
        #region "private property"
        private int _SIGridHeight;
        private int? _ID;
        private string _ProductCode;
        private string _ProductName;
        private int? _QtyInStock;
        private decimal? _AverageCost;
        private decimal? _Amount;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private string _currencyName;
        private string _currencyCode;
        //private List<StockEntity> _StockList;

        #endregion
        #region "public property"
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
        public string DateFormat
        {
            get { return _DateFormat; }
            set { SetProperty(ref _DateFormat, value, "DateFormat"); }
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
        public int? ID
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
        //public List<StockEntity> StockList
        //{
        //    get { return _StockList; }
        //    set
        //    {
        //        if (_StockList != value)
        //        {
        //            _StockList = value;
        //            OnPropertyChanged("StockList");
        //        }
        //    }
        //}
        public string ProductCode
        {
            get
            {
                return _ProductCode;
            }
            set
            {
                _ProductCode = value;
                OnPropertyChanged("ProductCode");
            }
        }
        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
                OnPropertyChanged("ProductName");
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
        public decimal? AverageCost
        {
            get
            {
                return _AverageCost;
            }
            set
            {
                _AverageCost = value;
                OnPropertyChanged("AverageCost");
            }
        }
        public decimal? Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
                OnPropertyChanged("Amount");
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
        #endregion
    }
 
    public class StockModel : ViewModelBase
    {
        #region "Private members"
        private StockEntity _StockData;
        private List<StockEntity> _StockDetailsData;
        #endregion

        #region "Properties"

        public StockEntity StockData
        {
            get { return _StockData; }
            set
            {
                _StockData = value;
                OnPropertyChanged("StockData");
            }
        }

        public List<StockEntity> StockDetailsData
        {
            get { return _StockDetailsData; }
            set
            {
                _StockDetailsData = value;
                OnPropertyChanged("StockDetailsData");
            }
        }

        #endregion
    }
}
