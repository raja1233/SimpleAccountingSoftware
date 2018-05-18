using SASBAL.Accounts;
using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Accounts.Services
{
    public class StockRepository : IStockRepository
    {
        public List<StockEntity> getStockList()
        {
            IStockBL obj = new StockBL();
            return obj.getStockList();
        }

        public string IsChequeNoPresent()
        {
            IStockBL obj = new StockBL();
            return obj.IsChequeNoPresent();
        }

        public int SaveStockData(StockModel JForm)
        {
            IStockBL obj = new StockBL();
            return obj.SaveStockData(JForm);
        }
    }
}
