using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Export
{
    public class Purchase_Quotation_List:ViewModelBase
    {
        #region Private Properties
        private string _SupplierName;
        private string _QuotationNo;
        private string _QuotationAmount;
        private string _QAmount;
        private string _QuotationAmountIncGST;
        private string _QuotationAmountExcGST;
        private string _ConvertedToPI;
        private string _ConvertedToPO;
        private string _ConvertedToNo;
        private string _IsDeleted;
        private string _ExcIncGST;
        private int _ID;
        private int _Sup_ID;
        private string _QuotationDateStr;
        private string _QuotationDate;
        private DateTime? _QuotationDateDateTime;
        private DateTime? _CreatedDate;
        private DateTime? _CreatedDateList;
        #endregion

        #region
        #region
        public string SupplierName
        {
            get { return _SupplierName; }

            set
            {
                if (_SupplierName != value)
                {
                    _SupplierName = value;
                    OnPropertyChanged("SupplierName");

                }
            }
        }
        public string QuotationNo
        {
            get { return _QuotationNo; }

            set
            {
                if (_QuotationNo != value)
                {
                    _QuotationNo = value;
                    OnPropertyChanged("QuotationNo");

                }
            }
        }
        public string QuotationDate
        {
            get { return _QuotationDate; }

            set
            {
                if (_QuotationDate != value)
                {
                    _QuotationDate = value;
                    OnPropertyChanged("QuotationDate");

                }
            }
        }
        public DateTime? QuotationDateDateTime
        {
            get { return _QuotationDateDateTime; }

            set
            {
                if (_QuotationDateDateTime != value)
                {
                    _QuotationDateDateTime = value;
                    OnPropertyChanged("QuotationDateDateTime");

                }
            }
        }
        public string QuotationAmount
        {
            get { return _QuotationAmount; }

            set
            {
                if (_QuotationAmount != value)
                {
                    _QuotationAmount = value;
                    OnPropertyChanged("QuotationAmount");

                }
            }
        }
        public string QAmount
        {
            get { return _QAmount; }

            set
            {
                if (_QAmount != value)
                {
                    _QAmount = value;
                    OnPropertyChanged("QAmount");

                }
            }
        }
        public string QuotationAmountIncGST
        {
            get { return _QuotationAmountIncGST; }

            set
            {
                if (_QuotationAmountIncGST != value)
                {
                    _QuotationAmountIncGST = value;
                    OnPropertyChanged("QuotationAmountIncGST");

                }
            }
        }
        public string QuotationAmountExcGST
        {
            get { return _QuotationAmountExcGST; }

            set
            {
                if (_QuotationAmountExcGST != value)
                {
                    _QuotationAmountExcGST = value;
                    OnPropertyChanged("QuotationAmountExcGST");

                }
            }
        }
        public string ConvertedToPI
        {
            get { return _ConvertedToPI; }

            set
            {
                if (_ConvertedToPI != value)
                {
                    _ConvertedToPI = value;
                    OnPropertyChanged("ConvertedToPI");

                }
            }
        }
        public string ConvertedToPO
        {
            get { return _ConvertedToPO; }

            set
            {
                if (_ConvertedToPO != value)
                {
                    _ConvertedToPO = value;
                    OnPropertyChanged("ConvertedToPO");

                }
            }
        }
        public string ConvertedToNo
        {
            get { return _ConvertedToNo; }

            set
            {
                if (_ConvertedToNo != value)
                {
                    _ConvertedToNo = value;
                    OnPropertyChanged("ConvertedToNo");

                }
            }
        }
        public string IsDeleted
        {
            get { return _IsDeleted; }

            set
            {
                if (_IsDeleted != value)
                {
                    _IsDeleted = value;
                    OnPropertyChanged("IsDeleted");

                }
            }
        }
        public string ExcIncGST
        {
            get { return _ExcIncGST; }

            set
            {
                if (_ExcIncGST != value)
                {
                    _ExcIncGST = value;
                    OnPropertyChanged("ExcIncGST");

                }
            }
        }
        public int ID
        {
            get { return _ID; }

            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged("ID");

                }
            }
        }
        public int Sup_ID
        {
            get { return _Sup_ID; }

            set
            {
                if (_Sup_ID != value)
                {
                    _Sup_ID = value;
                    OnPropertyChanged("Sup_ID");

                }
            }
        }
        public string QuotationDateStr
        {
            get { return _QuotationDateStr; }

            set
            {
                if (_QuotationDateStr != value)
                {
                    _QuotationDateStr = value;
                    OnPropertyChanged("QuotationDateStr");

                }
            }
        }
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }

            set
            {
                if (_CreatedDate != value)
                {
                    _CreatedDate = value;
                    OnPropertyChanged("CreatedDate");

                }
            }
        }
        public DateTime? CreatedDateList
        {
            get { return _CreatedDateList; }

            set
            {
                if (_CreatedDateList != value)
                {
                    _CreatedDateList = value;
                    OnPropertyChanged("CreatedDateList");

                }
            }
        }

        #endregion
        #endregion
    }
}
