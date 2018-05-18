
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DAL
{
    using Common;
    using Sales.DALInterface;
    using SASDAL;
    using UI.Entities;
    using UI.Entities.Sales;

    public class RefundToCustomersDAL : IRefundToCustomersDAL
    {
        public RefundToCustomerForm GetRefundToCustomerDetails(string cashChequeNo)
        {
            string str = Convert.ToString(Convert.ToByte(CashBankTransactionType.RefundToCustomer));
            RefundToCustomerForm pqf = new RefundToCustomerForm();

            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pq = (from pqs in entities.CashAndBankTransactions
                              where pqs.Cash_Cheque_No == cashChequeNo
                              && pqs.Type == str
                              select new RefundToCustomerEntity
                              {
                                  ID = pqs.ID,
                                  CustomerID = pqs.Cus_Sup_Id,
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
                        pqf.RefundToCustomer = pq;
                    }


                    var pqd = (from pqs in entities.CashAndBankTransactions
                               where pqs.Cash_Cheque_No == cashChequeNo
                                && pqs.Type == str
                               select new RefundToCustomerDetailsEntity
                               {
                                   SalesNo = pqs.SO_CN_PO_DN_No,
                                   SalesDate = pqs.SO_CN_PO_DN_Date,
                                   SalesAmount = pqs.SO_CN_PO_DN_Amt,
                                   AmountDue = pqs.Amt_Due,
                                   Discount = pqs.Discount,
                                   AmountAdjusted = pqs.Amt_Refunded
                               }).ToList<RefundToCustomerDetailsEntity>();

                    if (pqd != null)
                    {
                        pqf.RefundToCustomerDetails = pqd;
                    }

                    return pqf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RefundToCustomerForm GetNewPS(int? CustomerID)
        {
            RefundToCustomerForm pqf = new RefundToCustomerForm();

            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pqd = entities.Database.SqlQuery<RefundToCustomerDetailsEntity>("SRC_GetSalesDataForRefundToCustomers @CustomerID={0}", CustomerID).ToList();

                    if (pqd != null)
                    {
                        pqf.RefundToCustomerDetails = pqd;
                    }

                    return pqf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateRefundToCustomer(RefundToCustomerForm psForm)
        {
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    foreach (var item in psForm.RefundToCustomerDetails)
                    {
                        CashAndBankTransaction obj = entities.CashAndBankTransactions.Where(e => e.Cash_Cheque_No == psForm.RefundToCustomer.CashChequeNo
                        && e.SO_CN_PO_DN_No == item.SalesNo).SingleOrDefault();
                        if (obj != null)
                        {
                            obj.Acc_Id = psForm.RefundToCustomer.AccountId;
                            obj.Amount = psForm.RefundToCustomer.Amount;
                            obj.Cash_Cheque_No = psForm.RefundToCustomer.CashChequeNo;
                            obj.Cash_Cheque_Date = Convert.ToDateTime(psForm.RefundToCustomer.DateStr);
                            obj.Remarks = psForm.RefundToCustomer.Remarks;

                            obj.Is_Cheque = psForm.RefundToCustomer.IsCheque;

                            //saving details entity
                            obj.SO_CN_PO_DN_No = item.SalesNo;
                            obj.SO_CN_PO_DN_Date = item.SalesDate;
                            obj.SO_CN_PO_DN_Amt = item.SalesAmount;
                            obj.Amt_Due = obj.Amt_Due = item.AmountDue - item.AmountAdjusted;
                            obj.Amt_Refunded = item.AmountAdjusted;
                            obj.Discount = item.Discount;

                            obj.UpdatedBy = 0;
                            obj.UpdatedDate = DateTime.Now;
                            entities.SaveChanges();

                            if ( item.AmountAdjusted == item.SalesAmount)
                            {
                                CreditNote dn = entities.CreditNotes.Where(e => e.CN_No == item.SalesNo).SingleOrDefault();
                                SalesOrder order = entities.SalesOrders.Where(e => e.SO_No == item.SalesNo).SingleOrDefault();
                                if (dn != null)
                                {
                                    dn.CN_Status = Convert.ToByte(DN_Status.Refunded);
                                    entities.SaveChanges();
                                }
                                else if (order != null)
                                {
                                    order.SO_Status = Convert.ToByte(PO_Status.Refunded);
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
            return psForm.RefundToCustomer.ID;
        }

        public int SaveRefundToCustomer(RefundToCustomerForm psForm)
        {
            int autoId = 0;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    foreach (var item in psForm.RefundToCustomerDetails)
                    {
                        CashAndBankTransaction obj = new CashAndBankTransaction();
                        obj.Cus_Sup_Id = psForm.RefundToCustomer.CustomerID;
                        obj.Acc_Id = psForm.RefundToCustomer.AccountId;
                        obj.Amount = psForm.RefundToCustomer.Amount;
                        obj.Cash_Cheque_No = psForm.RefundToCustomer.CashChequeNo;
                        obj.Cash_Cheque_Date = psForm.RefundToCustomer.Date;
                        obj.Remarks = psForm.RefundToCustomer.Remarks;
                        obj.Type = Convert.ToString(Convert.ToByte(CashBankTransactionType.RefundToCustomer));
                        //obj.Type = "C";
                        obj.Is_Cheque = psForm.RefundToCustomer.IsCheque;

                        //saving details entity
                        obj.SO_CN_PO_DN_No = item.SalesNo;
                        obj.SO_CN_PO_DN_Date = item.SalesDate;
                        obj.SO_CN_PO_DN_Amt = item.SalesAmount;
                        obj.Amt_Due = item.AmountDue - item.AmountAdjusted;
                        //obj.Amt_Due = item.AmountDue;
                        obj.Amt_Refunded = item.AmountAdjusted;
                        obj.Discount = item.Discount;

                        obj.UpdatedBy = 0;
                        obj.UpdatedDate = DateTime.Now;

                        entities.CashAndBankTransactions.Add(obj);
                        entities.SaveChanges();

                        if (item.AmountAdjusted == item.SalesAmount)
                        {
                            CreditNote dn = entities.CreditNotes.Where(e => e.CN_No == item.SalesNo).SingleOrDefault();
                            SalesOrder order = entities.SalesOrders.Where(e => e.SO_No == item.SalesNo).SingleOrDefault();
                            if (dn != null)
                            {
                                dn.CN_Status = Convert.ToByte(DN_Status.Refunded);
                                entities.SaveChanges();
                            }
                            else if (order != null)
                            {
                                order.SO_Status = Convert.ToByte(PO_Status.Refunded);
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
            string st = Convert.ToString(Convert.ToByte(CashBankTransactionType.RefundToCustomer));
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

        public string GetCountOfPOCustomers(out List<CustomerEntity> lstCustomers)
        {
            string POCount = string.Empty;
            lstCustomers = new List<CustomerEntity>();
            byte collected = Convert.ToByte(PO_Status.Collected);
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var po = (from e in entities.SalesOrders
                              join p in entities.Customers
                              on e.Cus_Id equals p.ID
                              where e.IsDeleted != true && p.Cus_Inactive!="Y"
                              && e.SO_Status == collected
                              select new CustomerEntity
                              {
                                  CustomerID = e.Cus_Id,
                                  Name = p.Cus_Name
                              }
                         ).Distinct().ToList();

                    if (po != null)
                    {
                        lstCustomers = new List<CustomerEntity>(po.ToList());
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
        public string GetCountOfCNCustomers(out List<CustomerEntity> lstCustomers)
        {
            string DNCount = string.Empty;
            byte status = Convert.ToByte(DN_Status.UnAdjusted);
            byte unrefunded = Convert.ToByte(DN_Status.Refunded);
            lstCustomers = new List<CustomerEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var po = (from e in entities.CreditNotes
                              join p in entities.Customers
                              on e.Cus_Id equals p.ID
                              where e.IsDeleted != true && p.Cus_Inactive!="Y"
                              && (e.CN_Status == status || e.CN_Status != unrefunded)
                              select new CustomerEntity
                              {
                                  CustomerID = e.Cus_Id,
                                  Name = p.Cus_Name
                              }
                          ).Distinct().ToList();
                    if (po != null)
                    {
                        lstCustomers = new List<CustomerEntity>(po.ToList());
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
            string str = Convert.ToString(Convert.ToByte(CashBankTransactionType.RefundToCustomer));
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
