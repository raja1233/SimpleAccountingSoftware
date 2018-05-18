using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Common.Model
{
   public  class CashAndBankTabEntity:ViewModelBase
    {
        #region Private Properties
        private bool? _refundFromSupplierTabTrue;
        private bool? _refundToCustomerTabTrue;

        #endregion
        #region Public Properties
        public bool? RefundFromSupplierTabTrue
        {
            get
            {
                return _refundFromSupplierTabTrue;
            }
            set
            {
                _refundFromSupplierTabTrue = value;
                OnPropertyChanged("RefundFromSupplierTabTrue");
            }
        }
        public bool? RefundToCustomerTabTrue
        {
            get
            {
                return _refundToCustomerTabTrue;
            }
            set
            {
                _refundToCustomerTabTrue = value;
                OnPropertyChanged("RefundToCustomerTabTrue");
            }
        }

        #endregion
    }
}
