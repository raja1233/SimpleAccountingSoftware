﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DAL
{
     using SDN.Purchasings.DALInterface;
    using UI.Entities.Purchase;
    using SASDAL;
    public class DebitNoteDAL : IDebitNoteDAL
    {
        /// <summary>
        /// This method is used to get Purchase Invoice details
        /// </summary> 
        /// <param name="pqId"></param>
        /// <returns></returns>
        public DebitNoteForm GetDebitNoteDetails(string dnNo)
        {
            DebitNoteForm pqf = new DebitNoteForm();

            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pq = (from pqs in entities.PurchaseInvoices
                              join dn in entities.DebitNotes on
                              pqs.ID equals dn.PI_Id
                              where dn.DN_No == dnNo && (pqs.IsDeleted == false || pqs.IsDeleted == null)
                              select new DebitNoteEntity
                              {
                                  ID = dn.ID,
                                  SupplierCreditNoteNo = dn.Sup_CN_No,
                                  SupplierCreditNoteDate = dn.Sup_CN_Date,
                                  SCNAmount = dn.Sup_CN_Amount,
                                  SupplierID = pqs.Sup_Id,
                                  DebitNo = dn.DN_No,
                                  DebitDate = dn.DN_Date,
                                  TermsAndConditions = dn.DN_Reason,
                                  TotalBeforeTax = pqs.PI_Tot_bef_Tax,
                                  TotalTax = pqs.PI_GST_Amt,
                                  TotalAfterTax = pqs.PI_Tot_aft_Tax,
                                  ExcIncGST = pqs.Exc_Inc_GST,
                                  PurchaseInvoiceNo=pqs.PI_No,
                                  PurchaseInvoiceID=pqs.ID,
                                  Status = dn.DN_Status

                              }).SingleOrDefault();

                    if (pq != null)
                    {
                        pq.SupplierCreditNoteAmount = Convert.ToString(pq.SCNAmount);
                        pqf.DebitNote = pq;
                    }


                    var pqd = (from pqds in entities.PurchaseInvoiceDetails
                               where pqds.PI_ID == pq.PurchaseInvoiceID
                               select new PurchaseInvoiceDetailEntity
                               {
                                   ID = pqds.ID,
                                   PIID = pqds.PI_ID,
                                   PINo = pqds.PI_No,
                                   PandSCode = pqds.PandS_Code,
                                   PandSName = pqds.PandS_Name,
                                   PIQty = pqds.PI_Qty,
                                   Price = pqds.PI_Price,
                                   PIDiscount = pqds.PI_Discount,
                                   PIAmount = pqds.PI_Amount,
                                   GSTRate = pqds.GST_Rate
                               }).ToList<PurchaseInvoiceDetailEntity>();

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

        public DebitNoteForm GetPrintDebitNote(string pqNo)
        {
            DebitNoteForm pqf = new DebitNoteForm();

            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pq = (from pqs in entities.PurchaseInvoices
                              join dn in entities.DebitNotes on
                              pqs.ID equals dn.PI_Id
                              join S in entities.Suppliers on  dn.Sup_Id equals S.ID
                              where dn.DN_No == pqNo && (pqs.IsDeleted == false || pqs.IsDeleted == null)
                              select new DebitNoteEntity
                              {
                                  ID = dn.ID,
                                  SupplierCreditNoteNo = dn.Sup_CN_No,
                                  SupplierCreditNoteDate = dn.Sup_CN_Date,
                                  SCNAmount = dn.Sup_CN_Amount,
                                  SupplierID = pqs.Sup_Id,
                                  SupplierName=S.Sup_Name,
                                  SupplierBillToLine1=S.Sup_Bill_to_line1,
                                  SupplierBillToLine2=S.Sup_Bill_to_line2,
                                  SupplierBillToCity=S.Sup_Bill_to_city,
                                  SupplierBillToState=S.Sup_Bill_to_state,
                                  SupplierBillToCountary=S.Sup_Bill_to_country,
                                  SupplierBillToPostCode=S.Sup_Bill_to_post_code,
                                  SupplierTelephone =S.Sup_Telephone,  
                                  DebitNo = dn.DN_No,
                                  DebitDate = dn.DN_Date,
                                  TermsAndConditions = dn.DN_Reason,
                                  TotalBeforeTax = pqs.PI_Tot_bef_Tax,
                                  TotalTax = pqs.PI_GST_Amt,
                                  TotalAfterTax = pqs.PI_Tot_aft_Tax,
                                  ExcIncGST = pqs.Exc_Inc_GST,
                                  PurchaseInvoiceNo = pqs.PI_No,
                                  PurchaseInvoiceID = pqs.ID,
                                  Status = dn.DN_Status

                              }).SingleOrDefault();

                    if (pq != null)
                    {
                        pq.SupplierCreditNoteAmount = Convert.ToString(pq.SCNAmount);
                        pqf.DebitNote = pq;
                    }
                    //company details binding data
                    var company = (from com in entities.CompanyDetails
                                   where (com.IsDeleted == false || com.IsDeleted == null)
                                   select new DebitNoteEntity
                                   {
                                       CompanyName = com.Comp_Name,
                                       CompanyLogo = com.Comp_Logo,
                                       CompanyRegNumber = com.Comp_Reg_No,
                                       CompanyGstNumber = com.Comp_GST_Reg_No,
                                       CompanyBillToAddressLine1 = com.Comp_Bill_to_line1,
                                       CompanyBillToAddressLine2 = com.Comp_Bill_to_line2,
                                       CompanyBillToCity = com.Comp_Bill_to_city,
                                       CompanyBillToState = com.Comp_Bill_to_state,
                                       CompanyBillToCountary = com.Comp_Bill_to_country,
                                       CompanyBillToPostCode = com.Comp_Bill_to_post_code,
                                       CompanyEmail = com.Comp_Email,
                                       CompanyFax = com.Comp_Fax
                                   }).SingleOrDefault();
                    pqf.DebitNote.CompanyName = company.CompanyName;
                    pqf.DebitNote.CompanyLogo = company.CompanyLogo;
                    pqf.DebitNote.CompanyRegNumber = company.CompanyRegNumber;
                    pqf.DebitNote.CompanyGstNumber = company.CompanyGstNumber;
                    pqf.DebitNote.CompanyBillToAddressLine1 = company.CompanyBillToAddressLine1;
                    pqf.DebitNote.CompanyBillToAddressLine2 = company.CompanyBillToAddressLine2;
                    pqf.DebitNote.CompanyBillToCity = company.CompanyBillToCity;
                    pqf.DebitNote.CompanyBillToState = company.CompanyBillToState;
                    pqf.DebitNote.CompanyBillToCountary = company.CompanyBillToCountary;
                    pqf.DebitNote.CompanyBillToPostCode = company.CompanyBillToPostCode;
                    pqf.DebitNote.CompanyEmail = company.CompanyEmail;
                    pqf.DebitNote.CompanyFax = company.CompanyFax;
                    //end of company details binding
                    //option details
                    var optiondata = (from option in entities.Options
                                      select new DebitNoteEntity
                                      {
                                          CurrencyCode = option.Currency_Code
                                      }).SingleOrDefault();
                    pqf.DebitNote.CurrencyCode = optiondata.CurrencyCode;
                    //end options details
                    var pqd = (from pqds in entities.PurchaseInvoiceDetails
                               where pqds.PI_ID == pq.PurchaseInvoiceID
                               select new PurchaseInvoiceDetailEntity
                               {
                                   ID = pqds.ID,
                                   PIID = pqds.PI_ID,
                                   PINo = pqds.PI_No,
                                   PandSCode = pqds.PandS_Code,
                                   PandSName = pqds.PandS_Name,
                                   PIQty = pqds.PI_Qty,
                                   Price = pqds.PI_Price,
                                   PIDiscount = pqds.PI_Discount,
                                   PIAmount = pqds.PI_Amount,
                                   GSTRate = pqds.GST_Rate
                               }).ToList<PurchaseInvoiceDetailEntity>();

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

        public void UpdateDebitNote(DebitNoteForm debitNote)
        {
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    DebitNote obj = entities.DebitNotes.Where(e => e.DN_No == debitNote.DebitNote.DebitNo
                   ).SingleOrDefault();
                    if (obj != null)
                    {
                        if (!string.IsNullOrEmpty(debitNote.DebitNote.SupplierCreditNoteAmount))
                        {
                            debitNote.DebitNote.SCNAmount = Convert.ToDecimal(debitNote.DebitNote.SupplierCreditNoteAmount);
                        }
                        obj.DN_Reason = debitNote.DebitNote.TermsAndConditions;
                        obj.Sup_CN_No = debitNote.DebitNote.SupplierCreditNoteNo;
                        obj.Sup_CN_Date = debitNote.DebitNote.SupplierCreditNoteDate;
                        obj.Sup_CN_Amount = debitNote.DebitNote.SCNAmount;
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
