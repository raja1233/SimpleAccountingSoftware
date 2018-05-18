using SDN.UI.Entities;
using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BLInterface
{
   public interface IRefundFromSuppliersListBL
    {
        List<RefundFromSuppliersListEntity> GetAllPurInvoice();
        List<RefundFromSuppliersListEntity> GetAllPurInvoiceJson(string jsondata);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
