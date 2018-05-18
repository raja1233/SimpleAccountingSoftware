using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class MasterEntity : ViewModelBase
    {
        private int _ID;
        private string _MasterName;
        private bool? _IsCheckedMaster;

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
        public string MasterName
        {
            get
            {
                return _MasterName;
            }
            set
            {
                _MasterName = value;
                OnPropertyChanged("MasterName");
            }
        }
        public bool? IsCheckedMaster
        {
            get
            {
                return _IsCheckedMaster;
            }
            set
            {
                _IsCheckedMaster = value;
                OnPropertyChanged("IsCheckedMaster");
            }
        }
    }
}
