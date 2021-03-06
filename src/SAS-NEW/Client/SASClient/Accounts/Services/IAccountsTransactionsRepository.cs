﻿using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Accounts.Services
{
    public  interface IAccountsTransactionsRepository
    {
        /// <summary>
        /// get account and type name 
        /// </summary>
        /// <returns></returns>
         List<AccountsTransactionsEntity> GetAccountsTransactionNameAndType();
        /// <summary>
        /// get account and type details 
        /// </summary>
        /// <returns></returns>
        List<AccountsTransactionsEntity> GetAccountsTransactionDetails(int ID,string JsonData);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
    }
}
