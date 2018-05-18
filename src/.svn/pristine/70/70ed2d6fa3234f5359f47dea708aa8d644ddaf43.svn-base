using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDN.Purchasings.BLInterface
{
    using SDN.UI.Entities;

    public interface IPaymentsToSuppliersListBL
    {
        List<PaymentsToSuppliersListEntity> GetAllPurInvoice();
        List<PaymentsToSuppliersListEntity> GetAllPurInvoiceJson(string jsondata);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
