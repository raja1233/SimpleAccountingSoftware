using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Export
{
    public class TrailBalance_Details: ViewModelBase
    {
        #region Private Properties
        private string _AccountType;
        private string _AccountName;
        private string _AccountTypeCode;
        private string _DebitBalance;
        private string _CreditBalance;
        #endregion

        #region 
        public string AccountType
        {
            get
            {
                return _AccountType;
            }
            set
            {
                if(_AccountType != value)
                {
                    _AccountType = value;
                    OnPropertyChanged("AccountType");
                }
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
                if (_AccountName != value)
                {
                    _AccountName = value;
                    OnPropertyChanged("AccountName");
                }
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
                if (_AccountTypeCode != value)
                {
                    _AccountTypeCode = value;
                    OnPropertyChanged("AccountTypeCode");
                }
            }
        }
        public string DebitBalance
        {
            get
            {
                return _DebitBalance;
            }
            set
            {
                if (_DebitBalance != value)
                {
                    _DebitBalance = value;
                    OnPropertyChanged("DebitBalance");
                }
            }
        }
        public string CreditBalance
        {
            get
            {
                return _CreditBalance;
            }
            set
            {
                if (_CreditBalance != value)
                {
                    _CreditBalance = value;
                    OnPropertyChanged("CreditBalance");
                }
            }
        }
        #endregion
    }
}
