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
    public class PurchaseOrderListDAL : IPurchaseOrderListDAL
    {
        SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities();
        public List<PurchaseOrderListEntity> GetAllPurOrder()
        {

            List<PurchaseOrderListEntity> OrderList = (from x in entities.PurchaseOrders
                                                      join y in entities.Suppliers on x.Sup_Id equals y.ID
                                                      where x.IsDeleted !=true && x.Exc_Inc_GST!=null
                                                     join w in entities.CashAndBankTransactions on x.PO_No equals w.SO_CN_PO_DN_No into t 
                                                     from rt in t.DefaultIfEmpty()
                                                      select new PurchaseOrderListEntity {

                                                          ID = x.ID,
                                                          SupplierName = y.Sup_Name,
                                                          Sup_ID = x.Sup_Id,
                                                          OrderNo = x.PO_No,
                                                          OrderDate = x.PO_Date.ToString(),
                                                          OrderAmount = x.PO_Tot_aft_Tax.ToString(),
                                                          OAmount = x.PO_Tot_aft_Tax,
                                                          OrderAmountIncGST = x.PO_Tot_aft_Tax.ToString(),
                                                          OrderAmountExcGST = x.PO_Tot_bef_Tax.ToString(),
                                                          ConvertedToPI = x.PO_Conv_to_PI,
                                                          //ConvertedToPO = x.PO_Conv_to_PO,
                                                          ConvertedToNo=x.Conv_to_No,
                                                          IsDeleted = x.IsDeleted,
                                                          SelectedSearchPQList = x.ID,
                                                          CreatedDate = x.PO_Date,
                                                          CreatedDateList = x.CreatedDate,
                                                          ExcIncGST = x.Exc_Inc_GST,
                                                          AmountDeposited = rt.Amount.ToString(),
                                                          DeliveryDateTime = x.PO_Del_Date.ToString(),
                                                          DeliveryDateDateTime = x.PO_Del_Date
                                                      }).OrderBy(e => e.SupplierName).ToList();

           


            return OrderList;
        }

        public List<PurchaseOrderListEntity> GetAllPurOrderJson(string JsonData, bool? ExcincTax)
        {
            List<PurchaseOrderListEntity> OrderList = new List<PurchaseOrderListEntity>();
            List<PurchaseOrderListEntity> OrderListReturn = new List<PurchaseOrderListEntity>();
           
            OrderList = (from x in entities.PurchaseOrders
                         join y in entities.Suppliers on x.Sup_Id equals y.ID
                         where x.IsDeleted != true && x.Exc_Inc_GST != null
                         join w in entities.CashAndBankTransactions on x.PO_No equals w.SO_CN_PO_DN_No into t
                         from rt in t.DefaultIfEmpty()
                         select new PurchaseOrderListEntity
                         {

                             ID = x.ID,
                             SupplierName = y.Sup_Name,
                             Sup_ID = x.Sup_Id,
                             OrderNo = x.PO_No,
                             OrderDate = x.PO_Date.ToString(),
                             OrderAmount = x.PO_Tot_aft_Tax.ToString(),
                             OAmount = x.PO_Tot_aft_Tax,
                             OrderAmountIncGST = x.PO_Tot_aft_Tax.ToString(),
                             OrderAmountExcGST = x.PO_Tot_bef_Tax.ToString(),
                             ConvertedToPI = x.PO_Conv_to_PI,
                             //ConvertedToPO = x.PO_Conv_to_PO,
                             ConvertedToNo = x.Conv_to_No,
                             IsDeleted = x.IsDeleted,
                             SelectedSearchPQList = x.ID,
                             CreatedDate = x.PO_Date,
                             CreatedDateList = x.CreatedDate,
                             ExcIncGST = x.Exc_Inc_GST,
                             AmountDeposited = rt.Amount.ToString(),
                             OrderDateDateTime = x.PO_Date,
                             DAmount = rt.Amount,
                             DeliveryDateTime = x.PO_Del_Date.ToString(),
                             DeliveryDateDateTime = x.PO_Del_Date
                         }).OrderBy(e => e.SupplierName).ToList();
            // }).Where(w => w.IsDeleted != true && w.ExcIncGST == ExcincTax).ToList(); //Removed Filter ExcIncGST
            if (JsonData != null && JsonData != "[]")
            {
                DateTime startDate = new DateTime();
                //DateTime endDate = new DateTime();
                var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(JsonData);
                foreach (var item in objResponse1)
                {
                    switch (item.FieldName)
                    {
                        case "Year":
                            var year = Convert.ToInt32(item.FieldValue);
                            OrderList = OrderList.Where(x => x.OrderDateDateTime.Value.Year == year).ToList();
                            break;
                        case "Quarter":
                            switch (item.FieldValue)
                            {
                                case "1":
                                    OrderList = OrderList.Where(x => x.OrderDateDateTime.Value.Month == 1 || x.OrderDateDateTime.Value.Month == 2 || x.OrderDateDateTime.Value.Month == 3).ToList();
                                    break;
                                case "2":
                                    OrderList = OrderList.Where(x => x.OrderDateDateTime.Value.Month == 4 || x.OrderDateDateTime.Value.Month == 5 || x.OrderDateDateTime.Value.Month == 6).ToList();
                                    break;
                                case "3":
                                    OrderList = OrderList.Where(x => x.OrderDateDateTime.Value.Month == 7 || x.OrderDateDateTime.Value.Month == 8 || x.OrderDateDateTime.Value.Month == 9).ToList();
                                    break;
                                case "4":
                                    OrderList = OrderList.Where(x => x.OrderDateDateTime.Value.Month == 10 || x.OrderDateDateTime.Value.Month == 11 || x.OrderDateDateTime.Value.Month == 12).ToList();
                                    break;
                            }
                            break;
                        case "Month":
                            var month = Convert.ToInt32(item.FieldValue);
                            OrderList = OrderList.Where(x => x.OrderDateDateTime.Value.Month == month).ToList();
                            break;
                        case "StartDate":
                            //bool dateValid = DateTime.TryParse(item.FieldValue, out  startDate);
                            startDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);
                            // startDate = Convert.ToDateTime(item.FieldValue);
                            //OrderList = OrderList.Where(x => x.OrderDateDateTime ).ToList();
                            break;
                        case "EndDate":
                            //bool dateValid1 = DateTime.TryParse(item.FieldValue, out endDate);
                            DateTime endDate = DateTime.ParseExact(item.FieldValue, "MMM/dd/yyyy", CultureInfo.InvariantCulture);
                            //  DateTime endDate = Convert.ToDateTime(item.FieldValue);
                            OrderList = OrderList.Where(x => x.OrderDateDateTime > startDate && x.OrderDateDateTime < endDate).ToList();
                            break;
                    }
                }
                OrderListReturn = OrderList;
            }
            else
            {
                OrderListReturn = OrderList;
            }
            return OrderListReturn;
        }

        //public string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        //{
        //    if (ConvertedToPI == true)
        //        return "Invoice";
        //    else if (ConvertedToPO == true)
        //        return "Order";
        //    else
        //        return "";
        //}

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
