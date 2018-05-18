using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    using SDN.Common;
    using System.Globalization;

    public class PandSDetailsModel: ViewModelBase
    {
       // private int id;
        private string psCode;
        private string psName;
        private string psType;
        private int? psCategory1;
        private int? psCategory2;
        private int? taxID;
        private decimal? taxRate;
        //private string incomeAccount;
        //private string costsAccount;
        //private string assetsAccount;
        private string psDescription;
        private string standardSellPriceBeforeGST = "0";
        private string standardCostpriceBeforeGST = "0";
        private string standardSellPriceGST = "0";
        private string standardSellPriceAfterGST = "0";
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
        private int? minimumQuantity;
        private int? quantityInStock;
        private int? reservedForSalesOrders;
        private int? onPurchaseOrders;
        private int? availableForSale;
        private decimal? stockValue;
        private string isInActive;
        private int? loggedinUserID;
        private byte[] imgSource;
        private bool? isRefreshData;
        private DateTime? refreshDate;
        
        public int ID { get; set; }
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
                psType = value;
                OnPropertyChanged("PSType");
            }
        }
        public int? PSCategory1
        {
            get
            {
                return psCategory1;
            }
            set
            {
                psCategory1 = value;
                OnPropertyChanged("PSCategory1");
            }
        }
        public int? PSCategory2
        {
            get
            {
                return psCategory2;
            }
            set
            {
                psCategory2 = value;
                OnPropertyChanged("PSCategory2");
            }
        }

        public int? TaxID
        {
            get
            {
                return taxID;
            }
            set
            {
                taxID = value;
                OnPropertyChanged("TaxID");
            }
        }

        public decimal? TaxRate
        {
            get
            {
                return taxRate;
            }
            set
            {
                taxRate = value;
                OnPropertyChanged("GSTCodeRate");
            }
        }

        public string IsInActive
        {
            get
            {
                return isInActive;
            }
            set
            {
                isInActive = value;
                OnPropertyChanged("IsInactive");
            }
        }

        //public string IncomeAccount
        //{
        //    get
        //    {
        //        return incomeAccount;
        //    }
        //    set
        //    {
        //        incomeAccount = value;
        //        OnPropertyChanged("IncomeAccount");
        //    }
        //}
        //public string CostsAccount
        //{
        //    get
        //    {
        //        return costsAccount;
        //    }
        //    set
        //    {
        //        costsAccount = value;
        //        OnPropertyChanged("CostsAccount");
        //    }
        //}
        //public string AssetsAccount
        //{
        //    get
        //    {
        //        return assetsAccount;
        //    }
        //    set
        //    {
        //        assetsAccount = value;
        //        OnPropertyChanged("AssetsAccount");
        //    }
        //}
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

                if (standardSellPriceBeforeGST == null)
                    return this.standardSellPriceBeforeGST;
                else
                {
                    //var culture = CultureInfo.GetCultureInfo("en-US");
                    //var numberFormat = (NumberFormatInfo)culture.NumberFormat.Clone();
                    //var abc = _AccountOpeningBal.ToString(CultureInfo.CreateSpecificCulture("sv-SE"));
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
               // return standardSellPriceAfterGST;
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
               // return standardCostpriceAfterGST;
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

        public string AverageCostPriceGST
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
        public string AverageSellPriceAfterGST
        {
            get
            {
               // return averageSellPriceAfterGST;
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
                //return averageCostPriceBeforeGST;
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
                //return lastPurchasePriceBeforeGST;
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
                //return lastPurchasePriceAfterGST;
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

        public int? LoggedinUserID
        {
            get
            {
                return loggedinUserID;
            }
            set
            {
                loggedinUserID = value;
                OnPropertyChanged("LoggedinUserID");
            }
        }

        public bool? IsRefreshData
        {
            get
            {
                return isRefreshData;
            }
            set
            {
                isRefreshData = value;
                OnPropertyChanged("isRefreshData");
            }
        }

        public DateTime? RefreshDate
        {
            get
            {
                return refreshDate;
            }
            set
            {
                refreshDate = value;
                OnPropertyChanged("RefreshDate");
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
                OnPropertyChanged("ImgSource");
            }
        }
    }
}
