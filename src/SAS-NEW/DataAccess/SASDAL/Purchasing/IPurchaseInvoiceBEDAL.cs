﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DALInterface
{
    using SDN.UI.Entities.Purchase;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IPurchaseInvoiceBEDAL
    {
        int AddUpdateInvoice(PurchaseInvoiceForm invoiceData);
        //  bool CanDeleteInvoice(int pqID);
        int DeleteInvoice(string pqNo);
        PurchaseInvoiceForm GetPurchaseInvoice(string pqNo);
        string GetCategoryContent(string catType);
        int UpdationInvoice(PurchaseInvoiceForm invoiceData);
        int GetLastInvoiceNo();
        string GetNewLatestInvoiceNo();
        List<PurchaseInvoiceEntity> GetAllPurchaseInvoices();
    }
}