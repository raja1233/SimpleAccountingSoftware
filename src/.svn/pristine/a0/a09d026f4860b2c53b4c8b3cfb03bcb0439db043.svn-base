using SDN.UI.Entities;
using SDN.UI.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{
    public interface ICountAndAdjustStockListRepository
    {
        List<CountAndAdjustStockListEntity> GetAllStockCount();
        List<CountAndAdjustStockListEntity> GetAllStockCountJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
        List<YearEntity> GetYearRange();
        List<TaxModel> GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
