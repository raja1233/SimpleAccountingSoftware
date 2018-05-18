using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Sales
{
    using SDN.Common;
    using System.Collections.ObjectModel;
    public class SalesQuotationDetailEntity: ViewModelBase
    {
        #region "Private Properties"
        private int? id;
        private int? sqID;
        private string sqNo;
        private string pandSCode;
        private string pandSName;
        private int? sqQty;
        private string sqPrice;
        private decimal? sqAmount;
        private decimal? sqDiscount;
        private string sqDiscountStr;
        private string gstCode;
        private decimal? gstRate;
        private string gstRateStr;
        private ObservableCollection<PandSDetailsModel> productAndServices;
        private int sequenceNumber = 0;
        private decimal? sqAmountBeforeTax;
        private decimal? sqTaxAmount;

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
        public int? SQID
        {
            get
            {
                return sqID;
            }
            set
            {
                sqID = value;
                OnPropertyChanged("SQID");
            }
        }
        public string SQNo
        {
            get
            {
                return sqNo;
            }
            set
            {
                sqNo = value;
                OnPropertyChanged("SQNo");
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

        public int? SQQty
        {
            get
            {
                return sqQty;
            }
            set
            {
                sqQty = value;
                OnPropertyChanged("SQQty");
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
        public string SQPrice
        {
            get
            {
                return sqPrice;
            }
            set
            {
                sqPrice = value;
                OnPropertyChanged("SQPrice");
            }
        }
        public decimal? SQAmount
        {
            get
            {
                return sqAmount;
            }
            set
            {
                sqAmount = value;
                OnPropertyChanged("SQAmount");
            }
        }
        public decimal? SQDiscount
        {
            get
            {
                return sqDiscount;
            }
            set
            {
                sqDiscount = value;
                OnPropertyChanged("SQDiscount");
            }
        }
        public string SQDiscountStr
        {
            get
            {
                return sqDiscountStr;
            }
            set
            {
                sqDiscountStr = value;
                OnPropertyChanged("SQDiscountStr");
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
        public string  GSTRateStr
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

        public decimal? SQAmountBeforeTax
        {
            get
            {
                return sqAmountBeforeTax;
            }
            set
            {
                sqAmountBeforeTax = value;
                OnPropertyChanged("SQAmountBeforeTax");
            }
        }
        public decimal? SQTaxAmount
        {
            get
            {
                return sqTaxAmount;
            }
            set
            {
                sqTaxAmount = value;
                OnPropertyChanged("SQTaxAmount");
            }
        }

        

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

        public SalesQuotationDetailEntity()
        {

        }

        public SalesQuotationDetailEntity(int Id, int SQID, string SQNo, string PandSCode, string PSName, int? SQty, decimal? SQPrice,
           decimal SQAmount, decimal SQDiscount,string SQDiscountStr, string GSTCode, decimal GSTRate,string GSTRateStr)
        {
            this.ID = Id;
            this.SQID = SQID;
            this.SQNo = SQNo;
            this.PandSCode = PandSCode;
            this.PandSName = PSName;
            this.SQQty = SQty;
            this.SQPrice = Convert.ToString(SQPrice);
            this.SQAmount = SQAmount;
            this.SQDiscount = SQDiscount;
            this.SQDiscountStr = SQDiscountStr;
            this.GSTCode = GSTCode;
            this.GSTRate = GSTRate;
            this.GSTRateStr = GSTRateStr;
            // this.ProductAndServices = pands;
        }

        #endregion
    }
}
