namespace SDN.UI.Entities
{
    /// <summary>
    /// CustomerEntity class
    /// </summary>
    public class CustomerEntity : EntityBase
    {
        #region Private Propertes
       
        /// <summary>
        /// The customer ID
        /// </summary>
        private int customerID;
        private int? salesmanID;
        private int? discount;
        private string _Inactive;
        private decimal? creditLimitAmount;
        private decimal? balance;
        private string _CusCreditLimitAmountStr;
        private string _Cus_BalanceStr;
        #endregion

        #region Private Propertes

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>
        /// The customer ID.
        /// </value>
        public int CustomerID
        {
            get
            {
                return this.customerID;
            }
            set
            {
                this.customerID = value;
                this.OnPropertyChanged("CustomerID");
            }
        }

        public int? SalesmanID
        {
            get
            {
                return this.salesmanID;
            }
            set
            {
                this.salesmanID = value;
                this.OnPropertyChanged("SalesmanID");
            }
        }

        public int? Discount
        {
            get { return discount; }
            set { discount = value; OnPropertyChanged("Discount"); }
            
        }
        public string Inactive
        {
            get
            {
                return this._Inactive;
            }
            set
            {
                this._Inactive = value;
                this.OnPropertyChanged("Inactive");
            }
        }
        public decimal? CreditLimitAmount
        {
            get { return creditLimitAmount; }
            set { creditLimitAmount = value;
                OnPropertyChanged("CreditLimitAmount");
            }
        }
        public decimal? Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }
        public string CusCreditLimitAmountStr
        {
            get { return _CusCreditLimitAmountStr; }
            set
            {
                _CusCreditLimitAmountStr = value;
                OnPropertyChanged("CusCreditLimitAmountStr");
            }
        }
        public string Cus_BalanceStr
        {
            get { return _Cus_BalanceStr; }
            set
            {
                _Cus_BalanceStr = value;
                OnPropertyChanged("Cus_BalanceStr");
            }
        }

        #endregion

    }


}
