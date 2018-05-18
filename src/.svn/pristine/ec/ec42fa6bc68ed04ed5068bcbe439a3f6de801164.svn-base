using SDN.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Accounts
{
    
    public class JournalFormEntity : ViewModelBase
    {
        #region "private property"
        private bool? _MustCompare;

        private int _SIGridHeight;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private string _currencyName;
        private string _currencyCode;
        private string _JournalNo;
        private string _AccountName;
        private string _AccountTypeCode;
        private int? _ID;
        private decimal? _Debit;
        private decimal? _Credit;
        private string _DebitStr;
        private string _CreditStr;
        private DateTime? _JournalDate;
        private string _JournalDateStr;
        private string  _sumCredit;
        private string _sumDebit;
        private bool _IsEnable;
        #endregion
        #region "public property"
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
        public bool IsEnable
        {
            get
            {
                return _IsEnable;
            }
            set
            {
                _IsEnable = value;
                OnPropertyChanged("IsEnable");
            }
        }
        public string AccountTypeCode
        {
            get
            {
                return _AccountTypeCode;
            }
            set
            {
                _AccountTypeCode = value;
                OnPropertyChanged("AccountTypeCode");
            }
        }
        public int SIGridHeight
        {
            get
            {
                return _SIGridHeight;
            }
            set
            {
                _SIGridHeight = value;
                OnPropertyChanged("SIGridHeight");
            }
        }
        //public decimal? sumCredit
        //{
        //    get
        //    {
        //        return _sumCredit;
        //    }
        //    set
        //    {
        //        _sumCredit = value;
        //        OnPropertyChanged("sumCredit");
        //    }
        //}
        public string sumCredit
        {
            get
            {
                if (_sumCredit == null)
                    return this._sumCredit;
                else
                {
                    if (_sumCredit != "")
                    {
                        var balance = _sumCredit.Replace(",", "");
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
                        return this._sumCredit;
                }
            }
            set
            {
                _sumCredit = value;
                OnPropertyChanged("sumCredit");
            }
        }
        public string sumDebit
        {
            get
            {
                if (_sumDebit == null)
                    return this._sumDebit;
                else
                {
                    if (_sumDebit != "")
                    {
                        var balance = _sumDebit.Replace(",", "");
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
                        return this._sumDebit;
                }
            }
            set
            {
                _sumDebit = value;
                OnPropertyChanged("sumDebit");
            }
        }
        public DateTime? JournalDate
        {
            get { return _JournalDate; }
            set
            {
                _JournalDate = value;
                OnPropertyChanged("JournalDate");
            }
        }
        public string JournalDateStr
        {
            get { return _JournalDateStr; }
            set
            {
                _JournalDateStr = value;
                OnPropertyChanged("JournalDateStr");
            }
        }

        public int? ID
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
        public string DateFormat
        {
            get { return _DateFormat; }
            set { SetProperty(ref _DateFormat, value, "DateFormat"); }
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
        public string JournalNo
        {
            get { return _JournalNo; }
            set
            {
                _JournalNo = value;
                OnPropertyChanged("JournalNo");
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
        public decimal? Debit
        {
            get
            {
                return _Debit;

            }
            set
            {
                _Debit = value;
                OnPropertyChanged("Debit");
            }
        }
        public decimal? Credit
        {
            get
            {
                return _Credit;

            }
            set
            {
                _Credit = value;
                OnPropertyChanged("Credit");
            }
        }
        public string DebitStr
        {
            get
            {
                return _DebitStr;

            }
            set
            {
                _DebitStr = value;
                OnPropertyChanged("DebitStr");
            }
        }
        public string CreditStr
        {
            get
            {
                return _CreditStr;

            }
            set
            {
                _CreditStr = value;
                OnPropertyChanged("CreditStr");
            }
        }

        #endregion
    }
    public class JournalForm : ViewModelBase
    {
        #region "Private members"
        private JournalFormEntity _JournalData;
        private List<JournalFormEntity> _journalaDataDetails;
        #endregion

        #region "Properties"

        public JournalFormEntity JournalData
        {
            get { return _JournalData; }
            set
            {
                _JournalData = value;
                OnPropertyChanged("JournalData");
            }
        }

        public List<JournalFormEntity> JournalaDataDetails
        {
            get { return _journalaDataDetails; }
            set
            {
                _journalaDataDetails = value;
                OnPropertyChanged("JournalaDataDetails");
            }
        }

        #endregion
    }

}
