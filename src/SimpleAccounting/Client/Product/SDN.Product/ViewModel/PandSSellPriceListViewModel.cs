﻿using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SDN.Common;
using SDN.Product.Services;
using SDN.Product.View;
using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SDN.Product.ViewModel
{
    public class PandSSellPriceListViewModel : PandSSellPriceListEntity
    {

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public event PropertyChangedEventHandler PropertyChanged;
        private int Count = 0;
        private List<PandSSellPriceListEntity> DefaultList = new List<PandSSellPriceListEntity>();
        private List<PandSSellPriceListEntity> FullList = new List<PandSSellPriceListEntity>();
        private List<PandSSellPriceListEntity> cmbList = new List<PandSSellPriceListEntity>();
        PandSSellPriceListEntity allPosition = new PandSSellPriceListEntity();
        


        //public List<PandSSellPriceListEntity> DefaultList
        //{
        //    get
        //    {
        //        return _DefaultList;
        //    }
        //    set
        //    {
        //        _DefaultList = value;
        //        OnPropertyChanged("DefaultList");
        //    }
        //}

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseQuotationListViewModel"/> class.
        /// </summary>
        public PandSSellPriceListViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            PandSSellPriceListEntity allPosition = new PandSSellPriceListEntity();
            allPosition.Category1 = "All";
            allPosition.Category2 = "All";
            NavigateToPandSFormCommand = new RelayCommand(NavigatetoPandSForm);
            NavigaetoPandSNewCommand = new RelayCommand(NavigaetoPandSNew);
        }

        public PandSSellPriceListViewModel()
        {
        }

        public RelayCommand YearQuarterSelectedCommand { get; set; }
        public RelayCommand CalendarSelectionCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        public RelayCommand ShowSelectedCommand { get; set; }
        public RelayCommand NavigateToPandSFormCommand { get; set; }
        public RelayCommand ShowIncGSTCommand { get; set; }
        public RelayCommand ShowExcGSTCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand NavigaetoPurchaseCommand { get; set; }
        public RelayCommand NavigaetoPandSNewCommand { get; set; }
        #endregion  Constructor

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
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 31;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.GridHeight = minHeight;
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

        void NavigatetoPandSForm(object param)
        {
            SharedValues.NewClick = null;
            string obj = param.ToString();
            SharedValues.getValue = obj;
            var mainview = ServiceLocator.Current.GetInstance<PandSDetailsView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            //var tabview = ServiceLocator.Current.GetInstance<>();
            //var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            //tabregion.Add(tabview);
            //if (tabregion != null)
            //{
            //    tabregion.Activate(tabview);
            //}

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customer Details Form");
        }
        void NavigaetoPandSNew(object param)
        {
            string obj = param.ToString();
            SharedValues.NewClick = obj;
            var mainview = ServiceLocator.Current.GetInstance<PandSDetailsView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customer Details Form");
        }

        private void RefreshData()
        {
            IPandSSellPriceListRepository pandsRepository = new PandSSellPriceListRepository();
           
            this.PandSSellPriceList = pandsRepository.GetPandSList().OrderBy(x=>x.PandSName).ToList();
            this.ShowAllCount = this.PandSSellPriceList.Count();
            this.ShowSelectedCount = 0;
            FullList = this.PandSSellPriceList.ToList();
            DefaultList = this.PandSSellPriceList.ToList();
            this.PandSSellPriceListcmb = this.PandSSellPriceList.OrderBy(x => x.PandSName).ToList();
            this.PandSSellPriceListcmbCode = this.PandSSellPriceList.OrderBy(x => x.PandSCode).ToList();
            this.PandSSellPriceListcmbCat1 = this.PandSSellPriceList.GroupBy(x => x.Category1).Select(e => e.First()).OrderBy(x => x.Category1).ToList();
            this.PandSSellPriceListcmbCat2 = this.PandSSellPriceList.GroupBy(x => x.Category2).Select(e => e.First()).OrderBy(x => x.Category2).ToList();

            allPosition.Category1 = "All";
            allPosition.Category2 = "All";
            this.PandSSellPriceListcmbCat1.Insert(0, allPosition);
            this.PandSSellPriceListcmbCat2.Insert(0, allPosition);
            GetOptionsandTaxValues();
            this.ShowAllTrue = true;
            this.ShowBoth = true;
            this.ShowSelectedTrue = false;
            this.ShowProducts = false;
            this.ShowServices = false;

            if (this.ShowIncTaxTrue == true)
            {
                foreach (var item in this.PandSSellPriceList)
                {
                    item.StandardSellPriceStr = item.PandSStdSellPriceaftGST.ToString();
                    item.AverageSellPriceStr = item.PandSAveSellPriceaftGST.ToString();
                    item.LastSellPriceStr = item.PandSLastSoldPriceaftGST.ToString();
                }
            }
            else
            {
                foreach (var item in DefaultList)
                {
                    item.StandardSellPriceStr = item.PandSStdSellPricebefGST.ToString();
                    item.AverageSellPriceStr = item.PandSAveSellPricebefGST.ToString();
                    item.LastSellPriceStr = item.PandSLastSoldPricebefGST.ToString();
                }
            }


        }

        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            IPandSSellPriceListRepository pandsRepository = new PandSSellPriceListRepository();
            oData = pandsRepository.GetOptionDetails();
            if (oData != null)
            {
                this.CurrencyName = oData.CurrencyCode;     //there is no currency name field in database         
                this.CurrencyCode = oData.CurrencyCode;
                this.CurrencyFormat = oData.NumberFormat;
                this.DateFormat = oData.DateFormat;
                this.DecimalPlaces = oData.DecimalPlaces;
                if (oData.ShowAmountIncGST == true)
                {
                    this.ShowIncTaxTrue = true;
                    this.ShowExcTaxTrue = false;
                    //int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.PurchaseQuotationList)
                    //{
                    //    item.QuotationAmount = Math.Round(Convert.ToDouble(item.QuotationAmount), decimalpoints).ToString();
                    //}
                    //this.PurchaseQuotationList = this.PurchaseQuotationList.Where(x => x.ExcIncGST == true).ToList();
                }
                else
                {
                    this.ShowIncTaxTrue = false;
                    this.ShowExcTaxTrue = true;
                    int decimalpoints = Convert.ToInt32(DecimalPlaces);
                    //foreach (var item in this.PurchaseQuotationList)
                    //{
                    //    //item.QuotationAmount = item.QuotationAmountExcGST;
                    //    //item.QuotationAmount = Math.Round(Convert.ToDouble(item.QuotationAmountExcGST), decimalpoints).ToString();
                    //    item.QuotationAmount = Math.Round(Convert.ToDouble(item.QuotationAmount), decimalpoints).ToString();
                    //}
                    //commented on 23 May 2017
                    //if (this.PurchaseQuotationList != null)
                    //    this.PurchaseQuotationList = this.PurchaseQuotationList.Where(x => x.ExcIncGST == false).ToList();
                }
            }
            else
            {
                this.CurrencyName = "USD";
                this.CurrencyCode = "USD";
                this.CurrencyFormat = "en-US";
                this.DateFormat = "dd/MM/yyyy";
            }
            var objDefaultTax = pandsRepository.GetTaxes().FirstOrDefault();
            if (objDefaultTax != null)
            {
                this.TaxName = objDefaultTax.TaxName;
            }
            else
            {
                this.TaxName = "GST";
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
                case "ShowIncTaxTrue":
                    GetData(this.ShowIncTaxTrue.ToString(), "ShowIncTaxTrue");
                    break;
                case "ShowExcTaxTrue":
                    GetData(this.ShowExcTaxTrue.ToString(), "ShowExcTaxTrue");
                    break;
                case "ShowProducts":
                    GetData(this.ShowProducts.ToString(), "ShowProducts");
                    break;
                case "ShowServices":
                    GetData(this.ShowServices.ToString(), "ShowServices");
                    break;
                case "ShowBoth":
                    GetData(this.ShowBoth.ToString(), "ShowBoth");
                    break;
                case "ShowAllTrue":
                    GetData(this.ShowAllTrue.ToString(), "ShowAllTrue");
                    break;
                case "ShowSelectedTrue":
                    GetData(this.ShowSelectedTrue.ToString(), "ShowSelectedTrue");
                    break;
                case "SelectedPandSCode":
                    GetData(this.SelectedPandSCode, "SelectedPSCode");
                    break;
                case "SelectedPandSName":
                    GetData(this.SelectedPandSName, "SelectedPSName");
                    break;
                case "SelectedCategory1":
                    GetData(this.SelectedCategory1, "SelectedCategory1");
                    break;
                case "SelectedCategory2":
                    GetData(this.SelectedCategory2, "SelectedCategory2");
                    break;
                case "ShowAll":
                    GetData(this.ShowAllTrue.ToString(), "ShowAll");
                    break;
                    //case "ShowSelectedTrue":
                    //    GetData(this.ShowSelectedTrue.ToString(), "ShowSelectedTrue");
                    //    break;
            }
            base.OnPropertyChanged(name);
        }

        public void GetData(string SearchFilter, string parameter)
        {
            if (parameter == "ShowIncTaxTrue" && SearchFilter == "True")
            {
                foreach (var item in this.PandSSellPriceList)
                {
                    item.StandardSellPriceStr = item.PandSStdSellPriceaftGST.ToString();
                    item.AverageSellPriceStr = item.PandSAveSellPriceaftGST.ToString();
                    item.LastSellPriceStr = item.PandSLastSoldPriceaftGST.ToString();
                }
            }
            if (parameter == "ShowExcTaxTrue" && SearchFilter == "True")
            {
                foreach (var item in this.PandSSellPriceList)
                {
                    item.StandardSellPriceStr = item.PandSStdSellPricebefGST.ToString();
                    item.AverageSellPriceStr = item.PandSAveSellPricebefGST.ToString();
                    item.LastSellPriceStr = item.PandSLastSoldPricebefGST.ToString();
                }
            }
            if (parameter == "ShowAllTrue" && SearchFilter == "True")
            {
                this.SelectedCategory1 = null;
                this.SelectedCategory2 = null;
                this.SelectedPandSCode = null;
                this.SelectedPandSName = null;
                this.PandSSellPriceList = FullList.ToList();
                DefaultList = this.PandSSellPriceList;
                //this.PandSSellPriceListcmb = this.PandSSellPriceList;
                //this.PandSSellPriceListcmbCat1 = this.PandSSellPriceList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                //this.PandSSellPriceListcmbCat2 = this.PandSSellPriceList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                //allPosition.Category1 = "All";
                //allPosition.Category2 = "All";
                //this.PandSSellPriceListcmbCat1.Insert(0, allPosition);
                //this.PandSSellPriceListcmbCat2.Insert(0, allPosition);
                this.ShowSelectedTrue = false;
                //this.ShowAllTrue = true;
                this.ShowSelectedCount = 0;
            }
            if (parameter == "ShowProducts" && SearchFilter == "True")
            {
                this.SelectedCategory1 = null;
                this.SelectedCategory2 = null;
                this.SelectedPandSCode = null;
                this.SelectedPandSName = null;
                this.PandSSellPriceList = FullList.Where(x => x.PandSType == "P").ToList();
                DefaultList = this.PandSSellPriceList;
                //this.PandSSellPriceListcmb = this.PandSSellPriceList;
                //this.PandSSellPriceListcmbCat1 = this.PandSSellPriceList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                //this.PandSSellPriceListcmbCat2 = this.PandSSellPriceList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                //allPosition.Category1 = "All";
                //allPosition.Category2 = "All";
                //this.PandSSellPriceListcmbCat1.Insert(0, allPosition);
                //this.PandSSellPriceListcmbCat2.Insert(0, allPosition);
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.ShowSelectedCount = this.PandSSellPriceList.Count();
            }
            if (parameter == "ShowServices" && SearchFilter == "True")
            {
                this.SelectedCategory1 = null;
                this.SelectedCategory2 = null;
                this.SelectedPandSCode = null;
                this.SelectedPandSName = null;
                this.PandSSellPriceList = FullList.Where(x => x.PandSType == "S").ToList();
                DefaultList = this.PandSSellPriceList;
                //this.PandSSellPriceListcmb = this.PandSSellPriceList;
                //this.PandSSellPriceListcmbCat1 = this.PandSSellPriceList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                //this.PandSSellPriceListcmbCat2 = this.PandSSellPriceList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                //allPosition.Category1 = "All";
                //allPosition.Category2 = "All";
                //this.PandSSellPriceListcmbCat1.Insert(0, allPosition);
                //this.PandSSellPriceListcmbCat2.Insert(0, allPosition);
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.ShowSelectedCount = this.PandSSellPriceList.Count();
            }
            if (parameter == "ShowBoth" && SearchFilter == "True")
            {
                this.SelectedCategory1 = null;
                this.SelectedCategory2 = null;
                this.SelectedPandSCode = null;
                this.SelectedPandSName = null;
                this.PandSSellPriceList = FullList.ToList();
                DefaultList = this.PandSSellPriceList;
                //this.PandSSellPriceListcmb = this.PandSSellPriceList;
                //this.PandSSellPriceListcmbCat1 = this.PandSSellPriceList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                //this.PandSSellPriceListcmbCat2 = this.PandSSellPriceList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                //allPosition.Category1 = "All";
                //allPosition.Category2 = "All";
                //this.PandSSellPriceListcmbCat1.Insert(0, allPosition);
                //this.PandSSellPriceListcmbCat2.Insert(0, allPosition);
                this.ShowSelectedTrue = false;
                this.ShowAllTrue = true;
                this.ShowSelectedCount = 0;
            }
            if (parameter == "SelectedPSCode")
            {
                if (!string.IsNullOrWhiteSpace(SearchFilter))
                {
                    this.PandSSellPriceList = DefaultList.Where(x => x.PandSCode == SearchFilter).ToList();
                }

                else
                {
                    this.PandSSellPriceList = DefaultList;
                }
            }

            if (parameter == "SelectedPSName")
            {
                if (!string.IsNullOrWhiteSpace(SearchFilter))
                {
                    this.PandSSellPriceList = DefaultList.Where(x => x.PandSName == SearchFilter).ToList();
                }

                else
                {
                    this.PandSSellPriceList = DefaultList;
                }

            }
            if (parameter == "SelectedCategory1")
            {
                if (!string.IsNullOrWhiteSpace(SearchFilter))
                {
                    if (SearchFilter != "All")
                    {
                        if (this.SelectedCategory2 != "All")
                        {
                            this.PandSSellPriceList = DefaultList.Where(x => x.Category1 == SearchFilter && x.Category2 == this.SelectedCategory2).ToList();

                        }
                        else this.PandSSellPriceList = DefaultList.Where(x => x.Category1 == SearchFilter).ToList();
                    }

                    else if (this.SelectedCategory2 != "All")
                    {
                        this.PandSSellPriceList = DefaultList.Where(x => x.Category2 == this.SelectedCategory2).ToList();
                    }

                    else { this.PandSSellPriceList = DefaultList; }
                }

                else
                {
                    this.PandSSellPriceList = DefaultList;
                    this.SelectedCategory1 = "All";
                }

            }
            if (parameter == "SelectedCategory2")
            {
                if (!string.IsNullOrWhiteSpace(SearchFilter))
                {
                    if (SearchFilter != "All")
                    {
                        if (this.SelectedCategory1 != "All")
                        {
                            this.PandSSellPriceList = DefaultList.Where(x => x.Category2 == SearchFilter && x.Category1 == this.SelectedCategory1).ToList();
                        }
                        else
                            this.PandSSellPriceList = DefaultList.Where(x => x.Category2 == SearchFilter).ToList();
                    }
                    else if (this.SelectedCategory1 != "All")
                    {
                        this.PandSSellPriceList = DefaultList.Where(x => x.Category1 == this.SelectedCategory1).ToList();
                    }

                    else { this.PandSSellPriceList = DefaultList; }
                }

                else
                {
                    this.PandSSellPriceList = DefaultList;
                    this.SelectedCategory2 = "All";
                }

            }

        }
    }
}
