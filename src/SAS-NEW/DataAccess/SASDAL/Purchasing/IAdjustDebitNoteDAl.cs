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
        AdjustDebitNoteForm AdjustDebitNoteDetails(string AdjustedNo);
        int SaveAdjustDebitNote(AdjustDebitNoteForm psForm, int Type);
        int UpdateAdjustDebitNote(AdjustDebitNoteForm psForm, int Type);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLatestInvoiceNo();
    }
}