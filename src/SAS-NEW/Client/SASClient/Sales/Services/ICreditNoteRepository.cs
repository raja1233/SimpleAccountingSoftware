using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    public interface ICreditNoteRepository
    {
        CreditNoteForm GetCreditNoteDetails(string debitNoteNo);
        void UpdateCreditNote(CreditNoteForm debitNote);
        CreditNoteForm GetPrintCreditNote(string piNo);
    }
}
