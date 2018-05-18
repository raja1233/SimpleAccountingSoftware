using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using SASClient.CloseRequest;
using SDN.Common;
using SDN.Settings.Services;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SDN.Settings.ViewModels
{
    public class UsersSecurityViewModel : UsersSecurityEntity
    {
        #region Private Properties
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<UsersSecurityEntity> _UsersSecurityEntity = new ObservableCollection<UsersSecurityEntity>();
        private ObservableCollection<UserRoleModel> _UserRoleModelCollection = new ObservableCollection<UserRoleModel>();
        private ObservableCollection<UserRoleModel> _UserRoleModelCollectionDemo = new ObservableCollection<UserRoleModel>();
        private int _UserGridHeight;
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;
        StackList listitem = new StackList();
        //private ObservableCollection<UsersSecurityEntity> _UserSecurityEmptyGrid = new ObservableCollection<UsersSecurityEntity>();
        IUserSecurityRepository securityRepository = new UserSecurityRepository();
        #endregion

        #region Public Properties

        public int UserGridHeight
        {
            get
            {
                return _UserGridHeight;
            }
            set
            {
                _UserGridHeight = value;
                OnPropertyChanged("UserGridHeight");
            }
        }
        public ObservableCollection<UsersSecurityEntity> UserSecurityEntity
        {
            get
            {

                //_UsersSecurityEntity = new ObservableCollection<UsersSecurityEntity>(securityRepository.GetUsers());
                // _UsersSecurityEntity = new ObservableCollection<UsersSecurityEntity>();
                return _UsersSecurityEntity;
                //return _UsersSecurityEntity = new ObservableCollection<UsersSecurityEntity>(securityRepository.GetUsers());
            }
            set
            {
                if (_UsersSecurityEntity != value)
                {
                    _UsersSecurityEntity = value;
                    OnPropertyChanged("UserSecurityEntity");
                }
            }
        }

        public ObservableCollection<UserRoleModel> UserRoleModelCollection
        {
            get
            {
                return _UserRoleModelCollection;
            }
            set
            {
                _UserRoleModelCollection = value;
                OnPropertyChanged("UserRoleModelCollection");
            }
        }
        public ObservableCollection<UserRoleModel> UserRoleModelCollectionDemo
        {
            get
            {
                return _UserRoleModelCollectionDemo;
            }
            set
            {
                _UserRoleModelCollectionDemo = value;
                OnPropertyChanged("UserRoleModelCollectionDemo");
            }
        }
        //public ObservableCollection<UsersSecurityEntity> UserSecurityEmptyGrid
        //{
        //    get
        //    {
        //        return _UserSecurityEmptyGrid;
        //    }
        //    set
        //    {
        //        _UserSecurityEmptyGrid = value;
        //        OnPropertyChanged("UserSecurityEmptyGrid");
        //    }
        //}

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersSecurityEntity"/> class.
        /// </summary>
        public UsersSecurityViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
            : base()
        {
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            SaveCommand = new RelayCommand(DoSave, CanAddUser);
            AddNewRowCommand = new RelayCommand(addRow);
            SaveRolesCommand = new RelayCommand(addroles, CanSave);
            DeleteRowCommand = new RelayCommand(deleteuser, CanDelete);
            CheckAllRoles = new RelayCommand(checkallroles);
            CheckAllRolesTab = new RelayCommand(checkallrolestab);
            CheckIsActive = new RelayCommand(checkisactive);
            CheckModuleTab = new RelayCommand(checkmoduletab);
            CloseCommand = new DelegateCommand(Close);
            this.LoadBackground();
        }
        public ICommand CloseCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddNewRowCommand { get; set; }
        public RelayCommand SaveRolesCommand { get; set; }
        public RelayCommand DeleteRowCommand { get; set; }
        public RelayCommand CheckAllRoles { get; set; }
        public RelayCommand CheckAllRolesTab { get; set; }
        public RelayCommand CheckIsActive { get; set; }
        public RelayCommand CheckModuleTab { get; set; }
        #endregion

        #region Background Worked
        private void LoadBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;

            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;
            //worker.DoWork += (s, e) =>
            //{
            //    Thread.Sleep(2000);
            //};
            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadUserSecurityBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadUserSecurityBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly


            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadUserSecurityBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        private void LoadUserSecurityBackground(object sender, DoWorkEventArgs e)
        {
            int minHeight = 300;
            int headerRows = 180;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 100;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.UserGridHeight = minHeight;

            UserSecurityEntity = new ObservableCollection<UsersSecurityEntity>(securityRepository.GetUsers());
            UserRoleModelCollection = new ObservableCollection<UserRoleModel>(securityRepository.GetAllUserRoles());
            //UserSecurityEmptyGrid = UserSecurityEntity;
            //for (int i = 0; i < 20; i++)
            //{
            //    //UserSecurityEmptyGrid.Add(string.Empty );
            //    UserSecurityEmptyGrid.Add(new UsersSecurityEntity { Isinactive = false });
            //}
            //UserRoleModelCollectionDemo = UserRoleModelCollection;
        }
        /// <summary>
        ///  Occurs when System.ComponentModel.BackgroundWorker.ReportProgress(System.Int32) is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void LoadUserSecurityBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {

        }
        ///// <summary>
        /////  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        ///// </summary>
        ///// <param name="sender">The sender.</param>
        ///// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadUserSecurityBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = null;
        }
        #endregion

        #region Click Commands
        void DoSave(object param)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to save changes?\n", "Save Content", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    var user = UserSecurityEntity.ToList();
                    var saveuser = securityRepository.SaveUsers(user);
                    this.LoadBackground();
                    if (saveuser == false)
                    {
                        MessageBox.Show("Oops there seems to be a problem right now, kindly close the application and restart!\n"+ "@ Simple Accounting Software Pte Ltd");
                    }
                    break;
                case MessageBoxResult.No:
                    break;
                    //var demo = UserRoleModelCollection;


                    //var demo = UserRoleModelCollection;
                    //if (SelectedIndex == -1)
                    //{
                    //    personnel.AddEmployee(employee);
                    //    RaisePropertyChanged("Employee"); // Update the list from the data source
                    //}
                    //else
                    //    personnel.UpdateEmployee(employee);

                    //SelectedUser = null;
            }
        }
        private void Close()
        {
            try
            {
                List<string> listview = (List<string>)Application.Current.Resources["views"];
                var secondlast = listview.AsEnumerable().Reverse().Skip(1).First();
                CloseView close = new CloseView(regionManager, eventAggregator);
                close.CloseViewRequest(secondlast, true);
                listview.RemoveAt(listview.Count - 1);
            }
            catch (Exception)
            {
                List<string> listview = (List<string>)Application.Current.Resources["views"];
                CloseView close = new CloseView(regionManager, eventAggregator);
                close.CloseViewRequest("MainView", true);
                listview.RemoveAt(listview.Count - 1);
            }
            //List<string> calledlist = stack.x();
        }
        void addRow(object param)
        {
            UserSecurityEntity.Add(new UsersSecurityEntity { Isinactive = false });
        }
        void addroles(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            var user = SelectedUser as UsersSecurityEntity;
            var roles = UserRoleModelCollection.ToList();
            if (user.ID > 0 || user != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Save Content", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        var saverole = securityRepository.AddRoles(roles, user.ID);
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Kindly first save the user and then assign roles!\n"+ "@ Simple Accounting Software Pte Ltd", "Save Content", MessageBoxButton.OK);
            }
            Mouse.OverrideCursor = null;
        }
        void deleteuser(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            if (SelectedUser != null)
            {


                MessageBoxResult result = MessageBox.Show("Do you want to Delete User?\n"+ "@ Simple Accounting Software Pte Ltd", "Delete Content", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        var user = SelectedUser as UsersSecurityEntity;
                        if (user.ID > 0)
                        {
                            var deleteuser = securityRepository.DeleteUser(user.ID);
                            if (deleteuser == false)
                            {
                                MessageBox.Show("Oops there seems to be a problem right now, kindly close the application and restart!\n"+ "@ Simple Accounting Software Pte Ltd");
                            }
                            this.LoadBackground();
                        }
                        else
                        {
                            UserSecurityEntity.Remove(user);
                        }


                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            Mouse.OverrideCursor = null;
        }
        void checkallroles(object param)
        {
            if (param.ToString() == "True")
            {
                foreach (var item in UserRoleModelCollection)
                {
                    if (item.CheckModule != null)
                    {
                        item.CheckModule = true;
                    }
                    item.CheckTab = true;
                }
            }
            else
            {
                foreach (var item in UserRoleModelCollection)
                {
                    if (item.CheckModule != null)
                    {
                        item.CheckModule = false;
                    }
                    //item.CheckTab = false;
                }
            }

        }
        void checkallrolestab(object param)
        {
            if (param.ToString() == "True")
            {
                foreach (var item in UserRoleModelCollection)
                {
                    //if (item.CheckModule != null)
                    //{
                    //    item.CheckModule = true;
                    //}
                    item.CheckTab = true;
                }
            }
            else
            {
                foreach (var item in UserRoleModelCollection)
                {
                    if (item.CheckModule != null)
                    {
                        item.CheckModule = false;
                    }
                    item.CheckTab = false;
                }
            }

        }
        void checkisactive(object param)
        {
            if (param.ToString() == "True")
            {
                foreach (var item in UserSecurityEntity)
                {
                    item.Isinactive = true;
                }
            }
            else
            {
                foreach (var item in UserSecurityEntity)
                {
                    item.Isinactive = false;
                }
            }
        }

        void checkmoduletab(object param)
        {

        }


        #endregion
        object _SelectedUser;
        public object SelectedUser
        {
            get
            {
                return _SelectedUser;
            }
            set
            {
                if (_SelectedUser != value)
                {
                    _SelectedUser = value;
                    RaisePropertyChanged("SelectedUser");
                    OnUserChange();
                }
            }
        }
        object _SelectedUserRole;
        public object SelectedUserRole
        {
            get
            {
                return _SelectedUserRole;
            }
            set
            {
                if (_SelectedUserRole != value)
                {
                    _SelectedUserRole = value;
                    RaisePropertyChanged("SelectedUserRole");

                }
            }
        }

        object _SelectedRole;
        public object SelectedRole
        {
            get
            {
                return _SelectedRole;
            }
            set
            {
                if (_SelectedRole != value)
                {
                    _SelectedRole = value;
                    RaisePropertyChanged("SelectedRole");

                }
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(name));
            }
            switch (name)
            {
                case "CheckModule":
                    //CheckModule();
                    break;

            }

            base.OnPropertyChanged(name);
        }

        void checkdemo()
        {
            var demo = SelectedRole as UserRoleModel;
        }
        public void CheckModuledemo(object user)
        {
            UserRoleModel checkedmodule = user as UserRoleModel;
            if (checkedmodule.CheckModule != null)
            {
                foreach (var item in UserRoleModelCollection)
                {
                    if (item.ModuleId == checkedmodule.ModuleId)
                    {
                        if (checkedmodule.CheckModule == true)
                        {
                            item.CheckTab = true;
                        }
                        else
                        {
                            item.CheckTab = false;
                        }
                    }
                }
            }
        }
        public void OnUserChange()
        {
            var user = SelectedUser as UsersSecurityEntity;
            var role = SelectedRole as UserRoleModel;
            if (user != null)
            {
                var userRole = securityRepository.GetUserRoles(user.ID);
                foreach (var item in UserRoleModelCollection)
                {
                    item.CheckTab = false;
                    if (item.CheckModule != null)
                        item.CheckModule = false;
                }
                if (userRole.Count > 0)
                {
                    foreach (var item in UserRoleModelCollection)
                    {
                        foreach (var roleselction in userRole)
                        {
                            if (roleselction.TabId.Replace(" ", "") == item.TabId)
                                item.CheckTab = true;
                        }
                    }
                }
            }

        }

        public bool CanSave(object param)
        {
            var selectedUser = SelectedUser as UsersSecurityEntity;
            if (selectedUser != null)
            {
                var selecteduser = selectedUser as UsersSecurityEntity;
                if (selecteduser.UserName == null || selecteduser.UserName == "" || selecteduser.UserName == " " || selecteduser.ID == 0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        public bool CanAddUser(object param)
        {
            var selectedUser = SelectedUser as UsersSecurityEntity;
            if (selectedUser != null)
            {
                var selecteduser = selectedUser as UsersSecurityEntity;
                if (selecteduser.UserName == null || selecteduser.UserName == "" || selecteduser.UserName == " " || selecteduser.Password == null)
                    return false;
                else
                {
                    if (selecteduser.Password.Length < 6 || selecteduser.UserName.Length<3)
                    {
                        return false;
                    }

                    return true;
                }

            }
            else
                return false;
        }
        public bool CanDelete(object param)
        {
            if (SelectedUser != null)
            {
                return true;
            }
            else
                return false;
        }

    }
}
