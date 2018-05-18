
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BL
{
    using SDN.Sales.BLInterface;
    using SDN.Sales.DAL;
    using SDN.Sales.DALInterface;
    using SDN.UI.Entities.Sales;
    using UI.Entities;

    public class SalesQuotationBL: ISalesQuotationBL
    {
        public int AddUpdateQuotation(SalesQuotationForm quotationData)
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.AddUpdateQuotation(quotationData);
        }

        public bool CanDeleteQuotation(int pqID)
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.CanDeleteQuotation(pqID);
        }

        public bool DeleteQuotation(int purchaseQuotID)
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.DeleteQuotatoin(purchaseQuotID);
        }

        public List<SalesQuotationEntity> GetAllSalesQuotations()
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.GetAllSalesQuotations();
        }

        public int GetLatestQuotationNo()
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.GetLastQuotationNo();
        }

        public SalesQuotationForm GetSalesQuotation(string pqNo)
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.GetSalesQuotation(pqNo);
        }
       public List<ContentModel> GetAllSalesman(string catType)
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.GetAllSalesman(catType);
        }
        public int UpdationQuotation(SalesQuotationForm quotationData)
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.UpdationQuotation(quotationData);
        }

        public string GetCategoryContent(string catType)
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.GetCategoryContent(catType);
        }
        public int ConvertToSalesOrder(SalesQuotationForm pqForm)
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.ConvertToSalesOrder(pqForm);
        }

        public int ConvertToSalesInvoice(SalesQuotationForm quotationData)
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.ConvertToSalesInvoice(quotationData);
        }

        public SalesQuotationForm GetPrintSalesQuotation(string pqNo)
        {
            ISalesQuotationDAL PQDAL = new SalesQuotationDAL();
            return PQDAL.GetPrintSalesQuotation(pqNo);
        }
    }
}
