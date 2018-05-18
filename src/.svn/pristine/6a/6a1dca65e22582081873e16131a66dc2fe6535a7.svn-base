using Newtonsoft.Json;
using SDN.UI.Entities;
using SDN.UI.Entities.HomeScreen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.HomeScreen
{
    public class AuditTrailListDAL : IAuditTrailListDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<AuditTrailListEntity> GetAllAuditTrail()
        {
            List<AuditTrailListEntity> InvoiceList = new List<AuditTrailListEntity>();
            //List<AuditTrailListEntity> InvoiceList = entities.Database.SqlQuery<AuditTrailListEntity>("PRC_AuditTrailList").ToList();
            return InvoiceList;
        }

        public List<AuditTrailListEntity> GetAllAuditTrailJson(string JsonData)
        {
             List<AuditTrailListEntity> InvoiceList = new List<AuditTrailListEntity>();
            AuditTrailListEntity InvoiceList1 = new AuditTrailListEntity();
            List<AuditTrailListEntity> InvoiceListReturn = new List<AuditTrailListEntity>();
            if (JsonData != null)
            {
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                InvoiceList = entities.Database.SqlQuery<AuditTrailListEntity>("USP_AuditTrail @year,@Quarter,@Month,@ShowAll,@SDate,@EDate,@ScreenName",
                    new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                      new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                        new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                         new SqlParameter("ShowAll", Convert.ToBoolean(objResponse1[5].FieldValue)),
                          new SqlParameter("SDate", objResponse1[3].FieldValue),
                            new SqlParameter("EDate", objResponse1[4].FieldValue),
                            new SqlParameter("ScreenName", objResponse1[6].FieldValue)
                       ).ToList();
            }
            else
            {
                InvoiceList = entities.Database.SqlQuery<AuditTrailListEntity>("USP_AuditTrail @year,@Quarter,@Month,@ShowAll,@SDate,@EDate,@ScreenName",
                   new SqlParameter("Year", Convert.ToInt32(0)),
                     new SqlParameter("Quarter", Convert.ToInt32(0)),
                       new SqlParameter("Month", Convert.ToInt32(0)),
                        new SqlParameter("ShowAll", Convert.ToBoolean(1)),
                         new SqlParameter("SDate", "0"),
                           new SqlParameter("EDate", "0"),
                           new SqlParameter("ScreenName", "Customers Details")
                      ).ToList();
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
