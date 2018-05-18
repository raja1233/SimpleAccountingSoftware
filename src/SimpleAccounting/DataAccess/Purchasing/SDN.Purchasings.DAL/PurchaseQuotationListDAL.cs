﻿//using Newtonsoft.Json;
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
    public class PurchaseQuotationListDAL : IPurchaseQuotationListDAL
    {
        SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities();
        public List<PurchaseQuotationListEntity> GetAllPurQuotation()
        {
            List<PurchaseQuotationListEntity> quotationList = entities.PurchaseQuotations.Join(entities.Suppliers, y => y.Sup_Id, x => x.ID, (x, y) => new PurchaseQuotationListEntity
            {
                ID = x.ID,
                SupplierName = y.Sup_Name,
                Sup_ID = x.Sup_Id,
                QuotationNo = x.PQ_No,
                QuotationDate = x.PQ_Date.ToString(),
                QuotationDateDateTime = x.PQ_Date,
                QuotationAmount = x.PQ_Tot_aft_Tax.ToString(),
                QAmount=x.PQ_Tot_aft_Tax,
                QuotationAmountIncGST = x.PQ_Tot_aft_Tax.ToString(),
                QuotationAmountExcGST = x.PQ_Tot_bef_Tax.ToString(),
                ConvertedToPI = x.PQ_Conv_to_PI,
                ConvertedToPO = x.PQ_Conv_to_PO,
                ConvertedToNo = x.Conv_to_No,
                IsDeleted = x.IsDeleted,
                SelectedSearchPQList = x.ID,
                CreatedDate = x.PQ_Date,
                CreatedDateList = x.CreatedDate,
                ExcIncGST = x.Exc_Inc_GST
            }).Where(w => w.IsDeleted != true && w.ExcIncGST != null ).ToList();
            
            return quotationList;
        }

        public List<PurchaseQuotationListEntity> GetAllPurQuotationJson(string JsonData, bool? ExcincTax)
        {
            List<PurchaseQuotationListEntity> quotationList = new List<PurchaseQuotationListEntity>();
            List<PurchaseQuotationListEntity> quotationListReturn = new List<PurchaseQuotationListEntity>();
            quotationList = entities.PurchaseQuotations.Join(entities.Suppliers, y => y.Sup_Id, x => x.ID, (x, y) => new PurchaseQuotationListEntity
            {
                ID = x.ID,
                SupplierName = y.Sup_Name,
                Sup_ID = x.Sup_Id,
                QuotationNo = x.PQ_No,
                QuotationDate = x.PQ_Date.ToString(),
                QuotationDateDateTime = x.PQ_Date,
                QAmount = x.PQ_Tot_aft_Tax,
                QuotationAmount = x.PQ_Tot_aft_Tax.ToString(),
                QuotationAmountIncGST = x.PQ_Tot_aft_Tax.ToString(),
                QuotationAmountExcGST = x.PQ_Tot_bef_Tax.ToString(),
                ConvertedToPI = x.PQ_Conv_to_PI,
                ConvertedToPO = x.PQ_Conv_to_PO,
                ConvertedToNo=x.Conv_to_No,
                IsDeleted = x.IsDeleted,
                SelectedSearchPQList = x.ID,
                CreatedDate = x.PQ_Date,
                CreatedDateList = x.CreatedDate,
                ExcIncGST = x.Exc_Inc_GST
            }).Where(w => w.IsDeleted != true //&& w.ExcIncGST== ExcincTax //commented on 23 May 2017
            ).ToList();
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
                            quotationList = quotationList.Where(x => x.QuotationDateDateTime.Value.Year == year).ToList();
                            break;
                        case "Quarter":
                            switch (item.FieldValue)
                            {
                                case "1":
                                    quotationList = quotationList.Where(x => x.QuotationDateDateTime.Value.Month == 1|| x.QuotationDateDateTime.Value.Month==2|| x.QuotationDateDateTime.Value.Month==3).ToList();
                                    break;
                                case "2":
                                    quotationList = quotationList.Where(x => x.QuotationDateDateTime.Value.Month == 4 || x.QuotationDateDateTime.Value.Month == 5 || x.QuotationDateDateTime.Value.Month == 6).ToList();
                                    break;
                                case "3":
                                    quotationList = quotationList.Where(x => x.QuotationDateDateTime.Value.Month == 7 || x.QuotationDateDateTime.Value.Month == 8 || x.QuotationDateDateTime.Value.Month == 9).ToList();
                                    break;
                                case "4":
                                    quotationList = quotationList.Where(x => x.QuotationDateDateTime.Value.Month == 10 || x.QuotationDateDateTime.Value.Month == 11 || x.QuotationDateDateTime.Value.Month == 12).ToList();
                                    break;
                            }
                            break;
                        case "Month":
                            var month = Convert.ToInt32(item.FieldValue);
                            quotationList = quotationList.Where(x => x.QuotationDateDateTime.Value.Month == month).ToList();
                            break;
                        case "StartDate":
                            //startDate = Convert.ToDateTime(item.FieldValue);
                            startDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy",CultureInfo.InvariantCulture);
                            //quotationList = quotationList.Where(x => x.QuotationDateDateTime ).ToList();
                            break;
                        case "EndDate":
                            //DateTime endDate = Convert.ToDateTime(item.FieldValue);
                            DateTime endDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);

                            quotationList = quotationList.Where(x => x.QuotationDateDateTime>startDate&& x.QuotationDateDateTime<endDate).ToList();
                            break;
                    }
                }
                  quotationListReturn = quotationList;
            }
            else
            {
                quotationListReturn = quotationList;
            }
            return quotationListReturn;
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