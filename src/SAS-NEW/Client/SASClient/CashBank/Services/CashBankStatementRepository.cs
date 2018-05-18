﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.CashandBank;
using SASBAL.CashBank;
using System.Collections.ObjectModel;
using SDN.UI.Entities.Export;

namespace SASClient.CashBank.Services
{
    public class CashBankStatementRepository : ICashBankStatementRepository
    {
        /// <summary>
        /// GetAccountList
        /// </summary>
        /// <returns></returns>
        /// 
        public List<Cash_and_Bank_Statement> GetExportDataList(int CashBankStatementID, string jsondata,string FileName)
        {
            ICashBankStatementBL exportdata = new CashBankStatementBL();
            return exportdata.GetExportDataList(CashBankStatementID, jsondata,FileName);
        }
        public List<CashBankStatementEntity> GetAccountList()
        {



            ICashBankStatementBL AccountList = new CashBankStatementBL();
            return AccountList.GetBankAccountList();
        }
        /// <summary>
        /// GetAccountDetailList
        /// </summary>
        /// <param name="CashBankStatementID"></param>
        /// <param name="jsondata"></param>
        /// <returns></returns>
        public List<CashBankStatementEntity> GetAccountDetailList(int CashBankStatementID, string jsondata)
        {
            ICashBankStatementBL AccountDetailList = new CashBankStatementBL();
            return AccountDetailList.GetAccountDetailList(CashBankStatementID,jsondata);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ICashBankStatementBL pBL = new CashBankStatementBL();
            return pBL.GetLastSelectionData(ScreenId);
        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICashBankStatementBL pBL = new CashBankStatementBL();
            return pBL.SaveSearchJson(jsonSearch, ScreenId,ScreenName);
        }
    }
}
