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
    public class RefundToCustomersBL : IRefundToCustomersBL
    {
        public RefundToCustomerForm GetPaymentToSupplierDetails(string cashChequeNo)
        {
            IRefundToCustomersDAL psDAL = new RefundToCustomersDAL();
            return psDAL.GetRefundToCustomerDetails(cashChequeNo);
        }

        public RefundToCustomerForm GetNewPS(int? SupplierID)
        {
            IRefundToCustomersDAL psDAL = new RefundToCustomersDAL();
            return psDAL.GetNewPS(SupplierID);
        }
        public int SavePaymentToSupplier(RefundToCustomerForm psForm)
        {
            IRefundToCustomersDAL psDAL = new RefundToCustomersDAL();
            return psDAL.SaveRefundToCustomer(psForm);
        }
        public int UpdatePaymentToSupplier(RefundToCustomerForm psForm)
        {
            IRefundToCustomersDAL psDAL = new RefundToCustomersDAL();
            return psDAL.UpdateRefundToCustomer(psForm);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IRefundToCustomersDAL psDAL = new RefundToCustomersDAL();
            return psDAL.IsChequeNoPresent(cashChequeNo);
        }
        public string GetCountOfPOCustomers(out List<CustomerEntity> lstSuppliers)
        {
            IRefundToCustomersDAL psDAL = new RefundToCustomersDAL();
            return psDAL.GetCountOfPOCustomers(out lstSuppliers);
        }
        public string GetCountOfCNCustomers(out List<CustomerEntity> lstSuppliers)
        {
            IRefundToCustomersDAL psDAL = new RefundToCustomersDAL();
            return psDAL.GetCountOfCNCustomers(out lstSuppliers);
        }

        public string GetLastCashNo()
        {
            IRefundToCustomersDAL psDAL = new RefundToCustomersDAL();
            return psDAL.GetLastCashNo();
        }
    }
}
