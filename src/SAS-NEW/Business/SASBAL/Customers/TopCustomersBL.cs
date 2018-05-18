using SASDAL.Customers;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Customers
{
    public class TopCustomersBL : ITopCustomersBL
    {
        public List<TopCustomersEntity> GetPandSList(string JsonData)
        {
            ITopCustomersDAL pandsdal = new TopCustomersDAL();
            return pandsdal.GetPandSList(JsonData);
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ITopCustomersDAL purQuotation = new TopCustomersDAL();
            var result = purQuotation.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ITopCustomersDAL purQuotation = new TopCustomersDAL();
            var result = purQuotation.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ITopCustomersDAL purQuotation = new TopCustomersDAL();
            var result = purQuotation.GetDateFormat();
            return result;
        }
    }
}
