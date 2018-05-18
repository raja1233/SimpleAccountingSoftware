
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BL
{
    using DAL;
    using DALInterface;
    using SDN.Purchasings.BLInterface;
    using UI.Entities;

    public class TopSuppliersBL: ITopSuppliersBL
    {
        public List<TopSuppliersEntity> GetPandSList(string JsonData)
        {
            ITopSuppliersDAL pandsdal = new TopSuppliersDAL();
            return pandsdal.GetPandSList(JsonData);
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ITopSuppliersDAL purQuotation = new TopSuppliersDAL();
            var result = purQuotation.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ITopSuppliersDAL purQuotation = new TopSuppliersDAL();
            var result = purQuotation.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ITopSuppliersDAL purQuotation = new TopSuppliersDAL();
            var result = purQuotation.GetDateFormat();
            return result;
        }
    }
}
