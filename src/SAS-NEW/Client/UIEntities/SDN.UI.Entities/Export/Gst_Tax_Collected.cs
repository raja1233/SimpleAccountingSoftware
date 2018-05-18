using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Export
{
    public class Gst_Tax_Collected: ViewModelBase
    {
        #region Private Properties
        private string _TaxDescriptionC;
        private string _TaxCodeC;
        private string _TaxRateC;
        private int? _ID;
        private decimal? _TaxInvoiceAmountC;
        private decimal? _TaxCollectedC;
        private string _CustomersName;
        private string _TaxInvoiceNoC;
        private string _TaxDateC;
        private string _TaxInvoiceAmountStrC;
        private string _TaxCollectedStrC;

        #endregion
        #region
        public string TaxDescriptionC
        {
            get
            {
                return _TaxDescriptionC;
            }
            set
            {
                _TaxDescriptionC = value;
                OnPropertyChanged("TaxDescriptionC");
            }
        }
        public string TaxCodeC
        {
            get
            {
                return _TaxCodeC;
            }
            set
            {
                _TaxCodeC = value;
                OnPropertyChanged("TaxCodeC");
            }
        }
        public string TaxRateC
        {
            get
            {
                return _TaxRateC;
            }
            set
            {
                _TaxRateC = value;
                OnPropertyChanged("TaxRateC");
            }
        }
        public decimal? TaxInvoiceAmountC
        {
            get
            {
                return _TaxInvoiceAmountC;
            }
            set
            {
                _TaxInvoiceAmountC = value;
                OnPropertyChanged("TaxInvoiceAmountC");
            }
        }
        public decimal? TaxCollectedC
        {
            get
            {
                return _TaxCollectedC;
            }
            set
            {
                _TaxCollectedC = value;
                OnPropertyChanged("TaxCollectedC");
            }
        }
        public int? ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }
        public string CustomersName
        {
            get
            {
                return _CustomersName;
            }
            set
            {
                _CustomersName = value;
                OnPropertyChanged("CustomersName");
            }
        }
        public string TaxInvoiceNoC
        {
            get
            {
                return _TaxInvoiceNoC;
            }
            set
            {
                _TaxInvoiceNoC = value;
                OnPropertyChanged("TaxInvoiceNoC");
            }
        }
        public string TaxDateC
        {
            get
            {
                return _TaxDateC;
            }
            set
            {
                _TaxDateC = value;
                OnPropertyChanged("TaxDateC");
            }
        }
        public string TaxInvoiceAmountStrC
        {
            get
            {
                return _TaxInvoiceAmountStrC;
            }
            set
            {
                _TaxInvoiceAmountStrC = value;
                OnPropertyChanged("TaxInvoiceAmountStrC");
            }
        }
        public string TaxCollectedStrC
        {
            get
            {
                return _TaxCollectedStrC;
            }
            set
            {
                _TaxCollectedStrC = value;
                OnPropertyChanged("TaxCollectedStrC");
            }
        }

        #endregion
    }
}
