using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BLInterface
{
    public interface ISalesQuotationBL
    {
        int AddUpdateQuotation(SalesQuotationForm quotationData);
        bool DeleteQuotation(int purchaseQuotID);
        bool CanDeleteQuotation(int pqID);
        int UpdationQuotation(SalesQuotationForm quotationData);
        int GetLatestQuotationNo();
        int ConvertToSalesInvoice(SalesQuotationForm quotationData);
        List<ContentModel> GetAllSalesman(string catType);
        string GetCategoryContent(string catType);
        int ConvertToSalesOrder(SalesQuotationForm pqForm);
        SalesQuotationForm GetSalesQuotation(string pqNo);

        List<SalesQuotationEntity> GetAllSalesQuotations();
        SalesQuotationForm GetPrintSalesQuotation(string pqNo);
    }
}
