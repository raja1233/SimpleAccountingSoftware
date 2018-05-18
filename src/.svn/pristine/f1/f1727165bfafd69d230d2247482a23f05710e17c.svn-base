
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DAL
{
    using EDM;
    using SDN.Sales.DALInterface;
    using UI.Entities.Sales;

    public class CreditNoteDAL: ICreditNoteDAL
    {
        /// <summary>
        /// This method is used to get Purchase Invoice details
        /// </summary>
        /// <param name="pqId"></param>
        /// <returns></returns>
        public CreditNoteForm GetCreditNoteDetails(string cnNo)
        {
            CreditNoteForm pqf = new CreditNoteForm();

            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    var pq = (from pqs in entities.SalesInvoices
                              join dn in entities.CreditNotes on
                              pqs.ID equals dn.SI_Id
                              where dn.CN_No == cnNo && (pqs.IsDeleted == false || pqs.IsDeleted == null)
                              select new CreditNoteEntity
                              {
                                  SalesInvoiceID = pqs.ID,
                                  SalesInvoiceNo=pqs.SI_No,
                                  ID = dn.ID,
                                  CustomerDebitNoteNo = dn.Cus_DN_No,
                                  CustomerDebitNoteDate = dn.Cus_DN_Date,
                                  CDNAmount = dn.Cus_DN_Amount,
                                  CustomerID = pqs.Cus_Id,
                                  CreditNo = dn.CN_No,
                                  CreditDate = dn.CN_Date,
                                  TermsAndConditions = dn.CN_Reason,
                                  TotalBeforeTax = pqs.SI_Tot_bef_Tax,
                                  TotalTax = pqs.SI_GST_Amt,
                                  TotalAfterTax = pqs.SI_Tot_aft_Tax,
                                 

                                  Status = dn.CN_Status

                              }).SingleOrDefault();

                    if (pq != null)
                    {
                        pq.CustomerDebitNoteAmount = Convert.ToString(pq.CDNAmount);
                        pqf.CreditNote = pq;
                    }


                    var pqd = (from pqds in entities.SalesInvoiceDetails
                               where pqds.SI_ID == pq.SalesInvoiceID
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

        public void UpdateCreditNote(CreditNoteForm CreditNote)
        {
            try
            {
                using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
                {
                    CreditNote obj = entities.CreditNotes.Where(e => e.CN_No == CreditNote.CreditNote.CreditNo
                   ).SingleOrDefault();
                    if (obj != null)
                    {
                        if (!string.IsNullOrEmpty(CreditNote.CreditNote.CustomerDebitNoteAmount))
                        {
                            CreditNote.CreditNote.CDNAmount = Convert.ToDecimal(CreditNote.CreditNote.CustomerDebitNoteAmount);
                        }

                        obj.Cus_DN_No = CreditNote.CreditNote.CustomerDebitNoteNo;
                        obj.Cus_DN_Date = CreditNote.CreditNote.CustomerDebitNoteDate;
                        obj.Cus_DN_Amount = CreditNote.CreditNote.CDNAmount;
                        obj.ModifiedDate = DateTime.Now;
                        entities.SaveChanges();
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
