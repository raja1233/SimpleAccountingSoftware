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
   public class PandSSoldBL: IPandSSoldBL
    {
        public List<PandSSoldEntity> GetPandSSoldList()
        {
            IPandSSoldDAL pandsSoldDAl = new PandSSoldDAL();
            return pandsSoldDAl.GetAllSalesInvoice();
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPandSSoldDAL pandsSoldBL = new PandSSoldDAL();
            return pandsSoldBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }




        public List<PandSSoldEntity> GetAllSalesInvoice()
        {
            IPandSSoldDAL pandsSoldDAl = new PandSSoldDAL();
            var Invoicelist = pandsSoldDAl.GetAllSalesInvoice();
            
            return Invoicelist;
        }
        public List<PandSSoldEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary)
        {
            IPandSSoldDAL pandsSoldDAl = new PandSSoldDAL();
            var Invoicelist = pandsSoldDAl.GetAllSalesInvoiceJson(jsondata, ExcincTax,IsSummary);
           
            return Invoicelist;
        }
        
        public string GetLastSelectionData(int ScreenId)
        {
            IPandSSoldDAL pandsSoldDAl = new PandSSoldDAL();
            var result = pandsSoldDAl.GetLastSelectionData(ScreenId);
            return result;
        }
        public string getTotalCount(int ScreenId)
        {
            IPandSSoldDAL pandsSoldDAl = new PandSSoldDAL();
            var result = pandsSoldDAl.getTotalCount(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPandSSoldDAL pandsSoldDAl = new PandSSoldDAL();
            var result = pandsSoldDAl.GetDateFormat();
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
    }
}
