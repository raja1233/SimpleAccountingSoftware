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

    public  class PurchaseQuotationRepository:IPurchaseQuotationRepository
    {
        public List<PurchaseQuotationEntity> GetAllPurchaseQuotations()
        {
            IPurchaseQuotationBL pqBL = new PurchaseQuotationBL();
            return pqBL.GetAllPurchaseQuotations();
        }

        public int GetLatestQuotationNo()
        {
            IPurchaseQuotationBL pqBL = new PurchaseQuotationBL();
            return pqBL.GetLatestQuotationNo();
        }

         int IPurchaseQuotationRepository.AddUpdateQuotation(PurchaseQuotationForm quotationData)
        {
            IPurchaseQuotationBL pqBL = new PurchaseQuotationBL();
             int i=  pqBL.AddUpdateQuotation(quotationData);
            return i;
        }
       public  bool DeleteQuotation(int purchaseQuotID)
        {
            IPurchaseQuotationBL pqBL = new PurchaseQuotationBL();
            return pqBL.DeleteQuotation(purchaseQuotID);
        }
       public bool CanDeleteQuotation(int pqID)
        {
            IPurchaseQuotationBL pqBL = new PurchaseQuotationBL();
            return pqBL.CanDeleteQuotation(pqID);
        }

        public PurchaseQuotationForm GetPurchaseQuotation(string pqNo)
        {
            IPurchaseQuotationBL pqBL = new PurchaseQuotationBL();
            return pqBL.GetPurchaseQuotation(pqNo);
        }

        public int UpdationQuotation(PurchaseQuotationForm quotationData)
        {
            IPurchaseQuotationBL pqBL = new PurchaseQuotationBL();
            return pqBL.UpdationQuotation(quotationData);
        }

       public int ConvertToPurchaseOrder(PurchaseQuotationForm pqForm)
        {
            IPurchaseQuotationBL pqBL = new PurchaseQuotationBL();
            return pqBL.ConvertToPurchaseOrder(pqForm);
        }
        public int ConvertToPurchaseInvoice(PurchaseQuotationForm quotationData)
        {
            IPurchaseQuotationBL pqBL = new PurchaseQuotationBL();
            return pqBL.ConvertToPurchaseInvoice(quotationData);
        }
        public string GetCategoryContent(string catType)
        {
            IPurchaseQuotationBL pqBL = new PurchaseQuotationBL();
            return pqBL.GetCategoryContent(catType);
        }
    }


}
