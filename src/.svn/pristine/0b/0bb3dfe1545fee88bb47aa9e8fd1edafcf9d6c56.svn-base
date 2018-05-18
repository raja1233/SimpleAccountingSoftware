

namespace SDN.Sales.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using SDN.Common;
    using SDN.Sales.Services;
    using SDN.UI.Entities;    
    using System.Collections.Generic;
    using System.Linq;

    public sealed class CustomersViewModel:ViewModelBase
    {
       
        #region Private Properties

        /// <summary>
        /// The customer collection
        /// </summary>
        private ObservableCollection<CustomersEntity> customersData = new ObservableCollection<CustomersEntity>();
        private List<CatagoryType> _customerType;
        private List<CatagoryType> _salesmanType;
        private List<CatagoryType> creditLimitDays;
        private List<CatagoryType> creditLimitAmount;
        private List<CatagoryType> discount;
        private int _totalCustomer = 0;
        private int activeCustomer = 0;
        private int inActiveCustomer = 0;
        private string customerName;

        #endregion  Private Properties

        #region Public Properties

        /// <summary>
        /// Gets or sets the customer collection.
        /// </summary>
        /// <value>
        /// The customer collection.
        /// </value>
        public ObservableCollection<CustomersEntity> CustomersData
        {
            get
            {
                return this.customersData;
            }
            set
            {
                this.customersData = value;
            }
        }

        #endregion  Public Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersViewModel"/> class.
        /// </summary>
        public CustomersViewModel()
            : base()
        {
            this.LoadCustomersBackground();
        }
        #endregion  Constructor

        #region Background Worker

        /// <summary>
        /// Loads the customers background.
        /// </summary>
        private void LoadCustomersBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;

            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadCustomersBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadCustomersBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadCustomersBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadCustomersBackground(object sender, DoWorkEventArgs e)
        {
            ICustomerRepository customerRepository = new CustomerRepository();

            this.CustomerType = customerRepository.GetCatagoryType("CT").ToList();

            this.SalesmanType = customerRepository.GetCatagoryType("SM").ToList() ;

            this.CreditLimitDays = customerRepository.GetCatagoryType("CCLD").ToList();

            this.CreditLimitAmount = customerRepository.GetCatagoryType("CCLA").ToList();

            this.Discount = customerRepository.GetCatagoryType("CD").ToList();

            this.TotalCustomer = customerRepository.GetAllCustomers().Count();

            
            
            //BackgroundWorker source = (BackgroundWorker)sender;

            //var results = customerRepository.GetAllCustomers();
            //int index = 0;
            //foreach (var item in results)
            //{

            //    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
            //    source.ReportProgress(++index, item);
            //}
        }

        public List<CatagoryType> CustomerType
        {
            get { return _customerType; }

            set
            {
                if (_customerType != value)
                {
                    _customerType = value;
                    OnPropertyChanged("CustomerType");

                }
            }

        }
        public List<CatagoryType> CreditLimitDays
        {
            get { return creditLimitDays; }

            set
            {
                if (creditLimitDays != value)
                {
                    creditLimitDays = value;
                    OnPropertyChanged("CreditLimitDays");
                }
            }
        }
        public List<CatagoryType> CreditLimitAmount
        {
            get { return creditLimitAmount; }

            set
            {
                if (creditLimitAmount != value)
                {
                    creditLimitAmount = value;
                    OnPropertyChanged("CreditLimitAmount");
                }
            }
        }
        public List<CatagoryType> Discount
        {
            get { return discount; }

            set
            {
                if (discount != value)
                {
                    discount = value;
                    OnPropertyChanged("Discount");
                }
            }
        }

        public List<CatagoryType> SalesmanType
        {
            get { return _salesmanType; }

            set
            {
                if (_salesmanType != value)
                {
                    _salesmanType = value;
                    OnPropertyChanged("SalesmanType");

                }
            }
        }

        public int TotalCustomer
        {
            get { return _totalCustomer; }

            set
            {
                if (_totalCustomer != value)
                {
                    _totalCustomer = value;
                    OnPropertyChanged("TotalCustomer");

                }
            }
        }

        public int ActiveCustomer
        {
            get { return activeCustomer; }

            set
            {
                if (activeCustomer != value)
                {
                    activeCustomer = value;
                    OnPropertyChanged("ActiveCustomer");

                }
            }
        }

        public int InActiveCustomer
        {
            get { return inActiveCustomer; }

            set
            {
                if (inActiveCustomer != value)
                {
                    inActiveCustomer = value;
                    OnPropertyChanged("InActiveCustomer");
                }
            }
        }

        public string CustomerName
        {
            get { return customerName; }

            set
            {
                if (customerName != value)
                {
                    customerName = value;
                    OnPropertyChanged("CustomerName");
                }
            }
        }

        /// <summary>
        ///  Occurs when System.ComponentModel.BackgroundWorker.ReportProgress(System.Int32) is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void LoadCustomersBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            //this.CustomerCollection.Add((CustomerEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadCustomersBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {

            Mouse.OverrideCursor = null;
            //this.OnPropertyChanged("BillingAddressCollection");
            //this.OnPropertyChanged("ShippingAddressCollection");
        }

        #endregion Background Worker
        
    }
}
