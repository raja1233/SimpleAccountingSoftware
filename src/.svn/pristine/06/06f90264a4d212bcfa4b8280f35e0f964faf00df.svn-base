
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    using SDN.Common;
    using System.ComponentModel.DataAnnotations;

    public class TaxModel :ViewModelBase
    {

        #region "private data members"

        private int taxID;
        private string taxName;
        private string taxDescription;
        private string taxCode;
        private decimal taxRate;
        private string strTaxRate;
        private string isInActive;
        private bool? isDefault;
        private int _POGridHeight;
        #endregion

        #region "public data members"
        public int POGridHeight
        {
            get
            {
                return _POGridHeight;
            }
            set
            {
                _POGridHeight = value;
                OnPropertyChanged("POGridHeight");
            }
        }
        public int TaxID
        {
            get
            {
                return taxID;
            }
            set
            {
                taxID = value;
                OnPropertyChanged("TaxID");
            }
        }

        public string TaxName
        {
            get
            {
                return taxName;
            }
            set
            {
                taxName = value;
                OnPropertyChanged("TaxName");
            }
        }

        [Required(ErrorMessage = "Tax Description is Required")]
        public string TaxDescription
        {
            get
            {
                return taxDescription;
            }
            set
            {
                taxDescription = value;
                OnPropertyChanged("TaxDescription");
            }
        }

        [Required(ErrorMessage = "Tax Code is Required")]
        public string TaxCode
        {
            get
            {
                return taxCode;
            }
            set
            {
                taxCode = value;
                OnPropertyChanged("TaxCode");
            }
        }

      
        public decimal TaxRate
        {
            get
            {
                return taxRate;
            }
            set
            {
                taxRate = value;
                OnPropertyChanged("TaxRate");
            }
        }

        public string IsInActive
        {
            get
            {
                return isInActive;
            }
            set
            {
                isInActive = value;
                OnPropertyChanged("IsInActive");
            }
        }

        public bool? IsDefault
        {
            get
            {
                return isDefault;
            }
            set
            {
                isDefault = value;
                OnPropertyChanged("IsDefault");
            }
        }

        public string StrTaxRate
        {
            get
            {
                return strTaxRate;
            }
            set
            {
                strTaxRate = value;
                OnPropertyChanged("StrTaxRate");
            }
        }

        public bool? Predefined
        {
            get;set;
        }

        public string Rank { get; set; }

        #endregion

    }
}
