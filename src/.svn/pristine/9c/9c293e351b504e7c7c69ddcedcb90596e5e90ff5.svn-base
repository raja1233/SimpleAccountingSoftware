using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DALInterface
{
   public interface IPurchaseQuotationListDAL
    {
        List<PurchaseQuotationListEntity> GetAllPurQuotation();
        List<PurchaseQuotationListEntity> GetAllPurQuotationJson(string jsondata, bool? ExcincTax);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
    }
}
