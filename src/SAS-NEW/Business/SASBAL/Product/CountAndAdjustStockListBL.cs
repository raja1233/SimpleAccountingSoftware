
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BL
{
    using DAL;
    using DALInterface;
    using SDN.Products.BLInterface;
    using Settings.DALInterface;    
    using UI.Entities;
    using UI.Entities.Product;
    using Settings.DAL;

    public class CountAndAdjustStockListBL: ICountAndAdjustStockListBL
    {
        public List<CountAndAdjustStockListEntity> GetAllStockCount()
        {
            ICountAndAdjustStockListDAL casDL = new CountAndAdjustStockListDAL();
            var sclist= casDL.GetAllStockCount();
            foreach (var item in sclist)
            {
                item.CountAndAdjustStockDate = Convert.ToString(item.CountAndAdjustStockDateDatetime);
                item.AdjustedAmount = Convert.ToString(item.AdjustedAmountd);
            }
             return sclist;
        }
        public List<CountAndAdjustStockListEntity> GetAllStockCountJson(string jsondata)
        {
            ICountAndAdjustStockListDAL casDL = new CountAndAdjustStockListDAL();
            var sclist = casDL.GetAllStockCountJson(jsondata);
            foreach (var item in sclist)
            {
                item.CountAndAdjustStockDate = Convert.ToString(item.CountAndAdjustStockDateDatetime);
                item.AdjustedAmount = Convert.ToString(item.AdjustedAmountd);
            }
            return sclist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICountAndAdjustStockListDAL casDL = new CountAndAdjustStockListDAL();
            return casDL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
        public string GetLastSelectionData()
        {
            ICountAndAdjustStockListDAL casDL = new CountAndAdjustStockListDAL();
            return casDL.GetLastSelectionData();
        }
        public string GetDateFormat()
        {
            ICountAndAdjustStockListDAL casDL = new CountAndAdjustStockListDAL();
            return casDL.GetDateFormat();
        }

        public List<YearEntity> GetYearRange()
        {
             IOptionsDAL YearInfo = new OptionsDAL();
            var StartYear = YearInfo.GetYearStart();
            List<YearEntity> YearRange = new List<YearEntity>();
            YearEntity obj = new YearEntity();
            if (StartYear == 0)
            {
                obj.Year = (DateTime.Today.Year - 1).ToString();
                YearRange.Add(obj);

                obj.Year = DateTime.Today.Year.ToString();
                YearRange.Add(obj);
                return YearRange;
            }
            else
            {
                int diff = DateTime.Now.Year - StartYear;
                for (int i = 0; i <= diff; i++)
                {
                    obj = new YearEntity();
                    obj.Year = StartYear.ToString();
                    obj.ID = i;
                    YearRange.Add(obj);
                    StartYear++;
                }
                return YearRange;
            }
        }

        public List<TaxModel> GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetAllTaxes();
        }

        public OptionsEntity GetOptionSettings()
        {
            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }
    }
}
