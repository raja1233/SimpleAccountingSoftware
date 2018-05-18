using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.CashandBank;
using SASDAL.CashBank;
using SDN.UI.Entities.Accounts;
using SASDAL.Accounts;

namespace SASBAL.Accounts
{
    public class TrailBalanceBL : ITrailBalanceBL
    {
        public List<TrailBalanceEntity> GetList()
        {
            ITrailBalanceDAL list = new TrailBalanceDAL();
            return list.GetList();
        }
    }
}
