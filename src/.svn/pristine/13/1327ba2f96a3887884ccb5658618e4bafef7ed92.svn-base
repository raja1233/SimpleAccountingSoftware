using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using SDN.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Configuration;
using System.Data.SqlClient;
using SDN.UI.Entities;
using SASClient.File.Services;
using System.Windows;
using SystemInformation = System.Windows.Forms.SystemInformation;

using System.Reflection;
using System.Data;
using System.Data.Sql;
using SASClient.CloseRequest;
using Microsoft.Practices.Prism.Commands;

namespace SASClient.File.ViewModel
{
    public class BackupDataViewModel : BackupDataEntity
    {
        #region private property
        StackList itemlist = new StackList();
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private IBackupDataRepositoty repo = new BackupDataRepository();
        private BackupDataEntity result = new BackupDataEntity();
        #endregion
        #region 'server entity'


        #endregion
        #region "constructor"
        public BackupDataViewModel(IRegionManager regionManager, IEventAggregator eventAggregator):base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            LoadSupplierBackground();
            CloseCommand = new DelegateCommand(Close);
            BackupCommand = new RelayCommand(BackupDataCommand);
        }
        #endregion
        public RelayCommand BackupCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        #region BackgroundWorked
        private void LoadSupplierBackground()
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

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
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - (-62);
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SIGridHeight = minHeight;
            RefreshData();
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
        public void RefreshData()
        {
            try
            {
                DataBaseList = repo.getDataBaseName().ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void LoadDataBaseName(string Name)
        {

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

        public void BackupDataCommand(object param)
        {
            var status = "";
            var dbName = param.ToString();
            if (string.IsNullOrEmpty(dbName))
            {
                System.Windows.MessageBox.Show("Server Name & Database can not be Blank\n"+"@ Simple Accounting Software Pte Ltd");
                return;
            }
            else
            {
                if (!String.IsNullOrEmpty(dbName))
                {
                    System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog1.Filter = "Text files (*.bak)|*.bak|All files (*.*)|*.*";
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        
                        string filename = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                        string name = saveFileDialog1.FileName;

                        var test = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                        string fullPath = test + "\\"+ filename;
                        var Result= repo.BackupDataBase(dbName, fullPath);
                        //this.status= result.Where(x => x.status == status).Select(x => x.status).SingleOrDefault();
                        saveFileDialog1.RestoreDirectory = true;
                        System.Windows.MessageBox.Show(Result);
                    }
                }
            }
        }
        #endregion
    }
    }

