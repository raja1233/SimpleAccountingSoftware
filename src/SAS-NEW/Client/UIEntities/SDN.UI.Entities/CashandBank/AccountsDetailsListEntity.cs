using System;
using System.Collections.Generic;
using SDN.Common;

namespace SDN.UI.Entities.CashandBank
{
    public class AccountsDetailsListEntity : ViewModelBase
    {
        #region "Private Members"

        private int _ID;
        private string _AccountType;
        private string _isInactive;
        private string _AccountName;
        private string _OpeningBalance;
        private string _YearToDate;
        private string _YearToDateStr;
        private string _CurrentBalanceStr;
        private string _CurrentBalance;
        private string  _IsHyperLink;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private string _currencyName;
        private string _currencyCode;
        private int _AccountDetailsGridHeight;
        #endregion

        #region "Public Properties"

        public int AccountDetailsGridHeight
        {
            get
            {
                return _AccountDetailsGridHeight;
            }
            set
            {
                _AccountDetailsGridHeight = value;
                OnPropertyChanged("AccountDetailsGridHeight");
            }
        }
        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }
        public string IsHyperLink
        {
            get { return _IsHyperLink; }
            set
            {
                _IsHyperLink = value;
                
                OnPropertyChanged("NoHyperlink");
            }
        }
        public string AccountType
        {
            get { return _AccountType; }
            set
            {
                _AccountType = value;
                OnPropertyChanged("AccountType");
            }
        }
        public string AccountName
        {
            get { return _AccountName; }
            set
            {
                _AccountName = value;
                OnPropertyChanged("AccountName");
            }
        }

        public string OpeningBalance
        {
            get { return _OpeningBalance; }
            set
            {
                _OpeningBalance = value;
                OnPropertyChanged("OpeningBalance");
            }
        }

        public string YearToDate
        {
            get { return _YearToDate; }
            set
            {
                _YearToDate = value;
                OnPropertyChanged("YearToDate");
            }
        }

        public string CurrentBalance
        {
            get { return _CurrentBalance; }
            set
            {
                _CurrentBalance = value;
                OnPropertyChanged("CurrentBalance");
            }
        }

        public string IsInactive
        {
            get { return _isInactive; }
            set
            {
                _isInactive = value;
                OnPropertyChanged("IsInactive");
            }
        }
        public string YearToDateStr
        {
            get { return _YearToDateStr; }
            set
            {
                _YearToDateStr = value;
                OnPropertyChanged("YearToDateStr");
            }
        }
        public string CurrentBalanceStr
        {
            get { return _CurrentBalanceStr; }
            set
            {
                _CurrentBalanceStr = value;
                OnPropertyChanged("CurrentBalanceStr");
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
        #endregion
    }
}
