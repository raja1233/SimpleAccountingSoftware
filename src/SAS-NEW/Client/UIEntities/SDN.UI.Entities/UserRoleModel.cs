using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class UserRoleModel: ViewModelBase
    {
        private int id { get; set; }
        private string moduleName { get; set; }
        private int moduleId { get; set; }
        private string tabId { get; set; }
        private string tabName { get; set; }
        private int orderId { get; set; }
        private bool? _ShowModuleCheckBox;
        private bool? _CheckModule;
        private bool? _CheckTab;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public string ModuleName
        {
            get { return moduleName; }
            set { moduleName = value;
                OnPropertyChanged("ModuleName");
            }
        }

        public int ModuleId
        {
            get { return moduleId; }
            set { moduleId = value;
                OnPropertyChanged("ModuleId");
            }
        }
        public string TabId
        {
            get { return tabId; }

            set { tabId = value;
                OnPropertyChanged("TabId");
            }
        }
        public string TabName
        { get
            {
                return tabName;
            } set{
                tabName = value ;
                OnPropertyChanged("TabName");
            }
        }
        public int OrderId
        { get { return orderId; }
            set {
                orderId = value;
                OnPropertyChanged("OrderId");
            } }
        public bool? ShowModuleCheckBox
        {
            get
            {
                return _ShowModuleCheckBox;
            }
            set
            {
                _ShowModuleCheckBox = value;
                OnPropertyChanged("ShowModuleCheckBox");
            }
        }
        //public bool? CheckModule
        //{
        //    get
        //    {
        //        return _CheckModule;
        //    }
        //    set
        //    {
        //        _CheckModule = value;
        //        OnPropertyChanged("CheckModule");
        //    }
        //}
        //public bool? CheckTab
        //{
        //    get
        //    {
        //        return _CheckTab;
        //    }
        //    set
        //    {
        //        _CheckTab = value;
        //        OnPropertyChanged("CheckTab");
        //    }
        //}
        public bool? CheckTab
        {
            get { return _CheckTab; }
            set
            {
                if (_CheckTab != value)
                {
                    _CheckTab = value;
                    OnPropertyChanged("CheckTab");
                }
            }
        }
        public bool? CheckModule
        {
            get { return _CheckModule; }
            set
            {
                if (_CheckModule != value)
                {
                    _CheckModule = value;
                    OnPropertyChanged("CheckModule");
                }
            }
        }
    }
}
