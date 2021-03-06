﻿using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Purchase
{
    public class AdjustDebitNoteEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private List<SupplierDetailEntity> _ListSuppliers;
        private List<AccountsEntity> _AccountDetails;
        private List<AdjustDebitNoteEntity> _ListDebitNoteEntity;
        private DateTime? _Date;
        private string _DebitNoteNo;
        private string _AmountStr;
        private decimal? amount;
        private string _Remarks;
        private int? supplierID;
        private int? accntId;
        private bool? isCheque;
        private int _PtSFGridHeight;
        private string _PurchaseNo;


        #endregion

        #region Public Properties
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
        public List<SupplierDetailEntity> ListSuppliers
        {
            get
            {
                return _ListSuppliers;
            }
            set
            {
                _ListSuppliers = value;
                OnPropertyChanged("ListSuppliers");
            }
        }
        public List<AdjustDebitNoteEntity> ListDebitNoteEntity
        {
            get
            {
                return _ListDebitNoteEntity;
            }
            set
            {
                _ListDebitNoteEntity = value;
                OnPropertyChanged("ListDebitNoteEntity");
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

        public string DebitNoteNo
        {
            get { return _DebitNoteNo; }
            set
            {
                _DebitNoteNo = value;
                OnPropertyChanged("DebitNoteNo");
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

        public int? SupplierID
        {
            get { return supplierID; }
            set
            {
                supplierID = value;
                OnPropertyChanged("SupplierID");
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

    public class AdjustDebitNoteForm : ViewModelBase
    {
        private List<SupplierDetailEntity> lstSuppliers;
        private AdjustDebitNoteEntity paymentToSupplier;


        private List<AdjustDebitNoteDetailsEntity> paymentToSupplierDetails { get; set; }

        public AdjustDebitNoteEntity AdjustDebitNote
        {
            get
            {
                return paymentToSupplier;
            }
            set
            {
                paymentToSupplier = value;
                OnPropertyChanged("AdjustDebitNote");
            }
        }

        public List<AdjustDebitNoteDetailsEntity> AdjustDebitNoteDetails
        {
            get
            {
                return paymentToSupplierDetails;
            }
            set
            {
                paymentToSupplierDetails = value;
                OnPropertyChanged("AdjustDebitNoteDetails");
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
        public List<ContentModel> LstTermsAndConditions { get; set; }
    }

}
