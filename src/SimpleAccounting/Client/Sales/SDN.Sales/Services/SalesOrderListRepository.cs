using SDN.Sales.BL;
using SDN.Sales.BLInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    public class SalesOrderListRepository: ISalesOrderListRepository
    {
        public List<SalesOrderListEntity> GetAllSalesOrderJson(string jsondata, bool? ExcincTax)
        {
            ISalesOrderListBL purOrder = new SalesOrderListBL();
            List<SalesOrderListEntity> quotationlist = purOrder.GetAllSalesOrderJson(jsondata, ExcincTax);
            return quotationlist;
        }
        public List<SalesOrderListEntity> GetAllSalesOrder()
        {
            ISalesOrderListBL purOrder = new SalesOrderListBL();
            List<SalesOrderListEntity> Orderlist = purOrder.GetAllSalesOrder();
            return Orderlist;
        }
        public List<YearEntity> GetYearRange()
        {
            ISalesOrderListBL purOrder = new SalesOrderListBL();
            List<YearEntity> yearrange = purOrder.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ISalesOrderListBL purOrder = new SalesOrderListBL();
            var result = purOrder.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ISalesOrderListBL purOrder = new SalesOrderListBL();
            var result = purOrder.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ISalesOrderListBL purOrder = new SalesOrderListBL();
            var result = purOrder.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            ISalesOrderListBL purOrder = new SalesOrderListBL();
            return purOrder.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ISalesOrderListBL purOrder = new SalesOrderListBL();
            return purOrder.GetOptionSettings();

        }
    }
}
