﻿using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BLInterface
{
    public interface ISalesInvoiceBL
    {
        int AddUpdateInvoice(SalesInvoiceForm quotationData);
        int DeleteInvoice(string purchaseQuotID);

        int UpdationInvoice(SalesInvoiceForm quotationData);
        string GetLatestInvoiceNo();
        string GetCategoryContent(string catType);
        SalesInvoiceForm GetSalesInvoice(string pqNo);
        List<SalesInvoiceEntity> GetAllSalesInvoices();
    }
}
