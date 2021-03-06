﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SASClient.Accounts.Services;
using SASClient.CashBank.Services;
using SASClient.CashBank.Views;
using SASClient.CloseRequest;
using SASClient.File.Views;
using SDN.Common;
using SDN.UI.Entities;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SASClient.Accounts.ViewModel
{
    public class UnpaidSalesInvoiceViewModel : UnpaidSalesInvoiceEntity
    {
        #region private property
        private readonly IRegionManager regionManager;
        StackList itemlist = new StackList();
        private readonly IEventAggregator eventAggregator;
        private IUnpaidSalesInvoiceRepository unpaidInvoiceRepository = new UnpaidSalesInvoiceRepository();
        private List<UnpaidSalesInvoiceViewModel> _FullList;
        private static IEnumerable<UnpaidSalesInvoiceEntity> UnpaidInvoiceList;
        private ObservableCollection<UnpaidSalesInvoiceGridViewModel> _UnpaidSalesInvoicedetailsEntity;
        private ObservableCollection<UnpaidSalesInvoiceEntity> _UnpaidInvoiceService;
        private ObservableCollection<UnpaidSalesInvoiceGridViewModel> TempList;
        private string casErrors;
        private string _DateErrors;

        #endregion
        #region public property
        public ObservableCollection<UnpaidSalesInvoiceEntity> UnpaidInvoiceService
        {
            get
            {
                return _UnpaidInvoiceService;
            }
            set
            {
                if (_UnpaidInvoiceService != value)
                {
                    _UnpaidInvoiceService = value;
                    OnPropertyChanged("UnpaidInvoiceService");
                }
            }
        }
        public string CASErrors
        {
            get { return casErrors; }
            set
            {
                casErrors = value;
                OnPropertyChanged("CASErrors");
            }
        }
        public string DateErrors
        {
            get
            {
                return _DateErrors;
            }
            set
            {
                _DateErrors = value;
                OnPropertyChanged("DateErrors");
            }
        }
        public ObservableCollection<UnpaidSalesInvoiceGridViewModel> UnpaidSalesInvoicedetailsEntity
        {
            get
            {
                return _UnpaidSalesInvoicedetailsEntity;
            }
            set
            {
                _UnpaidSalesInvoicedetailsEntity = value;
                OnPropertyChanged("UnpaidSalesInvoicedetailsEntity");
            }
        }
        #endregion
        #region constructor property
        public UnpaidSalesInvoiceViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) :base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            LoadSupplierBackground();
            UnpaidSalesInvoicedetailsEntity = new ObservableCollection<UnpaidSalesInvoiceGridViewModel>();
            createNewUnpaidSalesInvoice();
            SaveCommand = new RelayCommand(SaveUnpaidSalesInvoice,CanSave);
            NavigateToSuppliersFormCommand = new RelayCommand(NavigateToCustomerDetails);
            NavigateToAccountsDetailsListFormCommand = new RelayCommand(NavigateToAccountsDetailList);
            NavigateToImportDataCommand = new RelayCommand(NavigateToImportData);
            CloseCommand = new DelegateCommand(Close);

        }
        public ICommand CloseCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand NavigateToSuppliersFormCommand { get; set; }
        public RelayCommand NavigateToAccountsDetailsListFormCommand { get; set; }
        public RelayCommand NavigateToImportDataCommand { get; set; }


        public void  NavigateToAccountsDetailList(object param)
        {
            SharedValues.ScreenCheckName = "Accounts Details";
            SharedValues.ViewName = "Accounts Details List";
            var accessitem = itemlist.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "AccountsDetailsTab";
            var view = ServiceLocator.Current.GetInstance<AccountsDetailsListView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }

            var tabview = ServiceLocator.Current.GetInstance<SASClient.Accounts.Views.AccountsTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Accounts Details List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        public void NavigateToImportData(object param)
        {
            SharedValues.ScreenCheckName = "Import Data";
            SharedValues.ViewName = "Import Data";
            var accessitem = itemlist.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "ImportDataTab";
            var tabview = ServiceLocator.Current.GetInstance<ImportDataView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<FileTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            var SubTabView = ServiceLocator.Current.GetInstance<FileSubTabView>();
            var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

            subMenuRegion.Add(SubTabView);

            if (subMenuRegion != null)
            {
                subMenuRegion.Activate(SubTabView);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Import Data");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
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
        public void NavigateToCustomerDetails(object param)
        {
            SharedValues.ScreenCheckName = "Customers Details";
            SharedValues.ViewName = "Customers Details";
            var accessitem = itemlist.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "CustomerDetailTab";
                var view = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersView>();

                IRegion region = this.regionManager.Regions[RegionNames.MainRegion];

                region.Add(view);
                if (region != null)
                {
                    region.Activate(view);
                }

                var view2 = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();

                IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                region2.Add(view2);
                if (region2 != null)
                {
                    region2.Activate(view2);
                }
        
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        public void createNewUnpaidSalesInvoice()
        {
         
            var row = new UnpaidSalesInvoiceGridViewModel(UnpaidInvoiceList);
            //row.SelectedPSID = 0;
            if (UnpaidSalesInvoicedetailsEntity != null)
            {
                if (UnpaidSalesInvoicedetailsEntity.Count > 0)
                {
                    UnpaidSalesInvoicedetailsEntity.Clear();
                    // var row = new CollectAmountDataGridViewModel();
                    //  PQDetailsEntity.Add(row);
                    OnPropertyChanged("UnpaidSalesInvoicedetailsEntity");
                }
            }
            UnpaidSalesInvoicedetailsEntity.Add(row);
            OnPropertyChanged("UnpaidSalesInvoicedetailsEntity");
        }

        #endregion
        #region public method
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

            int minHeight = 400;
            int headerRows = 300;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 55;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.SIGridHeight = minHeight;
            RefreshData();
            GetOptionsandTaxValues();
        }
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
                UnpaidInvoiceList = unpaidInvoiceRepository.getCustomerList();
                if(UnpaidInvoiceList != null)
                {
                    UnpaidInvoiceService = new ObservableCollection<UnpaidSalesInvoiceEntity>(UnpaidInvoiceList);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public int ManageDuplicateUnpaidSalesInvoice()
        {
            int rowFocusindex = -1;
            //ShowAllCount = PSDetailsEntity.Where(e => e.SelectedPSID != 0).Count();
            TempList = new ObservableCollection<UnpaidSalesInvoiceGridViewModel>();
            TempList = UnpaidSalesInvoicedetailsEntity;

            var query = TempList.GroupBy(x => x.ID)
              .Where(g => g.Count() > 1)
              .ToList();
            if (query.Count > 0 && UnpaidSalesInvoicedetailsEntity.Count > 1)
            {

                var obj1 = query[0].ElementAt(0);
                var obj2 = query[0].ElementAt(1);
                int? qty = 1;

                qty = query[0].ElementAt(0).CountQty + query[0].ElementAt(1).CountQty;

                var index1 = TempList.IndexOf(query[0].ElementAt(0));
                var index2 = TempList.IndexOf(query[0].ElementAt(1));
                OnPropertyChanged("UnpaidSalesInvoicedetailsEntity");
                TempList = UnpaidSalesInvoicedetailsEntity;
            }
            else
            {
                int count = UnpaidSalesInvoicedetailsEntity.Count(x => x.ID == 0);
                if (count == 0)
                {
                    var row = new UnpaidSalesInvoiceGridViewModel(UnpaidInvoiceList);
                    // row.CountQty = 0;
                    //   row.GSTRate = TaxRate;

                    UnpaidSalesInvoicedetailsEntity.Add(row);
                    OnPropertyChanged("UnpaidSalesInvoicedetailsEntity");
                    TempList = UnpaidSalesInvoicedetailsEntity;
                    rowFocusindex = -1;
                }
                else
                {
                    var emptyRow = TempList.Where(y => y.ID == 0).FirstOrDefault();
                    rowFocusindex = UnpaidSalesInvoicedetailsEntity.IndexOf(emptyRow);
                }

            }
            return rowFocusindex;
        }
        public void SaveUnpaidSalesInvoice(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
               
               
                string msg = ValidateJournal();
                if (msg != string.Empty && msg != "No Entry is done till Now")
                {
                  
                    CASErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                CASErrors = string.Empty;
                UnpaidSalesInvoiceModel JForm = GetDataIntoModel();
                unpaidInvoiceRepository.SaveUnpaidSalesInvoiceData(JForm);
                Mouse.OverrideCursor = null;
            }
        }
        public bool CanSave(object param)
        {
            string msg = string.Empty;
            bool status = false;
            var list1 = UnpaidSalesInvoicedetailsEntity.Where(x => x.ID == null).ToList();
            var list = UnpaidSalesInvoicedetailsEntity.Except(list1);
            foreach(var item in list)
            {
                var date = item.InvoiceDate;
                var Customer = item.ID;
                var InvoiceNo = item.InvoiceNo;
                var UpdatedAmount = item.UnpaidAmount;
                Regex r = new Regex("");
                if (date != null && Customer != null && InvoiceNo !=null && UpdatedAmount !=null)
                {
                   Regex number = new Regex("^[0-9]*$");
                   
                    //Regex r = new Regex("^(((0[1-9]|[12][0-9]|30)[-/]?(0[13-9]|1[012])|31[-/]?(0[13578]|1[02])|(0[1-9]|1[0-9]|2[0-8])[-/]?02)[-/]?[0-9]{4}|29[-/]?02[-/]?([0-9]{2}(([2468][048]|[02468][48])|[13579][26])|([13579][26]|[02468][048]|0[0-9]|1[0-6])00))$");
                    // Regex r = new Regex("^(((0[1-9]|[12][0-9]|3[01])[-/]?(0[13578]|1[02])[-/]?([0-9]{2}))|((0[1-9]|[12][0-9]|30)[-/]?(0[13456789]|1[012])[-/]?([0-9]{2}))|((0[1-9]|1[0-9]|2[0-8])[-/]?02[-/]?([0-9]{2}))|(29[-/]?02[-/]?((0[48]|[2468][048]|[13579][26])|(00))))$");
                    // Regex r = new Regex("^((0[1-9])|(1[0-2]))[-/]?((0[1-9])|(1[0-9])|(2[0-9])|(3[0-1]))[-/]?(([1][9][0-9][0-9])|([2][0-9][0-9][0-9]))$");
                    if (DateFormat == "dd/MM/yy")
                    {
                        r = new Regex("^(((0[1-9]|[12][0-9]|3[01])[-/](0[13578]|1[02])[-/]([0-9]{2}))|((0[1-9]|[12][0-9]|30)[-/](0[13456789]|1[012])[-/]([0-9]{2}))|((0[1-9]|1[0-9]|2[0-8])[-/]02[-/]([0-9]{2}))|(29[-/]02[-/]((0[48]|[2468][048]|[13579][26])|(00))))$");

                    }
                    if (DateFormat == "MM/dd/yy")
                    {
                        r = new Regex("^((0[1-9])|(1[0-2]))[-/]((0[1-9])|([0-2][1-9])|(3[0-1])|(20)|(10))[-/](([0-9][1-9])|([1-9]0))$");

                    }
                    if (DateFormat == "yy/MM/dd")
                    {
                        r = new Regex("^((([0-9][1-9])|([1-9]0))[-/]((0[1-9])|(1[0-2]))[-/]((0[1-9])|([0-2][1-9])|(3[0-1])|(20)|(10)))$");
                    }
                    if (number.IsMatch(InvoiceNo))
                    {
                        msg = "";
                        this.DateErrors = msg;
                        var no = number.IsMatch(InvoiceNo);
                        if (Convert.ToInt32(no) > 0)
                        {
                            msg = "";
                            this.DateErrors = msg;
                            if (r.IsMatch(date))
                            {
                                msg = "";
                                this.DateErrors = msg;
                               // status = true;
                            }
                            else
                            {
                                msg = "Only Date Accepted";
                                this.DateErrors = msg;
                                status = false;
                                break;
                            }
                        }
                        else
                        {
                            msg = "Positive Number Accepted";
                            this.DateErrors = msg;
                            status = false;
                            break;
                        }
                        
                    }
                    else
                    {
                        msg = "Only Numbers Accepted";
                        this.DateErrors = msg;
                        status = false;
                        break;
                    }
                    status = true;
                }
               else
                {
                    status = false;
                }
            }
            return status;
        }
        public string ValidateJournal()
        {
            string msg = string.Empty;
            UnpaidSalesInvoiceModel JForm = GetDataIntoModel();
            //var tempInvoiceNumber = unpaidInvoiceRepository.IsChequeNoPresent();
            //string result = JForm.UnpaidSalesInvoiceDetailsData.Where(x => x.InvoiceNo == tempInvoiceNumber).Select(x => x.InvoiceNo).FirstOrDefault();
            //if(result!=null)
            //{
            //    msg = "Entry against Cheque No is already done";
            //}
            //if(result == null)
            //{
            //    msg = "No Entry is done till Now";
            //}

            //return msg;
            List<string> ListInvoiceNumber = unpaidInvoiceRepository.IsChequeNoPresent();
            List<string> InsideList = JForm.UnpaidSalesInvoiceDetailsData.Select(x => x.InvoiceNo).ToList();
            List<string> PINumberList = InsideList.Distinct().ToList();
            foreach (var item in JForm.UnpaidSalesInvoiceDetailsData)
            {
                if (InsideList.Count != PINumberList.Count)
                {
                    msg = "Two Invoice Number Should Not Be Same";
                    //this.CASErrors =msg;
                    break;
                }
                if (ListInvoiceNumber == null)
                {
                    msg = "No Entry is done till Now";
                    //this.CASErrors=msg;
                    break;
                }
                if (ListInvoiceNumber.Contains(item.InvoiceNo))
                {
                    msg = "Entry against Cheque No is already done ";
                    // this.CASErrors = msg;
                    break;

                }


            }

            return msg;
        }
        public UnpaidSalesInvoiceModel GetDataIntoModel()
        {
            UnpaidSalesInvoiceModel JForm = new UnpaidSalesInvoiceModel();
            JForm.UnpaidSalesInvoiceDetailsData = new List<UnpaidSalesInvoiceEntity>();
            //UnpaidSalesInvoiceEntity model = new UnpaidSalesInvoiceEntity();
           
            //JForm.UnpaidSalesInvoiceData = model;

            foreach (var item in UnpaidSalesInvoicedetailsEntity)
            {
                if (item.ID != null)
                {
                    UnpaidSalesInvoiceEntity jEntity = new UnpaidSalesInvoiceEntity();
                    jEntity.ID = item.ID;
                    jEntity.CustomerName = item.CustomerName;
                    jEntity.InvoiceNo = "OSI-"+item.InvoiceNo;
                    jEntity.UnpaidAmount = item.UnpaidAmount;
                    jEntity.InvoiceDate = item.InvoiceDate;
                    jEntity.InvoiceDateTime = DateTime.ParseExact(item.InvoiceDate, DateFormat, null);
                    if (item.ID != 0 && Convert.ToInt32(item.ID) > 0)
                    {
                        JForm.UnpaidSalesInvoiceDetailsData.Add(jEntity);
                    }
                }
            }

            return JForm;
        }
        #endregion
    }
}
