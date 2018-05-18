
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Customers
{
    using SDN.Common;
    using System.Globalization;

    public class CustomersUnpaidInvoicesEntity : ViewModelBase
    {
        #region "Private members"
        private DateTime? statementDate;
        private string statementDateStr;
        private List<CustomersUnpaidInvoicesEntity> lstCustomers;
        private List<CustomersEntity> lstCustomersCmb;
        private List<CustomersInvoiceDetailsEntity> lstInvoiceDetails;
        private List<CustomersBalanceEntity> lstBalances;
        private CustomersStatementEntity balAndUnpaidInv; 
        private int gridHeight;
        private int invoiceGridHeight;
        private int selectedCustomerID;
        private int supplierID;
        private string supplierName;
        private string _TaxName;
        private string _DateFormat;
        private string currencyName;
        private string totalInvoiceAmount;
        private string totalPaidAmount;
        private string totalDueAmount;
        private bool isSelected;
        private string _CustomerName;
      
        private string _customerBillAddress1;
        private string _customerBillAddress2;
        private string _customerBillAddressCity;
        private string _customerBillAddressState;
        private string _customerBillAddressCountary;
        private string _CustomerBillPostCode;
        private string _CustomerTelephone;
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
        //private BitmapSource _CompanyLogo;
        private byte[] _CompanyLogo;

        #endregion
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
        #region "customer Entity"
       
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        public string CustomerBillAddress1
        {
            get
            {
                return _customerBillAddress1;
            }
            set
            {
                _customerBillAddress1 = value;
                OnPropertyChanged("CustomerBillAddress1");
            }

        }
        public string CustomerBillAddress2
        {
            get
            {
                return _customerBillAddress2;
            }
            set
            {
                _customerBillAddress2 = value;
                OnPropertyChanged("CustomerBillAddress2");
            }

        }
        public string CustomerBillAddressCity
        {
            get
            {
                return _customerBillAddressCity;
            }
            set
            {
                _customerBillAddressCity = value;
                OnPropertyChanged("CcustomerBillAddressCity");
            }
        }
        public string CustomerBillAddressState
        {
            get
            {
                return _customerBillAddressState;
            }
            set
            {
                _customerBillAddressState = value;
                OnPropertyChanged("CustomerBillAddressState");
            }
        }
        public string CustomerBillAddressCountary
        {
            get
            {
                return _customerBillAddressCountary;
            }
            set
            {
                _customerBillAddressCountary = value;
                OnPropertyChanged("CustomerBillAddressCountary");
            }
        }
        public string CustomerBillPostCode
        {
            get
            {
                return _CustomerBillPostCode;
            }
            set
            {
                _CustomerBillPostCode = value;
                OnPropertyChanged("CustomerBillPostCode");
            }
        }
        public string CustomerTelephone
        {
            get
            {
                return _CustomerTelephone;
            }
            set
            {
                _CustomerTelephone = value;
                OnPropertyChanged("CustomerTelephone");
            }
        }
        #endregion
        #region "Public Properties"
        public DateTime? StatementDate
        {
            get { return statementDate; }
            set
            {
                statementDate = value;
                OnPropertyChanged("StatementDate");
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
        public string TaxName
        {
            get
            {
                return _TaxName;
            }
            set
            {
                _TaxName = value;
                OnPropertyChanged("TaxName");
            }
        }
      
        public string DateFormat
        {
            get { return _DateFormat; }
            set { SetProperty(ref _DateFormat, value, "DateFormat"); }
        }
        public int GridHeight
        {
            get
            {
                return gridHeight;
            }
            set
            {
                gridHeight = value;
                OnPropertyChanged("GridHeight");
            }
        }
        public int InvoiceGridHeight
        {
            get
            {
                return invoiceGridHeight;
            }
            set
            {
                invoiceGridHeight = value;
                OnPropertyChanged("InvoiceGridHeight");
            }
        }

        public string StatementDateStr
        {
            get { return statementDateStr; }
            set
            {
                statementDateStr = value;
                OnPropertyChanged("StatementDateStr");
            }
        }

        public int SelectedCustomerID
        {
            get
            {
                return selectedCustomerID;
            }
            set
            {
                selectedCustomerID = value;
                OnPropertyChanged("SelectedCustomerID");
            }
        }

        public int CustomerID
        {
            get { return supplierID; }
            set
            {
                supplierID = value;
                OnPropertyChanged("CustomerID");
            }
        }
        public string SupplierName
        {
            get { return supplierName; }
            set
            {
                supplierName = value;
                OnPropertyChanged("SupplierName");
            }
        }

        public string TotalInvoiceAmount
        {
            get
            {
                if (totalInvoiceAmount == null)
                    return this.totalInvoiceAmount;
                else
                {
                    if (totalInvoiceAmount != "")
                    {
                        var balance = totalInvoiceAmount.Replace(",", "");
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
                        return this.totalInvoiceAmount;
                }
            }
            set
            {
                totalInvoiceAmount = value;
                OnPropertyChanged("TotalInvoiceAmount");
            }
        }
        public string TotalPaidAmount
        {
            get
            {
                if (totalPaidAmount == null)
                    return this.totalPaidAmount;
                else
                {
                    if (totalPaidAmount != "")
                    {
                        var balance = totalPaidAmount.Replace(",", "");
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
                        return this.totalPaidAmount;
                }
            }
            set
            {
                totalPaidAmount = value;
                OnPropertyChanged("TotalPaidAmount");
            }
        }
        public string TotalDueAmount
        {
            get
            {
                if (totalDueAmount == null)
                    return this.totalDueAmount;
                else
                {
                    if (totalDueAmount != "")
                    {
                        var balance = totalDueAmount.Replace(",", "");
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
                        return this.totalDueAmount;
                }
            }
            set
            {
                totalDueAmount = value;
                OnPropertyChanged("TotalDueAmount");
            }
        }
        public List<CustomersUnpaidInvoicesEntity> LstCustomers
        {
            get { return lstCustomers; }
            set
            {
                lstCustomers = value;
                OnPropertyChanged("LstCustomers");
            }
        }
          public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
      
        public List<CustomersEntity> LstCustomersCmb
        {
            get { return lstCustomersCmb; }
            set
            {
                lstCustomersCmb = value;
                OnPropertyChanged("LstCustomersCmb");
            }
        }
        public List<CustomersInvoiceDetailsEntity> LstInvoiceDetails
        {
            get { return lstInvoiceDetails; }
            set
            {
                lstInvoiceDetails = value;
                OnPropertyChanged("LstInvoiceDetails");
            }
        }

        public List<CustomersBalanceEntity> LstBalances
        {
            get { return lstBalances; }
            set
            {
                lstBalances = value;
                OnPropertyChanged("LstBalances");
            }
        }

        public CustomersStatementEntity BalAndUnpaidInv
        {
            get { return balAndUnpaidInv; }
            set
            {
                balAndUnpaidInv = value;
                OnPropertyChanged("BalAndUnpaidInv");
            }
        }

        #endregion
    }

    public class CustomersStatementEntity 
    {
        private CustomersUnpaidInvoicesEntity _InvoiceData;
        public List<CustomersBalanceEntity> LstBalances
        {
            get; set;
        }

        public List<CustomersInvoiceDetailsEntity> LstInvoices
        {
            get; set;
        }
        public CustomersUnpaidInvoicesEntity InvoiceData
        {
            get; set;
        }
    }

    public class CustomersBalanceEntity
    {
        #region "Private Members"
        private decimal? balance;
        private string balanceStr;
        private decimal? oneto30Days;
        private string oneto30DaysStr;
        private decimal? thirtyoneto60Days;
        private string thirtyoneto60DaysStr;
        private decimal? sixtyoneto90Days;
        private string sixtyoneto90DaysStr;
        private decimal? greaterThen90Days;
        private string greaterThen90DaysStr;
       
        #endregion

        #region "Properties"
        public decimal? Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                // OnPropertyChanged("Balance");
            }
        }
        
        public string BalanceStr
        {
            get
            {
                if (balanceStr == null)
                    return this.balanceStr;
                else
                {
                    if (balanceStr != "")
                    {
                        var balance = balanceStr.Replace(",", "");
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
                        return this.balanceStr;
                }
            }
            set
            {
                balanceStr = value;
                //OnPropertyChanged("BalanceStr");
            }
        }
        public decimal? Oneto30Days
        {
            get { return oneto30Days; }
            set
            {
                oneto30Days = value;
                // OnPropertyChanged("Oneto30Days");
            }
        }
        public string Oneto30DaysStr
        {
            get
            {
                if (oneto30DaysStr == null)
                    return this.oneto30DaysStr;
                else
                {
                    if (oneto30DaysStr != "")
                    {
                        var balance = oneto30DaysStr.Replace(",", "");
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
                        return this.oneto30DaysStr;
                }
            }
            set
            {
                oneto30DaysStr = value;
                //OnPropertyChanged("Oneto30DaysStr");
            }
        }
        public decimal? Thirtyoneto60Days
        {
            get { return thirtyoneto60Days; }
            set
            {
                thirtyoneto60Days = value;
                // OnPropertyChanged("Thirtyoneto60Days");
            }
        }
        public string Thirtyoneto60DaysStr
        {
            get
            {
                if (thirtyoneto60DaysStr == null)
                    return this.thirtyoneto60DaysStr;
                else
                {
                    if (thirtyoneto60DaysStr != "")
                    {
                        var balance = thirtyoneto60DaysStr.Replace(",", "");
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
                        return this.thirtyoneto60DaysStr;
                }
            }
            set
            {
                thirtyoneto60DaysStr = value;
                //  OnPropertyChanged("Thirtyoneto60DaysStr");
            }
        }
        public decimal? Sixtyoneto90Days
        {
            get { return sixtyoneto90Days; }
            set
            {
                sixtyoneto90Days = value;
                //OnPropertyChanged("Sixtyoneto90Days");
            }
        }
        public string Sixtyoneto90DaysStr
        {
            get
            {
                if (sixtyoneto90DaysStr == null)
                    return this.sixtyoneto90DaysStr;
                else
                {
                    if (sixtyoneto90DaysStr != "")
                    {
                        var balance = sixtyoneto90DaysStr.Replace(",", "");
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
                        return this.sixtyoneto90DaysStr;
                }
            }
            set
            {
                sixtyoneto90DaysStr = value;
                //  OnPropertyChanged("Sixtyoneto90DaysStr");
            }
        }
        public decimal? GreaterThen90Days
        {
            get { return greaterThen90Days; }
            set
            {
                greaterThen90Days = value;
                //OnPropertyChanged("GreaterThen90Days");
            }
        }
        public string GreaterThen90DaysStr
        {
            get
            {
                if (greaterThen90DaysStr == null)
                    return this.greaterThen90DaysStr;
                else
                {
                    if (greaterThen90DaysStr != "")
                    {
                        var balance = greaterThen90DaysStr.Replace(",", "");
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
                        return this.greaterThen90DaysStr;
                }
            }
            set
            {
                greaterThen90DaysStr = value;
                // OnPropertyChanged("GreaterThen90DaysStr");
            }
        }

        #endregion
    }

    public class CustomersInvoiceDetailsEntity
    {

        private string invoiceNo;
        private DateTime? invoiceDate;
        private string invoiceDateStr;
        private decimal? invoiceAmount;
        private string invoiceAmountStr;
        private DateTime? paymentDueDate;
        private string paymentDueDateStr;
        private decimal? amountPaid;
        private decimal? amountDue;
        private string amountPaidStr;
        private string amountDueStr;
       
        public string InvoiceNo
        {
            get { return invoiceNo; }
            set
            {
                invoiceNo = value;
                // OnPropertyChanged("InvoiceNo");
            }
        }
     
        public DateTime? InvoiceDate
        {
            get { return invoiceDate; }
            set
            {
                invoiceDate = value;
                // OnPropertyChanged("InvoiceDate");
            }
        }

        public string InvoiceDateStr
        {
            get { return invoiceDateStr; }
            set
            {
                invoiceDateStr = value;
                // OnPropertyChanged("InvoiceDateStr");
            }
        }

        public decimal? InvoiceAmount
        {
            get { return invoiceAmount; }
            set
            {
                invoiceAmount = value;
                //  OnPropertyChanged("InvoiceAmount");
            }
        }
        public string InvoiceAmountStr
        {
            get
            {
                if (invoiceAmount == null)
                    return this.invoiceAmountStr;
                else
                {
                    if (invoiceAmountStr != "")
                    {
                        var balance = invoiceAmountStr.Replace(",", "");
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
                        return this.invoiceAmountStr;
                }
            }
            set
            {
                invoiceAmountStr = value;
                // OnPropertyChanged("InvoiceAmountStr");
            }
        }

        public string PaymentDueDateStr
        {
            get { return paymentDueDateStr; }
            set
            {
                paymentDueDateStr = value;
                //  OnPropertyChanged("PaymentDueDateStr");
            }
        }
        public DateTime? PaymentDueDate
        {
            get { return paymentDueDate; }
            set
            {
                paymentDueDate = value;
                //  OnPropertyChanged("PaymentDueDate");
            }
        }
        public decimal? AmountPaid
        {
            get
            {
                return amountPaid;
            }
            set
            {
                amountPaid = value;
            }
        }
        public decimal? AmountDue
        {
            get
            {
                return amountDue;
            }
            set
            {
                amountDue = value;
            }
        }
        public string AmountPaidStr
        {
            get
            {
                if (amountPaidStr == null)
                    return this.amountPaidStr;
                else
                {
                    if (amountPaidStr != "")
                    {
                        var balance = amountPaidStr.Replace(",", "");
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
                        return this.amountPaidStr;
                }
            }
            set
            {
                amountPaidStr = value;
                // OnPropertyChanged("AmountPaidStr");
            }
        }
        public string AmountDueStr
        {
            get
            {
                if (amountDue == null)
                    return this.amountDueStr;
                else
                {
                    if (amountDueStr != "")
                    {
                        var balance = amountDueStr.Replace(",", "");
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
                        return this.amountDueStr;
                }
            }
            set
            {
                amountDueStr = value;
                // OnPropertyChanged("AmountDueStr");
            }
        }
    }

    public class CustomersEntity : ViewModelBase
    {
        private int supplierID;
        private string supplierName;
        private int selectedCustomerID;
     
        public int CustomerID
        {
            get { return supplierID; }
            set
            {
                supplierID = value;
                OnPropertyChanged("CustomerID");
            }
        }
      
        public string CustomerName
        {
            get { return supplierName; }
            set
            {
                supplierName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        public int SelectedCustomerID
        {
            get
            {
                return selectedCustomerID;
            }
            set
            {
                selectedCustomerID = value;
                OnPropertyChanged("SelectedCustomerID");
            }
        }
    }
}
