using SDN.UI.Entities.HomeScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.HomeScreen
{
    public interface INotificationListDAL
    {

        List<NotificationListEntity> GetAllNotification();
        List<NotificationListEntity> GetAllNotificationJson(string jsondata);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
    }
}
