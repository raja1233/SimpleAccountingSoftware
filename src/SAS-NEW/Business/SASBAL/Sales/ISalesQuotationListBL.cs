﻿using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BLInterface
{
    public interface ISalesQuotationListBL
    {
        List<SalesQuotationListEntity> GetAllSalesQuotation();
        List<SalesQuotationListEntity> GetAllSalesQuotationJson(string jsondata, bool? ExcincTax);
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData();
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}