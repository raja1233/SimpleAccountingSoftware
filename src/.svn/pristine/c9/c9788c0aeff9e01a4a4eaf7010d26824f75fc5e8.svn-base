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
    public class AuditTrailListRepository : IAuditTrailListRepository
    {
        public List<AuditTrailListEntity> GetAllAuditTrailJson(string jsondata)
        {
            IAuditTrailListBL purInvoice = new AuditTrailListBL();
            List<AuditTrailListEntity> quotationlist = purInvoice.GetAllAuditTrailJson(jsondata);
            return quotationlist;
        }
        public List<AuditTrailListEntity> GetAllAuditTrail()
        {
            IAuditTrailListBL purInvoice = new AuditTrailListBL();
            List<AuditTrailListEntity> Invoicelist = purInvoice.GetAllAuditTrail();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            IAuditTrailListBL purInvoice = new AuditTrailListBL();
            List<YearEntity> yearrange = purInvoice.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IAuditTrailListBL purInvoice = new AuditTrailListBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IAuditTrailListBL purInvoice = new AuditTrailListBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IAuditTrailListBL purInvoice = new AuditTrailListBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IAuditTrailListBL purInvoice = new AuditTrailListBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IAuditTrailListBL purInvoice = new AuditTrailListBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
