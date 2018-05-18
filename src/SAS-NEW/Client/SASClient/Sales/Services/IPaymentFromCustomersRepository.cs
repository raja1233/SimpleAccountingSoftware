using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public interface IPaymentFromCustomersRepository
    {
        string GetCountOfPOSuppliers(out List<CustomerEntity> lstCustomers);
        string GetCountOfPISuppliers(out List<CustomerEntity> lstCustomers);
        bool IsChequeNoPresent(string cashChequeNo);
        int UpdatePaymentFromCustomer(PaymentFromCustomerForm psForm);
        int SavePaymentFromCustomer(PaymentFromCustomerForm psForm);
        PaymentFromCustomerForm GetNewPS(int? SupplierID);
        PaymentFromCustomerForm GetPaymentFromCustomerDetails(string cashChequeNo);
        string GetLastCashNo();
    }
}
