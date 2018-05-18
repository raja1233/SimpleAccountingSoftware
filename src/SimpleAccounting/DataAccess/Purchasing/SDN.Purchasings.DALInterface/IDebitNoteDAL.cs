
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DALInterface
{
    using SDN.UI.Entities.Purchase;
    public interface IDebitNoteDAL
    {
        DebitNoteForm GetDebitNoteDetails(string debitNoteNo);
        void UpdateDebitNote(DebitNoteForm debitNote);
    }
}
