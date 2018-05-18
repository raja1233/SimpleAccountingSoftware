﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using SDN.UI.Entities.Sales;
    using UI.Entities;

    public interface ISalesOrderRepository
    {
        string GetCategoryContent(string catType);
        List<SalesOrderEntity> GetAllSalesOrders();
        int AddUpdateOrder(SalesOrderForm quotationData);
        bool DeleteOrder(int purchaseQuotID);
        bool CanDeleteOrder(int pqID);
        int GetLatestOrderNo();
        int ConvertToSalesInvoice(SalesOrderForm quotationData);
        int ConvertToSalesOrder(SalesOrderForm pqForm);
        SalesOrderForm GetSalesOrder(string pqNo);
        int UpdationOrder(SalesOrderForm quotationData);
    }
}