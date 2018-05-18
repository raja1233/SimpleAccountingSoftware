
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    using SDN.Common;
    using System.ComponentModel.DataAnnotations;

    public class TaxModel : ValidatableBindableBase
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

        #endregion

        #region "public data members"
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
                SetProperty(ref taxDescription, value);
                OnPropertyChanged(() => TaxDescription);
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
                SetProperty(ref taxCode, value);
                OnPropertyChanged(() => TaxCode);
            }
        }

        [Required(ErrorMessage = "Tax Rate is Required")]
        [Range(0, 100.00, ErrorMessage = "Tax Rate should be between from 0 to 100")]
        [RegularExpression(@"^\d{1,3}([.]\d{1,2})?%?$", ErrorMessage = "Please enter valid Rate")]
        public decimal TaxRate
        {
            get
            {
                return taxRate;
            }
            set
            {
                SetProperty(ref taxRate, value);
                OnPropertyChanged(() => TaxRate);
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
