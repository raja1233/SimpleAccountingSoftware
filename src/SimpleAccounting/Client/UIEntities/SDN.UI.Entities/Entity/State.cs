using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
  
    public class State
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _stateID;

        public int StateID
        {
            get { return _stateID; }
            set { _stateID = value; }
        }
    }
}
 
