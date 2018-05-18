using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
   public class UsersSecurityEntity: ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private string _UserName;
        private string _Password;
        private string _EncryptedPassword;
        private bool? _Isinactive;
        private List<UsersSecurityEntity> _UsersSecurityList;
        private UserRoleModel _UserRoleModel;
        private UsersSecurityEntity _selectedUser;
        #endregion

        #region Public Properties
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

        public List<UsersSecurityEntity> UsersSecurityList
        {
            get { return _UsersSecurityList; }
            set
            {
                if (_UsersSecurityList != value)
                {
                    _UsersSecurityList = value;
                    OnPropertyChanged("UsersSecurityList");
                }
            }
        }
        public UserRoleModel UserRoleModel
        {
            get { return _UserRoleModel; }
            set
            {
                if (_UserRoleModel != value)
                {
                    _UserRoleModel = value;
                    OnPropertyChanged("UserRoleModel");
                }
            }
        }
        public UsersSecurityEntity selectedUser
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
