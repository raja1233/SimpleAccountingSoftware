using Newtonsoft.Json;
using SDN.Sales.DALInterface;
using SDN.Sales.EDM;
using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DAL
{
    public class CreditNoteListDAL: ICreditNoteListDAL
    {
        SDNSalesDBEntities entities = new SDNSalesDBEntities();
        public List<CreditNoteListEntity> GetAllSalesCredit() 
        {
            List<CreditNoteListEntity> CreditList = entities.Database.SqlQuery<CreditNoteListEntity>("PRC_CreditNoteList").ToList();

            return CreditList;
        }

        public List<CreditNoteListEntity> GetAllSalesCreditJson(string JsonData, bool? ExcincTax)
        {
            List<CreditNoteListEntity> CreditList = new List<CreditNoteListEntity>();
            CreditNoteListEntity CreditList1 = new CreditNoteListEntity();
            List<CreditNoteListEntity> CreditListReturn = new List<CreditNoteListEntity>();
           
            CreditList = entities.Database.SqlQuery<CreditNoteListEntity>("PRC_CreditNoteList").ToList();
            
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
                            CreditList = CreditList.Where(x => x.CreditDateDateTime.Value.Year == year).ToList();
                            break;
                        case "Quarter":
                            switch (item.FieldValue)
                            {
                                case "1":
                                    CreditList = CreditList.Where(x => x.CreditDateDateTime.Value.Month == 1 || x.CreditDateDateTime.Value.Month == 2 || x.CreditDateDateTime.Value.Month == 3).ToList();
                                    break;
                                case "2":
                                    CreditList = CreditList.Where(x => x.CreditDateDateTime.Value.Month == 4 || x.CreditDateDateTime.Value.Month == 5 || x.CreditDateDateTime.Value.Month == 6).ToList();
                                    break;
                                case "3":
                                    CreditList = CreditList.Where(x => x.CreditDateDateTime.Value.Month == 7 || x.CreditDateDateTime.Value.Month == 8 || x.CreditDateDateTime.Value.Month == 9).ToList();
                                    break;
                                case "4":
                                    CreditList = CreditList.Where(x => x.CreditDateDateTime.Value.Month == 10 || x.CreditDateDateTime.Value.Month == 11 || x.CreditDateDateTime.Value.Month == 12).ToList();
                                    break;
                            }
                            break;
                        case "Month":
                            var month = Convert.ToInt32(item.FieldValue);
                            CreditList = CreditList.Where(x => x.CreditDateDateTime.Value.Month == month).ToList();
                            break;
                        case "StartDate":
                            startDate = Convert.ToDateTime(item.FieldValue);
                            //CreditList = CreditList.Where(x => x.CreditDateDateTime ).ToList();
                            break;
                        case "EndDate":
                            DateTime endDate = Convert.ToDateTime(item.FieldValue);
                            CreditList = CreditList.Where(x => x.CreditDateDateTime > startDate && x.CreditDateDateTime < endDate).ToList();
                            break;
                    }
                }
                CreditListReturn = CreditList;
            }
            else
            {
                CreditListReturn = CreditList;
            }
            return CreditListReturn;
        }

        public string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Credit";
            else if (ConvertedToPO == true)
                return "Credit";
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
