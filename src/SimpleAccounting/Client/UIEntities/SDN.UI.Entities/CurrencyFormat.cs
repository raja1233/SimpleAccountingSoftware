using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class CurrencyFormat: ViewModelBase
    {
        private string _CurrencyName;
        private string _CurrencyStyle;

        public string CurrencyName
        {
            get
            {
                return _CurrencyName;
            }
            set
            {
                _CurrencyName = value;
                OnPropertyChanged("CurrencyName");
            }
        }
        public string CurrencyStyle
        {
            get
            {
                return _CurrencyStyle;
            }
            set
            {
                _CurrencyStyle = value;
                OnPropertyChanged("_CurrencyStyle");
            }
        }
       
    }
}
