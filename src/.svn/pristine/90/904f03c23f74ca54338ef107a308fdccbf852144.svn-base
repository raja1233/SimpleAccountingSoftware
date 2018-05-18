namespace SDN.CashBank.DAL
{
    using SDN.CashBank.DALInterface;
    using SDN.CashBank.EDM;
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CashBankDetialDAL : ICashBankDetialsDAL
    {
        SDNCashBankDBEntities entites = new SDNCashBankDBEntities();
        public List<AccountsEntity> GetAccountDetails()
        {
            List<AccountsEntity> accountsource = entites.Accounts.Select(x => new AccountsEntity
            {
                AccountName = x.Acc_Name,
                AccountID = x.ID,
                AccountType = x.Acc_Type,
                //AccuntTypeCode = x.AccountType.Acc_Type_Code
            }).ToList();
            return accountsource;
        }

        public CashBankDetailEntity GetDefaultCashBank()
        {
            var cashbank = entites.AccountTypes.Where(x => x.Acc_Type_Code == "ACB").Select(x => new CashBankDetailEntity
            {
                AccountType = x.Acc_Type_Name,
                IsInActive = false
            }).FirstOrDefault();
            return cashbank;
        }
        public CashBankDetailEntity GetAccInfo(int AccountId)
        {
            var cashbank = entites.Accounts.Where(x => x.ID == AccountId).Select(x => new CashBankDetailEntity
            {
                AccountName = x.Acc_Name,
                AccountID = x.ID,
                AccountOpeningBal = x.Acc_Open_Bal.ToString(),
                AccountType = x.Acc_Type.ToString(),
                //AccuntTypeCode = x.AccountType.Acc_Type_Code,
                IsInActivestring = x.Acc_Inactive
            }).FirstOrDefault();
            return cashbank;
        }

        public int AddEditCashBank(CashBankDetailEntity cashbankentity)
        {
            try
            {
                var cashbank = entites.Accounts.Where(x => x.ID == cashbankentity.AccountID).FirstOrDefault();
                var checkduplicate = entites.Accounts.Where(x => x.Acc_Name.ToLower() == cashbankentity.AccountName.ToLower()&& x.IsDeleted!=true).FirstOrDefault();
                //if (checkduplicate != null)
                //{
                //    return 2;
                //}
                //else
                //{
                if (cashbank != null)
                {
                    cashbank.Acc_Name = cashbankentity.AccountName;
                    cashbank.Acc_Open_Bal = cashbankentity.AccountOpeningBal == null ? null as decimal? : Convert.ToDecimal(cashbankentity.AccountOpeningBal);
                    cashbank.Acc_Inactive = cashbankentity.IsInActivestring;
                    entites.SaveChanges();
                    return 1;
                }
                else
                {
                    if (checkduplicate != null)
                    {
                        return 2;
                    }
                    Account AccDetail = new Account()
                    {
                        Acc_Name = cashbankentity.AccountName,
                        Acc_Open_Bal = cashbankentity.AccountOpeningBal == null ? null as decimal? : Convert.ToDecimal(cashbankentity.AccountOpeningBal),
                        Acc_Inactive = cashbankentity.IsInActivestring
                    };
                    if (cashbankentity.AccountName.ToLower().Trim() == "cash")
                    {
                        //var accType = entites.AccountTypes.Where(x => x.Acc_Type_Code == "CAB").FirstOrDefault();
                        //if (accType != null)
                        //    AccDetail.Acc_Type = accType.ID;
                        return 2;
                    }
                    else
                    {
                        var accType = entites.AccountTypes.Where(x => x.Acc_Type_Code == "ACB").FirstOrDefault();
                        if (accType != null)
                            AccDetail.Acc_Type = accType.ID;
                    }
                    entites.Accounts.Add(AccDetail);
                    entites.SaveChanges();
                    return 1;
                }
                //}
            }
            catch (Exception ex)
            {
                return 3;
                throw ex;
            }
        }

        public bool DeleteCashBank(int AccountId)
        {
            try
            {
                var cashbank = entites.Accounts.Where(x => x.ID == AccountId).FirstOrDefault();
                if (cashbank != null)
                {
                    cashbank.IsDeleted = true;
                    entites.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public bool CanDeleteCashBank(int AccountId)
        {
            try
            {
                var cashbank = entites.AccountsTransactions.Where(x => x.Acc_Id == AccountId).FirstOrDefault();
                if (cashbank != null)
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }



}
