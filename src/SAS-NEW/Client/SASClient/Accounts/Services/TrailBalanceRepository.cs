using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.CashandBank;
using SASBAL.CashBank;
using SDN.UI.Entities.Accounts;
using SASBAL.Accounts;

namespace SASClient.Accounts.Services
{
    public class TrailBalanceRepository : ITrailBalanceRepository
    {
        public List<TrailBalanceEntity> GetList()
        {
            ITrailBalanceBL list = new TrailBalanceBL();
            return list.GetList();
        }
    }
}
