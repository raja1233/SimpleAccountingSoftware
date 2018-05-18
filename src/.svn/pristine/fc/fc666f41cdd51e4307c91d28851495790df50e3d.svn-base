using Newtonsoft.Json;
using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Product
{
    public class StockCardListDAL : IStockCardListDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<StockCardListEntity> GetAllStockCard()
        {
            List<StockCardListEntity> InvoiceList = new List<StockCardListEntity>();
            InvoiceList = entities.Database.SqlQuery<StockCardListEntity>("SSP_StockInOutList").ToList();
            return InvoiceList;
        }

        //public List<StockCardListEntity> GetAllStockCardJson(string JsonData)
        //{
        //    List<StockCardListEntity> InvoiceList = new List<StockCardListEntity>();
        //    StockCardListEntity InvoiceList1 = new StockCardListEntity();
        //    List<StockCardListEntity> InvoiceListReturn = new List<StockCardListEntity>();
        //    if (JsonData != null)
        //    {
        //        var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
        //        InvoiceList = entities.Database.SqlQuery<StockCardListEntity>("USP_StockCard @year,@Quarter,@Month,@ScreenName",
        //            new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
        //              new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
        //                new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
        //                 new SqlParameter("ShowAll", Convert.ToBoolean(objResponse1[5].FieldValue)),
        //                  new SqlParameter("SDate", objResponse1[3].FieldValue),
        //                    new SqlParameter("EDate", objResponse1[4].FieldValue),
        //                    new SqlParameter("ScreenName", objResponse1[6].FieldValue)
        //               ).ToList();
        //    }
        //    else
        //    {
        //        //InvoiceList = entities.Database.SqlQuery<StockCardListEntity>("USP_StockCard @year,@Quarter,@Month,@ShowAll,@SDate,@EDate,@ScreenName",
        //        //   new SqlParameter("Year", Convert.ToInt32(0)),
        //        //     new SqlParameter("Quarter", Convert.ToInt32(0)),
        //        //       new SqlParameter("Month", Convert.ToInt32(0)),
        //        //        new SqlParameter("ShowAll", Convert.ToBoolean(1)),
        //        //         new SqlParameter("SDate", "0"),
        //        //           new SqlParameter("EDate", "0"),
        //        //           new SqlParameter("ScreenName", "Customers Details")
        //        //      ).ToList();
        //    }
        //    return InvoiceList;
        //}
        public List<StockCardListEntity> GetProductsDetails(string jsondata, bool? ExcincTax, string ProductCode)
        {
            List<StockCardListEntity> InvoiceList = new List<StockCardListEntity>();
            StockCardListEntity InvoiceList1 = new StockCardListEntity();
            List<StockCardListEntity> InvoiceListReturn = new List<StockCardListEntity>();
            try
            {
                if (ProductCode != null && jsondata == null)
                {
                    //var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);
                    InvoiceList = entities.Database.SqlQuery<StockCardListEntity>("USP_StockCard @year,@Quarter,@Month,@IncGST,@ProductCode",
                       new SqlParameter("Year", Convert.ToInt32(0)),
                         new SqlParameter("Quarter", Convert.ToInt32(0)),
                           new SqlParameter("Month", Convert.ToInt32(0)),
                              new SqlParameter("IncGST", ExcincTax),
                              new SqlParameter("ProductCode", ProductCode)
                          ).ToList();
                }
                else
                {
                    if(ProductCode==null && jsondata!=null)
                    {
                        var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);
                        InvoiceList = entities.Database.SqlQuery<StockCardListEntity>("USP_StockCard @year,@Quarter,@Month,@IncGST,@ProductCode",
                      new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                        new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                          new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                             new SqlParameter("IncGST", ExcincTax),
                             new SqlParameter("ProductCode", DBNull.Value)
                         ).ToList();
                    }
                    else
                    {
                        if(ProductCode==null && jsondata==null)
                        {
                            //var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);
                            InvoiceList = entities.Database.SqlQuery<StockCardListEntity>("USP_StockCard @year,@Quarter,@Month,@IncGST,@ProductCode",
                               new SqlParameter("Year", Convert.ToInt32(0)),
                                 new SqlParameter("Quarter", Convert.ToInt32(0)),
                                   new SqlParameter("Month", Convert.ToInt32(0)),
                                      new SqlParameter("IncGST", ExcincTax),
                                      new SqlParameter("ProductCode", String.IsNullOrEmpty(ProductCode) ? "" : ProductCode)
                                  ).ToList();
                        }
                        else
                        {
                            var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsondata);
                            InvoiceList = entities.Database.SqlQuery<StockCardListEntity>("USP_StockCard @year,@Quarter,@Month,@IncGST,@ProductCode",
                               new SqlParameter("Year", Convert.ToInt32(objResponse1[0].FieldValue)),
                                 new SqlParameter("Quarter", Convert.ToInt32(objResponse1[1].FieldValue)),
                                   new SqlParameter("Month", Convert.ToInt32(objResponse1[2].FieldValue)),
                                      new SqlParameter("IncGST", ExcincTax),
                                      new SqlParameter("ProductCode", ProductCode)
                                  ).ToList();
                        }
                        
                    }
                  
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return InvoiceList;
        }
            //else
            //{
            //    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(jsonData);
            //    InvoiceList = entities.Database.SqlQuery<StockCardListEntity>("USP_StockCard @year,@Quarter,@Month,@IncGST,@ProductCode",
            //       new SqlParameter("Year", Convert.ToInt32(0)),
            //         new SqlParameter("Quarter", Convert.ToInt32(0)),
            //           new SqlParameter("Month", Convert.ToInt32(0)),
            //              new SqlParameter("IncGST", Convert.ToBoolean(1)),
            //              new SqlParameter("ProductCode", Convert.ToString(ProductCode))
            //          ).ToList();
            //}
            
            
        
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

        //public string GetLastSelectionData(int ScreenId)
        //{
        //    try
        //    {
        //        var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
        //        if (result != null)
        //            return result.Last_Selection;
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
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
                var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null)
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(result.Last_Selection);
                    objResponse1[0].FieldValue = DateTime.UtcNow.Year.ToString();
                    objResponse1[1].FieldValue = lastQuarter.ToString();
                    objResponse1[2].FieldValue = "0";
                   
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

        public List<ContentModel> GetCategoryContent(string catType)
        {
            List<ContentModel> model = new List<ContentModel>();
            using (SASEntitiesEDM obj = new SASEntitiesEDM())
            {
                try
                {
                    model = (from content in obj.CategoriesContents
                             join cat in obj.Categories on content.Cat_Id equals cat.ID
                             where cat.Cat_Code == catType && content.IsDeleted == false
                             select new ContentModel
                             {
                                 CategoryID=cat.ID,
                                 ContentID=content.ID,
                                 ContentName=content.Cat_Contents,
                                 IsSelected=content.Set_Default,
                             }).ToList();
                    return model;
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
           
        }
       
    }
}
