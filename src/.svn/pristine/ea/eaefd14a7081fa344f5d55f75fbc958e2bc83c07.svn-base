
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DAL
{
    using Common;
    using SDN.Purchasings.DALInterface;
    using SDN.PurchasingsEDM;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    public class AdjustDebitNoteDAl : IAdjustDebitNoteDAl
    {

        public List<SupplierDetailEntity> GetAllSupplier()
        {
            using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
            {
                //List<SupplierDetailEntity> suppliersource = entities.Suppliers.Where(x => x.IsDeleted != true).Select(x => new SupplierDetailEntity
                //{
                //    ID = x.ID,
                //    SupplierName = x.Sup_Name,
                //    Createddate = x.CreatedDate,
                //}).ToList();
                List<SupplierDetailEntity> suppliersource = (from s in entities.Suppliers
                                                             join d in entities.DebitNotes on s.ID equals d.Sup_Id
                                                             where d.IsDeleted != true
                                                             select new SupplierDetailEntity
                                                             {
                                                                 ID = s.ID,
                                                                 SupplierName = s.Sup_Name
                                                             }).Distinct().ToList();

                return suppliersource;
            }
        }

        public List<AdjustDebitNoteEntity> GetDebitNotes(string SupplierId)
        {
            using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
            {
                int supid = 0;
                //List<SupplierDetailEntity> suppliersource = entities.Suppliers.Where(x => x.IsDeleted != true).Select(x => new SupplierDetailEntity
                //{
                //    ID = x.ID,
                //    SupplierName = x.Sup_Name,
                //    Createddate = x.CreatedDate,
                //}).ToList();
                if (SupplierId != null || SupplierId != "" || SupplierId != " ")
                {
                    supid = Convert.ToInt32(SupplierId);
                }
                List<AdjustDebitNoteEntity> debitnotelist = (from p in entities.PurchaseInvoices
                                                             join d in entities.DebitNotes on p.ID equals d.PI_Id
                                                             where d.IsDeleted != true && d.Sup_Id == supid
                                                             select new AdjustDebitNoteEntity
                                                             {
                                                                 Date = d.DN_Date,
                                                                 Amount = p.PI_Tot_aft_Tax,
                                                                 DebitNoteNo = d.DN_No
                                                             }).ToList();

                return debitnotelist;
            }
        }

        public AdjustDebitNoteForm GetAdjustDebitNoteDetails(string DebitNoteNo)
        {
            AdjustDebitNoteForm pqf = new AdjustDebitNoteForm();

            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    decimal value;
                    var pq = (from pqs in entities.DebitNotes
                              join pi in entities.PurchaseInvoices on pqs.PI_Id equals pi.ID
                              where pqs.DN_No == DebitNoteNo
                              select new AdjustDebitNoteEntity
                              {
                                  ID = pqs.ID,
                                  SupplierID = pqs.Sup_Id,
                                  //Amount =  pi.PI_Tot_aft_Tax,
                                  Amount = pi.PI_Tot_aft_Tax,
                                  Date = pqs.DN_Date,
                                  DebitNoteNo = pqs.DN_No
                                  //CashChequeNo = pqs.Cash_Cheque_No,
                              }).FirstOrDefault();

                    if (pq != null)
                    {
                        pq.AmountStr = Convert.ToString(pq.Amount);
                        pqf.AdjustDebitNote = pq;
                    }

                    if (pq.SupplierID != 0 || pq.SupplierID != null)
                    {
                        //var pqd = (from pqs in entities.PurchaseInvoices 
                        //           where pqs.Sup_Id == pq.SupplierID && pqs.PI_Status == 2
                        //           select new AdjustDebitNoteDetailsEntity
                        //           {
                        //               PurchaseNo = pqs.PI_No,
                        //               PurchaseDate = pqs.PI_Date,
                        //               PaymentDueDate = pqs.PI_Pmt_Due_Date,
                        //               PurchaseAmount = pqs.PI_Tot_aft_Tax,
                        //               //AmountDue = pqs.Amt_Due,
                        //               //Discount = pqs.Discount,
                        //               //AmountAdjusted = pqs

                        //           }).ToList<AdjustDebitNoteDetailsEntity>();

                        var pqd = entities.Database.SqlQuery<AdjustDebitNoteDetailsEntity>("PRC_GetPurchaseDataForAdjustDebitNotes @SupplierID={0}", pq.SupplierID).ToList();

                        if (pqd != null)
                        {
                            pqf.AdjustDebitNoteDetails = pqd;
                        }
                    }


                    return pqf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AdjustDebitNoteForm GetNewPS(int? SupplierID)
        {
            AdjustDebitNoteForm pqf = new AdjustDebitNoteForm();

            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    var pqd = entities.Database.SqlQuery<AdjustDebitNoteDetailsEntity>("PRC_GetPurchaseDataForAdjustDebitNotes @SupplierID={0}", SupplierID).ToList();

                    if (pqd != null)
                    {
                        pqf.AdjustDebitNoteDetails = pqd;
                    }

                    return pqf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateAdjustDebitNote(AdjustDebitNoteForm psForm)
        {
            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    foreach (var item in psForm.AdjustDebitNoteDetails)
                    {
                        if (item.CheckAmountAdjusted == true)
                        {
                            CashAndBankTransaction obj = entities.CashAndBankTransactions.Where(e => e.SO_CN_PO_DN_No == item.PurchaseNo).SingleOrDefault();
                            if (obj != null)
                            {
                                obj.Acc_Id = psForm.AdjustDebitNote.AccountId;
                                obj.Amount = psForm.AdjustDebitNote.Amount;
                                //obj.Cash_Cheque_No = psForm.AdjustDebitNote.CashChequeNo;
                                obj.Cash_Cheque_Date = psForm.AdjustDebitNote.Date;
                                obj.Remarks = psForm.AdjustDebitNote.Remarks;
                                obj.Is_Cheque = psForm.AdjustDebitNote.IsCheque;
                                //saving details entity
                                obj.SO_CN_PO_DN_No = item.PurchaseNo;
                                obj.SO_CN_PO_DN_Date = item.PurchaseDate;
                                obj.SO_CN_PO_DN_Amt = item.PurchaseAmount;
                                obj.Amt_Due = item.AmountDue;
                                obj.Amt_Refunded = item.AmountAdjusted;
                                obj.Discount = item.Discount;
                                obj.DN_CN_No = psForm.AdjustDebitNote.DebitNoteNo;

                                obj.UpdatedBy = 0;
                                obj.UpdatedDate = DateTime.Now.Date;
                                entities.SaveChanges();

                                if (item.AmountDue == 0 && item.AmountAdjusted == item.PurchaseAmount)
                                {
                                    PurchaseInvoice invoice = entities.PurchaseInvoices.Where(e => e.PI_No == item.PurchaseNo).SingleOrDefault();
                                    //PurchaseOrder order = entities.PurchaseOrders.Where(e => e.PO_No == item.PurchaseNo).SingleOrDefault();
                                    if (invoice != null)
                                    {
                                        invoice.PI_Status = Convert.ToByte(PI_Status.Paid);
                                        entities.SaveChanges();
                                    }
                                    //else if (order != null)
                                    //{
                                    //}
                                    DebitNote debit = entities.DebitNotes.Where(e => e.DN_No == psForm.AdjustDebitNote.DebitNoteNo).SingleOrDefault();
                                    if (debit != null)
                                    {
                                        debit.DN_Status = Convert.ToByte(DN_Status.Adjusted);
                                        entities.SaveChanges();
                                    }
                                }
                            }
                            else
                            {
                                CashAndBankTransaction cashbankobj = new CashAndBankTransaction()
                                {
                                    Acc_Id = psForm.AdjustDebitNote.AccountId,
                                    Amount = psForm.AdjustDebitNote.Amount,
                                    Cash_Cheque_Date = psForm.AdjustDebitNote.Date,
                                    Remarks = psForm.AdjustDebitNote.Remarks,
                                    Is_Cheque = psForm.AdjustDebitNote.IsCheque,
                                    SO_CN_PO_DN_No = item.PurchaseNo,
                                    SO_CN_PO_DN_Date = item.PurchaseDate,
                                    SO_CN_PO_DN_Amt = item.PurchaseAmount,
                                    Amt_Due = item.AmountDue,
                                    Amt_Refunded = item.AmountAdjusted,
                                    Discount = item.Discount,
                                    UpdatedBy = 0,
                                    UpdatedDate = DateTime.Now.Date,
                                    Cus_Sup_Id = psForm.AdjustDebitNote.SupplierID,
                                    DN_CN_No = psForm.AdjustDebitNote.DebitNoteNo,
                                    Type = "S"
                                };
                                entities.CashAndBankTransactions.Add(cashbankobj);
                                entities.SaveChanges();
                                if (item.AmountDue == 0 && item.AmountAdjusted == item.PurchaseAmount)
                                {
                                    PurchaseInvoice invoice = entities.PurchaseInvoices.Where(e => e.PI_No == item.PurchaseNo).SingleOrDefault();
                                    //PurchaseOrder order = entities.PurchaseOrders.Where(e => e.PO_No == item.PurchaseNo).SingleOrDefault();
                                    if (invoice != null)
                                    {
                                        invoice.PI_Status = Convert.ToByte(PI_Status.Paid);
                                        entities.SaveChanges();
                                    }
                                    //else if (order != null)
                                    //{
                                    //}
                                }
                                DebitNote debit = entities.DebitNotes.Where(e => e.DN_No == psForm.AdjustDebitNote.DebitNoteNo).SingleOrDefault();
                                if (debit != null)
                                {
                                    debit.DN_Status = Convert.ToByte(DN_Status.Adjusted);
                                    entities.SaveChanges();
                                }

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return psForm.AdjustDebitNote.ID;
        }

        public int SaveAdjustDebitNote(AdjustDebitNoteForm psForm)
        {
            int autoId = 0;
            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    foreach (var item in psForm.AdjustDebitNoteDetails)
                    {
                        CashAndBankTransaction obj = new CashAndBankTransaction();
                        obj.Cus_Sup_Id = psForm.AdjustDebitNote.SupplierID;
                        obj.Acc_Id = psForm.AdjustDebitNote.AccountId;
                        obj.Amount = psForm.AdjustDebitNote.Amount;
                        //obj.Cash_Cheque_No = psForm.AdjustDebitNote.CashChequeNo;
                        obj.Cash_Cheque_Date = psForm.AdjustDebitNote.Date;
                        obj.Remarks = psForm.AdjustDebitNote.Remarks;
                        obj.Type = "S";
                        //obj.Is_Cheque = psForm.AdjustDebitNote.IsCheque;

                        //saving details entity
                        obj.SO_CN_PO_DN_No = item.PurchaseNo;
                        obj.SO_CN_PO_DN_Date = item.PurchaseDate;
                        obj.SO_CN_PO_DN_Amt = item.PurchaseAmount;
                        obj.Amt_Due = item.AmountDue;
                        obj.Amt_Refunded = item.AmountAdjusted;
                        obj.Discount = item.Discount;

                        obj.UpdatedBy = 0;
                        obj.UpdatedDate = DateTime.Now.Date;

                        entities.CashAndBankTransactions.Add(obj);
                        entities.SaveChanges();

                        if (item.AmountDue == 0 && item.AmountAdjusted == item.PurchaseAmount)
                        {
                            PurchaseInvoice invoice = entities.PurchaseInvoices.Where(e => e.PI_No == item.PurchaseNo).SingleOrDefault();
                            PurchaseOrder order = entities.PurchaseOrders.Where(e => e.PO_No == item.PurchaseNo).SingleOrDefault();
                            if (invoice != null)
                            {
                                invoice.PI_Status = Convert.ToByte(PI_Status.Paid);
                                entities.SaveChanges();
                            }
                            else if (order != null)
                            {

                            }

                        }

                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return autoId;
        }

        public string GetCountOfPOSuppliers()
        {
            string POCount = string.Empty;
            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    var po = (from e in entities.PurchaseOrders
                              join p in entities.Suppliers
                              on e.Sup_Id equals p.ID
                              where e.IsDeleted == false
                              select new
                              {
                                  e.Sup_Id,
                                  p.Sup_Name
                              }
                         ).Distinct().ToList();

                    if (po != null)
                    {
                        POCount = Convert.ToString(po.Count);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return POCount;
        }
        public string GetCountOfPISuppliers()
        {
            string PICount = string.Empty;
            byte status = Convert.ToByte(PI_Status.UnPaid);
            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    var po = (from e in entities.PurchaseInvoices
                              join p in entities.Suppliers
                              on e.Sup_Id equals p.ID
                              where e.IsDeleted == false
                              && e.PI_Status == status
                              select new
                              {
                                  e.Sup_Id,
                                  p.Sup_Name
                              }
                          ).Distinct().ToList();
                    if (po != null)
                    {
                        PICount = Convert.ToString(po.Count);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PICount;
        }

        public bool IsChequeNoPresent(string cashChequeNo)
        {
            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    var po = entities.CashAndBankTransactions.Where(e => e.Cash_Cheque_No == cashChequeNo).ToList();
                    if (po.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
