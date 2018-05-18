using SDN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.CloseRequest
{
    public class StackEntity : ViewModelBase
    {
        private ObservableCollection<string> _items ;
        public bool headervisible;

        public ObservableCollection<string> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }
        public bool Headervisible
        {
            get { return headervisible; }
            set { headervisible = value;
                OnPropertyChanged("Headervisible");
            }
        }
        
    }
}
