
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BL
{
    using SDN.Sales.BLInterface;
    using SDN.Sales.DALInterface;
    using SDN.Sales.DAL;
    using SDN.UI.Entities.Sales;
    public class CreditNoteBL: ICreditNoteBL
    {
        public CreditNoteForm GetCreditNoteDetails(string CreditNoteNo)
        {
            try
            {
                ICreditNoteDAL CreditNoteDAL = new CreditNoteDAL();
                return CreditNoteDAL.GetCreditNoteDetails(CreditNoteNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateCreditNote(CreditNoteForm CreditNote)
        {
            try
            {
                ICreditNoteDAL CreditNoteDAL = new CreditNoteDAL();
                CreditNoteDAL.UpdateCreditNote(CreditNote);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CreditNoteForm GetPrintCreditNote(string piNo)
        {
            ICreditNoteDAL PIDAL = new CreditNoteDAL();
            return PIDAL.GetPrintCreditNote(piNo);
        }
    }
}
