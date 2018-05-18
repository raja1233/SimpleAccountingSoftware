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
    public interface IPandSStockQuantitiesListRepository
    {
        List<PandSStockQuantitiesListEntity> GetPandSList();
        OptionsEntity GetOptionDetails();
        List<ProductandServiceStockQuantitiesListEntity> GetExportDataList(string FileName);
        IEnumerable<TaxModel> GetTaxes();
    }
}
