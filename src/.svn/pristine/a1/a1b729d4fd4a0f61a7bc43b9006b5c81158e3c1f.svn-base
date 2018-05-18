using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    public interface IPurchaseQuotationRepository
    {
        string GetCategoryContent(string catType);
        List<PurchaseQuotationEntity> GetAllPurchaseQuotations();
        int AddUpdateQuotation(PurchaseQuotationForm quotationData);
        bool DeleteQuotation(int purchaseQuotID);
        bool CanDeleteQuotation(int pqID);
        int GetLatestQuotationNo();
        int ConvertToPurchaseInvoice(PurchaseQuotationForm quotationData);
        int ConvertToPurchaseOrder(PurchaseQuotationForm pqForm);
        PurchaseQuotationForm GetPurchaseQuotation(string pqNo);
        int UpdationQuotation(PurchaseQuotationForm quotationData);

    }
}
