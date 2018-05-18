using SASClient.CashBank.Services;
using SDN.Common;
using SDN.Customers.Services;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.ViewModel
{
    
   public class AccountDataGridViewModel:ViewModelBase
    {
        private IReceiveMoneyRepository rmRepository = new ReceiveMoneyRepository();
        private ObservableCollection<AccountsEntity> accountList;
        ICustomerRepository customerRepository = new CustomerRepository();
        public ObservableCollection<AccountsEntity> AccountList
        {
            get
            {
                return accountList;
            }
            set
            {
                if (accountList != value)
                {
                    accountList = value;
                    OnPropertyChanged("AccountList");
                }
            }
        }
       // public  IAccountDetailsService accountRepository = new AccountDetailsService();


        public AccountDataGridViewModel(IEnumerable<AccountsEntity> accountList)
        {
            if (accountList == null)
            {
                accountList = rmRepository.GetAccountDetails().Where(t => t.AccountType == Convert.ToByte(Account_Type.Income)
                 || t.AccountType == Convert.ToByte(Account_Type.CurrentAssets) || t.AccountType == Convert.ToByte(Account_Type.FixedAssets)
                 || t.AccountType == Convert.ToByte(Account_Type.CurrentLiabilities) || t.AccountType == Convert.ToByte(Account_Type.LongTermLiabilities));
            }
            AccountList = new ObservableCollection<AccountsEntity>(accountList);
            TaxList = customerRepository.GetTaxCodeAndRatesList();
        }

        private int id;
        private string description;
        private int? selectedAccountId;
        private string selectedAccountName;
        private string amount;
        private decimal? gstRate;
        private string gstCode;
        private int? selectedTaxID;
        private decimal? amountBeforeTax;
        private decimal? taxAmount;
        private decimal? pqAmount;
        private int decimalPlaces;

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

        public int? SelectedAccountId
        {
            get { return selectedAccountId; }
            set
            {
                  selectedAccountId = value;
                    OnPropertyChanged("SelectedAccountId");
            }
        }
        public string SelectedAccountName
        {
            get { return selectedAccountName; }
            set
            {
                selectedAccountName = value;
                OnPropertyChanged("SelectedAccountName");
            }
        }
        public int? SelectedTaxID
        {
            get { return selectedTaxID; }

            set
            {
                selectedTaxID = value;
                OnPropertyChanged("SelectedTaxID");
                OnAmountChange();
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
                if (gstCode != value)
                {
                    gstCode = value;

                    OnPropertyChanged("GSTCode");
                }
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
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
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
                OnAmountChange();
            }

        }

        void OnAmountChange()
        {
           
            this.PQAmount = Convert.ToDecimal(PQAmountStr);
            this.AmountBeforeTax = PQAmount;
            if (SelectedTaxID != null)
            {
                var tax = TaxList.Where(e => e.TaxID == SelectedTaxID).FirstOrDefault();
                if (tax != null)
                {
                    this.TaxAmount = (PQAmount * tax.TaxRate)/100;
                }
                else
                {
                    this.TaxAmount = 0;
                }
            }
            AmountAfterTax = AmountBeforeTax + TaxAmount;
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
    }
}
