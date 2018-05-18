

namespace SDN.Purchasing.ViewModel
{
    using Microsoft.Practices.Prism.Commands;
    using SDN.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using SDN.UI.Entities;
    using SDN.Purchasing.Services;
    using System.Threading;
    using SASClient.CloseRequest;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.Events;

    //public class Sharedvalues
    //{
    //    public static string getValue { get; set; }
    //}

    public sealed class SupplierDetailViewModel : SupplierDetailEntity
    {
        #region Private Properties
        private readonly DelegateCommand saveClickCommand = null;

        private DelegateCommand newShippingClickCommand = null;
        //private List<Customer> _SearchCustomer;
        private DelegateCommand sameAsBillingAddressCommand = null;
        private DelegateCommand previousCommand = null;
        private DelegateCommand nextCommand = null;
        private DelegateCommand newCustomerClickCommand = null;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private DelegateCommand deleteCustomerClickCommand = null;
        public event PropertyChangedEventHandler PropertyChanged;
        StackList listitem = new StackList();
        #endregion

        #region Public Properties
        private DelegateCommand cancelClickCommand;
        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersViewModel"/> class.
        /// </summary>
        public SupplierDetailViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            SaveClickCommand = new RelayCommand(OnSaveSupplier, CanSave);
            //DeleteCustomerClickCommand = new RelayCommand(OnDeleteCustomer, CanDelete);
            NewSupplierClickCommand = new RelayCommand(NewSupplier);
            SameAsBillingAddressCommand = new RelayCommand(sameasbilltoadd);
            NextCommand = new RelayCommand(nextsupplier);
            PreviousCommand = new RelayCommand(previoussupplier);
            DeleteSupplierClickCommand = new RelayCommand(deletesupplier);
            RefreshCommand = new RelayCommand(RefreshSupplierData);
            //this.sample(Sharedvalues.getValue);
            CloseCommand = new DelegateCommand(Close);
            this.LoadSupplierBackground(SharedValues.getValue);
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
        }
        //public SupplierDetailViewModel(string suppId)
        //{
        //    this.ID = Convert.ToInt32(suppId);
        //    this.LoadSupplierBackground();
        //}
        #endregion  Constructor

        #region Relay Commands
        public ICommand CloseCommand { get; set; }
        public RelayCommand SaveClickCommand { get; set; }
        public RelayCommand DeleteCustomerClickCommand { get; set; }
        public RelayCommand NewSupplierClickCommand { get; set; }
        public RelayCommand SameAsBillingAddressCommand { get; set; }
        public RelayCommand NextCommand { get; set; }
        public RelayCommand PreviousCommand { get; set; }
        public RelayCommand DeleteSupplierClickCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }

        #endregion


        void OnSaveSupplier(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            SupplierDetailEntity supplier = new SupplierDetailEntity();
            supplier.ID = this.SelectedSearchSupplier;
            supplier.SupplierName = this.SupplierName;
            supplier.Email = this.Email;
            supplier.Fax = this.Fax;
            supplier.Telephone = this.Telephone;
            supplier.Supp_Reg_No = this.Supp_Reg_No;
            supplier.Sup_Bill_to_city = this.Sup_Bill_to_city;
            supplier.Sup_Bill_to_country = this.Sup_Bill_to_country;
            supplier.Sup_Bill_to_line1 = this.Sup_Bill_to_line1;
            supplier.Sup_Bill_to_line2 = this.Sup_Bill_to_line2;
            supplier.Sup_Bill_to_post_code = this.Sup_Bill_to_post_code;
            supplier.Sup_Bill_to_state = this.Sup_Bill_to_state;
            supplier.ShipAddressLine1 = this.ShipAddressLine1;
            supplier.ShipAddressLine2 = this.ShipAddressLine2;
            supplier.ShipCity = this.ShipCity;
            supplier.ShipCountry = this.ShipCountry;
            supplier.ShipState = this.ShipState;
            supplier.ShipPostalCode = this.ShipPostalCode;
            supplier.ContactPerson = this.ContactPerson;
            supplier.GstRegistrationNo = this.GstRegistrationNo;
            supplier.Remarks = this.Remarks;
            supplier.IsInActive = this.IsInActive;
            supplier.ChangeSupplierGST = this.ChangeSupplierGST;
            supplier.Balance = this.Balance;
            supplier.ID = this.ID;
            supplier.CreditLimitAmount = this.CreditLimitAmount;
            supplier.CreditLimitDays = this.CreditLimitDays;
            supplier.TaxId = this.SelectedTaxId;
            MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Save Content", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    ISupplierRepository supplierRepository = new SupplierRepository();
                    var savesupplier = supplierRepository.CreateSupplier(supplier);
                    if (savesupplier)
                    {
                        if (this.ID == 0)
                        {
                            //this.SearchSupplier = supplierRepository.GetAllSupplier().ToList();
                            //var SupplierIdSelected = this.SearchSupplier[this.SearchSupplier.Count - 1].ID;
                            //this.SelectedSearchSupplier = SupplierIdSelected;
                            RefreshData();
                        }
                        else
                        {
                            this.TotalSupplier = supplierRepository.GetAllSupplier().Count();
                            this.InActiveSupplier = supplierRepository.GetSupplierCount("Y");
                            this.ActiveSupplier = TotalSupplier - InActiveSupplier;
                        }

                    }
                    else
                    {
                        MessageBox.Show("There was some problem while updating the values, Kindly try again later.");
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
            //if (supplier.ChangeSupplierGST == true)
            //{
            //    this.ChangeSupplierGSTTrue = supplier.ChangeSupplierGST;
            //    this.ChangeSupplierGSTFalse = false;
            //}
            //else
            //{
            //    this.ChangeSupplierGSTTrue = false;
            //    this.ChangeSupplierGSTFalse = true;
            //}
            Mouse.OverrideCursor = null;
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
        void NewSupplier(object param)
        {
           // Mouse.OverrideCursor = Cursors.Wait;
            this.ID = 0;
            this.SupplierName = string.Empty;
            this.Balance = string.Empty;
            this.ContactPerson = string.Empty;
            this.CreditLimitAmount =string.Empty;
            this.ContactPerson = string.Empty;
            //this.CreditLimitAmount = null as decimal?;
            this.CreditLimitDays = string.Empty;
            this.Email = string.Empty;
            this.Fax = string.Empty;
            this.GstRegistrationNo = string.Empty;
            this.IsInActive = string.Empty;
            this.ShipAddressLine1 = string.Empty;
            this.ShipAddressLine2 = string.Empty;
            this.ShipCity = string.Empty;
            this.ShipCountry = string.Empty;
            this.ShipPostalCode = string.Empty;
            this.ShipState = string.Empty;
            this.Supp_Reg_No = string.Empty;
            this.Sup_Bill_to_city = string.Empty;
            this.Sup_Bill_to_country = string.Empty;
            this.Sup_Bill_to_line1 = string.Empty;
            this.Sup_Bill_to_line2 = string.Empty;
            this.Sup_Bill_to_post_code = string.Empty;
            this.Sup_Bill_to_state = string.Empty;
            this.Telephone = string.Empty;
            this.IsInActive = "N";
            this.SelectedSearchSupplier = 0;
           // Mouse.OverrideCursor = null;
            //this.Sup_Bill_to_line1 = string.Empty;
            //this.Sup_Bill_to_line2 = string.Empty;
            //this.Sup_Bill_to_post_code = string.Empty;
            //this.
        }
        void sameasbilltoadd(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.ShipAddressLine1 = this.Sup_Bill_to_line1;
            this.ShipAddressLine2 = this.Sup_Bill_to_line2;
            this.ShipCity = this.Sup_Bill_to_city;
            this.ShipCountry = this.Sup_Bill_to_country;
            this.ShipPostalCode = this.Sup_Bill_to_post_code;
            this.ShipState = this.Sup_Bill_to_state;
            Mouse.OverrideCursor = null;
        }
        void nextsupplier(object param)
        {
            //var current = SearchSupplier.FirstOrDefault(x => x.ID == SelectedSearchSupplier);

            //int index = SearchSupplier.IndexOf(current);

            //if (index < SearchSupplier.Count - 1)
            //{
            //    var next = SearchSupplier.ElementAt(index + 1);
            //    this.SelectedSearchSupplier = next.ID;

            //}
            Mouse.OverrideCursor = Cursors.Wait;
            var current = SearchSupplier.FirstOrDefault(x => x.ID == SelectedSearchSupplier);

            int index = SearchSupplier.IndexOf(current);

            if (index < SearchSupplier.Count - 1)
            {
                var next = SearchSupplier.ElementAt(index + 1);
                this.SelectedSearchSupplier = next.ID;

            }
            if (index >= SearchSupplier.Count - 2)
            {
                this.ForwardEnabled = false;
                if (index - 1 <= 0)
                    this.BackwardEnabled = false;
                else
                    this.BackwardEnabled = true;
            }

            else
            {
                this.ForwardEnabled = true;
                if (index - 1 <= 0)
                    this.BackwardEnabled = true;
                else
                    this.BackwardEnabled = true;
            }
            Mouse.OverrideCursor = null;

        }
        void previoussupplier(object param)
        {
            //var current = SearchSupplier.FirstOrDefault(x => x.ID == SelectedSearchSupplier);
            //int index = SearchSupplier.IndexOf(current);
            //if (index > 0)
            //{
            //    var next = SearchSupplier.ElementAt(index - 1);
            //    this.SelectedSearchSupplier = next.ID;
            //}
            Mouse.OverrideCursor = Cursors.Wait;
            var current = SearchSupplier.FirstOrDefault(x => x.ID == SelectedSearchSupplier);

            int index = SearchSupplier.IndexOf(current);

            if (index > 0)
            {
                var next = SearchSupplier.ElementAt(index - 1);
                this.SelectedSearchSupplier = next.ID;
            }
            if (index - 1 <= 0)
            {
                this.BackwardEnabled = false;
                if (index >= SearchSupplier.Count - 2)
                {
                    this.ForwardEnabled = false;
                }
                else
                {
                    this.ForwardEnabled = true;
                }
            }
            else
            {
                this.BackwardEnabled = true;
                if (index >= SearchSupplier.Count - 2)
                {
                    this.ForwardEnabled = true;
                }
                else
                {
                    this.ForwardEnabled = true;
                }
            }
            Mouse.OverrideCursor = null;
        }
        void deletesupplier(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ISupplierRepository supplierRepository = new SupplierRepository();

            MessageBoxResult result = MessageBox.Show("Do you want to delete the Supplier Details?\n"+ "@ Simple Accounting Software Pte Ltd", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    var candeletesupplier = supplierRepository.CanDeleteSupplier(this.SelectedSearchSupplier);
                    if (candeletesupplier)
                    {
                        var deletesupplier = supplierRepository.DeleteSupplier(this.SelectedSearchSupplier);
                        if (deletesupplier)
                        {
                            RefreshData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("you can not delete this supplier!\n"+ "@ Simple Accounting Software Pte Ltd", "Warning", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
            Mouse.OverrideCursor = null;
        }
        void RefreshSupplierData(object param)
        {
            //Mouse.OverrideCursor = Cursors.Wait;
            //bool IsSuccess = false;
            //if (this.ID > 0)
            //{
            //    ISupplierRepository repo = new SupplierRepository();
            //    //MessageBoxResult result = MessageBox.Show("Do you want to refresh data?", "Refresh data", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //    //if (result == MessageBoxResult.Yes) { 
            //    IsSuccess = repo.RefreshSupplier(this.ID);
            //    if (IsSuccess == false)
            //    {
            //        MessageBox.Show("Error while refreshing data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }

            //    //}

            //}
            //else
            //{
            //    MessageBox.Show("Can't refresh data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            //Mouse.OverrideCursor = null;
            this.SelectedSearchSupplier = 0;
            this.LoadSupplierBackground(SharedValues.getValue);
        }

        #region BackGround Worker
        private void LoadSupplierBackground(string Id)
        {
            Mouse.OverrideCursor = Cursors.Wait;

            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;
            worker.DoWork += (s, e) =>
            {
                Thread.Sleep(2000);
            };
            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadSupplierBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadSupplierBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
           

            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadSupplierBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {
            //ICustomerRepository customerRepository = new CustomerRepository();

            //this.CustomerType = customerRepository.GetCatagoryType("CT").ToList();

            //this.SalesmanType = customerRepository.GetCatagoryType("SM").ToList();
            //GetCustomerCreditLimit();

            GetOptionsData();
            RefreshData();
        }

        //private void GetCustomerCreditLimit()
        //{
        //    ICustomerRepository customerRepository = new CustomerRepository();
        //    this.CreditLimitDays = customerRepository.GetCatagoryType("CCLD").ToList();
        //    this.CreditLimitAmount = customerRepository.GetCatagoryType("CCLA").ToList();
        //    this.Discount = customerRepository.GetCatagoryType("CD").ToList();
        //    if (this.ID == -1)
        //    {
        //        var data = CreditLimitDays.Where(y => y.SetDefault == true).Select(x => x.ID).FirstOrDefault();
        //        if (data != null)
        //        {
        //            SelectedCreditLimitDays = Convert.ToInt32(data);
        //        }
        //        var data2 = CreditLimitAmount.Where(y => y.SetDefault == true).Select(x => x.ID).FirstOrDefault();
        //        if (data2 != null)
        //        {
        //            SelectedCreditLimitAmount = Convert.ToInt32(data2);
        //        }
        //        var data3 = Discount.Where(y => y.SetDefault == true).Select(x => x.ID).FirstOrDefault();
        //        if (data3 != null)
        //        {
        //            SelectedDiscount = Convert.ToInt32(data3);
        //        }
        //    }

        //}
        private void RefreshData()
        {
            ISupplierRepository supplierRepository = new SupplierRepository();
            this.TotalSupplier = supplierRepository.GetAllSupplier().Count();
            this.InActiveSupplier = supplierRepository.GetSupplierCount("Y");
            this.ActiveSupplier = TotalSupplier - InActiveSupplier;
            this.SearchSupplier = supplierRepository.GetAllSupplier().ToList();
            this.IsAllowedToChangeCLA_and_Discount = supplierRepository.AllowedToChangeLimit();
            string setdateFormat = this.DateFormat == null ? "{0:dd/MM/yyyy}" : "{0:" + this.DateFormat + "}";
            int supId = 0;
            ChangeSupplierGSTTrue = false;
            ChangeSupplierGSTFalse = true;
            DateTime? dtRefresh = DateTime.UtcNow;
            if (SharedValues.getValue == "New" || SharedValues.getValue == "SupplierDetailTab")
            {
                NewSupplier(null);
            }
            else
            {
                if (SearchSupplier.Count > 0)
                {
                    int SupplierSelectedId = 0;
                    if (SharedValues.getValue != null)
                    {
                        bool isValid = Int32.TryParse(SharedValues.getValue, out SupplierSelectedId);
                    }
                    // int SupplierSelectedId = Convert.ToInt32(SharedValues.getValue);
                    if (SupplierSelectedId != 0)
                    {
                        this.SelectedSearchSupplier = SupplierSelectedId;
                    }
                    else
                    {
                        //var dataRefresh = SearchSupplier.Find(x => x.IsRefreshed != null && x.IsRefreshed == true);
                        //if (dataRefresh != null)
                        //{
                        //    supId = dataRefresh.ID;
                        //    this.SelectedSearchSupplier = supId;
                        //    dtRefresh = (dataRefresh.RefreshedDate != null) ? DateTime.UtcNow : dataRefresh.RefreshedDate;
                        //}
                        //else
                        //{

                        supId = SearchSupplier[0].ID;
                        this.SelectedSearchSupplier = supId;
                        this.LastUpdateDate = String.Format(setdateFormat, this.SearchSupplier.OrderByDescending(x => x.Createddate).FirstOrDefault().Createddate);
                        //}
                        this.LastUpdateDate = String.Format(setdateFormat, dtRefresh);
                    }
                }
                else
                {
                    this.SelectedSearchSupplier = supId;
                    //this.ChangeCustomerGST = IsCompanyRegisteredForGST;
                    this.LastUpdateDate = String.Format(setdateFormat, System.DateTime.Now);
                }
                this.GetData(this.SelectedSearchSupplier);
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
                case "SelectedSearchSupplier":
                    GetData(this.SelectedSearchSupplier);
                    break;
            }

            base.OnPropertyChanged(name);
        }
        public bool CanDelete(object param)
        {
            //if (IsNew == false)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        public bool CanSave(object param)
        {
            if (!String.IsNullOrEmpty(SupplierName))
            {
                return true;
            }
            else
            {
                return false;
            }
            return true;
        }

        public void GetData(int supplierId)
        {
            ISupplierRepository repo = new SupplierRepository();

            var supplier = repo.GetAllSupplier().Where(x => x.ID == supplierId).FirstOrDefault();

            if (supplier != null)
            {
                if (supplier.TaxId == null && supplier.ChangeSupplierGST == false)
                {
                    this.SelectedTaxId = 0;
                }
                else
                {
                    this.SelectedTaxId = supplier.TaxId;
                }
                this.SelectedSearchSupplier = supplier.ID;
                this.SupplierName = supplier.SupplierName;
                this.Email = supplier.Email;
                this.Fax = supplier.Fax;
                //this.SelectedSalesman = supplier.Cus_Salesman;
                //this.SelectedCustomerType = supplier.Cus_Type;
                //this.SelectedCreditLimitDays = supplier.Cus_Credit_Limit_Days;
                //this.SelectedCreditLimitAmount = supplier.Cus_Credit_Limit_Amount;
                this.Telephone = supplier.Telephone;
                //this.SelectedDiscount = supplier.Discount;
                this.CreditLimitDays = supplier.CreditLimitDays;
                //this.CreditLimitAmount = Math.Round(Convert.ToDecimal(supplier.CreditLimitAmount), Convert.ToInt32(this.DecimalPlaces));
                this.CreditLimitAmount = supplier.CreditLimitAmount;
                this.Supp_Reg_No = supplier.Supp_Reg_No;
                this.Sup_Bill_to_city = supplier.Sup_Bill_to_city;
                this.Sup_Bill_to_country = supplier.Sup_Bill_to_country;
                this.Sup_Bill_to_line1 = supplier.Sup_Bill_to_line1;
                this.Sup_Bill_to_line2 = supplier.Sup_Bill_to_line2;
                this.Sup_Bill_to_post_code = supplier.Sup_Bill_to_post_code;
                this.Sup_Bill_to_state = supplier.Sup_Bill_to_state;
                this.ShipAddressLine1 = supplier.ShipAddressLine1;
                this.ShipAddressLine2 = supplier.ShipAddressLine2;
                this.ShipCity = supplier.ShipCity;
                this.ShipCountry = supplier.ShipCountry;
                this.ShipState = supplier.ShipState;
                this.ShipPostalCode = supplier.ShipPostalCode;
                this.ContactPerson = supplier.ContactPerson;
                this.GstRegistrationNo = supplier.GstRegistrationNo;
                this.Remarks = supplier.Remarks;
                this.IsInActive = supplier.IsInActive;
                this.ChangeSupplierGST = supplier.ChangeSupplierGST;
                this.Balance = supplier.Balance;
                this.ID = supplier.ID;
               
                //this.IsInActive = supplier.IsInActive;
                if (supplier.ChangeSupplierGST == true)
                {
                    this.ChangeSupplierGSTTrue = supplier.ChangeSupplierGST;
                    this.ChangeSupplierGSTFalse = false;
                }
                else
                {
                    this.ChangeSupplierGSTTrue = false;
                    this.ChangeSupplierGSTFalse = true;
                }

                ///Disable Privous button
                var current = SearchSupplier.FirstOrDefault(x => x.ID == SelectedSearchSupplier);

                int index = SearchSupplier.IndexOf(current);
                if (index - 1 <= 0)
                {
                    this.BackwardEnabled = false;
                    if (index >= SearchSupplier.Count - 1)
                    {
                        this.ForwardEnabled = false;
                    }
                    else
                    {
                        this.ForwardEnabled = true;
                    }
                }
                else
                {
                    this.BackwardEnabled = true;
                    if (index >= SearchSupplier.Count - 1)
                    {
                        this.ForwardEnabled = true;
                    }
                    else
                    {
                        this.ForwardEnabled = true;
                    }
                }
                ///disable next button
                var current1 = SearchSupplier.FirstOrDefault(x => x.ID == SelectedSearchSupplier);

                int index1 = SearchSupplier.IndexOf(current);


                if (index1 >= SearchSupplier.Count - 1)
                {
                    this.ForwardEnabled = false;
                    if (index1 <= 0)
                        this.BackwardEnabled = false;
                    else
                        this.BackwardEnabled = true;
                }

                else
                {
                    this.ForwardEnabled = true;
                    if (index1 <= 0)
                        this.BackwardEnabled = false;
                    else
                        this.BackwardEnabled = true;
                }




            }
            else
            {
                this.ID = 0;
                this.SupplierName = string.Empty;
                this.Balance = string.Empty;
                this.ContactPerson = string.Empty;
                //this.CreditLimitAmount = null as decimal?;
                this.CreditLimitAmount = string.Empty;
                this.ContactPerson = string.Empty;
              
                this.CreditLimitDays = string.Empty;
                this.Email = string.Empty;
                this.Fax = string.Empty;
                this.GstRegistrationNo = string.Empty;
                this.IsInActive = string.Empty;
                this.ShipAddressLine1 = string.Empty;
                this.ShipAddressLine2 = string.Empty;
                this.ShipCity = string.Empty;
                this.ShipCountry = string.Empty;
                this.ShipPostalCode = string.Empty;
                this.ShipState = string.Empty;
                this.Supp_Reg_No = string.Empty;
                this.Sup_Bill_to_city = string.Empty;
                this.Sup_Bill_to_country = string.Empty;
                this.Sup_Bill_to_line1 = string.Empty;
                this.Sup_Bill_to_line2 = string.Empty;
                this.Sup_Bill_to_post_code = string.Empty;
                this.Sup_Bill_to_state = string.Empty;
                this.Telephone = string.Empty;
                this.IsInActive = "N";
                this.SelectedSearchSupplier = 0;
                this.SelectedTaxId = 0;
            }
        }
        /// <summary>
        ///  Occurs when System.ComponentModel.BackgroundWorker.ReportProgress(System.Int32) is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void LoadSupplierBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {

        }

        ///// <summary>
        /////  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        ///// </summary>
        ///// <param name="sender">The sender.</param>
        ///// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadSupplierBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = 
            Mouse.OverrideCursor = null;

        }

        private void GetOptionsData()
        {
            OptionsEntity oData = new OptionsEntity();
            ISupplierRepository supplierRepository = new SupplierRepository();
            oData = supplierRepository.GetOptionSettings();
            if (oData != null)
            {
                this.CurrencyName = oData.CurrencyCode;     //there is no currency name field in database         
                this.CurrencyCode = oData.CurrencyCode;
                this.CurrencyFormat = oData.NumberFormat;
                this.DateFormat = oData.DateFormat;
                this.DecimalPlaces = oData.DecimalPlaces;
            }
            else
            {
                this.CurrencyName = "USD";
                this.CurrencyCode = "USD";
                this.CurrencyFormat = "en-US";
                this.DateFormat = "dd/MM/yyyy";
            }

            this.TaxandRateList = supplierRepository.GetTaxCodeAndRatesList();

            if(TaxandRateList!=null)
            {
                this.TaxName = TaxandRateList.FirstOrDefault().TaxName;
            }
            else
            {
                this.TaxName = "GST";               
            }
            TaxModel objDefaultTax = new TaxModel();
             objDefaultTax = supplierRepository.GetDefaultTaxes();
            if (objDefaultTax != null)
            {
                this.TaxRate = objDefaultTax.TaxRate;
                this.SelectedTaxId = objDefaultTax.TaxID;
                //this.TaxName = objDefaultTax.TaxRate;
            }
            
        }

        //public DelegateCommand SaveClickCommand
        //{
        //    get
        //    {
        //        return (this.saveClickCommand ?? new DelegateCommand(this.OnSaveSupplier));
        //    }
        //}

        //public DelegateCommand SameAsBillingAddressCommand
        //{
        //    get
        //    {
        //        return (this.sameAsBillingAddressCommand ?? new DelegateCommand(OnSameAsBillAddress));
        //    }
        //}

        //private void OnSameAsBillAddress()
        //{
        //    //var shippingAddress = new ShippingAddress();
        //    this.ShipCity = this.Cus_Bill_to_city;
        //    this.ShipAddressLine1 = this.Cus_Bill_to_line1;
        //    this.ShipAddressLine2 = this.Cus_Bill_to_line2;
        //    this.ShipState = this.Cus_Bill_to_state;
        //    this.ShipPostalCode = this.Cus_Bill_to_post_code;
        //    this.ShipCountry = this.Cus_Bill_to_country;

        //}

        //public DelegateCommand NewShippingClickCommand
        //{
        //    get
        //    {
        //        return (this.newShippingClickCommand ?? new DelegateCommand(this.OnNewShippingAddress));
        //    }
        //}

        //public DelegateCommand PreviousCommand
        //{
        //    get
        //    {
        //        return (this.previousCommand ?? new DelegateCommand(this.OnPreviouClick));
        //    }
        //}

        //public DelegateCommand NextCommand
        //{
        //    get
        //    {
        //        return (this.nextCommand ?? new DelegateCommand(this.OnNextClick));
        //    }
        //}

        //public DelegateCommand NewCustomerClickCommand
        //{
        //    get
        //    {
        //        return (this.newCustomerClickCommand ?? new DelegateCommand(this.OnNewCustomer));
        //    }
        //}
        //public DelegateCommand CancelClickCommand
        //{
        //    get
        //    {
        //        return (this.cancelClickCommand ?? new DelegateCommand(this.OnCancelClick));
        //    }
        //}

        //private void OnCancelClick()
        //{
        //    RefreshData();
        //}

        ////public DelegateCommand DeleteCustomerClickCommand
        ////{
        ////    get
        ////    {
        ////        return (this.deleteCustomerClickCommand ?? new DelegateCommand(this.OnDeleteCustomer));
        ////    }
        ////}
        //private void OnDeleteCustomer(object param)
        //{
        //    IsNew = false;
        //    int custId = this.SelectedSearchCustmer;
        //    bool canDelete = false;
        //    ICustomerRepository repo = new CustomerRepository();
        //    canDelete = repo.CanDeleteCustomer(custId);
        //    if (canDelete)
        //    {
        //        MessageBoxResult result = MessageBox.Show("Do you want to delete customer?", "Delete Customer", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //        if (result == MessageBoxResult.Yes)
        //        {
        //            canDelete = repo.DeleteCustomer(custId);
        //            if (canDelete)
        //            {
        //                RefreshData();
        //            }
        //        }
        //    }

        //}
        //private void OnNewShippingAddress()
        //{
        //    this.ClearShippingAddress();
        //    var address = new ShippingAddress();

        //}

        //private void OnSaveCustomer(object param)
        //{
        //    CustomerErrors = ValidateCustomer();
        //    if (CustomerErrors != string.Empty)
        //    {
        //        return;
        //    }
        //    MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Content", MessageBoxButton.YesNo);
        //    if (result == MessageBoxResult.Yes)
        //    {
        //        ICustomerRepository repo = new CustomerRepository();
        //        var customer = repo.GetAllCustomers().FirstOrDefault(x => x.ID == this.ID & x.IsDeleted != true);

        //        if (customer == null)
        //        {
        //            customer = new Customer();
        //            customer.ID = -1;
        //            customer.CreatedBy = loginId;
        //            customer.CreatedDate = System.DateTime.UtcNow;
        //        }
        //        else
        //        {
        //            customer.ModifiedBy = loginId;
        //            customer.ModifiedDate = System.DateTime.UtcNow;
        //        }

        //        customer.Cus_Name = CustomerName;
        //        customer.Cus_Email = Email;
        //        customer.Cus_Fax = Fax;
        //        customer.Cus_Discount = SelectedDiscount;
        //        customer.Cus_Company_Reg_no = Comp_Reg_No;
        //        customer.Cus_Bill_to_city = Cus_Bill_to_city;
        //        customer.Cus_Bill_to_country = Cus_Bill_to_country;
        //        customer.Cus_Bill_to_line1 = Cus_Bill_to_line1;
        //        customer.Cus_Bill_to_line2 = Cus_Bill_to_line2;
        //        customer.Cus_Bill_to_post_code = Cus_Bill_to_post_code;
        //        customer.Cus_Bill_to_state = Cus_Bill_to_state;
        //        customer.Cus_Ship_to_line1 = ShipAddressLine1;
        //        customer.Cus_Ship_to_line2 = ShipAddressLine2;
        //        customer.Cus_Ship_to_city = ShipCity;
        //        customer.Cus_Ship_to_state = ShipState;
        //        customer.Cus_Ship_to_country = ShipCountry;
        //        customer.Cus_Ship_to_post_code = ShipPostalCode;
        //        customer.Cus_Charge_GST = ChangeCustomerGST;
        //        customer.Cus_Salesman = SelectedSalesman;
        //        customer.Cus_Telephone = Telephone;
        //        customer.Cus_Type = SelectedCustomerType;
        //        customer.Cus_Credit_Limit_Days = SelectedCreditLimitDays;

        //        customer.Cus_Credit_Limit_Amount = SelectedCreditLimitAmount;
        //        customer.Cus_Contact_Person = ContactPerson;
        //        customer.Cus_GST_Reg_No = GstRegistrationNo;
        //        customer.Cus_Inactive = IsInActive;
        //        customer.Cus_Remarks = Remarks;

        //        repo.CreateCustomer(customer);

        //        IsNew = false;
        //    }
        //    else
        //    {
        //        IsNew = true;
        //    }
        //}

        //private void OnNextClick()
        //{
        //    var current = SearchCustomer.FirstOrDefault(x => x.ID == SelectedSearchCustmer);

        //    int index = SearchCustomer.IndexOf(current);

        //    if (index < SearchCustomer.Count - 1)
        //    {
        //        var next = SearchCustomer.ElementAt(index + 1);
        //        this.SelectedSearchCustmer = next.ID;

        //    }

        //}

        //private void OnPreviouClick()
        //{
        //    var current = SearchCustomer.FirstOrDefault(x => x.ID == SelectedSearchCustmer);

        //    int index = SearchCustomer.IndexOf(current);

        //    if (index > 0)
        //    {
        //        var next = SearchCustomer.ElementAt(index - 1);
        //        this.SelectedSearchCustmer = next.ID;
        //    }
        //}
        //private string ValidateCustomer()
        //{
        //    string EmailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        //    string PhonePattern = @"\+?\d[\d -]{8,15}\d";

        //    StringBuilder msg = new StringBuilder();
        //    if (CustomerName == null || CustomerName.Trim() == string.Empty)
        //    {
        //        msg.Append("Customer Name is Required.\n");
        //    }

        //    if (!String.IsNullOrEmpty(Email))
        //    {
        //        if (!Regex.IsMatch(Email, EmailPattern))
        //        {
        //            msg.Append("Invalid Email Address.\n");
        //        }
        //    }

        //    if (!String.IsNullOrEmpty(Telephone))
        //    {
        //        if (!Regex.IsMatch(Telephone, PhonePattern))
        //        {
        //            msg.Append("Invalid Phone No.\n");
        //        }
        //    }
        //    return msg.ToString();
        //}
        //private void ClearShippingAddress()
        //{
        //    this.ShipAddressLine1 = string.Empty;
        //    this.ShipAddressLine2 = string.Empty;
        //    this.ShipCity = string.Empty;
        //    this.ShipCountry = string.Empty;
        //    this.ShipState = string.Empty;
        //    this.ShipPostalCode = string.Empty;
        //}

        //private void OnNewCustomer()
        //{
        //    this.ID = -1;
        //    this.CustomerName = string.Empty;
        //    this.Email = string.Empty;
        //    this.Fax = string.Empty;
        //    this.SelectedSalesman = null;
        //    this.SelectedCustomerType = "-1";
        //    this.SelectedCreditLimitDays = null;
        //    this.SelectedCreditLimitAmount = null;
        //    this.Telephone = string.Empty;
        //    this.SelectedDiscount = null;
        //    this.Comp_Reg_No = string.Empty;
        //    this.Cus_Bill_to_city = string.Empty;
        //    this.Cus_Bill_to_country = string.Empty;
        //    this.Cus_Bill_to_line1 = string.Empty;
        //    this.Cus_Bill_to_line2 = string.Empty;
        //    this.Cus_Bill_to_post_code = string.Empty;
        //    this.Cus_Bill_to_state = string.Empty;
        //    this.ShipAddressLine1 = string.Empty;
        //    this.ShipAddressLine2 = string.Empty;
        //    this.ShipCity = string.Empty;
        //    this.ShipCountry = string.Empty;
        //    this.ShipState = string.Empty;
        //    this.ShipPostalCode = string.Empty;
        //    this.ContactPerson = string.Empty;
        //    this.GstRegistrationNo = string.Empty;
        //    this.ChangeCustomerGST = false;
        //    this.Balance = null;

        //    this.IsInActive = "N";
        //    this.Remarks = string.Empty;
        //    IsNew = true;
        //    GetCustomerCreditLimit();
        //}

        //#endregion Background Worker

        #endregion

        #region AutoFill
        public List<Country> AutoFillCountry()
        {

            ISupplierRepository repo = new SupplierRepository();
            return repo.AutoFillCountry();

        }

        public List<State> AutoFillState()
        {

            ISupplierRepository repo = new SupplierRepository();
            return repo.AutoFillState();

        }
        public List<City> AutoFillCity()
        {

            ISupplierRepository repo = new SupplierRepository();
            return repo.AutoFillCity();

        }
        public List<PostalCode> AutoFillPostalCode()
        {

            ISupplierRepository repo = new SupplierRepository();
            return repo.AutoFillPostalCode();

        }
        #endregion

    }
}


