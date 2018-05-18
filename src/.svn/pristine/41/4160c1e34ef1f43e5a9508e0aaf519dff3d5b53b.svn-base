using SASClient.Accounts.Services;
using SASClient.CashBank.Services;
using SDN.Common;
using SDN.UI.Entities;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace SASClient.Accounts.ViewModel
{
    public class UnpaidSalesInvoiceGridViewModel : ViewModelBase
    {
        #region private property
        private int? _ID;
        private string _CustomerName;
        private string _InvoiceNo;
        private DateTime? date;
        private string _InvoiceDate;
        private string _InvoiceDateStr;
        private decimal? _UnpaidAmount;
        private int? _SelectedCustomerID;
        private int _CountQty;
        private ObservableCollection<UnpaidSalesInvoiceEntity> _UnpaidInvoiceService;
        private IUnpaidSalesInvoiceRepository unpaidInvoiceRepository = new UnpaidSalesInvoiceRepository();
        #endregion
        #region public property
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
        public int CountQty
        {
            get
            {
                return _CountQty;
            }
            set
            {
                _CountQty = value;
                OnPropertyChanged("CountQty");
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

        public string InvoiceDate
        {
            get
            {
                
                return _InvoiceDate;
            }
            set
            {
                _InvoiceDate = value;
                OnPropertyChanged("InvoiceDate");
            }
        }
        public string InvoiceDateStr
        {
            get
            {
                return _InvoiceDateStr;
            }
            set
            {
                _InvoiceDateStr = value;
                OnPropertyChanged("InvoiceDateStr");
            }
        }
        public decimal? UnpaidAmount
        {
            get
            {
                return _UnpaidAmount;
            }
            set
            {
                _UnpaidAmount = value;
                OnPropertyChanged("UnpaidAmount");
            }
        }
        public int? SelectedCustomerID
        {
            get
            {
                return _SelectedCustomerID;
            }
            set
            {
                _SelectedCustomerID = value;
                OnPropertyChanged("SelectedCustomerID");
            }
        }
        public ObservableCollection<UnpaidSalesInvoiceEntity> UnpaidInvoiceService
        {
            get
            {
                return _UnpaidInvoiceService;
            }
            set
            {
                _UnpaidInvoiceService = value;
                OnPropertyChanged("UnpaidInvoiceService");
            }
        }
        public UnpaidSalesInvoiceGridViewModel(IEnumerable<UnpaidSalesInvoiceEntity> UnpaidInvoiceList)
        {
            if (UnpaidInvoiceList == null)
            {
                UnpaidInvoiceList = unpaidInvoiceRepository.getCustomerList();
            }
            SelectedCustomerID = 0;
            UnpaidInvoiceService = new ObservableCollection<UnpaidSalesInvoiceEntity>(UnpaidInvoiceList);
        }
        #endregion
    }
}
