
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Sales
{
    using SDN.Common;
    using System.Globalization;

    public class RefundToCustomerEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private List<CustomerEntity> _ListCustomers;
        private List<AccountsEntity> _AccountDetails;
        private DateTime? _Date;
        private string cashChequeNo;
        private string _AmountStr;
        private decimal? amount;
        private string _Remarks;
        private int? customerID;
        private int? accntId;
        private bool? isCheque;
        private int _PtSFGridHeight;


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

    public class RefundToCustomerForm : ViewModelBase
    {
        private List<CustomerEntity> lstCustomers;
        private RefundToCustomerEntity paymentFromCustomer;


        private List<RefundToCustomerDetailsEntity> paymentFromCustomerDetails { get; set; }

        public RefundToCustomerEntity RefundToCustomer
        {
            get
            {
                return paymentFromCustomer;
            }
            set
            {
                paymentFromCustomer = value;
                OnPropertyChanged("RefundToCustomer");
            }
        }

        public List<RefundToCustomerDetailsEntity> RefundToCustomerDetails
        {
            get
            {
                return paymentFromCustomerDetails;
            }
            set
            {
                paymentFromCustomerDetails = value;
                OnPropertyChanged("RefundToCustomerDetails");
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
