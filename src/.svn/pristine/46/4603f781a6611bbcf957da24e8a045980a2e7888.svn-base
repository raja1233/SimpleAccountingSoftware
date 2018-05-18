using SDN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Purchase
{
    public class PurchaseInvoiceDetailEntity: ViewModelBase
    {
        #region "Private Properties"
        private int? id;
        private int? piID;
        private string piNo;
        private string pandSCode;
        private string pandSName;
        private int? piQty;
        private string piPrice;
        private decimal? piAmount;
        private decimal? piDiscount;
        private string gstCode;
        private decimal? gstRate;
        private string gstRateStr;
        private ObservableCollection<PandSDetailsModel> productAndServices;
        private int sequenceNumber = 0;
        private decimal? piAmountBeforeTax;
        private decimal? piTaxAmount;
        private string piType;
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
        public int? PIID
        {
            get
            {
                return piID;
            }
            set
            {
                piID = value;
                OnPropertyChanged("PIID");
            }
        }
        public string PINo
        {
            get
            {
                return piNo;
            }
            set
            {
                piNo = value;
                OnPropertyChanged("PINo");
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

        public int? PIQty
        {
            get
            {
                return piQty;
            }
            set
            {
                piQty = value;
                OnPropertyChanged("PIQty");
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


        public string PIPrice
        {
            get
            {
                return piPrice;
            }
            set
            {
                piPrice = value;
                OnPropertyChanged("PIPrice");
            }
        }
        public decimal? PIAmount
        {
            get
            {
                return piAmount;
            }
            set
            {
                piAmount = value;
                OnPropertyChanged("PIAmount");
            }
        }
        public decimal? PIDiscount
        {
            get
            {
                return piDiscount;
            }
            set
            {
                piDiscount = value;
                OnPropertyChanged("PIDiscount");
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

        public decimal? PIAmountBeforeTax
        {
            get
            {
                return piAmountBeforeTax;
            }
            set
            {
                piAmountBeforeTax = value;
                OnPropertyChanged("PIAmountBeforeTax");
            }
        }
        public decimal? PITaxAmount
        {
            get
            {
                return piTaxAmount;
            }
            set
            {
                piTaxAmount = value;
                OnPropertyChanged("PITaxAmount");
            }
        }

       public string PIType
        {
            get
            {
                return piType;
            }
            set
            {
                piType = value;
                OnPropertyChanged("PIType");
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

        #region "Constructors"

        public PurchaseInvoiceDetailEntity()
        {

        }

        public PurchaseInvoiceDetailEntity(int Id, int PIID, string PINo, string PandSCode, string PSName, int? PIty, decimal? PIPrice,
           decimal PIAmount, decimal PIDiscount, string GSTCode, decimal GSTRate)
        {
            this.ID = Id;
            this.PIID = PIID;
            this.PINo = PINo;
            this.PandSCode = PandSCode;
            this.PandSName = PSName;
            this.PIQty = PIty;
            this.PIPrice = Convert.ToString(PIPrice);
            this.PIAmount = PIAmount;
            this.PIDiscount = PIDiscount;
            this.GSTCode = GSTCode;
            this.GSTRate = GSTRate;
            // this.ProductAndServices = pands;
        }

        #endregion
    }
}
