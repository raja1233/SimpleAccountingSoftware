using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DALInterface
{
    public interface IPandSCostPriceListDAL
    {
        List<PandSCostPriceListEntity> GetPandSList();
    }
}
