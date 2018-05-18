﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SASClient.Accounts.Services;
using SASClient.Accounts.Views;
using SASClient.CashBank.Services;
using SASClient.CloseRequest;
using SDN.CashBank.Views;
using SDN.Common;
using SDN.UI.Entities;
using SDN.UI.Entities.Accounts;
using SDN.UI.Entities.CashandBank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
//using static System.Net.Mime.MediaTypeNames;

namespace SASClient.Accounts.ViewModels
{
    public class TrailBalanceViewModel :TrailBalanceEntity
    {
        #region private member
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        StackList itemlist = new StackList();
        private ITrailBalanceRepository TrailRepository = new TrailBalanceRepository();
        private int Count = 0;
        #endregion
        public TrailBalanceViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
             : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
          
            this.LoadSupplierBackground();
            //NavigateToAccountFormCommand = new RelayCommand(NavigateToRespectiveAccountForm);
            CloseCommand = new DelegateCommand(Close);

        }
        #region "Relay command"
        //public RelayCommand NavigateToAccountFormCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        #endregion
        #region background region
        //public void  NavigateToRespectiveAccountForm(object param)
        //{
        //    try
        //    {
        //        if (param != null)
        //        {
        //            SharedValues.ScreenCheckName = "Accounts Details";
        //            SharedValues.ViewName = "Accounts Details";
        //            var accessitem = itemlist.AddToList();
        //            if (accessitem == true)
        //            {
        //                List<object> values = new List<object>();
        //            values = param as List<object>;
        //            var TransType = values[0];
        //            SharedValues.getValue = TransType.ToString();
        //            SharedValues.NewClick = TransType.ToString();
        //            var tabview = ServiceLocator.Current.GetInstance<AccountsTabView>();

        //            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
        //            tabregion.Add(tabview);
        //            if (tabregion != null)
        //            {
        //                tabregion.Activate(tabview);
        //            }
        //            PurchaseTabEntity tabentity = new PurchaseTabEntity();
        //            var tabentityValue = tabentity as PurchaseTabEntity;
        //            tabentityValue.OrderTabTrue = true;

        //            var mainview = ServiceLocator.Current.GetInstance<AccountsDetailsView>();

        //            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
        //            mainregion.Add(mainview);
        //            if (mainregion != null)
        //            {
        //                mainregion.Activate(mainview);
        //            }////
        //            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
        //            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        //            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Accounts Details Form");
        //            }
        //            else
        //            {
        //                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
        //            }
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        throw e;
        //    }
           
        //}
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

            int minHeight = 550;
            int headerRows = 300;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - (-80);
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SIGridHeight = minHeight;
            RefreshData();
        }


        private void LoadSupplierBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {

        }
        private void LoadSupplierBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = null;
            Count = 1;

        }

        #endregion end background

        public void RefreshData()
        {
            try
            {
                DataList = TrailRepository.GetList().ToList();
                TotalDebitAmount = Convert.ToString(DataList.Sum(e =>e.DebitBalance));
                TotalCreditAmount = Convert.ToString(DataList.Sum(e =>e.CreditBalance));
            }
            catch(Exception e)
            {
                throw e;
            }
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
            IReceiveMoneyListRepository purchaseRepository = new ReceiveMoneyListRepository();
            oData = purchaseRepository.GetOptionSettings();
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
        }
    }
}
