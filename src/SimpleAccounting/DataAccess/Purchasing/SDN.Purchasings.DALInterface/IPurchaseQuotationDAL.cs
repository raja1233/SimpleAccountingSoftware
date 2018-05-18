 

namespace SDN.Purchasings.DALInterface
{
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IPurchaseQuotationDAL
    {
     int AddUpdateQuotation(PurchaseQuotationForm quotationData);
        bool CanDeleteQuotation(int pqID);
        bool DeleteQuotatoin(int pqID);
        PurchaseQuotationForm GetPurchaseQuotation(string pqNo);
        int ConvertToPurchaseInvoice(PurchaseQuotationForm quotationData);
        int ConvertToPurchaseOrder(PurchaseQuotationForm pqForm);
        string GetCategoryContent(string catType);
        int UpdationQuotation(PurchaseQuotationForm quotationData);
        int GetLastQuotationNo();
        List<PurchaseQuotationEntity> GetAllPurchaseQuotations();
    }
}
