using SDN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    public class PurchaseOrderDetailEntity : ViewModelBase
    {
        #region "Private Properties"
        private int? id;
        private int? poID;
        private string poNo;
        private string pandSCode;
        private string pandSName;
        private int? poQty;
        private string poPrice;
        private decimal? poAmount;
        private decimal? poDiscount;
        private string gstCode;
        private string gstRateStr;
        private decimal? gstRate;
        private ObservableCollection<PandSDetailsModel> productAndServices;
        private int sequenceNumber = 0;
        private decimal? poAmountBeforeTax;
        private decimal? poTaxAmount;

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
        public int? POID
        {
            get
            {
                return poID;
            }
            set
            {
                poID = value;
                OnPropertyChanged("POID");
            }
        }
        public string PONo
        {
            get
            {
                return poNo;
            }
            set
            {
                poNo = value;
                OnPropertyChanged("PONo");
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

        public int? POQty
        {
            get
            {
                return poQty;
            }
            set
            {
                poQty = value;
                OnPropertyChanged("POQty");
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


        public string POPrice
        {
            get
            {
                return poPrice;
            }
            set
            {
                poPrice = value;
                OnPropertyChanged("POPrice");
            }
        }
        public decimal? POAmount
        {
            get
            {
                return poAmount;
            }
            set
            {
                poAmount = value;
                OnPropertyChanged("POAmount");
            }
        }
        public decimal? PODiscount
        {
            get
            {
                return poDiscount;
            }
            set
            {
                poDiscount = value;
                OnPropertyChanged("PODiscount");
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

        public decimal? POAmountBeforeTax
        {
            get
            {
                return poAmountBeforeTax;
            }
            set
            {
                poAmountBeforeTax = value;
                OnPropertyChanged("POAmountBeforeTax");
            }
        }
        public decimal? POTaxAmount
        {
            get
            {
                return poTaxAmount;
            }
            set
            {
                poTaxAmount = value;
                OnPropertyChanged("POTaxAmount");
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

        public PurchaseOrderDetailEntity()
        {

        }

        public PurchaseOrderDetailEntity(int Id, int POID, string PONo, string PandSCode, string PSName, int? POty, decimal? POPrice,
           decimal POAmount, decimal PODiscount, string GSTCode, decimal GSTRate)
        {
            this.ID = Id;
            this.POID = POID;
            this.PONo = PONo;
            this.PandSCode = PandSCode;
            this.PandSName = PSName;
            this.POQty = POty;
            this.POPrice = Convert.ToString(POPrice);
            this.POAmount = POAmount;
            this.PODiscount = PODiscount;
            this.GSTCode = GSTCode;
            this.GSTRate = GSTRate;
            // this.ProductAndServices = pands;
        }

        #endregion
    }
}
