
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Purchase
{
    using SDN.Common;
    using System.Globalization;

    public class AdjustDebitNoteDetailsEntity : ViewModelBase
    {
        #region "Private Members"
        private string purchaseNo;
        private DateTime? purchaseDate;
        private DateTime? paymentDueDate;
        private decimal? purchaseAmount;
        private string purchaseAmountStr;
        private string amountDueStr;
        private decimal? amountDue;
        private decimal? discount;
        private string amountAdjustedStr;
        private decimal? amountAdjusted;
        private bool? checkAmountAdjusted;
        private DateTime? _UpdatedDate;
        #endregion

        #region "Public Members"
        public string PurchaseNo
        {
            get { return purchaseNo; }
            set
            {
                purchaseNo = value;
                OnPropertyChanged("PurchaseNo");
            }
        }
        public bool? CheckAmountAdjusted
        {
            get { return checkAmountAdjusted; }
            set
            {
                checkAmountAdjusted = value;
                OnPropertyChanged("CheckAmountAdjusted");
            }
        }
        public DateTime? UpdatedDate
        {
            get { return _UpdatedDate; }
            set
            {
                _UpdatedDate = value;
                OnPropertyChanged("UpdatedDate");
            }
        }
        public DateTime? PurchaseDate
        {
            get { return purchaseDate; }
            set
            {
                purchaseDate = value;
                OnPropertyChanged("PurchaseDate");
            }
        }
        public DateTime? PaymentDueDate
        {
            get { return paymentDueDate; }
            set
            {
                paymentDueDate = value;
                OnPropertyChanged("PaymentDueDate");
            }
        }

        public decimal? PurchaseAmount
        {
            get { return purchaseAmount; }
            set
            {
                purchaseAmount = value;
                OnPropertyChanged("PurchaseAmount");
            }
        }

        public string PurchaseAmountStr
        {
            get
            {
                if (purchaseAmount == null)
                    return this.purchaseAmountStr;
                else
                {
                    if (purchaseAmountStr != "")
                    {
                        var balance = purchaseAmountStr.Replace(",", "");
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
                        return this.purchaseAmountStr;
                }
            }
            set
            {
                purchaseAmountStr = value;
                OnPropertyChanged("PurchaseAmountStr");
            }
        }

        public decimal? AmountDue
        {
            get { return amountDue; }
            set
            {
                amountDue = value;
                OnPropertyChanged("AmountDue");
            }
        }

        public string AmountDueStr
        {
            get
            {
                if (amountDueStr == null)
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
                OnPropertyChanged("AmountDueStr");
            }
        }

        public decimal? Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                OnPropertyChanged("Discount");
            }
        }

        public decimal? AmountAdjusted
        {
            get { return amountAdjusted; }
            set
            {
                amountAdjusted = value;
                OnPropertyChanged("AmountAdjusted");
            }
        }

        public string AmountAdjustedStr
        {
            get
            {
                if (amountAdjustedStr == null)
                    return this.amountAdjustedStr;
                else
                {
                    if (amountAdjustedStr != "")
                    {
                        var balance = amountAdjustedStr.Replace(",", "");
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
                        return this.amountAdjustedStr;
                }
            }
            set
            {
                amountAdjustedStr = value;
                OnPropertyChanged("AmountAdjustedStr");
            }
        }
        #endregion
    }
}
