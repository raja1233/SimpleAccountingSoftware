using SDN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;

namespace SDN.UI.Entities
{
    public class CompanyDetailsEntities: ViewModelBase
    {
        #region Private Properties

        
        private int _ID;
        private string _CompanyName;
        private string _Comp_Reg_No;
        private string _Comp_GST_Reg_No;
        private DateTime? _Comp_GST_Reg_Date = null;
        private DateTime? _Comp_GST_Dereg_Date = null;
        private string _Comp_Tel;
        private string _Comp_Fax;
        private string _Comp_Email;
        private DateTime? _Comp_year_start_date= null;
        private DateTime? _Comp_year_end_date = null;
        private byte[] _Comp_logo;
        private string _Software_Ser_No;
        private int _ShippingID;

        private string _Company_BillTo_Line1;
        private string _Company_BillTo_Line2;
        private string _Company_BillTo_City;
        private string _Company_BillTo_State;
        private string _Company_BillTo_Country;
        private string _Company_BillTo_PostalCode;
        private string _ShipTo_Line1;
        private string _ShipTo_Line2;
        private string _ShipTo_State;
        private string _ShipTo_City;
        private string _ShipTo_Country;
        private string _ShipTo_PostalCode;
        private int _ShippAddressCount;
        private IEnumerable<ShippingAddressEntity> _ShippingAddress;
        private BitmapSource _bitmapSource;
        private string _Tax_Name;
        private int _SelectedSearchAccount;
        private int _CompGridHeight;
        //private string _DateFormat;



        #endregion

        #region Public Properties

        public int CompGridHeight
        {
            get
            {
                return this._CompGridHeight;
            }
            set
            {
                this._CompGridHeight = value;
                this.OnPropertyChanged("CompGridHeight");
            }
        }

        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
                this.OnPropertyChanged("ID");
            }
        }
        public int ShippingID
        {
            get
            {
                return this._ShippingID;
            }
            set
            {
                this._ShippingID = value;
                this.OnPropertyChanged("ShippingID");
            }
        }
       
        public string Comp_Reg_No
        {
            get
            {
                return _Comp_Reg_No;
            }
            set
            {
                _Comp_Reg_No = value;
                OnPropertyChanged("Comp_Reg_No");
            }
        }

       
        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
                OnPropertyChanged("CompanyName");
            }
        }
       
        public string Comp_GST_Reg_No
        {
            get
            {
                return _Comp_GST_Reg_No;
            }
            set
            {
                _Comp_GST_Reg_No = value;
                OnPropertyChanged("Comp_GST_Reg_No");
            }
        }
      //  [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$",
      //ErrorMessage = "Please Enter Date Format in dd/mm/yyyy,dd-mm-yyyy or dd.mm.yyyy")]
        public DateTime? Comp_GST_Reg_Date
        {
            get
            {
                return _Comp_GST_Reg_Date;
            }
            set
            {
                _Comp_GST_Reg_Date = value;
                OnPropertyChanged("Comp_GST_Reg_Date");
            }
        }
        //   [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$",
        //ErrorMessage = "Please Enter Date Format in dd/mm/yyyy,dd-mm-yyyy or dd.mm.yyyy")]
        public DateTime? Comp_GST_Dereg_Date
        {
            get
            {
                return this._Comp_GST_Dereg_Date;
            }
            set
            {
                this._Comp_GST_Dereg_Date = value;
                this.OnPropertyChanged("Comp_GST_Dereg_Date");
            }
        }
        public string Comp_Tel
        {
            get
            {
                if (_Comp_Tel == null)
                    return this._Comp_Tel;
                switch (_Comp_Tel.Length)
                {
                    //case 7:
                    //    return Regex.Replace(_Comp_Tel, @"(\d{3})(\d{4})", "$1-$2");
                    case 10:
                        return Regex.Replace(_Comp_Tel, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
                    //case 11:
                    //    return Regex.Replace(_Comp_Tel, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");
                    default:
                        return _Comp_Tel;
                }
            }
            set
            {
                this._Comp_Tel = value;
                this.OnPropertyChanged("Comp_Tel");
            }
        }
        public string Comp_Fax
        {
            get
            {
               
                if (_Comp_Fax == null)
                    return this._Comp_Fax;
                switch (_Comp_Fax.Length)
                {
                    //case 7:
                    //    return Regex.Replace(_Comp_Tel, @"(\d{3})(\d{4})", "$1-$2");
                    case 10:
                        return Regex.Replace(_Comp_Fax, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
                    //case 11:
                    //    return Regex.Replace(_Comp_Tel, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");
                    default:
                        return _Comp_Fax;
                }
            }
        
            set
            {
                this._Comp_Fax = value;
                this.OnPropertyChanged("Comp_Fax");
            }
        }
        public string Comp_Email
        {
            get
            {
                return this._Comp_Email;
            }
            set
            {
                this._Comp_Email = value;
                this.OnPropertyChanged("Comp_Email");
            }
        }

        public DateTime? Comp_year_start_date
        {
            get
            {
                return this._Comp_year_start_date;
            }
            set
            {
                this._Comp_year_start_date = value;
                this.OnPropertyChanged("Comp_year_start_date");
            }
        }
        public DateTime? Comp_year_end_date
        {
            get
            {
                return this._Comp_year_end_date;
            }
            set
            {
                this._Comp_year_end_date = value;
                this.OnPropertyChanged("Comp_year_end_date");
            }
        }


        public byte[] Comp_logo
        {
            get
            {
                return this._Comp_logo;
            }
            set
            {
                this._Comp_logo = value;
                this.OnPropertyChanged("Comp_logo");
            }
        }
        public string Software_Ser_No
        {
            get
            {
                return this._Software_Ser_No;
            }
            set
            {
                this._Software_Ser_No = value;
                this.OnPropertyChanged("Software_Ser_No");
            }
        }

        public string Company_BillTo_Line1
        {
            get
            {
                return _Company_BillTo_Line1;
            }
            set
            {
                _Company_BillTo_Line1 = value;
                OnPropertyChanged("Company_BillTo_Line1");
            }
        }
        public string Company_BillTo_Line2
        {
            get
            {
                return _Company_BillTo_Line2;
            }
            set
            {
                _Company_BillTo_Line2 = value;
                OnPropertyChanged("Company_BillTo_Line2");
            }
        }
        public string Company_BillTo_City
        {
            get
            {
                return _Company_BillTo_City;
            }
            set
            {
                _Company_BillTo_City = value;
                OnPropertyChanged("Company_BillTo_City");
            }
        }
        public string Company_BillTo_State
        {
            get
            {
                return _Company_BillTo_State;
            }
            set
            {
                _Company_BillTo_State = value;
                OnPropertyChanged("Company_BillTo_State");
            }
        }
        public string Company_BillTo_Country
        {
            get
            {
                return _Company_BillTo_Country;
            }
            set
            {
                _Company_BillTo_Country = value;
                OnPropertyChanged("Company_BillTo_Country");
            }
        }
        public string Company_BillTo_PostalCode
        {
            get
            {
                return _Company_BillTo_PostalCode;
            }
            set
            {
                _Company_BillTo_PostalCode = value;
                OnPropertyChanged("_Company_BillTo_PostalCode");
            }
        }
        public string ShipTo_Line2
        {
            get
            {
                return _ShipTo_Line2;
            }
            set
            {
                _ShipTo_Line2 = value;
                OnPropertyChanged("ShipTo_Line2");
            }
        }
        public string ShipTo_Line1
        {
            get
            {
                return _ShipTo_Line1;
            }
            set
            {
                _ShipTo_Line1 = value;
                OnPropertyChanged("ShipTo_Line1");
            }
        }
        public string ShipTo_City
        {
            get
            {
                return _ShipTo_City;
            }
            set
            {
                _ShipTo_City = value;
                OnPropertyChanged("ShipTo_City");
            }
        }
        public string ShipTo_State
        {
            get
            {
                return _ShipTo_State;
            }
            set
            {
                _ShipTo_State = value;
                OnPropertyChanged("ShipTo_State");
            }
        }
        public string ShipTo_Country
        {
            get
            {
                return _ShipTo_Country;
            }
            set
            {
                _ShipTo_Country = value;
                OnPropertyChanged("ShipTo_Country");
            }
        }
        public string ShipTo_PostalCode
        {
            get
            {
                return _ShipTo_PostalCode;
            }
            set
            {
                _ShipTo_PostalCode = value;
                OnPropertyChanged("ShipTo_PostalCode");
            }
        }
        public int ShippAddressCount
        {
            get
            {
                return _ShippAddressCount;
            }
            set
            {
                _ShippAddressCount = value;
                OnPropertyChanged("ShippAddressCount");
            }
        }
        public BitmapSource ButtonSource
        {
            get {
                return _bitmapSource;
            }
            set
            {
                _bitmapSource = value;
                OnPropertyChanged("ButtonSource");
            }
        }
        public string Tax_Name
        {
            get
            {
                return _Tax_Name;
            }
            set
            {
                _Tax_Name = value;
                OnPropertyChanged("Tax_Name");
            }
        }



        //public string DateFormat
        //{
        //    get
        //    {
        //        return _DateFormat;
        //    }
        //    set
        //    {
        //        _DateFormat = value;
        //        OnPropertyChanged("DateFormat");
        //    }
        //}
        private string _DateFormat;
        public string DateFormat
        {
            get { return _DateFormat; }
            set { SetProperty(ref _DateFormat, value, "DateFormat"); }
        }


        public IEnumerable<ShippingAddressEntity> ShippingAddress
        {

            get
            {
                return _ShippingAddress;
            }
            set
            {
                _ShippingAddress = value;
                OnPropertyChanged("ShippingAddress");
            }
        }
        public int SelectedSearchAccount
        {
            get { return _SelectedSearchAccount; }
            set
            {
                if (_SelectedSearchAccount != value)
                {
                    _SelectedSearchAccount = value;
                    OnPropertyChanged("SelectedSearchAccount");
                }
            }
        }



        #endregion
    }
}
