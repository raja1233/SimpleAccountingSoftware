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
    public class PurchaseOrderListBL : IPurchaseOrderListBL
    {
        public List<PurchaseOrderListEntity> GetAllPurOrder()
        {
            IPurchaseOrderListDAL purOrder = new PurchaseOrderListDAL();
            var Orderlist = purOrder.GetAllPurOrder();            
            return Orderlist;
        }
        public List<PurchaseOrderListEntity> GetAllPurOrderJson(string jsondata, bool? ExcincTax)
        {
            IPurchaseOrderListDAL purOrder = new PurchaseOrderListDAL();
            var Orderlist = purOrder.GetAllPurOrderJson(jsondata, ExcincTax);           
            return Orderlist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPurchaseOrderListDAL purOrder = new PurchaseOrderListDAL();
            var result = purOrder.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData()
        {
            IPurchaseOrderListDAL purOrder = new PurchaseOrderListDAL();
            var result = purOrder.GetLastSelectionData();
            return result;
        }
        public string GetDateFormat()
        {
            IPurchaseOrderListDAL purOrder = new PurchaseOrderListDAL();
            var result = purOrder.GetDateFormat();
            return result;
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
