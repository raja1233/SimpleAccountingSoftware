﻿namespace SDN.CashBank.Services
{
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAccountDetailsService
    {
        List<AccountsEntity> GetAccountDetails();
        AccountDetailEntity GetDefaultAccount();
        AccountDetailEntity GetAccInfo(int AccountId);
        int AddEditAccount(AccountDetailEntity cashbankEntity);
        bool DeleteAccount(int AccountId);
        bool CanDeleteAccount(int AccountId);
        List<AccountsEntity> GetAccountTypes();
        AccountsEntity StartNewFinancialYear(string status);
    }
}
