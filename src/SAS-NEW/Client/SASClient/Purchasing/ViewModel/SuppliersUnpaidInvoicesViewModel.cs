
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.ViewModel
{
    using CloseRequest;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using SDN.Common;
    using SDN.Purchasing.Services;
    using SDN.Purchasing.View;
    using SDN.UI.Entities;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Suppliers;
    using Services;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    public class SuppliersUnpaidInvoicesViewModel: SuppliersUnpaidInvoicesEntity
    {
        #region "Private members"

        private ISuppliersUnPaidInvoicesRepository uiRepository = new SuppliersUnPaidInvoicesRepository();
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public event PropertyChangedEventHandler PropertyChanged;
        private int Count = 0;
        private DateTime? selectedStatementDate;
        StackList listitem = new StackList();
        #endregion

        #region "Properties"

        public DateTime? SelectedStatementDate
        {
            get { return selectedStatementDate; }
            set { selectedStatementDate = value;
                OnPropertyChanged("SelectedStatementDate");
                OnDateSelected();
            }
        }

        #endregion

        #region "Constructors"
        public SuppliersUnpaidInvoicesViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            SelectChangedCommand = new RelayCommand(OnSelectionChange);
            NavigateToInvoiceCommand = new RelayCommand(PurchaseInvoiceCommand);
            //StatementDate = DateTime.Now;
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var last = month.AddDays(-1);
            CloseCommand = new DelegateCommand(Close);
            SelectedStatementDate = last;
        }
        public SuppliersUnpaidInvoicesViewModel()
        {
        }
        #endregion

        #region "Relay Commands"
        public ICommand CloseCommand { get; set; }
        public RelayCommand SelectChangedCommand { get; set; }
        public RelayCommand NavigateToInvoiceCommand { get; set; }

        #endregion

        #region "Action Methods"
        public void RefreshData()
        {
            GetOptionsandTaxValues();
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
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            IPurchaseInvoiceListRepository purchaseRepository = new PurchaseInvoiceListRepository();
            oData = purchaseRepository.GetOptionSettings();
            if (oData != null)
            {
                this.CurrencyName = oData.CurrencyCode;     //there is no currency name field in database          
            }
            else
            {
                this.CurrencyName = "USD";
                this.DateFormat = "dd/MM/yyyy";
            }
            
            TaxModel objDefaultTax = new TaxModel();
            objDefaultTax = purchaseRepository.GetDefaultTaxes().FirstOrDefault();
            if (objDefaultTax != null)
            {
                this.TaxName = objDefaultTax.TaxName;
                //this.TaxName = objDefaultTax.TaxRate;
            }
            else
            {
                this.TaxName = "GST";
                //this.TaxRate = 0;
            }
        }

        public void OnDateSelected()
        {
            LstSuppliers = uiRepository.GetSuppliersList(Convert.ToString(SelectedStatementDate));

        }



        public void OnSelectionChange(object param)
        {
            if (SelectedSupplierID != 0)
            {
                BalAndUnpaidInv = uiRepository.GetAllUnPaidInvoice(SelectedSupplierID, Convert.ToString(SelectedStatementDate));
                LstBalances = BalAndUnpaidInv.LstBalances;
                LstInvoiceDetails = BalAndUnpaidInv.LstInvoices;
                LstSuppliers.Where(c => c.SupplierID == SelectedSupplierID).ToList().ForEach(cc => cc.IsSelected = true);
                //LstSuppliers.Where(c => c.SupplierID != SelectedSupplierID).ToList().ForEach(cc => cc.IsSelected = false);
                LstInvoiceDetails = LstInvoiceDetails.OrderBy(x => x.InvoiceDate).ToList();
                TotalInvoiceAmount = Convert.ToString(LstInvoiceDetails.Sum(e => e.InvoiceAmount));
                TotalPaidAmount = Convert.ToString(LstInvoiceDetails.Sum(e => e.AmountPaid));
                TotalDueAmount = Convert.ToString(LstInvoiceDetails.Sum(e => e.AmountDue));
            }
            else
            {

            }
        }
        void PurchaseInvoiceCommand(object param)
        {
            SharedValues.ScreenCheckName = "Purchases Invoice (P & S)";
            SharedValues.ViewName = "Purchase Invoice (Products & Services)";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                string obj = param.ToString();
            SharedValues.NewClick = obj;
            SharedValues.getValue = "PurchaseInvoiceTab";
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<PurchaseInvoicePandSView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }////
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoice - Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }

        }
        #endregion

        #region BackgroundWorked
        private void LoadSupplierBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();
            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;
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
            int minHeight = 300;
            int headerRows = 270;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows -52;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.GridHeight = minHeight;
            this.InvoiceGridHeight = GridHeight - 31;
            RefreshData();
        }
        //List<PandSSellPriceListEntity> DefaultList = new List<PandSSellPriceListEntity>();
        //List<PandSSellPriceListEntity> FullList = new List<PandSSellPriceListEntity>();
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

            Mouse.OverrideCursor = null;
            Count = 1;

        }
        #endregion
    }
}
