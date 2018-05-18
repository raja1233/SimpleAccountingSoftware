
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BL
{
    using SDN.Sales.BLInterface;
    using SDN.Sales.DAL;
    using SDN.Sales.DALInterface;
    using SDN.Settings.DAL;
    using SDN.Settings.DALInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public class SalesQuotationListBL: ISalesQuotationListBL
    {
        public List<SalesQuotationListEntity> GetAllSalesQuotation()
        {
            ISalesQuotationListDAL purQuotation = new SalesQuotationListDAL();
            var quotationlist = purQuotation.GetAllSalesQuotation();
          
            return quotationlist;
        }
        public List<SalesQuotationListEntity> GetAllSalesQuotationJson(string jsondata, bool? ExcincTax)
        {
            ISalesQuotationListDAL purQuotation = new SalesQuotationListDAL();
            var quotationlist = purQuotation.GetAllSalesQuotationJson(jsondata, ExcincTax);
           
            return quotationlist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ISalesQuotationListDAL purQuotation = new SalesQuotationListDAL();
            var result = purQuotation.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ISalesQuotationListDAL purQuotation = new SalesQuotationListDAL();
            var result = purQuotation.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ISalesQuotationListDAL purQuotation = new SalesQuotationListDAL();
            var result = purQuotation.GetDateFormat();
            return result;
        }

        private string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Invoice";
            else if (ConvertedToPO == true)
                return "Order";
            else
                return "";
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

        public TaxModel GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetAllTaxes().FirstOrDefault();
        }
        public OptionsEntity GetOptionSettings()
        {
            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }

    }
}
