using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
   public class ImportEntity : ViewModelBase
    {
        private int _ID;
        private string _MasterName;
        private bool? _IsChecked;
        private string _Name;
        private string _Name1;
        private bool _isDefault;
        private bool _radio3IsCheck;
        private bool _radio4IsCheck;
        //private bool isReject;
        //private bool isUpdate;
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
        public bool IsDefault
        {
            get
            {
                return _isDefault;
            }
            set
            {
                _isDefault = value;
                OnPropertyChanged("_isDefault");
            }
        }
        //public bool IsUpdate
        //{
        //    get
        //    {
        //        return isUpdate;
        //    }
        //    set
        //    {
        //        isUpdate = value;
        //        OnPropertyChanged("isUpdate");
        //    }
        //}
        //public bool IsReject
        //{
        //    get
        //    {
        //        return isReject;
        //    }
        //    set
        //    {
        //        isReject = value;
        //        OnPropertyChanged("isReject");
        //    }
        //}
        public string MasterName
        {
            get
            {
                return _MasterName;
            }
            set
            {
                _MasterName = value;
                OnPropertyChanged("TransactionName");
            }
        }
        public bool? IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                _IsChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        public string Name1
        {
            get
            {
                return _Name1;
            }
            set
            {
                _Name1 = value;
                OnPropertyChanged("Name1");
            }
        }
      
        public bool Radio3IsCheck
        {
            get { return this._radio3IsCheck; }
            set
            {
                this._radio3IsCheck = value;
                this.OnPropertyChanged("Radio3IsCheck");

            }
        }
       
        public bool Radio4IsCheck
        {
            get { return this._radio4IsCheck; }
            set
            {
                this._radio4IsCheck = value;
                this.OnPropertyChanged("Radio4IsCheck");

            }
        }
        //private string _radio1 = "Import Data From Excel Files";
        //public string Radio1
        //{
        //    get { return this._radio1; }
        //    set
        //    {
        //        this._radio1 = value;
        //        this.OnPropertyChanged("Radio1");
        //    }
        //}
        //private string _radio2 = "Import Data From Excel Files";
        //public string Radio2
        //{
        //    get { return this._radio2; }
        //    set
        //    {
        //        this._radio2 = value;
        //        this.OnPropertyChanged("Radio2");
        //    }
        //}
        //private bool _radio1IsCheck;
        //public bool Radio1IsCheck
        //{
        //    get { return this._radio1IsCheck; }
        //    set
        //    {
        //        this._radio1IsCheck = value;
        //        this.OnPropertyChanged("Radio1IsCheck");

        //    }
        //}
    }
}
