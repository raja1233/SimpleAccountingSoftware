using SDN.UI.Entities.HomeScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.HomeScreen
{
    public interface IAuditTrailListDAL
    {

        List<AuditTrailListEntity> GetAllAuditTrail();
        List<AuditTrailListEntity> GetAllAuditTrailJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
    }
}
