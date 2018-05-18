using SASDAL.Customers;
using SDN.UI.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Customers
{
    public class CustomersUnPaidInvoicesBL : ICustomersUnPaidInvoicesBL
    {
        public List<CustomersUnpaidInvoicesEntity> GetCustomersList(string statementDate)
        {
            ICustomersUnpaidInvoicesDAL sDAL = new CustomersUnPaidInvoicesDAL();
            return sDAL.GetCustomersList(statementDate);
        }
        public CustomersStatementEntity GetAllUnPaidInvoice(int supplierID, string statementDate)
        {
            ICustomersUnpaidInvoicesDAL sDAL = new CustomersUnPaidInvoicesDAL();
            return sDAL.GetAllUnPaidInvoice(supplierID, statementDate);
        }

        public CustomersStatementEntity GetPrintUnpaidSalesInvoice(int supplierID, string statementDate)
        {
            ICustomersUnpaidInvoicesDAL sDAL = new CustomersUnPaidInvoicesDAL();
            return sDAL.GetPrintUnpaidSalesInvoice(supplierID, statementDate);
        }
    }
}
