
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.CashBank
{
    using SDN.UI.Entities;
    public interface IPayMoneyDAL
    {
        List<AccountsEntity> GetAccountDetails();
        int SavePayMoney(PayMoneyEntity receiveMoney);
        int UpdatePayMoney(PayMoneyEntity receiveMoney);
        PayMoneyEntity GetPayMoneyDetails(string cashChequeNo);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
