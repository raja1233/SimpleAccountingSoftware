using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.CashBank
{
   public interface ITransferMoneyDAL
    {
        List<AccountsEntity> GetAccountDetails();
        int SaveTransferMoney(TransferMoneyEntity transferMoney);
        int UpdateTransferMoney(TransferMoneyEntity transferMoney);
        TransferMoneyEntity GetTransferMoneyDetails(string cashChequeNo);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
        bool CashChequeValidation(string chequeNo);
    }
}
