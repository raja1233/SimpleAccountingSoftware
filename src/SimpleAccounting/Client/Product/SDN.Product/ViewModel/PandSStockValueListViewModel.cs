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
    public class PandSStockValueListViewModel : PandSStockValueListEntity
    {

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public event PropertyChangedEventHandler PropertyChanged;
        private int Count = 0;
        private List<PandSStockValueListEntity> DefaultList = new List<PandSStockValueListEntity>();
        private List<PandSStockValueListEntity> FullList = new List<PandSStockValueListEntity>();
        private List<PandSStockValueListEntity> cmbList = new List<PandSStockValueListEntity>();
        PandSStockValueListEntity allPosition = new PandSStockValueListEntity();



        //public List<PandSStockValueListEntity> DefaultList
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
        public PandSStockValueListViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
            : base()
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.LoadSupplierBackground();
            PandSStockValueListEntity allPosition = new PandSStockValueListEntity();
            allPosition.Category1 = "All";
            allPosition.Category2 = "All";
            NavigateToPandSFormCommand = new RelayCommand(NavigatetoPandSForm);
            NavigaetoPandSNewCommand = new RelayCommand(NavigaetoPandSNew);
        }

        public PandSStockValueListViewModel()
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
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 30;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);

            this.GridHeight = minHeight;
            RefreshData();
        }
        //List<PandSStockValueListEntity> DefaultList = new List<PandSStockValueListEntity>();
        //List<PandSStockValueListEntity> FullList = new List<PandSStockValueListEntity>();
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
            IPandSStockValueListRepository pandsRepository = new PandSStockValueListRepository();

            this.PandSStockValueList = pandsRepository.GetPandSList().OrderBy(x => x.PandSName).ToList();
            this.ShowAllCount = this.PandSStockValueList.Count();
            this.ShowSelectedCount = 0;
            FullList = this.PandSStockValueList.ToList();
            DefaultList = this.PandSStockValueList.ToList();
            this.PandSStockValueListcmb = this.PandSStockValueList.OrderBy(x => x.PandSName).ToList();
            this.PandSStockValueListcmbCode = this.PandSStockValueList.OrderBy(x => x.PandSName).ToList();
            this.PandSStockValueListcmbCat1 = this.PandSStockValueList.GroupBy(x => x.Category1).Select(e => e.First()).OrderBy(x => x.Category1).ToList();
            this.PandSStockValueListcmbCat2 = this.PandSStockValueList.GroupBy(x => x.Category2).Select(e => e.First()).OrderBy(x => x.Category2).ToList();
            this.TotalQtyInStock = Convert.ToString(this.PandSStockValueList.Sum(e => e.QtyInStock));

            allPosition.Category1 = "All";
            allPosition.Category2 = "All";
            this.PandSStockValueListcmbCat1.Insert(0, allPosition);
            this.PandSStockValueListcmbCat2.Insert(0, allPosition);
            GetOptionsandTaxValues();
            this.ShowAllTrue = true;
            this.ShowBoth = true;
            this.ShowSelectedTrue = false;
            this.ShowProducts = false;
            this.ShowServices = false;

            if (this.ShowIncTaxTrue == true)
            {
                foreach (var item in this.PandSStockValueList)
                {
                    item.StandardCostPriceStr = item.PandSAveCostPricebefGST.ToString();
                    item.AverageCostPriceStr = item.PandSAveCostPriceaftGST.ToString();
                    item.PSStockValueStr = item.PSStockValueaftTax.ToString();
                   
                }
                this.TotalStockValue = Convert.ToString(this.PandSStockValueList.Sum(e => e.PSStockValueaftTax));
                this.TotalAvgCostPrice = Convert.ToString(this.PandSStockValueList.Sum(e => e.PandSAveCostPriceaftGST));
            }
            else
            {
                foreach (var item in DefaultList)
                {
                    item.StandardCostPriceStr = item.PandSAveCostPricebefGST.ToString();
                    item.AverageCostPriceStr = item.PandSAveCostPriceaftGST.ToString();
                    item.PSStockValueStr = item.PSStockValuebefTax.ToString();
                   
                }
                this.TotalStockValue = Convert.ToString(this.PandSStockValueList.Sum(e => e.PSStockValuebefTax));
                this.TotalAvgCostPrice = Convert.ToString(this.PandSStockValueList.Sum(e => e.PandSAveCostPricebefGST));
            }


        }

        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();
            IPandSStockValueListRepository pandsRepository = new PandSStockValueListRepository();
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
                foreach (var item in this.PandSStockValueList)
                {
                    item.StandardCostPriceStr = item.PandSAveCostPriceaftGST.ToString();
                    item.AverageCostPriceStr = item.PandSAveCostPriceaftGST.ToString();
                    item.PSStockValueStr = item.PSStockValueaftTax.ToString();
                    
                }
                this.TotalStockValue = Convert.ToString(this.PandSStockValueList.Sum(e => e.PSStockValueaftTax));
                this.TotalAvgCostPrice = Convert.ToString(this.PandSStockValueList.Sum(e => e.PandSAveCostPriceaftGST));
            }
            if (parameter == "ShowExcTaxTrue" && SearchFilter == "True")
            {
                foreach (var item in this.PandSStockValueList)
                {
                    item.StandardCostPriceStr = item.PandSAveCostPricebefGST.ToString();
                    item.AverageCostPriceStr = item.PandSAveCostPricebefGST.ToString();
                    item.PSStockValueStr = item.PSStockValuebefTax.ToString();
                  
                }
                this.TotalStockValue = Convert.ToString(this.PandSStockValueList.Sum(e => e.PSStockValuebefTax));
                this.TotalAvgCostPrice = Convert.ToString(this.PandSStockValueList.Sum(e => e.PandSAveCostPricebefGST));
            }
            if (parameter == "ShowAllTrue" && SearchFilter == "True")
            {
                this.SelectedCategory1 = null;
                this.SelectedCategory2 = null;
                this.SelectedPandSCode = null;
                this.SelectedPandSName = null;
                this.PandSStockValueList = FullList.ToList();
                DefaultList = this.PandSStockValueList;
                //this.PandSStockValueListcmb = this.PandSStockValueList;
                //this.PandSStockValueListcmbCat1 = this.PandSStockValueList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                //this.PandSStockValueListcmbCat2 = this.PandSStockValueList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                //allPosition.Category1 = "All";
                //allPosition.Category2 = "All";
                //this.PandSStockValueListcmbCat1.Insert(0, allPosition);
                //this.PandSStockValueListcmbCat2.Insert(0, allPosition);
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
                this.PandSStockValueList = FullList.Where(x => x.PandSType == "P").ToList();
                DefaultList = this.PandSStockValueList;
                //this.PandSStockValueListcmb = this.PandSStockValueList;
                //this.PandSStockValueListcmbCat1 = this.PandSStockValueList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                //this.PandSStockValueListcmbCat2 = this.PandSStockValueList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                //allPosition.Category1 = "All";
                //allPosition.Category2 = "All";
                //this.PandSStockValueListcmbCat1.Insert(0, allPosition);
                //this.PandSStockValueListcmbCat2.Insert(0, allPosition);
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.ShowSelectedCount = this.PandSStockValueList.Count();
            }
            if (parameter == "ShowServices" && SearchFilter == "True")
            {
                this.SelectedCategory1 = null;
                this.SelectedCategory2 = null;
                this.SelectedPandSCode = null;
                this.SelectedPandSName = null;
                this.PandSStockValueList = FullList.Where(x => x.PandSType == "S").ToList();
                DefaultList = this.PandSStockValueList;
                //this.PandSStockValueListcmb = this.PandSStockValueList;
                //this.PandSStockValueListcmbCat1 = this.PandSStockValueList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                //this.PandSStockValueListcmbCat2 = this.PandSStockValueList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                //allPosition.Category1 = "All";
                //allPosition.Category2 = "All";
                //this.PandSStockValueListcmbCat1.Insert(0, allPosition);
                //this.PandSStockValueListcmbCat2.Insert(0, allPosition);
                this.ShowSelectedTrue = true;
                this.ShowAllTrue = false;
                this.ShowSelectedCount = this.PandSStockValueList.Count();
            }
            if (parameter == "ShowBoth" && SearchFilter == "True")
            {
                this.SelectedCategory1 = null;
                this.SelectedCategory2 = null;
                this.SelectedPandSCode = null;
                this.SelectedPandSName = null;
                this.PandSStockValueList = FullList.ToList();
                DefaultList = this.PandSStockValueList;
                //this.PandSStockValueListcmb = this.PandSStockValueList;
                //this.PandSStockValueListcmbCat1 = this.PandSStockValueList.GroupBy(x => x.Category1).Select(e => e.First()).ToList();
                //this.PandSStockValueListcmbCat2 = this.PandSStockValueList.GroupBy(x => x.Category2).Select(e => e.First()).ToList();
                //allPosition.Category1 = "All";
                //allPosition.Category2 = "All";
                //this.PandSStockValueListcmbCat1.Insert(0, allPosition);
                //this.PandSStockValueListcmbCat2.Insert(0, allPosition);
            }
            if (parameter == "SelectedPSCode")
            {
                if (!string.IsNullOrWhiteSpace(SearchFilter))
                {
                    this.PandSStockValueList = DefaultList.Where(x => x.PandSCode == SearchFilter).ToList();
                }

                else
                {
                    this.PandSStockValueList = DefaultList;
                }
            }

            if (parameter == "SelectedPSName")
            {
                if (!string.IsNullOrWhiteSpace(SearchFilter))
                {
                    this.PandSStockValueList = DefaultList.Where(x => x.PandSName == SearchFilter).ToList();
                }

                else
                {
                    this.PandSStockValueList = DefaultList;
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
                            this.PandSStockValueList = DefaultList.Where(x => x.Category1 == SearchFilter && x.Category2 == this.SelectedCategory2).ToList();
                        }
                        else
                            this.PandSStockValueList = DefaultList.Where(x => x.Category1 == SearchFilter).ToList();
                        //DefaultList = this.PandSStockValueList;
                    }
                    else if (this.SelectedCategory2 != "All")
                    {
                        this.PandSStockValueList = DefaultList.Where(x => x.Category2 == this.SelectedCategory2).ToList();
                    }

                    else { this.PandSStockValueList = DefaultList; }
                }

                else
                {
                    this.PandSStockValueList = DefaultList;
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
                            this.PandSStockValueList = DefaultList.Where(x => x.Category2 == SearchFilter && x.Category1 == this.SelectedCategory1).ToList();
                        }
                        else
                            this.PandSStockValueList = DefaultList.Where(x => x.Category2 == SearchFilter).ToList();
                        //DefaultList = this.PandSStockValueList;
                    }
                    else if (this.SelectedCategory1 != "All")
                    {
                        this.PandSStockValueList = DefaultList.Where(x => x.Category1 == this.SelectedCategory1).ToList();
                    }

                    else { this.PandSStockValueList = DefaultList; }
                }
                else
                {
                    this.PandSStockValueList = DefaultList;
                    this.SelectedCategory2 = "All";
                }

            }

        }
    }
}
