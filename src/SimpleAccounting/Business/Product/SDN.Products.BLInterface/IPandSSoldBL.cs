﻿using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BLInterface
{
    public interface IPandSSoldBL
    {
        //List<PandSSoldEntity> GetPandSSoldList();
        //List<PandSSoldEntity> SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);

        List<PandSSoldEntity> GetAllSalesInvoice();
        List<PandSSoldEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax, bool? IsSummary);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string getTotalCount(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
