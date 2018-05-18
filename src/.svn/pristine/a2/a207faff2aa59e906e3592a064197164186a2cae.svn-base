
using SDN.CashBank.BL;
using SDN.CashBank.BLInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.CashBank.Services
{
    public class AccountDetailsService : IAccountDetailsService
    {
        public List<AccountsEntity> GetAccountDetails()
        {
            IAccountDetailsBL cashbankBL = new AccountDetailsBL();
            List<AccountsEntity> result = cashbankBL.GetAccountDetails();
            return result;
        }
        public AccountDetailEntity GetDefaultAccount()
        {
            IAccountDetailsBL cashbankBL = new AccountDetailsBL();
            AccountDetailEntity result = cashbankBL.GetDefaultAccount();
            return result;
        }
        public List<AccountsEntity> GetAccountTypes()
        {
            IAccountDetailsBL cashbankBL = new AccountDetailsBL();
            List<AccountsEntity> result = cashbankBL.GetAccountTypes();
            return result;
        }
        public AccountDetailEntity GetAccInfo(int AccountId)
        {
            IAccountDetailsBL cashbankBL = new AccountDetailsBL();
            AccountDetailEntity result = cashbankBL.GetAccInfo(AccountId);
            return result;
        }
        public int AddEditAccount(AccountDetailEntity cashbankEntity)
        {
            IAccountDetailsBL cashbankBL = new AccountDetailsBL();
            int result = cashbankBL.AddEditAccount(cashbankEntity);
            return result;
        }

        public bool DeleteAccount(int AccountId)
        {
            IAccountDetailsBL cashbankBL = new AccountDetailsBL();
            bool result = cashbankBL.DeleteAccount(AccountId);
            return result;
        }
        public bool CanDeleteAccount(int AccountId)
        {
            IAccountDetailsBL cashbankBL = new AccountDetailsBL();
            bool result = cashbankBL.CanDeleteAccount(AccountId);
            return result;
        }
    }
}
