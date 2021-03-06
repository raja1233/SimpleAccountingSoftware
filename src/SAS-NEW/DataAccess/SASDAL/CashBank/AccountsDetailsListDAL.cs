﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.CashandBank;
using System.Data.SqlClient;

namespace SASDAL.CashBank
{
    public class AccountsDetailsListDAL : IAccountsDetailsListDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<AccountsDetailsListEntity> GetAllAccountsDetailsList()
        {
            List<AccountsDetailsListEntity> lstAccountsDetails = new List<AccountsDetailsListEntity>();
            try
            {
                    lstAccountsDetails = entities.Database.SqlQuery<AccountsDetailsListEntity>("USP_GetAccountsDetailList").ToList(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAccountsDetails;
        }

        public AccountsDetailsListEntity StartNewFinancialYear(string status)
        {
            AccountsDetailsListEntity Message = new AccountsDetailsListEntity();
            try
            {
                Message = entities.Database.SqlQuery<AccountsDetailsListEntity>("StartNewFinancialYear @Message",
                    new SqlParameter("Message", status)).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }

            return Message;
        }

        public string UpdatePreviousAccount()
        {
            try
            {
                var message = entities.Accounts.SqlQuery("USP_PreviousAccountingSystemClosingBalances");
                return "Ok";
            }
            catch (Exception e)
            {

                throw e;
            }
            
                 
        }
    }
}
