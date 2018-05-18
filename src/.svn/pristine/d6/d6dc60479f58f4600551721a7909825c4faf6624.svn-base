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

    public class PurchaseOrderEntity : BaseEntity
    {
        #region "Private members"
        private int id;
        private bool? _MustCompare;

        private List<SupplierDetailEntity> lstSuppliers;
        private int supId;
        private string orderNo;
        private string purchaseInvoiceNo;
        private DateTime orderDate;
        private DateTime deliveryDate;
        private int? validForDays;
        private List<PandSDetailsModel> lstPandS;
        private List<ContentModel> lstContents;
        private string _OrderDateStr;
        private string _DeliveryDateStr;
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
        private ObservableCollection<PurchaseOrderDetailEntity> poDetailsEntity;
        private PurchaseOrderDetailEntity poEntity;
        private int? createdBy;
        private DateTime? createdDate;
        private string shipToAddress;
        private string billToAddress;
        private bool? po_Conv_to_PO;
        private bool? po_Conv_to_PI;
        private bool? excIncGST;
        private int _POFormGridHeight;
        private string sup_Balance;
        private bool? _RubberStampPI;
        private string sup_CreditLimitAmount;

        //private string shipToAddress;
        //private string billToAddress;
        private byte? piStatus;
        //private bool? excIncGST;
        private string ourSONo;
        private int? salesmanID;
        private int _SIFormGridHeight;
        private int _SortInvoiceId;
        //private string sup_Balance;
        //private string sup_CreditLimitAmount;
        private string _SupplierName;
        private string _SupplierBillAddress1;
        private string _SupplierBillAddress2;
        private string _SupplierBillAddressCity;
        private string _SupplierBillAddressState;
        private string _SupplierBillAddressCountary;
        private string _SupplierBillPostCode;
        private string _SupplierShipAddress1;
        private string _SupplierShipAddress2;
        private string _SupplierShipAddressCity;
        private string _SupplierShipAddressState;
        private string _SupplierShipAddressCountary;
        private string _SupplierShipPostCode;
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
        private string _CompanyShipToAddressLine1;
        private string _CompanyShipToAddressLine2;
        private string _CompanyShipToCity;
        private string _CompanyShipToState;
        private string _CompanyShipToCountary;
        private string _CompanyShipToPostCode;
        private string _CurrencyCode;
        //private BitmapSource _CompanyLogo;
        private byte[] _CompanyLogo;
        #endregion

        #region "Public members"
        #region "company entity"
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
        public string CompanyShipToAddressLine1
        {
            get
            {
                return _CompanyShipToAddressLine1;
            }
            set
            {
                _CompanyShipToAddressLine1 = value;
                OnPropertyChanged("CompanyShipToAddressLine1");
            }
        }
        public string CompanyShipToAddressLine2
        {
            get
            {
                return _CompanyShipToAddressLine2;
            }
            set
            {
                _CompanyShipToAddressLine2 = value;
                OnPropertyChanged("CompanyShipToAddressLine2");
            }
        }
        public string CompanyShipToCity
        {
            get
            {
                return _CompanyShipToCity;
            }
            set
            {
                _CompanyShipToCity = value;
                OnPropertyChanged("CompanyShipToCity");
            }
        }
        public string CompanyShipToState
        {
            get
            {
                return _CompanyShipToState;
            }
            set
            {
                _CompanyShipToState = value;
                OnPropertyChanged("CompanyShipToState");
            }
        }
        public string CompanyShipToCountary
        {
            get
            {
                return _CompanyShipToCountary;
            }
            set
            {
                _CompanyShipToCountary = value;
                OnPropertyChanged("CompanyShipToCountary");
            }
        }
        public string CompanyShipToPostCode
        {
            get
            {
                return _CompanyShipToPostCode;
            }
            set
            {
                _CompanyShipToPostCode = value;
                OnPropertyChanged("CompanyShipToPostCode");
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
        #endregion
        #region "options entity"
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
        public string SupplierBillAddress2
        {
            get
            {
                return _SupplierBillAddress2;
            }
            set
            {
                _SupplierBillAddress2 = value;
                OnPropertyChanged("SupplierBillAddress2");
            }

        }
        public string SupplierBillAddressCity
        {
            get
            {
                return _SupplierBillAddressCity;
            }
            set
            {
                _SupplierBillAddressCity = value;
                OnPropertyChanged("CSupplierBillAddressCity");
            }
        }
        public string SupplierBillAddressState
        {
            get
            {
                return _SupplierBillAddressState;
            }
            set
            {
                _SupplierBillAddressState = value;
                OnPropertyChanged("SupplierBillAddressState");
            }
        }
        public string SupplierBillAddressCountary
        {
            get
            {
                return _SupplierBillAddressCountary;
            }
            set
            {
                _SupplierBillAddressCountary = value;
                OnPropertyChanged("SupplierBillAddressCountary");
            }
        }
        public string SupplierBillPostCode
        {
            get
            {
                return _SupplierBillPostCode;
            }
            set
            {
                _SupplierBillPostCode = value;
                OnPropertyChanged("SupplierBillPostCode");
            }
        }
        public string SupplierShipAddress1
        {
            get
            {
                return _SupplierShipAddress1;
            }
            set
            {
                _SupplierShipAddress1 = value;
                OnPropertyChanged("SupplierShipAddress1");
            }
        }
        public string SupplierShipAddress2
        {
            get
            {
                return _SupplierShipAddress2;
            }
            set
            {
                _SupplierShipAddress2 = value;
                OnPropertyChanged("SupplierShipAddress2");
            }
        }
        public string SupplierShipAddressCity
        {
            get
            {
                return _SupplierShipAddressCity;
            }
            set
            {
                _SupplierShipAddressCity = value;
                OnPropertyChanged("SupplierShipAddressCity");
            }
        }
        public string SupplierShipAddressState
        {
            get
            {
                return _SupplierShipAddressState;
            }
            set
            {
                _SupplierShipAddressState = value;
                OnPropertyChanged("SupplierShipAddressState");
            }
        }
        public string SupplierShipAddressCountary
        {
            get
            {
                return _SupplierShipAddressCountary;
            }
            set
            {
                _SupplierShipAddressCountary = value;
                OnPropertyChanged("SupplierShipAddressCountary");
            }
        }
        public string SupplierShipPostCode
        {
            get
            {
                return _SupplierShipPostCode;
            }
            set
            {
                _SupplierShipPostCode = value;
                OnPropertyChanged("SupplierShipPostCode");
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
        public string SupplierBillAddress1
        {
            get
            {
                return _SupplierBillAddress1;
            }
            set
            {
                _SupplierBillAddress1 = value;
                OnPropertyChanged("SupplierBillAddress1");
            }
        }
        private byte? status;

        public byte? Status
        {
            get { return status; }
            set { status = value;
                OnPropertyChanged("Status");
            }
        }

        public int POFormGridHeight
        {
            get
            {
                return _POFormGridHeight;
            }
            set
            {
                _POFormGridHeight = value;
                OnPropertyChanged("POFormGridHeight");
            }
        }
        public bool? RubberStampPI
        {
            get
            {
                return _RubberStampPI;
            }
            set
            {
                _RubberStampPI = value;
                OnPropertyChanged("RubberStampPI");
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

        public PurchaseOrderDetailEntity POEntity
        {
            get
            {
                return poEntity;
            }
            set
            {
                poEntity = value;
                OnPropertyChanged("POEntity");
            }
        }
        public bool? PO_Conv_to_PO
        {
            get
            {
                return po_Conv_to_PO;
            }
            set
            {
                po_Conv_to_PO = value;
                OnPropertyChanged("PO_Conv_to_PO");
            }
        }
        public bool? PO_Conv_to_PI
        {
            get
            {
                return po_Conv_to_PI;
            }
            set
            {
                po_Conv_to_PI = value;
                OnPropertyChanged("PO_Conv_to_PI");
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

        public string OrderNo
        {
            get
            {
                return orderNo;
            }
            set
            {
                orderNo = value;
                OnPropertyChanged("OrderNo");
            }
        }
        public string PurchaseInvoiceNo
        {
            get
            {
                return purchaseInvoiceNo;
            }
            set
            {
                purchaseInvoiceNo = value;
                OnPropertyChanged("PurchaseInvoiceNo");
            }
        }
        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }
            set
            {
                orderDate = value;
                OnPropertyChanged("OrderDate");
            }
        }
        public string OrderDateStr
        {
            get
            {
                return _OrderDateStr;
            }
            set
            {
                _OrderDateStr = value;
                OnPropertyChanged("OrderDateStr");
            }
        }
        public string DeliveryDateStr
        {
            get
            {
                return _DeliveryDateStr;
            }
            set
            {
                _DeliveryDateStr = value;
                OnPropertyChanged("DeliveryDateStr");
            }
        }
        public DateTime DeliveryDate
        {
            get
            {
                return deliveryDate;
            }
            set
            {
                deliveryDate = value;
                OnPropertyChanged("DeliveryDate");
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
                //return _OrderAmount;
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
                //return _OrderAmount;
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
                //return _OrderAmount;
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

        //public ObservableCollection<PurchaseOrderDetailEntity> PODetailsEntity
        //{
        //    get
        //    {
        //        return poDetailsEntity=new ObservableCollection<PurchaseOrderDetailEntity>();
        //    }
        //    set
        //    {
        //        poDetailsEntity = value;
        //        OnPropertyChanged("PODetailsEntity");
        //    }
        //}

        #endregion


    }
    public class PurchaseOrderForm : ViewModelBase
    {
        private List<SupplierDetailEntity> lstSuppliers;
        private PurchaseOrderEntity order;


        private List<PurchaseOrderDetailEntity> orderDetails { get; set; }

        public PurchaseOrderEntity Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
                OnPropertyChanged("Order");
            }
        }

        public List<PurchaseOrderDetailEntity> OrderDetails
        {
            get
            {
                return orderDetails;
            }
            set
            {
                orderDetails = value;
                OnPropertyChanged("OrderDetails");
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
