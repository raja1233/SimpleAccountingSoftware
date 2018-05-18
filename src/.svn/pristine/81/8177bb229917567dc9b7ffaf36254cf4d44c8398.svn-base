using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Customers.DALInterface
{
    public interface IPandSSoldToCustomersDAL
    {
        //List<PandSSoldToCustomersEntity> GetPandSSoldToCustomersList();
        //List<PandSSoldToCustomersEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<PandSSoldToCustomersEntity> GetAllSalesInvoice();
        List<PandSSoldToCustomersEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax,bool? IsSummary);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
    }
}
