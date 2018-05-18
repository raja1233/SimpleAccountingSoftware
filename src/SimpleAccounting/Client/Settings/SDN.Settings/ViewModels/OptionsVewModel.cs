﻿namespace SDN.Settings.ViewModels
{
    using Microsoft.Practices.Prism.Events;
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
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Threading;

    public class OptionsVewModel : ViewModelBase
    {
        #region Private Properties
        private readonly IEventAggregator eventAggregator;
        private OptionsEntity _options;
        private ObservableCollection<CurrencyFormat> _currencyformat = new ObservableCollection<CurrencyFormat>();
        private string companyname = "smartData";
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        int compId = 0;
        private event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Public Properties
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsTabViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public OptionsVewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<CompanynameChangedEvent>().Publish(companyname);
        }

        public OptionsEntity Options
        {
            get
            {
                return this._options;
            }
            set
            {
                this._options = value;
            }
        }
        public ObservableCollection<AccountsEntity> AcountList
        {
            get
            {
                IOptionsService OptionsDetails = new OptionsService();
                var _accountCollection = new ObservableCollection<AccountsEntity>(OptionsDetails.GetAccountDetails());
                return _accountCollection;
            }
        }
        public ObservableCollection<CurrencyFormat> CurrencyFormatList
        {
            get
            {
                _currencyformat.Clear();
                CurrenyData();
                return _currencyformat;
            }
        }
        public int PIGridHeight { get; set; }

        #endregion

        #region Constructor
        public OptionsVewModel()
        {
            this.LoadOptionsBackground();
            SaveOptionsCommand = new RelayCommand(SaveOptions,CanSave);


        }
        #endregion

        private void CurrenyData()
        {
            _currencyformat.Add(new CurrencyFormat { CurrencyName = "en-IN", CurrencyStyle = "000,00,00,000" });
            _currencyformat.Add(new CurrencyFormat { CurrencyName = "en-US", CurrencyStyle = "000,000,000,000" });
        }

        public RelayCommand SaveOptionsCommand { get; set; }





        void SaveOptions(object param)
        {
            IOptionsService OptionsDetails = new OptionsService();
            //UpdateBindingGroup.CommitEdit();
            bool results = false;
            var optionsDetails = SelectedOptions as OptionsEntity;
            MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Save Content", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    results = OptionsDetails.AddEditOptions(optionsDetails);
                    break;
                case MessageBoxResult.No:

                    break;

            }
            if (results == true)
            {
                //MessageBox.Show("Data saved successfully!");
            }
            else
            {
                MessageBox.Show("There was some problem in updating the entries, kindly try again later!");
            }

        }

        object _SelectedOptions;
        public object SelectedOptions
        {
            get
            {

                return _SelectedOptions;
            }
            set
            {
                if (_SelectedOptions != value)
                {
                    _SelectedOptions = value;
                    RaisePropertyChanged("SelectedOptions");
                }
            }
        }

        BindingGroup _UpdateBindingGroup;
        public BindingGroup UpdateBindingGroup
        {
            get
            {
                return _UpdateBindingGroup;
            }
            set
            {
                if (_UpdateBindingGroup != value)
                {
                    _UpdateBindingGroup = value;
                    RaisePropertyChanged("UpdateBindingGroup");
                }
            }
        }

        #region Background Loads Options Data
        /// <summary>
        /// Loads the product models background.
        /// </summary>
        public void LoadOptionsBackground()
        {
            SelectedOptions = null; // Unselects last selection. Essential, as assignment below won't clear other control's SelectedItems
            var Options = new OptionsEntity();

            IOptionsService OptionsDetails = new OptionsService();
            var results = OptionsDetails.GetOptionsDetails();
            results.ShowAmountIncGST = true;


            int minHeight = 300;
            int headerRows = 490;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 155;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            results.OptionGridHeight = minHeight;


            SelectedOptions = results;
            //int compId = 0;
            Mouse.OverrideCursor = Cursors.Wait;

            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadOptionsBackground);

            // This event is raised when you call the ReportProgress method.
            //worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadProductsBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadOptionsBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadOptionsBackground(object sender, DoWorkEventArgs e)
        {
        
            //int index = 0;
            //Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
            //source.ReportProgress(index, results);
        }

        private void LoadOptionsBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {

            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("Options");
        }

        public void SetAccountDetails(string AccountName)
        {
            var item = SelectedOptions as OptionsEntity;
            item.DefCashBankAcc = AccountName;
        }

        public string setDefaultValue()
        {
            var item = SelectedOptions as OptionsEntity;
            return item.DefCashBankAcc;
        }
        //private void LoadProductsBackgroundProgress(object sender, ProgressChangedEventArgs e)
        //{
        //    this.Options ((OptionsEntity)e.UserState);
        //}

       

        public bool CanSave(object param)
        {

            if (SelectedOptions != null)
            {
                var selectedOption = SelectedOptions as OptionsEntity;
                if ((selectedOption.NametoPrintSalesInv == null || selectedOption.NametoPrintSalesInv == "" || selectedOption.NametoPrintSalesInv == " ") ||
                    (selectedOption.StartingSalesInvNo == null || selectedOption.StartingSalesInvNo == "" || selectedOption.StartingSalesInvNo == " ") ||
                    (selectedOption.CurrencyCode == null || selectedOption.CurrencyCode == "" || selectedOption.CurrencyCode == " "))
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        #endregion
    }
}