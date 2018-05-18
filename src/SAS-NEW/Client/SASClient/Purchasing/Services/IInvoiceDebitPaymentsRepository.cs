﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.Services
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Suppliers;
    public interface IInvoiceDebitPaymentsRepository
    {
        List<InvoiceDebitPaymentsEntity> GetSuppliersList(string json);
        List<InvDebitPaymentsDetailsEntity> GetUnPaidInvoices(int supplierID,string json);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        InvoiceDebitPaymentsEntity GetPrintPurchaseInvoiceDebitPayment(int supplierID, string jsondata);      
        List<YearEntity> GetYearRange();
    }
}
