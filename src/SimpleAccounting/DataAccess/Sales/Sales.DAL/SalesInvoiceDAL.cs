﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.Sales.DAL
{
    using SDN.Common;
    using SDN.Sales.DALInterface;
    using SDN.Sales.EDM;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    using System.Data.Entity;


    public class SalesInvoiceDAL : ISalesInvoiceDAL
    {
        /// <summary>
        /// This method is used to add or edit purchase invoice
        /// </summary>
        /// <param name="invoiceData"></param>
        /// <returns></returns>
        public int AddUpdateInvoice(SalesInvoiceForm invoiceData)
        {
            int autoId = 0;
            //Add purchase invoice
            SalesInvoice obj = new SalesInvoice();
            obj.ID = invoiceData.Invoice.ID;
            obj.Cus_Id = invoiceData.Invoice.CustomerID;

            obj.SI_Date = invoiceData.Invoice.InvoiceDate;
            obj.SI_GST_Amt = Convert.ToDecimal(invoiceData.Invoice.TotalTax);
            obj.SI_No = invoiceData.Invoice.InvoiceNo;
            obj.SI_TandC = invoiceData.Invoice.TermsAndConditions;
            obj.SI_Tot_aft_Tax = Convert.ToDecimal(invoiceData.Invoice.TotalAfterTax);
            obj.SI_Tot_bef_Tax = Convert.ToDecimal(invoiceData.Invoice.TotalBeforeTax);
            obj.Cus_PO_No = invoiceData.Invoice.OurSONo;
            obj.SI_Credit_Days = invoiceData.Invoice.CreditDays;
            obj.Salesman = invoiceData.Invoice.SalesmanID;
            obj.Exc_Inc_GST = invoiceData.Invoice.ExcIncGST;
            obj.SI_Status = Convert.ToByte(SI_Status.UnPaid);
            obj.IsDeleted = false;

            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    if (entities.SalesInvoices.AsNoTracking().FirstOrDefault(x => x.ID == invoiceData.Invoice.ID) == null)
                    {
                        //obj.CreatedBy = invoiceData.SIModel.CreatedBy;
                        obj.CreatedDate = DateTime.Now;
                        entities.SalesInvoices.Add(obj);
                        entities.SaveChanges();
                        autoId = obj.ID;
                    }
                    else
                    {
                        // obj.ModifiedBy = invoiceData.SIModel.ModifiedBy;
                        obj.ModifiedDate = DateTime.Now;
                        entities.Entry(obj).State = EntityState.Modified;
                        autoId = entities.SaveChanges();
                    }

                    invoiceData.Invoice.ID = autoId;
                    CreateCreditNote(invoiceData);

                    if (autoId > 0)
                    {
                        SalesInvoiceDetail SIDetails;
                        if (invoiceData.InvoiceDetails != null)
                        {
                            foreach (SalesInvoiceDetailEntity SIDetailEntity in invoiceData.InvoiceDetails)
                            {
                                SIDetails = new SalesInvoiceDetail();
                                SIDetails.SI_ID = autoId;
                                SIDetails.SI_No = SIDetailEntity.SINo;
                                SIDetails.PandS_Code = SIDetailEntity.PandSCode;
                                SIDetails.PandS_Name = SIDetailEntity.PandSName;
                                SIDetails.SI_Amount = SIDetailEntity.SIAmount;
                                SIDetails.SI_Discount = SIDetailEntity.SIDiscount;
                                SIDetails.SI_No = SIDetailEntity.SINo;
                                SIDetails.SI_Price = Convert.ToDecimal(SIDetailEntity.SIPrice);
                                SIDetails.SI_Qty = SIDetailEntity.SIQty;
                                SIDetails.GST_Code = SIDetailEntity.GSTCode;
                                SIDetails.GST_Rate = SIDetailEntity.GSTRate;


                                if (entities.SalesInvoiceDetails.AsNoTracking().FirstOrDefault(x => x.ID == SIDetailEntity.ID) == null)
                                {
                                    entities.SalesInvoiceDetails.Add(SIDetails);
                                    entities.SaveChanges();

                                }
                                else
                                {
                                    entities.Entry(SIDetails).State = EntityState.Modified;
                                    entities.SaveChanges();
                                }

                                int SIId = Convert.ToInt32(SIDetailEntity.SINo);
                                ProductsAndService ps = entities.ProductsAndServices.SingleOrDefault(e => e.ID == SIId);
                                if (ps != null)
                                {
                                    if (ps.PandS_Qty_in_stock != null || ps.PandS_Qty_in_stock >= 0)
                                    {
                                        ps.PandS_Qty_in_stock = ps.PandS_Qty_in_stock - SIDetailEntity.SIQty;
                                        entities.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }
                return autoId;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CreateCreditNote(SalesInvoiceForm invoiceData)
        {
            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    CreditNote deb = entities.CreditNotes.Where(e => e.SI_Id == invoiceData.Invoice.ID).SingleOrDefault();
                    if (Convert.ToDecimal(invoiceData.Invoice.TotalBeforeTax) < 0)
                    {
                        if (deb != null)
                        {
                            deb.CN_Date = DateTime.Now.Date;
                            // deb.CN_No = "CN-" + (GetLastCreditNoteNo() + 1);
                            //deb.SI_Id = obj.ID;
                            deb.Cus_Id = invoiceData.Invoice.CustomerID;
                            deb.Cus_DN_Amount = Convert.ToDecimal(invoiceData.Invoice.TotalBeforeTax);
                            deb.ModifiedDate = DateTime.Now;
                            entities.SaveChanges();
                        }
                        else
                        {
                            deb = new CreditNote();
                            deb.CN_Date = DateTime.Now.Date;
                            deb.CN_No = "CN-" + (GetLastCreditNoteNo() + 1);
                            deb.SI_Id = invoiceData.Invoice.ID;
                            deb.Cus_Id = invoiceData.Invoice.CustomerID;
                            deb.CN_Status = Convert.ToByte(DN_Status.UnAdjusted);
                            
                            deb.CreatedDate = DateTime.Now;
                            entities.CreditNotes.Add(deb);
                            entities.SaveChanges();
                        }
                    }
                    else
                    {
                        if (deb != null)
                        {
                            entities.CreditNotes.Remove(deb);
                            entities.SaveChanges();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdationInvoice(SalesInvoiceForm invoiceData)
        {
            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    SalesInvoice obj = entities.SalesInvoices.Where(e => e.SI_No == invoiceData.Invoice.InvoiceNo
                    ).SingleOrDefault();
                    if (obj != null)
                    {
                        //obj.ID = invoiceData.Invoice.ID;
                        obj.Cus_Id = invoiceData.Invoice.CustomerID;

                        obj.SI_Date = invoiceData.Invoice.InvoiceDate;
                        obj.SI_GST_Amt = Convert.ToDecimal(invoiceData.Invoice.TotalTax);
                        obj.SI_No = invoiceData.Invoice.InvoiceNo;
                        obj.SI_TandC = invoiceData.Invoice.TermsAndConditions;
                        obj.SI_Tot_aft_Tax = Convert.ToDecimal(invoiceData.Invoice.TotalAfterTax);
                        obj.SI_Tot_bef_Tax = Convert.ToDecimal(invoiceData.Invoice.TotalBeforeTax);
                        //obj.SI_Pmt_Due_Date = invoiceData.Invoice.PaymentDueDate;
                        obj.Cus_PO_No = invoiceData.Invoice.OurSONo;
                        obj.SI_Credit_Days = invoiceData.Invoice.CreditDays;
                        obj.Salesman = invoiceData.Invoice.SalesmanID;
                        obj.Exc_Inc_GST = invoiceData.Invoice.ExcIncGST;
                        obj.ModifiedDate = DateTime.Now;
                        entities.SaveChanges();
                    }

                    invoiceData.Invoice.ID = obj.ID;
                    CreateCreditNote(invoiceData);

                    var objSales = entities.SalesInvoiceDetails.Where
                        (e => e.SI_ID == obj.ID).ToList();
                    if (objSales != null)
                    {
                        foreach (var item in objSales)
                        {
                            int PSId = Convert.ToInt32(item.SI_No);
                            if (PSId != 0)
                            {
                                ProductsAndService ps = entities.ProductsAndServices.SingleOrDefault(e => e.ID == PSId);
                                if (ps != null)
                                {
                                    ps.PandS_Qty_in_stock = ps.PandS_Qty_in_stock + item.SI_Qty;
                                    entities.SaveChanges();
                                }
                            }

                            entities.SalesInvoiceDetails.Remove(item);
                            entities.SaveChanges();
                        }
                    }
                    SalesInvoiceDetail SIDetails;

                    if (invoiceData.InvoiceDetails != null)
                    {
                        foreach (SalesInvoiceDetailEntity SIDetailEntity in invoiceData.InvoiceDetails)
                        {
                            SIDetails = new SalesInvoiceDetail();
                            SIDetails.SI_ID = obj.ID;
                            SIDetails.SI_No = SIDetailEntity.SINo;
                            SIDetails.PandS_Code = SIDetailEntity.PandSCode;
                            SIDetails.PandS_Name = SIDetailEntity.PandSName;
                            SIDetails.SI_Amount = SIDetailEntity.SIAmount;
                            SIDetails.SI_Discount = SIDetailEntity.SIDiscount;
                            SIDetails.SI_No = SIDetailEntity.SINo;
                            SIDetails.SI_Price = Convert.ToDecimal(SIDetailEntity.SIPrice);
                            SIDetails.SI_Qty = SIDetailEntity.SIQty;
                            SIDetails.GST_Code = SIDetailEntity.GSTCode;
                            SIDetails.GST_Rate = SIDetailEntity.GSTRate;

                            entities.SalesInvoiceDetails.Add(SIDetails);
                            entities.SaveChanges();

                            int PSId = Convert.ToInt32(SIDetailEntity.SINo);
                            if (PSId != 0)
                            {
                                ProductsAndService ps = entities.ProductsAndServices.SingleOrDefault(e => e.ID == PSId);
                                if (ps != null)
                                {
                                    ps.PandS_Qty_in_stock = ps.PandS_Qty_in_stock - SIDetailEntity.SIQty;
                                    entities.SaveChanges();
                                }
                            }
                        }
                    }
                    return obj.ID;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteInvoice(string pqNo)
        {
            int SIStatus = 0;
            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    var SInvoice = entities.SalesInvoices.Where(e => e.SI_No == pqNo).FirstOrDefault();
                    if (SInvoice != null)
                    {
                        var SO_SI = entities.CashAndBankTransactions.Where(x => x.SO_CN_PO_DN_No == pqNo
                        ).FirstOrDefault();

                        if (SO_SI != null)
                        {
                            if (SO_SI.Amt_Due != null)
                            {
                                SInvoice.SI_Status = Convert.ToByte(SI_Status.UnPaid);
                                SIStatus = Convert.ToByte(SI_Status.UnPaid);
                            }
                            else
                            {
                                SInvoice.SI_Status = Convert.ToByte(SI_Status.Paid);
                                SIStatus = Convert.ToByte(SI_Status.Paid);
                            }

                        }
                        else
                        {
                            SInvoice.SI_Status = Convert.ToByte(SI_Status.Cancelled);
                            SIStatus = Convert.ToByte(SI_Status.Cancelled);

                            SInvoice.SI_Tot_bef_Tax = 0;
                            SInvoice.SI_Tot_aft_Tax = 0;
                            SInvoice.SI_GST_Amt = 0;
                            entities.SaveChanges();

                            var pd = entities.SalesInvoiceDetails.Where(e => e.SI_ID == SInvoice.ID).ToList();
                            if (pd != null)
                            {
                                foreach (var item in pd)
                                {
                                    int PSId = Convert.ToInt32(item.SI_No);
                                    if (PSId != 0)
                                    {
                                        ProductsAndService ps = entities.ProductsAndServices.SingleOrDefault(e => e.ID == PSId);
                                        if (ps != null)
                                        {
                                            ps.PandS_Qty_in_stock = ps.PandS_Qty_in_stock + item.SI_Qty;
                                            entities.SaveChanges();
                                        }
                                    }

                                    item.SI_Qty = 0;
                                    item.SI_Price = 0;
                                    item.SI_Discount = 0;
                                    item.SI_Amount = 0;
                                    item.GST_Rate = 0;
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
            return SIStatus;

        }

        private int GetLastCreditNoteNo()
        {
            int qno = 0;
            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    var pq = (from pqs in entities.CreditNotes
                              orderby pqs.ID descending
                              select new
                              {
                                  pqs.ID,
                                  pqs.CreatedDate
                              }

                             );
                    if (pq != null)
                    {
                        qno = pq.Take(1).SingleOrDefault().ID;
                    }
                    else
                    {
                        qno = 0;
                    }
                }
                return qno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetLastInvoiceNo()
        {
            string qno = string.Empty;
            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    var pq = (from pqs in entities.SalesInvoices
                              orderby pqs.ID descending
                              select new
                              {
                                  pqs.ID,
                                  pqs.SI_No,
                                  pqs.CreatedDate
                              }

                             );
                    if (pq != null)
                    {
                        qno = pq.Take(1).SingleOrDefault().SI_No;
                        if(qno!=null)
                        {
                            string[] str = qno.Split('-');
                            if(str!=null)
                            {
                                qno = str[1];
                            }
                            
                        }
                        else
                        {
                            qno =Convert.ToString(pq.Take(1).SingleOrDefault().ID);
                        }
                    }
                    else
                    {
                        var op = (from pqs in entities.Options
                                  select new
                                  {
                                     pqs.Starting_Sales_Inv_No
                                  }

                             );
                        if (op != null)
                        {
                            if (op.SingleOrDefault().Starting_Sales_Inv_No != null)
                            {
                                qno = op.SingleOrDefault().Starting_Sales_Inv_No;
                            }
                        }
                    }
                   
                }
                return qno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method is used to get category content 
        /// </summary>
        /// <returns></returns>
        public string GetCategoryContent(string catType)
        {
            string tandCContent = string.Empty;
            using (SDNSalesDBEntities objProdEntities = new SDNSalesDBEntities())
            {
                try
                {
                    var tandC = (from content in objProdEntities.TermsAndConditions
                                 where content.Cat_Code == catType
                                 select new ContentModel
                                 {
                                     ContentName = content.Cat_Content,
                                     ContentID = content.ID
                                 });
                    if (tandC != null)
                    {
                        tandCContent = tandC.SingleOrDefault().ContentName;
                    }
                    return tandCContent;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        /// <summary>
        /// This method is used to get all purchase invoices
        /// </summary>
        /// <returns></returns>
        public List<SalesInvoiceEntity> GetAllSalesInvoices()
        {
            // List<SalesInvoiceModel> lstSIF = new List<SalesInvoiceForm>();
            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    var lstSIs = (from pq in entities.SalesInvoices
                                  where (pq.IsDeleted == false || pq.IsDeleted == null)

                                  select new SalesInvoiceEntity
                                  {
                                      CustomerID = pq.Cus_Id,
                                      InvoiceNo = pq.SI_No,
                                      InvoiceDate = pq.SI_Date,
                                     // PaymentDueDate = pq.SI_Pmt_Due_Date,
                                      OurSONo = pq.Cus_PO_No,
                                      CreditDays=pq.SI_Credit_Days,
                                      SalesmanID=pq.Salesman,
                                      TotalBeforeTax = pq.SI_Tot_bef_Tax,
                                      TotalTax = pq.SI_GST_Amt,
                                      TotalAfterTax = pq.SI_Tot_aft_Tax,
                                      TermsAndConditions = pq.SI_TandC,
                                      CreatedBy = pq.CreatedBy,
                                      CreatedDate = pq.CreatedDate

                                  }).ToList<SalesInvoiceEntity>();

                    return lstSIs;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// This method is used to get Sales Invoice details
        /// </summary>
        /// <param name="pqId"></param>
        /// <returns></returns>
        public SalesInvoiceForm GetSalesInvoice(string pqno)
        {
            SalesInvoiceForm pqf = new SalesInvoiceForm();

            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    var pq = (from pqs in entities.SalesInvoices
                              where pqs.SI_No == pqno && (pqs.IsDeleted == false || pqs.IsDeleted == null)
                              select new SalesInvoiceEntity
                              {
                                  ID = pqs.ID,
                                  CustomerID = pqs.Cus_Id,
                                  InvoiceNo = pqs.SI_No,
                                  InvoiceDate = pqs.SI_Date,
                              //    PaymentDueDate = pqs.SI_Pmt_Due_Date,
                                  TermsAndConditions = pqs.SI_TandC,
                                  TotalBeforeTax = pqs.SI_Tot_bef_Tax,
                                  TotalTax = pqs.SI_GST_Amt,
                                  TotalAfterTax = pqs.SI_Tot_aft_Tax,
                                  ExcIncGST = pqs.Exc_Inc_GST,
                                  OurSONo = pqs.Cus_PO_No,
                                  CreditDays = pqs.SI_Credit_Days,
                                  SalesmanID = pqs.Salesman,
                                  SIStatus = pqs.SI_Status

                              }).SingleOrDefault();

                    if (pq != null)
                    {
                        pqf.Invoice = pq;
                    }


                    var pqd = (from pqds in entities.SalesInvoiceDetails
                               where pqds.SI_ID == pq.ID
                               select new SalesInvoiceDetailEntity
                               {
                                   ID = pqds.ID,
                                   SIID = pqds.SI_ID,
                                   SINo = pqds.SI_No,
                                   PandSCode = pqds.PandS_Code,
                                   PandSName = pqds.PandS_Name,
                                   SIQty = pqds.SI_Qty,
                                   Price = pqds.SI_Price,
                                   SIDiscount = pqds.SI_Discount,
                                   SIAmount = pqds.SI_Amount,
                                   GSTRate = pqds.GST_Rate
                               }).ToList<SalesInvoiceDetailEntity>();

                    if (pqd != null)
                    {

                        pqf.InvoiceDetails = pqd;
                    }

                    return pqf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
