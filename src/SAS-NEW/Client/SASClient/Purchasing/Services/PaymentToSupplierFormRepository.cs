
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    using SDN.Purchasing.Services;
    using SDN.Purchasings.BL;
    using SDN.Purchasings.BLInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    public class PaymentToSupplierFormRepository:IPaymentToSupplierFormRepository
    {
        public PaymentToSupplierForm GetPaymentToSupplierDetails(string cashChequeNo)
        {
            IPaymentToSupplierBL psBL = new PaymentToSupplierBL();
            return psBL.GetPaymentToSupplierDetails(cashChequeNo);
        }
        public PaymentToSupplierForm GetNewPS(int? SupplierID)
        {
            IPaymentToSupplierBL psBL = new PaymentToSupplierBL();
            return psBL.GetNewPS(SupplierID);
        }

        public int SavePaymentToSupplier(PaymentToSupplierForm psForm)
        {
            IPaymentToSupplierBL psBL = new PaymentToSupplierBL();
            return psBL.SavePaymentToSupplier(psForm);

        }
       public string GetCountOfPOSuppliers(out List<SupplierDetailEntity> lstSuppliers)
        {
            IPaymentToSupplierBL psBL = new PaymentToSupplierBL();
            return psBL.GetCountOfPOSuppliers(out lstSuppliers);
        }
        public string GetCountOfPISuppliers(out List<SupplierDetailEntity> lstSuppliers)
        {
            IPaymentToSupplierBL psBL = new PaymentToSupplierBL();
            return psBL.GetCountOfPISuppliers(out lstSuppliers);
        }
        public int UpdatePaymentToSupplier(PaymentToSupplierForm psForm)
        {
            IPaymentToSupplierBL psBL = new PaymentToSupplierBL();
            return psBL.UpdatePaymentToSupplier(psForm);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IPaymentToSupplierBL psBL = new PaymentToSupplierBL();
            return psBL.IsChequeNoPresent(cashChequeNo);
        }
        public string GetLastCashNo()
        {
            IPaymentToSupplierBL psBL = new PaymentToSupplierBL();
            return psBL.GetLastCashNo();
        }

       public List<AccountsEntity> GetAccountDetails()
        {
            IPaymentToSupplierBL psBL = new PaymentToSupplierBL();
            return psBL.GetAccountDetails();
        }
    }
}
