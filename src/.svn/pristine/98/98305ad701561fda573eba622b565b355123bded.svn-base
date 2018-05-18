using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities 
{
    using SDN.Common;
    using System.ComponentModel;
    using System.Globalization;

    public  class PurchaseQuotationEntity:BaseEntity
    {
        #region "Private members"
        private int id;
        private List<SupplierDetailEntity> lstSuppliers;
        private int supId;
        private string quotationNo;
        private DateTime quotationDate;
        private int? validForDays;
        private List<PandSDetailsModel> lstPandS;
        private List<ContentModel> lstContents;
        
        private int? quantity;
        private decimal? discount;
        private string amount;
        private string termsAndConditions;
        private decimal? totalBeforeTax = 0;
        private decimal? totalAfterTax = 0;
        private decimal? totalTax = 0;
        private string taxName;
        private string currencyName;
        private bool? excludingTax;
        private bool? includingTax;
        private ObservableCollection<PurchaseQuotationDetailEntity> pqDetailsEntity;
        private PurchaseQuotationDetailEntity pqEntity;
        private int? createdBy;
        private DateTime? createdDate;
        private string shipToAddress;
        private string billToAddress;
        private bool? pq_Conv_to_PO;
        private bool? pq_Conv_to_PI;
        private bool? excIncGST;
        private int _PQFormGridHeight;

        #endregion

        #region "Public members"

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public int PQFormGridHeight
        {
            get
            {
                return _PQFormGridHeight;
            }
            set
            {
                _PQFormGridHeight = value;
                OnPropertyChanged("PQFormGridHeight");
            }
        }

        public int SupplierID
        {
            get
            {
                return supId;
            }
            set
            {
                supId = value;
                OnPropertyChanged("SupplierID");
            }
        }



        public PurchaseQuotationDetailEntity PQEntity
        {
            get
            {
                return pqEntity;
            }
            set
            {
                pqEntity = value;
                OnPropertyChanged("PQEntity");
            }
        }
        public bool? PQ_Conv_to_PO
        {
            get
            {
                return pq_Conv_to_PO;
            }
            set
            {
                pq_Conv_to_PO = value;
                OnPropertyChanged("PQ_Conv_to_PO");
            }
        }
        public bool? PQ_Conv_to_PI
        {
            get
            {
                return pq_Conv_to_PI;
            }
            set
            {
                pq_Conv_to_PI = value;
                OnPropertyChanged("PQ_Conv_to_PI");
            }
        }


        public string TermsAndConditions
        {
            get
            {
                return termsAndConditions;
            }
            set
            {
                termsAndConditions = value;
                OnPropertyChanged("TermsAndConditions");
            }
        }

        public List<SupplierDetailEntity> LstSuppliers
        {
            get
            {
                return lstSuppliers;
            }
            set
            {
                lstSuppliers = value;
                OnPropertyChanged("LstSuppliers");
            }
        }

        public List<ContentModel> LstContents
        {
            get
            {
                return lstContents;
            }
            set
            {
                lstContents = value;
                OnPropertyChanged("LstContents");
            }
        }

        public string QuotationNo
        {
            get
            {
                return quotationNo;
            }
            set
            {
                quotationNo = value;
                OnPropertyChanged("QuotationNo");
            }
        }

        public DateTime QuotationDate
        {
            get
            {
                return quotationDate;
            }
            set
            {
                quotationDate = value;
                OnPropertyChanged("QuotationDate");
            }
        }

        public int? ValidForDays
        {
            get
            {
                return validForDays;
            }
            set
            {
                validForDays = value;
                OnPropertyChanged("ValidForDays");
            }
        }

        public List<PandSDetailsModel> LstPandS
        {
            get
            {
                return lstPandS;
            }
            set
            {
                lstPandS = value;
                OnPropertyChanged("LstPandS");
            }
        }

        public int? Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

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

        public string Amount
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

        public string TaxName
        {
            get
            {
                return taxName;
            }
            set
            {
                taxName = value;

            }
        }

        public string CurrencyName
        {
            get
            {
                return currencyName;
            }
            set
            {
                currencyName = value;
                OnPropertyChanged("CurrencyName");
            }
        }

        public bool? ExcIncGST
        {
            get
            {
                return excIncGST;
            }
            set
            {
                excIncGST = value;
                OnPropertyChanged("ExcIncGST");
            }
        }

        public string BillToAddress
        {
            get
            {
                return billToAddress;
            }
            set
            {
                billToAddress = value;
                OnPropertyChanged("BillToAddress");
            }
        }
        public string ShipToAddress
        {
            get
            {
                return shipToAddress;
            }
            set
            {
                shipToAddress = value;
                OnPropertyChanged("ShipToAddress");
            }
        }
        public decimal? TotalBeforeTax
        {
            get
            {
                return totalBeforeTax;
            }
            set
            {
                totalBeforeTax = value;
                OnPropertyChanged("TotalBeforeTax");
            }
        }
        public decimal? TotalAfterTax
        {
            get
            {
                return totalAfterTax;
            }
            set
            {
                totalAfterTax = value;
                OnPropertyChanged("TotalAfterTax");
            }
        }

        public decimal? TotalTax
        {
            get
            {
                return totalTax;
            }
            set
            {
                totalTax = value;
                OnPropertyChanged("TotalTax");
            }
        }

        private string totalBeforeTaxStr;
        private string totalTaxStr;
        private string totalAfterTaxStr;
        public string TotalBeforeTaxStr
        {
            get
            {
                //return _QuotationAmount;
                if (totalBeforeTaxStr == null)
                    return this.totalBeforeTaxStr;
                else
                {
                    if (totalBeforeTaxStr != "")
                    {
                        var balance = totalBeforeTaxStr.Replace(",", "");
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
                        return this.totalBeforeTaxStr;
                }
            }
            set
            {
                totalBeforeTaxStr = value;
                OnPropertyChanged("TotalBeforeTaxStr");
            }
            
        }
        public string TotalTaxStr
        {
            get
            {
                //return _QuotationAmount;
                if (totalTaxStr == null)
                    return this.totalTaxStr;
                else
                {
                    if (totalTaxStr != "")
                    {
                        var balance = totalTaxStr.Replace(",", "");
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
                        return this.totalTaxStr;
                }
            }
            set
            {
                totalTaxStr = value;
                OnPropertyChanged("TotalTaxStr");
            }
            
        }
        public string TotalAfterTaxStr
        {
            get
            {
                //return _QuotationAmount;
                if (totalAfterTaxStr == null)
                    return this.totalAfterTaxStr;
                else
                {
                    if (totalAfterTaxStr != "")
                    {
                        var balance = totalAfterTaxStr.Replace(",", "");
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
                        return this.totalAfterTaxStr;
                }
            }
            set
            {
                totalAfterTaxStr = value;
                OnPropertyChanged("TotalAfterTaxStr");
            }
          
        }

        public bool? ExcludingTax
        {
            get
            {
                return excludingTax;
            }
            set
            {
                excludingTax = value;
                OnPropertyChanged("ExcludingTax");
            }
        }

        public bool? IncludingTax
        {
            get
            {
                return includingTax;
            }
            set
            {
                includingTax = value;
                OnPropertyChanged("IncludingTax");
            }
        }

        public int? CreatedBy
        {
            get
            {
                return createdBy;
            }
            set
            {
                createdBy = value;
                OnPropertyChanged("CreatedBy");
            }
        }
        public DateTime? CreatedDate
        {
            get
            {
                return createdDate;
            }
            set
            {
                createdDate = value;
                OnPropertyChanged("CreatedDate");
            }
        }

        //public ObservableCollection<PurchaseQuotationDetailEntity> PQDetailsEntity
        //{
        //    get
        //    {
        //        return pqDetailsEntity=new ObservableCollection<PurchaseQuotationDetailEntity>();
        //    }
        //    set
        //    {
        //        pqDetailsEntity = value;
        //        OnPropertyChanged("PQDetailsEntity");
        //    }
        //}

        #endregion

       
    }
    public class PurchaseQuotationForm:ViewModelBase
    {
        private List<SupplierDetailEntity> lstSuppliers;
        private PurchaseQuotationEntity quotation;
     

        private List<PurchaseQuotationDetailEntity> quotationDetails { get; set; }

        public PurchaseQuotationEntity Quotation
        {
            get
            {
                return quotation;
            }
            set
            {
                quotation = value;
                OnPropertyChanged("Quotation");
            }
        }

        public List<PurchaseQuotationDetailEntity> QuotationDetails
        {
            get
            {
                return quotationDetails;
            }
            set
            {
                quotationDetails = value;
                OnPropertyChanged("QuotationDetails");
            }
        }

        public List<SupplierDetailEntity> LstSuppliers
        {
            get
            {
                return lstSuppliers;
            }
            set
            {
                lstSuppliers = value;
                OnPropertyChanged("LstSuppliers");
            }
        }

        public ObservableCollection<PandSDetailsModel> ProductAndServices
        {
            get;
            set;
        }

        public List<ContentModel> LstTermsAndConditions { get; set; }
    }
}
