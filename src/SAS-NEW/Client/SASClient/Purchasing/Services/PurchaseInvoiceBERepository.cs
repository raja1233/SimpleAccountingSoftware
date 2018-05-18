﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    using SDN.Purchasings.BL;
    using SDN.Purchasings.BLInterface;
    using UI.Entities.Purchase;
    public class PurchaseInvoiceBERepository: IPurchaseInvoiceBERepository
    {
        public List<PurchaseInvoiceEntity> GetAllPurchaseInvoices()
        {
            IPurchaseInvoiceBEBL pqBL = new PurchaseInvoiceBEBL();
            return pqBL.GetAllPurchaseInvoices();
        }

        public int GetLatestInvoiceNo()
        {
            IPurchaseInvoiceBEBL pqBL = new PurchaseInvoiceBEBL();
            return pqBL.GetLatestInvoiceNo();
        }
        public string GetNewLatestInvoiceNo()
        {
            IPurchaseInvoiceBEBL pqBL = new PurchaseInvoiceBEBL();
            return pqBL.GetNewLatestInvoiceNo();
        }
        int IPurchaseInvoiceBERepository.AddUpdateInvoice(PurchaseInvoiceForm invoiceData)
        {
            IPurchaseInvoiceBEBL pqBL = new PurchaseInvoiceBEBL();
            int i = pqBL.AddUpdateInvoice(invoiceData);
            return i;
        }
        public int DeleteInvoice(string purchaseQuotID)
        {
            IPurchaseInvoiceBEBL pqBL = new PurchaseInvoiceBEBL();
            return pqBL.DeleteInvoice(purchaseQuotID);
        }

        public PurchaseInvoiceForm GetPurchaseInvoice(string pqNo)
        {
            IPurchaseInvoiceBEBL pqBL = new PurchaseInvoiceBEBL();
            return pqBL.GetPurchaseInvoice(pqNo);
        }

        public int UpdationInvoice(PurchaseInvoiceForm invoiceData)
        {
            IPurchaseInvoiceBEBL pqBL = new PurchaseInvoiceBEBL();
            return pqBL.UpdationInvoice(invoiceData);
        }

        public string GetCategoryContent(string catType)
        {
            IPurchaseInvoiceBEBL pqBL = new PurchaseInvoiceBEBL();
            return pqBL.GetCategoryContent(catType);
        }
    }
}