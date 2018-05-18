using SDN.Purchasings.BL;
using SDN.Purchasings.BLInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    public class PurchaseOrderListRepository: IPurchaseOrderListRepository
    {

        public List<PurchaseOrderListEntity> GetAllPurOrderJson(string jsondata, bool? ExcincTax)
        {
            IPurchaseOrderListBL purOrder = new PurchaseOrderListBL();
            List<PurchaseOrderListEntity> quotationlist = purOrder.GetAllPurOrderJson(jsondata, ExcincTax);
            return quotationlist;
        }
        public List<PurchaseOrderListEntity> GetAllPurOrder()
        {
            IPurchaseOrderListBL purOrder = new PurchaseOrderListBL();
            List<PurchaseOrderListEntity> Orderlist = purOrder.GetAllPurOrder();
            return Orderlist;
        }
        public List<YearEntity> GetYearRange()
        {
            IPurchaseOrderListBL purOrder = new PurchaseOrderListBL();
            List<YearEntity> yearrange = purOrder.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPurchaseOrderListBL purOrder = new PurchaseOrderListBL();
            var result = purOrder.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IPurchaseOrderListBL purOrder = new PurchaseOrderListBL();
            var result = purOrder.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPurchaseOrderListBL purOrder = new PurchaseOrderListBL();
            var result = purOrder.GetDateFormat();
            return result;
        }
        public List<TaxModel> GetDefaultTaxes()
        {
            IPurchaseOrderListBL purOrder = new PurchaseOrderListBL();
            return purOrder.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IPurchaseOrderListBL purOrder = new PurchaseOrderListBL();
            return purOrder.GetOptionSettings();

        }
    }
}
