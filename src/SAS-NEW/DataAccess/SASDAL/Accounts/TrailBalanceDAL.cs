using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.CashandBank;
using SDN.UI.Entities.Accounts;

namespace SASDAL.Accounts
{
    public class TrailBalanceDAL : ITrailBalanceDAL
    {
        SASEntitiesEDM entites = new SASEntitiesEDM();

        public List<TrailBalanceEntity> GetList()
        {
            List<TrailBalanceEntity> AccountList = new List<TrailBalanceEntity>();
            try
            {
                AccountList = entites.Database.SqlQuery<TrailBalanceEntity>("USP_GetTrailBalanceDetailList").ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            var _getlist = AccountList.Where(x => x.AccountName != "Suspense Account").ToList();
            return AccountList= _getlist;
        }
    }
}
