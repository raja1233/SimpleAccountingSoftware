﻿using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Accounts
{
    public interface ILedgerDAL
    {
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        List<LedgerEntity> LedgerList(string jsondata);
    }
}