﻿namespace SDN.CashBank.DAL
{
    using DALInterface;
    using SASDAL;
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountDetialDAL : IAccountDetialsDAL
    {
        SASEntitiesEDM entites = new SASEntitiesEDM();
        public List<AccountsEntity> GetAccountDetails()
        {
          
            List<AccountsEntity> accountsource = entites.Database.SqlQuery<AccountsEntity>("AccountsDetails").ToList();
            return accountsource;
            

        }
        public List<AccountsEntity> GetAccountTypes()
        {
            List<AccountsEntity> accountsource = entites.AccountTypes.Select(x => new AccountsEntity
            {
               AccountName = x.Acc_Type_Name,
               AccuntTypeCode = x.Acc_Type_Code
                
            }).ToList();
            return accountsource;
        }

        public AccountDetailEntity GetDefaultAccount()
        {
            var cashbank = entites.AccountTypes.Select(x => new AccountDetailEntity
            {
                AccountType = x.Acc_Type_Name,
                IsInActive = false,
                //SeletedAccountType = x.Acc_Type_Code
            }).FirstOrDefault();
            return cashbank;
        }
        public AccountDetailEntity GetAccInfo(int AccountId)
        {
            var cashbank = entites.Accounts.Where(x => x.ID == AccountId).Select(x => new AccountDetailEntity
            {
                AccountName = x.Acc_Name,
                AccountID = x.ID,
                AccountOpeningBal = x.Acc_Open_Bal.ToString(),
                AccountType = x.Acc_Type.ToString(),
                //AccuntTypeCode = x.AccountType.Acc_Type_Code,
                SeletedAccountType = x.Acc_Type.ToString(),
                IsInActivestring = x.Acc_Inactive,
                IsLinkedAccount = x.IsLinked,
                HashSymbol = (x.IsLinked == true ? "#" : "")
            }).FirstOrDefault();
            return cashbank;
        }

        public int AddEditAccount(AccountDetailEntity cashbankentity)
        {
            try
            {
                var cashbank = entites.Accounts.Where(x => x.ID == cashbankentity.AccountID).FirstOrDefault();
                var checkduplicate = entites.Accounts.Where(x => x.Acc_Name.ToLower() == cashbankentity.AccountName.ToLower() && x.IsDeleted != true).FirstOrDefault();
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
                    cashbank.Acc_Type =Convert.ToInt32(cashbankentity.SeletedAccountType);
                    entites.SaveChanges();
                    //while update accounts
                    string accountName = cashbankentity.AccountName.ToString();
                    if (Convert.ToInt32(cashbankentity.SeletedAccountType) != 0)
                    {
                        var status = entites.Accounts.SqlQuery("USP_UpdateUserCreatedAccountInfo  @acctype,@accountName",
                                new SqlParameter("acctype", Convert.ToInt32(cashbankentity.SeletedAccountType)),
                                new SqlParameter("accountName", cashbankentity.AccountName)).SingleOrDefault();
                    }
                    return 1;
                }
                else
                {
                    if (checkduplicate != null)
                    {
                        return 2;
                    }
                    int acctype = Convert.ToInt32(cashbankentity.SeletedAccountType);
                 

                    Account AccDetail = new Account()
                    {
                        Acc_Name = cashbankentity.AccountName,
                        Acc_Open_Bal = cashbankentity.AccountOpeningBal == null ? null as decimal? : Convert.ToDecimal(cashbankentity.AccountOpeningBal),
                        Acc_Inactive = cashbankentity.IsInActivestring,
                        Acc_Type = acctype
                    };
                    //if (cashbankentity.AccountName.ToLower().Trim() == "cash")
                    //{
                    //    //var accType = entites.AccountTypes.Where(x => x.Acc_Type_Code == "CAB").FirstOrDefault();
                    //    //if (accType != null)
                    //    //    AccDetail.Acc_Type = accType.ID;
                    //    return 2;
                    //}
                    //else
                    //{
                    //    var accType = entites.AccountTypes.Where(x => x.Acc_Type_Code == "ACB").FirstOrDefault();
                    //    if (accType != null)
                    //        AccDetail.Acc_Type = accType.ID;
                    //}
                    entites.Accounts.Add(AccDetail);
                    entites.SaveChanges();
                    //while Creating new Accounts accounts
                    string accountName = cashbankentity.AccountName.ToString();
                    if (acctype!=0)
                    {
                        var status = entites.Accounts.SqlQuery("USP_UpdateUserCreatedAccountInfo  @acctype,@accountName",
                                new SqlParameter("acctype", acctype),
                                new SqlParameter("accountName", accountName)).SingleOrDefaultAsync();
                    }
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

        public bool DeleteAccount(int AccountId)
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
        public bool CanDeleteAccount(int AccountId)
        {
            try
            {
                var cashbank = entites.AccountsTransactions.Where(x => x.Acc_Id == AccountId).FirstOrDefault();
                var ReceiveMoney = entites.ReceiveMoneys.Where(x => x.CashBankAccountID == AccountId).FirstOrDefault();
                var PayMoney = entites.PayMoneys.Where(x => x.CashBankAccountID == AccountId).FirstOrDefault();
                var AccountsName = entites.Accounts.Where(x => x.ID == AccountId).Select(x => x.Acc_Name).FirstOrDefault();
                var BusinessExpenses = entites.BusinessExpensesDetails.Where(x => x.Bus_Expenses_Acc_Name == AccountsName).FirstOrDefault();
                var Journal = entites.JournalDetails.Where(x => x.Acc_ID == AccountId).FirstOrDefault();
                var TransferMoneyFromAccount = entites.TransferMoneys.Where(x => x.From_Acc_Id == AccountId).FirstOrDefault();
                var TransferMoneyToAccount = entites.TransferMoneys.Where(x => x.To_Acc_Id == AccountId).FirstOrDefault();
                if (cashbank != null)
                {
                    return false;
                }
                else if(ReceiveMoney!=null)
                {
                    return false;
                }
                else if (PayMoney!=null)
                {
                    return false;
                }
                else if (BusinessExpenses!=null)
                {
                    return false;
                }
                else if(Journal!=null)
                {
                    return false;
                }
                else if(TransferMoneyFromAccount!=null)
                {
                    return false;
                }
                else if (TransferMoneyToAccount != null)
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

        public AccountsEntity StartNewFinancialYear(string status)
        {
            AccountsEntity Message = new AccountsEntity();
            try
            {
                Message = entites.Database.SqlQuery<AccountsEntity>("StartNewFinancialYear @Message",
                    new SqlParameter("Message", status)).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            
            return Message;
        }
    }



}
