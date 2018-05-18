using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Product
{
    public interface IStockCardListDAL
    {

        List<StockCardListEntity> GetAllStockCard();
        //List<StockCardListEntity> GetAllStockCardJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        List<StockCardListEntity> GetProductsDetails(string jsonData, bool? ExcincTax, string ProductCode);
        List<ContentModel> GetCategoryContent(string catType);
    }
}
