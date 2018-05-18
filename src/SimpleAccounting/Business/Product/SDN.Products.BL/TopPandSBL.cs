
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BL
{
    using DAL;
    using DALInterface;
    using SDN.Products.BLInterface;
    using UI.Entities.ProductandServices;

    public class TopPandSBL: ITopPandSBL
    {
        public List<TopPandSEntity> GetPandSList(string JsonData)
        {
            ITopPandSDAL pandsdal = new TopPandSDAL();
            return pandsdal.GetPandSList(JsonData);
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ITopPandSDAL purQuotation = new TopPandSDAL();
            var result = purQuotation.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ITopPandSDAL purQuotation = new TopPandSDAL();
            var result = purQuotation.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ITopPandSDAL purQuotation = new TopPandSDAL();
            var result = purQuotation.GetDateFormat();
            return result;
        }
    }
}
