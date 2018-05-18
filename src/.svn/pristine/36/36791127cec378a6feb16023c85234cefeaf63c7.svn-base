using SASBAL.Product;
using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Product.Services
{
    public class StockCardListRepository : IStockCardListRepository
    {
        //public List<StockCardListEntity> GetAllStockCardJson(string jsondata)
        //{
        //    IStockCardListBL purInvoice = new StockCardListBL();
        //    List<StockCardListEntity> quotationlist = purInvoice.GetAllStockCardJson(jsondata);
        //    return quotationlist;
        //}
        public List<StockCardListEntity> GetAllStockCard()
        {
            IStockCardListBL purInvoice = new StockCardListBL();
            List<StockCardListEntity> Invoicelist = purInvoice.GetAllStockCard();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            IStockCardListBL purInvoice = new StockCardListBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IStockCardListBL purInvoice = new StockCardListBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IStockCardListBL purInvoice = new StockCardListBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IStockCardListBL purInvoice = new StockCardListBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IStockCardListBL purInvoice = new StockCardListBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IStockCardListBL purInvoice = new StockCardListBL();
            return purInvoice.GetOptionSettings();

        }

        public List<ContentModel> GetCategoryContent(string catType)
        {
            IStockCardListBL purInvoice = new StockCardListBL();
            return purInvoice.GetCategoryContent(catType);
        }
       public List<StockCardListEntity> GetProductsDetails(string jsondata, bool? ExcincTax,string ProductCode)
        {
            IStockCardListBL purInvoice = new StockCardListBL();
            return purInvoice.GetProductsDetails(jsondata, ExcincTax, ProductCode);
        }
      
    }
}
