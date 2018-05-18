
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Purchase
{
    using SDN.Common;
    using System.Globalization;

    public  class RefundFromSupplierEntity: ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private bool? _MustCompare;

        private List<SupplierDetailEntity> _ListSuppliers;
        private List<AccountsEntity> _AccountDetails;
        private DateTime? _Date;
        private string _DateStr;
        private string cashChequeNo;
        private string _AmountStr;
        private decimal? amount;
        private string _Remarks;
        private int? supplierID;
        private int? accntId;
        private bool? isCheque;
        private int _PtSFGridHeight;
        private string totalSalesAmount;
        private string totalAmountDue;
        private string totalAmountPaid;

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

        public string CashChequeNo
        {
            get { return cashChequeNo; }
            set
            {
                cashChequeNo = value;
                OnPropertyChanged("CashChequeNo");
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
        public string DateStr
        {
            get
            {
                return _DateStr;
            }
            set
            {
                _DateStr = value;
                OnPropertyChanged("DateStr");
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
        public string TotalSalesAmount
        {
            get
            {
                if (totalSalesAmount == null)
                    return this.totalSalesAmount;
                else
                {
                    if (totalSalesAmount != "")
                    {
                        var balance = totalSalesAmount.Replace(",", "");
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
                        return this.totalSalesAmount;
                }
            }
            set
            {
                totalSalesAmount = value;
                OnPropertyChanged("TotalSalesAmount");
            }
        }
        public string TotalAmountDue
        {
            get
            {
                if (totalAmountDue == null)
                    return this.totalAmountDue;
                else
                {
                    if (totalAmountDue != "")
                    {
                        var balance = totalAmountDue.Replace(",", "");
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
                        return this.totalAmountDue;
                }
            }
            set
            {
                totalAmountDue = value;
                OnPropertyChanged("TotalAmountDue");
            }
        }
        public string TotalAmountPaid
        {
            get
            {
                if (totalAmountPaid == null)
                    return this.totalAmountPaid;
                else
                {
                    if (totalAmountPaid != "")
                    {
                        var balance = totalAmountPaid.Replace(",", "");
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
                        return this.totalAmountPaid;
                }
            }
            set
            {
                totalAmountPaid = value;
                OnPropertyChanged("TotalAmountPaid");
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

    public class RefundFromSupplierForm : ViewModelBase
    {
        private List<SupplierDetailEntity> lstSuppliers;
        private RefundFromSupplierEntity refundFromSupplier;


        private List<RefundFromSupplierDetailsEntity> refundFromSupplierDetails { get; set; }

        public RefundFromSupplierEntity RefundFromSupplier
        {
            get
            {
                return refundFromSupplier;
            }
            set
            {
                refundFromSupplier = value;
                OnPropertyChanged("RefundFromSupplier");
            }
        }

        public List<RefundFromSupplierDetailsEntity> RefundFromSupplierDetails
        {
            get
            {
                return refundFromSupplierDetails;
            }
            set
            {
                refundFromSupplierDetails = value;
                OnPropertyChanged("RefundFromSupplierDetails");
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
