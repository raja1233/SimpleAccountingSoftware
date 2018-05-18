using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BLInterface
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public interface IRefundToCustomersBL
    {
        string GetCountOfPOCustomers(out List<CustomerEntity> lstSuppliers);
        string GetCountOfCNCustomers(out List<CustomerEntity> lstSuppliers);
        RefundToCustomerForm GetNewPS(int? SupplierID);
        int SavePaymentToSupplier(RefundToCustomerForm psForm);
        RefundToCustomerForm GetPaymentToSupplierDetails(string cashChequeNo);
        int UpdatePaymentToSupplier(RefundToCustomerForm psForm);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
