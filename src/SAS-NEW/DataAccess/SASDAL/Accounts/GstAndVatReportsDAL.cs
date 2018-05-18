using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using System.Data.SqlClient;
using Newtonsoft.Json;
using SDN.UI.Entities;

namespace SASDAL.Accounts
{
    public class GstAndVatReportsDAL : IGstAndVatReportsDAL
    {
        SASEntitiesEDM entity  = new SASEntitiesEDM();

        public List<GstAndVatSummaryEntity> getGstAndVAtCollectedDetails(string JSonData)
        {
            List<GstAndVatSummaryEntity> list = new List<GstAndVatSummaryEntity>();

            try
            {
                if(JSonData==null)
                {
                    list = entity.Database.SqlQuery<GstAndVatSummaryEntity>("USP_TaxCollected @year,@Quarter,@Month,@ShowAll",
                         new SqlParameter("year", Convert.ToInt32(0)),
                         new SqlParameter("Quarter", Convert.ToInt32(0)),
                         new SqlParameter("Month", Convert.ToInt32(0)),
                         new SqlParameter("ShowAll",Convert.ToBoolean(0))).ToList();
                }
                else
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JSonData);
                    list = entity.Database.SqlQuery<GstAndVatSummaryEntity>("USP_TaxCollected @year,@Quarter,@Month,@ShowAll",
                       new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                       new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                       new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                       new SqlParameter("ShowAll",Convert.ToBoolean(objResponse1[3].FieldValue))).ToList();
                }
                
            }
            catch (Exception e)
            {

                throw e;
            }
            return list;
        }

        public List<GstAndVatSummaryEntity> getGstAndVAtPaidDetails(string JSonData)
        {
            List<GstAndVatSummaryEntity> list = new List<GstAndVatSummaryEntity>();
            try
            {
                if(JSonData== null)
                {
                    list = entity.Database.SqlQuery<GstAndVatSummaryEntity>("USP_TaxPaid @year,@Quarter,@Month,@ShowAll",
                         new SqlParameter("year", Convert.ToInt32(0)),
                         new SqlParameter("Quarter", Convert.ToInt32(0)),
                         new SqlParameter("Month", Convert.ToInt32(0)),
                          new SqlParameter("ShowAll", Convert.ToBoolean(0))).ToList();
                }
                else
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JSonData);
                    list = entity.Database.SqlQuery<GstAndVatSummaryEntity>("USP_TaxPaid @year,@Quarter,@Month,@ShowAll",
                       new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                       new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                       new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                       new SqlParameter("ShowAll", Convert.ToBoolean(objResponse1[3].FieldValue))).ToList();
                }
                
            }
            catch (Exception e)
            {

                throw e;
            }
            return list;
        }

        public List<GstAndVatSummaryEntity> getGstAndVAtSummaryDetails(string JSonData)
        {
            List<GstAndVatSummaryEntity> list = new List<GstAndVatSummaryEntity>();
            try
            {
                if (JSonData==null)
                {
                         list = entity.Database.SqlQuery<GstAndVatSummaryEntity>("USP_TaxSummary @year,@Quarter,@Month,@ShowAll",
                         new SqlParameter("year", Convert.ToInt32(0)),
                         new SqlParameter("Quarter", Convert.ToInt32(0)),
                         new SqlParameter("Month", Convert.ToInt32(0)),
                          new SqlParameter("ShowAll", Convert.ToBoolean(0))).ToList();
                }
                else
                {
                       var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JSonData);
                       list = entity.Database.SqlQuery<GstAndVatSummaryEntity>("USP_TaxSummary @year,@Quarter,@Month,@ShowAll",
                       new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                       new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                       new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                       new SqlParameter("ShowAll", Convert.ToBoolean(objResponse1[3].FieldValue))).ToList();
                }
                
            }

            catch (Exception e)
            {

                throw e;
            }
            return list;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            try
            {
                DateTime dateTime = DateTime.UtcNow.Date;
                var quarter = (dateTime.Month + 2) / 3;

                var lastQuarter = quarter - 1;
                if (lastQuarter == 0)
                {
                    lastQuarter = 1;
                }
                var result = entity.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null)
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(result.Last_Selection);
                    objResponse1[0].FieldValue = DateTime.UtcNow.Year.ToString();
                    objResponse1[1].FieldValue = lastQuarter.ToString();
                    objResponse1[2].FieldValue = "0";
                    objResponse1[3].FieldValue = "False";
                    var finalresult = JsonConvert.SerializeObject(objResponse1);
                    return finalresult;
                }

                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            try
            {
                var result = entity.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null)
                {
                    result.Last_Selection = jsonSearch;
                    result.Last_Updated = DateTime.Now;
                    entity.SaveChanges();
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
                    entity.LastSelectionHistories.Add(lastSelection);
                    entity.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
