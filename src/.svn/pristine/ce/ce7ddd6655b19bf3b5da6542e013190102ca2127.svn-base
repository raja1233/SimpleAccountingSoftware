using SDN.UI.Entities.CashandBank;
using SDN.UI.Entities.Export;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.CashBank.Services
{
    public interface ICashBankStatementRepository
    {
        /// <summary>
        /// GetAccountList
        /// </summary>
        /// <returns></returns>
        List<CashBankStatementEntity> GetAccountList();
        /// <summary>
        /// GetAccountDetailList
        /// </summary>
        /// <param name="CashBankStatementID"></param>
        /// <param name="jsondata"></param>
        /// <returns></returns>
        List<CashBankStatementEntity> GetAccountDetailList(int CashBankStatementID, string jsondata);
        List<Cash_and_Bank_Statement> GetExportDataList(int CashBankStatementID, string jsondata,string FileName);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
    }
}
