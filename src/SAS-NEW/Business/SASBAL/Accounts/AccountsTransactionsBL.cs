using SASDAL.Accounts;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Accounts
{
    public class AccountsTransactionsBL : IAccountsTransactionsBL
    {
        public List<AccountsTransactionsEntity> GetAccountsTransactionDetails(int ID, string JsonData)
        {
            IAccountsTransactionsDAL accountsDetailList = new AccountsTransactionsDAL();
            return accountsDetailList.GetAccountsTransactionDetails(ID,JsonData);
        }

        //List<AccountsTransactionsEntity> GetAccountsTransactionNameAndType()
        //{
        //    IAccountsTransactionsDAL accountsList = new AccountsTransactionsDAL();
        //     accountsList.GetAccountsTransactionNameAndType().ToList();
        //}
        public List<AccountsTransactionsEntity> GetAccountsTransactionNameAndType()
        {
            IAccountsTransactionsDAL accountsList = new AccountsTransactionsDAL();
            return accountsList.GetAccountsTransactionNameAndType();
        }

        public string GetDateFormat()
        {
            IAccountsTransactionsDAL accountsList = new AccountsTransactionsDAL();
            return accountsList.GetDateFormat();
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IAccountsTransactionsDAL accountsList = new AccountsTransactionsDAL();
            return accountsList.GetLastSelectionData(ScreenId);
        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IAccountsTransactionsDAL accountsList = new AccountsTransactionsDAL();
            return accountsList.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
    }
}
