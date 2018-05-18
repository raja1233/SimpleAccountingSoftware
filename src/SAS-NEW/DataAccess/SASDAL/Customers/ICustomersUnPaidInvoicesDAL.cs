using SDN.UI.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Customers
{
    public interface ICustomersUnpaidInvoicesDAL
    {
        List<CustomersUnpaidInvoicesEntity> GetCustomersList(string statementDate);
        CustomersStatementEntity GetAllUnPaidInvoice(int supplierID, string statementDate);
        CustomersStatementEntity GetPrintUnpaidSalesInvoice(int supplierID, string statementDate);
    }
}
