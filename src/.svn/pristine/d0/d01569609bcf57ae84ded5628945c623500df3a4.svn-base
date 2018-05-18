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
    public class SalesOrderRepository : ISalesOrderRepository
    {
        public List<SalesOrderEntity> GetAllSalesOrders()
        {
            ISalesOrderBL pqBL = new SalesOrderBL();
            return pqBL.GetAllSalesOrders();
        }

        public string GetLatestOrderNo()
        {
            ISalesOrderBL pqBL = new SalesOrderBL();
            return pqBL.GetLatestOrderNo();
        }

        int ISalesOrderRepository.AddUpdateOrder(SalesOrderForm quotationData)
        {
            ISalesOrderBL pqBL = new SalesOrderBL();
            int i = pqBL.AddUpdateOrder(quotationData);
            return i;
        }
        public bool DeleteOrder(int purchaseQuotID)
        {
            ISalesOrderBL pqBL = new SalesOrderBL();
            return pqBL.DeleteOrder(purchaseQuotID);
        }
        public bool CanDeleteOrder(int pqID)
        {
            ISalesOrderBL pqBL = new SalesOrderBL();
            return pqBL.CanDeleteOrder(pqID);
        }

        public SalesOrderForm GetSalesOrder(string pqNo)
        {
            ISalesOrderBL pqBL = new SalesOrderBL();
            return pqBL.GetSalesOrder(pqNo);
        }

        public int UpdationOrder(SalesOrderForm quotationData)
        {
            ISalesOrderBL pqBL = new SalesOrderBL();
            return pqBL.UpdationOrder(quotationData);
        }

        public int ConvertToSalesOrder(SalesOrderForm pqForm)
        {
            ISalesOrderBL pqBL = new SalesOrderBL();
            return pqBL.ConvertToSalesOrder(pqForm);
        }
        public int ConvertToSalesInvoice(SalesOrderForm quotationData)
        {
            ISalesOrderBL pqBL = new SalesOrderBL();
            return pqBL.ConvertToSalesInvoice(quotationData);
        }
        public string GetCategoryContent(string catType)
        {
            ISalesOrderBL pqBL = new SalesOrderBL();
            return pqBL.GetCategoryContent(catType);
        }

        public SalesOrderForm GetPrintSalesOrder(string pqNo)
        {
            ISalesOrderBL pqBL = new SalesOrderBL();
            return pqBL.GetPrintSalesOrder(pqNo);
        }
    }
}
