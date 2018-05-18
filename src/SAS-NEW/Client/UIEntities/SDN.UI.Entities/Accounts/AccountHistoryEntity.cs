using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Accounts
{
    public class AccountHistoryEntity : ViewModelBase
    {
        #region
        private int _SIGridHeight;
        private bool? _EnableYearDropDown;
        private bool? _EnableQuarterDropDown;
        private bool isSelected;
        private string _JsonData;
        private int? _ID;
        private string _SelectedSearchYear;
        private bool? _ShowAllTrue;
        private string _SelectedSearchQuarter;
        private List<AccountHistoryEntity> _AccountHistoryList;
        private string _SelectedSearchMonth;
        private bool? _ShowSelectedTrue;
        private bool? _YearmonthQuartTrue;
        private string _FirstMonth;
        private string _SecondMonth;
        private string _ThirdMonth;
        private string _QuarterName;
        private string _AccountName;
        private string _YearOne;
        private string _MonthOne;
        private string _MonthTwo;
        private string _MonthThree;
        private string _QuarterOne;
        private string _currencyFormat;
        private decimal? _decimalPlaces;
        private string _DateFormat;
        private string _currencyName;
        private string _currencyCode;

        private List<YearEntity> _YearRange;

        #endregion
        #region public entity
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
        public string MonthOne
        {
            get
            {
                return _MonthOne;
            }
            set
            {
                _MonthOne = value;
                OnPropertyChanged("MonthOne");
            }
        }
        public string  MonthTwo
        {
            get
            {
                return _MonthTwo;
            }
            set
            {
                _MonthTwo = value;
                OnPropertyChanged("MonthTwo");
            }
        }
        public string  MonthThree
        {
            get
            {
                return _MonthThree;
            }
            set
            {
                _MonthThree = value;
                OnPropertyChanged("MonthThree");
            }
        }
        public string QuarterOne
        {
            get
            {
                return _QuarterOne;
            }
            set
            {
                _QuarterOne = value;
                OnPropertyChanged("QuarterOne");
            }
        }
        public string YearOne
        {
            get
            {
                return _YearOne;
            }
            set
            {
                _YearOne = value;
                OnPropertyChanged("YearOne");
            }
        }
        public bool? ShowSelectedTrue
        {
            get
            {
                return _ShowSelectedTrue;
            }
            set
            {
                _ShowSelectedTrue = value;
                OnPropertyChanged("ShowSelectedTrue");
            }
        }
        public string JsonData
        {
            get
            {
                return _JsonData;
            }
            set
            {
                _JsonData = value;
                OnPropertyChanged("JsonData");
            }
        }
        public bool? ShowAllTrue
        {
            get
            {
                return _ShowAllTrue;
            }
            set
            {
                _ShowAllTrue = value;
                OnPropertyChanged("ShowAllTrue");
            }
        }
        public bool? YearmonthQuartTrue
        {
            get
            {
                return _YearmonthQuartTrue;
            }
            set
            {
                _YearmonthQuartTrue = value;
                if (_YearmonthQuartTrue == true)
                {
                    //SelectedSearchStartDate = null;
                    //SelectedSearchEndDate = null;
                    //EnableEndDropDown = false;
                    //EnableStartDropDown = false;
                    //EnableMonthDropDown = true;
                    EnableQuarterDropDown = true;
                    EnableYearDropDown = true;

                }

                OnPropertyChanged("YearmonthQuartTrue");
            }
        }
        public string FirstMonth
        {
            get { return _FirstMonth; }

            set
            {
                if (_FirstMonth != value)
                {
                    _FirstMonth = value;
                    OnPropertyChanged("FirstMonth");
                }
            }
        }
        public string SecondMonth
        {
            get { return _SecondMonth; }

            set
            {
                if (_SecondMonth != value)
                {
                    _SecondMonth = value;
                    OnPropertyChanged("SecondMonth");
                }
            }
        }
        public string ThirdMonth
        {
            get { return _ThirdMonth; }

            set
            {
                if (_ThirdMonth != value)
                {
                    _ThirdMonth = value;
                    OnPropertyChanged("ThirdMonth");
                }
            }
        }
        public string QuarterName
        {
            get
            {
                return _QuarterName;
            }
            set
            {
                _QuarterName = value;
                OnPropertyChanged("QuarterName");
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
        public List<AccountHistoryEntity> AccountHistoryList
        {
            get { return _AccountHistoryList; }
            set
            {
                if (_AccountHistoryList != value)
                {
                    _AccountHistoryList = value;
                    OnPropertyChanged("AccountHistoryList");
                }
            }
        }
        public List<YearEntity> YearRange
        {
            get
            {
                return _YearRange;
            }
            set
            {
                _YearRange = value;
                OnPropertyChanged("YearRange");
            }
        }
        public string SelectedSearchYear
        {
            get
            {
                return _SelectedSearchYear;
            }
            set
            {
                _SelectedSearchYear = value;
                OnPropertyChanged("SelectedSearchYear");
            }
        }
        public string SelectedSearchQuarter
        {
            get
            {
                return _SelectedSearchQuarter;
            }
            set
            {
                _SelectedSearchQuarter = value;
                //if (_SelectedSearchQuarter != null)
                //SelectedSearchMonth = null;
                OnPropertyChanged("SelectedSearchQuarter");
            }
        }
        public string SelectedSearchMonth
        {
            get
            {
                return _SelectedSearchMonth;
            }
            set
            {
                _SelectedSearchMonth = value;
                if (_SelectedSearchMonth != null)
                    SelectedSearchQuarter = null;
                OnPropertyChanged("SelectedSearchMonth");
            }
        }
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
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
        public bool? EnableYearDropDown
        {
            get
            {
                return _EnableYearDropDown;
            }
            set
            {
                _EnableYearDropDown = value;
                OnPropertyChanged("EnableYearDropDown");
            }
        }
        public bool? EnableQuarterDropDown
        {
            get
            {
                return _EnableQuarterDropDown;
            }
            set
            {
                _EnableQuarterDropDown = value;
                OnPropertyChanged("EnableQuarterDropDown");
            }
        }
        #endregion
    }

}
