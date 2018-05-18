

namespace SDN.UI.Entities
{
    using System;
    using SDN.Common;
    using System.Globalization;
    public class PandSListModel: ViewModelBase
    {
        // private int id;
        private string psCode;
        private string psName;
        private string psType;
     
        private int? taxID;
        private decimal? taxRate;      
        private string isInActive;
        private decimal? _SPriceExcludingTax;
        private decimal? _SPriceIncludingTax;
        private decimal? _CPriceExcludingTax;
        private decimal? _CPriceIncludingTax;
        private decimal? _SPriceExcludingTaxBackup;
        private decimal? _SPriceIncludingTaxBackup;
        private decimal? _CPriceExcludingTaxBackup;
        private decimal? _CPriceIncludingTaxBackup;

        public int ID { get; set; }
        public string PSCode
        {
            get
            {
                return psCode;
            }
            set
            {
                psCode = value;
                OnPropertyChanged("PSCode");
            }
        }
        public string PSName
        {
            get
            {
                return psName;
            }
            set
            {
                psName = value;
                OnPropertyChanged("PSName");
            }
        }
        public string PSType
        {
            get
            {
                return psType;
            }
            set
            {
                psType = value;
                OnPropertyChanged("PSType");
            }
        }
         public int? TaxID
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

        public decimal? TaxRate
        {
            get
            {
                return taxRate;
            }
            set
            {
                taxRate = value;
                OnPropertyChanged("GSTCodeRate");
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
                OnPropertyChanged("IsInactive");
            }
        }
        #region "Sells Price Properties "       
        public decimal? SellPriceExcludingTax
        {
            get { return _SPriceExcludingTax;
            }
            set
            {
                _SPriceExcludingTax = value;
                OnPropertyChanged("SellPriceExcludingTax");
            }
        }
       public decimal? SellPriceIncludingTax
        {
            get
            {
                return _SPriceIncludingTax;
            }
            set
            {
                _SPriceIncludingTax = value;
                OnPropertyChanged("SellPriceIncludingTax");
            }
        }
      

        public decimal? SellPriceExcludingTaxBackup
        {
            get
            {
                return _SPriceExcludingTaxBackup;
            }
            set
            {
                _SPriceExcludingTaxBackup = value;
               
            }
        }
        public decimal? SellPriceIncludingTaxBackup
        {
            get
            {
                return _SPriceIncludingTaxBackup;
            }
            set
            {
                _SPriceIncludingTaxBackup = value;
                
            }
        }

        #endregion

        #region "Cost Price Properties"

        public decimal? CostPriceExcludingTax
        {
            get
            {
                return _CPriceExcludingTax;
            }
            set
            {
                _CPriceExcludingTax = value;
                OnPropertyChanged("CostPriceExcludingTax");
            }
        }
        public decimal? CostPriceIncludingTax
        {
            get
            {
                return _CPriceIncludingTax;
            }
            set
            {
                _CPriceIncludingTax = value;
                OnPropertyChanged("CostPriceIncludingTax");
            }
        }
        public decimal? CostPriceExcludingTaxBackup
        {
            get
            {
                return _CPriceExcludingTaxBackup;
            }
            set
            {
                _CPriceExcludingTaxBackup = value;
                
            }
        }
        public decimal? CostPriceIncludingTaxBackup
        {
            get
            {
                return _CPriceIncludingTaxBackup;
            }
            set
            {
                _CPriceIncludingTaxBackup = value;
              
            }
        }

        #endregion
    }
}
