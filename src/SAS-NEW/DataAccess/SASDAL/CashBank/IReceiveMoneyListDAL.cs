using SDN.UI.Entities.CashandBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.CashBank
{
    public interface IReceiveMoneyListDAL
    {
        //List<ReceiveMoneyListEntity> GetReceiveMoneyList();
        //List<ReceiveMoneyListEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<ReceiveMoneyListEntity> GetAllSalesInvoice();
        List<ReceiveMoneyListEntity> GetAllSalesInvoiceJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
    }
}
