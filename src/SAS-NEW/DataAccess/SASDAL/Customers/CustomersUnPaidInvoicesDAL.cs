using SDN.UI.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Customers
{
    public class CustomersUnPaidInvoicesDAL : ICustomersUnpaidInvoicesDAL
    {
        public List<CustomersUnpaidInvoicesEntity> GetCustomersList(string statementDate)
        {
            List<CustomersUnpaidInvoicesEntity> supList = new List<CustomersUnpaidInvoicesEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    supList = entities.Database.SqlQuery<CustomersUnpaidInvoicesEntity>("PRC_GetUnPaidInvoices_Customers @StatementDate",
                        new SqlParameter("StatementDate", statementDate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return supList;
        }
        public CustomersStatementEntity GetAllUnPaidInvoice(int customerID, string statementDate)
        {
            CustomersStatementEntity entity = new CustomersStatementEntity();
            List<CustomersBalanceEntity> lstbalances = new List<CustomersBalanceEntity>();
            List<CustomersInvoiceDetailsEntity> lstInvoices = new List<CustomersInvoiceDetailsEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    lstInvoices = entities.Database.SqlQuery<CustomersInvoiceDetailsEntity>("USP_CustomersStatementUnPaidInvoice @ID,@SDate",
                   new SqlParameter("ID", customerID),
                   new SqlParameter("SDate", statementDate)).ToList();

                    lstbalances = entities.Database.SqlQuery<CustomersBalanceEntity>("USP_GetStatementUnpaidInvoice_Summary @ID,@SDate,@Type",
                    new SqlParameter("ID", customerID),
                    new SqlParameter("SDate", statementDate),
                    new SqlParameter("Type", "C")).ToList();

                    entity.LstBalances = lstbalances;
                    entity.LstInvoices = lstInvoices;
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        public CustomersStatementEntity GetPrintUnpaidSalesInvoice(int customerID, string statementDate)
        {
            CustomersStatementEntity entity = new CustomersStatementEntity();
            List<CustomersBalanceEntity> lstbalances = new List<CustomersBalanceEntity>();
            List<CustomersInvoiceDetailsEntity> lstInvoices = new List<CustomersInvoiceDetailsEntity>();
            //CustomersEntity data = new CustomersEntity();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    lstInvoices = entities.Database.SqlQuery<CustomersInvoiceDetailsEntity>("USP_CustomersStatementUnPaidInvoice @ID,@SDate",
                   new SqlParameter("ID", customerID),
                   new SqlParameter("SDate", statementDate)).ToList();

                    lstbalances = entities.Database.SqlQuery<CustomersBalanceEntity>("USP_GetStatementUnpaidInvoice_Summary @ID,@SDate,@Type",
                    new SqlParameter("ID", customerID),
                    new SqlParameter("SDate", statementDate),
                    new SqlParameter("Type", "C")).ToList();

                    entity.LstBalances = lstbalances;
                    entity.LstInvoices = lstInvoices;
                    
                    var Customer = (from cus in entities.Customers
                                    where cus.ID == customerID && (cus.IsDeleted == false || cus.IsDeleted == null)
                                    select new CustomersUnpaidInvoicesEntity
                                    {
                                        CustomerName=cus.Cus_Name,
                                        CustomerBillAddress1=cus.Cus_Bill_to_line1,
                                        CustomerBillAddress2=cus.Cus_Bill_to_line2,
                                        CustomerBillAddressCity=cus.Cus_Bill_to_city,
                                        CustomerBillAddressState=cus.Cus_Bill_to_state,
                                        CustomerBillAddressCountary=cus.Cus_Bill_to_country,
                                        CustomerBillPostCode=cus.Cus_Bill_to_post_code
                                       
                                    }).SingleOrDefault();
                    if (Customer != null)
                    {
                        entity.InvoiceData = Customer;
                    }
                    
                    var optiondata = (from option in entities.Options
                                      select new CustomersUnpaidInvoicesEntity
                                      {
                                          CurrencyCode = option.Currency_Code
                                      }).SingleOrDefault();
                    if(optiondata!=null)
                    {
                        entity.InvoiceData.CurrencyCode = optiondata.CurrencyCode;
                    }
                    var company = (from com in entities.CompanyDetails
                                   where (com.IsDeleted == false || com.IsDeleted == null)
                                   select new CustomersUnpaidInvoicesEntity
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
                    if (company != null)
                    {
                        entity.InvoiceData.CompanyName = company.CompanyName;
                        entity.InvoiceData.CompanyLogo = company.CompanyLogo;
                        entity.InvoiceData.CompanyRegNumber = company.CompanyRegNumber;
                        entity.InvoiceData.CompanyGstNumber = company.CompanyGstNumber;
                        entity.InvoiceData.CompanyBillToAddressLine1 = company.CompanyBillToAddressLine1;
                        entity.InvoiceData.CompanyBillToAddressLine2 = company.CompanyBillToAddressLine2;
                        entity.InvoiceData.CompanyBillToCity = company.CompanyBillToCity;
                        entity.InvoiceData.CompanyBillToState = company.CompanyBillToState;
                        entity.InvoiceData.CompanyBillToCountary = company.CompanyBillToCountary;
                        entity.InvoiceData.CompanyBillToPostCode = company.CompanyBillToPostCode;
                    }
                    
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }
    }
}
