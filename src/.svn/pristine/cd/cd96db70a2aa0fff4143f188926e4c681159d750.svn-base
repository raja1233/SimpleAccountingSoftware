using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DALInterface
{
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UI.Entities.Sales;

    public interface ISalesQuotationDAL
    {
        int AddUpdateQuotation(SalesQuotationForm quotationData);
        bool CanDeleteQuotation(int pqID);
        bool DeleteQuotatoin(int pqID);
        SalesQuotationForm GetSalesQuotation(string pqNo);
        int ConvertToSalesInvoice(SalesQuotationForm quotationData);
        int ConvertToSalesOrder(SalesQuotationForm pqForm);
        string GetCategoryContent(string catType);
        List<ContentModel> GetAllSalesman(string catType);
        int UpdationQuotation(SalesQuotationForm quotationData);
        int GetLastQuotationNo();
        List<SalesQuotationEntity> GetAllSalesQuotations();
        SalesQuotationForm GetPrintSalesQuotation(string pqNo);
    }
}
