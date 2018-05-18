using SASBAL.Customers;
using SASClient.Customers.Services;
using SDN.UI.Entities.Customers;
using System.Collections.Generic;
using System;

public class CustomersUnPaidInvoicesRepository : ICustomersUnPaidInvoicesRepository
{
    public List<CustomersUnpaidInvoicesEntity> GetCustomersList(string statementDate)
    {
        ICustomersUnPaidInvoicesBL sDAL = new CustomersUnPaidInvoicesBL();
        return sDAL.GetCustomersList(statementDate);
    }
    public CustomersStatementEntity GetAllUnPaidInvoice(int supplierID, string statementDate)
    {
        ICustomersUnPaidInvoicesBL sDAL = new CustomersUnPaidInvoicesBL();
        return sDAL.GetAllUnPaidInvoice(supplierID, statementDate);
    }

    public CustomersStatementEntity GetPrintUnpaidSalesInvoice(int supplierID, string statementDate)
    {
        ICustomersUnPaidInvoicesBL sDAL = new CustomersUnPaidInvoicesBL();
        return sDAL.GetPrintUnpaidSalesInvoice(supplierID, statementDate);
    }
}