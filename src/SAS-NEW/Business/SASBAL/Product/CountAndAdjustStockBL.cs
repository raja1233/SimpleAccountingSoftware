using SASDAL;

namespace SDN.Products.BL
{
    using DAL;
    using DALInterface;
    using SDN.Products.BLInterface;
    using UI.Entities.Product;

    public  class CountAndAdjustStockBL: ICountAndAdjustStockBL
    {
        public int SaveCountAndAdjustStock(CountAndAdjustStockForm casForm)
        {
            ICountAndAdjustStockDAL casDL = new CountAndAdjustStockDAL();
            return casDL.SaveCountAndAdjustStock(casForm);
        }
        public int UpdateCountAndAdjustStock(CountAndAdjustStockForm casForm)
        {
            ICountAndAdjustStockDAL casDL = new CountAndAdjustStockDAL();
            return casDL.UpdateCountAndAdjustStock(casForm);
        }
        public CountAndAdjustStockForm GetCountAndAdjustStock(string stockCountNo)
        {
            ICountAndAdjustStockDAL casDL = new CountAndAdjustStockDAL();
            return casDL.GetCountAndAdjustStock(stockCountNo) ;
        }

        public string GetLatestStockCountNo()
        {
            ICountAndAdjustStockDAL casDL = new CountAndAdjustStockDAL();
            return casDL.GetLatestStockCountNo();
        }


    }
}
