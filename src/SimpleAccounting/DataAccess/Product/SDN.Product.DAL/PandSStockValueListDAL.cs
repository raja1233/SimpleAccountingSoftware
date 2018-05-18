using SDN.ProductEDM;
using SDN.Products.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DAL
{
    public class PandSStockValueListDAL : IPandSStockValueListDAL
    {
        SDNProductDBEntities entities = new SDNProductDBEntities();

        public List<PandSStockValueListEntity> GetPandSList()
        {

            List<PandSStockValueListEntity> pandslist = entities.Database.SqlQuery<PandSStockValueListEntity>("PRC_PandSStockValueList").ToList();
            return pandslist;
        }
    }
}
