using SDN.Purchasings.BLInterface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BL
{
    using SDN.Purchasings.DAL;
    using SDN.Purchasings.DALInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    public class PaymentToSupplierBL : IPaymentToSupplierBL
    { 
        public PaymentToSupplierForm GetPaymentToSupplierDetails(string cashChequeNo)
        {
            IPaymentToSupplierDAl psDAL = new PaymentToSupplierDAl();
            return  psDAL.GetPaymentToSupplierDetails(cashChequeNo);
        }
       public bool IsChequeNoPresent(string cashChequeNo)
        {
            IPaymentToSupplierDAl psDAL = new PaymentToSupplierDAl();
            return psDAL.IsChequeNoPresent(cashChequeNo);
        }
        public PaymentToSupplierForm GetNewPS(int? SupplierID)
        {
            IPaymentToSupplierDAl psDAL = new PaymentToSupplierDAl();
            return psDAL.GetNewPS(SupplierID);
        }
        public int SavePaymentToSupplier(PaymentToSupplierForm psForm)
        {
            IPaymentToSupplierDAl psDAL = new PaymentToSupplierDAl();
            return psDAL.SavePaymentToSupplier(psForm);
        }
        public int UpdatePaymentToSupplier(PaymentToSupplierForm psForm)
        {
            IPaymentToSupplierDAl psDAL = new PaymentToSupplierDAl();
            return psDAL.UpdatePaymentToSupplier(psForm);
        }
        public string GetCountOfPOSuppliers(out List<SupplierDetailEntity> lstSuppliers)
        {
            IPaymentToSupplierDAl psDAL = new PaymentToSupplierDAl();
            return psDAL.GetCountOfPOSuppliers(out lstSuppliers);
        }
        public string GetCountOfPISuppliers(out List<SupplierDetailEntity> lstSuppliers)
        {
            IPaymentToSupplierDAl psDAL = new PaymentToSupplierDAl();
            return psDAL.GetCountOfPISuppliers(out lstSuppliers);
        }

        public string GetLastCashNo()
        {
            IPaymentToSupplierDAl psDAL = new PaymentToSupplierDAl();
            return psDAL.GetLastCashNo();
        }

        public List<AccountsEntity> GetAccountDetails()
        {
            IPaymentToSupplierDAl psDAL = new PaymentToSupplierDAl();
            return psDAL.GetAccountDetails();
        }
    }
}
