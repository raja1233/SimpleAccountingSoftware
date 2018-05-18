using SDN.UI.Entities.CashandBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.CashBank
{
    public interface ITransferMoneyListDAL
    {
        //List<TransferMoneyListEntity> GetTransferMoneyList();
        //List<TransferMoneyListEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<TransferMoneyListEntity> GetAllSalesInvoice();
        List<TransferMoneyListEntity> GetAllSalesInvoiceJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
    }
}
