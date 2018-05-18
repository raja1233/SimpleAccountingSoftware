
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Product
{
    using SDN.UI.Entities.Product;
    public interface IPandSHistoryDAL
    {
        List<PandSHistoryEntity> GetAllSalesInvoice();
        List<PandSHistoryEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
    }
}
