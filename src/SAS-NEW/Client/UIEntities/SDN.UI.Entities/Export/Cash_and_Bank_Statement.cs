using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Export
{
    public class Cash_and_Bank_Statement:ViewModelBase
    {
        #region private entity


        private int _CashBankAccountID;
        private string _TransactionType;
        private string _Name;
        private string _ChequeNo;
        private string _CDate;
        //private DateTime _ODate;
        private string _DepositStr;
        private string _WithdrawalStr;
        private string _BalanceStr;
        private decimal _Balance;
        private int? _ID;
        private int _CashBankIdentityID;
        private bool? _NoHyperLink;
        
       
        #endregion
        #region public entity
       
        public bool? NoHyperLink
        {
            get { return _NoHyperLink; }
            set
            {
                _NoHyperLink = value;
                // OnPropertyChanged("InvoiceNo");
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
        //public DateTime ODate
        //{
        //    get
        //    {
        //        return _ODate;
        //    }
        //    set
        //    {
        //        _ODate = value;
        //        OnPropertyChanged("ODate");
        //    }
        //}
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
      
        #endregion
    }
}
