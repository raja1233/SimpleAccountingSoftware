using SDN.Products.BLInterface;
using SDN.Products.DAL;
using SDN.Products.DALInterface;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BL
{
    public class PandSPurchaseBL : IPandSPurchaseBL
    {
        public List<PandSPurchaseEntity> GetPandSPurchaseList()
        {
            IPandSPurchaseDAL pandsPurchaseDAl = new PandSPurchaseDAL();
            return pandsPurchaseDAl.GetAllSalesInvoice();
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPandSPurchaseDAL pandsPurchaseBL = new PandSPurchaseDAL();
            return pandsPurchaseBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }




        public List<PandSPurchaseEntity> GetAllSalesInvoice()
        {
            IPandSPurchaseDAL pandsPurchaseDAl = new PandSPurchaseDAL();
            var Invoicelist = pandsPurchaseDAl.GetAllSalesInvoice();
            
            return Invoicelist;
        }
        public List<PandSPurchaseEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary)
        {
            IPandSPurchaseDAL pandsPurchaseDAl = new PandSPurchaseDAL();
            var Invoicelist = pandsPurchaseDAl.GetAllSalesInvoiceJson(jsondata, ExcincTax, IsSummary);
          
            return Invoicelist;
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IPandSPurchaseDAL pandsPurchaseDAl = new PandSPurchaseDAL();
            var result = pandsPurchaseDAl.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPandSPurchaseDAL pandsPurchaseDAl = new PandSPurchaseDAL();
            var result = pandsPurchaseDAl.GetDateFormat();
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
        public string getTotalCount(int ScreenId)
        {
            IPandSPurchaseDAL pandsSoldDAl = new PandSPurchaseDAL();
            var result = pandsSoldDAl.getTotalCount(ScreenId);
            return result;
        }
    }
}
