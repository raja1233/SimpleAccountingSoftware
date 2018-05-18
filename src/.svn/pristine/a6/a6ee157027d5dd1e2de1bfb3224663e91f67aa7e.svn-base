

namespace SDN.Sales.DALInterface
{
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ISalesOrderDAL
    {
        int AddUpdateOrder(SalesOrderForm orderData);
        bool CanDeleteOrder(int poID);
        bool DeleteQuotatoin(int poID);
        SalesOrderForm GetSalesOrder(string pqNo);
        int ConvertToSalesInvoice(SalesOrderForm orderData);
        int ConvertToSalesOrder(SalesOrderForm poForm);
        string GetCategoryContent(string catType);
        int UpdationOrder(SalesOrderForm orderData);
        string GetLastOrderNo();
        List<SalesOrderEntity> GetAllSalesOrders();
        SalesOrderForm GetPrintSalesOrder(string pqNo);
    }
}
