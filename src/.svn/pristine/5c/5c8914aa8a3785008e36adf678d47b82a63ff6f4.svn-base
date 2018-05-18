
using SDN.UI.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities;
using SDN.Settings.DALInterface;

using SDN.Products.BLInterface;
using SDN.Products.BL;

namespace SDN.Product.Services
{
    public class CountAndAdjustStockListRepository: ICountAndAdjustStockListRepository
    {
        public List<CountAndAdjustStockListEntity> GetAllStockCount()
        {
            ICountAndAdjustStockListBL casDL = new CountAndAdjustStockListBL();
            return casDL.GetAllStockCount();
        }
        public List<CountAndAdjustStockListEntity> GetAllStockCountJson(string jsondata)
        {
            ICountAndAdjustStockListBL casDL = new CountAndAdjustStockListBL();
            return casDL.GetAllStockCountJson(jsondata);
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICountAndAdjustStockListBL casDL = new CountAndAdjustStockListBL();
            return casDL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ICountAndAdjustStockListBL casDL = new CountAndAdjustStockListBL();
            return casDL.GetLastSelectionData(ScreenId);
        }
        public string GetDateFormat()
        {
            ICountAndAdjustStockListBL casDL = new CountAndAdjustStockListBL();
            return casDL.GetDateFormat();
        }

        public List<YearEntity> GetYearRange()
        {
            ICountAndAdjustStockListBL casDL = new CountAndAdjustStockListBL();
            return casDL.GetYearRange();
        }

        public List<TaxModel> GetDefaultTaxes()
        {
            ICountAndAdjustStockListBL casDL = new CountAndAdjustStockListBL();
            return casDL.GetDefaultTaxes();
        }

        public OptionsEntity GetOptionSettings()
        {
            ICountAndAdjustStockListBL casDL = new CountAndAdjustStockListBL();
            return casDL.GetOptionSettings();
        }
    }
}
