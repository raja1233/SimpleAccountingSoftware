
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
    public class PaymentToSupplierDAl: IPaymentToSupplierDAl
    {
        public PaymentToSupplierForm GetPaymentToSupplierDetails(string cashChequeNo)
        {
            PaymentToSupplierForm pqf = new PaymentToSupplierForm();

            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    var pq = (from pqs in entities.CashAndBankTransactions
                              where pqs.Cash_Cheque_No == cashChequeNo
                              select new PaymentToSupplierEntity
                              {
                                  ID = pqs.ID,
                                  SupplierID = pqs.Cus_Sup_Id,
                                  Amount = pqs.Amount,
                                  AccountId = pqs.Acc_Id,
                                  Remarks = pqs.Remarks,
                                  Date = pqs.Cash_Cheque_Date,
                                  IsCheque = pqs.Is_Cheque,
                                  CashChequeNo=pqs.Cash_Cheque_No,
                              }).FirstOrDefault();

                    if (pq != null)
                    {
                        pq.AmountStr = Convert.ToString(pq.Amount);
                        pqf.PaymentToSupplier = pq;
                    }


                    var pqd = (from pqs in entities.CashAndBankTransactions
                               where pqs.Cash_Cheque_No == cashChequeNo
                               select new PaymentToSupplierDetailsEntity
                               {
                                   PurchaseNo = pqs.SO_CN_PO_DN_No,
                                   PurchaseDate = pqs.SO_CN_PO_DN_Date,
                                   PurchaseAmount = pqs.SO_CN_PO_DN_Amt,
                                   AmountDue = pqs.Amt_Due,
                                   Discount = pqs.Discount,
                                   AmountAdjusted = pqs.Amt_Refunded
                               }).ToList<PaymentToSupplierDetailsEntity>();

                    if (pqd != null)
                    {
                        pqf.PaymentToSupplierDetails = pqd;
                    }

                    return pqf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PaymentToSupplierForm GetNewPS(int? SupplierID)
        {
            PaymentToSupplierForm pqf = new PaymentToSupplierForm();

            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    var pqd = entities.Database.SqlQuery<PaymentToSupplierDetailsEntity>("PRC_GetPurchaseDataForPaymentToSuppliers @SupplierID={0}", SupplierID).ToList();

                    if (pqd != null)
                    {
                        pqf.PaymentToSupplierDetails = pqd;
                    }

                    return pqf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public int UpdatePaymentToSupplier(PaymentToSupplierForm psForm)
        {
            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    foreach (var item in psForm.PaymentToSupplierDetails)
                    {
                        CashAndBankTransaction obj = entities.CashAndBankTransactions.Where(e => e.Cash_Cheque_No == psForm.PaymentToSupplier.CashChequeNo
                        && e.SO_CN_PO_DN_No==item.PurchaseNo).SingleOrDefault();
                        if (obj != null)
                        {
                            obj.Acc_Id = psForm.PaymentToSupplier.AccountId;
                            obj.Amount = psForm.PaymentToSupplier.Amount;
                            obj.Cash_Cheque_No = psForm.PaymentToSupplier.CashChequeNo;
                            obj.Cash_Cheque_Date = psForm.PaymentToSupplier.Date;
                            obj.Remarks = psForm.PaymentToSupplier.Remarks;

                            obj.Is_Cheque = psForm.PaymentToSupplier.IsCheque;

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

                            PurchaseInvoice invoice = entities.PurchaseInvoices.Where(e => e.PI_No == item.PurchaseNo).SingleOrDefault();
                            PurchaseOrder order = entities.PurchaseOrders.Where(e => e.PO_No == item.PurchaseNo).SingleOrDefault();
                            if (invoice != null)
                            {
                                if (item.AmountDue == 0 && item.AmountAdjusted == item.PurchaseAmount)
                                {
                                    invoice.PI_Status = Convert.ToByte(PI_Status.Paid);
                                    entities.SaveChanges();
                                }
                                else
                                {
                                    invoice.PI_Status = Convert.ToByte(PI_Status.UnPaid);
                                    entities.SaveChanges();
                                }
                            }
                            else if (order != null)
                            {
                                order.PO_Status = Convert.ToByte(PO_Status.Collected);
                                entities.SaveChanges();
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return psForm.PaymentToSupplier.ID;
        }

        public int SavePaymentToSupplier(PaymentToSupplierForm psForm)
        {
            int autoId = 0;
            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    foreach (var item in psForm.PaymentToSupplierDetails)
                    {
                            CashAndBankTransaction obj = new CashAndBankTransaction();
                            obj.Cus_Sup_Id = psForm.PaymentToSupplier.SupplierID;
                            obj.Acc_Id = psForm.PaymentToSupplier.AccountId;
                            obj.Amount = psForm.PaymentToSupplier.Amount;
                            obj.Cash_Cheque_No = psForm.PaymentToSupplier.CashChequeNo;
                            obj.Cash_Cheque_Date = psForm.PaymentToSupplier.Date;
                            obj.Remarks = psForm.PaymentToSupplier.Remarks;
                            obj.Type = "S";
                            obj.Is_Cheque = psForm.PaymentToSupplier.IsCheque;

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

                        PurchaseInvoice invoice = entities.PurchaseInvoices.Where(e => e.PI_No == item.PurchaseNo).FirstOrDefault();
                        PurchaseOrder order = entities.PurchaseOrders.Where(e => e.PO_No == item.PurchaseNo).FirstOrDefault();
                        if (invoice != null)
                        {
                            if (item.AmountDue == 0 && item.AmountAdjusted == item.PurchaseAmount)
                            {
                                invoice.PI_Status = Convert.ToByte(PI_Status.Paid);
                                entities.SaveChanges();
                            }
                            else
                            {
                                invoice.PI_Status = Convert.ToByte(PI_Status.UnPaid);
                                entities.SaveChanges();
                            }
                        }
                        else if (order != null)
                        {
                            order.PO_Status = Convert.ToByte(PO_Status.Collected);
                            entities.SaveChanges();
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
            string cNo = string.Empty;
            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    var pq = (from pqs in entities.CashAndBankTransactions
                              where pqs.Is_Cheque==false && pqs.Type=="S"
                             // && pqs.Type.StartsWith("PS")
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
                    if (pq.Count>0)
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
            byte status = Convert.ToByte(PO_Status.unDeposited);
            lstSuppliers = new List<SupplierDetailEntity>();
            string POCount = string.Empty;
            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    var po = (from e in entities.PurchaseOrders
                              join p in entities.Suppliers
                              on e.Sup_Id equals p.ID
                              where e.IsDeleted == false
                              && e.PO_Status == status
                              select new SupplierDetailEntity
                              {
                                 ID= e.Sup_Id,
                                 SupplierName= p.Sup_Name
                              }
                         ).Distinct().ToList();

                    if (po != null)
                    {
                        lstSuppliers= new List<SupplierDetailEntity>(po.ToList());
                        POCount = Convert.ToString(po.Count);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return POCount;
        }
        public string GetCountOfPISuppliers(out List<SupplierDetailEntity> lstSuppliers)
        {
            string PICount = string.Empty;
            byte status = Convert.ToByte(PI_Status.UnPaid);
            lstSuppliers = new List<SupplierDetailEntity>();
            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    var po = (from e in entities.PurchaseInvoices
                              join p in entities.Suppliers
                              on e.Sup_Id equals p.ID
                              where e.IsDeleted == false
                              && e.PI_Status == status
                              select new SupplierDetailEntity
                              {
                                ID= e.Sup_Id,
                                SupplierName=  p.Sup_Name
                              }
                          ).Distinct().ToList();
                    if (po != null)
                    {
                        lstSuppliers = new List<SupplierDetailEntity>(po.ToList());
                        PICount = Convert.ToString(po.Count);
                    }

                }
               
            }
            catch(Exception ex)
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
                    var po = entities.CashAndBankTransactions.Where(e => e.Cash_Cheque_No == cashChequeNo && e.Type == "S").ToList();       
                    if (po.Count>0)
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

        public List<AccountsEntity> GetAccountDetails()
        {
            try
            {
                using (SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities())
                {
                    List<AccountsEntity> accountsource = entities.Accounts.Where(x => x.IsDeleted != true).Select(x => new AccountsEntity
                    {
                        AccountName = x.Acc_Name,
                        AccountID = x.ID,
                        AccountType = x.Acc_Type,
                        AccuntTypeCode = x.Acc_Type.ToString(),
                        IsInactive = x.Acc_Inactive
                    }).ToList();
                    return accountsource;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
