﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Saless.BL
{
    using BLInterface;
    using DAL;
    using DALInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public class AdjustCreditNoteBL : IAdjustCreditNoteBL
    {

        public IEnumerable<CustomerEntity> GetAllCustomer()
        {
            IAdjustCreditNoteDAl psBL = new AdjustCreditNoteDAl();
            IList<CustomerEntity> CustomerList = new List<CustomerEntity>();
            CustomerList = psBL.GetAllCustomer();
            return CustomerList;
        }

        public List<AdjustCreditNoteEntity> GetCreditNotes(string CustomerId)
        {
            IAdjustCreditNoteDAl psBL = new AdjustCreditNoteDAl();
            List<AdjustCreditNoteEntity> debitnotelist = new List<AdjustCreditNoteEntity>();
            debitnotelist = psBL.GetCreditNotes(CustomerId);
            return debitnotelist;
        }

        public AdjustCreditNoteForm GetAdjustCreditNoteDetails(string cashChequeNo)
        {
            IAdjustCreditNoteDAl psDAL = new AdjustCreditNoteDAl();
            return psDAL.GetAdjustCreditNoteDetails(cashChequeNo);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IAdjustCreditNoteDAl psDAL = new AdjustCreditNoteDAl();
            return psDAL.IsChequeNoPresent(cashChequeNo);
        }
        public AdjustCreditNoteForm GetNewPS(int? CustomerID)
        {
            IAdjustCreditNoteDAl psDAL = new AdjustCreditNoteDAl();
            return psDAL.GetNewPS(CustomerID);
        }
        public int SaveAdjustCreditNote(AdjustCreditNoteForm psForm, int Type)
        {
            IAdjustCreditNoteDAl psDAL = new AdjustCreditNoteDAl();
            return psDAL.SaveAdjustCreditNote(psForm, Type);
        }
        public int UpdateAdjustCreditNote(AdjustCreditNoteForm psForm, int Type)
        {
            IAdjustCreditNoteDAl psDAL = new AdjustCreditNoteDAl();
            return psDAL.UpdateAdjustCreditNote(psForm, Type);
        }
        public string GetCountOfSOCustomers()
        {
            IAdjustCreditNoteDAl psDAL = new AdjustCreditNoteDAl();
            return psDAL.GetCountOfSOCustomers();
            return null;
        }
        public string GetCountOfSICustomers()
        {
            IAdjustCreditNoteDAl psDAL = new AdjustCreditNoteDAl();
            return psDAL.GetCountOfSICustomers();
        }

        public string  GetLatestInvoiceNo()
        {
            IAdjustCreditNoteDAl psDAL = new AdjustCreditNoteDAl();
            return psDAL.GetLatestInvoiceNo();
        }

        public AdjustCreditNoteForm AdjustCreditNoteDetails(string cashChequeNo)
        {
            IAdjustCreditNoteDAl psDAL = new AdjustCreditNoteDAl();
            return psDAL.AdjustCreditNoteDetails(cashChequeNo);
        }
    }
}