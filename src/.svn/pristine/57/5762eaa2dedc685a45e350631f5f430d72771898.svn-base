using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DALInterface
{
    public interface ICreditNoteListDAL
    {
        List<CreditNoteListEntity> GetAllSalesCredit();  
        List<CreditNoteListEntity> GetAllSalesCreditJson(string jsondata, bool? ExcincTax);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
    }
}
