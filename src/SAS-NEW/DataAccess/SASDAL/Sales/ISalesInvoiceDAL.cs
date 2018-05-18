using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DALInterface
{
    public interface ISalesInvoiceDAL
    {
        int AddUpdateInvoice(SalesInvoiceForm invoiceData);
        //  bool CanDeleteInvoice(int pqID); 
        int DeleteInvoice(string pqNo);
        SalesInvoiceForm GetSalesInvoice(string pqNo);

        string GetCategoryContent(string catType);
        int UpdationInvoice(SalesInvoiceForm invoiceData);
        string GetLastInvoiceNo();
        List<SalesInvoiceEntity> GetAllSalesInvoices();
        SalesInvoiceForm GetPrintSalesInvoice(string piNo);
        SalesInvoiceEntity DeliveryOrderStatus();
    }
}
