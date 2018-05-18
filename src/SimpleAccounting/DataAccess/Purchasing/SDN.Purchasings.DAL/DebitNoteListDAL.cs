//using Newtonsoft.Json;
using Newtonsoft.Json;
using SDN.Purchasings.DALInterface;
using SDN.PurchasingsEDM;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DAL
{
    public class DebitNoteListDAL : IDebitNoteListDAL
    {
        SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities();
        public List<DebitNoteListEntity> GetAllPurDebit()
        {
            List<DebitNoteListEntity> DebitList = entities.Database.SqlQuery<DebitNoteListEntity>("DebitNoteList").ToList();
           
            return DebitList;
        }

        public List<DebitNoteListEntity> GetAllPurDebitJson(string JsonData, bool? ExcincTax)
        {
            List<DebitNoteListEntity> DebitList = new List<DebitNoteListEntity>();
            DebitNoteListEntity DebitList1 = new DebitNoteListEntity();
            List<DebitNoteListEntity> DebitListReturn = new List<DebitNoteListEntity>();
            ////DebitList = entities.DebitNotes.Join(entities.Suppliers, y => y.Sup_Id, x => x.ID, (x, y) => new DebitNoteListEntity
            ////{
            ////    ID = x.ID,
            ////    SupplierName = y.Sup_Name,
            ////    Sup_ID = x.Sup_Id,
            ////    DebitNo = x.PI_No,
            ////    DebitDate = x.PI_Date.ToString(),
            ////    DebitAmount = x.PI_Tot_aft_Tax.ToString(),
            ////    DebitAmountIncGST = x.PI_Tot_aft_Tax.ToString(),
            ////    DebitAmountExcGST = x.PI_Tot_bef_Tax.ToString(),
            ////    //ConvertedToPI = x.PO_Conv_to_PI,
            ////    //ConvertedToPO = x.PO_Conv_to_PO,
            ////    IsDeleted = x.IsDeleted,
            ////    SelectedSearchPQList = x.ID,
            ////    CreatedDate = x.PI_Date,
            ////    CreatedDateList = x.CreatedDate,
            ////    ExcIncGST = x.Exc_Inc_GST,
            ////    DebitDateDateTime = x.PI_Date
            ////}).Where(w => w.IsDeleted != true && w.ExcIncGST == ExcincTax).ToList();

            //DebitList = (from i in entities.DebitNotes
            //               join s in entities.Suppliers
            //               on i.Sup_Id equals s.ID
            //               join cbt in entities.CashAndBankTransactions
            //               on s.ID equals cbt.Cus_Sup_Id into cbtej
            //               from cbt in cbtej.DefaultIfEmpty()
            //               join d in entities.DebitNotes on i.ID equals d.PI_Id into ej
            //               from d in ej.DefaultIfEmpty()
            //               where i.IsDeleted != true && d.IsDeleted != true
            //               select new DebitNoteListEntity
            //               {
            //                   ID = i.ID,
            //                   Sup_ID = i.Sup_Id,
            //                   ExcIncGST = i.Exc_Inc_GST,
            //                   DebitNoteAmount = d.Sup_CN_Amount,
            //                   DebitNoteDate = d.DN_Date.ToString(),
            //                   DebitNoteNo = d.DN_No,
            //                   SupplierName = s.Sup_Name,
            //                   Status = i.PI_Status,
            //                   DebitNo = i.PI_No,
            //                   DebitDate = i.PI_Date.ToString(),
            //                   DebitAmount = i.PI_Tot_aft_Tax.ToString(),
            //                   IsDeleted = i.IsDeleted,
            //                   CashChequeAmount = cbt.Amount,
            //                   CashChequeDate = cbt.Cash_Cheque_Date.ToString(),
            //                   CashChequeNo = cbt.Cash_Cheque_No

            //               }).ToList();

            DebitList = entities.Database.SqlQuery<DebitNoteListEntity>("DebitNoteList").ToList();




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
                            DebitList = DebitList.Where(x => x.DebitDateDateTime.Value.Year == year).ToList();
                            break;
                        case "Quarter":
                            switch (item.FieldValue)
                            {
                                case "1":
                                    DebitList = DebitList.Where(x => x.DebitDateDateTime.Value.Month == 1 || x.DebitDateDateTime.Value.Month == 2 || x.DebitDateDateTime.Value.Month == 3).ToList();
                                    break;
                                case "2":
                                    DebitList = DebitList.Where(x => x.DebitDateDateTime.Value.Month == 4 || x.DebitDateDateTime.Value.Month == 5 || x.DebitDateDateTime.Value.Month == 6).ToList();
                                    break;
                                case "3":
                                    DebitList = DebitList.Where(x => x.DebitDateDateTime.Value.Month == 7 || x.DebitDateDateTime.Value.Month == 8 || x.DebitDateDateTime.Value.Month == 9).ToList();
                                    break;
                                case "4":
                                    DebitList = DebitList.Where(x => x.DebitDateDateTime.Value.Month == 10 || x.DebitDateDateTime.Value.Month == 11 || x.DebitDateDateTime.Value.Month == 12).ToList();
                                    break;
                            }
                            break;
                        case "Month":
                            var month = Convert.ToInt32(item.FieldValue);
                            DebitList = DebitList.Where(x => x.DebitDateDateTime.Value.Month == month).ToList();
                            break;
                        case "StartDate":
                            //startDate = Convert.ToDateTime(item.FieldValue);
                            startDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);
                            //DebitList = DebitList.Where(x => x.DebitDateDateTime ).ToList();
                            break;
                        case "EndDate":
                            // DateTime endDate = Convert.ToDateTime(item.FieldValue);
                            DateTime endDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);
                            DebitList = DebitList.Where(x => x.DebitDateDateTime > startDate && x.DebitDateDateTime < endDate).ToList();
                            break;
                    }
                }
                DebitListReturn = DebitList;
            }
            else
            {
                DebitListReturn = DebitList;
            }
            return DebitListReturn;
        }

        public string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Debit";
            else if (ConvertedToPO == true)
                return "Debit";
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
