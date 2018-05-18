
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using SDN.UI.Entities.Sales;
    using UI.Entities;

    public interface ISalesQuotationRepository
    {
        string GetCategoryContent(string catType);
        List<SalesQuotationEntity> GetAllSalesQuotations();
        int AddUpdateQuotation(SalesQuotationForm quotationData);
        bool DeleteQuotation(int purchaseQuotID);
        bool CanDeleteQuotation(int pqID);
        List<ContentModel> GetAllSalesman(string catType);
        int GetLatestQuotationNo();
        int ConvertToSalesInvoice(SalesQuotationForm quotationData);
        int ConvertToSalesOrder(SalesQuotationForm pqForm);
        SalesQuotationForm GetSalesQuotation(string pqNo);
        int UpdationQuotation(SalesQuotationForm quotationData);
        SalesQuotationForm GetPrintSalesQuotation(string pqNo);
    }
}
