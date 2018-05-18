﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SASClient.CloseRequest;
using SASClient.Purchasing.Services;
using SDN.Common;
using SDN.Purchasing.View;
using SDN.UI.Entities;
using SDN.UI.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SASClient.Purchasing.ViewModel
{
    public class SupplierPaymentDueDaysViewModel : SupplierPaymentDueDaysEntity
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public event PropertyChangedEventHandler PropertyChanged;
        StackList listitem = new StackList();
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseInvoiceListViewModel"/> class.
        /// </summary>
        public SupplierPaymentDueDaysViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            NavigateToSupplierCommand = new RelayCommand(NavigateToSupplier);
            CloseCommand = new DelegateCommand(Close);
        }

        public SupplierPaymentDueDaysViewModel()
        {
        }
        #endregion
        public ICommand CloseCommand { get; set; }
        public RelayCommand NavigateToSupplierCommand { get; set; }

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
        List<SupplierPaymentDueDaysEntity> DefaultList = new List<SupplierPaymentDueDaysEntity>();
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {
            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 37;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.GridHeight = minHeight;

            RefreshData();
        }
        private void RefreshData()
        {
            ISupplierPaymentDueDaysRepository paymentRepository = new SupplierPaymentDueDaysRepository();
            GetOptionsandTaxValues();
            this.ListDueDays = paymentRepository.GetAllData();
            DefaultList = this.ListDueDays;
            this.ListDueDayscmbSup = this.ListDueDays.GroupBy(x => x.Name).Select(y => y.First()).OrderBy(x => x.Name).ToList();
            this.BalanceTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Balance));
            this.OneToThirtyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Oneto30Days));
            this.OneToSixtyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Thirtyoneto60Days));
            this.OneToNinetyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Sixtyoneto90Days));
            this.GreaterthanNinetyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.GreaterThen90Days));
        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            ISupplierPaymentDueDaysRepository paymentRepository = new SupplierPaymentDueDaysRepository();
            oData = paymentRepository.GetOptionSettings();
            if (oData != null)
            {
                this.CurrencyName = oData.CurrencyCode;     //there is no currency name field in database         
                this.CurrencyCode = oData.CurrencyCode;
                this.CurrencyFormat = oData.NumberFormat;
                this.DecimalPlaces = oData.DecimalPlaces;
            }
            else
            {
                this.CurrencyName = "USD";
                this.CurrencyCode = "USD";
                this.CurrencyFormat = "en-US";
            }
            TaxModel objDefaultTax = new TaxModel();
            objDefaultTax = paymentRepository.GetDefaultTaxes().FirstOrDefault();
            if (objDefaultTax != null)
            {
                this.TaxName = objDefaultTax.TaxName;
            }
            else
            {
                this.TaxName = "GST";
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
            Mouse.OverrideCursor = null;
        }
        #endregion

        protected override void OnPropertyChanged(string name)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(name));
            }
            switch (name)
            {
                case "SelectedSearchName":
                    GetData(this.SelectedSearchName, "Name");
                    break;
            }

            base.OnPropertyChanged(name);
        }

        public void GetData(string SearchFilter, string parameter)
        {
            //IPurchaseInvoiceListRepository purchaseRepository = new PurchaseInvoiceListRepository();
            //var result = purchaseRepository.GetAllPurInvoice().ToList();
            if (SearchFilter != null || SearchFilter == string.Empty)
            {
                if (parameter == "Name")
                {
                    this.ListDueDays = DefaultList.Where(x => (x.Name == SearchFilter)).ToList();
                    this.BalanceTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Balance));
                    this.OneToThirtyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Oneto30Days));
                    this.OneToSixtyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Thirtyoneto60Days));
                    this.OneToNinetyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Sixtyoneto90Days));
                    this.GreaterthanNinetyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.GreaterThen90Days));
                }

            }
            else
            {

                this.ListDueDays = DefaultList.ToList();
                this.BalanceTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Balance));
                this.OneToThirtyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Oneto30Days));
                this.OneToSixtyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Thirtyoneto60Days));
                this.OneToNinetyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.Sixtyoneto90Days));
                this.GreaterthanNinetyTotal = Convert.ToString(this.ListDueDays.Sum(e => e.GreaterThen90Days));

            }
            //TotalInvoiceAmount = Convert.ToString(PurchaseInvoiceList.Sum(e => e.InvoiceAmountValue));
            //TotalCCDAmount = Convert.ToString(PurchaseInvoiceList.Sum(e => e.CashChequeAmount));
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
        void NavigateToSupplier(object param)
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Suppliers Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                string obj = param.ToString();
            SharedValues.getValue = obj;
            var mainview = ServiceLocator.Current.GetInstance<SupplierDetailView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<SupplierTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
    }
}