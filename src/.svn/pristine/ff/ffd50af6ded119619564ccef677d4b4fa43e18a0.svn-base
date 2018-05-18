using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;

namespace SASDAL.Accounts
{
    public class BalanceSheetDAL : IBalanceSheetDAL
    {
        SASEntitiesEDM entity = new SASEntitiesEDM();
        public List<BalanceSheetEntity> GatBalanceSheetDetails()
        {
            List<BalanceSheetEntity> list = new List<BalanceSheetEntity>();
            try
            {
                list = entity.Database.SqlQuery<BalanceSheetEntity>("USP_GetBalanceSheetList").ToList();
            }
            catch (Exception  e)
            {

                throw e;
            }
            //var _getlist = list.Where(x => x.AccountName != "Suspense Account").ToList();
            return list;//=_getlist;
        }
    }
}
