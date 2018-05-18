using SASBAL.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;

namespace SASClient.Accounts.Services
{
    public class AccountsTransactionsRepository : IAccountsTransactionsRepository
    {
        public List<AccountsTransactionsEntity> GetAccountsTransactionDetails(int ID,string JsonData)
        {
            IAccountsTransactionsBL accountsDetailList = new AccountsTransactionsBL();
            return accountsDetailList.GetAccountsTransactionDetails(ID, JsonData);
        }

        //public void GetAccountsTransactionNameAndType()
        //{
        //    IAccountsTransactionsBL accountsList = new AccountsTransactionsBL();
        //    accountsList.GetAccountsTransactionNameAndType();
        //}
        public List<AccountsTransactionsEntity> GetAccountsTransactionNameAndType()
        {
            IAccountsTransactionsBL accountsList = new AccountsTransactionsBL();
            return  accountsList.GetAccountsTransactionNameAndType();
        }

        public string GetDateFormat()
        {
            IAccountsTransactionsBL accountsList = new AccountsTransactionsBL();
            return accountsList.GetDateFormat();
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IAccountsTransactionsBL accountsList = new AccountsTransactionsBL();
            return accountsList.GetLastSelectionData(ScreenId);
        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IAccountsTransactionsBL accountsList = new AccountsTransactionsBL();
            return accountsList.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
    }
}
