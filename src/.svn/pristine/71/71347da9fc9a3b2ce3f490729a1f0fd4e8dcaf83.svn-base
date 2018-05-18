using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DALInterface
{
    using SDN.UI.Entities.Sales;
    public interface ISalesInvoiceListDAL
    {  
        
        List<SalesInvoiceListEntity> GetAllSalesInvoice();
        List<SalesInvoiceListEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
    }
}
