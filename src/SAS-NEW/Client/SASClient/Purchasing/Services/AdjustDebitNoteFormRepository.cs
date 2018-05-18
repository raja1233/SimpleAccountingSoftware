
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    using Sales.Services;
    using SDN.Purchasing.Services;
    using SDN.Purchasings.BL;
    using SDN.Purchasings.BLInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    public class AdjustDebitNoteFormRepository : IAdjustDebitNoteFormRepository
    {
        public IEnumerable<SupplierDetailEntity> GetAllSupplier()
        {
            IAdjustDebitNoteBL psBL = new AdjustDebitNoteBL();

            IList<SupplierDetailEntity> SupplierList = new List<SupplierDetailEntity>();
           

            SupplierList = psBL.GetAllSupplier().ToList();
            return SupplierList;
        }

        public List<AdjustDebitNoteEntity> GetDebitNotes(string SupplierId)
        {
            IAdjustDebitNoteBL psBL = new AdjustDebitNoteBL();
            List<AdjustDebitNoteEntity> debitnotelist = new List<AdjustDebitNoteEntity>();
            debitnotelist = psBL.GetDebitNotes(SupplierId);
            return debitnotelist;
        }


        public AdjustDebitNoteForm GetAdjustDebitNoteDetails(string cashChequeNo)
        {
            IAdjustDebitNoteBL psBL = new AdjustDebitNoteBL();
            return psBL.GetAdjustDebitNoteDetails(cashChequeNo);
        }
        public AdjustDebitNoteForm GetNewPS(int? SupplierID)
        {
            IAdjustDebitNoteBL psBL = new AdjustDebitNoteBL();
            return psBL.GetNewPS(SupplierID);
        }

        public int SaveAdjustDebitNote(AdjustDebitNoteForm psForm, int Type)
        {
            IAdjustDebitNoteBL psBL = new AdjustDebitNoteBL();
            return psBL.SaveAdjustDebitNote(psForm, Type);

        }
        public string GetCountOfPOSuppliers()
        {
            IAdjustDebitNoteBL psBL = new AdjustDebitNoteBL();
            return psBL.GetCountOfPOSuppliers();
        }
        public string GetCountOfPISuppliers()
        {
            IAdjustDebitNoteBL psBL = new AdjustDebitNoteBL();
            return psBL.GetCountOfPISuppliers();
        }
        public int UpdateAdjustDebitNote(AdjustDebitNoteForm psForm, int Type)
        {
            IAdjustDebitNoteBL psBL = new AdjustDebitNoteBL();
            return psBL.UpdateAdjustDebitNote(psForm, Type);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IAdjustDebitNoteBL psBL = new AdjustDebitNoteBL();
            return psBL.IsChequeNoPresent(cashChequeNo);
        }

        public string GetLatestInvoiceNo()
        {
            IAdjustDebitNoteBL psBL = new AdjustDebitNoteBL();
            return psBL.GetLatestInvoiceNo();
        }

        public AdjustDebitNoteForm AdjustDebitNoteDetails(string AdjustedNo)
        {
            IAdjustDebitNoteBL psBL = new AdjustDebitNoteBL();
            return psBL.AdjustDebitNoteDetails(AdjustedNo);
        }
    }
}
