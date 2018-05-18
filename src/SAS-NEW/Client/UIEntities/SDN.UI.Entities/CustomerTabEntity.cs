using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class CustomerTabEntity : ViewModelBase
    {
        #region Private Properties
        private bool? _CustomerDetailTabTrue;
        private bool? _CustomerHistoryTrue;
        private bool? _InvoiceTabTrue;
        private bool? _PandSSoldToCustomersTabTrue;
        private bool? _PaymentTabTrue;
        private bool? _TopCustomersTabTrue;
        private bool? _CustomerStatementTrue;
        private bool? _UnpaidInvoice;
        private bool? _CreditPaidDays;
        private bool? _CustomerDetailList1;
        private bool? _CustomerDetailList2;
        private bool? _CustomerDetailList3;
        private bool? _CustomerDetailList4;
        #endregion
        #region Public Properties
        public bool? CustomerDetailList1
        {
            get
            {
                return _CustomerDetailList1;
            }
            set
            {
                _CustomerDetailList1 = value;
                OnPropertyChanged("CustomerDetailList1");
            }
        }
        public bool? CustomerDetailList2
        {
            get
            {
                return _CustomerDetailList2;
            }
            set
            {
                _CustomerDetailList2 = value;
                OnPropertyChanged("CustomerDetailList2");
            }
        }
        public bool? CustomerDetailList3
        {
            get
            {
                return _CustomerDetailList3;
            }
            set
            {
                _CustomerDetailList3 = value;
                OnPropertyChanged("CustomerDetailList3");
            }
        }
        public bool? CustomerDetailList4
        {
            get
            {
                return _CustomerDetailList4;
            }
            set
            {
                _CustomerDetailList4 = value;
                OnPropertyChanged("CustomerDetailList4");
            }
        }
        public bool? CustomerDetailTabTrue
        {
            get
            {
                return _CustomerDetailTabTrue;
            }
            set
            {
                _CustomerDetailTabTrue = value;
                OnPropertyChanged("CustomerDetailTabTrue");
            }
        }
        public bool? CustomerHistoryTrue
        {
            get
            {
                return _CustomerHistoryTrue;
            }
            set
            {
                _CustomerHistoryTrue = value;
                OnPropertyChanged("CustomerHistoryTrue");
            }
        }
        public bool? CustomerStatementTrue
        {
            get
            {
                return _CustomerStatementTrue;
            }
            set
            {
                _CustomerStatementTrue = value;
                OnPropertyChanged("CustomerStatementTrue");
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
        public bool? PandSSoldToCustomersTabTrue
        {
            get
            {
                return _PandSSoldToCustomersTabTrue;
            }
            set
            {
                _PandSSoldToCustomersTabTrue = value;
                OnPropertyChanged("PandSSoldToCustomersTabTrue");
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
        public bool? UnpaidInvoice
        {
            get
            {
                return _UnpaidInvoice;
            }
            set
            {
                _UnpaidInvoice = value;
                OnPropertyChanged("UnpaidInvoice");
            }
        }
        public bool? CreditPaidDays
        {
            get
            {
                return _CreditPaidDays;
            }
            set
            {
                _CreditPaidDays = value;
                OnPropertyChanged("CreditPaidDays");
            }
        }

        public bool? TopCustomersTabTrue
        {
            get { return _TopCustomersTabTrue; }
            set
            {
                _TopCustomersTabTrue = value;
                OnPropertyChanged("TopCustomersTabTrue");
            }
        }
        #endregion
    }
}
