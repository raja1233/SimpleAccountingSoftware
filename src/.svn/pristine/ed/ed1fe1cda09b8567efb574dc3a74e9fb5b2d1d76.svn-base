using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using SASBAL.Accounts;

namespace SASClient.Accounts.Services
{
    public class GstAndVatReportsRepository : IGstAndVatReportsRepository
    {
        public List<GstAndVatSummaryEntity> getGstAndVAtCollectedDetails(string JSonData)
        {
            IGstAndVatReportsBL obj = new GstAndVatReportsBL();
            return obj.getGstAndVAtCollectedDetails(JSonData);
        }

        public List<GstAndVatSummaryEntity> getGstAndVAtPaidDetails(string JSonData)
        {
            IGstAndVatReportsBL obj = new GstAndVatReportsBL();
            return obj.getGstAndVAtPaidDetails(JSonData);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IGstAndVatReportsBL pandsSoldBL = new GstAndVatReportsBL();
            var result = pandsSoldBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public List<GstAndVatSummaryEntity> getGstAndVAtSummaryDetails(string JSonData)
        {
            IGstAndVatReportsBL obj = new GstAndVatReportsBL();
            return obj.getGstAndVAtSummaryDetails(JSonData);
        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IGstAndVatReportsBL obj = new GstAndVatReportsBL();
            return obj.SaveSearchJson(jsonSearch,ScreenId,ScreenName);
        }
    }
}
