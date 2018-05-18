using SDN.Products.BL;
using SDN.Products.BLInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{
    public class PandSDescriptionListRepository : IPandSDescriptionListRepository
    {
        public List<PandSDescriptionListEntity> GetPandSList()
        {
            IPandSDescriptionListBL pandsBL = new PandSDescriptionListBL();
            return pandsBL.GetPandSList();
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
