using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    using SDN.Purchasings.BL;
    using SDN.Purchasings.BLInterface;

    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        public List<PurchaseOrderEntity> GetAllPurchaseOrders()
        {
            IPurchaseOrderBL poBL = new PurchaseOrderBL();
            return poBL.GetAllPurchaseOrders();
        }

        public int GetLatestOrderNo()
        {
            IPurchaseOrderBL poBL = new PurchaseOrderBL();
            return poBL.GetLatestOrderNo();
        }

        int IPurchaseOrderRepository.AddUpdateOrder(PurchaseOrderForm quotationData)
        {
            IPurchaseOrderBL poBL = new PurchaseOrderBL();
            int i = poBL.AddUpdateOrder(quotationData);
            return i;
        }
        public bool DeleteOrder(int purchaseQuotID)
        {
            IPurchaseOrderBL poBL = new PurchaseOrderBL();
            return poBL.DeleteOrder(purchaseQuotID);
        }
        public bool CanDeleteOrder(int poID)
        {
            IPurchaseOrderBL poBL = new PurchaseOrderBL();
            return poBL.CanDeleteOrder(poID);
        }

        public PurchaseOrderForm GetPurchaseOrder(string poNo)
        {
            IPurchaseOrderBL poBL = new PurchaseOrderBL();
            return poBL.GetPurchaseOrder(poNo);
        }

        public int UpdationOrder(PurchaseOrderForm quotationData)
        {
            IPurchaseOrderBL poBL = new PurchaseOrderBL();
            return poBL.UpdationOrder(quotationData);
        }

        //public int ConvertToPurchaseOrder(PurchaseOrderForm poForm)
        //{
        //    IPurchaseOrderBL poBL = new PurchaseOrderBL();
        //    return poBL.ConvertToPurchaseOrder(poForm);
        //}
        public int ConvertToPurchaseInvoice(PurchaseOrderForm quotationData)
        {
            IPurchaseOrderBL poBL = new PurchaseOrderBL();
            return poBL.ConvertToPurchaseInvoice(quotationData);
        }
        public string GetCategoryContent(string catType)
        {
            IPurchaseOrderBL poBL = new PurchaseOrderBL();
            return poBL.GetCategoryContent(catType);
        }
        public PurchaseOrderForm GetPrintPurchaseOrder(string piNo)
        {
            IPurchaseOrderBL piBL = new PurchaseOrderBL();
            return piBL.GetPrintPurchaseOrder(piNo);
        }
    }


}
