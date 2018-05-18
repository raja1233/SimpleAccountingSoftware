using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public interface IRefundToCustomersRepository
    {
        string GetCountOfPOCustomer(out List<CustomerEntity> lstSuppliers);
        string GetCountOfDNCustomer(out List<CustomerEntity> lstSuppliers);
        bool IsChequeNoPresent(string cashChequeNo);
        int UpdateRefundToCustomer(RefundToCustomerForm psForm);
        int SaveRefundToCustomer(RefundToCustomerForm psForm);
        RefundToCustomerForm GetNewPS(int? SupplierID);
        RefundToCustomerForm GetRefundToCustomerDetails(string cashChequeNo);
        string GetLastCashNo();
    }
}
