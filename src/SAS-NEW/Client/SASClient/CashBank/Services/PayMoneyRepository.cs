
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.CashBank.Services
{
    using SASBAL.CashBank;
    using SDN.UI.Entities;
    public class PayMoneyRepository : IPayMoneyRepository
    {
        public List<AccountsEntity> GetAccountDetails()
        {
            IPayMoneyBL rmDAL = new PayMoneyBL();
            return rmDAL.GetAccountDetails();
        }
        public int SavePayMoney(PayMoneyEntity receiveMoney)
        {
            IPayMoneyBL rmDAL = new PayMoneyBL();
            return rmDAL.SavePayMoney(receiveMoney);
        }
        public int UpdatePayMoney(PayMoneyEntity receiveMoney)
        {
            IPayMoneyBL rmDAL = new PayMoneyBL();
            return rmDAL.UpdatePayMoney(receiveMoney);
        }
        public PayMoneyEntity GetPayMoneyDetails(string cashChequeNo)
        {
            IPayMoneyBL rmDAL = new PayMoneyBL();
            return rmDAL.GetPayMoneyDetails(cashChequeNo);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IPayMoneyBL rmDAL = new PayMoneyBL();
            return rmDAL.IsChequeNoPresent(cashChequeNo);
        }
        public string GetLastCashNo()
        {
            IPayMoneyBL rmDAL = new PayMoneyBL();
            return rmDAL.GetLastCashNo();
        }
    }
}
