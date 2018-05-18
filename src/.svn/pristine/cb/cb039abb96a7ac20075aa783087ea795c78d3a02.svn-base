
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.CashBank
{
    using SASDAL.CashBank;
    using SDN.UI.Entities;
    public class TransferMoneyBL: ITransferMoneyBL
    {
        public List<AccountsEntity> GetAccountDetails()
        {
            ITransferMoneyDAL rmDAL = new TransferMoneyDAL();
            return rmDAL.GetAccountDetails();
        }
        public int SaveTransferMoney(TransferMoneyEntity transferMoney)
        {
            ITransferMoneyDAL rmDAL = new TransferMoneyDAL();
            return rmDAL.SaveTransferMoney(transferMoney);
        }
        public int UpdateTransferMoney(TransferMoneyEntity transferMoney)
        {
            ITransferMoneyDAL rmDAL = new TransferMoneyDAL();
            return rmDAL.UpdateTransferMoney(transferMoney);
        }
        public TransferMoneyEntity GetTransferMoneyDetails(string cashChequeNo)
        {
            ITransferMoneyDAL rmDAL = new TransferMoneyDAL();
            return rmDAL.GetTransferMoneyDetails(cashChequeNo);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            ITransferMoneyDAL rmDAL = new TransferMoneyDAL();
            return rmDAL.IsChequeNoPresent(cashChequeNo);
        }
        public string GetLastCashNo()
        {
            ITransferMoneyDAL rmDAL = new TransferMoneyDAL();
            return rmDAL.GetLastCashNo();
        }

        public bool CashChequeValidation(string chequeNo)
        {
            ITransferMoneyDAL rmDAL = new TransferMoneyDAL();
            return rmDAL.CashChequeValidation(chequeNo);
        }
    }
}
