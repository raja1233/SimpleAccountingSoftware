﻿using SASBAL.Accounts;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Accounts.Services
{
    public class UnpaidPurchaseInvoiceRepository : IUnpaidPurchaseInvoiceRepository
    {
        public List<UnpaidPurchaseInvoiceEntity> getSupplierList()
        {
            IUnpaidPurchaseInvoiceBL obj = new UnpaidPurchaseInvoiceBL();
            return obj.getSupplierList();
        }

        public List<string> IsChequeNoPresent()
        {
            IUnpaidPurchaseInvoiceBL obj = new UnpaidPurchaseInvoiceBL();
            return obj.IsChequeNoPresent();
        }

        public int SaveUnpaidPurchaseInvoiceData(UnpaidPurchaseInvoiceModel JForm)
        {
            IUnpaidPurchaseInvoiceBL obj = new UnpaidPurchaseInvoiceBL();
            return obj.SaveUnpaidPurchaseInvoiceData(JForm);
        }
    }
}
