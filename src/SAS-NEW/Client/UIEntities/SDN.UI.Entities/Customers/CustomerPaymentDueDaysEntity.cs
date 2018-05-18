using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Customers
{
    public class CustomerPaymentDueDaysEntity : ViewModelBase
    {
        #region "Private members"
        private int _ID;
        private string _Name;
        private string _BalanceStr;
        private decimal? _Balance;
        private decimal? _Oneto30Days;
        private string _Oneto30DaysStr;
        private decimal? _Thirtyoneto60Days;
        private string _Thirtyoneto60DaysStr;
        private decimal? _Sixtyoneto90Days;
        private string _Sixtyoneto90DaysStr;
        private decimal? _GreaterThen90Days;
        private string _GreaterThen90DaysStr;
        private string _currencyName;
        private string _currencyCode;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _TaxName;
        private int? _GridHeight;
        private string _SelectedSearchName;
        private List<CustomerPaymentDueDaysEntity> _ListDueDays;
        private List<CustomerPaymentDueDaysEntity> _ListDueDayscmbSup;
        private string _BalanceTotal;
        private string _OneToThirtyTotal;
        private string _OneToSixtyTotal;
        private string _OneToNinetyTotal;
        private string _GreaterthanNinetyTotal;
        #endregion

        #region "Public members"
        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string BalanceStr
        {
            get { return _BalanceStr; }
            set
            {
                _BalanceStr = value;
                OnPropertyChanged("BalanceStr");
            }
        }
        public decimal? Balance
        {
            get { return _Balance; }
            set
            {
                _Balance = value;
                OnPropertyChanged("Balance");
            }
        }
        public decimal? Oneto30Days
        {
            get { return _Oneto30Days; }
            set
            {
                _Oneto30Days = value;
                OnPropertyChanged("Oneto30Days");
            }
        }
        public string Oneto30DaysStr
        {
            get { return _Oneto30DaysStr; }
            set
            {
                _Oneto30DaysStr = value;
                OnPropertyChanged("Oneto30DaysStr");
            }
        }
        public decimal? Thirtyoneto60Days
        {
            get { return _Thirtyoneto60Days; }
            set
            {
                _Thirtyoneto60Days = value;
                OnPropertyChanged("Thirtyoneto60Days");
            }
        }
        public string Thirtyoneto60DaysStr
        {
            get { return _Thirtyoneto60DaysStr; }
            set
            {
                _Thirtyoneto60DaysStr = value;
                OnPropertyChanged("Thirtyoneto60DaysStr");
            }
        }
        public decimal? Sixtyoneto90Days
        {
            get { return _Sixtyoneto90Days; }
            set
            {
                _Sixtyoneto90Days = value;
                OnPropertyChanged("Sixtyoneto90Days");
            }
        }
        public string Sixtyoneto90DaysStr
        {
            get { return _Sixtyoneto90DaysStr; }
            set
            {
                _Sixtyoneto90DaysStr = value;
                OnPropertyChanged("Sixtyoneto90DaysStr");
            }
        }
        public decimal? GreaterThen90Days
        {
            get { return _GreaterThen90Days; }
            set
            {
                _GreaterThen90Days = value;
                OnPropertyChanged("GreaterThen90Days");
            }
        }
        public string GreaterThen90DaysStr
        {
            get { return _GreaterThen90DaysStr; }
            set
            {
                _GreaterThen90DaysStr = value;
                OnPropertyChanged("GreaterThen90DaysStr");
            }
        }
        public string CurrencyName
        {
            get
            {
                return _currencyName;
            }
            set
            {

                if (_currencyName != value)
                {
                    _currencyName = value;
                    OnPropertyChanged("CurrencyName");
                }
            }
        }
        public string CurrencyCode
        {
            get { return _currencyCode; }

            set
            {
                if (_currencyCode != value)
                {
                    _currencyCode = value;
                    OnPropertyChanged("CurrencyCode");
                }
            }
        }
        public string CurrencyFormat
        {
            get { return _currencyFormat; }

            set
            {
                if (_currencyFormat != value)
                {
                    _currencyFormat = value;
                    OnPropertyChanged("CurrencyFormat");
                }
            }
        }
        public decimal? DecimalPlaces
        {
            get { return _decimalPlaces; }

            set
            {
                if (_decimalPlaces != value)
                {
                    _decimalPlaces = value;
                    OnPropertyChanged("DecimalPlaces");
                }
            }
        }
        public string TaxName
        {
            get
            {
                return _TaxName;
            }
            set
            {
                _TaxName = value;
                OnPropertyChanged("TaxName");
            }
        }
        public int? GridHeight
        {
            get
            {
                return _GridHeight;
            }
            set
            {
                _GridHeight = value;
                OnPropertyChanged("GridHeight");
            }
        }
        public string SelectedSearchName
        {
            get
            {
                return _SelectedSearchName;
            }
            set
            {
                _SelectedSearchName = value;
                OnPropertyChanged("SelectedSearchName");
            }
        }
        public List<CustomerPaymentDueDaysEntity> ListDueDays
        {
            get { return _ListDueDays; }
            set
            {
                _ListDueDays = value;
                OnPropertyChanged("ListDueDays");
            }
        }
        public List<CustomerPaymentDueDaysEntity> ListDueDayscmbSup
        {
            get { return _ListDueDayscmbSup; }
            set
            {
                _ListDueDayscmbSup = value;
                OnPropertyChanged("ListDueDayscmbSup");
            }
        }
        public string BalanceTotal
        {
            get
            {
                // return _TotalAmount;
                if (_BalanceTotal == null)
                    return this._BalanceTotal;
                else
                {
                    if (_BalanceTotal != "")
                    {
                        var balance = _BalanceTotal.Replace(",", "");
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
                        return this._BalanceTotal;
                }
            }
            set
            {
                _BalanceTotal = value;
                OnPropertyChanged("BalanceTotal");
            }
        }
        public string OneToThirtyTotal
        {
            get
            {
                // return _TotalAmount;
                if (_OneToThirtyTotal == null)
                    return this._OneToThirtyTotal;
                else
                {
                    if (_OneToThirtyTotal != "")
                    {
                        var balance = _OneToThirtyTotal.Replace(",", "");
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
                        return this._OneToThirtyTotal;
                }
            }
            set
            {
                _OneToThirtyTotal = value;
                OnPropertyChanged("OneToThirtyTotal");
            }
        }
        public string OneToSixtyTotal
        {
            get
            {
                // return _TotalAmount;
                if (_OneToSixtyTotal == null)
                    return this._OneToSixtyTotal;
                else
                {
                    if (_OneToSixtyTotal != "")
                    {
                        var balance = _OneToSixtyTotal.Replace(",", "");
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
                        return this._OneToSixtyTotal;
                }
            }
            set
            {
                _OneToSixtyTotal = value;
                OnPropertyChanged("OneToSixtyTotal");
            }
        }
        public string OneToNinetyTotal
        {
            get
            {
                // return _TotalAmount;
                if (_OneToNinetyTotal == null)
                    return this._OneToNinetyTotal;
                else
                {
                    if (_OneToNinetyTotal != "")
                    {
                        var balance = _OneToNinetyTotal.Replace(",", "");
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
                        return this._OneToNinetyTotal;
                }
            }
            set
            {
                _OneToNinetyTotal = value;
                OnPropertyChanged("OneToNinetyTotal");
            }
        }
        public string GreaterthanNinetyTotal
        {
            get
            {
                // return _TotalAmount;
                if (_GreaterthanNinetyTotal == null)
                    return this._GreaterthanNinetyTotal;
                else
                {
                    if (_GreaterthanNinetyTotal != "")
                    {
                        var balance = _GreaterthanNinetyTotal.Replace(",", "");
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
                        return this._GreaterthanNinetyTotal;
                }
            }
            set
            {
                _GreaterthanNinetyTotal = value;
                OnPropertyChanged("GreaterthanNinetyTotal");
            }
        }
        #endregion
    }
}
