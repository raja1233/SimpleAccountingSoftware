
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Customers
{
    using SDN.UI.Entities.Customers;
    public interface IInvoiceCreditPaymentsDAL
    {
        List<InvoiceCreditPaymentsEntity> GetCustomersList(string json);
        List<InvCreditPaymentsDetailsEntity> GetUnPaidInvoices(int supplierID, string json);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        InvoiceCreditPaymentsEntity GetPrintSalesInvoiceCreditPayement(int CustomerID, string json);
    }
}
