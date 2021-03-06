﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BL
{
    using Purchasings.DAL;
    using SDN.Sales.BLInterface;
    using SDN.Sales.DAL;
    using SDN.Sales.DALInterface;
    using SDN.UI.Entities.Sales;
    using UI.Entities;

    public class SalesOrderBL : ISalesOrderBL
    {
        public int AddUpdateOrder(SalesOrderForm quotationData)
        {
            ISalesOrderDAL PQDAL = new SalesOrderDAL();
            return PQDAL.AddUpdateOrder(quotationData);
        }

        public bool CanDeleteOrder(int pqID)
        {
            ISalesOrderDAL PQDAL = new SalesOrderDAL();
            return PQDAL.CanDeleteOrder(pqID);
        }

        public bool DeleteOrder(int purchaseQuotID)
        {
            ISalesOrderDAL PQDAL = new SalesOrderDAL();
            return PQDAL.DeleteQuotatoin(purchaseQuotID);
        }

        public List<SalesOrderEntity> GetAllSalesOrders()
        {
            ISalesOrderDAL PQDAL = new SalesOrderDAL();
            return PQDAL.GetAllSalesOrders();
        }

        public int GetLatestOrderNo()
        {
            ISalesOrderDAL PQDAL = new SalesOrderDAL();
            return PQDAL.GetLastOrderNo();
        }

        public SalesOrderForm GetSalesOrder(string pqNo)
        {
            ISalesOrderDAL PQDAL = new SalesOrderDAL();
            return PQDAL.GetSalesOrder(pqNo);
        }

        public int UpdationOrder(SalesOrderForm quotationData)
        {
            ISalesOrderDAL PQDAL = new SalesOrderDAL();
            return PQDAL.UpdationOrder(quotationData);
        }

        public string GetCategoryContent(string catType)
        {
            ISalesOrderDAL PQDAL = new SalesOrderDAL();
            return PQDAL.GetCategoryContent(catType);
        }
        public int ConvertToSalesOrder(SalesOrderForm pqForm)
        {
            ISalesOrderDAL PQDAL = new SalesOrderDAL();
            return PQDAL.ConvertToSalesOrder(pqForm);
        }

        public int ConvertToSalesInvoice(SalesOrderForm quotationData)
        {
            ISalesOrderDAL PQDAL = new SalesOrderDAL();
            return PQDAL.ConvertToSalesInvoice(quotationData);
        }
    }
}
