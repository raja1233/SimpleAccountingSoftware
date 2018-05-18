using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
  public  class CountryEntity:BaseEntity
    {
        #region Private Propertes

        /// <summary>
        /// The customer ID
        /// </summary>
        private int countryId;

        private string countryName;
        private string countryCode;
        #endregion

        #region public Propertes

        /// <summary>
        /// Gets or sets the country ID.
        /// </summary>
        /// <value>
        /// The country ID.
        /// </value>
        public int CountryId
        {
            get
            {
                return this.countryId;
            }
            set
            {
                this.countryId = value;
                this.OnPropertyChanged("CountryId");
            }
        }

        public string CountryName
        {
            get
            {
                return this.countryName;
            }
            set
            {
                this.countryName = value;
                this.OnPropertyChanged("CountryName");
            }
        }
        public string CountryCode
        {
            get
            {
                return this.countryCode;
            }
            set
            {
                this.countryCode = value;
                this.OnPropertyChanged("CountryCode");
            }
        }
        #endregion

    }
}
