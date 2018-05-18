using SDN.Products.BL;
using SDN.Products.BLInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Export;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{
    public class PandSStockValueListRepository : IPandSStockValueListRepository
    {
        public List<PandSStockValueListEntity> GetPandSList()
        {
            IPandSStockValueListBL pandsBL = new PandSStockValueListBL();
            return pandsBL.GetPandSList();
        }
        public List<ProductandServiceStockValueListEntity> GetExportDataList(string FileName)
        {
            IPandSStockValueListBL exportdata = new PandSStockValueListBL();
            return exportdata.GetExportDataList(FileName);
        }
        public IEnumerable<TaxModel> GetTaxes()
        {
            IPandSTaxCodeAndRateBL pandSTaxBL = new PandSTaxCodeAndRateBL();
            List<TaxModel> lsttaxes = pandSTaxBL.GetTax();
            return lsttaxes;
        }
        public OptionsEntity GetOptionDetails()
        {
            IOptionsDetailsBL optionDAL = new OptionsDetailsBL();
            OptionsEntity lstOptions = optionDAL.GetOptionsDetails();
            return lstOptions;
        }
    }
}
