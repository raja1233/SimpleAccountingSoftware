using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using SDN.Sales.Services;
    using SDN.Sales.BL;
    using SDN.Sales.BLInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public class PaymentFromCustomersRepository: IPaymentFromCustomersRepository
    {
        public PaymentFromCustomerForm GetPaymentFromCustomerDetails(string cashChequeNo)
        {
            IPaymentFromCustomersBL psBL = new PaymentFromCustomersBL();
            return psBL.GetPaymentToSupplierDetails(cashChequeNo);
        }
        public PaymentFromCustomerForm GetNewPS(int? SupplierID)
        {
            IPaymentFromCustomersBL psBL = new PaymentFromCustomersBL();
            return psBL.GetNewPS(SupplierID);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IPaymentFromCustomersBL psBL = new PaymentFromCustomersBL();
            return psBL.IsChequeNoPresent(cashChequeNo);
        }
        public int UpdatePaymentFromCustomer(PaymentFromCustomerForm psForm)
        {
            IPaymentFromCustomersBL psBL = new PaymentFromCustomersBL();
            return psBL.UpdatePaymentToSupplier(psForm);
        }
        public int SavePaymentFromCustomer(PaymentFromCustomerForm psForm)
        {
            IPaymentFromCustomersBL psBL = new PaymentFromCustomersBL();
            return psBL.SavePaymentToSupplier(psForm);

        }
        public string GetCountOfPOSuppliers(out List<CustomerEntity> lstCustomers)
        {
            IPaymentFromCustomersBL psBL = new PaymentFromCustomersBL();
            return psBL.GetCountOfPOSuppliers(out lstCustomers);
        }
        public string GetCountOfPISuppliers(out List<CustomerEntity> lstCustomers)
        {
            IPaymentFromCustomersBL psBL = new PaymentFromCustomersBL();
            return psBL.GetCountOfPISuppliers(out lstCustomers);
        }

        public string GetLastCashNo()
        {
            IPaymentFromCustomersBL psBL = new PaymentFromCustomersBL();
            return psBL.GetLastCashNo();
        }
    }
}
