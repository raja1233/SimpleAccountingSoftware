using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using SASBAL.Accounts;

namespace SASClient.Accounts.Services
{
    public class ProfitAndLossStatementRepository : IProfitAndLossStatementRepository
    {
        public List<ProfitAndLossStatementEntity> getProfitLossDetails()
        {
            IProfitAndLossStatementBL obj = new ProfitAndLossStatementBL();
            return obj.getProfitLossDetails();
        }
    }
}
