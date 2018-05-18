
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Product
{
    using SDN.Common;
    using System.Globalization;

    public class PandSQtyAndStockModel:ViewModelBase
    {
        #region "Private members"
        private int? psID;
        private string psCode;
        private string psName;
        private int? category1;
        private int? category2;
        private int? qtyInStock;
        private decimal? avgCostPriceBeforeGSTd;
        private decimal? avgCostPriceAfterGSTd;
        private decimal? stdPriceAfterGSTd;
        private decimal? stdPriceBeforeGSTd;
        private string avgCostPriceBeforeGST;
        private string avgCostPriceAfterGST;
        private string stdPriceAfterGST;
        private string stdPriceBeforeGST;
        private string psType;
        private string isInActive;
        #endregion

        #region "Properties"

        public int? PSID
        {
            get { return psID; }
            set { psID = value;
                OnPropertyChanged("PSID");
            }
        }
        public string PSCode
        {
            get { return psCode; }
            set { psCode = value;
                OnPropertyChanged("PSCode");
            }
        }
        public string PSName
        {
            get { return psName; }
            set
            {
                psName = value;
                OnPropertyChanged("PSName");
            }
        }
        public int? Category1
        {
            get { return category1; }
            set { category1 = value;
                OnPropertyChanged("Category1");
            }
        }

        public int? Category2
        {
            get { return category2; }
            set { category2 = value;
                OnPropertyChanged("Category2");
            }
        }
        public int? QtyInStock
        {
            get { return qtyInStock; }
            set
            {
                qtyInStock = value;
                OnPropertyChanged("QtyInStock");
            }
        }

        public string PSType
        {
            get { return psType; }
            set
            {
                psType = value;
                OnPropertyChanged("PSType");
            }
        }

        public string IsInActive
        {
            get { return isInActive; }
            set
            {
                isInActive = value;
                OnPropertyChanged("IsInActive");
            }
        }

        public decimal? AvgCostPriceBeforeGSTd
        {
            get { return avgCostPriceBeforeGSTd; }
            set
            {
                avgCostPriceBeforeGSTd = value;
                OnPropertyChanged("AvgCostPriceBeforeGSTd");
            }
        }
        public decimal? AvgCostPriceAfterGSTd
        {
            get { return avgCostPriceAfterGSTd; }
            set
            {
                avgCostPriceAfterGSTd = value;
                OnPropertyChanged("AvgCostPriceAfterGSTd");
            }
        }
        public decimal? StdPriceAfterGSTd
        {
            get { return stdPriceAfterGSTd; }
            set
            {
                stdPriceAfterGSTd = value;
                OnPropertyChanged("StdPriceAfterGSTd");
            }
        }
        public decimal? StdPriceBeforeGSTd
        {
            get { return stdPriceBeforeGSTd; }
            set
            {
                stdPriceBeforeGSTd = value;
                OnPropertyChanged("StdPriceBeforeGSTd");
            }
        }

        public string AvgCostPriceBeforeGST
        {
            get
            {
                //return _QuotationAmount;
                if (avgCostPriceBeforeGST == null)
                    return this.avgCostPriceBeforeGST;
                else
                {
                    if (avgCostPriceBeforeGST != "")
                    {
                        var balance = avgCostPriceBeforeGST.Replace(",", "");
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
                        return this.avgCostPriceBeforeGST;
                }
            }
            set
            {
                avgCostPriceBeforeGST = value;
                OnPropertyChanged("AmountStr");
            }
        }
         
        public string AvgCostPriceAfterGST
        {
            get
            {
                //return _QuotationAmount;
                if (avgCostPriceAfterGST == null)
                    return this.avgCostPriceAfterGST;
                else
                {
                    if (avgCostPriceAfterGST != "")
                    {
                        var balance = avgCostPriceAfterGST.Replace(",", "");
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
                        return this.avgCostPriceAfterGST;
                }
            }
            set
            {
                avgCostPriceAfterGST = value;
                OnPropertyChanged("AvgCostPriceAfterGST");
            }
        }
        public string StdPriceAfterGST
        {
            get
            {
                //return _QuotationAmount;
                if (stdPriceAfterGST == null)
                    return this.stdPriceAfterGST;
                else
                {
                    if (stdPriceAfterGST != "")
                    {
                        var balance = stdPriceAfterGST.Replace(",", "");
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
                        return this.stdPriceAfterGST;
                }
            }
            set
            {
                stdPriceAfterGST = value;
                OnPropertyChanged("StdPriceAfterGST");
            }
        }

        public string StdPriceBeforeGST
        {
            get
            {
               
                if (stdPriceBeforeGST == null)
                    return this.stdPriceBeforeGST;
                else
                {
                    if (stdPriceBeforeGST != "")
                    {
                        var balance = stdPriceBeforeGST.Replace(",", "");
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
                        return this.stdPriceBeforeGST;
                }
            }
            set
            {
               stdPriceBeforeGST = value;
                OnPropertyChanged("StdPriceBeforeGST");
            }
        }


        #endregion
    }
}
