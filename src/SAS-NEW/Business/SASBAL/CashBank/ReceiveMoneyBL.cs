
namespace SASBAL.CashBank
{
    using SASDAL.CashBank;
    using SDN.UI.Entities;
    using System.Collections.Generic;

    public class ReceiveMoneyBL: IReceiveMoneyBL
    {
       public List<AccountsEntity> GetAccountDetails()
        {
            IReceiveMoneyDAL rmDAL = new ReceiveMoneyDAL();
            return rmDAL.GetAccountDetails();
        }
        public int SaveReceiveMoney(ReceiveMoneyEntity receiveMoney)
        {
            IReceiveMoneyDAL rmDAL = new ReceiveMoneyDAL();
            return rmDAL.SaveReceiveMoney(receiveMoney);
        }
        public int UpdateReceiveMoney(ReceiveMoneyEntity receiveMoney)
        {
            IReceiveMoneyDAL rmDAL = new ReceiveMoneyDAL();
            return rmDAL.UpdateReceiveMoney(receiveMoney);
        }
        public ReceiveMoneyEntity GetReceiveMoneyDetails(string cashChequeNo)
        {
            IReceiveMoneyDAL rmDAL = new ReceiveMoneyDAL();
            return rmDAL.GetReceiveMoneyDetails(cashChequeNo);
        }
       public bool IsChequeNoPresent(string cashChequeNo)
        {
            IReceiveMoneyDAL rmDAL = new ReceiveMoneyDAL();
            return rmDAL.IsChequeNoPresent(cashChequeNo);
        }
        public string GetLastCashNo()
        {
            IReceiveMoneyDAL rmDAL = new ReceiveMoneyDAL();
            return rmDAL.GetLastCashNo();
        }
    }
}
