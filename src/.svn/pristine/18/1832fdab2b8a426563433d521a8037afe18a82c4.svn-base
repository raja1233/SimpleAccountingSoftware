
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BLInterface
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    public interface IPaymentToSupplierBL
    {
        List<AccountsEntity> GetAccountDetails();
        string GetCountOfPOSuppliers(out List<SupplierDetailEntity> lstSuppliers);
        string GetCountOfPISuppliers(out List<SupplierDetailEntity> lstSuppliers);
        PaymentToSupplierForm GetNewPS(int? SupplierID);
        bool IsChequeNoPresent(string cashChequeNo);
        int SavePaymentToSupplier(PaymentToSupplierForm psForm);
        int UpdatePaymentToSupplier(PaymentToSupplierForm psForm);
        PaymentToSupplierForm GetPaymentToSupplierDetails(string cashChequeNo);
        string GetLastCashNo();
    }
}
