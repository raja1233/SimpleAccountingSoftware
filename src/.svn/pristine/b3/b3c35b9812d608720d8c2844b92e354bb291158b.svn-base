using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.DialogBox
{
    using Common;
    using SDN.Product.Services;
    using UI.Entities;
    using System.ComponentModel.DataAnnotations;

    public class PandSDialogViewModel:ViewModelBase
    {
        #region "Private members"

        private List<PandSDetailsModel> productAndServices;
        private int selectedPandSID;
        IPandSDetailsRepository pandRepository = new PandSDetailsRepository();
        private int? qty;
        private decimal? price;
        private decimal? discount;
        private decimal? amount;
        private decimal? taxRate;
        private bool excludingTax;
        private string taxName;

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

        public  int? Qty
        {
            get
            {
                return qty;
            }
            set
            {
                qty = value;
                OnPropertyChanged("Qty");
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

         [Range(0,100,ErrorMessage ="Discount Should be between 0 to 100")]
        public decimal? Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
                OnPropertyChanged("Discount");
            }
        }
        public decimal? Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
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
                OnPropertyChanged("TaxRate");
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

        public bool IsExcludingTax
        {
            get
            {
                return excludingTax;
            }
            set
            {
                excludingTax = value;
                OnPropertyChanged("IsExcludingTax");
            }

        }


        #endregion

        #region "Relay Commands"

        public RelayCommand PandSSelectionChangedCommand { get; set; }
        public RelayCommand TextChangedCommand { get; set; }

        #endregion

        #region "Constructors"
        public PandSDialogViewModel()
        {
            PandSSelectionChangedCommand = new RelayCommand(OnPandSChange);
            TextChangedCommand = new RelayCommand(OnQtyOrDiscountChanged);

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

            #region "To display default tax name from Tax Code & rate"
            var data = pandRepository.GetTaxes().Where(t => t.IsDefault == true).FirstOrDefault();
            if (data != null)
            {
                TaxName = data.TaxName;
                TaxRate = data.TaxRate;
            }
            else
            {
                TaxName = "GST";
                TaxRate = 0;  //default 
            }
            #endregion

        }
        #endregion

        #region "member functions"

        public void OnPandSChange(object param)
        {
            GetPandSDetails();
        }

        public void OnQtyOrDiscountChanged(object param)
        {
            OnQtyOrDiscountChanged();
        }


        public void OnQtyOrDiscountChanged()
        {
            if (Qty != null && Price != null)
            {
                this.Amount = Qty * Price;

                if (Discount != null)
                {
                    Amount = Math.Round(Convert.ToDecimal(Amount - Math.Round(Convert.ToDecimal((Amount * Discount) / 100),2)),2);
                }

                //  AmountBeforeTax = PQAmount;
                //  TaxAmount = ((PQAmount * TaxRate) / 100);

                Amount = Math.Round(Convert.ToDecimal(Amount + Math.Round(Convert.ToDecimal((Amount * TaxRate) / 100),2)),2);
            }
        }

        public void GetPandSDetails()
        {
            #region getting Options details

            var lstOptions = pandRepository.GetOptionDetails();
            if (lstOptions != null)
            {
                bool? tax = lstOptions.ShowAmountIncGST;
                if (tax == true)
                {
                    IsExcludingTax = false;
                }
                else
                {
                    IsExcludingTax = true;
                }
            }

            #endregion


            var pqDetails = ProductAndServices.Where(p => p.ID == SelectedPandSID).SingleOrDefault();
            if (pqDetails != null)
            {
                //  PQDEntity = lst.Where(l => l.ID == SelectedPSID).SingleOrDefault();
                if (IsExcludingTax == true)
                {
                   Price = Math.Round(Convert.ToDecimal(pqDetails.StandardCostpriceBeforeGST),2);
                }
                else
                {
                  Price = Math.Round(Convert.ToDecimal(pqDetails.StandardCostpriceAfterGST),2);
                }
            }
        }

        #endregion
    }
}
