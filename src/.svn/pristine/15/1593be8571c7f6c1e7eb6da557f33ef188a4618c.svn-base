using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using SASBAL.Accounts;
using SASBAL.CashBank;

namespace SASClient.Accounts.Services
{
    public class LedgerRepository : ILedgerRepository
    {
        public List<LedgerEntity> LedgerList(string jsondata)
        {
            ILedgerBL obj = new LedgerBL();
            return obj.LedgerList(jsondata);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ILedgerBL ledgerBL = new LedgerBL();
            var result = ledgerBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ILedgerBL ledgerBL = new LedgerBL();
            return ledgerBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
    }
}
