using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BLInterface
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public interface IPaymentFromCustomersBL
    {
        string GetCountOfPOSuppliers(out List<CustomerEntity> lstCustomers);
        string GetCountOfPISuppliers(out List<CustomerEntity> lstCustomers);
        PaymentFromCustomerForm GetNewPS(int? SupplierID);
        int SavePaymentToSupplier(PaymentFromCustomerForm psForm);
        PaymentFromCustomerForm GetPaymentToSupplierDetails(string cashChequeNo);
        int UpdatePaymentToSupplier(PaymentFromCustomerForm psForm);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
