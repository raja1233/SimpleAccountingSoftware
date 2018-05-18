﻿using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Accounts
{
    public class TrailBalanceEntity: ViewModelBase
    {
        #region
        private int _SIGridHeight;
        private List<TrailBalanceEntity> _dataList;
        private int _ID;
        private string _AccountName;
        private decimal? _CreditBalance;
        private decimal? _DebitBalance;
        private string _JournalDate;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private string _currencyName;
        private string _currencyCode;
        private string totalDebitAmount;
        private string totalCreditAmount;
        private string _AccountTypeCode;
        private string _AccountType;
     
        private string _DebitBalanceStr;
        private string _CreditBalanceStr;
        private int _AccountsOrder;
        #endregion
        public int AccountsOrder
        {
            get
            {
                return _AccountsOrder;
            }
            set
            {
                _AccountsOrder = value;
                OnPropertyChanged("AccountsOrder");
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
        public string AccountTypeCode
        {
            get
            {
                return _AccountTypeCode;
            }
            set
            {
                _AccountTypeCode = value;
                OnPropertyChanged("AccountTypeCode");
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
        public string TotalDebitAmount
        {
            get
            {
                //return _QuotationAmount;
                if (totalDebitAmount == null)
                    return this.totalDebitAmount;
                else
                {
                    if (totalDebitAmount != "")
                    {
                        var balance = totalDebitAmount.Replace(",", "");
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
                        return this.totalDebitAmount;
                }
            }
            set
            {
                totalDebitAmount = value;
                OnPropertyChanged("TotalDebitAmount");
            }
        }
        public string TotalCreditAmount
        {
            get
            {
                //return _QuotationAmount;
                if (totalCreditAmount == null)
                    return this.totalCreditAmount;
                else
                {
                    if (totalCreditAmount != "")
                    {
                        var balance = totalCreditAmount.Replace(",", "");
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
                        return this.totalCreditAmount;
                }
            }
            set
            {
                totalCreditAmount = value;
                OnPropertyChanged("totalCreditAmount");
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
        public List<TrailBalanceEntity> DataList
        {
            get
            {
                return _dataList;

            }
            set
            {
                _dataList = value;
                OnPropertyChanged("DataList");

            }
        }
        
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
      
        public decimal? CreditBalance
        {
            get
            {
                return _CreditBalance;
            }
            set
            {
                _CreditBalance = value;
                OnPropertyChanged("CreditBalance");
            }
        }
        public decimal? DebitBalance
        {
            get
            {
                return _DebitBalance;
            }
            set
            {
                _DebitBalance = value;
                OnPropertyChanged("DebitBalance");
            }
        }
      
        public string  DebitBalanceStr
        {
            get
            {
                return _DebitBalanceStr;
            }
            set
            {
                _DebitBalanceStr = value;
                OnPropertyChanged("DebitBalanceStr");
            }
        }
        public string CreditBalanceStr
        {
            get
            {
                return _CreditBalanceStr;
            }
            set
            {
                _CreditBalanceStr = value;
                OnPropertyChanged("CreditBalanceStr");
            }
        }
    }
}