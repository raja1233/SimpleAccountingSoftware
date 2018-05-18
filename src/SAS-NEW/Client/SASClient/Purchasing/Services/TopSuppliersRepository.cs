
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.Services
{
    using SASBAL.Purchasing;
    using SDN.Products.BL;
    using SDN.Products.BLInterface;
    using SDN.Settings.DAL;
    using SDN.Settings.DALInterface;
    using SDN.UI.Entities;
    public class TopSuppliersRepository : ITopSuppliersRepository
    {
        public List<TopSuppliersEntity> GetPandSList(string JsonData)
        {
            ITopSuppliersBL pandsBL = new TopSuppliersBL();
            return pandsBL.GetPandSList(JsonData);
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ITopSuppliersBL pandsBL = new TopSuppliersBL();
            var result = pandsBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ITopSuppliersBL pandsBL = new TopSuppliersBL();
            var result = pandsBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ITopSuppliersBL pandsBL = new TopSuppliersBL();
            var result = pandsBL.GetDateFormat();
            return result;
        }
        public OptionsEntity GetOptionDetails()
        {
            IOptionsDetailsBL optionDAL = new OptionsDetailsBL();
            OptionsEntity lstOptions = optionDAL.GetOptionsDetails();
            return lstOptions;
        }
        public IEnumerable<TaxModel> GetTaxes()
        {
            IPandSTaxCodeAndRateBL pandSTaxBL = new PandSTaxCodeAndRateBL();
            List<TaxModel> lsttaxes = pandSTaxBL.GetTax();
            return lsttaxes;
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
    }
}
