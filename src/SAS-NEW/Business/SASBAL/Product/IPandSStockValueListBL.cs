﻿using SDN.UI.Entities.Export;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BLInterface
{
    public interface IPandSStockValueListBL
    {
        List<PandSStockValueListEntity> GetPandSList();
        List<ProductandServiceStockValueListEntity> GetExportDataList(string FileName);
    }
}
