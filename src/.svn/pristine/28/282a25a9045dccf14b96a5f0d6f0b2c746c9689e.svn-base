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

        #endregion

    }


}
