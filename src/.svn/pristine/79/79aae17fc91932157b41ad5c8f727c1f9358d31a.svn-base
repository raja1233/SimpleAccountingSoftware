using SDN.UI.Entities.CashandBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.CashBank
{
    public interface IPayMoneyListDAL
    {
        //List<PayMoneyListEntity> GetPayMoneyList();
        //List<PayMoneyListEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<PayMoneyListEntity> GetAllSalesInvoice();
        List<PayMoneyListEntity> GetAllSalesInvoiceJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
    }
}
