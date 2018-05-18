
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    using SDN.UI.Entities.Purchase;
    using UI.Entities;

    public interface IRefundFromSuppliersListRepository
    {
        List<RefundFromSuppliersListEntity> GetAllPurInvoice();
        List<RefundFromSuppliersListEntity> GetAllPurInvoiceJson(string jsondata);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
