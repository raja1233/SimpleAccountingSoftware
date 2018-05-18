using SDN.Sales.BL;
using SDN.Sales.BLInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    public class SalesQuotationRepository: ISalesQuotationRepository
    {
        public List<SalesQuotationEntity> GetAllSalesQuotations()
        {
            ISalesQuotationBL pqBL = new SalesQuotationBL();
            return pqBL.GetAllSalesQuotations();
        }

        public int GetLatestQuotationNo()
        {
            ISalesQuotationBL pqBL = new SalesQuotationBL();
            return pqBL.GetLatestQuotationNo();
        }

        int ISalesQuotationRepository.AddUpdateQuotation(SalesQuotationForm quotationData)
        {
            ISalesQuotationBL pqBL = new SalesQuotationBL();
            int i = pqBL.AddUpdateQuotation(quotationData);
            return i;
        }
        public bool DeleteQuotation(int purchaseQuotID)
        {
            ISalesQuotationBL pqBL = new SalesQuotationBL();
            return pqBL.DeleteQuotation(purchaseQuotID);
        }
        public bool CanDeleteQuotation(int pqID)
        {
            ISalesQuotationBL pqBL = new SalesQuotationBL();
            return pqBL.CanDeleteQuotation(pqID);
        }
        public List<ContentModel> GetAllSalesman(string catType)
        {
            ISalesQuotationBL pqBL = new SalesQuotationBL();
            return pqBL.GetAllSalesman(catType);
        }
        public SalesQuotationForm GetSalesQuotation(string pqNo)
        {
            ISalesQuotationBL pqBL = new SalesQuotationBL();
            return pqBL.GetSalesQuotation(pqNo);
        }

        public int UpdationQuotation(SalesQuotationForm quotationData)
        {
            ISalesQuotationBL pqBL = new SalesQuotationBL();
            return pqBL.UpdationQuotation(quotationData);
        }

        public int ConvertToSalesOrder(SalesQuotationForm pqForm)
        {
            ISalesQuotationBL pqBL = new SalesQuotationBL();
            return pqBL.ConvertToSalesOrder(pqForm);
        }
        public int ConvertToSalesInvoice(SalesQuotationForm quotationData)
        {
            ISalesQuotationBL pqBL = new SalesQuotationBL();
            return pqBL.ConvertToSalesInvoice(quotationData);
        }
        public string GetCategoryContent(string catType)
        {
            ISalesQuotationBL pqBL = new SalesQuotationBL();
            return pqBL.GetCategoryContent(catType);
        }
    }
}
