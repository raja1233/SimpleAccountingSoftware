using SDN.UI.Entities;
using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.Services
{
    public interface ISuppliersDetailsListRepository
    {
        List<SuppliersDetailsListEntity> GetSuppliersList(string json);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        OptionsEntity GetOptionSettings();
        TaxModel GetDefaultTaxes();
        List<SuppliersDetailsListEntity> GetStatusCount(int ScreenID);
    }
}
