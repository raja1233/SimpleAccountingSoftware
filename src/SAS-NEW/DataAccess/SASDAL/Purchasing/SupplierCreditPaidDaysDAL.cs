﻿using Newtonsoft.Json;
using SDN.UI.Entities;
using SDN.UI.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Purchasing
{
    public class SupplierCreditPaidDaysDAL : ISupplierCreditPaidDaysDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        

        public List<SupplierCreditPaidDaysEntity> GetAllSalesInvoiceJson(string JsonData)
        {
            List<SupplierCreditPaidDaysEntity> InvoiceList = new List<SupplierCreditPaidDaysEntity>();
            SupplierCreditPaidDaysEntity InvoiceList1 = new SupplierCreditPaidDaysEntity();
            List<SupplierCreditPaidDaysEntity> InvoiceListReturn = new List<SupplierCreditPaidDaysEntity>();
            if (JsonData != null)
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                InvoiceList = entities.Database.SqlQuery<SupplierCreditPaidDaysEntity>("USP_SupplierStatementCreditDaysPaidDays @year,@Quarter,@Month",
                    new SqlParameter("year", Convert.ToInt32(objResponse1[0].FieldValue)),
                      new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                        new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue))).ToList();
            }
            else
            {
                InvoiceList = entities.Database.SqlQuery<SupplierCreditPaidDaysEntity>("USP_SupplierStatementCreditDaysPaidDays @year,@Quarter,@Month",
                   new SqlParameter("year", Convert.ToInt32(0)),
                     new SqlParameter("Quarter", Convert.ToInt32(0)),
                       new SqlParameter("Month", Convert.ToInt32(0))).ToList();
            }
           


            return InvoiceList;
        }

        public string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Invoice";
            else if (ConvertedToPO == true)
                return "Invoice";
            else
                return "";
        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            try
            {
                var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null)
                {
                    result.Last_Selection = jsonSearch;
                    result.Last_Updated = DateTime.Now;
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    LastSelectionHistory lastSelection = new LastSelectionHistory()
                    {
                        Screen_Id = ScreenId,
                        Screen_Name = ScreenName,
                        Last_Selection = jsonSearch,
                        Last_Updated = DateTime.Now
                    };
                    entities.LastSelectionHistories.Add(lastSelection);
                    entities.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public string GetLastSelectionData(int ScreenId)
        {
            try
            {
                var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null)
                    return result.Last_Selection;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDateFormat()
        {
            try
            {
                var DateFormatResult = entities.Options.FirstOrDefault();
                string DateFormat = null;
                if (DateFormatResult != null)
                {
                    return DateFormat = DateFormatResult.Date_Format;
                }
                else
                {
                    return DateFormat = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
