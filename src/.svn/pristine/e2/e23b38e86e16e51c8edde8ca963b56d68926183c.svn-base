using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using SASDAL.Accounts;

namespace SASBAL.Accounts
{
    public class JournalListBL : IJournalListBL
    {
        public List<JournalListViewEntity> getJournalDetails(string JSonData)
        {
            IJournalListDAL list = new JournalListDAL();
            return list.getJournalDetails(JSonData);
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IJournalListDAL list = new JournalListDAL();
            return list.GetLastSelectionData(ScreenId);

        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IJournalListDAL list = new JournalListDAL();
            return list.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
    }
}
