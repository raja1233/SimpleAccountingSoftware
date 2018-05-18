
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.CashBank
{
    using SDN.UI.Entities;
    public interface IPayMoneyBL
    {
        List<AccountsEntity> GetAccountDetails();
        PayMoneyEntity GetPayMoneyDetails(string cashChequeNo);
        int SavePayMoney(PayMoneyEntity receiveMoney);
        int UpdatePayMoney(PayMoneyEntity receiveMoney);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
