
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DAL
{
    using Common;
    using SASDAL;
    using SDN.Purchasings.DALInterface;
    using UI.Entities;
    using UI.Entities.Purchase;

    public class RefundFromSupplierDAL: IRefundFromSupplierDAL
    {
        public RefundFromSupplierForm GetRefundFromSupplierDetails(string cashChequeNo)
        {
            string str = Convert.ToString(Convert.ToByte(CashBankTransactionType.RefundFromSupplier));
            RefundFromSupplierForm pqf = new RefundFromSupplierForm();

            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pq = (from pqs in entities.CashAndBankTransactions
                              where pqs.Cash_Cheque_No == cashChequeNo
                              && pqs.Type== str
                              select new RefundFromSupplierEntity
                              {
                                  ID = pqs.ID,
                                  SupplierID = pqs.Cus_Sup_Id,
                                  Amount = pqs.Amount,
                                  AccountId = pqs.Acc_Id,
                                  Remarks = pqs.Remarks,
                                  Date = pqs.Cash_Cheque_Date,
                                  IsCheque = pqs.Is_Cheque,
                                  CashChequeNo = pqs.Cash_Cheque_No,
                              }).FirstOrDefault();

                    if (pq != null)
                    {
                        pq.AmountStr = Convert.ToString(pq.Amount);
                        pqf.RefundFromSupplier = pq;
                    }


                    var pqd = (from pqs in entities.CashAndBankTransactions
                               where pqs.Cash_Cheque_No == cashChequeNo
                                && pqs.Type == str
                               select new RefundFromSupplierDetailsEntity
                               {
                                   PurchaseNo = pqs.SO_CN_PO_DN_No,
                                   PurchaseDate = pqs.SO_CN_PO_DN_Date,
                                   PurchaseAmount = pqs.SO_CN_PO_DN_Amt,
                                   AmountDue = pqs.Amt_Due,
                                   Discount = pqs.Discount,
                                   AmountAdjusted = pqs.Amt_Refunded
                               }).ToList<RefundFromSupplierDetailsEntity>();

                    if (pqd != null)
                    {
                        pqf.RefundFromSupplierDetails = pqd;
                    }

                    return pqf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RefundFromSupplierForm GetNewPS(int? SupplierID)
        {
            RefundFromSupplierForm pqf = new RefundFromSupplierForm();

            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pqd = entities.Database.SqlQuery<RefundFromSupplierDetailsEntity>("PRC_GetPurchaseDataForRefundFromSuppliers @SupplierID={0}", SupplierID).ToList();

                    if (pqd != null)
                    {
                        pqf.RefundFromSupplierDetails = pqd;
                    }

                    return pqf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateRefundFromSupplier(RefundFromSupplierForm psForm)
        {
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    foreach (var item in psForm.RefundFromSupplierDetails)
                    {
                        CashAndBankTransaction obj = entities.CashAndBankTransactions.Where(e => e.Cash_Cheque_No == psForm.RefundFromSupplier.CashChequeNo
                        && e.SO_CN_PO_DN_No == item.PurchaseNo).SingleOrDefault();
                        if (obj != null)
                        {
                            obj.Acc_Id = psForm.RefundFromSupplier.AccountId;
                            obj.Amount = psForm.RefundFromSupplier.Amount;
                            obj.Cash_Cheque_No = psForm.RefundFromSupplier.CashChequeNo;
                            obj.Cash_Cheque_Date = Convert.ToDateTime(psForm.RefundFromSupplier.DateStr);
                            obj.Remarks = psForm.RefundFromSupplier.Remarks;

                            obj.Is_Cheque = psForm.RefundFromSupplier.IsCheque;

                            //saving details entity
                            obj.SO_CN_PO_DN_No = item.PurchaseNo;
                            obj.SO_CN_PO_DN_Date = item.PurchaseDate;
                            obj.SO_CN_PO_DN_Amt = item.PurchaseAmount;
                            obj.Amt_Due = obj.Amt_Due = item.AmountDue - item.AmountAdjusted;
                            obj.Amt_Refunded = item.AmountAdjusted;
                            obj.Discount = item.Discount;

                            obj.UpdatedBy = 0;
                            obj.UpdatedDate = DateTime.Now;
                            entities.SaveChanges();

                            if ( item.AmountAdjusted == item.PurchaseAmount)
                            {
                                DebitNote dn = entities.DebitNotes.Where(e => e.DN_No == item.PurchaseNo).SingleOrDefault();
                                PurchaseOrder order = entities.PurchaseOrders.Where(e => e.PO_No == item.PurchaseNo).SingleOrDefault();
                                if (dn != null)
                                {
                                    dn.DN_Status = Convert.ToByte(DN_Status.Refunded);
                                    entities.SaveChanges();
                                }
                                else if (order != null)
                                {
                                    order.PO_Status = Convert.ToByte(PO_Status.Refunded);
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
            return psForm.RefundFromSupplier.ID;
        }

        public int SaveRefundFromSupplier(RefundFromSupplierForm psForm)
        {
            int autoId = 0;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    foreach (var item in psForm.RefundFromSupplierDetails)
                    {
                        CashAndBankTransaction obj = new CashAndBankTransaction();
                        obj.Cus_Sup_Id = psForm.RefundFromSupplier.SupplierID;
                        obj.Acc_Id = psForm.RefundFromSupplier.AccountId;
                        obj.Amount = psForm.RefundFromSupplier.Amount;
                        obj.Cash_Cheque_No = psForm.RefundFromSupplier.CashChequeNo;
                        obj.Cash_Cheque_Date = psForm.RefundFromSupplier.Date;
                        obj.Remarks = psForm.RefundFromSupplier.Remarks;
                        obj.Type = Convert.ToString(Convert.ToByte(CashBankTransactionType.RefundFromSupplier));
                        obj.Is_Cheque = psForm.RefundFromSupplier.IsCheque;

                        //saving details entity
                        obj.SO_CN_PO_DN_No = item.PurchaseNo;
                        obj.SO_CN_PO_DN_Date = item.PurchaseDate;
                        obj.SO_CN_PO_DN_Amt = item.PurchaseAmount;
                        obj.Amt_Due = item.AmountDue - item.AmountAdjusted;
                        obj.Amt_Due = item.AmountDue;
                        obj.Amt_Refunded = item.AmountAdjusted;
                        obj.Discount = item.Discount;

                        obj.UpdatedBy = 0;
                        obj.UpdatedDate = DateTime.Now;

                        entities.CashAndBankTransactions.Add(obj);
                        entities.SaveChanges();

                        if ( item.AmountAdjusted == item.PurchaseAmount)
                        {
                            DebitNote dn = entities.DebitNotes.Where(e => e.DN_No == item.PurchaseNo).SingleOrDefault();
                            PurchaseOrder order = entities.PurchaseOrders.Where(e => e.PO_No == item.PurchaseNo).SingleOrDefault();
                            if (dn != null)
                            {
                                dn.DN_Status = Convert.ToByte(DN_Status.Refunded);
                                entities.SaveChanges();
                            }
                            else if (order != null)
                            {
                                order.PO_Status = Convert.ToByte(PO_Status.Refunded);
                                entities.SaveChanges();
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

        public string GetLastCashNo()
        {
            string st = Convert.ToString(Convert.ToByte(CashBankTransactionType.RefundFromSupplier));
            string cNo = string.Empty;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pq = (from pqs in entities.CashAndBankTransactions
                              where pqs.Is_Cheque == false && pqs.Type == st
                              orderby pqs.UpdatedDate descending
                              select new
                              {
                                  pqs.UpdatedDate,
                                  pqs.Cash_Cheque_No,
                                  pqs.ID,
                                  pqs.Is_Cheque,
                                  pqs.Type
                              }

                               ).ToList();
                    if (pq.Count > 0)
                    {
                        cNo = pq.Take(1).SingleOrDefault().Cash_Cheque_No;
                        if (cNo != null)
                        {
                            string[] str = cNo.Split('-');
                            if (str != null)
                            {
                                cNo = Convert.ToString(Convert.ToInt64(str[1]) + 1);
                            }

                        }
                    }
                    else
                    {
                        cNo = Convert.ToString(1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cNo;
        }

        public string GetCountOfPOSuppliers(out List<SupplierDetailEntity> lstSuppliers)
        {
            string POCount = string.Empty;
            lstSuppliers = new List<SupplierDetailEntity>();
            byte collected = Convert.ToByte(PO_Status.Collected);
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var po = (from e in entities.PurchaseOrders
                              join p in entities.Suppliers
                              on e.Sup_Id equals p.ID
                              where e.IsDeleted == false
                              && e.PO_Status== collected
                              select new SupplierDetailEntity
                              {
                                  ID = e.Sup_Id,
                                  SupplierName = p.Sup_Name
                              }
                         ).Distinct().ToList();

                    if (po != null)
                    {
                        lstSuppliers = new List<SupplierDetailEntity>(po.ToList());
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
        public string GetCountOfDNSuppliers(out List<SupplierDetailEntity> lstSuppliers)
        {
            string DNCount = string.Empty;
            byte status = Convert.ToByte(DN_Status.UnAdjusted);
            byte unrefunded = Convert.ToByte(DN_Status.Refunded);
            lstSuppliers = new List<SupplierDetailEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var po = (from e in entities.DebitNotes
                              join p in entities.Suppliers
                              on e.Sup_Id equals p.ID
                              where e.IsDeleted == false && p.Sup_Inactive!="Y"
                              && (e.DN_Status == status || e.DN_Status!= unrefunded)
                              select new SupplierDetailEntity
                              {
                                  ID = e.Sup_Id,
                                  SupplierName = p.Sup_Name
                              }
                          ).Distinct().ToList();
                    if (po != null)
                    {
                        lstSuppliers = new List<SupplierDetailEntity>(po.ToList());
                        DNCount = Convert.ToString(po.Count);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DNCount;
        }

        public bool IsChequeNoPresent(string cashChequeNo)
        {
            string str = Convert.ToString(Convert.ToByte(CashBankTransactionType.RefundFromSupplier));
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var po = entities.CashAndBankTransactions.Where(e => e.Cash_Cheque_No == cashChequeNo 
                    && e.Type == str).ToList();
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
