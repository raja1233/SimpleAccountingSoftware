using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDN.Common
{
   public class StateDropDown
    {
        private string _statename = string.Empty;
        public string _countrycode = string.Empty;
        public string _statecode = string.Empty;

        public string StateName
        {
            get
            {
                return _statename;
            }
            set
            {
                _statename = value;
            }
        }

        public string CountryCode
        {
            get
            {
                return _countrycode;
            }
            set
            {
                _countrycode = value;
            }
        }

        public string StateCode
        {
            get
            {
                return _statecode;
            }
            set
            {
                _statecode = value;
            }
        }
    }
}
