
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.CashBank.Services
{
    using SDN.UI.Entities;
    public interface IReceiveMoneyRepository
    {
        List<AccountsEntity> GetAccountDetails();
        ReceiveMoneyEntity GetReceiveMoneyDetails(string cashChequeNo);
        int SaveReceiveMoney(ReceiveMoneyEntity receiveMoney);
        int UpdateReceiveMoney(ReceiveMoneyEntity receiveMoney);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
