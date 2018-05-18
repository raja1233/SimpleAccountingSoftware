using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.CashandBank;
using SASDAL.CashBank;

namespace SASBAL.CashBank
{
    public class AccountsDetailsListBL : IAccountsDetailsListBL
    {
        public List<AccountsDetailsListEntity> GetAllAccountsDetails()
        {
            IAccountsDetailsListDAL accountsDetailsDAL = new AccountsDetailsListDAL();
            return accountsDetailsDAL.GetAllAccountsDetailsList();
        }

        public AccountsDetailsListEntity StartNewFinancialYear(string status)
        {
            IAccountsDetailsListDAL obj = new AccountsDetailsListDAL();
            return obj.StartNewFinancialYear(status);
        }

        public string UpdatePreviousAccount()
        {
            IAccountsDetailsListDAL obj = new AccountsDetailsListDAL();
            return obj.UpdatePreviousAccount();
        }
    }
}
