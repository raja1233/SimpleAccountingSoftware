using SASDAL.Product;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Product
{
    public class StockCardListBL : IStockCardListBL
    {
        public List<StockCardListEntity> GetAllStockCard()
        {
            IStockCardListDAL purInvoice = new StockCardListDAL();
            var Invoicelist = purInvoice.GetAllStockCard();
            return Invoicelist;
        }
        //public List<StockCardListEntity> GetAllStockCardJson(string jsondata)
        //{
        //    IStockCardListDAL purInvoice = new StockCardListDAL();
        //    var Invoicelist = purInvoice.GetAllStockCardJson(jsondata);
        //    return Invoicelist;
        //}
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IStockCardListDAL purInvoice = new StockCardListDAL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IStockCardListDAL purInvoice = new StockCardListDAL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IStockCardListDAL purInvoice = new StockCardListDAL();
            var result = purInvoice.GetDateFormat();
            return result;
        }

        private string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Invoice";
            else if (ConvertedToPO == true)
                return "Invoice";
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
                    obj = new YearEntity();
                    obj.Year = StartYear.ToString();
                    obj.ID = i;
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
       public List<ContentModel> GetCategoryContent(string catType)
        {
            IStockCardListBL bl = new StockCardListBL();
            return bl.GetCategoryContent(catType);
        }
       public List<StockCardListEntity> GetProductsDetails(string jsondata, bool? ExcincTax, string ProductCode)
        {
            IStockCardListDAL bl = new StockCardListDAL();
            return bl.GetProductsDetails(jsondata, ExcincTax, ProductCode);
        }

       
    }
}
