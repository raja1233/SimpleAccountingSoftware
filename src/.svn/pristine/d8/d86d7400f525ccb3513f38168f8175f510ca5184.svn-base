using SDN.UI.Entities;
using SDN.UI.Entities.CashandBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.CashBank
{
    public interface ITransferMoneyListBL
    {
        //List<TransferMoneyListEntity> GetTransferMoneyList();
        //List<TransferMoneyListEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<TransferMoneyListEntity> GetAllSalesInvoice();
        List<TransferMoneyListEntity> GetAllSalesInvoiceJson(string jsondata);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
