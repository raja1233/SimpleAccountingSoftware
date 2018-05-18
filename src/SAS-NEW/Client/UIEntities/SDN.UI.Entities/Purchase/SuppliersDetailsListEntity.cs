
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Purchase
{
    using SDN.Common;
    using System.Globalization;

    public class SuppliersDetailsListEntity: ViewModelBase
    {
        #region "Private Members"

        private int id;
        private string name;
        private string compRegNo;
        private string gstRegNo;
        private string telephone;
        private string fax;
        private string email;
        private string contact;
        private string balanceStr;
        private decimal? balance;
        private string type;
        private string isInactive;
        private string salesman;
        private int? creditLimitDays;
        private string creditLimitAmountStr;
        private decimal? creditLimitAmount;
        private int? discount;
        private string billToLine1;
        private string billToLine2;
        private string billToCity;
        private string billToState;
        private string billToCountry;
        private string billToPostCode;

        private string shipToLine1;
        private string shipToLine2;
        private string shipToCity;
        private string shipToState;
        private string shipToCountry;
        private string shipToPostCode;
        private string _Active;
        private string _InActive;
        private string _Both;
        private List<SuppliersDetailsListEntity> supplierDetailsList1;
        //private List<SuppliersDetailsListEntity> supplierDetailsList2;
        //private List<SuppliersDetailsListEntity> supplierDetailsList3;
        //private List<SuppliersDetailsListEntity> supplierDetailsList4;

        private List<SuppliersDetailsListEntity> supplierDetailsListCusName;
        private List<SuppliersDetailsListEntity> supplierDetailsListCompRegNo;
        private List<SuppliersDetailsListEntity> supplierDetailsListGSTRegNo;
        private List<SuppliersDetailsListEntity> supplierDetailsListTelephone;
        private List<SuppliersDetailsListEntity> supplierDetailsListFax;
        private List<SuppliersDetailsListEntity> supplierDetailsListEmail;
        private List<SuppliersDetailsListEntity> supplierDetailsListContact;
        // //////////////////////////////////////////
        private List<SuppliersDetailsListEntity> supplierDetailsListBalance;
        private List<SuppliersDetailsListEntity> supplierDetailsListType;
        private List<SuppliersDetailsListEntity> supplierDetailsListSaleman;
        private List<SuppliersDetailsListEntity> supplierDetailsListCreditLimitDays;
        private List<SuppliersDetailsListEntity> supplierDetailsListCreditLimitAmount;
        private List<SuppliersDetailsListEntity> supplierDetailsListDisount;
        // ////////////////////////////////////////////////
        private List<SuppliersDetailsListEntity> supplierDetailsListBillLine1;
        private List<SuppliersDetailsListEntity> supplierDetailsListBillLine2;
        private List<SuppliersDetailsListEntity> supplierDetailsListBillCity;
        private List<SuppliersDetailsListEntity> supplierDetailsListBillState;
        private List<SuppliersDetailsListEntity> supplierDetailsListBillCountry;
        private List<SuppliersDetailsListEntity> supplierDetailsListBillPinCode;
        // ///////////////////////////////////////////////////
        private List<SuppliersDetailsListEntity> supplierDetailsListShipLine1;
        private List<SuppliersDetailsListEntity> supplierDetailsListShipLine2;
        private List<SuppliersDetailsListEntity> supplierDetailsListShipCity;
        private List<SuppliersDetailsListEntity> supplierDetailsListShipState;
        private List<SuppliersDetailsListEntity> supplierDetailsListShipCountry;
        private List<SuppliersDetailsListEntity> supplierDetailsListShipPinCode;

        private string _CurrencyName;
        private string _CurrencyCode;
        private string _CurrencyFormat;
        private string _DateFormat;
        private int? _DecimalPlaces;
        private string _TaxName;
        private int? _GridHeight;
        private string _JsonData;
        private string _LastupdatedDate;
        private bool? _ShowAllTrue;
        private bool? _ShowSelectedTrue;
        private int showAllCount;
        private int showSelectedCount;

        private string selectedName;
        private string selectedCompRegNo;
        private string selectedGSTRegNo;
        private string selectedTelephone;
        private string selectedFax;
        private string selectedEmail;
        private string selectedContact;

        private string selectedBalance;
        private string selectedType;
        private string selectedSalesman;
        private string selectedCreditLimitDays;
        private string selectedCreditLimitAmount;
        private string selectedDiscount;

        private string selectedBillToLine1;
        private string selectedBillToLine2;
        private string selectedBillToCity;
        private string selectedBillToState;
        private string selectedBillToCountry;
        private string selectedBillToPinCode;

        private string selectedShipToLine1;
        private string selectedShipToLine2;
        private string selectedShipToCity;
        private string selectedShipToState;
        private string selectedShipToCountry;
        private string selectedShipToPinCode;

        private bool? showActive;
        private bool? showInactive;
        private bool? showBoth;
        private int showActiveCount;
        private int showInactiveCount;
        private int showBothCount;
        private string totalBalance;
        #endregion

        #region "Public Properties"
        public string TotalBalance
        {
            get
            {
                //return _StandardSellPriceStr;
                if (totalBalance == null)
                    return this.totalBalance;
                else
                {
                    if (totalBalance != "")
                    {
                        var balance = totalBalance.Replace(",", "");
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
                        return this.totalBalance;
                }
            }
            set
            {
                totalBalance = value;
                OnPropertyChanged("TotalBalance");
            }
        }
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public string Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
                OnPropertyChanged("Active");
            }
        }
        public string InActive
        {
            get { return _InActive; }
            set
            {
                _InActive = value;
                OnPropertyChanged("InActive");
            }
        }
        public string Both
        {
            get { return _Both; }
            set
            {
                _Both = value;
                OnPropertyChanged("Both");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string CompanyRegNo
        {
            get { return compRegNo; }
            set
            {
                compRegNo = value;
                OnPropertyChanged("CompRegNo");
            }
        }
        public string GSTRegNo
        {
            get { return gstRegNo; }
            set
            {
                gstRegNo = value;
                OnPropertyChanged("GSTRegNo");
            }
        }
        public string Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
                OnPropertyChanged("Telephone");
            }
        }
        public string Fax
        {
            get { return fax; }
            set
            {
                fax = value;
                OnPropertyChanged("Fax");
            }
        }

        public string IsInactive
        {
            get { return isInactive; }
            set
            {
                isInactive = value;
                OnPropertyChanged("IsInactive");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string ContactPerson
        {
            get { return contact; }
            set
            {
                contact = value;
                OnPropertyChanged("Contact");
            }
        }
        public string BalanceStr
        {
            get
            {
                if (balanceStr == null)
                    return this.balanceStr;
                else
                {
                    if (balanceStr != "")
                    {
                        var balance = balanceStr.Replace(",", "");
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
                        return this.balanceStr;
                }
            }
            set
            {
                balanceStr = value;
                OnPropertyChanged("BalanceStr");
            }
        }
        public decimal? Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        public string Salesman
        {
            get { return salesman; }
            set
            {
                salesman = value;
                OnPropertyChanged("Salesman");
            }
        }
        public int? CreditLimitDays
        {
            get { return creditLimitDays; }
            set
            {
                creditLimitDays = value;
                OnPropertyChanged("CreditLimitDays");
            }
        }
        public string CreditLimitAmountStr
        {
            get
            {
                if (creditLimitAmountStr == null)
                    return this.creditLimitAmountStr;
                else
                {
                    if (creditLimitAmountStr != "")
                    {
                        var balance = creditLimitAmountStr.Replace(",", "");
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
                        return this.creditLimitAmountStr;
                }
            }
            set
            {
                creditLimitAmountStr = value;
                OnPropertyChanged("CreditLimitAmountStr");
            }
        }

        public int ShowActiveCount
        {
            get { return showActiveCount; }
            set
            {
                showActiveCount = value;
                OnPropertyChanged("ShowActiveCount");
            }
        }
        public int ShowInactiveCount
        {
            get { return showInactiveCount; }
            set
            {
                showInactiveCount = value;
                OnPropertyChanged("ShowInactiveCount");
            }
        }
        public int ShowBothCount
        {
            get { return showBothCount; }
            set
            {
                showBothCount = value;
                OnPropertyChanged("ShowBothCount");
            }
        }

        public decimal? CreditLimitAmount
        {
            get { return creditLimitAmount; }
            set
            {
                creditLimitAmount = value;
                OnPropertyChanged("CreditLimitAmount");
            }
        }
        public int? Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                OnPropertyChanged("Discount");
            }
        }
        public string BillToLine1
        {
            get { return billToLine1; }
            set
            {
                billToLine1 = value;
                OnPropertyChanged("BillToLine1");
            }
        }
        public string BillToLine2
        {
            get { return billToLine2; }
            set
            {
                billToLine2 = value;
                OnPropertyChanged("BillToLine2");
            }
        }
        public string BillToCity
        {
            get { return billToCity; }
            set
            {
                billToCity = value;
                OnPropertyChanged("BillToCity");
            }
        }
        public string BillToState
        {

            get { return billToState; }
            set
            {
                billToState = value;
                OnPropertyChanged("BillToState");
            }
        }
        public string BillToCountry
        {
            get { return billToCountry; }
            set
            {
                billToCountry = value;
                OnPropertyChanged("BillToCountry");
            }
        }
        public string BillToPostCode
        {
            get { return billToPostCode; }
            set
            {
                billToPostCode = value;
                OnPropertyChanged("BillToPostCode");
            }
        }

        public string ShipToLine1
        {
            get { return shipToLine1; }
            set
            {
                shipToLine1 = value;
                OnPropertyChanged("ShipToLine1");
            }
        }
        public string ShipToLine2
        {
            get { return shipToLine2; }
            set
            {
                shipToLine2 = value;
                OnPropertyChanged("ShipToLine2");
            }
        }
        public string ShipToCity
        {
            get { return shipToCity; }
            set
            {
                shipToCity = value;
                OnPropertyChanged("ShipToCity");
            }
        }
        public string ShipToState
        {
            get { return shipToState; }
            set
            {
                shipToState = value;
                OnPropertyChanged("ShipToState");
            }
        }
        public string ShipToCountry
        {
            get { return shipToCountry; }
            set
            {
                shipToCountry = value;
                OnPropertyChanged("ShipToCountry");
            }
        }
        public string ShipToPostCode
        {
            get { return shipToPostCode; }
            set
            {
                shipToPostCode = value;
                OnPropertyChanged("ShipToPostCode");
            }
        }

        public string CurrencyName
        {
            get { return _CurrencyName; }
            set
            {
                _CurrencyName = value;
                OnPropertyChanged("CurrencyName");
            }
        }
        public string CurrencyCode
        {
            get { return _CurrencyCode; }
            set
            {
                _CurrencyCode = value;
                OnPropertyChanged("CurrencyCode");
            }
        }
        public string CurrencyFormat
        {
            get { return _CurrencyFormat; }
            set
            {
                _CurrencyFormat = value;
                OnPropertyChanged("CurrencyFormat");
            }
        }
        public string DateFormat
        {
            get { return _DateFormat; }
            set
            {
                _DateFormat = value;
                OnPropertyChanged("DateFormat");
            }
        }
        public int? DecimalPlaces
        {
            get { return _DecimalPlaces; }
            set
            {
                _DecimalPlaces = value;
                OnPropertyChanged("DecimalPlaces");
            }
        }
        public string TaxName
        {
            get { return _TaxName; }
            set
            {
                _TaxName = value;
                OnPropertyChanged("TaxName");
            }
        }
        public int? GridHeight
        {
            get { return _GridHeight; }
            set
            {
                _GridHeight = value;
                OnPropertyChanged("GridHeight");
            }

        }
        public string JsonData
        {
            get { return _JsonData; }
            set
            {
                _JsonData = value;
                OnPropertyChanged("JsonData");
            }

        }
        public string LastupdatedDate
        {
            get { return _LastupdatedDate; }
            set
            {
                _LastupdatedDate = value;
                OnPropertyChanged("LastupdatedDate");
            }

        }

        public bool? ShowAllTrue
        {
            get { return _ShowAllTrue; }
            set
            {
                _ShowAllTrue = value;
                OnPropertyChanged("ShowAllTrue");
            }
        }
        public bool? ShowSelectedTrue
        {
            get { return _ShowSelectedTrue; }
            set
            {
                _ShowSelectedTrue = value;
                OnPropertyChanged("ShowSelectedTrue");
            }
        }

        public int ShowAllCount
        {
            get { return showAllCount; }
            set
            {
                showAllCount = value;
                OnPropertyChanged("ShowAllCount");
            }
        }
        public int ShowSelectedCount
        {
            get { return showSelectedCount; }
            set
            {
                showSelectedCount = value;
                OnPropertyChanged("ShowSelectedCount");
            }
        }

        public bool? ShowActive
        {
            get { return showActive; }
            set
            {
                showActive = value;
                OnPropertyChanged("ShowActive");
            }
        }
        public bool? ShowInactive
        {
            get { return showInactive; }
            set
            {
                showInactive = value;
                OnPropertyChanged("ShowInactive");
            }
        }
        public bool? ShowBoth
        {
            get { return showBoth; }
            set
            {
                showBoth = value;
                OnPropertyChanged("ShowBoth");
            }
        }


        public string SelectedName
        {
            get { return selectedName; }
            set
            {
                selectedName = value;
                OnPropertyChanged("SelectedName");
            }
        }
        public string SelectedCompRegNo
        {
            get { return selectedCompRegNo; }
            set
            {
                selectedCompRegNo = value;
                OnPropertyChanged("SelectedCompRegNo");
            }
        }
        public string SelectedGSTRegNo
        {
            get { return selectedGSTRegNo; }
            set
            {
                selectedGSTRegNo = value;
                OnPropertyChanged("SelectedGSTRegNo");
            }
        }
        public string SelectedTelephone
        {
            get { return selectedTelephone; }
            set
            {
                selectedTelephone = value;
                OnPropertyChanged("SelectedTelephone");
            }
        }
        public string SelectedFax
        {
            get { return selectedFax; }
            set
            {
                selectedFax = value;
                OnPropertyChanged("SelectedFax");
            }
        }
        public string SelectedEmail
        {
            get { return selectedEmail; }
            set
            {
                selectedEmail = value;
                OnPropertyChanged("SelectedEmail");
            }
        }
        public string SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedContact");
            }
        }

        public string SelectedBalance
        {
            get { return selectedBalance; }
            set
            {
                selectedBalance = value;
                OnPropertyChanged("SelectedBalance");
            }
        }
        public string SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }
        public string SelectedSalesman
        {
            get { return selectedSalesman; }
            set
            {
                selectedSalesman = value;
                OnPropertyChanged("SelectedSalesman");
            }
        }
        public string SelectedCreditLimitDays
        {
            get { return selectedCreditLimitDays; }
            set
            {
                selectedCreditLimitDays = value;
                OnPropertyChanged("SelectedCreditLimitDays");
            }
        }
        public string SelectedCreditLimitAmount
        {
            get { return selectedCreditLimitAmount; }
            set
            {
                selectedCreditLimitAmount = value;
                OnPropertyChanged("SelectedCreditLimitAmount");
            }
        }
        public string SelectedDiscount
        {
            get { return selectedDiscount; }
            set
            {
                selectedDiscount = value;
                OnPropertyChanged("SelectedDiscount");
            }
        }

        public string SelectedBillToLine1
        {
            get { return selectedBillToLine1; }
            set
            {
                selectedBillToLine1 = value;
                OnPropertyChanged("SelectedBillToLine1");
            }
        }
        public string SelectedBillToLine2
        {
            get { return selectedBillToLine2; }
            set
            {
                selectedBillToLine2 = value;
                OnPropertyChanged("SelectedBillToLine2");
            }
        }
        public string SelectedBillToCity
        {
            get { return selectedBillToCity; }
            set
            {
                selectedBillToCity = value;
                OnPropertyChanged("SelectedBillToCity");
            }
        }
        public string SelectedBillToState
        {
            get { return selectedBillToState; }
            set
            {
                selectedBillToState = value;
                OnPropertyChanged("SelectedBillToState");
            }
        }
        public string SelectedBillToCountry
        {
            get { return selectedBillToCountry; }
            set
            {
                selectedBillToCountry = value;
                OnPropertyChanged("SelectedBillToCountry");
            }
        }
        public string SelectedBillToPinCode
        {
            get { return selectedBillToPinCode; }
            set
            {
                selectedBillToPinCode = value;
                OnPropertyChanged("SelectedBillToPinCode");
            }
        }

        public string SelectedShipToLine1
        {
            get { return selectedShipToLine1; }
            set
            {
                selectedShipToLine1 = value;
                OnPropertyChanged("SelectedShipToLine1");
            }
        }
        public string SelectedShipToLine2
        {
            get { return selectedShipToLine2; }
            set
            {
                selectedShipToLine2 = value;
                OnPropertyChanged("SelectedShipToLine2");
            }
        }
        public string SelectedShipToCity
        {
            get { return selectedShipToCity; }
            set
            {
                selectedShipToCity = value;
                OnPropertyChanged("SelectedShipToCity");
            }
        }
        public string SelectedShipToState
        {
            get { return selectedShipToState; }
            set
            {
                selectedShipToState = value;
                OnPropertyChanged("SelectedShipToState");
            }
        }
        public string SelectedShipToCountry
        {
            get { return selectedShipToCountry; }
            set
            {
                selectedShipToCountry = value;
                OnPropertyChanged("SelectedShipToCountry");
            }
        }
        public string SelectedShipToPinCode
        {
            get { return selectedShipToPinCode; }
            set
            {
                selectedShipToPinCode = value;
                OnPropertyChanged("SelectedShipToPinCode");
            }
        }

        public List<SuppliersDetailsListEntity> SupplierDetailsList
        {
            get { return supplierDetailsList1; }
            set
            {
                supplierDetailsList1 = value;
                OnPropertyChanged("SupplierDetailsList");
            }
        }


        public List<SuppliersDetailsListEntity> SupplierDetailsListCusName
        {
            get { return supplierDetailsListCusName; }
            set
            {
                supplierDetailsListCusName = value;
                OnPropertyChanged("SupplierDetailsListCusName");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListCompRegNo
        {
            get { return supplierDetailsListCompRegNo; }
            set
            {
                supplierDetailsListCompRegNo = value;
                OnPropertyChanged("SupplierDetailsListCompRegNo");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListGSTRegNo
        {
            get { return supplierDetailsListGSTRegNo; }
            set
            {
                supplierDetailsListGSTRegNo = value;
                OnPropertyChanged("SupplierDetailsListGSTRegNo");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListTelephone
        {
            get { return supplierDetailsListTelephone; }
            set
            {
                supplierDetailsListTelephone = value;
                OnPropertyChanged("SupplierDetailsListTelephone");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListFax
        {
            get { return supplierDetailsListFax; }
            set
            {
                supplierDetailsListFax = value;
                OnPropertyChanged("SupplierDetailsListFax");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListEmail
        {
            get { return supplierDetailsListEmail; }
            set
            {
                supplierDetailsListEmail = value;
                OnPropertyChanged("SupplierDetailsListEmail");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListContact
        {
            get { return supplierDetailsListContact; }
            set
            {
                supplierDetailsListContact = value;
                OnPropertyChanged("SupplierDetailsListContact");
            }
        }

        public List<SuppliersDetailsListEntity> SupplierDetailsListBalance
        {
            get { return supplierDetailsListBalance; }
            set
            {
                supplierDetailsListBalance = value;
                OnPropertyChanged("SupplierDetailsListBalance");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListType
        {
            get { return supplierDetailsListType; }
            set
            {
                supplierDetailsListType = value;
                OnPropertyChanged("SupplierDetailsListType");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListSaleman
        {
            get { return supplierDetailsListSaleman; }
            set
            {
                supplierDetailsListSaleman = value;
                OnPropertyChanged("SupplierDetailsListSaleman");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListCreditLimitDays
        {
            get { return supplierDetailsListCreditLimitDays; }
            set
            {
                supplierDetailsListCreditLimitDays = value;
                OnPropertyChanged("SupplierDetailsListCreditLimitDays");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListCreditLimitAmount
        {
            get { return supplierDetailsListCreditLimitAmount; }
            set
            {
                supplierDetailsListCreditLimitAmount = value;
                OnPropertyChanged("SupplierDetailsListCreditLimitAmount");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListDisount
        {
            get { return supplierDetailsListDisount; }
            set
            {
                supplierDetailsListDisount = value;
                OnPropertyChanged("SupplierDetailsListDisount");
            }
        }

        public List<SuppliersDetailsListEntity> SupplierDetailsListBillLine1
        {
            get { return supplierDetailsListBillLine1; }
            set
            {
                supplierDetailsListBillLine1 = value;
                OnPropertyChanged("SupplierDetailsListBillLine1");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListBillLine2
        {
            get { return supplierDetailsListBillLine2; }
            set
            {
                supplierDetailsListBillLine2 = value;
                OnPropertyChanged("SupplierDetailsListBillLine2");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListBillCity
        {
            get { return supplierDetailsListBillCity; }
            set
            {
                supplierDetailsListBillCity = value;
                OnPropertyChanged("SupplierDetailsListBillCity");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListBillState
        {
            get { return supplierDetailsListBillState; }
            set
            {
                supplierDetailsListBillState = value;
                OnPropertyChanged("SupplierDetailsListBillState");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListBillCountry
        {
            get { return supplierDetailsListBillCountry; }
            set
            {
                supplierDetailsListBillCountry = value;
                OnPropertyChanged("SupplierDetailsListBillCountry");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListBillPinCode
        {
            get { return supplierDetailsListBillPinCode; }
            set
            {
                supplierDetailsListBillPinCode = value;
                OnPropertyChanged("SupplierDetailsListBillPinCode");
            }
        }
        // ///////////////////////////////////////////////////
        public List<SuppliersDetailsListEntity> SupplierDetailsListShipLine1
        {
            get { return supplierDetailsListShipLine1; }
            set
            {
                supplierDetailsListShipLine1 = value;
                OnPropertyChanged("SupplierDetailsListShipLine1");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListShipLine2
        {
            get { return supplierDetailsListShipLine2; }
            set
            {
                supplierDetailsListShipLine2 = value;
                OnPropertyChanged("SupplierDetailsListShipLine2");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListShipCity
        {
            get { return supplierDetailsListShipCity; }
            set
            {
                supplierDetailsListShipCity = value;
                OnPropertyChanged("SupplierDetailsListShipCity");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListShipState
        {
            get { return supplierDetailsListShipState; }
            set
            {
                supplierDetailsListShipState = value;
                OnPropertyChanged("SupplierDetailsListShipState");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListShipCountry
        {
            get { return supplierDetailsListShipCountry; }
            set
            {
                supplierDetailsListShipCountry = value;
                OnPropertyChanged("SupplierDetailsListShipCountry");
            }
        }
        public List<SuppliersDetailsListEntity> SupplierDetailsListShipPinCode
        {
            get { return supplierDetailsListShipPinCode; }
            set
            {
                supplierDetailsListShipPinCode = value;
                OnPropertyChanged("SupplierDetailsListShipPinCode");
            }
        }

        #endregion
    }
}
