using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DALInterface
{
    using SDN.UI.Entities.Sales;
    using SDN.UI.Entities;
    public interface IRefundToCustomersDAL
    {
        string GetCountOfPOCustomers(out List<CustomerEntity> lstCustomers);
        string GetCountOfCNCustomers(out List<CustomerEntity> lstCustomers);
        RefundToCustomerForm GetNewPS(int? CustomerID);
        RefundToCustomerForm GetRefundToCustomerDetails(string cashChequeNo);
        int SaveRefundToCustomer(RefundToCustomerForm psForm);
        int UpdateRefundToCustomer(RefundToCustomerForm psForm);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
