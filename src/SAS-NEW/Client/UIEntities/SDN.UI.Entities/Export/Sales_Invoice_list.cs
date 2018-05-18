using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Export
{
    public class Sales_Invoice_list:ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private int? _Cus_ID;
        private string _CustomerName;
        private decimal? _InvoiceAmountValue;
        private string _InvoiceNo;
        private string _InvoiceAmountIncGST;
        private string _InvoiceAmountExcGST;
        private DateTime? _CreditNoteDateDate;
        private string _CreditNoteNo;
        private bool? _IsDeleted;
        private bool? _ExcIncGST;
        private string _CashChequeNo;
        private DateTime? _InvoiceDateDateTime;
        private DateTime? _CashChequeDateDate;
        private decimal? _CreditNoteAmount;
        private decimal? _CashChequeAmount;
        private DateTime? _CreatedDate;
        private byte? _Status;

        #endregion
        #region 
        #region Public Properties

      
      
        public string CashChequeNo
        {
            get
            {
                return _CashChequeNo;
            }
            set
            {
                _CashChequeNo = value;
                OnPropertyChanged("CashChequeNo");
            }
        }
       
        public DateTime? CashChequeDateDate
        {
            get
            {
                return _CashChequeDateDate;
            }
            set
            {
                _CashChequeDateDate = value;
                OnPropertyChanged("CashChequeDate");
            }
        }
        public DateTime? InvoiceDateDateTime
        {
            get
            {
                return _InvoiceDateDateTime;
            }
            set
            {
                _InvoiceDateDateTime = value;
                OnPropertyChanged("InvoiceDateDateTime");
            }
        }


        public decimal? CashChequeAmount
        {
            get
            {
                return _CashChequeAmount;
            }
            set
            {
                _CashChequeAmount = value;
                OnPropertyChanged("CashChequeAmount");
            }
        }
       
        public byte? Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
                OnPropertyChanged("Status");
            }
        }
       
        public decimal? CreditNoteAmount
        {
            get
            {
                return _CreditNoteAmount;
            }
            set
            {
                _CreditNoteAmount = value;
                OnPropertyChanged("CreditNoteAmount");
            }
        }
       
        public DateTime? CreditNoteDateDate
        {
            get
            {
                return _CreditNoteDateDate;
            }
            set
            {
                _CreditNoteDateDate = value;
                OnPropertyChanged("CreditNoteDateDate");
            }
        }
        public string CreditNoteNo
        {
            get
            {
                return _CreditNoteNo;
            }
            set
            {
                _CreditNoteNo = value;
                OnPropertyChanged("CreditNoteNo");
            }
        }
        
        public bool? ExcIncGST
        {
            get
            {
                return _ExcIncGST;
            }
            set
            {
                _ExcIncGST = value;
                OnPropertyChanged("ExcIncGST");
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
        public int? Cus_ID
        {
            get
            {
                return _Cus_ID;
            }
            set
            {
                _Cus_ID = value;
                OnPropertyChanged("Cus_ID");
            }
        }
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
                OnPropertyChanged("CustomerName");
            }
        }
        public string InvoiceNo
        {
            get
            {
                return _InvoiceNo;
            }
            set
            {
                _InvoiceNo = value;
                OnPropertyChanged("InvoiceNo");
            }
        }
     
        
        public decimal? InvoiceAmountValue
        {
            get
            {
                return _InvoiceAmountValue;
            }
            set
            {
                _InvoiceAmountValue = value;
                OnPropertyChanged("InvoiceAmountValue");
            }
        }
        public string InvoiceAmountIncGST
        {
            get
            {
                return _InvoiceAmountIncGST;
            }
            set
            {
                _InvoiceAmountIncGST = value;
                OnPropertyChanged("InvoiceAmountIncGST");
            }
        }
        public string InvoiceAmountExcGST
        {
            get
            {
                return _InvoiceAmountExcGST;
            }
            set
            {
                _InvoiceAmountExcGST = value;
                OnPropertyChanged("InvoiceAmountExcGST");
            }
        }
        
       
        public bool? IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                _IsDeleted = value;
                OnPropertyChanged("IsDeleted");
            }
        }
       


        public DateTime? CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                _CreatedDate = value;
                OnPropertyChanged("CreatedDate");
            }
        }


        


        #endregion
        #endregion
    }
}
