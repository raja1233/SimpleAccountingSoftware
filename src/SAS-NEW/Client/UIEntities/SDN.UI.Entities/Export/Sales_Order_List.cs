﻿using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Export
{
    public class Sales_Order_List: ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private int _Cus_ID;
        private string _CustomerName;
        private string _OrderNo;
        private DateTime? _OrderDate;
        private string _OrderAmount;
        private string _OAmount;
        private string _OrderAmountIncGST;
        private string _OrderAmountExcGST;
        private string _ConvertedToSI;
        private string _IsDeleted;
        private string _ExcIncGST;
        private DateTime? _CreatedDate; 
        private DateTime? _CreatedDateList;
        private DateTime? _OrderDateDateTime;
        private string _AmountDeposited;
        private string _ConvertedToNo;
        private DateTime? _DeliveryDateDateTime;
        private string _DeliveryDateTime;

        #endregion


        #region Public Properties
  
        public string ConvertedToNo
        {
            get
            {
                return _ConvertedToNo;
            }
            set
            {
                _ConvertedToNo = value;
                OnPropertyChanged("ConvertedToNo");
            }
        }
        public string AmountDeposited
        {
            get
            {
                    return _AmountDeposited;
            }
            set
            {
                _AmountDeposited = value;
                OnPropertyChanged("AmountDeposited");
            }
        }
        public string ExcIncGST
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
        public DateTime? OrderDateDateTime
        {
            get
            {
                return _OrderDateDateTime;
            }
            set
            {
                _OrderDateDateTime = value;
                OnPropertyChanged("OrderDateDateTime");
            }
        }
        public DateTime? DeliveryDateDateTime
        {
            get
            {
                return _DeliveryDateDateTime;
            }
            set
            {
                _DeliveryDateDateTime = value;
                OnPropertyChanged("DeliveryDateDateTime");
            }
        }
        public string DeliveryDateTime
        {
            get
            {
                return _DeliveryDateTime;
            }
            set
            {
                _DeliveryDateTime = value;
                OnPropertyChanged("DeliveryDateTime");
            }
        }

      
        public DateTime? CreatedDateList
        {
            get
            {
                return _CreatedDateList;
            }
            set
            {
                _CreatedDateList = value;
                OnPropertyChanged("CreatedDateList");
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
        public int Cus_ID
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
        public string OrderNo
        {
            get
            {
                return _OrderNo;
            }
            set
            {
                _OrderNo = value;
                OnPropertyChanged("OrderNo");
            }
        }
        public DateTime? OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
                OnPropertyChanged("OrderDate");
            }
        }
        public string OrderAmount
        {
            get
            {
                //return _OrderAmount;
                
                    return _OrderAmount;
                
            }
            set
            {
                _OrderAmount = value;
                OnPropertyChanged("OrderAmount");
            }
        }
        public string OrderAmountIncGST
        {
            get
            {
                return _OrderAmountIncGST;
            }
            set
            {
                _OrderAmountIncGST = value;
                OnPropertyChanged("OrderAmountIncGST");
            }
        }
        public string OrderAmountExcGST
        {
            get
            {
                return _OrderAmountExcGST;
            }
            set
            {
                _OrderAmountExcGST = value;
                OnPropertyChanged("OrderAmountExcGST");
            }
        }
        public string ConvertedToSI
        {
            get
            {
                return _ConvertedToSI;
            }
            set
            {
                _ConvertedToSI = value;
                OnPropertyChanged("ConvertedToSI");
            }
        }
        public string IsDeleted
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

        public string OAmount
        {
            get { return _OAmount; }
            set
            {
                _OAmount = value;
                OnPropertyChanged("OAmount");
            }
        }
        
        #endregion
    }
}