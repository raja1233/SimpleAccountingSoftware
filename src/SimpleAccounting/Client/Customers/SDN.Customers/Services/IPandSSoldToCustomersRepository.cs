using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Customers.Services
{
    public interface IPandSSoldToCustomersRepository
    {
        //List<PandSSoldToCustomersEntity> GetPandSSoldToCustomersList();
        //List<PandSSoldToCustomersEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<PandSSoldToCustomersEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax,bool? IsSummary);
        List<PandSSoldToCustomersEntity> GetAllSalesInvoice();
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
        string getTotalCount(int ScreenId);
    }
}
