
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.CashBank
{
    using SDN.UI.Entities;
    public interface IReceiveMoneyDAL
    {
        List<AccountsEntity> GetAccountDetails();
        int SaveReceiveMoney(ReceiveMoneyEntity receiveMoney);
        int UpdateReceiveMoney(ReceiveMoneyEntity receiveMoney);
        ReceiveMoneyEntity GetReceiveMoneyDetails(string cashChequeNo);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
