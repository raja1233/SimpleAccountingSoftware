﻿using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Accounts
{
    public  interface IGstAndVatReportsDAL
    {
        List<GstAndVatSummaryEntity> getGstAndVAtPaidDetails(string JSonData);
        List<GstAndVatSummaryEntity> getGstAndVAtCollectedDetails(string JSonData);
        List<GstAndVatSummaryEntity> getGstAndVAtSummaryDetails(string JSonData);
        string GetLastSelectionData(int ScreenId);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

    }
}
