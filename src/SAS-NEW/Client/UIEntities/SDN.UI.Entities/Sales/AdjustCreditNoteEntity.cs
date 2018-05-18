﻿using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Sales
{
    public class AdjustCreditNoteEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private List<CustomerEntity> _ListCustomers;
        private List<AccountsEntity> _AccountDetails;
        private List<AdjustCreditNoteEntity> _ListCreditNoteEntity;
        private DateTime? _Date;
        private string _CreditNoteNo;
        private string _AmountStr;
        private decimal? amount;
        private string _Remarks;
        private int? customerID;
        private int? accntId;
        private bool? isCheque;
        private int _PtSFGridHeight;
        private string _SalesNo;
        private string _TotalInvoiceAmount;
        private string _AdjustCreditNoteNumber;
        private DateTime? _AdjustCreditNoteDate;
        private string _AdjustCreditNoteDateStr;
        private string _TotalAmountPaid;
        private bool? _MustCompare;
        #endregion

        #region Public Properties

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
        public string AdjustCreditNoteNumber
        {
            get
            {
                return _AdjustCreditNoteNumber;
            }
            set
            {
                _AdjustCreditNoteNumber = value;
                OnPropertyChanged("AdjustCreditNoteNumber");
            }
        }
        public DateTime? AdjustCreditNoteDate
        {
            get
            {
                return _AdjustCreditNoteDate;
            }
            set
            {
                _AdjustCreditNoteDate = value;
                OnPropertyChanged("AdjustCreditNoteDate");
            }
        }
        public string AdjustCreditNoteDateStr
        {
            get
            {
                return _AdjustCreditNoteDateStr;
            }
            set
            {
                _AdjustCreditNoteDateStr = value;
                OnPropertyChanged("AdjustCreditNoteDateStr");
            }
        }
        public string TotalInvoiceAmount
        {
            get
            {
                if (_TotalInvoiceAmount == null)
                    return this._TotalInvoiceAmount;
                else
                {
                    if (_TotalInvoiceAmount != "")
                    {
                        var balance = _TotalInvoiceAmount.Replace(",", "");
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
                        return this._TotalInvoiceAmount;
                }
            }
            set
            {
                _TotalInvoiceAmount = value;
                OnPropertyChanged("TotalInvoiceAmount");
            }
        }
        public string TotalAmountPaid
        {
            get
            {
                if (_TotalAmountPaid == null)
                    return this._TotalAmountPaid;
                else
                {
                    if (_TotalAmountPaid != "")
                    {
                        var balance = _TotalAmountPaid.Replace(",", "");
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
                        return this._TotalAmountPaid;
                }
            }
            set
            {
                _TotalAmountPaid = value;
                OnPropertyChanged("TotalAmountPaid");
            }
        }
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }
        public List<CustomerEntity> ListCustomers
        {
            get
            {
                return _ListCustomers;
            }
            set
            {
                _ListCustomers = value;
                OnPropertyChanged("ListCustomers");
            }
        }
        public List<AdjustCreditNoteEntity> ListCreditNoteEntity
        {
            get
            {
                return _ListCreditNoteEntity;
            }
            set
            {
                _ListCreditNoteEntity = value;
                OnPropertyChanged("ListCreditNoteEntity");
            }
        }
        public List<AccountsEntity> AccountDetails
        {
            get
            {
                return _AccountDetails;
            }
            set
            {
                _AccountDetails = value;
                OnPropertyChanged("AccountDetails");
            }
        }

        public string CreditNoteNo
        {
            get { return _CreditNoteNo; }
            set
            {
                _CreditNoteNo = value;
                OnPropertyChanged("CreditNoteNo");
            }
        }
        public DateTime? Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
                OnPropertyChanged("Date");
            }
        }
        public string AmountStr
        {
            get
            {
                if (_AmountStr == null)
                    return this._AmountStr;
                else
                {
                    if (_AmountStr != "")
                    {
                        var balance = _AmountStr.Replace(",", "");
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
                        return this._AmountStr;
                }
            }
            set
            {
                _AmountStr = value;
                OnPropertyChanged("AmountStr");
            }
        }

        public bool? IsCheque
        {
            get
            {
                return isCheque;
            }
            set
            {
                isCheque = value;
                OnPropertyChanged("IsCheque");
            }
        }

        public decimal? Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public int? CustomerID
        {
            get { return customerID; }
            set
            {
                customerID = value;
                OnPropertyChanged("CustomerID");
            }
        }

        public int? AccountId
        {
            get { return accntId; }
            set
            {
                accntId = value;
                OnPropertyChanged("AccountId");
            }
        }
        public string Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
                OnPropertyChanged("Remarks");
            }
        }
        public int PtSFGridHeight
        {
            get
            {
                return _PtSFGridHeight;
            }
            set
            {
                _PtSFGridHeight = value;
                OnPropertyChanged("PtSFGridHeight");
            }
        }
        #endregion
    }

    public class AdjustCreditNoteForm : ViewModelBase
    {
        private List<CustomerEntity> lstCustomers;
        private AdjustCreditNoteEntity paymentToCustomer;


        private List<AdjustCreditNoteDetailsEntity> paymentToCustomerDetails { get; set; }

        public AdjustCreditNoteEntity AdjustCreditNote
        {
            get
            {
                return paymentToCustomer;
            }
            set
            {
                paymentToCustomer = value;
                OnPropertyChanged("AdjustCreditNote");
            }
        }

        public List<AdjustCreditNoteDetailsEntity> AdjustCreditNoteDetails
        {
            get
            {
                return paymentToCustomerDetails;
            }
            set
            {
                paymentToCustomerDetails = value;
                OnPropertyChanged("AdjustCreditNoteDetails");
            }
        }

        public List<CustomerEntity> LstCustomers
        {
            get
            {
                return lstCustomers;
            }
            set
            {
                lstCustomers = value;
                OnPropertyChanged("LstCustomers");
            }
        }
        public List<ContentModel> LstTermsAndConditions { get; set; }
    }

}