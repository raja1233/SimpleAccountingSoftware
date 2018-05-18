﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DALInterface
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    public interface IAdjustDebitNoteDAl
    {
        List<AdjustDebitNoteEntity> GetDebitNotes(string SupplierId);
        List<SupplierDetailEntity> GetAllSupplier();
        string GetCountOfPOSuppliers();
        string GetCountOfPISuppliers();
        AdjustDebitNoteForm GetNewPS(int? SupplierID);
        AdjustDebitNoteForm GetAdjustDebitNoteDetails(string cashChequeNo);
        int SaveAdjustDebitNote(AdjustDebitNoteForm psForm);
        int UpdateAdjustDebitNote(AdjustDebitNoteForm psForm);
        bool IsChequeNoPresent(string cashChequeNo);
    }
}
