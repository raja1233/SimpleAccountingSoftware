﻿using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Accounts
{
    public  interface IBalanceSheetBL
    {
        List<BalanceSheetEntity> GatBalanceSheetDetails();
    }
}