
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.CashBank
{
    using SDN.UI.Entities;
    public interface IReceiveMoneyBL
    {
        List<AccountsEntity> GetAccountDetails();
        ReceiveMoneyEntity GetReceiveMoneyDetails(string cashChequeNo);
        int SaveReceiveMoney(ReceiveMoneyEntity receiveMoney);
        int UpdateReceiveMoney(ReceiveMoneyEntity receiveMoney);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
