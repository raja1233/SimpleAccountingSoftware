using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class BackupDataEntity :ViewModelBase
    {
        #region 'private property'
        private int _SIGridHeight;
        private int _ServerID;
        private int _ServerStatus;
        private string _ServerName;
        private string _ServerProduct;
        private string _DataSource;
        private string _Name;
        private string _status;
        private List<BackupDataEntity> _ServerList;
        private List<BackupDataEntity> _DataBaseList;
        #endregion
        #region 'public property'
        public int ServerID
        {
            get
            {
                return _ServerID;
            }
            set
            {
                _ServerID = value;
                OnPropertyChanged("ServerID");
            }
        }
        public int ServerStatus
        {
            get
            {
                return _ServerStatus;
            }
            set
            {
                _ServerStatus = value;
                OnPropertyChanged("ServerStatus");
            }
        }
        public string ServerName
        {
            get
            {
                return _ServerName;
            }
            set
            {
                _ServerName = value;
                OnPropertyChanged("ServerName");
            }
        }
        public string ServerProduct
        {
            get
            {
                return _ServerProduct;
            }
            set
            {
                _ServerProduct = value;
                OnPropertyChanged("ServerProduct");
            }
        }
        public string DataSource
        {
            get
            {
                return _DataSource;
            }
            set
            {
                _DataSource = value;
                OnPropertyChanged("DataSource");
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged("status");
            }
        }
        public List<BackupDataEntity> ServerList
        {
            get
            {
                return _ServerList;
            }
            set
            {
                _ServerList = value;
                OnPropertyChanged("ServerList");
            }
        }
        public List<BackupDataEntity> DataBaseList
        {
            get
            {
                return _DataBaseList;
            }
            set
            {
                _DataBaseList = value;
                OnPropertyChanged("DataBaseList");
            }
        }
        #endregion
        #region public property
        public int SIGridHeight
        {
            get
            {
                return _SIGridHeight;
            }
            set
            {
                _SIGridHeight = value;
                OnPropertyChanged("GridHeight");
            }
        }
        #endregion
    }
    public class BackupForm
    {

    }
}
