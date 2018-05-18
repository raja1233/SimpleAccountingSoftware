﻿namespace SDN.UI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountsEntity:BaseEntity
    {
        #region Private Properties
        private int _AccountID;
        private string _AccountName;
        private string _AccountTypeName;
        private int? _AccountType;
        private string _AccuntTypeCode;
        private decimal? _OpeningBalance;
        private decimal? _CurrentBalance;
        private string isInactive;
        private bool? isLinked;
        private bool? _IsActive;
        private string _HashSymbol;
        private string _FinancialYearMessage;
        private int _AccountsOrder;
        #endregion

        #region Public properties
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
        public string FinancialYearMessage
        {
            get
            {
                return _FinancialYearMessage;
            }
            set
            {
                _FinancialYearMessage = value;
                OnPropertyChanged("FinancialYearMessage");
            }
        }
        public string HashSymbol
        {
            get
            {
                return _HashSymbol;
            }
            set
            {
                _HashSymbol = value;
                OnPropertyChanged("HashSymbol");
            }
        }
        public int AccountID
        {
            get
            {
                return _AccountID;
            }
            set
            {
                _AccountID = value;
                OnPropertyChanged("AccountID");
            }
        }
        public bool? IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
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
        public string AccountTypeName
        {
            get
            {
                return _AccountTypeName;
            }
            set
            {
                _AccountTypeName = value;
                OnPropertyChanged("AccountTypeName");
            }
        }
        public string AccuntTypeCode
        {
            get
            {
                return _AccuntTypeCode;
            }
            set
            {
                _AccuntTypeCode = value;
                OnPropertyChanged("AccuntTypeCode");
            }
        }
        public int? AccountType
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

        public decimal? OpeningBalance
        {
            get { return _OpeningBalance; }
            set { _OpeningBalance = value;
                OnPropertyChanged("OpeningBalance");
            }
        }
        public decimal? CurrentBalance
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
            get
            {
                return isInactive;
            }
            set
            {
                isInactive = value;
                OnPropertyChanged("IsInactive");
            }
        }

        public bool? IsLinked
        {
            get { return isLinked; }
            set
            {
                isLinked = value;
                OnPropertyChanged("IsLinked");
            }
        }
        #endregion
    }
}
