using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Accounts
{
    public class UnpaidSalesInvoiceEntity :ViewModelBase
    {
        #region private property
        private int _SIGridHeight;
        private int? _ID;
        private string _CustomerName;
        private string _InvoiceNo;
        private string _InvoiceDate;
        private DateTime? _InvoiceDateTime;
        private string _InvoiceDateStr;
        private decimal? _UnpaidAmount;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private string _currencyName;
        private string _currencyCode;
        private List<UnpaidSalesInvoiceEntity> _CustomerList;
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
        public List<UnpaidSalesInvoiceEntity> CustomerList
        {
            get
            {
                return _CustomerList;
            }
            set
            {
                _CustomerList = value;
                OnPropertyChanged("CustomerList");
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
        public string InvoiceNo
        {
            get
            {
                return _InvoiceNo;
            }
            set
            {
               _InvoiceNo   = value;
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
        public string InvoiceDateStr
        {
            get
            {
                return _InvoiceDateStr;
            }
            set
            {
                _InvoiceDateStr = value;
                OnPropertyChanged("InvoiceDateStr");
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
    public class UnpaidSalesInvoiceModel : ViewModelBase
    {
        #region "Private members"
        private UnpaidSalesInvoiceEntity _UnpaidSalesInvoiceData;
        private List<UnpaidSalesInvoiceEntity> _UnpaidSalesInvoiceDetailsData;
        #endregion

        #region "Properties"

        public UnpaidSalesInvoiceEntity UnpaidSalesInvoiceData
        {
            get { return _UnpaidSalesInvoiceData; }
            set
            {
                _UnpaidSalesInvoiceData = value;
                OnPropertyChanged("UnpaidSalesInvoiceData");
            }
        }

        public List<UnpaidSalesInvoiceEntity> UnpaidSalesInvoiceDetailsData
        {
            get { return _UnpaidSalesInvoiceDetailsData; }
            set
            {
                _UnpaidSalesInvoiceDetailsData = value;
                OnPropertyChanged("UnpaidSalesInvoiceDetailsData");
            }
        }

        #endregion
    }
}
