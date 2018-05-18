using SDN.CashBank.BLInterface;
using SDN.CashBank.DAL;
using SDN.CashBank.DALInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.CashBank.BL
{
    public class CashBankDetailsBL : ICashBankDetailsBL
    {
        public List<AccountsEntity> GetAccountDetails()
        {
            ICashBankDetialsDAL CashBankDetails = new CashBankDetialDAL();
            var optionDAL = CashBankDetails.GetAccountDetails();
            return optionDAL;
        }
        public CashBankDetailEntity GetDefaultCashBank()
        {
            ICashBankDetialsDAL CashBankDetails = new CashBankDetialDAL();
            var optionDAL = CashBankDetails.GetDefaultCashBank();
            optionDAL.AccountOpeningBal = optionDAL.AccountOpeningBal==null?null: string.Format("{0:G29}", decimal.Parse(optionDAL.AccountOpeningBal));
            return optionDAL;
        }
        public CashBankDetailEntity GetAccInfo(int AccountId)
        {
            ICashBankDetialsDAL CashBankDetails = new CashBankDetialDAL();
            var optionDAL = CashBankDetails.GetAccInfo(AccountId);
            optionDAL.AccountOpeningBal = string.Format("{0:G29}", decimal.Parse(optionDAL.AccountOpeningBal));
            if (optionDAL.IsInActivestring == "Y")
                optionDAL.IsInActive = true;
            else
                optionDAL.IsInActive = false;
            return optionDAL;
        }
        public int AddEditCashBank(CashBankDetailEntity cashbankEntity)
        {
            ICashBankDetialsDAL CashBankDetails = new CashBankDetialDAL();
            //var openingbal = Convert.ToDecimal(cashbankEntity.AccountOpeningBal);
            cashbankEntity.AccountOpeningBal = string.Format("{0:G29}", decimal.Parse(cashbankEntity.AccountOpeningBal));
            if (cashbankEntity.IsInActive == true)
                cashbankEntity.IsInActivestring = "Y";
            else
                cashbankEntity.IsInActivestring = "N";
            int result = CashBankDetails.AddEditCashBank(cashbankEntity);
            return result;
        }
        public bool DeleteCashBank(int AccountId)
        {
            ICashBankDetialsDAL CashBankDetails = new CashBankDetialDAL();
            bool result = CashBankDetails.DeleteCashBank(AccountId);
            return result;
        }
        public bool CanDeleteCashBank(int AccountId)
        {
            ICashBankDetialsDAL CashBankDetails = new CashBankDetialDAL();
            bool result = CashBankDetails.CanDeleteCashBank(AccountId);
            return result;
        }
    }
}
