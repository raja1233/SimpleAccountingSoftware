 

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
    public class PurchaseQuotationBL : IPurchaseQuotationBL
    {
        public int AddUpdateQuotation(PurchaseQuotationForm quotationData)
        {
            IPurchaseQuotationDAL PQDAL = new PurchaseQuotationDAL();
            return PQDAL.AddUpdateQuotation(quotationData);
        }

        public bool CanDeleteQuotation(int pqID)
        {
            IPurchaseQuotationDAL PQDAL = new PurchaseQuotationDAL();
            return PQDAL.CanDeleteQuotation(pqID);
        }

        public bool DeleteQuotation(int purchaseQuotID)
        {
            IPurchaseQuotationDAL PQDAL = new PurchaseQuotationDAL();
            return PQDAL.DeleteQuotatoin(purchaseQuotID);
        }
        
        public List<PurchaseQuotationEntity> GetAllPurchaseQuotations()
        {
            IPurchaseQuotationDAL PQDAL = new PurchaseQuotationDAL();
            return PQDAL.GetAllPurchaseQuotations();
        }

        public int GetLatestQuotationNo()
        {
            IPurchaseQuotationDAL PQDAL = new PurchaseQuotationDAL();
            return PQDAL.GetLastQuotationNo();
        }

        public PurchaseQuotationForm GetPurchaseQuotation(string pqNo)
        {
            IPurchaseQuotationDAL PQDAL = new PurchaseQuotationDAL();
            return PQDAL.GetPurchaseQuotation(pqNo);
        }

        public int UpdationQuotation(PurchaseQuotationForm quotationData)
        {
            IPurchaseQuotationDAL PQDAL = new PurchaseQuotationDAL();
            return PQDAL.UpdationQuotation(quotationData);
        }

        public string GetCategoryContent(string catType)
        {
            IPurchaseQuotationDAL PQDAL = new PurchaseQuotationDAL();
            return PQDAL.GetCategoryContent(catType);
        }
        public int ConvertToPurchaseOrder(PurchaseQuotationForm pqForm)
        {
            IPurchaseQuotationDAL PQDAL = new PurchaseQuotationDAL();
            return PQDAL.ConvertToPurchaseOrder(pqForm);
        }

        public int ConvertToPurchaseInvoice(PurchaseQuotationForm quotationData)
        {
            IPurchaseQuotationDAL PQDAL = new PurchaseQuotationDAL();
            return PQDAL.ConvertToPurchaseInvoice(quotationData);
        }
    }
}
