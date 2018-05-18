using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Purchase
{
    using SDN.Common;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    public class PurchaseInvoiceEntity:BaseEntity
    {
        #region "Private members"
        private int id;
        private bool? _MustCompare;

        private List<SupplierDetailEntity> lstSuppliers;
        private int supId;
        private string invoiceNo;
        private DateTime invoiceDate;
        private DateTime? paymentDueDate;
        private string _PaymentDueDateStr;
        private string _InvoiceDateStr;
        private List<PandSDetailsModel> lstPandS;
        private List<ContentModel> lstContents;

        private int? quantity;
        private decimal? discount;
        private decimal? amount;
        private string amountStr;
        private string termsAndConditions;
        private decimal? totalBeforeTax = 0;
        private decimal? totalAfterTax = 0;
        private decimal? totalTax = 0;
        private string taxName;
        private string currencyName;
        private bool? excludingTax;
        private bool? includingTax;
        private ObservableCollection<PurchaseInvoiceDetailEntity> pqDetailsEntity;
        private PurchaseInvoiceDetailEntity pqEntity;
        private int? createdBy;
        private DateTime? createdDate;
        private string shipToAddress;
        private string billToAddress;
        private byte? piStatus;
        private bool? excIncGST;
        private string ourPONo;
        private int _PIFormGridHeight;
        private string sup_Balance;
        private string sup_CreditLimitAmount;
        #endregion

        #region "Public members"
        public bool? MustCompare
        {
            get
            {
                return _MustCompare;
            }
            set
            {
                _MustCompare = value;
                OnPropertyChanged("MustCompare");
            }
        }
        public int PIFormGridHeight
        {
            get
            {
                return _PIFormGridHeight;
            }
            set
            {
                _PIFormGridHeight = value;
                OnPropertyChanged("PIFormGridHeight");
            }
        }
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

        public string Sup_Balance
        {
            get { return sup_Balance; }
            set
            {
                sup_Balance = value;
                OnPropertyChanged("Sup_Balance");
            }
        }
        public string Sup_CreditLimitAmount
        {
            get { return sup_CreditLimitAmount; }
            set
            {
                sup_CreditLimitAmount = value;
                OnPropertyChanged("Sup_CreditLimitAmount");
            }
        }

        public PurchaseInvoiceDetailEntity PQEntity
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

        public string InvoiceNo
        {
            get
            {
                return invoiceNo;
            }
            set
            {
                invoiceNo = value;
                OnPropertyChanged("InvoiceNo");
            }
        }

        public string OurPONo
        {
            get
            {
                return ourPONo;
            }
            set
            {
                ourPONo = value;
                OnPropertyChanged("OurPONo");
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                return invoiceDate;
            }
            set
            {
                invoiceDate = value;
                OnPropertyChanged("InvoiceDate");
            }
        }

        public string InvoiceDateStr
        {
            get
            {
                return _InvoiceDateStr;
            }
            set
            {
                _InvoiceDateStr = value;
                OnPropertyChanged("InvoiceDateStr");
            }
        }
        public string PaymentDueDateStr
        {
            get
            {
                return _PaymentDueDateStr;
            }
            set
            {
                _PaymentDueDateStr = value;
                OnPropertyChanged("PaymentDueDateStr");
            }
        }
        public DateTime? PaymentDueDate
        {
            get
            {
                return paymentDueDate;
            }
            set
            {
                paymentDueDate = value;
                OnPropertyChanged("PaymentDueDate");
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

        public byte? PIStatus
        {
            get
            {
                return piStatus;
            }
            set
            {
                piStatus = value;
                OnPropertyChanged("PIStatus");
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

        public string AmountStr
        {
            get
            {
                return amountStr;
            }
            set
            {
                amountStr = value;
                OnPropertyChanged("AmountStr");
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

        public decimal? Price { get; set; }

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
                //return _InvoiceAmount;
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
                //return _InvoiceAmount;
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
                //return _InvoiceAmount;
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
        
        #endregion
    }

    public class PurchaseInvoiceForm : ViewModelBase
    {
        private List<SupplierDetailEntity> lstSuppliers;
        private PurchaseInvoiceEntity invoice;

        private List<PurchaseInvoiceBEDetailsEntity> beInvoiceDetails { get; set; }
        private List<PurchaseInvoiceDetailEntity> invoiceDetails { get; set; }

        public PurchaseInvoiceEntity Invoice
        {
            get
            {
                return invoice;
            }
            set
            {
                invoice = value;
                OnPropertyChanged("Invoice");
            }
        }

        public List<PurchaseInvoiceDetailEntity> InvoiceDetails
        {
            get
            {
                return invoiceDetails;
            }
            set
            {
                invoiceDetails = value;
                OnPropertyChanged("InvoiceDetails");
            }
        }

        public List<PurchaseInvoiceBEDetailsEntity> BEInvoiceDetails
        {
            get
            {
                return beInvoiceDetails;
            }
            set
            {
                beInvoiceDetails = value;
                OnPropertyChanged("BEInvoiceDetails");
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
