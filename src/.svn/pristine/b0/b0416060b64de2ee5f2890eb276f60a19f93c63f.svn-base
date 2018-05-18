using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.CashBank
{
   public interface ITransferMoneyBL
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
