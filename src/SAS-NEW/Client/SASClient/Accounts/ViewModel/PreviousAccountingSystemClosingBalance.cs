using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SASClient.Accounts.ViewModel
{
    public class PreviousAccountingSystemClosingBalance : PreviousAccountingSystemClosingBalanceEntity
    {
        #region "private property"
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private int Count=0;
        #endregion
        #region "public property"
        #endregion
        #region "constructor"
        public PreviousAccountingSystemClosingBalance(IRegionManager regionManager, IEventAggregator eventAggregator):
            base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
        }
        #endregion
        #region "public method"
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

            int minHeight = 500;
            int headerRows = 300;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 67;
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
        public void  RefreshData()
        {

        }
        #endregion
    }
}
