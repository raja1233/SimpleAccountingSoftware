

namespace SDN.Purchasings.BLInterface
{
    using UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IPurchaseOrderBL
    {
        int AddUpdateOrder(PurchaseOrderForm orderData);
        bool DeleteOrder(int purchaseOrderID);
        bool CanDeleteOrder(int poID);
        int UpdationOrder(PurchaseOrderForm orderData);
        int GetLatestOrderNo();
        int ConvertToPurchaseInvoice(PurchaseOrderForm orderData);

        string GetCategoryContent(string catType);
        //int ConvertToPurchaseOrder(PurchaseOrderForm pqForm);
        PurchaseOrderForm GetPurchaseOrder(string poNo);

        List<PurchaseOrderEntity> GetAllPurchaseOrders();
    }
}
