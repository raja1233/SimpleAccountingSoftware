
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DAL
{
    using Newtonsoft.Json;
    using SASDAL;
    using SDN.Products.DALInterface;
    using System.Globalization;
    using UI.Entities;
    using UI.Entities.Product;

    public class CountAndAdjustStockListDAL: CountAndAdjustStockListEntity,ICountAndAdjustStockListDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<CountAndAdjustStockListEntity> GetAllStockCount()
        {
            List<CountAndAdjustStockListEntity> scList = new List<CountAndAdjustStockListEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    scList = entities.StockCounts.Select(e =>
                    new CountAndAdjustStockListEntity
                    {
                        CountAndAdjustStockNo=e.Stock_count_no,
                        CountAndAdjustStockDateDatetime=e.StockDate,
                        AdjustedAmountd = e.Amount,
                        CreatedDate=e.UpdatedDate
                    }).ToList<CountAndAdjustStockListEntity>();
  
                }
                scList= scList.OrderBy(e => e.CreatedDate).GroupBy(e => e.CountAndAdjustStockNo).Select(e => e.First()).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return scList;
        }

        public List<CountAndAdjustStockListEntity> GetAllStockCountJson(string JsonData)
        {
            List<CountAndAdjustStockListEntity> scList = new List<CountAndAdjustStockListEntity>();
            List<CountAndAdjustStockListEntity> quotationListReturn = new List<CountAndAdjustStockListEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    scList = entities.StockCounts.Select(e =>
                    new CountAndAdjustStockListEntity
                    {
                        CountAndAdjustStockNo = e.Stock_count_no,
                        CountAndAdjustStockDateDatetime = e.StockDate,
                        AdjustedAmountd = e.Amount,
                        CreatedDate = e.UpdatedDate
                    }).ToList<CountAndAdjustStockListEntity>();

                }
                scList = scList.OrderBy(e => e.CreatedDate).GroupBy(e => e.CountAndAdjustStockNo).Select(e => e.First()).ToList();
                if (JsonData != null && JsonData != "[]")
                {
                    DateTime startDate = new DateTime();
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                    foreach (var item in objResponse1)
                    {
                        switch (item.FieldName)
                        {
                            case "Year":
                                var year = Convert.ToInt32(item.FieldValue);
                                scList = scList.Where(x => x.CountAndAdjustStockDateDatetime.Value.Year == year).ToList();
                                break;
                            case "Quarter":
                                switch (item.FieldValue)
                                {
                                    case "1":
                                        scList = scList.Where(x => x.CountAndAdjustStockDateDatetime.Value.Month == 1 || x.CountAndAdjustStockDateDatetime.Value.Month == 2 || x.CountAndAdjustStockDateDatetime.Value.Month == 3).ToList();
                                        break;
                                    case "2":
                                        scList = scList.Where(x => x.CountAndAdjustStockDateDatetime.Value.Month == 4 || x.CountAndAdjustStockDateDatetime.Value.Month == 5 || x.CountAndAdjustStockDateDatetime.Value.Month == 6).ToList();
                                        break;
                                    case "3":
                                        scList = scList.Where(x => x.CountAndAdjustStockDateDatetime.Value.Month == 7 || x.CountAndAdjustStockDateDatetime.Value.Month == 8 || x.CountAndAdjustStockDateDatetime.Value.Month == 9).ToList();
                                        break;
                                    case "4":
                                        scList = scList.Where(x => x.CountAndAdjustStockDateDatetime.Value.Month == 10 || x.CountAndAdjustStockDateDatetime.Value.Month == 11 || x.CountAndAdjustStockDateDatetime.Value.Month == 12).ToList();
                                        break;
                                }
                                break;
                            case "Month":
                                var month = Convert.ToInt32(item.FieldValue);
                                scList = scList.Where(x => x.CountAndAdjustStockDateDatetime.Value.Month == month).ToList();
                                break;
                            //case "StartDate":
                            //    //startDate = Convert.ToDateTime(item.FieldValue);
                            //    startDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);
                            //    //quotationList = quotationList.Where(x => x.QuotationDateDateTime ).ToList();
                            //    break;
                            //case "EndDate":
                            //    //DateTime endDate = Convert.ToDateTime(item.FieldValue);
                            //    DateTime endDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);

                            //    scList = scList.Where(x => x.CountAndAdjustStockDateDatetime > startDate && x.CountAndAdjustStockDateDatetime < endDate).ToList();
                            //    break;
                        }
                    }
                    quotationListReturn = scList;
                }
                else
                {
                    quotationListReturn = scList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return quotationListReturn;
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

        public string GetLastSelectionData() 
        {
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    DateTime dateTime = DateTime.UtcNow.Date;
                    var quarter = (dateTime.Month + 2) / 3;

                    var lastQuarter = quarter - 1;
                    if (lastQuarter == 0)
                    {
                        lastQuarter = 1;
                    }
                    var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == 26).FirstOrDefault();
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public string GetLastSelectionData(int ScreenId)
        //{
        //    try
        //    {
        //        DateTime dateTime = DateTime.UtcNow.Date;
        //        var quarter = (dateTime.Month + 2) / 3;

        //        var lastQuarter = quarter - 1;
        //        if (lastQuarter == 0)
        //        {
        //            lastQuarter = 1;
        //        }
        //        var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
        //        if (result != null)
        //        {
        //            var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(result.Last_Selection);
        //            objResponse1[0].FieldValue = DateTime.UtcNow.Year.ToString();
        //            objResponse1[1].FieldValue = lastQuarter.ToString();
        //            objResponse1[2].FieldValue = "0";
        //            objResponse1[4].FieldValue = "False";
        //            var finalresult = JsonConvert.SerializeObject(objResponse1);
        //            return finalresult;
        //        }

        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public string GetDateFormat()
        {
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
