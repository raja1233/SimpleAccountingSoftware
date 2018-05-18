﻿using SDN.UI.Entities;
using SDN.UI.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.Services
{
    public interface ISupplierCreditPaidDaysRepository
    {
        List<SupplierCreditPaidDaysEntity> GetAllSalesInvoiceJson(string jsondata);
       
        List<YearEntity> GetYearRange();
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        TaxModel GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}