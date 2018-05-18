
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.CashBank.Services
{
    using SASBAL.CashBank;
    using SDN.UI.Entities;
    public class ReceiveMoneyRepository: IReceiveMoneyRepository
    {
        public List<AccountsEntity> GetAccountDetails()
        {
            IReceiveMoneyBL rmDAL = new ReceiveMoneyBL();
            return rmDAL.GetAccountDetails();
        }
        public int SaveReceiveMoney(ReceiveMoneyEntity receiveMoney)
        {
            IReceiveMoneyBL rmDAL = new ReceiveMoneyBL();
            return rmDAL.SaveReceiveMoney(receiveMoney);
        }
        public int UpdateReceiveMoney(ReceiveMoneyEntity receiveMoney)
        {
            IReceiveMoneyBL rmDAL = new ReceiveMoneyBL();
            return rmDAL.UpdateReceiveMoney(receiveMoney);
        }
        public ReceiveMoneyEntity GetReceiveMoneyDetails(string cashChequeNo)
        {
            IReceiveMoneyBL rmDAL = new ReceiveMoneyBL();
            return rmDAL.GetReceiveMoneyDetails(cashChequeNo);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IReceiveMoneyBL rmDAL = new ReceiveMoneyBL();
            return rmDAL.IsChequeNoPresent(cashChequeNo);
        }
        public string GetLastCashNo()
        {
            IReceiveMoneyBL rmDAL = new ReceiveMoneyBL();
            return rmDAL.GetLastCashNo();
        }
    }
}
