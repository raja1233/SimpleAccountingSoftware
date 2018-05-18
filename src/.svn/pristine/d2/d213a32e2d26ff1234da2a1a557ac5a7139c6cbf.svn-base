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
    public class RefundToCustomersRepository : IRefundToCustomersRepository
    {
        public RefundToCustomerForm GetRefundToCustomerDetails(string cashChequeNo)
        {
            IRefundToCustomersBL psBL = new RefundToCustomersBL();
            return psBL.GetPaymentToSupplierDetails(cashChequeNo);
        }
        public RefundToCustomerForm GetNewPS(int? SupplierID)
        {
            IRefundToCustomersBL psBL = new RefundToCustomersBL();
            return psBL.GetNewPS(SupplierID);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IRefundToCustomersBL psBL = new RefundToCustomersBL();
            return psBL.IsChequeNoPresent(cashChequeNo);
        }
        public int UpdateRefundToCustomer(RefundToCustomerForm psForm)
        {
            IRefundToCustomersBL psBL = new RefundToCustomersBL();
            return psBL.UpdatePaymentToSupplier(psForm);
        }
        public int SaveRefundToCustomer(RefundToCustomerForm psForm)
        {
            IRefundToCustomersBL psBL = new RefundToCustomersBL();
            return psBL.SavePaymentToSupplier(psForm);

        }
        public string GetCountOfPOCustomer(out List<CustomerEntity> lstSuppliers)
        {
            IRefundToCustomersBL psBL = new RefundToCustomersBL();
            return psBL.GetCountOfPOCustomers(out lstSuppliers);
        }
        public string GetCountOfDNCustomer(out List<CustomerEntity> lstSuppliers)
        {
            IRefundToCustomersBL psBL = new RefundToCustomersBL();
            return psBL.GetCountOfCNCustomers(out lstSuppliers);
        }

        public string GetLastCashNo()
        {
            IRefundToCustomersBL psBL = new RefundToCustomersBL();
            return psBL.GetLastCashNo();
        }
    }
}
