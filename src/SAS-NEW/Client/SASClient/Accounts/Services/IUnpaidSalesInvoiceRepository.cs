﻿using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Accounts.Services
{
    public  interface IUnpaidSalesInvoiceRepository
    {
        List<UnpaidSalesInvoiceEntity> getCustomerList();
        int SaveUnpaidSalesInvoiceData(UnpaidSalesInvoiceModel JForm);
        List<string> IsChequeNoPresent();
    }
}
