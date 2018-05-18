﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BL
{
    using BLInterface;
    using UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;
    using DALInterface;
    using UI.Entities.Purchase;
    public class PurchaseInvoiceBEBL: IPurchaseInvoiceBEBL
    {
        public int AddUpdateInvoice(PurchaseInvoiceForm quotationData)
        {
            IPurchaseInvoiceBEDAL PQDAL = new PurchaseInvoiceBEDAL();
            return PQDAL.AddUpdateInvoice(quotationData);
        }
        
        public int DeleteInvoice(string purchaseQuotID)
        {
            IPurchaseInvoiceBEDAL PQDAL = new PurchaseInvoiceBEDAL();
            return PQDAL.DeleteInvoice(purchaseQuotID);
        }

        public List<PurchaseInvoiceEntity> GetAllPurchaseInvoices()
        {
            IPurchaseInvoiceBEDAL PQDAL = new PurchaseInvoiceBEDAL();
            return PQDAL.GetAllPurchaseInvoices();
        }
        public string GetNewLatestInvoiceNo()
        {
            IPurchaseInvoiceBEDAL PQDAL = new PurchaseInvoiceBEDAL();
            return PQDAL.GetNewLatestInvoiceNo();
        }
        public int GetLatestInvoiceNo()
        {
            IPurchaseInvoiceBEDAL PQDAL = new PurchaseInvoiceBEDAL();
            return PQDAL.GetLastInvoiceNo();
        }

        public PurchaseInvoiceForm GetPurchaseInvoice(string pqNo)
        {
            IPurchaseInvoiceBEDAL PQDAL = new PurchaseInvoiceBEDAL();
            return PQDAL.GetPurchaseInvoice(pqNo);
        }

        public int UpdationInvoice(PurchaseInvoiceForm quotationData)
        {
            IPurchaseInvoiceBEDAL PQDAL = new PurchaseInvoiceBEDAL();
            return PQDAL.UpdationInvoice(quotationData);
        }

        public string GetCategoryContent(string catType)
        {
            IPurchaseInvoiceBEDAL PQDAL = new PurchaseInvoiceBEDAL();
            return PQDAL.GetCategoryContent(catType);
        }

    }
}