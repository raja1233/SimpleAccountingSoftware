using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Accounts
{
    public class ProfitAndLossStatementEntity : ViewModelBase
    {
        #region "private property"
        private int _SIGridHeight;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private string _currencyName;
        private string _currencyCode;
        private int? _ID;
        private string _AccountType;
        private string _AccountName;
        private string _CurrentBalanceStr;
        private int? _AccTypeCode;
        private List<ProfitAndLossStatementEntity> _ProfitAndLossEntity;
        #endregion
        #region "public property"

        public List<ProfitAndLossStatementEntity> ProfitAndLossEntity
        {
            get
            {
                return _ProfitAndLossEntity;
            }
            set
            {
                _ProfitAndLossEntity = value;
                OnPropertyChanged("ProfitAndLossEntity");
            }
        }

        public string AccountType
        {
            get
            {
                return _AccountType;
            }
            set
            {
                _AccountType = value;
                OnPropertyChanged("AccountType");
            }
        }
        public string AccountName
        {
            get
            {
                return _AccountName;
            }
            set
            {
                _AccountName = value;
                OnPropertyChanged("AccountName");
            }
        }
        public string CurrentBalanceStr
        {
            get
            {
                return _CurrentBalanceStr;
            }
            set
            {
                _CurrentBalanceStr = value;
                OnPropertyChanged("CurrentBalanceStr");
            }
        }
        private int? ID
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
        private int? AccTypeCode
        {
            get
            {
                return _AccTypeCode;
            }
            set
            {
                _AccTypeCode = value;
                OnPropertyChanged("AccTypeCode");
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
        #endregion
    }
}
