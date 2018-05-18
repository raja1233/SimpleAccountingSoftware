using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities;

namespace SDN.Purchasings.DALInterface
{
    public interface IPaymentsToSuppliersListDAL
    {
        List<PaymentsToSuppliersListEntity> GetAllPurInvoice();
        List<PaymentsToSuppliersListEntity> GetAllPurInvoiceJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
    }
}
