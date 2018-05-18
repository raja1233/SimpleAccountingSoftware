﻿using SASClient.Accounts.ViewModel;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Accounts.Services
{
    public interface IUndeliveredSalesOrdersWithDepositsRepository
    {
        List<UndeliveredSalesOrdersWithDepositsViewEntity> GetCustomerList();
        List<string> IsChequeNoPresent();
        int SaveUndeliveredSalesOrderData(UndeliveredSalesOrdersWithDepositsModel model);

    }
}
