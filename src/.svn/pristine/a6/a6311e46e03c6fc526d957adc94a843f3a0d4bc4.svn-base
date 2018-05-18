
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Suppliers
{
    using SDN.Common;
    using System.Globalization;

    public class SuppliersUnpaidInvoicesEntity:ViewModelBase
    {
        #region "Private members"
        private DateTime? statementDate;
        private string statementDateStr;
        private List<SuppliersUnpaidInvoicesEntity> lstSuppliers;
        private List<SuppliersEntity> lstSuppliersCmb;
        private List<SuppliersInvoiceDetailsEntity> lstInvoiceDetails;
        private List<SuppliersBalanceEntity> lstBalances;
        private SuppliersStatementEntity balAndUnpaidInv;
        private int gridHeight;
        private int invoiceGridHeight;
        private int selectedSupplierID;
        private int supplierID;
        private string supplierName;
        private string _TaxName;
        private string _DateFormat;
        private string currencyName;
        private string totalInvoiceAmount;
        private string totalPaidAmount;
        private string totalDueAmount;
        private bool isSelected;
        #endregion

        #region "Public Properties"
        public DateTime? StatementDate
        {
            get { return statementDate; }
            set { statementDate = value;
                OnPropertyChanged("StatementDate");
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
        public  string CurrencyName
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
        public  int GridHeight
        {
            get { return gridHeight;
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

        public int SelectedSupplierID
        {
            get
            {
                return selectedSupplierID;
            }
            set
            {
                selectedSupplierID = value;
                OnPropertyChanged("SelectedSupplierID");
            }
        }
       
        public int SupplierID
        {
            get { return supplierID; }
            set
            {
                supplierID = value;
                OnPropertyChanged("SupplierID");
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
        public List<SuppliersUnpaidInvoicesEntity> LstSuppliers
        {
            get { return lstSuppliers; }
            set
            {
                lstSuppliers = value;
                OnPropertyChanged("LstSuppliers");
            }
        }


        public List<SuppliersEntity> LstSuppliersCmb
        {
            get { return lstSuppliersCmb; }
            set {
                lstSuppliersCmb = value;
                OnPropertyChanged("LstSuppliersCmb");
            }
        }
        public List<SuppliersInvoiceDetailsEntity> LstInvoiceDetails
        {
            get { return lstInvoiceDetails; }
            set
            {
                lstInvoiceDetails = value;
                OnPropertyChanged("LstInvoiceDetails");
            }
        }

        public List<SuppliersBalanceEntity> LstBalances
        {
            get { return lstBalances; }
            set
            {
                lstBalances = value;
                OnPropertyChanged("LstBalances");
            }
        }

        public SuppliersStatementEntity BalAndUnpaidInv
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

    public class SuppliersStatementEntity
    {

        public List<SuppliersBalanceEntity> LstBalances
        {
            get; set;
        }

        public List<SuppliersInvoiceDetailsEntity> LstInvoices
        {
            get; set;
        }
    }

    public class SuppliersBalanceEntity
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
            set { balance = value;
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

    public class SuppliersInvoiceDetailsEntity
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

    public class SuppliersEntity:ViewModelBase
    {
        private int supplierID;
        private string supplierName;
        private int selectedSupplierID;
      
        public int SupplierID
        {
            get { return supplierID; }
            set
            {
                supplierID = value;
                OnPropertyChanged("SupplierID");
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

        public int SelectedSupplierID
        {
            get
            {
                return selectedSupplierID;
            }
            set
            {
                selectedSupplierID = value;
                OnPropertyChanged("SelectedSupplierID");
            }
        }
    }
}
