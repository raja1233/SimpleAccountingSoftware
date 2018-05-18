
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

    public class PurchaseInvoiceBEDetailsEntity:ViewModelBase
    {
        #region "Private Properties"
        private int id;
        private string description;
        private int? selectedAccountId;
        private string accountName;
        private string amount;
        private decimal? gstRate;
        private string gstCode;
        private int? selectedTaxID;
        private decimal? amountBeforeTax;
        private decimal? taxAmount;
        private decimal? pqAmount;
        private int decimalPlaces;
        private string piType;
        public int ID
        {

            get { return id; }

            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("ID");
                }
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
        public string AccountName
        {
            get { return accountName; }
            set
            {
                accountName = value;
                OnPropertyChanged("AccountName");
            }
        }

        public int? SelectedAccountId
        {
            get { return selectedAccountId; }

            set
            {
                selectedAccountId = value;
                OnPropertyChanged("SelectedAccountId");

            }
        }

        public int? SelectedTaxID
        {
            get { return selectedTaxID; }
            set
            {
                selectedTaxID = value;
                OnPropertyChanged("SelectedTaxID");

            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Amount
        {
            get
            {
                if (amount == null)
                    return this.amount;
                else
                {
                    if (amount != "")
                    {
                        var balance = amount.Replace(",", "");
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
                        return this.amount;
                }
            }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }

        }

        public List<TaxModel> taxList;
        public List<TaxModel> TaxList
        {
            get
            {
                return taxList;
            }
            set
            {
                taxList = value;
                OnPropertyChanged("TaxList");
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
                if (gstRate != value)
                {
                    gstRate = value;

                    OnPropertyChanged("GSTRate");
                }
            }
        }
        public decimal? PQAmount
        {
            get
            {
                return pqAmount;
            }
            set
            {
                if (pqAmount != value)
                {
                    pqAmount = value;
                    OnPropertyChanged("PQAmount");
                }
            }
        }
        private string pqAmountStr;
        public string PQAmountStr
        {
            get
            {
                if (pqAmountStr == null)
                    return this.pqAmountStr;
                else
                {
                    if (pqAmountStr != "")
                    {
                        var balance = pqAmountStr.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new System.Globalization.CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                    }
                    else
                        return this.pqAmountStr;
                }
            }
            set
            {
                pqAmountStr = value;
                OnPropertyChanged("PQAmountStr");
            }

        }

        public decimal? AmountBeforeTax
        {
            get
            {
                return amountBeforeTax;
            }
            set
            {
                if (amountBeforeTax != value)
                {
                    amountBeforeTax = value;
                    OnPropertyChanged("AmountBeforeTax");
                }
            }
        }
        private decimal? amountAfterTax;
        public decimal? AmountAfterTax
        {
            get
            {
                return amountAfterTax;
            }
            set
            {
                if (amountAfterTax != value)
                {
                    amountAfterTax = value;
                    OnPropertyChanged("AmountAfterTax");
                }
            }
        }
        public decimal? TaxAmount
        {
            get
            {
                return taxAmount;
            }
            set
            {
                if (taxAmount != value)
                {
                    taxAmount = value;
                    OnPropertyChanged("TaxAmount");
                }
            }
        }

        #endregion "End Private Properties"

        #region "Constructors"

        public PurchaseInvoiceBEDetailsEntity()
        {

        }
        
        #endregion
    }
}
