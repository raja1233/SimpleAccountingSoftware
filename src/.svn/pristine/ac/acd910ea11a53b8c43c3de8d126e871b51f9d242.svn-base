
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using SDN.UI.Entities;
    using UI.Entities.Sales;

    public interface IPaymentFromCustomersListRepository
    {
        List<PaymentFromCustomersListEntity> GetAllPurInvoiceJson(string jsondata);
        List<PaymentFromCustomersListEntity> GetAllPurInvoice();
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
