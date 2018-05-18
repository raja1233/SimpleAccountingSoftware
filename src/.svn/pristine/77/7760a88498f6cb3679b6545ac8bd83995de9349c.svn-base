using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.CashBank.DALInterface
{
    public interface ICashBankDetialsDAL
    {
        List<AccountsEntity> GetAccountDetails();
        CashBankDetailEntity GetDefaultCashBank();
        CashBankDetailEntity GetAccInfo(int AccountId);
        int AddEditCashBank(CashBankDetailEntity cashbankEntity);
        bool DeleteCashBank(int AccountId);
        bool CanDeleteCashBank(int AccountId);
    }
}
