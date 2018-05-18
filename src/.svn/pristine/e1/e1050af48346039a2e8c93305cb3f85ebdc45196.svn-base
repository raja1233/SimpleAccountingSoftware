

namespace SDN.UI.Entities
{
    using SDN.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OptionsEntity : ViewModelBase
    {
        #region Private Properties
        private int _ID;
        private string _DateFormat;

        private string _NumberFormat;
        private int _DecimalPlaces;
        private string _CurrencyCode;
        private string _StartingSalesInvNo;
        private string _NametoPrintSalesInv;
        private string _DefCashBankAcc;
        private string _AccountID;
        private IEnumerable<AccountsEntity> _AccountDetails;
        private IEnumerable<CurrencyFormat> _CurrencyFormat;
        private string _CurrencyName;
        private string _Tax_Name;
        private int _OptionGridHeight;

        private bool? _ShowAmountIncGST;
        private bool? _ShowAmountIncGSTTrue;
        private bool? _ShowAmountIncGSTFalse;

        private bool? _ShowAccountBal;
        private bool? _ShowAccountBalTrue;
        private bool? _ShowAccountBalFalse;

        private bool? _CusDetailAllowChgLimit;
        private bool? _CusDetailAllowChgLimitTrue;
        private bool? _CusDetailAllowChgLimitFalse;

        private bool? _PSDetailAllowChgAct;
        private bool? _PSDetailAllowChgActTrue;
        private bool? _PSDetailAllowChgActFalse;

        private bool? _AllowToCreateSaleInv;
        private bool? _AllowToCreateSaleInvTrue;
        private bool? _AllowToCreateSaleInvFalse;

        private bool? _ShowPSName;
        private bool? _ShowPSNameTrue;
        private bool? _ShowPSNameFalse;

        private bool? _ShowPSNameDesc;
        private bool? _ShowPSNameDescTrue;
        private bool? _ShowPSNameDescFalse;

        private bool? _AllowEditPSNameDesc;
        private bool? _AllowEditPSNameDescTrue;
        private bool? _AllowEditPSNameDescFalse;

        private bool? _AllowEditPSPrice;
        private bool? _AllowEditPSPriceTrue;
        private bool? _AllowEditPSPriceFalse;

        private bool? _AllowEditDiscount;
        private bool? _AllowEditDiscountTrue;
        private bool? _AllowEditDiscountFalse;

        private bool? _HideDiscColumn;
        private bool? _HideDiscColumnTrue;
        private bool? _HideDiscColumnFalse;

        private bool? _PSQtyJumNextLine;
        private bool? _PSQtyJumNextLineTrue;
        private bool? _PSQtyJumNextLineFalse;

        private bool? _PrintPSName;
        private bool? _PrintPSNameTrue;
        private bool? _PrintPSNameFalse;

        private bool? _PrintPSNameDesc;
        private bool? _PrintPSNameDescTrue;
        private bool? _PrintPSNameDescFalse;

        private bool? _PrintDelSalesInv;
        private bool? _PrintDelSalesInvTrue;
        private bool? _PrintDelSalesInvFalse;
        #endregion


        #region Public Properties
        public int OptionGridHeight
        {
            get
            {
                return _OptionGridHeight;
            }
            set
            {
                _OptionGridHeight = value;
                OnPropertyChanged("OptionGridHeight");
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
        public string DateFormat
        {
            get
            {
                return _DateFormat;
            }
            set
            {
                _DateFormat = value;
                OnPropertyChanged("DateFormat");
            }
        }
        public string NumberFormat
        {
            get
            {
                return _NumberFormat;
            }
            set
            {
                _NumberFormat = value;
                OnPropertyChanged("NumberFormat");
            }
        }
        public int DecimalPlaces
        {
            get
            {
                return _DecimalPlaces;
            }
            set
            {
                _DecimalPlaces = value;
                OnPropertyChanged("_DecimalPlaces");
            }
        }
        public string CurrencyCode
        {
            get
            {
                return _CurrencyCode;
            }
            set
            {
                _CurrencyCode = value;
                OnPropertyChanged("CurrencyCode");
            }
        }
        public string StartingSalesInvNo
        {
            get
            {
                return _StartingSalesInvNo;
            }
            set
            {
                _StartingSalesInvNo = value;
                OnPropertyChanged("StartingSalesInvNo");
            }
        }
        public string NametoPrintSalesInv
        {
            get
            {
                return _NametoPrintSalesInv;
            }
            set
            {
                _NametoPrintSalesInv = value;
                OnPropertyChanged("NametoPrintSalesInv");
            }
        }
        public string DefCashBankAcc
        {
            get
            {
                return _DefCashBankAcc;
            }
            set
            {
                _DefCashBankAcc = value;
                OnPropertyChanged("DefCashBankAcc");
            }
        }
        public string AccountID
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
        public string CurrencyName
        {
            get
            {
                return _CurrencyName;
            }
            set
            {
                _CurrencyName = value;
                OnPropertyChanged("CurrencyName");
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
        public IEnumerable<CurrencyFormat> CurrencyFormat
        {
            get
            {
                return _CurrencyFormat;
            }
            set
            {
                _CurrencyFormat = value;
                OnPropertyChanged("_CurrencyFormat");
            }
        }


        public bool? ShowAmountIncGST
        {
            get
            {

                     
                return _ShowAmountIncGST;
            }
            set
            {
                if (ShowAmountIncGSTTrue == null)
                {
                    ShowAmountIncGSTTrue = false;
                    ShowAmountIncGSTFalse = true;
                }
               else if (ShowAmountIncGSTTrue == true)
                {
                    _ShowAmountIncGST = true;
                }
                else if (ShowAmountIncGSTFalse == true)
                {
                    _ShowAmountIncGST = false;
                }
                else
                {
                    _ShowAmountIncGST = value;
                }

                OnPropertyChanged("ShowAmountIncGST");
            }
        }
        public bool? ShowAmountIncGSTTrue
        {
            get
            {
               
                    return _ShowAmountIncGSTTrue;
            }
            set
            {

                _ShowAmountIncGSTTrue = value;
                ShowAmountIncGST = true;
                OnPropertyChanged("ShowAmountIncGSTTrue");
            }
        }
        public bool? ShowAmountIncGSTFalse
        {
            get
            {
              
                    return _ShowAmountIncGSTFalse;
            }
            set
            {

                _ShowAmountIncGSTFalse = value;
                ShowAmountIncGST = false;
                OnPropertyChanged("ShowAmountIncGSTFalse");
            }
        }


        public bool? ShowAccountBal
        {
            get
            {
                return _ShowAccountBal;
            }
            set
            {
                if (ShowAccountBalTrue == null)
                {
                    ShowAccountBalTrue = false;
                    ShowAccountBalFalse = true;
                }
                else if (ShowAccountBalTrue == true)
                {
                    _ShowAccountBal = true;
                }
                else if (ShowAccountBalFalse == true)
                {
                    _ShowAccountBal = false;
                }
                else
                {
                    _ShowAccountBal = value;
                }

                OnPropertyChanged("ShowAccountBal");
            }
        }
        public bool? ShowAccountBalTrue
        {
            get
            {
                return _ShowAccountBalTrue;
            }
            set
            {
                _ShowAccountBalTrue = value;
                ShowAccountBal = true;
                OnPropertyChanged("ShowAccountBalTrue");
            }
        }
        public bool? ShowAccountBalFalse
        {
            get
            {
                return _ShowAccountBalFalse;
            }
            set
            {
                _ShowAccountBalFalse = value;
                ShowAccountBal = false;
                OnPropertyChanged("ShowAccountBalFalse");
            }
        }


        public bool? CusDetailAllowChgLimit
        {
            get
            {
                return _CusDetailAllowChgLimit;
            }
            set
            {
                if (CusDetailAllowChgLimitTrue == null)
                {
                    CusDetailAllowChgLimitTrue = false;
                    CusDetailAllowChgLimitFalse = true;
                }
                else if (CusDetailAllowChgLimitTrue == true)
                {
                    _CusDetailAllowChgLimit = true;
                }
                else if (CusDetailAllowChgLimitFalse == true)
                {
                    _CusDetailAllowChgLimit = false;
                }
                else
                {
                    _CusDetailAllowChgLimit = value;
                }

                OnPropertyChanged("CusDetailAllowChgLimit");
            }
        }
        public bool? CusDetailAllowChgLimitTrue
        {
            get
            {
                return _CusDetailAllowChgLimitTrue;
            }
            set
            {
                _CusDetailAllowChgLimitTrue = value;
                CusDetailAllowChgLimit = true;
                OnPropertyChanged("CusDetailAllowChgLimitTrue");
            }
        }
        public bool? CusDetailAllowChgLimitFalse
        {
            get
            {
                return _CusDetailAllowChgLimitFalse;
            }
            set
            {
                _CusDetailAllowChgLimitFalse = value;
                CusDetailAllowChgLimit = false;
                OnPropertyChanged("CusDetailAllowChgLimitFalse");
            }
        }


        public bool? PSDetailAllowChgAct
        {
            get
            {
                return _PSDetailAllowChgAct;
            }
            set
            {
                if (PSDetailAllowChgActTrue == null)
                {
                    PSDetailAllowChgActTrue = false;
                    PSDetailAllowChgActFalse = true;
                }
                else if (PSDetailAllowChgActTrue == true)
                {
                    _PSDetailAllowChgAct = true;
                }
                else if (PSDetailAllowChgActFalse == true)
                {
                    _PSDetailAllowChgAct = false;
                }
                else
                {
                    _PSDetailAllowChgAct = value;
                }
                OnPropertyChanged("PSDetailAllowChgAct");
            }
        }
        public bool? PSDetailAllowChgActTrue
        {
            get
            {
                return _PSDetailAllowChgActTrue;
            }
            set
            {
                _PSDetailAllowChgActTrue = value;
                PSDetailAllowChgAct = true;
                OnPropertyChanged("PSDetailAllowChgActTrue");
            }
        }
        public bool? PSDetailAllowChgActFalse
        {
            get
            {
                return _PSDetailAllowChgActFalse;
            }
            set
            {
                _PSDetailAllowChgActFalse = value;
                PSDetailAllowChgAct = false;
                OnPropertyChanged("PSDetailAllowChgActFalse");
            }
        }


        public bool? AllowToCreateSaleInv
        {
            get
            {
                return _AllowToCreateSaleInv;
            }
            set
            {
                if (AllowToCreateSaleInvTrue == null)
                {
                    AllowToCreateSaleInvTrue = false;
                    AllowToCreateSaleInvFalse = true;
                }
                else if (AllowToCreateSaleInvTrue == true)
                {
                    _AllowToCreateSaleInv = true;
                }
                else if (AllowToCreateSaleInvFalse == true)
                {
                    _AllowToCreateSaleInv = false;
                }
                else
                {
                    _AllowToCreateSaleInv = value;
                }
                OnPropertyChanged("AllowToCreateSaleInv");
            }
        }
        public bool? AllowToCreateSaleInvTrue
        {
            get
            {
                return _AllowToCreateSaleInvTrue;
            }
            set
            {
                _AllowToCreateSaleInvTrue = value;
                AllowToCreateSaleInv = true;
                OnPropertyChanged("AllowToCreateSaleInvTrue");
            }
        }
        public bool? AllowToCreateSaleInvFalse
        {
            get
            {
                return _AllowToCreateSaleInvFalse;
            }
            set
            {
                _AllowToCreateSaleInvFalse = value;
                AllowToCreateSaleInv = false;
                OnPropertyChanged("AllowToCreateSaleInvFalse");
            }
        }


        public bool? ShowPSName
        {
            get
            {
                return _ShowPSName;
            }
            set
            {
                if (ShowPSNameTrue == null)
                {
                    ShowPSNameTrue = false;
                    ShowPSNameFalse = true;
                }
                else if (ShowPSNameTrue == true)
                {
                    _ShowPSName = true;
                }
                else if (ShowPSNameFalse == true)
                {
                    _ShowPSName = false;
                }
                else if (ShowPSNameDesc == true)
                {
                    _ShowPSName = false;
                }
                else
                {
                    _ShowPSName = value;
                }
                OnPropertyChanged("ShowPSName");
            }
        }
        public bool? ShowPSNameTrue
        {
            get
            {
                return _ShowPSNameTrue;
            }
            set
            {
                _ShowPSNameTrue = value;
                ShowPSName = true;
                OnPropertyChanged("ShowPSNameTrue");
            }
        }
        public bool? ShowPSNameFalse
        {
            get
            {
                return _ShowPSNameFalse;
            }
            set
            {
                _ShowPSNameFalse = value;
                ShowPSName = false;
                OnPropertyChanged("ShowPSNameFalse");
            }
        }


        public bool? ShowPSNameDesc
        {
            get
            {
                return _ShowPSNameDesc;
            }
            set
            {
                if (ShowPSNameDescTrue == null)
                {
                    ShowPSNameDescTrue = false;
                    ShowPSNameDescFalse = true;
                }
                else if (ShowPSNameDescTrue == true)
                {
                    _ShowPSNameDesc = true;
                }
                else if (ShowPSNameDescFalse == true)
                {
                    _ShowPSNameDesc = false;
                }
                else if (ShowPSName == true)
                {
                    _ShowPSNameDesc = false;
                }
                else
                {
                    _ShowPSNameDesc = value;
                }
                OnPropertyChanged("ShowPSNameDesc");
            }
        }
        public bool? ShowPSNameDescTrue
        {
            get
            {
                return _ShowPSNameDescTrue;
            }
            set
            {
                _ShowPSNameDescTrue = value;
                ShowPSNameDesc = true;
                OnPropertyChanged("ShowPSNameDescTrue");
            }
        }
        public bool? ShowPSNameDescFalse
        {
            get
            {
                return _ShowPSNameDescFalse;
            }
            set
            {
                _ShowPSNameDescFalse = value;
                ShowPSNameDesc = false;
                OnPropertyChanged("ShowPSNameDescFalse");
            }
        }


        public bool? AllowEditPSNameDesc
        {
            get
            {
                return _AllowEditPSNameDesc;
            }
            set
            {
                if (AllowEditPSNameDescTrue == null)
                {
                    AllowEditPSNameDescTrue = false;
                    AllowEditPSNameDescFalse = true;
                }
                else if (AllowEditPSNameDescTrue == true)
                {
                    _AllowEditPSNameDesc = true;
                }
                else if (AllowEditPSNameDescFalse == true)
                {
                    _AllowEditPSNameDesc = false;
                }
                else
                {
                    _AllowEditPSNameDesc = value;
                }
                OnPropertyChanged("AllowEditPSNameDesc");
            }
        }
        public bool? AllowEditPSNameDescTrue
        {
            get
            {
                return _AllowEditPSNameDescTrue;
            }
            set
            {
                _AllowEditPSNameDescTrue = value;
                AllowEditPSNameDesc = true;
                OnPropertyChanged("AllowEditPSNameDescTrue");
            }
        }
        public bool? AllowEditPSNameDescFalse
        {
            get
            {
                return _AllowEditPSNameDescFalse;
            }
            set
            {
                _AllowEditPSNameDescFalse = value;
                AllowEditPSNameDesc = false;
                OnPropertyChanged("AllowEditPSNameDescFalse");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool? AllowEditPSPrice
        {
            get
            {
                return _AllowEditPSPrice;
            }
            set
            {
                if (AllowEditPSPriceTrue == null)
                {
                    AllowEditPSPriceTrue = false;
                    AllowEditPSPriceFalse = true;
                }
                else if (AllowEditPSPriceTrue == true)
                {
                    _AllowEditPSPrice = true;
                }
                else if (AllowEditPSPriceFalse == true)
                {
                    _AllowEditPSPrice = false;
                }
                else
                {
                    _AllowEditPSPrice = value;
                }
                OnPropertyChanged("AllowEditPSPrice");
            }
        }
        public bool? AllowEditPSPriceTrue
        {
            get
            {
                return _AllowEditPSPriceTrue;
            }
            set
            {
                _AllowEditPSPriceTrue = value;
                AllowEditPSPrice = true;
                OnPropertyChanged("AllowEditPSPriceTrue");
            }
        }
        public bool? AllowEditPSPriceFalse
        {
            get
            {
                return _AllowEditPSPriceFalse;
            }
            set
            {
                _AllowEditPSPriceFalse = value;
                AllowEditPSPrice = false;
                OnPropertyChanged("AllowEditPSPriceFalse");
            }
        }


        public bool? AllowEditDiscount
        {
            get
            {
                return _AllowEditDiscount;
            }
            set
            {
                if (AllowEditDiscountTrue == null)
                {
                    AllowEditDiscountTrue = false;
                    AllowEditDiscountFalse = true;
                }
                else if (AllowEditDiscountTrue == true)
                {
                    _AllowEditDiscount = true;
                }
                else if (AllowEditDiscountFalse == true)
                {
                    _AllowEditDiscount = false;
                }
                else
                {
                    _AllowEditDiscount = value;
                }
                OnPropertyChanged("AllowEditDiscount");
            }
        }
        public bool? AllowEditDiscountTrue
        {
            get
            {
                return _AllowEditDiscountTrue;
            }
            set
            {
                _AllowEditDiscountTrue = value;
                AllowEditDiscount = true;
                OnPropertyChanged("AllowEditDiscountTrue");
            }
        }
        public bool? AllowEditDiscountFalse
        {
            get
            {
                return _AllowEditDiscountFalse;
            }
            set
            {
                _AllowEditDiscountFalse = value;
                AllowEditDiscount = false;
                OnPropertyChanged("AllowEditDiscountFalse");
            }
        }


        public bool? HideDiscColumn
        {
            get
            {
                return _HideDiscColumn;
            }
            set
            {
                if (HideDiscColumnTrue == null)
                {
                    HideDiscColumnTrue = false;
                    HideDiscColumnFalse = true;
                }
                else if (HideDiscColumnTrue == true)
                {
                    _HideDiscColumn = true;
                }
                else if (HideDiscColumnFalse == true)
                {
                    _HideDiscColumn = false;
                }
                else
                {
                    _HideDiscColumn = value;
                }
                OnPropertyChanged("HideDiscColumn");
            }
        }
        public bool? HideDiscColumnTrue
        {
            get
            {
                return _HideDiscColumnTrue;
            }
            set
            {
                _HideDiscColumnTrue = value;
                HideDiscColumn = true;
                OnPropertyChanged("HideDiscColumnTrue");
            }
        }
        public bool? HideDiscColumnFalse
        {
            get
            {
                return _HideDiscColumnFalse;
            }
            set
            {
                _HideDiscColumnFalse = value;
                HideDiscColumn = false;
                OnPropertyChanged("HideDiscColumnFalse");
            }
        }


        public bool? PSQtyJumNextLine
        {
            get
            {
                return _PSQtyJumNextLine;
            }
            set
            {
                if (PSQtyJumNextLineTrue == null)
                {
                    PSQtyJumNextLineTrue = false;
                    PSQtyJumNextLineFalse = true;
                }
                else if (PSQtyJumNextLineTrue == true)
                {
                    _PSQtyJumNextLine = true;
                }
                else if (PSQtyJumNextLineFalse == true)
                {
                    _PSQtyJumNextLine = false;
                }
                else
                {
                    _PSQtyJumNextLine = value;
                }
                OnPropertyChanged("PSQtyJumNextLine");
            }
        }
        public bool? PSQtyJumNextLineTrue
        {
            get
            {
                return _PSQtyJumNextLineTrue;
            }
            set
            {
                _PSQtyJumNextLineTrue = value;
                PSQtyJumNextLine = true;
                OnPropertyChanged("PSQtyJumNextLineTrue");
            }
        }
        public bool? PSQtyJumNextLineFalse
        {
            get
            {
                return _PSQtyJumNextLineFalse;
            }
            set
            {
                _PSQtyJumNextLineFalse = value;
                PSQtyJumNextLine = false;
                OnPropertyChanged("PSQtyJumNextLineFalse");
            }
        }


        public bool? PrintPSName
        {
            get
            {
                return _PrintPSName;
            }
            set
            {
                if (PrintPSNameTrue == null)
                {
                    PrintPSNameTrue = false;
                    PrintPSNameFalse = true;
                }
                else if (PrintPSNameTrue == true)
                {
                    _PrintPSName = true;
                }
                else if (PrintPSNameFalse == true)
                {
                    _PrintPSName = false;
                }
                else if (PrintPSNameDesc == true)
                {
                    _PrintPSName = false;
                }
                else
                {
                    _PrintPSName = value;
                }
                OnPropertyChanged("PrintPSName");
            }
        }
        public bool? PrintPSNameTrue
        {
            get
            {
                return _PrintPSNameTrue;
            }
            set
            {
                _PrintPSNameTrue = value;
                PrintPSName = true;
                OnPropertyChanged("PrintPSNameTrue");
            }
        }
        public bool? PrintPSNameFalse
        {
            get
            {
                return _PrintPSNameFalse;
            }
            set
            {
                _PrintPSNameFalse = value;
                PrintPSName = false;
                OnPropertyChanged("PrintPSNameFalse");
            }
        }

        public bool? PrintPSNameDesc
        {
            get
            {
                return _PrintPSNameDesc;
            }
            set
            {
                if (PrintPSNameDescTrue == null)
                {
                    PrintPSNameDescTrue = false;
                    PrintPSNameDescFalse = true;
                }
                else if (PrintPSNameDescTrue == true)
                {
                    _PrintPSNameDesc = true;
                }
                else if (PrintPSNameDescFalse == true)
                {
                    _PrintPSNameDesc = false;
                }
                else if (PrintPSName == true)
                {
                    _PrintPSNameDesc = false;
                }
                else
                {
                    _PrintPSNameDesc = value;
                }
                OnPropertyChanged("PrintPSNameDesc");
            }
        }
        public bool? PrintPSNameDescTrue
        {
            get
            {
                return _PrintPSNameDescTrue;
            }
            set
            {
                _PrintPSNameDescTrue = value;
                PrintPSNameDesc = true;
                OnPropertyChanged("PrintPSNameDescTrue");
            }
        }
        public bool? PrintPSNameDescFalse
        {
            get
            {
                return _PrintPSNameDescFalse;
            }
            set
            {
                _PrintPSNameDescFalse = value;
                PrintPSNameDesc = false;
                OnPropertyChanged("PrintPSNameDescFalse");
            }
        }

        public bool? PrintDelSalesInv
        {
            get
            {
                return _PrintDelSalesInv;
            }
            set
            {
                if (PrintDelSalesInvTrue == null)
                {
                    PrintDelSalesInvTrue = false;
                    PrintDelSalesInvFalse = true;
                }
                else if (PrintDelSalesInvTrue == true)
                {
                    _PrintDelSalesInv = true;
                }
                else if (PrintDelSalesInvFalse == true)
                {
                    _PrintDelSalesInv = false;
                }
                else
                {
                    _PrintDelSalesInv = value;
                }
                OnPropertyChanged("PrintDelSalesInv");
            }
        }
        public bool? PrintDelSalesInvTrue
        {
            get
            {
                return _PrintDelSalesInvTrue;
            }
            set
            {
                _PrintDelSalesInvTrue = value;
                PrintDelSalesInv = true;
                OnPropertyChanged("PrintDelSalesInvTrue");
            }
        }
        public bool? PrintDelSalesInvFalse
        {
            get
            {
                return _PrintDelSalesInvFalse;
            }
            set
            {
                _PrintDelSalesInvFalse = value;
                PrintDelSalesInv = false;
                OnPropertyChanged("PrintDelSalesInvFalse");
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
        #endregion
    }
}
