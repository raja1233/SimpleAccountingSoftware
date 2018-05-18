
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Purchase
{
    using SDN.Common;
    using System.Collections.ObjectModel;
    using System.Globalization;
     
    public class DebitNoteEntity: BaseEntity
    {
        #region "Private members"
        private int id;
        private bool? _MustCompare;

        private List<SupplierDetailEntity> lstSuppliers;
        private int supId;
        private string debitNo;
        private DateTime? debitDate;
        private string supplierCreditNoteNo;
        private DateTime? supplierCreditNoteDate;
        private string _SupplierCreditNoteDateStr;
        private string supplierCreditNoteAmount;
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
        private byte? status;
        private bool? excIncGST;
        private string ourPONo;
        private int _PIFormGridHeight;
        private int purchaseInvoiceID;
        private string purchaseInvoiceNo;
        private bool? _RubberStampDN;
        #endregion
        #region "Suppliers Entity"
        private string _SupplierName;
        private string _SupplierBillToLine1;
        private string _SupplierBillToLine2;
        private string _SupplierBillToCity;
        private string _SupplierBillToState;
        private string _SupplierBillToCountary;
        private string _SupplierBillToPostCode;
        private string _SupplierTelephone;
        private string _CompanyName;
        private string _CompanyRegNumber;
        private string _Telephone;
        private string _CompanyFax;
        private string _CompanyEmail;
        private string _CompanyGstNumber;
        private string _CompanyBillToAddressLine1;
        private string _CompanyBillToAddressLine2;
        private string _CompanyBillToCity;
        private string _CompanyBillToState;
        private string _CompanyBillToCountary;
        private string _CompanyBillToPostCode;
        private string _CurrencyCode;
        private byte[] _CompanyLogo;
        #endregion
        #region "Suppliers public entity"
        public string SupplierName
        {
            get
            {
                return _SupplierName;
            }
            set
            {
                _SupplierName = value;
                OnPropertyChanged("SupplierName");
            }
        }
        public string SupplierBillToLine1
        {
            get
            {
                return _SupplierBillToLine1;
            }
            set
            {
                _SupplierBillToLine1 = value;
                OnPropertyChanged("SupplierBillToLine1");
            }
        }
        public string SupplierBillToLine2
        {
            get
            {
                return _SupplierBillToLine2;
            }
            set
            {
                _SupplierBillToLine2 = value;
                OnPropertyChanged("SupplierBillToLine2");
            }
        }
        public string SupplierBillToCity
        {
            get
            {
                return _SupplierBillToCity;
            }
            set
            {
                _SupplierBillToCity = value;
                OnPropertyChanged("SupplierBillToCity");
            }
        }
        public string SupplierBillToState
        {
            get
            {
                return _SupplierBillToState;
            }
            set
            {
                _SupplierBillToState = value;
                OnPropertyChanged("SupplierBillToState");
            }
        }
        public string SupplierBillToCountary
        {
            get
            {
                return _SupplierBillToCountary;
            }
            set
            {
                _SupplierBillToCountary = value;
                OnPropertyChanged("SupplierBillToCountary");
            }
        }
        public string SupplierBillToPostCode
        {
            get
            {
                return _SupplierBillToPostCode;
            }
            set
            {
                _SupplierBillToPostCode = value;
                OnPropertyChanged("SupplierBillToPostCode");
            }
        }
        public string SupplierTelephone
        {
            get
            {
                return _SupplierTelephone;
            }
            set
            {
                _SupplierTelephone = value;
                OnPropertyChanged("SupplierTelephone");
            }
        }
        public byte[] CompanyLogo
        {
            get
            {
                return this._CompanyLogo;
            }
            set
            {
                this._CompanyLogo = value;
                this.OnPropertyChanged("CompanyLogo");
            }
        }
        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
                OnPropertyChanged("CompanyName");
            }
        }
        public string CompanyRegNumber
        {
            get
            {
                return _CompanyRegNumber;
            }
            set
            {
                _CompanyRegNumber = value;
                OnPropertyChanged("CompanyRegNumber");
            }
        }
        public string Telephone
        {
            get
            {
                return _Telephone;
            }
            set
            {
                _Telephone = value;
                OnPropertyChanged("Telephone");
            }
        }
        public string CompanyFax
        {
            get
            {
                return _CompanyFax;
            }
            set
            {
                _CompanyFax = value;
                OnPropertyChanged("CompanyFax");
            }
        }
        public string CompanyEmail
        {
            get
            {
                return _CompanyEmail;
            }
            set
            {
                _CompanyEmail = value;
                OnPropertyChanged("CompanyEmail");
            }
        }
        public string CompanyGstNumber
        {
            get
            {
                return _CompanyGstNumber;
            }
            set
            {
                _CompanyGstNumber = value;
                OnPropertyChanged("CompanyGstNumber");
            }
        }
        public string CompanyBillToAddressLine1
        {
            get
            {
                return _CompanyBillToAddressLine1;
            }
            set
            {
                _CompanyBillToAddressLine1 = value;
                OnPropertyChanged("CompanyBillToAddressLine1");
            }
        }
        public string CompanyBillToAddressLine2
        {
            get
            {
                return _CompanyBillToAddressLine2;
            }
            set
            {
                _CompanyBillToAddressLine2 = value;
                OnPropertyChanged("CompanyBillToAddressLine2");
            }
        }
        public string CompanyBillToCity
        {
            get
            {
                return _CompanyBillToCity;
            }
            set
            {
                _CompanyBillToCity = value;
                OnPropertyChanged("CompanyBillToCity");
            }
        }
        public string CompanyBillToState
        {
            get
            {
                return _CompanyBillToState;
            }
            set
            {
                _CompanyBillToState = value;
                OnPropertyChanged("CompanyBillToState");
            }
        }
        public string CompanyBillToCountary
        {
            get
            {
                return _CompanyBillToCountary;
            }
            set
            {
                _CompanyBillToCountary = value;
                OnPropertyChanged("CompanyBillToCountary");
            }
        }
        public string CompanyBillToPostCode
        {
            get
            {
                return _CompanyBillToPostCode;
            }
            set
            {
                _CompanyBillToPostCode = value;
                OnPropertyChanged("CompanyBillToPostCode");
            }
        }
        public string CurrencyCode
        {
            get
            {
                return _CurrencyCode;
            }
            set
            {
                _CurrencyCode = value;
                OnPropertyChanged("CurrencyCode");
            }
        }
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
       
        public bool? RubberStampDN
        {
            get
            {
                return _RubberStampDN;
            }
            set
            {
                _RubberStampDN = value;
                OnPropertyChanged("RubberStampDN");
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

        public int PurchaseInvoiceID
        {
            get
            {
                return purchaseInvoiceID;
            }
            set
            {
                purchaseInvoiceID = value;
                OnPropertyChanged("PurchaseInvoiceID");
            }
        }

        public string PurchaseInvoiceNo
        {
            get { return purchaseInvoiceNo; }
            set { purchaseInvoiceNo = value;
                OnPropertyChanged("PurchaseInvoiceNo");
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
       
        public string DebitNo
        {
            get
            {
                return debitNo;
            }
            set
            {
                debitNo = value;
                OnPropertyChanged("DebitNo");
            }
        }

        public DateTime? DebitDate
        {
            get
            {
                return debitDate;
            }
            set
            {
                debitDate = value;
                OnPropertyChanged("DebitDate");
            }
        }
        public string SupplierCreditNoteNo
        {
            get { return supplierCreditNoteNo; }
            set { supplierCreditNoteNo = value;
                OnPropertyChanged("SupplierCreditNoteNo");
            }
        }

        private decimal? scnAmount;

        public decimal? SCNAmount
        {
            get { return scnAmount; }
            set { scnAmount = value;
                OnPropertyChanged("SCNAmount");
            }
        }

        public string SupplierCreditNoteAmount
        {
            get
            { 
                if (supplierCreditNoteAmount == null)
                    return this.supplierCreditNoteAmount;
                else
                {
                    if (supplierCreditNoteAmount != "")
                    {
                        var balance = supplierCreditNoteAmount.Replace(",", "");
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
                        return this.supplierCreditNoteAmount;
                }
            }
            set
            {
                supplierCreditNoteAmount = value;
                OnPropertyChanged("SupplierCreditNoteAmount");
            }
        }
        
        public DateTime? SupplierCreditNoteDate
        {
            get
            {
                return supplierCreditNoteDate;
            }
            set
            {
                supplierCreditNoteDate = value;
                OnPropertyChanged("SupplierCreditNoteDate");
            }
        }
        public string SupplierCreditNoteDateStr
        {
            get
            {
                return _SupplierCreditNoteDateStr;
            }
            set
            {
                _SupplierCreditNoteDateStr = value;
                OnPropertyChanged("SupplierCreditNoteDateStr");
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

        public byte? Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                OnPropertyChanged("Status");
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

    public class DebitNoteForm : ViewModelBase
    {
        private List<SupplierDetailEntity> lstSuppliers;
        private DebitNoteEntity dnote;


        private List<PurchaseInvoiceDetailEntity> invoiceDetails { get; set; }

        public DebitNoteEntity DebitNote
        {
            get
            {
                return dnote;
            }
            set
            {
                dnote = value;
                OnPropertyChanged("DebitNote");
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
