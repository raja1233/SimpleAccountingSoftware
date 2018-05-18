﻿using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Accounts
{
    public interface IAccountsTransactionsDAL
    {
        List<AccountsTransactionsEntity> GetAccountsTransactionNameAndType();
        List<AccountsTransactionsEntity> GetAccountsTransactionDetails(int ID, string JsonData);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
    }
}

