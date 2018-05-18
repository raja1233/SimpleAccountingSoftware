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
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    using SASDAL;
    using System.Data.Entity;

    public class AdjustCreditNoteDAl : IAdjustCreditNoteDAl
    {

        public List<CustomerEntity> GetAllCustomer()
        {
            using (SASEntitiesEDM entities = new SASEntitiesEDM())
            {
                
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
            using (SASEntitiesEDM entities = new SASEntitiesEDM())
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
                                                             where d.IsDeleted != true && d.Cus_Id == supid &&d.CN_Amount>0
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
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    
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
                    //var temp = pq.CreditNoteNo;
                    //var x = temp.Substring(2);
                    //var y = "AC" + x;
                    //pq.CreditNoteNo = y;
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
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
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

        public int UpdateAdjustCreditNote(AdjustCreditNoteForm psForm, int Type)
        {
            int autoId = 0;
            string AdjustedNo = string.Empty;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    //adjusted credit note account entity
                    //Adjusted Account entity db entry
                    AdjustedCreditNote Acn = new AdjustedCreditNote();
                    Acn.CustomerID = psForm.AdjustCreditNote.CustomerID;
                    Acn.CreditNoteNumber = psForm.AdjustCreditNote.CreditNoteNo;
                    Acn.CreditNoteDate = psForm.AdjustCreditNote.Date;
                    Acn.AdjustCreditNoteNumber = psForm.AdjustCreditNote.AdjustCreditNoteNumber;
                    Acn.AdjustCreditNoteDate = psForm.AdjustCreditNote.AdjustCreditNoteDate;
                    Acn.CreditNoteAmount = psForm.AdjustCreditNote.Amount;
                    Acn.CreatedBy = 0;
                    if (entities.AdjustedCreditNotes.AsNoTracking().FirstOrDefault(x => x.ID == psForm.AdjustCreditNote.ID) == null)
                    {
                        //obj.CreatedBy = invoiceData.SIModel.CreatedBy;
                        Acn.CreatedDate = DateTime.Now;
                        entities.AdjustedCreditNotes.Add(Acn);
                        entities.SaveChanges();
                        autoId = Acn.ID;
                        AdjustedNo = Acn.AdjustCreditNoteNumber;
                    }
                    else
                    {
                        // obj.ModifiedBy = invoiceData.SIModel.ModifiedBy;
                        Acn.ModifiedDate = DateTime.Now;
                        entities.Entry(Acn).State = EntityState.Modified;
                        autoId = entities.SaveChanges();
                    }
                    foreach (var item in psForm.AdjustCreditNoteDetails)
                    {
                        if (item.CheckAmountAdjusted == true)
                        {
                            AdjustedCreditNoteDetail ACN = new AdjustedCreditNoteDetail();
                            if (autoId > 0)
                            {

                                ACN.ACN_ID = autoId;
                                //ACN.CreditNoteNo = psForm.AdjustCreditNote.CreditNoteNo;
                                //ACN.AdjustCreditNoteNo = psForm.AdjustCreditNote.AdjustCreditNoteNumber;
                                ACN.SalesInvoiceNo = item.SalesNo;
                                ACN.SalesInvoiceDate = item.SalesDate;
                                ACN.PaymentDueDate = item.PaymentDueDate;
                                ACN.SalesInvoiceAmount = item.SalesAmount;
                                ACN.AmountDue = item.AmountDue;
                                ACN.AmountAdjusted = item.AmountAdjusted;
                                ACN.CreatedBy = 0;
                                if (entities.AdjustedCreditNoteDetails.AsNoTracking().FirstOrDefault(x => x.ID == psForm.AdjustCreditNote.ID) == null)
                                {
                                    entities.AdjustedCreditNoteDetails.Add(ACN);
                                    entities.SaveChanges();

                                }
                                else
                                {
                                    entities.Entry(ACN).State = EntityState.Modified;
                                    entities.SaveChanges();
                                }
                            }
                        }

                    }
                    //adjusted credit note entity
                    foreach (var item in psForm.AdjustCreditNoteDetails)
                    {
                        if (item.CheckAmountAdjusted == true)
                        {
                            CashAndBankTransaction obj = entities.CashAndBankTransactions.Where(e => e.SO_CN_PO_DN_No == item.SalesNo).OrderByDescending(x=>x.ID).ToList().FirstOrDefault();
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
                                obj.Amt_Due = item.AmountDue-item.AmountAdjusted;
                                obj.Amt_Refunded = item.AmountAdjusted;
                                obj.Discount = item.Discount;
                                obj.DN_CN_No = psForm.AdjustCreditNote.CreditNoteNo;

                                obj.UpdatedBy = 0;
                                obj.UpdatedDate = DateTime.Now.Date;
                                obj.AD_AC_NO = AdjustedNo;
                                entities.SaveChanges();

                                if (item.AmountAdjusted == item.SalesAmount)
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
                                    Amt_Due = item.AmountDue -item.AmountAdjusted,
                                    Amt_Refunded = item.AmountAdjusted,
                                    Discount = item.Discount,
                                    UpdatedBy = 0,
                                    UpdatedDate = DateTime.Now.Date,
                                    Cus_Sup_Id = psForm.AdjustCreditNote.CustomerID,
                                    DN_CN_No = psForm.AdjustCreditNote.CreditNoteNo,
                                    Type = Type.ToString(),
                                    AD_AC_NO= AdjustedNo
                                };
                                entities.CashAndBankTransactions.Add(cashbankobj);
                                entities.SaveChanges();
                                if (item.AmountAdjusted == item.SalesAmount)
                                {
                                    SalesInvoice invoice = entities.SalesInvoices.Where(e => e.SI_No == item.SalesNo).SingleOrDefault();
                                    //SalesOrder order = entities.SalesOrders.Where(e => e.PO_No == item.SalesNo).SingleOrDefault();
                                    if (invoice != null)
                                    {
                                        invoice.SI_Status = Convert.ToByte(SI_Status.Paid);
                                        entities.SaveChanges();
                                    }
                                   
                                }
                                CreditNote debit = entities.CreditNotes.Where(e => e.CN_No == psForm.AdjustCreditNote.CreditNoteNo).SingleOrDefault();
                                if (debit != null)
                                {
                                    debit.CN_Status = Convert.ToByte(CN_Status.Adjusted);
                                    entities.SaveChanges();
                                }
                                

                                //end adjusted Account entity db entry


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

        public int SaveAdjustCreditNote(AdjustCreditNoteForm psForm, int Type)
        {
            int autoId = 0;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
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
                        obj.Type = Type.ToString();
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

                        if ( item.AmountAdjusted == item.SalesAmount)
                        {
                            SalesInvoice invoice = entities.SalesInvoices.Where(e => e.SI_No == item.SalesNo).SingleOrDefault();
                            SalesOrder order = entities.SalesOrders.Where(e => e.SO_No == item.SalesNo).SingleOrDefault();
                            if (invoice != null)
                            {
                                invoice.SI_Status = Convert.ToByte(SI_Status.Paid);
                                entities.SaveChanges();
                            }
                    

                        }
                        CreditNote debit = entities.CreditNotes.Where(e => e.CN_No == psForm.AdjustCreditNote.CreditNoteNo).SingleOrDefault();
                        if (debit != null)
                        {
                            debit.CN_Status = Convert.ToByte(CN_Status.Adjusted);
                            entities.SaveChanges();
                        }

                        //}

                    // add Adjust credit note entity

                    //end of adding entity Adjust credit notes
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
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
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
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
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
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
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

        public string GetLatestInvoiceNo()
        {
            string sNo = string.Empty;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pq = (from acn in entities.AdjustedCreditNotes
                              orderby acn.CreatedDate descending
                              select new
                              {
                                  acn.ID,
                                  acn.AdjustCreditNoteNumber,
                                  acn.AdjustCreditNoteDate
                              }

                             ).ToList();
                    if (pq.Count > 0)
                    {
                        sNo = pq.Take(1).SingleOrDefault().AdjustCreditNoteNumber;
                        if (sNo != null)
                        {
                            string[] str = sNo.Split('-');
                            if (str != null)
                            {
                                sNo = Convert.ToString(Convert.ToInt64(str[1]) + 1);
                            }

                        }
                    }
                    else
                    {
                        sNo = Convert.ToString(1);
                    }
                }
                return sNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AdjustCreditNoteForm AdjustCreditNoteDetails(string cashChequeNo)
        {
            AdjustCreditNoteForm pqf = new AdjustCreditNoteForm();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {

                    var pq = (from pqs in entities.AdjustedCreditNotes
                              join pi in entities.AdjustedCreditNoteDetails on pqs.ID equals pi.ACN_ID
                              where pqs.AdjustCreditNoteNumber == cashChequeNo
                              select new AdjustCreditNoteEntity
                              {
                                  ID = pqs.ID,
                                  CustomerID = pqs.CustomerID,
                                  //Amount =  pi.SI_Tot_aft_Tax,
                                  Amount = pqs.CreditNoteAmount,
                                  Date = pqs.CreditNoteDate,
                                  CreditNoteNo = pqs.CreditNoteNumber,
                                  AdjustCreditNoteNumber = pqs.AdjustCreditNoteNumber,
                                  AdjustCreditNoteDate = pqs.AdjustCreditNoteDate
                                  //CashChequeNo = pqs.Cash_Cheque_No,
                              }).FirstOrDefault();
                    //var temp = pq.CreditNoteNo;
                    //var x = temp.Substring(2);
                    //var y = "AC" + x;
                    //pq.CreditNoteNo = y;
                    
                    if (pq != null)
                    {
                        //pq.AdjustCreditNoteDateStr = pq.AdjustCreditNoteDate.ToString();
                        //pq.AdjustCreditNoteDate = Convert.ToDateTime(pq.AdjustCreditNoteDateStr);
                        pq.AmountStr = Convert.ToString(pq.Amount);
                        pqf.AdjustCreditNote = pq;
                    }

                    var pqd = (from s in entities.AdjustedCreditNotes
                               join t in entities.AdjustedCreditNoteDetails on s.ID equals t.ACN_ID
                               where s.AdjustCreditNoteNumber == cashChequeNo
                               select new AdjustCreditNoteDetailsEntity
                               {
                                   SalesNo = t.SalesInvoiceNo,
                                   SalesDate = t.SalesInvoiceDate,
                                   PaymentDueDate = t.PaymentDueDate,
                                   SalesAmount = t.SalesInvoiceAmount,
                                   AmountDue = t.AmountDue,
                                   AmountAdjusted = t.AmountAdjusted
                               }).ToList();

                        if (pqd != null)
                        {
                            pqf.AdjustCreditNoteDetails = pqd;
                        }
                    }


                    return pqf;
                }
           
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}