using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Accounts
{
    public interface IJournalFormBL
    {
        IEnumerable<JournalFormEntity> GetAccountsListComboList();
        string GetLatestInvoiceNo();
        int SaveJournalData(JournalForm JForm);
        JournalForm GetJournalDetails(string JNo);
        bool IsChequeNoPresent(string JNumber);
    }
}
