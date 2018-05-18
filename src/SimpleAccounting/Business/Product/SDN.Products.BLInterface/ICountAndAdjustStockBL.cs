
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BLInterface
{
    using SDN.UI.Entities.Product;
    public interface ICountAndAdjustStockBL
    {
        int SaveCountAndAdjustStock(CountAndAdjustStockForm casForm);
        int UpdateCountAndAdjustStock(CountAndAdjustStockForm casForm);
        CountAndAdjustStockForm GetCountAndAdjustStock(string stockCountNo);
        string GetLatestStockCountNo();
    }
}
