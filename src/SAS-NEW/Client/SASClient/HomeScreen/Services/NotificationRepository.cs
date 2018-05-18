using SASBAL.HomeScreen;
using SDN.UI.Entities;
using SDN.UI.Entities.HomeScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.HomeScreen.Services
{
    public class NotificationListRepository : INotificationListRepository
    {
        public List<NotificationListEntity> GetAllNotificationJson(string jsondata)
        {
            INotificationListBL purInvoice = new NotificationListBL();
            List<NotificationListEntity> quotationlist = purInvoice.GetAllNotificationJson(jsondata);
            return quotationlist;
        }
        public List<NotificationListEntity> GetAllNotification()
        {
            INotificationListBL purInvoice = new NotificationListBL();
            List<NotificationListEntity> Invoicelist = purInvoice.GetAllNotification();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            INotificationListBL purInvoice = new NotificationListBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            INotificationListBL purInvoice = new NotificationListBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            INotificationListBL purInvoice = new NotificationListBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            INotificationListBL purInvoice = new NotificationListBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            INotificationListBL purInvoice = new NotificationListBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            INotificationListBL purInvoice = new NotificationListBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
