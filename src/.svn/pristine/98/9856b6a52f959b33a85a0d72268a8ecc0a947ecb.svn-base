using SDN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Sales
{
    public class SalesInvoiceDetailEntity : ViewModelBase
    {
        #region "Private Properties"
        private int? id;
        private int? siID;
        private string siNo;
        private string pandSCode;
        private string pandSName;
        private int? siQty;
        private string siPrice;
        private decimal? siAmount;
        private decimal? siDiscount;
        private string gstCode;
        private decimal? gstRate;
        private string gstRateStr;
        private ObservableCollection<PandSDetailsModel> productAndServices;
        private int sequenceNumber = 0;
        private decimal? siAmountBeforeTax;
        private decimal? siTaxAmount;

        #endregion "End Private Properties"
        #region "Public Properties"


        public int? ID
        {

            get { return id; }

            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public int? SIID
        {
            get
            {
                return siID;
            }
            set
            {
                siID = value;
                OnPropertyChanged("SIID");
            }
        }
        public string SINo
        {
            get
            {
                return siNo;
            }
            set
            {
                siNo = value;
                OnPropertyChanged("SINo");
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

        public int? SIQty
        {
            get
            {
                return siQty;
            }
            set
            {
                siQty = value;
                OnPropertyChanged("SIQty");
            }
        }
        private decimal? price;
        private decimal? priceExcTax;
        private decimal? priceIncTax;
        public decimal? Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public decimal? PriceExcludedTax
        {
            get
            {
                return priceExcTax;
            }
            set
            {
                priceExcTax = value;
                OnPropertyChanged("PriceExcludedTax");
            }
        }
        public decimal? PriceIncludedTax
        {
            get
            {
                return priceIncTax;
            }
            set
            {
                priceIncTax = value;
                OnPropertyChanged("PriceIncludedTax");
            }
        }


        public string SIPrice
        {
            get
            {
                return siPrice;
            }
            set
            {
                siPrice = value;
                OnPropertyChanged("SIPrice");
            }
        }
        public decimal? SIAmount
        {
            get
            {
                return siAmount;
            }
            set
            {
                siAmount = value;
                OnPropertyChanged("SIAmount");
            }
        }
        public decimal? SIDiscount
        {
            get
            {
                return siDiscount;
            }
            set
            {
                siDiscount = value;
                OnPropertyChanged("SIDiscount");
            }
        }
        public string GSTCode
        {
            get
            {
                return gstCode;
            }
            set
            {
                gstCode = value;
                OnPropertyChanged("GSTCode");
            }
        }
        public decimal? GSTRate
        {
            get
            {
                return gstRate;
            }
            set
            {
                gstRate = value;
                OnPropertyChanged("GSTRate");
            }
        }
        public string GSTRateStr
        {
            get
            {
                return gstRateStr;
            }
            set
            {
                gstRateStr = value;
                OnPropertyChanged("GSTRateStr");
            }
        }

        public decimal? SIAmountBeforeTax
        {
            get
            {
                return siAmountBeforeTax;
            }
            set
            {
                siAmountBeforeTax = value;
                OnPropertyChanged("SIAmountBeforeTax");
            }
        }
        public decimal? SITaxAmount
        {
            get
            {
                return siTaxAmount;
            }
            set
            {
                siTaxAmount = value;
                OnPropertyChanged("SITaxAmount");
            }
        }

        //public bool IsModified
        //{
        //    get
        //    {
        //        return isModified;
        //    }
        //    set
        //    {
        //        isModified = value;
        //        OnPropertyChanged("IsModified");
        //    }
        //}

        public ObservableCollection<PandSDetailsModel> ProductAndServices
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
        public int SequenceNumber
        {
            get
            {
                return sequenceNumber;
            }

            set
            {
                sequenceNumber = value;
                OnPropertyChanged("SequenceNumber");
            }
        }

        //private int p_SequenceNumber;



        #endregion "End Private Properties"

        //public override bool Equals(object obj)
        //{
        //    return obj;
        //}

        #region "Constructors"

        public SalesInvoiceDetailEntity()
        {

        }

        public SalesInvoiceDetailEntity(int Id, int SIID, string SINo, string PandSCode, string PSName, int? SIty, decimal? SIPrice,
           decimal SIAmount, decimal SIDiscount, string GSTCode, decimal GSTRate, string GSTRateStr)
        {
            this.ID = Id;
            this.SIID = SIID;
            this.SINo = SINo;
            this.PandSCode = PandSCode;
            this.PandSName = PSName;
            this.SIQty = SIty;
            this.SIPrice = Convert.ToString(SIPrice);
            this.SIAmount = SIAmount;
            this.SIDiscount = SIDiscount;
            this.GSTCode = GSTCode;
            this.GSTRate = GSTRate;
            this.GSTRateStr = GSTRateStr;
            // this.ProductAndServices = pands;
        }

        #endregion
    }
}
