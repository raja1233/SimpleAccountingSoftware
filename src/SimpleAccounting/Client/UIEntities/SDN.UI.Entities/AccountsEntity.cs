namespace SDN.UI.Entities
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
        private int? _AccountType;
        private string _AccuntTypeCode;
        private string isInactive;
        #endregion

        #region Public properties
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
        #endregion
    }
}
