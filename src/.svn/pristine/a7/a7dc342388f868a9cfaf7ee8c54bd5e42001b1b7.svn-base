
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BL
{
    using DAL;
    using DALInterface;
    using SDN.Purchasings.BLInterface;
    using UI.Entities.Purchase;

    public class DebitNoteBL:IDebitNoteBL
    {
        public DebitNoteForm GetDebitNoteDetails(string debitNoteNo)
        {
            try
            {
                IDebitNoteDAL debitNoteDAL = new DebitNoteDAL();
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
                IDebitNoteDAL debitNoteDAL = new DebitNoteDAL();
                 debitNoteDAL.UpdateDebitNote(debitNote);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
