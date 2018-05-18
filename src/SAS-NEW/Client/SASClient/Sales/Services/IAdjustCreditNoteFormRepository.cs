﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public interface IAdjustCreditNoteFormRepository
    {
        List<AdjustCreditNoteEntity> GetCreditNotes(string CustomerId);
        IEnumerable<CustomerEntity> GetAllCustomer();
        string GetCountOfSOCustomers();
        string GetCountOfSICustomers();
        bool IsChequeNoPresent(string cashChequeNo);
        int SaveAdjustCreditNote(AdjustCreditNoteForm psForm, int Type);
        int UpdateAdjustCreditNote(AdjustCreditNoteForm psForm, int Type);
        AdjustCreditNoteForm GetNewPS(int? CustomerID);
        AdjustCreditNoteForm GetAdjustCreditNoteDetails(string cashChequeNo);
        AdjustCreditNoteForm AdjustCreditNoteDetails(string cashChequeNo);
        string  GetLatestInvoiceNo();
    }
}
