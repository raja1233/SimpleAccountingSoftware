using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    using SDN.UI.Entities.Purchase;
    using SDN.Purchasings.BLInterface;
    using SDN.Purchasings.BL;
    public class DebitNoteRepository : IDebitNoteRepository
    {
        public DebitNoteForm GetDebitNoteDetails(string debitNoteNo)
        {
            try
            {
                IDebitNoteBL debitNoteDAL = new DebitNoteBL();
                return debitNoteDAL.GetDebitNoteDetails(debitNoteNo);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateDebitNote(DebitNoteForm debitNote)
        {
            try
            {
                IDebitNoteBL debitNoteDAL = new DebitNoteBL();
                debitNoteDAL.UpdateDebitNote(debitNote);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
