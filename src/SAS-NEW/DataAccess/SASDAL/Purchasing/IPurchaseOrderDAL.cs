

namespace SDN.Purchasings.DALInterface
{
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IPurchaseOrderDAL
    {
        int AddUpdateOrder(PurchaseOrderForm orderData);
        bool CanDeleteOrder(int poID);
        bool DeleteQuotatoin(int poID);
        PurchaseOrderForm GetPurchaseOrder(string pqNo);
        int ConvertToPurchaseInvoice(PurchaseOrderForm orderData);
        int ConvertToPurchaseOrder(PurchaseOrderForm poForm);
        string GetCategoryContent(string catType);
        int UpdationOrder(PurchaseOrderForm orderData);
        int GetLastOrderNo();
        List<PurchaseOrderEntity> GetAllPurchaseOrders();
        PurchaseOrderForm GetPrintPurchaseOrder(string piNo);
    }
}
