namespace SDN.CashBank.ViewModels
{
    using Microsoft.Practices.Prism.Events;
    using UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Common;
    using Services;

    public class CashBankDetailViewModel : ViewModelBase
    {
        #region Private Properties
        private readonly IEventAggregator eventAggregator;
        private CashBankDetailEntity _cashbankdetails;
        private string companyname = "smartData";
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        int compId = -1;
        private event PropertyChangedEventHandler PropertyChanged;
        int PrivateSeletedIndex = 0;
        #endregion

        //public CashBankDetailViewModel(IEventAggregator eventAggregator)
        //{
        //    this.eventAggregator = eventAggregator;
        //    eventAggregator.GetEvent<CompanynameChangedEvent>().Publish(companyname);
        //}

        public CashBankDetailEntity CashBankDetails
        {
            get
            {
                return this._cashbankdetails;
            }
            set
            {
                this._cashbankdetails = value;
            }
        }

        //public ObservableCollection<AccountsEntity> AcountList
        //{
        //    get
        //    {
        //        ICashBankDetailsService CashBankDetails = new CashBankDetailsService();
        //        var _accountCollection = new ObservableCollection<AccountsEntity>(CashBankDetails.GetAccountDetails());
        //        return _accountCollection;
        //    }
        //}

        #region Constructor
        public CashBankDetailViewModel()
        {
            this.LoadOptionsBackground();
            ClickSaveCommand = new RelayCommand(SaveOptions, CanSave);
            ClickNewCommand = new RelayCommand(NewCommand);
            ClickDeleteCommand = new RelayCommand(DeleteCommand);
            UpdateBindingGroup = new System.Windows.Data.BindingGroup { Name = "Group1" };
        }
        #endregion


        public RelayCommand ClickSaveCommand { get; set; }
        public RelayCommand ClickNewCommand { get; set; }
        public RelayCommand ClickDeleteCommand { get; set; }

        void SaveOptions(object param)
        {
            ICashBankDetailsService CashBankDetails = new CashBankDetailsService();
            //UpdateBindingGroup.CommitEdit();
            int results = 0;
            var cashbankDetails = SelectedCashBank as CashBankDetailEntity;

            MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Save Content", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    results = CashBankDetails.AddEditCashBank(cashbankDetails);
                    break;
                case MessageBoxResult.No:
                    break;
            }

            if (results == 1)
            {
                var result1 = CashBankDetails.GetAccountDetails();
                var cashbankentity = SelectedCashBank as CashBankDetailEntity;
                cashbankentity.AccountDetails = result1;
                //cashbankentity.AccountName = string.Empty;
                //cashbankentity.AccountOpeningBal = string.Empty;
                //cashbankentity.IsInActive = false;
                if (result1.Count == 1)
                    cashbankentity.SeletedIndex = 0;
                else if (result1.Count > 0)
                    cashbankentity.SeletedIndex = PrivateSeletedIndex;
                if (cashbankentity.IsCashAccount == true)
                    cashbankentity.DeleteEnabled = false;
                else
                    cashbankentity.DeleteEnabled = true;


            }
            else if(results==2)
            {
                MessageBox.Show("Account Name already Exits.Please choose a different account name");
            }
            else 
            {
                MessageBox.Show("There was some problem in updating the entries, kindly try again later!");
            }

        }
        void NewCommand(object param)
        {
            var cashbank = SelectedCashBank as CashBankDetailEntity;
            ICashBankDetailsService CashBankDetails = new CashBankDetailsService();
            var result1 = CashBankDetails.GetAccountDetails();
            cashbank.AccountDetails = result1;
            if (result1.Count == 0)
                PrivateSeletedIndex = 0;
            else
                PrivateSeletedIndex = result1.Count;
            cashbank.AccountID = -1;
            cashbank.AccountName = string.Empty;
            cashbank.AccountOpeningBal = string.Empty;
            cashbank.IsInActive = false;
            cashbank.IsEnabled = true;
            cashbank.DeleteEnabled = false;
            cashbank.ReadOnlyAccountName = false;

        }
        void DeleteCommand(object param)
        {
            bool? result1 = false;
            ICashBankDetailsService CashBankDetails = new CashBankDetailsService();
            MessageBoxResult result = MessageBox.Show("Do you really want to delete the Cash and Bank Details?", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    var cashbank = SelectedCashBank as CashBankDetailEntity;
                    var candeletecashbank = CashBankDetails.CanDeleteCashBank(cashbank.AccountID);
                    if (candeletecashbank)
                    {
                        result1 = CashBankDetails.DeleteCashBank(cashbank.AccountID);
                        var cashbankentity = SelectedCashBank as CashBankDetailEntity;
                        var results = CashBankDetails.GetAccountDetails();

                        cashbankentity.AccountDetails = results;
                        //cashbankentity.IsEnabled = true;
                        //cashbankentity.IsInActive = false;

                        if (result1 == true)
                        {
                            if (results.Count - 1 >= PrivateSeletedIndex)
                                cashbankentity.SeletedIndex = PrivateSeletedIndex;
                            else if (results.Count - 1 == PrivateSeletedIndex - 1 && results.Count != 0)
                                cashbankentity.SeletedIndex = PrivateSeletedIndex - 1;
                            else
                            {
                                cashbankentity.AccountName = string.Empty;
                                cashbankentity.AccountOpeningBal = string.Empty;
                                cashbankentity.AccountID = -1;
                                cashbankentity.IsEnabled = true;
                                cashbankentity.IsInActive = false;
                                cashbankentity.SeletedIndex = 0;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There was some problem in deleting the entries, kindly try again later!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("You can delete this account!");
                    }
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }

        object _SelectedCashBank;
        public object SelectedCashBank
        {
            get
            {

                return _SelectedCashBank;
            }
            set
            {
                if (_SelectedCashBank != value)
                {
                    _SelectedCashBank = value;
                    RaisePropertyChanged("SelectedCashBank");
                }
            }
        }

        BindingGroup _UpdateBindingGroup;
        public BindingGroup UpdateBindingGroup
        {
            get
            {
                return _UpdateBindingGroup;
            }
            set
            {
                if (_UpdateBindingGroup != value)
                {
                    _UpdateBindingGroup = value;
                    RaisePropertyChanged("UpdateBindingGroup");
                }
            }
        }

        public void LoadOptionsBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            RefreshPage();
            //int compId = 0;
            Mouse.OverrideCursor = null;
        }

        public void RefreshPage()
        {
            SelectedCashBank = null; // Unselects last selection. Essential, as assignment below won't clear other control's SelectedItems
            var CashBank = new CashBankDetailEntity();

            ICashBankDetailsService CashBankDetails = new CashBankDetailsService();
            var results = CashBankDetails.GetDefaultCashBank();
            var accountinfo = CashBankDetails.GetAccountDetails();
            if (results != null)
            {
                results.AccountDetails = accountinfo;
                results.SeletedIndex = 0;
                SelectedCashBank = results;
            }

            //this.AccountDetails = customerRepository.GetAllCustomers().ToList();
            //if (SearchCustomer.Count > 0)
            //{
            //    this.SelectedSearchCustmer = SearchCustomer[0].ID;
            //    custId = SearchCustomer[0].ID;
            //}
            //else
            //{
            //    this.SelectedSearchCustmer = custId;
            //}
            //this.GetData(this.SelectedSearchCustmer);
        }

        public void LoadAccInfo(int AccountId, int selectedIndex)
        {
            ICashBankDetailsService CashBankDetails = new CashBankDetailsService();
            var results = CashBankDetails.GetAccInfo(AccountId);
            var accountinfo = SelectedCashBank as CashBankDetailEntity;
            if (results.AccuntTypeCode.ToLower() == "cab")
            {
                accountinfo.IsEnabled = false;
                accountinfo.ReadOnlyAccountName = true;
                accountinfo.DeleteEnabled = false;
                accountinfo.IsCashAccount = true;
            }
            else
            {
                accountinfo.DeleteEnabled = true;
                accountinfo.IsEnabled = true;
                accountinfo.ReadOnlyAccountName = false;
                accountinfo.IsCashAccount = false;

            }
            accountinfo.AccountID = results.AccountID;
            accountinfo.AccountOpeningBal = results.AccountOpeningBal;
            accountinfo.AccountName = results.AccountName;
            accountinfo.IsInActive = results.IsInActive;
            accountinfo.SeletedIndex = selectedIndex;
            PrivateSeletedIndex = selectedIndex;
            //OnPropertyChanged("Account");
        }

        public bool CanSave(object param)
        {

            if (SelectedCashBank != null)
            {
                var selectedOption = SelectedCashBank as CashBankDetailEntity;
                if (selectedOption.AccountName == null || selectedOption.AccountName == "" || selectedOption.AccountName == " ")
                    return false;
                else
                    return true;

            }
            else
                return false;
        }

    }
}
