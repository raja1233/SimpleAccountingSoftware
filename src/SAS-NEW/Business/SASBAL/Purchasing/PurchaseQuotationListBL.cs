using SDN.Purchasings.BLInterface;
using SDN.Purchasings.DAL;
using SDN.Purchasings.DALInterface;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BL
{
    public class PurchaseQuotationListBL : IPurchaseQuotationListBL
    {
      public List<PurchaseQuotationListEntity> GetAllPurQuotation()
        {
            IPurchaseQuotationListDAL purQuotation = new PurchaseQuotationListDAL();
            var quotationlist = purQuotation.GetAllPurQuotation();            
            
            return quotationlist;
        }
        public List<PurchaseQuotationListEntity> GetAllPurQuotationJson(string jsondata, bool? ExcincTax)
        {
            IPurchaseQuotationListDAL purQuotation = new PurchaseQuotationListDAL();
            var quotationlist = purQuotation.GetAllPurQuotationJson(jsondata,ExcincTax);
            
            return quotationlist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPurchaseQuotationListDAL purQuotation = new PurchaseQuotationListDAL();
            var result = purQuotation.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData()
        {
            IPurchaseQuotationListDAL purQuotation = new PurchaseQuotationListDAL();
            var result = purQuotation.GetLastSelectionData();
            return result;
        }
        public string GetDateFormat()
        {
            IPurchaseQuotationListDAL purQuotation = new PurchaseQuotationListDAL();
            var result = purQuotation.GetDateFormat();
            return result;
        }

       
        public List<YearEntity> GetYearRange()
        {
            IOptionsDAL YearInfo = new OptionsDAL();
            var StartYear = YearInfo.GetYearStart();
            List<YearEntity> YearRange = new List<YearEntity>();
            YearEntity obj = new YearEntity();
           if(StartYear==0)
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
                for(int i = 0; i <= diff; i++)
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
