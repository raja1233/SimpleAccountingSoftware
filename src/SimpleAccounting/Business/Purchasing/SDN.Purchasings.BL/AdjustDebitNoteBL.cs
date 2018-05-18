﻿using SDN.Purchasings.BLInterface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BL
{
    using SDN.Purchasings.DAL;
    using SDN.Purchasings.DALInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    public class AdjustDebitNoteBL : IAdjustDebitNoteBL
    {

        public IEnumerable<SupplierDetailEntity> GetAllSupplier()
        {
            IAdjustDebitNoteDAl psBL = new AdjustDebitNoteDAl();
            IList<SupplierDetailEntity> SupplierList = new List<SupplierDetailEntity>();
            SupplierList = psBL.GetAllSupplier();
            return SupplierList;
        }

        public List<AdjustDebitNoteEntity> GetDebitNotes(string SupplierId)
        {
            IAdjustDebitNoteDAl psBL = new AdjustDebitNoteDAl();
            List<AdjustDebitNoteEntity> debitnotelist = new List<AdjustDebitNoteEntity>();
            debitnotelist = psBL.GetDebitNotes(SupplierId);
            return debitnotelist;
        }

        public AdjustDebitNoteForm GetAdjustDebitNoteDetails(string cashChequeNo)
        {
            IAdjustDebitNoteDAl psDAL = new AdjustDebitNoteDAl();
            return psDAL.GetAdjustDebitNoteDetails(cashChequeNo);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IAdjustDebitNoteDAl psDAL = new AdjustDebitNoteDAl();
            return psDAL.IsChequeNoPresent(cashChequeNo);
        }
        public AdjustDebitNoteForm GetNewPS(int? SupplierID)
        {
            IAdjustDebitNoteDAl psDAL = new AdjustDebitNoteDAl();
            return psDAL.GetNewPS(SupplierID);
        }
        public int SaveAdjustDebitNote(AdjustDebitNoteForm psForm)
        {
            IAdjustDebitNoteDAl psDAL = new AdjustDebitNoteDAl();
            return psDAL.SaveAdjustDebitNote(psForm);
        }
        public int UpdateAdjustDebitNote(AdjustDebitNoteForm psForm)
        {
            IAdjustDebitNoteDAl psDAL = new AdjustDebitNoteDAl();
            return psDAL.UpdateAdjustDebitNote(psForm);
        }
        public string GetCountOfPOSuppliers()
        {
            IAdjustDebitNoteDAl psDAL = new AdjustDebitNoteDAl();
            return psDAL.GetCountOfPOSuppliers();
        }
        public string GetCountOfPISuppliers()
        {
            IAdjustDebitNoteDAl psDAL = new AdjustDebitNoteDAl();
            return psDAL.GetCountOfPISuppliers();
        }
    }
}