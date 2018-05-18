using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    using SDN.Purchasings.BL;
    using SDN.Purchasings.BLInterface;
    using UI.Entities.Purchase;

    public class PurchaseInvoicePandSRepository: IPurchaseInvoicePandSRepository
    {
        public List<PurchaseInvoiceEntity> GetAllPurchaseInvoices()
        {
            IPurchaseInvoicePandSBL pqBL = new PurchaseInvoicePandSBL();
            return pqBL.GetAllPurchaseInvoices();
        }

        public string GetLatestInvoiceNo()
        {
            IPurchaseInvoicePandSBL pqBL = new PurchaseInvoicePandSBL();
            return pqBL.GetLatestInvoiceNo();
        }
        public int GetLastInvoiceNo()
        {
            IPurchaseInvoicePandSBL pqBL = new PurchaseInvoicePandSBL();
            return pqBL.GetLastInvoiceNo();
        }

        int IPurchaseInvoicePandSRepository.AddUpdateInvoice(PurchaseInvoiceForm invoiceData)
        {
            IPurchaseInvoicePandSBL pqBL = new PurchaseInvoicePandSBL();
            int i = pqBL.AddUpdateInvoice(invoiceData);
            return i;
        }
        public int DeleteInvoice(string purchaseQuotID)
        {
            IPurchaseInvoicePandSBL pqBL = new PurchaseInvoicePandSBL();
            return pqBL.DeleteInvoice(purchaseQuotID);
        }

        public PurchaseInvoiceForm GetPurchaseInvoice(string pqNo)
        {
            IPurchaseInvoicePandSBL pqBL = new PurchaseInvoicePandSBL();
            return pqBL.GetPurchaseInvoice(pqNo);
        }

        public int UpdationInvoice(PurchaseInvoiceForm invoiceData)
        {
            IPurchaseInvoicePandSBL pqBL = new PurchaseInvoicePandSBL();
            return pqBL.UpdationInvoice(invoiceData);
        }

        public string GetCategoryContent(string catType)
        {
            IPurchaseInvoicePandSBL pqBL = new PurchaseInvoicePandSBL();
            return pqBL.GetCategoryContent(catType);
        }
    }
}
