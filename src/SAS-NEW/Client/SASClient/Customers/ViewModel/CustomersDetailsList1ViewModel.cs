﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Customers.ViewModel
{
    using CloseRequest;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Newtonsoft.Json;
    using SDN.Common;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Customers;
    using Services;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    public class CustomersDetailsList1ViewModel: CustomersDetailsListEntity
    {

        private List<SearchEntity> SearchValues;
        private string jsonSearch;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private int Count = 0;
        private List<CustomersDetailsListEntity> _customerstatusCount = new List<CustomersDetailsListEntity>();
        StackList listitem = new StackList();
        #region Constructor
        public List<CustomersDetailsListEntity> customerstatusCount
        {
            get
            {
                return _customerstatusCount;
            }
            set
            {
                _customerstatusCount = value;
                OnPropertyChanged("customerstatusCount");
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseInvoiceListViewModel"/> class.
        /// </summary>
        public CustomersDetailsList1ViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            SearchCommand = new RelayCommand(Search);
            ShowAllCommand = new RelayCommand(ShowAll);
            ShowSelectedCommand = new RelayCommand(ShowSelected);
            ShowActiveCommand = new RelayCommand(OnShowActive);
            ShowInactiveCommand = new RelayCommand(OnShowInactive);
            ShowBothCommand = new RelayCommand(OnShowBoth);
            NewCommand = new RelayCommand(OnNew);
            NavigateToClientCommand = new RelayCommand(OnNew);
            CloseCommand = new DelegateCommand(Close);
        }


        public CustomersDetailsList1ViewModel()
        {
        }
        public ICommand CloseCommand { get; set; }
        public RelayCommand NavigateToClientCommand { get; set; }
        public RelayCommand NewCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        public RelayCommand ShowSelectedCommand { get; set; }
        public RelayCommand ShowActiveCommand { get; set; }
        public RelayCommand ShowInactiveCommand { get; set; }
        public RelayCommand ShowBothCommand { get; set; }

        #endregion  Constructor

        #region ButtonCommands
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
        void OnNew(object param)
        {
            SharedValues.ScreenCheckName = "Customers Details";
            SharedValues.ViewName = "Customers Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                string obj = param.ToString();
            SharedValues.getValue = obj;
            var mainview = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }

            var tabview = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details Form");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        void OnShowActive(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.ShowSelectedTrue = true;
            this.ShowAllTrue = false;
            Search(null);
            Mouse.OverrideCursor = null;
        }

        void OnShowInactive(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.ShowSelectedTrue = true;
            this.ShowAllTrue = false;
            Search(null);
            Mouse.OverrideCursor = null;
        }

        void OnShowBoth(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.ShowSelectedTrue = false;
            this.ShowAllTrue = true;
            Search(null);
            Mouse.OverrideCursor = null;
        }

        void refreshcommand(object param)
        {
            RefreshData();
        }

        void ShowAll(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ShowAllTrue = true;
            ShowBoth = true;
            ShowInactive = false;
            ShowActive = false;
            Search(null);

            this.CustomerDetailsList = FullPQList;
            this.CustomerDetailsList = FullPQList;
            // this.RefundFromSuppliersListcmbDebit = this.RefundFromSuppliersListcmb.GroupBy(x => x.CashDebitNo).Select(g => g.First()).Where(y => y.CashDebitNo != null).ToList();
            this.CustomerDetailsListCusName = this.CustomerDetailsList.GroupBy(x => x.Name).Select(g => g.First()).Where(x => !string.IsNullOrEmpty(x.Name) || !string.IsNullOrWhiteSpace(x.Name)).OrderBy(e => e.Name).ToList();
            this.CustomerDetailsListCompRegNo = this.CustomerDetailsList.GroupBy(x => x.CompanyRegNo).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.CompanyRegNo) || !string.IsNullOrWhiteSpace(x.CompanyRegNo)).Distinct().OrderBy(e => e.CompanyRegNo).ToList();
            this.CustomerDetailsListGSTRegNo = this.CustomerDetailsList.GroupBy(x => x.GSTRegNo).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.GSTRegNo) || !string.IsNullOrWhiteSpace(x.GSTRegNo)).Distinct().OrderBy(e => e.GSTRegNo).ToList();

            this.CustomerDetailsListTelephone = this.CustomerDetailsList.GroupBy(x => x.Telephone).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Telephone) || !string.IsNullOrWhiteSpace(x.Telephone)).Distinct().ToList();
            this.CustomerDetailsListFax = this.CustomerDetailsList.GroupBy(x => x.Fax).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Fax) || !string.IsNullOrWhiteSpace(x.Fax)).Distinct().ToList();
            this.CustomerDetailsListEmail = this.CustomerDetailsList.GroupBy(x => x.Email).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Email) || !string.IsNullOrWhiteSpace(x.Email)).Distinct().ToList();
            this.CustomerDetailsListContact = this.CustomerDetailsList.GroupBy(x => x.ContactPerson).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ContactPerson) || !string.IsNullOrWhiteSpace(x.ContactPerson)).Distinct().ToList();

            this.CustomerDetailsListBalance = this.CustomerDetailsList.GroupBy(x => x.BalanceStr).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BalanceStr) || !string.IsNullOrWhiteSpace(x.BalanceStr)).Distinct().ToList();
            this.CustomerDetailsListType = this.CustomerDetailsList.GroupBy(x => x.Type).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Type) || !string.IsNullOrWhiteSpace(x.Type)).Distinct().ToList();
            this.CustomerDetailsListSaleman = this.CustomerDetailsList.GroupBy(x => x.Salesman).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Salesman) || !string.IsNullOrWhiteSpace(x.Salesman)).Distinct().ToList();
            this.CustomerDetailsListCreditLimitDays = this.CustomerDetailsList.GroupBy(x => x.CreditLimitDays).Select(y => y.First()).Where(y => y.CreditLimitDays != null).Distinct().ToList();
            this.CustomerDetailsListCreditLimitAmount = this.CustomerDetailsList.GroupBy(x => x.CreditLimitAmountStr).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.CreditLimitAmountStr) || !string.IsNullOrWhiteSpace(x.CreditLimitAmountStr)).Distinct().ToList();
            this.CustomerDetailsListDisount = this.CustomerDetailsList.GroupBy(x => x.Discount).Select(y => y.First()).Where(y => y.Discount != null).Distinct().ToList();

            this.CustomerDetailsListBillLine1 = this.CustomerDetailsList.GroupBy(x => x.BillToLine1).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToLine1) || !string.IsNullOrWhiteSpace(x.BillToLine1)).Distinct().ToList();
            this.CustomerDetailsListBillLine2 = this.CustomerDetailsList.GroupBy(x => x.BillToLine2).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToLine2) || !string.IsNullOrWhiteSpace(x.BillToLine2)).Distinct().ToList();
            this.CustomerDetailsListBillCity = this.CustomerDetailsList.GroupBy(x => x.BillToCity).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToCity) || !string.IsNullOrWhiteSpace(x.BillToCity)).Distinct().ToList();
            this.CustomerDetailsListBillState = this.CustomerDetailsList.GroupBy(x => x.BillToState).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToState) || !string.IsNullOrWhiteSpace(x.BillToState)).Distinct().ToList();
            this.CustomerDetailsListBillCountry = this.CustomerDetailsList.GroupBy(x => x.BillToCountry).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToCountry) || !string.IsNullOrWhiteSpace(x.BillToCountry)).Distinct().ToList();
            this.CustomerDetailsListBillPinCode = this.CustomerDetailsList.GroupBy(x => x.BillToPostCode).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToPostCode) || !string.IsNullOrWhiteSpace(x.BillToPostCode)).Distinct().ToList();


            this.CustomerDetailsListShipLine1 = this.CustomerDetailsList.GroupBy(x => x.ShipToLine1).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToLine1) || !string.IsNullOrWhiteSpace(x.ShipToLine1)).Distinct().ToList();
            this.CustomerDetailsListShipLine2 = this.CustomerDetailsList.GroupBy(x => x.ShipToLine2).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToLine2) || !string.IsNullOrWhiteSpace(x.ShipToLine2)).Distinct().ToList();
            this.CustomerDetailsListShipCity = this.CustomerDetailsList.GroupBy(x => x.ShipToCity).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToCity) || !string.IsNullOrWhiteSpace(x.ShipToCity)).Distinct().ToList();
            this.CustomerDetailsListShipState = this.CustomerDetailsList.GroupBy(x => x.ShipToState).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToState) || !string.IsNullOrWhiteSpace(x.ShipToState)).Distinct().ToList();
            this.CustomerDetailsListShipCountry = this.CustomerDetailsList.GroupBy(x => x.ShipToCountry).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToCountry) || !string.IsNullOrWhiteSpace(x.ShipToCountry)).Distinct().ToList();
            this.CustomerDetailsListShipPinCode = this.CustomerDetailsList.GroupBy(x => x.ShipToPostCode).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToPostCode) || !string.IsNullOrWhiteSpace(x.ShipToPostCode)).Distinct().ToList();

            if (this.ShowAllTrue == false)
                this.ShowSelectedCount = this.CustomerDetailsList.Count();
            else
                this.ShowSelectedCount = 0;


           
            Mouse.OverrideCursor = null;
        }
        void ShowSelected(object param)
        {
            Search(null);
        }
        void Search(object param)
        {
            
            if (Count != 0)
            {
                SearchValues = new List<SearchEntity>();
                if (this.ShowAllTrue==true)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "ShowAll";
                    value.FieldValue = "true";
                    SearchValues.Add(value);

                }
                else
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "ShowAll";
                    value.FieldValue = "false";
                    SearchValues.Add(value);
                }

                if (this.ShowActive == true)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "ActiveOrInactive";
                    value.FieldValue = "1";
                    SearchValues.Add(value);

                }
               else if (this.ShowInactive == true)
                {
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "ActiveOrInactive";
                    value.FieldValue = "2";
                    SearchValues.Add(value);

                }
                else
                {
                  
                    SearchEntity value = new SearchEntity();
                    value.FieldName = "ActiveOrInactive";
                    value.FieldValue = "0";
                    SearchValues.Add(value);
                }


                //this.PurchaseInvoiceList = this.PurchaseInvoiceListInternal;
                jsonSearch = JsonConvert.SerializeObject(SearchValues);
                this.JsonData = jsonSearch;

                ICustomersDetailsListRepository  cusRepository = new CustomersDetailsListRepository();
                var results = cusRepository.SaveSearchJson(jsonSearch, Convert.ToInt32(ScreenId.CustomerDetailsList), "CustomersDetailsList");
                if (Count != 0)
                {
                    this.CustomerDetailsList = cusRepository.GetCustomersList(jsonSearch);

                }

                this.CustomerDetailsList = this.CustomerDetailsList;
                this.CustomerDetailsListCusName = this.CustomerDetailsList.GroupBy(x => x.Name).Select(g => g.First()).Where(x => !string.IsNullOrEmpty(x.Name) || !string.IsNullOrWhiteSpace(x.Name)).OrderBy(e => e.Name).ToList();
                this.CustomerDetailsListCompRegNo = this.CustomerDetailsList.GroupBy(x => x.CompanyRegNo).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.CompanyRegNo) || !string.IsNullOrWhiteSpace(x.CompanyRegNo)).Distinct().OrderBy(e => e.CompanyRegNo).ToList();
                this.CustomerDetailsListGSTRegNo = this.CustomerDetailsList.GroupBy(x => x.GSTRegNo).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.GSTRegNo) || !string.IsNullOrWhiteSpace(x.GSTRegNo)).Distinct().OrderBy(e => e.GSTRegNo).ToList();

                this.CustomerDetailsListTelephone = this.CustomerDetailsList.GroupBy(x => x.Telephone).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Telephone) || !string.IsNullOrWhiteSpace(x.Telephone)).Distinct().ToList();
                this.CustomerDetailsListFax = this.CustomerDetailsList.GroupBy(x => x.Fax).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Fax) || !string.IsNullOrWhiteSpace(x.Fax)).Distinct().ToList();
                this.CustomerDetailsListEmail = this.CustomerDetailsList.GroupBy(x => x.Email).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Email) || !string.IsNullOrWhiteSpace(x.Email)).Distinct().ToList();
                this.CustomerDetailsListContact = this.CustomerDetailsList.GroupBy(x => x.ContactPerson).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ContactPerson) || !string.IsNullOrWhiteSpace(x.ContactPerson)).Distinct().ToList();

                this.CustomerDetailsListBalance = this.CustomerDetailsList.GroupBy(x => x.BalanceStr).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BalanceStr) || !string.IsNullOrWhiteSpace(x.BalanceStr)).Distinct().ToList();
                this.CustomerDetailsListType = this.CustomerDetailsList.GroupBy(x => x.Type).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Type) || !string.IsNullOrWhiteSpace(x.Type)).Distinct().ToList();
                this.CustomerDetailsListSaleman = this.CustomerDetailsList.GroupBy(x => x.Salesman).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Salesman) || !string.IsNullOrWhiteSpace(x.Salesman)).Distinct().ToList();
                this.CustomerDetailsListCreditLimitDays = this.CustomerDetailsList.GroupBy(x => x.CreditLimitDays).Select(y => y.First()).Where(y => y.CreditLimitDays != null).Distinct().ToList();
                this.CustomerDetailsListCreditLimitAmount = this.CustomerDetailsList.GroupBy(x => x.CreditLimitAmountStr).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.CreditLimitAmountStr) || !string.IsNullOrWhiteSpace(x.CreditLimitAmountStr)).Distinct().ToList();
                this.CustomerDetailsListDisount = this.CustomerDetailsList.GroupBy(x => x.Discount).Select(y => y.First()).Where(y => y.Discount != null).Distinct().ToList();

                this.CustomerDetailsListBillLine1 = this.CustomerDetailsList.GroupBy(x => x.BillToLine1).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToLine1) || !string.IsNullOrWhiteSpace(x.BillToLine1)).Distinct().ToList();
                this.CustomerDetailsListBillLine2 = this.CustomerDetailsList.GroupBy(x => x.BillToLine2).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToLine2) || !string.IsNullOrWhiteSpace(x.BillToLine2)).Distinct().ToList();
                this.CustomerDetailsListBillCity = this.CustomerDetailsList.GroupBy(x => x.BillToCity).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToCity) || !string.IsNullOrWhiteSpace(x.BillToCity)).Distinct().ToList();
                this.CustomerDetailsListBillState = this.CustomerDetailsList.GroupBy(x => x.BillToState).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToState) || !string.IsNullOrWhiteSpace(x.BillToState)).Distinct().ToList();
                this.CustomerDetailsListBillCountry = this.CustomerDetailsList.GroupBy(x => x.BillToCountry).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToCountry) || !string.IsNullOrWhiteSpace(x.BillToCountry)).Distinct().ToList();
                this.CustomerDetailsListBillPinCode = this.CustomerDetailsList.GroupBy(x => x.BillToPostCode).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToPostCode) || !string.IsNullOrWhiteSpace(x.BillToPostCode)).Distinct().ToList();


                this.CustomerDetailsListShipLine1 = this.CustomerDetailsList.GroupBy(x => x.ShipToLine1).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToLine1) || !string.IsNullOrWhiteSpace(x.ShipToLine1)).Distinct().ToList();
                this.CustomerDetailsListShipLine2 = this.CustomerDetailsList.GroupBy(x => x.ShipToLine2).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToLine2) || !string.IsNullOrWhiteSpace(x.ShipToLine2)).Distinct().ToList();
                this.CustomerDetailsListShipCity = this.CustomerDetailsList.GroupBy(x => x.ShipToCity).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToCity) || !string.IsNullOrWhiteSpace(x.ShipToCity)).Distinct().ToList();
                this.CustomerDetailsListShipState = this.CustomerDetailsList.GroupBy(x => x.ShipToState).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToState) || !string.IsNullOrWhiteSpace(x.ShipToState)).Distinct().ToList();
                this.CustomerDetailsListShipCountry = this.CustomerDetailsList.GroupBy(x => x.ShipToCountry).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToCountry) || !string.IsNullOrWhiteSpace(x.ShipToCountry)).Distinct().ToList();
                this.CustomerDetailsListShipPinCode = this.CustomerDetailsList.GroupBy(x => x.ShipToPostCode).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToPostCode) || !string.IsNullOrWhiteSpace(x.ShipToPostCode)).Distinct().ToList();

                if (this.ShowAllTrue == true) 
                {
                    this.ShowSelectedCount = 0;
                    this.ShowAllCount= this.CustomerDetailsList.Count();
                }
                else
                    this.ShowSelectedCount = this.CustomerDetailsList.Count();
                DefaultList = this.CustomerDetailsList;

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
        List<CustomersDetailsListEntity> DefaultList = new List<CustomersDetailsListEntity>();
        List<CustomersDetailsListEntity> FullPQList = new List<CustomersDetailsListEntity>();
        private void LoadSupplierBackground(object sender, DoWorkEventArgs e)
        {

            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 50;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.GridHeight = minHeight;
            RefreshData();
        }

        private void RefreshData()
        {
            ICustomersDetailsListRepository custRepository = new CustomersDetailsListRepository();
           // this.DateFormat = custRepository.GetDateFormat();
           
            GetOptionsandTaxValues();
            this.JsonData = custRepository.GetLastSelectionData(Convert.ToInt32(ScreenId.CustomerDetailsList));
            this.CustomerDetailsList = custRepository.GetCustomersList(this.JsonData).OrderBy(x=>x.Name).ToList();
            this.ShowAllCount = custRepository.GetCustomersList(JsonData).Count();
            this.customerstatusCount = custRepository.GetCustomerStatusCount(Convert.ToInt32(ScreenId.CustomerDetailsList));
            foreach (var item in customerstatusCount)
            {
                this.ShowActiveCount = Convert.ToInt32(item.Active);
                this.ShowInactiveCount = Convert.ToInt32(item.InActive);
                this.ShowBothCount = Convert.ToInt32(item.Both);
            }
            this.ShowSelectedCount = this.CustomerDetailsList.Count();
            this.CustomerDetailsListCusName = this.CustomerDetailsList.GroupBy(x => x.Name).Select(g => g.First()).Where(x => !string.IsNullOrEmpty(x.Name) || !string.IsNullOrWhiteSpace(x.Name)).OrderBy(e => e.Name).ToList();
            this.CustomerDetailsListCompRegNo = this.CustomerDetailsList.GroupBy(x => x.CompanyRegNo).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.CompanyRegNo) || !string.IsNullOrWhiteSpace(x.CompanyRegNo)).Distinct().OrderBy(e => e.CompanyRegNo).ToList();
            this.CustomerDetailsListGSTRegNo = this.CustomerDetailsList.GroupBy(x => x.GSTRegNo).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.GSTRegNo) || !string.IsNullOrWhiteSpace(x.GSTRegNo)).Distinct().OrderBy(e => e.GSTRegNo).ToList();

            this.CustomerDetailsListTelephone = this.CustomerDetailsList.GroupBy(x => x.Telephone).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Telephone) || !string.IsNullOrWhiteSpace(x.Telephone)).Distinct().ToList();
            this.CustomerDetailsListFax = this.CustomerDetailsList.GroupBy(x => x.Fax).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Fax) || !string.IsNullOrWhiteSpace(x.Fax)).Distinct().ToList();
            this.CustomerDetailsListEmail = this.CustomerDetailsList.GroupBy(x => x.Email).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Email) || !string.IsNullOrWhiteSpace(x.Email)).Distinct().ToList();
            this.CustomerDetailsListContact = this.CustomerDetailsList.GroupBy(x => x.ContactPerson).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ContactPerson) || !string.IsNullOrWhiteSpace(x.ContactPerson)).Distinct().ToList();

            this.CustomerDetailsListBalance= this.CustomerDetailsList.GroupBy(x => x.BalanceStr).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BalanceStr) || !string.IsNullOrWhiteSpace(x.BalanceStr)).Distinct().ToList();
            this.CustomerDetailsListType = this.CustomerDetailsList.GroupBy(x => x.Type).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Type) || !string.IsNullOrWhiteSpace(x.Type)).Distinct().ToList();
            this.CustomerDetailsListSaleman = this.CustomerDetailsList.GroupBy(x => x.Salesman).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.Salesman) || !string.IsNullOrWhiteSpace(x.Salesman)).Distinct().ToList();
            this.CustomerDetailsListCreditLimitDays = this.CustomerDetailsList.GroupBy(x => x.CreditLimitDays).Select(y => y.First()).Where(y => y.CreditLimitDays != null).Distinct().ToList();
            this.CustomerDetailsListCreditLimitAmount = this.CustomerDetailsList.GroupBy(x => x.CreditLimitAmountStr).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.CreditLimitAmountStr) || !string.IsNullOrWhiteSpace(x.CreditLimitAmountStr)).Distinct().ToList();
            this.CustomerDetailsListDisount = this.CustomerDetailsList.GroupBy(x => x.Discount).Select(y => y.First()).Where(y => y.Discount != null ).Distinct().ToList();

            this.CustomerDetailsListBillLine1 = this.CustomerDetailsList.GroupBy(x => x.BillToLine1).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToLine1) || !string.IsNullOrWhiteSpace(x.BillToLine1)).Distinct().ToList();
            this.CustomerDetailsListBillLine2 = this.CustomerDetailsList.GroupBy(x => x.BillToLine2).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToLine2) || !string.IsNullOrWhiteSpace(x.BillToLine2)).Distinct().ToList();
            this.CustomerDetailsListBillCity= this.CustomerDetailsList.GroupBy(x => x.BillToCity).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToCity) || !string.IsNullOrWhiteSpace(x.BillToCity)).Distinct().ToList();
            this.CustomerDetailsListBillState = this.CustomerDetailsList.GroupBy(x => x.BillToState).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToState) || !string.IsNullOrWhiteSpace(x.BillToState)).Distinct().ToList();
            this.CustomerDetailsListBillCountry = this.CustomerDetailsList.GroupBy(x => x.BillToCountry).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToCountry) || !string.IsNullOrWhiteSpace(x.BillToCountry)).Distinct().ToList();
            this.CustomerDetailsListBillPinCode = this.CustomerDetailsList.GroupBy(x => x.BillToPostCode).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.BillToPostCode) || !string.IsNullOrWhiteSpace(x.BillToPostCode)).Distinct().ToList();


            this.CustomerDetailsListShipLine1 = this.CustomerDetailsList.GroupBy(x => x.ShipToLine1).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToLine1) || !string.IsNullOrWhiteSpace(x.ShipToLine1)).Distinct().ToList();
            this.CustomerDetailsListShipLine2 = this.CustomerDetailsList.GroupBy(x => x.ShipToLine2).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToLine2) || !string.IsNullOrWhiteSpace(x.ShipToLine2)).Distinct().ToList();
            this.CustomerDetailsListShipCity = this.CustomerDetailsList.GroupBy(x => x.ShipToCity).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToCity) || !string.IsNullOrWhiteSpace(x.ShipToCity)).Distinct().ToList();
            this.CustomerDetailsListShipState = this.CustomerDetailsList.GroupBy(x => x.ShipToState).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToState) || !string.IsNullOrWhiteSpace(x.ShipToState)).Distinct().ToList();
            this.CustomerDetailsListShipCountry = this.CustomerDetailsList.GroupBy(x => x.ShipToCountry).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToCountry) || !string.IsNullOrWhiteSpace(x.ShipToCountry)).Distinct().ToList();
            this.CustomerDetailsListShipPinCode = this.CustomerDetailsList.GroupBy(x => x.ShipToPostCode).Select(y => y.First()).Where(x => !string.IsNullOrEmpty(x.ShipToPostCode) || !string.IsNullOrWhiteSpace(x.ShipToPostCode)).Distinct().ToList();

            DefaultList = this.CustomerDetailsList;
            FullPQList = this.CustomerDetailsList;
            //this.ShowAllCount = this.PurchaseInvoiceListcmb.Count();
            SetDefaultSearchSelection(this.JsonData);
            TotalBalance = Convert.ToString(CustomerDetailsList.Sum(x => x.Balance));
            //var Updateddate = this.CustomerDetailsListCusName.Max(x => x.CreatedDate);
            //string date = this.DateFormat as string;
            //this.LastUpdateDate = Convert.ToDateTime(Updateddate).ToString(date);

        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            ICustomersDetailsListRepository cdRepository = new CustomersDetailsListRepository();
            oData = cdRepository.GetOptionSettings();
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
            
            TaxModel objDefaultTax = new TaxModel();
            objDefaultTax = cdRepository.GetDefaultTaxes();
            if (objDefaultTax != null)
            {
                this.TaxName = objDefaultTax.TaxName;
            }
            else
            {
                this.TaxName = "GST";
            }
        }


        public void SetDefaultSearchSelection(string jsondata)
        {
            if (jsondata != null && jsondata != "[]")
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);
                foreach (var item in objResponse1)
                {
                    switch (item.FieldName)
                    {
                        case "ActiveOrInactive":
                            if (item.FieldValue == "1")
                            {
                                this.ShowBoth = false;
                                this.ShowActive = true;
                                this.ShowInactive = false;
                                this.ShowAllTrue = false;
                                this.ShowSelectedTrue = true;
                            }
                            else if (item.FieldValue == "2")
                            {
                                this.ShowBoth = false;
                                this.ShowActive = false;
                                this.ShowInactive = true;
                                this.ShowAllTrue = false;
                                this.ShowSelectedTrue = true;
                            }
                            else
                            {
                                this.ShowBoth = true;
                                this.ShowActive = false;
                                this.ShowInactive = false;
                                this.ShowAllTrue = true;
                                this.ShowSelectedTrue = false;
                            }
                            break;
                    }
                }
                Search(null);
            }
            else
            {
                this.ShowAllTrue = true;
                this.ShowSelectedTrue = false;
                this.ShowBoth = true;
                this.ShowActive = false;
                this.ShowInactive = false;
            }
        }
        public void LoadSearchResult(string Suppliername)
        {
            ICustomersDetailsListRepository cusRepository = new CustomersDetailsListRepository();
            this.ShowAllCount = cusRepository.GetCustomersList(JsonData).Count();
            this.CustomerDetailsList = cusRepository.GetCustomersList(JsonData
                ).Where(x => x.Name == Suppliername).ToList();
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
                case "SelectedName":
                    GetData(this.SelectedName, "SelectedName");
                    break;
                case "SelectedCompRegNo":
                    GetData(this.SelectedCompRegNo, "SelectedCompRegNo");
                    break;
                case "SelectedGSTRegNo":
                    GetData(this.SelectedGSTRegNo, "SelectedGSTRegNo");
                    break;
                case "SelectedTelephone":
                    GetData(this.SelectedTelephone, "SelectedTelephone");
                    break;
                case "SelectedEmail":
                    GetData(this.SelectedEmail, "SelectedEmail");
                    break;
                case "SelectedFax":
                    GetData(this.SelectedFax, "SelectedFax");
                    break;
                case "SelectedContact":
                    GetData(this.SelectedContact, "SelectedContact");
                    break;
                case "SelectedBalance":
                    GetData(this.SelectedBalance, "SelectedBalance");
                    break;
                case "SelectedType":
                    GetData(this.SelectedType, "SelectedType");
                    break;
                case "SelectedSalesman":
                    GetData(this.SelectedSalesman, "SelectedSalesman");
                    break;
                case "SelectedCreditLimitDays":
                    GetData(this.SelectedCreditLimitDays, "SelectedCreditLimitDays");
                    break;
                case "SelectedCreditLimitAmount":
                    GetData(this.SelectedCreditLimitAmount, "SelectedCreditLimitAmount");
                    break;
                case "SelectedDiscount":
                    GetData(this.SelectedDiscount, "SelectedDiscount");
                    break;
                case "SelectedBillToLine1":
                    GetData(this.SelectedBillToLine1, "SelectedBillToLine1");
                    break;
                case "SelectedBillToLine2":
                    GetData(this.SelectedBillToLine2, "SelectedBillToLine2");
                    break;
                case "SelectedBillToCity":
                    GetData(this.SelectedBillToCity, "SelectedBillToCity");
                    break;
                case "SelectedBillToState":
                    GetData(this.SelectedBillToState, "SelectedBillToState");
                    break;
                case "SelectedBillToCountry":
                    GetData(this.SelectedBillToCountry, "SelectedBillToCountry");
                    break;
                case "SelectedBillToPinCode":
                    GetData(this.SelectedBillToPinCode, "SelectedBillToPinCode");
                    break;
                case "SelectedShipToLine1":
                    GetData(this.SelectedShipToLine1, "SelectedShipToLine1");
                    break;
                case "SelectedShipToLine2":
                    GetData(this.SelectedShipToLine2, "SelectedShipToLine2");
                    break;
                case "SelectedShipToCity":
                    GetData(this.SelectedShipToCity, "SelectedShipToCity");
                    break;
                case "SelectedShipToState":
                    GetData(this.SelectedShipToState, "SelectedShipToState");
                    break;
                case "SelectedShipToCountry":
                    GetData(this.SelectedShipToCountry, "SelectedShipToCountry");
                    break;
                case "SelectedShipToPinCode":
                    GetData(this.SelectedShipToPinCode, "SelectedShipToPinCode");
                    break;
              
                //case "ShowActive":
                //    SetData(this.ShowActive.ToString(), "ShowActive");
                //    break;
                //case "ShowInactive":
                //    SetData(this.ShowInactive.ToString(), "ShowInactive");
                //    break;
                //case "ShowBoth":
                //    SetData(this.ShowBoth.ToString(), "ShowBoth");
                //    break;
             
            }

            base.OnPropertyChanged(name);
        }

        public void SetData(string SearchFilter, string parameter)
        {
            if (parameter == "ShowActive" && SearchFilter != string.Empty && SearchFilter != null)
            {
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
              //  this.ShowActive = true;
                //this.ShowInactive = false;
                //this.ShowBoth = false;
            }
            if (parameter == "ShowInactive" && SearchFilter != string.Empty && SearchFilter != null)
            {
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                //this.ShowActive = false;
                ////this.ShowInactive = true;
                //this.ShowBoth = false;

            }
            if (parameter == "ShowBoth" && SearchFilter != string.Empty && SearchFilter != null)
            {
                this.ShowSelectedTrue = false;
                this.ShowAllTrue = true;
                //this.ShowActive = false;
                //this.ShowInactive = false;
                //this.ShowBoth = true;
            }
           
            Search(null);
            
        }

        public void SearchPQList()
        {

        }

        public void GetData(string SearchFilter, string parameter)
        {
            //IPurchaseInvoiceListRepository purchaseRepository = new PurchaseInvoiceListRepository();
            //var result = purchaseRepository.GetAllPurInvoice().ToList();
            if (SearchFilter != null || SearchFilter == string.Empty)
            {
                if (parameter == "SelectedName")
                {
                    this.ShowAllCount = this.ShowAllCount;
                   
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => (x.Name == SearchFilter)).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => (x.Name == SearchFilter)).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }

                if (parameter == "SelectedCompRegNo")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.CompanyRegNo == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.CompanyRegNo == SearchFilter).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }
                if (parameter == "SelectedGSTRegNo")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.GSTRegNo == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.GSTRegNo == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedTelephone")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.Telephone == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.Telephone == SearchFilter).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }
                if (parameter == "SelectedEmail")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.Email == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.Email == SearchFilter).ToList();
                    }

                    //DefaultList = DefaultList.Where(x => x.SupplierName == SearchFilter).ToList();
                }

                if (parameter == "SelectedFax")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.Fax == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.Fax == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedContact")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.ContactPerson  == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.ContactPerson == SearchFilter).ToList();
                    }
                }
              
                if (parameter == "SelectedBalance")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.BalanceStr == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.BalanceStr == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedType")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.Type == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.Type == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedSalesman")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.Salesman == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.Salesman == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedCreditLimitDays")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.CreditLimitDays == Convert.ToInt32(SearchFilter)).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.CreditLimitDays == Convert.ToInt32(SearchFilter)).ToList();
                    }
                }
                if (parameter == "SelectedCreditLimitAmount")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.CreditLimitAmountStr == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.CreditLimitAmountStr == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedDiscount")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.Discount == Convert.ToInt32(SearchFilter)).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.Discount == Convert.ToInt32(SearchFilter)).ToList();
                    }
                }
                if (parameter == "SelectedBillToLine1")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.BillToLine1 == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.BillToLine1 == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedBillToLine2")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.BillToLine2 == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.BillToLine2 == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedBillToCity")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.BillToCity == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.BillToCity == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedBillToState")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.BillToState == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.BillToState == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedBillToCountry")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.BillToCountry == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.BillToCountry == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedBillToPinCode")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.BillToPostCode == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.BillToPostCode == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedShipToLine1")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.ShipToLine1 == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.ShipToLine1 == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedShipToLine2")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.ShipToLine2 == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.ShipToLine2 == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedShipToCity")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.ShipToCity == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.ShipToCity == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedShipToState")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.ShipToState == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.ShipToState == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedShipToCountry")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.ShipToCountry == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.ShipToCountry == SearchFilter).ToList();
                    }
                }
                if (parameter == "SelectedShipToPinCode")
                {
                    this.ShowAllCount = this.ShowAllCount;
                    //var searchname = SearchFilter.Split('#')[0];
                    if (this.ShowAllTrue == true)
                    {
                        this.CustomerDetailsList = FullPQList.Where(x => x.ShipToPostCode == SearchFilter).ToList();
                    }
                    else
                    {
                        this.CustomerDetailsList = DefaultList.Where(x => x.ShipToPostCode == SearchFilter).ToList();
                    }
                }
            }
            else
            {
                if (this.ShowAllTrue == true)
                {
                    this.CustomerDetailsList = FullPQList.ToList();
                }
                else
                {
                    this.CustomerDetailsList = DefaultList.ToList();
                }
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
            Count = 1;
        }


        #endregion
    }
}
