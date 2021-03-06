﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using Saless.BL;
    using Saless.BLInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public class AdjustCreditNoteFormRepository : IAdjustCreditNoteFormRepository
    {
        public IEnumerable<CustomerEntity> GetAllCustomer()
        {
            IAdjustCreditNoteBL psBL = new AdjustCreditNoteBL();
            IList<CustomerEntity> CustomerList = new List<CustomerEntity>();
            CustomerList = psBL.GetAllCustomer().ToList();
            return CustomerList;
        }

        public List<AdjustCreditNoteEntity> GetCreditNotes(string CustomerId)
        {
            IAdjustCreditNoteBL psBL = new AdjustCreditNoteBL();
            List<AdjustCreditNoteEntity> debitnotelist = new List<AdjustCreditNoteEntity>();
            debitnotelist = psBL.GetCreditNotes(CustomerId);
            return debitnotelist;
        }


        public AdjustCreditNoteForm GetAdjustCreditNoteDetails(string cashChequeNo)
        {
            IAdjustCreditNoteBL psBL = new AdjustCreditNoteBL();
            return psBL.GetAdjustCreditNoteDetails(cashChequeNo);
        }
        public AdjustCreditNoteForm GetNewPS(int? CustomerID)
        {
            IAdjustCreditNoteBL psBL = new AdjustCreditNoteBL();
            return psBL.GetNewPS(CustomerID);
        }

        public int SaveAdjustCreditNote(AdjustCreditNoteForm psForm)
        {
            IAdjustCreditNoteBL psBL = new AdjustCreditNoteBL();
            return psBL.SaveAdjustCreditNote(psForm);

        }
        public string GetCountOfSOCustomers()
        {
            IAdjustCreditNoteBL psBL = new AdjustCreditNoteBL();
            return psBL.GetCountOfSOCustomers();
        }
        public string GetCountOfSICustomers()
        {
            IAdjustCreditNoteBL psBL = new AdjustCreditNoteBL();
            return psBL.GetCountOfSICustomers();
        }
        public int UpdateAdjustCreditNote(AdjustCreditNoteForm psForm)
        {
            IAdjustCreditNoteBL psBL = new AdjustCreditNoteBL();
            return psBL.UpdateAdjustCreditNote(psForm);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IAdjustCreditNoteBL psBL = new AdjustCreditNoteBL();
            return psBL.IsChequeNoPresent(cashChequeNo);
        }
    }
}
