﻿using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class QuarterEntity: ViewModelBase
    {
        private int _ID;
        private string _Quarter;

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }
        public string Quarter
        {
            get
            {
                return _Quarter;
            }
            set
            {
                _Quarter = value;
                OnPropertyChanged("Quarter");
            }
        }
    }
}