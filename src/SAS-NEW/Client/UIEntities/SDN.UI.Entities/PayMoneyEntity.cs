﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities
{
    using SDN.Common;
    using System.Globalization;

    public class PayMoneyEntity : ViewModelBase
    {
        #region "Private Properties"
        private int id;

        private List<AccountsEntity> cashAndBankAccountsLst;
        private List<AccountsEntity> linkedAccountsLst;
        private List<TaxModel> lstTaxes;
        private string cashChequeNo;
        private bool? _MustCompare;

        private DateTime? cashChequeDate;
        private string cashChequeDateStr;
        private string totalBeforeTaxStr;
        private decimal? totalBeforeTax;
        private string totalTaxStr;
        private decimal? totalTax;
        private string totalAfterTaxStr;
        private decimal? totalAfterTax;
        private string remarks;
        private int? selectedLinkedAcntID;
        private int? selectedCashBankAcntID;
        private int? selectedTaxID;
        private decimal? gstRate;
        private bool? isCheque;
        private string taxName;
        private string currencyName;

        #endregion

        #region "Public Properties"
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
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public List<AccountsEntity> CashAndBankAccountsLst
        {
            get { return cashAndBankAccountsLst; }
            set
            {
                cashAndBankAccountsLst = value;
                OnPropertyChanged("CashAndBankAccountsLst");
            }
        }

        public List<TaxModel> LstTaxes
        {
            get { return lstTaxes; }
            set
            {
                lstTaxes = value;
                OnPropertyChanged("LstTaxes");
            }
        }

        public List<AccountsEntity> LinkedAccountsLst
        {
            get { return linkedAccountsLst; }
            set
            {
                linkedAccountsLst = value;
                OnPropertyChanged("LinkedAccountsLst");
            }
        }

        public string CashChequeNo
        {
            get { return cashChequeNo; }
            set
            {
                cashChequeNo = value;
                OnPropertyChanged("CashChequeNo");
            }
        }
        public DateTime? CashChequeDate
        {
            get { return cashChequeDate; }
            set
            {
                cashChequeDate = value;
                OnPropertyChanged("CashChequeDate");
            }
        }
        public string CashChequeDateStr
        {
            get { return cashChequeDateStr; }
            set
            {
                cashChequeDateStr = value;
                OnPropertyChanged("CashChequeDateStr");
            }
        }
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
                        decimal balance = 0;
                        bool isValid = decimal.TryParse(totalBeforeTaxStr.Replace(",", ""),out balance);
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
                        decimal balance = 0;
                        bool isValid = decimal.TryParse(totalTaxStr.Replace(",", ""), out balance);                        
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
        public decimal? TotalTax
        {
            get { return totalTax; }
            set
            {
                totalTax = value;
                OnPropertyChanged("TotalTax");
            }

        }
        public string TotalAfterTaxStr
        {
            get
            {

                if (totalAfterTaxStr == null)
                    return this.totalAfterTaxStr;
                else
                {
                    if (totalAfterTaxStr != "")
                    {
                        //var balance = totalAfterTaxStr.Replace(",", "");
                        decimal balance = 0;
                        bool isValid = decimal.TryParse(totalAfterTaxStr.Replace(",", ""), out balance);
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
        public decimal? TotalAfterTax
        {
            get { return totalAfterTax; }
            set
            {
                totalAfterTax = value;
                OnPropertyChanged("TotalAfterTax");
            }
        }
        public string Remarks
        {
            get { return remarks; }
            set
            {
                remarks = value;
                OnPropertyChanged("Remarks");
            }
        }

        public int? SelectedLinkedAcntID
        {
            get { return selectedLinkedAcntID; }
            set
            {
                selectedLinkedAcntID = value;
                OnPropertyChanged("SelectedLinkedAcntID");
            }
        }
        public int? SelectedCashBankAcntID
        {
            get { return selectedCashBankAcntID; }
            set
            {
                selectedCashBankAcntID = value;
                OnPropertyChanged("SelectedCashBankAcntID");
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
        public decimal? TaxRate
        {
            get { return gstRate; }
            set
            {
                gstRate = value;
                OnPropertyChanged("TaxRate");
            }
        }

        public bool? IsCheque
        {
            get { return isCheque; }
            set
            {
                isCheque = value;
                OnPropertyChanged("IsCheque");
            }
        }

        public string TaxName
        {
            get { return taxName; }
            set
            {
                taxName = value;
                OnPropertyChanged("TaxName");
            }
        }
        public string CurrencyName
        {
            get { return currencyName; }
            set
            {
                currencyName = value;
                OnPropertyChanged("CurrencyName");
            }
        }

        #endregion
    }
}
