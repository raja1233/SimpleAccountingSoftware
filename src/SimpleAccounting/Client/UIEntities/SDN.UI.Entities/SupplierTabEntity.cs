using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class SupplierTabEntity : ViewModelBase
    {
        #region Private Properties
        private bool? _SupplierDetailTabTrue;
        private bool? _SupplierHistoryTrue;
        private bool? _TopSuppliersTabTrue;
        private bool? _DebitTabTrue;
        private bool? _PaymentTabTrue;
        #endregion
        #region Public Properties
        public bool? SupplierDetailTabTrue
        {
            get
            {
                return _SupplierDetailTabTrue;
            }
            set
            {
                _SupplierDetailTabTrue = value;
                OnPropertyChanged("SupplierDetailTabTrue");
            }
        }
        public bool? SupplierHistoryTrue
        {
            get
            {
                return _SupplierHistoryTrue;
            }
            set
            {
                _SupplierHistoryTrue = value;
                OnPropertyChanged("SupplierHistoryTrue");
            }
        }
        public bool? TopSuppliersTabTrue
        {
            get
            {
                return _TopSuppliersTabTrue;
            }
            set
            {
                _TopSuppliersTabTrue = value;
                OnPropertyChanged("TopSuppliersTabTrue");
            }
        }
        public bool? DebitTabTrue
        {
            get
            {
                return _DebitTabTrue;
            }
            set
            {
                _DebitTabTrue = value;
                OnPropertyChanged("DebitTabTrue");
            }
        }
        public bool? PaymentTabTrue
        {
            get
            {
                return _PaymentTabTrue;
            }
            set
            {
                _PaymentTabTrue = value;
                OnPropertyChanged("PaymentTabTrue");
            }
        }
        #endregion
    }
}
