using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Accounts.Services
{
    public interface IJournalListRepository
    {
        List<JournalListViewEntity> getJournalDetails(string JSonData);
        string GetLastSelectionData(int ScreenId);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
    }
}
