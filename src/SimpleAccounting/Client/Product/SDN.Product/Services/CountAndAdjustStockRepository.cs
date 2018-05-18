using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDN.Product.Services
{
    using Products.BL;
    using Products.BLInterface;
    using SDN.UI.Entities.Product;
    public class CountAndAdjustStockRepository: ICountAndAdjustStockRepository
    {
        public int SaveCountAndAdjustStock(CountAndAdjustStockForm casForm)
        {
            ICountAndAdjustStockBL casBL = new CountAndAdjustStockBL();
            return casBL.SaveCountAndAdjustStock(casForm);
        }
        public int UpdateCountAndAdjustStock(CountAndAdjustStockForm casForm)
        {
            ICountAndAdjustStockBL casBL = new CountAndAdjustStockBL();
            return casBL.UpdateCountAndAdjustStock(casForm);
        }
        public CountAndAdjustStockForm GetCountAndAdjustStock(string stockCountNo)
        {
            ICountAndAdjustStockBL casBL = new CountAndAdjustStockBL();
            return casBL.GetCountAndAdjustStock(stockCountNo);
        }
       public string GetLatestStockCountNo()
        {
            ICountAndAdjustStockBL casBL = new CountAndAdjustStockBL();
            return casBL.GetLatestStockCountNo();
        }
    }
}
