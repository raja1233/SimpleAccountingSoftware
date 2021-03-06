﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.ViewModel
{
    using Common;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Sales.Services;
    using SASClient.CloseRequest;
    using SDN.UI.Entities.Product;
    using Services;
    using Settings.Services;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Input;
    using UI.Entities;

    public class CountAndAdjustStockViewModel : CountAndAdjustStockEntity
    {
        #region "Private members"
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _DateErrors;
        private DateTime? _CountNAjustDateCalender;
        ICompanyDetails CompanyD = new CompanyDetails();
        private ObservableCollection<DataGridViewModel> psDetailsEntity;
        // private static IEnumerable<PandSDetailsModel> ProductList;
        private static IEnumerable<PandSQtyAndStockModel> ProductList;
        private ICountAndAdjustStockRepository casRepository = new CountAndAdjustStockRepository();
        public IPandSDetailsRepository pandsRepository = new PandSDetailsRepository();
        // private ObservableCollection<PandSDetailsModel> productAndServices;
        private ObservableCollection<PandSQtyAndStockModel> productAndServices;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public ObservableCollection<DataGridViewModel> lst;
        private bool isNew;
        private string casErrors;
        private int showAllCount;
        private int showSelectedCount;
        private int selectedPSCat1;
        private int selectedPSCat2;
        private bool showAllrdn;
        private bool showSelectedrdn;
        StackList listitem = new StackList();
        #endregion

        #region "Properties"
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
        public DateTime? CountNAjustDateCalender
        {
            get
            {
                return _CountNAjustDateCalender;
            }
            set
            {
                _CountNAjustDateCalender = value;
                OnPropertyChanged("CountNAjustDateCalender");
            }
        }
        public ObservableCollection<DataGridViewModel> PSDetailsEntity
        {
            get { return psDetailsEntity; }
            set
            {
                psDetailsEntity = value;
                OnPropertyChanged("PSDetailsEntity");
            }
        }

        public ObservableCollection<DataGridViewModel> Lst
        {
            get { return lst; }
            set
            {
                lst = value;
                OnPropertyChanged("Lst");
            }
        }

        //public ObservableCollection<PandSDetailsModel> ProductAndServices
        //{
        //    get
        //    {
        //        return productAndServices;
        //    }
        //    set
        //    {
        //        if (productAndServices != value)
        //        {
        //            productAndServices = value;
        //            OnPropertyChanged("ProductAndServices");
        //        }
        //    }
        //}
        public ObservableCollection<PandSQtyAndStockModel> ProductAndServices
        {
            get
            {
                return productAndServices;
            }
            set
            {
                if (productAndServices != value)
                {
                    productAndServices = value;
                    OnPropertyChanged("ProductAndServices");
                }
            }
        }

        public bool IsNew
        {
            get { return isNew; }
            set
            {
                isNew = value;
                OnPropertyChanged("IsNew");
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

        public bool ShowAllrdn
        {
            get { return showAllrdn; }
            set
            {
                showAllrdn = value;
                OnPropertyChanged("ShowAllrdn");
            }
        }
        public bool ShowSelectedrdn
        {
            get { return showSelectedrdn; }
            set
            {
                showSelectedrdn = value;
                OnPropertyChanged("ShowSelectedrdn");
            }
        }

        public int ShowAllCount
        {
            get { return showAllCount; }
            set
            {
                showAllCount = value;
                OnPropertyChanged("ShowAllCount");
            }
        }
        public int ShowSelectedCount
        {
            get { return showSelectedCount; }
            set
            {
                showSelectedCount = value;
                OnPropertyChanged("ShowSelectedCount");
            }
        }

        public int SelectedPSCat1
        {
            get { return selectedPSCat1; }
            set
            {
                selectedPSCat1 = value;
                OnPropertyChanged("SelectedPSCat1");
                if (selectedPSCat1 != 0)
                {
                    ShowSelected();
                }
            }
        }
        public int SelectedPSCat2
        {
            get { return selectedPSCat2; }
            set
            {
                selectedPSCat2 = value;
                OnPropertyChanged("SelectedPSCat2");
                if (selectedPSCat2 != 0)
                {
                    ShowSelected();
                }
            }
        }
        #endregion

        #region "Constructor"
        public CountAndAdjustStockViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            LoadSupplierBackground();

            int minHeight = 300;
            int headerRows = 300;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows - 47;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.PSFormGridHeight = minHeight;
            PSDetailsEntity = new ObservableCollection<DataGridViewModel>();
            Lst = new ObservableCollection<DataGridViewModel>();
           
            if (IsNew == false)
            {
                ShowAllCount = PSDetailsEntity.Count();
            }
            StockDate = DateTime.Now;
            SaveCommand = new RelayCommand(SaveCountAndAdjustStock, CanSave);
            NewPSCommand = new RelayCommand(GetNewCountAndAdjustStock);
            ShowAllCommand = new RelayCommand(ShowAll);
            StockTakeCommand = new RelayCommand(OnStockTake);
            IncDecStockCommand = new RelayCommand(IncDecStock);
            CloseCommand = new DelegateCommand(Close);
            if (!String.IsNullOrEmpty(SharedValues.NewClick))
            {
                if (SharedValues.NewClick != "New")
                {
                    MustCompare = false;
                    GetCountAndAdjustStock(SharedValues.NewClick);
                }
                else if (SharedValues.NewClick == "New")
                {
                    MustCompare = true;
                    GetNewCountAndAdjustStock(null);
                }
            }
        }

        #endregion

        #region "relay Commands"
        public ICommand CloseCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand NewPSCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        public RelayCommand StockTakeCommand { get; set; }
        public RelayCommand IncDecStockCommand { get; set; }
        #endregion

        #region "Command methods"

        public void ShowAll(object param)
        {
            PSDetailsEntity = Lst;
            SelectedPSCat1 = 0;
            SelectedPSCat2 = 0;
            ShowAllCount = PSDetailsEntity.Where(e => e.SelectedPSID != 0).Count();
            ShowAllrdn = true;
            ShowSelectedrdn = false;
            ShowSelectedCount = 0;
            OnPropertyChanged("PSDetailsEntity");

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
        public void ShowSelected()
        {

            // List<DataGridViewModel> lst = new List<DataGridViewModel>();

            if (SelectedPSCat1 != 0 && SelectedPSCat2 != 0)
            {
                PSDetailsEntity = new ObservableCollection<DataGridViewModel>(Lst.Where(e => e.PSCat1 == SelectedPSCat1 && e.PSCat2 == SelectedPSCat2));
            }
            else if (SelectedPSCat1 != 0)
            {
                PSDetailsEntity = new ObservableCollection<DataGridViewModel>(Lst.Where(e => e.PSCat1 == SelectedPSCat1));
            }
            else if (SelectedPSCat2 != 0)
            {
                PSDetailsEntity = new ObservableCollection<DataGridViewModel>(Lst.Where(e => e.PSCat2 == SelectedPSCat2));
            }
            ShowAllrdn = false;
            ShowSelectedrdn = true;
            ShowSelectedCount = PSDetailsEntity.Where(e => e.SelectedPSID != 0).Count();
            OnPropertyChanged("PSDetailsEntity");
        }

        public void OnStockTake(object param)
        {
            SharedValues.StockType= Convert.ToInt16(Stock_Type.StockTake);
            Type = Convert.ToInt16(Stock_Type.StockTake);
            foreach (var item in PSDetailsEntity.Where(e=>e.SelectedPSID!=0 || e.SelectedPSID!=null))
            {
                item.Difference = item.CountQty - item.SystemQty;
                if (item.Difference != null)
                {
                    if (item.AvgCost != Convert.ToString(0))
                    {
                        item.Amount = Convert.ToInt32(item.Difference) * Convert.ToDecimal(item.AvgCost);
                        item.AdjustedAmount = item.AdjustedAmount + item.Amount;
                    }
                    else
                    {
                        item.AvgCost = item.AvgCostStr;
                        item.Amount = Convert.ToInt32(item.Difference) * Convert.ToDecimal(item.AvgCostStr);
                        item.AdjustedAmount = item.AdjustedAmount + item.Amount;
                    }
                }
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
                case "CountNAjustDateCalender":
                    FillStartDate();
                    break;


            }
            base.OnPropertyChanged(name);
        }


        void FillStartDate()
        {
            string date = this.DateFormat as string;
            StockDateStr = Convert.ToDateTime(this.CountNAjustDateCalender).ToString(date);

        }
        public void IncDecStock(object param)
        {
            SharedValues.StockType = Convert.ToInt16(Stock_Type.IncreaseDecreaseStock);
            Type = Convert.ToInt16(Stock_Type.IncreaseDecreaseStock);
            foreach (var item in PSDetailsEntity.Where(e => e.SelectedPSID != 0 ))
            {
                item.Amount = 0;
                item.AdjustedAmount = 0;
                item.AvgCost = Convert.ToString(0);
            }
        }

        public void SaveCountAndAdjustStock(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                string msg = ValidateCountAndAdjustStock();
                if (msg != string.Empty)
                {
                    DateErrors = msg;
                    Mouse.OverrideCursor = null;
                    return;
                }

                DateErrors = string.Empty;
                CountAndAdjustStockForm CAForm = GetDataIntoModel();

                int i = 0;
                if (IsNew == true)
                {
                    i = casRepository.SaveCountAndAdjustStock(CAForm);
                }
                else
                {
                    i = casRepository.UpdateCountAndAdjustStock(CAForm);
                }
                if (i > 0)
                {
                    IsNew = false;
                }
                Mouse.OverrideCursor = null;
            }
        }
        public bool CanSave(object param)
        {
            string date = this.DateFormat as string;
            var c = CompanyD.GetCompanyDetails().Comp_year_start_date;

            if (StockDateStr != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(StockDateStr) && !string.IsNullOrWhiteSpace(StockDateStr))
                    {

                        //item.StartDate = item.StartDate.Replace('.', '/');
                        //item.StartDate = item.StartDate.Replace('-', '/');
                        //item.EndDate = item.EndDate.Replace('.', '/');
                        //item.EndDate = item.EndDate.Replace('-', '/');
                        var Start = (DateTime.ParseExact(StockDateStr, date, CultureInfo.InvariantCulture));
                        this.DateErrors = "";
                        //var End = (DateTime.ParseExact(item.EndDate, date, CultureInfo.InvariantCulture));
                        if (Start < c)
                        {
                            this.DateErrors = "Date should be greater than Start Financial year";
                            return false;
                        }

                    }
                }
                catch (Exception ex)
                {
                    this.DateErrors = "Please enter the date in " + date + " format!";
                    return false;
                }
                return true;
            }
            else
            {
                return true;
            }
        }
        #endregion

            #region "Public Methods"

        public void RefreshData()
        {
            ProductList = pandsRepository.GetPandSList().Where(e => e.PSType == "P" && e.IsInActive != "Y");
            if (ProductList != null)
            {
                ProductAndServices = new ObservableCollection<PandSQtyAndStockModel>(ProductList);
            }
            
            var pscat1 = pandsRepository.GetCategoryContent("PSC01");
            var pscat2 = pandsRepository.GetCategoryContent("PSC02");
            if (pscat1 != null)
            {
                PSCategory1 = pscat1.ToList();
            }
            if (pscat2 != null) { PSCategory2 = pscat2.ToList(); }
            AdjustedAmountStr = Convert.ToString(PSDetailsEntity.Sum(e => e.Amount));
            GetOptionsandTaxValues();
        }

        public string ValidateCountAndAdjustStock()
        {
            string msg = string.Empty;
            if(this.StockDateStr==null)
            {
                msg = "Please Enter Date";
            }

            return msg;

        }
        void GetOptionsandTaxValues()
        {
            OptionsEntity oData = new OptionsEntity();

            oData = pandsRepository.GetOptionDetails();
            if (oData != null)
            {
                this.CurrencyName = oData.CurrencyCode;     //there is no currency name field in database         

                this.DateFormat = oData.DateFormat;
                this.DecimalPlaces = oData.DecimalPlaces;
            }
            else
            {
                this.CurrencyName = "USD";
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
        public void GetCountAndAdjustStock(string scNo)
        {
            // Mouse.OverrideCursor = Cursors.Wait;
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            CountAndAdjustStockForm pqf = casRepository.GetCountAndAdjustStock(scNo);

            this.StockCountNo = pqf.CountAndAdjustStock.StockCountNo;
            DateTime Dateinstr = (DateTime)pqf.CountAndAdjustStock.StockDate;
            this.StockDateStr = Dateinstr.ToString(oData.DateFormat);

            if (pqf.CountAndAdjustStock.Type == Convert.ToInt16(Stock_Type.IncreaseDecreaseStock))
            {
                IsIncreaseDecreaseStock = true;
                IsStockDamaged = false;
                IsStockTake = false;
                SharedValues.StockType = Convert.ToInt16(Stock_Type.IncreaseDecreaseStock);
            }
            else if (pqf.CountAndAdjustStock.Type == Convert.ToInt16(Stock_Type.StockDamaged))
            {
                IsIncreaseDecreaseStock = false;
                IsStockDamaged = true;
                IsStockTake = false;
                SharedValues.StockType = Convert.ToInt16(Stock_Type.StockDamaged);
            }
            else if (pqf.CountAndAdjustStock.Type == Convert.ToInt16(Stock_Type.StockTake))
            {
                IsIncreaseDecreaseStock = false;
                IsStockDamaged = false;
                IsStockTake = true;
                SharedValues.StockType = Convert.ToInt16(Stock_Type.StockTake);
            }

            this.PSDetailsEntity = new ObservableCollection<DataGridViewModel>();
            foreach (var item in pqf.CountAndAdjustStockDetails)
            {
                DataGridViewModel pqEntity = new DataGridViewModel(ProductList);
                pqEntity.SelectedPSID = item.PSID;
                pqEntity.PandSCode = item.PandSCode;
                pqEntity.PandSName = item.PandSName;
                pqEntity.SystemQty = item.SystemQty;
                pqEntity.CountQty = item.CountQty;
                pqEntity.Difference = item.Difference;

                pqEntity.AvgCost = Convert.ToString(item.AverageCost);
                pqEntity.Amount = item.Amount;
                pqEntity.AmountStr = item.AmountStr;

                PSDetailsEntity.Add(pqEntity);
            }

        }
        public void GetNewCountAndAdjustStock(object param)
        {
            this.StockCountNo = "AS-" + casRepository.GetLatestStockCountNo();
            IsIncreaseDecreaseStock = true;
            IsStockDamaged = false;
            IsStockTake = false;
            SharedValues.StockType = Convert.ToInt32(Stock_Type.IncreaseDecreaseStock);
            IsNew = true;
            AdjustedAmountStr = Convert.ToString(0);
            if (PSDetailsEntity != null)
            {
                if (PSDetailsEntity.Count > 0)
                {
                    PSDetailsEntity.Clear();
                    // var row = new CollectAmountDataGridViewModel();
                    //  PQDetailsEntity.Add(row);
                    OnPropertyChanged("PSDetailsEntity");
                }
            }
            var row = new DataGridViewModel(ProductList);
            //row.SelectedPSID = 0;
            PSDetailsEntity.Add(row);
            OnPropertyChanged("PSDetailsEntity");
            Lst = PSDetailsEntity;
        }
        public CountAndAdjustStockForm GetDataIntoModel()
        {
            OptionsEntity oData = new OptionsEntity();
            ISalesOrderListRepository purchaseRepository = new SalesOrderListRepository();
            oData = purchaseRepository.GetOptionSettings();
            CountAndAdjustStockForm CSForm = new CountAndAdjustStockForm();
            CSForm.CountAndAdjustStockDetails = new List<CountAndAdjustStockDetailsEntity>();
            CountAndAdjustStockEntity model = new CountAndAdjustStockEntity();
            model.StockCountNo = this.StockCountNo;
            model.StockDate = DateTime.ParseExact(this.StockDateStr, oData.DateFormat, null);

            if (IsIncreaseDecreaseStock == true) { model.StockType = Convert.ToByte(Stock_Type.IncreaseDecreaseStock); }
            if (IsStockDamaged == true) { model.StockType = Convert.ToByte(Stock_Type.StockDamaged); }
            if (IsStockTake == true) { model.StockType = Convert.ToByte(Stock_Type.StockTake); }

            CSForm.CountAndAdjustStock = model;

            foreach (var item in PSDetailsEntity.Where(e=>e.CountQty!=0))
            {
                if (item.SelectedPSID != 0)
                {
                    CountAndAdjustStockDetailsEntity pqEntity = new CountAndAdjustStockDetailsEntity();
                    pqEntity.PSID = item.SelectedPSID;
                    pqEntity.PandSCode = item.PandSCode;
                    pqEntity.PandSName = item.PandSName;
                    pqEntity.SystemQty = item.SystemQty;
                    pqEntity.CountQty = item.CountQty;
                    pqEntity.Difference = item.Difference;
                    pqEntity.AvgCost = item.AvgCost;
                    pqEntity.Amount = item.Amount;
                    pqEntity.AdjustedAmount = Convert.ToDecimal(AdjustedAmountStr);
                    pqEntity.AdjustedAmountStr = AdjustedAmountStr;
                    if (item.SelectedPSID != 0 && Convert.ToInt32(item.SelectedPSID) > 0)
                    {
                        CSForm.CountAndAdjustStockDetails.Add(pqEntity);
                    }
                }
            }
            return CSForm;
        }
        public int ManageDuplicatePandS()
        {
            int rowFocusindex = -1;
            ShowAllCount = PSDetailsEntity.Where(e => e.SelectedPSID != 0).Count();
            lst = new ObservableCollection<DataGridViewModel>();
            lst = PSDetailsEntity;

            var query = lst.GroupBy(x => x.SelectedPSID)
              .Where(g => g.Count() > 1)
              .ToList();
            if (query.Count > 0 && PSDetailsEntity.Count > 1)
            {

                var obj1 = query[0].ElementAt(0);
                var obj2 = query[0].ElementAt(1);
                int? qty = 1;
                decimal? productAmount2 = 0;
                // decimal? discountP2 = 0;
                qty = query[0].ElementAt(0).CountQty + query[0].ElementAt(1).CountQty;
                productAmount2 = Convert.ToDecimal(query[0].ElementAt(1).Amount);
                // discountP2 = query[0].ElementAt(1).PQDiscount;

                var index1 = lst.IndexOf(query[0].ElementAt(0));
                var index2 = lst.IndexOf(query[0].ElementAt(1));

                if (productAmount2 != null)
                {
                    obj1.CountQty = qty;
                    obj1.AmountStr = Convert.ToString(productAmount2);
                    // obj1.PQDiscount = discountP2;
                    PSDetailsEntity[index1] = obj1;
                    var row = new DataGridViewModel(ProductList);
                    //row.CountQty = 0;

                    PSDetailsEntity[index2] = row;
                    rowFocusindex = index2;
                }

                OnPropertyChanged("PSDetailsEntity");
                Lst = PSDetailsEntity;
            }
            else
            {
                int count = PSDetailsEntity.Count(x => x.SelectedPSID == 0);
                if (count == 0)
                {
                    var row = new DataGridViewModel(ProductList);
                    // row.CountQty = 0;
                    //   row.GSTRate = TaxRate;

                    PSDetailsEntity.Add(row);
                    OnPropertyChanged("PSDetailsEntity");
                    Lst = PSDetailsEntity;
                    rowFocusindex = -1;
                }
                else
                {
                    var emptyRow = lst.Where(y => y.SelectedPSID == 0).FirstOrDefault();
                    rowFocusindex = PSDetailsEntity.IndexOf(emptyRow);
                }

            }
            AdjustedAmountStr = Convert.ToString(PSDetailsEntity.Sum(e => e.Amount));
            return rowFocusindex;
        }

        #endregion

        #region BackGround Worker
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

        #endregion
    }
}
