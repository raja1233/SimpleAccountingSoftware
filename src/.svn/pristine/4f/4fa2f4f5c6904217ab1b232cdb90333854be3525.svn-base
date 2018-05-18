using SASDAL.Accounts;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Accounts
{
    public class LedgerBL : ILedgerBL
    {
        public List<LedgerEntity> LedgerList(string jsondata)
        {
            ILedgerDAL obj = new LedgerDAL();
            return obj.LedgerList(jsondata);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ILedgerDAL ledgerDAL = new LedgerDAL();
            var result = ledgerDAL.GetLastSelectionData(ScreenId);
            return result;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ILedgerDAL ledgerDAL = new LedgerDAL();
            return ledgerDAL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
    }
}
