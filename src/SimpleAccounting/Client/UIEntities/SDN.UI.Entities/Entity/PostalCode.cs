using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities 
{
     public class PostalCode
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _postalcodeID;

        public int PostalCodeID
        {
            get { return _postalcodeID; }
            set { _postalcodeID = value; }
        }
    }
}
 
