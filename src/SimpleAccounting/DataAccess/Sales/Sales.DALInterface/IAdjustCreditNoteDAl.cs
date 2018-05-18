﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Saless.DALInterface
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public interface IAdjustCreditNoteDAl
    {
        List<AdjustCreditNoteEntity> GetCreditNotes(string CustomerId);
        List<CustomerEntity> GetAllCustomer();
        string GetCountOfSOCustomers();
        string GetCountOfSICustomers();
        AdjustCreditNoteForm GetNewPS(int? CustomerID);
        AdjustCreditNoteForm GetAdjustCreditNoteDetails(string cashChequeNo);
        int SaveAdjustCreditNote(AdjustCreditNoteForm psForm);
        int UpdateAdjustCreditNote(AdjustCreditNoteForm psForm);
        bool IsChequeNoPresent(string cashChequeNo);
    }
}