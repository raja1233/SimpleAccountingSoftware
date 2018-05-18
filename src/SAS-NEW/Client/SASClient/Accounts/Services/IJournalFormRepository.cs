using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Accounts.Services
{
    public  interface IJournalFormRepository
    {
        IEnumerable<JournalFormEntity> GetAccountsListComboList();
        int SaveJournalData(JournalForm JForm);
        JournalForm GetJournalDetails(string JNo);
        string GetLatestInvoiceNo();
        bool IsChequeNoPresent(string JNumber);
       

    }
}
