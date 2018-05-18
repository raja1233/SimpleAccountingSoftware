using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Login
{
    public class LoginUserEntity : BaseEntity
    {
        #region private properties
        private int _ID;
        private string _UserName;
        private string _Password;
        private string _EncryptedPassword;
        private bool? _Isinactive;
        private List<LoginUserEntity> _LoginUserList;
        private string moduleName { get; set; }
        private int moduleId { get; set; }
        private string tabId { get; set; }
        private string tabName { get; set; }
        private int orderId { get; set; }
        private bool? _ShowModuleCheckBox;
        private bool? _CheckModule;
        private bool? _CheckTab;

        private LoginUserEntity _selectedUser;

        #endregion
        #region Public properties
        public string ModuleName
        {
            get { return moduleName; }
            set
            {
                moduleName = value;
                OnPropertyChanged("ModuleName");
            }
        }

        public int ModuleId
        {
            get { return moduleId; }
            set
            {
                moduleId = value;
                OnPropertyChanged("ModuleId");
            }
        }
        public string TabId
        {
            get { return tabId; }

            set
            {
                tabId = value;
                OnPropertyChanged("TabId");
            }
        }
        public string TabName
        {
            get
            {
                return tabName;
            }
            set
            {
                tabName = value;
                OnPropertyChanged("TabName");
            }
        }
        public int OrderId
        {
            get { return orderId; }
            set
            {
                orderId = value;
                OnPropertyChanged("OrderId");
            }
        }
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
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        public bool? Isinactive
        {
            get { return _Isinactive; }
            set
            {
                if (_Isinactive != value)
                {
                    _Isinactive = value;
                    OnPropertyChanged("Isinactive");
                }
            }
        }
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

      
        public string EncryptedPassword
        {
            get { return _EncryptedPassword; }
            set
            {
                if (_EncryptedPassword != value)
                {
                    _EncryptedPassword = value;
                    OnPropertyChanged("EncryptedPassword");
                }
            }
        }
        public List<LoginUserEntity> LoginUserList
        {
            get { return _LoginUserList; }
            set
            {
                if (_LoginUserList != value)
                {
                    _LoginUserList = value;
                    OnPropertyChanged("LoginUserList");
                }
            }
        }
      
        public LoginUserEntity selectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged("selectedUser");
                }
            }
        }
        #endregion
    }
}
