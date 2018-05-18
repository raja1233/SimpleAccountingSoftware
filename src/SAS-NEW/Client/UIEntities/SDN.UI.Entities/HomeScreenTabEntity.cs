using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class HomeScreenTabEntity:ViewModelBase
    {
        #region Private Properties
        private bool? _NotificationTabTrue;
        private bool? _AuditTrailTabTrue;
        private bool? _TodoListTabTrue;
        #endregion
        #region Public Properties
        public bool? NotificationTabTrue
        {
            get
            {
                return _NotificationTabTrue;
            }
            set
            {
                _NotificationTabTrue = value;
                OnPropertyChanged("NotificationTabTrue");
            }
        }
        public bool? TodoListTabTrue
        {
            get
            {
                return _TodoListTabTrue;
            }
            set
            {
                _TodoListTabTrue = value;
                OnPropertyChanged("TodoListTabTrue");
            }
        }
        public bool? AuditTrailTabTrue
        {
            get
            {
                return _AuditTrailTabTrue;
            }
            set
            {
                _AuditTrailTabTrue = value;
                OnPropertyChanged("AuditTrailTabTrue");
            }
        }
       
        #endregion
    }
}
