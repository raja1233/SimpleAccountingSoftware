
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Customers.BLInterface
{
    using SDN.UI.Entities;
    public interface ITopCustomersBL
    {
        List<TopCustomersEntity> GetPandSList(string jsonData);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
    }
}
