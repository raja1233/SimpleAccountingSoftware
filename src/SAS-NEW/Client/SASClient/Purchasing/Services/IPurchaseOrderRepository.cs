using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    public interface IPurchaseOrderRepository
    {
        string GetCategoryContent(string catType);
        List<PurchaseOrderEntity> GetAllPurchaseOrders();
        int AddUpdateOrder(PurchaseOrderForm quotationData);
        bool DeleteOrder(int purchaseQuotID);
        bool CanDeleteOrder(int pqID);
        int GetLatestOrderNo();
        int ConvertToPurchaseInvoice(PurchaseOrderForm quotationData);
        //int ConvertToPurchaseOrder(PurchaseOrderForm pqForm);
        PurchaseOrderForm GetPurchaseOrder(string pqNo);
        int UpdationOrder(PurchaseOrderForm quotationData);
        PurchaseOrderForm GetPrintPurchaseOrder(string piNo);

    }
}
