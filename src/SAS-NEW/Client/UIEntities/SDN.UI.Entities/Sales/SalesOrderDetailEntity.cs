using SDN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class SalesOrderDetailEntity : ViewModelBase
    {
        #region "Private Properties"
        private int? id;
        private int? soID;
        private string soNo;
        private string pandSCode;
        private string pandSName;
        private int? soQty;
        private string soPrice;
        private decimal? soAmount;
        private decimal? soDiscount;
        private string gstCode;
        private decimal? gstRate;
        private string gstRateStr;
        private ObservableCollection<PandSDetailsModel> productAndServices;
        private int sequenceNumber = 0;
        private decimal? soAmountBeforeTax;
        private decimal? soTaxAmount;

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
        public int? SOID
        {
            get
            {
                return soID;
            }
            set
            {
                soID = value;
                OnPropertyChanged("SOID");
            }
        }
        public string SONo
        {
            get
            {
                return soNo;
            }
            set
            {
                soNo = value;
                OnPropertyChanged("SONo");
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

        public int? SOQty
        {
            get
            {
                return soQty;
            }
            set
            {
                soQty = value;
                OnPropertyChanged("SOQty");
            }
        }
        private decimal? price;
        private decimal? priceExcTax;
        private decimal? priceIncTax;
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


        public string SOPrice
        {
            get
            {
                return soPrice;
            }
            set
            {
                soPrice = value;
                OnPropertyChanged("SOPrice");
            }
        }
        public decimal? SOAmount
        {
            get
            {
                return soAmount;
            }
            set
            {
                soAmount = value;
                OnPropertyChanged("SOAmount");
            }
        }
        public decimal? SODiscount
        {
            get
            {
                return soDiscount;
            }
            set
            {
                soDiscount = value;
                OnPropertyChanged("SODiscount");
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

        public decimal? SOAmountBeforeTax
        {
            get
            {
                return soAmountBeforeTax;
            }
            set
            {
                soAmountBeforeTax = value;
                OnPropertyChanged("SOAmountBeforeTax");
            }
        }
        public decimal? SOTaxAmount
        {
            get
            {
                return soTaxAmount;
            }
            set
            {
                soTaxAmount = value;
                OnPropertyChanged("SOTaxAmount");
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

        public SalesOrderDetailEntity()
        {

        }

        public SalesOrderDetailEntity(int Id, int SOID, string SONo, string PandSCode, string PSName, int? SOty, decimal? SOPrice,
           decimal SOAmount, decimal SODiscount, string GSTCode, decimal GSTRate, string GSTRateStr)
        {
            this.ID = Id;
            this.SOID = SOID;
            this.SONo = SONo;
            this.PandSCode = PandSCode;
            this.PandSName = PSName;
            this.SOQty = SOty;
            this.SOPrice = Convert.ToString(SOPrice);
            this.SOAmount = SOAmount;
            this.SODiscount = SODiscount;
            this.GSTCode = GSTCode;
            this.GSTRate = GSTRate;
            this.GSTRateStr = GSTRateStr;
            // this.ProductAndServices = pands;
        }

        #endregion
    }
}
