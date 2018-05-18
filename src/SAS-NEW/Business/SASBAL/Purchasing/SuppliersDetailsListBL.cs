
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Purchasing
{
    using SASDAL.Purchasing;
    using SDN.UI.Entities.Purchase;
    public class SuppliersDetailsListBL: ISuppliersDetailsListBL
    {
        public List<SuppliersDetailsListEntity> GetSuppliersList(string json)
        {
            ISuppliersDetailsListDAL cdDAL = new SuppliersDetailsListDAL();
            return cdDAL.GetSuppliersList(json);
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ISuppliersDetailsListDAL cdDAL = new SuppliersDetailsListDAL();
            return cdDAL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ISuppliersDetailsListDAL cdDAL = new SuppliersDetailsListDAL();
            return cdDAL.GetLastSelectionData(ScreenId);
        }

        public List<SuppliersDetailsListEntity> GetStatusCount(int ScreenID)
        {
            ISuppliersDetailsListDAL obj = new SuppliersDetailsListDAL();
            return obj.GetStatusCount(ScreenID);
        }
    }
}
