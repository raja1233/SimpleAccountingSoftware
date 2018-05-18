using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Customers.BLInterface
{
    public interface IPandSSoldToCustomersBL
    {
         
        List<PandSSoldToCustomersEntity> GetAllSalesInvoice();
        List<PandSSoldToCustomersEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax,bool? IsSummary);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
