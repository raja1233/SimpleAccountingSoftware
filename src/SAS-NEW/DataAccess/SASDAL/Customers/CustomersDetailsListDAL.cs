﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Customers
{
    using Newtonsoft.Json;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Customers;
    using System.Data.SqlClient;

    public class CustomersDetailsListDAL: ICustomersDetailsListDAL
    {
       public List<CustomersDetailsListEntity> GetCustomersList(string json)
        {
            string ignored = string.Empty;
           
            List<CustomersDetailsListEntity> lstCustomers = new List<CustomersDetailsListEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    if(json==null)
                    {
                        ignored = JsonConvert.SerializeObject(json,
                               Formatting.Indented,
                               new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                        lstCustomers = entities.Database.SqlQuery<CustomersDetailsListEntity>("USP_GetCustomersDetailList @ShowAll,@ActiveInActiveBoth",
                      new SqlParameter("ShowAll", Convert.ToBoolean(0)),
                       new SqlParameter("ActiveInActiveBoth", Convert.ToInt32(0))
                      ).ToList();
                    }
                    else
                    {
                      
                        var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(json);
                        lstCustomers = entities.Database.SqlQuery<CustomersDetailsListEntity>("USP_GetCustomersDetailList @ShowAll,@ActiveInActiveBoth",
                        new SqlParameter("ShowAll", Convert.ToBoolean(objResponse1[0].FieldValue)),
                         new SqlParameter("ActiveInActiveBoth", Convert.ToInt32(objResponse1[1].FieldValue))
                        ).ToList();
                    }
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return lstCustomers;
        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
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
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                    if (result != null)
                        return result.Last_Selection;
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CustomersDetailsListEntity> GetCustomerStatusCount(int ScreenID)
        {
            List<CustomersDetailsListEntity> list = new List<CustomersDetailsListEntity>();
            try
            {
                using (SASEntitiesEDM entity = new SASEntitiesEDM())
                {
                    list = entity.Database.SqlQuery<CustomersDetailsListEntity>("USP_GetAllStatusCountByScreenIDOne @ScreenID",
                        new SqlParameter("ScreenID", ScreenID)).ToList();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            return list;
        }
    }
}
