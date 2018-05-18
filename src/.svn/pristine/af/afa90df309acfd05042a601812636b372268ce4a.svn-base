 

namespace SDN.Purchasings.BLInterface
{
    using UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IPurchaseQuotationBL
    {
         int AddUpdateQuotation(PurchaseQuotationForm quotationData);
        bool DeleteQuotation(int purchaseQuotID);
        bool CanDeleteQuotation(int pqID);
        int UpdationQuotation(PurchaseQuotationForm quotationData);
        int GetLatestQuotationNo();
        int ConvertToPurchaseInvoice(PurchaseQuotationForm quotationData);

        string GetCategoryContent(string catType);
        int ConvertToPurchaseOrder(PurchaseQuotationForm pqForm);
        PurchaseQuotationForm GetPurchaseQuotation(string pqNo);
        PurchaseQuotationForm GetPrintPurchaseQuotation(string pqNo);
        List<PurchaseQuotationEntity> GetAllPurchaseQuotations();
    }
}
