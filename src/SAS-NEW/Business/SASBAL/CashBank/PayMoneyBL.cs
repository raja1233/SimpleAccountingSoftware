
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.CashBank
{
    using SASDAL.CashBank;
    using SDN.UI.Entities;
    public class PayMoneyBL : IPayMoneyBL
    {
        public List<AccountsEntity> GetAccountDetails()
        {
            IPayMoneyDAL rmDAL = new PayMoneyDAL();
            return rmDAL.GetAccountDetails();
        }
        public int SavePayMoney(PayMoneyEntity receiveMoney)
        {
            IPayMoneyDAL rmDAL = new PayMoneyDAL();
            return rmDAL.SavePayMoney(receiveMoney);
        }
        public int UpdatePayMoney(PayMoneyEntity receiveMoney)
        {
            IPayMoneyDAL rmDAL = new PayMoneyDAL();
            return rmDAL.UpdatePayMoney(receiveMoney);
        }
        public PayMoneyEntity GetPayMoneyDetails(string cashChequeNo)
        {
            IPayMoneyDAL rmDAL = new PayMoneyDAL();
            return rmDAL.GetPayMoneyDetails(cashChequeNo);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IPayMoneyDAL rmDAL = new PayMoneyDAL();
            return rmDAL.IsChequeNoPresent(cashChequeNo);
        }
        public string GetLastCashNo()
        {
            IPayMoneyDAL rmDAL = new PayMoneyDAL();
            return rmDAL.GetLastCashNo();
        }
    }
}
