using SDN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
  public  class PurchaseQuotationDetailEntity:ViewModelBase
    {
        #region "Private Properties"
        private int? id;
        private int? pqID;
        private string pqNo;
        private string pandSCode;
        private string pandSName;
        private int? pqQty;
        private string pqPrice;
        private decimal? pqAmount;
        private decimal? pqDiscount;
        private string gstCode;
        private decimal? gstRate;
        private ObservableCollection<PandSDetailsModel> productAndServices;
        private int sequenceNumber=0;
        private decimal? pqAmountBeforeTax;
        private decimal? pqTaxAmount;
        private string gstRateStr;
        #endregion "End Private Properties"
        #region "Public Properties"


        public int? ID {

            get { return id; }

            set { id = value;
                OnPropertyChanged("ID");
            } }
        public int? PQID
        {
            get
            {
                return pqID;
            }
            set {
                pqID = value;
                OnPropertyChanged("PQID");
            }
        }
        public string PQNo
        {
            get
            {
              return  pqNo;
            }
            set
            {
                pqNo = value;
                OnPropertyChanged("PQNo");
            }
        }
        public string PandSCode
        {
            get
            {
                return pandSCode;
            }
            set {
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
            set {
                pandSName = value;
                OnPropertyChanged("PandSName");
            }
        }
       
        public int? PQQty
        {
            get
            {
                return pqQty;
            }
            set
            {
                pqQty = value;
                OnPropertyChanged("PQQty");
            }
        }
        private decimal? price;
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
       

        public string PQPrice
        {
            get
            {
               return  pqPrice;
            }
            set
            {
                pqPrice = value;
                OnPropertyChanged("PQPrice");
            }
        }
        public decimal? PQAmount
        {
            get
            {
                return pqAmount;
            }
            set {
                pqAmount = value;
                OnPropertyChanged("PQAmount");
            }
        }
        public decimal? PQDiscount
        {
            get
            {
                return pqDiscount;
            }
            set
            {
                pqDiscount = value;
                OnPropertyChanged("PQDiscount");
            }
        }
        public string GSTCode
        {
            get
            {
                return gstCode;
            }
            set {
                gstCode = value;
                OnPropertyChanged("GSTCode");
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
                if (gstRateStr != value)
                {
                    gstRateStr = value;
                    OnPropertyChanged("GSTRateStr");
                }
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

        public decimal? PQAmountBeforeTax
        {
            get
            {
                return pqAmountBeforeTax;
            }
            set
            {
                pqAmountBeforeTax = value;
                OnPropertyChanged("PQAmountBeforeTax");
            }
        }
        public decimal? PQTaxAmount
        {
            get
            {
                return pqTaxAmount;
            }
            set
            {
                pqTaxAmount = value;
                OnPropertyChanged("PQTaxAmount");
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

        public PurchaseQuotationDetailEntity()
        {
           
        }

        public PurchaseQuotationDetailEntity(int Id, int PQID, string PQNo, string PandSCode, string PSName, int? PQty, decimal? PQPrice,
           decimal PQAmount, decimal PQDiscount, string GSTCode, decimal GSTRate)
        {
            this.ID = Id;
            this.PQID = PQID;
            this.PQNo = PQNo;
            this.PandSCode = PandSCode;
            this.PandSName = PSName;
            this.PQQty = PQty;
            this.PQPrice = Convert.ToString(PQPrice);
            this.PQAmount = PQAmount;
            this.PQDiscount = PQDiscount;
            this.GSTCode = GSTCode;
            this.GSTRate = GSTRate;
           // this.ProductAndServices = pands;
        }

        #endregion
    }
}
