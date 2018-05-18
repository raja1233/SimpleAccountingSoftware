using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
   public interface IPurchaseInvoicePandSRepository
    {
        string GetCategoryContent(string catType);
        List<PurchaseInvoiceEntity> GetAllPurchaseInvoices();
        int AddUpdateInvoice(PurchaseInvoiceForm quotationData);
        int DeleteInvoice(string purchaseQuotID);
        
        int GetLatestInvoiceNo();
        
        PurchaseInvoiceForm GetPurchaseInvoice(string pqNo);
        int UpdationInvoice(PurchaseInvoiceForm quotationData);

    }
}
