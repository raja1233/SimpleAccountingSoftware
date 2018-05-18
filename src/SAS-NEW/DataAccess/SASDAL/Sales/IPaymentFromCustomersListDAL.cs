
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DALInterface
{
    using SDN.UI.Entities.Sales;
    public interface IPaymentFromCustomersListDAL
    {
        List<PaymentFromCustomersListEntity> GetAllPurInvoice();
        List<PaymentFromCustomersListEntity> GetAllPurInvoiceJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
    }
}
