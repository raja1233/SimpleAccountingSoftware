﻿using Newtonsoft.Json;
using SDN.Sales.DALInterface;
using SDN.Sales.EDM;
using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DAL
{
    public class SalesQuotationListDAL: ISalesQuotationListDAL
    {
        SDNSalesDBEntities entities = new SDNSalesDBEntities();
        public List<SalesQuotationListEntity> GetAllSalesQuotation()
        {
            try
            {
                List<SalesQuotationListEntity> quotationList = entities.SalesQuotations.Join(entities.Customers, y => y.Cus_Id, x => x.ID, (x, y) => new SalesQuotationListEntity
                {
                    ID = x.ID,
                    CustomerName = y.Cus_Name,
                    Cus_ID = x.Cus_Id,
                    QuotationNo = x.SQ_No,
                    QuotationDate = x.SQ_Date.ToString(),
                    QuotationAmount = x.SQ_Tot_aft_Tax.ToString(),
                    QAmount = x.SQ_Tot_aft_Tax,
                    QuotationAmountIncGST = x.SQ_Tot_aft_Tax.ToString(),
                    QuotationAmountExcGST = x.SQ_Tot_bef_Tax.ToString(),
                    ConvertedToSI = x.SQ_Conv_to_SI,
                    ConvertedToSO = x.SQ_Conv_to_SO,
                    ConvertedToNo = x.Conv_to_No,
                    IsDeleted = x.IsDeleted,
                    SelectedSearchPQList = x.ID,
                    CreatedDate = x.SQ_Date,
                    CreatedDateList = x.CreatedDate,
                    ExcIncGST = x.Exc_Inc_GST
                }).Where(w => w.IsDeleted != true && w.ExcIncGST != null).ToList();

                //List<SalesQuotationListEntity> quotationList = entities.SalesQuotations.Join(entities.Suppliers, y => y.Sup_Id, x => x.ID, (x, y) => x.).Where(x => x.IsDeleted != true).Select(x => new SalesQuotationListEntity
                //{
                //    SupplierName = x.Sup_Id.name
                //}).ToList();

                //List<SalesQuotationListEntity> quotationList = (from quotation in entities.SalesQuotations
                //                                                  join supplier in entities.Suppliers on quotation.Sup_Id equals supplier.ID
                //                                                  where x => x.IsDeleted != true
                //                                                  select new SalesQuotationListEntity {
                //                                                      SupplierName = quotation. ,

                //                                                  })



                return quotationList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesQuotationListEntity> GetAllSalesQuotationJson(string JsonData, bool? ExcincTax)
        {
            try
            {
                List<SalesQuotationListEntity> quotationList = new List<SalesQuotationListEntity>();
                List<SalesQuotationListEntity> quotationListReturn = new List<SalesQuotationListEntity>();
                quotationList = entities.SalesQuotations.Join(entities.Customers, y => y.Cus_Id, x => x.ID, (x, y) => new SalesQuotationListEntity
                {
                    ID = x.ID,
                    CustomerName = y.Cus_Name,
                    Cus_ID = x.Cus_Id,
                    QuotationNo = x.SQ_No,
                    QuotationDate = x.SQ_Date.ToString(),
                    QuotationDateDateTime = x.SQ_Date,
                    QuotationAmount = x.SQ_Tot_aft_Tax.ToString(),
                    QuotationAmountIncGST = x.SQ_Tot_aft_Tax.ToString(),
                    QAmount=x.SQ_Tot_aft_Tax,
                    QuotationAmountExcGST = x.SQ_Tot_bef_Tax.ToString(),
                    ConvertedToSI = x.SQ_Conv_to_SI,
                    ConvertedToSO = x.SQ_Conv_to_SO,
                    ConvertedToNo = x.Conv_to_No,
                    IsDeleted = x.IsDeleted,
                    SelectedSearchPQList = x.ID,
                    CreatedDate = x.SQ_Date,
                    CreatedDateList = x.CreatedDate,
                    ExcIncGST = x.Exc_Inc_GST
                }).Where(w => w.IsDeleted != true //&& w.ExcIncGST == ExcincTax //commented on 23 May 2017
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
                                        quotationList = quotationList.Where(x => x.QuotationDateDateTime.Value.Month == 1 || x.QuotationDateDateTime.Value.Month == 2 || x.QuotationDateDateTime.Value.Month == 3).ToList();
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
                                startDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);
                                //quotationList = quotationList.Where(x => x.QuotationDateDateTime ).ToList();
                                break;
                            case "EndDate":
                                //DateTime endDate = Convert.ToDateTime(item.FieldValue);
                                DateTime endDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);
                                quotationList = quotationList.Where(x => x.QuotationDateDateTime > startDate && x.QuotationDateDateTime < endDate).ToList();
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Invoice";
            else if (ConvertedToPO == true)
                return "Order";
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
