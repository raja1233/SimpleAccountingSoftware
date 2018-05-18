using SDN.Products.BLInterface;
using SDN.Products.DAL;
using SDN.Products.DALInterface;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BL
{
    public class PandSStockValueListBL : IPandSStockValueListBL
    {
        public List<PandSStockValueListEntity> GetPandSList()
        {
            IPandSStockValueListDAL pandsdal = new PandSStockValueListDAL();
            return pandsdal.GetPandSList();
        }      
    }
}
