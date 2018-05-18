﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using SASDAL.Accounts;

namespace SASBAL.Accounts
{
    public class UndeliveredSalesOrdersWithDepositsBL : IUndeliveredSalesOrdersWithDepositsBL
    {
        public List<UndeliveredSalesOrdersWithDepositsViewEntity> GetCustomerList()
        {
            IUndeliveredSalesOrdersWithDepositsDAL obj = new UndeliveredSalesOrdersWithDepositsDAL();
            return obj.GetCustomerList();
        }

        public List<string> IsChequeNoPresent()
        {
            IUndeliveredSalesOrdersWithDepositsDAL obj = new UndeliveredSalesOrdersWithDepositsDAL();
            return obj.IsChequeNoPresent();
        }

        public int SaveUndeliveredSalesOrderData(UndeliveredSalesOrdersWithDepositsModel model)
        {
            IUndeliveredSalesOrdersWithDepositsDAL obj = new UndeliveredSalesOrdersWithDepositsDAL();
            return obj.SaveUndeliveredSalesOrderData(model);
        }
    }
}