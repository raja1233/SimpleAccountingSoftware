using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    
   public class Country
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _countryID;

        public int CountryID
        {
            get { return _countryID; }
            set { _countryID = value; }
        }
    }
}
