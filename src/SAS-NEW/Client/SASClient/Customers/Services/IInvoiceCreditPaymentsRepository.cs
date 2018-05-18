﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Customers.Services
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Customers;
    public interface IInvoiceCreditPaymentsRepository
    {
        List<InvoiceCreditPaymentsEntity> GetCustomersList(string json);
        List<InvCreditPaymentsDetailsEntity> GetUnPaidInvoices(int supplierID, string json);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);

        List<YearEntity> GetYearRange();
        InvoiceCreditPaymentsEntity GetPrintSalesInvoiceCreditPayement(int CustomerID, string json);
    }
}
