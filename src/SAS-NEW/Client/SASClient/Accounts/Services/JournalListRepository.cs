using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using SASBAL.Accounts;

namespace SASClient.Accounts.Services
{
    public class JournalListRepository : IJournalListRepository
    {
        public List<JournalListViewEntity> getJournalDetails(string JSonData)
        {
            IJournalListBL List = new JournalListBL();
            return List.getJournalDetails(JSonData);
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IJournalListBL List = new JournalListBL();
            return List.GetLastSelectionData(ScreenId);
        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IJournalListBL List = new JournalListBL();
            return List.SaveSearchJson(jsonSearch,ScreenId,ScreenName);
        }
    }
}
