using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using SASDAL.Accounts;

namespace SASBAL.Accounts
{
    public class GstAndVatReportsBL : IGstAndVatReportsBL
    {
        public List<GstAndVatSummaryEntity> getGstAndVAtCollectedDetails(string JSonData)
        {
            IGstAndVatReportsDAL obj = new GstAndVatReportsDAL();
            return obj.getGstAndVAtCollectedDetails(JSonData);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IGstAndVatReportsDAL obj = new GstAndVatReportsDAL();
            var result = obj.GetLastSelectionData(ScreenId);
            return result;
        }
        public List<GstAndVatSummaryEntity> getGstAndVAtPaidDetails(string JSonData)
        {
            IGstAndVatReportsDAL obj = new GstAndVatReportsDAL();
            return obj.getGstAndVAtPaidDetails(JSonData);
        }

        public List<GstAndVatSummaryEntity> getGstAndVAtSummaryDetails(string JSonData)
        {
            IGstAndVatReportsDAL obj = new GstAndVatReportsDAL();
            return obj.getGstAndVAtSummaryDetails(JSonData);
        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IGstAndVatReportsDAL obj = new GstAndVatReportsDAL();
            return obj.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
    }
}
