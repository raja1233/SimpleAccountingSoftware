
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.CashBank.Services
{
    using SDN.UI.Entities;
    public interface IPayMoneyRepository
    {
        List<AccountsEntity> GetAccountDetails();
        PayMoneyEntity GetPayMoneyDetails(string cashChequeNo);
        int SavePayMoney(PayMoneyEntity receiveMoney);
        int UpdatePayMoney(PayMoneyEntity receiveMoney);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
