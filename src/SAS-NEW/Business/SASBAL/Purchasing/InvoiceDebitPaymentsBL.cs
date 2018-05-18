
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Purchasing
{
    using SASDAL.Purchasing;
    using SDN.UI.Entities.Suppliers;
    public class InvoiceDebitPaymentsBL: IInvoiceDebitPaymentsBL
    {
      public List<InvoiceDebitPaymentsEntity> GetSuppliersList(string json)
        {
            IInvoiceDebitPaymentsDAL pDAL = new InvoiceDebitPaymentsDAL();
            return pDAL.GetSuppliersList(json);
        }
        public List<InvDebitPaymentsDetailsEntity> GetUnPaidInvoices(int supplierID,string json)
        {
            IInvoiceDebitPaymentsDAL pDAL = new InvoiceDebitPaymentsDAL();
            return pDAL.GetUnPaidInvoices(supplierID, json);
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IInvoiceDebitPaymentsDAL pDAL = new InvoiceDebitPaymentsDAL();
            return pDAL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
       public string GetLastSelectionData(int ScreenId)
        {
            IInvoiceDebitPaymentsDAL pDAL = new InvoiceDebitPaymentsDAL();
            return pDAL.GetLastSelectionData(ScreenId);
        }
        public InvoiceDebitPaymentsEntity GetPrintPurchaseInvoiceDebitPayment(int supplierID, string jsondata)
        {
            IInvoiceDebitPaymentsDAL piBL = new InvoiceDebitPaymentsDAL();
            return piBL.GetPrintPurchaseInvoiceDebitPayment(supplierID, jsondata);
        }

    }
}
