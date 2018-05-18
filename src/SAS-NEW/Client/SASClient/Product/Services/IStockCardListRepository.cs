using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Product.Services
{
    public interface IStockCardListRepository
    {
        //List<StockCardListEntity> GetAllStockCardJson(string jsondata);
        List<StockCardListEntity> GetAllStockCard();
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
        List<ContentModel> GetCategoryContent(string catType);
        List<StockCardListEntity> GetProductsDetails(string jsondata, bool? ExcincTax, string ProductCode);
       
    }
}
