
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    using SDN.Common;
    public class SettingsTabEntity: ViewModelBase
    {
        #region Private Properties
        private bool? _CompanyDetailsTabTrue;
        private bool? _CategoryTabTrue;
        private bool? _OptionsTabTrue;
        private bool? _CodesandRatesTabTrue;
        private bool? _UsersandSecurityTabTrue;
        #endregion
        #region Public Properties
        public bool? CompanyDetailsTabTrue
        {
            get
            {
                return _CompanyDetailsTabTrue;
            }
            set
            {
                _CompanyDetailsTabTrue = value;
                OnPropertyChanged("CompanyDetailsTabTrue");
            }
        }
        public bool? CategoryTabTrue
        {
            get
            {
                return _CategoryTabTrue;
            }
            set
            {
                _CategoryTabTrue = value;
                OnPropertyChanged("CategoryTabTrue");
            }
        }
        public bool? OptionsTabTrue
        {
            get
            {
                return _OptionsTabTrue;
            }
            set
            {
                _OptionsTabTrue = value;
                OnPropertyChanged("OptionsTabTrue");
            }
        }
        public bool? CodesandRatesTabTrue
        {
            get
            {
                return _CodesandRatesTabTrue;
            }
            set
            {
                _CodesandRatesTabTrue = value;
                OnPropertyChanged("CodesandRatesTabTrue");
            }
        }
        public bool? UsersandSecurityTabTrue
        {
            get
            {
                return _UsersandSecurityTabTrue;
            }
            set
            {
                _UsersandSecurityTabTrue = value;
                OnPropertyChanged("UsersandSecurityTabTrue");
            }
        }
        #endregion
    }
}
