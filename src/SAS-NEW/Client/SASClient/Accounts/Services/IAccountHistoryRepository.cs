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
    public interface IAccountHistoryRepository
    {
        List<AccountHistoryEntity> GetAllSalesInvoiceJson(string jsondata);
        List<Account_History_List> ExportAccountHistory(string jsondata,string FileName);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
 
    }
}

