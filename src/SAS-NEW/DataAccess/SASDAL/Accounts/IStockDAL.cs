using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Accounts
{
    public interface IStockDAL
    {
        List<StockEntity> getStockList();
        int SaveStockData(StockModel JForm);
        string IsChequeNoPresent();
    }
}
