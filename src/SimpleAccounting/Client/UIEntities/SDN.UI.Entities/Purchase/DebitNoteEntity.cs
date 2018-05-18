﻿
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
        private List<SupplierDetailEntity> lstSuppliers;
        private int supId;
        private string debitNo;
        private DateTime? debitDate;
        private string supplierCreditNoteNo;
        private DateTime? supplierCreditNoteDate;
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
        #endregion

        #region "Public members"

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
