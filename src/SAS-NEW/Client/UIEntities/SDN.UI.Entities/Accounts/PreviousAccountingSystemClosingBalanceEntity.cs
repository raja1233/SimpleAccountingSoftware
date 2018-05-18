using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Accounts
{
    public class PreviousAccountingSystemClosingBalanceEntity :ViewModelBase
    {
        #region "private property"
        private int _SIGridHeight;
        #endregion
        #region "public property"
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
        #endregion
    }
}
