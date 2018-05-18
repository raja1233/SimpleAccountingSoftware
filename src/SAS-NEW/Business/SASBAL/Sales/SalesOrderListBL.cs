using SDN.Sales.BLInterface;
using SDN.Sales.DAL;
using SDN.Sales.DALInterface;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BL
{
    public class SalesOrderListBL: ISalesOrderListBL
    {
        public List<SalesOrderListEntity> GetAllSalesOrder()
        {
            ISalesOrderListDAL purOrder = new SalesOrderListDAL();
            var Orderlist = purOrder.GetAllSalesOrder();
            //foreach (var item in Orderlist)
            //{
            //    var convertresult = CheckConvertTo(item.ConvertedToSI, item.ConvertedToSO);
            //    item.ConvertedTo = convertresult;
            //}
            return Orderlist;
        }
        public List<SalesOrderListEntity> GetAllSalesOrderJson(string jsondata, bool? ExcincTax)
        {
            ISalesOrderListDAL purOrder = new SalesOrderListDAL();
            var Orderlist = purOrder.GetAllSalesOrderJson(jsondata, ExcincTax);
            //foreach (var item in Orderlist)
            //{
            //    var convertresult = CheckConvertTo(item.ConvertedToSI, item.ConvertedToSO);
            //    item.ConvertedTo = convertresult;
            //}
            return Orderlist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ISalesOrderListDAL purOrder = new SalesOrderListDAL();
            var result = purOrder.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData()
        {
            ISalesOrderListDAL purOrder = new SalesOrderListDAL();
            var result = purOrder.GetLastSelectionData();
            return result;
        }
        public string GetDateFormat()
        {
            ISalesOrderListDAL purOrder = new SalesOrderListDAL();
            var result = purOrder.GetDateFormat();
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

    }
}
