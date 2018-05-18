using SDN.UI.Entities;
using SDN.UI.Entities.CashandBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.CashBank.Services
{
    public interface IReceiveMoneyListRepository
    {
        //List<ReceiveMoneyListEntity> GetReceiveMoneyList();
        //List<ReceiveMoneyListEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<ReceiveMoneyListEntity> GetAllSalesInvoiceJson(string jsondata);
        List<ReceiveMoneyListEntity> GetAllSalesInvoice();
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
