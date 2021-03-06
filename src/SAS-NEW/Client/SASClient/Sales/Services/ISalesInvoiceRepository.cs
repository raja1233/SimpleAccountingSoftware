﻿using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    public interface ISalesInvoiceRepository
    {
        string GetCategoryContent(string catType);
        List<SalesInvoiceEntity> GetAllSalesInvoices();
        int AddUpdateInvoice(SalesInvoiceForm quotationData);
        int DeleteInvoice(string purchaseQuotID); 

        string GetLatestInvoiceNo();

        SalesInvoiceForm GetSalesInvoice(string pqNo);
        int UpdationInvoice(SalesInvoiceForm quotationData);
        SalesInvoiceForm GetPrintSalesInvoice(string piNo);
        SalesInvoiceEntity DeliveryOrderStatus();
    }
}
