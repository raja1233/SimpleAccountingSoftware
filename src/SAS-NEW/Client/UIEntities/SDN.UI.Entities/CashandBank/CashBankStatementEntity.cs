﻿using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.CashandBank
{
    public class CashBankStatementEntity : ViewModelBase
    {
        #region private entity
        private int _SIGridHeight;
        private bool? _EnableYearDropDown;
        private bool? _EnableQuarterDropDown;
        private bool? _EnableMonthDropDown;
        private int _CashBankAccountID;
        private string _CashBankAccountName;
        private string _TransactionType;
        private string _Name;
        private string _ChequeNo;
        private string _CDate;
        private string _DepositStr;
        private string _WithdrawalStr;
        private string _BalanceStr;
        private decimal _Balance;
        private bool isSelected;
        private string _JsonData;
        private int? _ID;
        private int _Index;
        private int _CashBankIdentityID;
        private string _SelectedSearchYear;
        private string _SelectedSearchQuarter;
        private string _SelectedSearchMonth;
        private bool? _ShowSelectedTrue;
        private bool? _YearmonthQuartTrue;
        private string selectedName;
        private List<YearEntity> _YearRange;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private string _currencyName;
        private string _currencyCode;
        private bool? _NoHyperLink;
        private List<CashBankStatementEntity> _CashBankStatementSearchList;
        private bool _IsChecked;
        private List<CashBankStatementEntity> _CashBankStatementcmb;
        private List<CashBankStatementEntity> _CashBankStatementList;
        private List<CashBankStatementEntity> _CashBankStatementDetailList;
        private List<CashBankStatementEntity> _StockCardListcmbTranType;
        private string _SelectedTransactionType;
        #endregion
        #region public entity
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
        public bool? NoHyperLink
        {
            get { return _NoHyperLink; }
            set
            {
                _NoHyperLink = value;
                // OnPropertyChanged("InvoiceNo");
            }
        }
        public List<CashBankStatementEntity> StockCardListcmbTranType
        {
            get { return _StockCardListcmbTranType; }
            set
            {
                if (_StockCardListcmbTranType != value)
                {
                    _StockCardListcmbTranType = value;
                    OnPropertyChanged("StockCardListcmbTranType");
                }
            }
        }
        public string SelectedTransactionType
        {
            get { return _SelectedTransactionType; }
            set
            {
                _SelectedTransactionType = value;
                OnPropertyChanged("SelectedTransactionType");
            }
        }
        public bool? EnableYearDropDown
        {
            get
            {
                return _EnableYearDropDown;
            }
            set
            {
                _EnableYearDropDown = value;
                OnPropertyChanged("EnableYearDropDown");
            }
        }
        public string SelectedName
        {
            get { return selectedName; }
            set
            {
                selectedName = value;
                OnPropertyChanged("SelectedName");
            }
        }
        public bool? EnableQuarterDropDown
        {
            get
            {
                return _EnableQuarterDropDown;
            }
            set
            {
                _EnableQuarterDropDown = value;
                OnPropertyChanged("EnableQuarterDropDown");
            }
        }
        public string JsonData
        {
            get
            {
                return _JsonData;
            }
            set
            {
                _JsonData = value;
                OnPropertyChanged("JsonData");
            }
        }
        public bool IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                _IsChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        public List<CashBankStatementEntity> CashBankStatementSearchList
        {
            get { return _CashBankStatementSearchList; }
            set
            {
                if (_CashBankStatementSearchList != value)
                {
                    _CashBankStatementSearchList = value;
                    OnPropertyChanged("CashBankStatementSearchList");
                }
            }
        }
        //public string SelectedName
        //{
        //    get
        //    {
        //        return _SelectedName;
        //    }
        //    set
        //    {
        //        _SelectedName = value;
        //        OnPropertyChanged("SelectedName");
        //    }
        //}
        //public int Index
        //{
        //    get
        //    {
        //        return _Index;
        //    }

        //    set
        //    {
        //        _Index = value;
        //        OnPropertyChanged("Index");
        //    }
        //}
        public bool? EnableMonthDropDown
        {
            get
            {
                return _EnableMonthDropDown;
            }
            set
            {
                _EnableMonthDropDown = value;
                OnPropertyChanged("EnableMonthDropDown");
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
        public decimal Balance
        {
            get
            {
                return _Balance;
            }
            set
            {
                _Balance = value;
                OnPropertyChanged("Balance");
            }
        }
        public List<CashBankStatementEntity> CashBankStatementcmb
        {
            get { return _CashBankStatementcmb; }
            set
            {
                if (_CashBankStatementcmb != value)
                {
                    _CashBankStatementcmb = value;
                    OnPropertyChanged("CashBankStatementcmb");
                }
            }
        }
        public bool? YearmonthQuartTrue
        {
            get
            {
                return _YearmonthQuartTrue;
            }
            set
            {
                _YearmonthQuartTrue = value;
                if (_YearmonthQuartTrue == true)
                {
                    //SelectedSearchStartDate = null;
                    //SelectedSearchEndDate = null;
                    //EnableEndDropDown = false;
                    //EnableStartDropDown = false;
                    EnableMonthDropDown = true;
                    EnableQuarterDropDown = true;
                    EnableYearDropDown = true;

                }

                OnPropertyChanged("YearmonthQuartTrue");
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
        public int CashBankIdentityID
        {
            get
            {
                return _CashBankIdentityID;
            }
            set
            {
                _CashBankIdentityID = value;
                OnPropertyChanged("CashBankIdentityID");
            }
        }
        public int CashBankAccountID
        {
            get
            {
                return _CashBankAccountID;
            }
            set
            {
                _CashBankAccountID = value;
                OnPropertyChanged("CashBankAccountID");
            }
        }
        public string CashBankAccountName
        {
            get
            {
                return _CashBankAccountName;
            }
            set
            {
                _CashBankAccountName = value;
                OnPropertyChanged("CashBankAccountName");
            }
        }
        public string TransactionType
        {
            get
            {
                return _TransactionType;
            }
            set
            {
                _TransactionType = value;
                OnPropertyChanged("TransactionType");
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string CDate
        {
            get
            {
                return _CDate;
            }
            set
            {
                _CDate = value;
                OnPropertyChanged("CDate");
            }
        }
        public string ChequeNo
        {
            get
            {
                return _ChequeNo;
            }
            set
            {
                _ChequeNo = value;
                OnPropertyChanged("ChequeNo");
            }
        }
        public string DepositStr
        {
            get
            {
                return _DepositStr;
            }
            set
            {
                _DepositStr = value;
                OnPropertyChanged("DepositStr");
            }
        }
        public string WithdrawalStr
        {
            get
            {
                return _WithdrawalStr;
            }
            set
            {
                _WithdrawalStr = value;
                OnPropertyChanged("WithdrawalStr");
            }
        }
        public List<YearEntity> YearRange
        {
            get
            {
                return _YearRange;
            }
            set
            {
                _YearRange = value;
                OnPropertyChanged("YearRange");
            }
        }
        public string SelectedSearchYear
        {
            get
            {
                return _SelectedSearchYear;
            }
            set
            {
                _SelectedSearchYear = value;
                OnPropertyChanged("SelectedSearchYear");
            }
        }
        public string SelectedSearchQuarter
        {
            get
            {
                return _SelectedSearchQuarter;
            }
            set
            {
                _SelectedSearchQuarter = value;
                //if (_SelectedSearchQuarter != null)
                //SelectedSearchMonth = null;
                OnPropertyChanged("SelectedSearchQuarter");
            }
        }
        public string SelectedSearchMonth
        {
            get
            {
                return _SelectedSearchMonth;
            }
            set
            {
                _SelectedSearchMonth = value;
                if (_SelectedSearchMonth != null)
                    SelectedSearchQuarter = null;
                OnPropertyChanged("SelectedSearchMonth");
            }
        }
        public string BalanceStr
        {
            get
            {
                return _BalanceStr;
            }
            set
            {
                _BalanceStr = value;
                OnPropertyChanged("BalanceStr");
            }
        }
        public List<CashBankStatementEntity> CashBankStatementList
        {
            get { return _CashBankStatementList; }
            set
            {
                if (_CashBankStatementList != value)
                {
                    _CashBankStatementList = value;
                    OnPropertyChanged("CashBankStatementList");
                }
            }
        }
        public List<CashBankStatementEntity> CashBankStatementDetailList
        {
            get { return _CashBankStatementDetailList; }
            set
            {

                _CashBankStatementDetailList = value;
                OnPropertyChanged("CashBankStatementDetailList");

            }
        }
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        #endregion
    }
}
