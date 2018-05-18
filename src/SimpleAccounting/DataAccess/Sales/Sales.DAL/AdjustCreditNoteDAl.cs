﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Saless.DAL
{
    using Common;
    using DALInterface;
    using Sales.EDM;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public class AdjustCreditNoteDAl : IAdjustCreditNoteDAl
    {

        public List<CustomerEntity> GetAllCustomer()
        {
            using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
            {
                //List<CustomerEntity> suppliersource = entities.Customers.Where(x => x.IsDeleted != true).Select(x => new CustomerEntity
                //{
                //    ID = x.ID,
                //    CustomerName = x.Sup_Name,
                //    Createddate = x.CreatedDate,
                //}).ToList();
                List<CustomerEntity> suppliersource = (from s in entities.Customers
                                                             join d in entities.CreditNotes on s.ID equals d.Cus_Id
                                                             where d.IsDeleted != true
                                                             select new CustomerEntity
                                                             {
                                                                 CustomerID = s.ID,
                                                                 Name = s.Cus_Name
                                                             }).Distinct().ToList();

                return suppliersource;
            }
        }

        public List<AdjustCreditNoteEntity> GetCreditNotes(string CustomerId)
        {
            using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
            {
                int supid = 0;
                //List<CustomerEntity> suppliersource = entities.Customers.Where(x => x.IsDeleted != true).Select(x => new CustomerEntity
                //{
                //    ID = x.ID,
                //    CustomerName = x.Sup_Name,
                //    Createddate = x.CreatedDate,
                //}).ToList();
                if (CustomerId != null || CustomerId != "" || CustomerId != " ")
                {
                    supid = Convert.ToInt32(CustomerId);
                }
                List<AdjustCreditNoteEntity> debitnotelist = (from p in entities.SalesInvoices
                                                             join d in entities.CreditNotes on p.ID equals d.SI_Id
                                                             where d.IsDeleted != true && d.Cus_Id == supid
                                                             select new AdjustCreditNoteEntity
                                                             {
                                                                 Date = d.CN_Date,
                                                                 Amount = p.SI_Tot_aft_Tax,
                                                                 CreditNoteNo = d.CN_No
                                                             }).ToList();

                return debitnotelist;
            }
        }

        public AdjustCreditNoteForm GetAdjustCreditNoteDetails(string CreditNoteNo)
        {
            AdjustCreditNoteForm pqf = new AdjustCreditNoteForm();

            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    decimal value;
                    var pq = (from pqs in entities.CreditNotes
                              join pi in entities.SalesInvoices on pqs.SI_Id equals pi.ID
                              where pqs.CN_No == CreditNoteNo
                              select new AdjustCreditNoteEntity
                              {
                                  ID = pqs.ID,
                                  CustomerID = pqs.Cus_Id,
                                  //Amount =  pi.SI_Tot_aft_Tax,
                                  Amount = pi.SI_Tot_aft_Tax,
                                  Date = pqs.CN_Date,
                                  CreditNoteNo = pqs.CN_No
                                  //CashChequeNo = pqs.Cash_Cheque_No,
                              }).FirstOrDefault();

                    if (pq != null)
                    {
                        pq.AmountStr = Convert.ToString(pq.Amount);
                        pqf.AdjustCreditNote = pq;
                    }

                    if (pq.CustomerID != 0 || pq.CustomerID != null)
                    {
                        //var pqd = (from pqs in entities.SalesInvoices 
                        //           where pqs.Cus_Id == pq.CustomerID && pqs.SI_Status == 2
                        //           select new AdjustCreditNoteDetailsEntity
                        //           {
                        //               SalesNo = pqs.SI_No,
                        //               SalesDate = pqs.PI_Date,
                        //               PaymentDueDate = pqs.PI_Pmt_Due_Date,
                        //               SalesAmount = pqs.SI_Tot_aft_Tax,
                        //               //AmountDue = pqs.Amt_Due,
                        //               //Discount = pqs.Discount,
                        //               //AmountAdjusted = pqs

                        //           }).ToList<AdjustCreditNoteDetailsEntity>();

                        var pqd = entities.Database.SqlQuery<AdjustCreditNoteDetailsEntity>("PRC_GetSalesDataForAdjustCreditNotes @CustomerID={0}", pq.CustomerID).ToList();

                        if (pqd != null)
                        {
                            pqf.AdjustCreditNoteDetails = pqd;
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
        public AdjustCreditNoteForm GetNewPS(int? CustomerID)
        {
            AdjustCreditNoteForm pqf = new AdjustCreditNoteForm();

            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    var pqd = entities.Database.SqlQuery<AdjustCreditNoteDetailsEntity>("PRC_GetSalesDataForAdjustCreditNotes @CustomerID={0}", CustomerID).ToList();

                    if (pqd != null)
                    {
                        pqf.AdjustCreditNoteDetails = pqd;
                    }

                    return pqf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateAdjustCreditNote(AdjustCreditNoteForm psForm)
        {
            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    foreach (var item in psForm.AdjustCreditNoteDetails)
                    {
                        if (item.CheckAmountAdjusted == true)
                        {
                            CashAndBankTransaction obj = entities.CashAndBankTransactions.Where(e => e.SO_CN_PO_DN_No == item.SalesNo).SingleOrDefault();
                            if (obj != null)
                            {
                                obj.Acc_Id = psForm.AdjustCreditNote.AccountId;
                                obj.Amount = psForm.AdjustCreditNote.Amount;
                                //obj.Cash_Cheque_No = psForm.AdjustCreditNote.CashChequeNo;
                                obj.Cash_Cheque_Date = psForm.AdjustCreditNote.Date;
                                obj.Remarks = psForm.AdjustCreditNote.Remarks;
                                obj.Is_Cheque = psForm.AdjustCreditNote.IsCheque;
                                //saving details entity
                                obj.SO_CN_PO_DN_No = item.SalesNo;
                                obj.SO_CN_PO_DN_Date = item.SalesDate;
                                obj.SO_CN_PO_DN_Amt = item.SalesAmount;
                                obj.Amt_Due = item.AmountDue;
                                obj.Amt_Refunded = item.AmountAdjusted;
                                obj.Discount = item.Discount;
                                obj.DN_CN_No = psForm.AdjustCreditNote.CreditNoteNo;

                                obj.UpdatedBy = 0;
                                obj.UpdatedDate = DateTime.Now.Date;
                                entities.SaveChanges();

                                if (item.AmountDue == 0 && item.AmountAdjusted == item.SalesAmount)
                                {
                                    SalesInvoice invoice = entities.SalesInvoices.Where(e => e.SI_No == item.SalesNo).SingleOrDefault();
                                    //SalesOrder order = entities.SalesOrders.Where(e => e.PO_No == item.SalesNo).SingleOrDefault();
                                    if (invoice != null)
                                    {
                                        invoice.SI_Status = Convert.ToByte(SI_Status.Paid);
                                        entities.SaveChanges();
                                    }
                                    //else if (order != null)
                                    //{
                                    //}
                                    CreditNote debit = entities.CreditNotes.Where(e => e.CN_No == psForm.AdjustCreditNote.CreditNoteNo).SingleOrDefault();
                                    if (debit != null)
                                    {
                                        debit.CN_Status = Convert.ToByte(CN_Status.Adjusted);
                                        entities.SaveChanges();
                                    }
                                }
                            }
                            else
                            {
                                CashAndBankTransaction cashbankobj = new CashAndBankTransaction()
                                {
                                    Acc_Id = psForm.AdjustCreditNote.AccountId,
                                    Amount = psForm.AdjustCreditNote.Amount,
                                    Cash_Cheque_Date = psForm.AdjustCreditNote.Date,
                                    Remarks = psForm.AdjustCreditNote.Remarks,
                                    Is_Cheque = psForm.AdjustCreditNote.IsCheque,
                                    SO_CN_PO_DN_No = item.SalesNo,
                                    SO_CN_PO_DN_Date = item.SalesDate,
                                    SO_CN_PO_DN_Amt = item.SalesAmount,
                                    Amt_Due = item.AmountDue,
                                    Amt_Refunded = item.AmountAdjusted,
                                    Discount = item.Discount,
                                    UpdatedBy = 0,
                                    UpdatedDate = DateTime.Now.Date,
                                    Cus_Sup_Id = psForm.AdjustCreditNote.CustomerID,
                                    DN_CN_No = psForm.AdjustCreditNote.CreditNoteNo,
                                    Type = "S"
                                };
                                entities.CashAndBankTransactions.Add(cashbankobj);
                                entities.SaveChanges();
                                if (item.AmountDue == 0 && item.AmountAdjusted == item.SalesAmount)
                                {
                                    SalesInvoice invoice = entities.SalesInvoices.Where(e => e.SI_No == item.SalesNo).SingleOrDefault();
                                    //SalesOrder order = entities.SalesOrders.Where(e => e.PO_No == item.SalesNo).SingleOrDefault();
                                    if (invoice != null)
                                    {
                                        invoice.SI_Status = Convert.ToByte(SI_Status.Paid);
                                        entities.SaveChanges();
                                    }
                                    //else if (order != null)
                                    //{
                                    //}
                                }
                                CreditNote debit = entities.CreditNotes.Where(e => e.CN_No == psForm.AdjustCreditNote.CreditNoteNo).SingleOrDefault();
                                if (debit != null)
                                {
                                    debit.CN_Status = Convert.ToByte(CN_Status.Adjusted);
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
            return psForm.AdjustCreditNote.ID;
        }

        public int SaveAdjustCreditNote(AdjustCreditNoteForm psForm)
        {
            int autoId = 0;
            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    foreach (var item in psForm.AdjustCreditNoteDetails)
                    {
                        CashAndBankTransaction obj = new CashAndBankTransaction();
                        obj.Cus_Sup_Id = psForm.AdjustCreditNote.CustomerID;
                        obj.Acc_Id = psForm.AdjustCreditNote.AccountId;
                        obj.Amount = psForm.AdjustCreditNote.Amount;
                        //obj.Cash_Cheque_No = psForm.AdjustCreditNote.CashChequeNo;
                        obj.Cash_Cheque_Date = psForm.AdjustCreditNote.Date;
                        obj.Remarks = psForm.AdjustCreditNote.Remarks;
                        obj.Type = "S";
                        //obj.Is_Cheque = psForm.AdjustCreditNote.IsCheque;

                        //saving details entity
                        obj.SO_CN_PO_DN_No = item.SalesNo;
                        obj.SO_CN_PO_DN_Date = item.SalesDate;
                        obj.SO_CN_PO_DN_Amt = item.SalesAmount;
                        obj.Amt_Due = item.AmountDue;
                        obj.Amt_Refunded = item.AmountAdjusted;
                        obj.Discount = item.Discount;

                        obj.UpdatedBy = 0;
                        obj.UpdatedDate = DateTime.Now.Date;

                        entities.CashAndBankTransactions.Add(obj);
                        entities.SaveChanges();

                        if (item.AmountDue == 0 && item.AmountAdjusted == item.SalesAmount)
                        {
                            SalesInvoice invoice = entities.SalesInvoices.Where(e => e.SI_No == item.SalesNo).SingleOrDefault();
                            SalesOrder order = entities.SalesOrders.Where(e => e.SO_No == item.SalesNo).SingleOrDefault();
                            if (invoice != null)
                            {
                                invoice.SI_Status = Convert.ToByte(SI_Status.Paid);
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

        public string GetCountOfSOCustomers()
        {
            string POCount = string.Empty;
            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    var po = (from e in entities.SalesOrders
                              join p in entities.Customers
                              on e.Cus_Id equals p.ID
                              where e.IsDeleted == false
                              select new
                              {
                                  e.Cus_Id,
                                  p.Cus_Name
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
        public string GetCountOfSICustomers()
        {
            string PICount = string.Empty;
            byte status = Convert.ToByte(SI_Status.UnPaid);
            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    var po = (from e in entities.SalesInvoices
                              join p in entities.Customers
                              on e.Cus_Id equals p.ID
                              where e.IsDeleted == false
                              && e.SI_Status == status
                              select new
                              {
                                  e.Cus_Id,
                                  p.Cus_Name
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
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
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
