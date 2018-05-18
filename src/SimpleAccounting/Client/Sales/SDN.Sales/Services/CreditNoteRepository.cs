
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using BL;
    using SDN.Sales.BLInterface;
    using SDN.UI.Entities.Sales;

    public class CreditNoteRepository: ICreditNoteRepository
    {
        public CreditNoteForm GetCreditNoteDetails(string creditNoteNo)
        {
            try
            {
                ICreditNoteBL debitNoteDAL = new CreditNoteBL();
                return debitNoteDAL.GetCreditNoteDetails(creditNoteNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCreditNote(CreditNoteForm creditNote)
        {
            try
            {
                ICreditNoteBL debitNoteDAL = new CreditNoteBL();
                debitNoteDAL.UpdateCreditNote(creditNote);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
