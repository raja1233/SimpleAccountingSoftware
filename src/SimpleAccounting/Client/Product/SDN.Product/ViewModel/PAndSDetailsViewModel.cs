using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.ViewModel
{
    using Common;
    using SDN.UI.Entities;
    using System.Collections.ObjectModel;
    using SDN.Product.Services;
    using System.IO;
    using System.Windows.Media.Imaging;
    using System.Drawing;
    using SDN.Common.Formatters;
    using System.Windows;
    using System.ComponentModel;
    using System.Windows.Input;
    using System.Globalization;
    using System.Configuration;

    public static class BitmapConversion
    {
        public static BitmapSource BitmapToBitmapSource(Bitmap source)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          source.GetHbitmap(),
                          IntPtr.Zero,
                          Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());
        }
    }

    public class PAndSDetailsViewModel : ViewModelBase
    {
        #region "private data members"
        byte[] Default_photo_aray;
        private List<PandSDetailsModel> productAndServices;
        ObservableCollection<ContentModel> psCategory1;
        ObservableCollection<ContentModel> psCategory2;
        ObservableCollection<TaxModel> tax;

        private string taxName;
        private TaxModel selectedTaxID;
        private ContentModel selectedPSCategory1;
        private ContentModel selectedPSCategory2;
        private int? defaultCat1;
        private int? defaultCat2;
        private int totalPandS;
        private int activePandS;
        private int inactivePandS;
        private int productCount;
        private int servicesCount;
        private bool isNew = false;
        private string pandsErrors;
        private int? defaultTaxId;
       
        private string refreshdate;
        private int decimalPlaces;
        private System.Windows.Visibility visibilityForLabel;
        private System.Windows.Visibility visibilityForTextBox;

        IPandSDetailsRepository pandRepository = new PandSDetailsRepository();


        #endregion

        #region "Constructors"
        public PAndSDetailsViewModel()
        {
            Mouse.OverrideCursor = Cursors.Wait;

            IsProduct = true;
            VisibilityForTextBox = System.Windows.Visibility.Visible;
            VisibilityForLabel = System.Windows.Visibility.Collapsed;
            RefreshPandSData();
            if (SharedValues.NewClick == "New")
                OnNewPandS(SharedValues.NewClick);
           

            string currentDirectory = Directory.GetCurrentDirectory();
           // var dataDirectory = ConfigurationManager.AppSettings["DataDirectory"];
            string filePath = Path.Combine(currentDirectory, "DefaultImage.png");
            try
            {
               
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                Default_photo_aray = new byte[fs.Length];
                fs.Read(Default_photo_aray, 0, Convert.ToInt32(fs.Length));
                fs.Close();
            }
            catch  
            {
              //  MessageBox.Show("Error:Can't Read default image of product from "+ filePath, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                 
            }
            GetPandSData();

            var lstOptions = pandRepository.GetOptionDetails();
            if (lstOptions != null)
            {
                decimalPlaces = lstOptions.DecimalPlaces;
                CurrencyName = lstOptions.CurrencyCode;
            }

            SellPriceTextChangedCommand = new RelayCommand(CalculateStandardSellPrices);
            CostPriceTextChangedCommand = new RelayCommand(CalculateStandardCostPrices);
            RateSelectionChangedCommand = new RelayCommand(CalculateStandardPricesFromRate);
            SellPriceAfterTaxTextChangedCommand = new RelayCommand(CalculateStandardSellPriceFromAfterTax);
            CostPriceAfterTaxTextChangedCommand = new RelayCommand(CalculateStandardCostPriceFromAfterTax);
            SaveCommand = new RelayCommand(SavePandS, CanSave);
            DeleteCommand = new RelayCommand(DeletePandS, CanDelete);
            NewPandSCommand = new RelayCommand(OnNewPandS,CanNew);
            PrevClickCommand = new RelayCommand(OnPrevPandS, CanPrev);
            NextClickCommand = new RelayCommand(OnNextPandS, CanNext);
            PandSSelectionChangedCommand = new RelayCommand(SetPandSData);
            DuplicateCommand = new RelayCommand(GetDuplicate,CanDuplicate);
            RefreshCommand = new RelayCommand(GetRefreshData);
            ProductsCheckedCommand = new RelayCommand(OnProductsChecked);
            ServiceCheckedCommand = new RelayCommand(OnServiceChecked);
            Mouse.OverrideCursor = null;
        }
        #endregion

        #region "Relay Command"
        public RelayCommand SellPriceTextChangedCommand { get; set; }
        public RelayCommand CostPriceTextChangedCommand { get; set; }
        public RelayCommand RateSelectionChangedCommand { get; set; }
        public RelayCommand SellPriceAfterTaxTextChangedCommand { get; set; }
        public RelayCommand CostPriceAfterTaxTextChangedCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public RelayCommand DuplicateCommand { get; set; }
        public RelayCommand NewPandSCommand { get; set; }
        public RelayCommand PrevClickCommand { get; set; }
        public RelayCommand NextClickCommand { get; set; }

        public RelayCommand ProductsCheckedCommand { get; set; }
        public RelayCommand ServiceCheckedCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand PandSSelectionChangedCommand { get; set; }

        #endregion

        #region "Properties"

        public List<PandSDetailsModel> ProductAndServices
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

        public ObservableCollection<ContentModel> PSCategory1
        {
            get
            {
                return psCategory1 = new ObservableCollection<ContentModel>(pandRepository.GetCategoryContent("PSC01".Trim()));
            }
            set
            {
                psCategory1 = value;
                OnPropertyChanged("PSCategory1");
            }
        }

        public ObservableCollection<ContentModel> PSCategory2
        {
            get
            {
                return psCategory2 = new ObservableCollection<ContentModel>(pandRepository.GetCategoryContent("PSC02".Trim()));
            }
            set
            {
                psCategory2 = value;
                OnPropertyChanged("PSCategory2");
            }
        }

        public ObservableCollection<TaxModel> Tax
        {
            get
            {
                return tax = new ObservableCollection<TaxModel>(pandRepository.GetTaxes());
            }
            set
            {
                tax = value;
                OnPropertyChanged("Tax");
            }
        }

        public int ProductsCount
        {
            get
            {
                return productCount;
            }
            set
            {
                productCount = value;
                OnPropertyChanged("ProductsCount");
            }
        }

        public int ServicesCount
        {
            get
            {
                return servicesCount;
            }
            set
            {
                servicesCount = value;
                OnPropertyChanged("ServicesCount");
            }
        }

        public int ActivePandS
        {
            get
            {
                return activePandS;
            }
            set
            {
                activePandS = value;
                OnPropertyChanged("ActivePandS");
            }
        }

        public int InActivePandS
        {
            get
            {
                return inactivePandS;
            }
            set
            {
                inactivePandS = value;
                OnPropertyChanged("InActivePandS");
            }
        }

        public int TotalPandS
        {
            get
            {
                return totalPandS;
            }
            set
            {
                totalPandS = value;
                OnPropertyChanged("TotalPandS");
            }
        }

        public bool IsNew
        {
            get
            {
                return isNew;
            }
            set
            {
                isNew = value;
                OnPropertyChanged("IsNew");
            }
        }

        public string TaxName
        {
            get
            {
                return taxName;
            }
            set
            {
                taxName = value;
                OnPropertyChanged("TaxName");
            }
        }
        public TaxModel SelectedTaxID
        {
            get
            {
                return selectedTaxID;
            }
            set
            {
                selectedTaxID = value;
                OnPropertyChanged("SelectedTaxID");
            }
        }

        public ContentModel SelectedPSCategory1
        {
            get
            {
                return selectedPSCategory1;
            }
            set
            {
                selectedPSCategory1 = value;
                OnPropertyChanged("SelectedPSCategory1");
            }
        }
        public ContentModel SelectedPSCategory2
        {
            get
            {
                return selectedPSCategory2;
            }
            set
            {
                selectedPSCategory2 = value;
                OnPropertyChanged("SelectedPSCategory2");
            }
        }

        public int? DefaultPSCat1
        {
            get
            {
                return defaultCat1;
            }
            set
            {
                defaultCat1 = value;
                OnPropertyChanged("DefaultPSCat1");
            }
        }
        public int? DefaultPSCat2
        {
            get
            {
                return defaultCat2;
            }
            set
            {
                defaultCat2 = value;
                OnPropertyChanged("DefaultPSCat2");
            }
        }

        public string CurrencyName
        {
            get; set;
        }
        public int? DefaultTaxID
        {
            get
            {
                return defaultTaxId;
            }
            set
            {
                defaultTaxId = value;
                OnPropertyChanged("DefaultTaxID");
            }
        }
        public string PandSErrors
        {
            get
            {
                return pandsErrors;
            }
            set
            {
                pandsErrors = value;
                OnPropertyChanged("PandSErrors");
            }

        }
        
        public string RefreshDate
        {
            get
            {
                return refreshdate;
            }
            set
            {
                refreshdate = value;
                OnPropertyChanged("RefreshDate");
            }
        }
        public void SavePandS()
        {
            // Ask the Model or the DAL to persist me...
        }

        public System.Windows.Visibility VisibilityForLabel
        {
            get
            {
                return visibilityForLabel;
            }
            set
            {
                visibilityForLabel = value;
                OnPropertyChanged("VisibilityForLabel");
            }
        }
        public System.Windows.Visibility VisibilityForTextBox
        {
            get
            {
                return visibilityForTextBox;
            }
            set
            {
                visibilityForTextBox = value;
                OnPropertyChanged("VisibilityForTextBox");
            }
        }

        #endregion

        #region "PandSModel"

        private int id;
        private string psCode;
        private string psName;
        private string psType;
        private bool? isProduct;
        private bool? isService;
        private int? pandsCategory1;
        private int? pandsCategory2;
        private int? taxId;
        private decimal? taxrate;
        private string isInactive;
        private string psDescription;
        private string standardSellPriceBeforeGST="0";
        private string standardCostpriceBeforeGST="0";
        private string standardSellPriceGST="0";
        private string standardSellPriceAfterGST= "0";
        private string standardCostpriceAfterGST = "0";
        private string standardCostPriceGST = "0";
        private string averageSellPriceBeforeGST = "0";
        private string averageCostPriceBeforeGST = "0";
        private string averageSellPriceAfterGST = "0";
        private string averageCostPriceAfterGST = "0";
        private string averageCostPriceGST = "0";
        private string averageSellPriceGST = "0";
        private string lastSoldPriceBeforeGST = "0";
        private string lastSoldPriceAfterGST = "0";
        private string lastPurchasePriceBeforeGST = "0";
        private string lastPurchasePriceAfterGST = "0";
        private string lastSoldPriceGST = "0";
        private string lastPurchasePriceGST = "0";
        private int? minimumQuantity = 0;
        private int? quantityInStock = 0;
        private int? reservedForSalesOrders = 0;
        private int? onPurchaseOrders = 0;
        private int? availableForSale = 0;
        private decimal? stockValue = 0;
        private double totalQuantityInStock = 0;
        private string totalAverageCostPrice;
        private double totalStockValue = 0;
        private int loggedInUserId;
        private int selectedPandSID;
        private byte[] imgSource;
        private BitmapSource _bitmapSource;

        public BitmapSource ButtonSource
        {
            get
            {
                return _bitmapSource;
            }
            set
            {
                _bitmapSource = value;
                OnPropertyChanged("ButtonSource");
            }
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public string PSCode
        {
            get
            {
                return psCode;
            }
            set
            {
                psCode = value;
                OnPropertyChanged("PSCode");
            }
        }
        public string PSName
        {
            get
            {
                return psName;
            }
            set
            {
                psName = value;
                OnPropertyChanged("PSName");
            }
        }
        public string PSType
        {
            get
            {
                return psType;
            }
            set
            {
                if (IsProduct == true)
                {
                    psType = "P";
                }
                else if (IsService == true)
                {
                    psType = "S";
                }
                else
                {
                    psType = value;
                }
                OnPropertyChanged("PSType");
            }
        }


        public bool? IsProduct
        {
            get
            {
                return isProduct;
            }
            set
            {
                isProduct = value;
                // psType = "P";
                OnPropertyChanged("IsProduct");
            }
        }
        public bool? IsService
        {
            get
            {
                return isService;
            }
            set
            {
                isService = value;
                //psType = "S";
                OnPropertyChanged("IsService");
            }
        }
        public int? PandSCategory1
        {
            get
            {
                return pandsCategory1;
            }
            set
            {
                pandsCategory1 = value;
                OnPropertyChanged("PSCategory1");
            }
        }
        public int? PandSCategory2
        {
            get
            {
                return pandsCategory2;
            }
            set
            {
                pandsCategory2 = value;
                OnPropertyChanged("PSCategory2");
            }
        }
        public int? TaxID
        {
            get
            {
                return taxId;
            }
            set
            {
                taxId = value;
                OnPropertyChanged("TaxID");
            }
        }

        public decimal? Taxrate
        {
            get
            {
                return taxrate;
            }
            set
            {
                taxrate = value;
                OnPropertyChanged("Rate");
            }
        }

        public string IsInActive
        {
            get
            {
                return isInactive;
            }
            set
            {
                if (isInactive != value)
                {
                    isInactive = value;
                    OnPropertyChanged("IsInActive");
                }

            }
        }
        public string PSDescription
        {
            get
            {
                return psDescription;
            }
            set
            {
                psDescription = value;
                OnPropertyChanged("PSDescription");
            }
        }
        public string StandardSellPriceBeforeGST
        {
            get
            {
                //return standardSellPriceBeforeGST;
                if (standardSellPriceBeforeGST == null )
                    return this.standardSellPriceBeforeGST;
                else
                {
                    if (standardSellPriceBeforeGST != "")
                    {
                        var balance = standardSellPriceBeforeGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.standardSellPriceBeforeGST;
                }
            }
            set
            {
                standardSellPriceBeforeGST = value;
                OnPropertyChanged("StandardSellPriceBeforeGST");
            }
        }
        public string StandardCostpriceBeforeGST
        {
            get
            {
                //return standardCostpriceBeforeGST;
                if (standardCostpriceBeforeGST == null)
                    return this.standardCostpriceBeforeGST;
                else
                {
                    if (standardCostpriceBeforeGST != "")
                    {
                        var balance = standardCostpriceBeforeGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.standardCostpriceBeforeGST;
                }
            }
            set
            {
                standardCostpriceBeforeGST = value;
                OnPropertyChanged("StandardCostpriceBeforeGST");
            }
        }

        public string StandardSellPriceAfterGST
        {
            get
            {
                //return standardSellPriceAfterGST;
                if (standardSellPriceAfterGST == null)
                    return this.standardSellPriceAfterGST;
                else
                {
                    if (standardSellPriceAfterGST != "")
                    {
                        var balance = standardSellPriceAfterGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.standardSellPriceAfterGST;
                }
            }
            set
            {
                standardSellPriceAfterGST = value;
                OnPropertyChanged("StandardSellPriceAfterGST");
            }
        }
        public string StandardCostpriceAfterGST
        {
            get
            {
                //return standardCostpriceAfterGST;
                if (standardCostpriceAfterGST == null)
                    return this.standardCostpriceAfterGST;
                else
                {
                    if (standardCostpriceAfterGST != "")
                    {
                        var balance = standardCostpriceAfterGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.standardCostpriceAfterGST;
                }
            }
            set
            {
                standardCostpriceAfterGST = value;
                OnPropertyChanged("StandardCostpriceAfterGST");
            }
        }

        public string AverageSellPriceBeforeGST
        {
            get
            {
                //return averageSellPriceBeforeGST;
                if (averageSellPriceBeforeGST == null)
                    return this.averageSellPriceBeforeGST;
                else
                {
                    if (averageSellPriceBeforeGST != "")
                    {
                        var balance = averageSellPriceBeforeGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.averageSellPriceBeforeGST;
                }
            }
            set
            {
                averageSellPriceBeforeGST = value;
                OnPropertyChanged("AverageSellPriceBeforeGST");
            }
        }

        public string StandardSellPriceGST
        {
            get
            {
                //return averageSellPriceBeforeGST;
                if (standardSellPriceGST == null)
                    return this.standardSellPriceGST;
                else
                {
                    if (standardSellPriceGST != "")
                    {
                        var balance = standardSellPriceGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.standardSellPriceGST;
                }
            }
            set
            {
                standardSellPriceGST = value;
                OnPropertyChanged("StandardSellPriceGST");
            }
        }

        public string StandardCostPriceGST
        {
            get
            {
                //return averageSellPriceBeforeGST;
                if (standardCostPriceGST == null)
                    return this.standardCostPriceGST;
                else
                {
                    if (standardCostPriceGST != "")
                    {
                        var balance = standardCostPriceGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.standardCostPriceGST;
                }
            }
            set
            {
                standardCostPriceGST = value;
                OnPropertyChanged("StandardCostPriceGST");
            }
        }

        public  string AverageCostPriceGST
        {
            get
            {
                //return averageSellPriceBeforeGST;
                if (averageCostPriceGST == null)
                    return this.averageCostPriceGST;
                else
                {
                    if (averageCostPriceGST != "")
                    {
                        var balance = averageCostPriceGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.averageCostPriceGST;
                }
            }
            set
            {
                averageCostPriceGST = value;
                OnPropertyChanged("AverageCostPriceGST");
            }
        }
        public string AverageSellPriceGST
        {
            get
            {
                //return averageSellPriceBeforeGST;
                if (averageSellPriceGST == null)
                    return this.averageSellPriceGST;
                else
                {
                    if (averageSellPriceGST != "")
                    {
                        var balance = averageSellPriceGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.averageSellPriceGST;
                }
            }
            set
            {
                averageSellPriceGST = value;
                OnPropertyChanged("AverageSellPriceGST");
            }
        }

        public string LastSoldPriceGST
        {
            get
            {
                //return averageSellPriceBeforeGST;
                if (lastSoldPriceGST == null)
                    return this.lastSoldPriceGST;
                else
                {
                    if (lastSoldPriceGST != "")
                    {
                        var balance = lastSoldPriceGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.lastSoldPriceGST;
                }
            }
            set
            {
                lastSoldPriceGST = value;
                OnPropertyChanged("LastSoldPriceGST");
            }
        }
        public string LastPurchasePriceGST
        {
            get
            {
               
                if (lastPurchasePriceGST == null)
                    return this.lastPurchasePriceGST;
                else
                {
                    if (lastPurchasePriceGST != "")
                    {
                        var balance = lastPurchasePriceGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.lastPurchasePriceGST;
                }
            }
            set
            {
                lastPurchasePriceGST = value;
                OnPropertyChanged("LastPurchasePriceGST");
            }
        }

        public int SelectedPandSID
        {
            get
            {
                return selectedPandSID;
            }
            set
            {
                selectedPandSID = value;
                OnPropertyChanged("SelectedPandSID");
            }
        }

        public string AverageSellPriceAfterGST
        {
            get
            {
                // return lastPurchasePriceBeforeGST;
                if (averageSellPriceAfterGST == null)
                    return this.averageSellPriceAfterGST;
                else
                {
                    if (averageSellPriceAfterGST != "")
                    {
                        var balance = averageSellPriceAfterGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.averageSellPriceAfterGST;
                }
            }
            set
            {
                averageSellPriceAfterGST = value;
                OnPropertyChanged("AverageSellPriceAfterGST");
            }
           
        }
        public string AverageCostPriceBeforeGST
        {
            get
            {
                //return averageCostPriceAfterGST;
                if (averageCostPriceBeforeGST == null)
                    return this.averageCostPriceBeforeGST;
                else
                {
                    if (averageCostPriceBeforeGST != "")
                    {
                        var balance = averageCostPriceBeforeGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.averageCostPriceBeforeGST;
                }
            }
            set
            {
                averageCostPriceBeforeGST = value;
                OnPropertyChanged("AverageCostPriceBeforeGST");
            }
           
        }

        public string AverageCostPriceAfterGST
        {
            get
            {
                //return averageCostPriceAfterGST;
                if (averageCostPriceAfterGST == null)
                    return this.averageCostPriceAfterGST;
                else
                {
                    if (averageCostPriceAfterGST != "")
                    {
                        var balance = averageCostPriceAfterGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.averageCostPriceAfterGST;
                }
            }
            set
            {
                averageCostPriceAfterGST = value;
                OnPropertyChanged("AverageCostPriceAfterGST");
            }
        }

        public string LastSoldPriceBeforeGST
        {
            get
            {
                //return lastSoldPriceBeforeGST;
                if (lastSoldPriceBeforeGST == null)
                    return this.lastSoldPriceBeforeGST;
                else
                {
                    if (lastSoldPriceBeforeGST != "")
                    {
                        var balance = lastSoldPriceBeforeGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.lastSoldPriceBeforeGST;
                }
            }
            set
            {
                lastSoldPriceBeforeGST = value;
                OnPropertyChanged("LastSoldPriceBeforeGST");
            }
        }

        public string LastSoldPriceAfterGST
        {
            get
            {
                //return lastSoldPriceAfterGST;
                if (lastSoldPriceAfterGST == null)
                    return this.lastSoldPriceAfterGST;
                else
                {
                    if (lastSoldPriceAfterGST != "")
                    {
                        var balance = lastSoldPriceAfterGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.lastSoldPriceAfterGST;
                }
            }
            set
            {
                lastSoldPriceAfterGST = value;
                OnPropertyChanged("LastSoldPriceAfterGST");
            }
        }

        public string LastPurchasePriceBeforeGST
        {
            get
            {
               // return lastPurchasePriceBeforeGST;
                if (lastPurchasePriceBeforeGST == null)
                    return this.lastPurchasePriceBeforeGST;
                else
                {
                    if (lastPurchasePriceBeforeGST != "")
                    {
                        var balance = lastPurchasePriceBeforeGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.lastPurchasePriceBeforeGST;
                }
            }
            set
            {
                lastPurchasePriceBeforeGST = value;
                OnPropertyChanged("LastPurchasePriceBeforeGST");
            }
        }

        public string LastPurchasePriceAfterGST
        {
            get
            {
              //  return lastPurchasePriceAfterGST;
                if (lastPurchasePriceAfterGST == null)
                    return this.lastPurchasePriceAfterGST;
                else
                {
                    if (lastPurchasePriceAfterGST != "")
                    {
                        var balance = lastPurchasePriceAfterGST.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.lastPurchasePriceAfterGST;
                }
            }
            set
            {
                lastPurchasePriceAfterGST = value;
                OnPropertyChanged("LastPurchasePriceAfterGST");
            }
        }

        public int? MinimumQuantity
        {
            get
            {
                return minimumQuantity;
            }
            set
            {
                minimumQuantity = value;
                OnPropertyChanged("MinimumQuantity");
            }
        }
        public int? QuantityInStock
        {
            get
            {
                return quantityInStock;
            }
            set
            {
                quantityInStock = value;
                OnPropertyChanged("QuantityInStock");
            }
        }
        public int? ReservedForSalesOrders
        {
            get
            {
                return reservedForSalesOrders;
            }
            set
            {
                reservedForSalesOrders = value;
                OnPropertyChanged("ReservedForSalesOrders");
            }
        }
        public int? OnPurchaseOrders
        {
            get
            {
                return onPurchaseOrders;
            }
            set
            {
                onPurchaseOrders = value;
                OnPropertyChanged("OnPurchaseOrders");
            }
        }
        public int? AvailableForSale
        {
            get
            {
                return availableForSale;
            }
            set
            {
                availableForSale = value;
                OnPropertyChanged("AvailableForSale");
            }
        }
        public decimal? StockValue
        {
            get
            {
                return stockValue;
            }
            set
            {
                stockValue = value;
                OnPropertyChanged("StockValue");
            }
        }

        public double TotalQuantityInStock
        {
            get
            {
                return totalQuantityInStock;
            }
            set
            {
                totalQuantityInStock = value;
                OnPropertyChanged("TotalQuantityInStock");
            }
        }

        public string TotalAverageCostPrice
        {
            get
            {
                //return totalAverageCostPrice;
                if (totalAverageCostPrice == null)
                    return this.totalAverageCostPrice;
                else
                {
                    if (totalAverageCostPrice != "")
                    {
                        var balance = totalAverageCostPrice.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.totalAverageCostPrice;
                }
            }
            set
            {
                totalAverageCostPrice = value;
                OnPropertyChanged("TotalAverageCostPrice");
            }
        }

        public double TotalStockValue
        {
            get
            {
                return totalStockValue;
            }
            set
            {
                totalStockValue = value;
                OnPropertyChanged("TotalStockValue");
            }
        }

        public int LoggedInUserId
        {
            get
            {
                return loggedInUserId;
            }
            set
            {
                loggedInUserId = value;
                OnPropertyChanged("LoggedInUserId");
            }
        }

        public byte[] ImgSource
        {
            get
            {
                return imgSource;
            }
            set
            {
                imgSource = value;
                OnPropertyChanged("imgSource");
            }
        }

        #endregion
        private void LoadProductsBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;

            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;


            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadProductsBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadProductsBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadProductsBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        public void LoadProductsBackground(object sender, DoWorkEventArgs e)
        {
            //RefreshPandSData();
        }

        /// <summary>
        ///  Occurs when System.ComponentModel.BackgroundWorker.ReportProgress(System.Int32) is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void LoadProductsBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
        }
        private void LoadProductsBackgroundProgressState(object sender, ProgressChangedEventArgs e)
        {
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadProductsBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = null;

        }


        #region "private methods"

        private void CalculateStandardSellPrices(object param)
        {
            try
            {
                if (!string.IsNullOrEmpty(StandardSellPriceBeforeGST))
                {
                    //StandardSellPriceAfterGST = Math.Round(Convert.ToDecimal(StandardSellPriceBeforeGST + Math.Round(Convert.ToDecimal((SelectedTaxID.TaxRate * StandardSellPriceBeforeGST) / 100), decimalPlaces)),decimalPlaces);
                    StandardSellPriceAfterGST = Math.Round(Convert.ToDecimal(StandardSellPriceBeforeGST) + (Convert.ToDecimal(SelectedTaxID.TaxRate) * Convert.ToDecimal(StandardSellPriceBeforeGST) / 100), decimalPlaces).ToString();
                    StandardSellPriceGST= Math.Round((Convert.ToDecimal(SelectedTaxID.TaxRate) * Convert.ToDecimal(StandardSellPriceBeforeGST) / 100), decimalPlaces).ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CalculateStandardCostPrices(object param)
        {
            try
            {
                if (!string.IsNullOrEmpty(StandardCostpriceBeforeGST))
                {
                    StandardCostpriceAfterGST = Math.Round((Convert.ToDecimal(StandardCostpriceBeforeGST) + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * Convert.ToDecimal(StandardCostpriceBeforeGST)) / 100)), decimalPlaces).ToString();
                    StandardCostPriceGST = Math.Round((Convert.ToDecimal(SelectedTaxID.TaxRate) * Convert.ToDecimal(StandardCostpriceBeforeGST) / 100), decimalPlaces).ToString();
                }
                else
                    StandardCostpriceAfterGST = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void CalculateStandardPricesFromRate(object param)
        {
            try
            {
                //StandardSellPriceAfterGST = Math.Round(Convert.ToDecimal(StandardSellPriceBeforeGST + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * Convert.ToDecimal(StandardSellPriceBeforeGST)) / 100)),decimalPlaces);
                //StandardCostpriceAfterGST = Math.Round(Convert.ToDecimal(StandardCostpriceBeforeGST + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * StandardCostpriceBeforeGST) / 100)),decimalPlaces);

                //AverageSellPriceAfterGST= Math.Round(Convert.ToDecimal(AverageSellPriceBeforeGST + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * AverageSellPriceBeforeGST) / 100)),decimalPlaces);
                //  AverageCostPriceAfterGST = Math.Round(Convert.ToDecimal(AverageCostPriceBeforeGST + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * AverageCostPriceBeforeGST) / 100)),decimalPlaces);

                //  LastPurchasePriceAfterGST= Math.Round(Convert.ToDecimal(LastPurchasePriceBeforeGST + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * LastPurchasePriceBeforeGST) / 100)),decimalPlaces);
                //  LastSoldPriceAfterGST= Math.Round(Convert.ToDecimal(LastSoldPriceBeforeGST + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * LastSoldPriceBeforeGST) / 100)),decimalPlaces);

                StandardSellPriceAfterGST = Math.Round((Convert.ToDecimal(StandardSellPriceBeforeGST) + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * Convert.ToDecimal(StandardSellPriceBeforeGST)) / 100)), decimalPlaces).ToString();
                StandardCostpriceAfterGST = Math.Round((Convert.ToDecimal(StandardCostpriceBeforeGST) + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * Convert.ToDecimal(StandardCostpriceBeforeGST)) / 100)), decimalPlaces).ToString();

                StandardSellPriceGST = Math.Round((Convert.ToDecimal(SelectedTaxID.TaxRate) * Convert.ToDecimal(StandardSellPriceBeforeGST) / 100), decimalPlaces).ToString();
                StandardCostPriceGST = Math.Round((Convert.ToDecimal(SelectedTaxID.TaxRate) * Convert.ToDecimal(StandardCostpriceBeforeGST) / 100), decimalPlaces).ToString();

                AverageSellPriceAfterGST = Math.Round((Convert.ToDecimal(AverageSellPriceBeforeGST) + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * Convert.ToDecimal(AverageSellPriceBeforeGST)) / 100)), decimalPlaces).ToString();
                AverageCostPriceAfterGST = Math.Round((Convert.ToDecimal(AverageCostPriceBeforeGST) + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * Convert.ToDecimal(AverageCostPriceBeforeGST)) / 100)), decimalPlaces).ToString();

                AverageCostPriceGST = Utility.CalculatePercentage(Convert.ToDecimal(AverageCostPriceBeforeGST), Taxrate).ToString();
                AverageSellPriceGST = Utility.CalculatePercentage(Convert.ToDecimal(AverageSellPriceBeforeGST), Taxrate).ToString();

                LastPurchasePriceAfterGST = Math.Round((Convert.ToDecimal(LastPurchasePriceBeforeGST) + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * Convert.ToDecimal(LastPurchasePriceBeforeGST)) / 100)), decimalPlaces).ToString();
                LastSoldPriceAfterGST = Math.Round((Convert.ToDecimal(LastSoldPriceBeforeGST) + ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * Convert.ToDecimal(LastSoldPriceBeforeGST)) / 100)), decimalPlaces).ToString().ToString();

                LastPurchasePriceGST = Utility.CalculatePercentage(Convert.ToDecimal(LastPurchasePriceBeforeGST), Taxrate).ToString();
                LastSoldPriceGST = Utility.CalculatePercentage(Convert.ToDecimal(LastSoldPriceBeforeGST), Taxrate).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CalculateStandardCostPriceFromAfterTax(object param)
        {
            try
            {

                StandardCostpriceBeforeGST = Math.Round((Convert.ToDecimal(StandardCostpriceAfterGST) - ((Math.Round(Convert.ToDecimal(SelectedTaxID.TaxRate), decimalPlaces) * Convert.ToDecimal(StandardCostpriceAfterGST) / 100))), decimalPlaces).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CalculateStandardSellPriceFromAfterTax(object param)
        {
            try
            {

                //StandardSellPriceBeforeGST = Math.Round(Convert.ToDecimal(StandardSellPriceAfterGST - Math.Round(Convert.ToDecimal((SelectedTaxID.TaxRate * StandardSellPriceAfterGST) / 100), decimalPlaces)), decimalPlaces);
                StandardSellPriceBeforeGST = Math.Round((Convert.ToDecimal(StandardSellPriceAfterGST) - Math.Round((Convert.ToDecimal(SelectedTaxID.TaxRate) * Convert.ToDecimal(StandardSellPriceAfterGST) / 100), decimalPlaces)), decimalPlaces).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnProductsChecked(object param)
        {
            if (IsNew == true)
            {
                VisibilityForLabel = System.Windows.Visibility.Collapsed;
                VisibilityForTextBox = System.Windows.Visibility.Visible;
            }
            else
            {
                if (PSType == "S")
                {
                    PandSErrors = "Cannot change PS Type";
                }
                else
                {
                    PandSErrors = string.Empty;
                }
            }

        }

        private void OnServiceChecked(object param)
        {
            if (IsNew == true)
            {
                VisibilityForTextBox = System.Windows.Visibility.Collapsed;
                VisibilityForLabel = System.Windows.Visibility.Visible;

            }
            else
            {
                if (PSType == "P")
                {
                    PandSErrors = "Cannot change PS Type";
                }
                else
                {
                    PandSErrors = string.Empty;
                }
            }

        }

        private void SavePandS(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save?", "Save Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                var pands = new PandSDetailsModel();

                if (PSCode != null)
                {
                    if (PSCode.Trim() != string.Empty)
                    {
                        pands.PSCode = PSCode.Trim();
                    }
                    else
                    {
                        PandSErrors = "Please enter PS Code";
                        Mouse.OverrideCursor = null;
                        return;
                    }
                }

                if (PSName != null)
                {
                    if (PSName.Trim() != string.Empty)
                    {
                        pands.PSName = PSName.Trim();
                    }
                    else
                    {
                        PandSErrors = "Please enter PS Name";
                        Mouse.OverrideCursor = null;
                        return;
                    }
                }

                pands.PSType = PSType;

                if ((IsService == null || IsService == false) && (IsProduct == false || IsProduct == null))
                {
                    PandSErrors = "Please select PSType";
                    Mouse.OverrideCursor = null;
                    return;
                }
                else
                {
                    if (IsService == true)
                    {
                        PSType = "S";
                    }
                    else if (IsProduct == true)
                    {
                        PSType = "P";
                    }
                }

                //if(!string.IsNullOrEmpty(StandardSellPriceBeforeGST))
                //{
                //    if(Convert.ToDecimal(StandardSellPriceBeforeGST)==0)
                //    {
                //        PandSErrors = "Price should not be zero";
                //        Mouse.OverrideCursor = null;
                //        return;
                //    }
                //}

                //if (!string.IsNullOrEmpty(StandardCostpriceBeforeGST))
                //{
                //    if (Convert.ToDecimal(StandardCostpriceBeforeGST) == 0)
                //    {
                //        PandSErrors = "Price should not be zero";
                //        Mouse.OverrideCursor = null;
                //        return;
                //    }
                //}

                pands.PSType = PSType;

                pands.TaxRate = SelectedTaxID.TaxRate;
                pands.TaxID = SelectedTaxID.TaxID;
                pands.PSCategory1 = DefaultPSCat1;
                pands.PSCategory2 = DefaultPSCat2;
                pands.PSDescription = PSDescription;
                pands.StandardSellPriceBeforeGST = this.StandardSellPriceBeforeGST.ToString();
                pands.StandardSellPriceAfterGST = this.StandardSellPriceAfterGST;
                pands.StandardCostpriceBeforeGST = this.StandardCostpriceBeforeGST.ToString();
                pands.StandardCostpriceAfterGST = this.StandardCostpriceAfterGST.ToString();
                pands.AverageSellPriceBeforeGST = this.AverageSellPriceBeforeGST.ToString();
                pands.AverageSellPriceAfterGST = this.AverageSellPriceAfterGST;
                pands.AverageCostPriceBeforeGST = this.AverageCostPriceBeforeGST;
                pands.AverageCostPriceAfterGST = this.averageCostPriceAfterGST;
                pands.LastSoldPriceBeforeGST = this.LastSoldPriceBeforeGST;
                pands.LastSoldPriceAfterGST = this.LastSoldPriceAfterGST;
                pands.LastPurchasePriceBeforeGST = this.LastPurchasePriceBeforeGST;
                pands.LastPurchasePriceAfterGST = this.LastPurchasePriceAfterGST;

                if (IsService == true)
                {
                    pands.MinimumQuantity = 0;
                    pands.QuantityInStock = 0;
                    pands.ReservedForSalesOrders = 0;
                    pands.OnPurchaseOrders = 0;
                    pands.StockValue = 0;
                }
                else
                {
                    pands.MinimumQuantity = this.MinimumQuantity;
                    pands.QuantityInStock = this.QuantityInStock;
                    pands.ReservedForSalesOrders = this.ReservedForSalesOrders;
                    pands.OnPurchaseOrders = this.OnPurchaseOrders;
                    pands.StockValue = this.StockValue;
                }
                pands.LoggedinUserID = this.LoggedInUserId;
                pands.IsInActive = this.IsInActive;
                pands.ImgSource = this.ImgSource;

                var psCode = pandRepository.GetAllPandS();
                
                if (IsNew == true)
                {
                    var ps = psCode.Where(e => e.PSCode == PSCode).Count();
                    if (ps == 0)
                    {
                       int id= pandRepository.SavePandS(pands);
                        if(id!=0)
                        {
                            SelectedPandSID = id;
                        }
                        IsNew = false;
                       // RefreshPandSData();
                        Mouse.OverrideCursor = null;
                        // GetNewPandS();
                    }
                    else
                    {
                        PandSErrors = "P&S Code should be unique";
                    }
                }
                else
                {
                    pands.ID = SelectedPandSID;
                    var psType = psCode.Where(e => e.ID == SelectedPandSID).Select(e => e.PSType).SingleOrDefault();

                    if (psType != null)
                    {
                        if (psType == "P" && IsService == true)
                        {
                            PandSErrors = "Cannot change PS Type";
                            Mouse.OverrideCursor = null;
                            return;
                        }
                        else if (psType == "S" && IsProduct == true)
                        {
                            PandSErrors = "Cannot change PS Type";
                            Mouse.OverrideCursor = null;
                            return;
                        }
                        else
                        {
                            PandSErrors = string.Empty;
                        }
                    }

                    var psd = psCode.Where(e => e.PSCode == PSCode.Trim() && e.ID != SelectedPandSID).Count();
                    if (psd == 0)
                    {
                        pandRepository.UpdatePandS(pands);
                        IsNew = false;
                        var psData = pandRepository.GetAllPandS();
                        if (psData != null)
                        {
                            //Counting no of Products
                            ProductsCount = psData.Where(p => p.PSType == "P").Count();
                            //Counting no of Services
                            ServicesCount = psData.Where(p => p.PSType == "S").Count();

                            //Counting total no of Products and Services
                            TotalPandS = psData.Count();
                            //Counting total no of active Products and Services
                            ActivePandS = psData.Where(e => e.IsInActive == null || e.IsInActive != "Y").Count();
                            //Counting total no of Inactive Products and Services
                            InActivePandS = TotalPandS - ActivePandS;

                            //List<PandSDetailsModel> lstPandSModel = new List<PandSDetailsModel>(pandRepository.GetAllPandS());
                            ////List<PandS> lstPandS = new List<PandS>();

                            //if (lstPandSModel.Count > 0)
                            //{
                            //    ProductAndServices = lstPandSModel;
                            //}
                            //else
                            //{
                            //    ProductAndServices = new List<PandSDetailsModel>();
                            //}
                        }
                        Mouse.OverrideCursor = null;
                        //  GetNewPandS();
                    }
                    else
                    {
                        PandSErrors = "P&S Code should be unique";

                    }
                }


            }
            Mouse.OverrideCursor = null;
        }

        private void DeletePandS(object param)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                var model = new PandSDetailsModel();
                model.ID = SelectedPandSID;
                model.PSCode = this.PSCode;
                model.PSName = this.PSName;
                model.LoggedinUserID = this.LoggedInUserId;

                pandRepository.DeletePandS(model);
                RefreshPandSData();
                Mouse.OverrideCursor = null;
            }
        }

        private bool CanDuplicate(object param)
        {
            if (IsNew == false && !String.IsNullOrEmpty(PSCode) && !String.IsNullOrEmpty(PSName) &&
             !String.IsNullOrEmpty(Convert.ToString(StandardSellPriceBeforeGST))
             && !String.IsNullOrEmpty(Convert.ToString(StandardCostpriceBeforeGST)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //added on sanvir's review dated: 05/05/2017
        private bool CanNew(object param)
        {
            if(IsNew==false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CanSave(object param)
        {
            if (!String.IsNullOrEmpty(PSCode) && !String.IsNullOrEmpty(PSName)
               && !String.IsNullOrEmpty(Convert.ToString(StandardSellPriceBeforeGST))
                && !String.IsNullOrEmpty(Convert.ToString(StandardCostpriceBeforeGST)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CanDelete(object param)
        {
            if (IsNew == false && !String.IsNullOrEmpty(PSCode) && !String.IsNullOrEmpty(PSName) &&
              !String.IsNullOrEmpty(Convert.ToString(StandardSellPriceBeforeGST))
              && !String.IsNullOrEmpty(Convert.ToString(StandardCostpriceBeforeGST)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnNewPandS(object param)
        {
            isNew = true;
            GetNewPandS();
        }

        private void OnPrevPandS(object param)
        {
          
            var current = ProductAndServices.FirstOrDefault(x => x.ID == SelectedPandSID);
            
            int index = ProductAndServices.IndexOf(current);

            if (index > 0)
            {
                var next = ProductAndServices.ElementAt(index - 1);
                this.SelectedPandSID = next.ID;
            }
        }

        private bool CanPrev(object param)
        {
            var current = ProductAndServices.FirstOrDefault(x => x.ID == SelectedPandSID);

            int index = ProductAndServices.IndexOf(current);

            if (index > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnNextPandS(object param)
        {
            var current = ProductAndServices.FirstOrDefault(x => x.ID == SelectedPandSID);

            int index = ProductAndServices.IndexOf(current);

            if (index < ProductAndServices.Count - 1)
            {
                var next = ProductAndServices.ElementAt(index + 1);
                this.SelectedPandSID = next.ID;

            }
        }

        private bool CanNext(object param)
        {
            var current = ProductAndServices.FirstOrDefault(x => x.ID == SelectedPandSID);

            int index = ProductAndServices.IndexOf(current);

            if (index < ProductAndServices.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void SetPandSData(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            GetPandSData();
            PandSErrors = string.Empty;
            Mouse.OverrideCursor = null;
        }

        public void SetPandSPicture(byte[] photo)
        {
            this.ImgSource = photo;
            if (ImgSource != null && ImgSource.Length > 0)
            {
                System.Drawing.Bitmap imageBitMap = BytesToBitmap(ImgSource);
                this.ButtonSource = BitmapConversion.BitmapToBitmapSource(imageBitMap);

            }
            //else
            //{ 

            //    System.Drawing.Bitmap imageBitMap = BytesToBitmap(ImgSource);
            //    this.ButtonSource = BitmapConversion.BitmapToBitmapSource(imageBitMap);

            //}
        }

        public static Bitmap BytesToBitmap(byte[] byteArray)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArray))
            {
                Bitmap img = (Bitmap)Image.FromStream(ms);
                return img;
            }
        }
        private void RefreshPandSData()
        {
            #region "To display default tax name from Tax Code & rate"
            var data = pandRepository.GetTaxes().FirstOrDefault();
            if (data != null)
            {
                TaxName = data.TaxName;
            }
            else
            {
                TaxName = "GST";  //default 
            }
            #endregion

            #region displaying default selected PS Category 1
            var cat1 = pandRepository.GetCategoryContent("PSC01".Trim()).Where(c => c.IsSelected == true).Select(c => c.ContentID).FirstOrDefault();
            if (cat1 != 0)
            {
                this.DefaultPSCat1 = cat1;
            }
            #endregion

            #region displaying default selected PS Category2

            var cat2 = pandRepository.GetCategoryContent("PSC02".Trim()).Where(c => c.IsSelected == true).Select(c => c.ContentID).SingleOrDefault();
            if (cat2 != 0)
            {
                this.DefaultPSCat2 = cat2;
            }
            #endregion

            #region displaying  default selected tax

            var defaultTax = pandRepository.GetTaxes().Where(t => t.IsDefault == true).Select(c => c.TaxID).SingleOrDefault();
            if (defaultTax != 0)
            {
                this.DefaultTaxID = defaultTax;
            }
            #endregion

            #region "Displaying Counts of P and S"

            var pands = pandRepository.GetAllPandS();
            if (pands != null)
            {
                //Counting no of Products
                ProductsCount = pands.Where(p => p.PSType == "P").Count();
                //Counting no of Services
                ServicesCount = pands.Where(p => p.PSType == "S").Count();

                //Counting total no of Products and Services
                TotalPandS = pands.Count();
                //Counting total no of active Products and Services
                ActivePandS = pands.Where(e => e.IsInActive == null || e.IsInActive != "Y").Count();
                //Counting total no of Inactive Products and Services
                InActivePandS = TotalPandS - ActivePandS;
            }

            if (pands.Count() == 0)
            {
                GetNewPandS();
            }

            #endregion

            GetStockPriceAndValue();

            #region getting Options details

            string dateFormat = string.Empty;
            var lstOptions = pandRepository.GetOptionDetails();
            if (lstOptions != null)
            {
                CurrencyName = lstOptions.CurrencyCode;
             
                string format = lstOptions.NumberFormat;
                dateFormat = lstOptions.DateFormat;
                if (format == string.Empty || format == null)
                {
                    format = "en-IN";
                }

            }
            #endregion

            List<PandSDetailsModel> lstPandSModel = new List<PandSDetailsModel>(pandRepository.GetAllPandS());
            //List<PandS> lstPandS = new List<PandS>();

            if (lstPandSModel.Count > 0)
            {
                ProductAndServices = lstPandSModel;
            }
            else
            {
                ProductAndServices = new List<PandSDetailsModel>();
            }
            if (lstPandSModel.Count > 0)
            {
                var refresh = ProductAndServices.Where(e => e.PSCode == SharedValues.getValue||e.PSName==SharedValues.getValue).SingleOrDefault();
                if (refresh != null)
                {
                    SelectedPandSID = refresh.ID;
                    DateTime tmpDate = DateTime.Parse(Convert.ToString(refresh.RefreshDate));
                    if (dateFormat != string.Empty || dateFormat != null)
                    {
                        RefreshDate = tmpDate.ToString(dateFormat);
                    }
                    else
                    {
                        RefreshDate = tmpDate.ToShortDateString();
                    }
                }
                else
                {
                    SelectedPandSID = ProductAndServices.FirstOrDefault().ID;
                    RefreshDate = Convert.ToString((Convert.ToDateTime(ProductAndServices.Where(e => e.ID == SelectedPandSID).Select(e => e.RefreshDate).SingleOrDefault())));
                    DateTime tmpDate = DateTime.Parse(RefreshDate);
                    if (dateFormat != string.Empty || dateFormat != null)
                    {
                        RefreshDate = tmpDate.ToString(dateFormat);
                    }
                    else
                    {
                        RefreshDate = tmpDate.ToShortDateString();
                    }
                }
            }

        }

        private void GetStockPriceAndValue()
        {
            #region getting Last Purchase Invoice Price and Average Purchase Price

            var lstPurchasePrice = pandRepository.GetPurchaseInvoiceDetails(SelectedPandSID);
            if (lstPurchasePrice.Count > 0)
            {
                //getting last Purchase invoice done for P & S 
                var price = lstPurchasePrice.OrderByDescending(e => e.InvoiceDate).Take(1).SingleOrDefault();
                if (price != null)
                {
                    LastPurchasePriceBeforeGST = price.Price.ToString();
                    if (!string.IsNullOrEmpty(LastPurchasePriceBeforeGST))
                    {
                        LastPurchasePriceAfterGST = Convert.ToString(Convert.ToDecimal(LastPurchasePriceBeforeGST) + Utility.CalculatePercentage(Convert.ToDecimal(LastPurchasePriceBeforeGST), Taxrate));
                        LastPurchasePriceGST = Utility.CalculatePercentage(Convert.ToDecimal(LastPurchasePriceBeforeGST), Taxrate).ToString();
                    }
                    else
                    {
                        LastPurchasePriceAfterGST = "0";
                        LastPurchasePriceGST = "0";
                    }
                }
                else
                {
                    LastPurchasePriceBeforeGST = "0";
                    LastPurchasePriceAfterGST = "0";
                    LastPurchasePriceGST = "0";
                }

                int totalCount = lstPurchasePrice.Count();
                decimal? sumOfPrice = lstPurchasePrice.Sum(e => e.Price);

                //calculating avg price from purchase invoices
                if (totalCount != 0 && sumOfPrice != null)
                {

                    AverageCostPriceBeforeGST = Utility.CalculateAverage(sumOfPrice, totalCount).ToString();
                    if (!string.IsNullOrEmpty(AverageCostPriceBeforeGST))
                    {
                        AverageCostPriceAfterGST = Convert.ToString(Convert.ToDecimal(AverageCostPriceBeforeGST) + Utility.CalculatePercentage(Convert.ToDecimal(AverageCostPriceBeforeGST), Taxrate));
                        AverageCostPriceGST = Utility.CalculatePercentage(Convert.ToDecimal(AverageCostPriceBeforeGST), Taxrate).ToString();
                        TotalAverageCostPrice = AverageCostPriceBeforeGST;
                    }
                    else
                    {
                        AverageCostPriceAfterGST = "0";
                        AverageCostPriceGST = "0";
                    }
                }
                else
                {
                    AverageCostPriceBeforeGST = "0";
                    AverageCostPriceAfterGST = "0";
                    AverageCostPriceGST = "0";
                    TotalAverageCostPrice = StandardCostpriceBeforeGST;
                }

                //calculating Quantity in stock added on purchase invoice
                var quantity = lstPurchasePrice.Sum(p => p.Quantity);
                if (quantity != null)
                {
                    QuantityInStock = QuantityInStock + quantity;
                    OnPurchaseOrders = OnPurchaseOrders + quantity;

                }

            }
            else
            {
                LastPurchasePriceBeforeGST = "0";
                LastPurchasePriceAfterGST = "0";
                LastPurchasePriceGST = "0";

                AverageCostPriceBeforeGST = "0";
                AverageCostPriceAfterGST = "0";
                AverageCostPriceGST = "0";
                if (!string.IsNullOrEmpty(StandardCostpriceBeforeGST))
                    TotalAverageCostPrice = Convert.ToString(StandardCostpriceBeforeGST);
            }

            #endregion

            #region getting Last Sold Price and average sell price

            var lstSalesPrice = pandRepository.GetSalesInvoiceDetails(SelectedPandSID);
            if (lstSalesPrice.Count() > 0)
            {
                //getting last Sales invoice done for P & S 
                var salePrice = lstSalesPrice.OrderByDescending(e => e.InvoiceDate).Take(1).SingleOrDefault();
                if (salePrice != null)
                {
                    LastSoldPriceBeforeGST = salePrice.Price.ToString();
                    if (!string.IsNullOrEmpty(LastSoldPriceBeforeGST))
                    {
                        LastSoldPriceAfterGST = Convert.ToString(Convert.ToDecimal(LastSoldPriceBeforeGST) + Utility.CalculatePercentage(Convert.ToDecimal(LastSoldPriceBeforeGST), Taxrate));
                        LastSoldPriceGST = Utility.CalculatePercentage(Convert.ToDecimal(LastSoldPriceBeforeGST), Taxrate).ToString();
                    }
                    else
                    {
                        LastSoldPriceAfterGST = "0";
                        LastSoldPriceGST = "0";
                    }
                }
                else
                {
                    LastSoldPriceBeforeGST = "0";
                    LastSoldPriceAfterGST = "0";
                    LastSoldPriceGST = "0";
                }

                //calculating avg price from sales invoices
                int totalCount = lstSalesPrice.Count();
                decimal? sumOfPrice = lstSalesPrice.Sum(e => e.Price);
                if (totalCount != 0 && sumOfPrice != null)
                {
                    AverageSellPriceBeforeGST = Utility.CalculateAverage(sumOfPrice, totalCount).ToString();
                    if (!string.IsNullOrEmpty(AverageSellPriceBeforeGST))
                    {
                        AverageSellPriceAfterGST = Convert.ToString(Convert.ToDecimal(AverageSellPriceBeforeGST) + Utility.CalculatePercentage(Convert.ToDecimal(AverageSellPriceBeforeGST), Taxrate));
                        AverageSellPriceGST = Utility.CalculatePercentage(Convert.ToDecimal(AverageSellPriceBeforeGST), Taxrate).ToString();
                    }
                    else
                    {
                        AverageSellPriceAfterGST = "0";
                        AverageSellPriceGST = "0";
                    }
                }
                else
                {
                    AverageSellPriceBeforeGST = "0";
                    AverageSellPriceAfterGST = "0";
                    AverageSellPriceGST = "0";
                }

                //calculating Quantity in stock added on Sales invoice
                var quantity = lstSalesPrice.Sum(p => p.Quantity);
                if (quantity != null)
                {
                    QuantityInStock = quantity - QuantityInStock;
                    ReservedForSalesOrders = ReservedForSalesOrders + quantity;
                }

            }
            else
            {
                LastSoldPriceBeforeGST = "0";
                LastSoldPriceAfterGST = "0";
                LastSoldPriceGST = "0";

                AverageSellPriceBeforeGST = "0";
                AverageSellPriceAfterGST = "0";
                AverageSellPriceGST = "0";
            }

            #endregion

            #region Calculating Available for Sale
            if (ReservedForSalesOrders != null)
            {
                AvailableForSale = QuantityInStock - ReservedForSalesOrders;
            }
            #endregion

        }

        private void GetRefreshData(object param)
        {
            if (SelectedPandSID != 0)
            {
                pandRepository.UpdateRefreshData(SelectedPandSID);
            }
        }

        private void GetDuplicate(object param)
        {
            PSCode = string.Empty;
            //this.StandardSellPriceBeforeGST = "0";
            //this.StandardSellPriceAfterGST = "0";
            //this.StandardCostpriceBeforeGST = "0";
            //this.StandardCostpriceAfterGST = "0";
            //this.AverageSellPriceBeforeGST = "0";
            //this.AverageSellPriceAfterGST = "0";
            //this.AverageCostPriceBeforeGST = "0";
            //this.averageCostPriceAfterGST = "0";
            //this.LastSoldPriceBeforeGST = "0";
            //this.LastSoldPriceAfterGST = "0";
            //this.LastPurchasePriceBeforeGST = "0";
            //this.LastPurchasePriceAfterGST = "0";
            //this.ImgSource = Default_photo_aray;
            this.MinimumQuantity = 0;
            this.QuantityInStock = 0;
            this.ReservedForSalesOrders = 0;
            this.OnPurchaseOrders = 0;
            this.StockValue = 0;
            this.IsInActive = "N";
            this.TotalQuantityInStock = 0;
            this.TotalAverageCostPrice = "0";
            this.TotalStockValue = 0;

            SelectedPandSID = 0;
            PandSErrors = string.Empty;
        }

        private void GetPandSData()
        {
            int decimalplaces = 0;
            if (ProductAndServices != null)
            {
                var current = pandRepository.GetAllPandS().FirstOrDefault(x => x.ID == SelectedPandSID);
                if (current != null)
                {
                    var lstOptions = pandRepository.GetOptionDetails();
                    if (lstOptions != null)
                    {
                        decimalplaces = lstOptions.DecimalPlaces;
                        decimalPlaces = lstOptions.DecimalPlaces;
                    }

                    PSCode = current.PSCode;
                    PSName = current.PSName;
                    DefaultPSCat1 = current.PSCategory1;
                    DefaultPSCat2 = current.PSCategory2;
                    Tax = new ObservableCollection<TaxModel>(pandRepository.GetTaxes());
                    Taxrate = current.TaxRate;
                    var taxExists = Tax.Where(e => e.TaxID == current.TaxID).FirstOrDefault();
                    if (taxExists != null)
                    {
                        DefaultTaxID = current.TaxID;
                    }
                    else
                    {
                        var tax = Tax.FirstOrDefault();
                        if(tax!=null)
                        {
                            DefaultTaxID = tax.TaxID;
                        }
                    }
                    
                    //PSType = current.PSType;
                    if (current.PSType == "P")
                    {
                        PSType = "P";
                        IsProduct = true;
                        VisibilityForTextBox = System.Windows.Visibility.Visible;
                        VisibilityForLabel = System.Windows.Visibility.Collapsed;
                    }
                    else
                    {
                        IsProduct = false;
                    }
                    if (current.PSType == "S")
                    {
                        PSType = "S";
                        IsService = true;
                        VisibilityForTextBox = System.Windows.Visibility.Collapsed;
                        VisibilityForLabel = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        IsService = false;
                    }
                    
                    PSDescription = current.PSDescription;
                    IsInActive = current.IsInActive;
                   
                    MinimumQuantity = current.MinimumQuantity;
                    QuantityInStock = current.QuantityInStock;
                    ReservedForSalesOrders = current.ReservedForSalesOrders;
                    OnPurchaseOrders = current.OnPurchaseOrders;
                    
                    if (current.ImgSource != null)
                        ImgSource = current.ImgSource;
                    else
                        ImgSource = Default_photo_aray;

                    GetStockPriceAndValue();
                    StandardSellPriceBeforeGST = current.StandardSellPriceBeforeGST;
                    StandardSellPriceAfterGST = Math.Round(Convert.ToDecimal(current.StandardSellPriceAfterGST), decimalplaces).ToString();
                    StandardCostpriceBeforeGST = Math.Round(Convert.ToDecimal(current.StandardCostpriceBeforeGST), decimalplaces).ToString();
                    StandardCostpriceAfterGST = Math.Round(Convert.ToDecimal(current.StandardCostpriceAfterGST), decimalplaces).ToString();
                    //AverageSellPriceBeforeGST = Math.Round(Convert.ToDecimal(current.AverageSellPriceBeforeGST), decimalplaces).ToString();
                    //AverageSellPriceAfterGST = Math.Round(Convert.ToDecimal(current.AverageSellPriceAfterGST), decimalplaces).ToString();
                    //AverageCostPriceAfterGST = Math.Round(Convert.ToDecimal(current.AverageCostPriceAfterGST), decimalplaces).ToString();
                    //AverageCostPriceBeforeGST = Math.Round(Convert.ToDecimal(current.AverageCostPriceBeforeGST), decimalplaces).ToString();
                    //LastSoldPriceBeforeGST = Math.Round(Convert.ToDecimal(current.LastSoldPriceBeforeGST), decimalplaces).ToString();
                    //LastSoldPriceAfterGST = Math.Round(Convert.ToDecimal(current.LastSoldPriceAfterGST), decimalplaces).ToString();
                    //LastPurchasePriceBeforeGST = Math.Round(Convert.ToDecimal(current.LastPurchasePriceBeforeGST), decimalplaces).ToString();
                    //LastPurchasePriceAfterGST = Math.Round(Convert.ToDecimal(current.LastPurchasePriceAfterGST), decimalplaces).ToString();
                    if (current.AverageCostPriceAfterGST != null)
                    {
                        StockValue = QuantityInStock * Convert.ToDecimal(current.AverageCostPriceAfterGST);
                    }
                    else
                    {
                        StockValue = QuantityInStock * Convert.ToDecimal(current.StandardCostpriceAfterGST);
                    }
                }
            }
            isNew = false;

        }

        private void GetNewPandS()
        {
            PSCode = string.Empty;
            PSName = string.Empty;
            IsProduct = true;
            IsService = false;

            PSDescription = string.Empty;
            this.StandardSellPriceBeforeGST = "0";
            this.StandardSellPriceAfterGST = "0";
            this.StandardCostpriceBeforeGST = "0";
            this.StandardCostpriceAfterGST = "0";
            this.AverageSellPriceBeforeGST = "0";
            this.AverageSellPriceAfterGST = "0";
            this.AverageCostPriceBeforeGST = "0";
            this.AverageCostPriceAfterGST = "0";
            this.LastSoldPriceBeforeGST = "0";
            this.LastSoldPriceAfterGST = "0";
            this.LastPurchasePriceBeforeGST = "0";
            this.LastPurchasePriceAfterGST = "0";
            this.AvailableForSale = 0;
            this.ImgSource = Default_photo_aray;
            this.MinimumQuantity = 0;
            this.QuantityInStock = 0;
            this.ReservedForSalesOrders = 0;
            this.OnPurchaseOrders = 0;
            this.StockValue = 0;
            this.IsInActive = "N";

            VisibilityForTextBox = System.Windows.Visibility.Visible;
            VisibilityForLabel = System.Windows.Visibility.Collapsed;

            SelectedPandSID = 0;
            PandSErrors = string.Empty;

            IsNew = true;
            this.TotalQuantityInStock = 0;
            this.TotalAverageCostPrice = string.Empty;
            this.TotalStockValue = 0;

            #region displaying default selected PS Category 1
            var cat1 = pandRepository.GetCategoryContent("PSC01".Trim()).Where(c => c.IsSelected == true).Select(c => c.ContentID).FirstOrDefault();
            if (cat1 != 0)
            {
                this.DefaultPSCat1 = cat1;
            }
            #endregion

            #region displaying default selected PS Category2

            var cat2 = pandRepository.GetCategoryContent("PSC02".Trim()).Where(c => c.IsSelected == true).Select(c => c.ContentID).SingleOrDefault();
            if (cat2 != 0)
            {
                this.DefaultPSCat2 = cat2;
            }
            #endregion

            #region displaying  default selected tax
            Tax= new ObservableCollection<TaxModel>(pandRepository.GetTaxes());
            var defaultTax = pandRepository.GetTaxes().Where(t => t.IsDefault == true).Select(c => c.TaxID).SingleOrDefault();
            if (defaultTax != 0)
            {
                this.DefaultTaxID = defaultTax;
            }
            #endregion
        }


        #endregion

    }

}
