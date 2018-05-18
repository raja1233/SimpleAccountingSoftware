
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.ViewModel
{
    using Common;
    using SDN.UI.Entities;
    using Services;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using UI.Entities.Product;

    public class DataGridViewModel:ViewModelBase
    {
        #region "Private members"
        private int? id;
        private int? selectedPSID;
        private string pandSCode;
        private string pandSName;
        private int? systemQty;
        private int? countQty;
        private int? difference;
        private string avgCost;
        private decimal? amount;
        private string amountStr;
        private decimal? adjustedAmount;
        private int? psCat1;
        private int? psCat2;
        // private ObservableCollection<PandSDetailsModel> productAndServices;
        private ObservableCollection<PandSQtyAndStockModel> productAndServices;
        public IPandSDetailsRepository pandsRepository = new PandSDetailsRepository();
        #endregion "End Private Properties"

        #region "Public Properties"

        public int? SelectedPSID
        {
            get
            {
                return selectedPSID;
            }
            set
            {
                if (selectedPSID != value)
                {
                    selectedPSID = value;
                    OnPropertyChanged("SelectedPSID");
                    GetPandSDetails();
                }
            }
        }
        public int? ID
        {

            get { return id; }

            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public string PandSCode
        {
            get
            {
                return pandSCode;
            }
            set
            {
                pandSCode = value;
                OnPropertyChanged("PandSCode");
            }
        }
        public string PandSName
        {
            get
            {
                return pandSName;
            }
            set
            {
                pandSName = value;
                OnPropertyChanged("PandSName");
            }
        }

        public int? SystemQty
        {
            get { return systemQty; }
            set { systemQty = value;
                OnPropertyChanged("SystemQty");
            }
        }
        public int? CountQty
        {
            get { return countQty; }
            set
            {
                countQty = value;
                OnPropertyChanged("CountQty");
                OnAddCountQty();
            }
        }
        public int? Difference
        {
            get
            {
                return difference;
            }
            set
            {
                difference = value;
                OnPropertyChanged("Difference");
            }

        }
        public string AvgCost
        {
            get { return avgCost; }
            set
            {
                avgCost = value;
                OnPropertyChanged("AvgCost");
            }
        }
        public decimal? Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }
        public string AmountStr
        {
            get
            {
                //return _QuotationAmount;
                if (amountStr == null)
                    return this.amountStr;
                else
                {
                    if (amountStr != "")
                    {
                        var balance = amountStr.Replace(",", "");
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
                        return this.amountStr;
                }
            }
            set
            {
                amountStr = value;
                OnPropertyChanged("AmountStr");
            }
        }
        public decimal? AdjustedAmount
        {
           get { return adjustedAmount; }
            set { adjustedAmount = value;
                OnPropertyChanged("AdjustedAmount");
            }
        }
        public int? PSCat1
        {
            get { return psCat1; }
            set { psCat1 = value;
                OnPropertyChanged("PSCat1");
            }
        }
        public int? PSCat2
        {
            get { return psCat2; }
            set
            {
                psCat2 = value;
                OnPropertyChanged("PSCat2");
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
        //        productAndServices = value;
        //        OnPropertyChanged("ProductAndServices");
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
                productAndServices = value;
                OnPropertyChanged("ProductAndServices");
            }
        }
        public DataGridViewModel(IEnumerable<PandSQtyAndStockModel> ProductList)
        {

            if (ProductList == null)
            {
                ProductList = pandsRepository.GetPandSList().Where(e => e.PSType == "P" && e.IsInActive != "Y");
            }

            ProductAndServices = new ObservableCollection<PandSQtyAndStockModel>(ProductList);
            AdjustedAmount = 0;
        }
        //public DataGridViewModel(IEnumerable<PandSDetailsModel> ProductList)
        //{

        //    //if (ProductList == null)
        //    //{
        //        ProductList = pandsRepository.GetAllPandS().Where(e => e.PSType == "P" && e.IsInActive != "Y");
        //    //}

        //    ProductAndServices = new ObservableCollection<PandSDetailsModel>(ProductList);
        //    AdjustedAmount = 0;
        //}

        public void OnAddCountQty()
        {
            Difference = SystemQty - CountQty;
            if(Difference!=null)
            {
                Amount = Convert.ToInt32(Difference) * Convert.ToDecimal(AvgCost);
                AdjustedAmount = AdjustedAmount + Amount;
            }
            
        }

        public void GetPandSDetails()
         {
             if (ProductAndServices != null && this.SelectedPSID != 0)
            {
                var pqDetails = ProductAndServices.Where(p => p.PSID == Convert.ToInt32(this.SelectedPSID)).SingleOrDefault();
                if (pqDetails != null)
                {
                    PandSCode = pqDetails.PSCode;
                    PandSName = pqDetails.PSName;
                     PSCat1 = pqDetails.Category1;
                    PSCat2 = pqDetails.Category2;
                    SystemQty = pqDetails.QtyInStock;
                    CountQty = 0;
                    if (pqDetails.AvgCostPriceBeforeGSTd != null)
                    {
                        if (Math.Round(Convert.ToDecimal(pqDetails.AvgCostPriceBeforeGSTd),0)!=0)
                        {
                            AvgCost =Convert.ToString( pqDetails.AvgCostPriceBeforeGSTd);
                        }
                        else
                        {
                            AvgCost = Convert.ToString(pqDetails.StdPriceBeforeGSTd);
                        }
                    }
                    else
                    {
                        AvgCost = Convert.ToString(pqDetails.StdPriceBeforeGSTd);
                    }
                }
            }
         }
        #endregion "End Private Properties"
    }
}
