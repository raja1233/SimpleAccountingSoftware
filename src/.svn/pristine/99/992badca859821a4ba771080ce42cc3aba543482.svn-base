using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using SASDAL.Accounts;

namespace SASBAL.Accounts
{
    public class JournalFormBL : IJournalFormBL
    {
        public IEnumerable<JournalFormEntity> GetAccountsListComboList()
        {
            IJournalFormDAL JournalObj = new JournalFormDAL();
            List<JournalFormEntity> AccountsList = JournalObj.GetAccountsListComboList().ToList();
            return AccountsList;
        }

        public JournalForm GetJournalDetails(string JNo)
        {
            IJournalFormDAL JournalObj = new JournalFormDAL();
            return JournalObj.GetJournalDetails(JNo);
        }

        public string GetLatestInvoiceNo()
        {
            IJournalFormDAL JournalObj = new JournalFormDAL();
            return JournalObj.GetLatestInvoiceNo();
        }

        public bool IsChequeNoPresent(string JNumber)
        {
            IJournalFormDAL JournalObj = new JournalFormDAL();
            return JournalObj.IsChequeNoPresent(JNumber);
        }

        public int SaveJournalData(JournalForm JForm)
        {
            IJournalFormDAL JournalObj = new JournalFormDAL();
            return JournalObj.SaveJournalData(JForm);
        }
    }
}
