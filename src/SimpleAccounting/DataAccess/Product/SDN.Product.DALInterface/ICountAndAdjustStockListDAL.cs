using SDN.UI.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DALInterface
{
    public interface ICountAndAdjustStockListDAL
    {
        List<CountAndAdjustStockListEntity> GetAllStockCount();
        List<CountAndAdjustStockListEntity> GetAllStockCountJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
    }
}
