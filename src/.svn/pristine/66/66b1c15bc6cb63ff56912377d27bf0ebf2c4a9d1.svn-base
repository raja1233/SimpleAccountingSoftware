
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{
    using Products.BL;
    using Products.BLInterface;
    using SDN.UI.Entities.ProductandServices;
    using Settings.DAL;
    using Settings.DALInterface;
    using UI.Entities;

    public class TopPandSRepository: ITopPandSRepository
    {
       public List<TopPandSEntity> GetPandSList(string JsonData)
        {
            ITopPandSBL pandsBL = new TopPandSBL();
            return pandsBL.GetPandSList(JsonData);
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ITopPandSBL pandsBL = new TopPandSBL();
            var result = pandsBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ITopPandSBL pandsBL = new TopPandSBL();
            var result = pandsBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ITopPandSBL pandsBL = new TopPandSBL();
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
                    obj.Year = StartYear.ToString();
                    YearRange.Add(obj);
                    StartYear++;
                }
                return YearRange;
            }
        }

    }
}
