﻿using SASClient.Accounts.Services;
using SDN.Common;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Accounts.ViewModel
{
    public  class JGridViewModel :ViewModelBase
    {
        #region  "private property"
        private int? _ID;
        private string _AccountName;
        private decimal? _Debit;
        private decimal? _Credit;
        private string _DebitStr;
        private string _CreditStr;
        private int? _SelectedAccountID;
        private int _CountQty;
        private IJournalFormRepository journalRepository = new JournalFormRepository();
        private ObservableCollection<JournalFormEntity> _JournalServices;
        private DateTime? _JournalDate;
        private string _JournalDateStr;
        #endregion
        #region "public property"
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
        public DateTime? JournalDate
        {
            get
            {
                return _JournalDate;

            }
            set
            {
                _JournalDate = value;
                OnPropertyChanged("JournalDate");
            }
        }
        public string JournalDateStr
        {
            get
            {
                return _JournalDateStr;

            }
            set
            {
                _JournalDateStr = value;
                OnPropertyChanged("JournalDateStr");
            }
        }

        public int? SelectedAccountID
        {
            get
            {
                return _SelectedAccountID;

            }
            set
            {
                _SelectedAccountID = value;
                OnPropertyChanged("SelectedAccountID");
                GetJournalDetails();
            }
        }
        public string  AccountName
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
        public decimal?  Debit
        {
            get
            {
                return _Debit;

            }
            set
            {
                _Debit = value;
                OnPropertyChanged("Debit");
            }
        }
        public decimal? Credit
        {
            get
            {
                return _Credit;

            }
            set
            {
                _Credit = value;
                OnPropertyChanged("Credit");
            }
        }
        public string  DebitStr
        {
            get
            {
                return _DebitStr;

            }
            set
            {
                _DebitStr = value;
                OnPropertyChanged("DebitStr");
            }
        }
        public string CreditStr
        {
            get
            {
                return _CreditStr;

            }
            set
            {
                _CreditStr = value;
                OnPropertyChanged("CreditStr");
            }
        }
        public ObservableCollection<JournalFormEntity> JournalServices
        {
            get
            {
                return _JournalServices;
            }
            set
            {
                _JournalServices = value;
                OnPropertyChanged("JournalServices");
            }
        }
        public int CountQty
        {
            get
            {
                return _CountQty;
            }
            set
            {
                _CountQty = value;
                OnPropertyChanged("CountQty");
            }
        }
        public void GetJournalDetails()
        {

        }
        public JGridViewModel(IEnumerable<JournalFormEntity> JournalList)
        {

            if (JournalList == null)
            {
                JournalList = journalRepository.GetAccountsListComboList();
            }
            SelectedAccountID = 0;
            JournalServices = new ObservableCollection<JournalFormEntity>(JournalList);
            
        }
        #endregion
    }
}