using SDN.UI.Entities;
using SDN.UI.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BLInterface
{
    public interface ICountAndAdjustStockListBL
    {
        List<CountAndAdjustStockListEntity> GetAllStockCount();
        List<CountAndAdjustStockListEntity> GetAllStockCountJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        List<YearEntity> GetYearRange();
        List<TaxModel> GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
