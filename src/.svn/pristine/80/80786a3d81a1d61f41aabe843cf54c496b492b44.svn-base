
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.UI.Entities.Customers
{
    using SDN.Common;
    using System.Globalization;

    public class CustomersDetailsListEntity : ViewModelBase
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
        private string salesman;
        private int? creditLimitDays;
        private string creditLimitAmountStr;
        private int? creditLimitAmount;
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

        private List<CustomersDetailsListEntity> customerDetailsList1;
        //private List<CustomersDetailsListEntity> customerDetailsList2;
        //private List<CustomersDetailsListEntity> customerDetailsList3;
        //private List<CustomersDetailsListEntity> customerDetailsList4;

        private List<CustomersDetailsListEntity> customerDetailsListCusName;
        private List<CustomersDetailsListEntity> customerDetailsListCompRegNo;
        private List<CustomersDetailsListEntity> customerDetailsListGSTRegNo;
        private List<CustomersDetailsListEntity> customerDetailsListTelephone;
        private List<CustomersDetailsListEntity> customerDetailsListFax;
        private List<CustomersDetailsListEntity> customerDetailsListEmail;
        private List<CustomersDetailsListEntity> customerDetailsListContact;
        // //////////////////////////////////////////
        private List<CustomersDetailsListEntity> customerDetailsListBalance;
        private List<CustomersDetailsListEntity> customerDetailsListType;
        private List<CustomersDetailsListEntity> customerDetailsListSaleman;
        private List<CustomersDetailsListEntity> customerDetailsListCreditLimitDays;
        private List<CustomersDetailsListEntity> customerDetailsListCreditLimitAmount;
        private List<CustomersDetailsListEntity> customerDetailsListDisount;
        // ////////////////////////////////////////////////
        private List<CustomersDetailsListEntity> customerDetailsListBillLine1;
        private List<CustomersDetailsListEntity> customerDetailsListBillLine2;
        private List<CustomersDetailsListEntity> customerDetailsListBillCity;
        private List<CustomersDetailsListEntity> customerDetailsListBillState;
        private List<CustomersDetailsListEntity> customerDetailsListBillCountry;
        private List<CustomersDetailsListEntity> customerDetailsListBillPinCode;
        // ///////////////////////////////////////////////////
        private List<CustomersDetailsListEntity> customerDetailsListShipLine1;
        private List<CustomersDetailsListEntity> customerDetailsListShipLine2;
        private List<CustomersDetailsListEntity> customerDetailsListShipCity;
        private List<CustomersDetailsListEntity> customerDetailsListShipState;
        private List<CustomersDetailsListEntity> customerDetailsListShipCountry;
        private List<CustomersDetailsListEntity> customerDetailsListShipPinCode;

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
        private string isInactive;
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
            set { id = value;
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

        public string IsInactive
        {
            get { return isInactive; }
            set
            {
                isInactive = value;
                OnPropertyChanged("IsInactive");
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
        public int? CreditLimitAmount
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

        public List<CustomersDetailsListEntity> CustomerDetailsList
        {
            get { return customerDetailsList1; }
            set
            {
                customerDetailsList1 = value;
                OnPropertyChanged("CustomerDetailsList");
            }
        }


        public List<CustomersDetailsListEntity> CustomerDetailsListCusName
        {
            get { return customerDetailsListCusName; }
            set
            {
                customerDetailsListCusName = value;
                OnPropertyChanged("CustomerDetailsListCusName");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListCompRegNo
        {
            get { return customerDetailsListCompRegNo; }
            set
            {
                customerDetailsListCompRegNo = value;
                OnPropertyChanged("CustomerDetailsListCompRegNo");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListGSTRegNo
        {
            get { return customerDetailsListGSTRegNo; }
            set
            {
                customerDetailsListGSTRegNo = value;
                OnPropertyChanged("CustomerDetailsListGSTRegNo");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListTelephone
        {
            get { return customerDetailsListTelephone; }
            set
            {
                customerDetailsListTelephone = value;
                OnPropertyChanged("CustomerDetailsListTelephone");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListFax
        {
            get { return customerDetailsListFax; }
            set
            {
                customerDetailsListFax = value;
                OnPropertyChanged("CustomerDetailsListFax");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListEmail
        {
            get { return customerDetailsListEmail; }
            set
            {
                customerDetailsListEmail = value;
                OnPropertyChanged("CustomerDetailsListEmail");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListContact
        {
            get { return customerDetailsListContact; }
            set
            {
                customerDetailsListContact = value;
                OnPropertyChanged("CustomerDetailsListContact");
            }
        }

        public List<CustomersDetailsListEntity> CustomerDetailsListBalance
        {
            get { return customerDetailsListBalance; }
            set
            {
                customerDetailsListBalance = value;
                OnPropertyChanged("CustomerDetailsListBalance");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListType
        {
            get { return customerDetailsListType; }
            set
            {
                customerDetailsListType = value;
                OnPropertyChanged("CustomerDetailsListType");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListSaleman
        {
            get { return customerDetailsListSaleman; }
            set
            {
                customerDetailsListSaleman = value;
                OnPropertyChanged("CustomerDetailsListSaleman");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListCreditLimitDays
        {
            get { return customerDetailsListCreditLimitDays; }
            set
            {
                customerDetailsListCreditLimitDays = value;
                OnPropertyChanged("CustomerDetailsListCreditLimitDays");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListCreditLimitAmount
        {
            get { return customerDetailsListCreditLimitAmount; }
            set
            {
                customerDetailsListCreditLimitAmount = value;
                OnPropertyChanged("CustomerDetailsListCreditLimitAmount");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListDisount
        {
            get { return customerDetailsListDisount; }
            set
            {
                customerDetailsListDisount = value;
                OnPropertyChanged("CustomerDetailsListDisount");
            }
        }

        public List<CustomersDetailsListEntity> CustomerDetailsListBillLine1
        {
            get { return customerDetailsListBillLine1; }
            set
            {
                customerDetailsListBillLine1 = value;
                OnPropertyChanged("CustomerDetailsListBillLine1");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListBillLine2
        {
            get { return customerDetailsListBillLine2; }
            set
            {
                customerDetailsListBillLine2 = value;
                OnPropertyChanged("CustomerDetailsListBillLine2");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListBillCity
        {
            get { return customerDetailsListBillCity; }
            set
            {
                customerDetailsListBillCity = value;
                OnPropertyChanged("CustomerDetailsListBillCity");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListBillState
        {
            get { return customerDetailsListBillState; }
            set
            {
                customerDetailsListBillState = value;
                OnPropertyChanged("CustomerDetailsListBillState");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListBillCountry
        {
            get { return customerDetailsListBillCountry; }
            set
            {
                customerDetailsListBillCountry = value;
                OnPropertyChanged("CustomerDetailsListBillCountry");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListBillPinCode
        {
            get { return customerDetailsListBillPinCode; }
            set
            {
                customerDetailsListBillPinCode = value;
                OnPropertyChanged("CustomerDetailsListBillPinCode");
            }
        }
        // ///////////////////////////////////////////////////
        public List<CustomersDetailsListEntity> CustomerDetailsListShipLine1
        {
            get { return customerDetailsListShipLine1; }
            set
            {
                customerDetailsListShipLine1 = value;
                OnPropertyChanged("CustomerDetailsListShipLine1");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListShipLine2
        {
            get { return customerDetailsListShipLine2; }
            set
            {
                customerDetailsListShipLine2 = value;
                OnPropertyChanged("CustomerDetailsListShipLine2");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListShipCity
        {
            get { return customerDetailsListShipCity; }
            set
            {
                customerDetailsListShipCity = value;
                OnPropertyChanged("CustomerDetailsListShipCity");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListShipState
        {
            get { return customerDetailsListShipState; }
            set
            {
                customerDetailsListShipState = value;
                OnPropertyChanged("CustomerDetailsListShipState");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListShipCountry
        {
            get { return customerDetailsListShipCountry; }
            set
            {
                customerDetailsListShipCountry = value;
                OnPropertyChanged("CustomerDetailsListShipCountry");
            }
        }
        public List<CustomersDetailsListEntity> CustomerDetailsListShipPinCode
        {
            get { return customerDetailsListShipPinCode; }
            set
            {
                customerDetailsListShipPinCode = value;
                OnPropertyChanged("CustomerDetailsListShipPinCode");
            }
        }
    
        #endregion
    }
}
