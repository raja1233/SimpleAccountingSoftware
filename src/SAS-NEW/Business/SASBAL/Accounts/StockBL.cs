using SASDAL.Accounts;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Accounts
{
    public class StockBL : IStockBL
    {
        public List<StockEntity> getStockList()
        {
            IStockDAL obj = new StockDAL();
            return obj.getStockList();
        }

        public string IsChequeNoPresent()
        {
            IStockDAL obj = new StockDAL();
            return obj.IsChequeNoPresent();
        }

        public int SaveStockData(StockModel JForm)
        {
            IStockDAL obj = new StockDAL();
            return obj.SaveStockData(JForm);
        }
    }
}
