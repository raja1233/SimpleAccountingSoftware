
namespace SDN.UI.Entities
{
    /// <summary>
    /// Created By: Sunil Sharma
    /// </summary>
    public class CustomersEntity :BaseEntity
    {
        #region Private Propertes

        /// <summary>
        /// The customer ID
        /// </summary>
        private int id;

        #endregion

        #region Private Propertes

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>
        /// The customer ID.
        /// </value>
        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                this.OnPropertyChanged("ID");
            }
        }

        #endregion

    }
}
