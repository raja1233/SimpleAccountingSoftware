using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BL
{
    using BLInterface;
    using UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;
    using DALInterface;
    using UI.Entities.Purchase;

    public class PurchaseInvoicePandSBL : IPurchaseInvoicePandSBL
    {
        public int AddUpdateInvoice(PurchaseInvoiceForm quotationData)
        {
            IPurchaseInvoicePandSDAL PQDAL = new PurchaseInvoicePandSDAL();
            return PQDAL.AddUpdateInvoice(quotationData);
        }

        public int DeleteInvoice(string purchaseQuotID)
        {
            IPurchaseInvoicePandSDAL PQDAL = new PurchaseInvoicePandSDAL();
            return PQDAL.DeleteInvoice(purchaseQuotID);
        }

        public List<PurchaseInvoiceEntity> GetAllPurchaseInvoices()
        {
            IPurchaseInvoicePandSDAL PQDAL = new PurchaseInvoicePandSDAL();
            return PQDAL.GetAllPurchaseInvoices();
        }

        public int GetLatestInvoiceNo()
        {
            IPurchaseInvoicePandSDAL PQDAL = new PurchaseInvoicePandSDAL();
            return PQDAL.GetLastInvoiceNo();
        }

        public PurchaseInvoiceForm GetPurchaseInvoice(string pqNo)
        {
            IPurchaseInvoicePandSDAL PQDAL = new PurchaseInvoicePandSDAL();
            return PQDAL.GetPurchaseInvoice(pqNo);
        }

        public int UpdationInvoice(PurchaseInvoiceForm quotationData)
        {
            IPurchaseInvoicePandSDAL PQDAL = new PurchaseInvoicePandSDAL();
            return PQDAL.UpdationInvoice(quotationData);
        }

        public string GetCategoryContent(string catType)
        {
            IPurchaseInvoicePandSDAL PQDAL = new PurchaseInvoicePandSDAL();
            return PQDAL.GetCategoryContent(catType);
        }
        
        
    }
}
