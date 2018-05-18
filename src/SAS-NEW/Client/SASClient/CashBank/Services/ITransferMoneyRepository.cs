﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.CashBank.Services
{
    using SDN.UI.Entities;
    public interface ITransferMoneyRepository
    {
        List<AccountsEntity> GetAccountDetails();
        TransferMoneyEntity GetTransferMoneyDetails(string cashChequeNo);
        int SaveTransferMoney(TransferMoneyEntity transferMoney);
        int UpdateTransferMoney(TransferMoneyEntity transferMoney);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
        bool CashChequeValidation(string chequeNo);
    }
}
