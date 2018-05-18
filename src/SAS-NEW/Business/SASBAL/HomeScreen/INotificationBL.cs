﻿using SDN.UI.Entities;
using SDN.UI.Entities.HomeScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.HomeScreen
{
    public interface INotificationListBL
    {
        List<NotificationListEntity> GetAllNotification();
        List<NotificationListEntity> GetAllNotificationJson(string jsondata);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}