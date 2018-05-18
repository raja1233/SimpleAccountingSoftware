﻿using SASBAL.Accounts;
using SDN.UI.Entities;
using SDN.UI.Entities.Accounts;
using SDN.UI.Entities.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Accounts.Services
{
    public class AccountHistoryRepository : IAccountHistoryRepository
    {
        public List<AccountHistoryEntity> GetAllSalesInvoiceJson(string jsondata)
        {
            IAccountHistoryBL purInvoice = new AccountHistoryBL();
            List<AccountHistoryEntity> quotationlist = purInvoice.GetAllSalesInvoiceJson(jsondata);
            return quotationlist;
        }
        public List<Account_History_List> ExportAccountHistory(string jsondata,string FileName)
        {
            IAccountHistoryBL purInvoice = new AccountHistoryBL();
            List<Account_History_List> accountlist = purInvoice.ExportAccountHistory(jsondata,FileName);
            return accountlist;
        }
        public List<YearEntity> GetYearRange()
        {
            IAccountHistoryBL purInvoice = new AccountHistoryBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IAccountHistoryBL purInvoice = new AccountHistoryBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IAccountHistoryBL purInvoice = new AccountHistoryBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IAccountHistoryBL purInvoice = new AccountHistoryBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
    }
}
