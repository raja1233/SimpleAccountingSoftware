
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BLInterface
{
    using SDN.UI.Entities.Sales;
    using UI.Entities;

    public interface IRefundToCustomersListBL
    {
        List<RefundToCustomersListEntity> GetAllPurInvoice();
        List<RefundToCustomersListEntity> GetAllPurInvoiceJson(string jsondata);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
