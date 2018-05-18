using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.DALInterface
{
    using SDN.UI.Entities.Sales;
    using SDN.UI.Entities;
    public interface IPaymentFromCustomersDAL
    {
        string GetCountOfPOSuppliers(out List<CustomerEntity> lstCustomers);
        string GetCountOfPISuppliers(out List<CustomerEntity> lstCustomers);
        PaymentFromCustomerForm GetNewPS(int? SupplierID);
        PaymentFromCustomerForm GetPaymentFromCustomerDetails(string cashChequeNo);
        int SavePaymentFromCustomer(PaymentFromCustomerForm psForm);
        int UpdatePaymentToSupplier(PaymentFromCustomerForm psForm);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
