﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Customers
{
    using SASDAL.Customers;
    using SDN.UI.Entities.Customers;
    public class InvoiceCreditPaymentsBL: IInvoiceCreditPaymentsBL
    {
        public List<InvoiceCreditPaymentsEntity> GetCustomersList(string json)
        {
            IInvoiceCreditPaymentsDAL pDAL = new InvoiceCreditPaymentsDAL();
            return pDAL.GetCustomersList(json);
        }
        public List<InvCreditPaymentsDetailsEntity> GetUnPaidInvoices(int supplierID, string json)
        {
            IInvoiceCreditPaymentsDAL pDAL = new InvoiceCreditPaymentsDAL();
            return pDAL.GetUnPaidInvoices(supplierID, json);
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IInvoiceCreditPaymentsDAL pDAL = new InvoiceCreditPaymentsDAL();
            return pDAL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IInvoiceCreditPaymentsDAL pDAL = new InvoiceCreditPaymentsDAL();
            return pDAL.GetLastSelectionData(ScreenId);
        }

        public InvoiceCreditPaymentsEntity GetPrintSalesInvoiceCreditPayement(int CustomerID, string json)
        {
            IInvoiceCreditPaymentsDAL pDAL = new InvoiceCreditPaymentsDAL();
            return pDAL.GetPrintSalesInvoiceCreditPayement(CustomerID,json);
        }
    }
}
