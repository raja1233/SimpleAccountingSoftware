using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Accounts
{
    public class UndeliveredPurchaseOrdersDepositsEntity : ViewModelBase
    {
        #region private property
        private int _SIGridHeight;
        private int? _ID;
        private string _SupplierName;
        private string _OrderNo;
        private string _OrderDate;
        private DateTime? _OrderDateTime;
        private decimal? _UndeliveredAmount;
        private decimal? _DepositAmount;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private string _currencyName;
        private string _currencyCode;
        private List<UndeliveredPurchaseOrdersDepositsEntity> _SupplierList;
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
        public List<UndeliveredPurchaseOrdersDepositsEntity> SupplierList
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
        public string OrderNo
        {
            get
            {
                return _OrderNo;
            }
            set
            {
                _OrderNo = value;
                OnPropertyChanged("OrderNo");
            }
        }

        public string OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
                OnPropertyChanged("OrderDate");
            }
        }
        public DateTime? OrderDateTime
        {
            get
            {
                return _OrderDateTime;
            }
            set
            {
                _OrderDateTime = value;
                OnPropertyChanged("OrderDateTime");
            }
        }
        public decimal? UndeliveredAmount
        {
            get
            {
                return _UndeliveredAmount;
            }
            set
            {
                _UndeliveredAmount = value;
                OnPropertyChanged("UndeliveredAmount");
            }
        }
        public decimal? DepositAmount
        {
            get
            {
                return _DepositAmount;
            }
            set
            {
                _DepositAmount = value;
                OnPropertyChanged("DepositAmount");
            }
        }
        #endregion
        #region constructor property

        #endregion
        #region public property

        #endregion
    }
    public class UndeliveredPurchaseOrdersDepositsModel : ViewModelBase
    {
        #region "Private members"
        private UndeliveredPurchaseOrdersDepositsEntity _UndeliveredPurchaseOrdersDepositsData;
        private List<UndeliveredPurchaseOrdersDepositsEntity> _UndeliveredPurchaseOrdersDepositsDetailsData;
        #endregion

        #region "Properties"

        public UndeliveredPurchaseOrdersDepositsEntity UndeliveredPurchaseOrdersDepositsData
        {
            get { return _UndeliveredPurchaseOrdersDepositsData; }
            set
            {
                _UndeliveredPurchaseOrdersDepositsData = value;
                OnPropertyChanged("UndeliveredPurchaseOrdersDepositsData");
            }
        }

        public List<UndeliveredPurchaseOrdersDepositsEntity> UndeliveredPurchaseOrdersDepositsDetailsData
        {
            get { return _UndeliveredPurchaseOrdersDepositsDetailsData; }
            set
            {
                _UndeliveredPurchaseOrdersDepositsDetailsData = value;
                OnPropertyChanged("UndeliveredPurchaseOrdersDepositsDetailsData");
            }
        }

        #endregion
    }
}
