using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Sales
{
    public class SalesTabEntity: ViewModelBase
    {
        #region Private Properties
        private bool? _QuotationTabTrue;
        private bool? _OrderTabTrue;
        private bool? _InvoiceTabTrue;
        private bool? _DebitTabTrue;
        private bool? _PaymentTabTrue;
        #endregion
        #region Public Properties
        public bool? QuotationTabTrue
        {
            get
            {
                return _QuotationTabTrue;
            }
            set
            {
                _QuotationTabTrue = value;
                OnPropertyChanged("QuotationTabTrue");
            }
        }
        public bool? OrderTabTrue
        {
            get
            {
                return _OrderTabTrue;
            }
            set
            {
                _OrderTabTrue = value;
                OnPropertyChanged("OrderTabTrue");
            }
        }
        public bool? InvoiceTabTrue
        {
            get
            {
                return _InvoiceTabTrue;
            }
            set
            {
                _InvoiceTabTrue = value;
                OnPropertyChanged("InvoiceTabTrue");
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
