using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Export
{
    public class Profit_and_Loss_Detail : ViewModelBase
    {
        #region Private Properties
        private string _AccountType;
        private string _AccountName;
        private int _AccTypeCode;
        private string _CurrentBalanceStr;
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
                if (_AccountType != value)
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
        public int AccTypeCode
        {
            get
            {
                return _AccTypeCode;
            }
            set
            {
                if (_AccTypeCode != value)
                {
                    _AccTypeCode = value;
                    OnPropertyChanged("AccTypeCode");
                }
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
                if (_CurrentBalanceStr != value)
                {
                    _CurrentBalanceStr = value;
                    OnPropertyChanged("CurrentBalanceStr");
                }
            }
        }
        #endregion
    }
}
