﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Sales
{
    using SDN.Common;
    using System.Globalization;

    public class AdjustCreditNoteDetailsEntity : ViewModelBase
    {
        #region "Private Members"
        private string salesNo;
        private DateTime? salesDate;
        private DateTime? paymentDueDate;
        private decimal? salesAmount;
        private string salesAmountStr;
        private string amountDueStr;
        private decimal? amountDue;
        private decimal? discount;
        private string amountAdjustedStr;
        private decimal? amountAdjusted;
        private bool? checkAmountAdjusted;
        private DateTime? _UpdatedDate;
        #endregion

        #region "Public Members"
        public string SalesNo
        {
            get { return salesNo; }
            set
            {
                salesNo = value;
                OnPropertyChanged("SalesNo");
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

        public DateTime? SalesDate
        {
            get { return salesDate; }
            set
            {
                salesDate = value;
                OnPropertyChanged("SalesDate");
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

        public decimal? SalesAmount
        {
            get { return salesAmount; }
            set
            {
                salesAmount = value;
                OnPropertyChanged("SalesAmount");
            }
        }

        public string SalesAmountStr
        {
            get
            {
                if (salesAmount == null)
                    return this.salesAmountStr;
                else
                {
                    if (salesAmountStr != "")
                    {
                        var balance = salesAmountStr.Replace(",", "");
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
                        return this.salesAmountStr;
                }
            }
            set
            {
                salesAmountStr = value;
                OnPropertyChanged("SalesAmountStr");
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