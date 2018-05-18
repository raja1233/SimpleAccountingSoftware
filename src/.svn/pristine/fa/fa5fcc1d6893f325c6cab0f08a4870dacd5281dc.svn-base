using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BL
{
    using BLInterface;
    using SDN.Sales.DAL;
    using SDN.Sales.DALInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Sales;
    public class PaymentFromCustomersBL: IPaymentFromCustomersBL
    {
        public PaymentFromCustomerForm GetPaymentToSupplierDetails(string cashChequeNo)
        {
            IPaymentFromCustomersDAL psDAL = new PaymentFromCustomersDAL();
            return psDAL.GetPaymentFromCustomerDetails(cashChequeNo);
        }

        public PaymentFromCustomerForm GetNewPS(int? SupplierID)
        {
            IPaymentFromCustomersDAL psDAL = new PaymentFromCustomersDAL();
            return psDAL.GetNewPS(SupplierID);
        }
        public int SavePaymentToSupplier(PaymentFromCustomerForm psForm)
        {
            IPaymentFromCustomersDAL psDAL = new PaymentFromCustomersDAL();
            return psDAL.SavePaymentFromCustomer(psForm);
        }
        public int UpdatePaymentToSupplier(PaymentFromCustomerForm psForm)
        {
            IPaymentFromCustomersDAL psDAL = new PaymentFromCustomersDAL();
            return psDAL.UpdatePaymentToSupplier(psForm);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IPaymentFromCustomersDAL psDAL = new PaymentFromCustomersDAL();
            return psDAL.IsChequeNoPresent(cashChequeNo);
        }
        public string GetCountOfPOSuppliers(out List<CustomerEntity> lstCustomers)
        {
            IPaymentFromCustomersDAL psDAL = new PaymentFromCustomersDAL();
            return psDAL.GetCountOfPOSuppliers(out lstCustomers);
        }
        public string GetCountOfPISuppliers(out List<CustomerEntity> lstCustomers)
        {
            IPaymentFromCustomersDAL psDAL = new PaymentFromCustomersDAL();
            return psDAL.GetCountOfPISuppliers(out lstCustomers);
        }

        public string GetLastCashNo()
        {
            IPaymentFromCustomersDAL psDAL = new PaymentFromCustomersDAL();
            return psDAL.GetLastCashNo();
        }
    }
}
