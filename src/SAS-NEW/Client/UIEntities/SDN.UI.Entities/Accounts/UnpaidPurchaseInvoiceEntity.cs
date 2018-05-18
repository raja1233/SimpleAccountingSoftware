using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Accounts
{
    public class UnpaidPurchaseInvoiceEntity : ViewModelBase
    {
        #region private property
        private int _SIGridHeight;
        private int? _ID;
        private string _SupplierName;
        private string _InvoiceNo;
        private string _InvoiceDate;
        private DateTime? _InvoiceDateTime;
        private decimal? _UnpaidAmount;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private string _currencyName;
        private string _currencyCode;
        private List<UnpaidPurchaseInvoiceEntity> _SupplierList;
        #endregion
        #region public property
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
        public List<UnpaidPurchaseInvoiceEntity> SupplierList
        {
            get
            {
                return _SupplierList;
            }
            set
            {
                _SupplierList = value;
                OnPropertyChanged("SupplierList");
            }
        }
        public string SupplierName
        {
            get
            {
                return _SupplierName;
            }
            set
            {
                _SupplierName = value;
                OnPropertyChanged("SupplierName");
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
        public DateTime? InvoiceDateTime
        {
            get
            {
                return _InvoiceDateTime;
            }
            set
            {
                _InvoiceDateTime = value;
                OnPropertyChanged("InvoiceDateTime");
            }
        }
        public decimal? UnpaidAmount
        {
            get
            {
                return _UnpaidAmount;
            }
            set
            {
                _UnpaidAmount = value;
                OnPropertyChanged("UnpaidAmount");
            }
        }
        #endregion
        #region constructor property

        #endregion
        #region public property

        #endregion
    }
    public class UnpaidPurchaseInvoiceModel : ViewModelBase
    {
        #region "Private members"
        private UnpaidPurchaseInvoiceEntity _UnpaidPurchaseInvoiceData;
        private List<UnpaidPurchaseInvoiceEntity> _UnpaidPurchaseInvoiceDetailsData;
        #endregion

        #region "Properties"

        public UnpaidPurchaseInvoiceEntity UnpaidPurchaseInvoiceData
        {
            get { return _UnpaidPurchaseInvoiceData; }
            set
            {
                _UnpaidPurchaseInvoiceData = value;
                OnPropertyChanged("UnpaidPurchaseInvoiceData");
            }
        }

        public List<UnpaidPurchaseInvoiceEntity> UnpaidPurchaseInvoiceDetailsData
        {
            get { return _UnpaidPurchaseInvoiceDetailsData; }
            set
            {
                _UnpaidPurchaseInvoiceDetailsData = value;
                OnPropertyChanged("UnpaidPurchaseInvoiceDetailsData");
            }
        }

        #endregion
    }
}
