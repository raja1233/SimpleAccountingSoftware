﻿using SDN.UI.Entities.Accounts;
using SDN.UI.Entities.CashandBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Accounts
{
    public interface ITrailBalanceBL
    {
        List<TrailBalanceEntity> GetList();
    }
}