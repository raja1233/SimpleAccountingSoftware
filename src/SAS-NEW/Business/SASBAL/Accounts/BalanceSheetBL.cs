using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using SASDAL.Accounts;

namespace SASBAL.Accounts
{
    public class BalanceSheetBL : IBalanceSheetBL
    {
        public List<BalanceSheetEntity> GatBalanceSheetDetails()
        {
            IBalanceSheetDAL obj = new BalanceSheetDAL();
            return obj.GatBalanceSheetDetails();
        }
    }
}
