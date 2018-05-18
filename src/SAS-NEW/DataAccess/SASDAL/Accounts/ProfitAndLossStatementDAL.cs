using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;

namespace SASDAL.Accounts
{
    public class ProfitAndLossStatementDAL : IProfitAndLossStatementDAL
    {
        SASEntitiesEDM entity = new SASEntitiesEDM();
        public List<ProfitAndLossStatementEntity> getProfitLossDetails()
        {
            List<ProfitAndLossStatementEntity> ProfitAndLossList = new List<ProfitAndLossStatementEntity>();
            try
            {
                ProfitAndLossList = entity.Database.SqlQuery<ProfitAndLossStatementEntity>("USP_GetProfitAndLossDetailList").ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
            return ProfitAndLossList;
        }
    }
}
