using SDN.CashBank.BL;
using SDN.CashBank.BLInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.CashBank.Services
{
    public class CashBankDetailsService:ICashBankDetailsService
    {
        public List<AccountsEntity> GetAccountDetails()
        {
            ICashBankDetailsBL cashbankBL = new CashBankDetailsBL();
            List<AccountsEntity> result = cashbankBL.GetAccountDetails();
            return result;
        }
        public CashBankDetailEntity GetDefaultCashBank()
        {
            ICashBankDetailsBL cashbankBL = new CashBankDetailsBL();
            CashBankDetailEntity result = cashbankBL.GetDefaultCashBank();
            return result;
        }
        public CashBankDetailEntity GetAccInfo(int AccountId)
        {
            ICashBankDetailsBL cashbankBL = new CashBankDetailsBL();
            CashBankDetailEntity result = cashbankBL.GetAccInfo(AccountId);
            return result;
        }
        public int AddEditCashBank(CashBankDetailEntity cashbankEntity)
        {
            ICashBankDetailsBL cashbankBL = new CashBankDetailsBL();
            int result = cashbankBL.AddEditCashBank(cashbankEntity);
            return result;
        }

        public bool DeleteCashBank(int AccountId)
        {
            ICashBankDetailsBL cashbankBL = new CashBankDetailsBL();
            bool result = cashbankBL.DeleteCashBank(AccountId);
            return result;
        }
        public bool CanDeleteCashBank(int AccountId)
        {
            ICashBankDetailsBL cashbankBL = new CashBankDetailsBL();
            bool result = cashbankBL.CanDeleteCashBank(AccountId);
            return result;
        }
    }
}
