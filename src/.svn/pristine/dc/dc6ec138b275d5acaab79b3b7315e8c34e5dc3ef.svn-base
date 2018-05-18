using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using SASBAL.Accounts;

namespace SASClient.Accounts.Services
{
    public class JournalFormRepository : IJournalFormRepository
    {
        public IEnumerable<JournalFormEntity> GetAccountsListComboList()
        {
            IJournalFormBL JournalObj = new JournalFormBL();
            List<JournalFormEntity> AccountsList = JournalObj.GetAccountsListComboList().ToList();
            return AccountsList;
        }

        public JournalForm GetJournalDetails(string JNo)
        {
            IJournalFormBL JournalObj = new JournalFormBL();
            return JournalObj.GetJournalDetails(JNo);
        }

        public string GetLatestInvoiceNo()
        {
            IJournalFormBL JournalObj = new JournalFormBL();
            return JournalObj.GetLatestInvoiceNo();
        }

        public bool IsChequeNoPresent(string JNumber)
        {
            IJournalFormBL JournalObj = new JournalFormBL();
            return JournalObj.IsChequeNoPresent(JNumber);
        }
       

        public int SaveJournalData(JournalForm JForm)
        {
            IJournalFormBL JournalObj = new JournalFormBL();
            return JournalObj.SaveJournalData(JForm);
        }

       
    }
}
