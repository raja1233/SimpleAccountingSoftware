using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BLInterface
{
    using UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UI.Entities.Purchase;

    public interface IPurchaseInvoicePandSBL
    {
        int AddUpdateInvoice(PurchaseInvoiceForm quotationData);
        int DeleteInvoice(string purchaseQuotID);
       
        int UpdationInvoice(PurchaseInvoiceForm quotationData);
        int GetLatestInvoiceNo();
        string GetCategoryContent(string catType);
        PurchaseInvoiceForm GetPurchaseInvoice(string pqNo);
        List<PurchaseInvoiceEntity> GetAllPurchaseInvoices();
    }
}
