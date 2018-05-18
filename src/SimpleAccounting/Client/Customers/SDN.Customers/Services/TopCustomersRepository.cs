
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Customers.Services
{
    using SDN.Customers.BL;
    using SDN.Customers.BLInterface;
    using Products.BLInterface;
    using SDN.UI.Entities;
    using Products.BL;
    using Settings.DALInterface;
    using Settings.DAL;

    public class TopCustomersRepository: ITopCustomersRepository
    {
        public List<TopCustomersEntity> GetPandSList(string JsonData)
        {
            ITopCustomersBL pandsBL = new TopCustomersBL();
            return pandsBL.GetPandSList(JsonData);
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ITopCustomersBL pandsBL = new TopCustomersBL();
            var result = pandsBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ITopCustomersBL pandsBL = new TopCustomersBL();
            var result = pandsBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ITopCustomersBL pandsBL = new TopCustomersBL();
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
