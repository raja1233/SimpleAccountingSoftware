
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.CashBank.Services
{
    using SASBAL.CashBank;
    using SDN.UI.Entities;
    public class TransferMoneyRepository: ITransferMoneyRepository
    {
        public List<AccountsEntity> GetAccountDetails()
        {
            ITransferMoneyBL rmDAL = new TransferMoneyBL();
            return rmDAL.GetAccountDetails();
        }
        public int SaveTransferMoney(TransferMoneyEntity transferMoney)
        {
            ITransferMoneyBL rmDAL = new TransferMoneyBL();
            return rmDAL.SaveTransferMoney(transferMoney);
        }
        public int UpdateTransferMoney(TransferMoneyEntity transferMoney)
        {
            ITransferMoneyBL rmDAL = new TransferMoneyBL();
            return rmDAL.UpdateTransferMoney(transferMoney);
        }
        public TransferMoneyEntity GetTransferMoneyDetails(string cashChequeNo)
        {
            ITransferMoneyBL rmDAL = new TransferMoneyBL();
            return rmDAL.GetTransferMoneyDetails(cashChequeNo);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            ITransferMoneyBL rmDAL = new TransferMoneyBL();
            return rmDAL.IsChequeNoPresent(cashChequeNo);
        }
        public string GetLastCashNo()
        {
            ITransferMoneyBL rmDAL = new TransferMoneyBL();
            return rmDAL.GetLastCashNo();
        }

        public bool CashChequeValidation(string chequeNo)
        {
            ITransferMoneyBL obj = new TransferMoneyBL();
            return obj.CashChequeValidation(chequeNo);
        }
    }
}
