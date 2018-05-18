
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BLInterface
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    public interface IAdjustDebitNoteBL
    {
        List<AdjustDebitNoteEntity> GetDebitNotes(string SupplierId);
        IEnumerable<SupplierDetailEntity> GetAllSupplier();
        string GetCountOfPOSuppliers();
        string GetCountOfPISuppliers();
        AdjustDebitNoteForm GetNewPS(int? SupplierID);
        bool IsChequeNoPresent(string cashChequeNo);
        int SaveAdjustDebitNote(AdjustDebitNoteForm psForm, int Type);
        int UpdateAdjustDebitNote(AdjustDebitNoteForm psForm, int Type);
        AdjustDebitNoteForm AdjustDebitNoteDetails(string AdjustedNo);
        AdjustDebitNoteForm GetAdjustDebitNoteDetails(string cashChequeNo);
        string GetLatestInvoiceNo();
    }
}
