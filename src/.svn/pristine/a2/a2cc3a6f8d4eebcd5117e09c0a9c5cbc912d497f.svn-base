using SDN.UI.Entities.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Purchasing
{
    public interface ISuppliersDetailsListBL
    {
        List<SuppliersDetailsListEntity> GetSuppliersList(string json);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        List<SuppliersDetailsListEntity> GetStatusCount(int ScreenID);
    }
}
