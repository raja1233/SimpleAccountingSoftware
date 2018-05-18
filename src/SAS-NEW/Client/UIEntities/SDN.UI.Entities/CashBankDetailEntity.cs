namespace SDN.UI.Entities
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class CashBankDetailEntity : ViewModelBase
    {
        #region Private Properties
        private int _AccountID;
        private string _AccountName;
        private string _AccountType;
        private string _AccountOpeningBal;
        private string _AccountCodeID;
        private bool? _IsInActive;
        private string _IsInActivestring;
        private bool? _IsEnabled;
        private string _AccuntTypeCode;
        private int _SeletedIndex;
        private bool? _ReadOnlyAccountName;
        private bool? _DeleteEnabled;
        private bool? _IsCashAccount;
        private IEnumerable<AccountsEntity> _AccountDetails;

        #endregion

        #region public Properties
        public int AccountID
        {
            get
            {
                return _AccountID;
            }
            set
            {
                _AccountID = value;
                OnPropertyChanged("AccountID");
            }
        }
        public string AccountName
        {
            get
            {
                return _AccountName;
            }
            set
            {
                _AccountName = value;
                OnPropertyChanged("AccountName");
            }
        }
        public string AccountType
        {
            get
            {
                return _AccountType;
            }
            set
            {
                _AccountType = value;
                OnPropertyChanged("AccountType");
            }
        }
        public string AccountOpeningBal
        {
            get
            {
                //return _AccountOpeningBal;
                if (_AccountOpeningBal == null)
                    return this._AccountOpeningBal;
                else
                {
                    //var culture = CultureInfo.GetCultureInfo("en-US");
                    //var numberFormat = (NumberFormatInfo)culture.NumberFormat.Clone();
                    //var abc = _AccountOpeningBal.ToString(CultureInfo.CreateSpecificCulture("sv-SE"));
                    if (_AccountOpeningBal != "")
                    {
                        var balance = _AccountOpeningBal.Replace(",", "");
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 2)
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 3)
                            return Convert.ToDecimal(balance).ToString("N3", new CultureInfo(SharedValues.CurrencyName));
                        if (Convert.ToInt32(SharedValues.decimalPlaces) == 0)
                            return Convert.ToDecimal(balance).ToString("N0", new CultureInfo(SharedValues.CurrencyName));
                        else
                            return Convert.ToDecimal(balance).ToString("N", new CultureInfo(SharedValues.CurrencyName));
                        //return abc;
                    }
                    else
                        return this._AccountOpeningBal;
                    //return abc;
                }

                //case 11:
                //    return Regex.Replace(_Comp_Tel, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");

            }
            set
            {
                _AccountOpeningBal = value;
                OnPropertyChanged("AccountOpeningBal");
            }
        }
        public string AccountCodeID
        {
            get
            {
                return _AccountCodeID;
            }
            set
            {
                _AccountCodeID = value;
                OnPropertyChanged("AccountCodeID");
            }
        }
        public bool? IsInActive
        {
            get
            {
                return _IsInActive;
            }
            set
            {

                _IsInActive = value;
                OnPropertyChanged("IsInActive");
            }
        }
        public bool? IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {

                _IsEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }
        public bool? ReadOnlyAccountName
        {
            get
            {
                return _ReadOnlyAccountName;
            }
            set
            {

                _ReadOnlyAccountName = value;
                OnPropertyChanged("ReadOnlyAccountName");
            }
        }
        public bool? DeleteEnabled
        {
            get
            {
                return _DeleteEnabled;
            }
            set
            {

                _DeleteEnabled = value;
                OnPropertyChanged("DeleteEnabled");
            }
        }
        public bool? IsCashAccount
        {
            get
            {
                return _IsCashAccount;
            }
            set
            {

                _IsCashAccount = value;
                OnPropertyChanged("IsCashAccount");
            }
        }
        public string IsInActivestring
        {
            get
            {
                return _IsInActivestring;
            }
            set
            {
                _IsInActivestring = value;
                OnPropertyChanged("IsInActivestring");
            }
        }
        public string AccuntTypeCode
        {
            get
            {
                return _AccuntTypeCode;
            }
            set
            {
                _AccuntTypeCode = value;
                OnPropertyChanged("AccuntTypeCode");
            }
        }
        public IEnumerable<AccountsEntity> AccountDetails
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
        //public string AccountID
        //{
        //    get
        //    {
        //        return _AccountID;
        //    }
        //    set
        //    {
        //        _AccountID = value;
        //        OnPropertyChanged("AccountID");
        //    }
        //}
        public int SeletedIndex
        {
            get
            {
                return _SeletedIndex;
            }
            set
            {
                _SeletedIndex = value;
                OnPropertyChanged("SeletedIndex");
            }
        }
        #endregion
    }
}
