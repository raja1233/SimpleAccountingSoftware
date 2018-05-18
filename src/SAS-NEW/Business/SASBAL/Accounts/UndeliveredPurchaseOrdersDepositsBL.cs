﻿using SASDAL.Accounts;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Accounts
{
    public class UndeliveredPurchaseOrdersDepositsBL : IUndeliveredPurchaseOrdersDepositsBL
    {
        public List<UndeliveredPurchaseOrdersDepositsEntity> getSupplierList()
        {
            IUndeliveredPurchaseOrdersDepositsDAL obj = new UndeliveredPurchaseOrdersDepositsDAL();
            return obj.getSupplierList();
        }

        public List<string> IsChequeNoPresent()
        {
            IUndeliveredPurchaseOrdersDepositsDAL obj = new UndeliveredPurchaseOrdersDepositsDAL();
            return obj.IsChequeNoPresent();
        }

        public int SaveUndeliveredPurchaseOrdersDepositsData(UndeliveredPurchaseOrdersDepositsModel JForm)
        {
            IUndeliveredPurchaseOrdersDepositsDAL obj = new UndeliveredPurchaseOrdersDepositsDAL();
            return obj.SaveUndeliveredPurchaseOrdersDepositsData(JForm);
        }
    }
}