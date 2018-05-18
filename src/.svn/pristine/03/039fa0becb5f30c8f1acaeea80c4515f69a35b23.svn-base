using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Export
{
    public class Balance_Sheet: ViewModelBase
    {
        #region Private Properties
        private string _AccountType;
        private string _AccountName;
        private decimal _CurrentBalance;
  
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
        public decimal CurrentBalance
        {
            get
            {
                return _CurrentBalance;
            }
            set
            {
                if (_CurrentBalance != value)
                {
                    _CurrentBalance = value;
                    OnPropertyChanged("CurrentBalance");
                }
            }
        }
       
        #endregion
    }
}
