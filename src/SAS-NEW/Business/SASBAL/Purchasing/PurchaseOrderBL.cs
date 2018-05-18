

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
    public class PurchaseOrderBL : IPurchaseOrderBL
    {
        public int AddUpdateOrder(PurchaseOrderForm quotationData)
        {
            IPurchaseOrderDAL PODAL = new PurchaseOrderDAL();
            return PODAL.AddUpdateOrder(quotationData);
        }

        public bool CanDeleteOrder(int poID)
        {
            IPurchaseOrderDAL PODAL = new PurchaseOrderDAL();
            return PODAL.CanDeleteOrder(poID);
        }

        public bool DeleteOrder(int purchaseQuotID)
        {
            IPurchaseOrderDAL PODAL = new PurchaseOrderDAL();
            return PODAL.DeleteQuotatoin(purchaseQuotID);
        }

        public List<PurchaseOrderEntity> GetAllPurchaseOrders()
        {
            IPurchaseOrderDAL PODAL = new PurchaseOrderDAL();
            return PODAL.GetAllPurchaseOrders();
        }

        public int GetLatestOrderNo()
        {
            IPurchaseOrderDAL PODAL = new PurchaseOrderDAL();
            return PODAL.GetLastOrderNo();
        }

        public PurchaseOrderForm GetPurchaseOrder(string poNo)
        {
            IPurchaseOrderDAL PODAL = new PurchaseOrderDAL();
            return PODAL.GetPurchaseOrder(poNo);
        }

        public int UpdationOrder(PurchaseOrderForm quotationData)
        {
            IPurchaseOrderDAL PODAL = new PurchaseOrderDAL();
            return PODAL.UpdationOrder(quotationData);
        }

        public string GetCategoryContent(string catType)
        {
            IPurchaseOrderDAL PODAL = new PurchaseOrderDAL();
            return PODAL.GetCategoryContent(catType);
        }
        //public int ConvertToPurchaseOrder(PurchaseOrderForm poForm)
        //{
        //    IPurchaseOrderDAL PODAL = new PurchaseOrderDAL();
        //    return PODAL.ConvertToPurchaseOrder(poForm);
        //}

        public int ConvertToPurchaseInvoice(PurchaseOrderForm quotationData)
        {
            IPurchaseOrderDAL PODAL = new PurchaseOrderDAL();
            return PODAL.ConvertToPurchaseInvoice(quotationData);
        }
        public PurchaseOrderForm GetPrintPurchaseOrder(string piNo)
        {
            IPurchaseOrderDAL PIDAL = new PurchaseOrderDAL();
            return PIDAL.GetPrintPurchaseOrder(piNo);
        }
    }
}
