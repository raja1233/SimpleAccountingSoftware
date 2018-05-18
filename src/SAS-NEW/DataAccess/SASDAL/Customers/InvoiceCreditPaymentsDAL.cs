﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Customers
{
    using Newtonsoft.Json;
    using SDN.Common;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Customers;
    using System.Data.SqlClient;

    public class InvoiceCreditPaymentsDAL: IInvoiceCreditPaymentsDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        string ignored = string.Empty;
        public List<InvoiceCreditPaymentsEntity> GetCustomersList(string json)
        {
            
            List<InvoiceCreditPaymentsEntity> lstInvoiceDetails = new List<InvoiceCreditPaymentsEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    if(json==null)
                    {
                            ignored = JsonConvert.SerializeObject(json,
                                   Formatting.Indented,
                                   new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                                        lstInvoiceDetails = entities.Database.SqlQuery<InvoiceCreditPaymentsEntity>("USP_InvCNPayment_Customers @year,@Quarter,@Month",
                                    new SqlParameter("year", Convert.ToInt64(0)),
                                     new SqlParameter("Quarter", Convert.ToInt64(0)),
                                      new SqlParameter("Month", Convert.ToInt64(0))).ToList();
                        }
                        else
                        {
                        var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(json);
                                lstInvoiceDetails = entities.Database.SqlQuery<InvoiceCreditPaymentsEntity>("USP_InvCNPayment_Customers @year,@Quarter,@Month",
                               new SqlParameter("year", Convert.ToInt64(objResponse1[0].FieldValue)),
                                new SqlParameter("Quarter", Convert.ToInt64(objResponse1[1].FieldValue)),
                                 new SqlParameter("Month", Convert.ToInt64(objResponse1[2].FieldValue))).ToList();
                        }
                   
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInvoiceDetails;
        }
        public List<InvCreditPaymentsDetailsEntity> GetUnPaidInvoices(int supplierID, string json)
        {
            var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(json);
            List<InvCreditPaymentsDetailsEntity> lstInvoiceDetails = new List<InvCreditPaymentsDetailsEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    lstInvoiceDetails = entities.Database.SqlQuery<InvCreditPaymentsDetailsEntity>("USP_CustomerStatementInvCNPayment @ID, @year,@Quarter,@Month",
                        new SqlParameter("ID", supplierID),
                         new SqlParameter("year", Convert.ToInt16(objResponse1[0].FieldValue)),
                          new SqlParameter("Quarter", Convert.ToInt16(objResponse1[1].FieldValue)),
                           new SqlParameter("Month", Convert.ToInt16(objResponse1[2].FieldValue))).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInvoiceDetails;
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
        //public string GetLastSelectionData(int ScreenId)
        //{
        //    try
        //    {
        //        using (SASEntitiesEDM entities = new SASEntitiesEDM())
        //        {
        //            var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
        //            if (result != null)
        //                return result.Last_Selection;
        //            else
        //                return null;
        //        }
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
                var month = dateTime.Month;
                var Quarter = 0;
                var lastQuarter = 0;
                var lastMonth = month - 1;
                if (lastMonth == 0) 
                {
                    lastMonth = 1;
                }
                if(month == 1 || month == 2  || month ==3)
                {
                    Quarter = 1;
                    lastQuarter = Quarter;
                }
                else if(month == 4 || month == 5 || month == 6)
                {
                    Quarter = 2;
                    lastQuarter = Quarter - 1;
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                    Quarter = 3;
                    lastQuarter = Quarter - 1;
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                    Quarter = 4;
                    lastQuarter = Quarter - 1;
                }
                var result = entities.LastSelectionHistories.Where(x => x.Screen_Id == ScreenId).FirstOrDefault();
                if (result != null)
                {
                    var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(result.Last_Selection);
                    objResponse1[0].FieldValue = DateTime.UtcNow.Year.ToString();
                    objResponse1[1].FieldValue = Quarter.ToString();
                    objResponse1[2].FieldValue = lastMonth.ToString();
                    var finalresult = JsonConvert.SerializeObject(objResponse1);
                    SharedValues.JsonDataValues = finalresult;
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
        public InvoiceCreditPaymentsEntity GetPrintSalesInvoiceCreditPayement(int CustomerID, string json)
        {
            InvoiceCreditPaymentsEntity entity = new InvoiceCreditPaymentsEntity();
            List<InvCreditPaymentsDetailsEntity> invoiceCreditPay = new List<InvCreditPaymentsDetailsEntity>();
            var objResponse1 = JsonConvert.DeserializeObject<List<SearchEntity>>(json);
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    invoiceCreditPay = entities.Database.SqlQuery<InvCreditPaymentsDetailsEntity>("USP_CustomerStatementInvCNPayment @ID, @year,@Quarter,@Month",
                        new SqlParameter("ID", CustomerID),
                         new SqlParameter("year", Convert.ToInt16(objResponse1[0].FieldValue)),
                          new SqlParameter("Quarter", Convert.ToInt16(objResponse1[1].FieldValue)),
                           new SqlParameter("Month", Convert.ToInt16(objResponse1[2].FieldValue))).ToList();


                    var Customer = (from cus in entities.Customers
                                    where cus.ID == CustomerID && (cus.IsDeleted == false || cus.IsDeleted == null)
                                    select new InvoiceCreditPaymentsEntity
                                    {
                                        CustomerName = cus.Cus_Name,
                                        CustomerBillAddress1 = cus.Cus_Bill_to_line1,
                                        CustomerBillAddress2 = cus.Cus_Bill_to_line2,
                                        CustomerBillAddressCity = cus.Cus_Bill_to_city,
                                        CustomerBillAddressState = cus.Cus_Bill_to_state,
                                        CustomerBillAddressCountary = cus.Cus_Bill_to_country,
                                        CustomerBillPostCode = cus.Cus_Bill_to_post_code,
                                        CustomerTelephone = cus.Cus_Telephone
                                    }).SingleOrDefault();
                   if(Customer!=null)
                    {
                        entity.InvoiceCreditPayement= Customer;
                        //entity.InvoiceCreditPayement.CustomerBillAddress1 = Customer.CustomerBillAddress1;
                        //entity.InvoiceCreditPayement.CustomerBillAddress2 = Customer.CustomerBillAddress2;
                        //entity.InvoiceCreditPayement.CustomerBillAddressCity = Customer.CustomerBillAddressCity;
                        //entity.InvoiceCreditPayement.CustomerBillAddressState = Customer.CustomerBillAddressState;
                        //entity.InvoiceCreditPayement.CustomerBillAddressCountary = Customer.CustomerBillAddressCountary;
                        //entity.InvoiceCreditPayement.CustomerBillPostCode = Customer.CustomerBillPostCode;
                    }
                       

                    var optiondata = (from option in entities.Options
                                      select new InvoiceCreditPaymentsEntity
                                      {
                                          CurrencyCode = option.Currency_Code
                                      }).SingleOrDefault();
                   if(optiondata!=null)
                    {
                        entity.InvoiceCreditPayement = optiondata;
                    }
                       
                  
                    var company = (from com in entities.CompanyDetails
                                   where (com.IsDeleted == false || com.IsDeleted == null)
                                   select new InvoiceCreditPaymentsEntity
                                   {
                                       CompanyName = com.Comp_Name,
                                       CompanyLogo = com.Comp_Logo,
                                       CompanyRegNumber = com.Comp_Reg_No,
                                       CompanyGstNumber = com.Comp_GST_Reg_No,
                                       CompanyBillToAddressLine1 = com.Comp_Bill_to_line1,
                                       CompanyBillToAddressLine2 = com.Comp_Bill_to_line2,
                                       CompanyBillToCity = com.Comp_Bill_to_city,
                                       CompanyBillToState = com.Comp_Bill_to_state,
                                       CompanyBillToCountary = com.Comp_Bill_to_country,
                                       CompanyBillToPostCode = com.Comp_Bill_to_post_code,
                                       CompanyEmail = com.Comp_Email,
                                       CompanyFax = com.Comp_Fax
                                   }).SingleOrDefault();
                   if(company!=null)
                    {
                        entity.InvoiceCreditPayement.CompanyName = company.CompanyName;
                        entity.InvoiceCreditPayement.CompanyLogo = company.CompanyLogo;
                        entity.InvoiceCreditPayement.CompanyRegNumber = company.CompanyRegNumber;
                        entity.InvoiceCreditPayement.CompanyGstNumber = company.CompanyGstNumber;
                        entity.InvoiceCreditPayement.CompanyBillToAddressLine1 = company.CompanyBillToAddressLine1;
                        entity.InvoiceCreditPayement.CompanyBillToAddressLine2 = company.CompanyBillToAddressLine2;
                        entity.InvoiceCreditPayement.CompanyBillToCity = company.CompanyBillToCity;
                        entity.InvoiceCreditPayement.CompanyBillToState = company.CompanyBillToState;
                        entity.InvoiceCreditPayement.CompanyBillToCountary = company.CompanyBillToCountary;
                        entity.InvoiceCreditPayement.CompanyBillToPostCode = company.CompanyBillToPostCode;
                    }
                          
                }
                entity.LstInvoiceDetails = invoiceCreditPay;
                
            }
            catch (Exception e)
            {
               
                    throw e;
            }
            return entity;
        }
    }
}
