using SASDAL;
using SDN.Products.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Export;
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
        SASEntitiesEDM entities = new SASEntitiesEDM();

        public List<PandSStockValueListEntity> GetPandSList()
        {

            List<PandSStockValueListEntity> pandslist = entities.Database.SqlQuery<PandSStockValueListEntity>("PRC_PandSStockValueList").ToList();
            return pandslist;
        }
        public List<ProductandServiceStockValueListEntity> GetExportDataList(string FileName)
        {
            List<ProductandServiceStockValueListEntity> exportdata = new List<ProductandServiceStockValueListEntity>();
            try
            {
                exportdata = entities.Database.SqlQuery<ProductandServiceStockValueListEntity>("PRC_PandSStockValueList").ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return exportdata;
        }

    }
}
